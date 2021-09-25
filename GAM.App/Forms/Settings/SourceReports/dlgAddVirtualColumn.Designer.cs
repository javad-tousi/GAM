namespace GAM.Forms.Settings.SourceReports
{
    partial class dlgAddVirtualColumn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAddVirtualColumn));
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlBotton = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddColumn = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCaption = new DevExpress.XtraEditors.TextEdit();
            this.cboType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.cboUnitPrice = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.pnlBotton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnitPrice.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.EditValue = "";
            this.txtName.Location = new System.Drawing.Point(10, 13);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Properties.Appearance.Options.UseFont = true;
            this.txtName.Properties.AutoHeight = false;
            this.txtName.Properties.Mask.EditMask = "[a-zA-Z0-9_]+";
            this.txtName.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtName.Size = new System.Drawing.Size(270, 24);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "نام لاتین ستون";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(281, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 151;
            this.label4.Text = "نوع محتوا";
            // 
            // pnlBotton
            // 
            this.pnlBotton.Controls.Add(this.btnAddColumn);
            this.pnlBotton.Controls.Add(this.btnCancel);
            this.pnlBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotton.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlBotton.Location = new System.Drawing.Point(0, 97);
            this.pnlBotton.Name = "pnlBotton";
            this.pnlBotton.Size = new System.Drawing.Size(358, 35);
            this.pnlBotton.TabIndex = 152;
            // 
            // btnAddColumn
            // 
            this.btnAddColumn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddColumn.ImageOptions.Image")));
            this.btnAddColumn.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnAddColumn.Location = new System.Drawing.Point(113, 3);
            this.btnAddColumn.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.btnAddColumn.Name = "btnAddColumn";
            this.btnAddColumn.Size = new System.Drawing.Size(240, 29);
            this.btnAddColumn.TabIndex = 6;
            this.btnAddColumn.Text = "افزودن ستون به لیست";
            this.btnAddColumn.Click += new System.EventHandler(this.btnAddColumn_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 29);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(282, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 154;
            this.label5.Text = "عنوان نمایشی";
            // 
            // txtCaption
            // 
            this.txtCaption.EditValue = "";
            this.txtCaption.Location = new System.Drawing.Point(10, 40);
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaption.Properties.Appearance.Options.UseFont = true;
            this.txtCaption.Properties.AutoHeight = false;
            this.txtCaption.Properties.Mask.EditMask = "[a-zA-Z]+";
            this.txtCaption.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCaption.Size = new System.Drawing.Size(270, 24);
            this.txtCaption.TabIndex = 3;
            // 
            // cboType
            // 
            this.cboType.EditValue = "System.String";
            this.cboType.Location = new System.Drawing.Point(168, 67);
            this.cboType.Margin = new System.Windows.Forms.Padding(0);
            this.cboType.Name = "cboType";
            this.cboType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboType.Properties.Appearance.Options.UseFont = true;
            this.cboType.Properties.AutoHeight = false;
            this.cboType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboType.Properties.Items.AddRange(new object[] {
            "System.String",
            "System.Int32",
            "System.Int64",
            "System.Double"});
            this.cboType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboType.Size = new System.Drawing.Size(112, 24);
            this.cboType.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(119, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 158;
            this.label7.Text = "واحد";
            // 
            // cboUnitPrice
            // 
            this.cboUnitPrice.EditValue = "";
            this.cboUnitPrice.Location = new System.Drawing.Point(10, 67);
            this.cboUnitPrice.Name = "cboUnitPrice";
            this.cboUnitPrice.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cboUnitPrice.Properties.Appearance.Options.UseFont = true;
            this.cboUnitPrice.Properties.AutoHeight = false;
            this.cboUnitPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUnitPrice.Properties.Items.AddRange(new object[] {
            "",
            "Rial",
            "MillionRial",
            "MilliardRial"});
            this.cboUnitPrice.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboUnitPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboUnitPrice.Size = new System.Drawing.Size(108, 24);
            this.cboUnitPrice.TabIndex = 5;
            // 
            // dlgAddVirtualColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 132);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCaption);
            this.Controls.Add(this.pnlBotton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.cboUnitPrice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgAddVirtualColumn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "اطلاعات ستون";
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.pnlBotton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCaption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnitPrice.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel pnlBotton;
        private DevExpress.XtraEditors.SimpleButton btnAddColumn;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtCaption;
        private DevExpress.XtraEditors.ComboBoxEdit cboType;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.ComboBoxEdit cboUnitPrice;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}