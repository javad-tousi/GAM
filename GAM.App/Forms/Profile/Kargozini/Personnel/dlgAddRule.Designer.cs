namespace GAM.Forms.Profile.Kargozini.Personnel
{
    partial class dlgAddRule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAddRule));
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.txtRuleDate = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRuleNo = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRuleDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBotton = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtBranchId = new System.Windows.Forms.TextBox();
            this.lblBranchID = new System.Windows.Forms.Label();
            this.lblBranchName = new System.Windows.Forms.Label();
            this.btnBranchesList = new DevExpress.XtraEditors.SimpleButton();
            this.txtEmploymentId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txPostId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblPostName = new System.Windows.Forms.Label();
            this.btnPostsList = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.cboRuleName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtJobId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblJobName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboPersonnelStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblRequestType = new System.Windows.Forms.Label();
            this.btnJobsList = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRuleDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRuleNo.Properties)).BeginInit();
            this.pnlBotton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboRuleName.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPersonnelStatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(173, 29);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(20, 20);
            this.pictureEdit1.TabIndex = 177;
            // 
            // txtRuleDate
            // 
            this.txtRuleDate.EditValue = "";
            this.txtRuleDate.Location = new System.Drawing.Point(195, 25);
            this.txtRuleDate.Name = "txtRuleDate";
            this.txtRuleDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtRuleDate.Properties.Appearance.Options.UseFont = true;
            this.txtRuleDate.Properties.AutoHeight = false;
            this.txtRuleDate.Properties.Mask.EditMask = "9999/99/99";
            this.txtRuleDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtRuleDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtRuleDate.Properties.MaxLength = 15;
            this.txtRuleDate.Properties.NullText = "0";
            this.txtRuleDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRuleDate.Size = new System.Drawing.Size(91, 25);
            this.txtRuleDate.TabIndex = 1;
            this.txtRuleDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(288, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 179;
            this.label3.Text = "تاریخ حکم";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtRuleNo
            // 
            this.txtRuleNo.EditValue = "";
            this.txtRuleNo.Location = new System.Drawing.Point(173, 53);
            this.txtRuleNo.Name = "txtRuleNo";
            this.txtRuleNo.Properties.AllowMouseWheel = false;
            this.txtRuleNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuleNo.Properties.Appearance.Options.UseFont = true;
            this.txtRuleNo.Properties.AutoHeight = false;
            this.txtRuleNo.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtRuleNo.Properties.Mask.EditMask = "\\d+";
            this.txtRuleNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtRuleNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtRuleNo.Properties.MaxLength = 13;
            this.txtRuleNo.Properties.NullText = "0";
            this.txtRuleNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRuleNo.Size = new System.Drawing.Size(113, 24);
            this.txtRuleNo.TabIndex = 2;
            this.txtRuleNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label5.Location = new System.Drawing.Point(287, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 14);
            this.label5.TabIndex = 182;
            this.label5.Text = "شماره حکم";
            // 
            // txtRuleDescription
            // 
            this.txtRuleDescription.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuleDescription.Location = new System.Drawing.Point(12, 105);
            this.txtRuleDescription.Multiline = true;
            this.txtRuleDescription.Name = "txtRuleDescription";
            this.txtRuleDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRuleDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRuleDescription.Size = new System.Drawing.Size(274, 42);
            this.txtRuleDescription.TabIndex = 4;
            this.txtRuleDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label1.Location = new System.Drawing.Point(287, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 188;
            this.label1.Text = "توضیحات";
            // 
            // pnlBotton
            // 
            this.pnlBotton.Controls.Add(this.btnSave);
            this.pnlBotton.Controls.Add(this.btnCancel);
            this.pnlBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotton.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlBotton.Location = new System.Drawing.Point(0, 395);
            this.pnlBotton.Name = "pnlBotton";
            this.pnlBotton.Size = new System.Drawing.Size(358, 35);
            this.pnlBotton.TabIndex = 189;
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(123, 3);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(230, 29);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "تایید و ثبت اطلاعات";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 29);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtBranchId
            // 
            this.txtBranchId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranchId.Location = new System.Drawing.Point(233, 47);
            this.txtBranchId.Name = "txtBranchId";
            this.txtBranchId.ReadOnly = true;
            this.txtBranchId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBranchId.Size = new System.Drawing.Size(48, 22);
            this.txtBranchId.TabIndex = 6;
            this.txtBranchId.TabStop = false;
            this.txtBranchId.Tag = "";
            this.txtBranchId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBranchId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // lblBranchID
            // 
            this.lblBranchID.AutoSize = true;
            this.lblBranchID.Location = new System.Drawing.Point(282, 52);
            this.lblBranchID.Name = "lblBranchID";
            this.lblBranchID.Size = new System.Drawing.Size(42, 13);
            this.lblBranchID.TabIndex = 192;
            this.lblBranchID.Text = "کد واحد";
            // 
            // lblBranchName
            // 
            this.lblBranchName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblBranchName.ForeColor = System.Drawing.Color.Black;
            this.lblBranchName.Location = new System.Drawing.Point(7, 50);
            this.lblBranchName.Name = "lblBranchName";
            this.lblBranchName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBranchName.Size = new System.Drawing.Size(190, 17);
            this.lblBranchName.TabIndex = 193;
            // 
            // btnBranchesList
            // 
            this.btnBranchesList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBranchesList.Enabled = false;
            this.btnBranchesList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBranchesList.ImageOptions.Image")));
            this.btnBranchesList.Location = new System.Drawing.Point(203, 47);
            this.btnBranchesList.Name = "btnBranchesList";
            this.btnBranchesList.Size = new System.Drawing.Size(25, 22);
            this.btnBranchesList.TabIndex = 7;
            this.btnBranchesList.Click += new System.EventHandler(this.btnBranchesList_Click);
            // 
            // txtEmploymentId
            // 
            this.txtEmploymentId.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmploymentId.Location = new System.Drawing.Point(195, 25);
            this.txtEmploymentId.Name = "txtEmploymentId";
            this.txtEmploymentId.ReadOnly = true;
            this.txtEmploymentId.Size = new System.Drawing.Size(91, 23);
            this.txtEmploymentId.TabIndex = 0;
            this.txtEmploymentId.TabStop = false;
            this.txtEmploymentId.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 195;
            this.label2.Text = "ش.کارمندی";
            // 
            // txPostId
            // 
            this.txPostId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txPostId.Location = new System.Drawing.Point(233, 72);
            this.txPostId.Name = "txPostId";
            this.txPostId.ReadOnly = true;
            this.txPostId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txPostId.Size = new System.Drawing.Size(48, 22);
            this.txPostId.TabIndex = 8;
            this.txPostId.TabStop = false;
            this.txPostId.Tag = "";
            this.txPostId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(282, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 206;
            this.label10.Text = "کد پست";
            // 
            // lblPostName
            // 
            this.lblPostName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPostName.ForeColor = System.Drawing.Color.Black;
            this.lblPostName.Location = new System.Drawing.Point(7, 75);
            this.lblPostName.Name = "lblPostName";
            this.lblPostName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPostName.Size = new System.Drawing.Size(190, 17);
            this.lblPostName.TabIndex = 207;
            // 
            // btnPostsList
            // 
            this.btnPostsList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPostsList.Enabled = false;
            this.btnPostsList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPostsList.ImageOptions.Image")));
            this.btnPostsList.Location = new System.Drawing.Point(203, 72);
            this.btnPostsList.Name = "btnPostsList";
            this.btnPostsList.Size = new System.Drawing.Size(25, 22);
            this.btnPostsList.TabIndex = 9;
            this.btnPostsList.Click += new System.EventHandler(this.btnPostsList_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(287, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 210;
            this.label4.Text = "نوع حکم";
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.ForeColor = System.Drawing.Color.Blue;
            this.checkBox.Location = new System.Drawing.Point(44, 371);
            this.checkBox.Name = "checkBox";
            this.checkBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox.Size = new System.Drawing.Size(242, 17);
            this.checkBox.TabIndex = 12;
            this.checkBox.Text = "صحت اطلاعات فوق مورد تایید اینجانب می باشد";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // cboRuleName
            // 
            this.cboRuleName.Location = new System.Drawing.Point(123, 80);
            this.cboRuleName.Name = "cboRuleName";
            this.cboRuleName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cboRuleName.Properties.Appearance.Options.UseFont = true;
            this.cboRuleName.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRuleName.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboRuleName.Properties.AutoHeight = false;
            this.cboRuleName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cboRuleName.Properties.Items.AddRange(new object[] {
            "",
            "تغییر وضعیت",
            "انتقال",
            "انتقال-قطعی",
            "تغییر پست",
            "تغییر شغل",
            "تغییر پست و شغل",
            "انتقال و تغییر پست",
            "انتقال و تغییر شغل",
            "انتقال و تغییر پست و شغل",
            "تشویقی",
            "اخطار کتبی",
            "لغو حکم"});
            this.cboRuleName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboRuleName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboRuleName.Size = new System.Drawing.Size(163, 22);
            this.cboRuleName.TabIndex = 3;
            this.cboRuleName.SelectedIndexChanged += new System.EventHandler(this.cboRuleName_SelectedIndexChanged);
            this.cboRuleName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(120, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 214;
            this.label6.Text = "(اختیاری)";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.ForeColor = System.Drawing.Color.Gray;
            this.lblFullName.Location = new System.Drawing.Point(139, 31);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(50, 13);
            this.lblFullName.TabIndex = 215;
            this.lblFullName.Text = "(اختیاری)";
            // 
            // txtJobId
            // 
            this.txtJobId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobId.Location = new System.Drawing.Point(233, 97);
            this.txtJobId.Name = "txtJobId";
            this.txtJobId.ReadOnly = true;
            this.txtJobId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtJobId.Size = new System.Drawing.Size(48, 22);
            this.txtJobId.TabIndex = 10;
            this.txtJobId.TabStop = false;
            this.txtJobId.Tag = "";
            this.txtJobId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(282, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 218;
            this.label7.Text = "کد شغل";
            // 
            // lblJobName
            // 
            this.lblJobName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblJobName.ForeColor = System.Drawing.Color.Black;
            this.lblJobName.Location = new System.Drawing.Point(7, 100);
            this.lblJobName.Name = "lblJobName";
            this.lblJobName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblJobName.Size = new System.Drawing.Size(190, 17);
            this.lblJobName.TabIndex = 219;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtFullName);
            this.groupBox1.Controls.Add(this.txtEmploymentId);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblFullName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(358, 81);
            this.groupBox1.TabIndex = 220;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اطلاعات همکار";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(288, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 217;
            this.label8.Text = "نام همکار";
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullName.Location = new System.Drawing.Point(12, 50);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(274, 23);
            this.txtFullName.TabIndex = 0;
            this.txtFullName.TabStop = false;
            this.txtFullName.Tag = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtRuleDate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.pictureEdit1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtRuleNo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtRuleDescription);
            this.groupBox2.Controls.Add(this.cboRuleName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(358, 156);
            this.groupBox2.TabIndex = 221;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "اطلاعات حکم";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboPersonnelStatus);
            this.groupBox3.Controls.Add(this.lblRequestType);
            this.groupBox3.Controls.Add(this.btnJobsList);
            this.groupBox3.Controls.Add(this.txtBranchId);
            this.groupBox3.Controls.Add(this.btnBranchesList);
            this.groupBox3.Controls.Add(this.lblBranchName);
            this.groupBox3.Controls.Add(this.txtJobId);
            this.groupBox3.Controls.Add(this.lblBranchID);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.btnPostsList);
            this.groupBox3.Controls.Add(this.lblJobName);
            this.groupBox3.Controls.Add(this.lblPostName);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txPostId);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 237);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(358, 128);
            this.groupBox3.TabIndex = 222;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "تغییرات جدید";
            // 
            // cboPersonnelStatus
            // 
            this.cboPersonnelStatus.EditValue = "";
            this.cboPersonnelStatus.Enabled = false;
            this.cboPersonnelStatus.Location = new System.Drawing.Point(140, 21);
            this.cboPersonnelStatus.Name = "cboPersonnelStatus";
            this.cboPersonnelStatus.Properties.AllowMouseWheel = false;
            this.cboPersonnelStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cboPersonnelStatus.Properties.Appearance.Options.UseFont = true;
            this.cboPersonnelStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPersonnelStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboPersonnelStatus.Properties.AutoHeight = false;
            this.cboPersonnelStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cboPersonnelStatus.Properties.Items.AddRange(new object[] {
            "",
            "شاغل",
            "ماموریت",
            "استعلاجی",
            "مرخصی بازنشستگی",
            "تمدید خدمت",
            "بازخرید",
            "معلق",
            "اخراج شده",
            "بازنشسته",
            "فوت شده"});
            this.cboPersonnelStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboPersonnelStatus.Size = new System.Drawing.Size(142, 22);
            this.cboPersonnelStatus.TabIndex = 5;
            // 
            // lblRequestType
            // 
            this.lblRequestType.AutoSize = true;
            this.lblRequestType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRequestType.Location = new System.Drawing.Point(283, 26);
            this.lblRequestType.Name = "lblRequestType";
            this.lblRequestType.Size = new System.Drawing.Size(66, 13);
            this.lblRequestType.TabIndex = 222;
            this.lblRequestType.Text = "وضعیت جدید";
            // 
            // btnJobsList
            // 
            this.btnJobsList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnJobsList.Enabled = false;
            this.btnJobsList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnJobsList.ImageOptions.Image")));
            this.btnJobsList.Location = new System.Drawing.Point(203, 97);
            this.btnJobsList.Name = "btnJobsList";
            this.btnJobsList.Size = new System.Drawing.Size(25, 22);
            this.btnJobsList.TabIndex = 11;
            this.btnJobsList.Click += new System.EventHandler(this.btnJobsList_Click);
            // 
            // dlgAddRule
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 430);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.pnlBotton);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "dlgAddRule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "افزودن حکم (داخلی) جدید";
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRuleDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRuleNo.Properties)).EndInit();
            this.pnlBotton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboRuleName.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPersonnelStatus.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.TextEdit txtRuleDate;
        private System.Windows.Forms.Label label3;
        public DevExpress.XtraEditors.TextEdit txtRuleNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRuleDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel pnlBotton;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        public System.Windows.Forms.TextBox txtBranchId;
        private System.Windows.Forms.Label lblBranchID;
        public System.Windows.Forms.Label lblBranchName;
        private DevExpress.XtraEditors.SimpleButton btnBranchesList;
        public System.Windows.Forms.TextBox txtEmploymentId;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txPostId;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label lblPostName;
        private DevExpress.XtraEditors.SimpleButton btnPostsList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox;
        public DevExpress.XtraEditors.ComboBoxEdit cboRuleName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFullName;
        public System.Windows.Forms.TextBox txtJobId;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label lblJobName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraEditors.SimpleButton btnJobsList;
        public DevExpress.XtraEditors.ComboBoxEdit cboPersonnelStatus;
        private System.Windows.Forms.Label lblRequestType;
    }
}