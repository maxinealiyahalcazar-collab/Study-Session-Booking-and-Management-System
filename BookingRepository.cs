using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Text;

namespace Study_Session
{
    public class BookingRepository
    {

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
                     
                        Booking booking = new Booking(0, sessionId, studentId, expectation, "Pending", "Unpaid", null);

                        booking.confirmBooking();
                        booking.completePayment();

                            using (MySqlConnection connection3 = Database.GetConnection())
                            {
                                connection3.Open();

                                string query3 = @"INSERT INTO booking (studentId, sessionId, bookingStatus, paymentStatus, expectation) VALUES (@studentId, @sessionId, @bookingStatus, @paymentStatus, @expectation)";

                                using (MySqlCommand command3 = new MySqlCommand(query3, connection3))
                                {
                                    command3.Parameters.AddWithValue("@studentId", booking.StudentId);
                                    command3.Parameters.AddWithValue("@sessionId", booking.SessionId);
                                    command3.Parameters.AddWithValue("@bookingStatus", booking.BookingStatus);
                                    command3.Parameters.AddWithValue("@paymentStatus", booking.PaymentStatus);
                                    command3.Parameters.AddWithValue("@expectation", booking.Expectations);

                                    command3.ExecuteNonQuery();
                                }
                            }
                        }

                        return "Joined";
                }
            }
        }

       
        public string CompleteCreatorBooking(int userId, int sessionId, string expectation)
        {
            Booking booking = GetBookingByStudentAndSession(userId, sessionId);

            if (booking == null || booking.BookingStatus != "Accepted" || booking.PaymentStatus != "Unpaid")
            {
                return "BookingNotFound";
            }

            booking.completePayment();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string bookingQuery = @"UPDATE booking b JOIN student st ON b.studentId = st.studentId SET b.paymentStatus = @paymentStatus,
                b.expectation = @expectation WHERE b.bookingId = @bookingId";

                using (MySqlCommand command = new MySqlCommand(bookingQuery, connection))
                {
                    command.Parameters.AddWithValue("@paymentStatus", booking.PaymentStatus);
                    command.Parameters.AddWithValue("@expectation", expectation);
                    command.Parameters.AddWithValue("@bookingId", booking.BookingId);

                    return command.ExecuteNonQuery() > 0 ? "Joined" : "BookingNotFound";
                }
            }
        }

        public string CompleteWaitlistPayment(int userId, int sessionId, string expectation)
        {
            Booking booking = GetBookingByStudentAndSession(userId, sessionId);

            if (booking == null || booking.BookingStatus != "Pending" || booking.PaymentStatus != "Unpaid")
            {
                return "BookingNotFound";
            }

            booking.completePayment();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"UPDATE booking SET bookingStatus = @bookingStatus, paymentStatus = @paymentStatus, expectation = @expectation WHERE bookingId = @bookingId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@bookingStatus", booking.BookingStatus);
                    command.Parameters.AddWithValue("@paymentStatus", booking.PaymentStatus);
                    command.Parameters.AddWithValue("@expectation", expectation);
                    command.Parameters.AddWithValue("@bookingId", booking.BookingId);

                    return command.ExecuteNonQuery() > 0 ? "Joined" : "BookingNotFound";
                }
            }
        }

        private Booking GetBookingByStudentAndSession(int userId, int sessionId)
        {
            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"SELECT b.bookingId, b.sessionId, b.studentId, b.expectation, b.bookingStatus, b.paymentStatus, b.waitlistPosition
                FROM booking b INNER JOIN student st ON b.studentId = st.studentId WHERE st.userId = @userId
                AND b.sessionId = @sessionId AND b.bookingStatus IN ('Accepted', 'Pending', 'Waitlisted') LIMIT 1";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@sessionId", sessionId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Booking(Convert.ToInt32(reader["bookingId"]), Convert.ToInt32(reader["sessionId"]),
                                Convert.ToInt32(reader["studentId"]), reader["expectation"].ToString(), reader["bookingStatus"].ToString(),
                                reader["paymentStatus"].ToString(), reader["waitlistPosition"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["waitlistPosition"]));
                        }
                    }
                }
            }

            return null;
        }
        public bool CancelBooking(int userId, int sessionId)
        {
            Booking booking = GetBookingByStudentAndSession(userId, sessionId);

            if (booking == null)
            {
                return false;
            }

            string oldStatus = booking.BookingStatus;
            int? oldWaitlistPosition = booking.WaitlistPosition;

            booking.cancelBooking();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string cancelQuery = @"UPDATE booking SET bookingStatus = @bookingStatus, waitlistPosition = @waitlistPosition WHERE bookingId = @bookingId";

                        int rowsAffected;

                        using (MySqlCommand command = new MySqlCommand(cancelQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@bookingStatus", booking.BookingStatus);
                            command.Parameters.AddWithValue("@waitlistPosition", booking.WaitlistPosition.HasValue ? (object)booking.WaitlistPosition.Value : DBNull.Value);
                            command.Parameters.AddWithValue("@bookingId", booking.BookingId);

                            rowsAffected = command.ExecuteNonQuery();
                        }

                        if (rowsAffected == 0)
                        {
                            transaction.Rollback();
                            return false;
                        } 

                        if (oldStatus == "Waitlisted")
                        {
                            string shiftQuery = @"UPDATE booking SET waitlistPosition = waitlistPosition - 1 WHERE sessionId = @sessionId
                            AND bookingStatus = 'Waitlisted' AND waitlistPosition > @oldPosition";

                            using (MySqlCommand command = new MySqlCommand(shiftQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@sessionId", sessionId);
                                command.Parameters.AddWithValue("@oldPosition", oldWaitlistPosition.Value);
                                command.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            return true;
                        }

                        int? nextBookingId = null;
                        int nextPosition = 0;

                        string waitlistQuery = @"SELECT bookingId, waitlistPosition FROM booking WHERE sessionId = @sessionId AND bookingStatus = 'Waitlisted'
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
                            string promoteQuery = @"UPDATE booking SET bookingStatus = 'Pending', waitlistPosition = NULL
                            WHERE bookingId = @bookingId";

                            using (MySqlCommand command = new MySqlCommand(promoteQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@bookingId", nextBookingId.Value);
                                command.ExecuteNonQuery();
                            }


                            string shiftQuery = @"UPDATE booking SET waitlistPosition = waitlistPosition - 1 WHERE sessionId = @sessionId
                            AND bookingStatus = 'Waitlisted' AND waitlistPosition > @nextPosition";

                            using (MySqlCommand command = new MySqlCommand(shiftQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@sessionId", sessionId);
                                command.Parameters.AddWithValue("@nextPosition", nextPosition);
                                command.ExecuteNonQuery();
                            }
                        }

                        else
                        {
                            string updateSessionQuery = @"UPDATE session SET sessionStatus = 'Open' WHERE sessionId = @sessionId";

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

        public List<Booking> GetMyWaitlistedBookings(int userId)
        {
            List<Booking> bookings = new List<Booking>();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"SELECT b.bookingId, b.sessionId, b.studentId, b.expectation, b.bookingStatus,
                b.paymentStatus, b.waitlistPosition FROM booking b INNER JOIN student st ON b.studentId = st.studentId INNER JOIN session s ON b.sessionId = s.sessionId
                WHERE st.userId = @userId AND b.bookingStatus IN ('Waitlisted', 'Pending') AND s.endDateTime > NOW() ORDER BY b.waitlistPosition ASC";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Booking booking = new Booking(Convert.ToInt32(reader["bookingId"]), Convert.ToInt32(reader["sessionId"]), Convert.ToInt32(reader["studentId"]),
                            reader["expectation"].ToString(), reader["bookingStatus"].ToString(), reader["paymentStatus"].ToString(),
                            reader["waitlistPosition"] == DBNull.Value ? null : Convert.ToInt32(reader["waitlistPosition"]));

                            bookings.Add(booking);
                        }
                    }
                }
            }

            return bookings;
        }

        public List<string> GetStudentExpectations(int sessionId)
        {
            List<string> expectations = new List<string>();

            using (MySqlConnection connection = Database.GetConnection())
            {
                connection.Open();

                string query = @"SELECT expectation FROM booking WHERE sessionId = @sessionId AND bookingStatus = 'Accepted'
                AND expectation IS NOT NULL AND expectation <> ''";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sessionId", sessionId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            expectations.Add(reader["expectation"].ToString());
                        }
                    }
                }
            }

            return expectations;
        }
    }
}