namespace GAM.Forms.Profile
{
    partial class dlgDataLogs
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgDataLogs));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colActionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryNote = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colActionDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.pnlBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.zoomTrackBar = new DevExpress.XtraEditors.ZoomTrackBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryNote,
            this.repositoryDelete});
            this.gridControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl.Size = new System.Drawing.Size(713, 306);
            this.gridControl.TabIndex = 7;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colActionID,
            this.colActionName,
            this.colNote,
            this.colActionDateTime,
            this.colUserName,
            this.colDelete});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsCustomization.AllowSort = false;
            this.gridView.OptionsHint.ShowCellHints = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsView.RowAutoHeight = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // colActionID
            // 
            this.colActionID.Caption = " ";
            this.colActionID.FieldName = "ActionID";
            this.colActionID.Name = "colActionID";
            this.colActionID.OptionsColumn.AllowEdit = false;
            this.colActionID.OptionsColumn.FixedWidth = true;
            this.colActionID.OptionsFilter.AllowFilter = false;
            this.colActionID.Visible = true;
            this.colActionID.VisibleIndex = 0;
            this.colActionID.Width = 25;
            // 
            // colActionName
            // 
            this.colActionName.AppearanceCell.Options.UseTextOptions = true;
            this.colActionName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colActionName.AppearanceHeader.Options.UseTextOptions = true;
            this.colActionName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colActionName.Caption = "نوع فعالیت";
            this.colActionName.FieldName = "ActionName";
            this.colActionName.Name = "colActionName";
            this.colActionName.OptionsColumn.AllowEdit = false;
            this.colActionName.OptionsColumn.FixedWidth = true;
            this.colActionName.Visible = true;
            this.colActionName.VisibleIndex = 1;
            this.colActionName.Width = 91;
            // 
            // colNote
            // 
            this.colNote.AppearanceHeader.Options.UseTextOptions = true;
            this.colNote.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNote.Caption = "توضیحات";
            this.colNote.ColumnEdit = this.repositoryNote;
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.OptionsFilter.AllowFilter = false;
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 2;
            this.colNote.Width = 340;
            // 
            // repositoryNote
            // 
            this.repositoryNote.Name = "repositoryNote";
            // 
            // colActionDateTime
            // 
            this.colActionDateTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colActionDateTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colActionDateTime.Caption = "زمان ایجاد";
            this.colActionDateTime.FieldName = "ActionDateTime";
            this.colActionDateTime.Image = ((System.Drawing.Image)(resources.GetObject("colActionDateTime.Image")));
            this.colActionDateTime.Name = "colActionDateTime";
            this.colActionDateTime.OptionsColumn.AllowEdit = false;
            this.colActionDateTime.OptionsColumn.FixedWidth = true;
            this.colActionDateTime.OptionsFilter.AllowFilter = false;
            this.colActionDateTime.Visible = true;
            this.colActionDateTime.VisibleIndex = 3;
            this.colActionDateTime.Width = 110;
            // 
            // colUserName
            // 
            this.colUserName.AppearanceHeader.Options.UseTextOptions = true;
            this.colUserName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserName.Caption = "کاربر ایجاد کننده";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Image = ((System.Drawing.Image)(resources.GetObject("colUserName.Image")));
            this.colUserName.Name = "colUserName";
            this.colUserName.OptionsColumn.AllowEdit = false;
            this.colUserName.OptionsColumn.FixedWidth = true;
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 4;
            this.colUserName.Width = 100;
            // 
            // colDelete
            // 
            this.colDelete.ColumnEdit = this.repositoryDelete;
            this.colDelete.Name = "colDelete";
            this.colDelete.Visible = true;
            this.colDelete.VisibleIndex = 5;
            this.colDelete.Width = 20;
            // 
            // repositoryDelete
            // 
            this.repositoryDelete.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.repositoryDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryDelete.Name = "repositoryDelete";
            this.repositoryDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryDelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryDelete_ButtonClick);
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.InsertGalleryImage("pencolor_16x16.png", "images/richedit/pencolor_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/richedit/pencolor_16x16.png"), 0);
            this.imageCollection.Images.SetKeyName(0, "pencolor_16x16.png");
            this.imageCollection.InsertGalleryImage("issue_16x16.png", "office2013/support/issue_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/support/issue_16x16.png"), 1);
            this.imageCollection.Images.SetKeyName(1, "issue_16x16.png");
            this.imageCollection.InsertGalleryImage("undo_16x16.png", "images/history/undo_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/history/undo_16x16.png"), 2);
            this.imageCollection.Images.SetKeyName(2, "undo_16x16.png");
            this.imageCollection.InsertGalleryImage("breakingchange_16x16.png", "images/support/breakingchange_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/breakingchange_16x16.png"), 3);
            this.imageCollection.Images.SetKeyName(3, "breakingchange_16x16.png");
            this.imageCollection.InsertGalleryImage("botask_16x16.png", "images/business%20objects/botask_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/botask_16x16.png"), 4);
            this.imageCollection.Images.SetKeyName(4, "botask_16x16.png");
            this.imageCollection.InsertGalleryImage("moveup_16x16.png", "images/arrows/moveup_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/moveup_16x16.png"), 5);
            this.imageCollection.Images.SetKeyName(5, "moveup_16x16.png");
            this.imageCollection.InsertGalleryImage("insertcomment_16x16.png", "images/comments/insertcomment_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/comments/insertcomment_16x16.png"), 6);
            this.imageCollection.Images.SetKeyName(6, "insertcomment_16x16.png");
            this.imageCollection.InsertGalleryImage("info_16x16.png", "office2013/support/info_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/support/info_16x16.png"), 7);
            this.imageCollection.Images.SetKeyName(7, "info_16x16.png");
            this.imageCollection.InsertGalleryImage("open_16x16.png", "images/actions/open_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/open_16x16.png"), 8);
            this.imageCollection.Images.SetKeyName(8, "open_16x16.png");
            this.imageCollection.InsertGalleryImage("reminder_16x16.png", "images/scheduling/reminder_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/scheduling/reminder_16x16.png"), 9);
            this.imageCollection.Images.SetKeyName(9, "reminder_16x16.png");
            this.imageCollection.InsertGalleryImage("handtool_16x16.png", "images/pdf%20viewer/handtool_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/pdf%20viewer/handtool_16x16.png"), 10);
            this.imageCollection.Images.SetKeyName(10, "handtool_16x16.png");
            this.imageCollection.Images.SetKeyName(11, "closeddocument_16x16.png");
            this.imageCollection.InsertGalleryImage("notes_16x16.png", "images/content/notes_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/content/notes_16x16.png"), 12);
            this.imageCollection.Images.SetKeyName(12, "notes_16x16.png");
            this.imageCollection.InsertGalleryImage("forcetesting_16x16.png", "office2013/programming/forcetesting_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/programming/forcetesting_16x16.png"), 13);
            this.imageCollection.Images.SetKeyName(13, "forcetesting_16x16.png");
            this.imageCollection.InsertGalleryImage("iconsetsymbols3_16x16.png", "images/conditional%20formatting/iconsetsymbols3_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/conditional%20formatting/iconsetsymbols3_16x16.png"), 14);
            this.imageCollection.Images.SetKeyName(14, "iconsetsymbols3_16x16.png");
            this.imageCollection.InsertGalleryImage("movedown_16x16.png", "images/arrows/movedown_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/movedown_16x16.png"), 15);
            this.imageCollection.Images.SetKeyName(15, "movedown_16x16.png");
            this.imageCollection.InsertGalleryImage("breakingchange_16x16.png", "images/support/breakingchange_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/breakingchange_16x16.png"), 16);
            this.imageCollection.Images.SetKeyName(16, "breakingchange_16x16.png");
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.zoomTrackBar);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 306);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlBottom.Size = new System.Drawing.Size(713, 23);
            this.pnlBottom.TabIndex = 200;
            this.pnlBottom.Text = "flowLayoutPanel1";
            this.pnlBottom.Visible = false;
            // 
            // zoomTrackBar
            // 
            this.zoomTrackBar.EditValue = null;
            this.zoomTrackBar.Location = new System.Drawing.Point(490, 0);
            this.zoomTrackBar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.zoomTrackBar.Name = "zoomTrackBar";
            this.zoomTrackBar.Properties.Middle = 5;
            this.zoomTrackBar.Size = new System.Drawing.Size(220, 23);
            this.zoomTrackBar.TabIndex = 0;
            this.zoomTrackBar.TabStop = false;
            this.zoomTrackBar.EditValueChanged += new System.EventHandler(this.zoomTrackBar_EditValueChanged);
            // 
            // dlgDataLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 329);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
            this.MinimizeBox = false;
            this.Name = "dlgDataLogs";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ریز فرایندها";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colActionID;
        private DevExpress.XtraGrid.Columns.GridColumn colActionName;
        private DevExpress.XtraGrid.Columns.GridColumn colActionDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryNote;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.Utils.ImageCollection imageCollection;
        private System.Windows.Forms.FlowLayoutPanel pnlBottom;
        private DevExpress.XtraEditors.ZoomTrackBarControl zoomTrackBar;
        private DevExpress.XtraGrid.Columns.GridColumn colDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryDelete;
    }
}