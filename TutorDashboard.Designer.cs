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
            btnLogout = new Button();
            btnStudentMode = new Button();
            btnReadReviews = new Button();
            btnBrowseSession = new Button();
            btnCreateSession = new Button();
            btnTutorRequests = new Button();
            btnMySession = new Button();
            btnMyProfile = new Button();
            btnMain = new Button();
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
            lblTopics = new Label();
            lblSubjects = new Label();
            lblCreateSessionDescription = new Label();
            lblCreateSessionTitle = new Label();
            lblProfileTitle = new Label();
            lblProfileDescription = new Label();
            btnEditProfile = new Button();
            btnSaveProfile = new Button();
            btnCancelProfile = new Button();
            lblProfileCredentials = new Label();
            txtEditCredential = new TextBox();
            lblProfileCredentialValue = new Label();
            lblProfileSubject = new Label();
            txtEditSubject = new TextBox();
            lblProfileSubjectsValue = new Label();
            lblProfileAvailability = new Label();
            lblProfileRating = new Label();
            txtEditAvailability = new TextBox();
            lblProfileAvailabilityValue = new Label();
            lblProfileRatingValue = new Label();
            pnlMyProfile = new Panel();
            btnViewProfile = new Button();
            pnlMySessions = new Panel();
            flpOngoingSessions = new FlowLayoutPanel();
            flpCompletedSessions = new FlowLayoutPanel();
            flpUpcomingSessions = new FlowLayoutPanel();
            lblCompletedSessions = new Label();
            lblOngoingSessions = new Label();
            lblUpcomingSessions = new Label();
            lblMySessionsDescription = new Label();
            lblMySessionsTitle = new Label();
            pnlBrowseSession = new Panel();
            txtSearch = new TextBox();
            lblSearch = new Label();
            flpBrowseSession = new FlowLayoutPanel();
            pnlRequests = new Panel();
            flpTutorRequestList = new FlowLayoutPanel();
            lblTutorRequestDescription = new Label();
            lblTutorRequestsTitle = new Label();
            pnlReviews = new Panel();
            flpTutorReviews = new FlowLayoutPanel();
            lblReviewsDescription = new Label();
            lblReviews = new Label();
            pnlMainMenu = new Panel();
            pnlTutorRequests = new Panel();
            lblTutorRequestsValue = new Label();
            lblTutorRequests = new Label();
            lblWelcome = new Label();
            pnlNotifications = new Panel();
            lblNotificationsTitle = new Label();
            flpNotifications = new FlowLayoutPanel();
            pnlTutorRating = new Panel();
            lblTutorRatingValue = new Label();
            lblTutorRating = new Label();
            pnlSideBar.SuspendLayout();
            pnlCreateSession.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSlots).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRequiredTutors).BeginInit();
            pnlMyProfile.SuspendLayout();
            pnlMySessions.SuspendLayout();
            pnlBrowseSession.SuspendLayout();
            pnlRequests.SuspendLayout();
            pnlReviews.SuspendLayout();
            pnlMainMenu.SuspendLayout();
            pnlTutorRequests.SuspendLayout();
            pnlNotifications.SuspendLayout();
            pnlTutorRating.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSideBar
            // 
            pnlSideBar.BackColor = Color.MediumSlateBlue;
            pnlSideBar.Controls.Add(btnLogout);
            pnlSideBar.Controls.Add(btnStudentMode);
            pnlSideBar.Controls.Add(btnReadReviews);
            pnlSideBar.Controls.Add(btnBrowseSession);
            pnlSideBar.Controls.Add(btnCreateSession);
            pnlSideBar.Controls.Add(btnTutorRequests);
            pnlSideBar.Controls.Add(btnMySession);
            pnlSideBar.Controls.Add(btnMyProfile);
            pnlSideBar.Controls.Add(btnMain);
            pnlSideBar.Location = new Point(0, 0);
            pnlSideBar.Margin = new Padding(4);
            pnlSideBar.Name = "pnlSideBar";
            pnlSideBar.Size = new Size(230, 644);
            pnlSideBar.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(13, 305);
            btnLogout.Margin = new Padding(4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(204, 34);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnStudentMode
            // 
            btnStudentMode.Location = new Point(13, 597);
            btnStudentMode.Margin = new Padding(4);
            btnStudentMode.Name = "btnStudentMode";
            btnStudentMode.Size = new Size(204, 34);
            btnStudentMode.TabIndex = 7;
            btnStudentMode.Text = "Student Mode";
            btnStudentMode.UseVisualStyleBackColor = true;
            btnStudentMode.Click += btnStudentMode_Click;
            // 
            // btnReadReviews
            // 
            btnReadReviews.Location = new Point(12, 262);
            btnReadReviews.Margin = new Padding(4);
            btnReadReviews.Name = "btnReadReviews";
            btnReadReviews.Size = new Size(204, 34);
            btnReadReviews.TabIndex = 6;
            btnReadReviews.Text = "Read Reviews";
            btnReadReviews.UseVisualStyleBackColor = true;
            btnReadReviews.Click += btnReadReviews_Click;
            // 
            // btnBrowseSession
            // 
            btnBrowseSession.Location = new Point(12, 222);
            btnBrowseSession.Margin = new Padding(4);
            btnBrowseSession.Name = "btnBrowseSession";
            btnBrowseSession.Size = new Size(204, 34);
            btnBrowseSession.TabIndex = 5;
            btnBrowseSession.Text = "Browse Session";
            btnBrowseSession.UseVisualStyleBackColor = true;
            btnBrowseSession.Click += btnBrowseSession_Click;
            // 
            // btnCreateSession
            // 
            btnCreateSession.Location = new Point(12, 182);
            btnCreateSession.Margin = new Padding(4);
            btnCreateSession.Name = "btnCreateSession";
            btnCreateSession.Size = new Size(204, 34);
            btnCreateSession.TabIndex = 4;
            btnCreateSession.Text = "Create Session";
            btnCreateSession.UseVisualStyleBackColor = true;
            btnCreateSession.Click += btnCreateSession_Click;
            // 
            // btnTutorRequests
            // 
            btnTutorRequests.Location = new Point(12, 142);
            btnTutorRequests.Margin = new Padding(4);
            btnTutorRequests.Name = "btnTutorRequests";
            btnTutorRequests.Size = new Size(204, 34);
            btnTutorRequests.TabIndex = 3;
            btnTutorRequests.Text = "Tutor Requests";
            btnTutorRequests.UseVisualStyleBackColor = true;
            btnTutorRequests.Click += btnTutorRequests_Click;
            // 
            // btnMySession
            // 
            btnMySession.Location = new Point(12, 102);
            btnMySession.Margin = new Padding(4);
            btnMySession.Name = "btnMySession";
            btnMySession.Size = new Size(204, 34);
            btnMySession.TabIndex = 2;
            btnMySession.Text = "My Sessions";
            btnMySession.UseVisualStyleBackColor = true;
            btnMySession.Click += btnMySession_Click;
            // 
            // btnMyProfile
            // 
            btnMyProfile.Location = new Point(12, 62);
            btnMyProfile.Margin = new Padding(4);
            btnMyProfile.Name = "btnMyProfile";
            btnMyProfile.Size = new Size(204, 34);
            btnMyProfile.TabIndex = 1;
            btnMyProfile.Text = "My Profile";
            btnMyProfile.UseVisualStyleBackColor = true;
            btnMyProfile.Click += btnMyProfile_Click;
            // 
            // btnMain
            // 
            btnMain.Location = new Point(12, 22);
            btnMain.Margin = new Padding(4);
            btnMain.Name = "btnMain";
            btnMain.Size = new Size(204, 34);
            btnMain.TabIndex = 0;
            btnMain.Text = "Main";
            btnMain.UseVisualStyleBackColor = true;
            btnMain.Click += btnMain_Click;
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
            pnlCreateSession.Controls.Add(lblTopics);
            pnlCreateSession.Controls.Add(lblSubjects);
            pnlCreateSession.Controls.Add(lblCreateSessionDescription);
            pnlCreateSession.Controls.Add(lblCreateSessionTitle);
            pnlCreateSession.Location = new Point(0, 0);
            pnlCreateSession.Margin = new Padding(2);
            pnlCreateSession.Name = "pnlCreateSession";
            pnlCreateSession.Size = new Size(1178, 644);
            pnlCreateSession.TabIndex = 18;
            pnlCreateSession.Visible = false;
            // 
            // txtSearchTutor
            // 
            txtSearchTutor.Location = new Point(872, 138);
            txtSearchTutor.Margin = new Padding(2);
            txtSearchTutor.Name = "txtSearchTutor";
            txtSearchTutor.Size = new Size(260, 31);
            txtSearchTutor.TabIndex = 23;
            txtSearchTutor.Click += txtSearchTutor_Click;
            // 
            // lblSelectedTutors
            // 
            lblSelectedTutors.AutoSize = true;
            lblSelectedTutors.Location = new Point(751, 542);
            lblSelectedTutors.Margin = new Padding(2, 0, 2, 0);
            lblSelectedTutors.Name = "lblSelectedTutors";
            lblSelectedTutors.Size = new Size(137, 25);
            lblSelectedTutors.TabIndex = 22;
            lblSelectedTutors.Text = "Selected Tutors:";
            // 
            // lblSearchTutor
            // 
            lblSearchTutor.AutoSize = true;
            lblSearchTutor.Location = new Point(751, 142);
            lblSearchTutor.Margin = new Padding(2, 0, 2, 0);
            lblSearchTutor.Name = "lblSearchTutor";
            lblSearchTutor.Size = new Size(115, 25);
            lblSearchTutor.TabIndex = 21;
            lblSearchTutor.Text = "Search Tutor:";
            // 
            // flpTutorList
            // 
            flpTutorList.AutoScroll = true;
            flpTutorList.BorderStyle = BorderStyle.FixedSingle;
            flpTutorList.FlowDirection = FlowDirection.TopDown;
            flpTutorList.Location = new Point(751, 182);
            flpTutorList.Margin = new Padding(2);
            flpTutorList.Name = "flpTutorList";
            flpTutorList.Size = new Size(381, 343);
            flpTutorList.TabIndex = 20;
            flpTutorList.WrapContents = false;
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.Location = new Point(324, 390);
            lblEndTime.Margin = new Padding(2, 0, 2, 0);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(46, 25);
            lblEndTime.TabIndex = 19;
            lblEndTime.Text = "End:";
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Location = new Point(322, 342);
            lblStartTime.Margin = new Padding(2, 0, 2, 0);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(52, 25);
            lblStartTime.TabIndex = 18;
            lblStartTime.Text = "Start:";
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "hh:mm tt";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(409, 384);
            dtpEndTime.Margin = new Padding(2);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(265, 31);
            dtpEndTime.TabIndex = 17;
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "hh:mm tt";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(409, 342);
            dtpStartTime.Margin = new Padding(2);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.Size = new Size(265, 31);
            dtpStartTime.TabIndex = 16;
            // 
            // dtpSessionDate
            // 
            dtpSessionDate.CustomFormat = "MMMM dd, yyyy";
            dtpSessionDate.Format = DateTimePickerFormat.Custom;
            dtpSessionDate.Location = new Point(409, 300);
            dtpSessionDate.Margin = new Padding(2);
            dtpSessionDate.Name = "dtpSessionDate";
            dtpSessionDate.Size = new Size(265, 31);
            dtpSessionDate.TabIndex = 15;
            dtpSessionDate.ValueChanged += dtpSessionDate_ValueChanged;
            // 
            // btnSubmitSession
            // 
            btnSubmitSession.Location = new Point(944, 568);
            btnSubmitSession.Margin = new Padding(2);
            btnSubmitSession.Name = "btnSubmitSession";
            btnSubmitSession.Size = new Size(188, 34);
            btnSubmitSession.TabIndex = 14;
            btnSubmitSession.Text = "Create Session";
            btnSubmitSession.UseVisualStyleBackColor = true;
            btnSubmitSession.Click += btnSubmitSession_Click;
            // 
            // numSlots
            // 
            numSlots.Location = new Point(494, 488);
            numSlots.Margin = new Padding(2);
            numSlots.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            numSlots.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSlots.Name = "numSlots";
            numSlots.Size = new Size(180, 31);
            numSlots.TabIndex = 13;
            numSlots.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numRequiredTutors
            // 
            numRequiredTutors.Location = new Point(494, 432);
            numRequiredTutors.Margin = new Padding(2);
            numRequiredTutors.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numRequiredTutors.Name = "numRequiredTutors";
            numRequiredTutors.Size = new Size(180, 31);
            numRequiredTutors.TabIndex = 12;
            numRequiredTutors.Click += numRequiredTutors_ValueChanged;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(494, 528);
            txtLocation.Margin = new Padding(2);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(180, 31);
            txtLocation.TabIndex = 10;
            // 
            // txtTopic
            // 
            txtTopic.Location = new Point(425, 248);
            txtTopic.Margin = new Padding(2);
            txtTopic.Name = "txtTopic";
            txtTopic.Size = new Size(249, 31);
            txtTopic.TabIndex = 9;
            // 
            // txtSubject
            // 
            txtSubject.Location = new Point(425, 192);
            txtSubject.Margin = new Padding(2);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(249, 31);
            txtSubject.TabIndex = 8;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(322, 534);
            lblLocation.Margin = new Padding(2, 0, 2, 0);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(83, 25);
            lblLocation.TabIndex = 7;
            lblLocation.Text = "Location:";
            // 
            // lblSlots
            // 
            lblSlots.AutoSize = true;
            lblSlots.Location = new Point(324, 488);
            lblSlots.Margin = new Padding(2, 0, 2, 0);
            lblSlots.Name = "lblSlots";
            lblSlots.Size = new Size(55, 25);
            lblSlots.TabIndex = 6;
            lblSlots.Text = "Slots:";
            // 
            // lblRequiredTutors
            // 
            lblRequiredTutors.AutoSize = true;
            lblRequiredTutors.Location = new Point(322, 432);
            lblRequiredTutors.Margin = new Padding(2, 0, 2, 0);
            lblRequiredTutors.Name = "lblRequiredTutors";
            lblRequiredTutors.Size = new Size(141, 25);
            lblRequiredTutors.TabIndex = 5;
            lblRequiredTutors.Text = "Required Tutors:";
            // 
            // lblSessionDate
            // 
            lblSessionDate.AutoSize = true;
            lblSessionDate.Location = new Point(322, 298);
            lblSessionDate.Margin = new Padding(2, 0, 2, 0);
            lblSessionDate.Name = "lblSessionDate";
            lblSessionDate.Size = new Size(53, 25);
            lblSessionDate.TabIndex = 4;
            lblSessionDate.Text = "Date:";
            // 
            // lblTopics
            // 
            lblTopics.AutoSize = true;
            lblTopics.Location = new Point(322, 246);
            lblTopics.Margin = new Padding(2, 0, 2, 0);
            lblTopics.Name = "lblTopics";
            lblTopics.Size = new Size(57, 25);
            lblTopics.TabIndex = 3;
            lblTopics.Text = "Topic:";
            // 
            // lblSubjects
            // 
            lblSubjects.AutoSize = true;
            lblSubjects.Location = new Point(322, 196);
            lblSubjects.Margin = new Padding(2, 0, 2, 0);
            lblSubjects.Name = "lblSubjects";
            lblSubjects.Size = new Size(74, 25);
            lblSubjects.TabIndex = 2;
            lblSubjects.Text = "Subject:";
            // 
            // lblCreateSessionDescription
            // 
            lblCreateSessionDescription.AutoSize = true;
            lblCreateSessionDescription.Location = new Point(272, 88);
            lblCreateSessionDescription.Margin = new Padding(2, 0, 2, 0);
            lblCreateSessionDescription.Name = "lblCreateSessionDescription";
            lblCreateSessionDescription.Size = new Size(334, 25);
            lblCreateSessionDescription.TabIndex = 1;
            lblCreateSessionDescription.Text = "Set-up a study session for others to join.";
            // 
            // lblCreateSessionTitle
            // 
            lblCreateSessionTitle.AutoSize = true;
            lblCreateSessionTitle.Location = new Point(272, 38);
            lblCreateSessionTitle.Margin = new Padding(2, 0, 2, 0);
            lblCreateSessionTitle.Name = "lblCreateSessionTitle";
            lblCreateSessionTitle.Size = new Size(127, 25);
            lblCreateSessionTitle.TabIndex = 0;
            lblCreateSessionTitle.Text = "Create Session";
            // 
            // lblProfileTitle
            // 
            lblProfileTitle.AutoSize = true;
            lblProfileTitle.Location = new Point(272, 38);
            lblProfileTitle.Margin = new Padding(2, 0, 2, 0);
            lblProfileTitle.Name = "lblProfileTitle";
            lblProfileTitle.Size = new Size(92, 25);
            lblProfileTitle.TabIndex = 0;
            lblProfileTitle.Text = "My Profile";
            // 
            // lblProfileDescription
            // 
            lblProfileDescription.AutoSize = true;
            lblProfileDescription.Location = new Point(272, 88);
            lblProfileDescription.Margin = new Padding(2, 0, 2, 0);
            lblProfileDescription.Name = "lblProfileDescription";
            lblProfileDescription.Size = new Size(369, 25);
            lblProfileDescription.TabIndex = 1;
            lblProfileDescription.Text = "View and manage your personal information.";
            // 
            // btnEditProfile
            // 
            btnEditProfile.Location = new Point(815, 432);
            btnEditProfile.Margin = new Padding(2);
            btnEditProfile.Name = "btnEditProfile";
            btnEditProfile.Size = new Size(131, 34);
            btnEditProfile.TabIndex = 10;
            btnEditProfile.Text = "Edit profile";
            btnEditProfile.UseVisualStyleBackColor = true;
            btnEditProfile.Click += btnEditProfile_Click;
            // 
            // btnSaveProfile
            // 
            btnSaveProfile.Location = new Point(815, 505);
            btnSaveProfile.Margin = new Padding(2);
            btnSaveProfile.Name = "btnSaveProfile";
            btnSaveProfile.Size = new Size(131, 34);
            btnSaveProfile.TabIndex = 15;
            btnSaveProfile.Text = "Save";
            btnSaveProfile.UseVisualStyleBackColor = true;
            btnSaveProfile.Visible = false;
            btnSaveProfile.Click += btnSaveProfile_Click;
            // 
            // btnCancelProfile
            // 
            btnCancelProfile.Location = new Point(971, 505);
            btnCancelProfile.Margin = new Padding(2);
            btnCancelProfile.Name = "btnCancelProfile";
            btnCancelProfile.Size = new Size(131, 34);
            btnCancelProfile.TabIndex = 16;
            btnCancelProfile.Text = "Cancel";
            btnCancelProfile.UseVisualStyleBackColor = true;
            btnCancelProfile.Visible = false;
            // 
            // lblProfileCredentials
            // 
            lblProfileCredentials.AutoSize = true;
            lblProfileCredentials.Location = new Point(291, 272);
            lblProfileCredentials.Margin = new Padding(2, 0, 2, 0);
            lblProfileCredentials.Name = "lblProfileCredentials";
            lblProfileCredentials.Size = new Size(103, 25);
            lblProfileCredentials.TabIndex = 17;
            lblProfileCredentials.Text = "Credentials:";
            // 
            // txtEditCredential
            // 
            txtEditCredential.Location = new Point(402, 272);
            txtEditCredential.Margin = new Padding(2);
            txtEditCredential.Multiline = true;
            txtEditCredential.Name = "txtEditCredential";
            txtEditCredential.Size = new Size(444, 95);
            txtEditCredential.TabIndex = 18;
            txtEditCredential.Visible = false;
            // 
            // lblProfileCredentialValue
            // 
            lblProfileCredentialValue.AutoSize = true;
            lblProfileCredentialValue.Location = new Point(402, 272);
            lblProfileCredentialValue.Margin = new Padding(2, 0, 2, 0);
            lblProfileCredentialValue.Name = "lblProfileCredentialValue";
            lblProfileCredentialValue.Size = new Size(99, 25);
            lblProfileCredentialValue.TabIndex = 19;
            lblProfileCredentialValue.Text = "Credentials";
            // 
            // lblProfileSubject
            // 
            lblProfileSubject.AutoSize = true;
            lblProfileSubject.Location = new Point(291, 178);
            lblProfileSubject.Margin = new Padding(2, 0, 2, 0);
            lblProfileSubject.Name = "lblProfileSubject";
            lblProfileSubject.Size = new Size(82, 25);
            lblProfileSubject.TabIndex = 20;
            lblProfileSubject.Text = "Subjects:";
            // 
            // txtEditSubject
            // 
            txtEditSubject.Location = new Point(402, 178);
            txtEditSubject.Margin = new Padding(2);
            txtEditSubject.Name = "txtEditSubject";
            txtEditSubject.Size = new Size(444, 31);
            txtEditSubject.TabIndex = 21;
            txtEditSubject.Visible = false;
            // 
            // lblProfileSubjectsValue
            // 
            lblProfileSubjectsValue.AutoSize = true;
            lblProfileSubjectsValue.Location = new Point(402, 178);
            lblProfileSubjectsValue.Margin = new Padding(2, 0, 2, 0);
            lblProfileSubjectsValue.Name = "lblProfileSubjectsValue";
            lblProfileSubjectsValue.Size = new Size(70, 25);
            lblProfileSubjectsValue.TabIndex = 22;
            lblProfileSubjectsValue.Text = "Subject";
            // 
            // lblProfileAvailability
            // 
            lblProfileAvailability.AutoSize = true;
            lblProfileAvailability.Location = new Point(291, 221);
            lblProfileAvailability.Margin = new Padding(2, 0, 2, 0);
            lblProfileAvailability.Name = "lblProfileAvailability";
            lblProfileAvailability.Size = new Size(101, 25);
            lblProfileAvailability.TabIndex = 23;
            lblProfileAvailability.Text = "Availability:";
            // 
            // lblProfileRating
            // 
            lblProfileRating.AutoSize = true;
            lblProfileRating.Location = new Point(297, 375);
            lblProfileRating.Margin = new Padding(2, 0, 2, 0);
            lblProfileRating.Name = "lblProfileRating";
            lblProfileRating.Size = new Size(67, 25);
            lblProfileRating.TabIndex = 24;
            lblProfileRating.Text = "Rating:";
            // 
            // txtEditAvailability
            // 
            txtEditAvailability.Location = new Point(402, 220);
            txtEditAvailability.Margin = new Padding(2);
            txtEditAvailability.Name = "txtEditAvailability";
            txtEditAvailability.Size = new Size(444, 31);
            txtEditAvailability.TabIndex = 25;
            txtEditAvailability.Visible = false;
            // 
            // lblProfileAvailabilityValue
            // 
            lblProfileAvailabilityValue.AutoSize = true;
            lblProfileAvailabilityValue.Location = new Point(402, 220);
            lblProfileAvailabilityValue.Margin = new Padding(2, 0, 2, 0);
            lblProfileAvailabilityValue.Name = "lblProfileAvailabilityValue";
            lblProfileAvailabilityValue.Size = new Size(97, 25);
            lblProfileAvailabilityValue.TabIndex = 27;
            lblProfileAvailabilityValue.Text = "Availability";
            // 
            // lblProfileRatingValue
            // 
            lblProfileRatingValue.AutoSize = true;
            lblProfileRatingValue.Location = new Point(400, 407);
            lblProfileRatingValue.Margin = new Padding(2, 0, 2, 0);
            lblProfileRatingValue.Name = "lblProfileRatingValue";
            lblProfileRatingValue.Size = new Size(63, 25);
            lblProfileRatingValue.TabIndex = 28;
            lblProfileRatingValue.Text = "Rating";
            // 
            // pnlMyProfile
            // 
            pnlMyProfile.Controls.Add(btnViewProfile);
            pnlMyProfile.Controls.Add(lblProfileRatingValue);
            pnlMyProfile.Controls.Add(lblProfileAvailabilityValue);
            pnlMyProfile.Controls.Add(txtEditAvailability);
            pnlMyProfile.Controls.Add(lblProfileRating);
            pnlMyProfile.Controls.Add(lblProfileAvailability);
            pnlMyProfile.Controls.Add(lblProfileSubjectsValue);
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
            pnlMyProfile.Size = new Size(1178, 644);
            pnlMyProfile.TabIndex = 24;
            pnlMyProfile.Visible = false;
            // 
            // btnViewProfile
            // 
            btnViewProfile.Location = new Point(971, 432);
            btnViewProfile.Margin = new Padding(2);
            btnViewProfile.Name = "btnViewProfile";
            btnViewProfile.Size = new Size(131, 34);
            btnViewProfile.TabIndex = 29;
            btnViewProfile.Text = "View profile";
            btnViewProfile.UseVisualStyleBackColor = true;
            btnViewProfile.Click += btnViewProfile_Click;
            // 
            // pnlMySessions
            // 
            pnlMySessions.Controls.Add(flpOngoingSessions);
            pnlMySessions.Controls.Add(flpCompletedSessions);
            pnlMySessions.Controls.Add(flpUpcomingSessions);
            pnlMySessions.Controls.Add(lblCompletedSessions);
            pnlMySessions.Controls.Add(lblOngoingSessions);
            pnlMySessions.Controls.Add(lblUpcomingSessions);
            pnlMySessions.Controls.Add(lblMySessionsDescription);
            pnlMySessions.Controls.Add(lblMySessionsTitle);
            pnlMySessions.Location = new Point(0, 0);
            pnlMySessions.Name = "pnlMySessions";
            pnlMySessions.Size = new Size(1178, 644);
            pnlMySessions.TabIndex = 30;
            // 
            // flpOngoingSessions
            // 
            flpOngoingSessions.AutoScroll = true;
            flpOngoingSessions.FlowDirection = FlowDirection.TopDown;
            flpOngoingSessions.Location = new Point(543, 199);
            flpOngoingSessions.Name = "flpOngoingSessions";
            flpOngoingSessions.Size = new Size(291, 418);
            flpOngoingSessions.TabIndex = 6;
            flpOngoingSessions.WrapContents = false;
            // 
            // flpCompletedSessions
            // 
            flpCompletedSessions.AutoScroll = true;
            flpCompletedSessions.FlowDirection = FlowDirection.TopDown;
            flpCompletedSessions.Location = new Point(840, 199);
            flpCompletedSessions.Name = "flpCompletedSessions";
            flpCompletedSessions.Size = new Size(294, 418);
            flpCompletedSessions.TabIndex = 6;
            flpCompletedSessions.WrapContents = false;
            // 
            // flpUpcomingSessions
            // 
            flpUpcomingSessions.AutoScroll = true;
            flpUpcomingSessions.FlowDirection = FlowDirection.TopDown;
            flpUpcomingSessions.Location = new Point(261, 199);
            flpUpcomingSessions.Name = "flpUpcomingSessions";
            flpUpcomingSessions.Size = new Size(276, 418);
            flpUpcomingSessions.TabIndex = 5;
            flpUpcomingSessions.WrapContents = false;
            // 
            // lblCompletedSessions
            // 
            lblCompletedSessions.AutoSize = true;
            lblCompletedSessions.Location = new Point(851, 171);
            lblCompletedSessions.Name = "lblCompletedSessions";
            lblCompletedSessions.Size = new Size(100, 25);
            lblCompletedSessions.TabIndex = 4;
            lblCompletedSessions.Text = "Completed";
            // 
            // lblOngoingSessions
            // 
            lblOngoingSessions.AutoSize = true;
            lblOngoingSessions.Location = new Point(558, 171);
            lblOngoingSessions.Name = "lblOngoingSessions";
            lblOngoingSessions.Size = new Size(83, 25);
            lblOngoingSessions.TabIndex = 3;
            lblOngoingSessions.Text = "Ongoing";
            // 
            // lblUpcomingSessions
            // 
            lblUpcomingSessions.AutoSize = true;
            lblUpcomingSessions.Location = new Point(282, 171);
            lblUpcomingSessions.Name = "lblUpcomingSessions";
            lblUpcomingSessions.Size = new Size(95, 25);
            lblUpcomingSessions.TabIndex = 2;
            lblUpcomingSessions.Text = "Upcoming";
            // 
            // lblMySessionsDescription
            // 
            lblMySessionsDescription.AutoSize = true;
            lblMySessionsDescription.Location = new Point(272, 81);
            lblMySessionsDescription.Name = "lblMySessionsDescription";
            lblMySessionsDescription.Size = new Size(486, 25);
            lblMySessionsDescription.TabIndex = 1;
            lblMySessionsDescription.Text = "Here are your upcoming, ongoing, and completed sessions.";
            // 
            // lblMySessionsTitle
            // 
            lblMySessionsTitle.AutoSize = true;
            lblMySessionsTitle.Location = new Point(272, 38);
            lblMySessionsTitle.Name = "lblMySessionsTitle";
            lblMySessionsTitle.Size = new Size(110, 25);
            lblMySessionsTitle.TabIndex = 0;
            lblMySessionsTitle.Text = "My Sessions";
            // 
            // pnlBrowseSession
            // 
            pnlBrowseSession.Controls.Add(txtSearch);
            pnlBrowseSession.Controls.Add(lblSearch);
            pnlBrowseSession.Controls.Add(flpBrowseSession);
            pnlBrowseSession.Location = new Point(0, 0);
            pnlBrowseSession.Name = "pnlBrowseSession";
            pnlBrowseSession.Size = new Size(1178, 644);
            pnlBrowseSession.TabIndex = 24;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(370, 71);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(775, 31);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(252, 71);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(64, 25);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search";
            // 
            // flpBrowseSession
            // 
            flpBrowseSession.Location = new Point(252, 132);
            flpBrowseSession.Name = "flpBrowseSession";
            flpBrowseSession.Size = new Size(893, 499);
            flpBrowseSession.TabIndex = 0;
            // 
            // pnlRequests
            // 
            pnlRequests.Controls.Add(flpTutorRequestList);
            pnlRequests.Controls.Add(lblTutorRequestDescription);
            pnlRequests.Controls.Add(lblTutorRequestsTitle);
            pnlRequests.Location = new Point(0, 0);
            pnlRequests.Name = "pnlRequests";
            pnlRequests.Size = new Size(1178, 644);
            pnlRequests.TabIndex = 3;
            // 
            // flpTutorRequestList
            // 
            flpTutorRequestList.Location = new Point(269, 145);
            flpTutorRequestList.Name = "flpTutorRequestList";
            flpTutorRequestList.Size = new Size(876, 472);
            flpTutorRequestList.TabIndex = 2;
            // 
            // lblTutorRequestDescription
            // 
            lblTutorRequestDescription.AutoSize = true;
            lblTutorRequestDescription.Location = new Point(269, 77);
            lblTutorRequestDescription.Name = "lblTutorRequestDescription";
            lblTutorRequestDescription.Size = new Size(210, 25);
            lblTutorRequestDescription.TabIndex = 1;
            lblTutorRequestDescription.Text = "View your tutor requests.";
            // 
            // lblTutorRequestsTitle
            // 
            lblTutorRequestsTitle.AutoSize = true;
            lblTutorRequestsTitle.Location = new Point(264, 31);
            lblTutorRequestsTitle.Name = "lblTutorRequestsTitle";
            lblTutorRequestsTitle.Size = new Size(130, 25);
            lblTutorRequestsTitle.TabIndex = 0;
            lblTutorRequestsTitle.Text = "Tutor Requests";
            // 
            // pnlReviews
            // 
            pnlReviews.Controls.Add(flpTutorReviews);
            pnlReviews.Controls.Add(lblReviewsDescription);
            pnlReviews.Controls.Add(lblReviews);
            pnlReviews.Location = new Point(0, 0);
            pnlReviews.Name = "pnlReviews";
            pnlReviews.Size = new Size(1178, 644);
            pnlReviews.TabIndex = 3;
            // 
            // flpTutorReviews
            // 
            flpTutorReviews.Location = new Point(261, 142);
            flpTutorReviews.Name = "flpTutorReviews";
            flpTutorReviews.Size = new Size(881, 484);
            flpTutorReviews.TabIndex = 2;
            // 
            // lblReviewsDescription
            // 
            lblReviewsDescription.AutoSize = true;
            lblReviewsDescription.Location = new Point(272, 96);
            lblReviewsDescription.Name = "lblReviewsDescription";
            lblReviewsDescription.Size = new Size(179, 25);
            lblReviewsDescription.TabIndex = 1;
            lblReviewsDescription.Text = "Read student reviews";
            // 
            // lblReviews
            // 
            lblReviews.AutoSize = true;
            lblReviews.Location = new Point(272, 48);
            lblReviews.Name = "lblReviews";
            lblReviews.Size = new Size(74, 25);
            lblReviews.TabIndex = 0;
            lblReviews.Text = "Reviews";
            // 
            // pnlMainMenu
            // 
            pnlMainMenu.Controls.Add(pnlTutorRequests);
            pnlMainMenu.Controls.Add(lblWelcome);
            pnlMainMenu.Controls.Add(pnlNotifications);
            pnlMainMenu.Controls.Add(pnlTutorRating);
            pnlMainMenu.Location = new Point(0, 0);
            pnlMainMenu.Name = "pnlMainMenu";
            pnlMainMenu.Size = new Size(1178, 644);
            pnlMainMenu.TabIndex = 3;
            // 
            // pnlTutorRequests
            // 
            pnlTutorRequests.BorderStyle = BorderStyle.FixedSingle;
            pnlTutorRequests.Controls.Add(lblTutorRequestsValue);
            pnlTutorRequests.Controls.Add(lblTutorRequests);
            pnlTutorRequests.Location = new Point(252, 300);
            pnlTutorRequests.Margin = new Padding(2);
            pnlTutorRequests.Name = "pnlTutorRequests";
            pnlTutorRequests.Size = new Size(363, 150);
            pnlTutorRequests.TabIndex = 6;
            // 
            // lblTutorRequestsValue
            // 
            lblTutorRequestsValue.AutoSize = true;
            lblTutorRequestsValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTutorRequestsValue.Location = new Point(32, 69);
            lblTutorRequestsValue.Margin = new Padding(2, 0, 2, 0);
            lblTutorRequestsValue.Name = "lblTutorRequestsValue";
            lblTutorRequestsValue.Size = new Size(41, 48);
            lblTutorRequestsValue.TabIndex = 5;
            lblTutorRequestsValue.Text = "0";
            // 
            // lblTutorRequests
            // 
            lblTutorRequests.AutoSize = true;
            lblTutorRequests.Location = new Point(32, 25);
            lblTutorRequests.Margin = new Padding(2, 0, 2, 0);
            lblTutorRequests.Name = "lblTutorRequests";
            lblTutorRequests.Size = new Size(130, 25);
            lblTutorRequests.TabIndex = 4;
            lblTutorRequests.Text = "Tutor Requests";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(272, 38);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(85, 25);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";
            // 
            // pnlNotifications
            // 
            pnlNotifications.BorderStyle = BorderStyle.FixedSingle;
            pnlNotifications.Controls.Add(lblNotificationsTitle);
            pnlNotifications.Controls.Add(flpNotifications);
            pnlNotifications.Location = new Point(631, 107);
            pnlNotifications.Margin = new Padding(2);
            pnlNotifications.Name = "pnlNotifications";
            pnlNotifications.Size = new Size(503, 490);
            pnlNotifications.TabIndex = 7;
            // 
            // lblNotificationsTitle
            // 
            lblNotificationsTitle.AutoSize = true;
            lblNotificationsTitle.Location = new Point(32, 22);
            lblNotificationsTitle.Margin = new Padding(2, 0, 2, 0);
            lblNotificationsTitle.Name = "lblNotificationsTitle";
            lblNotificationsTitle.Size = new Size(112, 25);
            lblNotificationsTitle.TabIndex = 3;
            lblNotificationsTitle.Text = "Notifications";
            // 
            // flpNotifications
            // 
            flpNotifications.AutoScroll = true;
            flpNotifications.FlowDirection = FlowDirection.TopDown;
            flpNotifications.Location = new Point(32, 71);
            flpNotifications.Margin = new Padding(2);
            flpNotifications.Name = "flpNotifications";
            flpNotifications.Size = new Size(432, 390);
            flpNotifications.TabIndex = 4;
            flpNotifications.WrapContents = false;
            // 
            // pnlTutorRating
            // 
            pnlTutorRating.BorderStyle = BorderStyle.FixedSingle;
            pnlTutorRating.Controls.Add(lblTutorRatingValue);
            pnlTutorRating.Controls.Add(lblTutorRating);
            pnlTutorRating.Location = new Point(258, 123);
            pnlTutorRating.Margin = new Padding(2);
            pnlTutorRating.Name = "pnlTutorRating";
            pnlTutorRating.Size = new Size(363, 150);
            pnlTutorRating.TabIndex = 5;
            // 
            // lblTutorRatingValue
            // 
            lblTutorRatingValue.AutoSize = true;
            lblTutorRatingValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTutorRatingValue.Location = new Point(32, 72);
            lblTutorRatingValue.Margin = new Padding(2, 0, 2, 0);
            lblTutorRatingValue.Name = "lblTutorRatingValue";
            lblTutorRatingValue.Size = new Size(41, 48);
            lblTutorRatingValue.TabIndex = 4;
            lblTutorRatingValue.Text = "0";
            // 
            // lblTutorRating
            // 
            lblTutorRating.AutoSize = true;
            lblTutorRating.Location = new Point(32, 22);
            lblTutorRating.Margin = new Padding(2, 0, 2, 0);
            lblTutorRating.Name = "lblTutorRating";
            lblTutorRating.Size = new Size(110, 25);
            lblTutorRating.TabIndex = 3;
            lblTutorRating.Text = "Tutor Rating";
            // 
            // TutorDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 644);
            Controls.Add(pnlSideBar);
            Controls.Add(pnlCreateSession);
            Controls.Add(pnlMySessions);
            Controls.Add(pnlMyProfile);
            Controls.Add(pnlReviews);
            Controls.Add(pnlMainMenu);
            Controls.Add(pnlRequests);
            Controls.Add(pnlBrowseSession);
            Margin = new Padding(4);
            Name = "TutorDashboard";
            Text = "TutorDashboard";
            pnlSideBar.ResumeLayout(false);
            pnlCreateSession.ResumeLayout(false);
            pnlCreateSession.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSlots).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRequiredTutors).EndInit();
            pnlMyProfile.ResumeLayout(false);
            pnlMyProfile.PerformLayout();
            pnlMySessions.ResumeLayout(false);
            pnlMySessions.PerformLayout();
            pnlBrowseSession.ResumeLayout(false);
            pnlBrowseSession.PerformLayout();
            pnlRequests.ResumeLayout(false);
            pnlRequests.PerformLayout();
            pnlReviews.ResumeLayout(false);
            pnlReviews.PerformLayout();
            pnlMainMenu.ResumeLayout(false);
            pnlMainMenu.PerformLayout();
            pnlTutorRequests.ResumeLayout(false);
            pnlTutorRequests.PerformLayout();
            pnlNotifications.ResumeLayout(false);
            pnlNotifications.PerformLayout();
            pnlTutorRating.ResumeLayout(false);
            pnlTutorRating.PerformLayout();
            ResumeLayout(false);
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
        private Label lblTopics;
        private Label lblSubjects;
        private Label lblCreateSessionDescription;
        private Label lblCreateSessionTitle;
        private Label lblProfileTitle;
        private Label lblProfileDescription;
        private Button btnEditProfile;
        private Button btnSaveProfile;
        private Button btnCancelProfile;
        private Label lblProfileCredentials;
        private TextBox txtEditCredential;
        private Label lblProfileCredentialValue;
        private Label lblProfileSubject;
        private TextBox txtEditSubject;
        private Label lblProfileSubjectsValue;
        private Label lblProfileAvailability;
        private Label lblProfileRating;
        private TextBox txtEditAvailability;
        private Label lblProfileAvailabilityValue;
        private Label lblProfileRatingValue;
        private Panel pnlMyProfile;
        private Button btnViewProfile;
        private Panel pnlMySessions;
        private Label lblMySessionsDescription;
        private Label lblMySessionsTitle;
        private Label lblUpcomingSessions;
        private FlowLayoutPanel flpOngoingSessions;
        private FlowLayoutPanel flpCompletedSessions;
        private FlowLayoutPanel flpUpcomingSessions;
        private Label lblCompletedSessions;
        private Label lblOngoingSessions;
        private Panel pnlRequests;
        private TextBox txtSearch;
        private Label lblSearch;
        private Label label2;
        private Panel pnlBrowseSession;
        private FlowLayoutPanel flpBrowseSession;
        private Panel pnlReviews;
        private FlowLayoutPanel flpTutorRequestList;
        private Label lblTutorRequestDescription;
        private Label lblTutorRequestsTitle;
        private FlowLayoutPanel flpTutorReviews;
        private Label lblReviewsDescription;
        private Label lblReviews;
        private Panel pnlMainMenu;
        private Panel pnlTutorRequests;
        private Label lblTutorRequestsValue;
        private Label lblTutorRequests;
        private Panel pnlNotifications;
        private Label lblNotificationsTitle;
        private FlowLayoutPanel flpNotifications;
        private Panel pnlTutorRating;
        private Label lblTutorRatingValue;
        private Label lblTutorRating;
        private Panel pnlNotification;
        private Panel pnlWaitlistedSessions;
        private Label lblWaitlistedCount;
        private Panel pnlBookedSessions;
        private Button btnLogout;
        private Label lblWelcome;
    }
}