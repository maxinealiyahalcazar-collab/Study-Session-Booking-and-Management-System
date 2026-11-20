namespace Study_Session
{
    partial class StudentDashboard
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
            pnlSidebar = new Panel();
            btnSwitchTutorMode = new Button();
            btnLogout = new Button();
            btnBrowseSession = new Button();
            btnCreateSession = new Button();
            btnMySessions = new Button();
            btnMyProfile = new Button();
            btnMain = new Button();
            lblDashboardTitle = new Label();
            lblWelcome = new Label();
            pnlBookedSessions = new Panel();
            lblBookedCount = new Label();
            lblBookedTitle = new Label();
            pnlWaitlistedSessions = new Panel();
            lblWaitlistedCount = new Label();
            lblWaitlistedTitle = new Label();
            pnlCompletedSessions = new Panel();
            lblCompletedCount = new Label();
            lblCompletedTitle = new Label();
            pnlNotification = new Panel();
            lblNotificationsTitle = new Label();
            flpNotifications = new FlowLayoutPanel();
            pnlMyProfile = new Panel();
            btnViewProfile = new Button();
            btnCancelProfile = new Button();
            btnSaveProfile = new Button();
            lblProfileProgramValue = new Label();
            lblProfileYearValue = new Label();
            lblProfileUEGmailValue = new Label();
            lblProfileFullNameValue = new Label();
            btnEditProfile = new Button();
            txtEditFullName = new TextBox();
            txtEditProgram = new TextBox();
            txtEditUEGmail = new TextBox();
            txtEditYear = new TextBox();
            lblProfileYear = new Label();
            lblProfileProgram = new Label();
            lblProfileUEGmail = new Label();
            lblProfileFullName = new Label();
            lblProfileDescription = new Label();
            lblProfileTitle = new Label();
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
            pnlBrowseSession = new Panel();
            txtSearchSessions = new TextBox();
            lblSearchSessions = new Label();
            flpBrowseSessions = new FlowLayoutPanel();
            flpUpcomingSessions = new FlowLayoutPanel();
            flpOngoingSessions = new FlowLayoutPanel();
            flpCompletedSessions = new FlowLayoutPanel();
            pnlMySession = new Panel();
            lblCompleted = new Label();
            lblOngoing = new Label();
            lblUpcoming = new Label();
            lblMySessionsDescription = new Label();
            lblMySessions = new Label();
            flpWaitlistedSessions = new FlowLayoutPanel();
            lblWaitlist = new Label();
            pnlSidebar.SuspendLayout();
            pnlBookedSessions.SuspendLayout();
            pnlWaitlistedSessions.SuspendLayout();
            pnlCompletedSessions.SuspendLayout();
            pnlNotification.SuspendLayout();
            pnlMyProfile.SuspendLayout();
            pnlCreateSession.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSlots).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRequiredTutors).BeginInit();
            pnlBrowseSession.SuspendLayout();
            pnlMySession.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.MediumSlateBlue;
            pnlSidebar.Controls.Add(btnSwitchTutorMode);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(btnBrowseSession);
            pnlSidebar.Controls.Add(btnCreateSession);
            pnlSidebar.Controls.Add(btnMySessions);
            pnlSidebar.Controls.Add(btnMyProfile);
            pnlSidebar.Controls.Add(btnMain);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(230, 644);
            pnlSidebar.TabIndex = 0;
            // 
            // btnSwitchTutorMode
            // 
            btnSwitchTutorMode.Location = new Point(12, 598);
            btnSwitchTutorMode.Name = "btnSwitchTutorMode";
            btnSwitchTutorMode.Size = new Size(204, 34);
            btnSwitchTutorMode.TabIndex = 8;
            btnSwitchTutorMode.Text = "Switch to Tutor Mode";
            btnSwitchTutorMode.UseVisualStyleBackColor = true;
            btnSwitchTutorMode.Click += btnSwitchTutorMode_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(12, 223);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(204, 34);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnBrowseSession
            // 
            btnBrowseSession.Location = new Point(12, 183);
            btnBrowseSession.Name = "btnBrowseSession";
            btnBrowseSession.Size = new Size(204, 34);
            btnBrowseSession.TabIndex = 6;
            btnBrowseSession.Text = "Browse Session";
            btnBrowseSession.UseVisualStyleBackColor = true;
            // 
            // btnCreateSession
            // 
            btnCreateSession.Location = new Point(12, 143);
            btnCreateSession.Name = "btnCreateSession";
            btnCreateSession.Size = new Size(204, 34);
            btnCreateSession.TabIndex = 5;
            btnCreateSession.Text = "Create Session";
            btnCreateSession.UseVisualStyleBackColor = true;
            btnCreateSession.Click += btnCreateSession_Click;
            // 
            // btnMySessions
            // 
            btnMySessions.Location = new Point(12, 103);
            btnMySessions.Name = "btnMySessions";
            btnMySessions.Size = new Size(204, 34);
            btnMySessions.TabIndex = 4;
            btnMySessions.Text = "My Sessions";
            btnMySessions.UseVisualStyleBackColor = true;
            btnMySessions.Click += btnMySessions_Click;
            // 
            // btnMyProfile
            // 
            btnMyProfile.Location = new Point(12, 63);
            btnMyProfile.Name = "btnMyProfile";
            btnMyProfile.Size = new Size(204, 34);
            btnMyProfile.TabIndex = 3;
            btnMyProfile.Text = "My Profile";
            btnMyProfile.UseVisualStyleBackColor = true;
            btnMyProfile.Click += btnMyProfile_Click;
            // 
            // btnMain
            // 
            btnMain.Location = new Point(12, 23);
            btnMain.Name = "btnMain";
            btnMain.Size = new Size(204, 34);
            btnMain.TabIndex = 2;
            btnMain.Text = "Main";
            btnMain.UseVisualStyleBackColor = true;
            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.AutoSize = true;
            lblDashboardTitle.Location = new Point(257, 23);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(166, 25);
            lblDashboardTitle.TabIndex = 1;
            lblDashboardTitle.Text = "Student Dashboard";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(257, 63);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(132, 25);
            lblWelcome.TabIndex = 2;
            lblWelcome.Text = "Welcome back!";
            // 
            // pnlBookedSessions
            // 
            pnlBookedSessions.BorderStyle = BorderStyle.FixedSingle;
            pnlBookedSessions.Controls.Add(lblBookedCount);
            pnlBookedSessions.Controls.Add(lblBookedTitle);
            pnlBookedSessions.Location = new Point(257, 129);
            pnlBookedSessions.Name = "pnlBookedSessions";
            pnlBookedSessions.Size = new Size(363, 150);
            pnlBookedSessions.TabIndex = 3;
            // 
            // lblBookedCount
            // 
            lblBookedCount.AutoSize = true;
            lblBookedCount.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBookedCount.Location = new Point(33, 72);
            lblBookedCount.Name = "lblBookedCount";
            lblBookedCount.Size = new Size(41, 48);
            lblBookedCount.TabIndex = 4;
            lblBookedCount.Text = "0";
            // 
            // lblBookedTitle
            // 
            lblBookedTitle.AutoSize = true;
            lblBookedTitle.Location = new Point(33, 23);
            lblBookedTitle.Name = "lblBookedTitle";
            lblBookedTitle.Size = new Size(146, 25);
            lblBookedTitle.TabIndex = 3;
            lblBookedTitle.Text = "Booked Sessions";
            // 
            // pnlWaitlistedSessions
            // 
            pnlWaitlistedSessions.BorderStyle = BorderStyle.FixedSingle;
            pnlWaitlistedSessions.Controls.Add(lblWaitlistedCount);
            pnlWaitlistedSessions.Controls.Add(lblWaitlistedTitle);
            pnlWaitlistedSessions.Location = new Point(257, 300);
            pnlWaitlistedSessions.Name = "pnlWaitlistedSessions";
            pnlWaitlistedSessions.Size = new Size(363, 150);
            pnlWaitlistedSessions.TabIndex = 4;
            // 
            // lblWaitlistedCount
            // 
            lblWaitlistedCount.AutoSize = true;
            lblWaitlistedCount.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWaitlistedCount.Location = new Point(33, 69);
            lblWaitlistedCount.Name = "lblWaitlistedCount";
            lblWaitlistedCount.Size = new Size(41, 48);
            lblWaitlistedCount.TabIndex = 5;
            lblWaitlistedCount.Text = "0";
            // 
            // lblWaitlistedTitle
            // 
            lblWaitlistedTitle.AutoSize = true;
            lblWaitlistedTitle.Location = new Point(33, 25);
            lblWaitlistedTitle.Name = "lblWaitlistedTitle";
            lblWaitlistedTitle.Size = new Size(162, 25);
            lblWaitlistedTitle.TabIndex = 4;
            lblWaitlistedTitle.Text = "Waitlisted Sessions";
            // 
            // pnlCompletedSessions
            // 
            pnlCompletedSessions.BorderStyle = BorderStyle.FixedSingle;
            pnlCompletedSessions.Controls.Add(lblCompletedCount);
            pnlCompletedSessions.Controls.Add(lblCompletedTitle);
            pnlCompletedSessions.Location = new Point(257, 469);
            pnlCompletedSessions.Name = "pnlCompletedSessions";
            pnlCompletedSessions.Size = new Size(363, 150);
            pnlCompletedSessions.TabIndex = 5;
            // 
            // lblCompletedCount
            // 
            lblCompletedCount.AutoSize = true;
            lblCompletedCount.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompletedCount.Location = new Point(33, 73);
            lblCompletedCount.Name = "lblCompletedCount";
            lblCompletedCount.Size = new Size(41, 48);
            lblCompletedCount.TabIndex = 6;
            lblCompletedCount.Text = "0";
            // 
            // lblCompletedTitle
            // 
            lblCompletedTitle.AutoSize = true;
            lblCompletedTitle.Location = new Point(33, 23);
            lblCompletedTitle.Name = "lblCompletedTitle";
            lblCompletedTitle.Size = new Size(173, 25);
            lblCompletedTitle.TabIndex = 3;
            lblCompletedTitle.Text = "Completed Sessions";
            // 
            // pnlNotification
            // 
            pnlNotification.BorderStyle = BorderStyle.FixedSingle;
            pnlNotification.Controls.Add(lblNotificationsTitle);
            pnlNotification.Controls.Add(flpNotifications);
            pnlNotification.Location = new Point(646, 129);
            pnlNotification.Name = "pnlNotification";
            pnlNotification.Size = new Size(503, 490);
            pnlNotification.TabIndex = 6;
            // 
            // lblNotificationsTitle
            // 
            lblNotificationsTitle.AutoSize = true;
            lblNotificationsTitle.Location = new Point(33, 23);
            lblNotificationsTitle.Name = "lblNotificationsTitle";
            lblNotificationsTitle.Size = new Size(112, 25);
            lblNotificationsTitle.TabIndex = 3;
            lblNotificationsTitle.Text = "Notifications";
            // 
            // flpNotifications
            // 
            flpNotifications.AutoScroll = true;
            flpNotifications.FlowDirection = FlowDirection.TopDown;
            flpNotifications.Location = new Point(33, 71);
            flpNotifications.Name = "flpNotifications";
            flpNotifications.Size = new Size(433, 390);
            flpNotifications.TabIndex = 4;
            flpNotifications.WrapContents = false;
            // 
            // pnlMyProfile
            // 
            pnlMyProfile.Controls.Add(btnViewProfile);
            pnlMyProfile.Controls.Add(btnCancelProfile);
            pnlMyProfile.Controls.Add(btnSaveProfile);
            pnlMyProfile.Controls.Add(lblProfileProgramValue);
            pnlMyProfile.Controls.Add(lblProfileYearValue);
            pnlMyProfile.Controls.Add(lblProfileUEGmailValue);
            pnlMyProfile.Controls.Add(lblProfileFullNameValue);
            pnlMyProfile.Controls.Add(btnEditProfile);
            pnlMyProfile.Controls.Add(txtEditFullName);
            pnlMyProfile.Controls.Add(txtEditProgram);
            pnlMyProfile.Controls.Add(txtEditUEGmail);
            pnlMyProfile.Controls.Add(txtEditYear);
            pnlMyProfile.Controls.Add(lblProfileYear);
            pnlMyProfile.Controls.Add(lblProfileProgram);
            pnlMyProfile.Controls.Add(lblProfileUEGmail);
            pnlMyProfile.Controls.Add(lblProfileFullName);
            pnlMyProfile.Controls.Add(lblProfileDescription);
            pnlMyProfile.Controls.Add(lblProfileTitle);
            pnlMyProfile.Location = new Point(0, 0);
            pnlMyProfile.Name = "pnlMyProfile";
            pnlMyProfile.Size = new Size(1415, 644);
            pnlMyProfile.TabIndex = 7;
            pnlMyProfile.Visible = false;
            // 
            // btnViewProfile
            // 
            btnViewProfile.Location = new Point(971, 451);
            btnViewProfile.Name = "btnViewProfile";
            btnViewProfile.Size = new Size(131, 34);
            btnViewProfile.TabIndex = 17;
            btnViewProfile.Text = "View Profile";
            btnViewProfile.UseVisualStyleBackColor = true;
            btnViewProfile.Click += btnViewProfile_Click;
            // 
            // btnCancelProfile
            // 
            btnCancelProfile.Location = new Point(971, 505);
            btnCancelProfile.Name = "btnCancelProfile";
            btnCancelProfile.Size = new Size(131, 34);
            btnCancelProfile.TabIndex = 16;
            btnCancelProfile.Text = "Cancel";
            btnCancelProfile.UseVisualStyleBackColor = true;
            btnCancelProfile.Visible = false;
            btnCancelProfile.Click += btnCancelProfile_Click;
            // 
            // btnSaveProfile
            // 
            btnSaveProfile.Location = new Point(815, 505);
            btnSaveProfile.Name = "btnSaveProfile";
            btnSaveProfile.Size = new Size(131, 34);
            btnSaveProfile.TabIndex = 15;
            btnSaveProfile.Text = "Save";
            btnSaveProfile.UseVisualStyleBackColor = true;
            btnSaveProfile.Visible = false;
            btnSaveProfile.Click += btnSaveProfile_Click;
            // 
            // lblProfileProgramValue
            // 
            lblProfileProgramValue.AutoSize = true;
            lblProfileProgramValue.Location = new Point(409, 320);
            lblProfileProgramValue.Name = "lblProfileProgramValue";
            lblProfileProgramValue.Size = new Size(81, 25);
            lblProfileProgramValue.TabIndex = 14;
            lblProfileProgramValue.Text = "Program";
            // 
            // lblProfileYearValue
            // 
            lblProfileYearValue.AutoSize = true;
            lblProfileYearValue.Location = new Point(409, 272);
            lblProfileYearValue.Name = "lblProfileYearValue";
            lblProfileYearValue.Size = new Size(44, 25);
            lblProfileYearValue.TabIndex = 13;
            lblProfileYearValue.Text = "Year";
            // 
            // lblProfileUEGmailValue
            // 
            lblProfileUEGmailValue.AutoSize = true;
            lblProfileUEGmailValue.Location = new Point(402, 223);
            lblProfileUEGmailValue.Name = "lblProfileUEGmailValue";
            lblProfileUEGmailValue.Size = new Size(83, 25);
            lblProfileUEGmailValue.TabIndex = 12;
            lblProfileUEGmailValue.Text = "UE Gmail";
            // 
            // lblProfileFullNameValue
            // 
            lblProfileFullNameValue.AutoSize = true;
            lblProfileFullNameValue.Location = new Point(402, 177);
            lblProfileFullNameValue.Name = "lblProfileFullNameValue";
            lblProfileFullNameValue.Size = new Size(91, 25);
            lblProfileFullNameValue.TabIndex = 11;
            lblProfileFullNameValue.Text = "Full Name";
            // 
            // btnEditProfile
            // 
            btnEditProfile.Location = new Point(815, 451);
            btnEditProfile.Name = "btnEditProfile";
            btnEditProfile.Size = new Size(131, 34);
            btnEditProfile.TabIndex = 10;
            btnEditProfile.Text = "Edit profile";
            btnEditProfile.UseVisualStyleBackColor = true;
            btnEditProfile.Click += btnEditProfile_Click;
            // 
            // txtEditFullName
            // 
            txtEditFullName.Location = new Point(402, 177);
            txtEditFullName.Name = "txtEditFullName";
            txtEditFullName.Size = new Size(444, 31);
            txtEditFullName.TabIndex = 9;
            txtEditFullName.Visible = false;
            // 
            // txtEditProgram
            // 
            txtEditProgram.Location = new Point(402, 320);
            txtEditProgram.Name = "txtEditProgram";
            txtEditProgram.Size = new Size(444, 31);
            txtEditProgram.TabIndex = 8;
            txtEditProgram.Visible = false;
            // 
            // txtEditUEGmail
            // 
            txtEditUEGmail.Location = new Point(402, 220);
            txtEditUEGmail.Name = "txtEditUEGmail";
            txtEditUEGmail.Size = new Size(444, 31);
            txtEditUEGmail.TabIndex = 7;
            txtEditUEGmail.Visible = false;
            // 
            // txtEditYear
            // 
            txtEditYear.Location = new Point(402, 272);
            txtEditYear.Name = "txtEditYear";
            txtEditYear.Size = new Size(444, 31);
            txtEditYear.TabIndex = 6;
            txtEditYear.Visible = false;
            // 
            // lblProfileYear
            // 
            lblProfileYear.AutoSize = true;
            lblProfileYear.Location = new Point(291, 272);
            lblProfileYear.Name = "lblProfileYear";
            lblProfileYear.Size = new Size(48, 25);
            lblProfileYear.TabIndex = 5;
            lblProfileYear.Text = "Year:";
            // 
            // lblProfileProgram
            // 
            lblProfileProgram.AutoSize = true;
            lblProfileProgram.Location = new Point(291, 320);
            lblProfileProgram.Name = "lblProfileProgram";
            lblProfileProgram.Size = new Size(85, 25);
            lblProfileProgram.TabIndex = 4;
            lblProfileProgram.Text = "Program:";
            // 
            // lblProfileUEGmail
            // 
            lblProfileUEGmail.AutoSize = true;
            lblProfileUEGmail.Location = new Point(291, 221);
            lblProfileUEGmail.Name = "lblProfileUEGmail";
            lblProfileUEGmail.Size = new Size(87, 25);
            lblProfileUEGmail.TabIndex = 3;
            lblProfileUEGmail.Text = "UE Gmail:";
            // 
            // lblProfileFullName
            // 
            lblProfileFullName.AutoSize = true;
            lblProfileFullName.Location = new Point(291, 177);
            lblProfileFullName.Name = "lblProfileFullName";
            lblProfileFullName.Size = new Size(95, 25);
            lblProfileFullName.TabIndex = 2;
            lblProfileFullName.Text = "Full Name:";
            // 
            // lblProfileDescription
            // 
            lblProfileDescription.AutoSize = true;
            lblProfileDescription.Location = new Point(273, 88);
            lblProfileDescription.Name = "lblProfileDescription";
            lblProfileDescription.Size = new Size(369, 25);
            lblProfileDescription.TabIndex = 1;
            lblProfileDescription.Text = "View and manage your personal information.";
            // 
            // lblProfileTitle
            // 
            lblProfileTitle.AutoSize = true;
            lblProfileTitle.Location = new Point(273, 38);
            lblProfileTitle.Name = "lblProfileTitle";
            lblProfileTitle.Size = new Size(92, 25);
            lblProfileTitle.TabIndex = 0;
            lblProfileTitle.Text = "My Profile";
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
            pnlCreateSession.Name = "pnlCreateSession";
            pnlCreateSession.Size = new Size(1412, 644);
            pnlCreateSession.TabIndex = 17;
            pnlCreateSession.Visible = false;
            // 
            // txtSearchTutor
            // 
            txtSearchTutor.Location = new Point(872, 137);
            txtSearchTutor.Name = "txtSearchTutor";
            txtSearchTutor.Size = new Size(260, 31);
            txtSearchTutor.TabIndex = 23;
            txtSearchTutor.TextChanged += txtSearchTutor_TextChanged;
            // 
            // lblSelectedTutors
            // 
            lblSelectedTutors.AutoSize = true;
            lblSelectedTutors.Location = new Point(751, 542);
            lblSelectedTutors.Name = "lblSelectedTutors";
            lblSelectedTutors.Size = new Size(137, 25);
            lblSelectedTutors.TabIndex = 22;
            lblSelectedTutors.Text = "Selected Tutors:";
            // 
            // lblSearchTutor
            // 
            lblSearchTutor.AutoSize = true;
            lblSearchTutor.Location = new Point(751, 143);
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
            flpTutorList.Location = new Point(751, 183);
            flpTutorList.Name = "flpTutorList";
            flpTutorList.Size = new Size(381, 343);
            flpTutorList.TabIndex = 20;
            flpTutorList.WrapContents = false;
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.Location = new Point(324, 390);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(46, 25);
            lblEndTime.TabIndex = 19;
            lblEndTime.Text = "End:";
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Location = new Point(323, 343);
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
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(265, 31);
            dtpEndTime.TabIndex = 17;
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "hh:mm tt";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(409, 343);
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
            dtpSessionDate.Name = "dtpSessionDate";
            dtpSessionDate.Size = new Size(265, 31);
            dtpSessionDate.TabIndex = 15;
            dtpSessionDate.ValueChanged += dtpSessionDate_ValueChanged;
            // 
            // btnSubmitSession
            // 
            btnSubmitSession.Location = new Point(944, 568);
            btnSubmitSession.Name = "btnSubmitSession";
            btnSubmitSession.Size = new Size(188, 34);
            btnSubmitSession.TabIndex = 14;
            btnSubmitSession.Text = "Create Session";
            btnSubmitSession.UseVisualStyleBackColor = true;
            btnSubmitSession.Click += btnSubmitSession_Click;
            // 
            // numSlots
            // 
            numSlots.Location = new Point(494, 487);
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
            numRequiredTutors.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numRequiredTutors.Name = "numRequiredTutors";
            numRequiredTutors.Size = new Size(180, 31);
            numRequiredTutors.TabIndex = 12;
            numRequiredTutors.ValueChanged += numRequiredTutors_ValueChanged;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(494, 528);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(180, 31);
            txtLocation.TabIndex = 10;
            // 
            // txtTopic
            // 
            txtTopic.Location = new Point(425, 248);
            txtTopic.Name = "txtTopic";
            txtTopic.Size = new Size(249, 31);
            txtTopic.TabIndex = 9;
            // 
            // txtSubject
            // 
            txtSubject.Location = new Point(425, 193);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(249, 31);
            txtSubject.TabIndex = 8;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(322, 534);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(83, 25);
            lblLocation.TabIndex = 7;
            lblLocation.Text = "Location:";
            // 
            // lblSlots
            // 
            lblSlots.AutoSize = true;
            lblSlots.Location = new Point(324, 487);
            lblSlots.Name = "lblSlots";
            lblSlots.Size = new Size(55, 25);
            lblSlots.TabIndex = 6;
            lblSlots.Text = "Slots:";
            // 
            // lblRequiredTutors
            // 
            lblRequiredTutors.AutoSize = true;
            lblRequiredTutors.Location = new Point(322, 432);
            lblRequiredTutors.Name = "lblRequiredTutors";
            lblRequiredTutors.Size = new Size(141, 25);
            lblRequiredTutors.TabIndex = 5;
            lblRequiredTutors.Text = "Required Tutors:";
            // 
            // lblSessionDate
            // 
            lblSessionDate.AutoSize = true;
            lblSessionDate.Location = new Point(322, 297);
            lblSessionDate.Name = "lblSessionDate";
            lblSessionDate.Size = new Size(53, 25);
            lblSessionDate.TabIndex = 4;
            lblSessionDate.Text = "Date:";
            // 
            // lblTopic
            // 
            lblTopic.AutoSize = true;
            lblTopic.Location = new Point(322, 246);
            lblTopic.Name = "lblTopic";
            lblTopic.Size = new Size(57, 25);
            lblTopic.TabIndex = 3;
            lblTopic.Text = "Topic:";
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Location = new Point(322, 196);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(74, 25);
            lblSubject.TabIndex = 2;
            lblSubject.Text = "Subject:";
            // 
            // lblCreateSessionDescription
            // 
            lblCreateSessionDescription.AutoSize = true;
            lblCreateSessionDescription.Location = new Point(273, 88);
            lblCreateSessionDescription.Name = "lblCreateSessionDescription";
            lblCreateSessionDescription.Size = new Size(334, 25);
            lblCreateSessionDescription.TabIndex = 1;
            lblCreateSessionDescription.Text = "Set-up a study session for others to join.";
            // 
            // lblCreateSessionTitle
            // 
            lblCreateSessionTitle.AutoSize = true;
            lblCreateSessionTitle.Location = new Point(273, 38);
            lblCreateSessionTitle.Name = "lblCreateSessionTitle";
            lblCreateSessionTitle.Size = new Size(127, 25);
            lblCreateSessionTitle.TabIndex = 0;
            lblCreateSessionTitle.Text = "Create Session";
            // 
            // pnlBrowseSession
            // 
            pnlBrowseSession.Controls.Add(txtSearchSessions);
            pnlBrowseSession.Controls.Add(lblSearchSessions);
            pnlBrowseSession.Controls.Add(flpBrowseSessions);
            pnlBrowseSession.Location = new Point(0, 0);
            pnlBrowseSession.Name = "pnlBrowseSession";
            pnlBrowseSession.Size = new Size(1178, 644);
            pnlBrowseSession.TabIndex = 17;
            // 
            // txtSearchSessions
            // 
            txtSearchSessions.Location = new Point(409, 48);
            txtSearchSessions.Name = "txtSearchSessions";
            txtSearchSessions.Size = new Size(736, 31);
            txtSearchSessions.TabIndex = 2;
            txtSearchSessions.TextChanged += txtSearchSessions_TextChanged_1;
            // 
            // lblSearchSessions
            // 
            lblSearchSessions.AutoSize = true;
            lblSearchSessions.Location = new Point(257, 51);
            lblSearchSessions.Name = "lblSearchSessions";
            lblSearchSessions.Size = new Size(141, 25);
            lblSearchSessions.TabIndex = 1;
            lblSearchSessions.Text = "Search Sessions:";
            // 
            // flpBrowseSessions
            // 
            flpBrowseSessions.AutoScroll = true;
            flpBrowseSessions.FlowDirection = FlowDirection.TopDown;
            flpBrowseSessions.Location = new Point(261, 98);
            flpBrowseSessions.Name = "flpBrowseSessions";
            flpBrowseSessions.Padding = new Padding(10);
            flpBrowseSessions.Size = new Size(884, 517);
            flpBrowseSessions.TabIndex = 0;
            flpBrowseSessions.WrapContents = false;
            // 
            // flpUpcomingSessions
            // 
            flpUpcomingSessions.AutoScroll = true;
            flpUpcomingSessions.FlowDirection = FlowDirection.TopDown;
            flpUpcomingSessions.Location = new Point(544, 193);
            flpUpcomingSessions.Name = "flpUpcomingSessions";
            flpUpcomingSessions.Size = new Size(265, 426);
            flpUpcomingSessions.TabIndex = 0;
            flpUpcomingSessions.WrapContents = false;
            // 
            // flpOngoingSessions
            // 
            flpOngoingSessions.AutoScroll = true;
            flpOngoingSessions.FlowDirection = FlowDirection.TopDown;
            flpOngoingSessions.Location = new Point(826, 193);
            flpOngoingSessions.Name = "flpOngoingSessions";
            flpOngoingSessions.Size = new Size(276, 426);
            flpOngoingSessions.TabIndex = 1;
            flpOngoingSessions.WrapContents = false;
            // 
            // flpCompletedSessions
            // 
            flpCompletedSessions.AutoScroll = true;
            flpCompletedSessions.FlowDirection = FlowDirection.TopDown;
            flpCompletedSessions.Location = new Point(1119, 189);
            flpCompletedSessions.Name = "flpCompletedSessions";
            flpCompletedSessions.Size = new Size(269, 426);
            flpCompletedSessions.TabIndex = 2;
            flpCompletedSessions.WrapContents = false;
            // 
            // pnlMySession
            // 
            pnlMySession.Controls.Add(lblWaitlist);
            pnlMySession.Controls.Add(flpWaitlistedSessions);
            pnlMySession.Controls.Add(lblCompleted);
            pnlMySession.Controls.Add(lblOngoing);
            pnlMySession.Controls.Add(lblUpcoming);
            pnlMySession.Controls.Add(lblMySessionsDescription);
            pnlMySession.Controls.Add(lblMySessions);
            pnlMySession.Controls.Add(flpCompletedSessions);
            pnlMySession.Controls.Add(flpOngoingSessions);
            pnlMySession.Controls.Add(flpUpcomingSessions);
            pnlMySession.Location = new Point(0, 0);
            pnlMySession.Name = "pnlMySession";
            pnlMySession.Size = new Size(1415, 644);
            pnlMySession.TabIndex = 24;
            // 
            // lblCompleted
            // 
            lblCompleted.AutoSize = true;
            lblCompleted.Location = new Point(1119, 148);
            lblCompleted.Name = "lblCompleted";
            lblCompleted.Size = new Size(100, 25);
            lblCompleted.TabIndex = 7;
            lblCompleted.Text = "Completed";
            // 
            // lblOngoing
            // 
            lblOngoing.AutoSize = true;
            lblOngoing.Location = new Point(826, 149);
            lblOngoing.Name = "lblOngoing";
            lblOngoing.Size = new Size(83, 25);
            lblOngoing.TabIndex = 6;
            lblOngoing.Text = "Ongoing";
            // 
            // lblUpcoming
            // 
            lblUpcoming.AutoSize = true;
            lblUpcoming.Location = new Point(545, 149);
            lblUpcoming.Name = "lblUpcoming";
            lblUpcoming.Size = new Size(95, 25);
            lblUpcoming.TabIndex = 5;
            lblUpcoming.Text = "Upcoming";
            // 
            // lblMySessionsDescription
            // 
            lblMySessionsDescription.AutoSize = true;
            lblMySessionsDescription.Location = new Point(261, 76);
            lblMySessionsDescription.Name = "lblMySessionsDescription";
            lblMySessionsDescription.Size = new Size(482, 25);
            lblMySessionsDescription.TabIndex = 4;
            lblMySessionsDescription.Text = "Here are your upcoming, ongoing, and completed sessions";
            // 
            // lblMySessions
            // 
            lblMySessions.AutoSize = true;
            lblMySessions.Location = new Point(261, 38);
            lblMySessions.Name = "lblMySessions";
            lblMySessions.Size = new Size(110, 25);
            lblMySessions.TabIndex = 3;
            lblMySessions.Text = "My Sessions";
            // 
            // flpWaitlistedSessions
            // 
            flpWaitlistedSessions.AutoScroll = true;
            flpWaitlistedSessions.FlowDirection = FlowDirection.TopDown;
            flpWaitlistedSessions.Location = new Point(257, 193);
            flpWaitlistedSessions.Name = "flpWaitlistedSessions";
            flpWaitlistedSessions.Size = new Size(265, 426);
            flpWaitlistedSessions.TabIndex = 8;
            flpWaitlistedSessions.WrapContents = false;
            // 
            // lblWaitlist
            // 
            lblWaitlist.AutoSize = true;
            lblWaitlist.Location = new Point(261, 143);
            lblWaitlist.Name = "lblWaitlist";
            lblWaitlist.Size = new Size(69, 25);
            lblWaitlist.TabIndex = 9;
            lblWaitlist.Text = "Waitlist";
            // 
            // StudentDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1413, 644);
            Controls.Add(pnlSidebar);
            Controls.Add(pnlMySession);
            Controls.Add(pnlCreateSession);
            Controls.Add(pnlMyProfile);
            Controls.Add(pnlBrowseSession);
            Controls.Add(pnlNotification);
            Controls.Add(pnlCompletedSessions);
            Controls.Add(pnlWaitlistedSessions);
            Controls.Add(pnlBookedSessions);
            Controls.Add(lblWelcome);
            Controls.Add(lblDashboardTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "StudentDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Dashboard";
            pnlSidebar.ResumeLayout(false);
            pnlBookedSessions.ResumeLayout(false);
            pnlBookedSessions.PerformLayout();
            pnlWaitlistedSessions.ResumeLayout(false);
            pnlWaitlistedSessions.PerformLayout();
            pnlCompletedSessions.ResumeLayout(false);
            pnlCompletedSessions.PerformLayout();
            pnlNotification.ResumeLayout(false);
            pnlNotification.PerformLayout();
            pnlMyProfile.ResumeLayout(false);
            pnlMyProfile.PerformLayout();
            pnlCreateSession.ResumeLayout(false);
            pnlCreateSession.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSlots).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRequiredTutors).EndInit();
            pnlBrowseSession.ResumeLayout(false);
            pnlBrowseSession.PerformLayout();
            pnlMySession.ResumeLayout(false);
            pnlMySession.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlSidebar;
        private Label lblDashboardTitle;
        private Label lblWelcome;
        private Panel pnlBookedSessions;
        private Label lblBookedTitle;
        private Panel pnlWaitlistedSessions;
        private Label lblWaitlistedTitle;
        private Panel pnlCompletedSessions;
        private Label lblCompletedTitle;
        private Panel pnlNotification;
        private Label lblNotificationsTitle;
        private ListBox lstNotifications;
        private Label lblBookedCount;
        private Label lblWaitlistedCount;
        private Label lblCompletedCount;
        private FlowLayoutPanel flpNotifications;
        private Button btnLogout;
        private Button btnBrowseSession;
        private Button btnCreateSession;
        private Button btnMySessions;
        private Button btnMyProfile;
        private Button btnMain;
        private Panel pnlMyProfile;
        private Label lblProfileFullName;
        private Label lblProfileDescription;
        private Label lblProfileTitle;
        private TextBox txtEditYear;
        private TextBox txtEditProgram;
        private TextBox txtEditUEGmail;
        private TextBox txtEditFullName;
        private Label lblProfileYear;
        private Label lblProfileProgram;
        private Label lblProfileUEGmail;
        private Label lblProfileYearValue;
        private Label lblProfileUEGmailValue;
        private Label lblProfileFullNameValue;
        private Button btnEditProfile;
        private Label lblProfileProgramValue;
        private Button btnCancelProfile;
        private Button btnSaveProfile;
        private Panel pnlCreateSession;
        private Label lblSubject;
        private Label lblCreateSessionDescription;
        private Label lblCreateSessionTitle;
        private TextBox txtLocation;
        private TextBox txtTopic;
        private TextBox txtSubject;
        private Label lblLocation;
        private Label lblSlots;
        private Label lblRequiredTutors;
        private Label lblSessionDate;
        private Label lblTopic;
        private Button btnSubmitSession;
        private NumericUpDown numSlots;
        private NumericUpDown numRequiredTutors;
        private DateTimePicker dtpSessionDate;
        private Label lblStartTime;
        private DateTimePicker dtpEndTime;
        private DateTimePicker dtpStartTime;
        private Label lblEndTime;
        private TextBox txtSearchTutor;
        private Label lblSelectedTutors;
        private Label lblSearchTutor;
        private FlowLayoutPanel flpTutorList;
        private Panel pnlBrowseSession;
        private TextBox txtSearchSessions;
        private Label lblSearchSessions;
        private FlowLayoutPanel flpBrowseSessions;
        private FlowLayoutPanel flpUpcomingSessions;
        private FlowLayoutPanel flpOngoingSessions;
        private FlowLayoutPanel flpCompletedSessions;
        private Panel pnlMySession;
        private Label lblMySessions;
        private Label lblCompleted;
        private Label lblOngoing;
        private Label lblUpcoming;
        private Label lblMySessionsDescription;
        private Button btnViewProfile;
        private Button btnSwitchTutorMode;
        private FlowLayoutPanel flpWaitlistedSessions;
        private Label lblWaitlist;
    }
}