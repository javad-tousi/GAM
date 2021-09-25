namespace GAM.Forms.Profile.LegalFile.NewFile
{
    partial class dlgChangeLevels
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgChangeLevels));
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.rgContractLevels = new DevExpress.XtraEditors.RadioGroup();
            this.pnlBottom = new System.Windows.Forms.GroupBox();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.txtDateLevel = new DevExpress.XtraEditors.TextEdit();
            this.label22 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rgContractLevels.Properties)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateLevel.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(7, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(144, 30);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "تغییر مرحله قانونی";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rgContractLevels
            // 
            this.rgContractLevels.Dock = System.Windows.Forms.DockStyle.Top;
            this.rgContractLevels.Location = new System.Drawing.Point(0, 0);
            this.rgContractLevels.Name = "rgContractLevels";
            this.rgContractLevels.Properties.AllowFocused = false;
            this.rgContractLevels.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgContractLevels.Properties.Appearance.Options.UseFont = true;
            this.rgContractLevels.Properties.Columns = 1;
            this.rgContractLevels.Properties.LookAndFeel.SkinName = "Stardust";
            this.rgContractLevels.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.rgContractLevels.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rgContractLevels.Size = new System.Drawing.Size(426, 340);
            this.rgContractLevels.TabIndex = 15;
            this.rgContractLevels.SelectedIndexChanged += new System.EventHandler(this.rgContractLevels_SelectedIndexChanged);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.pictureEdit1);
            this.pnlBottom.Controls.Add(this.txtDateLevel);
            this.pnlBottom.Controls.Add(this.label22);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBottom.Location = new System.Drawing.Point(0, 340);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlBottom.Size = new System.Drawing.Size(426, 56);
            this.pnlBottom.TabIndex = 16;
            this.pnlBottom.TabStop = false;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(249, 21);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(20, 20);
            this.pictureEdit1.TabIndex = 236;
            // 
            // txtDateLevel
            // 
            this.txtDateLevel.EditValue = "";
            this.txtDateLevel.Location = new System.Drawing.Point(272, 19);
            this.txtDateLevel.Name = "txtDateLevel";
            this.txtDateLevel.Properties.AllowMouseWheel = false;
            this.txtDateLevel.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateLevel.Properties.Appearance.Options.UseFont = true;
            this.txtDateLevel.Properties.AutoHeight = false;
            this.txtDateLevel.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtDateLevel.Properties.Mask.EditMask = "\\d?\\d?\\d?\\d?/\\d?\\d?/\\d?\\d?";
            this.txtDateLevel.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.txtDateLevel.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDateLevel.Properties.MaxLength = 15;
            this.txtDateLevel.Properties.NullText = "0";
            this.txtDateLevel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDateLevel.Size = new System.Drawing.Size(84, 23);
            this.txtDateLevel.TabIndex = 234;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(358, 24);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(57, 13);
            this.label22.TabIndex = 235;
            this.label22.Text = "تاریخ انتقال";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(0, 396);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(426, 19);
            this.label1.TabIndex = 147;
            this.label1.Text = "توضیح: منظور تاریخ انتقال تاریخی می باشد که پرونده به مرحله مورد نظر منتقل گردیده" +
    " است.";
            // 
            // dlgChangeLevels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 415);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.rgContractLevels);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.LookAndFeel.SkinName = "Office 2010 Silver";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgChangeLevels";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تغییر مراحل وصول مطالبات";
            ((System.ComponentModel.ISupportInitialize)(this.rgContractLevels.Properties)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateLevel.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.RadioGroup rgContractLevels;
        private System.Windows.Forms.GroupBox pnlBottom;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        public DevExpress.XtraEditors.TextEdit txtDateLevel;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label1;

    }
}