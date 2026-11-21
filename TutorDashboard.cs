using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Study_Session
{
    public partial class TutorDashboard : Form
    {
        private Tutor loggedInTutor;
        private UserRepository userRepository = new UserRepository();
        private SessionRepository sessionRepository = new SessionRepository();
        private List<int> selectedTutorIds = new List<int>();
        private List<Tutor> availableTutors = new List<Tutor>();

        public TutorDashboard()
        {
            InitializeComponent();
        }

        public TutorDashboard(Tutor tutor)
        {
            InitializeComponent();
            pnlCreateSession.Visible = false;
            flpBrowseSessions.Visible = false;
            pnlMain.Visible = false;
            pnlMyProfile.Visible = true;
            loggedInTutor = tutor;
            lblWelcome.Text = $"Welcome back, {loggedInTutor.FullName}!";

            LoadTutorProfile();
        }

        private void LoadTutorProfile()
        {
            lblProfileSubjectsValue.Text = loggedInTutor.Subjects;
            lblProfileAvailabilityValue.Text = loggedInTutor.Availability;
            lblProfileCredentialValue.Text = loggedInTutor.Credentials;
            lblProfileRatingValue.Text = loggedInTutor.Rating.ToString("0.00");
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            txtEditSubject.Text = lblProfileSubjectsValue.Text;
            txtEditAvailability.Text = lblProfileAvailabilityValue.Text;
            txtEditCredential.Text = lblProfileCredentialValue.Text;

            lblProfileSubjectsValue.Visible = false;
            lblProfileAvailabilityValue.Visible = false;
            lblProfileCredentialValue.Visible = false;

            txtEditSubject.Visible = true;
            txtEditAvailability.Visible = true;
            txtEditCredential.Visible = true;

            btnEditProfile.Visible = false;
            btnSaveProfile.Visible = true;
            btnCancelProfile.Visible = true;
        }

        private void btnViewProfile_Click(object sender, EventArgs e)
        {
            loggedInTutor.viewProfile();
        }

        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            pnlMyProfile.BringToFront();
        }

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEditSubject.Text) ||
               string.IsNullOrWhiteSpace(txtEditAvailability.Text) ||
               string.IsNullOrWhiteSpace(txtEditCredential.Text))
            {
                MessageBox.Show("Please complete all profile fields.");
                return;
            }

            loggedInTutor.Subjects = txtEditSubject.Text.Trim();
            loggedInTutor.Availability = txtEditAvailability.Text.Trim();
            loggedInTutor.Credentials = txtEditCredential.Text.Trim();

            bool updated = userRepository.UpdateTutorProfile(loggedInTutor);

            if (updated)
            {
                MessageBox.Show("Tutor profile updated successfully!");

                LoadTutorProfile();

                txtEditSubject.Visible = false;
                txtEditAvailability.Visible = false;
                txtEditCredential.Visible = false;

                lblProfileSubjectsValue.Visible = true;
                lblProfileAvailabilityValue.Visible = true;
                lblProfileCredentialValue.Visible = true;

                btnEditProfile.Visible = true;
                btnSaveProfile.Visible = false;
                btnCancelProfile.Visible = false;
            }
            else
            {
                MessageBox.Show("Unable to update tutor profile.");
            }
        }

        private void LoadTutorSessions()
        {
            List<Session> tutorSessions = sessionRepository.GetTutorMySessions(loggedInTutor.UserId);

            flpUpcomingSessions.Controls.Clear();
            flpOngoingSessions.Controls.Clear();
            flpCompletedSessions.Controls.Clear();

            foreach (Session session in tutorSessions)
            {
                string category = "";

                if (DateTime.Now < session.StartDateTime)
                    category = "Upcoming";

                else if (DateTime.Now <= session.EndDateTime)
                    category = "Ongoing";

                else
                    category = "Completed";

                Panel sessionCard = CreateSessionCard(session);

                if (category == "Upcoming")
                    flpUpcomingSessions.Controls.Add(sessionCard);

                else if (category == "Ongoing")
                    flpOngoingSessions.Controls.Add(sessionCard);

                else
                    flpCompletedSessions.Controls.Add(sessionCard);
            }
        }

        private Panel CreateSessionCard(Session session)
        {
            Panel card = new Panel();
            card.Width = 250;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Margin = new Padding(0, 5, 0, 5);

            Label lblSubjects = new Label();
            lblSubjects.Text = session.Subject;
            lblSubjects.Font = new Font("Arial", 12, FontStyle.Bold);
            lblSubjects.Location = new Point(10, 10);
            lblSubjects.Size = new Size(180, 30);
            lblSubjects.AutoEllipsis = true;

            Label lblTopics = new Label();
            lblTopics.Text = "Topic: " + session.Topic;
            lblTopics.Width = 180;
            lblTopics.Font = new Font("Arial", 10);

            lblTopics.Location = new Point(10, 45);
            lblTopics.Width = 270;
            lblTopics.AutoSize = false;
            lblTopics.AutoEllipsis = true;

            Size topicSize = TextRenderer.MeasureText(
                lblTopics.Text,
                lblTopics.Font,
                new Size(180, 0),
                TextFormatFlags.WordBreak
            );

            lblTopics.Height = topicSize.Height + 5;

            Label lblDate = new Label();
            lblDate.Text = session.StartDateTime.ToString("MMMM dd, yyyy");
            lblDate.Location = new Point(10, lblTopics.Bottom + 10);
            lblDate.AutoSize = true;

            Button btnView = new Button();
            btnView.Text = "View Details";
            btnView.Size = new Size(110, 35);
            btnView.Location = new Point(10, lblDate.Bottom + 10);

            string category = "";

            if (DateTime.Now < session.StartDateTime)
                category = "Upcoming";

            else if (DateTime.Now <= session.EndDateTime)
                category = "Ongoing";

            else
                category = "Completed";

            btnView.Click += (sender, e) =>
            {
                SessionDetails detailsForm = new SessionDetails(session, category, loggedInTutor.UserId, null, true);

                if (detailsForm.ShowDialog() == DialogResult.OK)
                {
                    LoadTutorSessions();
                }
            };

            card.Height = btnView.Bottom + 15;

            card.Controls.Add(lblSubjects);
            card.Controls.Add(lblTopics);
            card.Controls.Add(lblDate);
            card.Controls.Add(btnView);

            return card;
        }

        private void btnSubmitSession2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSubject3.Text) ||
                string.IsNullOrWhiteSpace(txtTopic3.Text) ||
                string.IsNullOrWhiteSpace(txtLocation2.Text))
            {
                MessageBox.Show("Please complete all fields.");
                return;
            }

            if (numSlots2.Value <= 0)
            {
                MessageBox.Show("Please enter at least one available slot.");
                return;
            }

            DateTime selectedDate = dtpSessionDate2.Value.Date;
            DateTime startDateTime = selectedDate.Add(dtpStartTime2.Value.TimeOfDay);
            DateTime endDateTime = selectedDate.Add(dtpEndTime2.Value.TimeOfDay);

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

            Session newSession = loggedInTutor.createSession(txtSubject3.Text.Trim(), txtTopic3.Text.Trim(), startDateTime, endDateTime,
            Convert.ToInt32(numRequiredTutors2.Value), Convert.ToInt32(numSlots2.Value), txtLocation2.Text.Trim());

            if (newSession == null)
            {
                MessageBox.Show("Invalid session details. Please check the date, time, and other fields.");
                return;
            }

            if (selectedTutorIds.Count != Convert.ToInt32(numRequiredTutors2.Value))
            {
                MessageBox.Show("Please select the required number of additional tutors.");
                return;
            }

            int sessionId = sessionRepository.createTutorSession(newSession, selectedTutorIds);

            if (sessionId > 0)
            {
                MessageBox.Show("Session created successfully!");
                selectedTutorIds.Clear();
                lblSelectedTutors2.Text = "Selected Tutors: 0";

                txtSubject3.Clear();
                txtTopic3.Clear();
                txtLocation2.Clear();

                numSlots2.Value = 1;
                numRequiredTutors2.Value = 0;

                dtpSessionDate2.Value = DateTime.Today;
                dtpStartTime2.Value = DateTime.Now;
                dtpEndTime2.Value = DateTime.Now;

                LoadTutorSessions();
            }

            else
            {
                MessageBox.Show("Unable to create session.");
                return;
            }
        }
        private void LoadAvailableTutors()
        {
            availableTutors = userRepository.GetAvailableTutors();
            DisplayTutorList(txtSearchTutor2.Text);
        }

        private void DisplayTutorList(string searchText)
        {
            flpTutorList2.Controls.Clear();

            foreach (Tutor tutor in availableTutors)
            {
                if (tutor.TutorId == loggedInTutor.TutorId)
                {
                    continue;
                }

                string tutorName = tutor.FullName;
                string subjects = tutor.Subjects;
                string availability = tutor.Availability;
                string sessionDay = dtpSessionDate2.Value.DayOfWeek.ToString();
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

                bool isSelected = selectedTutorIds.Contains(tutor.TutorId);

                if (!isAvailable && !isSelected)
                {
                    continue;
                }

                if (!tutorName.Contains(searchText, StringComparison.OrdinalIgnoreCase) && !subjects.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                int tutorId = tutor.TutorId;
                CheckBox tutorCheckBox = new CheckBox();

                tutorCheckBox.Text = tutorName;

                tutorCheckBox.Tag = tutorId;
                tutorCheckBox.AutoSize = true;
                tutorCheckBox.Margin = new Padding(5);
                tutorCheckBox.Checked = selectedTutorIds.Contains(tutorId);

                if (!isAvailable)
                {
                    tutorCheckBox.Text = tutorName + " (Unavailable)";
                    tutorCheckBox.Enabled = false;
                }

                tutorCheckBox.CheckedChanged += (sender, e) =>
                {
                    if (tutorCheckBox.Checked)
                    {
                        if (selectedTutorIds.Count >= numRequiredTutors2.Value)
                        {
                            MessageBox.Show("You can only select up to " + numRequiredTutors2.Value + " tutors.");
                            tutorCheckBox.Checked = false;
                            return;
                        }

                        if (!selectedTutorIds.Contains(tutorId))
                        {
                            selectedTutorIds.Add(tutorId);
                        }
                    }

                    else
                    {
                        selectedTutorIds.Remove(tutorId);
                    }

                    lblSelectedTutors2.Text = "Selected Tutors: " + selectedTutorIds.Count;
                };

                Button btnViewProfile = new Button();

                btnViewProfile.Text = "View Profile";
                btnViewProfile.AutoSize = true;
                btnViewProfile.Margin = new Padding(5);

                btnViewProfile.Click += (sender, e) =>
                {
                    int selectedUserId = tutor.UserId;

                    User profileUser = userRepository.GetUserProfile(selectedUserId);

                    if (profileUser != null)
                    {
                        UserProfile profileForm = new UserProfile(profileUser);
                        profileForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Profile not found.");
                    }
                };

                Panel tutorPanel = new Panel();
                tutorPanel.Width = flpTutorList2.Width - 25;
                tutorPanel.Height = 45;

                tutorCheckBox.Location = new Point(5, 10);
                btnViewProfile.Location = new Point(tutorPanel.Width - btnViewProfile.Width - 10, 5);

                tutorPanel.Controls.Add(tutorCheckBox);
                tutorPanel.Controls.Add(btnViewProfile);

                flpTutorList2.Controls.Add(tutorPanel);
            }
        }

        private void txtSearchTutor2_TextChanged(object sender, EventArgs e)
        {
            DisplayTutorList(txtSearchTutor2.Text);
        }

        private void dtpSessionDate2_ValueChanged(object sender, EventArgs e)
        {
            DisplayTutorList(txtSearchTutor2.Text);
        }

        private void numRequiredTutors2_ValueChanged(object sender, EventArgs e)
        {
            if (numRequiredTutors.Value < selectedTutorIds.Count)
            {
                MessageBox.Show("You cannot set the required tutors below the number of tutors already selected.");

                numRequiredTutors.Value = selectedTutorIds.Count;
            }
        }
        private void btnCreateSession_Click(object sender, EventArgs e)
        {
            LoadAvailableTutors();
        }
    }

}
