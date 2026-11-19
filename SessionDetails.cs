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
        private int sessionId;
        private DataRow sessionData;
        private Action<DataRow> editSessionCallback;
        UserRepository repository = new UserRepository();
        public SessionDetails()
        {
            InitializeComponent();

        }

        public SessionDetails(DataRow sessionData, string category, int userId, Action<DataRow> editCallback)
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
            sessionId = Convert.ToInt32(sessionData[sessionId]);
            this.sessionData = sessionData;
            editSessionCallback = editCallback;

            btnRateTutor.Visible = category == "Completed";
            btnUploadMaterials.Visible = category == "Completed";
            btnViewMaterials.Visible = category == "Completed";

            lblSubject.Text = sessionData["subject"].ToString();
            lblTopic.Text = "Topic: " + sessionData["topic"].ToString();

            DateTime start = Convert.ToDateTime(sessionData["startDateTime"]);
            DateTime end = Convert.ToDateTime(sessionData["endDateTime"]);

            lblDate.Text = "Date: " + start.ToString("MMMM dd, yyyy");
            lblTime.Text = "Time: " + start.ToString("hh:mm tt")
                           + " - " + end.ToString("hh:mm tt");

            lblLocation.Text = "Location: " + sessionData["location"].ToString();
            lblSlots.Text = "Slots: " + sessionData["slots"].ToString();
            lblStatus.Text = "Status: " + sessionData["sessionStatus"].ToString();

            bool isCreator = Convert.ToInt32(sessionData["isCreator"]) == 1;

            if (sessionCategory == "Upcoming")
            {
                btnEditSession.Visible = isCreator;
                btnCancelSession.Visible = isCreator;
                btnCancelBooking.Visible = !isCreator;
            }
            else if (sessionCategory == "Ongoing")
            {
                btnCompleteSession.Visible = isCreator;
            }
            else if (sessionCategory == "Completed")
            {
                btnUploadMaterials.Visible = true;
                btnViewMaterials.Visible = true;
                btnRateTutor.Visible = true;
            }
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {

            DialogResult confirm = MessageBox.Show("Are you sure you want to cancel this booking?", "Cancel Booking",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool success = repository.CancelBooking(loggedInUserId, sessionId);

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
                bool success = repository.CancelSession(sessionId);

                if (success)
                {
                    MessageBox.Show("Your session has been cancelled successfully.");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

                else
                {
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
                UserRepository repository = new UserRepository();

                bool success = repository.CompleteSession(sessionId);

                if (success)
                {
                    MessageBox.Show("Session successfully completed!");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Unable to complete the session.");
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

            SessionActivityForm ratingForm = new SessionActivityForm(sessionId, studentId, "Rate");
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

            SessionActivityForm activityForm = new SessionActivityForm(sessionId, studentId, "Upload");

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

            SessionActivityForm activityForm =
                new SessionActivityForm(sessionId, studentId, "View");

            activityForm.ShowDialog();
        }
    }
}
