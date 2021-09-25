namespace GAM.Forms.Profile.Etebarat.Arshive
{
    partial class dlgAddLoanFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAddLoanFile));
            this.pnlBotton = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.lblCoverNo = new System.Windows.Forms.Label();
            this.lblIndicatorID = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtBranchID = new System.Windows.Forms.TextBox();
            this.lblBranchID = new System.Windows.Forms.Label();
            this.lblBranchName = new System.Windows.Forms.Label();
            this.btnBranchesInfo = new DevExpress.XtraEditors.SimpleButton();
            this.txtNote = new System.Windows.Forms.CustomControls.FilterdTextBox();
            this.txtCustomerName = new System.Windows.Forms.CustomControls.FilterdTextBox();
            this.btnGetLastIndicatorID = new DevExpress.XtraEditors.SimpleButton();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.CustomControls.FilterdTextBox();
            this.txtIndicatorID = new DevExpress.XtraEditors.TextEdit();
            this.txtCoverNo = new DevExpress.XtraEditors.TextEdit();
            this.pnlBotton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndicatorID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoverNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBotton
            // 
            this.pnlBotton.Controls.Add(this.btnCancel);
            this.pnlBotton.Controls.Add(this.btnSave);
            this.pnlBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotton.Location = new System.Drawing.Point(0, 199);
            this.pnlBotton.Name = "pnlBotton";
            this.pnlBotton.Size = new System.Drawing.Size(360, 35);
            this.pnlBotton.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(84, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(271, 29);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "ثبت اطلاعات و تشکیل پرونده";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCoverNo
            // 
            this.lblCoverNo.AutoSize = true;
            this.lblCoverNo.Location = new System.Drawing.Point(281, 67);
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
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(281, 115);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(66, 13);
            this.lblCustomerName.TabIndex = 184;
            this.lblCustomerName.Text = "صاحب پرونده";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(281, 140);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(47, 13);
            this.lblNote.TabIndex = 186;
            this.lblNote.Text = "یادداشت";
            // 
            // txtBranchID
            // 
            this.txtBranchID.Enabled = false;
            this.txtBranchID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranchID.Location = new System.Drawing.Point(231, 12);
            this.txtBranchID.MaxLength = 5;
            this.txtBranchID.Name = "txtBranchID";
            this.txtBranchID.ReadOnly = true;
            this.txtBranchID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBranchID.Size = new System.Drawing.Size(48, 22);
            this.txtBranchID.TabIndex = 1;
            this.txtBranchID.TabStop = false;
            this.txtBranchID.Tag = "";
            this.txtBranchID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBranchID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // lblBranchID
            // 
            this.lblBranchID.AutoSize = true;
            this.lblBranchID.Location = new System.Drawing.Point(281, 17);
            this.lblBranchID.Name = "lblBranchID";
            this.lblBranchID.Size = new System.Drawing.Size(48, 13);
            this.lblBranchID.TabIndex = 189;
            this.lblBranchID.Text = "کد شعبه";
            // 
            // lblBranchName
            // 
            this.lblBranchName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblBranchName.ForeColor = System.Drawing.Color.Black;
            this.lblBranchName.Location = new System.Drawing.Point(7, 15);
            this.lblBranchName.Name = "lblBranchName";
            this.lblBranchName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBranchName.Size = new System.Drawing.Size(191, 17);
            this.lblBranchName.TabIndex = 190;
            // 
            // btnBranchesInfo
            // 
            this.btnBranchesInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBranchesInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBranchesInfo.ImageOptions.Image")));
            this.btnBranchesInfo.Location = new System.Drawing.Point(201, 12);
            this.btnBranchesInfo.Name = "btnBranchesInfo";
            this.btnBranchesInfo.Size = new System.Drawing.Size(25, 22);
            this.btnBranchesInfo.TabIndex = 2;
            this.btnBranchesInfo.Click += new System.EventHandler(this.btnBranchesInfo_Click);
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
            this.txtNote.Location = new System.Drawing.Point(7, 137);
            this.txtNote.MaxLength = 100;
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.PromptFont = null;
            this.txtNote.PromptForeColor = System.Drawing.SystemColors.Control;
            this.txtNote.PromptText = "";
            this.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNote.SelectAllFocused = true;
            this.txtNote.Size = new System.Drawing.Size(272, 56);
            this.txtNote.TabIndex = 7;
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
            this.txtCustomerName.Location = new System.Drawing.Point(7, 112);
            this.txtCustomerName.MaxLength = 100;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PromptFont = null;
            this.txtCustomerName.PromptForeColor = System.Drawing.SystemColors.Control;
            this.txtCustomerName.PromptText = "";
            this.txtCustomerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustomerName.SelectAllFocused = true;
            this.txtCustomerName.Size = new System.Drawing.Size(272, 22);
            this.txtCustomerName.TabIndex = 6;
            this.txtCustomerName.TextLanguage = System.Windows.Forms.CustomControls.FilterdTextBox.LanguageEnum.Farsi;
            this.txtCustomerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // btnGetLastIndicatorID
            // 
            this.btnGetLastIndicatorID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGetLastIndicatorID.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGetLastIndicatorID.ImageOptions.Image")));
            this.btnGetLastIndicatorID.Location = new System.Drawing.Point(172, 37);
            this.btnGetLastIndicatorID.Name = "btnGetLastIndicatorID";
            this.btnGetLastIndicatorID.Size = new System.Drawing.Size(25, 22);
            this.btnGetLastIndicatorID.TabIndex = 3;
            this.btnGetLastIndicatorID.Click += new System.EventHandler(this.btnGetLastIndicatorID_Click);
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Location = new System.Drawing.Point(281, 90);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(77, 13);
            this.lblCustomerID.TabIndex = 192;
            this.lblCustomerID.Text = "شماره مشتری";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.AcceptedChars = "-";
            this.txtCustomerID.BackColor = System.Drawing.SystemColors.Window;
            this.txtCustomerID.BackColorOnErr = System.Drawing.Color.Pink;
            this.txtCustomerID.BackColorUsed = System.Drawing.SystemColors.Window;
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID.FilterChars = System.Windows.Forms.CustomControls.FilterdTextBox.FilteredEnum.Numeric;
            this.txtCustomerID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerID.Location = new System.Drawing.Point(136, 87);
            this.txtCustomerID.MaxLength = 100;
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.PromptFont = null;
            this.txtCustomerID.PromptForeColor = System.Drawing.SystemColors.Control;
            this.txtCustomerID.PromptText = "";
            this.txtCustomerID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustomerID.SelectAllFocused = true;
            this.txtCustomerID.Size = new System.Drawing.Size(143, 22);
            this.txtCustomerID.TabIndex = 5;
            this.txtCustomerID.TextLanguage = System.Windows.Forms.CustomControls.FilterdTextBox.LanguageEnum.Farsi;
            this.txtCustomerID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // txtIndicatorID
            // 
            this.txtIndicatorID.EditValue = "";
            this.txtIndicatorID.Location = new System.Drawing.Point(201, 37);
            this.txtIndicatorID.Name = "txtIndicatorID";
            this.txtIndicatorID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndicatorID.Properties.Appearance.Options.UseFont = true;
            this.txtIndicatorID.Properties.Mask.EditMask = "[0-9]+";
            this.txtIndicatorID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtIndicatorID.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtIndicatorID.Properties.MaxLength = 15;
            this.txtIndicatorID.Properties.NullText = "0";
            this.txtIndicatorID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtIndicatorID.Size = new System.Drawing.Size(78, 22);
            this.txtIndicatorID.TabIndex = 3;
            this.txtIndicatorID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // txtCoverNo
            // 
            this.txtCoverNo.EditValue = "1";
            this.txtCoverNo.Location = new System.Drawing.Point(242, 62);
            this.txtCoverNo.Name = "txtCoverNo";
            this.txtCoverNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoverNo.Properties.Appearance.Options.UseFont = true;
            this.txtCoverNo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCoverNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCoverNo.Properties.Mask.EditMask = "[0-9]+";
            this.txtCoverNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtCoverNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtCoverNo.Properties.MaxLength = 15;
            this.txtCoverNo.Properties.NullText = "0";
            this.txtCoverNo.Properties.ReadOnly = true;
            this.txtCoverNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCoverNo.Size = new System.Drawing.Size(37, 22);
            this.txtCoverNo.TabIndex = 4;
            this.txtCoverNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // dlgAddFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 234);
            this.Controls.Add(this.txtCoverNo);
            this.Controls.Add(this.txtIndicatorID);
            this.Controls.Add(this.lblCustomerID);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.btnGetLastIndicatorID);
            this.Controls.Add(this.txtBranchID);
            this.Controls.Add(this.lblBranchID);
            this.Controls.Add(this.lblBranchName);
            this.Controls.Add(this.btnBranchesInfo);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.lblIndicatorID);
            this.Controls.Add(this.lblCoverNo);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.pnlBotton);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "dlgAddFile";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "پرونده اعتباری جدید";
            this.TopMost = true;
            this.pnlBotton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtIndicatorID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoverNo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlBotton;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        public System.Windows.Forms.CustomControls.FilterdTextBox txtCustomerName;
        private System.Windows.Forms.Label lblCoverNo;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.Label lblIndicatorID;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblNote;
        public System.Windows.Forms.CustomControls.FilterdTextBox txtNote;
        public System.Windows.Forms.TextBox txtBranchID;
        private System.Windows.Forms.Label lblBranchID;
        public System.Windows.Forms.Label lblBranchName;
        private DevExpress.XtraEditors.SimpleButton btnBranchesInfo;
        private DevExpress.XtraEditors.SimpleButton btnGetLastIndicatorID;
        private System.Windows.Forms.Label lblCustomerID;
        public System.Windows.Forms.CustomControls.FilterdTextBox txtCustomerID;
        private DevExpress.XtraEditors.TextEdit txtIndicatorID;
        private DevExpress.XtraEditors.TextEdit txtCoverNo;
    }
}