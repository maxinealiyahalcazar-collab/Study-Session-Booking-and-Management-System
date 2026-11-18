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
        public UserProfile()
        {
            InitializeComponent();
        }

        public UserProfile(DataRow userData)
        {
            InitializeComponent();

            lblFullName.Text = userData["fullName"].ToString();
            lblUEGmail.Text = userData["ueGmail"].ToString();
            lblYear.Text = userData["year"].ToString();
            lblProgram.Text = userData["program"].ToString();

            lblCredentials.Text = userData["credentials"].ToString();
            lblSubjects.Text = userData["subjects"].ToString();
            lblRating.Text = userData["rating"].ToString();
            lblAvailability.Text = userData["availability"].ToString();
        }
    }
        
}
