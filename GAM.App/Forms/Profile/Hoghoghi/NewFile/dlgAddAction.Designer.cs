namespace GAM.Forms.Profile.LegalFile.NewFile
{
    partial class dlgSendMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgSendMessage));
            this.lblNote = new System.Windows.Forms.Label();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.txtContractId = new DevExpress.XtraEditors.TextEdit();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.pnlBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSend = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.pnlMain = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.cboActivities = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContractId.Properties)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboActivities.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNote
            // 
            this.lblNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNote.Location = new System.Drawing.Point(373, 92);
            this.lblNote.Margin = new System.Windows.Forms.Padding(0);
            this.lblNote.Name = "lblNote";
            this.lblNote.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblNote.Size = new System.Drawing.Size(57, 105);
            this.lblNote.TabIndex = 135;
            this.lblNote.Text = "شرح اقدام";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Dock = System.Windows.Forms.DockStyle.Top;
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
            this.txtCustomerName.Size = new System.Drawing.Size(367, 23);
            this.txtCustomerName.TabIndex = 2;
            // 
            // txtContractId
            // 
            this.txtContractId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContractId.EditValue = "";
            this.txtContractId.Enabled = false;
            this.txtContractId.Location = new System.Drawing.Point(3, 3);
            this.txtContractId.Name = "txtContractId";
            this.txtContractId.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.txtContractId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContractId.Properties.Appearance.Options.UseBackColor = true;
            this.txtContractId.Properties.Appearance.Options.UseFont = true;
            this.txtContractId.Properties.Appearance.Options.UseTextOptions = true;
            this.txtContractId.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtContractId.Properties.AutoHeight = false;
            this.txtContractId.Properties.Mask.EditMask = "\\d+";
            this.txtContractId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtContractId.Properties.MaxLength = 15;
            this.txtContractId.Properties.ReadOnly = true;
            this.txtContractId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtContractId.Size = new System.Drawing.Size(367, 24);
            this.txtContractId.TabIndex = 1;
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.Color.White;
            this.txtNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNote.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(3, 95);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNote.Size = new System.Drawing.Size(367, 99);
            this.txtNote.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnSend);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 220);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlBottom.Size = new System.Drawing.Size(430, 34);
            this.pnlBottom.TabIndex = 141;
            // 
            // btnSend
            // 
            this.btnSend.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.ImageOptions.Image")));
            this.btnSend.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnSend.Location = new System.Drawing.Point(146, 3);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(281, 29);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "ثبت اطلاعات";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
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
            // pnlMain
            // 
            this.pnlMain.ColumnCount = 2;
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 373F));
            this.pnlMain.Controls.Add(this.label3, 0, 0);
            this.pnlMain.Controls.Add(this.txtContractId, 1, 0);
            this.pnlMain.Controls.Add(this.label2, 0, 1);
            this.pnlMain.Controls.Add(this.lblNote, 0, 3);
            this.pnlMain.Controls.Add(this.label1, 0, 2);
            this.pnlMain.Controls.Add(this.txtNote, 1, 3);
            this.pnlMain.Controls.Add(this.cboActivities, 1, 2);
            this.pnlMain.Controls.Add(this.txtCustomerName, 1, 1);
            this.pnlMain.Controls.Add(this.checkBox, 1, 4);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlMain.RowCount = 5;
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlMain.Size = new System.Drawing.Size(430, 220);
            this.pnlMain.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(373, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 30);
            this.label3.TabIndex = 143;
            this.label3.Text = "ش.قرارداد";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(373, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 29);
            this.label2.TabIndex = 135;
            this.label2.Text = "نام مدیون";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox.ForeColor = System.Drawing.Color.Blue;
            this.checkBox.Location = new System.Drawing.Point(3, 200);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(367, 17);
            this.checkBox.TabIndex = 144;
            this.checkBox.Text = "مایلم این اقدام برای تمامی قراردادهای مرتبط با این قرارداد هم اجرا شود";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // cboActivities
            // 
            this.cboActivities.Location = new System.Drawing.Point(224, 62);
            this.cboActivities.Name = "cboActivities";
            this.cboActivities.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.cboActivities.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboActivities.Properties.Appearance.Options.UseBackColor = true;
            this.cboActivities.Properties.Appearance.Options.UseFont = true;
            this.cboActivities.Properties.AutoHeight = false;
            this.cboActivities.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboActivities.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("اقدام", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("عودت", "2", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("توقف اقدامات قانونی", 10, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("مختومه", "11", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("توضیحات", 12, -1)});
            this.cboActivities.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboActivities.Size = new System.Drawing.Size(146, 27);
            this.cboActivities.TabIndex = 142;
            this.cboActivities.SelectedIndexChanged += new System.EventHandler(this.cboMessageType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(373, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 33);
            this.label1.TabIndex = 143;
            this.label1.Text = "نوع اقدام";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dlgSendMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 254);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgSendMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ثبت اقدامات";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContractId.Properties)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboActivities.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNote;
        public DevExpress.XtraEditors.TextEdit txtCustomerName;
        public DevExpress.XtraEditors.TextEdit txtContractId;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.FlowLayoutPanel pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnSend;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.TableLayoutPanel pnlMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ImageComboBoxEdit cboActivities;
    }
}