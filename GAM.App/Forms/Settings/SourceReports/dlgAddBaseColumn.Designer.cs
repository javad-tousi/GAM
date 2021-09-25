namespace GAM.Forms.Settings.SourceReports
{
    partial class dlgAddBaseColumn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAddBaseColumn));
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHeaderText = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlBotton = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddColumn = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCaption = new DevExpress.XtraEditors.TextEdit();
            this.cboType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboUnitPrice = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtHeaderLocationY = new DevExpress.XtraEditors.SpinEdit();
            this.txtHeaderLocationX = new DevExpress.XtraEditors.SpinEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIndex = new DevExpress.XtraEditors.SpinEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSetHeaderText = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderText.Properties)).BeginInit();
            this.pnlBotton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnitPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderLocationY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderLocationX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndex.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.EditValue = "";
            this.txtName.Location = new System.Drawing.Point(27, 45);
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
            this.label1.Location = new System.Drawing.Point(299, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "نام لاتین ستون";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 23);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "موقعیت عنوان";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "عنوان ثابت ستون";
            // 
            // txtHeaderText
            // 
            this.txtHeaderText.EditValue = "";
            this.txtHeaderText.Location = new System.Drawing.Point(27, 72);
            this.txtHeaderText.Name = "txtHeaderText";
            this.txtHeaderText.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeaderText.Properties.Appearance.Options.UseFont = true;
            this.txtHeaderText.Properties.AutoHeight = false;
            this.txtHeaderText.Properties.Mask.EditMask = "[a-zA-Z]+";
            this.txtHeaderText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtHeaderText.Size = new System.Drawing.Size(270, 24);
            this.txtHeaderText.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(298, 131);
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
            this.pnlBotton.Location = new System.Drawing.Point(0, 157);
            this.pnlBotton.Name = "pnlBotton";
            this.pnlBotton.Size = new System.Drawing.Size(381, 35);
            this.pnlBotton.TabIndex = 152;
            // 
            // btnAddColumn
            // 
            this.btnAddColumn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddColumn.ImageOptions.Image")));
            this.btnAddColumn.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnAddColumn.Location = new System.Drawing.Point(113, 3);
            this.btnAddColumn.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.btnAddColumn.Name = "btnAddColumn";
            this.btnAddColumn.Size = new System.Drawing.Size(263, 29);
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
            this.label5.Location = new System.Drawing.Point(299, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 154;
            this.label5.Text = "عنوان نمایشی";
            // 
            // txtCaption
            // 
            this.txtCaption.EditValue = "";
            this.txtCaption.Location = new System.Drawing.Point(27, 99);
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
            this.cboType.Location = new System.Drawing.Point(185, 126);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(299, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 156;
            this.label6.Text = "شماره ستون";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(136, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 158;
            this.label7.Text = "واحد";
            // 
            // cboUnitPrice
            // 
            this.cboUnitPrice.EditValue = "";
            this.cboUnitPrice.Location = new System.Drawing.Point(27, 126);
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
            // txtHeaderLocationY
            // 
            this.txtHeaderLocationY.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtHeaderLocationY.Location = new System.Drawing.Point(27, 18);
            this.txtHeaderLocationY.Name = "txtHeaderLocationY";
            this.txtHeaderLocationY.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeaderLocationY.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtHeaderLocationY.Properties.Appearance.Options.UseFont = true;
            this.txtHeaderLocationY.Properties.Appearance.Options.UseForeColor = true;
            this.txtHeaderLocationY.Properties.AutoHeight = false;
            this.txtHeaderLocationY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtHeaderLocationY.Properties.Mask.EditMask = "n0";
            this.txtHeaderLocationY.Properties.MaxValue = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtHeaderLocationY.Size = new System.Drawing.Size(48, 24);
            this.txtHeaderLocationY.TabIndex = 0;
            this.txtHeaderLocationY.TabStop = false;
            this.txtHeaderLocationY.EditValueChanged += new System.EventHandler(this.txtHeaderLocationY_EditValueChanged);
            // 
            // txtHeaderLocationX
            // 
            this.txtHeaderLocationX.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtHeaderLocationX.Location = new System.Drawing.Point(100, 18);
            this.txtHeaderLocationX.Name = "txtHeaderLocationX";
            this.txtHeaderLocationX.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeaderLocationX.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.txtHeaderLocationX.Properties.Appearance.Options.UseFont = true;
            this.txtHeaderLocationX.Properties.Appearance.Options.UseForeColor = true;
            this.txtHeaderLocationX.Properties.AutoHeight = false;
            this.txtHeaderLocationX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtHeaderLocationX.Properties.Mask.EditMask = "n0";
            this.txtHeaderLocationX.Properties.MaxValue = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtHeaderLocationX.Size = new System.Drawing.Size(48, 24);
            this.txtHeaderLocationX.TabIndex = 0;
            this.txtHeaderLocationX.TabStop = false;
            this.txtHeaderLocationX.EditValueChanged += new System.EventHandler(this.txtHeaderLocationX_EditValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(81, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 162;
            this.label8.Text = "X:";
            // 
            // txtIndex
            // 
            this.txtIndex.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtIndex.Location = new System.Drawing.Point(249, 18);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtIndex.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndex.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.txtIndex.Properties.Appearance.Options.UseBackColor = true;
            this.txtIndex.Properties.Appearance.Options.UseFont = true;
            this.txtIndex.Properties.Appearance.Options.UseForeColor = true;
            this.txtIndex.Properties.AutoHeight = false;
            this.txtIndex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtIndex.Properties.Mask.EditMask = "n0";
            this.txtIndex.Properties.MaxValue = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtIndex.Size = new System.Drawing.Size(48, 24);
            this.txtIndex.TabIndex = 0;
            this.txtIndex.TabStop = false;
            this.txtIndex.EditValueChanged += new System.EventHandler(this.txtIndex_EditValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(231, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 164;
            this.label9.Text = "X:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 13);
            this.label10.TabIndex = 165;
            this.label10.Text = "Y:";
            // 
            // btnSetHeaderText
            // 
            this.btnSetHeaderText.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSetHeaderText.ImageOptions.Image")));
            this.btnSetHeaderText.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSetHeaderText.Location = new System.Drawing.Point(4, 73);
            this.btnSetHeaderText.Name = "btnSetHeaderText";
            this.btnSetHeaderText.Size = new System.Drawing.Size(21, 23);
            this.btnSetHeaderText.TabIndex = 166;
            this.btnSetHeaderText.Click += new System.EventHandler(this.btnSetHeaderText_Click);
            // 
            // dlgAddBaseColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 192);
            this.Controls.Add(this.btnSetHeaderText);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtIndex);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtHeaderLocationX);
            this.Controls.Add(this.txtHeaderLocationY);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCaption);
            this.Controls.Add(this.pnlBotton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHeaderText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.cboUnitPrice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgAddBaseColumn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "اطلاعات ستون";
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderText.Properties)).EndInit();
            this.pnlBotton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCaption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnitPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderLocationY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderLocationX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndex.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtHeaderText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel pnlBotton;
        private DevExpress.XtraEditors.SimpleButton btnAddColumn;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtCaption;
        private DevExpress.XtraEditors.ComboBoxEdit cboType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.ComboBoxEdit cboUnitPrice;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SpinEdit txtHeaderLocationY;
        private DevExpress.XtraEditors.SpinEdit txtHeaderLocationX;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.SpinEdit txtIndex;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.SimpleButton btnSetHeaderText;
    }
}