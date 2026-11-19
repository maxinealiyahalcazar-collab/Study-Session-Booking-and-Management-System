using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Study_Session
{
    public partial class BookingForm : Form
    {
        private int loggedInUserId;
        private int sessionId;
        private bool isCreator;
        private bool isWaitlist;

        private UserRepository repository = new UserRepository();
        public BookingForm()
        {
            InitializeComponent();
        }

        public BookingForm(DataRow sessionData, int userId, bool creator = false, bool waitlist = false)
        {
            InitializeComponent();
            loggedInUserId = userId;
            isCreator = creator;
            sessionId = Convert.ToInt32(sessionData["sessionId"]);
            isWaitlist = waitlist;

            lblSubject.Text = sessionData["subject"].ToString();
            lblTopic.Text = sessionData["topic"].ToString();

            DateTime start = Convert.ToDateTime(sessionData["startDateTime"]);
            DateTime end = Convert.ToDateTime(sessionData["endDateTime"]);

            lblDate.Text = start.ToString("MMMM dd, yyyy");
            lblTime.Text = start.ToString("hh:mm tt") + " - " + end.ToString("hh:mm tt");
            lblLocation.Text = sessionData["location"].ToString();
            lblSlots.Text = sessionData["availableSlots"].ToString() + " / " + sessionData["slots"].ToString();
            lblRequiredTutors.Text = sessionData["requiredTutors"].ToString();

            LoadAcceptedTutors(Convert.ToInt32(sessionData["sessionId"]));
        }


        private void LoadAcceptedTutors(int sessionId)
        {
            UserRepository repository = new UserRepository();

            DataTable tutors = repository.GetAcceptedSessionTutors(sessionId);

            flpSessionTutors.Controls.Clear();

            foreach (DataRow row in tutors.Rows)
            {
                Panel tutorCard = new Panel();
                tutorCard.Width = 280;
                tutorCard.Height = 90;
                tutorCard.BorderStyle = BorderStyle.FixedSingle;
                tutorCard.Margin = new Padding(5);

                Label lblName = new Label();
                lblName.Text = row["fullName"].ToString();
                lblName.Font = new Font("Arial", 10, FontStyle.Bold);
                lblName.Location = new Point(10, 10);
                lblName.AutoSize = true;

                Label lblSubjects = new Label();
                lblSubjects.Text = "Subjects: " + row["subjects"].ToString();
                lblSubjects.Location = new Point(10, 35);
                lblSubjects.AutoSize = true;

                Label lblRating = new Label();
                lblRating.Text = "Rating: " + row["rating"].ToString();
                lblRating.Location = new Point(10, 60);
                lblRating.AutoSize = true;

                tutorCard.Controls.Add(lblName);
                tutorCard.Controls.Add(lblSubjects);
                tutorCard.Controls.Add(lblRating);

                flpSessionTutors.Controls.Add(tutorCard);
            }
        }

        private Random random = new Random();
        private void generatePaymentAccount()
        {
            int accountNumber = random.Next(1000, 10000);

            if (cmbPaymentMethod.Text == "GCash")
            {
                txtPaymentAccount.Text = "GCASH-DEMO-" + accountNumber;
            }
            else if (cmbPaymentMethod.Text == "Maya")
            {
                txtPaymentAccount.Text = "MAYA-DEMO-" + accountNumber;
            }
            else
            {
                txtPaymentAccount.Clear();
            }
        }

        private void cmbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            generatePaymentAccount();
        }

        private void btnSubmitPayment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtExpectations.Text))
            {
                MessageBox.Show("Please enter your expectations for the session.");
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbPaymentMethod.Text))
            {
                MessageBox.Show("Please select a payment method.");
                return;
            }

            MessageBox.Show("Payment submitted successfully! Please complete your booking!");

            btnCompleteBooking.Visible = true;
            btnSubmitPayment.Enabled = false;
        }

        private void btnCompleteBooking_Click(object sender, EventArgs e)
        {
            string result;

            if (isCreator)
            {
                result = repository.CompleteCreatorBooking(loggedInUserId, sessionId, txtExpectations.Text.Trim());
            }

            else
            {
                result = repository.JoinSession(loggedInUserId, sessionId, txtExpectations.Text.Trim());
            }

            if (result == "Joined")
            {
                MessageBox.Show("Payment successful! Your booking has been confirmed.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        
            else if (result == "Already Booked")
            {
                MessageBox.Show("You have already booked this session.");
            }

            else if (result == "Waitlisted")
            {
                MessageBox.Show("This session is full. You have been added to the waitlist");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            else if (result == "Session Not Found")
            {
                MessageBox.Show("This session no longer exists.");
            }

            else if (result == "Session Unavailable")
            {
                MessageBox.Show("This session is no longer available.");
            }

            else if (result == "Student Not Found")
            {
                MessageBox.Show("Student account not found.");
            }
        }

    }
}