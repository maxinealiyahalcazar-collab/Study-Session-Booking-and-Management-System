using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Study_Session
{
    public partial class UserProfile : Form
    {
        public UserProfile(User user)
        {
            InitializeComponent();

            lblFullName.Text = user.FullName;
            lblUEGmail.Text = user.UEGmail;
            lblYear.Text = user.Year;
            lblProgram.Text = user.Program;

            if (user is Tutor tutor)
            {
                lblCredentials.Text = tutor.Credentials;
                lblSubjects.Text = tutor.Subjects;
                lblRating.Text = tutor.Rating.ToString("0.00");
                lblAvailability.Text = tutor.Availability;
            }

            else
            {
                lblCredentials.Text = "N/A";
                lblSubjects.Text = "N/A";
                lblRating.Text = "N/A";
                lblAvailability.Text = "N/A";
            }
        }
    }
        
}
