using Microsoft.VisualBasic.ApplicationServices;
using MySqlX.XDevAPI;
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
        private Student loggedInStudent;
        private UserRepository userRepository = new UserRepository();
        private SessionRepository sessionRepository = new SessionRepository();
        private BookingRepository bookingRepository = new BookingRepository();
        List<Tutor> availableTutors = new List<Tutor>();
        private List<Session> browseSessions;
        private bool isEditMode = false;
        private int editingSessionId = 0;
        private Session editingSession;
        private List<int> selectedTutorIds = new List<int>();

        public StudentDashboard(Student student)
        {
            InitializeComponent();

            loggedInStudent = student;
            loggedInUserId = student.UserId;

            lblWelcome.Text = $"Welcome back, {loggedInStudent.FullName}!";

            int bookedCount = userRepository.GetBookedSessionCount(loggedInUserId);
            lblBookedCount.Text = bookedCount.ToString();

            int waitlistedCount = userRepository.GetWaitlistedSessionCount(loggedInUserId);
            lblWaitlistedCount.Text = waitlistedCount.ToString();

            int completedCount = userRepository.GetCompletedSessionCount(loggedInUserId);
            lblCompletedCount.Text = completedCount.ToString();

            LoadNotifications();
            LoadAvailableTutors();
            LoadBrowseSessions();
            LoadMySessions();

            dtpSessionDate.MinDate = DateTime.Today;
        }

        private void LoadNotifications()
        {
            loggedInStudent.viewNotifications(flpNotifications);
        }

        private void LoadStudentProfile()
        {
            User studentProfile = userRepository.GetUserProfile(loggedInUserId);

            if (studentProfile != null)
            {
                lblProfileFullNameValue.Text = studentProfile.FullName;
                lblProfileUEGmailValue.Text = studentProfile.UEGmail;
                lblProfileYearValue.Text = studentProfile.Year;
                lblProfileProgramValue.Text = studentProfile.Program;
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
            if (string.IsNullOrWhiteSpace(txtEditFullName.Text) ||
                string.IsNullOrWhiteSpace(txtEditUEGmail.Text) ||
                string.IsNullOrWhiteSpace(txtEditYear.Text) ||
                string.IsNullOrWhiteSpace(txtEditProgram.Text))
            {
                MessageBox.Show("Please complete all fields.");
                return;
            }

            try
            {
                bool valid = loggedInStudent.editProfile(txtEditFullName.Text.Trim(), txtEditUEGmail.Text.Trim(), txtEditYear.Text.Trim(),
                txtEditProgram.Text.Trim());

                if (!valid)
                {
                    MessageBox.Show("Please complete all fields.");
                    return;
                }

                bool updated = userRepository.UpdateStudentProfile(loggedInStudent);

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
                MessageBox.Show("Error updating profile. " + ex.Message);
            }
        }

        private void btnViewProfile_Click(object sender, EventArgs e)
        {
            loggedInStudent.viewProfile();
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
                if (editingSession == null)
                {
                    MessageBox.Show("Unable to find the study session.");
                    return;
                }

                string oldSubject = editingSession.Subject;
                string oldTopic = editingSession.Topic;
                DateTime oldStartDateTime = editingSession.StartDateTime;
                DateTime oldEndDateTime = editingSession.EndDateTime;
                int oldSlots = editingSession.Slots;
                int oldRequiredTutors = editingSession.RequiredTutors;
                string oldLocation = editingSession.Location;

                bool isValid = editingSession.EditSession(txtSubject.Text.Trim(), txtTopic.Text.Trim(), startDateTime, endDateTime, (int)numSlots.Value, (int)numRequiredTutors.Value, txtLocation.Text.Trim());

                if (!isValid)
                {
                    MessageBox.Show("Please check your session details. Make sure all fields are valid.");
                    return;
                }

                bool success = sessionRepository.UpdateSession(editingSession);

                if (success)
                {
                    success = sessionRepository.UpdateSessionTutors(editingSessionId, selectedTutorIds);
                }

                else
                {
                    MessageBox.Show("Unable to update the study session.");
                }
            }

            else
            {
                Session newSession = loggedInStudent.createSession(txtSubject.Text.Trim(), txtTopic.Text.Trim(), startDateTime,
                endDateTime, (int)numRequiredTutors.Value, (int)numSlots.Value, txtLocation.Text.Trim());

                if (newSession == null)
                {
                    MessageBox.Show("Invalid session details.");
                    return;
                }

                int newSessionId = sessionRepository.createStudentSession(newSession, selectedTutorIds);

                if (newSessionId > 0)
                {
                    MessageBox.Show("Study session created successfully!");
                    
                    txtSubject.Clear();
                    txtTopic.Clear();
                    txtLocation.Clear();

                    numSlots.Value = 1;
                    numRequiredTutors.Value = 0;

                    dtpSessionDate.Value = DateTime.Today;
                    dtpStartTime.Value = DateTime.Now;
                    dtpEndTime.Value = DateTime.Now;

                    lblSelectedTutors.Text = "Selected Tutors: 0";
                }
                else
                {
                    MessageBox.Show("Unable to create the study session.");
                }
            }
        }
        private void LoadAvailableTutors()
        {
            availableTutors = userRepository.GetAvailableTutors();    
            DisplayTutorList(txtSearchTutor.Text);

        }
        private void DisplayTutorList(string searchText)
        {
            flpTutorList.Controls.Clear();

            foreach (Tutor tutor in availableTutors)
            {
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
                    tutorCheckBox.Enabled = false;
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

                        if (loggedInStudent.requestTutor(tutor))
                        {
                            selectedTutorIds.Add(tutorId);
                        }
                        else
                        {
                            tutorCheckBox.Checked = false;
                            return;
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
            browseSessions = sessionRepository.GetBrowseSessions(loggedInUserId);
            DisplayBrowseSessions(browseSessions);
        }


        private void DisplayBrowseSessions(List<Session> sessions)
        {
            flpBrowseSessions.Controls.Clear();

            foreach (Session session in sessions)
            {
                Panel sessionCard = new Panel();
                loggedInStudent.browseSession(session);

                sessionCard.Width = flpBrowseSessions.ClientSize.Width - 35;
                sessionCard.Height = 185;
                sessionCard.BorderStyle = BorderStyle.FixedSingle;
                sessionCard.Margin = new Padding(5);
                sessionCard.Padding = new Padding(10);

                Label lblSubject = new Label();
                lblSubject.Text = session.Subject;
                lblSubject.Font = new Font("Arial", 12, FontStyle.Bold);
                lblSubject.Location = new Point(10, 10);
                lblSubject.AutoSize = true;

                Label lblTopic = new Label();
                lblTopic.Text = "Topic: " + session.Topic;
                lblTopic.Location = new Point(10, 40);
                lblTopic.AutoSize = true;

                DateTime start = session.StartDateTime;
                DateTime end = session.EndDateTime;

                Label lblDateTime = new Label();
                lblDateTime.Text = start.ToString("MMMM dd, yyyy") +
                    " | " + start.ToString("hh:mm tt") +
                    " - " + end.ToString("hh:mm tt");
                lblDateTime.Location = new Point(10, 65);
                lblDateTime.AutoSize = true;

                Label lblSlots = new Label();
                lblSlots.Text = "Available Slots: " + session.AvailableSlots;
                lblSlots.Location = new Point(10, 90);
                lblSlots.AutoSize = true;

                int availableSlots = session.AvailableSlots;
                int totalSlots = session.Slots;

                Label lblLocation = new Label();
                lblLocation.Text = "Location: " + session.Location;
                lblLocation.Location = new Point(10, 115);
                lblLocation.AutoSize = true;

                int waitlistedCount = session.WaitlistedCount;

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
                
                Button btnViewDetails = new Button();
                btnViewDetails.Text = "View Details";
                btnViewDetails.Width = 110;
                btnViewDetails.Height = 30;
                btnViewDetails.Location = new Point(135, 145);

                btnViewDetails.Click += (sender, e) =>
                {
                    SessionDetails detailsForm = new SessionDetails(session, "Browse", loggedInUserId, null);

                    detailsForm.ShowDialog();
                };

                btnJoinSession.Click += (sender, e) =>
                {
                    BookingForm bookingForm = new BookingForm(session, loggedInUserId);

                    if (bookingForm.ShowDialog() == DialogResult.OK)
                    {
                        DisplayBrowseSessions(sessionRepository.GetBrowseSessions(loggedInUserId));
                    }
                };

                btnJoinWaitlist.Click += (sender, e) =>
                {
                    string result = bookingRepository.JoinSession(loggedInUserId, session.SessionId, "");

                    if (result == "Waitlisted")
                    {
                        MessageBox.Show("You have been added to the waitlist!");

                        DisplayBrowseSessions(sessionRepository.GetBrowseSessions(loggedInUserId));
                        LoadMySessions();
                    }

                    else if (result == "Joined")
                    {
                        BookingForm bookingForm = new BookingForm(session, loggedInUserId, false, true);

                        if (bookingForm.ShowDialog() == DialogResult.OK)
                        {
                            DisplayBrowseSessions(sessionRepository.GetBrowseSessions(loggedInUserId));
                            LoadMySessions();
                        }
                    }

                    else
                    {
                        MessageBox.Show(result);
                    }
                };

                sessionCard.Controls.Add(lblSubject);
                sessionCard.Controls.Add(lblTopic);
                sessionCard.Controls.Add(lblDateTime);
                sessionCard.Controls.Add(lblSlots);
                sessionCard.Controls.Add(lblLocation);
                sessionCard.Controls.Add(btnJoinSession);
                sessionCard.Controls.Add(btnJoinWaitlist);
                sessionCard.Controls.Add(btnViewDetails);

                flpBrowseSessions.Controls.Add(sessionCard);
            }
        }

        private void txtSearchSessions_TextChanged_1(object sender, EventArgs e)
        {
            string searchText = txtSearchSessions.Text.Trim();

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

        private void btnMySessions_Click(object sender, EventArgs e)
        {
            LoadMySessions();
        }

        private Panel CreateSessionCard(Session session)
        {
            Panel card = new Panel();
            card.Width = 250;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Margin = new Padding(0, 5, 0, 5);

            Label lblSubject = new Label();
            lblSubject.Text = session.Subject;
            lblSubject.Font = new Font("Arial", 12, FontStyle.Bold);
            lblSubject.Location = new Point(10, 10);
            lblSubject.Size = new Size(180, 30);
            lblSubject.AutoEllipsis = true;

            Label lblTopic = new Label();
            lblTopic.Text = "Topic: " + session.Topic;
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
            lblDate.Text = session.StartDateTime.ToString("MMMM dd, yyyy");
            lblDate.Location = new Point(10, lblTopic.Bottom + 10);
            lblDate.AutoSize = true;

            Label lblTutor = new Label();
            lblTutor.Text = string.IsNullOrEmpty(session.CreatorTutorName)
                ? "Tutor: Not assigned"
                : "Tutor: " + session.CreatorTutorName;

            lblTutor.Location = new Point(10, lblDate.Bottom + 10);
            lblTutor.AutoSize = true;

            Button btnView = new Button();
            btnView.Text = "View Details";
            btnView.Size = new Size(110, 35);
            btnView.Location = new Point(10, lblTutor.Bottom + 10);

            string category = "";

            if (DateTime.Now < session.StartDateTime)
                category = "Upcoming";

            else if (DateTime.Now <= session.EndDateTime)
                category = "Ongoing";

            else
                category = "Completed";

            btnView.Click += (sender, e) =>
            {
                SessionDetails detailsForm = new SessionDetails(session, category, loggedInUserId, data => LoadSessionForEditing(data));

                if (detailsForm.ShowDialog() == DialogResult.OK)
                {
                    LoadMySessions();
                }
            };

            card.Height = btnView.Bottom + 15;

            card.Controls.Add(lblSubject);
            card.Controls.Add(lblTopic);
            card.Controls.Add(lblDate);
            card.Controls.Add(lblTutor);
            card.Controls.Add(btnView);

            return card;
        }

        private Panel CreateWaitlistedSessionCard(Booking booking)
        {
            Session session = sessionRepository.GetSessionById(booking.SessionId);

            if (session == null)
                return null;

            Panel card = new Panel();
            card.Width = 250;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Margin = new Padding(0, 5, 0, 5);

            Label lblSubject = new Label();
            lblSubject.Text = session.Subject;
            lblSubject.Font = new Font("Arial", 12, FontStyle.Bold);
            lblSubject.Location = new Point(10, 10);
            lblSubject.Size = new Size(180, 30);
            lblSubject.AutoEllipsis = true;

            Label lblTopic = new Label();
            lblTopic.Text = "Topic: " + session.Topic;
            lblTopic.Location = new Point(10, 45);
            lblTopic.Size = new Size(220, 30);
            lblTopic.Font = new Font("Arial", 10);
            lblTopic.AutoEllipsis = true;

            Label lblDate = new Label();
            lblDate.Text = session.StartDateTime.ToString("MMMM dd, yyyy");
            lblDate.Location = new Point(10, 80);
            lblDate.AutoSize = true;

            Label lblStatus = new Label();
            lblStatus.Text = "Status: " + booking.BookingStatus;
            lblStatus.Location = new Point(10, 105);
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Arial", 10, FontStyle.Bold);

            card.Controls.Add(lblSubject);
            card.Controls.Add(lblTopic);
            card.Controls.Add(lblDate);
            card.Controls.Add(lblStatus);
            
            Button btnView = new Button();
            btnView.Text = "View Details";
            btnView.Size = new Size(110, 35);
            btnView.Location = new Point(10, 135);

            string category = "";

            if (DateTime.Now < session.StartDateTime)
                category = "Upcoming";
            else if (DateTime.Now <= session.EndDateTime)
                category = "Ongoing";
            else
                category = "Completed";

            btnView.Click += (sender, e) =>
            {
                SessionDetails detailsForm = new SessionDetails(session, category, loggedInUserId, data => LoadSessionForEditing(data));

                if (detailsForm.ShowDialog() == DialogResult.OK)
                {
                    LoadMySessions();
                }
            };

            card.Controls.Add(btnView);
            if (booking.BookingStatus == "Pending")
            {
                Button btnPayment = new Button();
                btnPayment.Text = "Complete Payment";
                btnPayment.Size = new Size(150, 35);
                btnPayment.Location = new Point(10, 175);

                btnPayment.Click += (sender, e) =>
                {
                    BookingForm bookingForm = new BookingForm(session, loggedInUserId, false, true);

                    if (bookingForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadMySessions();
                    }
                };

                card.Controls.Add(btnPayment);
                card.Height = btnPayment.Bottom + 15;
            }
            else
            {
                card.Height = btnView.Bottom + 15;
            }

            return card;
        }
        private void LoadMySessions()
        {
            List<Session> understaffedSessions = sessionRepository.GetUnderstaffedSessions();

            foreach (Session session in understaffedSessions)
            {
                string oldStatus = session.SessionStatus;
                session.CancelSession();
                bool success = sessionRepository.CancelSession(session);

                if (!success)
                {
                    session.RestoreSessionStatus(oldStatus);
                }
            }

            List<Session> sessions = loggedInStudent.viewMySessions();

            flpUpcomingSessions.Controls.Clear();
            flpOngoingSessions.Controls.Clear();
            flpCompletedSessions.Controls.Clear();
            flpWaitlistedSessions.Controls.Clear();

            DateTime now = DateTime.Now;

            foreach (Session session in sessions)
            {
                DateTime start = session.StartDateTime;
                DateTime end = session.EndDateTime;
                string status = session.SessionStatus;


                if (status == "Completed")
                {
                    flpCompletedSessions.Controls.Add(CreateSessionCard(session));
                }
                else if (now < start)
                {
                    flpUpcomingSessions.Controls.Add(CreateSessionCard(session));
                }
                else if (now >= start && now <= end)
                {
                    flpOngoingSessions.Controls.Add(CreateSessionCard(session));
                }
                else
                {
                    flpCompletedSessions.Controls.Add(CreateSessionCard(session));
                }
            }

            List<Booking> waitlistedBookings = bookingRepository.GetMyWaitlistedBookings(loggedInUserId);

            foreach (Booking booking in waitlistedBookings)
            {
                Panel card = CreateWaitlistedSessionCard(booking);

                if (card != null)
                {
                    flpWaitlistedSessions.Controls.Add(card);
                }
            }
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log-out?", "Confirm Logout",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                loggedInStudent.logout();

                this.Hide();

                Main loginForm = new Main();
                loginForm.Show();

                this.Close();
            }

        }

        private void btnSwitchTutorMode_Click(object sender, EventArgs e)
        {
            User existingProfile = userRepository.GetUserProfile(loggedInStudent.UserId);

            if (existingProfile is Tutor existingTutor)
            {
                MessageBox.Show("You are already registered as a tutor.");
                existingTutor.LoadDashboard(null);
                this.Hide();
                return;
            }   

            Tutor newTutor = loggedInStudent.becomeTutor();

            if (newTutor == null)
            {
                MessageBox.Show("Unable to switch to Tutor.");
                return;
            }

            Tutor registeredTutor = userRepository.CreateTutor(newTutor);

            if (registeredTutor != null)
            {
                MessageBox.Show("You have successfully registered as a tutor!");
                registeredTutor.LoadDashboard(null);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Unable to register as a tutor.");
            }
        }
    }
}
