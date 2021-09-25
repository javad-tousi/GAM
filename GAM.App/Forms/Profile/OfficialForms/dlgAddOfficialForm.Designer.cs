namespace GAM.Forms.Profile.OfficialForms
{
    partial class dlgAddOfficeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAddOfficeForm));
            this.lblSubject = new System.Windows.Forms.Label();
            this.cboCategory = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboReceiverName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblReceiverName = new System.Windows.Forms.Label();
            this.cboSignatories = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblSignatories = new System.Windows.Forms.Label();
            this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtSubject = new System.Windows.Forms.CustomControls.FilterdTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.cboCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboReceiverName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSignatories.Properties)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(286, 17);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(53, 13);
            this.lblSubject.TabIndex = 189;
            this.lblSubject.Text = "عنوان فرم";
            // 
            // cboCategory
            // 
            this.cboCategory.Location = new System.Drawing.Point(78, 42);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategory.Properties.Appearance.Options.UseFont = true;
            this.cboCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cboCategory.Properties.Items.AddRange(new object[] {
            "اعتبار اسنادی",
            "بررسی",
            "بسته اعتباری",
            "تمدید/تبدیل",
            "حواله",
            "سلف",
            "ضمانتنامه",
            "فروش اقساطی",
            "قرض الحسنه",
            "مجوزات",
            "مرابحه",
            "مسکن",
            "مشارکت مدنی",
            "مصوبه",
            "مضاربه",
            "مطالبات",
            "معرفی/عودت",
            "مکاتبات",
            "وثایق"});
            this.cboCategory.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboCategory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboCategory.Size = new System.Drawing.Size(206, 22);
            this.cboCategory.TabIndex = 2;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCategory.Location = new System.Drawing.Point(285, 46);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(59, 13);
            this.lblCategory.TabIndex = 191;
            this.lblCategory.Text = "دسته بندی";
            // 
            // cboReceiverName
            // 
            this.cboReceiverName.Location = new System.Drawing.Point(78, 70);
            this.cboReceiverName.Name = "cboReceiverName";
            this.cboReceiverName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReceiverName.Properties.Appearance.Options.UseFont = true;
            this.cboReceiverName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cboReceiverName.Properties.Items.AddRange(new object[] {
            "اداره امور مالی",
            "اداره برنامه ریزی و نظارت اعتباری",
            "اداره کارگزینی",
            "اداره کل اعتبارات",
            "اداره کل امنیت و فرآوری داده",
            "اداره کل بانکداری شخصی",
            "اداره کل وصول مطالبات",
            "حوزه ها و شعب",
            "رئیس اعتبارات",
            "سازمان بازرسی کل کشور",
            "سایر بانک ها",
            "ستاد دیه",
            "شرکت تدبیرگران",
            "شعبه",
            "کلیه شعب",
            "ندارد"});
            this.cboReceiverName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboReceiverName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboReceiverName.Size = new System.Drawing.Size(206, 22);
            this.cboReceiverName.TabIndex = 3;
            // 
            // lblReceiverName
            // 
            this.lblReceiverName.AutoSize = true;
            this.lblReceiverName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblReceiverName.Location = new System.Drawing.Point(285, 74);
            this.lblReceiverName.Name = "lblReceiverName";
            this.lblReceiverName.Size = new System.Drawing.Size(35, 13);
            this.lblReceiverName.TabIndex = 193;
            this.lblReceiverName.Text = "گیرنده";
            // 
            // cboSignatories
            // 
            this.cboSignatories.Location = new System.Drawing.Point(78, 98);
            this.cboSignatories.Name = "cboSignatories";
            this.cboSignatories.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSignatories.Properties.Appearance.Options.UseFont = true;
            this.cboSignatories.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cboSignatories.Properties.Items.AddRange(new object[] {
            "اداره اعتبارات",
            "شعبه",
            "کارشناس",
            "کمیته اعتباری",
            "کمیته تعیین تکلیف مطالبات",
            "معاونت اعتباری",
            "ندارد"});
            this.cboSignatories.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboSignatories.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboSignatories.Size = new System.Drawing.Size(206, 22);
            this.cboSignatories.TabIndex = 4;
            // 
            // lblSignatories
            // 
            this.lblSignatories.AutoSize = true;
            this.lblSignatories.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSignatories.Location = new System.Drawing.Point(285, 102);
            this.lblSignatories.Name = "lblSignatories";
            this.lblSignatories.Size = new System.Drawing.Size(69, 13);
            this.lblSignatories.TabIndex = 195;
            this.lblSignatories.Text = "امضاء کنندگان";
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBrowse.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowse.ImageOptions.Image")));
            this.btnBrowse.Location = new System.Drawing.Point(78, 126);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(25, 22);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(109, 126);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFileName.Size = new System.Drawing.Size(175, 22);
            this.txtFileName.TabIndex = 5;
            this.txtFileName.TabStop = false;
            this.txtFileName.Tag = "";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFileName.Location = new System.Drawing.Point(285, 130);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(58, 13);
            this.lblFileName.TabIndex = 198;
            this.lblFileName.Text = "انتخاب فایل";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.btnEdit);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 166);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlBottom.Size = new System.Drawing.Size(358, 36);
            this.pnlBottom.TabIndex = 0;
            this.pnlBottom.Text = "flowLayoutPanel1";
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(216, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(139, 30);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "ثبت فرم";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Enabled = false;
            this.btnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.Image")));
            this.btnEdit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnEdit.Location = new System.Drawing.Point(85, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(125, 30);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = " ویرایش محتوا";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtSubject
            // 
            this.txtSubject.AcceptedChars = "-()";
            this.txtSubject.BackColor = System.Drawing.SystemColors.Window;
            this.txtSubject.BackColorOnErr = System.Drawing.Color.Pink;
            this.txtSubject.BackColorUsed = System.Drawing.SystemColors.Window;
            this.txtSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubject.FilterChars = System.Windows.Forms.CustomControls.FilterdTextBox.FilteredEnum.PersianChars;
            this.txtSubject.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubject.Location = new System.Drawing.Point(12, 14);
            this.txtSubject.MaxLength = 100;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.PromptFont = null;
            this.txtSubject.PromptForeColor = System.Drawing.SystemColors.Control;
            this.txtSubject.PromptText = "";
            this.txtSubject.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSubject.SelectAllFocused = true;
            this.txtSubject.Size = new System.Drawing.Size(272, 22);
            this.txtSubject.TabIndex = 1;
            this.txtSubject.TextLanguage = System.Windows.Forms.CustomControls.FilterdTextBox.LanguageEnum.Farsi;
            // 
            // dlgAddOfficeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 202);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.cboSignatories);
            this.Controls.Add(this.lblSignatories);
            this.Controls.Add(this.cboReceiverName);
            this.Controls.Add(this.lblReceiverName);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.txtSubject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgAddOfficeForm";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "افزودن فرم جدید";
            ((System.ComponentModel.ISupportInitialize)(this.cboCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboReceiverName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSignatories.Properties)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSubject;
        public System.Windows.Forms.CustomControls.FilterdTextBox txtSubject;
        public DevExpress.XtraEditors.ComboBoxEdit cboCategory;
        private System.Windows.Forms.Label lblCategory;
        public DevExpress.XtraEditors.ComboBoxEdit cboReceiverName;
        private System.Windows.Forms.Label lblReceiverName;
        public DevExpress.XtraEditors.ComboBoxEdit cboSignatories;
        private System.Windows.Forms.Label lblSignatories;
        private DevExpress.XtraEditors.SimpleButton btnBrowse;
        public System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.FlowLayoutPanel pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}