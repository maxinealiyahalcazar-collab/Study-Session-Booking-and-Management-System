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
                SessionDetails detailsForm = new SessionDetails(
                    session,
                    category,
                    loggedInTutor.UserId,
                    null,
                    true
                );

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
    }
}
