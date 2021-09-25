namespace GAM.Forms.Profile.Etebarat.MyFiles
{
    partial class dlgRejectLoanFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgRejectLoanFile));
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.tbl1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboRejectType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            this.tbl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboRejectType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.Color.Ivory;
            this.txtNote.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.ForeColor = System.Drawing.Color.Blue;
            this.txtNote.Location = new System.Drawing.Point(3, 64);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ReadOnly = true;
            this.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNote.Size = new System.Drawing.Size(330, 53);
            this.txtNote.TabIndex = 2;
            // 
            // lblNote
            // 
            this.lblNote.Location = new System.Drawing.Point(336, 61);
            this.lblNote.Margin = new System.Windows.Forms.Padding(0);
            this.lblNote.Name = "lblNote";
            this.lblNote.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblNote.Size = new System.Drawing.Size(67, 59);
            this.lblNote.TabIndex = 135;
            this.lblNote.Text = "شرح مختومه";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnOk);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 121);
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
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "مختومه شدن";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(137, 29);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.EditValue = "";
            this.txtCustomerName.Location = new System.Drawing.Point(3, 33);
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
            this.tbl1.Controls.Add(this.lblNote, 0, 2);
            this.tbl1.Controls.Add(this.txtNote, 1, 2);
            this.tbl1.Controls.Add(this.label3, 0, 1);
            this.tbl1.Controls.Add(this.txtCustomerName, 1, 1);
            this.tbl1.Controls.Add(this.label4, 0, 0);
            this.tbl1.Controls.Add(this.cboRejectType, 1, 0);
            this.tbl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbl1.Location = new System.Drawing.Point(0, 0);
            this.tbl1.Name = "tbl1";
            this.tbl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbl1.RowCount = 3;
            this.tbl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tbl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tbl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbl1.Size = new System.Drawing.Size(403, 120);
            this.tbl1.TabIndex = 151;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(336, 30);
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
            this.label4.Location = new System.Drawing.Point(336, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 30);
            this.label4.TabIndex = 143;
            this.label4.Text = "علت مختومه";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboRejectType
            // 
            this.cboRejectType.Location = new System.Drawing.Point(173, 3);
            this.cboRejectType.Name = "cboRejectType";
            this.cboRejectType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRejectType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboRejectType.Properties.AutoHeight = false;
            this.cboRejectType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboRejectType.Properties.Items.AddRange(new object[] {
            "بررسی و تکمیل مدارک",
            "رفع نقص و تکمیل مدارک",
            "در حدود اختیارت حوزه/شعبه",
            "کسری مدارک",
            "عدم تکمیل مدارک",
            "مذاکره تلفنی با شعبه",
            "سایر موارد"});
            this.cboRejectType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboRejectType.Size = new System.Drawing.Size(160, 24);
            this.cboRejectType.TabIndex = 0;
            this.cboRejectType.SelectedIndexChanged += new System.EventHandler(this.cboRejectType_SelectedIndexChanged);
            // 
            // dlgRejectLoanFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 155);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.tbl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "dlgRejectLoanFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "علت مختومه شدن";
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            this.tbl1.ResumeLayout(false);
            this.tbl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboRejectType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.FlowLayoutPanel pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        public DevExpress.XtraEditors.TextEdit txtCustomerName;
        private DevExpress.Utils.ImageCollection imageCollection;
        private System.Windows.Forms.TableLayoutPanel tbl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.ComboBoxEdit cboRejectType;
    }
}