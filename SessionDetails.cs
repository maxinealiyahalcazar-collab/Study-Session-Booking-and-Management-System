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
        private Action<Session> editSessionCallback;
        private UserRepository userRepository = new UserRepository();
        private SessionRepository sessionRepository = new SessionRepository();
        private BookingRepository bookingRepository = new BookingRepository();

        private Session sessionData;

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

            sessionCategory = category;
            loggedInUserId = userId;
            sessionId = sessionData.SessionId;
            this.isTutor = isTutor;
            this.sessionData = sessionData;
            editSessionCallback = editCallback;

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

                if (isTutor)
                    btnWithdraw.Visible = !isCreator;

                else
                {
                    btnCancelSession.Visible = isCreator;
                    btnCancelBooking.Visible = !isCreator;
                }
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
            DialogResult confirm = MessageBox.Show("Are you sure you want to cancel this session?", "Cancel Booking",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string oldStatus = sessionData.SessionStatus;
                sessionData.CancelSession();
                bool success = sessionRepository.CancelSession(sessionData);

                if (success)
                {
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
            DialogResult result = MessageBox.Show(
                "Are you sure you want to mark this session as completed?",
                "Complete Session",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

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

            SessionActivityForm ratingForm = new SessionActivityForm(sessionData, studentId, "Rate");
            ratingForm.ShowDialog();
        }

        private void btnUploadMaterials_Click(object sender, EventArgs e)
        {
            UserRepository repository = new UserRepository();

            int studentId = repository.GetStudentIdByUserId(loggedInUserId);

            if (studentId <= 0)
            {
                MessageBox.Show("Student record not found.");
                return;
            }

            SessionActivityForm activityForm = new SessionActivityForm(sessionData, studentId, "Upload");
            activityForm.ShowDialog();
        }

        private void btnViewMaterials_Click(object sender, EventArgs e)
        {
            UserRepository repository = new UserRepository();

            int studentId = repository.GetStudentIdByUserId(loggedInUserId);

            if (studentId <= 0)
            {
                MessageBox.Show("Student record not found.");
                return;
            }

            SessionActivityForm activityForm = new SessionActivityForm(sessionData, studentId, "View");
            activityForm.ShowDialog();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {

        }
    }
}
