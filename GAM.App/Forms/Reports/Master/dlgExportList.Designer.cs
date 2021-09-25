namespace GAM.Forms.Reports.Master
{
    partial class dlgExportList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgExportList));
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.pnlBotton = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioGroup2 = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.pnlBotton.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroup1.Location = new System.Drawing.Point(3, 17);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.SeaGreen;
            this.radioGroup1.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.Appearance.Options.UseForeColor = true;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "استان > شعب"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "استان > حوزه ها"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "استان > حوزه ها > شعب"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "استان > حوزه ها > شعب تحت نظارت")});
            this.radioGroup1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioGroup1.Size = new System.Drawing.Size(305, 140);
            this.radioGroup1.TabIndex = 0;
            // 
            // pnlBotton
            // 
            this.pnlBotton.Controls.Add(this.btnOk);
            this.pnlBotton.Controls.Add(this.btnCancel);
            this.pnlBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotton.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlBotton.Location = new System.Drawing.Point(0, 276);
            this.pnlBotton.Name = "pnlBotton";
            this.pnlBotton.Size = new System.Drawing.Size(311, 35);
            this.pnlBotton.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnOk.Location = new System.Drawing.Point(103, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(205, 29);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "دریافت فایل اکسل";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 240);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(311, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "راهنما:\r\nاز طریق فعال کردن دکمه انتخاب (زیر لیست گزارشات) می توانید دو یا چند گزا" +
    "رش را انتخاب و در قالب یک فایل اکسل ذخیره نمایید.\r\n\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioGroup1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(311, 160);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "سطح ذخیره اطلاعات";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioGroup2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(311, 80);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "نوع ذخیره سازی اطلاعات";
            // 
            // radioGroup2
            // 
            this.radioGroup2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroup2.Enabled = false;
            this.radioGroup2.Location = new System.Drawing.Point(3, 17);
            this.radioGroup2.Name = "radioGroup2";
            this.radioGroup2.Properties.Appearance.BackColor = System.Drawing.Color.SeaGreen;
            this.radioGroup2.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.radioGroup2.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup2.Properties.Appearance.Options.UseForeColor = true;
            this.radioGroup2.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "همه گزارشات تجمیع و در یک Sheet اکسل ذخیره شود"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "هر گـزارش بصورت جدا در یک Sheet اکسل ذخیره شود")});
            this.radioGroup2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioGroup2.Size = new System.Drawing.Size(305, 60);
            this.radioGroup2.TabIndex = 0;
            // 
            // dlgExportList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 311);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlBotton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "dlgExportList";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ذخیره اطلاعات";
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.pnlBotton.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private System.Windows.Forms.FlowLayoutPanel pnlBotton;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.RadioGroup radioGroup2;
    }
}