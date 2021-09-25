namespace GAM.Dialogs
{
    partial class msgLoopLoading
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
            this.progressPanel = new DevExpress.XtraWaitForm.ProgressPanel();
            this.SuspendLayout();
            // 
            // progressPanel
            // 
            this.progressPanel.Appearance.BackColor = System.Drawing.Color.White;
            this.progressPanel.Appearance.Options.UseBackColor = true;
            this.progressPanel.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressPanel.AppearanceCaption.Options.UseFont = true;
            this.progressPanel.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.progressPanel.AppearanceDescription.Options.UseFont = true;
            this.progressPanel.BarAnimationElementThickness = 2;
            this.progressPanel.Caption = "";
            this.progressPanel.Description = "";
            this.progressPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressPanel.ImageHorzOffset = 10;
            this.progressPanel.Location = new System.Drawing.Point(0, 0);
            this.progressPanel.LookAndFeel.SkinName = "Office 2010 Black";
            this.progressPanel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.progressPanel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.progressPanel.ShowDescription = false;
            this.progressPanel.Size = new System.Drawing.Size(42, 44);
            this.progressPanel.TabIndex = 0;
            this.progressPanel.Text = "progressPanel";
            // 
            // dlgLoopLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(42, 44);
            this.Controls.Add(this.progressPanel);
            this.Name = "dlgLoopLoading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWaitForm.ProgressPanel progressPanel;
    }
}
