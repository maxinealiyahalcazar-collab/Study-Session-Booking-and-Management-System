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

        public Tutor(int userId, string fullName, string studentNumber, string ueGmail, string year, string program,
        string passwordHash, string subjects, string availability, string credentials) : base(userId, fullName, studentNumber, ueGmail, year, program, passwordHash)
        {
            this.tutorId = 0;
            this.subjects = subjects;
            this.availability = availability;
            this.credentials = credentials;
            this.rating = 0.00;
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

        public static Tutor CreateFromStudent(Student student)
        {
            if (student == null)
            {
                return null;
            }

            return new Tutor(student.UserId, student.FullName, student.StudentNumber, student.UEGmail, student.Year,
            student.Program, student.PasswordHash, "", "Unavailable", "");
        }

        public override void LoadDashboard(Panel dashboardPanel)
        {
            TutorDashboard dashboard = new TutorDashboard(this);
            dashboard.Show();
        }

        public Session createSession(string subject, string topic, DateTime startDateTime, DateTime endDateTime, int requiredTutors, int slots, string location)
        {
            if (string.IsNullOrWhiteSpace(subject) || string.IsNullOrWhiteSpace(topic) || string.IsNullOrWhiteSpace(location) ||
                startDateTime <= DateTime.Now || endDateTime <= startDateTime || slots <= 0 || requiredTutors < 0)
            {
                return null;
            }

            return new Session(0, null, this.TutorId, requiredTutors, subject, topic, startDateTime, endDateTime, slots, location,
            "Open", 0, slots, 0);
        }
    }
}
