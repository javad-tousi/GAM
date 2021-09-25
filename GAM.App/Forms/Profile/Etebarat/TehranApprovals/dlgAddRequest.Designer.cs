namespace GAM.Forms.Profile.Etebarat.TehranApprovals
{
    partial class dlgAddRequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAddRequest));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblPleaseWait = new System.Windows.Forms.Label();
            this.txtRequestId = new DevExpress.XtraEditors.TextEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.pnlBotton = new System.Windows.Forms.FlowLayoutPanel();
            this.lblProvinceLetterNo = new System.Windows.Forms.Label();
            this.txtProvinceLetterNo = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.pnlTop = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.colCheckbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModifiedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequestType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFacilityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequestAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreditCommitee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtRequestId.Properties)).BeginInit();
            this.pnlBotton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvinceLetterNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPleaseWait
            // 
            this.lblPleaseWait.AutoSize = true;
            this.lblPleaseWait.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPleaseWait.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblPleaseWait.Location = new System.Drawing.Point(258, 13);
            this.lblPleaseWait.Margin = new System.Windows.Forms.Padding(3, 13, 3, 0);
            this.lblPleaseWait.Name = "lblPleaseWait";
            this.lblPleaseWait.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPleaseWait.Size = new System.Drawing.Size(88, 13);
            this.lblPleaseWait.TabIndex = 3;
            this.lblPleaseWait.Text = "کمی صبر کنید ...";
            this.lblPleaseWait.Visible = false;
            // 
            // txtRequestId
            // 
            this.txtRequestId.EditValue = "";
            this.txtRequestId.Location = new System.Drawing.Point(417, 7);
            this.txtRequestId.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.txtRequestId.Name = "txtRequestId";
            this.txtRequestId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequestId.Properties.Appearance.Options.UseFont = true;
            this.txtRequestId.Properties.AutoHeight = false;
            this.txtRequestId.Properties.Mask.EditMask = "\\d+";
            this.txtRequestId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtRequestId.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtRequestId.Properties.MaxLength = 15;
            this.txtRequestId.Properties.NullText = "0";
            this.txtRequestId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRequestId.Size = new System.Drawing.Size(118, 24);
            this.txtRequestId.TabIndex = 1;
            this.txtRequestId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextControl_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Location = new System.Drawing.Point(352, 6);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(59, 26);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(541, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 12, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 213;
            this.label1.Text = "شماره پیشنهاد";
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(197, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 29);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "بستن";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(298, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(320, 29);
            this.btnSave.TabIndex = 10;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "افزودن موارد انتخاب شده به لیست پیشنهادات مدیریت شعب";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlBotton
            // 
            this.pnlBotton.Controls.Add(this.btnSave);
            this.pnlBotton.Controls.Add(this.btnCancel);
            this.pnlBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotton.Location = new System.Drawing.Point(0, 255);
            this.pnlBotton.Name = "pnlBotton";
            this.pnlBotton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlBotton.Size = new System.Drawing.Size(621, 35);
            this.pnlBotton.TabIndex = 3;
            // 
            // lblProvinceLetterNo
            // 
            this.lblProvinceLetterNo.AutoSize = true;
            this.lblProvinceLetterNo.ForeColor = System.Drawing.Color.Black;
            this.lblProvinceLetterNo.Location = new System.Drawing.Point(538, 232);
            this.lblProvinceLetterNo.Name = "lblProvinceLetterNo";
            this.lblProvinceLetterNo.Size = new System.Drawing.Size(73, 13);
            this.lblProvinceLetterNo.TabIndex = 216;
            this.lblProvinceLetterNo.Text = "ش.نامه استان";
            // 
            // txtProvinceLetterNo
            // 
            this.txtProvinceLetterNo.EditValue = "";
            this.txtProvinceLetterNo.Location = new System.Drawing.Point(417, 227);
            this.txtProvinceLetterNo.Name = "txtProvinceLetterNo";
            this.txtProvinceLetterNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProvinceLetterNo.Properties.Appearance.Options.UseFont = true;
            this.txtProvinceLetterNo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtProvinceLetterNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtProvinceLetterNo.Properties.Mask.EditMask = "\\d+";
            this.txtProvinceLetterNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtProvinceLetterNo.Properties.MaxLength = 15;
            this.txtProvinceLetterNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtProvinceLetterNo.Size = new System.Drawing.Size(118, 22);
            this.txtProvinceLetterNo.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(621, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 221;
            this.label2.Text = "لیست پیشنهادات";
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
            this.colModifiedDate,
            this.colRequestType,
            this.colCustomerName,
            this.colFacilityName,
            this.colRequestAmount,
            this.colCreditCommitee});
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(3, 17);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(615, 164);
            this.dataGrid.TabIndex = 4;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.txtRequestId);
            this.pnlTop.Controls.Add(this.btnSearch);
            this.pnlTop.Controls.Add(this.lblPleaseWait);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlTop.Size = new System.Drawing.Size(621, 37);
            this.pnlTop.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGrid);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(621, 184);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "لیست پیشنهادات شعبه";
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
            // colModifiedDate
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colModifiedDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.colModifiedDate.HeaderText = "تاریخ تغییرات";
            this.colModifiedDate.Name = "colModifiedDate";
            this.colModifiedDate.ReadOnly = true;
            this.colModifiedDate.Width = 90;
            // 
            // colRequestType
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colRequestType.DefaultCellStyle = dataGridViewCellStyle7;
            this.colRequestType.HeaderText = "نوع پیشنهاد";
            this.colRequestType.Name = "colRequestType";
            this.colRequestType.ReadOnly = true;
            // 
            // colCustomerName
            // 
            this.colCustomerName.HeaderText = "نام متقاضی";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Width = 250;
            // 
            // colFacilityName
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colFacilityName.DefaultCellStyle = dataGridViewCellStyle8;
            this.colFacilityName.HeaderText = "نوع تسهیلات";
            this.colFacilityName.Name = "colFacilityName";
            this.colFacilityName.ReadOnly = true;
            this.colFacilityName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFacilityName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colFacilityName.Width = 250;
            // 
            // colRequestAmount
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colRequestAmount.DefaultCellStyle = dataGridViewCellStyle9;
            this.colRequestAmount.HeaderText = "مبلغ";
            this.colRequestAmount.Name = "colRequestAmount";
            this.colRequestAmount.ReadOnly = true;
            this.colRequestAmount.Width = 80;
            // 
            // colCreditCommitee
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCreditCommitee.DefaultCellStyle = dataGridViewCellStyle10;
            this.colCreditCommitee.HeaderText = "کمیته اعتباری";
            this.colCreditCommitee.Name = "colCreditCommitee";
            this.colCreditCommitee.ReadOnly = true;
            // 
            // dlgAddRequest
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 290);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblProvinceLetterNo);
            this.Controls.Add(this.txtProvinceLetterNo);
            this.Controls.Add(this.pnlBotton);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "dlgAddRequest";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تغییر کمیته اعتباری";
            ((System.ComponentModel.ISupportInitialize)(this.txtRequestId.Properties)).EndInit();
            this.pnlBotton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtProvinceLetterNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPleaseWait;
        private DevExpress.XtraEditors.TextEdit txtRequestId;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.FlowLayoutPanel pnlBotton;
        private System.Windows.Forms.Label lblProvinceLetterNo;
        public DevExpress.XtraEditors.TextEdit txtProvinceLetterNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.FlowLayoutPanel pnlTop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifiedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequestType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFacilityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequestAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreditCommitee;
    }
}