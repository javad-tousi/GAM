namespace GAM.Forms.Profile.Etebarat.Arshive
{
    partial class dlgWriteFileNo
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(38, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "!پرونده شما با موفقیت در سیستم ثبت شد";
            // 
            // txtFileNo
            // 
            this.txtFileNo.BackColor = System.Drawing.SystemColors.Info;
            this.txtFileNo.Enabled = false;
            this.txtFileNo.Font = new System.Drawing.Font("B Titr", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFileNo.Location = new System.Drawing.Point(96, 71);
            this.txtFileNo.Name = "txtFileNo";
            this.txtFileNo.ReadOnly = true;
            this.txtFileNo.Size = new System.Drawing.Size(100, 36);
            this.txtFileNo.TabIndex = 1;
            this.txtFileNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(198, 82);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(48, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "ش ثبت:";
            // 
            // btnOK
            // 
            this.btnOK.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnOK.Location = new System.Drawing.Point(106, 125);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 29);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "بستن";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dlgWriteFileNo
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(289, 161);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFileNo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "dlgWriteFileNo";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileNo;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}