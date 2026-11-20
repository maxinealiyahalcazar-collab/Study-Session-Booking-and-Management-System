using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Data;
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
            set { fullName = value; }
        }

        public string StudentNumber
        {
            get { return studentNumber; }
        }

        public string UEGmail
        {
            get { return ueGmail; }
            set { ueGmail = value; }
        }
        public string Year
        {
            get { return year; }
            set { year = value; }
        }

        public string Program
        {
            get { return program; }
            set { program = value; }
        }

        public string PasswordHash
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

        public bool login(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }

        public void logout()
        {
            passwordHash = string.Empty;
        }

        public void viewProfile()
        {
            UserRepository userRepository = new UserRepository();

            User profileUser = userRepository.GetUserProfile(UserId);

            if (profileUser != null)
            {
                UserProfile profileForm = new UserProfile(profileUser);
                profileForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Profile not found.");
            }
        }

        public bool editProfile(string fullName, string ueGmail, string year, string program)
        {
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(ueGmail) ||
                string.IsNullOrWhiteSpace(year) ||
                string.IsNullOrWhiteSpace(program))
            {
                return false;
            }

            this.FullName = fullName;
            this.UEGmail = ueGmail;
            this.Year = year;
            this.Program = program;

            return true;
        }

        public void sendNotification(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            UserRepository userRepository = new UserRepository();

            userRepository.AddNotification(UserId, message);
        }

        public void viewNotifications(FlowLayoutPanel notificationPanel)
        {
            UserRepository userRepository = new UserRepository();

            DataTable notifications = userRepository.GetNotifications(UserId);

            notificationPanel.Controls.Clear();

            foreach (DataRow row in notifications.Rows)
            {
                Panel panel = new Panel();

                panel.Size = new Size(320, 65);
                panel.BackColor = Color.MediumSlateBlue;
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Margin = new Padding(3, 3, 3, 8);

                Label messageLabel = new Label();
                messageLabel.Text = row["message"].ToString();
                messageLabel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                messageLabel.Location = new Point(10, 8);
                messageLabel.Size = new Size(290, 22);

                Label dateLabel = new Label();
                DateTime createdAt = Convert.ToDateTime(row["createdAt"]);
                dateLabel.Text = createdAt.ToString("MM/dd/yyyy HH:mm");
                dateLabel.Font = new Font("Segoe UI", 8);
                dateLabel.Location = new Point(10, 35);
                dateLabel.AutoSize = true;

                panel.Controls.Add(messageLabel);
                panel.Controls.Add(dateLabel);

                notificationPanel.Controls.Add(panel);
            }
        }
    }
}

