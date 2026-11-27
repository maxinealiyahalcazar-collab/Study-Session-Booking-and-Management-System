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
            btnWithdraw = new Button();
            lblTutors = new Label();
            flpConfirmedTutors = new FlowLayoutPanel();
            btnReadExpectations = new Button();
            SuspendLayout();
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Location = new Point(42, 49);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(70, 25);
            lblSubject.TabIndex = 0;
            lblSubject.Text = "Subject";
            // 
            // lblTopic
            // 
            lblTopic.AutoSize = true;
            lblTopic.Location = new Point(44, 87);
            lblTopic.Name = "lblTopic";
            lblTopic.Size = new Size(53, 25);
            lblTopic.TabIndex = 1;
            lblTopic.Text = "Topic";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(44, 135);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(49, 25);
            lblDate.TabIndex = 2;
            lblDate.Text = "Date";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(44, 175);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(50, 25);
            lblTime.TabIndex = 3;
            lblTime.Text = "Time";
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(42, 425);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(79, 25);
            lblLocation.TabIndex = 4;
            lblLocation.Text = "Location";
            // 
            // lblSlots
            // 
            lblSlots.AutoSize = true;
            lblSlots.Location = new Point(44, 450);
            lblSlots.Name = "lblSlots";
            lblSlots.Size = new Size(51, 25);
            lblSlots.TabIndex = 5;
            lblSlots.Text = "Slots";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(42, 475);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(60, 25);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Status";
            // 
            // btnCancelBooking
            // 
            btnCancelBooking.Location = new Point(42, 536);
            btnCancelBooking.Name = "btnCancelBooking";
            btnCancelBooking.Size = new Size(112, 34);
            btnCancelBooking.TabIndex = 7;
            btnCancelBooking.Text = "Cancel Booking";
            btnCancelBooking.UseVisualStyleBackColor = true;
            btnCancelBooking.Visible = false;
            btnCancelBooking.Click += btnCancelBooking_Click;
            // 
            // btnEditSession
            // 
            btnEditSession.Location = new Point(160, 536);
            btnEditSession.Name = "btnEditSession";
            btnEditSession.Size = new Size(112, 34);
            btnEditSession.TabIndex = 8;
            btnEditSession.Text = "Edit Session";
            btnEditSession.UseVisualStyleBackColor = true;
            btnEditSession.Visible = false;
            btnEditSession.Click += btnEditSession_Click;
            // 
            // btnCancelSession
            // 
            btnCancelSession.Location = new Point(411, 536);
            btnCancelSession.Name = "btnCancelSession";
            btnCancelSession.Size = new Size(149, 34);
            btnCancelSession.TabIndex = 9;
            btnCancelSession.Text = "Cancel Session";
            btnCancelSession.UseVisualStyleBackColor = true;
            btnCancelSession.Visible = false;
            btnCancelSession.Click += btnCancelSession_Click;
            // 
            // btnCompleteSession
            // 
            btnCompleteSession.Location = new Point(42, 576);
            btnCompleteSession.Name = "btnCompleteSession";
            btnCompleteSession.Size = new Size(112, 34);
            btnCompleteSession.TabIndex = 10;
            btnCompleteSession.Text = "Complete";
            btnCompleteSession.UseVisualStyleBackColor = true;
            btnCompleteSession.Visible = false;
            btnCompleteSession.Click += btnCompleteSession_Click;
            // 
            // btnUploadMaterials
            // 
            btnUploadMaterials.Location = new Point(212, 576);
            btnUploadMaterials.Name = "btnUploadMaterials";
            btnUploadMaterials.Size = new Size(112, 34);
            btnUploadMaterials.TabIndex = 11;
            btnUploadMaterials.Text = "Upload";
            btnUploadMaterials.UseVisualStyleBackColor = true;
            btnUploadMaterials.Visible = false;
            btnUploadMaterials.Click += btnUploadMaterials_Click;
            // 
            // btnViewMaterials
            // 
            btnViewMaterials.Location = new Point(330, 576);
            btnViewMaterials.Name = "btnViewMaterials";
            btnViewMaterials.Size = new Size(112, 34);
            btnViewMaterials.TabIndex = 12;
            btnViewMaterials.Text = "View Materials";
            btnViewMaterials.UseVisualStyleBackColor = true;
            btnViewMaterials.Visible = false;
            btnViewMaterials.Click += btnViewMaterials_Click;
            // 
            // btnRateTutor
            // 
            btnRateTutor.Location = new Point(448, 576);
            btnRateTutor.Name = "btnRateTutor";
            btnRateTutor.Size = new Size(112, 34);
            btnRateTutor.TabIndex = 13;
            btnRateTutor.Text = "Rate Tutor";
            btnRateTutor.UseVisualStyleBackColor = true;
            btnRateTutor.Visible = false;
            btnRateTutor.Click += btnRateTutor_Click;
            // 
            // btnWithdraw
            // 
            btnWithdraw.Location = new Point(293, 536);
            btnWithdraw.Name = "btnWithdraw";
            btnWithdraw.Size = new Size(112, 34);
            btnWithdraw.TabIndex = 14;
            btnWithdraw.Text = "Withdraw";
            btnWithdraw.UseVisualStyleBackColor = true;
            btnWithdraw.Visible = false;
            btnWithdraw.Click += btnWithdraw_Click;
            // 
            // lblTutors
            // 
            lblTutors.AutoSize = true;
            lblTutors.Location = new Point(44, 214);
            lblTutors.Name = "lblTutors";
            lblTutors.Size = new Size(62, 25);
            lblTutors.TabIndex = 15;
            lblTutors.Text = "Tutors";
            // 
            // flpConfirmedTutors
            // 
            flpConfirmedTutors.AutoScroll = true;
            flpConfirmedTutors.FlowDirection = FlowDirection.TopDown;
            flpConfirmedTutors.Location = new Point(44, 263);
            flpConfirmedTutors.Name = "flpConfirmedTutors";
            flpConfirmedTutors.Size = new Size(516, 128);
            flpConfirmedTutors.TabIndex = 16;
            flpConfirmedTutors.WrapContents = false;
            // 
            // btnReadExpectations
            // 
            btnReadExpectations.Location = new Point(411, 496);
            btnReadExpectations.Name = "btnReadExpectations";
            btnReadExpectations.Size = new Size(149, 34);
            btnReadExpectations.TabIndex = 17;
            btnReadExpectations.Text = "Read Expectations";
            btnReadExpectations.UseVisualStyleBackColor = true;
            btnReadExpectations.Visible = false;
            btnReadExpectations.Click += btnReadExpectations_Click;
            // 
            // SessionDetails
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(630, 660);
            Controls.Add(btnReadExpectations);
            Controls.Add(flpConfirmedTutors);
            Controls.Add(lblTutors);
            Controls.Add(btnWithdraw);
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
        private Button btnWithdraw;
        private Label lblTutors;
        private FlowLayoutPanel flpConfirmedTutors;
        private Button btnReadExpectations;
    }
}