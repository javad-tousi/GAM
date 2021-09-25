namespace GAM.Forms.Profile.Etebarat.Arshive
{
    partial class dlgEditFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgEditFile));
            this.pnlBotton = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtFileId = new System.Windows.Forms.TextBox();
            this.txtCoverNo = new System.Windows.Forms.TextBox();
            this.lblCoverNo = new System.Windows.Forms.Label();
            this.lblIndicatorID = new System.Windows.Forms.Label();
            this.lblFileID = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtBranchId = new System.Windows.Forms.TextBox();
            this.lblBranchID = new System.Windows.Forms.Label();
            this.lblBranchName = new System.Windows.Forms.Label();
            this.btnBranchesList = new DevExpress.XtraEditors.SimpleButton();
            this.txtNote = new System.Windows.Forms.CustomControls.FilterdTextBox();
            this.txtCustomerName = new System.Windows.Forms.CustomControls.FilterdTextBox();
            this.btnGetLastIndicatorID = new DevExpress.XtraEditors.SimpleButton();
            this.txtIndicatorId = new System.Windows.Forms.TextBox();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.CustomControls.FilterdTextBox();
            this.pnlBotton.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBotton
            // 
            this.pnlBotton.Controls.Add(this.btnCancel);
            this.pnlBotton.Controls.Add(this.btnSave);
            this.pnlBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotton.Location = new System.Drawing.Point(0, 219);
            this.pnlBotton.Name = "pnlBotton";
            this.pnlBotton.Size = new System.Drawing.Size(355, 35);
            this.pnlBotton.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 29);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(93, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(259, 29);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "ویرایش اطلاعات";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtFileId
            // 
            this.txtFileId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileId.Location = new System.Drawing.Point(201, 12);
            this.txtFileId.Name = "txtFileId";
            this.txtFileId.ReadOnly = true;
            this.txtFileId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFileId.Size = new System.Drawing.Size(78, 22);
            this.txtFileId.TabIndex = 1;
            this.txtFileId.Tag = "";
            // 
            // txtCoverNo
            // 
            this.txtCoverNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtCoverNo.ForeColor = System.Drawing.Color.Blue;
            this.txtCoverNo.Location = new System.Drawing.Point(248, 62);
            this.txtCoverNo.MaxLength = 2;
            this.txtCoverNo.Name = "txtCoverNo";
            this.txtCoverNo.ReadOnly = true;
            this.txtCoverNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCoverNo.Size = new System.Drawing.Size(31, 22);
            this.txtCoverNo.TabIndex = 3;
            this.txtCoverNo.TabStop = false;
            this.txtCoverNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCoverNo
            // 
            this.lblCoverNo.AutoSize = true;
            this.lblCoverNo.Location = new System.Drawing.Point(281, 66);
            this.lblCoverNo.Name = "lblCoverNo";
            this.lblCoverNo.Size = new System.Drawing.Size(24, 13);
            this.lblCoverNo.TabIndex = 162;
            this.lblCoverNo.Text = "جلد";
            // 
            // lblIndicatorID
            // 
            this.lblIndicatorID.AutoSize = true;
            this.lblIndicatorID.ForeColor = System.Drawing.Color.Black;
            this.lblIndicatorID.Location = new System.Drawing.Point(281, 41);
            this.lblIndicatorID.Name = "lblIndicatorID";
            this.lblIndicatorID.Size = new System.Drawing.Size(37, 13);
            this.lblIndicatorID.TabIndex = 182;
            this.lblIndicatorID.Text = "کلاسه";
            // 
            // lblFileID
            // 
            this.lblFileID.AutoSize = true;
            this.lblFileID.Location = new System.Drawing.Point(281, 16);
            this.lblFileID.Name = "lblFileID";
            this.lblFileID.Size = new System.Drawing.Size(42, 13);
            this.lblFileID.TabIndex = 183;
            this.lblFileID.Text = "شناسه";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(281, 139);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(66, 13);
            this.lblCustomerName.TabIndex = 184;
            this.lblCustomerName.Text = "صاحب پرونده";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(281, 164);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(47, 13);
            this.lblNote.TabIndex = 186;
            this.lblNote.Text = "یادداشت";
            // 
            // txtBranchId
            // 
            this.txtBranchId.Enabled = false;
            this.txtBranchId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranchId.Location = new System.Drawing.Point(231, 86);
            this.txtBranchId.MaxLength = 5;
            this.txtBranchId.Name = "txtBranchId";
            this.txtBranchId.ReadOnly = true;
            this.txtBranchId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBranchId.Size = new System.Drawing.Size(48, 22);
            this.txtBranchId.TabIndex = 4;
            this.txtBranchId.TabStop = false;
            this.txtBranchId.Tag = "";
            this.txtBranchId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBranchID
            // 
            this.lblBranchID.AutoSize = true;
            this.lblBranchID.Location = new System.Drawing.Point(281, 91);
            this.lblBranchID.Name = "lblBranchID";
            this.lblBranchID.Size = new System.Drawing.Size(48, 13);
            this.lblBranchID.TabIndex = 189;
            this.lblBranchID.Text = "کد شعبه";
            // 
            // lblBranchName
            // 
            this.lblBranchName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblBranchName.ForeColor = System.Drawing.Color.Black;
            this.lblBranchName.Location = new System.Drawing.Point(7, 89);
            this.lblBranchName.Name = "lblBranchName";
            this.lblBranchName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBranchName.Size = new System.Drawing.Size(191, 17);
            this.lblBranchName.TabIndex = 190;
            // 
            // btnBranchesList
            // 
            this.btnBranchesList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBranchesList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBranchesInfo.ImageOptions.Image")));
            this.btnBranchesList.Location = new System.Drawing.Point(201, 86);
            this.btnBranchesList.Name = "btnBranchesList";
            this.btnBranchesList.Size = new System.Drawing.Size(25, 22);
            this.btnBranchesList.TabIndex = 5;
            this.btnBranchesList.Click += new System.EventHandler(this.btnBranchesList_Click);
            // 
            // txtNote
            // 
            this.txtNote.AcceptedChars = ".-()";
            this.txtNote.BackColor = System.Drawing.SystemColors.Window;
            this.txtNote.BackColorOnErr = System.Drawing.Color.Pink;
            this.txtNote.BackColorUsed = System.Drawing.SystemColors.Window;
            this.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNote.FilterChars = System.Windows.Forms.CustomControls.FilterdTextBox.FilteredEnum.PersianChars;
            this.txtNote.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(7, 161);
            this.txtNote.MaxLength = 100;
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.PromptFont = null;
            this.txtNote.PromptForeColor = System.Drawing.SystemColors.Control;
            this.txtNote.PromptText = "";
            this.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNote.SelectAllFocused = true;
            this.txtNote.Size = new System.Drawing.Size(272, 56);
            this.txtNote.TabIndex = 8;
            this.txtNote.TextLanguage = System.Windows.Forms.CustomControls.FilterdTextBox.LanguageEnum.Farsi;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.AcceptedChars = ".-()";
            this.txtCustomerName.BackColor = System.Drawing.SystemColors.Window;
            this.txtCustomerName.BackColorOnErr = System.Drawing.Color.Pink;
            this.txtCustomerName.BackColorUsed = System.Drawing.SystemColors.Window;
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.FilterChars = System.Windows.Forms.CustomControls.FilterdTextBox.FilteredEnum.PersianChars;
            this.txtCustomerName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(7, 136);
            this.txtCustomerName.MaxLength = 100;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PromptFont = null;
            this.txtCustomerName.PromptForeColor = System.Drawing.SystemColors.Control;
            this.txtCustomerName.PromptText = "";
            this.txtCustomerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustomerName.SelectAllFocused = true;
            this.txtCustomerName.Size = new System.Drawing.Size(272, 22);
            this.txtCustomerName.TabIndex = 7;
            this.txtCustomerName.TextLanguage = System.Windows.Forms.CustomControls.FilterdTextBox.LanguageEnum.Farsi;
            // 
            // btnGetLastIndicatorID
            // 
            this.btnGetLastIndicatorID.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGetLastIndicatorID.BackgroundImage")));
            this.btnGetLastIndicatorID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGetLastIndicatorID.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGetLastIndicatorID.ImageOptions.Image")));
            this.btnGetLastIndicatorID.Location = new System.Drawing.Point(172, 37);
            this.btnGetLastIndicatorID.Name = "btnGetLastIndicatorID";
            this.btnGetLastIndicatorID.Size = new System.Drawing.Size(25, 22);
            this.btnGetLastIndicatorID.TabIndex = 0;
            this.btnGetLastIndicatorID.TabStop = false;
            this.btnGetLastIndicatorID.Click += new System.EventHandler(this.btnGetLastIndicatorId_Click);
            // 
            // txtIndicatorId
            // 
            this.txtIndicatorId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndicatorId.Location = new System.Drawing.Point(201, 37);
            this.txtIndicatorId.Name = "txtIndicatorId";
            this.txtIndicatorId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtIndicatorId.Size = new System.Drawing.Size(78, 22);
            this.txtIndicatorId.TabIndex = 2;
            this.txtIndicatorId.Tag = "";
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Location = new System.Drawing.Point(281, 114);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(77, 13);
            this.lblCustomerID.TabIndex = 194;
            this.lblCustomerID.Text = "شماره مشتری";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.AcceptedChars = "-";
            this.txtCustomerId.BackColor = System.Drawing.SystemColors.Window;
            this.txtCustomerId.BackColorOnErr = System.Drawing.Color.Pink;
            this.txtCustomerId.BackColorUsed = System.Drawing.SystemColors.Window;
            this.txtCustomerId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerId.FilterChars = System.Windows.Forms.CustomControls.FilterdTextBox.FilteredEnum.Numeric;
            this.txtCustomerId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerId.Location = new System.Drawing.Point(111, 111);
            this.txtCustomerId.MaxLength = 100;
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.PromptFont = null;
            this.txtCustomerId.PromptForeColor = System.Drawing.SystemColors.Control;
            this.txtCustomerId.PromptText = "";
            this.txtCustomerId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustomerId.SelectAllFocused = true;
            this.txtCustomerId.Size = new System.Drawing.Size(168, 22);
            this.txtCustomerId.TabIndex = 6;
            this.txtCustomerId.TextLanguage = System.Windows.Forms.CustomControls.FilterdTextBox.LanguageEnum.Farsi;
            // 
            // dlgEditFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 254);
            this.Controls.Add(this.lblCustomerID);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.txtIndicatorId);
            this.Controls.Add(this.btnGetLastIndicatorID);
            this.Controls.Add(this.txtBranchId);
            this.Controls.Add(this.lblBranchID);
            this.Controls.Add(this.lblBranchName);
            this.Controls.Add(this.btnBranchesList);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.lblFileID);
            this.Controls.Add(this.lblIndicatorID);
            this.Controls.Add(this.txtCoverNo);
            this.Controls.Add(this.lblCoverNo);
            this.Controls.Add(this.txtFileId);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.pnlBotton);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "dlgEditFile";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ویرایش اطلاعات پرونده";
            this.TopMost = true;
            this.pnlBotton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlBotton;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        public System.Windows.Forms.TextBox txtFileId;
        public System.Windows.Forms.CustomControls.FilterdTextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCoverNo;
        private System.Windows.Forms.Label lblCoverNo;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.Label lblIndicatorID;
        private System.Windows.Forms.Label lblFileID;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblNote;
        public System.Windows.Forms.CustomControls.FilterdTextBox txtNote;
        public System.Windows.Forms.TextBox txtBranchId;
        private System.Windows.Forms.Label lblBranchID;
        public System.Windows.Forms.Label lblBranchName;
        private DevExpress.XtraEditors.SimpleButton btnBranchesList;
        private DevExpress.XtraEditors.SimpleButton btnGetLastIndicatorID;
        public System.Windows.Forms.TextBox txtIndicatorId;
        private System.Windows.Forms.Label lblCustomerID;
        public System.Windows.Forms.CustomControls.FilterdTextBox txtCustomerId;
    }
}