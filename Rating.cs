using System;
using System.Collections.Generic;
using System.Text;

namespace Study_Session
{
    public class Rating
    {
        private int ratingId;
        private int sessionId;
        private int studentId;
        private int tutorId;
        private double ratingValue;
        private string reviewText = "";

        public int RatingId
        {
            get { return ratingId; }
        }

        public int SessionId
        {
            get { return sessionId; }
        }

        public int StudentId
        {
            get { return studentId; }
        }

        public int TutorId
        {
            get { return tutorId; }
        }

        public double RatingValue
        {
            get { return ratingValue; }
        }

        public string ReviewText
        {
            get { return reviewText; }
        }

        public Rating(int ratingId, int sessionId, int studentId, int tutorId, double ratingValue, string reviewText)
        {
            if (ratingValue < 1.0 || ratingValue > 5.0)
            {
                throw new ArgumentOutOfRangeException("Rating value must be between 1.0 and 5.0.");
            }

            this.ratingId = ratingId;
            this.sessionId = sessionId;
            this.studentId = studentId;
            this.tutorId = tutorId;
            this.ratingValue = ratingValue;
            this.reviewText = reviewText;
        }
    }
}
