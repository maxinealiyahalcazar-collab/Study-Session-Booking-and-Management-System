using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Study_Session
{
    public partial class SessionActivityForm : Form
    {
        private int sessionId;
        private int studentId;
        private int selectedTutorId;
        private string selectedTutorName;
        private DataTable sessionTutors;
        private string selectedFilePath = "";
        private string activityMode;

        public SessionActivityForm(int sessionId, int studentId, string mode)
        {
            InitializeComponent();
            this.sessionId = sessionId;
            this.studentId = studentId;
            activityMode = mode;
            selectedTutorId = 0;

            pnlRateTutor.Visible = false;
            pnlUploadMaterials.Visible = false;
            pnlViewMaterials.Visible = false;

            if (activityMode == "Rate")
            {
                pnlRateTutor.Visible = true;
                LoadSessionTutors();
            }
            else if (activityMode == "Upload")
            {
                pnlUploadMaterials.Visible = true;
            }
            else if (activityMode == "View")
            {
                pnlViewMaterials.Visible = true;
                LoadMaterials();
            }

            LoadSessionTutors();
        }

        private void LoadSessionTutors()
        {
            UserRepository repository = new UserRepository();

            sessionTutors = repository.GetAcceptedSessionTutors(sessionId);

            flpTutorList.Controls.Clear();

            foreach (DataRow row in sessionTutors.Rows)
            {
                int tutorId = Convert.ToInt32(row["tutorId"]);
                string tutorName = row["fullName"].ToString();

                Panel tutorPanel = new Panel();
                tutorPanel.Width = flpTutorList.Width - 25;
                tutorPanel.Height = 45;

                Label lblTutorName = new Label();
                lblTutorName.Text = tutorName;
                lblTutorName.Location = new Point(5, 12);
                lblTutorName.AutoSize = true;

                Button btnRate = new Button();
                btnRate.Text = "Rate";
                btnRate.Size = new Size(70, 30);
                btnRate.Location = new Point(tutorPanel.Width - 80, 5);

                btnRate.Click += (sender, e) =>
                {
                    selectedTutorId = tutorId;
                    selectedTutorName = tutorName;

                    lblSelectedTutor.Text = "Selected Tutor: " + tutorName;
                };

                bool alreadyRated = repository.HasAlreadyRated(studentId, tutorId, sessionId);

                if (alreadyRated)
                {
                    btnRate.Text = "Rated";
                    btnRate.Enabled = false;
                }

                tutorPanel.Controls.Add(lblTutorName);
                tutorPanel.Controls.Add(btnRate);

                flpTutorList.Controls.Add(tutorPanel);
            }
        }

        private void btnSubmitRating_Click(object sender, EventArgs e)
        {
            if (selectedTutorId == 0)
            {
                MessageBox.Show("Please select a tutor to rate.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtReview.Text))
            {
                MessageBox.Show("Please write a review.");
                return;
            }

            UserRepository repository = new UserRepository();

            bool success = repository.AddRating(selectedTutorId, studentId, sessionId, numRating.Value, txtReview.Text.Trim());

            if (repository.HasAlreadyRated(studentId, selectedTutorId, sessionId))
            {
                MessageBox.Show("You have already rated this tutor for this session.");
                return;
            }

            if (success)
            {
                MessageBox.Show("Rating submitted successfully!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Unable to submit rating.");
            }
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Select Learning Material";
            openFileDialog.Filter =
                "Supported Files|*.pdf;*.doc;*.docx;*.ppt;*.pptx;*.txt|" +
                "PDF Files|*.pdf|" +
                "Word Documents|*.doc;*.docx|" +
                "PowerPoint Files|*.ppt;*.pptx|" +
                "Text Files|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;

                lblSelectedFile.Text = System.IO.Path.GetFileName(selectedFilePath);
                btnUploadMaterial.Visible = true;
            }
        }

        private void btnUploadMaterial_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaterialName.Text))
            {
                MessageBox.Show("Please enter a material name.");
                return;
            }

            if (string.IsNullOrWhiteSpace(selectedFilePath))
            {
                MessageBox.Show("Please select a file first.");
                return;
            }

            string uploadFolder = System.IO.Path.Combine(Application.StartupPath, "UploadedMaterials");

            if (!System.IO.Directory.Exists(uploadFolder))
            {
                System.IO.Directory.CreateDirectory(uploadFolder);
            }
            string fileName = System.IO.Path.GetFileName(selectedFilePath);

            string destinationPath = System.IO.Path.Combine(
                uploadFolder,
                fileName
            );

            System.IO.File.Copy(selectedFilePath, destinationPath, true);

            UserRepository repository = new UserRepository();

            bool success = repository.AddMaterial(sessionId, txtMaterialName.Text.Trim(), txtDescription.Text.Trim(), destinationPath);

            if (success)
            {
                MessageBox.Show("Material uploaded successfully!");

                txtMaterialName.Clear();
                txtDescription.Clear();
                lblSelectedFile.Text = "No file selected";
                selectedFilePath = "";
            }
            else
            {
                MessageBox.Show("Unable to upload material.");
            }
        }

        private void LoadMaterials()
        {
            UserRepository repository = new UserRepository();

            DataTable materials = repository.GetMaterialsBySessionId(sessionId);

            flpMaterials.Controls.Clear();

            if (materials.Rows.Count == 0)
            {
                lblNoMaterials.Visible = true;
                return;
            }

            lblNoMaterials.Visible = false;

            foreach (DataRow row in materials.Rows)
            {
                Panel materialCard = new Panel();
                materialCard.Width = 450;
                materialCard.Height = 110;
                materialCard.BorderStyle = BorderStyle.FixedSingle;
                materialCard.Margin = new Padding(5);
                materialCard.Padding = new Padding(10);

                Label lblName = new Label();
                lblName.Text = row["materialName"].ToString();
                lblName.Font = new Font("Arial", 11, FontStyle.Bold);
                lblName.AutoSize = true;
                lblName.Location = new Point(10, 10);

                Label lblDescription = new Label();
                lblDescription.Text = row["description"].ToString();
                lblDescription.Location = new Point(10, 40);
                lblDescription.Size = new Size(420, 30);

                Button btnOpen = new Button();
                btnOpen.Text = "View File";
                btnOpen.Size = new Size(100, 30);
                btnOpen.Location = new Point(10, 75);

                string filePath = row["fileLink"].ToString();

                btnOpen.Click += (s, e) =>
                {
                    if (System.IO.File.Exists(filePath))
                    {
                        System.Diagnostics.Process.Start(
                            new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = filePath,
                                UseShellExecute = true
                            }
                        );
                    }
                    else
                    {
                        MessageBox.Show("The material file could not be found.");
                    }
                };

                materialCard.Controls.Add(lblName);
                materialCard.Controls.Add(lblDescription);
                materialCard.Controls.Add(btnOpen);

                flpMaterials.Controls.Add(materialCard);
            }
        }
    }
}
