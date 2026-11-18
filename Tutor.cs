using System;
using System.Collections.Generic;
using System.Text;

namespace Study_Session
{
    public class Tutor : User
    {
        private int tutorId;
        private string subjects;
        private string availability;
        private string credentials;
        private double rating;

        public int TutorId
        {
            get { return tutorId; }
        }

        public string Subjects
        {
            get { return subjects; }
            set { subjects = value; }
        }

        public string Availability
        {
            get { return availability; }
            set { availability = value; }
        }

        public string Credentials
        {
            get { return credentials; }
            set { credentials = value; }
        }

        public double Rating
        {
            get { return rating; }
            protected set { rating = value; }
        }

        public Tutor(int userId, int tutorId, string fullName, string studentNumber, string ueGmail, string year, string program, string passwordHash, string subjects, string availability, string credentials, double rating)
            : base(userId, fullName, studentNumber, ueGmail, year, program, passwordHash)
        {
            this.tutorId = tutorId;
            this.subjects = subjects;
            this.availability = availability;
            this.credentials = credentials;
            this.rating = rating;
        }

        public override void LoadDashboard(Panel dashboardPanel)
        {
            MessageBox.Show("Tutor Dashboard loaded.");
        }
    }
}
