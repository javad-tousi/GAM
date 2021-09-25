namespace GAM.Forms.Profile.Etebarat.Print
{
    partial class dlgAddLinkedRequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAddLinkedRequest));
            this.txtRequestId = new DevExpress.XtraEditors.TextEdit();
            this.lblIdPishnehad = new System.Windows.Forms.Label();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.cboRequestType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblRequestType = new System.Windows.Forms.Label();
            this.txtFacilityId = new System.Windows.Forms.TextBox();
            this.btnFacilitysList = new DevExpress.XtraEditors.SimpleButton();
            this.txtFacilityName = new System.Windows.Forms.TextBox();
            this.lblFacilityId = new System.Windows.Forms.Label();
            this.txtRequestAmount = new DevExpress.XtraEditors.TextEdit();
            this.lblRequestAmount = new System.Windows.Forms.Label();
            this.cboRequestPlane = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblRequestPlane = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.txtRequestId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRequestType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRequestAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRequestPlane.Properties)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRequestId
            // 
            this.txtRequestId.EditValue = "";
            this.txtRequestId.Location = new System.Drawing.Point(110, 12);
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
            this.txtRequestId.Size = new System.Drawing.Size(173, 26);
            this.txtRequestId.TabIndex = 33;
            this.txtRequestId.EditValueChanged += new System.EventHandler(this.txtRequestId_EditValueChanged);
            // 
            // lblIdPishnehad
            // 
            this.lblIdPishnehad.AutoSize = true;
            this.lblIdPishnehad.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblIdPishnehad.ForeColor = System.Drawing.Color.Black;
            this.lblIdPishnehad.Location = new System.Drawing.Point(284, 18);
            this.lblIdPishnehad.Name = "lblIdPishnehad";
            this.lblIdPishnehad.Size = new System.Drawing.Size(66, 13);
            this.lblIdPishnehad.TabIndex = 35;
            this.lblIdPishnehad.Text = "ش پیشنهاد";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(37, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 26);
            this.btnSearch.TabIndex = 34;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboRequestType
            // 
            this.cboRequestType.Location = new System.Drawing.Point(143, 3);
            this.cboRequestType.Name = "cboRequestType";
            this.cboRequestType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cboRequestType.Properties.Appearance.Options.UseFont = true;
            this.cboRequestType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRequestType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboRequestType.Properties.AutoHeight = false;
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
            this.cboRequestType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboRequestType.Size = new System.Drawing.Size(140, 22);
            this.cboRequestType.TabIndex = 135;
            // 
            // lblRequestType
            // 
            this.lblRequestType.AutoSize = true;
            this.lblRequestType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRequestType.Location = new System.Drawing.Point(284, 7);
            this.lblRequestType.Name = "lblRequestType";
            this.lblRequestType.Size = new System.Drawing.Size(62, 13);
            this.lblRequestType.TabIndex = 136;
            this.lblRequestType.Text = "نوع پیشنهاد";
            // 
            // txtFacilityId
            // 
            this.txtFacilityId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFacilityId.Location = new System.Drawing.Point(258, 53);
            this.txtFacilityId.Name = "txtFacilityId";
            this.txtFacilityId.ReadOnly = true;
            this.txtFacilityId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFacilityId.Size = new System.Drawing.Size(25, 22);
            this.txtFacilityId.TabIndex = 137;
            this.txtFacilityId.TabStop = false;
            this.txtFacilityId.Tag = "";
            this.txtFacilityId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnFacilitysList
            // 
            this.btnFacilitysList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFacilitysList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFacilitysList.ImageOptions.Image")));
            this.btnFacilitysList.Location = new System.Drawing.Point(13, 53);
            this.btnFacilitysList.Name = "btnFacilitysList";
            this.btnFacilitysList.Size = new System.Drawing.Size(25, 22);
            this.btnFacilitysList.TabIndex = 139;
            this.btnFacilitysList.Click += new System.EventHandler(this.btnFacilitysList_Click);
            // 
            // txtFacilityName
            // 
            this.txtFacilityName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFacilityName.Location = new System.Drawing.Point(41, 53);
            this.txtFacilityName.Name = "txtFacilityName";
            this.txtFacilityName.ReadOnly = true;
            this.txtFacilityName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFacilityName.Size = new System.Drawing.Size(215, 22);
            this.txtFacilityName.TabIndex = 138;
            this.txtFacilityName.TabStop = false;
            this.txtFacilityName.Tag = "";
            // 
            // lblFacilityId
            // 
            this.lblFacilityId.AutoSize = true;
            this.lblFacilityId.Location = new System.Drawing.Point(284, 57);
            this.lblFacilityId.Name = "lblFacilityId";
            this.lblFacilityId.Size = new System.Drawing.Size(67, 13);
            this.lblFacilityId.TabIndex = 140;
            this.lblFacilityId.Text = "نوع تسهیلات";
            // 
            // txtRequestAmount
            // 
            this.txtRequestAmount.Location = new System.Drawing.Point(173, 79);
            this.txtRequestAmount.Name = "txtRequestAmount";
            this.txtRequestAmount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequestAmount.Properties.Appearance.Options.UseFont = true;
            this.txtRequestAmount.Properties.Mask.EditMask = "n0";
            this.txtRequestAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtRequestAmount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtRequestAmount.Properties.MaxLength = 15;
            this.txtRequestAmount.Properties.NullText = "0";
            this.txtRequestAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRequestAmount.Size = new System.Drawing.Size(110, 22);
            this.txtRequestAmount.TabIndex = 141;
            // 
            // lblRequestAmount
            // 
            this.lblRequestAmount.AutoSize = true;
            this.lblRequestAmount.Location = new System.Drawing.Point(284, 86);
            this.lblRequestAmount.Name = "lblRequestAmount";
            this.lblRequestAmount.Size = new System.Drawing.Size(27, 13);
            this.lblRequestAmount.TabIndex = 142;
            this.lblRequestAmount.Text = "مبلغ";
            // 
            // cboRequestPlane
            // 
            this.cboRequestPlane.Location = new System.Drawing.Point(165, 28);
            this.cboRequestPlane.Name = "cboRequestPlane";
            this.cboRequestPlane.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cboRequestPlane.Properties.Appearance.Options.UseFont = true;
            this.cboRequestPlane.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRequestPlane.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboRequestPlane.Properties.AutoHeight = false;
            this.cboRequestPlane.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cboRequestPlane.Properties.Items.AddRange(new object[] {
            "",
            "سررسید گذشته",
            "معوق",
            "مشکوک الوصول",
            "جاری"});
            this.cboRequestPlane.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboRequestPlane.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboRequestPlane.Size = new System.Drawing.Size(118, 22);
            this.cboRequestPlane.TabIndex = 143;
            // 
            // lblRequestPlane
            // 
            this.lblRequestPlane.AutoSize = true;
            this.lblRequestPlane.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRequestPlane.Location = new System.Drawing.Point(284, 33);
            this.lblRequestPlane.Name = "lblRequestPlane";
            this.lblRequestPlane.Size = new System.Drawing.Size(48, 13);
            this.lblRequestPlane.TabIndex = 144;
            this.lblRequestPlane.Text = "نوع طبقه";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 150);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlBottom.Size = new System.Drawing.Size(360, 34);
            this.pnlBottom.TabIndex = 145;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(120, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(237, 29);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "افزودن به لیست";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 29);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboRequestType);
            this.panel1.Controls.Add(this.lblRequestType);
            this.panel1.Controls.Add(this.cboRequestPlane);
            this.panel1.Controls.Add(this.lblFacilityId);
            this.panel1.Controls.Add(this.lblRequestPlane);
            this.panel1.Controls.Add(this.txtFacilityName);
            this.panel1.Controls.Add(this.txtRequestAmount);
            this.panel1.Controls.Add(this.btnFacilitysList);
            this.panel1.Controls.Add(this.lblRequestAmount);
            this.panel1.Controls.Add(this.txtFacilityId);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 112);
            this.panel1.TabIndex = 146;
            // 
            // dlgAddLinkedRequest
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 184);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.txtRequestId);
            this.Controls.Add(this.lblIdPishnehad);
            this.Controls.Add(this.btnSearch);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "dlgAddLinkedRequest";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ثبت پیشنهاد";
            ((System.ComponentModel.ISupportInitialize)(this.txtRequestId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRequestType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRequestAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRequestPlane.Properties)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.TextEdit txtRequestId;
        private System.Windows.Forms.Label lblIdPishnehad;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        public DevExpress.XtraEditors.ComboBoxEdit cboRequestType;
        private System.Windows.Forms.Label lblRequestType;
        public System.Windows.Forms.TextBox txtFacilityId;
        private DevExpress.XtraEditors.SimpleButton btnFacilitysList;
        public System.Windows.Forms.TextBox txtFacilityName;
        private System.Windows.Forms.Label lblFacilityId;
        private DevExpress.XtraEditors.TextEdit txtRequestAmount;
        private System.Windows.Forms.Label lblRequestAmount;
        public DevExpress.XtraEditors.ComboBoxEdit cboRequestPlane;
        private System.Windows.Forms.Label lblRequestPlane;
        private System.Windows.Forms.FlowLayoutPanel pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.Panel panel1;
    }
}