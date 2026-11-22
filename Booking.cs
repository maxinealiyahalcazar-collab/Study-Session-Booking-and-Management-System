using System;
using System.Collections.Generic;
using System.Text;

namespace Study_Session
{
    public class Booking
    {
        private int bookingId;
        private int sessionId;
        private int studentId;
        private string expectations = "";
        private string bookingStatus = "";
        private string paymentStatus = "";
        private int? waitlistPosition;

        public int BookingId
        {
            get { return bookingId; }
        }

        public int SessionId
        {
            get { return sessionId; }
        }

        public int StudentId
        {
            get { return studentId; }
        }

        public string Expectations
        {
            get { return expectations; }
        }

        public string BookingStatus
        {
            get { return bookingStatus; }
        }
        public string PaymentStatus
        {
            get { return paymentStatus; }
        }

        public int? WaitlistPosition
        {
            get { return waitlistPosition; }
        }

        public Booking(int bookingId, int sessionId, int studentId, string expectations, string bookingStatus, string paymentStatus, int? waitlistPosition)
        {
            this.bookingId = bookingId;
            this.sessionId = sessionId;
            this.studentId = studentId;
            this.expectations = expectations;
            this.bookingStatus = bookingStatus;
            this.paymentStatus = paymentStatus;
            this.waitlistPosition = waitlistPosition;
        }

        public void confirmBooking()
        {
            bookingStatus = "Accepted";
        }

        public void completePayment()
        {
            paymentStatus = "Paid";
        }

        public void cancelBooking()
        {
            bookingStatus = "Withdrawn";
            waitlistPosition = null;
        }
    }
}
