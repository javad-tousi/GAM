namespace GAM.Forms.Profile.Etebarat.Review
{
    partial class dlgAddRequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAddRequest));
            this.pnlSave = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.pnlSearch = new System.Windows.Forms.GroupBox();
            this.lblPleaseWait = new System.Windows.Forms.Label();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtRequestId = new DevExpress.XtraEditors.TextEdit();
            this.lblRequestId = new System.Windows.Forms.Label();
            this.pnlRequestInfo = new System.Windows.Forms.GroupBox();
            this.btnFilesList = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCoverNo = new System.Windows.Forms.TextBox();
            this.txtFileId = new System.Windows.Forms.TextBox();
            this.txtCustomerId = new DevExpress.XtraEditors.TextEdit();
            this.txtReferralDate = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.cboBails1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblBails = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBailsDetail = new System.Windows.Forms.TextBox();
            this.txtFacilityName = new System.Windows.Forms.TextBox();
            this.cboPersonType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblRequestType = new System.Windows.Forms.Label();
            this.lblFacilityID = new System.Windows.Forms.Label();
            this.btnFacilitysList = new DevExpress.XtraEditors.SimpleButton();
            this.cboRequestType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtFacilityID = new System.Windows.Forms.TextBox();
            this.lblRequestAmount = new System.Windows.Forms.Label();
            this.txtRequestAmount = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomerName = new System.Windows.Forms.CustomControls.FilterdTextBox();
            this.btnBranchesInfo = new DevExpress.XtraEditors.SimpleButton();
            this.lblFileID = new System.Windows.Forms.Label();
            this.lblBranchName = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.lblBranchID = new System.Windows.Forms.Label();
            this.txtBranchId = new System.Windows.Forms.TextBox();
            this.pnlSave.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRequestId.Properties)).BeginInit();
            this.pnlRequestInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferralDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBails1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPersonType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRequestType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRequestAmount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSave
            // 
            this.pnlSave.Controls.Add(this.btnSave);
            this.pnlSave.Controls.Add(this.btnCancel);
            this.pnlSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSave.Enabled = false;
            this.pnlSave.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlSave.Location = new System.Drawing.Point(0, 325);
            this.pnlSave.Name = "pnlSave";
            this.pnlSave.Size = new System.Drawing.Size(440, 36);
            this.pnlSave.TabIndex = 187;
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(115, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(322, 29);
            this.btnSave.TabIndex = 0;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "تایید اطلاعات و افزودن به لیست پیشنهادات";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(6, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 29);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.lblPleaseWait);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.txtRequestId);
            this.pnlSearch.Controls.Add(this.lblRequestId);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlSearch.Size = new System.Drawing.Size(440, 49);
            this.pnlSearch.TabIndex = 202;
            this.pnlSearch.TabStop = false;
            // 
            // lblPleaseWait
            // 
            this.lblPleaseWait.AutoSize = true;
            this.lblPleaseWait.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPleaseWait.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblPleaseWait.Location = new System.Drawing.Point(9, 22);
            this.lblPleaseWait.Name = "lblPleaseWait";
            this.lblPleaseWait.Size = new System.Drawing.Size(111, 13);
            this.lblPleaseWait.TabIndex = 35;
            this.lblPleaseWait.Text = "لطفاً کمی صبر کنید ...";
            this.lblPleaseWait.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(124, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(81, 25);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtRequestId
            // 
            this.txtRequestId.EditValue = "";
            this.txtRequestId.Location = new System.Drawing.Point(211, 16);
            this.txtRequestId.Name = "txtRequestId";
            this.txtRequestId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequestId.Properties.Appearance.Options.UseFont = true;
            this.txtRequestId.Properties.Appearance.Options.UseTextOptions = true;
            this.txtRequestId.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtRequestId.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtRequestId.Properties.Mask.EditMask = "\\d+";
            this.txtRequestId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtRequestId.Properties.MaxLength = 15;
            this.txtRequestId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRequestId.Size = new System.Drawing.Size(137, 24);
            this.txtRequestId.TabIndex = 0;
            this.txtRequestId.EditValueChanged += new System.EventHandler(this.txtRequestID_EditValueChanged);
            this.txtRequestId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // lblRequestId
            // 
            this.lblRequestId.AutoSize = true;
            this.lblRequestId.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRequestId.ForeColor = System.Drawing.Color.Black;
            this.lblRequestId.Location = new System.Drawing.Point(350, 21);
            this.lblRequestId.Name = "lblRequestId";
            this.lblRequestId.Size = new System.Drawing.Size(77, 13);
            this.lblRequestId.TabIndex = 34;
            this.lblRequestId.Text = "شماره پیشنهاد";
            // 
            // pnlRequestInfo
            // 
            this.pnlRequestInfo.Controls.Add(this.btnFilesList);
            this.pnlRequestInfo.Controls.Add(this.label1);
            this.pnlRequestInfo.Controls.Add(this.txtCoverNo);
            this.pnlRequestInfo.Controls.Add(this.txtFileId);
            this.pnlRequestInfo.Controls.Add(this.txtCustomerId);
            this.pnlRequestInfo.Controls.Add(this.txtReferralDate);
            this.pnlRequestInfo.Controls.Add(this.label2);
            this.pnlRequestInfo.Controls.Add(this.lblCustomerId);
            this.pnlRequestInfo.Controls.Add(this.cboBails1);
            this.pnlRequestInfo.Controls.Add(this.lblBails);
            this.pnlRequestInfo.Controls.Add(this.label4);
            this.pnlRequestInfo.Controls.Add(this.txtBailsDetail);
            this.pnlRequestInfo.Controls.Add(this.txtFacilityName);
            this.pnlRequestInfo.Controls.Add(this.cboPersonType);
            this.pnlRequestInfo.Controls.Add(this.lblRequestType);
            this.pnlRequestInfo.Controls.Add(this.lblFacilityID);
            this.pnlRequestInfo.Controls.Add(this.btnFacilitysList);
            this.pnlRequestInfo.Controls.Add(this.cboRequestType);
            this.pnlRequestInfo.Controls.Add(this.txtFacilityID);
            this.pnlRequestInfo.Controls.Add(this.lblRequestAmount);
            this.pnlRequestInfo.Controls.Add(this.txtRequestAmount);
            this.pnlRequestInfo.Controls.Add(this.txtCustomerName);
            this.pnlRequestInfo.Controls.Add(this.btnBranchesInfo);
            this.pnlRequestInfo.Controls.Add(this.lblFileID);
            this.pnlRequestInfo.Controls.Add(this.lblBranchName);
            this.pnlRequestInfo.Controls.Add(this.lblCurrency);
            this.pnlRequestInfo.Controls.Add(this.lblBranchID);
            this.pnlRequestInfo.Controls.Add(this.txtBranchId);
            this.pnlRequestInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRequestInfo.Enabled = false;
            this.pnlRequestInfo.Location = new System.Drawing.Point(0, 49);
            this.pnlRequestInfo.Name = "pnlRequestInfo";
            this.pnlRequestInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlRequestInfo.Size = new System.Drawing.Size(440, 276);
            this.pnlRequestInfo.TabIndex = 203;
            this.pnlRequestInfo.TabStop = false;
            this.pnlRequestInfo.Text = "اطلاعات پیشنهاد";
            // 
            // btnFilesList
            // 
            this.btnFilesList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFilesList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilesList.Enabled = false;
            this.btnFilesList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFilesList.ImageOptions.Image")));
            this.btnFilesList.Location = new System.Drawing.Point(21, 96);
            this.btnFilesList.Name = "btnFilesList";
            this.btnFilesList.Size = new System.Drawing.Size(25, 22);
            this.btnFilesList.TabIndex = 0;
            this.btnFilesList.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(350, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 206;
            this.label1.Text = "نوع مشتری";
            // 
            // txtCoverNo
            // 
            this.txtCoverNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoverNo.Location = new System.Drawing.Point(324, 96);
            this.txtCoverNo.Name = "txtCoverNo";
            this.txtCoverNo.ReadOnly = true;
            this.txtCoverNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCoverNo.Size = new System.Drawing.Size(25, 22);
            this.txtCoverNo.TabIndex = 0;
            this.txtCoverNo.TabStop = false;
            this.txtCoverNo.Tag = "";
            this.txtCoverNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFileId
            // 
            this.txtFileId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileId.Location = new System.Drawing.Point(275, 96);
            this.txtFileId.Name = "txtFileId";
            this.txtFileId.ReadOnly = true;
            this.txtFileId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFileId.Size = new System.Drawing.Size(47, 22);
            this.txtFileId.TabIndex = 0;
            this.txtFileId.TabStop = false;
            this.txtFileId.Tag = "";
            this.txtFileId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.EditValue = "";
            this.txtCustomerId.Location = new System.Drawing.Point(213, 44);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.txtCustomerId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerId.Properties.Appearance.Options.UseBackColor = true;
            this.txtCustomerId.Properties.Appearance.Options.UseFont = true;
            this.txtCustomerId.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCustomerId.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtCustomerId.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtCustomerId.Properties.Mask.EditMask = "\\d+";
            this.txtCustomerId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtCustomerId.Properties.MaxLength = 12;
            this.txtCustomerId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCustomerId.Size = new System.Drawing.Size(137, 22);
            this.txtCustomerId.TabIndex = 3;
            this.txtCustomerId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // txtReferralDate
            // 
            this.txtReferralDate.EditValue = "";
            this.txtReferralDate.Location = new System.Drawing.Point(253, 19);
            this.txtReferralDate.Name = "txtReferralDate";
            this.txtReferralDate.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.txtReferralDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferralDate.Properties.Appearance.Options.UseBackColor = true;
            this.txtReferralDate.Properties.Appearance.Options.UseFont = true;
            this.txtReferralDate.Properties.Mask.EditMask = "9999/99/99";
            this.txtReferralDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtReferralDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtReferralDate.Properties.MaxLength = 15;
            this.txtReferralDate.Properties.NullText = "0";
            this.txtReferralDate.Properties.ReadOnly = true;
            this.txtReferralDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtReferralDate.Size = new System.Drawing.Size(97, 22);
            this.txtReferralDate.TabIndex = 2;
            this.txtReferralDate.TabStop = false;
            this.txtReferralDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(350, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 203;
            this.label2.Text = "تاریخ ارجاع";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerId.Location = new System.Drawing.Point(350, 50);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(77, 13);
            this.lblCustomerId.TabIndex = 201;
            this.lblCustomerId.Text = "شماره مشتری";
            // 
            // cboBails1
            // 
            this.cboBails1.Location = new System.Drawing.Point(212, 223);
            this.cboBails1.Name = "cboBails1";
            this.cboBails1.Properties.AllowMouseWheel = false;
            this.cboBails1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBails1.Properties.Appearance.Options.UseFont = true;
            this.cboBails1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cboBails1.Properties.Items.AddRange(new object[] {
            "",
            "سپرده",
            "ملک",
            "سفته",
            "قرارداد",
            "سپرده + ملک",
            "سپرده + سفته",
            "سپرده + قرارداد",
            "ملک + سفته",
            "ملک + قرارداد",
            "سپرده + ملک + سفته",
            "سپرده + ملک + قرارداد"});
            this.cboBails1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboBails1.Size = new System.Drawing.Size(137, 22);
            this.cboBails1.TabIndex = 10;
            this.cboBails1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // lblBails
            // 
            this.lblBails.AutoSize = true;
            this.lblBails.Location = new System.Drawing.Point(351, 228);
            this.lblBails.Name = "lblBails";
            this.lblBails.Size = new System.Drawing.Size(81, 13);
            this.lblBails.TabIndex = 199;
            this.lblBails.Text = "وثایق پیشنهادی";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(351, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 197;
            this.label4.Text = "شرح وثایق";
            // 
            // txtBailsDetail
            // 
            this.txtBailsDetail.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtBailsDetail.Location = new System.Drawing.Point(21, 248);
            this.txtBailsDetail.Name = "txtBailsDetail";
            this.txtBailsDetail.Size = new System.Drawing.Size(328, 22);
            this.txtBailsDetail.TabIndex = 11;
            this.txtBailsDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // txtFacilityName
            // 
            this.txtFacilityName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFacilityName.Location = new System.Drawing.Point(49, 148);
            this.txtFacilityName.Name = "txtFacilityName";
            this.txtFacilityName.ReadOnly = true;
            this.txtFacilityName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFacilityName.Size = new System.Drawing.Size(250, 22);
            this.txtFacilityName.TabIndex = 7;
            this.txtFacilityName.Tag = "";
            this.txtFacilityName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // cboPersonType
            // 
            this.cboPersonType.Location = new System.Drawing.Point(274, 70);
            this.cboPersonType.Name = "cboPersonType";
            this.cboPersonType.Properties.AllowMouseWheel = false;
            this.cboPersonType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPersonType.Properties.Appearance.Options.UseFont = true;
            this.cboPersonType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPersonType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboPersonType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cboPersonType.Properties.Items.AddRange(new object[] {
            "حقیقی",
            "حقوقی"});
            this.cboPersonType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboPersonType.Size = new System.Drawing.Size(76, 22);
            this.cboPersonType.TabIndex = 4;
            this.cboPersonType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // lblRequestType
            // 
            this.lblRequestType.AutoSize = true;
            this.lblRequestType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRequestType.Location = new System.Drawing.Point(351, 177);
            this.lblRequestType.Name = "lblRequestType";
            this.lblRequestType.Size = new System.Drawing.Size(62, 13);
            this.lblRequestType.TabIndex = 136;
            this.lblRequestType.Text = "نوع پیشنهاد";
            // 
            // lblFacilityID
            // 
            this.lblFacilityID.AutoSize = true;
            this.lblFacilityID.Location = new System.Drawing.Point(351, 152);
            this.lblFacilityID.Name = "lblFacilityID";
            this.lblFacilityID.Size = new System.Drawing.Size(67, 13);
            this.lblFacilityID.TabIndex = 140;
            this.lblFacilityID.Text = "نوع تسهیلات";
            // 
            // btnFacilitysList
            // 
            this.btnFacilitysList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFacilitysList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFacilitysList.ImageOptions.Image")));
            this.btnFacilitysList.Location = new System.Drawing.Point(21, 148);
            this.btnFacilitysList.Name = "btnFacilitysList";
            this.btnFacilitysList.Size = new System.Drawing.Size(25, 22);
            this.btnFacilitysList.TabIndex = 0;
            this.btnFacilitysList.TabStop = false;
            this.btnFacilitysList.Click += new System.EventHandler(this.btnFacilitysList_Click);
            // 
            // cboRequestType
            // 
            this.cboRequestType.Location = new System.Drawing.Point(211, 173);
            this.cboRequestType.Name = "cboRequestType";
            this.cboRequestType.Properties.AllowMouseWheel = false;
            this.cboRequestType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRequestType.Properties.Appearance.Options.UseFont = true;
            this.cboRequestType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRequestType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboRequestType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cboRequestType.Properties.Items.AddRange(new object[] {
            "",
            "موردی",
            "حد اعتباری",
            "سقف اعتباری",
            "مصوبه خاص",
            "تقسیط",
            "تمدید",
            "تغییر وثیقه",
            "تبدیل",
            "متمم",
            "تخفیف کارمزد",
            "بازدید"});
            this.cboRequestType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboRequestType.Size = new System.Drawing.Size(138, 22);
            this.cboRequestType.TabIndex = 8;
            this.cboRequestType.SelectedIndexChanged += new System.EventHandler(this.cboRequestType_SelectedIndexChanged);
            this.cboRequestType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // txtFacilityID
            // 
            this.txtFacilityID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFacilityID.Location = new System.Drawing.Point(303, 148);
            this.txtFacilityID.Name = "txtFacilityID";
            this.txtFacilityID.ReadOnly = true;
            this.txtFacilityID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFacilityID.Size = new System.Drawing.Size(46, 22);
            this.txtFacilityID.TabIndex = 0;
            this.txtFacilityID.TabStop = false;
            this.txtFacilityID.Tag = "";
            this.txtFacilityID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblRequestAmount
            // 
            this.lblRequestAmount.AutoSize = true;
            this.lblRequestAmount.Location = new System.Drawing.Point(351, 202);
            this.lblRequestAmount.Name = "lblRequestAmount";
            this.lblRequestAmount.Size = new System.Drawing.Size(77, 13);
            this.lblRequestAmount.TabIndex = 142;
            this.lblRequestAmount.Text = "مبلغ پیشنهادی";
            // 
            // txtRequestAmount
            // 
            this.txtRequestAmount.Location = new System.Drawing.Point(211, 198);
            this.txtRequestAmount.Name = "txtRequestAmount";
            this.txtRequestAmount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequestAmount.Properties.Appearance.Options.UseFont = true;
            this.txtRequestAmount.Properties.Mask.EditMask = "n0";
            this.txtRequestAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtRequestAmount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtRequestAmount.Properties.MaxLength = 15;
            this.txtRequestAmount.Properties.NullText = "0";
            this.txtRequestAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRequestAmount.Size = new System.Drawing.Size(138, 22);
            this.txtRequestAmount.TabIndex = 9;
            this.txtRequestAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.AcceptedChars = ".-()";
            this.txtCustomerName.BackColor = System.Drawing.SystemColors.Window;
            this.txtCustomerName.BackColorOnErr = System.Drawing.Color.Pink;
            this.txtCustomerName.BackColorUsed = System.Drawing.SystemColors.Window;
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.FilterChars = System.Windows.Forms.CustomControls.FilterdTextBox.FilteredEnum.PersianChars;
            this.txtCustomerName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(49, 96);
            this.txtCustomerName.MaxLength = 100;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PromptFont = null;
            this.txtCustomerName.PromptForeColor = System.Drawing.SystemColors.Control;
            this.txtCustomerName.PromptText = "";
            this.txtCustomerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustomerName.SelectAllFocused = true;
            this.txtCustomerName.Size = new System.Drawing.Size(223, 22);
            this.txtCustomerName.TabIndex = 5;
            this.txtCustomerName.TextLanguage = System.Windows.Forms.CustomControls.FilterdTextBox.LanguageEnum.Farsi;
            this.txtCustomerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // btnBranchesInfo
            // 
            this.btnBranchesInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBranchesInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBranchesInfo.ImageOptions.Image")));
            this.btnBranchesInfo.Location = new System.Drawing.Point(274, 123);
            this.btnBranchesInfo.Name = "btnBranchesInfo";
            this.btnBranchesInfo.Size = new System.Drawing.Size(25, 22);
            this.btnBranchesInfo.TabIndex = 0;
            this.btnBranchesInfo.TabStop = false;
            this.btnBranchesInfo.Click += new System.EventHandler(this.btnBranchesInfo_Click);
            // 
            // lblFileID
            // 
            this.lblFileID.AutoSize = true;
            this.lblFileID.Location = new System.Drawing.Point(350, 100);
            this.lblFileID.Name = "lblFileID";
            this.lblFileID.Size = new System.Drawing.Size(62, 13);
            this.lblFileID.TabIndex = 185;
            this.lblFileID.Text = "نام متقاضی";
            // 
            // lblBranchName
            // 
            this.lblBranchName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblBranchName.ForeColor = System.Drawing.Color.Black;
            this.lblBranchName.Location = new System.Drawing.Point(18, 126);
            this.lblBranchName.Name = "lblBranchName";
            this.lblBranchName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBranchName.Size = new System.Drawing.Size(250, 17);
            this.lblBranchName.TabIndex = 146;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(151, 202);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCurrency.Size = new System.Drawing.Size(57, 13);
            this.lblCurrency.TabIndex = 181;
            this.lblCurrency.Text = "میلیون ریال";
            // 
            // lblBranchID
            // 
            this.lblBranchID.AutoSize = true;
            this.lblBranchID.Location = new System.Drawing.Point(351, 128);
            this.lblBranchID.Name = "lblBranchID";
            this.lblBranchID.Size = new System.Drawing.Size(48, 13);
            this.lblBranchID.TabIndex = 145;
            this.lblBranchID.Text = "کد شعبه";
            // 
            // txtBranchId
            // 
            this.txtBranchId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranchId.Location = new System.Drawing.Point(303, 123);
            this.txtBranchId.Name = "txtBranchId";
            this.txtBranchId.ReadOnly = true;
            this.txtBranchId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBranchId.Size = new System.Drawing.Size(46, 22);
            this.txtBranchId.TabIndex = 6;
            this.txtBranchId.Tag = "";
            this.txtBranchId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBranchId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // dlgAddRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 361);
            this.Controls.Add(this.pnlRequestInfo);
            this.Controls.Add(this.pnlSave);
            this.Controls.Add(this.pnlSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgAddRequest";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.pnlSave.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRequestId.Properties)).EndInit();
            this.pnlRequestInfo.ResumeLayout(false);
            this.pnlRequestInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferralDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBails1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPersonType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRequestType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRequestAmount.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlSave;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.GroupBox pnlSearch;
        private System.Windows.Forms.GroupBox pnlRequestInfo;
        private System.Windows.Forms.Label lblCustomerId;
        public DevExpress.XtraEditors.ComboBoxEdit cboBails1;
        private System.Windows.Forms.Label lblBails;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBailsDetail;
        public System.Windows.Forms.TextBox txtFacilityName;
        public DevExpress.XtraEditors.ComboBoxEdit cboPersonType;
        private System.Windows.Forms.Label lblRequestId;
        private System.Windows.Forms.Label lblRequestType;
        private System.Windows.Forms.Label lblFacilityID;
        private DevExpress.XtraEditors.SimpleButton btnFacilitysList;
        public DevExpress.XtraEditors.ComboBoxEdit cboRequestType;
        public System.Windows.Forms.TextBox txtFacilityID;
        private System.Windows.Forms.Label lblRequestAmount;
        public DevExpress.XtraEditors.TextEdit txtRequestAmount;
        public System.Windows.Forms.CustomControls.FilterdTextBox txtCustomerName;
        private DevExpress.XtraEditors.SimpleButton btnBranchesInfo;
        private System.Windows.Forms.Label lblFileID;
        public System.Windows.Forms.Label lblBranchName;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Label lblBranchID;
        public System.Windows.Forms.TextBox txtBranchId;
        public DevExpress.XtraEditors.TextEdit txtRequestId;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private System.Windows.Forms.Label lblPleaseWait;
        private DevExpress.XtraEditors.TextEdit txtReferralDate;
        private System.Windows.Forms.Label label2;
        public DevExpress.XtraEditors.TextEdit txtCustomerId;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtCoverNo;
        public System.Windows.Forms.TextBox txtFileId;
        private DevExpress.XtraEditors.SimpleButton btnFilesList;
    }
}