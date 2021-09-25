namespace GAM.Forms.Reports.Master
{
    partial class dlgBranchInfo
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
            this.vGridControl = new DevExpress.XtraVerticalGrid.VGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl)).BeginInit();
            this.SuspendLayout();
            // 
            // vGridControl
            // 
            this.vGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.vGridControl.Location = new System.Drawing.Point(0, 0);
            this.vGridControl.Name = "vGridControl";
            this.vGridControl.OptionsBehavior.Editable = false;
            this.vGridControl.OptionsSelectionAndFocus.EnableAppearanceFocusedRow = false;
            this.vGridControl.OptionsSelectionAndFocus.EnableAppearanceSelectedRowHeader = false;
            this.vGridControl.OptionsView.ShowFocusedFrame = false;
            this.vGridControl.OptionsView.ShowRootLevelIndent = false;
            this.vGridControl.RecordWidth = 125;
            this.vGridControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vGridControl.RowHeaderWidth = 75;
            this.vGridControl.Size = new System.Drawing.Size(260, 334);
            this.vGridControl.TabIndex = 1;
            // 
            // dlgBranchInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 334);
            this.Controls.Add(this.vGridControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgBranchInfo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اطلاعات واحد";
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.VGridControl vGridControl;
    }
}