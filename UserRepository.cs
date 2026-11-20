using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Study_Session
{
    public class UserRepository
    {

        public Student RegisterUser(Student student)
        {
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
                            userCommand.Parameters.AddWithValue("@fullName", student.FullName);
                            userCommand.Parameters.AddWithValue("@studentNumber", student.StudentNumber);
                            userCommand.Parameters.AddWithValue("@ueGmail", student.UEGmail);
                            userCommand.Parameters.AddWithValue("@year", student.Year);
                            userCommand.Parameters.AddWithValue("@program", student.Program);
                            userCommand.Parameters.AddWithValue("@password", student.PasswordHash);

                            userCommand.ExecuteNonQuery();

                            userId = Convert.ToInt32(userCommand.LastInsertedId);
                        }

                        int studentId;

                        string studentQuery = @"INSERT INTO student (userId) VALUES (@userId)";

                        using (MySqlCommand studentCommand = new MySqlCommand(studentQuery, connection, transaction))
                        {
                            studentCommand.Parameters.AddWithValue("@userId", userId);
                            studentCommand.ExecuteNonQuery();
                            studentId = Convert.ToInt32(studentCommand.LastInsertedId);
                        }

                        transaction.Commit();
                        return new Student(userId, studentId, student.FullName, student.StudentNumber, student.UEGmail, student.Year, student.Program, student.PasswordHash);
                    }

                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error registering user: " + ex.Message);
                    }

                }

            }

        }

        public User LoginUser(string studentNumber, string password)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string userQuery2 = @"SELECT u.userId, s.studentId, u.fullName, u.studentNumber,
                u.ueGmail, u.year, u.program, u.password FROM user u INNER JOIN student s ON u.userId = s.userId
                WHERE u.studentNumber = @studentNumber";

                using (MySqlCommand command = new MySqlCommand(userQuery2, connection))
                {
                    command.Parameters.AddWithValue("@studentNumber", studentNumber);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string passwordHash = reader["password"].ToString();

                            if (BCrypt.Net.BCrypt.Verify(password, passwordHash))
                            {
                                Student student = new Student(Convert.ToInt32(reader["userId"]), Convert.ToInt32(reader["studentId"]), reader["fullName"].ToString(),
                                reader["studentNumber"].ToString(), reader["ueGmail"].ToString(), reader["year"].ToString(), reader["program"].ToString(),
                                passwordHash);

                                return student;
                            }
                        }
                    }
                }
            }

            return null;
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
    }
} 
