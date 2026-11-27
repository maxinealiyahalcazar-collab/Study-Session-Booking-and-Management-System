namespace Study_Session
{
    partial class BookingForm
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
            lblRequiredTutors = new Label();
            lblAssignedTutors = new Label();
            flpSessionTutors = new FlowLayoutPanel();
            lblExpectations = new Label();
            txtExpectations = new TextBox();
            lblPayment = new Label();
            lblSessionFee = new Label();
            lblFeeAmount = new Label();
            lblPaymentMethod = new Label();
            cmbPaymentMethod = new ComboBox();
            label1 = new Label();
            txtPaymentAccount = new TextBox();
            btnSubmitPayment = new Button();
            btnCompleteBooking = new Button();
            SuspendLayout();
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Location = new Point(51, 60);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(70, 25);
            lblSubject.TabIndex = 0;
            lblSubject.Text = "Subject";
            // 
            // lblTopic
            // 
            lblTopic.AutoSize = true;
            lblTopic.Location = new Point(51, 98);
            lblTopic.Name = "lblTopic";
            lblTopic.Size = new Size(53, 25);
            lblTopic.TabIndex = 1;
            lblTopic.Text = "Topic";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(51, 138);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(49, 25);
            lblDate.TabIndex = 2;
            lblDate.Text = "Date";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(53, 176);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(50, 25);
            lblTime.TabIndex = 3;
            lblTime.Text = "Time";
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(53, 201);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(79, 25);
            lblLocation.TabIndex = 4;
            lblLocation.Text = "Location";
            // 
            // lblSlots
            // 
            lblSlots.AutoSize = true;
            lblSlots.Location = new Point(53, 243);
            lblSlots.Name = "lblSlots";
            lblSlots.Size = new Size(51, 25);
            lblSlots.TabIndex = 5;
            lblSlots.Text = "Slots";
            // 
            // lblRequiredTutors
            // 
            lblRequiredTutors.AutoSize = true;
            lblRequiredTutors.Location = new Point(54, 283);
            lblRequiredTutors.Name = "lblRequiredTutors";
            lblRequiredTutors.Size = new Size(137, 25);
            lblRequiredTutors.TabIndex = 6;
            lblRequiredTutors.Text = "Required Tutors";
            // 
            // lblAssignedTutors
            // 
            lblAssignedTutors.AutoSize = true;
            lblAssignedTutors.Location = new Point(54, 322);
            lblAssignedTutors.Name = "lblAssignedTutors";
            lblAssignedTutors.Size = new Size(140, 25);
            lblAssignedTutors.TabIndex = 7;
            lblAssignedTutors.Text = "Assigned Tutors";
            // 
            // flpSessionTutors
            // 
            flpSessionTutors.AutoScroll = true;
            flpSessionTutors.FlowDirection = FlowDirection.TopDown;
            flpSessionTutors.Location = new Point(54, 360);
            flpSessionTutors.Name = "flpSessionTutors";
            flpSessionTutors.Size = new Size(442, 120);
            flpSessionTutors.TabIndex = 8;
            flpSessionTutors.WrapContents = false;
            // 
            // lblExpectations
            // 
            lblExpectations.AutoSize = true;
            lblExpectations.Location = new Point(591, 60);
            lblExpectations.Name = "lblExpectations";
            lblExpectations.Size = new Size(111, 25);
            lblExpectations.TabIndex = 9;
            lblExpectations.Text = "Expectations";
            // 
            // txtExpectations
            // 
            txtExpectations.Location = new Point(591, 98);
            txtExpectations.MaxLength = 300;
            txtExpectations.Multiline = true;
            txtExpectations.Name = "txtExpectations";
            txtExpectations.ScrollBars = ScrollBars.Vertical;
            txtExpectations.Size = new Size(402, 188);
            txtExpectations.TabIndex = 10;
            // 
            // lblPayment
            // 
            lblPayment.AutoSize = true;
            lblPayment.Location = new Point(591, 322);
            lblPayment.Name = "lblPayment";
            lblPayment.Size = new Size(138, 25);
            lblPayment.TabIndex = 11;
            lblPayment.Text = "Payment Details";
            // 
            // lblSessionFee
            // 
            lblSessionFee.AutoSize = true;
            lblSessionFee.Location = new Point(591, 360);
            lblSessionFee.Name = "lblSessionFee";
            lblSessionFee.Size = new Size(104, 25);
            lblSessionFee.TabIndex = 12;
            lblSessionFee.Text = "Session Fee";
            // 
            // lblFeeAmount
            // 
            lblFeeAmount.AutoSize = true;
            lblFeeAmount.Location = new Point(713, 360);
            lblFeeAmount.Name = "lblFeeAmount";
            lblFeeAmount.Size = new Size(42, 25);
            lblFeeAmount.TabIndex = 13;
            lblFeeAmount.Text = "100";
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Location = new Point(591, 414);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(148, 25);
            lblPaymentMethod.TabIndex = 14;
            lblPaymentMethod.Text = "Payment Method";
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Items.AddRange(new object[] { "GCash", "Maya" });
            cmbPaymentMethod.Location = new Point(745, 411);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(182, 33);
            cmbPaymentMethod.TabIndex = 15;
            cmbPaymentMethod.SelectedIndexChanged += cmbPaymentMethod_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(591, 455);
            label1.Name = "label1";
            label1.Size = new Size(150, 25);
            label1.TabIndex = 16;
            label1.Text = "Payment Account";
            // 
            // txtPaymentAccount
            // 
            txtPaymentAccount.Location = new Point(745, 455);
            txtPaymentAccount.Name = "txtPaymentAccount";
            txtPaymentAccount.ReadOnly = true;
            txtPaymentAccount.Size = new Size(182, 31);
            txtPaymentAccount.TabIndex = 17;
            // 
            // btnSubmitPayment
            // 
            btnSubmitPayment.Location = new Point(815, 515);
            btnSubmitPayment.Name = "btnSubmitPayment";
            btnSubmitPayment.Size = new Size(112, 34);
            btnSubmitPayment.TabIndex = 18;
            btnSubmitPayment.Text = "Submit Payment";
            btnSubmitPayment.UseVisualStyleBackColor = true;
            btnSubmitPayment.Click += btnSubmitPayment_Click;
            // 
            // btnCompleteBooking
            // 
            btnCompleteBooking.Location = new Point(684, 515);
            btnCompleteBooking.Name = "btnCompleteBooking";
            btnCompleteBooking.Size = new Size(112, 34);
            btnCompleteBooking.TabIndex = 19;
            btnCompleteBooking.Text = "Complete";
            btnCompleteBooking.UseVisualStyleBackColor = true;
            btnCompleteBooking.Visible = false;
            btnCompleteBooking.Click += btnCompleteBooking_Click;
            // 
            // BookingForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1046, 602);
            Controls.Add(btnCompleteBooking);
            Controls.Add(btnSubmitPayment);
            Controls.Add(txtPaymentAccount);
            Controls.Add(label1);
            Controls.Add(cmbPaymentMethod);
            Controls.Add(lblPaymentMethod);
            Controls.Add(lblFeeAmount);
            Controls.Add(lblSessionFee);
            Controls.Add(lblPayment);
            Controls.Add(txtExpectations);
            Controls.Add(lblExpectations);
            Controls.Add(flpSessionTutors);
            Controls.Add(lblAssignedTutors);
            Controls.Add(lblRequiredTutors);
            Controls.Add(lblSlots);
            Controls.Add(lblLocation);
            Controls.Add(lblTime);
            Controls.Add(lblDate);
            Controls.Add(lblTopic);
            Controls.Add(lblSubject);
            Name = "BookingForm";
            Text = "SessionDetailsForm";
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
        private Label lblRequiredTutors;
        private Label lblAssignedTutors;
        private FlowLayoutPanel flpSessionTutors;
        private Label lblExpectations;
        private TextBox txtExpectations;
        private Label lblPayment;
        private Label lblSessionFee;
        private Label lblFeeAmount;
        private Label lblPaymentMethod;
        private ComboBox cmbPaymentMethod;
        private Label label1;
        private TextBox txtPaymentAccount;
        private Button btnSubmitPayment;
        private Button btnCompleteBooking;
    }
}