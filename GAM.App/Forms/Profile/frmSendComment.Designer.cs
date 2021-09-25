namespace GAM.Forms.Profile
{
    partial class frmSendComment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSendComment));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlText = new System.Windows.Forms.GroupBox();
            this.txtMessageText = new DevExpress.XtraEditors.MemoEdit();
            this.btnSubmit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessageText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::GAM.Properties.Resources.lightman;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 236);
            this.pictureBox1.TabIndex = 147;
            this.pictureBox1.TabStop = false;
            // 
            // pnlText
            // 
            this.pnlText.Controls.Add(this.txtMessageText);
            this.pnlText.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlText.Location = new System.Drawing.Point(106, 0);
            this.pnlText.Name = "pnlText";
            this.pnlText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlText.Size = new System.Drawing.Size(391, 202);
            this.pnlText.TabIndex = 148;
            this.pnlText.TabStop = false;
            this.pnlText.Text = "متن درخواست";
            // 
            // txtMessageText
            // 
            this.txtMessageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessageText.EditValue = "";
            this.txtMessageText.Location = new System.Drawing.Point(3, 17);
            this.txtMessageText.Name = "txtMessageText";
            this.txtMessageText.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessageText.Properties.Appearance.Options.UseFont = true;
            this.txtMessageText.Properties.MaxLength = 500;
            this.txtMessageText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMessageText.Size = new System.Drawing.Size(385, 182);
            this.txtMessageText.TabIndex = 141;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmit.Appearance.Options.UseFont = true;
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSubmit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSubmit.ImageOptions.Image")));
            this.btnSubmit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnSubmit.Location = new System.Drawing.Point(106, 202);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(391, 34);
            this.btnSubmit.TabIndex = 149;
            this.btnSubmit.Text = "ارسال به مدیر سیستم";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // frmSendComment
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 236);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.pnlText);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSendComment";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ارسال پیام";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMessageText.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox pnlText;
        private DevExpress.XtraEditors.MemoEdit txtMessageText;
        private DevExpress.XtraEditors.SimpleButton btnSubmit;

    }
}