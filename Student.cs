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
    }
}
