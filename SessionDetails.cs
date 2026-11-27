using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Study_Session
{
    public partial class SessionDetails : Form
    {
        private string sessionCategory;
        private int loggedInUserId;
        private bool isTutor;
        private int sessionId;
        private Session sessionData;
        private Action<Session> editSessionCallback;
        private UserRepository userRepository = new UserRepository();
        private SessionRepository sessionRepository = new SessionRepository();
        private BookingRepository bookingRepository = new BookingRepository();

        public SessionDetails(Session sessionData, string category, int userId, Action<Session> editCallback, bool isTutor = false)
        {
            InitializeComponent();

            btnCancelBooking.Visible = false;
            btnEditSession.Visible = false;
            btnCancelSession.Visible = false;
            btnCompleteSession.Visible = false;
            btnUploadMaterials.Visible = false;
            btnViewMaterials.Visible = false;
            btnRateTutor.Visible = false;
            btnWithdraw.Visible = false;
            btnReadExpectations.Visible = false;

            sessionCategory = category;
            loggedInUserId = userId;
            sessionId = sessionData.SessionId;
            this.isTutor = isTutor;
            this.sessionData = sessionData;

            if (sessionData.SessionStatus == "Completed")
            {
                category = "Completed";
            }
            else if (sessionData.SessionStatus == "Cancelled")
            {
                category = "Cancelled";
            }

            editSessionCallback = editCallback;
            LoadConfirmedTutors();

            btnRateTutor.Visible = category == "Completed";
            btnUploadMaterials.Visible = category == "Completed";
            btnViewMaterials.Visible = category == "Completed";

            lblSubject.Text = sessionData.Subject;
            lblTopic.Text = "Topic: " + sessionData.Topic;

            DateTime start = Convert.ToDateTime(sessionData.StartDateTime);
            DateTime end = Convert.ToDateTime(sessionData.EndDateTime);

            lblDate.Text = "Date: " + start.ToString("MMMM dd, yyyy");
            lblTime.Text = "Time: " + start.ToString("hh:mm tt")
                           + " - " + end.ToString("hh:mm tt");

            lblLocation.Text = "Location: " + sessionData.Location;
            lblSlots.Text = "Slots: " + sessionData.Slots;
            lblStatus.Text = "Status: " + sessionData.SessionStatus;

            bool isCreator;

            if (isTutor)
            {
                int tutorId = userRepository.GetTutorIdByUserId(loggedInUserId);
                isCreator = sessionData.CreatorTutorId == tutorId;
            }
            else
            {
                int studentId = userRepository.GetStudentIdByUserId(loggedInUserId);
                isCreator = sessionData.CreatorStudentId == studentId;
            }


            if (sessionCategory == "Upcoming")
            {
                btnEditSession.Visible = isCreator;
                btnCancelSession.Visible = isCreator;
                btnReadExpectations.Visible = isTutor;

                if (isTutor)
                    btnWithdraw.Visible = !isCreator;
                else
                    btnCancelBooking.Visible = !isCreator;
            }

            else if (sessionCategory == "Ongoing")
            {
                btnCompleteSession.Visible = isCreator;
            }

            else if (sessionCategory == "Completed")
            {
                btnViewMaterials.Visible = true;

                if (!isTutor)
                {
                    btnUploadMaterials.Visible = true;
                    btnRateTutor.Visible = true;
                }
            }
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {

            DialogResult confirm = MessageBox.Show("Are you sure you want to cancel this booking?", "Cancel Booking",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool success = bookingRepository.CancelBooking(loggedInUserId, sessionId);

                if (success)
                {
                    MessageBox.Show("Your booking has been cancelled successfully.");
                    
                    int creatorUserId = sessionRepository.GetSessionCreatorUserId(sessionId);

                    if (creatorUserId > 0)
                    {
                        userRepository.AddNotification(creatorUserId, "A student has cancelled their booking for your session.");
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Unable to cancel your booking.");
                }
            }
        }

        private void btnCancelSession_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to cancel this session?", "Cancel Session",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string oldStatus = sessionData.SessionStatus;
                sessionData.CancelSession();
                bool success = sessionRepository.CancelSession(sessionData);


                if (success)
                {
                    List<int> participantUserIds = sessionRepository.GetSessionParticipantUserIds(sessionId);

                    foreach (int userId in participantUserIds)
                    {
                        userRepository.AddNotification(userId, "The session '" + sessionData.Topic + "' has been cancelled.");
                    }
                    MessageBox.Show("Your session has been cancelled successfully.");



                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

                else
                {
                    sessionData.RestoreSessionStatus(oldStatus);
                    MessageBox.Show("Unable to cancel your session.");
                }
            }
        }

        private void btnEditSession_Click(object sender, EventArgs e)
        {
            if (editSessionCallback != null)
            {
                editSessionCallback.Invoke(sessionData);
                this.Close();
            }
        }

        private void btnCompleteSession_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to mark this session as completed?", "Complete Session",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string oldStatus = sessionData.SessionStatus;
                sessionData.CompleteSession();
                bool success = sessionRepository.UpdateSessionStatus(sessionData);

                if (success)
                {
                    MessageBox.Show("Session successfully completed!");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Unable to complete the session.");
                    sessionData.RestoreSessionStatus(oldStatus);

                }
            }
        }

        private void btnRateTutor_Click(object sender, EventArgs e)
        {
            UserRepository repository = new UserRepository();

            int studentId = repository.GetStudentIdByUserId(loggedInUserId);

            if (studentId <= 0)
            {
                MessageBox.Show("Student record not found.");
                return;
            }

            Student student = repository.GetStudentById(loggedInUserId);

            if (student == null)
            {
                MessageBox.Show("Student information not found.");
                return;
            }

            SessionActivityForm ratingForm = new SessionActivityForm(sessionData, studentId, "Rate", student);
            ratingForm.ShowDialog();
        }

        private void btnUploadMaterials_Click(object sender, EventArgs e)
        {
            UserRepository userRepository = new UserRepository();

            int studentId = userRepository.GetStudentIdByUserId(loggedInUserId);

            if (studentId <= 0)
            {
                MessageBox.Show("Student record not found.");
                return;
            }

            Student student = userRepository.GetStudentById(loggedInUserId);

            if (student == null)
            {
                MessageBox.Show("Student information not found.");
                return;
            }

            SessionActivityForm uploadForm = new SessionActivityForm(sessionData, studentId, "Upload", student);

            uploadForm.ShowDialog();
        }

        private void btnViewMaterials_Click(object sender, EventArgs e)
        {
            UserRepository userRepository = new UserRepository();

            int userId;

            if (isTutor)
            {
                userId = userRepository.GetTutorIdByUserId(loggedInUserId);
            }

            else
            {
                userId = userRepository.GetStudentIdByUserId(loggedInUserId);
            }

            if (userId <= 0)
            {
                MessageBox.Show("User record not found.");
                return;
            }

            SessionActivityForm activityForm = new SessionActivityForm(sessionData, userId, "View");
            activityForm.ShowDialog();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to withdraw from this session?",
            "Withdraw Session", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                int tutorId = userRepository.GetTutorIdByUserId(loggedInUserId);

                bool success = sessionRepository.WithdrawTutorRequest(sessionId, tutorId);

                if (success)
                {
                    MessageBox.Show("You have successfully withdrawn from the session.");

                    int creatorUserId = sessionRepository.GetSessionCreatorUserId(sessionId);

                    Tutor withdrawingTutor = userRepository.GetTutorById(tutorId);
                    if (creatorUserId > 0 && withdrawingTutor != null)
                    {
                        userRepository.AddNotification(
                            creatorUserId,
                            withdrawingTutor.FullName + " has withdrawn from your session."
                        );
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Unable to withdraw from the session.");
                }
            }
        }

        private void LoadConfirmedTutors()
        {
            List<Tutor> confirmedTutors = sessionRepository.GetConfirmedSessionTutors(sessionId);

            flpConfirmedTutors.Controls.Clear();

            if (confirmedTutors.Count == 0)
            {
                Label lblNoTutors = new Label();
                lblNoTutors.Text = "No confirmed tutors yet.";
                lblNoTutors.AutoSize = true;
                lblNoTutors.Margin = new Padding(5);

                flpConfirmedTutors.Controls.Add(lblNoTutors);
                return;
            }

            foreach (Tutor tutor in confirmedTutors)
            {
                Panel tutorPanel = new Panel();
                tutorPanel.Width = flpConfirmedTutors.ClientSize.Width - 25;
                tutorPanel.Height = 40;
                tutorPanel.Margin = new Padding(5);

                Label lblTutorName = new Label();
                lblTutorName.Text = tutor.FullName;
                lblTutorName.AutoSize = true;
                lblTutorName.Location = new Point(10, 10);

                Button btnViewProfile = new Button();
                btnViewProfile.Text = "View Profile";
                btnViewProfile.Size = new Size(100, 30);
                btnViewProfile.Location = new Point(tutorPanel.Width - 110, 5);

                btnViewProfile.Click += (sender, e) =>
                {
                    User profileUser = userRepository.GetUserProfile(tutor.UserId);

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

                tutorPanel.Controls.Add(lblTutorName);
                tutorPanel.Controls.Add(btnViewProfile);
                flpConfirmedTutors.Controls.Add(tutorPanel);
            }
        }

        private void btnReadExpectations_Click(object sender, EventArgs e)
        {
            SessionActivityForm activityForm = new SessionActivityForm(sessionData, loggedInUserId, "Expectations");
            activityForm.ShowDialog();
        }
    }
}
