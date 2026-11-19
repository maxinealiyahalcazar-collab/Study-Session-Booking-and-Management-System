using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Study_Session
{
    public class UserRepository
    {

        public int RegisterUser(string fullName, string studentNumber, string ueGmail, string year, string program, string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int userId;

                        string userQuery = @"INSERT INTO user (fullName, studentNumber, ueGmail, year, program, password) VALUES (@fullName, @studentNumber, @ueGmail, @year, @program, @password)";
                        ;
                        using (MySqlCommand userCommand = new MySqlCommand(userQuery, connection, transaction))
                        {
                            userCommand.Parameters.AddWithValue("@fullName", fullName);
                            userCommand.Parameters.AddWithValue("@studentNumber", studentNumber);
                            userCommand.Parameters.AddWithValue("@ueGmail", ueGmail);
                            userCommand.Parameters.AddWithValue("@year", year);
                            userCommand.Parameters.AddWithValue("@program", program);
                            userCommand.Parameters.AddWithValue("@password", passwordHash);

                            userCommand.ExecuteNonQuery();

                            userId = Convert.ToInt32(userCommand.LastInsertedId);
                        }

                        string studentQuery = @"INSERT INTO student (userId) VALUES (@userId)";

                        using (MySqlCommand studentCommand = new MySqlCommand(studentQuery, connection, transaction))
                        {
                            studentCommand.Parameters.AddWithValue("@userId", userId);
                            studentCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return userId;
                    }

                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error registering user: " + ex.Message);
                    }

                }

            }

        }

        public int LoginUser(string studentNumber, string password)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string userQuery2 = @"SELECT userId, password FROM user WHERE studentNumber = @studentNumber";

                using (MySqlCommand command = new MySqlCommand(userQuery2, connection))
                {
                    command.Parameters.AddWithValue("@studentNumber", studentNumber);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = reader.GetInt32("userId");
                            string passwordHash = reader.GetString("password");

                            if (BCrypt.Net.BCrypt.Verify(password, passwordHash))
                            {
                                return userId;
                            }
                        }
                    }
                }
            }
            return 0;
        }

        public string GetUserFullName(int userId)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                string userQuery3 = @"SELECT fullName FROM user WHERE userId = @userId";

                using (MySqlCommand command = new MySqlCommand(userQuery3, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    object result = command.ExecuteScalar();
                    return Convert.ToString(result) ?? "Student";
                }
            }
        }

        public int GetStudentIdByUserId(int userId)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                string query = @"SELECT studentId FROM student WHERE userId = @userId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    return result == null ? 0 : Convert.ToInt32(result);
                }
            }
        }

        public int GetBookedSessionCount(int userId)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                string userQuery4 = @"SELECT COUNT(*) FROM booking b INNER JOIN student s ON b.studentId = s.studentId WHERE s.userId = @userId AND b.bookingStatus = 'Booked'";

                using (MySqlCommand command = new MySqlCommand(userQuery4, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    object result = command.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
        }

        public int GetWaitlistedSessionCount(int userId)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                string userQuery5 = @"SELECT COUNT(*) FROM booking b INNER JOIN student s ON b.studentId = s.studentId WHERE s.userId = @userId AND b.bookingStatus = 'Waitlisted'";

                using (MySqlCommand command = new MySqlCommand(userQuery5, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    object result = command.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
        }

        public int GetCompletedSessionCount(int userId)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                string userQuery6 = @"SELECT COUNT(DISTINCT se.sessionId) FROM booking b INNER JOIN student s ON b.studentId = s.studentId 
                INNER JOIN session se ON b.sessionId = se.sessionId WHERE s.userId = @userId AND b.bookingStatus = 'Booked' AND se.sessionStatus = 'Completed'";

                using (MySqlCommand command = new MySqlCommand(userQuery6, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    object result = command.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
        }

        public DataTable GetNotifications(int userId)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                string userQuery7 = @"SELECT message, createdAt FROM notification WHERE userId = @userId ORDER BY createdAt DESC";

                using (MySqlCommand command = new MySqlCommand(userQuery7, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable notifications = new DataTable();
                        adapter.Fill(notifications);
                        return notifications;
                    }
                }
            }
        }

        public DataTable GetUserProfile(int userId)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                string userQuery8 = @"SELECT u.fullName, u.ueGmail, u.year, u.program, t.credentials, t.subjects, t.rating, t.availability FROM user u LEFT JOIN tutor t ON u.userId = t.userId
                WHERE u.userId = @userId";
                using (MySqlCommand command = new MySqlCommand(userQuery8, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable profile = new DataTable();
                        adapter.Fill(profile);
                        return profile;
                    }
                }
            }
        }

        public bool updateStudentProfile(int userId, string fullName, string ueGmail, string year, string program)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string updateQuery = @"UPDATE user SET fullName = @fullName, ueGmail = @ueGmail, year = @year, program = @program WHERE userId = @userId";
                using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@userId", userId);
                    updateCommand.Parameters.AddWithValue("@fullName", fullName);
                    updateCommand.Parameters.AddWithValue("@ueGmail", ueGmail);
                    updateCommand.Parameters.AddWithValue("@year", year);
                    updateCommand.Parameters.AddWithValue("@program", program);

                    return updateCommand.ExecuteNonQuery() > 0;
                }
            }
        }

        public int createStudentSession(int userId, string subject, string topic, DateTime startDateTime, DateTime endDateTime, int requiredTutors, int slots, string location, HashSet<int> selectedTutorIds)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                int studentId;

                string studentQuery = @"SELECT studentId FROM student WHERE userId = @userId";

                using (MySqlCommand studentCommand = new MySqlCommand(studentQuery, connection))
                {
                    studentCommand.Parameters.AddWithValue("@userId", userId);
                    object result = studentCommand.ExecuteScalar();

                    if (result == null)
                    {
                        return 0;
                    }

                    studentId = Convert.ToInt32(result);
                }

                string studentQuery2 = @"INSERT INTO session (creatorStudentId, topic, subject, startDateTime, endDateTime, requiredTutors, slots, location) VALUES (@studentId, @topic, @subject, @startDateTime, @endDateTime, @requiredTutors, @slots, @location)";

                using (MySqlCommand studentCommand2 = new MySqlCommand(studentQuery2, connection))
                {
                    studentCommand2.Parameters.AddWithValue("@studentId", studentId);
                    studentCommand2.Parameters.AddWithValue("@topic", topic);
                    studentCommand2.Parameters.AddWithValue("@subject", subject);
                    studentCommand2.Parameters.AddWithValue("@startDateTime", startDateTime);
                    studentCommand2.Parameters.AddWithValue("@endDateTime", endDateTime);
                    studentCommand2.Parameters.AddWithValue("@slots", slots);
                    studentCommand2.Parameters.AddWithValue("@requiredTutors", requiredTutors);
                    studentCommand2.Parameters.AddWithValue("@location", location);
                    studentCommand2.ExecuteNonQuery();

                    int sessionId = Convert.ToInt32(studentCommand2.LastInsertedId);
                    string bookingQuery = @"INSERT INTO booking (studentId, sessionId, bookingStatus, paymentStatus, expectation) VALUES (@studentId, @sessionId, 'Accepted', 'Unpaid', '')";

                    foreach (int tutorId in selectedTutorIds)
                    { string tutorQuery = @"INSERT INTO sessionTutor (sessionId, tutorId, requestStatus) VALUES (@sessionId, @tutorId, 'Pending')";

                        using (MySqlCommand tutorCommand = new MySqlCommand(tutorQuery, connection))
                        {
                            tutorCommand.Parameters.AddWithValue("@sessionId", sessionId);
                            tutorCommand.Parameters.AddWithValue("@tutorId", tutorId);

                            tutorCommand.ExecuteNonQuery();
                        }
                    }

                    using (MySqlCommand bookingCommand = new MySqlCommand(bookingQuery, connection))
                    {
                        bookingCommand.Parameters.AddWithValue("@studentId", studentId);
                        bookingCommand.Parameters.AddWithValue("@sessionId", sessionId);

                        bookingCommand.ExecuteNonQuery();
                        return sessionId;
                    }
                }

            }
        }

        public string CompleteCreatorBooking(int userId, int sessionId, string expectation)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string bookingQuery = @"UPDATE booking b JOIN student st ON b.studentId = st.studentId SET b.paymentStatus = 'Paid', b.expectation = @expectation WHERE st.userId = @userId
                AND b.sessionId = @sessionId AND b.bookingStatus = 'Accepted' AND b.paymentStatus = 'Unpaid'";

                using (MySqlCommand command = new MySqlCommand(bookingQuery, connection))
                {
                    command.Parameters.AddWithValue("@expectation", expectation);
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@sessionId", sessionId);

                    return command.ExecuteNonQuery() > 0 ? "Joined" : "BookingNotFound";
                }
            }
        }

        public DataRow GetSessionById(int sessionId)
        {
            DataTable sessionTable = new DataTable();

            using (MySqlConnection connection = Database.GetConnection())
            {
                string sessionQuery = @"SELECT sessionId, subject, topic, startDateTime, endDateTime, slots, slots AS availableSlots, requiredTutors, location, creatorStudentId, creatorTutorId
                FROM session WHERE sessionId = @sessionId";

                using (MySqlCommand command = new MySqlCommand(sessionQuery, connection))
                {
                    command.Parameters.AddWithValue("@sessionId", sessionId);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(sessionTable);
                    }
                }
            }

            if (sessionTable.Rows.Count > 0)
            {
                return sessionTable.Rows[0];
            }

            return null;
        }
        public DataTable GetAvailableTutors()
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string tutorQuery = @"SELECT t.tutorId, u.userId, u.fullName, u.ueGmail, u.year, u.program, t.credentials, t.subjects, t.rating, t.availability FROM tutor t INNER JOIN user u ON t.userId = u.userId ORDER BY u.fullname ASC";

                using (MySqlCommand tutorCommand = new MySqlCommand(tutorQuery, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(tutorCommand))
                    {
                        DataTable tutors = new DataTable();
                        adapter.Fill(tutors);
                        return tutors;
                    }
                }
            }
        }


        public DataTable GetBrowseSessions(int userId)
        {
            DataTable sessions = new DataTable();

            using (MySqlConnection connection = Database.GetConnection())
            {
                string query = @"SELECT s.sessionId, s.subject, s.topic, s.startDateTime, s.endDateTime, s.slots, s.requiredTutors, s.location, s.creatorStudentId, s.creatorTutorId,
                COUNT(b.bookingId) AS occupiedSlots, (s.slots - COUNT(b.bookingId)) AS availableSlots, (SELECT COUNT(*) FROM booking wb WHERE wb.sessionId = s.sessionId AND wb.bookingStatus = 'Waitlisted') AS waitlistedCount FROM session s LEFT JOIN booking b ON s.sessionId = b.sessionId
                AND b.bookingStatus = 'Accepted' WHERE s.sessionStatus IN ('Open', 'Full') AND s.startDateTime > NOW() AND NOT (s.slots <= (SELECT COUNT(*) FROM booking ab WHERE ab.sessionId = s.sessionId
                AND ab.bookingStatus = 'Accepted') AND (SELECT COUNT(*) FROM booking wb WHERE wb.sessionId = s.sessionId AND wb.bookingStatus = 'Waitlisted') >= 5) AND s.CreatorStudentId NOT IN (SELECT studentId FROM student WHERE userId = @userId) AND s.sessionId NOT IN (SELECT sessionId
                FROM booking WHERE studentId = (SELECT studentId FROM student WHERE userId = @userId))
                GROUP BY s.sessionId, s.subject, s.topic, s.startDateTime, s.endDateTime, s.slots, s.requiredTutors, s.location, s.creatorStudentId, s.creatorTutorId ORDER BY s.startDateTime ASC";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(sessions);
                    }
                }
            }

            return sessions;
        }


        public DataTable GetAcceptedSessionTutors(int sessionId)
        {
            DataTable tutors = new DataTable();

            using (MySqlConnection conn = Database.GetConnection())
            {
                string query = @" SELECT t.tutorId, u.fullName, t.credentials, t.subjects, t.rating FROM sessionTutor st INNER JOIN tutor t ON st.tutorId = t.tutorId INNER JOIN `user` u ON t.userId = u.userId
                WHERE st.sessionId = @sessionId AND st.requestStatus IN ('Pending', 'Accepted') ORDER BY u.fullName ASC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@sessionId", sessionId);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(tutors);
                    }
                }
            }

            return tutors;
        }

        public string JoinSession(int userId, int sessionId, string expectation)
        {
            int studentId;

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"SELECT studentId FROM student WHERE userId = @userId";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    object result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        return "Student Not Found";
                    }

                    studentId = Convert.ToInt32(result);
                }
            }

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                string query = @"SELECT COUNT(*) FROM booking WHERE studentId = @studentId AND sessionId = @sessionId AND bookingStatus IN ('Pending', 'Accepted', 'Waitlisted')";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);
                    command.Parameters.AddWithValue("@sessionId", sessionId);

                    int existingBooking = Convert.ToInt32(command.ExecuteScalar());

                    if (existingBooking > 0)
                    {
                        return "Already Booked";
                    }
                }

                using (MySqlConnection connection2 = Database.GetConnection())
                {
                    connection2.Open();

                    string query2 = @"SELECT s.slots, COUNT(b.bookingId) AS occupiedSlots, s.sessionStatus FROM session s LEFT JOIN booking b ON s.sessionId = b.sessionId
                    AND b.bookingStatus = 'Accepted' WHERE s.sessionId = @sessionId GROUP BY s.sessionId, s.slots, s.sessionStatus";

                    using (MySqlCommand command2 = new MySqlCommand(query2, connection2))
                    {
                        command2.Parameters.AddWithValue("@sessionId", sessionId);

                        using (MySqlDataReader reader = command2.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                return "SessionNotFound";
                            }

                            int slots = Convert.ToInt32(reader["slots"]);
                            int occupiedSlots = Convert.ToInt32(reader["occupiedSlots"]);
                            string status = reader["sessionStatus"].ToString();

                            if (status != "Open")
                            {
                                return "Session Unavailable";
                            }

                            if (occupiedSlots >= slots)
                            {
                                using (MySqlConnection waitlistConnection = Database.GetConnection())
                                {
                                    waitlistConnection.Open();

                                    string positionQuery = @"SELECT COUNT(*) FROM booking WHERE sessionId = @sessionId AND bookingStatus = 'Waitlisted'";

                                    int position;

                                    using (MySqlCommand positionCommand = new MySqlCommand(positionQuery, waitlistConnection))
                                    {
                                        positionCommand.Parameters.AddWithValue("@sessionId", sessionId);

                                        position = Convert.ToInt32(positionCommand.ExecuteScalar()) + 1;
                                    }

                                    string insertQuery = @" INSERT INTO booking (studentId, sessionId, bookingStatus, paymentStatus, waitlistPosition, expectation)
                                    VALUES (@studentId, @sessionId, 'Waitlisted', 'Unpaid', @position, @expectation)";

                                    using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, waitlistConnection))
                                    {
                                        insertCommand.Parameters.AddWithValue("@studentId", studentId);
                                        insertCommand.Parameters.AddWithValue("@sessionId", sessionId);
                                        insertCommand.Parameters.AddWithValue("@position", position);
                                        insertCommand.Parameters.AddWithValue("@expectation", expectation);

                                        insertCommand.ExecuteNonQuery();
                                    }
                                }

                                return "Waitlisted";
                            }
                        }


                        using (MySqlConnection connection3 = Database.GetConnection())
                        {
                            connection3.Open();

                            string query3 = @"INSERT INTO booking (studentId, sessionId, bookingStatus, paymentStatus, expectation) VALUES (@studentId, @sessionId, 'Accepted', 'Paid', @expectation)";

                            using (MySqlCommand command3 = new MySqlCommand(query3, connection3))
                            {
                                command3.Parameters.AddWithValue("@studentId", studentId);
                                command3.Parameters.AddWithValue("@sessionId", sessionId);
                                command3.Parameters.AddWithValue("@expectation", expectation);

                                command3.ExecuteNonQuery();
                            }
                        }

                        return "Joined";
                    }
                }
            }
        }

        public string JoinWaitlist(int userId, int sessionId, string expectation)
        {
            int studentId;

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"SELECT studentId FROM student WHERE userId = @userId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    object result = command.ExecuteScalar();

                    if (result == null)
                    {
                        return "StudentNotFound";
                    }

                    studentId = Convert.ToInt32(result);
                }
            }

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"SELECT COUNT(*) FROM booking WHERE studentId = @studentId AND sessionId = @sessionId AND bookingStatus IN ('Pending', 'Accepted', 'Waitlisted')";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);
                    command.Parameters.AddWithValue("@sessionId", sessionId);

                    int existingBooking = Convert.ToInt32(command.ExecuteScalar());

                    if (existingBooking > 0)
                    {
                        return "AlreadyBooked";
                    }
                }
            }

            int slots;
            int occupiedSlots;
            int waitlistedCount;

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"SELECT s.slots, COUNT(CASE WHEN b.bookingStatus = 'Accepted' THEN 1 END) AS occupiedSlots, COUNT(CASE WHEN b.bookingStatus = 'Waitlisted' THEN 1 END) AS waitlistedCount
                     FROM session s LEFT JOIN booking b ON s.sessionId = b.sessionId WHERE s.sessionId = @sessionId GROUP BY s.sessionId, s.slots";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sessionId", sessionId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return "SessionNotFound";
                        }

                        slots = Convert.ToInt32(reader["slots"]);
                        occupiedSlots = Convert.ToInt32(reader["occupiedSlots"]);
                        waitlistedCount = Convert.ToInt32(reader["waitlistedCount"]);

                        if (occupiedSlots < slots)
                        {
                            return "SlotsAvailable";
                        }

                        if (waitlistedCount >= 5)
                        {
                            return "WaitlistFull";
                        }

                        int waitlistPosition = waitlistedCount + 1;

                        using (MySqlConnection connection2 = Database.GetConnection())
                        {
                            connection2.Open();

                            string query2 = @"INSERT INTO booking (studentId, sessionId, bookingStatus, paymentStatus, waitlistPosition, expectation)
                            VALUES (@studentId, @sessionId, 'Waitlisted', 'Paid', @waitlistPosition, @expectation)";

                            using (MySqlCommand command2 = new MySqlCommand(query, connection))
                            {
                                command2.Parameters.AddWithValue("@studentId", studentId);
                                command2.Parameters.AddWithValue("@sessionId", sessionId);
                                command2.Parameters.AddWithValue("@waitlistPosition", waitlistPosition);
                                command2.Parameters.AddWithValue("@expectation", expectation);

                                command.ExecuteNonQuery();
                            }
                        }

                        return "Waitlisted";
                    }
                }
            }
        }


        public bool CancelBooking(int userId, int sessionId)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string cancelQuery = @"UPDATE booking SET bookingStatus = 'Withdrawn' WHERE sessionId = @sessionId AND studentId = 
                        (SELECT studentId FROM student WHERE userId = @userId) AND bookingStatus = 'Accepted'";

                        int rowsAffected;

                        using (MySqlCommand command = new MySqlCommand(cancelQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@sessionId", sessionId);
                            command.Parameters.AddWithValue("@userId", userId);

                            rowsAffected = command.ExecuteNonQuery();
                        }

                        if (rowsAffected == 0)
                        {
                            transaction.Rollback();
                            return false;
                        }

                        int? nextBookingId = null;
                        int nextPosition = 0;

                        string waitlistQuery = @" SELECT bookingId, waitlistPosition FROM booking WHERE sessionId = @sessionId AND bookingStatus = 'Waitlisted'
                        ORDER BY waitlistPosition ASC LIMIT 1 FOR UPDATE";

                        using (MySqlCommand command = new MySqlCommand(waitlistQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@sessionId", sessionId);

                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    nextBookingId = Convert.ToInt32(reader["bookingId"]);
                                    nextPosition = Convert.ToInt32(reader["waitlistPosition"]);
                                }
                            }
                        }

                        if (nextBookingId.HasValue)
                        {
                            string promoteQuery = @"UPDATE booking SET bookingStatus = 'Accepted', waitlistPosition = NULL WHERE bookingId = @bookingId";

                            using (MySqlCommand command = new MySqlCommand(promoteQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@bookingId", nextBookingId.Value);
                                command.ExecuteNonQuery();
                            }

                            string shiftQuery = @"UPDATE booking SET waitlistPosition = waitlistPosition - 1 WHERE sessionId = @sessionId AND bookingStatus = 'Waitlisted'
                            AND waitlistPosition > @nextPosition";

                            using (MySqlCommand command = new MySqlCommand(shiftQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@sessionId", sessionId);
                                command.Parameters.AddWithValue("@nextPosition", nextPosition);
                                command.ExecuteNonQuery();
                            }
                        }

                        else
                        {
                            string updateSessionQuery = @" UPDATE session SET sessionStatus = 'Open' WHERE sessionId = @sessionId";

                            using (MySqlCommand command = new MySqlCommand(updateSessionQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@sessionId", sessionId);
                                command.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }


        public bool CancelSession(int sessionId)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string bookingQuery = @"UPDATE booking SET bookingStatus = 'Cancelled' WHERE sessionId = @sessionId AND bookingStatus IN ('Accepted', 'Waitlisted')";

                        using (MySqlCommand bookingCommand = new MySqlCommand(bookingQuery, connection, transaction))
                        {
                            bookingCommand.Parameters.AddWithValue("@sessionId", sessionId);
                            bookingCommand.ExecuteNonQuery();
                        }

                        string sessionQuery = @"UPDATE session SET sessionStatus = 'Cancelled' WHERE sessionId = @sessionId";

                        using (MySqlCommand sessionCommand = new MySqlCommand(sessionQuery, connection, transaction))
                        {
                            sessionCommand.Parameters.AddWithValue("@sessionId", sessionId);
                            int rowsAffected = sessionCommand.ExecuteNonQuery();

                            if (rowsAffected == 0)
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }

                        transaction.Commit();
                        return true;
                    }

                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public DataTable GetMySessions(int userId)
        {
            DataTable sessions = new DataTable();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"SELECT DISTINCT s.sessionId, s.subject, s.topic, s.startDateTime, s.endDateTime, s.slots, s.requiredTutors, s.location, s.creatorStudentId, s.creatorTutorId,
                CASE WHEN s.creatorStudentId = (SELECT studentId FROM student WHERE userId = @userId) THEN 1 ELSE 0 END AS isCreator, s.sessionStatus FROM session s WHERE
                (s.creatorStudentId = (SELECT studentId FROM student WHERE userId = @userId) OR EXISTS (SELECT 1 FROM booking b WHERE b.sessionId = s.sessionId
                AND b.studentId = (SELECT studentId FROM student WHERE userId = @userId) AND b.bookingStatus = 'Accepted'))
                AND s.sessionStatus != 'Cancelled' ORDER BY s.startDateTime ASC";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(sessions);
                    }
                }
            }

            return sessions;
        }

        public bool UpdateStudentSession(int sessionId, string subject, string topic, DateTime startDateTime, DateTime endDateTime, int slots,
        int requiredTutors, string location)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                string query = @"UPDATE session SET subject = @subject, topic = @topic, startDateTime = @startDateTime,
                endDateTime = @endDateTime, slots = @slots, requiredTutors = @requiredTutors,
                location = @location WHERE sessionId = @sessionId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sessionId", sessionId);
                    command.Parameters.AddWithValue("@subject", subject);
                    command.Parameters.AddWithValue("@topic", topic);
                    command.Parameters.AddWithValue("@startDateTime", startDateTime);
                    command.Parameters.AddWithValue("@endDateTime", endDateTime);
                    command.Parameters.AddWithValue("@slots", slots);
                    command.Parameters.AddWithValue("@requiredTutors", requiredTutors);
                    command.Parameters.AddWithValue("@location", location);

                    connection.Open();

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool CompleteSession(int sessionId)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                string query = @"UPDATE session SET sessionStatus = 'Completed' WHERE sessionId = @sessionId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sessionId", sessionId);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool AddRating(int tutorId, int studentId, int sessionId, decimal rating, string reviewText)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                string query = @"INSERT INTO rating (tutorId, studentId, sessionId, rating, reviewText) VALUES (@tutorId, @studentId, @sessionId, @rating, @reviewText)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tutorId", tutorId);
                    command.Parameters.AddWithValue("@studentId", studentId);
                    command.Parameters.AddWithValue("@sessionId", sessionId);
                    command.Parameters.AddWithValue("@rating", rating);
                    command.Parameters.AddWithValue("@reviewText", reviewText);

                    connection.Open();

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool HasAlreadyRated(int studentId, int tutorId, int sessionId)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                string query = @"SELECT COUNT(*) FROM rating WHERE studentId = @studentId AND tutorId = @tutorId AND sessionId = @sessionId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);
                    command.Parameters.AddWithValue("@tutorId", tutorId);
                    command.Parameters.AddWithValue("@sessionId", sessionId);

                    connection.Open();

                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        public void CancelUnderstaffedSessions()
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                string query = @"UPDATE session s SET s.sessionStatus = 'Cancelled' WHERE s.sessionStatus <> 'Cancelled'
                AND s.startDateTime <= NOW() AND (SELECT COUNT(*) FROM sessionTutor st WHERE st.sessionId = s.sessionId
                AND st.requestStatus = 'Accepted') < GREATEST(COALESCE(s.requiredTutors, 0), 1)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool AddMaterial(int sessionId, string materialName, string description, string fileLink)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                string query = @"INSERT INTO material (sessionId, materialName, description, fileLink) VALUES
                (@sessionId, @materialName, @description, @fileLink)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sessionId", sessionId);
                    command.Parameters.AddWithValue("@materialName", materialName);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@fileLink", fileLink);

                    connection.Open();

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public DataTable GetMaterialsBySessionId(int sessionId)
        {
            DataTable materials = new DataTable();

            using (MySqlConnection connection = Database.GetConnection())
            {
                string query = @"SELECT materialId, materialName, description, fileLink FROM material
            WHERE sessionId = @sessionId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sessionId", sessionId);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(materials);
                    }
                }
            }

            return materials;
        }
    }
} 
