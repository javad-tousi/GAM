namespace GAM.Forms.Profile
{
    partial class dlgAlerts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAlerts));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlertText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryAlertText = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colbtnDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositorybtnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryAlertText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorybtnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl.Size = new System.Drawing.Size(658, 435);
            this.gridControl.TabIndex = 13;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCategory,
            this.colDateTime,
            this.colAlertText,
            this.colbtnDelete});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsCustomization.AllowSort = false;
            this.gridView.OptionsHint.ShowCellHints = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsView.RowAutoHeight = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.RowHeight = 22;
            this.gridView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView_RowStyle);
            // 
            // colCategory
            // 
            this.colCategory.Caption = " ";
            this.colCategory.FieldName = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.OptionsColumn.AllowEdit = false;
            this.colCategory.OptionsColumn.FixedWidth = true;
            this.colCategory.OptionsColumn.ReadOnly = true;
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 0;
            this.colCategory.Width = 20;
            // 
            // colDateTime
            // 
            this.colDateTime.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDateTime.AppearanceCell.Options.UseFont = true;
            this.colDateTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDateTime.AppearanceHeader.Options.UseFont = true;
            this.colDateTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colDateTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDateTime.Caption = "تاریخ و ساعت";
            this.colDateTime.FieldName = "DateCreated";
            this.colDateTime.Image = ((System.Drawing.Image)(resources.GetObject("colDateTime.Image")));
            this.colDateTime.Name = "colDateTime";
            this.colDateTime.OptionsColumn.AllowEdit = false;
            this.colDateTime.OptionsColumn.FixedWidth = true;
            this.colDateTime.OptionsColumn.ReadOnly = true;
            this.colDateTime.Visible = true;
            this.colDateTime.VisibleIndex = 1;
            this.colDateTime.Width = 120;
            // 
            // colAlertText
            // 
            this.colAlertText.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAlertText.AppearanceCell.Options.UseFont = true;
            this.colAlertText.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAlertText.AppearanceHeader.Options.UseFont = true;
            this.colAlertText.AppearanceHeader.Options.UseTextOptions = true;
            this.colAlertText.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAlertText.Caption = "متن هشدار";
            this.colAlertText.ColumnEdit = this.repositoryAlertText;
            this.colAlertText.FieldName = "Content";
            this.colAlertText.Name = "colAlertText";
            this.colAlertText.OptionsColumn.AllowEdit = false;
            this.colAlertText.OptionsColumn.ReadOnly = true;
            this.colAlertText.Visible = true;
            this.colAlertText.VisibleIndex = 2;
            this.colAlertText.Width = 357;
            // 
            // repositoryAlertText
            // 
            this.repositoryAlertText.Name = "repositoryAlertText";
            // 
            // colbtnDelete
            // 
            this.colbtnDelete.Caption = " ";
            this.colbtnDelete.ColumnEdit = this.repositorybtnDelete;
            this.colbtnDelete.Name = "colbtnDelete";
            this.colbtnDelete.OptionsColumn.FixedWidth = true;
            this.colbtnDelete.Visible = true;
            this.colbtnDelete.VisibleIndex = 3;
            this.colbtnDelete.Width = 22;
            // 
            // repositorybtnDelete
            // 
            this.repositorybtnDelete.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.repositorybtnDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositorybtnDelete.Name = "repositorybtnDelete";
            this.repositorybtnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositorybtnDelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositorybtnDelete_ButtonClick);
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.InsertGalleryImage("reminder_16x16.png", "images/scheduling/reminder_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/scheduling/reminder_16x16.png"), 0);
            this.imageCollection.Images.SetKeyName(0, "reminder_16x16.png");
            this.imageCollection.InsertGalleryImage("suggestion_16x16.png", "images/support/suggestion_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/suggestion_16x16.png"), 1);
            this.imageCollection.Images.SetKeyName(1, "suggestion_16x16.png");
            this.imageCollection.InsertGalleryImage("warning_16x16.png", "images/status/warning_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/status/warning_16x16.png"), 2);
            this.imageCollection.Images.SetKeyName(2, "warning_16x16.png");
            this.imageCollection.InsertGalleryImage("convert_16x16.png", "images/actions/convert_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/convert_16x16.png"), 3);
            this.imageCollection.Images.SetKeyName(3, "convert_16x16.png");
            this.imageCollection.InsertGalleryImage("about_16x16.png", "devav/actions/about_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("devav/actions/about_16x16.png"), 4);
            this.imageCollection.Images.SetKeyName(4, "about_16x16.png");
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 435);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlBottom.Size = new System.Drawing.Size(658, 30);
            this.pnlBottom.TabIndex = 0;
            this.pnlBottom.Text = "flowLayoutPanel1";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Enabled = false;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(658, 30);
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "خروج";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // dlgAlerts
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 465);
            this.ControlBox = false;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.LookAndFeel.SkinName = "Office 2010 Silver";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MinimizeBox = false;
            this.Name = "dlgAlerts";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "( هشدارهای سامانه گام )";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlgAlerts_FormClosing);
            this.Shown += new System.EventHandler(this.dlgAlerts_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryAlertText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorybtnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colAlertText;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryAlertText;
        private System.Windows.Forms.Panel pnlBottom;
        private DevExpress.XtraGrid.Columns.GridColumn colbtnDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositorybtnDelete;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.Timer timer;
    }
}