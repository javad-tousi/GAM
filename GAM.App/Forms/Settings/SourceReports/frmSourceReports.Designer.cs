namespace GAM.Forms.Settings.SourceReports
{
    partial class frmSourceReports
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions7 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSourceReports));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject25 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject26 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject27 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject28 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions8 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject29 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject30 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject31 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject32 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colShowTables = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryShowTables = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colSourceId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReferenceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSourceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShowMap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryShowMap = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnAddSource = new DevExpress.XtraEditors.SimpleButton();
            this.pnlBotton = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryShowTables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryShowMap)).BeginInit();
            this.pnlBotton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(2, 2);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryShowMap,
            this.repositoryShowTables});
            this.gridControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl.Size = new System.Drawing.Size(755, 325);
            this.gridControl.TabIndex = 3;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colShowTables,
            this.colSourceId,
            this.colReferenceName,
            this.colSourceName,
            this.colLastDate,
            this.colShowMap});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsCustomization.AllowColumnMoving = false;
            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.DoubleClick += new System.EventHandler(this.gridView_DoubleClick);
            // 
            // colShowTables
            // 
            this.colShowTables.ColumnEdit = this.repositoryShowTables;
            this.colShowTables.Name = "colShowTables";
            this.colShowTables.OptionsColumn.FixedWidth = true;
            this.colShowTables.OptionsColumn.ShowCaption = false;
            this.colShowTables.Visible = true;
            this.colShowTables.VisibleIndex = 0;
            this.colShowTables.Width = 24;
            // 
            // repositoryShowTables
            // 
            this.repositoryShowTables.AutoHeight = false;
            editorButtonImageOptions7.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions7.Image")));
            this.repositoryShowTables.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions7, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject25, serializableAppearanceObject26, serializableAppearanceObject27, serializableAppearanceObject28, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryShowTables.Name = "repositoryShowTables";
            this.repositoryShowTables.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryShowTables.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryShowTables_ButtonClick);
            // 
            // colSourceId
            // 
            this.colSourceId.AppearanceCell.Options.UseTextOptions = true;
            this.colSourceId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSourceId.AppearanceHeader.Options.UseTextOptions = true;
            this.colSourceId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSourceId.FieldName = "SourceID";
            this.colSourceId.Image = ((System.Drawing.Image)(resources.GetObject("colSourceId.Image")));
            this.colSourceId.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.colSourceId.Name = "colSourceId";
            this.colSourceId.OptionsColumn.AllowEdit = false;
            this.colSourceId.OptionsColumn.FixedWidth = true;
            this.colSourceId.OptionsColumn.ReadOnly = true;
            this.colSourceId.OptionsColumn.ShowCaption = false;
            this.colSourceId.Visible = true;
            this.colSourceId.VisibleIndex = 1;
            this.colSourceId.Width = 50;
            // 
            // colReferenceName
            // 
            this.colReferenceName.AppearanceCell.Options.UseTextOptions = true;
            this.colReferenceName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReferenceName.AppearanceHeader.Options.UseTextOptions = true;
            this.colReferenceName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReferenceName.Caption = "مرجع گزارش";
            this.colReferenceName.FieldName = "ReferenceName";
            this.colReferenceName.Name = "colReferenceName";
            this.colReferenceName.OptionsColumn.AllowEdit = false;
            this.colReferenceName.OptionsColumn.ReadOnly = true;
            this.colReferenceName.Visible = true;
            this.colReferenceName.VisibleIndex = 2;
            this.colReferenceName.Width = 189;
            // 
            // colSourceName
            // 
            this.colSourceName.AppearanceCell.Options.UseTextOptions = true;
            this.colSourceName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSourceName.AppearanceHeader.Options.UseTextOptions = true;
            this.colSourceName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSourceName.Caption = "نام گزارش";
            this.colSourceName.FieldName = "SourceName";
            this.colSourceName.Name = "colSourceName";
            this.colSourceName.OptionsColumn.AllowEdit = false;
            this.colSourceName.OptionsColumn.ReadOnly = true;
            this.colSourceName.Visible = true;
            this.colSourceName.VisibleIndex = 3;
            this.colSourceName.Width = 378;
            // 
            // colLastDate
            // 
            this.colLastDate.AppearanceCell.Options.UseTextOptions = true;
            this.colLastDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLastDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colLastDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLastDate.Caption = "آخرین مقطع";
            this.colLastDate.FieldName = "LastDate";
            this.colLastDate.Name = "colLastDate";
            this.colLastDate.OptionsColumn.AllowEdit = false;
            this.colLastDate.OptionsColumn.FixedWidth = true;
            this.colLastDate.OptionsColumn.ReadOnly = true;
            this.colLastDate.Visible = true;
            this.colLastDate.VisibleIndex = 4;
            // 
            // colShowMap
            // 
            this.colShowMap.AppearanceCell.Options.UseTextOptions = true;
            this.colShowMap.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShowMap.AppearanceHeader.Options.UseTextOptions = true;
            this.colShowMap.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShowMap.ColumnEdit = this.repositoryShowMap;
            this.colShowMap.Name = "colShowMap";
            this.colShowMap.OptionsColumn.ShowCaption = false;
            this.colShowMap.Visible = true;
            this.colShowMap.VisibleIndex = 5;
            this.colShowMap.Width = 27;
            // 
            // repositoryShowMap
            // 
            this.repositoryShowMap.AutoHeight = false;
            editorButtonImageOptions8.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions8.Image")));
            this.repositoryShowMap.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions8, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject29, serializableAppearanceObject30, serializableAppearanceObject31, serializableAppearanceObject32, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryShowMap.Name = "repositoryShowMap";
            this.repositoryShowMap.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryShowMap.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryShowMap_ButtonClick);
            // 
            // btnAddSource
            // 
            this.btnAddSource.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddSource.ImageOptions.Image")));
            this.btnAddSource.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnAddSource.Location = new System.Drawing.Point(612, 3);
            this.btnAddSource.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.btnAddSource.Name = "btnAddSource";
            this.btnAddSource.Size = new System.Drawing.Size(138, 29);
            this.btnAddSource.TabIndex = 6;
            this.btnAddSource.Text = "افزودن منبع اطلاعاتی";
            this.btnAddSource.Click += new System.EventHandler(this.btnAddSource_Click);
            // 
            // pnlBotton
            // 
            this.pnlBotton.Controls.Add(this.btnAddSource);
            this.pnlBotton.Controls.Add(this.btnRefresh);
            this.pnlBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotton.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlBotton.Location = new System.Drawing.Point(2, 327);
            this.pnlBotton.Name = "pnlBotton";
            this.pnlBotton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pnlBotton.Size = new System.Drawing.Size(755, 35);
            this.pnlBotton.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnRefresh.Location = new System.Drawing.Point(450, 3);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(154, 29);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "بروزرسانی جداول";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.gridControl);
            this.pnlMain.Controls.Add(this.pnlBotton);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(759, 364);
            this.pnlMain.TabIndex = 4;
            // 
            // frmSourceReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 364);
            this.Controls.Add(this.pnlMain);
            this.Name = "frmSourceReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "منابع";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryShowTables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryShowMap)).EndInit();
            this.pnlBotton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colSourceId;
        private DevExpress.XtraGrid.Columns.GridColumn colReferenceName;
        private DevExpress.XtraGrid.Columns.GridColumn colSourceName;
        private DevExpress.XtraGrid.Columns.GridColumn colShowMap;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryShowMap;
        private DevExpress.XtraEditors.SimpleButton btnAddSource;
        private System.Windows.Forms.FlowLayoutPanel pnlBotton;
        private DevExpress.XtraGrid.Columns.GridColumn colShowTables;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryShowTables;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        public DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraGrid.Columns.GridColumn colLastDate;
    }
}