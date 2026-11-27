using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

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

                            Student student = new Student(Convert.ToInt32(reader["userId"]), Convert.ToInt32(reader["studentId"]), reader["fullName"].ToString(), reader["studentNumber"].ToString(),
                            reader["ueGmail"].ToString(), reader["year"].ToString(), reader["program"].ToString(), passwordHash);

                            return student;
                        }
                    }
                }
            }

            return null;
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

        public int GetTutorIdByUserId(int userId)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = "SELECT tutorId FROM tutor WHERE userId = @userId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    object result = command.ExecuteScalar();

                    return result == null || result == DBNull.Value
                        ? 0
                        : Convert.ToInt32(result);
                }
            }
        }



        public Student GetStudentById(int userId)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"SELECT s.studentId, u.userId, u.fullName, u.studentNumber, u.ueGmail, u.year, u.program, u.password FROM student s
                INNER JOIN user u ON s.userId = u.userId WHERE u.userId = @userId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Student(Convert.ToInt32(reader["userId"]), Convert.ToInt32(reader["studentId"]), reader["fullName"].ToString(),
                            reader["studentNumber"].ToString(), reader["ueGmail"].ToString(), reader["year"].ToString(), reader["program"].ToString(), reader["password"].ToString());
                        }
                    }
                }
            }

            return null;
        }

        public Tutor GetTutorById(int tutorId)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"SELECT t.tutorId, u.userId, u.fullName, u.studentNumber, u.ueGmail, u.year, u.program, u.password, t.credentials,
                t.subjects, t.availability, t.rating FROM tutor t INNER JOIN user u ON t.userId = u.userId WHERE t.tutorId = @tutorId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tutorId", tutorId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Tutor(Convert.ToInt32(reader["userId"]), Convert.ToInt32(reader["tutorId"]), reader["fullName"].ToString(), reader["studentNumber"].ToString(),
                            reader["ueGmail"].ToString(), reader["year"].ToString(), reader["program"].ToString(), reader["password"].ToString(),
                            reader["subjects"].ToString(), reader["availability"].ToString(), reader["credentials"].ToString(),
                            Convert.ToDouble(reader["rating"]));
                        }
                    }
                }
            }

            return null;
        }

        public int GetBookedSessionCount(int userId)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                string userQuery4 = @"SELECT COUNT(*) FROM booking b INNER JOIN student s ON b.studentId = s.studentId INNER JOIN session se ON b.sessionId = se.sessionId WHERE s.userId = @userId AND b.bookingStatus = 'Accepted'  
                AND se.startDateTime > NOW() AND se.sessionStatus != 'Cancelled'";

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

                string query = @"SELECT COUNT(DISTINCT se.sessionId) FROM booking b INNER JOIN student s ON b.studentId = s.studentId
                INNER JOIN session se ON b.sessionId = se.sessionId WHERE s.userId = @userId AND b.bookingStatus = 'Accepted'
                AND se.sessionStatus = 'Completed'";

                using (MySqlCommand command = new MySqlCommand(query, connection))
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

        public bool AddNotification(int userId, string message)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"INSERT INTO notification (message, userId) VALUES (@message, @userId)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@message", message);
                    command.Parameters.AddWithValue("@userId", userId);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public void NotifyAllUsers(string message)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = "SELECT userId FROM `user`";

                List<int> userIds = new List<int>();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userIds.Add(Convert.ToInt32(reader["userId"]));
                        }
                    }
                }

                foreach (int userId in userIds)
                {
                    AddNotification(userId, message);
                }
            }
        }

        public User GetUserProfile(int userId)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"SELECT u.userId, u.fullName, u.studentNumber, u.ueGmail, u.year, u.program, u.password, s.studentId,
                t.tutorId, t.credentials, t.subjects, t.rating, t.availability FROM user u LEFT JOIN student s ON u.userId = s.userId
                LEFT JOIN tutor t ON u.userId = t.userId WHERE u.userId = @userId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["userId"]);
                            string fullName = reader["fullName"].ToString();
                            string studentNumber = reader["studentNumber"].ToString();
                            string email = reader["ueGmail"].ToString();
                            string year = reader["year"].ToString();
                            string program = reader["program"].ToString();
                            string passwordHash = reader["password"].ToString();

                            if (reader["tutorId"] != DBNull.Value)
                            {
                                return new Tutor(id, Convert.ToInt32(reader["tutorId"]), fullName, studentNumber, email,
                                year, program, passwordHash, reader["subjects"].ToString(), reader["availability"].ToString(), reader["credentials"].ToString(),
                                Convert.ToDouble(reader["rating"]));
                            }

                            return new Student(id, Convert.ToInt32(reader["studentId"]), fullName, studentNumber, email, year, program, passwordHash);
                        }
                    }
                }
            }

            return null;
        }

        public bool UpdateStudentProfile(Student student)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string updateQuery = @"UPDATE user SET fullName = @fullName, ueGmail = @ueGmail, year = @year, program = @program WHERE userId = @userId";
                using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@userId", student.UserId);
                    updateCommand.Parameters.AddWithValue("@fullName", student.FullName);
                    updateCommand.Parameters.AddWithValue("@ueGmail", student.UEGmail);
                    updateCommand.Parameters.AddWithValue("@year", student.Year);
                    updateCommand.Parameters.AddWithValue("@program", student.Program);

                    return updateCommand.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateTutorProfile(Tutor tutor)
        {
            if (tutor == null)
            {
                return false;
            }

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"UPDATE tutor SET subjects = @subjects, availability = @availability, credentials = @credentials
                WHERE tutorId = @tutorId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@subjects", tutor.Subjects);
                    command.Parameters.AddWithValue("@availability", tutor.Availability);
                    command.Parameters.AddWithValue("@credentials", tutor.Credentials);
                    command.Parameters.AddWithValue("@tutorId", tutor.TutorId);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool SubmitRating(Rating rating)
        {
            if (rating == null)
                return false;

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"INSERT INTO rating (reviewText, rating, tutorId, studentId, sessionId)
                VALUES (@reviewText, @rating, @tutorId, @studentId, @sessionId)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@reviewText", string.IsNullOrWhiteSpace(rating.ReviewText) ? (object)DBNull.Value : rating.ReviewText);

                    command.Parameters.AddWithValue("@rating", rating.RatingValue);
                    command.Parameters.AddWithValue("@tutorId", rating.TutorId);
                    command.Parameters.AddWithValue("@studentId", rating.StudentId);
                    command.Parameters.AddWithValue("@sessionId", rating.SessionId);

                    bool success = command.ExecuteNonQuery() > 0;

                    if (success)
                    {
                        Tutor tutor = new UserRepository()
                            .GetTutorById(rating.TutorId);

                        return UpdateTutorRating(tutor);
                    }

                    return false;
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

        public bool UpdateTutorRating(Tutor tutor)
        {
            if (tutor == null) return false;

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"UPDATE tutor SET rating = (SELECT COALESCE(AVG(rating), 0)
                FROM rating WHERE tutorId = @tutorId) WHERE tutorId = @tutorId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tutorId", tutor.TutorId);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public Tutor CreateTutor(Tutor tutor)
        {
            if (tutor == null)
            {
                return null;
            }

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"INSERT INTO tutor (userId, credentials, rating, subjects, availability) VALUES
                (@userId, @credentials, @rating, @subjects, @availability); SELECT LAST_INSERT_ID();";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", tutor.UserId);
                    command.Parameters.AddWithValue("@credentials", tutor.Credentials);
                    command.Parameters.AddWithValue("@rating", tutor.Rating);
                    command.Parameters.AddWithValue("@subjects", tutor.Subjects);
                    command.Parameters.AddWithValue("@availability", tutor.Availability);

                    int newTutorId = Convert.ToInt32(command.ExecuteScalar());

                    return new Tutor(tutor.UserId, newTutorId, tutor.FullName, tutor.StudentNumber, tutor.UEGmail, tutor.Year,
                    tutor.Program, tutor.PasswordHash, tutor.Subjects, tutor.Availability, tutor.Credentials, tutor.Rating);
                }
            }
        }

        public DataTable GetPendingTutorRequests(Tutor tutor)
        {
            DataTable requests = new DataTable();

            if (tutor == null)
                return requests;

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"SELECT st.sessionTutorId, st.sessionId, st.tutorId, st.requestStatus, s.subject, s.topic,
                s.startDateTime, s.endDateTime, s.location, u.fullName AS creatorName, u.userId AS creatorUserId
                FROM sessionTutor st INNER JOIN session s ON st.sessionId = s.sessionId LEFT JOIN `user` u ON
                (s.creatorStudentId IS NOT NULL AND u.userId = (SELECT userId FROM student WHERE studentId = s.creatorStudentId))
                OR (s.creatorTutorId IS NOT NULL AND u.userId = (SELECT userId FROM tutor WHERE tutorId = s.creatorTutorId))
                WHERE st.tutorId = @tutorId AND st.requestStatus = 'Pending' ORDER BY s.startDateTime ASC";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tutorId", tutor.TutorId);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(requests);
                    }
                }
            }

            return requests;
        }

        public bool RespondToTutorRequest(int sessionTutorId, Tutor tutor, string response)
        {
            if (tutor == null ||
                (response != "Accepted" && response != "Declined"))
                return false;

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"UPDATE sessionTutor SET requestStatus = @response WHERE sessionTutorId = @sessionTutorId
                AND tutorId = @tutorId AND requestStatus = 'Pending'";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@response", response);
                    command.Parameters.AddWithValue("@sessionTutorId", sessionTutorId);
                    command.Parameters.AddWithValue("@tutorId", tutor.TutorId);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Rating> GetTutorReviews(Tutor tutor)
        {
            List<Rating> reviews = new List<Rating>();

            if (tutor == null)
                return reviews;

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"SELECT ratingId, sessionId, studentId, tutorId, rating, reviewText
                FROM rating WHERE tutorId = @tutorId ORDER BY ratingId DESC";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tutorId", tutor.TutorId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rating rating = new Rating(
                                Convert.ToInt32(reader["ratingId"]),
                                Convert.ToInt32(reader["sessionId"]),
                                Convert.ToInt32(reader["studentId"]),
                                Convert.ToInt32(reader["tutorId"]),
                                Convert.ToDouble(reader["rating"]),
                                reader["reviewText"] == DBNull.Value ? "" : reader["reviewText"].ToString()
                            );

                            reviews.Add(rating);
                        }
                    }
                }
            }

            return reviews;
        }
    }
}
