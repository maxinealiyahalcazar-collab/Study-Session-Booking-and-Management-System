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
        private int loggedInUserId;
        private UserRepository userRepository = new UserRepository();
        private SessionRepository sessionRepository = new SessionRepository();
        private List<int> selectedTutorIds = new List<int>();
        private List<Tutor> availableTutors = new List<Tutor>();
        private bool isEditMode = false;
        private Session editingSession;
        private int editingSessionId;
        private List<Session> browseSessions = new List<Session>();


        public TutorDashboard(Tutor tutor)
        {
            InitializeComponent();
            loggedInTutor = tutor;
            loggedInUserId = tutor.UserId;

            lblWelcome.Text = $"Welcome back, {loggedInTutor.FullName}!";

            HideAllPanels();
            pnlMainMenu.Visible = true;
            LoadTutorProfile();
            LoadTutorRequestCount();
            LoadTutorAverageRating();
            LoadTutorNotifications();

            dtpSessionDate.MinDate = DateTime.Today;
        }

        private void HideAllPanels()
        {
            Panel[] panels = { pnlMyProfile, pnlMainMenu, pnlMySessions, pnlCreateSession, pnlBrowseSession, pnlRequests, pnlReviews };

            foreach (Panel panel in panels)
            {
                panel.Visible = false;
            }
        }
        private void LoadTutorRequestCount()
        {
            DataTable requests = loggedInTutor.viewRequests(userRepository);
            lblTutorRequestsValue.Text = requests.Rows.Count.ToString();
        }

        private void LoadTutorAverageRating()
        {
            Tutor tutor = userRepository.GetTutorById(loggedInTutor.TutorId);

            if (tutor != null)
            {
                lblTutorRatingValue.Text = tutor.Rating.ToString("0.00");
            }
            else
            {
                lblTutorRatingValue.Text = "0.00";
            }
        }

        private void LoadTutorNotifications()
        {
            DataTable notifications = userRepository.GetNotifications(loggedInTutor.UserId);

            flpNotifications.Controls.Clear();

            foreach (DataRow row in notifications.Rows)
            {
                Panel notificationPanel = new Panel();
                notificationPanel.Width = flpNotifications.ClientSize.Width - 25;
                notificationPanel.Height = 65;
                notificationPanel.BorderStyle = BorderStyle.FixedSingle;
                notificationPanel.Margin = new Padding(5);

                Label lblMessage = new Label();
                lblMessage.Text = row["message"].ToString();
                lblMessage.Location = new Point(10, 10);
                lblMessage.AutoSize = true;
                lblMessage.MaximumSize = new Size(notificationPanel.Width - 20, 0);

                Label lblDate = new Label();
                lblDate.Text = Convert.ToDateTime(row["createdAt"]).ToString("MMM dd, yyyy hh:mm tt");
                lblDate.Location = new Point(10, 35);
                lblDate.AutoSize = true;

                notificationPanel.Controls.Add(lblMessage);
                notificationPanel.Controls.Add(lblDate);

                flpNotifications.Controls.Add(notificationPanel);
            }
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

            btnViewProfile.Visible = false;
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
            HideAllPanels();
            pnlMyProfile.Visible = true;
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

            btnViewProfile.Visible = true;
        }

        private void LoadTutorSessions()
        {
            sessionRepository.CancelUnderstaffedSessions();
            sessionRepository.UpdateOngoingSessions();

            List<Session> tutorSessions = sessionRepository.GetTutorMySessions(loggedInTutor.UserId);

            flpUpcomingSessions.Controls.Clear();
            flpOngoingSessions.Controls.Clear();
            flpCompletedSessions.Controls.Clear();

            foreach (Session session in tutorSessions)
            {
             
                string category = "";

                if (session.SessionStatus == "Completed")
                {
                    category = "Completed";
                }
                else if (session.SessionStatus == "Cancelled")
                {
                    continue;
                }
                else if (DateTime.Now < session.StartDateTime)
                {
                    category = "Upcoming";
                }
                else if (DateTime.Now <= session.EndDateTime)
                {
                    category = "Ongoing";
                }
                else
                {
                    category = "Completed";
                }

                Panel sessionCard = CreateSessionCard(session);

                if (category == "Upcoming")
                {
                    flpUpcomingSessions.Controls.Add(sessionCard);
                }
                else if (category == "Ongoing")
                {
                    flpOngoingSessions.Controls.Add(sessionCard);
                }
                else if (category == "Completed")
                {
                    flpCompletedSessions.Controls.Add(sessionCard);
                }
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

            if (session.SessionStatus == "Completed")
            {
                category = "Completed";
            }
            else if (session.SessionStatus == "Cancelled")
            {
                category = "Cancelled";
            }
            else if (DateTime.Now < session.StartDateTime)
            {
                category = "Upcoming";
            }
            else if (DateTime.Now <= session.EndDateTime)
            {
                category = "Ongoing";
            }
            else
            {
                category = "Completed";
            }

            btnView.Click += (sender, e) =>
            {
                SessionDetails detailsForm = new SessionDetails(session, category, loggedInTutor.UserId, data => LoadSessionForEditing(data), true);

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

        private void btnSubmitSession_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSubject.Text) ||
                string.IsNullOrWhiteSpace(txtTopic.Text) ||
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
                if (editingSession == null)
                {
                    MessageBox.Show("Unable to find the study session.");
                    return;
                }

                bool isValid = editingSession.EditSession(txtSubject.Text.Trim(), txtTopic.Text.Trim(), startDateTime, endDateTime, Convert.ToInt32(numSlots.Value),
                Convert.ToInt32(numRequiredTutors.Value), txtLocation.Text.Trim());

                if (!isValid)
                {
                    MessageBox.Show("Please check your session details.");
                    return;
                }

                bool success = sessionRepository.UpdateSession(editingSession);

                if (success)
                {
                    success = sessionRepository.UpdateSessionTutors(editingSessionId, selectedTutorIds);
                }

                if (success)
                {
                    List<int> participantUserIds = sessionRepository.GetSessionParticipantUserIds(editingSessionId);

                    foreach (int userId in participantUserIds)
                    {
                        userRepository.AddNotification(userId, "The session '" + editingSession.Topic + "' has been updated. Please check the new session details.");
                    }

                    MessageBox.Show("Study session updated successfully!");

                    isEditMode = false;
                    editingSession = null;
                    editingSessionId = 0;

                    selectedTutorIds.Clear();

                    lblSelectedTutors.Text = "Selected Tutors: 0";

                    txtSubject.Clear();
                    txtTopic.Clear();
                    txtLocation.Clear();

                    numSlots.Value = 1;
                    numRequiredTutors.Value = 0;

                    dtpSessionDate.Value = DateTime.Today;
                    dtpStartTime.Value = DateTime.Now;
                    dtpEndTime.Value = DateTime.Now;

                    btnSubmitSession.Text = "Create Session";

                    LoadTutorSessions();
                    return;
                }
                else
                {
                    MessageBox.Show("Unable to update the study session.");
                }

                return;
            }

            Session newSession = loggedInTutor.createSession(txtSubject.Text.Trim(), txtTopic.Text.Trim(), startDateTime, endDateTime,
            Convert.ToInt32(numRequiredTutors.Value), Convert.ToInt32(numSlots.Value), txtLocation.Text.Trim());

            if (newSession == null)
            {
                MessageBox.Show("Invalid session details. Please check the date, time, and other fields.");
                return;
            }

            if (selectedTutorIds.Count != Convert.ToInt32(numRequiredTutors.Value))
            {
                MessageBox.Show("Please select the required number of additional tutors.");
                return;
            }

            int sessionId = sessionRepository.CreateTutorSession(newSession, selectedTutorIds);

            if (sessionId > 0)
            {
                MessageBox.Show("Session created successfully!");

                selectedTutorIds.Clear();

                lblSelectedTutors.Text = "Selected Tutors: 0";

                txtSubject.Clear();
                txtTopic.Clear();
                txtLocation.Clear();

                numSlots.Value = 1;
                numRequiredTutors.Value = 0;

                dtpSessionDate.Value = DateTime.Today;
                dtpStartTime.Value = DateTime.Now;
                dtpEndTime.Value = DateTime.Now;

                LoadTutorSessions();
            }

            else
            {
                MessageBox.Show("Unable to create session.");
            }
        }
  
        private void LoadAvailableTutors()
        {
            availableTutors = sessionRepository.GetAvailableTutors(loggedInUserId);
            DisplayTutorList(txtSearchTutor.Text);
        }

        private void DisplayTutorList(string searchText)
        {
            flpTutorList.Controls.Clear();

            foreach (Tutor tutor in availableTutors)
            {
                if (tutor.TutorId == loggedInTutor.TutorId)
                {
                    continue;
                }

                string tutorName = tutor.FullName;
                string subjects = tutor.Subjects;
                string availability = tutor.Availability;
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
                    tutorCheckBox.Checked = false;
                    tutorCheckBox.Enabled = false;

                    selectedTutorIds.Remove(tutorId);

                }

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

                        if (!selectedTutorIds.Contains(tutorId))
                        {
                            selectedTutorIds.Add(tutorId);
                        }
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
                tutorPanel.Width = flpTutorList.Width - 25;
                tutorPanel.Height = 45;

                tutorCheckBox.Location = new Point(5, 10);
                btnViewProfile.Location = new Point(tutorPanel.Width - btnViewProfile.Width - 10, 5);

                tutorPanel.Controls.Add(tutorCheckBox);
                tutorPanel.Controls.Add(btnViewProfile);

                flpTutorList.Controls.Add(tutorPanel);
            }
        }


        private void dtpSessionDate_ValueChanged(object sender, EventArgs e)
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
        private void btnCreateSession_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            pnlCreateSession.Visible = true;

            LoadAvailableTutors();
        }

        private void txtSearchTutor_Click(object sender, EventArgs e)
        {
            DisplayTutorList(txtSearchTutor.Text);
        }


        private void LoadSessionForEditing(Session session)
        {
            isEditMode = true;
            selectedTutorIds.Clear();

            editingSession = session;
            editingSessionId = session.SessionId;

            List<Tutor> tutors = sessionRepository.GetRequestedSessionTutors(session.SessionId);

            foreach (Tutor tutor in tutors)
            {
                selectedTutorIds.Add(tutor.TutorId);
            }

            lblSelectedTutors.Text = "Selected Tutors: " + selectedTutorIds.Count;
            txtSubject.Text = session.Subject;
            txtTopic.Text = session.Topic;
            txtLocation.Text = session.Location;

            DateTime start = session.StartDateTime;
            DateTime end = session.EndDateTime;

            dtpSessionDate.Value = start;
            dtpStartTime.Value = start;
            dtpEndTime.Value = end;

            numSlots.Value = Convert.ToDecimal(session.Slots);
            numRequiredTutors.Value = Convert.ToDecimal(session.RequiredTutors);

            btnSubmitSession.Text = "Save Changes";

            pnlCreateSession.Visible = true;
            pnlCreateSession.BringToFront();
            DisplayTutorList(txtSearchTutor.Text);
        }

        private void btnMySession_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            pnlMySessions.Visible = true;

            LoadTutorSessions();
        }

        private void LoadBrowseSessions()
        {
            browseSessions = sessionRepository.GetTutorBrowseSessions(loggedInTutor.UserId);
            DisplayBrowseSessions(browseSessions);
            MessageBox.Show("Sessions retrieved: " + browseSessions.Count);
        }
        private void btnBrowseSession_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            pnlBrowseSession.Visible = true;

            LoadBrowseSessions();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            List<Session> filteredSessions = new List<Session>();

            foreach (Session session in browseSessions)
            {
                string subject = session.Subject;
                string topic = session.Topic;

                if (subject.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    topic.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    filteredSessions.Add(session);
                }
            }

            DisplayBrowseSessions(filteredSessions);
        }

        private void DisplayBrowseSessions(List<Session> sessions)
        {
            flpBrowseSession.Controls.Clear();

            foreach (Session session in sessions)
            {
                Panel sessionPanel = new Panel();
                sessionPanel.Width = flpBrowseSession.Width - 25;
                sessionPanel.Height = 155;
                sessionPanel.BorderStyle = BorderStyle.FixedSingle;
                sessionPanel.Margin = new Padding(5);

                Label lblSubject = new Label();
                lblSubject.Text = session.Subject;
                lblSubject.Font = new Font("Arial", 12, FontStyle.Bold);
                lblSubject.Location = new Point(10, 10);
                lblSubject.AutoSize = true;

                Label lblTopic = new Label();
                lblTopic.Text = "Topic: " + session.Topic;
                lblTopic.Location = new Point(10, 40);
                lblTopic.AutoSize = true;

                Label lblDate = new Label();
                lblDate.Text = "Date: " + session.StartDateTime.ToString("MMMM dd, yyyy");
                lblDate.Location = new Point(10, 65);
                lblDate.AutoSize = true;

                Label lblSlots = new Label();
                lblSlots.Text = "Required Tutors: " + session.RequiredTutors;
                lblSlots.Location = new Point(10, 90);
                lblSlots.AutoSize = true;

                Button btnView = new Button();
                btnView.Text = "View Details";
                btnView.Size = new Size(110, 30);
                btnView.Location = new Point(10, 110);

                btnView.Click += (sender, e) =>
                {
                    loggedInTutor.browseSession(session);
                    SessionDetails detailsForm = new SessionDetails(session, "Upcoming", loggedInTutor.UserId, null, true);

                    detailsForm.ShowDialog();
                };

                Button btnTake = new Button();
                btnTake.Text = "Take Session";
                btnTake.Size = new Size(110, 30);
                btnTake.Location = new Point(130, 110);

                btnTake.Click += (sender, e) =>
                {
                    DialogResult confirm = MessageBox.Show("Are you sure you want to take this session?", "Take Session",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        if (userRepository.HasStudentBookingForSession(loggedInUserId, session.SessionId))
                        {
                            MessageBox.Show("You already joined this session as a student. You cannot take it as a tutor.",
                                "Cannot Take Session",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );

                            return;
                        }
                        bool success = loggedInTutor.takeSession(session, sessionRepository);

                        if (success)
                        {
                            MessageBox.Show("You have successfully joined the session!");

                            LoadBrowseSessions();
                            LoadTutorSessions();
                        }
                        else
                        {
                            MessageBox.Show("Unable to take this session. It may no longer have available tutor positions.");
                        }
                    }
                };

                sessionPanel.Controls.Add(lblSubject);
                sessionPanel.Controls.Add(lblTopic);
                sessionPanel.Controls.Add(lblDate);
                sessionPanel.Controls.Add(lblSlots);
                sessionPanel.Controls.Add(btnView);
                sessionPanel.Controls.Add(btnTake);

                flpBrowseSession.Controls.Add(sessionPanel);
            }
        }

        private void LoadTutorRequests()
        {
            DataTable requests = loggedInTutor.viewRequests(userRepository);
            DisplayTutorRequests(requests);
        }

        private void DisplayTutorRequests(DataTable requests)
        {
            flpTutorRequestList.Controls.Clear();

            foreach (DataRow row in requests.Rows)
            {
                Panel requestPanel = new Panel();
                requestPanel.Width = flpTutorRequestList.ClientSize.Width - 25;
                requestPanel.Height = 170;
                requestPanel.BorderStyle = BorderStyle.FixedSingle;
                requestPanel.Margin = new Padding(5);

                Label lblCreator = new Label();
                lblCreator.Text = "Requested by: " + row["creatorName"].ToString();
                lblCreator.Location = new Point(10, 10);
                lblCreator.AutoSize = true;

                Label lblSubject = new Label();
                lblSubject.Text = "Subject: " + row["subject"].ToString();
                lblSubject.Location = new Point(10, 40);
                lblSubject.AutoSize = true;

                Label lblTopic = new Label();
                lblTopic.Text = "Topic: " + row["topic"].ToString();
                lblTopic.Location = new Point(10, 65);
                lblTopic.AutoSize = true;

                Label lblDate = new Label();
                DateTime start = Convert.ToDateTime(row["startDateTime"]);
                DateTime end = Convert.ToDateTime(row["endDateTime"]);
                lblDate.Text = "Date: " + start.ToString("MMMM dd, yyyy") +
                               " | " + start.ToString("hh:mm tt") +
                               " - " + end.ToString("hh:mm tt");
                lblDate.Location = new Point(10, 90);
                lblDate.AutoSize = true;

                Label lblLocation = new Label();
                lblLocation.Text = "Location: " + row["location"].ToString();
                lblLocation.Location = new Point(10, 115);
                lblLocation.AutoSize = true;

                Button btnViewProfile = new Button();
                btnViewProfile.Text = "View Profile";
                btnViewProfile.Size = new Size(110, 30);
                btnViewProfile.Location = new Point(210, 140);

                btnViewProfile.Click += (sender, e) =>
                {
                    int creatorUserId = Convert.ToInt32(row["creatorUserId"]);

                    User profileUser = userRepository.GetUserProfile(creatorUserId);

                    if (profileUser != null)
                    {
                        UserProfile profileForm = new UserProfile(profileUser);
                        profileForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Creator profile not found.");
                    }
                };

                Button btnAccept = new Button();
                btnAccept.Text = "Accept";
                btnAccept.Size = new Size(90, 30);
                btnAccept.Location = new Point(10, 140);

                Button btnDecline = new Button();
                btnDecline.Text = "Decline";
                btnDecline.Size = new Size(90, 30);
                btnDecline.Location = new Point(110, 140);

                int sessionId = Convert.ToInt32(row["sessionId"]);
                int sessionTutorId = Convert.ToInt32(row["sessionTutorId"]);
             
                btnAccept.Click += (sender, e) =>
                {
                    DialogResult confirm = MessageBox.Show(
                        "Are you sure you want to accept this tutor request?",
                        "Accept Request",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (confirm == DialogResult.Yes)
                    {
                        if (userRepository.HasStudentBookingForSession(loggedInUserId, sessionId))
                        {
                            MessageBox.Show("You already joined this session as a student. You cannot accept the tutor request.", "Cannot Accept Request",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );

                            return;
                        }

                        bool success = loggedInTutor.acceptTutorRequest(sessionTutorId, userRepository);

                        if (success)
                        {
                            int creatorUserId = sessionRepository.GetSessionCreatorUserId(sessionId);

                            if (creatorUserId > 0)
                            {
                                userRepository.AddNotification(creatorUserId, loggedInTutor.FullName + " accepted your tutor invitation.");
                            }

                            MessageBox.Show("Tutor request accepted!");
                            LoadTutorRequests();
                        }

                        else
                        {
                            MessageBox.Show("Unable to accept this request.");
                        }
                    }
                };

                btnDecline.Click += (sender, e) =>
                {
                    DialogResult confirm = MessageBox.Show(
                        "Are you sure you want to decline this tutor request?",
                        "Decline Request",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (confirm == DialogResult.Yes)
                    {
                        bool success = loggedInTutor.declineTutorRequest(sessionTutorId, userRepository);

                        if (success)
                        {
                            int creatorUserId = sessionRepository.GetSessionCreatorUserId(sessionId);

                            if (creatorUserId > 0)
                            {
                                userRepository.AddNotification(creatorUserId, loggedInTutor.FullName + " declined your tutor invitation.");
                            }

                            MessageBox.Show("Tutor request declined!");
                            LoadTutorRequests();
                        }

                        else
                        {
                            MessageBox.Show("Unable to decline this request.");
                        }
                    }
                };
                requestPanel.Controls.Add(lblCreator);
                requestPanel.Controls.Add(lblSubject);
                requestPanel.Controls.Add(lblTopic);
                requestPanel.Controls.Add(lblDate);
                requestPanel.Controls.Add(lblLocation);
                requestPanel.Controls.Add(btnViewProfile);
                requestPanel.Controls.Add(btnAccept);
                requestPanel.Controls.Add(btnDecline);

                flpTutorRequestList.Controls.Add(requestPanel);
            }
        }

        private void LoadTutorReviews()
        {
            List<Rating> reviews = userRepository.GetTutorReviews(loggedInTutor);

            DisplayTutorReviews(reviews);
        }

        private void DisplayTutorReviews(List<Rating> reviews)
        {
            flpTutorReviews.Controls.Clear();

            foreach (Rating rating in reviews)
            {
                Session session = sessionRepository.GetSessionById(rating.SessionId);

                if (session == null)
                    continue;

                Panel reviewPanel = new Panel();
                reviewPanel.Width = flpTutorReviews.ClientSize.Width - 25;
                reviewPanel.Height = 150;
                reviewPanel.BorderStyle = BorderStyle.FixedSingle;
                reviewPanel.Margin = new Padding(5);

                Label lblSubject = new Label();
                lblSubject.Text = "Subject: " + session.Subject;
                lblSubject.Location = new Point(10, 10);
                lblSubject.AutoSize = true;

                Label lblTopic = new Label();
                lblTopic.Text = "Topic: " + session.Topic;
                lblTopic.Location = new Point(10, 35);
                lblTopic.AutoSize = true;

                Label lblRating = new Label();
                lblRating.Text = "Rating: " + rating.RatingValue.ToString("0.0") + " / 5.0";
                lblRating.Location = new Point(10, 60);
                lblRating.AutoSize = true;

                Label lblReview = new Label();
                lblReview.Text = "Review: " + rating.ReviewText;
                lblReview.Location = new Point(10, 85);
                lblReview.AutoSize = true;
                lblReview.MaximumSize = new Size(reviewPanel.Width - 20, 0);

                reviewPanel.Controls.Add(lblSubject);
                reviewPanel.Controls.Add(lblTopic);
                reviewPanel.Controls.Add(lblRating);
                reviewPanel.Controls.Add(lblReview);

                flpTutorReviews.Controls.Add(reviewPanel);
            }
        }

        private void btnReadReviews_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            pnlReviews.Visible = true;
            LoadTutorReviews();
        }

        private void btnStudentMode_Click(object sender, EventArgs e)
        {
            Student student = userRepository.GetStudentById(loggedInUserId);

            if (student == null)
            {
                MessageBox.Show("Student profile not found.");
                return;
            }

            StudentDashboard studentDashboard = new StudentDashboard(student);
            studentDashboard.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log-out?", "Confirm Logout",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                loggedInTutor.logout();

                this.Hide();

                Main loginForm = new Main();
                loginForm.Show();

                this.Close();
            }
        }

        private void btnTutorRequests_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            pnlRequests.Visible = true;

            LoadTutorRequests();
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            pnlMainMenu.Visible = true;
            LoadTutorAverageRating();
            LoadTutorRequestCount();
            LoadTutorNotifications();
        }
    }
}
