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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentDashboard));
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
            btnTutorMode = new Button();
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
            lblWaitlist = new Label();
            flpWaitlistedSessions = new FlowLayoutPanel();
            lblCompleted = new Label();
            lblOngoing = new Label();
            lblUpcoming = new Label();
            lblMySessionsDescription = new Label();
            lblMySessions = new Label();
            pnlMain = new Panel();
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
            pnlMain.SuspendLayout();
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
            pnlSidebar.Margin = new Padding(2);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(230, 805);
            pnlSidebar.TabIndex = 0;
            // 
            // btnSwitchTutorMode
            // 
            btnSwitchTutorMode.Location = new Point(15, 748);
            btnSwitchTutorMode.Margin = new Padding(4);
            btnSwitchTutorMode.Name = "btnSwitchTutorMode";
            btnSwitchTutorMode.Size = new Size(211, 42);
            btnSwitchTutorMode.TabIndex = 8;
            btnSwitchTutorMode.Text = "Switch to Tutor Mode";
            btnSwitchTutorMode.UseVisualStyleBackColor = true;
            btnSwitchTutorMode.Click += btnSwitchTutorMode_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(12, 222);
            btnLogout.Margin = new Padding(2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(204, 34);
            // btnLogout
            // 
            btnLogout.BackgroundImage = (Image)resources.GetObject("btnLogout.BackgroundImage");
            btnLogout.BackgroundImageLayout = ImageLayout.Stretch;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.MediumSlateBlue;
            btnLogout.Location = new Point(9, 310);
            btnLogout.Margin = new Padding(2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(168, 29);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnBrowseSession
            // 
            btnBrowseSession.Location = new Point(12, 182);
            btnBrowseSession.Margin = new Padding(2);
            btnBrowseSession.Name = "btnBrowseSession";
            btnBrowseSession.Size = new Size(204, 34);
            btnBrowseSession.BackgroundImage = (Image)resources.GetObject("btnBrowseSession.BackgroundImage");
            btnBrowseSession.BackgroundImageLayout = ImageLayout.Stretch;
            btnBrowseSession.FlatAppearance.BorderSize = 0;
            btnBrowseSession.FlatStyle = FlatStyle.Flat;
            btnBrowseSession.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBrowseSession.ForeColor = Color.MediumSlateBlue;
            btnBrowseSession.Location = new Point(7, 224);
            btnBrowseSession.Margin = new Padding(2);
            btnBrowseSession.Name = "btnBrowseSession";
            btnBrowseSession.Size = new Size(169, 32);
            btnBrowseSession.TabIndex = 6;
            btnBrowseSession.Text = "Browse Session";
            btnBrowseSession.UseVisualStyleBackColor = true;
            btnBrowseSession.Click += btnBrowseSession_Click;
            // 
            // btnCreateSession
            // 
            btnCreateSession.Location = new Point(12, 142);
            btnCreateSession.Margin = new Padding(2);
            btnCreateSession.Name = "btnCreateSession";
            btnCreateSession.Size = new Size(204, 34);
            btnCreateSession.BackgroundImage = (Image)resources.GetObject("btnCreateSession.BackgroundImage");
            btnCreateSession.BackgroundImageLayout = ImageLayout.Stretch;
            btnCreateSession.FlatAppearance.BorderSize = 0;
            btnCreateSession.FlatStyle = FlatStyle.Flat;
            btnCreateSession.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateSession.ForeColor = Color.MediumSlateBlue;
            btnCreateSession.Location = new Point(12, 178);
            btnCreateSession.Margin = new Padding(2);
            btnCreateSession.Name = "btnCreateSession";
            btnCreateSession.Size = new Size(167, 30);
            btnCreateSession.TabIndex = 5;
            btnCreateSession.Text = "Create Session";
            btnCreateSession.UseVisualStyleBackColor = true;
            btnCreateSession.Click += btnCreateSession_Click;
            // 
            // btnMySessions
            // 
            btnMySessions.Location = new Point(12, 102);
            btnMySessions.Margin = new Padding(2);
            btnMySessions.Name = "btnMySessions";
            btnMySessions.Size = new Size(204, 34);
            btnMySessions.BackgroundImage = (Image)resources.GetObject("btnMySessions.BackgroundImage");
            btnMySessions.BackgroundImageLayout = ImageLayout.Stretch;
            btnMySessions.FlatAppearance.BorderSize = 0;
            btnMySessions.FlatStyle = FlatStyle.Flat;
            btnMySessions.Font = new Font("Arial Narrow", 10F, FontStyle.Bold);
            btnMySessions.ForeColor = Color.MediumSlateBlue;
            btnMySessions.Location = new Point(12, 132);
            btnMySessions.Margin = new Padding(2);
            btnMySessions.Name = "btnMySessions";
            btnMySessions.Size = new Size(166, 32);
            btnMySessions.TabIndex = 4;
            btnMySessions.Text = "My Sessions";
            btnMySessions.UseVisualStyleBackColor = true;
            btnMySessions.Click += btnMySessions_Click;
            // 
            // btnMyProfile
            // 
            btnMyProfile.Location = new Point(12, 62);
            btnMyProfile.Margin = new Padding(2);
            btnMyProfile.Name = "btnMyProfile";
            btnMyProfile.Size = new Size(204, 34);
            btnMyProfile.BackgroundImage = (Image)resources.GetObject("btnMyProfile.BackgroundImage");
            btnMyProfile.BackgroundImageLayout = ImageLayout.Stretch;
            btnMyProfile.FlatAppearance.BorderSize = 0;
            btnMyProfile.FlatStyle = FlatStyle.Flat;
            btnMyProfile.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMyProfile.ForeColor = Color.MediumSlateBlue;
            btnMyProfile.Location = new Point(14, 85);
            btnMyProfile.Margin = new Padding(2);
            btnMyProfile.Name = "btnMyProfile";
            btnMyProfile.Size = new Size(165, 32);
            btnMyProfile.TabIndex = 3;
            btnMyProfile.Text = "My Profile";
            btnMyProfile.UseVisualStyleBackColor = true;
            btnMyProfile.Click += btnMyProfile_Click;
            // 
            // btnMain
            // 
            btnMain.Location = new Point(12, 22);
            btnMain.Margin = new Padding(2);
            btnMain.Name = "btnMain";
            btnMain.Size = new Size(204, 34);
            btnMain.BackColor = SystemColors.ControlLightLight;
            btnMain.BackgroundImage = (Image)resources.GetObject("btnMain.BackgroundImage");
            btnMain.BackgroundImageLayout = ImageLayout.Stretch;
            btnMain.FlatAppearance.BorderSize = 0;
            btnMain.FlatStyle = FlatStyle.Flat;
            btnMain.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMain.ForeColor = Color.MediumSlateBlue;
            btnMain.Location = new Point(14, 39);
            btnMain.Margin = new Padding(2);
            btnMain.Name = "btnMain";
            btnMain.Size = new Size(165, 32);
            btnMain.TabIndex = 2;
            btnMain.Text = "Main";
            btnMain.UseVisualStyleBackColor = false;
            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.AutoSize = true;
            lblDashboardTitle.Location = new Point(258, 22);
            lblDashboardTitle.Margin = new Padding(2, 0, 2, 0);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(166, 25);
            lblDashboardTitle.TabIndex = 1;
            lblDashboardTitle.Text = "Student Dashboard";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(0, 0);
            lblWelcome.Margin = new Padding(2, 0, 2, 0);
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
            pnlBookedSessions.Location = new Point(355, 115);
            pnlBookedSessions.Location = new Point(206, 103);
            pnlBookedSessions.Margin = new Padding(2);
            pnlBookedSessions.Name = "pnlBookedSessions";
            pnlBookedSessions.Size = new Size(363, 150);
            pnlBookedSessions.TabIndex = 3;
            // 
            // lblBookedCount
            // 
            lblBookedCount.AutoSize = true;
            lblBookedCount.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBookedCount.Location = new Point(32, 72);
            lblBookedCount.Margin = new Padding(2, 0, 2, 0);
            lblBookedCount.Name = "lblBookedCount";
            lblBookedCount.Size = new Size(41, 48);
            lblBookedCount.TabIndex = 4;
            lblBookedCount.Text = "0";
            // 
            // lblBookedTitle
            // 
            lblBookedTitle.AutoSize = true;
            lblBookedTitle.Location = new Point(32, 22);
            lblBookedTitle.Margin = new Padding(2, 0, 2, 0);
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
            pnlWaitlistedSessions.Location = new Point(355, 307);
            pnlWaitlistedSessions.Location = new Point(206, 240);
            pnlWaitlistedSessions.Margin = new Padding(2);
            pnlWaitlistedSessions.Name = "pnlWaitlistedSessions";
            pnlWaitlistedSessions.Size = new Size(363, 150);
            pnlWaitlistedSessions.TabIndex = 4;
            // 
            // lblWaitlistedCount
            // 
            lblWaitlistedCount.AutoSize = true;
            lblWaitlistedCount.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWaitlistedCount.Location = new Point(32, 69);
            lblWaitlistedCount.Margin = new Padding(2, 0, 2, 0);
            lblWaitlistedCount.Name = "lblWaitlistedCount";
            lblWaitlistedCount.Size = new Size(41, 48);
            lblWaitlistedCount.TabIndex = 5;
            lblWaitlistedCount.Text = "0";
            // 
            // lblWaitlistedTitle
            // 
            lblWaitlistedTitle.AutoSize = true;
            lblWaitlistedTitle.Location = new Point(32, 25);
            lblWaitlistedTitle.Margin = new Padding(2, 0, 2, 0);
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
            pnlCompletedSessions.Location = new Point(355, 504);
            pnlCompletedSessions.Location = new Point(206, 375);
            pnlCompletedSessions.Margin = new Padding(2);
            pnlCompletedSessions.Name = "pnlCompletedSessions";
            pnlCompletedSessions.Size = new Size(363, 150);
            pnlCompletedSessions.TabIndex = 5;
            // 
            // lblCompletedCount
            // 
            lblCompletedCount.AutoSize = true;
            lblCompletedCount.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompletedCount.Location = new Point(32, 72);
            lblCompletedCount.Margin = new Padding(2, 0, 2, 0);
            lblCompletedCount.Name = "lblCompletedCount";
            lblCompletedCount.Size = new Size(41, 48);
            lblCompletedCount.TabIndex = 6;
            lblCompletedCount.Text = "0";
            // 
            // lblCompletedTitle
            // 
            lblCompletedTitle.AutoSize = true;
            lblCompletedTitle.Location = new Point(32, 22);
            lblCompletedTitle.Margin = new Padding(2, 0, 2, 0);
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
            pnlNotification.Location = new Point(1201, 164);
            pnlNotification.Location = new Point(517, 103);
            pnlNotification.Margin = new Padding(2);
            pnlNotification.Name = "pnlNotification";
            pnlNotification.Size = new Size(503, 490);
            pnlNotification.TabIndex = 6;
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
            flpNotifications.Location = new Point(26, 57);
            flpNotifications.Margin = new Padding(2);
            flpNotifications.Name = "flpNotifications";
            flpNotifications.Size = new Size(432, 390);
            flpNotifications.TabIndex = 4;
            flpNotifications.WrapContents = false;
            // 
            // pnlMyProfile
            // 
            pnlMyProfile.Controls.Add(btnViewProfile);
            pnlMyProfile.BackgroundImage = (Image)resources.GetObject("pnlMyProfile.BackgroundImage");
            pnlMyProfile.BackgroundImageLayout = ImageLayout.Stretch;
            pnlMyProfile.BorderStyle = BorderStyle.Fixed3D;
            pnlMyProfile.Controls.Add(btnTutorMode);
            pnlMyProfile.Controls.Add(btnLogout);
            pnlMyProfile.Controls.Add(btnCancelProfile);
            pnlMyProfile.Controls.Add(btnBrowseSession);
            pnlMyProfile.Controls.Add(btnSaveProfile);
            pnlMyProfile.Controls.Add(btnCreateSession);
            pnlMyProfile.Controls.Add(lblProfileProgramValue);
            pnlMyProfile.Controls.Add(btnMySessions);
            pnlMyProfile.Controls.Add(lblProfileYearValue);
            pnlMyProfile.Controls.Add(btnMyProfile);
            pnlMyProfile.Controls.Add(lblProfileUEGmailValue);
            pnlMyProfile.Controls.Add(btnMain);
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
            pnlMyProfile.Location = new Point(1, 0);
            pnlMyProfile.Margin = new Padding(2);
            pnlMyProfile.Name = "pnlMyProfile";
            pnlMyProfile.Size = new Size(1769, 805);
            pnlMyProfile.TabIndex = 7;
            pnlMyProfile.Visible = false;
            // 
            // btnViewProfile
            // 
            btnViewProfile.Location = new Point(1214, 564);
            btnViewProfile.Margin = new Padding(4);
            btnViewProfile.Name = "btnViewProfile";
            btnViewProfile.Size = new Size(164, 42);
            btnViewProfile.TabIndex = 17;
            btnViewProfile.Text = "View Profile";
            btnViewProfile.UseVisualStyleBackColor = true;
            btnViewProfile.Click += btnViewProfile_Click;
            // 
            // btnCancelProfile
            // 
            btnCancelProfile.Location = new Point(971, 505);
            btnCancelProfile.Margin = new Padding(2);
            btnCancelProfile.Name = "btnCancelProfile";
            btnCancelProfile.Size = new Size(131, 34);
            // btnTutorMode
            // 
            btnTutorMode.BackgroundImage = (Image)resources.GetObject("btnTutorMode.BackgroundImage");
            btnTutorMode.BackgroundImageLayout = ImageLayout.Stretch;
            btnTutorMode.FlatAppearance.BorderSize = 0;
            btnTutorMode.FlatStyle = FlatStyle.Flat;
            btnTutorMode.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTutorMode.ForeColor = Color.MediumSlateBlue;
            btnTutorMode.Location = new Point(8, 268);
            btnTutorMode.Margin = new Padding(2);
            btnTutorMode.Name = "btnTutorMode";
            btnTutorMode.Size = new Size(168, 29);
            btnTutorMode.TabIndex = 17;
            btnTutorMode.Text = "Tutor Mode";
            btnTutorMode.UseVisualStyleBackColor = true;
            // 
            // btnCancelProfile
            // 
            btnCancelProfile.BackgroundImage = (Image)resources.GetObject("btnCancelProfile.BackgroundImage");
            btnCancelProfile.BackgroundImageLayout = ImageLayout.Stretch;
            btnCancelProfile.FlatAppearance.BorderSize = 0;
            btnCancelProfile.FlatStyle = FlatStyle.Flat;
            btnCancelProfile.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelProfile.ForeColor = Color.Lavender;
            btnCancelProfile.Location = new Point(471, 412);
            btnCancelProfile.Margin = new Padding(2);
            btnCancelProfile.Name = "btnCancelProfile";
            btnCancelProfile.Size = new Size(145, 31);
            btnCancelProfile.TabIndex = 16;
            btnCancelProfile.Text = "Cancel";
            btnCancelProfile.UseVisualStyleBackColor = true;
            btnCancelProfile.Visible = false;
            btnCancelProfile.Click += btnCancelProfile_Click;
            // 
            // btnSaveProfile
            // 
            btnSaveProfile.Location = new Point(815, 505);
            btnSaveProfile.Margin = new Padding(2);
            btnSaveProfile.Name = "btnSaveProfile";
            btnSaveProfile.Size = new Size(131, 34);
            btnSaveProfile.BackgroundImage = (Image)resources.GetObject("btnSaveProfile.BackgroundImage");
            btnSaveProfile.BackgroundImageLayout = ImageLayout.Stretch;
            btnSaveProfile.FlatAppearance.BorderSize = 0;
            btnSaveProfile.FlatStyle = FlatStyle.Flat;
            btnSaveProfile.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveProfile.ForeColor = Color.Lavender;
            btnSaveProfile.Location = new Point(287, 410);
            btnSaveProfile.Margin = new Padding(2);
            btnSaveProfile.Name = "btnSaveProfile";
            btnSaveProfile.Size = new Size(145, 34);
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
            lblProfileProgramValue.Margin = new Padding(2, 0, 2, 0);
            lblProfileProgramValue.Name = "lblProfileProgramValue";
            lblProfileProgramValue.Size = new Size(81, 25);
            lblProfileProgramValue.Font = new Font("Arial Narrow", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProfileProgramValue.ForeColor = Color.DarkSlateBlue;
            lblProfileProgramValue.Location = new Point(327, 256);
            lblProfileProgramValue.Margin = new Padding(2, 0, 2, 0);
            lblProfileProgramValue.Name = "lblProfileProgramValue";
            lblProfileProgramValue.Size = new Size(61, 20);
            lblProfileProgramValue.TabIndex = 14;
            lblProfileProgramValue.Text = "Program";
            // 
            // lblProfileYearValue
            // 
            lblProfileYearValue.AutoSize = true;
            lblProfileYearValue.Location = new Point(409, 272);
            lblProfileYearValue.Margin = new Padding(2, 0, 2, 0);
            lblProfileYearValue.Name = "lblProfileYearValue";
            lblProfileYearValue.Size = new Size(44, 25);
            lblProfileYearValue.Font = new Font("Arial Narrow", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProfileYearValue.ForeColor = Color.DarkSlateBlue;
            lblProfileYearValue.Location = new Point(327, 218);
            lblProfileYearValue.Margin = new Padding(2, 0, 2, 0);
            lblProfileYearValue.Name = "lblProfileYearValue";
            lblProfileYearValue.Size = new Size(36, 20);
            lblProfileYearValue.TabIndex = 13;
            lblProfileYearValue.Text = "Year";
            // 
            // lblProfileUEGmailValue
            // 
            lblProfileUEGmailValue.AutoSize = true;
            lblProfileUEGmailValue.Location = new Point(402, 222);
            lblProfileUEGmailValue.Margin = new Padding(2, 0, 2, 0);
            lblProfileUEGmailValue.Name = "lblProfileUEGmailValue";
            lblProfileUEGmailValue.Size = new Size(83, 25);
            lblProfileUEGmailValue.Font = new Font("Arial Narrow", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProfileUEGmailValue.ForeColor = Color.DarkSlateBlue;
            lblProfileUEGmailValue.Location = new Point(322, 178);
            lblProfileUEGmailValue.Margin = new Padding(2, 0, 2, 0);
            lblProfileUEGmailValue.Name = "lblProfileUEGmailValue";
            lblProfileUEGmailValue.Size = new Size(65, 20);
            lblProfileUEGmailValue.TabIndex = 12;
            lblProfileUEGmailValue.Text = "UE Gmail";
            // 
            // lblProfileFullNameValue
            // 
            lblProfileFullNameValue.AutoSize = true;
            lblProfileFullNameValue.Location = new Point(402, 178);
            lblProfileFullNameValue.Margin = new Padding(2, 0, 2, 0);
            lblProfileFullNameValue.Name = "lblProfileFullNameValue";
            lblProfileFullNameValue.Size = new Size(91, 25);
            lblProfileFullNameValue.BackColor = SystemColors.Control;
            lblProfileFullNameValue.Font = new Font("Arial Narrow", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProfileFullNameValue.ForeColor = Color.DarkSlateBlue;
            lblProfileFullNameValue.Location = new Point(324, 144);
            lblProfileFullNameValue.Margin = new Padding(2, 0, 2, 0);
            lblProfileFullNameValue.Name = "lblProfileFullNameValue";
            lblProfileFullNameValue.Size = new Size(70, 20);
            lblProfileFullNameValue.TabIndex = 11;
            lblProfileFullNameValue.Text = "Full Name";
            // 
            // btnEditProfile
            // 
            btnEditProfile.Location = new Point(1019, 564);
            btnEditProfile.Margin = new Padding(4);
            btnEditProfile.Name = "btnEditProfile";
            btnEditProfile.Size = new Size(131, 34);
            btnEditProfile.BackgroundImage = (Image)resources.GetObject("btnEditProfile.BackgroundImage");
            btnEditProfile.BackgroundImageLayout = ImageLayout.Stretch;
            btnEditProfile.FlatAppearance.BorderSize = 0;
            btnEditProfile.FlatStyle = FlatStyle.Flat;
            btnEditProfile.Font = new Font("Arial Narrow", 10F, FontStyle.Bold);
            btnEditProfile.ForeColor = Color.Lavender;
            btnEditProfile.Location = new Point(376, 347);
            btnEditProfile.Margin = new Padding(2);
            btnEditProfile.Name = "btnEditProfile";
            btnEditProfile.Size = new Size(145, 37);
            btnEditProfile.TabIndex = 10;
            btnEditProfile.Text = "Edit profile";
            btnEditProfile.UseVisualStyleBackColor = true;
            btnEditProfile.Click += btnEditProfile_Click;
            // 
            // txtEditFullName
            // 
            txtEditFullName.Location = new Point(402, 178);
            txtEditFullName.BackColor = Color.White;
            txtEditFullName.ForeColor = Color.Lavender;
            txtEditFullName.Location = new Point(322, 142);
            txtEditFullName.Margin = new Padding(2);
            txtEditFullName.Name = "txtEditFullName";
            txtEditFullName.Size = new Size(444, 31);
            txtEditFullName.TabIndex = 9;
            txtEditFullName.Visible = false;
            // 
            // txtEditProgram
            // 
            txtEditProgram.Location = new Point(402, 320);
            txtEditProgram.ForeColor = Color.Lavender;
            txtEditProgram.Location = new Point(322, 256);
            txtEditProgram.Margin = new Padding(2);
            txtEditProgram.Name = "txtEditProgram";
            txtEditProgram.Size = new Size(444, 31);
            txtEditProgram.TabIndex = 8;
            txtEditProgram.Visible = false;
            // 
            // txtEditUEGmail
            // 
            txtEditUEGmail.Location = new Point(402, 220);
            txtEditUEGmail.ForeColor = Color.Lavender;
            txtEditUEGmail.Location = new Point(322, 176);
            txtEditUEGmail.Margin = new Padding(2);
            txtEditUEGmail.Name = "txtEditUEGmail";
            txtEditUEGmail.Size = new Size(444, 31);
            txtEditUEGmail.TabIndex = 7;
            txtEditUEGmail.Visible = false;
            // 
            // txtEditYear
            // 
            txtEditYear.Location = new Point(402, 272);
            txtEditYear.ForeColor = Color.Lavender;
            txtEditYear.Location = new Point(322, 218);
            txtEditYear.Margin = new Padding(2);
            txtEditYear.Name = "txtEditYear";
            txtEditYear.Size = new Size(444, 31);
            txtEditYear.TabIndex = 6;
            txtEditYear.Visible = false;
            // 
            // lblProfileYear
            // 
            lblProfileYear.AutoSize = true;
            lblProfileYear.Location = new Point(291, 272);
            lblProfileYear.BackColor = Color.Transparent;
            lblProfileYear.Font = new Font("Arial Narrow", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProfileYear.ForeColor = Color.Lavender;
            lblProfileYear.Location = new Point(233, 218);
            lblProfileYear.Margin = new Padding(2, 0, 2, 0);
            lblProfileYear.Name = "lblProfileYear";
            lblProfileYear.Size = new Size(48, 25);
            lblProfileYear.TabIndex = 5;
            lblProfileYear.Text = "Year:";
            // 
            // lblProfileProgram
            // 
            lblProfileProgram.AutoSize = true;
            lblProfileProgram.Location = new Point(291, 320);
            lblProfileProgram.Margin = new Padding(2, 0, 2, 0);
            lblProfileProgram.Name = "lblProfileProgram";
            lblProfileProgram.Size = new Size(85, 25);
            lblProfileProgram.BackColor = Color.Transparent;
            lblProfileProgram.Font = new Font("Arial Narrow", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProfileProgram.ForeColor = Color.Lavender;
            lblProfileProgram.Location = new Point(233, 256);
            lblProfileProgram.Margin = new Padding(2, 0, 2, 0);
            lblProfileProgram.Name = "lblProfileProgram";
            lblProfileProgram.Size = new Size(65, 20);
            lblProfileProgram.TabIndex = 4;
            lblProfileProgram.Text = "Program:";
            // 
            // lblProfileUEGmail
            // 
            lblProfileUEGmail.AutoSize = true;
            lblProfileUEGmail.Location = new Point(291, 221);
            lblProfileUEGmail.Margin = new Padding(2, 0, 2, 0);
            lblProfileUEGmail.Name = "lblProfileUEGmail";
            lblProfileUEGmail.Size = new Size(87, 25);
            lblProfileUEGmail.BackColor = Color.Transparent;
            lblProfileUEGmail.Font = new Font("Arial Narrow", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProfileUEGmail.ForeColor = Color.Lavender;
            lblProfileUEGmail.Location = new Point(233, 177);
            lblProfileUEGmail.Margin = new Padding(2, 0, 2, 0);
            lblProfileUEGmail.Name = "lblProfileUEGmail";
            lblProfileUEGmail.Size = new Size(69, 20);
            lblProfileUEGmail.TabIndex = 3;
            lblProfileUEGmail.Text = "UE Gmail:";
            // 
            // lblProfileFullName
            // 
            lblProfileFullName.AutoSize = true;
            lblProfileFullName.Location = new Point(291, 178);
            lblProfileFullName.Margin = new Padding(2, 0, 2, 0);
            lblProfileFullName.Name = "lblProfileFullName";
            lblProfileFullName.Size = new Size(95, 25);
            lblProfileFullName.BackColor = Color.Transparent;
            lblProfileFullName.Font = new Font("Arial Narrow", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProfileFullName.ForeColor = Color.Lavender;
            lblProfileFullName.Location = new Point(233, 142);
            lblProfileFullName.Margin = new Padding(2, 0, 2, 0);
            lblProfileFullName.Name = "lblProfileFullName";
            lblProfileFullName.Size = new Size(74, 20);
            lblProfileFullName.TabIndex = 2;
            lblProfileFullName.Text = "Full Name:";
            // 
            // lblProfileDescription
            // 
            lblProfileDescription.AutoSize = true;
            lblProfileDescription.Location = new Point(272, 88);
            lblProfileDescription.Margin = new Padding(2, 0, 2, 0);
            lblProfileDescription.Name = "lblProfileDescription";
            lblProfileDescription.Size = new Size(369, 25);
            lblProfileDescription.BackColor = Color.Transparent;
            lblProfileDescription.Font = new Font("Arial Narrow", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProfileDescription.ForeColor = Color.Lavender;
            lblProfileDescription.Location = new Point(218, 70);
            lblProfileDescription.Margin = new Padding(2, 0, 2, 0);
            lblProfileDescription.Name = "lblProfileDescription";
            lblProfileDescription.Size = new Size(278, 20);
            lblProfileDescription.TabIndex = 1;
            lblProfileDescription.Text = "View and manage your personal information.";
            // 
            // lblProfileTitle
            // 
            lblProfileTitle.AutoSize = true;
            lblProfileTitle.Location = new Point(272, 38);
            lblProfileTitle.Margin = new Padding(2, 0, 2, 0);
            lblProfileTitle.Name = "lblProfileTitle";
            lblProfileTitle.Size = new Size(92, 25);
            lblProfileTitle.BackColor = Color.Transparent;
            lblProfileTitle.FlatStyle = FlatStyle.Flat;
            lblProfileTitle.Font = new Font("Arial Narrow", 15.7F, FontStyle.Bold);
            lblProfileTitle.ForeColor = Color.Lavender;
            lblProfileTitle.Location = new Point(218, 30);
            lblProfileTitle.Margin = new Padding(2, 0, 2, 0);
            lblProfileTitle.Name = "lblProfileTitle";
            lblProfileTitle.Size = new Size(119, 31);
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
            pnlCreateSession.Margin = new Padding(2);
            pnlCreateSession.Name = "pnlCreateSession";
            pnlCreateSession.Size = new Size(1765, 805);
            pnlCreateSession.TabIndex = 17;
            pnlCreateSession.Visible = false;
            // 
            // txtSearchTutor
            // 
            txtSearchTutor.Location = new Point(872, 138);
            txtSearchTutor.Location = new Point(698, 110);
            txtSearchTutor.Margin = new Padding(2);
            txtSearchTutor.Name = "txtSearchTutor";
            txtSearchTutor.Size = new Size(260, 31);
            txtSearchTutor.TabIndex = 23;
            txtSearchTutor.TextChanged += txtSearchTutor_TextChanged;
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
            flpTutorList.Location = new Point(601, 146);
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
            dtpEndTime.Location = new Point(327, 307);
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
            dtpStartTime.Location = new Point(327, 274);
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
            dtpSessionDate.Location = new Point(327, 240);
            dtpSessionDate.Margin = new Padding(2);
            dtpSessionDate.Name = "dtpSessionDate";
            dtpSessionDate.Size = new Size(265, 31);
            dtpSessionDate.TabIndex = 15;
            dtpSessionDate.ValueChanged += dtpSessionDate_ValueChanged;
            // 
            // btnSubmitSession
            // 
            btnSubmitSession.Location = new Point(944, 568);
            btnSubmitSession.Location = new Point(755, 454);
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
            numSlots.Location = new Point(395, 390);
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
            numRequiredTutors.Location = new Point(395, 346);
            numRequiredTutors.Margin = new Padding(2);
            numRequiredTutors.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numRequiredTutors.Name = "numRequiredTutors";
            numRequiredTutors.Size = new Size(180, 31);
            numRequiredTutors.TabIndex = 12;
            numRequiredTutors.ValueChanged += numRequiredTutors_ValueChanged;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(494, 528);
            txtLocation.Location = new Point(395, 422);
            txtLocation.Margin = new Padding(2);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(180, 31);
            txtLocation.TabIndex = 10;
            // 
            // txtTopic
            // 
            txtTopic.Location = new Point(425, 248);
            txtTopic.Location = new Point(340, 198);
            txtTopic.Margin = new Padding(2);
            txtTopic.Name = "txtTopic";
            txtTopic.Size = new Size(249, 31);
            txtTopic.TabIndex = 9;
            // 
            // txtSubject
            // 
            txtSubject.Location = new Point(425, 192);
            txtSubject.Location = new Point(340, 154);
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
            // lblTopic
            // 
            lblTopic.AutoSize = true;
            lblTopic.Location = new Point(322, 246);
            lblTopic.Margin = new Padding(2, 0, 2, 0);
            lblTopic.Name = "lblTopic";
            lblTopic.Size = new Size(57, 25);
            lblTopic.TabIndex = 3;
            lblTopic.Text = "Topic:";
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Location = new Point(322, 196);
            lblSubject.Margin = new Padding(2, 0, 2, 0);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(74, 25);
            lblSubject.TabIndex = 2;
            lblSubject.Text = "Subject:";
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
            // pnlBrowseSession
            // 
            pnlBrowseSession.Controls.Add(txtSearchSessions);
            pnlBrowseSession.Controls.Add(lblSearchSessions);
            pnlBrowseSession.Controls.Add(flpBrowseSessions);
            pnlBrowseSession.Location = new Point(0, 0);
            pnlBrowseSession.Margin = new Padding(2);
            pnlBrowseSession.Name = "pnlBrowseSession";
            pnlBrowseSession.Size = new Size(1178, 644);
            pnlBrowseSession.TabIndex = 17;
            // 
            // txtSearchSessions
            // 
            txtSearchSessions.Location = new Point(409, 48);
            txtSearchSessions.Location = new Point(327, 38);
            txtSearchSessions.Margin = new Padding(2);
            txtSearchSessions.Name = "txtSearchSessions";
            txtSearchSessions.Size = new Size(736, 31);
            txtSearchSessions.TabIndex = 2;
            txtSearchSessions.TextChanged += txtSearchSessions_TextChanged_1;
            // 
            // lblSearchSessions
            // 
            lblSearchSessions.AutoSize = true;
            lblSearchSessions.Location = new Point(258, 51);
            lblSearchSessions.Margin = new Padding(2, 0, 2, 0);
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
            flpBrowseSessions.Margin = new Padding(2);
            flpBrowseSessions.Name = "flpBrowseSessions";
            flpBrowseSessions.Padding = new Padding(10);
            flpBrowseSessions.Size = new Size(884, 518);
            flpBrowseSessions.Location = new Point(209, 78);
            flpBrowseSessions.Margin = new Padding(2);
            flpBrowseSessions.Name = "flpBrowseSessions";
            flpBrowseSessions.Padding = new Padding(8);
            flpBrowseSessions.Size = new Size(707, 414);
            flpBrowseSessions.TabIndex = 0;
            flpBrowseSessions.WrapContents = false;
            // 
            // flpUpcomingSessions
            // 
            flpUpcomingSessions.AutoScroll = true;
            flpUpcomingSessions.FlowDirection = FlowDirection.TopDown;
            flpUpcomingSessions.Location = new Point(680, 241);
            flpUpcomingSessions.Margin = new Padding(4);
            flpUpcomingSessions.Name = "flpUpcomingSessions";
            flpUpcomingSessions.Size = new Size(331, 532);
            flpUpcomingSessions.TabIndex = 0;
            flpUpcomingSessions.WrapContents = false;
            // 
            // flpOngoingSessions
            // 
            flpOngoingSessions.AutoScroll = true;
            flpOngoingSessions.FlowDirection = FlowDirection.TopDown;
            flpOngoingSessions.Location = new Point(1032, 241);
            flpOngoingSessions.Margin = new Padding(4);
            flpOngoingSessions.Name = "flpOngoingSessions";
            flpOngoingSessions.Size = new Size(345, 532);
            flpOngoingSessions.TabIndex = 1;
            flpOngoingSessions.WrapContents = false;
            // 
            // flpCompletedSessions
            // 
            flpCompletedSessions.AutoScroll = true;
            flpCompletedSessions.FlowDirection = FlowDirection.TopDown;
            flpCompletedSessions.Location = new Point(1399, 236);
            flpCompletedSessions.Margin = new Padding(4);
            flpCompletedSessions.Name = "flpCompletedSessions";
            flpCompletedSessions.Size = new Size(336, 532);
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
            pnlMySession.Margin = new Padding(4);
            pnlMySession.Name = "pnlMySession";
            pnlMySession.Size = new Size(1769, 805);
            pnlMySession.TabIndex = 24;
            // 
            // lblWaitlist
            // 
            lblWaitlist.AutoSize = true;
            lblWaitlist.Location = new Point(326, 179);
            lblWaitlist.Margin = new Padding(4, 0, 4, 0);
            lblWaitlist.Name = "lblWaitlist";
            lblWaitlist.Size = new Size(69, 25);
            lblWaitlist.TabIndex = 9;
            lblWaitlist.Text = "Waitlist";
            // 
            // flpWaitlistedSessions
            // 
            flpWaitlistedSessions.AutoScroll = true;
            flpWaitlistedSessions.FlowDirection = FlowDirection.TopDown;
            flpWaitlistedSessions.Location = new Point(321, 241);
            flpWaitlistedSessions.Margin = new Padding(4);
            flpWaitlistedSessions.Name = "flpWaitlistedSessions";
            flpWaitlistedSessions.Size = new Size(331, 532);
            flpWaitlistedSessions.TabIndex = 8;
            flpWaitlistedSessions.WrapContents = false;
            // 
            // lblCompleted
            // 
            lblCompleted.AutoSize = true;
            lblCompleted.Location = new Point(1399, 185);
            lblCompleted.Margin = new Padding(4, 0, 4, 0);
            lblCompleted.Name = "lblCompleted";
            lblCompleted.Size = new Size(100, 25);
            lblCompleted.TabIndex = 7;
            lblCompleted.Text = "Completed";
            // 
            // lblOngoing
            // 
            lblOngoing.AutoSize = true;
            lblOngoing.Location = new Point(1032, 186);
            lblOngoing.Margin = new Padding(4, 0, 4, 0);
            lblOngoing.Name = "lblOngoing";
            lblOngoing.Size = new Size(83, 25);
            lblOngoing.TabIndex = 6;
            lblOngoing.Text = "Ongoing";
            // 
            // lblUpcoming
            // 
            lblUpcoming.AutoSize = true;
            lblUpcoming.Location = new Point(681, 186);
            lblUpcoming.Margin = new Padding(4, 0, 4, 0);
            lblUpcoming.Name = "lblUpcoming";
            lblUpcoming.Size = new Size(95, 25);
            lblUpcoming.TabIndex = 5;
            lblUpcoming.Text = "Upcoming";
            // 
            // lblMySessionsDescription
            // 
            lblMySessionsDescription.AutoSize = true;
            lblMySessionsDescription.Location = new Point(326, 95);
            lblMySessionsDescription.Margin = new Padding(4, 0, 4, 0);
            lblMySessionsDescription.Name = "lblMySessionsDescription";
            lblMySessionsDescription.Size = new Size(482, 25);
            lblMySessionsDescription.TabIndex = 4;
            lblMySessionsDescription.Text = "Here are your upcoming, ongoing, and completed sessions";
            // 
            // lblMySessions
            // 
            lblMySessions.AutoSize = true;
            lblMySessions.Location = new Point(326, 48);
            lblMySessions.Margin = new Padding(4, 0, 4, 0);
            lblMySessions.Name = "lblMySessions";
            lblMySessions.Size = new Size(110, 25);
            lblMySessions.TabIndex = 3;
            lblMySessions.Text = "My Sessions";
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(lblWelcome);
            pnlMain.Controls.Add(lblDashboardTitle);
            pnlMain.Controls.Add(pnlWaitlistedSessions);
            pnlMain.Controls.Add(pnlBookedSessions);
            pnlMain.Controls.Add(pnlCompletedSessions);
            pnlMain.Controls.Add(pnlNotification);
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1769, 805);
            pnlMain.TabIndex = 18;
            // 
            // StudentDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1766, 805);
            Controls.Add(pnlSidebar);
            Controls.Add(pnlMain);
            Controls.Add(pnlMyProfile);
            Controls.Add(pnlCreateSession);
            Controls.Add(pnlMySession);
            Controls.Add(pnlBrowseSession);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ClientSize = new Size(942, 515);
            Controls.Add(pnlMyProfile);
            Controls.Add(pnlCreateSession);
            Controls.Add(pnlBookedSessions);
            Controls.Add(pnlNotification);
            Controls.Add(pnlBrowseSession);
            Controls.Add(pnlCompletedSessions);
            Controls.Add(pnlWaitlistedSessions);
            Controls.Add(lblWelcome);
            Controls.Add(lblDashboardTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "StudentDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Dashboard";
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
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
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
        private Panel pnlMain;
        private Button btnTutorMode;
    }
}