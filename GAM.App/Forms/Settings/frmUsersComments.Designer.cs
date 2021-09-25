namespace GAM.Forms.Settings
{
    partial class frmUsersComments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsersComments));
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemContent = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemContent)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemContent});
            this.gridControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl.Size = new System.Drawing.Size(703, 374);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsView.RowAutoHeight = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "تاریخ ارسال";
            this.gridColumn1.FieldName = "RegisteredDateTime";
            this.gridColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridColumn1.Image")));
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 108;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "نام کاربر";
            this.gridColumn2.FieldName = "UserName";
            this.gridColumn2.Image = ((System.Drawing.Image)(resources.GetObject("gridColumn2.Image")));
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.FixedWidth = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 110;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "متن پیام";
            this.gridColumn3.ColumnEdit = this.repositoryItemContent;
            this.gridColumn3.FieldName = "Content";
            this.gridColumn3.Image = ((System.Drawing.Image)(resources.GetObject("gridColumn3.Image")));
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 448;
            // 
            // repositoryItemContent
            // 
            this.repositoryItemContent.Name = "repositoryItemContent";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.gridControl);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(703, 374);
            this.pnlMain.TabIndex = 1;
            // 
            // frmUsersComments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 374);
            this.Controls.Add(this.pnlMain);
            this.Name = "frmUsersComments";
            this.Text = "پیشنهادات ارسالی از سوی کاربران";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemContent)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        public DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemContent;
    }
}