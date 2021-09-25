namespace GAM.Forms.Profile.Etebarat.Arshive
{
    partial class dlgArchiveLogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgArchiveLogs));
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIsArchived = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryIsArchived = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colRegisteredDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIndicatorID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCoverNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBranchName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpertName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryIsArchived)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryIsArchived});
            this.gridControl.Size = new System.Drawing.Size(619, 331);
            this.gridControl.TabIndex = 7;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIsArchived,
            this.colRegisteredDateTime,
            this.colIndicatorID,
            this.colFileID,
            this.colCoverNo,
            this.colBranchName,
            this.colExpertName});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.RowHeight = 23;
            // 
            // colIsArchived
            // 
            this.colIsArchived.ColumnEdit = this.repositoryIsArchived;
            this.colIsArchived.FieldName = "IsArchived";
            this.colIsArchived.Name = "colIsArchived";
            this.colIsArchived.OptionsColumn.ShowCaption = false;
            this.colIsArchived.Visible = true;
            this.colIsArchived.VisibleIndex = 0;
            this.colIsArchived.Width = 20;
            // 
            // repositoryIsArchived
            // 
            this.repositoryIsArchived.AutoHeight = false;
            this.repositoryIsArchived.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repositoryIsArchived.Name = "repositoryIsArchived";
            this.repositoryIsArchived.PictureChecked = ((System.Drawing.Image)(resources.GetObject("repositoryIsArchived.PictureChecked")));
            this.repositoryIsArchived.PictureUnchecked = ((System.Drawing.Image)(resources.GetObject("repositoryIsArchived.PictureUnchecked")));
            // 
            // colRegisteredDateTime
            // 
            this.colRegisteredDateTime.AppearanceCell.Options.UseTextOptions = true;
            this.colRegisteredDateTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRegisteredDateTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colRegisteredDateTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRegisteredDateTime.Caption = "تاریخ ثبت";
            this.colRegisteredDateTime.FieldName = "RegisteredDateTime";
            this.colRegisteredDateTime.Image = ((System.Drawing.Image)(resources.GetObject("colRegisteredDateTime.Image")));
            this.colRegisteredDateTime.Name = "colRegisteredDateTime";
            this.colRegisteredDateTime.OptionsColumn.AllowEdit = false;
            this.colRegisteredDateTime.OptionsColumn.FixedWidth = true;
            this.colRegisteredDateTime.OptionsColumn.ReadOnly = true;
            this.colRegisteredDateTime.OptionsFilter.AllowFilter = false;
            this.colRegisteredDateTime.Visible = true;
            this.colRegisteredDateTime.VisibleIndex = 1;
            this.colRegisteredDateTime.Width = 106;
            // 
            // colIndicatorID
            // 
            this.colIndicatorID.AppearanceCell.Options.UseTextOptions = true;
            this.colIndicatorID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIndicatorID.AppearanceHeader.Options.UseTextOptions = true;
            this.colIndicatorID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIndicatorID.Caption = "کلاسه";
            this.colIndicatorID.FieldName = "IndicatorID";
            this.colIndicatorID.Name = "colIndicatorID";
            this.colIndicatorID.OptionsColumn.AllowEdit = false;
            this.colIndicatorID.OptionsColumn.FixedWidth = true;
            this.colIndicatorID.OptionsColumn.ReadOnly = true;
            this.colIndicatorID.Visible = true;
            this.colIndicatorID.VisibleIndex = 2;
            this.colIndicatorID.Width = 60;
            // 
            // colFileID
            // 
            this.colFileID.AppearanceCell.Options.UseTextOptions = true;
            this.colFileID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFileID.AppearanceHeader.Options.UseTextOptions = true;
            this.colFileID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFileID.Caption = "ش پرونده";
            this.colFileID.FieldName = "FileID";
            this.colFileID.Name = "colFileID";
            this.colFileID.OptionsColumn.AllowEdit = false;
            this.colFileID.OptionsColumn.FixedWidth = true;
            this.colFileID.OptionsColumn.ReadOnly = true;
            this.colFileID.Visible = true;
            this.colFileID.VisibleIndex = 3;
            this.colFileID.Width = 62;
            // 
            // colCoverNo
            // 
            this.colCoverNo.AppearanceCell.Options.UseTextOptions = true;
            this.colCoverNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCoverNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colCoverNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCoverNo.Caption = "جلد";
            this.colCoverNo.FieldName = "CoverNo";
            this.colCoverNo.Name = "colCoverNo";
            this.colCoverNo.OptionsColumn.AllowEdit = false;
            this.colCoverNo.OptionsColumn.FixedWidth = true;
            this.colCoverNo.OptionsColumn.ReadOnly = true;
            this.colCoverNo.Visible = true;
            this.colCoverNo.VisibleIndex = 4;
            this.colCoverNo.Width = 39;
            // 
            // colBranchName
            // 
            this.colBranchName.AppearanceCell.Options.UseTextOptions = true;
            this.colBranchName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBranchName.AppearanceHeader.Options.UseTextOptions = true;
            this.colBranchName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBranchName.Caption = "نام شعبه";
            this.colBranchName.FieldName = "BranchName";
            this.colBranchName.Name = "colBranchName";
            this.colBranchName.OptionsColumn.AllowEdit = false;
            this.colBranchName.OptionsColumn.FixedWidth = true;
            this.colBranchName.OptionsColumn.ReadOnly = true;
            this.colBranchName.Visible = true;
            this.colBranchName.VisibleIndex = 5;
            this.colBranchName.Width = 165;
            // 
            // colExpertName
            // 
            this.colExpertName.AppearanceHeader.Options.UseTextOptions = true;
            this.colExpertName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colExpertName.Caption = "تحویل گیرنده";
            this.colExpertName.FieldName = "ExpertName";
            this.colExpertName.Image = ((System.Drawing.Image)(resources.GetObject("colExpertName.Image")));
            this.colExpertName.Name = "colExpertName";
            this.colExpertName.OptionsColumn.AllowEdit = false;
            this.colExpertName.OptionsColumn.FixedWidth = true;
            this.colExpertName.OptionsColumn.ReadOnly = true;
            this.colExpertName.OptionsFilter.AllowFilter = false;
            this.colExpertName.Visible = true;
            this.colExpertName.VisibleIndex = 6;
            this.colExpertName.Width = 150;
            // 
            // dlgArchiveLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 331);
            this.Controls.Add(this.gridControl);
            this.Name = "dlgArchiveLogs";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryIsArchived)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colRegisteredDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colFileID;
        private DevExpress.XtraGrid.Columns.GridColumn colBranchName;
        private DevExpress.XtraGrid.Columns.GridColumn colExpertName;
        private DevExpress.XtraGrid.Columns.GridColumn colCoverNo;
        private DevExpress.XtraGrid.Columns.GridColumn colIsArchived;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryIsArchived;
        private DevExpress.XtraGrid.Columns.GridColumn colIndicatorID;
    }
}