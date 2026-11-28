using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Study_Session
{
    public class SessionRepository
    {
        public Session GetSessionById(int sessionId)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                string sessionQuery = @" SELECT s.sessionId, s.subject, s.topic, s.startDateTime, s.endDateTime, s.slots, s.requiredTutors,
                s.location, s.creatorStudentId, s.creatorTutorId, s.sessionStatus, (SELECT COUNT(*) FROM booking b
                WHERE b.sessionId = s.sessionId AND b.bookingStatus IN ('Accepted', 'Pending')) AS occupiedSlots, (s.slots - (SELECT COUNT(*)
                FROM booking b WHERE b.sessionId = s.sessionId AND b.bookingStatus IN ('Accepted', 'Pending'))) AS availableSlots, (SELECT COUNT(*)
                FROM booking wb WHERE wb.sessionId = s.sessionId AND wb.bookingStatus = 'Waitlisted') AS waitlistedCount FROM session s
                WHERE s.sessionId = @sessionId";

                using (MySqlCommand command = new MySqlCommand(sessionQuery, connection))
                {
                    command.Parameters.AddWithValue("@sessionId", sessionId);

                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Session session = new Session(Convert.ToInt32(reader["sessionId"]), reader["creatorStudentId"] == DBNull.Value ? null : Convert.ToInt32(reader["creatorStudentId"]),
                                reader["creatorTutorId"] == DBNull.Value ? null : Convert.ToInt32(reader["creatorTutorId"]), Convert.ToInt32(reader["requiredTutors"]), reader["subject"].ToString(),
                                reader["topic"].ToString(), Convert.ToDateTime(reader["startDateTime"]), Convert.ToDateTime(reader["endDateTime"]), Convert.ToInt32(reader["slots"]), reader["location"].ToString(),
                                reader["sessionStatus"].ToString(), Convert.ToInt32(reader["occupiedSlots"]), Convert.ToInt32(reader["availableSlots"]), Convert.ToInt32(reader["waitlistedCount"]));

                            return session;
                        }
                    }
                }
            }

            return null;
        }

        public int GetSessionCreatorUserId(int sessionId)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"SELECT COALESCE ((SELECT userId FROM student WHERE studentId = s.creatorStudentId),
                (SELECT userId FROM tutor WHERE tutorId = s.creatorTutorId)) FROM session s WHERE s.sessionId = @sessionId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sessionId", sessionId);

                    object result = command.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                        return 0;

                    return Convert.ToInt32(result);
                }
            }
        }

        public List<int> GetSessionParticipantUserIds(int sessionId)
        {
            List<int> userIds = new List<int>();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"SELECT st.userId FROM booking b INNER JOIN student st ON b.studentId = st.studentId WHERE b.sessionId = @sessionId
                AND b.bookingStatus = 'Accepted' UNION SELECT t.userId FROM sessionTutor st INNER JOIN tutor t ON st.tutorId = t.tutorId
                WHERE st.sessionId = @sessionId AND st.requestStatus = 'Accepted' UNION SELECT st.userId FROM session s INNER JOIN student st ON s.creatorStudentId = st.studentId
                WHERE s.sessionId = @sessionId UNION SELECT t.userId FROM session s INNER JOIN tutor t ON s.creatorTutorId = t.tutorId
                WHERE s.sessionId = @sessionId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sessionId", sessionId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userIds.Add(Convert.ToInt32(reader["userId"]));
                        }
                    }
                }
            }

            return userIds;
        }
        public List<Session> GetMySessions(int userId)
        {
            List<Session> sessions = new List<Session>();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"SELECT DISTINCT s.sessionId, s.subject, s.topic, s.startDateTime, s.endDateTime, s.slots, s.requiredTutors, s.location, s.creatorStudentId,
                s.creatorTutorId, s.sessionStatus, tu.fullname AS creatorTutorName FROM session s LEFT JOIN tutor t ON s.creatorTutorId = t.tutorId LEFT JOIN user tu ON t.userId = tu.userId WHERE
                (s.creatorStudentId = (SELECT studentId FROM student WHERE userId = @userId) OR EXISTS (SELECT 1 FROM booking b WHERE b.sessionId = s.sessionId
                AND b.studentId = (SELECT studentId FROM student WHERE userId = @userId)
                AND b.bookingStatus = 'Accepted')) AND s.sessionStatus != 'Cancelled' ORDER BY s.startDateTime ASC";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Session session = new Session(Convert.ToInt32(reader["sessionId"]), reader["creatorStudentId"] == DBNull.Value ? null : Convert.ToInt32(reader["creatorStudentId"]),
                                reader["creatorTutorId"] == DBNull.Value ? null : Convert.ToInt32(reader["creatorTutorId"]), Convert.ToInt32(reader["requiredTutors"]),
                                reader["subject"].ToString(), reader["topic"].ToString(), Convert.ToDateTime(reader["startDateTime"]), Convert.ToDateTime(reader["endDateTime"]),
                                Convert.ToInt32(reader["slots"]), reader["location"].ToString(), reader["sessionStatus"].ToString(),
                                0, 0, 0);

                            session.CreatorTutorName = reader["creatorTutorName"] == DBNull.Value ? "" : reader["creatorTutorName"].ToString();
                            sessions.Add(session);
                        }
                    }
                }
            }

            return sessions;
        }

        public List<Session> GetTutorMySessions(int userId)
        {
            List<Session> tutorSessions = new List<Session>();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                string query = @"SELECT DISTINCT s.sessionId, s.subject, s.topic, s.startDateTime, s.endDateTime, s.slots, s.requiredTutors, s.location, s.creatorStudentId,
                s.creatorTutorId, s.sessionStatus FROM session s WHERE (s.creatorTutorId = (SELECT tutorId FROM tutor WHERE userId = @userId)
                OR EXISTS (SELECT 1 FROM sessionTutor st WHERE st.sessionId = s.sessionId AND st.tutorId = (SELECT tutorId FROM tutor WHERE userId = @userId)
                AND st.requestStatus = 'Accepted')) AND s.sessionStatus != 'Cancelled' ORDER BY s.startDateTime ASC";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Session session = new Session(Convert.ToInt32(reader["sessionId"]), reader["creatorStudentId"] == DBNull.Value ? null : Convert.ToInt32(reader["creatorStudentId"]),
                            reader["creatorTutorId"] == DBNull.Value ? null : Convert.ToInt32(reader["creatorTutorId"]), Convert.ToInt32(reader["requiredTutors"]), reader["subject"].ToString(),
                            reader["topic"].ToString(), Convert.ToDateTime(reader["startDateTime"]), Convert.ToDateTime(reader["endDateTime"]), Convert.ToInt32(reader["slots"]),
                            reader["location"].ToString(), reader["sessionStatus"].ToString(), 0, 0, 0);

                            tutorSessions.Add(session);
                        }
                    }
                }
            }

            return tutorSessions;
        }

        public List<Session> GetBrowseSessions(int userId)
        {
            List<Session> sessions = new List<Session>();

            using (MySqlConnection connection = Database.GetConnection())
            {
                string query = @"SELECT s.sessionId, s.subject, s.topic, s.startDateTime, s.endDateTime, s.slots, s.requiredTutors, s.location, s.creatorStudentId, s.creatorTutorId, s.sessionStatus,
                COUNT(b.bookingId) AS occupiedSlots, (s.slots - COUNT(b.bookingId)) AS availableSlots, (SELECT COUNT(*) FROM booking wb WHERE wb.sessionId = s.sessionId AND wb.bookingStatus = 'Waitlisted') AS waitlistedCount FROM session s LEFT JOIN booking b ON s.sessionId = b.sessionId
                AND b.bookingStatus IN ('Accepted', 'Pending') WHERE s.sessionStatus IN ('Open', 'Full') AND s.startDateTime > NOW() AND NOT (s.slots <= (SELECT COUNT(*) FROM booking ab WHERE ab.sessionId = s.sessionId
                AND ab.bookingStatus IN ('Accepted', 'Pending')) AND (SELECT COUNT(*) FROM booking wb WHERE wb.sessionId = s.sessionId AND wb.bookingStatus = 'Waitlisted') >= 3) AND NOT EXISTS (SELECT 1 FROM student st
                WHERE st.studentId = s.creatorStudentId AND st.userId = @userId) AND NOT EXISTS (SELECT 1 FROM tutor t WHERE t.tutorId = s.creatorTutorId AND t.userId = @userId) AND NOT EXISTS (SELECT 1 FROM booking myBooking
                INNER JOIN student myStudent ON myBooking.studentId = myStudent.studentId WHERE myBooking.sessionId = s.sessionId AND myStudent.userId = @userId) AND NOT EXISTS (SELECT 1 FROM sessionTutor st INNER JOIN tutor t ON st.tutorId = t.tutorId
                WHERE st.sessionId = s.sessionId AND t.userId = @userId AND st.requestStatus = 'Accepted') GROUP BY s.sessionId, s.subject, s.topic, s.startDateTime, s.endDateTime, s.slots, s.requiredTutors, 
                s.location, s.creatorStudentId, s.creatorTutorId, s.sessionStatus ORDER BY s.startDateTime ASC";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Session session = new Session(Convert.ToInt32(reader["sessionId"]), reader["creatorStudentId"] == DBNull.Value ? null : Convert.ToInt32(reader["creatorStudentId"]),
                            reader["creatorTutorId"] == DBNull.Value ? null : Convert.ToInt32(reader["creatorTutorId"]), Convert.ToInt32(reader["requiredTutors"]),
                            reader["subject"].ToString(), reader["topic"].ToString(), Convert.ToDateTime(reader["startDateTime"]),
                            Convert.ToDateTime(reader["endDateTime"]), Convert.ToInt32(reader["slots"]), reader["location"].ToString(),
                            reader["sessionStatus"].ToString(), Convert.ToInt32(reader["occupiedSlots"]), Convert.ToInt32(reader["availableSlots"]),
                            Convert.ToInt32(reader["waitlistedCount"]));

                            sessions.Add(session);
                        }
                    }
                }
            }

            return sessions;

        }

        public List<Session> GetTutorBrowseSessions(int userId)
        {
            List<Session> sessions = new List<Session>();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"SELECT s.sessionId, s.creatorStudentId, s.creatorTutorId, s.requiredTutors, s.subject, s.topic, s.startDateTime, s.endDateTime, s.slots,
                s.location, s.sessionStatus, (SELECT COUNT(*) FROM sessionTutor st WHERE st.sessionId = s.sessionId AND st.requestStatus = 'Accepted') AS acceptedTutors FROM session s 
                WHERE s.requiredTutors > 0 AND s.sessionStatus IN ('Open', 'Full') AND s.startDateTime > NOW() AND NOT EXISTS (SELECT 1 FROM student st 
                WHERE st.studentId = s.creatorStudentId AND st.userId = @userId) AND NOT EXISTS (SELECT 1 FROM tutor t WHERE t.tutorId = s.creatorTutorId AND t.userId = @userId) 
                AND NOT EXISTS (SELECT 1 FROM sessionTutor st INNER JOIN tutor t ON st.tutorId = t.tutorId
                WHERE st.sessionId = s.sessionId AND t.userId = @userId AND st.requestStatus IN ('Accepted', 'Withdrawn')) AND NOT EXISTS (SELECT 1 FROM booking b
                INNER JOIN student st ON b.studentId = st.studentId WHERE b.sessionId = s.sessionId AND st.userId = @userId
                AND b.bookingStatus IN ('Accepted', 'Pending', 'Waitlisted')) HAVING acceptedTutors < requiredTutors
                ORDER BY s.startDateTime ASC";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Session session = new Session(Convert.ToInt32(reader["sessionId"]), reader["creatorStudentId"] == DBNull.Value ? null : Convert.ToInt32(reader["creatorStudentId"]),
                                reader["creatorTutorId"] == DBNull.Value ? null : Convert.ToInt32(reader["creatorTutorId"]), Convert.ToInt32(reader["requiredTutors"]),
                                reader["subject"].ToString(), reader["topic"].ToString(), Convert.ToDateTime(reader["startDateTime"]), Convert.ToDateTime(reader["endDateTime"]),
                                Convert.ToInt32(reader["slots"]), reader["location"].ToString(), reader["sessionStatus"].ToString(), 0, 0, 0);

                            sessions.Add(session);
                        }
                    }
                }
            }

            return sessions;
        }


        public bool UpdateSession(Session session)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"UPDATE session SET subject = @subject, topic = @topic, startDateTime = @startDateTime,
                endDateTime = @endDateTime, slots = @slots, requiredTutors = @requiredTutors,
                location = @location WHERE sessionId = @sessionId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@subject", session.Subject);
                    command.Parameters.AddWithValue("@topic", session.Topic);
                    command.Parameters.AddWithValue("@startDateTime", session.StartDateTime);
                    command.Parameters.AddWithValue("@endDateTime", session.EndDateTime);
                    command.Parameters.AddWithValue("@slots", session.Slots);
                    command.Parameters.AddWithValue("@requiredTutors", session.RequiredTutors);
                    command.Parameters.AddWithValue("@location", session.Location);
                    command.Parameters.AddWithValue("@sessionId", session.SessionId);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateSessionStatus(Session session)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                string query = @"UPDATE session SET sessionStatus = @sessionStatus WHERE sessionId = @sessionId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sessionStatus", session.SessionStatus);
                    command.Parameters.AddWithValue("@sessionId", session.SessionId);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public void UpdateOngoingSessions()
        {
            string query = @"UPDATE session SET sessionStatus = 'Ongoing' WHERE sessionStatus IN ('Open', 'Full')
            AND startDateTime <= NOW() AND endDateTime > NOW();";

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool CancelSession(Session session)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        List<int> tutorUserIds = new List<int>();
                        List<int> participantUserIds = new List<int>();
                        UserRepository userRepository = new UserRepository();

                        string bookingQuery = @"UPDATE booking SET bookingStatus = 'Cancelled' WHERE sessionId = @sessionId AND bookingStatus IN ('Accepted', 'Waitlisted')";

                        using (MySqlCommand bookingCommand = new MySqlCommand(bookingQuery, connection, transaction))
                        {
                            bookingCommand.Parameters.AddWithValue("@sessionId", session.SessionId);
                            bookingCommand.ExecuteNonQuery();
                        }

                        string sessionQuery = @"UPDATE session SET sessionStatus = 'Cancelled' WHERE sessionId = @sessionId";

                        using (MySqlCommand sessionCommand = new MySqlCommand(sessionQuery, connection, transaction))
                        {
                            sessionCommand.Parameters.AddWithValue("@sessionId", session.SessionId);
                            int rowsAffected = sessionCommand.ExecuteNonQuery();

                            if (rowsAffected == 0)
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }

                        string participantQuery = @"SELECT u.userId FROM booking b INNER JOIN student s ON b.studentId = s.studentId INNER JOIN user u ON s.userId = u.userId
                        WHERE b.sessionId = @sessionId AND b.bookingStatus = 'Cancelled'";

                        using (MySqlCommand participantCommand = new MySqlCommand(participantQuery, connection, transaction))
                        {
                            participantCommand.Parameters.AddWithValue("@sessionId", session.SessionId);

                            using (MySqlDataReader reader = participantCommand.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    participantUserIds.Add(Convert.ToInt32(reader["userId"]));
                                }
                            }
                        }

                        transaction.Commit();
                        
                        foreach (int tutorUserId in tutorUserIds)
                        {
                            userRepository.AddNotification(tutorUserId, $"The study session '{session.Topic}' has been cancelled.");
                        }

                        foreach (int participantUserId in participantUserIds)
                        {
                            userRepository.AddNotification(participantUserId, $"The study session '{session.Topic}' has been cancelled.");
                        }


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
        public List<Session> GetUnderstaffedSessions()
        {
            List<Session> sessions = new List<Session>();
            List<int> sessionIds = new List<int>();

            using (MySqlConnection connection = Database.GetConnection())
            {
                string query = @"SELECT s.sessionId FROM session s WHERE s.sessionStatus NOT IN ('Cancelled', 'Completed')
                AND s.startDateTime <= NOW() AND ((COALESCE(s.requiredTutors, 0) > 0
                AND (SELECT COUNT(*) FROM sessionTutor st WHERE st.sessionId = s.sessionId AND st.requestStatus = 'Accepted'
                ) < COALESCE(s.requiredTutors, 0)) OR (s.creatorTutorId IS NOT NULL AND (SELECT COUNT(*) FROM booking b
                WHERE b.sessionId = s.sessionId AND b.bookingStatus IN ('Accepted', 'Pending')) = 0))";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sessionIds.Add(Convert.ToInt32(reader["sessionId"]));
                        }
                    }
                }
            }

            foreach (int sessionId in sessionIds)
            {
                Session session = GetSessionById(sessionId);

                if (session != null)
                {
                    sessions.Add(session);
                }
            }

            return sessions;
        }

        public void CancelUnderstaffedSessions()
        {
            List<Session> understaffedSessions = GetUnderstaffedSessions();

            UserRepository userRepository = new UserRepository();

            foreach (Session session in understaffedSessions)
            {
                bool success = CancelSession(session);

                if (success)
                {
                    List<int> participantUserIds = GetSessionParticipantUserIds(session.SessionId);

                    foreach (int userId in participantUserIds)
                    {
                        userRepository.AddNotification(userId, "The session '" + session.Topic + "' has been cancelled because it did not meet the session requirements.");
                    }
                }
            }
        }

        public List<Tutor> GetAvailableTutors(int userId)
        {
            List<Tutor> tutors = new List<Tutor>();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string tutorQuery = @"SELECT t.tutorId, u.userId, u.fullName, u.studentNumber, u.ueGmail, u.year, u.program, t.credentials,
                t.subjects, t.rating, t.availability FROM tutor t INNER JOIN user u ON t.userId = u.userId WHERE t.userId != @userId ORDER BY u.fullName ASC";

                using (MySqlCommand command = new MySqlCommand(tutorQuery, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tutor tutor = new Tutor(Convert.ToInt32(reader["userId"]), Convert.ToInt32(reader["tutorId"]),
                            reader["fullName"].ToString(), reader["studentNumber"].ToString(), reader["ueGmail"].ToString(), reader["year"].ToString(),
                            reader["program"].ToString(), string.Empty, reader["subjects"].ToString(), reader["availability"].ToString(),
                            reader["credentials"].ToString(), Convert.ToDouble(reader["rating"]));

                            tutors.Add(tutor);
                        }
                    }
                }
            }

            return tutors;
        }
        public List<Tutor> GetRequestedSessionTutors(int sessionId)
        {
            List<Tutor> tutors = new List<Tutor>();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"SELECT t.tutorId, u.userId, u.fullName, u.studentNumber, u.ueGmail, u.year, u.program, t.credentials,
                t.subjects, t.availability, t.rating FROM sessionTutor st INNER JOIN tutor t ON st.tutorId = t.tutorId
                INNER JOIN user u ON t.userId = u.userId WHERE st.sessionId = @sessionId AND st.requestStatus IN ('Accepted', 'Pending')
                ORDER BY u.fullName ASC";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sessionId", sessionId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tutor tutor = new Tutor(Convert.ToInt32(reader["userId"]), Convert.ToInt32(reader["tutorId"]),
                            reader["fullName"].ToString(), reader["studentNumber"].ToString(), reader["ueGmail"].ToString(),
                            reader["year"].ToString(), reader["program"].ToString(), string.Empty, reader["subjects"].ToString(),
                            reader["availability"].ToString(), reader["credentials"].ToString(),
                            Convert.ToDouble(reader["rating"]));

                            tutors.Add(tutor);
                        }
                    }
                }
            }

            return tutors;
        }

        public List<Tutor> GetConfirmedSessionTutors(int sessionId)
        {
            List<Tutor> sessionTutors = new List<Tutor>();

            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string query = @"SELECT t.tutorId, u.userId, u.fullName, u.studentNumber, u.ueGmail, u.year, u.program, t.credentials, t.subjects, t.availability, t.rating FROM tutor t
                INNER JOIN user u ON t.userId = u.userId WHERE t.tutorId = (SELECT creatorTutorId FROM session WHERE sessionId = @sessionId) UNION SELECT t.tutorId, u.userId, u.fullName, u.studentNumber,
                u.ueGmail, u.year, u.program, t.credentials, t.subjects, t.availability, t.rating FROM sessionTutor st INNER JOIN tutor t ON st.tutorId = t.tutorId
                INNER JOIN user u ON t.userId = u.userId WHERE st.sessionId = @sessionId AND st.requestStatus = 'Accepted' ORDER BY fullName ASC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@sessionId", sessionId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tutor tutor = new Tutor(Convert.ToInt32(reader["userId"]), Convert.ToInt32(reader["tutorId"]),
                            reader["fullName"].ToString(), reader["studentNumber"].ToString(), reader["ueGmail"].ToString(), reader["year"].ToString(),
                            reader["program"].ToString(), string.Empty, reader["subjects"].ToString(), reader["availability"].ToString(),
                            reader["credentials"].ToString(), Convert.ToDouble(reader["rating"]));

                            sessionTutors.Add(tutor);
                        }
                    }
                }
            }

            return sessionTutors;
        }

        public bool WithdrawTutorRequest(int sessionId, int tutorId)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"UPDATE sessionTutor SET requestStatus = 'Withdrawn' WHERE sessionId = @sessionId
                AND tutorId = @tutorId AND requestStatus = 'Accepted'";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sessionId", sessionId);
                    command.Parameters.AddWithValue("@tutorId", tutorId);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }


        public bool UpdateSessionTutors(int sessionId, List<int> selectedTutorIds)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string selectQuery = @"SELECT tutorId, requestStatus FROM sessionTutor
                        WHERE sessionId = @sessionId";

                        DataTable existingTutors = new DataTable();

                        using (MySqlCommand command = new MySqlCommand(selectQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@sessionId", sessionId);

                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                            {
                                adapter.Fill(existingTutors);
                            }
                        }

                        foreach (DataRow row in existingTutors.Rows)
                        {
                            int tutorId = Convert.ToInt32(row["tutorId"]);

                            if (!selectedTutorIds.Contains(tutorId))
                            {
                                string updateQuery = @"UPDATE sessionTutor SET requestStatus = 'Withdrawn' WHERE sessionId = @sessionId AND tutorId = @tutorId";

                                using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection, transaction))
                                {
                                    updateCommand.Parameters.AddWithValue("@sessionId", sessionId);
                                    updateCommand.Parameters.AddWithValue("@tutorId", tutorId);
                                    updateCommand.ExecuteNonQuery();
                                }
                            }
                        }

                        List<int> invitedTutorUserIds = new List<int>();

                        string topicQuery = @"SELECT topic FROM session WHERE sessionId = @sessionId";

                        string sessionTopic = "";

                        using (MySqlCommand topicCommand = new MySqlCommand(topicQuery, connection, transaction))
                        {
                            topicCommand.Parameters.AddWithValue("@sessionId", sessionId);

                            object result = topicCommand.ExecuteScalar();

                            if (result != null)
                            {
                                sessionTopic = result.ToString();
                            }
                        }

                        foreach (int selectedTutorId in selectedTutorIds)
                        {
                            bool tutorExists = false;
                            string existingStatus = "";

                            foreach (DataRow row in existingTutors.Rows)
                            {
                                int existingTutorId = Convert.ToInt32(row["tutorId"]);

                                if (existingTutorId == selectedTutorId)
                                {
                                    tutorExists = true;
                                    existingStatus = row["requestStatus"].ToString();
                                    break;
                                }
                            }

                            if (tutorExists)
                            {
                                if (existingStatus == "Withdrawn" ||
                                    existingStatus == "Declined")
                                {
                                    string reactivateQuery = @"UPDATE sessionTutor SET requestStatus = 'Pending' WHERE sessionId = @sessionId AND tutorId = @tutorId";

                                    using (MySqlCommand reactivateCommand = new MySqlCommand(reactivateQuery, connection, transaction))
                                    {
                                        reactivateCommand.Parameters.AddWithValue("@sessionId", sessionId);
                                        reactivateCommand.Parameters.AddWithValue("@tutorId", selectedTutorId);
                                        reactivateCommand.ExecuteNonQuery();
                                    }

                                    string userQuery = @"SELECT userId FROM tutor WHERE tutorId = @tutorId";

                                    using (MySqlCommand userCommand = new MySqlCommand(userQuery, connection, transaction))
                                    {
                                        userCommand.Parameters.AddWithValue("@tutorId", selectedTutorId);

                                        object result = userCommand.ExecuteScalar();

                                        if (result != null)
                                        {
                                            invitedTutorUserIds.Add(Convert.ToInt32(result));
                                        }
                                    }
                                }
                            }

                            else
                            {
                                string insertQuery = @"INSERT INTO sessionTutor (sessionId, tutorId, requestStatus) VALUES (@sessionId, @tutorId, 'Pending')";

                                using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection, transaction))
                                {
                                    insertCommand.Parameters.AddWithValue("@sessionId", sessionId);
                                    insertCommand.Parameters.AddWithValue("@tutorId", selectedTutorId);
                                    insertCommand.ExecuteNonQuery();
                                }

                                string userQuery = @"SELECT userId FROM tutor WHERE tutorId = @tutorId";

                                using (MySqlCommand userCommand = new MySqlCommand(userQuery, connection, transaction))
                                {
                                    userCommand.Parameters.AddWithValue("@tutorId", selectedTutorId);

                                    object result = userCommand.ExecuteScalar();

                                    if (result != null)
                                    {
                                        invitedTutorUserIds.Add(Convert.ToInt32(result));
                                    }
                                }
                            }
                        }

                        transaction.Commit();

                        UserRepository userRepository = new UserRepository();

                        foreach (int tutorUserId in invitedTutorUserIds)
                        {
                            userRepository.AddNotification(tutorUserId, $"You have been invited to join the study session '{sessionTopic}'.");
                        }

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

        public int CreateStudentSession(Session session, List<int> selectedTutorIds)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string sessionQuery = @"INSERT INTO session (creatorStudentId, topic, subject, startDateTime, endDateTime,
                requiredTutors, slots, location) VALUES (@studentId, @topic, @subject, @startDateTime, @endDateTime,
                @requiredTutors, @slots, @location)";

                using (MySqlCommand command = new MySqlCommand(sessionQuery, connection))
                {
                    command.Parameters.AddWithValue("@studentId", session.CreatorStudentId);
                    command.Parameters.AddWithValue("@topic", session.Topic);
                    command.Parameters.AddWithValue("@subject", session.Subject);
                    command.Parameters.AddWithValue("@startDateTime", session.StartDateTime);
                    command.Parameters.AddWithValue("@endDateTime", session.EndDateTime);
                    command.Parameters.AddWithValue("@requiredTutors", session.RequiredTutors);
                    command.Parameters.AddWithValue("@slots", session.Slots);
                    command.Parameters.AddWithValue("@location", session.Location);

                    command.ExecuteNonQuery();

                    int sessionId = Convert.ToInt32(command.LastInsertedId);
                    List<int> invitedTutorUserIds = new List<int>();

                    string bookingQuery = @"INSERT INTO booking (studentId, sessionId, bookingStatus, paymentStatus, expectation)
                    VALUES (@studentId, @sessionId, 'Accepted', 'Unpaid', '')";

                    using (MySqlCommand bookingCommand = new MySqlCommand(bookingQuery, connection))
                    {
                        bookingCommand.Parameters.AddWithValue("@studentId", session.CreatorStudentId);
                        bookingCommand.Parameters.AddWithValue("@sessionId", sessionId);
                        bookingCommand.ExecuteNonQuery();
                    }

                    foreach (int tutorId in selectedTutorIds)
                    {
                        string tutorQuery = @"INSERT INTO sessionTutor (sessionId, tutorId, requestStatus)
                        VALUES (@sessionId, @tutorId, 'Pending')";

                        using (MySqlCommand tutorCommand = new MySqlCommand(tutorQuery, connection))
                        {
                            tutorCommand.Parameters.AddWithValue("@sessionId", sessionId);
                            tutorCommand.Parameters.AddWithValue("@tutorId", tutorId);
                            tutorCommand.ExecuteNonQuery();
                        }

                        string userIdQuery = "SELECT userId FROM tutor WHERE tutorId = @tutorId";

                        using (MySqlCommand userIdCommand = new MySqlCommand(userIdQuery, connection))
                        {
                            userIdCommand.Parameters.AddWithValue("@tutorId", tutorId);

                            object result = userIdCommand.ExecuteScalar();

                            if (result != null)
                            {
                                invitedTutorUserIds.Add(Convert.ToInt32(result));
                            }
                        }
                    }

                    UserRepository userRepository = new UserRepository();

                    userRepository.NotifyAllUsers($"A new study session '{session.Topic}' has been created for you to join!");

                    foreach (int tutorUserId in invitedTutorUserIds)
                    {
                        userRepository.AddNotification(tutorUserId, $"You have been invited to join the study session '{session.Topic}'.");
                    }

                    return sessionId;
                }
            }
        }


        public int CreateTutorSession(Session session, List<int> selectedTutorIds)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                int sessionId = 0;
                List<int> invitedTutorUserIds = new List<int>();

                string sessionQuery = @"INSERT INTO session (creatorTutorId, topic, subject, startDateTime, endDateTime, requiredTutors, slots, location) 
                VALUES (@tutorId, @topic, @subject, @startDateTime, @endDateTime, @requiredTutors, @slots, @location)";

                using (MySqlCommand command = new MySqlCommand(sessionQuery, connection))
                {
                    command.Parameters.AddWithValue("@tutorId", session.CreatorTutorId);
                    command.Parameters.AddWithValue("@topic", session.Topic);
                    command.Parameters.AddWithValue("@subject", session.Subject);
                    command.Parameters.AddWithValue("@startDateTime", session.StartDateTime);
                    command.Parameters.AddWithValue("@endDateTime", session.EndDateTime);
                    command.Parameters.AddWithValue("@requiredTutors", session.RequiredTutors);
                    command.Parameters.AddWithValue("@slots", session.Slots);
                    command.Parameters.AddWithValue("@location", session.Location);

                    command.ExecuteNonQuery();

                    sessionId = Convert.ToInt32(command.LastInsertedId);
                }

                foreach (int tutorId in selectedTutorIds)
                {
                    string tutorQuery = @"INSERT INTO sessionTutor (sessionId, tutorId, requestStatus) VALUES (@sessionId, @tutorId, 'Pending')";

                    using (MySqlCommand tutorCommand = new MySqlCommand(tutorQuery, connection))
                    {
                        tutorCommand.Parameters.AddWithValue("@sessionId", sessionId);
                        tutorCommand.Parameters.AddWithValue("@tutorId", tutorId);
                        tutorCommand.ExecuteNonQuery();
                    }

                    string userIdQuery = @"SELECT userId FROM tutor WHERE tutorId = @tutorId";

                    using (MySqlCommand userIdCommand = new MySqlCommand(userIdQuery, connection))
                    {
                        userIdCommand.Parameters.AddWithValue("@tutorId", tutorId);
                        object result = userIdCommand.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            invitedTutorUserIds.Add(Convert.ToInt32(result));
                        }
                    }
                }

                UserRepository userRepository = new UserRepository();

                userRepository.NotifyAllUsers($"A new study session '{session.Topic}' has been created for you to join!");

                foreach (int tutorUserId in invitedTutorUserIds)
                {
                    userRepository.AddNotification(tutorUserId, $"You have been invited to join the study session '{session.Topic}'.");
                }

                return sessionId;
            }
        }

        public bool TakeTutorSession(Session session, Tutor tutor)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string checkQuery = @"SELECT requiredTutors, (SELECT COUNT(*) FROM sessionTutor WHERE sessionId = s.sessionId
                        AND requestStatus = 'Accepted') AS acceptedTutors FROM session s WHERE sessionId = @sessionId AND sessionStatus != 'Cancelled'
                        FOR UPDATE";

                        int requiredTutors;
                        int acceptedTutors;

                        using (MySqlCommand command = new MySqlCommand(checkQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@sessionId", session.SessionId);

                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    transaction.Rollback();
                                    return false;
                                }

                                requiredTutors = Convert.ToInt32(reader["requiredTutors"]);
                                acceptedTutors = Convert.ToInt32(reader["acceptedTutors"]);
                            }
                        }

                        string existingQuery = @"SELECT requestStatus FROM sessionTutor WHERE sessionId = @sessionId
                        AND tutorId = @tutorId";

                        string existingStatus = null;

                        using (MySqlCommand command = new MySqlCommand(existingQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@sessionId", session.SessionId);
                            command.Parameters.AddWithValue("@tutorId", tutor.TutorId);

                            object result = command.ExecuteScalar();

                            if (result != null)
                            {
                                existingStatus = result.ToString();
                            }
                        }

                        if (existingStatus == "Accepted")
                        {
                            transaction.Rollback();
                            return false;
                        }

                        if (acceptedTutors >= requiredTutors)
                        {
                            transaction.Rollback();
                            return false;
                        }

                        if (existingStatus != null)
                        {
                            
                            string updateQuery = @"UPDATE sessionTutor SET requestStatus = 'Accepted' WHERE sessionId = @sessionId
                            AND tutorId = @tutorId";

                            using (MySqlCommand command = new MySqlCommand(updateQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@sessionId", session.SessionId);
                                command.Parameters.AddWithValue("@tutorId", tutor.TutorId);
                                command.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                           
                            string insertQuery = @"INSERT INTO sessionTutor (sessionId, tutorId, requestStatus) VALUES
                            (@sessionId, @tutorId, 'Accepted')";

                            using (MySqlCommand command = new MySqlCommand(insertQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@sessionId", session.SessionId);
                                command.Parameters.AddWithValue("@tutorId", tutor.TutorId);
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

        public bool HasAcceptedTutorSession(int userId, int sessionId)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"SELECT COUNT(*) FROM sessionTutor st INNER JOIN tutor t ON st.tutorId = t.tutorId WHERE t.userId = @userId
                AND st.sessionId = @sessionId AND st.requestStatus = 'Accepted'";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@sessionId", sessionId);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0;
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

    

