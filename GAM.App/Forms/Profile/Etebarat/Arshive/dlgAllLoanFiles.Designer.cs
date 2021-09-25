namespace GAM.Forms.Profile.Etebarat.Arshive
{
    partial class dlgAllLoanFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAllLoanFiles));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlSearch = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearch = new DevExpress.XtraEditors.ButtonEdit();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFileID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIndicatorID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCoverNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBranchID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBranchName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.progressBar = new DevExpress.XtraEditors.ProgressBarControl();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.ColumnCount = 2;
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.pnlSearch.Controls.Add(this.txtSearch, 0, 0);
            this.pnlSearch.Controls.Add(this.btnRefresh, 1, 0);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(1);
            this.pnlSearch.RowCount = 1;
            this.pnlSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlSearch.Size = new System.Drawing.Size(606, 29);
            this.pnlSearch.TabIndex = 11;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.EditValue = "";
            this.txtSearch.Location = new System.Drawing.Point(31, 1);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Properties.Appearance.Options.UseFont = true;
            this.txtSearch.Properties.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.txtSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.txtSearch.Properties.NullValuePrompt = "نام مشتری/شناسه پرونده/شماره کلاسه";
            this.txtSearch.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtSearch.Size = new System.Drawing.Size(574, 27);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtSearch_ButtonClick);
            this.txtSearch.EditValueChanged += new System.EventHandler(this.txtSearch_EditValueChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnRefresh.Location = new System.Drawing.Point(1, 1);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(30, 27);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 29);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(606, 455);
            this.gridControl.TabIndex = 3;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            this.gridControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFileID,
            this.colIndicatorID,
            this.colCoverNo,
            this.colBranchID,
            this.colBranchName,
            this.colCustomerName});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.RowHeight = 22;
            this.gridView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView_RowStyle);
            this.gridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyDown);
            this.gridView.DoubleClick += new System.EventHandler(this.gridView_DoubleClick);
            // 
            // colFileID
            // 
            this.colFileID.AppearanceCell.Options.UseTextOptions = true;
            this.colFileID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFileID.AppearanceHeader.Options.UseTextOptions = true;
            this.colFileID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFileID.Caption = "شناسه";
            this.colFileID.FieldName = "FileID";
            this.colFileID.Name = "colFileID";
            this.colFileID.OptionsColumn.AllowEdit = false;
            this.colFileID.OptionsColumn.FixedWidth = true;
            this.colFileID.OptionsColumn.ReadOnly = true;
            this.colFileID.OptionsFilter.AllowFilter = false;
            this.colFileID.Visible = true;
            this.colFileID.VisibleIndex = 0;
            this.colFileID.Width = 30;
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
            this.colIndicatorID.OptionsFilter.AllowFilter = false;
            this.colIndicatorID.Visible = true;
            this.colIndicatorID.VisibleIndex = 1;
            this.colIndicatorID.Width = 40;
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
            this.colCoverNo.OptionsFilter.AllowFilter = false;
            this.colCoverNo.Visible = true;
            this.colCoverNo.VisibleIndex = 2;
            this.colCoverNo.Width = 30;
            // 
            // colBranchID
            // 
            this.colBranchID.AppearanceCell.Options.UseTextOptions = true;
            this.colBranchID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBranchID.AppearanceHeader.Options.UseTextOptions = true;
            this.colBranchID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBranchID.Caption = "کد شعبه";
            this.colBranchID.FieldName = "BranchID";
            this.colBranchID.Name = "colBranchID";
            this.colBranchID.OptionsColumn.AllowEdit = false;
            this.colBranchID.OptionsColumn.FixedWidth = true;
            this.colBranchID.OptionsColumn.ReadOnly = true;
            this.colBranchID.Visible = true;
            this.colBranchID.VisibleIndex = 3;
            this.colBranchID.Width = 40;
            // 
            // colBranchName
            // 
            this.colBranchName.AppearanceHeader.Options.UseTextOptions = true;
            this.colBranchName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBranchName.Caption = "نام شعبه";
            this.colBranchName.FieldName = "BranchName";
            this.colBranchName.Name = "colBranchName";
            this.colBranchName.OptionsColumn.AllowEdit = false;
            this.colBranchName.OptionsColumn.FixedWidth = true;
            this.colBranchName.OptionsColumn.ReadOnly = true;
            this.colBranchName.Visible = true;
            this.colBranchName.VisibleIndex = 4;
            this.colBranchName.Width = 100;
            // 
            // colCustomerName
            // 
            this.colCustomerName.AppearanceHeader.Options.UseTextOptions = true;
            this.colCustomerName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCustomerName.Caption = "نام مشتری";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Image = ((System.Drawing.Image)(resources.GetObject("colCustomerName.Image")));
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.OptionsColumn.AllowEdit = false;
            this.colCustomerName.OptionsColumn.FixedWidth = true;
            this.colCustomerName.OptionsColumn.ReadOnly = true;
            this.colCustomerName.OptionsFilter.AllowFilter = false;
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 5;
            this.colCustomerName.Width = 150;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.EditValue = "0";
            this.progressBar.Location = new System.Drawing.Point(0, 484);
            this.progressBar.Name = "progressBar";
            this.progressBar.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.progressBar.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.progressBar.Properties.ShowTitle = true;
            this.progressBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.progressBar.Size = new System.Drawing.Size(606, 18);
            this.progressBar.TabIndex = 0;
            this.progressBar.Visible = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.gridControl);
            this.pnlMain.Controls.Add(this.progressBar);
            this.pnlMain.Controls.Add(this.pnlSearch);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlMain.Size = new System.Drawing.Size(606, 502);
            this.pnlMain.TabIndex = 12;
            // 
            // dlgAllLoanFiles
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 502);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.LookAndFeel.SkinName = "Office 2010 Silver";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgAllLoanFiles";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlSearch;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colFileID;
        private DevExpress.XtraGrid.Columns.GridColumn colIndicatorID;
        private DevExpress.XtraGrid.Columns.GridColumn colCoverNo;
        private DevExpress.XtraGrid.Columns.GridColumn colBranchID;
        private DevExpress.XtraGrid.Columns.GridColumn colBranchName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraEditors.ButtonEdit txtSearch;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.ProgressBarControl progressBar;
        public DevExpress.XtraEditors.PanelControl pnlMain;
    }
}