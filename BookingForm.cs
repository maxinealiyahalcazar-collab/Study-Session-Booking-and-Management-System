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
        private UserRepository userRepository = new UserRepository();
        private SessionRepository sessionRepository = new SessionRepository();
        private BookingRepository bookingRepository = new BookingRepository();
    

        public BookingForm(Session sessionData, int userId, bool creator = false, bool waitlist = false)
        {
            InitializeComponent();

            loggedInUserId = userId;
            isCreator = creator;
            sessionId = sessionData.SessionId;
            isWaitlist = waitlist;

            lblSubject.Text = sessionData.Subject;
            lblTopic.Text = sessionData.Topic;

            DateTime start = sessionData.StartDateTime;
            DateTime end = sessionData.EndDateTime;

            lblDate.Text = start.ToString("MMMM dd, yyyy");
            lblTime.Text = start.ToString("hh:mm tt") + " - " + end.ToString("hh:mm tt");
            lblLocation.Text = sessionData.Location;
            lblSlots.Text = sessionData.AvailableSlots + " / " + sessionData.Slots;
            lblRequiredTutors.Text = sessionData.RequiredTutors.ToString();

            LoadAcceptedTutors(sessionData.SessionId);
        }


        private void LoadAcceptedTutors(int sessionId)
        {

            List<Tutor> tutors = sessionRepository.GetRequestedSessionTutors(sessionId);

            flpSessionTutors.Controls.Clear();

            foreach (Tutor tutor in tutors)
            {
                Panel tutorCard = new Panel();
                tutorCard.Width = 280;
                tutorCard.Height = 90;
                tutorCard.BorderStyle = BorderStyle.FixedSingle;
                tutorCard.Margin = new Padding(5);

                Label lblName = new Label();
                lblName.Text = tutor.FullName;
                lblName.Font = new Font("Arial", 10, FontStyle.Bold);
                lblName.Location = new Point(10, 10);
                lblName.AutoSize = true;

                Label lblSubjects = new Label();
                lblSubjects.Text = "Subjects: " + tutor.Subjects;
                lblSubjects.Location = new Point(10, 35);
                lblSubjects.AutoSize = true;

                Label lblRating = new Label();
                lblRating.Text = "Rating: " + tutor.Rating.ToString("");
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
                result = bookingRepository.CompleteCreatorBooking(loggedInUserId, sessionId, txtExpectations.Text.Trim());
            }

            else if (isWaitlist)
            {
                result = bookingRepository.CompleteWaitlistPayment(loggedInUserId, sessionId, txtExpectations.Text.Trim());
            }
            else
            {
                result = bookingRepository.JoinSession(loggedInUserId, sessionId, txtExpectations.Text.Trim());
            }

            if (result == "Joined")
            {
                MessageBox.Show("Booking completed successfully!");

                if (!isCreator && !isWaitlist)
                {
                    int creatorUserId = sessionRepository.GetSessionCreatorUserId(sessionId);

                    if (creatorUserId > 0)
                    {
                        userRepository.AddNotification(
                            creatorUserId, "A student has successfully booked your session.");
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            else
            {
                MessageBox.Show("Unable to complete booking: " + result);
            }

        }
    }
}