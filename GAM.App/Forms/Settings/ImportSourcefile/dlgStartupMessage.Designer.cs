namespace GAM.Forms.Settings.ImportSourcefile
{
    partial class dlgStartupMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgStartupMessage));
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 38);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(324, 80);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnOk.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnOk.Location = new System.Drawing.Point(108, 127);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(135, 29);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "متوجه شدم";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 16);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(223, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "لطفاً قبل از ذخیره فایل به متن ذیل توجه فرمایید:";
            // 
            // dlgStartupMessage
            // 
            this.AcceptButton = this.btnOk;
            this.Appearance.BackColor = System.Drawing.Color.Pink;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 163);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtMessage);
            this.Name = "dlgStartupMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private System.Windows.Forms.Label label1;
    }
}