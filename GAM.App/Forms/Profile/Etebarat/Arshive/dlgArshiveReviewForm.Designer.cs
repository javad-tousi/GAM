namespace GAM.Forms.Profile.Etebarat.Arshive
{
    partial class dlgArshiveReviewReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgArshiveReviewReport));
            this.pnlBotton = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnFindSerial = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReviewNo = new DevExpress.XtraEditors.TextEdit();
            this.lblCoverNo = new System.Windows.Forms.Label();
            this.lblIndicatorID = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.btnBranchesList = new DevExpress.XtraEditors.SimpleButton();
            this.lblBranchName = new System.Windows.Forms.Label();
            this.lblBranchID = new System.Windows.Forms.Label();
            this.txtBranchId = new System.Windows.Forms.TextBox();
            this.btnGetLastIndicatorID = new DevExpress.XtraEditors.SimpleButton();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.txtIndicatorId = new DevExpress.XtraEditors.TextEdit();
            this.txtCoverNo = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomerId = new System.Windows.Forms.CustomControls.FilterdTextBox();
            this.txtCustomerName = new System.Windows.Forms.CustomControls.FilterdTextBox();
            this.lblPleaseWait = new System.Windows.Forms.Label();
            this.txtRequestsCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlBotton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReviewNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndicatorId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoverNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBotton
            // 
            this.pnlBotton.Controls.Add(this.btnCancel);
            this.pnlBotton.Controls.Add(this.btnSave);
            this.pnlBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotton.Location = new System.Drawing.Point(0, 202);
            this.pnlBotton.Name = "pnlBotton";
            this.pnlBotton.Size = new System.Drawing.Size(360, 35);
            this.pnlBotton.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(107, 29);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(116, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(240, 29);
            this.btnSave.TabIndex = 10;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "ثبت اطلاعات و تشکیل پرونده";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnFindSerial
            // 
            this.btnFindSerial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFindSerial.Location = new System.Drawing.Point(98, 19);
            this.btnFindSerial.Name = "btnFindSerial";
            this.btnFindSerial.Size = new System.Drawing.Size(59, 26);
            this.btnFindSerial.TabIndex = 2;
            this.btnFindSerial.Text = "جستجو";
            this.btnFindSerial.Click += new System.EventHandler(this.btnFindSerial_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(281, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 195;
            this.label1.Text = "شماره بررسی";
            // 
            // txtReviewNo
            // 
            this.txtReviewNo.EditValue = "";
            this.txtReviewNo.Location = new System.Drawing.Point(161, 20);
            this.txtReviewNo.Name = "txtReviewNo";
            this.txtReviewNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReviewNo.Properties.Appearance.Options.UseFont = true;
            this.txtReviewNo.Properties.AutoHeight = false;
            this.txtReviewNo.Properties.Mask.EditMask = "\\d+";
            this.txtReviewNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtReviewNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtReviewNo.Properties.MaxLength = 15;
            this.txtReviewNo.Properties.NullText = "0";
            this.txtReviewNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtReviewNo.Size = new System.Drawing.Size(118, 24);
            this.txtReviewNo.TabIndex = 1;
            this.txtReviewNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // lblCoverNo
            // 
            this.lblCoverNo.AutoSize = true;
            this.lblCoverNo.Location = new System.Drawing.Point(281, 177);
            this.lblCoverNo.Name = "lblCoverNo";
            this.lblCoverNo.Size = new System.Drawing.Size(24, 13);
            this.lblCoverNo.TabIndex = 162;
            this.lblCoverNo.Text = "جلد";
            // 
            // lblIndicatorID
            // 
            this.lblIndicatorID.AutoSize = true;
            this.lblIndicatorID.ForeColor = System.Drawing.Color.Black;
            this.lblIndicatorID.Location = new System.Drawing.Point(281, 153);
            this.lblIndicatorID.Name = "lblIndicatorID";
            this.lblIndicatorID.Size = new System.Drawing.Size(37, 13);
            this.lblIndicatorID.TabIndex = 182;
            this.lblIndicatorID.Text = "کلاسه";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(281, 76);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(66, 13);
            this.lblCustomerName.TabIndex = 184;
            this.lblCustomerName.Text = "صاحب پرونده";
            // 
            // btnBranchesList
            // 
            this.btnBranchesList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBranchesList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBranchesList.ImageOptions.Image")));
            this.btnBranchesList.Location = new System.Drawing.Point(201, 124);
            this.btnBranchesList.Name = "btnBranchesList";
            this.btnBranchesList.Size = new System.Drawing.Size(25, 22);
            this.btnBranchesList.TabIndex = 6;
            this.btnBranchesList.Click += new System.EventHandler(this.btnBranchesList_Click);
            // 
            // lblBranchName
            // 
            this.lblBranchName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblBranchName.ForeColor = System.Drawing.Color.Black;
            this.lblBranchName.Location = new System.Drawing.Point(7, 127);
            this.lblBranchName.Name = "lblBranchName";
            this.lblBranchName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBranchName.Size = new System.Drawing.Size(191, 17);
            this.lblBranchName.TabIndex = 190;
            // 
            // lblBranchID
            // 
            this.lblBranchID.AutoSize = true;
            this.lblBranchID.Location = new System.Drawing.Point(281, 129);
            this.lblBranchID.Name = "lblBranchID";
            this.lblBranchID.Size = new System.Drawing.Size(48, 13);
            this.lblBranchID.TabIndex = 189;
            this.lblBranchID.Text = "کد شعبه";
            // 
            // txtBranchId
            // 
            this.txtBranchId.Enabled = false;
            this.txtBranchId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranchId.Location = new System.Drawing.Point(231, 124);
            this.txtBranchId.MaxLength = 5;
            this.txtBranchId.Name = "txtBranchId";
            this.txtBranchId.ReadOnly = true;
            this.txtBranchId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBranchId.Size = new System.Drawing.Size(48, 22);
            this.txtBranchId.TabIndex = 5;
            this.txtBranchId.TabStop = false;
            this.txtBranchId.Tag = "";
            this.txtBranchId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBranchId.TextChanged += new System.EventHandler(this.txtBranchId_TextChanged);
            this.txtBranchId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // btnGetLastIndicatorID
            // 
            this.btnGetLastIndicatorID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGetLastIndicatorID.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGetLastIndicatorID.ImageOptions.Image")));
            this.btnGetLastIndicatorID.Location = new System.Drawing.Point(172, 149);
            this.btnGetLastIndicatorID.Name = "btnGetLastIndicatorID";
            this.btnGetLastIndicatorID.Size = new System.Drawing.Size(25, 22);
            this.btnGetLastIndicatorID.TabIndex = 8;
            this.btnGetLastIndicatorID.Click += new System.EventHandler(this.btnGetLastIndicatorId_Click);
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Location = new System.Drawing.Point(281, 51);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(77, 13);
            this.lblCustomerID.TabIndex = 192;
            this.lblCustomerID.Text = "شماره مشتری";
            // 
            // txtIndicatorId
            // 
            this.txtIndicatorId.EditValue = "";
            this.txtIndicatorId.Location = new System.Drawing.Point(201, 149);
            this.txtIndicatorId.Name = "txtIndicatorId";
            this.txtIndicatorId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndicatorId.Properties.Appearance.Options.UseFont = true;
            this.txtIndicatorId.Properties.Mask.EditMask = "[0-9]+";
            this.txtIndicatorId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtIndicatorId.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtIndicatorId.Properties.MaxLength = 15;
            this.txtIndicatorId.Properties.NullText = "0";
            this.txtIndicatorId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtIndicatorId.Size = new System.Drawing.Size(78, 22);
            this.txtIndicatorId.TabIndex = 7;
            this.txtIndicatorId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // txtCoverNo
            // 
            this.txtCoverNo.EditValue = "1";
            this.txtCoverNo.Location = new System.Drawing.Point(242, 174);
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
            this.txtCoverNo.TabIndex = 9;
            this.txtCoverNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
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
            this.txtCustomerId.Location = new System.Drawing.Point(161, 48);
            this.txtCustomerId.MaxLength = 100;
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.PromptFont = null;
            this.txtCustomerId.PromptForeColor = System.Drawing.SystemColors.Control;
            this.txtCustomerId.PromptText = "";
            this.txtCustomerId.SelectAllFocused = true;
            this.txtCustomerId.Size = new System.Drawing.Size(118, 22);
            this.txtCustomerId.TabIndex = 3;
            this.txtCustomerId.TextLanguage = System.Windows.Forms.CustomControls.FilterdTextBox.LanguageEnum.Farsi;
            this.txtCustomerId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
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
            this.txtCustomerName.Location = new System.Drawing.Point(7, 73);
            this.txtCustomerName.MaxLength = 100;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PromptFont = null;
            this.txtCustomerName.PromptForeColor = System.Drawing.SystemColors.Control;
            this.txtCustomerName.PromptText = "";
            this.txtCustomerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustomerName.SelectAllFocused = true;
            this.txtCustomerName.Size = new System.Drawing.Size(272, 22);
            this.txtCustomerName.TabIndex = 4;
            this.txtCustomerName.TextLanguage = System.Windows.Forms.CustomControls.FilterdTextBox.LanguageEnum.Farsi;
            this.txtCustomerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // lblPleaseWait
            // 
            this.lblPleaseWait.AutoSize = true;
            this.lblPleaseWait.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPleaseWait.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblPleaseWait.Location = new System.Drawing.Point(7, 26);
            this.lblPleaseWait.Name = "lblPleaseWait";
            this.lblPleaseWait.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPleaseWait.Size = new System.Drawing.Size(88, 13);
            this.lblPleaseWait.TabIndex = 196;
            this.lblPleaseWait.Text = "کمی صبر کنید ...";
            this.lblPleaseWait.Visible = false;
            // 
            // txtRequestsCount
            // 
            this.txtRequestsCount.Enabled = false;
            this.txtRequestsCount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequestsCount.Location = new System.Drawing.Point(231, 99);
            this.txtRequestsCount.MaxLength = 5;
            this.txtRequestsCount.Name = "txtRequestsCount";
            this.txtRequestsCount.ReadOnly = true;
            this.txtRequestsCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRequestsCount.Size = new System.Drawing.Size(48, 22);
            this.txtRequestsCount.TabIndex = 197;
            this.txtRequestsCount.TabStop = false;
            this.txtRequestsCount.Tag = "";
            this.txtRequestsCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 198;
            this.label2.Text = "تعداد پیشنهاد";
            // 
            // dlgArshiveReviewReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 237);
            this.Controls.Add(this.txtRequestsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPleaseWait);
            this.Controls.Add(this.txtReviewNo);
            this.Controls.Add(this.btnFindSerial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCoverNo);
            this.Controls.Add(this.txtIndicatorId);
            this.Controls.Add(this.lblCustomerID);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.btnGetLastIndicatorID);
            this.Controls.Add(this.txtBranchId);
            this.Controls.Add(this.lblBranchID);
            this.Controls.Add(this.lblBranchName);
            this.Controls.Add(this.btnBranchesList);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.lblIndicatorID);
            this.Controls.Add(this.lblCoverNo);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.pnlBotton);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "dlgArshiveReviewReport";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "پرونده اعتباری جدید";
            this.TopMost = true;
            this.pnlBotton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtReviewNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndicatorId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoverNo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlBotton;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnFindSerial;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtReviewNo;
        public System.Windows.Forms.CustomControls.FilterdTextBox txtCustomerName;
        private System.Windows.Forms.Label lblCoverNo;
        private System.Windows.Forms.Label lblIndicatorID;
        private System.Windows.Forms.Label lblCustomerName;
        private DevExpress.XtraEditors.SimpleButton btnBranchesList;
        public System.Windows.Forms.Label lblBranchName;
        private System.Windows.Forms.Label lblBranchID;
        public System.Windows.Forms.TextBox txtBranchId;
        private DevExpress.XtraEditors.SimpleButton btnGetLastIndicatorID;
        public System.Windows.Forms.CustomControls.FilterdTextBox txtCustomerId;
        private System.Windows.Forms.Label lblCustomerID;
        private DevExpress.XtraEditors.TextEdit txtIndicatorId;
        private DevExpress.XtraEditors.TextEdit txtCoverNo;
        private System.Windows.Forms.Label lblPleaseWait;
        public System.Windows.Forms.TextBox txtRequestsCount;
        private System.Windows.Forms.Label label2;
    }
}