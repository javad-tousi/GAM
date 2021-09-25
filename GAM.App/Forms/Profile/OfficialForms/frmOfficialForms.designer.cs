namespace GAM.Forms.Profile.OfficialForms
{
    partial class frmOfficeForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOfficeForms));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddDocument = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditDocument = new DevExpress.XtraEditors.SimpleButton();
            this.btnCopyContent = new DevExpress.XtraEditors.SimpleButton();
            this.btnOpenDocument = new DevExpress.XtraEditors.SimpleButton();
            this.btnFavoritesList = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new DevExpress.XtraEditors.ButtonEdit();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceiverName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSignatories = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbtnFavorite = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFavorites = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositorybtnFavoriteYellow = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositorybtnFavoriteBlue = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.pnlBottom.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorybtnFavoriteYellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorybtnFavoriteBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnAddDocument);
            this.pnlBottom.Controls.Add(this.btnEditDocument);
            this.pnlBottom.Controls.Add(this.btnCopyContent);
            this.pnlBottom.Controls.Add(this.btnOpenDocument);
            this.pnlBottom.Controls.Add(this.btnFavoritesList);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(2, 494);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlBottom.Size = new System.Drawing.Size(763, 33);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnAddDocument
            // 
            this.btnAddDocument.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddDocument.ImageOptions.Image")));
            this.btnAddDocument.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnAddDocument.Location = new System.Drawing.Point(645, 3);
            this.btnAddDocument.Name = "btnAddDocument";
            this.btnAddDocument.Size = new System.Drawing.Size(115, 27);
            this.btnAddDocument.TabIndex = 2;
            this.btnAddDocument.Text = "افزودن فرم";
            this.btnAddDocument.Click += new System.EventHandler(this.btnAddDocument_Click);
            // 
            // btnEditDocument
            // 
            this.btnEditDocument.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEditDocument.ImageOptions.Image")));
            this.btnEditDocument.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnEditDocument.Location = new System.Drawing.Point(524, 3);
            this.btnEditDocument.Name = "btnEditDocument";
            this.btnEditDocument.Size = new System.Drawing.Size(115, 27);
            this.btnEditDocument.TabIndex = 3;
            this.btnEditDocument.Text = "ویرایش فرم";
            this.btnEditDocument.Click += new System.EventHandler(this.btnEditDocument_Click);
            // 
            // btnCopyContent
            // 
            this.btnCopyContent.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyContent.ImageOptions.Image")));
            this.btnCopyContent.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnCopyContent.Location = new System.Drawing.Point(403, 3);
            this.btnCopyContent.Name = "btnCopyContent";
            this.btnCopyContent.Size = new System.Drawing.Size(115, 27);
            this.btnCopyContent.TabIndex = 4;
            this.btnCopyContent.Text = "کپی محتوا";
            this.btnCopyContent.Click += new System.EventHandler(this.btnCopyContent_Click);
            // 
            // btnOpenDocument
            // 
            this.btnOpenDocument.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenDocument.ImageOptions.Image")));
            this.btnOpenDocument.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnOpenDocument.Location = new System.Drawing.Point(282, 3);
            this.btnOpenDocument.Name = "btnOpenDocument";
            this.btnOpenDocument.Size = new System.Drawing.Size(115, 27);
            this.btnOpenDocument.TabIndex = 5;
            this.btnOpenDocument.Text = "نمایش در Word";
            this.btnOpenDocument.Click += new System.EventHandler(this.btnOpenDocument_Click);
            // 
            // btnFavoritesList
            // 
            this.btnFavoritesList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFavoritesList.ImageOptions.Image")));
            this.btnFavoritesList.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnFavoritesList.Location = new System.Drawing.Point(161, 3);
            this.btnFavoritesList.Name = "btnFavoritesList";
            this.btnFavoritesList.Size = new System.Drawing.Size(115, 27);
            this.btnFavoritesList.TabIndex = 7;
            this.btnFavoritesList.Text = "علاقمندی ها";
            this.btnFavoritesList.Click += new System.EventHandler(this.btnFavoritesList_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnRefresh.Location = new System.Drawing.Point(40, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(115, 27);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "بروزرسانی";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
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
            this.repositorybtnFavoriteBlue});
            this.gridControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl.Size = new System.Drawing.Size(763, 463);
            this.gridControl.TabIndex = 9;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colCategory,
            this.colSubject,
            this.colReceiverName,
            this.colSignatories,
            this.colbtnFavorite,
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
            this.gridView.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView_CustomRowCellEdit);
            // 
            // colId
            // 
            this.colId.AppearanceCell.Options.UseTextOptions = true;
            this.colId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colId.AppearanceHeader.Options.UseTextOptions = true;
            this.colId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colId.Caption = " ";
            this.colId.FieldName = "ID";
            this.colId.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.FixedWidth = true;
            this.colId.OptionsColumn.ReadOnly = true;
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 27;
            // 
            // colCategory
            // 
            this.colCategory.AppearanceCell.Options.UseTextOptions = true;
            this.colCategory.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCategory.AppearanceHeader.Options.UseTextOptions = true;
            this.colCategory.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCategory.Caption = "طبقه بندی";
            this.colCategory.FieldName = "Category";
            this.colCategory.Image = ((System.Drawing.Image)(resources.GetObject("colCategory.Image")));
            this.colCategory.Name = "colCategory";
            this.colCategory.OptionsColumn.AllowEdit = false;
            this.colCategory.OptionsColumn.FixedWidth = true;
            this.colCategory.OptionsColumn.ReadOnly = true;
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 1;
            this.colCategory.Width = 110;
            // 
            // colSubject
            // 
            this.colSubject.AppearanceHeader.Options.UseTextOptions = true;
            this.colSubject.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSubject.Caption = "عنوان";
            this.colSubject.FieldName = "Subject";
            this.colSubject.Image = ((System.Drawing.Image)(resources.GetObject("colSubject.Image")));
            this.colSubject.Name = "colSubject";
            this.colSubject.OptionsColumn.AllowEdit = false;
            this.colSubject.OptionsColumn.ReadOnly = true;
            this.colSubject.Visible = true;
            this.colSubject.VisibleIndex = 2;
            this.colSubject.Width = 300;
            // 
            // colReceiverName
            // 
            this.colReceiverName.AppearanceCell.Options.UseTextOptions = true;
            this.colReceiverName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReceiverName.AppearanceHeader.Options.UseTextOptions = true;
            this.colReceiverName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReceiverName.Caption = "گیرنده";
            this.colReceiverName.FieldName = "ReceiverName";
            this.colReceiverName.Image = ((System.Drawing.Image)(resources.GetObject("colReceiverName.Image")));
            this.colReceiverName.Name = "colReceiverName";
            this.colReceiverName.OptionsColumn.AllowEdit = false;
            this.colReceiverName.OptionsColumn.FixedWidth = true;
            this.colReceiverName.OptionsColumn.ReadOnly = true;
            this.colReceiverName.Visible = true;
            this.colReceiverName.VisibleIndex = 3;
            this.colReceiverName.Width = 140;
            // 
            // colSignatories
            // 
            this.colSignatories.AppearanceCell.Options.UseTextOptions = true;
            this.colSignatories.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSignatories.AppearanceHeader.Options.UseTextOptions = true;
            this.colSignatories.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSignatories.Caption = "امضاء کنندگان";
            this.colSignatories.FieldName = "Signatories";
            this.colSignatories.Image = ((System.Drawing.Image)(resources.GetObject("colSignatories.Image")));
            this.colSignatories.Name = "colSignatories";
            this.colSignatories.OptionsColumn.AllowEdit = false;
            this.colSignatories.OptionsColumn.FixedWidth = true;
            this.colSignatories.OptionsColumn.ReadOnly = true;
            this.colSignatories.Visible = true;
            this.colSignatories.VisibleIndex = 4;
            this.colSignatories.Width = 140;
            // 
            // colbtnFavorite
            // 
            this.colbtnFavorite.Caption = " ";
            this.colbtnFavorite.FieldName = "Favorite";
            this.colbtnFavorite.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.colbtnFavorite.Name = "colbtnFavorite";
            this.colbtnFavorite.Visible = true;
            this.colbtnFavorite.VisibleIndex = 5;
            this.colbtnFavorite.Width = 25;
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
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.repositorybtnFavoriteYellow.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositorybtnFavoriteYellow.Name = "repositorybtnFavoriteYellow";
            this.repositorybtnFavoriteYellow.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositorybtnFavoriteYellow.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositorybtnFavoriteYellow_ButtonClick);
            // 
            // repositorybtnFavoriteBlue
            // 
            this.repositorybtnFavoriteBlue.AutoHeight = false;
            editorButtonImageOptions3.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions3.Image")));
            this.repositorybtnFavoriteBlue.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, serializableAppearanceObject10, serializableAppearanceObject11, serializableAppearanceObject12, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositorybtnFavoriteBlue.Name = "repositorybtnFavoriteBlue";
            this.repositorybtnFavoriteBlue.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositorybtnFavoriteBlue.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositorybtnFavoriteBlue_ButtonClick);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.gridControl);
            this.pnlMain.Controls.Add(this.pnlSearch);
            this.pnlMain.Controls.Add(this.pnlBottom);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(767, 529);
            this.pnlMain.TabIndex = 10;
            // 
            // frmOfficeForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 529);
            this.Controls.Add(this.pnlMain);
            this.Name = "frmOfficeForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جدول فرم های اداری";
            this.pnlBottom.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorybtnFavoriteYellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorybtnFavoriteBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.FlowLayoutPanel pnlBottom;
        private DevExpress.XtraEditors.ButtonEdit txtSearch;
        private DevExpress.XtraEditors.SimpleButton btnCopyContent;
        private DevExpress.XtraEditors.SimpleButton btnEditDocument;
        private DevExpress.XtraEditors.SimpleButton btnOpenDocument;
        private DevExpress.XtraEditors.SimpleButton btnAddDocument;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colReceiverName;
        private DevExpress.XtraGrid.Columns.GridColumn colSignatories;
        private DevExpress.XtraGrid.Columns.GridColumn colbtnFavorite;
        private DevExpress.XtraEditors.SimpleButton btnFavoritesList;
        private DevExpress.XtraGrid.Columns.GridColumn colFavorites;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositorybtnFavoriteYellow;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositorybtnFavoriteBlue;
        public DevExpress.XtraEditors.PanelControl pnlMain;
    }
}