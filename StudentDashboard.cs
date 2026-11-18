using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Study_Session
{
    public partial class StudentDashboard : Form
    {
        private int loggedInUserId;
        UserRepository repository = new UserRepository();
        DataTable availableTutors = new DataTable();
        HashSet<int> selectedTutorIds = new HashSet<int>();
        private DataTable browseSessions = new DataTable();

        public StudentDashboard()
        {
            InitializeComponent();
        }

        public StudentDashboard(int userId)
        {
            InitializeComponent();

            loggedInUserId = userId;

            string studentName = repository.GetUserFullName(loggedInUserId);

            lblWelcome.Text = $"Welcome back, {studentName}!";

            int bookedCount = repository.GetBookedSessionCount(loggedInUserId);
            lblBookedCount.Text = bookedCount.ToString();

            int waitlistedCount = repository.GetWaitlistedSessionCount(loggedInUserId);
            lblWaitlistedCount.Text = waitlistedCount.ToString();

            int completedCount = repository.GetCompletedSessionCount(loggedInUserId);
            lblCompletedCount.Text = completedCount.ToString();

            LoadNotifications();
            LoadAvailableTutors();
            LoadBrowseSessions();

            dtpSessionDate.MinDate = DateTime.Today;
        }

        private void LoadNotifications()
        {
            UserRepository repository = new UserRepository();
            DataTable notifications = repository.GetNotifications(loggedInUserId);

            flpNotifications.Controls.Clear();

            foreach (DataRow row in notifications.Rows)
            {
                Panel notificationPanel = new Panel();

                notificationPanel.Size = new Size(320, 65);
                notificationPanel.BackColor = Color.MediumSlateBlue;
                notificationPanel.BorderStyle = BorderStyle.FixedSingle;
                notificationPanel.Margin = new Padding(3, 3, 3, 8);

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

                notificationPanel.Controls.Add(messageLabel);
                notificationPanel.Controls.Add(dateLabel);

                flpNotifications.Controls.Add(notificationPanel);
            }
        }

        private void LoadStudentProfile()
        {
            UserRepository repository = new UserRepository();
            DataTable studentProfile = repository.GetStudentProfile(loggedInUserId);
            if (studentProfile.Rows.Count > 0)
            {
                DataRow row = studentProfile.Rows[0];

                lblProfileFullNameValue.Text = row["fullName"].ToString();
                lblProfileUEGmailValue.Text = row["ueGmail"].ToString();
                lblProfileYearValue.Text = row["year"].ToString();
                lblProfileProgramValue.Text = row["program"].ToString();
            }
        }

        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            pnlMyProfile.Visible = true;
            LoadStudentProfile();
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            txtEditFullName.Text = lblProfileFullNameValue.Text;
            txtEditUEGmail.Text = lblProfileUEGmailValue.Text;
            txtEditYear.Text = lblProfileYearValue.Text;
            txtEditProgram.Text = lblProfileProgramValue.Text;

            lblProfileFullNameValue.Visible = false;
            lblProfileUEGmailValue.Visible = false;
            lblProfileYearValue.Visible = false;
            lblProfileProgramValue.Visible = false;

            txtEditFullName.Visible = true;
            txtEditUEGmail.Visible = true;
            txtEditYear.Visible = true;
            txtEditProgram.Visible = true;

            btnEditProfile.Visible = false;
            btnSaveProfile.Visible = true;
            btnCancelProfile.Visible = true;
        }

        private void btnCancelProfile_Click(object sender, EventArgs e)
        {
            txtEditFullName.Visible = false;
            txtEditUEGmail.Visible = false;
            txtEditYear.Visible = false;
            txtEditProgram.Visible = false;

            lblProfileFullNameValue.Visible = true;
            lblProfileUEGmailValue.Visible = true;
            lblProfileYearValue.Visible = true;
            lblProfileProgramValue.Visible = true;

            btnEditProfile.Visible = true;
            btnSaveProfile.Visible = false;
            btnCancelProfile.Visible = false;
        }

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEditFullName.Text) || string.IsNullOrWhiteSpace(txtEditUEGmail.Text) ||
                string.IsNullOrWhiteSpace(txtEditYear.Text) || string.IsNullOrWhiteSpace(txtEditProgram.Text))
            {
                MessageBox.Show("Please complete all fields.");
                return;
            }

            try
            {
                UserRepository repository = new UserRepository();

                bool updated = repository.updateStudentProfile(loggedInUserId, txtEditFullName.Text.Trim(), txtEditUEGmail.Text.Trim(), txtEditYear.Text.Trim(), txtEditProgram.Text.Trim());

                if (updated)
                {
                    MessageBox.Show("Profile updated successfully!");


                    LoadStudentProfile();

                    txtEditFullName.Visible = false;
                    txtEditUEGmail.Visible = false;
                    txtEditYear.Visible = false;
                    txtEditProgram.Visible = false;

                    lblProfileFullNameValue.Visible = true;
                    lblProfileUEGmailValue.Visible = true;
                    lblProfileYearValue.Visible = true;
                    lblProfileProgramValue.Visible = true;

                    btnEditProfile.Visible = true;
                    btnSaveProfile.Visible = false;
                    btnCancelProfile.Visible = false;

                }

                else
                {
                    MessageBox.Show("No profile changes were saved.");
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error updating profile." + ex.Message);
            }

        }

        private void btnCreateSession_Click(object sender, EventArgs e)
        {
            pnlMyProfile.Visible = false;
            pnlCreateSession.Visible = true;
        }

        private void btnSubmitSession_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSubject.Text) || string.IsNullOrWhiteSpace(txtTopic.Text) ||
               string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please complete all fields.");
                return;
            }

            if (numSlots.Value <= 0)
            {
                MessageBox.Show("Please enter at least one available slot.");
                return;
            }

            DateTime selectedDate = dtpSessionDate.Value.Date;
            DateTime startDateTime = selectedDate.Add(dtpStartTime.Value.TimeOfDay);
            DateTime endDateTime = selectedDate.Add(dtpEndTime.Value.TimeOfDay);

            if (startDateTime <= DateTime.Now)
            {
                MessageBox.Show("Please select a future starting time.");
                return;
            }

            if (endDateTime <= startDateTime)
            {
                MessageBox.Show("End time must be later than start time.");
                return;
            }

            UserRepository repository = new UserRepository();

            bool success = repository.createStudentSession(loggedInUserId, txtSubject.Text.Trim(), txtTopic.Text.Trim(), startDateTime, endDateTime, (int)numSlots.Value, (int)numRequiredTutors.Value, txtLocation.Text.Trim());

            if (success)
            {
                MessageBox.Show("Study session successfully created!");

                txtSubject.Clear();
                txtTopic.Clear();
                txtLocation.Clear();

                selectedTutorIds.Clear();
                lblSelectedTutors.Text = "Selected Tutors: " + selectedTutorIds.Count();

                numSlots.Value = 0;
                numRequiredTutors.Value = 0;
                dtpSessionDate.Value = DateTime.Today;
                dtpStartTime.Value = DateTime.Now;
                dtpEndTime.Value = DateTime.Now.AddHours(1);
            }

            else
            {
                MessageBox.Show("Unable to create the study session.");
            }
        }

        private void LoadAvailableTutors()
        {
            availableTutors = repository.GetAvailableTutors();

            DisplayTutorList(txtSearchTutor.Text);

        }
        private void DisplayTutorList(string searchText)
        {
            flpTutorList.Controls.Clear();

            foreach (DataRow row in availableTutors.Rows)
            {
                string tutorName = row["fullName"].ToString();
                string subjects = row["subjects"].ToString();
                string availability = row["availability"].ToString();
                string sessionDay = dtpSessionDate.Value.DayOfWeek.ToString();
                string[] availableDays = availability.Split(',');
                bool isAvailable = false;

                foreach (string day in availableDays)
                {
                    if (day.Trim().Equals(sessionDay, StringComparison.OrdinalIgnoreCase))
                    {
                        isAvailable = true;
                        break;
                    }
                }

                if (!isAvailable)
                {
                    selectedTutorIds.Remove(Convert.ToInt32(row["tutorId"]));
                    continue;
                }

                if (!tutorName.Contains(searchText, StringComparison.OrdinalIgnoreCase) && !subjects.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                int tutorId = Convert.ToInt32(row["tutorId"]);

                CheckBox tutorCheckBox = new CheckBox();

                tutorCheckBox.Text = tutorName;

                tutorCheckBox.Tag = tutorId;
                tutorCheckBox.AutoSize = true;
                tutorCheckBox.Margin = new Padding(5);
                tutorCheckBox.Checked = selectedTutorIds.Contains(tutorId);

                tutorCheckBox.CheckedChanged += (sender, e) =>
                {
                    if (tutorCheckBox.Checked)
                    {
                        if (selectedTutorIds.Count >= numRequiredTutors.Value)
                        {
                            MessageBox.Show("You can only select up to " + numRequiredTutors.Value + " tutors.");
                            tutorCheckBox.Checked = false;
                            return;
                        }

                        selectedTutorIds.Add(tutorId);
                    }

                    else
                    {
                        selectedTutorIds.Remove(tutorId);
                    }

                    lblSelectedTutors.Text = "Selected Tutors: " + selectedTutorIds.Count;
                };

                Button btnViewProfile = new Button();

                btnViewProfile.Text = "View Profile";
                btnViewProfile.AutoSize = true;
                btnViewProfile.Margin = new Padding(5);

                btnViewProfile.Click += (sender, e) =>
                {
                    UserProfile profileForm = new UserProfile(row);
                    profileForm.ShowDialog();
                };

                Panel tutorPanel = new Panel();
                tutorPanel.Width = flpTutorList.Width - 25;
                tutorPanel.Height = 45;

                tutorCheckBox.Location = new Point(5, 10);
                btnViewProfile.Location = new Point(tutorPanel.Width - btnViewProfile.Width - 10, 5);

                tutorPanel.Controls.Add(tutorCheckBox);
                tutorPanel.Controls.Add(btnViewProfile);

                flpTutorList.Controls.Add(tutorPanel);
            }
        }

        private void txtSearchTutor_TextChanged(object sender, EventArgs e)
        {
            DisplayTutorList(txtSearchTutor.Text);
        }

        private void numRequiredTutors_ValueChanged(object sender, EventArgs e)
        {
            if (numRequiredTutors.Value < selectedTutorIds.Count)
            {
                MessageBox.Show("You cannot set the required tutors below the number of tutors already selected.");

                numRequiredTutors.Value = selectedTutorIds.Count;
            }
        }

        private void dtpSessionDate_ValueChanged(object sender, EventArgs e)
        {
            DisplayTutorList(txtSearchTutor.Text);
        }

        private void LoadBrowseSessions()
        {
            browseSessions = repository.GetBrowseSessions();
            DisplayBrowseSessions(browseSessions);
        }


        private void DisplayBrowseSessions(DataTable sessions)
        {
            flpBrowseSessions.Controls.Clear();

            foreach (DataRow row in sessions.Rows)
            {
                Panel sessionCard = new Panel();

                sessionCard.Width = flpBrowseSessions.ClientSize.Width - 35;
                sessionCard.Height = 150;
                sessionCard.BorderStyle = BorderStyle.FixedSingle;
                sessionCard.Margin = new Padding(5);
                sessionCard.Padding = new Padding(10);

                Label lblSubject = new Label();
                lblSubject.Text = row["subject"].ToString();
                lblSubject.Font = new Font("Arial", 12, FontStyle.Bold);
                lblSubject.Location = new Point(10, 10);
                lblSubject.AutoSize = true;

                Label lblTopic = new Label();
                lblTopic.Text = "Topic: " + row["topic"].ToString();
                lblTopic.Location = new Point(10, 40);
                lblTopic.AutoSize = true;

                DateTime start = Convert.ToDateTime(row["startDateTime"]);
                DateTime end = Convert.ToDateTime(row["endDateTime"]);

                Label lblDateTime = new Label();
                lblDateTime.Text = start.ToString("MMMM dd, yyyy") +
                    " | " + start.ToString("hh:mm tt") +
                    " - " + end.ToString("hh:mm tt");
                lblDateTime.Location = new Point(10, 65);
                lblDateTime.AutoSize = true;

                Label lblSlots = new Label();
                lblSlots.Text = "Available Slots: " +
                    row["availableSlots"] + " / " + row["slots"];
                lblSlots.Location = new Point(10, 90);
                lblSlots.AutoSize = true;

                Label lblLocation = new Label();
                lblLocation.Text = "Location: " + row["location"].ToString();
                lblLocation.Location = new Point(10, 115);
                lblLocation.AutoSize = true;

                sessionCard.Controls.Add(lblSubject);
                sessionCard.Controls.Add(lblTopic);
                sessionCard.Controls.Add(lblDateTime);
                sessionCard.Controls.Add(lblSlots);
                sessionCard.Controls.Add(lblLocation);

                flpBrowseSessions.Controls.Add(sessionCard);
            }
        }

        private void txtSearchSessions_TextChanged_1(object sender, EventArgs e)
        {
            string searchText = txtSearchSessions.Text.Trim();

            DataTable filteredSessions = browseSessions.Clone();

            foreach (DataRow row in browseSessions.Rows)
            {
                string subject = row["subject"].ToString();
                string topic = row["topic"].ToString();

                if (subject.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 || topic.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    filteredSessions.ImportRow(row);
                }

            }

            DisplayBrowseSessions(filteredSessions);
        }
    }
}
