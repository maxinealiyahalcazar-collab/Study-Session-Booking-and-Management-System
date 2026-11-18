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

        public DataTable GetStudentProfile(int userId)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                string userQuery8 = @"SELECT fullName, ueGmail, year, program FROM user WHERE userId = @userId";
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

        public bool createStudentSession(int userId, string subject, string topic, DateTime startDateTime, DateTime endDateTime, int requiredTutors, int slots, string location)
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
                        return false;
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

                    return studentCommand2.ExecuteNonQuery() > 0;
                }

            }
        }

        public DataTable GetAvailableTutors()
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string tutorQuery = @"SELECT t.tutorId, u.userId, u.fullName, u.ueGmail, u.year, u.program, t.credentials, t.subjects, t.rating, t.availability FROM tutor t INNER JOIN user u ON t.userId = u.userId ORDER BY u.fullname ASC";

                using (MySqlCommand tutorCommand = new MySqlCommand(tutorQuery, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter (tutorCommand))
                    {
                        DataTable tutors = new DataTable();
                        adapter.Fill(tutors);
                        return tutors;
                    }
                }
            }
        }


public DataTable GetBrowseSessions()
        {
            DataTable sessions = new DataTable();

            using (MySqlConnection conn = Database.GetConnection())
            {
                string query = @"SELECT s.sessionId, s.subject, s.topic, s.startDateTime, s.endDateTime, s.slots, s.requiredTutors, s.location, s.creatorStudentId, s.creatorTutorId,
                COUNT(b.bookingId) AS occupiedSlots, (s.slots - COUNT(b.bookingId)) AS availableSlots FROM session s LEFT JOIN booking b ON s.sessionId = b.sessionId
                AND b.bookingStatus = 'Accepted' WHERE s.sessionStatus IN ('Open', 'Full') AND s.startDateTime > NOW()
                GROUP BY s.sessionId, s.subject, s.topic, s.startDateTime, s.endDateTime, s.slots, s.requiredTutors, s.location, s.creatorStudentId, s.creatorTutorId ORDER BY s.startDateTime ASC";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    adapter.Fill(sessions);
                }
            }

            return sessions;
        }

    }
} 
