namespace Study_Session
{
    partial class TutorDashboard
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
            pnlSideBar = new Panel();
            btnStudentMode = new Button();
            btnReadReviews = new Button();
            btnBrowseSession = new Button();
            btnCreateSession = new Button();
            btnTutorRequests = new Button();
            btnMySession = new Button();
            btnMyProfile = new Button();
            btnMain = new Button();
            lblSearchSessions = new Label();
            txtSearchSessions = new TextBox();
            flpBrowseSessions = new FlowLayoutPanel();
            pnlCreateSession = new Panel();
            txtSearchTutor = new TextBox();
            lblSelectedTutors = new Label();
            lblSearchTutor = new Label();
            flpTutorList = new FlowLayoutPanel();
            lblEndTime = new Label();
            lblStartTime = new Label();
            dtpEndTime = new DateTimePicker();
            dtpStartTime = new DateTimePicker();
            dtpSessionDate = new DateTimePicker();
            btnSubmitSession = new Button();
            numSlots = new NumericUpDown();
            numRequiredTutors = new NumericUpDown();
            txtLocation = new TextBox();
            txtTopic = new TextBox();
            txtSubject = new TextBox();
            lblLocation = new Label();
            lblSlots = new Label();
            lblRequiredTutors = new Label();
            lblSessionDate = new Label();
            lblTopic = new Label();
            lblSubject = new Label();
            lblCreateSessionDescription = new Label();
            lblCreateSessionTitle = new Label();
            pnlMyProfile = new Panel();
            lblProfileRatingValue = new Label();
            lblProfileAvailabilityValue = new Label();
            txtEditAvailability = new TextBox();
            lblProfileRating = new Label();
            lblProfileAvailability = new Label();
            lblProfileSubjectValue = new Label();
            txtEditSubject = new TextBox();
            lblProfileSubject = new Label();
            lblProfileCredentialValue = new Label();
            txtEditCredential = new TextBox();
            lblProfileCredentials = new Label();
            btnCancelProfile = new Button();
            btnSaveProfile = new Button();
            btnEditProfile = new Button();
            lblProfileDescription = new Label();
            lblProfileTitle = new Label();
            pnlBrowseSession = new Panel();
            textBox1 = new TextBox();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pnlTutorRequest = new Panel();
            pnlNotification = new Panel();
            lblNotificationsTitle = new Label();
            flpNotifications = new FlowLayoutPanel();
            pnlBookedSessions = new Panel();
            lblBookedCount = new Label();
            lblBookedTitle = new Label();
            pnlSideBar.SuspendLayout();
            pnlCreateSession.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSlots).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRequiredTutors).BeginInit();
            pnlMyProfile.SuspendLayout();
            pnlBrowseSession.SuspendLayout();
            pnlNotification.SuspendLayout();
            pnlBookedSessions.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSideBar
            // 
            pnlSideBar.BackColor = Color.MediumSlateBlue;
            pnlSideBar.Controls.Add(btnStudentMode);
            pnlSideBar.Controls.Add(btnReadReviews);
            pnlSideBar.Controls.Add(btnBrowseSession);
            pnlSideBar.Controls.Add(btnCreateSession);
            pnlSideBar.Controls.Add(btnTutorRequests);
            pnlSideBar.Controls.Add(btnMySession);
            pnlSideBar.Controls.Add(btnMyProfile);
            pnlSideBar.Controls.Add(btnMain);
            pnlSideBar.Location = new Point(0, 0);
            pnlSideBar.Name = "pnlSideBar";
            pnlSideBar.Size = new Size(184, 515);
            pnlSideBar.TabIndex = 0;
            pnlSideBar.Paint += pnlSideBar_Paint;
            // 
            // btnStudentMode
            // 
            btnStudentMode.Location = new Point(10, 242);
            btnStudentMode.Name = "btnStudentMode";
            btnStudentMode.Size = new Size(163, 27);
            btnStudentMode.TabIndex = 7;
            btnStudentMode.Text = "Student Mode";
            btnStudentMode.UseVisualStyleBackColor = true;
            // 
            // btnReadReviews
            // 
            btnReadReviews.Location = new Point(10, 210);
            btnReadReviews.Name = "btnReadReviews";
            btnReadReviews.Size = new Size(163, 27);
            btnReadReviews.TabIndex = 6;
            btnReadReviews.Text = "Read Reviews";
            btnReadReviews.UseVisualStyleBackColor = true;
            // 
            // btnBrowseSession
            // 
            btnBrowseSession.Location = new Point(10, 178);
            btnBrowseSession.Name = "btnBrowseSession";
            btnBrowseSession.Size = new Size(163, 27);
            btnBrowseSession.TabIndex = 5;
            btnBrowseSession.Text = "Browse Session";
            btnBrowseSession.UseVisualStyleBackColor = true;
            // 
            // btnCreateSession
            // 
            btnCreateSession.Location = new Point(10, 146);
            btnCreateSession.Name = "btnCreateSession";
            btnCreateSession.Size = new Size(163, 27);
            btnCreateSession.TabIndex = 4;
            btnCreateSession.Text = "Create Session";
            btnCreateSession.UseVisualStyleBackColor = true;
            // 
            // btnTutorRequests
            // 
            btnTutorRequests.Location = new Point(10, 114);
            btnTutorRequests.Name = "btnTutorRequests";
            btnTutorRequests.Size = new Size(163, 27);
            btnTutorRequests.TabIndex = 3;
            btnTutorRequests.Text = "Tutor Requests";
            btnTutorRequests.UseVisualStyleBackColor = true;
            // 
            // btnMySession
            // 
            btnMySession.Location = new Point(10, 82);
            btnMySession.Name = "btnMySession";
            btnMySession.Size = new Size(163, 27);
            btnMySession.TabIndex = 2;
            btnMySession.Text = "My Sessions";
            btnMySession.UseVisualStyleBackColor = true;
            // 
            // btnMyProfile
            // 
            btnMyProfile.Location = new Point(10, 50);
            btnMyProfile.Name = "btnMyProfile";
            btnMyProfile.Size = new Size(163, 27);
            btnMyProfile.TabIndex = 1;
            btnMyProfile.Text = "My Profile";
            btnMyProfile.UseVisualStyleBackColor = true;
            // 
            // btnMain
            // 
            btnMain.Location = new Point(10, 18);
            btnMain.Name = "btnMain";
            btnMain.Size = new Size(163, 27);
            btnMain.TabIndex = 0;
            btnMain.Text = "Main";
            btnMain.UseVisualStyleBackColor = true;
            btnMain.Click += button1_Click;
            // 
            // lblSearchSessions
            // 
            lblSearchSessions.AutoSize = true;
            lblSearchSessions.Location = new Point(206, 41);
            lblSearchSessions.Margin = new Padding(2, 0, 2, 0);
            lblSearchSessions.Name = "lblSearchSessions";
            lblSearchSessions.Size = new Size(115, 20);
            lblSearchSessions.TabIndex = 2;
            lblSearchSessions.Text = "Search Sessions:";
            // 
            // txtSearchSessions
            // 
            txtSearchSessions.Location = new Point(327, 38);
            txtSearchSessions.Margin = new Padding(2);
            txtSearchSessions.Name = "txtSearchSessions";
            txtSearchSessions.Size = new Size(590, 27);
            txtSearchSessions.TabIndex = 3;
            // 
            // flpBrowseSessions
            // 
            flpBrowseSessions.AutoScroll = true;
            flpBrowseSessions.FlowDirection = FlowDirection.TopDown;
            flpBrowseSessions.Location = new Point(209, 78);
            flpBrowseSessions.Margin = new Padding(2);
            flpBrowseSessions.Name = "flpBrowseSessions";
            flpBrowseSessions.Padding = new Padding(8);
            flpBrowseSessions.Size = new Size(707, 414);
            flpBrowseSessions.TabIndex = 4;
            flpBrowseSessions.WrapContents = false;
            // 
            // pnlCreateSession
            // 
            pnlCreateSession.Controls.Add(txtSearchTutor);
            pnlCreateSession.Controls.Add(lblSelectedTutors);
            pnlCreateSession.Controls.Add(lblSearchTutor);
            pnlCreateSession.Controls.Add(flpTutorList);
            pnlCreateSession.Controls.Add(lblEndTime);
            pnlCreateSession.Controls.Add(lblStartTime);
            pnlCreateSession.Controls.Add(dtpEndTime);
            pnlCreateSession.Controls.Add(dtpStartTime);
            pnlCreateSession.Controls.Add(dtpSessionDate);
            pnlCreateSession.Controls.Add(btnSubmitSession);
            pnlCreateSession.Controls.Add(numSlots);
            pnlCreateSession.Controls.Add(numRequiredTutors);
            pnlCreateSession.Controls.Add(txtLocation);
            pnlCreateSession.Controls.Add(txtTopic);
            pnlCreateSession.Controls.Add(txtSubject);
            pnlCreateSession.Controls.Add(lblLocation);
            pnlCreateSession.Controls.Add(lblSlots);
            pnlCreateSession.Controls.Add(lblRequiredTutors);
            pnlCreateSession.Controls.Add(lblSessionDate);
            pnlCreateSession.Controls.Add(lblTopic);
            pnlCreateSession.Controls.Add(lblSubject);
            pnlCreateSession.Controls.Add(lblCreateSessionDescription);
            pnlCreateSession.Controls.Add(lblCreateSessionTitle);
            pnlCreateSession.Location = new Point(0, 0);
            pnlCreateSession.Margin = new Padding(2);
            pnlCreateSession.Name = "pnlCreateSession";
            pnlCreateSession.Size = new Size(942, 515);
            pnlCreateSession.TabIndex = 18;
            pnlCreateSession.Visible = false;
            // 
            // txtSearchTutor
            // 
            txtSearchTutor.Location = new Point(698, 110);
            txtSearchTutor.Margin = new Padding(2);
            txtSearchTutor.Name = "txtSearchTutor";
            txtSearchTutor.Size = new Size(209, 27);
            txtSearchTutor.TabIndex = 23;
            // 
            // lblSelectedTutors
            // 
            lblSelectedTutors.AutoSize = true;
            lblSelectedTutors.Location = new Point(601, 434);
            lblSelectedTutors.Margin = new Padding(2, 0, 2, 0);
            lblSelectedTutors.Name = "lblSelectedTutors";
            lblSelectedTutors.Size = new Size(114, 20);
            lblSelectedTutors.TabIndex = 22;
            lblSelectedTutors.Text = "Selected Tutors:";
            // 
            // lblSearchTutor
            // 
            lblSearchTutor.AutoSize = true;
            lblSearchTutor.Location = new Point(601, 114);
            lblSearchTutor.Margin = new Padding(2, 0, 2, 0);
            lblSearchTutor.Name = "lblSearchTutor";
            lblSearchTutor.Size = new Size(95, 20);
            lblSearchTutor.TabIndex = 21;
            lblSearchTutor.Text = "Search Tutor:";
            // 
            // flpTutorList
            // 
            flpTutorList.AutoScroll = true;
            flpTutorList.BorderStyle = BorderStyle.FixedSingle;
            flpTutorList.FlowDirection = FlowDirection.TopDown;
            flpTutorList.Location = new Point(601, 146);
            flpTutorList.Margin = new Padding(2);
            flpTutorList.Name = "flpTutorList";
            flpTutorList.Size = new Size(305, 275);
            flpTutorList.TabIndex = 20;
            flpTutorList.WrapContents = false;
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.Location = new Point(259, 312);
            lblEndTime.Margin = new Padding(2, 0, 2, 0);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(37, 20);
            lblEndTime.TabIndex = 19;
            lblEndTime.Text = "End:";
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Location = new Point(258, 274);
            lblStartTime.Margin = new Padding(2, 0, 2, 0);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(43, 20);
            lblStartTime.TabIndex = 18;
            lblStartTime.Text = "Start:";
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "hh:mm tt";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(327, 307);
            dtpEndTime.Margin = new Padding(2);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(213, 27);
            dtpEndTime.TabIndex = 17;
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "hh:mm tt";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(327, 274);
            dtpStartTime.Margin = new Padding(2);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.Size = new Size(213, 27);
            dtpStartTime.TabIndex = 16;
            // 
            // dtpSessionDate
            // 
            dtpSessionDate.CustomFormat = "MMMM dd, yyyy";
            dtpSessionDate.Format = DateTimePickerFormat.Custom;
            dtpSessionDate.Location = new Point(327, 240);
            dtpSessionDate.Margin = new Padding(2);
            dtpSessionDate.Name = "dtpSessionDate";
            dtpSessionDate.Size = new Size(213, 27);
            dtpSessionDate.TabIndex = 15;
            // 
            // btnSubmitSession
            // 
            btnSubmitSession.Location = new Point(755, 454);
            btnSubmitSession.Margin = new Padding(2);
            btnSubmitSession.Name = "btnSubmitSession";
            btnSubmitSession.Size = new Size(150, 27);
            btnSubmitSession.TabIndex = 14;
            btnSubmitSession.Text = "Create Session";
            btnSubmitSession.UseVisualStyleBackColor = true;
            // 
            // numSlots
            // 
            numSlots.Location = new Point(395, 390);
            numSlots.Margin = new Padding(2);
            numSlots.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            numSlots.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSlots.Name = "numSlots";
            numSlots.Size = new Size(144, 27);
            numSlots.TabIndex = 13;
            numSlots.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numRequiredTutors
            // 
            numRequiredTutors.Location = new Point(395, 346);
            numRequiredTutors.Margin = new Padding(2);
            numRequiredTutors.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numRequiredTutors.Name = "numRequiredTutors";
            numRequiredTutors.Size = new Size(144, 27);
            numRequiredTutors.TabIndex = 12;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(395, 422);
            txtLocation.Margin = new Padding(2);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(145, 27);
            txtLocation.TabIndex = 10;
            // 
            // txtTopic
            // 
            txtTopic.Location = new Point(340, 198);
            txtTopic.Margin = new Padding(2);
            txtTopic.Name = "txtTopic";
            txtTopic.Size = new Size(200, 27);
            txtTopic.TabIndex = 9;
            // 
            // txtSubject
            // 
            txtSubject.Location = new Point(340, 154);
            txtSubject.Margin = new Padding(2);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(200, 27);
            txtSubject.TabIndex = 8;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(258, 427);
            lblLocation.Margin = new Padding(2, 0, 2, 0);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(69, 20);
            lblLocation.TabIndex = 7;
            lblLocation.Text = "Location:";
            // 
            // lblSlots
            // 
            lblSlots.AutoSize = true;
            lblSlots.Location = new Point(259, 390);
            lblSlots.Margin = new Padding(2, 0, 2, 0);
            lblSlots.Name = "lblSlots";
            lblSlots.Size = new Size(44, 20);
            lblSlots.TabIndex = 6;
            lblSlots.Text = "Slots:";
            // 
            // lblRequiredTutors
            // 
            lblRequiredTutors.AutoSize = true;
            lblRequiredTutors.Location = new Point(258, 346);
            lblRequiredTutors.Margin = new Padding(2, 0, 2, 0);
            lblRequiredTutors.Name = "lblRequiredTutors";
            lblRequiredTutors.Size = new Size(117, 20);
            lblRequiredTutors.TabIndex = 5;
            lblRequiredTutors.Text = "Required Tutors:";
            // 
            // lblSessionDate
            // 
            lblSessionDate.AutoSize = true;
            lblSessionDate.Location = new Point(258, 238);
            lblSessionDate.Margin = new Padding(2, 0, 2, 0);
            lblSessionDate.Name = "lblSessionDate";
            lblSessionDate.Size = new Size(44, 20);
            lblSessionDate.TabIndex = 4;
            lblSessionDate.Text = "Date:";
            // 
            // lblTopic
            // 
            lblTopic.AutoSize = true;
            lblTopic.Location = new Point(258, 197);
            lblTopic.Margin = new Padding(2, 0, 2, 0);
            lblTopic.Name = "lblTopic";
            lblTopic.Size = new Size(48, 20);
            lblTopic.TabIndex = 3;
            lblTopic.Text = "Topic:";
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Location = new Point(258, 157);
            lblSubject.Margin = new Padding(2, 0, 2, 0);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(61, 20);
            lblSubject.TabIndex = 2;
            lblSubject.Text = "Subject:";
            // 
            // lblCreateSessionDescription
            // 
            lblCreateSessionDescription.AutoSize = true;
            lblCreateSessionDescription.Location = new Point(218, 70);
            lblCreateSessionDescription.Margin = new Padding(2, 0, 2, 0);
            lblCreateSessionDescription.Name = "lblCreateSessionDescription";
            lblCreateSessionDescription.Size = new Size(273, 20);
            lblCreateSessionDescription.TabIndex = 1;
            lblCreateSessionDescription.Text = "Set-up a study session for others to join.";
            // 
            // lblCreateSessionTitle
            // 
            lblCreateSessionTitle.AutoSize = true;
            lblCreateSessionTitle.Location = new Point(218, 30);
            lblCreateSessionTitle.Margin = new Padding(2, 0, 2, 0);
            lblCreateSessionTitle.Name = "lblCreateSessionTitle";
            lblCreateSessionTitle.Size = new Size(105, 20);
            lblCreateSessionTitle.TabIndex = 0;
            lblCreateSessionTitle.Text = "Create Session";
            // 
            // pnlMyProfile
            // 
            pnlMyProfile.Controls.Add(lblProfileRatingValue);
            pnlMyProfile.Controls.Add(lblProfileAvailabilityValue);
            pnlMyProfile.Controls.Add(txtEditAvailability);
            pnlMyProfile.Controls.Add(lblProfileRating);
            pnlMyProfile.Controls.Add(lblProfileAvailability);
            pnlMyProfile.Controls.Add(lblProfileSubjectValue);
            pnlMyProfile.Controls.Add(txtEditSubject);
            pnlMyProfile.Controls.Add(lblProfileSubject);
            pnlMyProfile.Controls.Add(lblProfileCredentialValue);
            pnlMyProfile.Controls.Add(txtEditCredential);
            pnlMyProfile.Controls.Add(lblProfileCredentials);
            pnlMyProfile.Controls.Add(btnCancelProfile);
            pnlMyProfile.Controls.Add(btnSaveProfile);
            pnlMyProfile.Controls.Add(btnEditProfile);
            pnlMyProfile.Controls.Add(lblProfileDescription);
            pnlMyProfile.Controls.Add(lblProfileTitle);
            pnlMyProfile.Location = new Point(0, 0);
            pnlMyProfile.Margin = new Padding(2);
            pnlMyProfile.Name = "pnlMyProfile";
            pnlMyProfile.Size = new Size(942, 515);
            pnlMyProfile.TabIndex = 24;
            pnlMyProfile.Visible = false;
            // 
            // lblProfileRatingValue
            // 
            lblProfileRatingValue.AutoSize = true;
            lblProfileRatingValue.Location = new Point(322, 256);
            lblProfileRatingValue.Margin = new Padding(2, 0, 2, 0);
            lblProfileRatingValue.Name = "lblProfileRatingValue";
            lblProfileRatingValue.Size = new Size(52, 20);
            lblProfileRatingValue.TabIndex = 28;
            lblProfileRatingValue.Text = "Rating";
            // 
            // lblProfileAvailabilityValue
            // 
            lblProfileAvailabilityValue.AutoSize = true;
            lblProfileAvailabilityValue.Location = new Point(322, 176);
            lblProfileAvailabilityValue.Margin = new Padding(2, 0, 2, 0);
            lblProfileAvailabilityValue.Name = "lblProfileAvailabilityValue";
            lblProfileAvailabilityValue.Size = new Size(83, 20);
            lblProfileAvailabilityValue.TabIndex = 27;
            lblProfileAvailabilityValue.Text = "Availability";
            lblProfileAvailabilityValue.Click += lblProfileAvailabilityValue_Click;
            // 
            // txtEditAvailability
            // 
            txtEditAvailability.Location = new Point(322, 176);
            txtEditAvailability.Margin = new Padding(2);
            txtEditAvailability.Name = "txtEditAvailability";
            txtEditAvailability.Size = new Size(356, 27);
            txtEditAvailability.TabIndex = 25;
            // 
            // lblProfileRating
            // 
            lblProfileRating.AutoSize = true;
            lblProfileRating.Location = new Point(233, 256);
            lblProfileRating.Margin = new Padding(2, 0, 2, 0);
            lblProfileRating.Name = "lblProfileRating";
            lblProfileRating.Size = new Size(55, 20);
            lblProfileRating.TabIndex = 24;
            lblProfileRating.Text = "Rating:";
            lblProfileRating.Click += label2_Click;
            // 
            // lblProfileAvailability
            // 
            lblProfileAvailability.AutoSize = true;
            lblProfileAvailability.Location = new Point(233, 177);
            lblProfileAvailability.Margin = new Padding(2, 0, 2, 0);
            lblProfileAvailability.Name = "lblProfileAvailability";
            lblProfileAvailability.Size = new Size(86, 20);
            lblProfileAvailability.TabIndex = 23;
            lblProfileAvailability.Text = "Availability:";
            // 
            // lblProfileSubjectValue
            // 
            lblProfileSubjectValue.AutoSize = true;
            lblProfileSubjectValue.Location = new Point(322, 142);
            lblProfileSubjectValue.Margin = new Padding(2, 0, 2, 0);
            lblProfileSubjectValue.Name = "lblProfileSubjectValue";
            lblProfileSubjectValue.Size = new Size(58, 20);
            lblProfileSubjectValue.TabIndex = 22;
            lblProfileSubjectValue.Text = "Subject";
            // 
            // txtEditSubject
            // 
            txtEditSubject.Location = new Point(322, 142);
            txtEditSubject.Margin = new Padding(2);
            txtEditSubject.Name = "txtEditSubject";
            txtEditSubject.Size = new Size(356, 27);
            txtEditSubject.TabIndex = 21;
            // 
            // lblProfileSubject
            // 
            lblProfileSubject.AutoSize = true;
            lblProfileSubject.Location = new Point(233, 142);
            lblProfileSubject.Margin = new Padding(2, 0, 2, 0);
            lblProfileSubject.Name = "lblProfileSubject";
            lblProfileSubject.Size = new Size(67, 20);
            lblProfileSubject.TabIndex = 20;
            lblProfileSubject.Text = "Subjects:";
            // 
            // lblProfileCredentialValue
            // 
            lblProfileCredentialValue.AutoSize = true;
            lblProfileCredentialValue.Location = new Point(322, 218);
            lblProfileCredentialValue.Margin = new Padding(2, 0, 2, 0);
            lblProfileCredentialValue.Name = "lblProfileCredentialValue";
            lblProfileCredentialValue.Size = new Size(77, 20);
            lblProfileCredentialValue.TabIndex = 19;
            lblProfileCredentialValue.Text = "Credential";
            lblProfileCredentialValue.Click += lblProfileCredentialValue_Click;
            // 
            // txtEditCredential
            // 
            txtEditCredential.Location = new Point(322, 218);
            txtEditCredential.Margin = new Padding(2);
            txtEditCredential.Name = "txtEditCredential";
            txtEditCredential.Size = new Size(356, 27);
            txtEditCredential.TabIndex = 18;
            // 
            // lblProfileCredentials
            // 
            lblProfileCredentials.AutoSize = true;
            lblProfileCredentials.Location = new Point(233, 218);
            lblProfileCredentials.Margin = new Padding(2, 0, 2, 0);
            lblProfileCredentials.Name = "lblProfileCredentials";
            lblProfileCredentials.Size = new Size(86, 20);
            lblProfileCredentials.TabIndex = 17;
            lblProfileCredentials.Text = "Credentials:";
            // 
            // btnCancelProfile
            // 
            btnCancelProfile.Location = new Point(777, 404);
            btnCancelProfile.Margin = new Padding(2);
            btnCancelProfile.Name = "btnCancelProfile";
            btnCancelProfile.Size = new Size(105, 27);
            btnCancelProfile.TabIndex = 16;
            btnCancelProfile.Text = "Cancel";
            btnCancelProfile.UseVisualStyleBackColor = true;
            btnCancelProfile.Visible = false;
            // 
            // btnSaveProfile
            // 
            btnSaveProfile.Location = new Point(652, 404);
            btnSaveProfile.Margin = new Padding(2);
            btnSaveProfile.Name = "btnSaveProfile";
            btnSaveProfile.Size = new Size(105, 27);
            btnSaveProfile.TabIndex = 15;
            btnSaveProfile.Text = "Save";
            btnSaveProfile.UseVisualStyleBackColor = true;
            btnSaveProfile.Visible = false;
            // 
            // btnEditProfile
            // 
            btnEditProfile.Location = new Point(652, 342);
            btnEditProfile.Margin = new Padding(2);
            btnEditProfile.Name = "btnEditProfile";
            btnEditProfile.Size = new Size(105, 27);
            btnEditProfile.TabIndex = 10;
            btnEditProfile.Text = "Edit profile";
            btnEditProfile.UseVisualStyleBackColor = true;
            // 
            // lblProfileDescription
            // 
            lblProfileDescription.AutoSize = true;
            lblProfileDescription.Location = new Point(218, 70);
            lblProfileDescription.Margin = new Padding(2, 0, 2, 0);
            lblProfileDescription.Name = "lblProfileDescription";
            lblProfileDescription.Size = new Size(307, 20);
            lblProfileDescription.TabIndex = 1;
            lblProfileDescription.Text = "View and manage your personal information.";
            // 
            // lblProfileTitle
            // 
            lblProfileTitle.AutoSize = true;
            lblProfileTitle.Location = new Point(218, 30);
            lblProfileTitle.Margin = new Padding(2, 0, 2, 0);
            lblProfileTitle.Name = "lblProfileTitle";
            lblProfileTitle.Size = new Size(76, 20);
            lblProfileTitle.TabIndex = 0;
            lblProfileTitle.Text = "My Profile";
            // 
            // pnlBrowseSession
            // 
            pnlBrowseSession.Controls.Add(textBox1);
            pnlBrowseSession.Controls.Add(label1);
            pnlBrowseSession.Controls.Add(flowLayoutPanel1);
            pnlBrowseSession.Location = new Point(0, 0);
            pnlBrowseSession.Margin = new Padding(2);
            pnlBrowseSession.Name = "pnlBrowseSession";
            pnlBrowseSession.Size = new Size(942, 515);
            pnlBrowseSession.TabIndex = 29;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(327, 38);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(590, 27);
            textBox1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(206, 41);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(115, 20);
            label1.TabIndex = 1;
            label1.Text = "Search Sessions:";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(209, 78);
            flowLayoutPanel1.Margin = new Padding(2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(8);
            flowLayoutPanel1.Size = new Size(707, 414);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.WrapContents = false;
            // 
            // pnlTutorRequest
            // 
            pnlTutorRequest.Location = new Point(0, 0);
            pnlTutorRequest.Name = "pnlTutorRequest";
            pnlTutorRequest.Size = new Size(942, 515);
            pnlTutorRequest.TabIndex = 24;
            // 
            // pnlNotification
            // 
            pnlNotification.BorderStyle = BorderStyle.FixedSingle;
            pnlNotification.Controls.Add(lblNotificationsTitle);
            pnlNotification.Controls.Add(flpNotifications);
            pnlNotification.Location = new Point(517, 103);
            pnlNotification.Margin = new Padding(2);
            pnlNotification.Name = "pnlNotification";
            pnlNotification.Size = new Size(403, 392);
            pnlNotification.TabIndex = 7;
            // 
            // lblNotificationsTitle
            // 
            lblNotificationsTitle.AutoSize = true;
            lblNotificationsTitle.Location = new Point(26, 18);
            lblNotificationsTitle.Margin = new Padding(2, 0, 2, 0);
            lblNotificationsTitle.Name = "lblNotificationsTitle";
            lblNotificationsTitle.Size = new Size(94, 20);
            lblNotificationsTitle.TabIndex = 3;
            lblNotificationsTitle.Text = "Notifications";
            // 
            // flpNotifications
            // 
            flpNotifications.AutoScroll = true;
            flpNotifications.FlowDirection = FlowDirection.TopDown;
            flpNotifications.Location = new Point(26, 57);
            flpNotifications.Margin = new Padding(2);
            flpNotifications.Name = "flpNotifications";
            flpNotifications.Size = new Size(346, 312);
            flpNotifications.TabIndex = 4;
            flpNotifications.WrapContents = false;
            // 
            // pnlBookedSessions
            // 
            pnlBookedSessions.BorderStyle = BorderStyle.FixedSingle;
            pnlBookedSessions.Controls.Add(lblBookedCount);
            pnlBookedSessions.Controls.Add(lblBookedTitle);
            pnlBookedSessions.Location = new Point(206, 103);
            pnlBookedSessions.Margin = new Padding(2);
            pnlBookedSessions.Name = "pnlBookedSessions";
            pnlBookedSessions.Size = new Size(291, 120);
            pnlBookedSessions.TabIndex = 29;
            // 
            // lblBookedCount
            // 
            lblBookedCount.AutoSize = true;
            lblBookedCount.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBookedCount.Location = new Point(26, 58);
            lblBookedCount.Margin = new Padding(2, 0, 2, 0);
            lblBookedCount.Name = "lblBookedCount";
            lblBookedCount.Size = new Size(35, 41);
            lblBookedCount.TabIndex = 4;
            lblBookedCount.Text = "0";
            // 
            // lblBookedTitle
            // 
            lblBookedTitle.AutoSize = true;
            lblBookedTitle.Location = new Point(26, 18);
            lblBookedTitle.Margin = new Padding(2, 0, 2, 0);
            lblBookedTitle.Name = "lblBookedTitle";
            lblBookedTitle.Size = new Size(119, 20);
            lblBookedTitle.TabIndex = 3;
            lblBookedTitle.Text = "Booked Sessions";
            // 
            // TutorDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 515);
            Controls.Add(pnlSideBar);
            Controls.Add(pnlMyProfile);
            Controls.Add(pnlBookedSessions);
            Controls.Add(pnlTutorRequest);
            Controls.Add(pnlCreateSession);
            Controls.Add(pnlNotification);
            Controls.Add(pnlBrowseSession);
            Controls.Add(flpBrowseSessions);
            Controls.Add(txtSearchSessions);
            Controls.Add(lblSearchSessions);
            Name = "TutorDashboard";
            Text = "TutorDashboard";
            pnlSideBar.ResumeLayout(false);
            pnlCreateSession.ResumeLayout(false);
            pnlCreateSession.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSlots).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRequiredTutors).EndInit();
            pnlMyProfile.ResumeLayout(false);
            pnlMyProfile.PerformLayout();
            pnlBrowseSession.ResumeLayout(false);
            pnlBrowseSession.PerformLayout();
            pnlNotification.ResumeLayout(false);
            pnlNotification.PerformLayout();
            pnlBookedSessions.ResumeLayout(false);
            pnlBookedSessions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlSideBar;
        private Button btnMain;
        private Button btnCreateSession;
        private Button btnTutorRequests;
        private Button btnMySession;
        private Button btnMyProfile;
        private Button btnStudentMode;
        private Button btnReadReviews;
        private Button btnBrowseSession;
        private Label lblSearchSessions;
        private TextBox txtSearchSessions;
        private FlowLayoutPanel flpBrowseSessions;
        private Panel pnlCreateSession;
        private TextBox txtSearchTutor;
        private Label lblSelectedTutors;
        private Label lblSearchTutor;
        private FlowLayoutPanel flpTutorList;
        private Label lblEndTime;
        private Label lblStartTime;
        private DateTimePicker dtpEndTime;
        private DateTimePicker dtpStartTime;
        private DateTimePicker dtpSessionDate;
        private Button btnSubmitSession;
        private NumericUpDown numSlots;
        private NumericUpDown numRequiredTutors;
        private TextBox txtLocation;
        private TextBox txtTopic;
        private TextBox txtSubject;
        private Label lblLocation;
        private Label lblSlots;
        private Label lblRequiredTutors;
        private Label lblSessionDate;
        private Label lblTopic;
        private Label lblSubject;
        private Label lblCreateSessionDescription;
        private Label lblCreateSessionTitle;
        private Panel pnlMyProfile;
        private Button btnCancelProfile;
        private Button btnSaveProfile;
        private Button btnEditProfile;
        private Label lblProfileDescription;
        private Label lblProfileTitle;
        private TextBox txtEditCredential;
        private Label lblProfileCredentials;
        private Label lblProfileCredentialValue;
        private Label lblProfileSubjectValue;
        private TextBox txtEditSubject;
        private Label lblProfileSubject;
        private TextBox txtEditAvailability;
        private Label lblProfileRating;
        private Label lblProfileAvailability;
        private Label lblProfileAvailabilityValue;
        private Label lblProfileRatingValue;
        private Panel pnlBrowseSession;
        private TextBox textBox1;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel pnlTutorRequest;
        private Panel pnlNotification;
        private Label lblNotificationsTitle;
        private FlowLayoutPanel flpNotifications;
        private Panel pnlBookedSessions;
        private Label lblBookedCount;
        private Label lblBookedTitle;
    }
}