namespace GAM.Forms.Settings.SourceReports
{
    partial class dlgAddSourceReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAddSourceReport));
            this.txtSourceName = new DevExpress.XtraEditors.TextEdit();
            this.lblReportName = new System.Windows.Forms.Label();
            this.cboReferenceNames = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblSourceName = new System.Windows.Forms.Label();
            this.txtSourceId = new DevExpress.XtraEditors.TextEdit();
            this.lblSourceId = new System.Windows.Forms.Label();
            this.pnlBotton = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddSource = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtSourceName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboReferenceNames.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSourceId.Properties)).BeginInit();
            this.pnlBotton.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSourceName
            // 
            this.txtSourceName.EditValue = "";
            this.txtSourceName.Location = new System.Drawing.Point(9, 53);
            this.txtSourceName.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.txtSourceName.Name = "txtSourceName";
            this.txtSourceName.Properties.AutoHeight = false;
            this.txtSourceName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSourceName.Size = new System.Drawing.Size(297, 24);
            this.txtSourceName.TabIndex = 1;
            // 
            // lblReportName
            // 
            this.lblReportName.AutoSize = true;
            this.lblReportName.Location = new System.Drawing.Point(308, 58);
            this.lblReportName.Margin = new System.Windows.Forms.Padding(0);
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Size = new System.Drawing.Size(53, 13);
            this.lblReportName.TabIndex = 8;
            this.lblReportName.Text = "نام گزارش";
            this.lblReportName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboReferenceNames
            // 
            this.cboReferenceNames.EditValue = "سایر";
            this.cboReferenceNames.Location = new System.Drawing.Point(125, 27);
            this.cboReferenceNames.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.cboReferenceNames.Name = "cboReferenceNames";
            this.cboReferenceNames.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReferenceNames.Properties.Appearance.Options.UseFont = true;
            this.cboReferenceNames.Properties.AutoHeight = false;
            this.cboReferenceNames.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboReferenceNames.Properties.Items.AddRange(new object[] {
            "سامانه نما",
            "سامانه مراجع ذیصلاح",
            "سامانه فرم های آماری",
            "سامانه MIS",
            "سامانه Branch",
            "سایر"});
            this.cboReferenceNames.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboReferenceNames.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboReferenceNames.Size = new System.Drawing.Size(181, 24);
            this.cboReferenceNames.TabIndex = 0;
            // 
            // lblSourceName
            // 
            this.lblSourceName.AutoSize = true;
            this.lblSourceName.Location = new System.Drawing.Point(308, 32);
            this.lblSourceName.Margin = new System.Windows.Forms.Padding(0);
            this.lblSourceName.Name = "lblSourceName";
            this.lblSourceName.Size = new System.Drawing.Size(55, 13);
            this.lblSourceName.TabIndex = 10;
            this.lblSourceName.Text = "نام سامانه";
            this.lblSourceName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSourceId
            // 
            this.txtSourceId.EditValue = "";
            this.txtSourceId.Location = new System.Drawing.Point(243, 79);
            this.txtSourceId.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.txtSourceId.Name = "txtSourceId";
            this.txtSourceId.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtSourceId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSourceId.Properties.Appearance.Options.UseBackColor = true;
            this.txtSourceId.Properties.Appearance.Options.UseFont = true;
            this.txtSourceId.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSourceId.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtSourceId.Properties.AutoHeight = false;
            this.txtSourceId.Properties.Mask.EditMask = "\\d+";
            this.txtSourceId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSourceId.Properties.MaxLength = 10;
            this.txtSourceId.Size = new System.Drawing.Size(63, 25);
            this.txtSourceId.TabIndex = 2;
            // 
            // lblSourceId
            // 
            this.lblSourceId.AutoSize = true;
            this.lblSourceId.Location = new System.Drawing.Point(308, 85);
            this.lblSourceId.Margin = new System.Windows.Forms.Padding(0);
            this.lblSourceId.Name = "lblSourceId";
            this.lblSourceId.Size = new System.Drawing.Size(51, 13);
            this.lblSourceId.TabIndex = 12;
            this.lblSourceId.Text = "کد گزارش";
            this.lblSourceId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlBotton
            // 
            this.pnlBotton.Controls.Add(this.btnAddSource);
            this.pnlBotton.Controls.Add(this.btnCancel);
            this.pnlBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotton.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlBotton.Location = new System.Drawing.Point(0, 117);
            this.pnlBotton.Name = "pnlBotton";
            this.pnlBotton.Size = new System.Drawing.Size(366, 35);
            this.pnlBotton.TabIndex = 13;
            // 
            // btnAddSource
            // 
            this.btnAddSource.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddSource.ImageOptions.Image")));
            this.btnAddSource.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnAddSource.Location = new System.Drawing.Point(99, 3);
            this.btnAddSource.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.btnAddSource.Name = "btnAddSource";
            this.btnAddSource.Size = new System.Drawing.Size(262, 29);
            this.btnAddSource.TabIndex = 3;
            this.btnAddSource.Text = "افزودن منبع به لیست";
            this.btnAddSource.Click += new System.EventHandler(this.btnAddSource_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 29);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dlgAddSourceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 152);
            this.Controls.Add(this.pnlBotton);
            this.Controls.Add(this.lblSourceId);
            this.Controls.Add(this.txtSourceId);
            this.Controls.Add(this.lblSourceName);
            this.Controls.Add(this.cboReferenceNames);
            this.Controls.Add(this.lblReportName);
            this.Controls.Add(this.txtSourceName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgAddSourceReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "افزودن منبع اطلاعاتی";
            ((System.ComponentModel.ISupportInitialize)(this.txtSourceName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboReferenceNames.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSourceId.Properties)).EndInit();
            this.pnlBotton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtSourceName;
        private System.Windows.Forms.Label lblReportName;
        private DevExpress.XtraEditors.ComboBoxEdit cboReferenceNames;
        private System.Windows.Forms.Label lblSourceName;
        private DevExpress.XtraEditors.TextEdit txtSourceId;
        private System.Windows.Forms.Label lblSourceId;
        private System.Windows.Forms.FlowLayoutPanel pnlBotton;
        private DevExpress.XtraEditors.SimpleButton btnAddSource;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}