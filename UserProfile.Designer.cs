namespace Study_Session
{
    partial class UserProfile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblFullName = new Label();
            lblUEGmail = new Label();
            lblYear = new Label();
            lblProgram = new Label();
            lblCredentials = new Label();
            lblSubjects = new Label();
            lblRating = new Label();
            lblAvailability = new Label();
            SuspendLayout();
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(40, 60);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(95, 25);
            lblFullName.TabIndex = 0;
            lblFullName.Text = "Full Name:";
            // 
            // lblUEGmail
            // 
            lblUEGmail.AutoSize = true;
            lblUEGmail.Location = new Point(40, 113);
            lblUEGmail.Name = "lblUEGmail";
            lblUEGmail.Size = new Size(87, 25);
            lblUEGmail.TabIndex = 1;
            lblUEGmail.Text = "UE Gmail:";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(40, 162);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(48, 25);
            lblYear.TabIndex = 2;
            lblYear.Text = "Year:";
            // 
            // lblProgram
            // 
            lblProgram.AutoSize = true;
            lblProgram.Location = new Point(40, 203);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(85, 25);
            lblProgram.TabIndex = 3;
            lblProgram.Text = "Program:";
            // 
            // lblCredentials
            // 
            lblCredentials.AutoSize = true;
            lblCredentials.Location = new Point(45, 366);
            lblCredentials.Name = "lblCredentials";
            lblCredentials.Size = new Size(103, 25);
            lblCredentials.TabIndex = 4;
            lblCredentials.Text = "Credentials:";
            // 
            // lblSubjects
            // 
            lblSubjects.AutoSize = true;
            lblSubjects.Location = new Point(45, 318);
            lblSubjects.Name = "lblSubjects";
            lblSubjects.Size = new Size(82, 25);
            lblSubjects.TabIndex = 5;
            lblSubjects.Text = "Subjects:";
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Location = new Point(45, 417);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(67, 25);
            lblRating.TabIndex = 6;
            lblRating.Text = "Rating:";
            // 
            // lblAvailability
            // 
            lblAvailability.AutoSize = true;
            lblAvailability.Location = new Point(53, 459);
            lblAvailability.Name = "lblAvailability";
            lblAvailability.Size = new Size(101, 25);
            lblAvailability.TabIndex = 7;
            lblAvailability.Text = "Availability:";
            // 
            // UserProfile
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 581);
            Controls.Add(lblAvailability);
            Controls.Add(lblRating);
            Controls.Add(lblSubjects);
            Controls.Add(lblCredentials);
            Controls.Add(lblProgram);
            Controls.Add(lblYear);
            Controls.Add(lblUEGmail);
            Controls.Add(lblFullName);
            Name = "UserProfile";
            Text = "UserProfile";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFullName;
        private Label lblUEGmail;
        private Label lblYear;
        private Label lblProgram;
        private Label lblCredentials;
        private Label lblSubjects;
        private Label lblRating;
        private Label lblAvailability;
    }
}