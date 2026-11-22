namespace Study_Session
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlSignup = new Panel();
            btnSignup2 = new Button();
            cmbProgram = new ComboBox();
            cmbYear = new ComboBox();
            txtConfirmPassword = new TextBox();
            txtPassword = new TextBox();
            txtUEGmail = new TextBox();
            txtStudentNumber = new TextBox();
            txtFullName = new TextBox();
            pnlLogin = new Panel();
            pnlStart = new Panel();
            btnSignup = new Button();
            btnLogin = new Button();
            btnLogin2 = new Button();
            txtPassword2 = new TextBox();
            txtStudentNumber2 = new TextBox();
            pnlSignup.SuspendLayout();
            pnlLogin.SuspendLayout();
            pnlStart.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSignup
            // 
            pnlSignup.Controls.Add(btnSignup2);
            pnlSignup.Controls.Add(cmbProgram);
            pnlSignup.Controls.Add(cmbYear);
            pnlSignup.Controls.Add(txtConfirmPassword);
            pnlSignup.Controls.Add(txtPassword);
            pnlSignup.Controls.Add(txtUEGmail);
            pnlSignup.Controls.Add(txtStudentNumber);
            pnlSignup.Controls.Add(txtFullName);
            pnlSignup.Location = new Point(0, 0);
            pnlSignup.Name = "pnlSignup";
            pnlSignup.Size = new Size(1179, 644);
            pnlSignup.TabIndex = 0;
            // 
            // btnSignup2
            // 
            btnSignup2.Location = new Point(637, 421);
            btnSignup2.Name = "btnSignup2";
            btnSignup2.Size = new Size(112, 34);
            btnSignup2.TabIndex = 7;
            btnSignup2.Text = "Signup";
            btnSignup2.UseVisualStyleBackColor = true;
            btnSignup2.Click += btnSignup2_Click;
            // 
            // cmbProgram
            // 
            cmbProgram.FormattingEnabled = true;
            cmbProgram.Items.AddRange(new object[] { "Civil Engineering", "Computer Engineering", "Mechanical Engineering", "Electronics Engineering", "Electrical Engineering" });
            cmbProgram.Location = new Point(567, 190);
            cmbProgram.Name = "cmbProgram";
            cmbProgram.Size = new Size(182, 33);
            cmbProgram.TabIndex = 6;
            // 
            // cmbYear
            // 
            cmbYear.FormattingEnabled = true;
            cmbYear.Items.AddRange(new object[] { "1st Year", "2nd Year", "3rd Year", "4th Year" });
            cmbYear.Location = new Point(567, 93);
            cmbYear.Name = "cmbYear";
            cmbYear.Size = new Size(182, 33);
            cmbYear.TabIndex = 5;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(567, 342);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(182, 31);
            txtConfirmPassword.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(567, 267);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(182, 31);
            txtPassword.TabIndex = 3;
            // 
            // txtUEGmail
            // 
            txtUEGmail.Location = new Point(114, 301);
            txtUEGmail.Name = "txtUEGmail";
            txtUEGmail.Size = new Size(182, 31);
            txtUEGmail.TabIndex = 2;
            // 
            // txtStudentNumber
            // 
            txtStudentNumber.Location = new Point(114, 217);
            txtStudentNumber.Name = "txtStudentNumber";
            txtStudentNumber.Size = new Size(182, 31);
            txtStudentNumber.TabIndex = 1;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(114, 106);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(182, 31);
            txtFullName.TabIndex = 0;
            // 
            // pnlLogin
            // 
            pnlLogin.Controls.Add(pnlStart);
            pnlLogin.Controls.Add(btnLogin2);
            pnlLogin.Controls.Add(txtPassword2);
            pnlLogin.Controls.Add(txtStudentNumber2);
            pnlLogin.Location = new Point(0, 0);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(1179, 644);
            pnlLogin.TabIndex = 8;
            // 
            // pnlStart
            // 
            pnlStart.Controls.Add(btnSignup);
            pnlStart.Controls.Add(btnLogin);
            pnlStart.Location = new Point(3, 0);
            pnlStart.Name = "pnlStart";
            pnlStart.Size = new Size(1179, 644);
            pnlStart.TabIndex = 9;
            // 
            // btnSignup
            // 
            btnSignup.Location = new Point(973, 499);
            btnSignup.Name = "btnSignup";
            btnSignup.Size = new Size(112, 34);
            btnSignup.TabIndex = 8;
            btnSignup.Text = "Signup";
            btnSignup.UseVisualStyleBackColor = true;
            btnSignup.Click += btnSignup_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(973, 570);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(112, 34);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnLogin2
            // 
            btnLogin2.Location = new Point(341, 313);
            btnLogin2.Name = "btnLogin2";
            btnLogin2.Size = new Size(112, 34);
            btnLogin2.TabIndex = 7;
            btnLogin2.Text = "Login";
            btnLogin2.UseVisualStyleBackColor = true;
            btnLogin2.Click += btnLogin2_Click;
            // 
            // txtPassword2
            // 
            txtPassword2.Location = new Point(315, 217);
            txtPassword2.Name = "txtPassword2";
            txtPassword2.Size = new Size(182, 31);
            txtPassword2.TabIndex = 4;
            // 
            // txtStudentNumber2
            // 
            txtStudentNumber2.Location = new Point(315, 132);
            txtStudentNumber2.Name = "txtStudentNumber2";
            txtStudentNumber2.Size = new Size(182, 31);
            txtStudentNumber2.TabIndex = 2;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 644);
            Controls.Add(pnlLogin);
            Controls.Add(pnlSignup);
            Name = "Main";
            Text = "Study Session Booking and Management System";
            pnlSignup.ResumeLayout(false);
            pnlSignup.PerformLayout();
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            pnlStart.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSignup;
        private TextBox txtUEGmail;
        private TextBox txtStudentNumber;
        private TextBox txtFullName;
        private TextBox txtPassword;
        private ComboBox cmbYear;
        private ComboBox cmbProgram;
        private TextBox txtConfirmPassword;
        private Button btnSignup2;
        private Panel pnlLogin;
        private Button btnLogin2;
        private TextBox txtPassword2;
        private TextBox txtStudentNumber2;
        private Panel pnlStart;
        private Button btnSignup;
        private Button btnLogin;
    }
}
