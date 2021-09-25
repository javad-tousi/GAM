namespace GAM.Forms.Profile.Etebarat.MyFiles
{
    partial class dlgAddExpertReportNote
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAddExpertReportNote));
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.tbl1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSubject = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDateAction = new Atf.UI.DateTimeSelector();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            this.tbl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSubject.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.Color.Ivory;
            this.txtNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNote.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.ForeColor = System.Drawing.Color.Blue;
            this.txtNote.Location = new System.Drawing.Point(3, 97);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ReadOnly = true;
            this.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNote.Size = new System.Drawing.Size(330, 76);
            this.txtNote.TabIndex = 2;
            // 
            // lblNote
            // 
            this.lblNote.Location = new System.Drawing.Point(336, 94);
            this.lblNote.Margin = new System.Windows.Forms.Padding(0);
            this.lblNote.Name = "lblNote";
            this.lblNote.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblNote.Size = new System.Drawing.Size(67, 59);
            this.lblNote.TabIndex = 135;
            this.lblNote.Text = "شرح اقدام";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnOk);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 225);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlBottom.Size = new System.Drawing.Size(403, 34);
            this.pnlBottom.TabIndex = 149;
            // 
            // btnOk
            // 
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnOk.Location = new System.Drawing.Point(146, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(254, 29);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "ثبت اطلاعات";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(137, 29);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.EditValue = "";
            this.txtCustomerName.Location = new System.Drawing.Point(3, 66);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.txtCustomerName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Properties.Appearance.Options.UseBackColor = true;
            this.txtCustomerName.Properties.Appearance.Options.UseFont = true;
            this.txtCustomerName.Properties.AutoHeight = false;
            this.txtCustomerName.Properties.ReadOnly = true;
            this.txtCustomerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustomerName.Size = new System.Drawing.Size(330, 24);
            this.txtCustomerName.TabIndex = 1;
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.InsertGalleryImage("undo_16x16.png", "images/history/undo_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/history/undo_16x16.png"), 0);
            this.imageCollection.Images.SetKeyName(0, "undo_16x16.png");
            this.imageCollection.InsertGalleryImage("insertcomment_16x16.png", "images/comments/insertcomment_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/comments/insertcomment_16x16.png"), 1);
            this.imageCollection.Images.SetKeyName(1, "insertcomment_16x16.png");
            this.imageCollection.InsertGalleryImage("reminder_16x16.png", "images/scheduling/reminder_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/scheduling/reminder_16x16.png"), 2);
            this.imageCollection.Images.SetKeyName(2, "reminder_16x16.png");
            // 
            // tbl1
            // 
            this.tbl1.ColumnCount = 2;
            this.tbl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tbl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl1.Controls.Add(this.label2, 0, 0);
            this.tbl1.Controls.Add(this.lblNote, 0, 3);
            this.tbl1.Controls.Add(this.txtNote, 1, 3);
            this.tbl1.Controls.Add(this.label3, 0, 2);
            this.tbl1.Controls.Add(this.txtCustomerName, 1, 2);
            this.tbl1.Controls.Add(this.label4, 0, 1);
            this.tbl1.Controls.Add(this.cboSubject, 1, 1);
            this.tbl1.Controls.Add(this.label1, 1, 4);
            this.tbl1.Controls.Add(this.txtDateAction, 1, 0);
            this.tbl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl1.Location = new System.Drawing.Point(0, 0);
            this.tbl1.Name = "tbl1";
            this.tbl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbl1.RowCount = 5;
            this.tbl1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbl1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbl1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tbl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbl1.Size = new System.Drawing.Size(403, 259);
            this.tbl1.TabIndex = 151;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(336, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 33);
            this.label2.TabIndex = 146;
            this.label2.Text = "تاریخ اقدام";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(336, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 31);
            this.label3.TabIndex = 135;
            this.label3.Text = "نام مشتری";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(336, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 30);
            this.label4.TabIndex = 143;
            this.label4.Text = "نوع اقدام";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboSubject
            // 
            this.cboSubject.Location = new System.Drawing.Point(173, 36);
            this.cboSubject.Name = "cboSubject";
            this.cboSubject.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSubject.Properties.Appearance.Options.UseFont = true;
            this.cboSubject.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSubject.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboSubject.Properties.AutoHeight = false;
            this.cboSubject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSubject.Properties.DropDownRows = 10;
            this.cboSubject.Properties.Items.AddRange(new object[] {
            "کسری مدارک اول",
            "کسری مدارک دوم",
            "تکمیل مدارک و مستندات",
            "بازدید مشتری",
            "تکمیل گزارش کارشناسی",
            "ثبت سامانه جامع اعتباری",
            "ارسال به تهران",
            "عودت پرونده",
            "بدون اقدام",
            "سایر موارد"});
            this.cboSubject.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboSubject.Size = new System.Drawing.Size(160, 24);
            this.cboSubject.TabIndex = 0;
            this.cboSubject.SelectedIndexChanged += new System.EventHandler(this.cboSubject_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(3, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 83);
            this.label1.TabIndex = 144;
            this.label1.Text = "توضیح مهم: کارشناس می بایست پس از تکمیل گزارش کارشناسی حتماً گزینه \"تکمیل گزارش ک" +
    "ارشناسی\" را انتخاب و ثبت نماید در غیر اینصورت گزارش کارشناسی برای ایشان ثبت نخوا" +
    "هد شد!";
            // 
            // txtDateAction
            // 
            this.txtDateAction.CustomFormat = "dd/MM/yyyy";
            this.txtDateAction.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateAction.ForeColor = System.Drawing.Color.Blue;
            this.txtDateAction.Format = Atf.UI.DateTimeSelectorFormat.Custom;
            this.txtDateAction.Location = new System.Drawing.Point(235, 6);
            this.txtDateAction.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.txtDateAction.Name = "txtDateAction";
            this.txtDateAction.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDateAction.Size = new System.Drawing.Size(98, 24);
            this.txtDateAction.TabIndex = 145;
            this.txtDateAction.UsePersianFormat = true;
            this.txtDateAction.ValueChanged += new System.EventHandler(this.txtDateAction_ValueChanged);
            // 
            // dlgAddExpertReportNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 259);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.tbl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "dlgAddExpertReportNote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "توضیحات کارشناسی";
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            this.tbl1.ResumeLayout(false);
            this.tbl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSubject.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.FlowLayoutPanel pnlBottom;
        public DevExpress.XtraEditors.TextEdit txtCustomerName;
        private DevExpress.Utils.ImageCollection imageCollection;
        private System.Windows.Forms.TableLayoutPanel tbl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.ComboBoxEdit cboSubject;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.Label label1;
        private Atf.UI.DateTimeSelector txtDateAction;
        private System.Windows.Forms.Label label2;
    }
}