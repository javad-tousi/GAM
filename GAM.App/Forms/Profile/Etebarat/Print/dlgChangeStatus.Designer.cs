namespace GAM.Forms.Profile.Etebarat.Print
{
    partial class dlgChangeStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgChangeStatus));
            this.txtRequestID = new DevExpress.XtraEditors.TextEdit();
            this.lblIRequestID = new System.Windows.Forms.Label();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtNote = new System.Windows.Forms.RichTextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblRequestType = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.txtOldRequestStatus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboNewRequestStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSerial = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReviewNo = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDeleteReviewNo = new DevExpress.XtraEditors.SimpleButton();
            this.cboNotes = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.btnDeleteExpertNo = new DevExpress.XtraEditors.SimpleButton();
            this.txtExpertNo = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.listRequests = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddLinkedRequest = new DevExpress.XtraEditors.SimpleButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.CustomControls.FilterdTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGroupId = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRequestID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboNewRequestStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReviewNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNotes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpertNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRequestID
            // 
            this.txtRequestID.EditValue = "";
            this.txtRequestID.Location = new System.Drawing.Point(222, 19);
            this.txtRequestID.Name = "txtRequestID";
            this.txtRequestID.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.txtRequestID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequestID.Properties.Appearance.Options.UseBackColor = true;
            this.txtRequestID.Properties.Appearance.Options.UseFont = true;
            this.txtRequestID.Properties.Appearance.Options.UseTextOptions = true;
            this.txtRequestID.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtRequestID.Properties.Mask.EditMask = "\\d+";
            this.txtRequestID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtRequestID.Properties.MaxLength = 15;
            this.txtRequestID.Properties.ReadOnly = true;
            this.txtRequestID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRequestID.Size = new System.Drawing.Size(127, 22);
            this.txtRequestID.TabIndex = 1;
            // 
            // lblIRequestID
            // 
            this.lblIRequestID.AutoSize = true;
            this.lblIRequestID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblIRequestID.ForeColor = System.Drawing.Color.Black;
            this.lblIRequestID.Location = new System.Drawing.Point(349, 24);
            this.lblIRequestID.Name = "lblIRequestID";
            this.lblIRequestID.Size = new System.Drawing.Size(77, 13);
            this.lblIRequestID.TabIndex = 34;
            this.lblIRequestID.Text = "شماره پیشنهاد";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.EditValue = "";
            this.txtCustomerName.Location = new System.Drawing.Point(12, 95);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.txtCustomerName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Properties.Appearance.Options.UseBackColor = true;
            this.txtCustomerName.Properties.Appearance.Options.UseFont = true;
            this.txtCustomerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustomerName.Size = new System.Drawing.Size(337, 24);
            this.txtCustomerName.TabIndex = 5;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(349, 101);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(62, 13);
            this.lblCustomerName.TabIndex = 1;
            this.lblCustomerName.Text = "نام متقاضی";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(172, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(260, 29);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "اعمال تغییرات";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(5, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(161, 29);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.Color.Ivory;
            this.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNote.Enabled = false;
            this.txtNote.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtNote.Location = new System.Drawing.Point(12, 230);
            this.txtNote.MaxLength = 1000;
            this.txtNote.Name = "txtNote";
            this.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNote.Size = new System.Drawing.Size(337, 68);
            this.txtNote.TabIndex = 9;
            this.txtNote.Text = "";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(349, 233);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(77, 13);
            this.lblNote.TabIndex = 133;
            this.lblNote.Text = "توضیحات شعبه";
            // 
            // lblRequestType
            // 
            this.lblRequestType.AutoSize = true;
            this.lblRequestType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRequestType.Location = new System.Drawing.Point(349, 209);
            this.lblRequestType.Name = "lblRequestType";
            this.lblRequestType.Size = new System.Drawing.Size(70, 13);
            this.lblRequestType.TabIndex = 136;
            this.lblRequestType.Text = "پیش نویس ها";
            this.lblRequestType.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 349);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlBottom.Size = new System.Drawing.Size(435, 34);
            this.pnlBottom.TabIndex = 137;
            // 
            // txtOldRequestStatus
            // 
            this.txtOldRequestStatus.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldRequestStatus.Location = new System.Drawing.Point(12, 179);
            this.txtOldRequestStatus.MaxLength = 100;
            this.txtOldRequestStatus.Name = "txtOldRequestStatus";
            this.txtOldRequestStatus.ReadOnly = true;
            this.txtOldRequestStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtOldRequestStatus.Size = new System.Drawing.Size(127, 22);
            this.txtOldRequestStatus.TabIndex = 6;
            this.txtOldRequestStatus.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(140, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 187;
            this.label2.Text = "وضعیت جاری";
            // 
            // cboNewRequestStatus
            // 
            this.cboNewRequestStatus.Location = new System.Drawing.Point(222, 179);
            this.cboNewRequestStatus.Name = "cboNewRequestStatus";
            this.cboNewRequestStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNewRequestStatus.Properties.Appearance.Options.UseFont = true;
            this.cboNewRequestStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cboNewRequestStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboNewRequestStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboNewRequestStatus.Size = new System.Drawing.Size(127, 22);
            this.cboNewRequestStatus.TabIndex = 7;
            this.cboNewRequestStatus.SelectedIndexChanged += new System.EventHandler(this.cboNewRequestStatus_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(350, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 189;
            this.label3.Text = "وضعیت جدید";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtSerial
            // 
            this.txtSerial.EditValue = "";
            this.txtSerial.Location = new System.Drawing.Point(13, 19);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.txtSerial.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerial.Properties.Appearance.Options.UseBackColor = true;
            this.txtSerial.Properties.Appearance.Options.UseFont = true;
            this.txtSerial.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSerial.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtSerial.Properties.Mask.EditMask = "\\d+";
            this.txtSerial.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSerial.Properties.MaxLength = 15;
            this.txtSerial.Properties.ReadOnly = true;
            this.txtSerial.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSerial.Size = new System.Drawing.Size(127, 22);
            this.txtSerial.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(141, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 191;
            this.label1.Text = "شماره بررسی";
            // 
            // txtReviewNo
            // 
            this.txtReviewNo.EditValue = "";
            this.txtReviewNo.Location = new System.Drawing.Point(44, 44);
            this.txtReviewNo.Name = "txtReviewNo";
            this.txtReviewNo.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.txtReviewNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReviewNo.Properties.Appearance.Options.UseBackColor = true;
            this.txtReviewNo.Properties.Appearance.Options.UseFont = true;
            this.txtReviewNo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtReviewNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtReviewNo.Properties.Mask.EditMask = "\\d+";
            this.txtReviewNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtReviewNo.Properties.MaxLength = 15;
            this.txtReviewNo.Properties.ReadOnly = true;
            this.txtReviewNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtReviewNo.Size = new System.Drawing.Size(95, 22);
            this.txtReviewNo.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(140, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 193;
            this.label4.Text = "سریال پیشنهاد";
            // 
            // btnDeleteReviewNo
            // 
            this.btnDeleteReviewNo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteReviewNo.ImageOptions.Image")));
            this.btnDeleteReviewNo.Location = new System.Drawing.Point(13, 44);
            this.btnDeleteReviewNo.Name = "btnDeleteReviewNo";
            this.btnDeleteReviewNo.Size = new System.Drawing.Size(26, 23);
            this.btnDeleteReviewNo.TabIndex = 194;
            this.btnDeleteReviewNo.Click += new System.EventHandler(this.btnDeleteReviewNo_Click);
            // 
            // cboNotes
            // 
            this.cboNotes.EditValue = "";
            this.cboNotes.Enabled = false;
            this.cboNotes.Location = new System.Drawing.Point(12, 204);
            this.cboNotes.Name = "cboNotes";
            this.cboNotes.Properties.AllowMultiSelect = true;
            this.cboNotes.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNotes.Properties.Appearance.Options.UseFont = true;
            this.cboNotes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cboNotes.Properties.PopupFormSize = new System.Drawing.Size(390, 230);
            this.cboNotes.Properties.SelectAllItemVisible = false;
            this.cboNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboNotes.Size = new System.Drawing.Size(337, 22);
            this.cboNotes.TabIndex = 8;
            this.cboNotes.EditValueChanged += new System.EventHandler(this.cboNotes_EditValueChanged);
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Checked = true;
            this.checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox.Location = new System.Drawing.Point(13, 324);
            this.checkBox.Name = "checkBox";
            this.checkBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox.Size = new System.Drawing.Size(340, 17);
            this.checkBox.TabIndex = 0;
            this.checkBox.TabStop = false;
            this.checkBox.Text = "مایلم تاریخ ویرایش اطلاعات پیشنهاد (تاریخ آخرین تغییرات) به روز شود";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // btnDeleteExpertNo
            // 
            this.btnDeleteExpertNo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteExpertNo.ImageOptions.Image")));
            this.btnDeleteExpertNo.Location = new System.Drawing.Point(13, 69);
            this.btnDeleteExpertNo.Name = "btnDeleteExpertNo";
            this.btnDeleteExpertNo.Size = new System.Drawing.Size(26, 23);
            this.btnDeleteExpertNo.TabIndex = 197;
            this.btnDeleteExpertNo.Click += new System.EventHandler(this.btnDeleteExpertNo_Click);
            // 
            // txtExpertNo
            // 
            this.txtExpertNo.EditValue = "";
            this.txtExpertNo.Location = new System.Drawing.Point(44, 69);
            this.txtExpertNo.Name = "txtExpertNo";
            this.txtExpertNo.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.txtExpertNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpertNo.Properties.Appearance.Options.UseBackColor = true;
            this.txtExpertNo.Properties.Appearance.Options.UseFont = true;
            this.txtExpertNo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtExpertNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtExpertNo.Properties.Mask.EditMask = "\\d+";
            this.txtExpertNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtExpertNo.Properties.MaxLength = 15;
            this.txtExpertNo.Properties.ReadOnly = true;
            this.txtExpertNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtExpertNo.Size = new System.Drawing.Size(95, 22);
            this.txtExpertNo.TabIndex = 195;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(141, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 196;
            this.label5.Text = "شماره گزارش";
            // 
            // listRequests
            // 
            this.listRequests.Cursor = System.Windows.Forms.Cursors.Default;
            this.listRequests.Location = new System.Drawing.Point(12, 122);
            this.listRequests.MultiColumn = true;
            this.listRequests.Name = "listRequests";
            this.listRequests.Size = new System.Drawing.Size(318, 53);
            this.listRequests.TabIndex = 199;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(349, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 200;
            this.label6.Text = "پیشنهادات مرتبط";
            // 
            // btnAddLinkedRequest
            // 
            this.btnAddLinkedRequest.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddLinkedRequest.ImageOptions.Image")));
            this.btnAddLinkedRequest.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnAddLinkedRequest.Location = new System.Drawing.Point(331, 122);
            this.btnAddLinkedRequest.Name = "btnAddLinkedRequest";
            this.btnAddLinkedRequest.Size = new System.Drawing.Size(18, 53);
            this.btnAddLinkedRequest.TabIndex = 201;
            this.btnAddLinkedRequest.Click += new System.EventHandler(this.btnAddLinkedRequest_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(349, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 207;
            this.label7.Text = "شماره مشتری";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(9, 304);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(343, 13);
            this.label8.TabIndex = 208;
            this.label8.Text = "توضیح: درصورت خالی بودن باکس \"توضیحات شعبه\" لاگی ثبت نخواهد شد.";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.AcceptedChars = "";
            this.txtCustomerId.BackColorOnErr = System.Drawing.Color.Pink;
            this.txtCustomerId.BackColorUsed = System.Drawing.Color.White;
            this.txtCustomerId.FilterChars = System.Windows.Forms.CustomControls.FilterdTextBox.FilteredEnum.Digits;
            this.txtCustomerId.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerId.Location = new System.Drawing.Point(222, 69);
            this.txtCustomerId.MaxLength = 12;
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.PromptFont = null;
            this.txtCustomerId.PromptForeColor = System.Drawing.SystemColors.GrayText;
            this.txtCustomerId.PromptText = "";
            this.txtCustomerId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCustomerId.SelectAllFocused = true;
            this.txtCustomerId.Size = new System.Drawing.Size(127, 23);
            this.txtCustomerId.TabIndex = 206;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(349, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 210;
            this.label9.Text = "کد گروه";
            // 
            // txtGroupId
            // 
            this.txtGroupId.EditValue = "";
            this.txtGroupId.Location = new System.Drawing.Point(222, 44);
            this.txtGroupId.Name = "txtGroupId";
            this.txtGroupId.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.txtGroupId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroupId.Properties.Appearance.Options.UseBackColor = true;
            this.txtGroupId.Properties.Appearance.Options.UseFont = true;
            this.txtGroupId.Properties.Appearance.Options.UseTextOptions = true;
            this.txtGroupId.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtGroupId.Properties.Mask.EditMask = "\\d+";
            this.txtGroupId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtGroupId.Properties.MaxLength = 50;
            this.txtGroupId.Properties.ReadOnly = true;
            this.txtGroupId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtGroupId.Size = new System.Drawing.Size(127, 22);
            this.txtGroupId.TabIndex = 209;
            // 
            // dlgChangeStatus
            // 
            this.AcceptButton = this.btnSave;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 383);
            this.ControlBox = false;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtGroupId);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnAddLinkedRequest);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listRequests);
            this.Controls.Add(this.btnDeleteExpertNo);
            this.Controls.Add(this.txtExpertNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.btnDeleteReviewNo);
            this.Controls.Add(this.txtReviewNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSerial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboNewRequestStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOldRequestStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.lblRequestType);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.txtRequestID);
            this.Controls.Add(this.lblIRequestID);
            this.Controls.Add(this.cboNotes);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "dlgChangeStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تغییر وضعیت پیشنهاد";
            ((System.ComponentModel.ISupportInitialize)(this.txtRequestID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboNewRequestStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReviewNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNotes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpertNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupId.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.TextEdit txtRequestID;
        private System.Windows.Forms.Label lblIRequestID;
        public DevExpress.XtraEditors.TextEdit txtCustomerName;
        private System.Windows.Forms.Label lblCustomerName;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        public System.Windows.Forms.RichTextBox txtNote;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label lblRequestType;
        private System.Windows.Forms.FlowLayoutPanel pnlBottom;
        private System.Windows.Forms.TextBox txtOldRequestStatus;
        private System.Windows.Forms.Label label2;
        public DevExpress.XtraEditors.ComboBoxEdit cboNewRequestStatus;
        private System.Windows.Forms.Label label3;
        public DevExpress.XtraEditors.TextEdit txtSerial;
        private System.Windows.Forms.Label label1;
        public DevExpress.XtraEditors.TextEdit txtReviewNo;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton btnDeleteReviewNo;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cboNotes;
        private System.Windows.Forms.CheckBox checkBox;
        private DevExpress.XtraEditors.SimpleButton btnDeleteExpertNo;
        public DevExpress.XtraEditors.TextEdit txtExpertNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SimpleButton btnAddLinkedRequest;
        public System.Windows.Forms.CustomControls.FilterdTextBox txtCustomerId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public DevExpress.XtraEditors.CheckedListBoxControl listRequests;
        private System.Windows.Forms.Label label9;
        public DevExpress.XtraEditors.TextEdit txtGroupId;
    }
}