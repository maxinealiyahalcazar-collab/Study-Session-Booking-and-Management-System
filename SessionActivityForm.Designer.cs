namespace Study_Session
{
    partial class SessionActivityForm
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
            lblTitle = new Label();
            lblTutors = new Label();
            flpTutorList = new FlowLayoutPanel();
            lblReview = new Label();
            lblSelectedTutor = new Label();
            lblRating = new Label();
            txtReview = new TextBox();
            btnSubmitRating = new Button();
            numRating = new NumericUpDown();
            pnlUploadMaterials = new Panel();
            txtMaterialName = new TextBox();
            txtDescription = new TextBox();
            btnUploadMaterial = new Button();
            btnChooseFile = new Button();
            lblSelectedFile = new Label();
            lblDescription = new Label();
            lblMaterialName = new Label();
            lblUploadMaterial = new Label();
            pnlRateTutor = new Panel();
            pnlViewMaterials = new Panel();
            pnlExpectations = new Panel();
            lblReadExpectations = new Label();
            flpExpectations = new FlowLayoutPanel();
            lblViewMaterialsTitle = new Label();
            flpMaterials = new FlowLayoutPanel();
            lblNoMaterials = new Label();
            ((System.ComponentModel.ISupportInitialize)numRating).BeginInit();
            pnlUploadMaterials.SuspendLayout();
            pnlRateTutor.SuspendLayout();
            pnlViewMaterials.SuspendLayout();
            pnlExpectations.SuspendLayout();
            flpMaterials.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(30, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(63, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Rating";
            // 
            // lblTutors
            // 
            lblTutors.AutoSize = true;
            lblTutors.Location = new Point(41, 85);
            lblTutors.Name = "lblTutors";
            lblTutors.Size = new Size(62, 25);
            lblTutors.TabIndex = 1;
            lblTutors.Text = "Tutors";
            // 
            // flpTutorList
            // 
            flpTutorList.AutoScroll = true;
            flpTutorList.FlowDirection = FlowDirection.TopDown;
            flpTutorList.Location = new Point(41, 131);
            flpTutorList.Name = "flpTutorList";
            flpTutorList.Size = new Size(415, 167);
            flpTutorList.TabIndex = 2;
            flpTutorList.WrapContents = false;
            // 
            // lblReview
            // 
            lblReview.AutoSize = true;
            lblReview.Location = new Point(48, 391);
            lblReview.Name = "lblReview";
            lblReview.Size = new Size(66, 25);
            lblReview.TabIndex = 4;
            lblReview.Text = "Review";
            // 
            // lblSelectedTutor
            // 
            lblSelectedTutor.AutoSize = true;
            lblSelectedTutor.Location = new Point(51, 317);
            lblSelectedTutor.Name = "lblSelectedTutor";
            lblSelectedTutor.Size = new Size(125, 25);
            lblSelectedTutor.TabIndex = 5;
            lblSelectedTutor.Text = "Selected Tutor";
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Location = new Point(48, 357);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(63, 25);
            lblRating.TabIndex = 6;
            lblRating.Text = "Rating";
            // 
            // txtReview
            // 
            txtReview.Location = new Point(51, 429);
            txtReview.Multiline = true;
            txtReview.Name = "txtReview";
            txtReview.Size = new Size(405, 109);
            txtReview.TabIndex = 7;
            // 
            // btnSubmitRating
            // 
            btnSubmitRating.Location = new Point(281, 554);
            btnSubmitRating.Name = "btnSubmitRating";
            btnSubmitRating.Size = new Size(175, 34);
            btnSubmitRating.TabIndex = 9;
            btnSubmitRating.Text = "Submit Rating";
            btnSubmitRating.UseVisualStyleBackColor = true;
            btnSubmitRating.Click += btnSubmitRating_Click;
            // 
            // numRating
            // 
            numRating.Location = new Point(120, 357);
            numRating.Name = "numRating";
            numRating.Size = new Size(180, 31);
            numRating.TabIndex = 10;
            // 
            // pnlUploadMaterials
            // 
            pnlUploadMaterials.Controls.Add(txtMaterialName);
            pnlUploadMaterials.Controls.Add(txtDescription);
            pnlUploadMaterials.Controls.Add(btnUploadMaterial);
            pnlUploadMaterials.Controls.Add(btnChooseFile);
            pnlUploadMaterials.Controls.Add(lblSelectedFile);
            pnlUploadMaterials.Controls.Add(lblDescription);
            pnlUploadMaterials.Controls.Add(lblMaterialName);
            pnlUploadMaterials.Controls.Add(lblUploadMaterial);
            pnlUploadMaterials.Location = new Point(0, 0);
            pnlUploadMaterials.Name = "pnlUploadMaterials";
            pnlUploadMaterials.Size = new Size(506, 609);
            pnlUploadMaterials.TabIndex = 11;
            // 
            // txtMaterialName
            // 
            txtMaterialName.Location = new Point(41, 173);
            txtMaterialName.Name = "txtMaterialName";
            txtMaterialName.Size = new Size(415, 31);
            txtMaterialName.TabIndex = 7;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(48, 267);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(408, 149);
            txtDescription.TabIndex = 6;
            // 
            // btnUploadMaterial
            // 
            btnUploadMaterial.Location = new Point(344, 504);
            btnUploadMaterial.Name = "btnUploadMaterial";
            btnUploadMaterial.Size = new Size(112, 34);
            btnUploadMaterial.TabIndex = 5;
            btnUploadMaterial.Text = "Upload Material";
            btnUploadMaterial.UseVisualStyleBackColor = true;
            btnUploadMaterial.Visible = false;
            btnUploadMaterial.Click += btnUploadMaterial_Click;
            // 
            // btnChooseFile
            // 
            btnChooseFile.Location = new Point(344, 437);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.Size = new Size(112, 34);
            btnChooseFile.TabIndex = 4;
            btnChooseFile.Text = "Choose File";
            btnChooseFile.UseVisualStyleBackColor = true;
            btnChooseFile.Click += btnChooseFile_Click;
            // 
            // lblSelectedFile
            // 
            lblSelectedFile.AutoEllipsis = true;
            lblSelectedFile.AutoSize = true;
            lblSelectedFile.Location = new Point(51, 437);
            lblSelectedFile.Name = "lblSelectedFile";
            lblSelectedFile.Size = new Size(109, 25);
            lblSelectedFile.TabIndex = 3;
            lblSelectedFile.Text = "Selected File";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(30, 216);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(102, 25);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Description";
            // 
            // lblMaterialName
            // 
            lblMaterialName.AutoSize = true;
            lblMaterialName.Location = new Point(30, 131);
            lblMaterialName.Name = "lblMaterialName";
            lblMaterialName.Size = new Size(127, 25);
            lblMaterialName.TabIndex = 1;
            lblMaterialName.Text = "Material Name";
            // 
            // lblUploadMaterial
            // 
            lblUploadMaterial.AutoSize = true;
            lblUploadMaterial.Location = new Point(30, 43);
            lblUploadMaterial.Name = "lblUploadMaterial";
            lblUploadMaterial.Size = new Size(146, 25);
            lblUploadMaterial.TabIndex = 0;
            lblUploadMaterial.Text = "Upload Materials";
            // 
            // pnlRateTutor
            // 
            pnlRateTutor.Controls.Add(lblTitle);
            pnlRateTutor.Controls.Add(numRating);
            pnlRateTutor.Controls.Add(btnSubmitRating);
            pnlRateTutor.Controls.Add(txtReview);
            pnlRateTutor.Controls.Add(lblTutors);
            pnlRateTutor.Controls.Add(lblRating);
            pnlRateTutor.Controls.Add(lblSelectedTutor);
            pnlRateTutor.Controls.Add(lblReview);
            pnlRateTutor.Controls.Add(flpTutorList);
            pnlRateTutor.Location = new Point(0, 0);
            pnlRateTutor.Name = "pnlRateTutor";
            pnlRateTutor.Size = new Size(506, 609);
            pnlRateTutor.TabIndex = 8;
            // 
            // pnlViewMaterials
            // 
            pnlViewMaterials.Controls.Add(pnlExpectations);
            pnlViewMaterials.Controls.Add(lblViewMaterialsTitle);
            pnlViewMaterials.Controls.Add(flpMaterials);
            pnlViewMaterials.Location = new Point(0, 0);
            pnlViewMaterials.Name = "pnlViewMaterials";
            pnlViewMaterials.Size = new Size(506, 609);
            pnlViewMaterials.TabIndex = 11;
            // 
            // pnlExpectations
            // 
            pnlExpectations.Controls.Add(lblReadExpectations);
            pnlExpectations.Controls.Add(flpExpectations);
            pnlExpectations.Location = new Point(3, 3);
            pnlExpectations.Name = "pnlExpectations";
            pnlExpectations.Size = new Size(506, 609);
            pnlExpectations.TabIndex = 12;
            // 
            // lblReadExpectations
            // 
            lblReadExpectations.AutoSize = true;
            lblReadExpectations.Location = new Point(41, 43);
            lblReadExpectations.Name = "lblReadExpectations";
            lblReadExpectations.Size = new Size(155, 25);
            lblReadExpectations.TabIndex = 0;
            lblReadExpectations.Text = "Read Expectations";
            // 
            // flpExpectations
            // 
            flpExpectations.AutoScroll = true;
            flpExpectations.Location = new Point(41, 91);
            flpExpectations.Name = "flpExpectations";
            flpExpectations.Size = new Size(415, 476);
            flpExpectations.TabIndex = 1;
            flpExpectations.WrapContents = false;
            // 
            // lblViewMaterialsTitle
            // 
            lblViewMaterialsTitle.AutoSize = true;
            lblViewMaterialsTitle.Location = new Point(41, 43);
            lblViewMaterialsTitle.Name = "lblViewMaterialsTitle";
            lblViewMaterialsTitle.Size = new Size(125, 25);
            lblViewMaterialsTitle.TabIndex = 0;
            lblViewMaterialsTitle.Text = "View Materials";
            // 
            // flpMaterials
            // 
            flpMaterials.AutoScroll = true;
            flpMaterials.Controls.Add(lblNoMaterials);
            flpMaterials.Location = new Point(41, 91);
            flpMaterials.Name = "flpMaterials";
            flpMaterials.Size = new Size(415, 476);
            flpMaterials.TabIndex = 1;
            flpMaterials.WrapContents = false;
            // 
            // lblNoMaterials
            // 
            lblNoMaterials.AutoSize = true;
            lblNoMaterials.Location = new Point(3, 0);
            lblNoMaterials.Name = "lblNoMaterials";
            lblNoMaterials.Size = new Size(407, 25);
            lblNoMaterials.TabIndex = 2;
            lblNoMaterials.Text = "No materials have been uploaded for this session.";
            // 
            // SessionActivityForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(507, 610);
            Controls.Add(pnlViewMaterials);
            Controls.Add(pnlRateTutor);
            Controls.Add(pnlUploadMaterials);
            Name = "SessionActivityForm";
            Text = "RatingTutor";
            ((System.ComponentModel.ISupportInitialize)numRating).EndInit();
            pnlUploadMaterials.ResumeLayout(false);
            pnlUploadMaterials.PerformLayout();
            pnlRateTutor.ResumeLayout(false);
            pnlRateTutor.PerformLayout();
            pnlViewMaterials.ResumeLayout(false);
            pnlViewMaterials.PerformLayout();
            pnlExpectations.ResumeLayout(false);
            pnlExpectations.PerformLayout();
            flpMaterials.ResumeLayout(false);
            flpMaterials.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblTutors;
        private FlowLayoutPanel flpTutorList;
        private Label lblTitle;
        private Label lblReview;
        private Label lblSelectedTutor;
        private Label lblRating;
        private TextBox txtReview;
        private Button btnSubmitRating;
        private NumericUpDown numRating;
        private Panel pnlUploadMaterials;
        private Label lblSelectedFile;
        private Label lblDescription;
        private Label lblMaterialName;
        private Label lblUploadMaterial;
        private TextBox txtDescription;
        private Button btnUploadMaterial;
        private Button btnChooseFile;
        private TextBox txtMaterialName;
        private Panel pnlRateTutor;
        private Panel pnlViewMaterials;
        private FlowLayoutPanel flpMaterials;
        private Label lblViewMaterialsTitle;
        private Label lblNoMaterials;
        private Panel pnlExpectations;
        private Label lblReadExpectations;
        private FlowLayoutPanel flpExpectations;
    }
}