namespace GAM.Forms.Profile.Etebarat.AddExpertReport
{
    partial class frmAddExpertReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddExpertReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtFileId = new System.Windows.Forms.TextBox();
            this.btnFilesList = new DevExpress.XtraEditors.SimpleButton();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblFileID = new System.Windows.Forms.Label();
            this.txtExpertId = new System.Windows.Forms.TextBox();
            this.lblExpertName = new System.Windows.Forms.Label();
            this.lblExpert = new System.Windows.Forms.Label();
            this.btnUsersInfo = new DevExpress.XtraEditors.SimpleButton();
            this.pnlCustomerInfo = new System.Windows.Forms.GroupBox();
            this.txtCustomerId = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.chkIsLegalPerson = new System.Windows.Forms.CheckBox();
            this.txtCoverNo = new System.Windows.Forms.TextBox();
            this.txtBranchId = new System.Windows.Forms.TextBox();
            this.lblBranchID = new System.Windows.Forms.Label();
            this.lblBranchName = new System.Windows.Forms.Label();
            this.btnBranchesList = new DevExpress.XtraEditors.SimpleButton();
            this.pnlSave = new System.Windows.Forms.Panel();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.pnlInput = new System.Windows.Forms.GroupBox();
            this.rgInputType = new DevExpress.XtraEditors.RadioGroup();
            this.pnlSearch = new System.Windows.Forms.GroupBox();
            this.txtRequestId = new DevExpress.XtraEditors.TextEdit();
            this.lblIdRequestId = new System.Windows.Forms.Label();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.pnlExpertInfo = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboReferralType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblRequestType = new System.Windows.Forms.Label();
            this.lblDate1 = new System.Windows.Forms.Label();
            this.txtReferralDate = new Atf.UI.DateTimeSelector();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.grpRequests = new System.Windows.Forms.GroupBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.colCheckbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReviewNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequestId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequestType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequestAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.pnlCustomerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerId.Properties)).BeginInit();
            this.pnlSave.SuspendLayout();
            this.pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgInputType.Properties)).BeginInit();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRequestId.Properties)).BeginInit();
            this.pnlExpertInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboReferralType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            this.grpRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFileId
            // 
            this.txtFileId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileId.Location = new System.Drawing.Point(400, 45);
            this.txtFileId.Name = "txtFileId";
            this.txtFileId.ReadOnly = true;
            this.txtFileId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFileId.Size = new System.Drawing.Size(53, 22);
            this.txtFileId.TabIndex = 7;
            this.txtFileId.TabStop = false;
            this.txtFileId.Tag = "";
            this.txtFileId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFileId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // btnFilesList
            // 
            this.btnFilesList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFilesList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilesList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFilesList.ImageOptions.Image")));
            this.btnFilesList.Location = new System.Drawing.Point(16, 45);
            this.btnFilesList.Name = "btnFilesList";
            this.btnFilesList.Size = new System.Drawing.Size(25, 22);
            this.btnFilesList.TabIndex = 9;
            this.btnFilesList.Click += new System.EventHandler(this.btnShowAllFiles_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(47, 45);
            this.txtCustomerName.MaxLength = 100;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustomerName.Size = new System.Drawing.Size(350, 22);
            this.txtCustomerName.TabIndex = 8;
            this.txtCustomerName.TabStop = false;
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            this.txtCustomerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // lblFileID
            // 
            this.lblFileID.AutoSize = true;
            this.lblFileID.Location = new System.Drawing.Point(479, 49);
            this.lblFileID.Name = "lblFileID";
            this.lblFileID.Size = new System.Drawing.Size(60, 13);
            this.lblFileID.TabIndex = 192;
            this.lblFileID.Text = "نام مشتری";
            // 
            // txtExpertId
            // 
            this.txtExpertId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpertId.Location = new System.Drawing.Point(416, 17);
            this.txtExpertId.Name = "txtExpertId";
            this.txtExpertId.ReadOnly = true;
            this.txtExpertId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtExpertId.Size = new System.Drawing.Size(62, 22);
            this.txtExpertId.TabIndex = 11;
            this.txtExpertId.TabStop = false;
            this.txtExpertId.Tag = "";
            this.txtExpertId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // lblExpertName
            // 
            this.lblExpertName.BackColor = System.Drawing.Color.Transparent;
            this.lblExpertName.ForeColor = System.Drawing.Color.Black;
            this.lblExpertName.Location = new System.Drawing.Point(217, 20);
            this.lblExpertName.Name = "lblExpertName";
            this.lblExpertName.Size = new System.Drawing.Size(166, 17);
            this.lblExpertName.TabIndex = 195;
            // 
            // lblExpert
            // 
            this.lblExpert.AutoSize = true;
            this.lblExpert.ForeColor = System.Drawing.Color.Black;
            this.lblExpert.Location = new System.Drawing.Point(479, 21);
            this.lblExpert.Name = "lblExpert";
            this.lblExpert.Size = new System.Drawing.Size(66, 13);
            this.lblExpert.TabIndex = 194;
            this.lblExpert.Text = "نام کارشناس";
            // 
            // btnUsersInfo
            // 
            this.btnUsersInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUsersInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUsersInfo.ImageOptions.Image")));
            this.btnUsersInfo.Location = new System.Drawing.Point(389, 17);
            this.btnUsersInfo.Name = "btnUsersInfo";
            this.btnUsersInfo.Size = new System.Drawing.Size(25, 22);
            this.btnUsersInfo.TabIndex = 12;
            this.btnUsersInfo.Click += new System.EventHandler(this.btnUsersInfo_Click);
            // 
            // pnlCustomerInfo
            // 
            this.pnlCustomerInfo.Controls.Add(this.txtCustomerId);
            this.pnlCustomerInfo.Controls.Add(this.label1);
            this.pnlCustomerInfo.Controls.Add(this.chkIsLegalPerson);
            this.pnlCustomerInfo.Controls.Add(this.txtCoverNo);
            this.pnlCustomerInfo.Controls.Add(this.txtBranchId);
            this.pnlCustomerInfo.Controls.Add(this.lblBranchID);
            this.pnlCustomerInfo.Controls.Add(this.lblBranchName);
            this.pnlCustomerInfo.Controls.Add(this.btnBranchesList);
            this.pnlCustomerInfo.Controls.Add(this.txtFileId);
            this.pnlCustomerInfo.Controls.Add(this.lblFileID);
            this.pnlCustomerInfo.Controls.Add(this.btnFilesList);
            this.pnlCustomerInfo.Controls.Add(this.txtCustomerName);
            this.pnlCustomerInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCustomerInfo.Enabled = false;
            this.pnlCustomerInfo.Location = new System.Drawing.Point(2, 273);
            this.pnlCustomerInfo.Name = "pnlCustomerInfo";
            this.pnlCustomerInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlCustomerInfo.Size = new System.Drawing.Size(562, 98);
            this.pnlCustomerInfo.TabIndex = 2;
            this.pnlCustomerInfo.TabStop = false;
            this.pnlCustomerInfo.Text = "اطلاعات مشتری";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.EditValue = "";
            this.txtCustomerId.Location = new System.Drawing.Point(321, 71);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtCustomerId.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.txtCustomerId.Properties.Appearance.Options.UseFont = true;
            this.txtCustomerId.Properties.Appearance.Options.UseForeColor = true;
            this.txtCustomerId.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCustomerId.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtCustomerId.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtCustomerId.Properties.Mask.EditMask = "\\d+";
            this.txtCustomerId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtCustomerId.Properties.MaxLength = 12;
            this.txtCustomerId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCustomerId.Size = new System.Drawing.Size(157, 22);
            this.txtCustomerId.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(478, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 209;
            this.label1.Text = "شماره مشتری";
            // 
            // chkIsLegalPerson
            // 
            this.chkIsLegalPerson.AutoSize = true;
            this.chkIsLegalPerson.Location = new System.Drawing.Point(47, 72);
            this.chkIsLegalPerson.Name = "chkIsLegalPerson";
            this.chkIsLegalPerson.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsLegalPerson.Size = new System.Drawing.Size(60, 17);
            this.chkIsLegalPerson.TabIndex = 0;
            this.chkIsLegalPerson.TabStop = false;
            this.chkIsLegalPerson.Text = "حقوقی";
            this.chkIsLegalPerson.UseVisualStyleBackColor = true;
            // 
            // txtCoverNo
            // 
            this.txtCoverNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoverNo.Location = new System.Drawing.Point(455, 45);
            this.txtCoverNo.Name = "txtCoverNo";
            this.txtCoverNo.ReadOnly = true;
            this.txtCoverNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCoverNo.Size = new System.Drawing.Size(23, 22);
            this.txtCoverNo.TabIndex = 6;
            this.txtCoverNo.TabStop = false;
            this.txtCoverNo.Tag = "";
            this.txtCoverNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBranchId
            // 
            this.txtBranchId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranchId.Location = new System.Drawing.Point(430, 20);
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
            this.lblBranchID.Location = new System.Drawing.Point(478, 25);
            this.lblBranchID.Name = "lblBranchID";
            this.lblBranchID.Size = new System.Drawing.Size(48, 13);
            this.lblBranchID.TabIndex = 204;
            this.lblBranchID.Text = "کد شعبه";
            // 
            // lblBranchName
            // 
            this.lblBranchName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblBranchName.ForeColor = System.Drawing.Color.Black;
            this.lblBranchName.Location = new System.Drawing.Point(206, 23);
            this.lblBranchName.Name = "lblBranchName";
            this.lblBranchName.Size = new System.Drawing.Size(188, 17);
            this.lblBranchName.TabIndex = 205;
            // 
            // btnBranchesList
            // 
            this.btnBranchesList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBranchesList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBranchesList.ImageOptions.Image")));
            this.btnBranchesList.Location = new System.Drawing.Point(400, 20);
            this.btnBranchesList.Name = "btnBranchesList";
            this.btnBranchesList.Size = new System.Drawing.Size(25, 22);
            this.btnBranchesList.TabIndex = 5;
            this.btnBranchesList.Click += new System.EventHandler(this.btnBranchesList_Click);
            // 
            // pnlSave
            // 
            this.pnlSave.Controls.Add(this.btnSave);
            this.pnlSave.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSave.Location = new System.Drawing.Point(2, 441);
            this.pnlSave.Name = "pnlSave";
            this.pnlSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlSave.Size = new System.Drawing.Size(562, 35);
            this.pnlSave.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(196, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(178, 29);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "ثبت گزارش کارشناسی";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlInput
            // 
            this.pnlInput.Controls.Add(this.rgInputType);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInput.Location = new System.Drawing.Point(2, 2);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlInput.Size = new System.Drawing.Size(562, 90);
            this.pnlInput.TabIndex = 0;
            this.pnlInput.TabStop = false;
            this.pnlInput.Text = "روش ورودی";
            // 
            // rgInputType
            // 
            this.rgInputType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgInputType.Location = new System.Drawing.Point(3, 17);
            this.rgInputType.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.rgInputType.Name = "rgInputType";
            this.rgInputType.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgInputType.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.rgInputType.Properties.Appearance.Options.UseBackColor = true;
            this.rgInputType.Properties.Appearance.Options.UseForeColor = true;
            this.rgInputType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgInputType.Properties.Columns = 1;
            this.rgInputType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "پیشنهاد سیستمی"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "فرم بررسی"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "درخواست شعبه (بدون پیشنهاد سیستمی)")});
            this.rgInputType.Size = new System.Drawing.Size(556, 70);
            this.rgInputType.TabIndex = 0;
            this.rgInputType.SelectedIndexChanged += new System.EventHandler(this.rgInputType_SelectedIndexChanged);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.txtRequestId);
            this.pnlSearch.Controls.Add(this.lblIdRequestId);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(2, 92);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(562, 47);
            this.pnlSearch.TabIndex = 1;
            this.pnlSearch.TabStop = false;
            // 
            // txtRequestId
            // 
            this.txtRequestId.EditValue = "";
            this.txtRequestId.Location = new System.Drawing.Point(290, 15);
            this.txtRequestId.Name = "txtRequestId";
            this.txtRequestId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtRequestId.Properties.Appearance.Options.UseFont = true;
            this.txtRequestId.Properties.Appearance.Options.UseTextOptions = true;
            this.txtRequestId.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtRequestId.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtRequestId.Properties.Mask.EditMask = "\\d+";
            this.txtRequestId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtRequestId.Properties.MaxLength = 15;
            this.txtRequestId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRequestId.Size = new System.Drawing.Size(188, 26);
            this.txtRequestId.TabIndex = 1;
            this.txtRequestId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // lblIdRequestId
            // 
            this.lblIdRequestId.AutoSize = true;
            this.lblIdRequestId.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblIdRequestId.ForeColor = System.Drawing.Color.Black;
            this.lblIdRequestId.Location = new System.Drawing.Point(479, 21);
            this.lblIdRequestId.Name = "lblIdRequestId";
            this.lblIdRequestId.Size = new System.Drawing.Size(66, 13);
            this.lblIdRequestId.TabIndex = 32;
            this.lblIdRequestId.Text = "ش.پیشنهاد";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(217, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 26);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlExpertInfo
            // 
            this.pnlExpertInfo.Controls.Add(this.label2);
            this.pnlExpertInfo.Controls.Add(this.cboReferralType);
            this.pnlExpertInfo.Controls.Add(this.lblRequestType);
            this.pnlExpertInfo.Controls.Add(this.lblDate1);
            this.pnlExpertInfo.Controls.Add(this.txtReferralDate);
            this.pnlExpertInfo.Controls.Add(this.txtExpertId);
            this.pnlExpertInfo.Controls.Add(this.lblExpertName);
            this.pnlExpertInfo.Controls.Add(this.lblExpert);
            this.pnlExpertInfo.Controls.Add(this.btnUsersInfo);
            this.pnlExpertInfo.Controls.Add(this.comboBoxEdit1);
            this.pnlExpertInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlExpertInfo.Location = new System.Drawing.Point(2, 371);
            this.pnlExpertInfo.Name = "pnlExpertInfo";
            this.pnlExpertInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlExpertInfo.Size = new System.Drawing.Size(562, 70);
            this.pnlExpertInfo.TabIndex = 3;
            this.pnlExpertInfo.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(482, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 201;
            this.label2.Text = "وضعیت";
            // 
            // cboReferralType
            // 
            this.cboReferralType.EditValue = "گزارش کارشناسی";
            this.cboReferralType.Location = new System.Drawing.Point(26, 42);
            this.cboReferralType.Name = "cboReferralType";
            this.cboReferralType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cboReferralType.Properties.Appearance.Options.UseFont = true;
            this.cboReferralType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReferralType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboReferralType.Properties.AutoHeight = false;
            this.cboReferralType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cboReferralType.Properties.Items.AddRange(new object[] {
            "گزارش کارشناسی",
            "گزارش بازدید",
            "ارسال به تهران"});
            this.cboReferralType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboReferralType.Size = new System.Drawing.Size(146, 24);
            this.cboReferralType.TabIndex = 14;
            // 
            // lblRequestType
            // 
            this.lblRequestType.AutoSize = true;
            this.lblRequestType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRequestType.Location = new System.Drawing.Point(172, 47);
            this.lblRequestType.Name = "lblRequestType";
            this.lblRequestType.Size = new System.Drawing.Size(49, 13);
            this.lblRequestType.TabIndex = 199;
            this.lblRequestType.Text = "نوع ارجاع";
            // 
            // lblDate1
            // 
            this.lblDate1.AutoSize = true;
            this.lblDate1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblDate1.Location = new System.Drawing.Point(172, 21);
            this.lblDate1.Margin = new System.Windows.Forms.Padding(3, 12, 3, 0);
            this.lblDate1.Name = "lblDate1";
            this.lblDate1.Size = new System.Drawing.Size(55, 13);
            this.lblDate1.TabIndex = 197;
            this.lblDate1.Text = "تاریخ ارجاع";
            // 
            // txtReferralDate
            // 
            this.txtReferralDate.CustomFormat = "dd/MM/yyyy";
            this.txtReferralDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferralDate.Format = Atf.UI.DateTimeSelectorFormat.Custom;
            this.txtReferralDate.Location = new System.Drawing.Point(60, 15);
            this.txtReferralDate.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.txtReferralDate.Name = "txtReferralDate";
            this.txtReferralDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtReferralDate.Size = new System.Drawing.Size(112, 24);
            this.txtReferralDate.TabIndex = 13;
            this.txtReferralDate.UsePersianFormat = true;
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.EditValue = "بررسی";
            this.comboBoxEdit1.Enabled = false;
            this.comboBoxEdit1.Location = new System.Drawing.Point(389, 42);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.comboBoxEdit1.Properties.Appearance.Options.UseFont = true;
            this.comboBoxEdit1.Properties.AutoHeight = false;
            this.comboBoxEdit1.Size = new System.Drawing.Size(89, 24);
            this.comboBoxEdit1.TabIndex = 200;
            // 
            // grpRequests
            // 
            this.grpRequests.Controls.Add(this.dataGrid);
            this.grpRequests.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRequests.Location = new System.Drawing.Point(2, 139);
            this.grpRequests.Name = "grpRequests";
            this.grpRequests.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpRequests.Size = new System.Drawing.Size(562, 134);
            this.grpRequests.TabIndex = 5;
            this.grpRequests.TabStop = false;
            this.grpRequests.Text = "لیست پیشنهادات شعبه";
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToOrderColumns = true;
            this.dataGrid.AllowUserToResizeColumns = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheckbox,
            this.colSerial,
            this.colReviewNo,
            this.colRequestId,
            this.colRequestType,
            this.colCustomerName,
            this.colRequestAmount});
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(3, 17);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(556, 114);
            this.dataGrid.TabIndex = 5;
            // 
            // colCheckbox
            // 
            this.colCheckbox.HeaderText = "";
            this.colCheckbox.Name = "colCheckbox";
            this.colCheckbox.Width = 20;
            // 
            // colSerial
            // 
            this.colSerial.HeaderText = "";
            this.colSerial.Name = "colSerial";
            this.colSerial.ReadOnly = true;
            this.colSerial.Visible = false;
            // 
            // colReviewNo
            // 
            this.colReviewNo.HeaderText = "";
            this.colReviewNo.Name = "colReviewNo";
            this.colReviewNo.Visible = false;
            // 
            // colRequestId
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colRequestId.DefaultCellStyle = dataGridViewCellStyle1;
            this.colRequestId.HeaderText = "شماره پیشنهاد";
            this.colRequestId.Name = "colRequestId";
            this.colRequestId.ReadOnly = true;
            // 
            // colRequestType
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colRequestType.DefaultCellStyle = dataGridViewCellStyle2;
            this.colRequestType.HeaderText = "نوع پیشنهاد";
            this.colRequestType.Name = "colRequestType";
            this.colRequestType.ReadOnly = true;
            // 
            // colCustomerName
            // 
            this.colCustomerName.HeaderText = "نام متقاضی";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Width = 240;
            // 
            // colRequestAmount
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colRequestAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.colRequestAmount.HeaderText = "مبلغ";
            this.colRequestAmount.Name = "colRequestAmount";
            this.colRequestAmount.ReadOnly = true;
            this.colRequestAmount.Width = 80;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlSave);
            this.pnlMain.Controls.Add(this.pnlExpertInfo);
            this.pnlMain.Controls.Add(this.pnlCustomerInfo);
            this.pnlMain.Controls.Add(this.grpRequests);
            this.pnlMain.Controls.Add(this.pnlSearch);
            this.pnlMain.Controls.Add(this.pnlInput);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(566, 493);
            this.pnlMain.TabIndex = 1;
            // 
            // frmAddExpertReport
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 493);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddExpertReport";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlCustomerInfo.ResumeLayout(false);
            this.pnlCustomerInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerId.Properties)).EndInit();
            this.pnlSave.ResumeLayout(false);
            this.pnlInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgInputType.Properties)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRequestId.Properties)).EndInit();
            this.pnlExpertInfo.ResumeLayout(false);
            this.pnlExpertInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboReferralType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            this.grpRequests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox txtFileId;
        private DevExpress.XtraEditors.SimpleButton btnFilesList;
        public System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblFileID;
        public System.Windows.Forms.TextBox txtExpertId;
        private System.Windows.Forms.Label lblExpertName;
        private System.Windows.Forms.Label lblExpert;
        private DevExpress.XtraEditors.SimpleButton btnUsersInfo;
        private System.Windows.Forms.GroupBox pnlCustomerInfo;
        private System.Windows.Forms.Panel pnlSave;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        public System.Windows.Forms.TextBox txtBranchId;
        private System.Windows.Forms.Label lblBranchID;
        public System.Windows.Forms.Label lblBranchName;
        private DevExpress.XtraEditors.SimpleButton btnBranchesList;
        private System.Windows.Forms.GroupBox pnlInput;
        private DevExpress.XtraEditors.RadioGroup rgInputType;
        private System.Windows.Forms.GroupBox pnlSearch;
        public DevExpress.XtraEditors.TextEdit txtRequestId;
        private System.Windows.Forms.Label lblIdRequestId;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private System.Windows.Forms.GroupBox pnlExpertInfo;
        public System.Windows.Forms.TextBox txtCoverNo;
        private System.Windows.Forms.CheckBox chkIsLegalPerson;
        private System.Windows.Forms.Label lblDate1;
        private Atf.UI.DateTimeSelector txtReferralDate;
        private System.Windows.Forms.Label label1;
        public DevExpress.XtraEditors.TextEdit txtCustomerId;
        private System.Windows.Forms.GroupBox grpRequests;
        private System.Windows.Forms.DataGridView dataGrid;
        public DevExpress.XtraEditors.ComboBoxEdit cboReferralType;
        private System.Windows.Forms.Label lblRequestType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReviewNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequestId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequestType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequestAmount;
        public DevExpress.XtraEditors.PanelControl pnlMain;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit comboBoxEdit1;
    }
}