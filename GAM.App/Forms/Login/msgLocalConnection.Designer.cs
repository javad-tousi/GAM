namespace GAM.Forms.Login
{
    partial class msgLocalConnection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(msgLocalConnection));
            this.lblMessage = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pnlBotton = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNo = new DevExpress.XtraEditors.SimpleButton();
            this.btnYes = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new DevExpress.XtraEditors.TextEdit();
            this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.pnlBotton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblMessage.Location = new System.Drawing.Point(44, 20);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMessage.Size = new System.Drawing.Size(305, 74);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "در صورت تمایل به اجرای برنامه بصورت آفـلاین می بایست ابتدا فایلهای راه اندازی برن" +
    "امه را در یک پـوشه به نام Data کپی سپس آدرس پوشه مذکور را در کادر پایین وارد نما" +
    "یید";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("labelControl1.Appearance.Image")));
            this.labelControl1.Appearance.Options.UseImage = true;
            this.labelControl1.Location = new System.Drawing.Point(11, 45);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(32, 32);
            this.labelControl1.TabIndex = 6;
            // 
            // pnlBotton
            // 
            this.pnlBotton.Controls.Add(this.btnNo);
            this.pnlBotton.Controls.Add(this.btnYes);
            this.pnlBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotton.Location = new System.Drawing.Point(0, 113);
            this.pnlBotton.Name = "pnlBotton";
            this.pnlBotton.Size = new System.Drawing.Size(360, 34);
            this.pnlBotton.TabIndex = 7;
            // 
            // btnNo
            // 
            this.btnNo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNo.ImageOptions.Image")));
            this.btnNo.Location = new System.Drawing.Point(3, 3);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(118, 29);
            this.btnNo.TabIndex = 0;
            this.btnNo.Text = "انصراف";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnYes.ImageOptions.Image")));
            this.btnYes.Location = new System.Drawing.Point(127, 3);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(230, 29);
            this.btnYes.TabIndex = 0;
            this.btnYes.TabStop = false;
            this.btnYes.Text = "ثبت تنظیمات";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(135, 6);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(98, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "تنظیمات آفلاین";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(62, 86);
            this.txtPath.Name = "txtPath";
            this.txtPath.Properties.AutoHeight = false;
            this.txtPath.Properties.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(256, 23);
            this.txtPath.TabIndex = 9;
            // 
            // btnBrowse
            // 
            this.btnBrowse.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnBrowse.Location = new System.Drawing.Point(320, 85);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(26, 24);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // msgLocalConnection
            // 
            this.AcceptButton = this.btnNo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 147);
            this.ControlBox = false;
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlBotton);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "msgLocalConnection";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlBotton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.FlowLayoutPanel pnlBotton;
        private DevExpress.XtraEditors.SimpleButton btnYes;
        private DevExpress.XtraEditors.SimpleButton btnNo;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtPath;
        private DevExpress.XtraEditors.SimpleButton btnBrowse;
    }
}