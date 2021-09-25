namespace GAM.Forms.Profile.OfficialForms
{
    partial class dlgCirculars
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgCirculars));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new DevExpress.XtraEditors.ButtonEdit();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReferences = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateCreate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDownloadLink = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFavorites = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositorybtnFavoriteYellow = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositorybtnFavoriteBlue = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.colFavorite = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryDownloadLink = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorybtnFavoriteYellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorybtnFavoriteBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDownloadLink)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(2, 2);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(1);
            this.pnlSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlSearch.Size = new System.Drawing.Size(763, 29);
            this.pnlSearch.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.EditValue = "";
            this.txtSearch.Location = new System.Drawing.Point(1, 1);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Properties.Appearance.Options.UseFont = true;
            this.txtSearch.Properties.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.txtSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.txtSearch.Properties.NullValuePrompt = "شناسه فرم - عنوان - کلمات کلیدی";
            this.txtSearch.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtSearch.Size = new System.Drawing.Size(761, 27);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtSearch_ButtonClick);
            this.txtSearch.EditValueChanged += new System.EventHandler(this.txtSearch_EditValueChanged);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(2, 31);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositorybtnFavoriteYellow,
            this.repositorybtnFavoriteBlue,
            this.repositoryDownloadLink});
            this.gridControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl.Size = new System.Drawing.Size(763, 496);
            this.gridControl.TabIndex = 9;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFavorite,
            this.colId,
            this.colCategory,
            this.colSubject,
            this.colReferences,
            this.colDateCreate,
            this.colDownloadLink,
            this.colFavorites});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.RowHeight = 22;
            // 
            // colId
            // 
            this.colId.AppearanceCell.Options.UseTextOptions = true;
            this.colId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colId.AppearanceHeader.Options.UseTextOptions = true;
            this.colId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colId.Caption = " شماره";
            this.colId.FieldName = "DocumentID";
            this.colId.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.FixedWidth = true;
            this.colId.OptionsColumn.ReadOnly = true;
            this.colId.Visible = true;
            this.colId.VisibleIndex = 1;
            this.colId.Width = 51;
            // 
            // colCategory
            // 
            this.colCategory.AppearanceCell.Options.UseTextOptions = true;
            this.colCategory.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCategory.AppearanceHeader.Options.UseTextOptions = true;
            this.colCategory.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCategory.Caption = "طبقه بندی";
            this.colCategory.FieldName = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.OptionsColumn.AllowEdit = false;
            this.colCategory.OptionsColumn.FixedWidth = true;
            this.colCategory.OptionsColumn.ReadOnly = true;
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 2;
            this.colCategory.Width = 126;
            // 
            // colSubject
            // 
            this.colSubject.AppearanceHeader.Options.UseTextOptions = true;
            this.colSubject.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSubject.Caption = "موضوع";
            this.colSubject.FieldName = "Subject";
            this.colSubject.Name = "colSubject";
            this.colSubject.OptionsColumn.AllowEdit = false;
            this.colSubject.OptionsColumn.ReadOnly = true;
            this.colSubject.Visible = true;
            this.colSubject.VisibleIndex = 3;
            this.colSubject.Width = 315;
            // 
            // colReferences
            // 
            this.colReferences.AppearanceCell.Options.UseTextOptions = true;
            this.colReferences.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReferences.AppearanceHeader.Options.UseTextOptions = true;
            this.colReferences.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReferences.Caption = "مرجع صدور";
            this.colReferences.FieldName = "References";
            this.colReferences.Name = "colReferences";
            this.colReferences.OptionsColumn.AllowEdit = false;
            this.colReferences.OptionsColumn.FixedWidth = true;
            this.colReferences.OptionsColumn.ReadOnly = true;
            this.colReferences.Visible = true;
            this.colReferences.VisibleIndex = 5;
            this.colReferences.Width = 147;
            // 
            // colDateCreate
            // 
            this.colDateCreate.AppearanceCell.Options.UseTextOptions = true;
            this.colDateCreate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDateCreate.AppearanceHeader.Options.UseTextOptions = true;
            this.colDateCreate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDateCreate.Caption = "تاریخ صدور";
            this.colDateCreate.FieldName = "DateCreate";
            this.colDateCreate.Name = "colDateCreate";
            this.colDateCreate.OptionsColumn.AllowEdit = false;
            this.colDateCreate.OptionsColumn.FixedWidth = true;
            this.colDateCreate.OptionsColumn.ReadOnly = true;
            this.colDateCreate.Visible = true;
            this.colDateCreate.VisibleIndex = 4;
            this.colDateCreate.Width = 70;
            // 
            // colDownloadLink
            // 
            this.colDownloadLink.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.colDownloadLink.AppearanceCell.Options.UseForeColor = true;
            this.colDownloadLink.AppearanceCell.Options.UseTextOptions = true;
            this.colDownloadLink.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDownloadLink.AppearanceHeader.Options.UseTextOptions = true;
            this.colDownloadLink.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDownloadLink.Caption = "فایل";
            this.colDownloadLink.ColumnEdit = this.repositoryDownloadLink;
            this.colDownloadLink.FieldName = "DownloadLink";
            this.colDownloadLink.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.colDownloadLink.Name = "colDownloadLink";
            this.colDownloadLink.OptionsColumn.FixedWidth = true;
            this.colDownloadLink.Visible = true;
            this.colDownloadLink.VisibleIndex = 6;
            this.colDownloadLink.Width = 30;
            // 
            // colFavorites
            // 
            this.colFavorites.FieldName = "Favorites";
            this.colFavorites.Name = "colFavorites";
            this.colFavorites.OptionsColumn.AllowEdit = false;
            this.colFavorites.OptionsColumn.FixedWidth = true;
            this.colFavorites.OptionsColumn.ReadOnly = true;
            // 
            // repositorybtnFavoriteYellow
            // 
            this.repositorybtnFavoriteYellow.AutoHeight = false;
            this.repositorybtnFavoriteYellow.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.repositorybtnFavoriteYellow.Name = "repositorybtnFavoriteYellow";
            this.repositorybtnFavoriteYellow.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositorybtnFavoriteBlue
            // 
            this.repositorybtnFavoriteBlue.AutoHeight = false;
            this.repositorybtnFavoriteBlue.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.repositorybtnFavoriteBlue.Name = "repositorybtnFavoriteBlue";
            this.repositorybtnFavoriteBlue.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.gridControl);
            this.pnlMain.Controls.Add(this.pnlSearch);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(767, 529);
            this.pnlMain.TabIndex = 10;
            // 
            // colFavorite
            // 
            this.colFavorite.Name = "colFavorite";
            this.colFavorite.Visible = true;
            this.colFavorite.VisibleIndex = 0;
            this.colFavorite.Width = 20;
            // 
            // repositoryDownloadLink
            // 
            this.repositoryDownloadLink.AutoHeight = false;
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.repositoryDownloadLink.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "نمایش", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryDownloadLink.Name = "repositoryDownloadLink";
            this.repositoryDownloadLink.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryDownloadLink.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryDownloadLink_ButtonClick);
            // 
            // dlgCirculars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 529);
            this.Controls.Add(this.pnlMain);
            this.Name = "dlgCirculars";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فهرست اطلاعیه ها و بخشنامه ها";
            this.pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorybtnFavoriteYellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorybtnFavoriteBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDownloadLink)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearch;
        private DevExpress.XtraEditors.ButtonEdit txtSearch;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colReferences;
        private DevExpress.XtraGrid.Columns.GridColumn colDateCreate;
        private DevExpress.XtraGrid.Columns.GridColumn colDownloadLink;
        private DevExpress.XtraGrid.Columns.GridColumn colFavorites;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositorybtnFavoriteYellow;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositorybtnFavoriteBlue;
        public DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraGrid.Columns.GridColumn colFavorite;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryDownloadLink;
    }
}