using System;
using System.Collections.Generic;
using System.Text;

namespace Study_Session
{
    public abstract class User
    {
        private int userId;
        private string fullName;
        private string studentNumber;
        private string ueGmail;
        private string year;
        private string program;
        private string passwordHash;

        public int UserId
        {
            get { return userId; }
        }

        public string FullName
        {
            get { return fullName; }
        }

        public string UEGmail
        {
            get { return ueGmail; }
        }
        public string Year
        {
            get { return year; }
        }

        public string Program
        {
            get { return program; }
        }

        protected string PasswordHash
        {
            get { return passwordHash; }
        }

        protected User(int userId, string fullName, string studentNumber, string ueGmail, string year, string program, string passwordHash)
        {
            this.userId = userId;
            this.fullName = fullName;
            this.studentNumber = studentNumber;
            this.ueGmail = ueGmail;
            this.year = year;
            this.program = program;
            this.passwordHash = passwordHash;
        }

        public abstract void LoadDashboard(Panel dashboardPanel);  
    }
}

