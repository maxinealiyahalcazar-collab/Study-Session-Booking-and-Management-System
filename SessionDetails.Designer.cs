namespace Study_Session
{
    partial class SessionDetails
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
            lblSubject = new Label();
            lblTopic = new Label();
            lblDate = new Label();
            lblTime = new Label();
            lblLocation = new Label();
            lblSlots = new Label();
            lblStatus = new Label();
            btnCancelBooking = new Button();
            btnEditSession = new Button();
            btnCancelSession = new Button();
            btnCompleteSession = new Button();
            btnUploadMaterials = new Button();
            btnViewMaterials = new Button();
            btnRateTutor = new Button();
            SuspendLayout();
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Location = new Point(42, 67);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(70, 25);
            lblSubject.TabIndex = 0;
            lblSubject.Text = "Subject";
            // 
            // lblTopic
            // 
            lblTopic.AutoSize = true;
            lblTopic.Location = new Point(42, 117);
            lblTopic.Name = "lblTopic";
            lblTopic.Size = new Size(53, 25);
            lblTopic.TabIndex = 1;
            lblTopic.Text = "Topic";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(42, 175);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(49, 25);
            lblDate.TabIndex = 2;
            lblDate.Text = "Date";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(42, 227);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(50, 25);
            lblTime.TabIndex = 3;
            lblTime.Text = "Time";
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(42, 275);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(79, 25);
            lblLocation.TabIndex = 4;
            lblLocation.Text = "Location";
            // 
            // lblSlots
            // 
            lblSlots.AutoSize = true;
            lblSlots.Location = new Point(42, 321);
            lblSlots.Name = "lblSlots";
            lblSlots.Size = new Size(51, 25);
            lblSlots.TabIndex = 5;
            lblSlots.Text = "Slots";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(42, 377);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(60, 25);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Status";
            // 
            // btnCancelBooking
            // 
            btnCancelBooking.Location = new Point(120, 452);
            btnCancelBooking.Name = "btnCancelBooking";
            btnCancelBooking.Size = new Size(112, 34);
            btnCancelBooking.TabIndex = 7;
            btnCancelBooking.Text = "Cancel Booking";
            btnCancelBooking.UseVisualStyleBackColor = true;
            btnCancelBooking.Click += btnCancelBooking_Click;
            // 
            // btnEditSession
            // 
            btnEditSession.Location = new Point(238, 452);
            btnEditSession.Name = "btnEditSession";
            btnEditSession.Size = new Size(112, 34);
            btnEditSession.TabIndex = 8;
            btnEditSession.Text = "Edit Session";
            btnEditSession.UseVisualStyleBackColor = true;
            btnEditSession.Click += btnEditSession_Click;
            // 
            // btnCancelSession
            // 
            btnCancelSession.Location = new Point(356, 452);
            btnCancelSession.Name = "btnCancelSession";
            btnCancelSession.Size = new Size(112, 34);
            btnCancelSession.TabIndex = 9;
            btnCancelSession.Text = "Cancel Session";
            btnCancelSession.UseVisualStyleBackColor = true;
            btnCancelSession.Click += btnCancelSession_Click;
            // 
            // btnCompleteSession
            // 
            btnCompleteSession.Location = new Point(186, 492);
            btnCompleteSession.Name = "btnCompleteSession";
            btnCompleteSession.Size = new Size(112, 34);
            btnCompleteSession.TabIndex = 10;
            btnCompleteSession.Text = "Complete";
            btnCompleteSession.UseVisualStyleBackColor = true;
            btnCompleteSession.Click += btnCompleteSession_Click;
            // 
            // btnUploadMaterials
            // 
            btnUploadMaterials.Location = new Point(304, 492);
            btnUploadMaterials.Name = "btnUploadMaterials";
            btnUploadMaterials.Size = new Size(112, 34);
            btnUploadMaterials.TabIndex = 11;
            btnUploadMaterials.Text = "Upload";
            btnUploadMaterials.UseVisualStyleBackColor = true;
            btnUploadMaterials.Click += btnUploadMaterials_Click;
            // 
            // btnViewMaterials
            // 
            btnViewMaterials.Location = new Point(186, 545);
            btnViewMaterials.Name = "btnViewMaterials";
            btnViewMaterials.Size = new Size(112, 34);
            btnViewMaterials.TabIndex = 12;
            btnViewMaterials.Text = "View Materials";
            btnViewMaterials.UseVisualStyleBackColor = true;
            btnViewMaterials.Click += btnViewMaterials_Click;
            // 
            // btnRateTutor
            // 
            btnRateTutor.Location = new Point(304, 545);
            btnRateTutor.Name = "btnRateTutor";
            btnRateTutor.Size = new Size(112, 34);
            btnRateTutor.TabIndex = 13;
            btnRateTutor.Text = "Rate Tutor";
            btnRateTutor.UseVisualStyleBackColor = true;
            btnRateTutor.Click += btnRateTutor_Click;
            // 
            // SessionDetails
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(630, 660);
            Controls.Add(btnRateTutor);
            Controls.Add(btnViewMaterials);
            Controls.Add(btnUploadMaterials);
            Controls.Add(btnCompleteSession);
            Controls.Add(btnCancelSession);
            Controls.Add(btnEditSession);
            Controls.Add(btnCancelBooking);
            Controls.Add(lblStatus);
            Controls.Add(lblSlots);
            Controls.Add(lblLocation);
            Controls.Add(lblTime);
            Controls.Add(lblDate);
            Controls.Add(lblTopic);
            Controls.Add(lblSubject);
            Name = "SessionDetails";
            Text = "SessionDetails";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSubject;
        private Label lblTopic;
        private Label lblDate;
        private Label lblTime;
        private Label lblLocation;
        private Label lblSlots;
        private Label lblStatus;
        private Button btnCancelBooking;
        private Button btnEditSession;
        private Button btnCancelSession;
        private Button btnCompleteSession;
        private Button btnUploadMaterials;
        private Button btnViewMaterials;
        private Button btnRateTutor;
    }
}