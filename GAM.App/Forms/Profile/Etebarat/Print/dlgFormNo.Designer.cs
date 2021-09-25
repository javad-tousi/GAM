namespace GAM.Forms.Profile.Etebarat.Print
{
    partial class dlgFormNo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgFormNo));
            this.label2 = new System.Windows.Forms.Label();
            this.txtFormNo = new System.Windows.Forms.TextBox();
            this.pnlBotton = new System.Windows.Forms.FlowLayoutPanel();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.pnlBotton.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(201, 34);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(47, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "ش فرم:";
            // 
            // txtFormNo
            // 
            this.txtFormNo.BackColor = System.Drawing.SystemColors.Info;
            this.txtFormNo.Font = new System.Drawing.Font("B Titr", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFormNo.Location = new System.Drawing.Point(104, 23);
            this.txtFormNo.MaxLength = 3;
            this.txtFormNo.Name = "txtFormNo";
            this.txtFormNo.Size = new System.Drawing.Size(95, 36);
            this.txtFormNo.TabIndex = 0;
            this.txtFormNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlBotton
            // 
            this.pnlBotton.Controls.Add(this.btnCancel);
            this.pnlBotton.Controls.Add(this.btnView);
            this.pnlBotton.Controls.Add(this.btnPrint);
            this.pnlBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotton.Location = new System.Drawing.Point(0, 81);
            this.pnlBotton.Name = "pnlBotton";
            this.pnlBotton.Size = new System.Drawing.Size(305, 35);
            this.pnlBotton.TabIndex = 14;
            // 
            // btnView
            // 
            this.btnView.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnView.ImageOptions.Image")));
            this.btnView.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnView.Location = new System.Drawing.Point(104, 3);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(95, 29);
            this.btnView.TabIndex = 8;
            this.btnView.Text = "نمایش";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.ImageOptions.Image")));
            this.btnPrint.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnPrint.Location = new System.Drawing.Point(205, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(95, 29);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "چاپ";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 29);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dlgFormNo
            // 
            this.AcceptButton = this.btnPrint;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 116);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBotton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFormNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "dlgFormNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.pnlBotton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFormNo;
        private System.Windows.Forms.FlowLayoutPanel pnlBotton;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}