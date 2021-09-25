namespace GAM.Forms.Settings.SourceReports
{
    partial class dlgAddCustomColumn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAddCustomColumn));
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExtension = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlBotton = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddCustomColumn = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteCustomColumn = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCaption = new DevExpress.XtraEditors.TextEdit();
            this.cboType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboUnitPrice = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExtension.Properties)).BeginInit();
            this.pnlBotton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnitPrice.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.EditValue = "";
            this.txtName.Location = new System.Drawing.Point(12, 17);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Properties.Appearance.Options.UseFont = true;
            this.txtName.Properties.AutoHeight = false;
            this.txtName.Properties.Mask.EditMask = "[a-zA-Z0-9]+";
            this.txtName.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtName.Size = new System.Drawing.Size(289, 24);
            this.txtName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "فورمول";
            // 
            // txtExtension
            // 
            this.txtExtension.EditValue = "";
            this.txtExtension.Location = new System.Drawing.Point(12, 71);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExtension.Properties.Appearance.Options.UseFont = true;
            this.txtExtension.Properties.Appearance.Options.UseTextOptions = true;
            this.txtExtension.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.txtExtension.Properties.AutoHeight = false;
            this.txtExtension.Properties.Mask.EditMask = "[a-zA-Z]+";
            this.txtExtension.Properties.NullValuePrompt = "[ColumnName1]+[ColumnName2]";
            this.txtExtension.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtExtension.Size = new System.Drawing.Size(289, 55);
            this.txtExtension.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(302, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 151;
            this.label4.Text = "نوع محتوا";
            // 
            // pnlBotton
            // 
            this.pnlBotton.Controls.Add(this.btnAddCustomColumn);
            this.pnlBotton.Controls.Add(this.btnDeleteCustomColumn);
            this.pnlBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotton.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlBotton.Location = new System.Drawing.Point(0, 162);
            this.pnlBotton.Name = "pnlBotton";
            this.pnlBotton.Size = new System.Drawing.Size(381, 35);
            this.pnlBotton.TabIndex = 152;
            // 
            // btnAddCustomColumn
            // 
            this.btnAddCustomColumn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCustomColumn.ImageOptions.Image")));
            this.btnAddCustomColumn.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnAddCustomColumn.Location = new System.Drawing.Point(113, 3);
            this.btnAddCustomColumn.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.btnAddCustomColumn.Name = "btnAddCustomColumn";
            this.btnAddCustomColumn.Size = new System.Drawing.Size(263, 29);
            this.btnAddCustomColumn.TabIndex = 5;
            this.btnAddCustomColumn.Text = "افزودن ستون به لیست";
            this.btnAddCustomColumn.Click += new System.EventHandler(this.btnAddCustomColumn_Click);
            // 
            // btnDeleteCustomColumn
            // 
            this.btnDeleteCustomColumn.Enabled = false;
            this.btnDeleteCustomColumn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteCustomColumn.ImageOptions.Image")));
            this.btnDeleteCustomColumn.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnDeleteCustomColumn.Location = new System.Drawing.Point(3, 3);
            this.btnDeleteCustomColumn.Name = "btnDeleteCustomColumn";
            this.btnDeleteCustomColumn.Size = new System.Drawing.Size(104, 29);
            this.btnDeleteCustomColumn.TabIndex = 6;
            this.btnDeleteCustomColumn.Text = "حذف ستون";
            this.btnDeleteCustomColumn.Click += new System.EventHandler(this.btnDeleteCustomColumn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 154;
            this.label5.Text = "عنوان نمایشی";
            // 
            // txtCaption
            // 
            this.txtCaption.EditValue = "";
            this.txtCaption.Location = new System.Drawing.Point(12, 44);
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaption.Properties.Appearance.Options.UseFont = true;
            this.txtCaption.Properties.AutoHeight = false;
            this.txtCaption.Properties.Mask.EditMask = "[a-zA-Z]+";
            this.txtCaption.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCaption.Size = new System.Drawing.Size(289, 24);
            this.txtCaption.TabIndex = 3;
            // 
            // cboType
            // 
            this.cboType.EditValue = "System.String";
            this.cboType.Location = new System.Drawing.Point(189, 129);
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
            this.cboType.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "نام لاتین ستون";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(121, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 160;
            this.label7.Text = "واحد";
            // 
            // cboUnitPrice
            // 
            this.cboUnitPrice.EditValue = "";
            this.cboUnitPrice.Location = new System.Drawing.Point(12, 129);
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
            this.cboUnitPrice.TabIndex = 4;
            // 
            // dlgAddCustomColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 197);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCaption);
            this.Controls.Add(this.pnlBotton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtExtension);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.cboUnitPrice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgAddCustomColumn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "اطلاعات ستون سفارشی";
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExtension.Properties)).EndInit();
            this.pnlBotton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCaption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnitPrice.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtName;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtExtension;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel pnlBotton;
        private DevExpress.XtraEditors.SimpleButton btnAddCustomColumn;
        private DevExpress.XtraEditors.SimpleButton btnDeleteCustomColumn;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtCaption;
        private DevExpress.XtraEditors.ComboBoxEdit cboType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.ComboBoxEdit cboUnitPrice;
    }
}