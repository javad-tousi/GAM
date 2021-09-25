namespace GAM.Forms.Profile.Hoghoghi.NewFile
{
    partial class dlgAddPlaque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAddPlaque));
            this.pnlBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtPlaqueLeft1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPlaquePart1 = new DevExpress.XtraEditors.SpinEdit();
            this.txtPlaquePart2 = new DevExpress.XtraEditors.SpinEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPlaquePart = new DevExpress.XtraEditors.SpinEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPlaqueSection = new DevExpress.XtraEditors.SpinEdit();
            this.txtPlaqueCity = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPlaqueAddress = new DevExpress.XtraEditors.MemoEdit();
            this.txtMortgagorId = new DevExpress.XtraEditors.TextEdit();
            this.lblMortgagorId = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.cboLegalPerson = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPlaqueLeft2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtMortgagorName = new System.Windows.Forms.CustomControls.FilterdTextBox();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaqueLeft1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaquePart1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaquePart2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaquePart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaqueSection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaqueCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaqueAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMortgagorId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLegalPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaqueLeft2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 312);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlBottom.Size = new System.Drawing.Size(374, 34);
            this.pnlBottom.TabIndex = 142;
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(121, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(250, 29);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "افزودن به لیست";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(7, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 29);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtPlaqueLeft1
            // 
            this.txtPlaqueLeft1.EditValue = "";
            this.txtPlaqueLeft1.Location = new System.Drawing.Point(204, 65);
            this.txtPlaqueLeft1.Name = "txtPlaqueLeft1";
            this.txtPlaqueLeft1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaqueLeft1.Properties.Appearance.Options.UseFont = true;
            this.txtPlaqueLeft1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPlaqueLeft1.Properties.Items.AddRange(new object[] {
            "",
            "باقیمانده",
            "بخشی",
            "قسمتی",
            "مفروض",
            "تجمیعی"});
            this.txtPlaqueLeft1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtPlaqueLeft1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPlaqueLeft1.Size = new System.Drawing.Size(95, 24);
            this.txtPlaqueLeft1.TabIndex = 4;
            this.txtPlaqueLeft1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(300, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 14);
            this.label1.TabIndex = 145;
            this.label1.Text = "فرعی از";
            // 
            // txtPlaquePart1
            // 
            this.txtPlaquePart1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPlaquePart1.Location = new System.Drawing.Point(204, 92);
            this.txtPlaquePart1.Name = "txtPlaquePart1";
            this.txtPlaquePart1.Properties.AllowMouseWheel = false;
            this.txtPlaquePart1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.txtPlaquePart1.Properties.Appearance.Options.UseFont = true;
            this.txtPlaquePart1.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPlaquePart1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtPlaquePart1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPlaquePart1.Properties.Mask.EditMask = "f0";
            this.txtPlaquePart1.Properties.MaxValue = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtPlaquePart1.Size = new System.Drawing.Size(95, 24);
            this.txtPlaquePart1.TabIndex = 5;
            this.txtPlaquePart1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // txtPlaquePart2
            // 
            this.txtPlaquePart2.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPlaquePart2.Location = new System.Drawing.Point(204, 146);
            this.txtPlaquePart2.Name = "txtPlaquePart2";
            this.txtPlaquePart2.Properties.AllowMouseWheel = false;
            this.txtPlaquePart2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.txtPlaquePart2.Properties.Appearance.Options.UseFont = true;
            this.txtPlaquePart2.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPlaquePart2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtPlaquePart2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPlaquePart2.Properties.Mask.EditMask = "f0";
            this.txtPlaquePart2.Properties.MaxValue = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtPlaquePart2.Size = new System.Drawing.Size(95, 24);
            this.txtPlaquePart2.TabIndex = 7;
            this.txtPlaquePart2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(300, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 14);
            this.label2.TabIndex = 148;
            this.label2.Text = "فرعی از";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(300, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 14);
            this.label3.TabIndex = 150;
            this.label3.Text = "اصلی از";
            // 
            // txtPlaquePart
            // 
            this.txtPlaquePart.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPlaquePart.Location = new System.Drawing.Point(204, 173);
            this.txtPlaquePart.Name = "txtPlaquePart";
            this.txtPlaquePart.Properties.AllowMouseWheel = false;
            this.txtPlaquePart.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.txtPlaquePart.Properties.Appearance.Options.UseFont = true;
            this.txtPlaquePart.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPlaquePart.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtPlaquePart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPlaquePart.Properties.Mask.EditMask = "f0";
            this.txtPlaquePart.Properties.MaxValue = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtPlaquePart.Size = new System.Drawing.Size(95, 24);
            this.txtPlaquePart.TabIndex = 8;
            this.txtPlaquePart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(300, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 14);
            this.label4.TabIndex = 152;
            this.label4.Text = "بخش";
            // 
            // txtPlaqueSection
            // 
            this.txtPlaqueSection.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPlaqueSection.Location = new System.Drawing.Point(204, 200);
            this.txtPlaqueSection.Name = "txtPlaqueSection";
            this.txtPlaqueSection.Properties.AllowMouseWheel = false;
            this.txtPlaqueSection.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.txtPlaqueSection.Properties.Appearance.Options.UseFont = true;
            this.txtPlaqueSection.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPlaqueSection.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtPlaqueSection.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPlaqueSection.Properties.Mask.EditMask = "f0";
            this.txtPlaqueSection.Properties.MaxValue = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtPlaqueSection.Size = new System.Drawing.Size(95, 24);
            this.txtPlaqueSection.TabIndex = 9;
            this.txtPlaqueSection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // txtPlaqueCity
            // 
            this.txtPlaqueCity.EditValue = "";
            this.txtPlaqueCity.Location = new System.Drawing.Point(12, 200);
            this.txtPlaqueCity.Name = "txtPlaqueCity";
            this.txtPlaqueCity.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.txtPlaqueCity.Properties.Appearance.Options.UseFont = true;
            this.txtPlaqueCity.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPlaqueCity.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtPlaqueCity.Size = new System.Drawing.Size(125, 24);
            this.txtPlaqueCity.TabIndex = 10;
            this.txtPlaqueCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(138, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 155;
            this.label5.Text = "شهرستان";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(300, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 156;
            this.label6.Text = "آدرس";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(302, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 14);
            this.label7.TabIndex = 157;
            this.label7.Text = "سهم";
            // 
            // txtPlaqueAddress
            // 
            this.txtPlaqueAddress.EditValue = "";
            this.txtPlaqueAddress.Location = new System.Drawing.Point(12, 227);
            this.txtPlaqueAddress.Name = "txtPlaqueAddress";
            this.txtPlaqueAddress.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaqueAddress.Properties.Appearance.Options.UseFont = true;
            this.txtPlaqueAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPlaqueAddress.Size = new System.Drawing.Size(287, 63);
            this.txtPlaqueAddress.TabIndex = 11;
            // 
            // txtMortgagorId
            // 
            this.txtMortgagorId.EditValue = "";
            this.txtMortgagorId.Location = new System.Drawing.Point(204, 39);
            this.txtMortgagorId.Name = "txtMortgagorId";
            this.txtMortgagorId.Properties.AllowMouseWheel = false;
            this.txtMortgagorId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMortgagorId.Properties.Appearance.Options.UseFont = true;
            this.txtMortgagorId.Properties.AutoHeight = false;
            this.txtMortgagorId.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtMortgagorId.Properties.Mask.EditMask = "999-999999-9";
            this.txtMortgagorId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtMortgagorId.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtMortgagorId.Properties.MaxLength = 13;
            this.txtMortgagorId.Properties.NullText = "0";
            this.txtMortgagorId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMortgagorId.Size = new System.Drawing.Size(95, 23);
            this.txtMortgagorId.TabIndex = 3;
            this.txtMortgagorId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // lblMortgagorId
            // 
            this.lblMortgagorId.AutoSize = true;
            this.lblMortgagorId.ForeColor = System.Drawing.Color.Black;
            this.lblMortgagorId.Location = new System.Drawing.Point(299, 44);
            this.lblMortgagorId.Name = "lblMortgagorId";
            this.lblMortgagorId.Size = new System.Drawing.Size(68, 13);
            this.lblMortgagorId.TabIndex = 250;
            this.lblMortgagorId.Text = "کد ملی راهن";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(299, 18);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(76, 13);
            this.label27.TabIndex = 249;
            this.label27.Text = "نام راهن اصلی";
            // 
            // cboLegalPerson
            // 
            this.cboLegalPerson.EditValue = "حقیقی";
            this.cboLegalPerson.Location = new System.Drawing.Point(12, 15);
            this.cboLegalPerson.Name = "cboLegalPerson";
            this.cboLegalPerson.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLegalPerson.Properties.Appearance.Options.UseFont = true;
            this.cboLegalPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLegalPerson.Properties.Items.AddRange(new object[] {
            "حقیقی",
            "حقوقی"});
            this.cboLegalPerson.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboLegalPerson.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboLegalPerson.Size = new System.Drawing.Size(74, 24);
            this.cboLegalPerson.TabIndex = 2;
            this.cboLegalPerson.SelectedIndexChanged += new System.EventHandler(this.cboLegalPerson_SelectedIndexChanged);
            this.cboLegalPerson.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(0, 293);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(374, 19);
            this.label8.TabIndex = 251;
            this.label8.Text = "نحوه درج صحیح آدرس: مشهد-خ آزادی-بین آزادی 6 و 8-پلاک 201";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(302, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 14);
            this.label9.TabIndex = 253;
            this.label9.Text = "سهم";
            // 
            // txtPlaqueLeft2
            // 
            this.txtPlaqueLeft2.EditValue = "";
            this.txtPlaqueLeft2.Location = new System.Drawing.Point(204, 119);
            this.txtPlaqueLeft2.Name = "txtPlaqueLeft2";
            this.txtPlaqueLeft2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaqueLeft2.Properties.Appearance.Options.UseFont = true;
            this.txtPlaqueLeft2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPlaqueLeft2.Properties.Items.AddRange(new object[] {
            "",
            "باقیمانده",
            "بخشی",
            "قسمتی",
            "مفروض",
            "تجمیعی"});
            this.txtPlaqueLeft2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtPlaqueLeft2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPlaqueLeft2.Size = new System.Drawing.Size(95, 24);
            this.txtPlaqueLeft2.TabIndex = 6;
            this.txtPlaqueLeft2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // txtMortgagorName
            // 
            this.txtMortgagorName.AcceptedChars = ".-()";
            this.txtMortgagorName.BackColor = System.Drawing.SystemColors.Window;
            this.txtMortgagorName.BackColorOnErr = System.Drawing.Color.Pink;
            this.txtMortgagorName.BackColorUsed = System.Drawing.SystemColors.Window;
            this.txtMortgagorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMortgagorName.FilterChars = System.Windows.Forms.CustomControls.FilterdTextBox.FilteredEnum.PersianChars;
            this.txtMortgagorName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMortgagorName.Location = new System.Drawing.Point(92, 15);
            this.txtMortgagorName.MaxLength = 100;
            this.txtMortgagorName.Name = "txtMortgagorName";
            this.txtMortgagorName.PromptFont = null;
            this.txtMortgagorName.PromptForeColor = System.Drawing.SystemColors.Control;
            this.txtMortgagorName.PromptText = "";
            this.txtMortgagorName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMortgagorName.SelectAllFocused = true;
            this.txtMortgagorName.Size = new System.Drawing.Size(207, 22);
            this.txtMortgagorName.TabIndex = 1;
            this.txtMortgagorName.TextLanguage = System.Windows.Forms.CustomControls.FilterdTextBox.LanguageEnum.Farsi;
            this.txtMortgagorName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // dlgAddPlaque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 346);
            this.ControlBox = false;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPlaqueLeft2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboLegalPerson);
            this.Controls.Add(this.txtMortgagorId);
            this.Controls.Add(this.lblMortgagorId);
            this.Controls.Add(this.txtMortgagorName);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPlaqueCity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPlaqueSection);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPlaquePart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPlaquePart2);
            this.Controls.Add(this.txtPlaquePart1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPlaqueLeft1);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.txtPlaqueAddress);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "dlgAddPlaque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "افزودن/ویرایش پلاک ثبتی";
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaqueLeft1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaquePart1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaquePart2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaquePart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaqueSection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaqueCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaqueAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMortgagorId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLegalPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaqueLeft2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.ComboBoxEdit txtPlaqueLeft1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SpinEdit txtPlaquePart1;
        private DevExpress.XtraEditors.SpinEdit txtPlaquePart2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SpinEdit txtPlaquePart;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SpinEdit txtPlaqueSection;
        private DevExpress.XtraEditors.TextEdit txtPlaqueCity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.MemoEdit txtPlaqueAddress;
        public DevExpress.XtraEditors.TextEdit txtMortgagorId;
        private System.Windows.Forms.Label lblMortgagorId;
        public System.Windows.Forms.CustomControls.FilterdTextBox txtMortgagorName;
        private System.Windows.Forms.Label label27;
        private DevExpress.XtraEditors.ComboBoxEdit cboLegalPerson;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.ComboBoxEdit txtPlaqueLeft2;
    }
}