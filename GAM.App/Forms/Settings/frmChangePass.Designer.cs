namespace GAM.Forms.Settings
{
    partial class dlgChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgChangePassword));
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblNewPassword1 = new System.Windows.Forms.Label();
            this.lblNewPassword2 = new System.Windows.Forms.Label();
            this.pnlGroup1 = new System.Windows.Forms.GroupBox();
            this.txtCurrentUserName = new System.Windows.Forms.CustomControls.FilterdTextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtCurrentPassword = new System.Windows.Forms.CustomControls.FilterdTextBox();
            this.pnlGroup2 = new System.Windows.Forms.GroupBox();
            this.txtNewPassword1 = new System.Windows.Forms.CustomControls.FilterdTextBox();
            this.txtNewPassword2 = new System.Windows.Forms.CustomControls.FilterdTextBox();
            this.pnlBotton = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUpdatePassword = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.pnlGroup1.SuspendLayout();
            this.pnlGroup2.SuspendLayout();
            this.pnlBotton.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPassword.Location = new System.Drawing.Point(228, 49);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(74, 13);
            this.lblPassword.TabIndex = 25;
            this.lblPassword.Text = "رمز عبور فعلی";
            // 
            // lblNewPassword1
            // 
            this.lblNewPassword1.AutoSize = true;
            this.lblNewPassword1.BackColor = System.Drawing.Color.Transparent;
            this.lblNewPassword1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblNewPassword1.Location = new System.Drawing.Point(227, 24);
            this.lblNewPassword1.Name = "lblNewPassword1";
            this.lblNewPassword1.Size = new System.Drawing.Size(45, 13);
            this.lblNewPassword1.TabIndex = 27;
            this.lblNewPassword1.Text = "رمز عبور";
            // 
            // lblNewPassword2
            // 
            this.lblNewPassword2.AutoSize = true;
            this.lblNewPassword2.BackColor = System.Drawing.Color.Transparent;
            this.lblNewPassword2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblNewPassword2.Location = new System.Drawing.Point(227, 49);
            this.lblNewPassword2.Name = "lblNewPassword2";
            this.lblNewPassword2.Size = new System.Drawing.Size(69, 13);
            this.lblNewPassword2.TabIndex = 29;
            this.lblNewPassword2.Text = "تکرار رمز عبور";
            // 
            // pnlGroup1
            // 
            this.pnlGroup1.Controls.Add(this.txtCurrentUserName);
            this.pnlGroup1.Controls.Add(this.lblUserName);
            this.pnlGroup1.Controls.Add(this.txtCurrentPassword);
            this.pnlGroup1.Controls.Add(this.lblPassword);
            this.pnlGroup1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGroup1.Location = new System.Drawing.Point(7, 7);
            this.pnlGroup1.Name = "pnlGroup1";
            this.pnlGroup1.Padding = new System.Windows.Forms.Padding(5);
            this.pnlGroup1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlGroup1.Size = new System.Drawing.Size(325, 75);
            this.pnlGroup1.TabIndex = 31;
            this.pnlGroup1.TabStop = false;
            this.pnlGroup1.Text = "گذر واژه قدیم";
            // 
            // txtCurrentUserName
            // 
            this.txtCurrentUserName.AcceptedChars = null;
            this.txtCurrentUserName.BackColorOnErr = System.Drawing.Color.Pink;
            this.txtCurrentUserName.BackColorUsed = System.Drawing.Color.White;
            this.txtCurrentUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrentUserName.EnterToNextControl = true;
            this.txtCurrentUserName.FilterChars = System.Windows.Forms.CustomControls.FilterdTextBox.FilteredEnum.EnglishAndAllChars;
            this.txtCurrentUserName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentUserName.ForeColor = System.Drawing.Color.DimGray;
            this.txtCurrentUserName.Location = new System.Drawing.Point(25, 20);
            this.txtCurrentUserName.MaxLength = 10;
            this.txtCurrentUserName.Name = "txtCurrentUserName";
            this.txtCurrentUserName.PromptFont = null;
            this.txtCurrentUserName.PromptForeColor = System.Drawing.SystemColors.GrayText;
            this.txtCurrentUserName.PromptText = "";
            this.txtCurrentUserName.ReadOnly = true;
            this.txtCurrentUserName.SelectAllFocused = true;
            this.txtCurrentUserName.Size = new System.Drawing.Size(199, 22);
            this.txtCurrentUserName.TabIndex = 1;
            this.txtCurrentUserName.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblUserName.Location = new System.Drawing.Point(228, 24);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(69, 13);
            this.lblUserName.TabIndex = 27;
            this.lblUserName.Text = "کاربر سیستم";
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.AcceptedChars = null;
            this.txtCurrentPassword.BackColorOnErr = System.Drawing.Color.Pink;
            this.txtCurrentPassword.BackColorUsed = System.Drawing.Color.White;
            this.txtCurrentPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrentPassword.EnterToNextControl = true;
            this.txtCurrentPassword.FilterChars = System.Windows.Forms.CustomControls.FilterdTextBox.FilteredEnum.EnglishAndAllChars;
            this.txtCurrentPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentPassword.ForeColor = System.Drawing.Color.DimGray;
            this.txtCurrentPassword.Location = new System.Drawing.Point(25, 45);
            this.txtCurrentPassword.MaxLength = 10;
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.PromptFont = null;
            this.txtCurrentPassword.PromptForeColor = System.Drawing.SystemColors.GrayText;
            this.txtCurrentPassword.PromptText = "";
            this.txtCurrentPassword.SelectAllFocused = true;
            this.txtCurrentPassword.Size = new System.Drawing.Size(199, 21);
            this.txtCurrentPassword.TabIndex = 2;
            this.txtCurrentPassword.TextLanguage = System.Windows.Forms.CustomControls.FilterdTextBox.LanguageEnum.English;
            this.txtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // pnlGroup2
            // 
            this.pnlGroup2.Controls.Add(this.txtNewPassword1);
            this.pnlGroup2.Controls.Add(this.lblNewPassword2);
            this.pnlGroup2.Controls.Add(this.lblNewPassword1);
            this.pnlGroup2.Controls.Add(this.txtNewPassword2);
            this.pnlGroup2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGroup2.Location = new System.Drawing.Point(7, 82);
            this.pnlGroup2.Name = "pnlGroup2";
            this.pnlGroup2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlGroup2.Size = new System.Drawing.Size(325, 79);
            this.pnlGroup2.TabIndex = 32;
            this.pnlGroup2.TabStop = false;
            this.pnlGroup2.Text = "گذر واژه جدید";
            // 
            // txtNewPassword1
            // 
            this.txtNewPassword1.AcceptedChars = null;
            this.txtNewPassword1.BackColorOnErr = System.Drawing.Color.Pink;
            this.txtNewPassword1.BackColorUsed = System.Drawing.Color.White;
            this.txtNewPassword1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPassword1.EnterToNextControl = true;
            this.txtNewPassword1.FilterChars = System.Windows.Forms.CustomControls.FilterdTextBox.FilteredEnum.EnglishAndAllChars;
            this.txtNewPassword1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword1.ForeColor = System.Drawing.Color.DimGray;
            this.txtNewPassword1.Location = new System.Drawing.Point(25, 20);
            this.txtNewPassword1.MaxLength = 10;
            this.txtNewPassword1.Name = "txtNewPassword1";
            this.txtNewPassword1.PromptFont = null;
            this.txtNewPassword1.PromptForeColor = System.Drawing.SystemColors.GrayText;
            this.txtNewPassword1.PromptText = "";
            this.txtNewPassword1.SelectAllFocused = true;
            this.txtNewPassword1.Size = new System.Drawing.Size(199, 21);
            this.txtNewPassword1.TabIndex = 3;
            this.txtNewPassword1.TextLanguage = System.Windows.Forms.CustomControls.FilterdTextBox.LanguageEnum.English;
            this.txtNewPassword1.UseSystemPasswordChar = true;
            // 
            // txtNewPassword2
            // 
            this.txtNewPassword2.AcceptedChars = null;
            this.txtNewPassword2.BackColorOnErr = System.Drawing.Color.Pink;
            this.txtNewPassword2.BackColorUsed = System.Drawing.Color.White;
            this.txtNewPassword2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPassword2.EnterToNextControl = true;
            this.txtNewPassword2.FilterChars = System.Windows.Forms.CustomControls.FilterdTextBox.FilteredEnum.EnglishAndAllChars;
            this.txtNewPassword2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword2.ForeColor = System.Drawing.Color.DimGray;
            this.txtNewPassword2.Location = new System.Drawing.Point(25, 45);
            this.txtNewPassword2.MaxLength = 10;
            this.txtNewPassword2.Name = "txtNewPassword2";
            this.txtNewPassword2.PromptFont = null;
            this.txtNewPassword2.PromptForeColor = System.Drawing.SystemColors.GrayText;
            this.txtNewPassword2.PromptText = "";
            this.txtNewPassword2.SelectAllFocused = true;
            this.txtNewPassword2.Size = new System.Drawing.Size(199, 21);
            this.txtNewPassword2.TabIndex = 4;
            this.txtNewPassword2.TextLanguage = System.Windows.Forms.CustomControls.FilterdTextBox.LanguageEnum.English;
            this.txtNewPassword2.UseSystemPasswordChar = true;
            // 
            // pnlBotton
            // 
            this.pnlBotton.Controls.Add(this.btnUpdatePassword);
            this.pnlBotton.Controls.Add(this.btnCancel);
            this.pnlBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotton.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlBotton.Location = new System.Drawing.Point(0, 166);
            this.pnlBotton.Name = "pnlBotton";
            this.pnlBotton.Size = new System.Drawing.Size(339, 35);
            this.pnlBotton.TabIndex = 0;
            // 
            // btnUpdatePassword
            // 
            this.btnUpdatePassword.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdatePassword.ImageOptions.Image")));
            this.btnUpdatePassword.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnUpdatePassword.Location = new System.Drawing.Point(101, 3);
            this.btnUpdatePassword.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.btnUpdatePassword.Name = "btnUpdatePassword";
            this.btnUpdatePassword.Size = new System.Drawing.Size(233, 29);
            this.btnUpdatePassword.TabIndex = 5;
            this.btnUpdatePassword.Text = "تایید اطلاعات";
            this.btnUpdatePassword.Click += new System.EventHandler(this.btnUpdatePassword_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(5, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 29);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlGroup2);
            this.pnlMain.Controls.Add(this.pnlGroup1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(7);
            this.pnlMain.Size = new System.Drawing.Size(339, 166);
            this.pnlMain.TabIndex = 30;
            // 
            // dlgChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 201);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBotton);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.LookAndFeel.SkinName = "Office 2010 Silver";
            this.Name = "dlgChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.pnlGroup1.ResumeLayout(false);
            this.pnlGroup1.PerformLayout();
            this.pnlGroup2.ResumeLayout(false);
            this.pnlGroup2.PerformLayout();
            this.pnlBotton.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblNewPassword1;
        private System.Windows.Forms.Label lblNewPassword2;
        private System.Windows.Forms.GroupBox pnlGroup1;
        public System.Windows.Forms.CustomControls.FilterdTextBox txtCurrentUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.GroupBox pnlGroup2;
        private System.Windows.Forms.FlowLayoutPanel pnlBotton;
        private DevExpress.XtraEditors.SimpleButton btnUpdatePassword;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private System.Windows.Forms.CustomControls.FilterdTextBox txtCurrentPassword;
        private System.Windows.Forms.CustomControls.FilterdTextBox txtNewPassword1;
        private System.Windows.Forms.CustomControls.FilterdTextBox txtNewPassword2;
    }
}