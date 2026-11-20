using System;
using System.Collections.Generic;
using System.Text;

namespace Study_Session
{
    public class Student : User
    {
        private int studentId;
        public int StudentId
        {
            get { return studentId; }
        }

        public Student(int userId, int studentId, string fullName, string studentNumber, string ueGmail, string year, string program, string passwordHash)
            : base(userId, fullName, studentNumber, ueGmail, year, program, passwordHash)
        {
            this.studentId = studentId;
        }

        public override void LoadDashboard(Panel dashboardPanel)
        {
            StudentDashboard dashboard = new StudentDashboard(this);
            dashboard.Show();
        }

        public Session createSession(string subject, string topic, DateTime startDateTime, DateTime endDateTime, int requiredTutors,
        int slots, string location)
        {
            if (string.IsNullOrWhiteSpace(subject) || string.IsNullOrWhiteSpace(topic) || string.IsNullOrWhiteSpace(location) ||startDateTime <= DateTime.Now ||
                endDateTime <= startDateTime || slots <= 0 || requiredTutors < 0)
            {
                return null;
            }

            return new Session(0, this.StudentId, null, requiredTutors, subject, topic, startDateTime, endDateTime, slots, location,
            "Open", 0, slots, 0);
        }

        public void browseSession(Session session)
        {
            if (session == null)
            {
                MessageBox.Show("Study session not found.");
                return;
            }
        }

        public List<Session> viewMySessions()
        {
            SessionRepository repository = new SessionRepository();
            return repository.GetMySessions(this.UserId);
        }

        public bool requestTutor(Tutor tutor)
        {
            if (tutor == null)
            {
                return false;
            }

            return true;
        }

        public bool uploadMaterials(Session session, string materialName, string description, string fileLink)
        {
            if (session == null)
            {
                return false;
            }

            if (!session.AddMaterials(materialName, description, fileLink))
            {
                return false;
            }

            SessionRepository sessionRepository = new SessionRepository();

            return sessionRepository.AddMaterial(session.SessionId, materialName, description, fileLink);
        }

        public bool rateTutor(Tutor tutor, Rating rating)
        {
            if (tutor == null || rating == null)
            {
                return false;
            }

            if (rating.TutorId != tutor.TutorId ||
                rating.StudentId != this.StudentId)
            {
                return false;
            }

            UserRepository userRepository = new UserRepository();

            return userRepository.AddRating(rating.TutorId, rating.StudentId, rating.SessionId, (decimal)rating.RatingValue, rating.ReviewText);
        }

        public Tutor becomeTutor()
        {
            return Tutor.CreateFromStudent(this);
        }
    }
}
