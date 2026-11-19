using Org.BouncyCastle.Utilities;
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
        private bool isEditMode = false;
        private int editingSessionId = 0;

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
            LoadMySessions();

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
            DataTable studentProfile = repository.GetUserProfile(loggedInUserId);
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

        private void btnViewProfile_Click(object sender, EventArgs e)
        {
            UserRepository repository = new UserRepository();

            DataTable profile = repository.GetUserProfile(loggedInUserId);

            if (profile.Rows.Count > 0)
            {
                UserProfile profileForm = new UserProfile(profile.Rows[0]);
                profileForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Profile not found.");
            }
        }
        private void btnCreateSession_Click(object sender, EventArgs e)
        {
            pnlMyProfile.Visible = false;
            pnlCreateSession.Visible = true;
            isEditMode = false;
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

            if (isEditMode)
            {
                bool success = repository.UpdateStudentSession(editingSessionId, txtSubject.Text.Trim(), txtTopic.Text.Trim(), startDateTime, endDateTime, (int)numSlots.Value, (int)numRequiredTutors.Value, txtLocation.Text.Trim());

                if (success)
                {
                    MessageBox.Show("Study session successfully updated!");
                    isEditMode = false;
                    editingSessionId = 0;
                }

                else
                {
                    MessageBox.Show("Unable to update the study session.");
                }
            }

            else
            {
                UserRepository repository = new UserRepository();

                int newSessionId = repository.createStudentSession(loggedInUserId, txtSubject.Text.Trim(), txtTopic.Text.Trim(), startDateTime, endDateTime, (int)numSlots.Value, (int)numRequiredTutors.Value, txtLocation.Text.Trim(), selectedTutorIds);

                if (newSessionId > 0)
                {
                    DataRow sessionData = repository.GetSessionById(newSessionId);

                    if (sessionData != null)
                    {
                        using (BookingForm bookingForm = new BookingForm(sessionData, loggedInUserId, true))
                        {
                            bookingForm.ShowDialog();
                        }
                    }

                    MessageBox.Show("Study session successfully created!");

                    txtSubject.Clear();
                    txtTopic.Clear();
                    txtLocation.Clear();

                    selectedTutorIds.Clear();
                    lblSelectedTutors.Text = "Selected Tutors: " + selectedTutorIds.Count();

                    numSlots.Value = numSlots.Minimum;
                    numRequiredTutors.Value = numRequiredTutors.Minimum;
                    dtpSessionDate.Value = DateTime.Today;
                    dtpStartTime.Value = DateTime.Now;
                    dtpEndTime.Value = DateTime.Now.AddHours(1);
                }

                else
                {
                    MessageBox.Show("Unable to create the study session.");
                }
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
            browseSessions = repository.GetBrowseSessions(loggedInUserId);
            DisplayBrowseSessions(browseSessions);
        }


        private void DisplayBrowseSessions(DataTable sessions)
        {
            flpBrowseSessions.Controls.Clear();

            foreach (DataRow row in sessions.Rows)
            {
                Panel sessionCard = new Panel();

                sessionCard.Width = flpBrowseSessions.ClientSize.Width - 35;
                sessionCard.Height = 185;
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
                lblSlots.Text = "Available Slots: " + row["availableSlots"];
                lblSlots.Location = new Point(10, 90);
                lblSlots.AutoSize = true;

                int availableSlots = Convert.ToInt32(row["availableSlots"]);
                int totalSlots = Convert.ToInt32(row["slots"]);

                Label lblLocation = new Label();
                lblLocation.Text = "Location: " + row["location"].ToString();
                lblLocation.Location = new Point(10, 115);
                lblLocation.AutoSize = true;

                int waitlistedCount = Convert.ToInt32(row["waitlistedCount"]);

                Button btnJoinSession = new Button();
                btnJoinSession.Text = "Join Session";
                btnJoinSession.Width = 110;
                btnJoinSession.Height = 30;
                btnJoinSession.Location = new Point(10, 145);
                btnJoinSession.Visible = availableSlots > 0;

                Button btnJoinWaitlist = new Button();
                btnJoinWaitlist.Text = "Join Waitlist";
                btnJoinWaitlist.Width = 120;
                btnJoinWaitlist.Height = 30;
                btnJoinWaitlist.Location = new Point(10, 145);
                btnJoinWaitlist.Visible = availableSlots <= 0 && waitlistedCount < 5;

                btnJoinSession.Click += (sender, e) =>
                {
                    BookingForm bookingForm = new BookingForm(row, loggedInUserId);

                    if (bookingForm.ShowDialog() == DialogResult.OK)
                    {
                        DisplayBrowseSessions(repository.GetBrowseSessions(loggedInUserId));
                    }
                };

                btnJoinWaitlist.Click += (sender, e) =>
                {
                    BookingForm bookingForm = new BookingForm(row, loggedInUserId, false, true);
                    bookingForm.ShowDialog();

                    if (bookingForm.ShowDialog() == DialogResult.OK)
                    {
                        DisplayBrowseSessions(repository.GetBrowseSessions(loggedInUserId));
                    }
                };

                sessionCard.Controls.Add(lblSubject);
                sessionCard.Controls.Add(lblTopic);
                sessionCard.Controls.Add(lblDateTime);
                sessionCard.Controls.Add(lblSlots);
                sessionCard.Controls.Add(lblLocation);
                sessionCard.Controls.Add(btnJoinSession);
                sessionCard.Controls.Add(btnJoinWaitlist);

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

        private void btnMySessions_Click(object sender, EventArgs e)
        {

        }

        private Panel CreateSessionCard(DataRow row)
        {
            Panel card = new Panel();
            card.Width = 250;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Margin = new Padding(0, 5, 0, 5);

            Label lblSubject = new Label();
            lblSubject.Text = row["subject"].ToString();
            lblSubject.Font = new Font("Arial", 12, FontStyle.Bold);
            lblSubject.Location = new Point(10, 10);
            lblSubject.Size = new Size(180, 30);
            lblSubject.AutoEllipsis = true;

            Label lblTopic = new Label();
            lblTopic.Text = "Topic: " + row["topic"].ToString();
            lblTopic.Width = 180;
            lblTopic.Font = new Font("Arial", 10);

            lblTopic.Location = new Point(10, 45);
            lblTopic.Width = 270;
            lblTopic.AutoSize = false;
            lblTopic.AutoEllipsis = true;

            Size topicSize = TextRenderer.MeasureText(
                lblTopic.Text,
                lblTopic.Font,
                new Size(180, 0),
                TextFormatFlags.WordBreak
            );

            lblTopic.Height = topicSize.Height + 5;

            Label lblDate = new Label();
            lblDate.Text = Convert.ToDateTime(row["startDateTime"])
                .ToString("MMMM dd, yyyy");
            lblDate.Location = new Point(10, lblTopic.Bottom + 10);
            lblDate.AutoSize = true;

            Button btnView = new Button();
            btnView.Text = "View Details";
            btnView.Size = new Size(110, 35);
            btnView.Location = new Point(10, lblDate.Bottom + 10);

            string category = "";

            if (DateTime.Now < Convert.ToDateTime(row["startDateTime"]))
                category = "Upcoming";
            else if (DateTime.Now <= Convert.ToDateTime(row["endDateTime"]))
                category = "Ongoing";
            else
                category = "Completed";

            btnView.Click += (sender, e) =>
            {
                SessionDetails detailsForm = new SessionDetails(row, category, loggedInUserId, data => LoadSessionForEditing(data));

                if (detailsForm.ShowDialog() == DialogResult.OK)
                {
                    LoadMySessions();
                }
            };

            card.Height = btnView.Bottom + 15;

            card.Controls.Add(lblSubject);
            card.Controls.Add(lblTopic);
            card.Controls.Add(lblDate);
            card.Controls.Add(btnView);

            return card;
        }
        private void LoadMySessions()
        {
            repository.CancelUnderstaffedSessions();
            DataTable sessions = repository.GetMySessions(loggedInUserId);

            flpUpcomingSessions.Controls.Clear();
            flpOngoingSessions.Controls.Clear();
            flpCompletedSessions.Controls.Clear();

            DateTime now = DateTime.Now;

            foreach (DataRow row in sessions.Rows)
            {
                DateTime start = Convert.ToDateTime(row["startDateTime"]);
                DateTime end = Convert.ToDateTime(row["endDateTime"]);
                string status = row["sessionStatus"].ToString();


                if (status == "Completed")
                {
                    flpCompletedSessions.Controls.Add(CreateSessionCard(row));
                }
                else if (now < start)
                {
                    flpUpcomingSessions.Controls.Add(CreateSessionCard(row));
                }
                else if (now >= start && now <= end)
                {
                    flpOngoingSessions.Controls.Add(CreateSessionCard(row));
                }
                else
                {
                    flpCompletedSessions.Controls.Add(CreateSessionCard(row));
                }
            }
        }

        private void LoadSessionForEditing(DataRow data)
        {
            isEditMode = true;
            selectedTutorIds.Clear();
            editingSessionId = Convert.ToInt32(data["sessionId"]);

            UserRepository repository = new UserRepository();

            DataTable selectedTutors = repository.GetAcceptedSessionTutors(editingSessionId);
            foreach (DataRow tutor in selectedTutors.Rows)
            {
                selectedTutorIds.Add(Convert.ToInt32(tutor["tutorId"]));
            }

            txtSubject.Text = data["subject"].ToString();
            txtTopic.Text = data["topic"].ToString();
            txtLocation.Text = data["location"].ToString();

            DateTime start = Convert.ToDateTime(data["startDateTime"]);
            DateTime end = Convert.ToDateTime(data["endDateTime"]);

            dtpSessionDate.Value = start;
            dtpStartTime.Value = start;
            dtpEndTime.Value = end;

            numSlots.Value = Convert.ToDecimal(data["slots"]);

            if (data["requiredTutors"] != DBNull.Value)
            {
                numRequiredTutors.Value = Convert.ToDecimal(data["requiredTutors"]);
            }

            btnSubmitSession.Text = "Save Changes";

            pnlCreateSession.Visible = true;
            pnlCreateSession.BringToFront();
            DisplayTutorList(txtSearchTutor.Text);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log-out?", "Confirm Logout",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();

                Main loginForm = new Main();
                loginForm.Show();

                this.Close();
            }

        }

        private void btnSwitchTutorMode_Click(object sender, EventArgs e)
        {

        }
    }
}
