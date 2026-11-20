using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Study_Session
{
    public partial class Main : Form
    {
        private UserRepository userRepository = new UserRepository();
        public Main()
        {
            InitializeComponent();
        }

        private void btnSignup2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtStudentNumber.Text) ||
                string.IsNullOrWhiteSpace(txtUEGmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text) || cmbYear.SelectedIndex == -1 || cmbProgram.SelectedIndex == -1)
            {
                MessageBox.Show("Please complete all fields.");
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            try
            {

                string passwordHash = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text);

                Student newStudent = new Student(0, 0, txtFullName.Text.Trim(), txtStudentNumber.Text.Trim(), txtUEGmail.Text.Trim(), cmbYear.SelectedItem.ToString(),
                cmbProgram.SelectedItem.ToString(), passwordHash);

                Student registeredStudent = userRepository.RegisterUser(newStudent);
                
                MessageBox.Show("User registered successfully.");

                txtFullName.Clear();
                txtStudentNumber.Clear();
                txtUEGmail.Clear();
                txtPassword.Clear();
                txtConfirmPassword.Clear();
                cmbYear.SelectedIndex = -1;
                cmbProgram.SelectedIndex = -1;
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Signup Error: {ex.Message}");
            }
        }

        private void btnLogin2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentNumber2.Text) || string.IsNullOrWhiteSpace(txtPassword2.Text))
            {
                MessageBox.Show("Please enter your Student Number and Password.");
                return;
            }

            try
            {
                UserRepository repository = new UserRepository();

                User loggedInUser = repository.LoginUser(txtStudentNumber2.Text.Trim(), txtPassword2.Text);

                if (loggedInUser == null)
                {
                    MessageBox.Show("Invalid student number or password.");
                    return;
                }

                MessageBox.Show("Login successful.");

                loggedInUser.LoadDashboard(null);
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"LoginError: {ex.Message}");
            }
        }
    }
}
