namespace GAM.Forms.Profile.Hoghoghi.Circulation
{
    partial class frmCirculationLegalFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCirculationLegalFiles));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colbtnShowLog = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryShowLog = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colModifiedDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIndicatorId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBranchName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLevelId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLevelName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractPlan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpertName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colColorName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboFileStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.pnlSearch = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearch = new DevExpress.XtraEditors.ButtonEdit();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportToXlsx = new DevExpress.XtraEditors.SimpleButton();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryShowLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFileStatus.Properties)).BeginInit();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(2, 31);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryShowLog});
            this.gridControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl.Size = new System.Drawing.Size(960, 419);
            this.gridControl.TabIndex = 9;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colbtnShowLog,
            this.colModifiedDateTime,
            this.colFileId,
            this.colFileStatus,
            this.colContractId,
            this.colIndicatorId,
            this.colBranchName,
            this.colCustomerName,
            this.colLevelId,
            this.colLevelName,
            this.colDateLevel,
            this.colContractPlan,
            this.colExpertName,
            this.colAgentName,
            this.colColorName});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsCustomization.AllowColumnMoving = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.RowHeight = 22;
            this.gridView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView_RowStyle);
            // 
            // colbtnShowLog
            // 
            this.colbtnShowLog.AppearanceHeader.Options.UseTextOptions = true;
            this.colbtnShowLog.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colbtnShowLog.Caption = " ";
            this.colbtnShowLog.ColumnEdit = this.repositoryShowLog;
            this.colbtnShowLog.FieldName = "btnShowLog";
            this.colbtnShowLog.Name = "colbtnShowLog";
            this.colbtnShowLog.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.colbtnShowLog.OptionsFilter.AllowFilter = false;
            this.colbtnShowLog.Visible = true;
            this.colbtnShowLog.VisibleIndex = 0;
            this.colbtnShowLog.Width = 25;
            // 
            // repositoryShowLog
            // 
            this.repositoryShowLog.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.repositoryShowLog.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryShowLog.Name = "repositoryShowLog";
            this.repositoryShowLog.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryShowLog.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryShowLog_ButtonClick);
            // 
            // colModifiedDateTime
            // 
            this.colModifiedDateTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colModifiedDateTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colModifiedDateTime.Caption = "آخرین اقدام";
            this.colModifiedDateTime.FieldName = "ModifiedDateTime";
            this.colModifiedDateTime.Image = ((System.Drawing.Image)(resources.GetObject("colModifiedDateTime.Image")));
            this.colModifiedDateTime.Name = "colModifiedDateTime";
            this.colModifiedDateTime.OptionsColumn.AllowEdit = false;
            this.colModifiedDateTime.OptionsColumn.FixedWidth = true;
            this.colModifiedDateTime.OptionsColumn.ReadOnly = true;
            this.colModifiedDateTime.OptionsFilter.AllowFilter = false;
            this.colModifiedDateTime.Visible = true;
            this.colModifiedDateTime.VisibleIndex = 1;
            this.colModifiedDateTime.Width = 105;
            // 
            // colFileId
            // 
            this.colFileId.AppearanceCell.Options.UseTextOptions = true;
            this.colFileId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colFileId.AppearanceHeader.Options.UseTextOptions = true;
            this.colFileId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFileId.Caption = "ش.پرونده";
            this.colFileId.FieldName = "FileID";
            this.colFileId.Name = "colFileId";
            this.colFileId.OptionsColumn.AllowEdit = false;
            this.colFileId.OptionsColumn.FixedWidth = true;
            this.colFileId.OptionsColumn.ReadOnly = true;
            this.colFileId.OptionsFilter.AllowFilter = false;
            this.colFileId.Visible = true;
            this.colFileId.VisibleIndex = 2;
            this.colFileId.Width = 65;
            // 
            // colFileStatus
            // 
            this.colFileStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colFileStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFileStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colFileStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFileStatus.Caption = "وضعیت";
            this.colFileStatus.FieldName = "FileStatus";
            this.colFileStatus.Name = "colFileStatus";
            this.colFileStatus.OptionsColumn.AllowEdit = false;
            this.colFileStatus.OptionsColumn.FixedWidth = true;
            this.colFileStatus.OptionsColumn.ReadOnly = true;
            this.colFileStatus.Visible = true;
            this.colFileStatus.VisibleIndex = 3;
            this.colFileStatus.Width = 65;
            // 
            // colContractId
            // 
            this.colContractId.AppearanceCell.Options.UseTextOptions = true;
            this.colContractId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colContractId.AppearanceHeader.Options.UseTextOptions = true;
            this.colContractId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colContractId.Caption = "شماره قرارداد";
            this.colContractId.FieldName = "ContractID";
            this.colContractId.Name = "colContractId";
            this.colContractId.OptionsColumn.FixedWidth = true;
            this.colContractId.OptionsColumn.ReadOnly = true;
            this.colContractId.OptionsFilter.AllowFilter = false;
            this.colContractId.Visible = true;
            this.colContractId.VisibleIndex = 4;
            this.colContractId.Width = 100;
            // 
            // colIndicatorId
            // 
            this.colIndicatorId.AppearanceCell.Options.UseTextOptions = true;
            this.colIndicatorId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colIndicatorId.AppearanceHeader.Options.UseTextOptions = true;
            this.colIndicatorId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIndicatorId.Caption = "ش.کلاسه";
            this.colIndicatorId.FieldName = "IndicatorID";
            this.colIndicatorId.Name = "colIndicatorId";
            this.colIndicatorId.OptionsColumn.AllowEdit = false;
            this.colIndicatorId.OptionsColumn.FixedWidth = true;
            this.colIndicatorId.OptionsColumn.ReadOnly = true;
            this.colIndicatorId.OptionsFilter.AllowFilter = false;
            this.colIndicatorId.Visible = true;
            this.colIndicatorId.VisibleIndex = 5;
            this.colIndicatorId.Width = 65;
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
            this.colBranchName.VisibleIndex = 6;
            this.colBranchName.Width = 130;
            // 
            // colCustomerName
            // 
            this.colCustomerName.AppearanceHeader.Options.UseTextOptions = true;
            this.colCustomerName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCustomerName.Caption = "نام مدیون";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Image = ((System.Drawing.Image)(resources.GetObject("colCustomerName.Image")));
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.OptionsColumn.AllowEdit = false;
            this.colCustomerName.OptionsColumn.FixedWidth = true;
            this.colCustomerName.OptionsColumn.ReadOnly = true;
            this.colCustomerName.OptionsFilter.AllowFilter = false;
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 7;
            this.colCustomerName.Width = 180;
            // 
            // colLevelId
            // 
            this.colLevelId.AppearanceCell.Options.UseTextOptions = true;
            this.colLevelId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevelId.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevelId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevelId.Caption = " ";
            this.colLevelId.FieldName = "LevelID";
            this.colLevelId.Name = "colLevelId";
            this.colLevelId.OptionsColumn.AllowEdit = false;
            this.colLevelId.OptionsColumn.FixedWidth = true;
            this.colLevelId.OptionsColumn.ReadOnly = true;
            this.colLevelId.OptionsFilter.AllowFilter = false;
            this.colLevelId.Visible = true;
            this.colLevelId.VisibleIndex = 8;
            this.colLevelId.Width = 20;
            // 
            // colLevelName
            // 
            this.colLevelName.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevelName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevelName.Caption = "شرح آخرین اقدام";
            this.colLevelName.FieldName = "LevelName";
            this.colLevelName.Name = "colLevelName";
            this.colLevelName.OptionsColumn.AllowEdit = false;
            this.colLevelName.OptionsColumn.FixedWidth = true;
            this.colLevelName.OptionsColumn.ReadOnly = true;
            this.colLevelName.OptionsFilter.AllowFilter = false;
            this.colLevelName.Visible = true;
            this.colLevelName.VisibleIndex = 9;
            this.colLevelName.Width = 262;
            // 
            // colDateLevel
            // 
            this.colDateLevel.AppearanceCell.Options.UseTextOptions = true;
            this.colDateLevel.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDateLevel.AppearanceHeader.Options.UseTextOptions = true;
            this.colDateLevel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDateLevel.Caption = "تاریخ اقدام";
            this.colDateLevel.DisplayFormat.FormatString = "0000/00/00";
            this.colDateLevel.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDateLevel.FieldName = "DateLevel";
            this.colDateLevel.Name = "colDateLevel";
            this.colDateLevel.OptionsColumn.AllowEdit = false;
            this.colDateLevel.OptionsColumn.FixedWidth = true;
            this.colDateLevel.OptionsColumn.ReadOnly = true;
            this.colDateLevel.OptionsFilter.AllowFilter = false;
            this.colDateLevel.Visible = true;
            this.colDateLevel.VisibleIndex = 10;
            // 
            // colContractPlan
            // 
            this.colContractPlan.AppearanceCell.Options.UseTextOptions = true;
            this.colContractPlan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colContractPlan.AppearanceHeader.Options.UseTextOptions = true;
            this.colContractPlan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colContractPlan.Caption = "سرفصل";
            this.colContractPlan.FieldName = "ContractPlan";
            this.colContractPlan.Name = "colContractPlan";
            this.colContractPlan.OptionsColumn.AllowEdit = false;
            this.colContractPlan.OptionsColumn.FixedWidth = true;
            this.colContractPlan.OptionsColumn.ReadOnly = true;
            this.colContractPlan.Visible = true;
            this.colContractPlan.VisibleIndex = 11;
            this.colContractPlan.Width = 90;
            // 
            // colExpertName
            // 
            this.colExpertName.AppearanceCell.Options.UseTextOptions = true;
            this.colExpertName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colExpertName.AppearanceHeader.Options.UseTextOptions = true;
            this.colExpertName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colExpertName.Caption = "نام کارشناس";
            this.colExpertName.FieldName = "ExpertName";
            this.colExpertName.Name = "colExpertName";
            this.colExpertName.OptionsColumn.AllowEdit = false;
            this.colExpertName.OptionsColumn.FixedWidth = true;
            this.colExpertName.OptionsColumn.ReadOnly = true;
            this.colExpertName.Visible = true;
            this.colExpertName.VisibleIndex = 12;
            this.colExpertName.Width = 130;
            // 
            // colAgentName
            // 
            this.colAgentName.AppearanceCell.Options.UseTextOptions = true;
            this.colAgentName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAgentName.AppearanceHeader.Options.UseTextOptions = true;
            this.colAgentName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAgentName.Caption = "نام مامور اجرا";
            this.colAgentName.FieldName = "AgentName";
            this.colAgentName.Name = "colAgentName";
            this.colAgentName.OptionsColumn.AllowEdit = false;
            this.colAgentName.OptionsColumn.FixedWidth = true;
            this.colAgentName.OptionsColumn.ReadOnly = true;
            this.colAgentName.Visible = true;
            this.colAgentName.VisibleIndex = 13;
            this.colAgentName.Width = 130;
            // 
            // colColorName
            // 
            this.colColorName.AppearanceCell.Options.UseTextOptions = true;
            this.colColorName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colColorName.AppearanceHeader.Options.UseTextOptions = true;
            this.colColorName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colColorName.Caption = "رنگ";
            this.colColorName.FieldName = "ColorName";
            this.colColorName.Name = "colColorName";
            this.colColorName.OptionsColumn.AllowEdit = false;
            this.colColorName.OptionsColumn.FixedWidth = true;
            this.colColorName.OptionsColumn.ReadOnly = true;
            this.colColorName.Visible = true;
            this.colColorName.VisibleIndex = 14;
            this.colColorName.Width = 40;
            // 
            // cboFileStatus
            // 
            this.cboFileStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboFileStatus.EditValue = "پرونده های جاری";
            this.cboFileStatus.Location = new System.Drawing.Point(56, 2);
            this.cboFileStatus.Margin = new System.Windows.Forms.Padding(1, 1, 1, 6);
            this.cboFileStatus.Name = "cboFileStatus";
            this.cboFileStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFileStatus.Properties.Appearance.Options.UseFont = true;
            this.cboFileStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.cboFileStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboFileStatus.Properties.AutoComplete = false;
            this.cboFileStatus.Properties.AutoHeight = false;
            this.cboFileStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cboFileStatus.Properties.Items.AddRange(new object[] {
            "پرونده های جاری",
            "متوقف/مختومه"});
            this.cboFileStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboFileStatus.Size = new System.Drawing.Size(140, 26);
            this.cboFileStatus.TabIndex = 5;
            this.cboFileStatus.TabStop = false;
            this.cboFileStatus.SelectedIndexChanged += new System.EventHandler(this.cboFileStatus_SelectedIndexChanged);
            // 
            // pnlSearch
            // 
            this.pnlSearch.ColumnCount = 4;
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlSearch.Controls.Add(this.cboFileStatus, 1, 0);
            this.pnlSearch.Controls.Add(this.txtSearch, 0, 0);
            this.pnlSearch.Controls.Add(this.btnRefresh, 2, 0);
            this.pnlSearch.Controls.Add(this.btnExportToXlsx, 3, 0);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(2, 2);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(1);
            this.pnlSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlSearch.RowCount = 1;
            this.pnlSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.pnlSearch.Size = new System.Drawing.Size(960, 29);
            this.pnlSearch.TabIndex = 12;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.EditValue = "";
            this.txtSearch.Location = new System.Drawing.Point(198, 2);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(1, 1, 1, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Properties.Appearance.Options.UseFont = true;
            this.txtSearch.Properties.AutoHeight = false;
            this.txtSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.txtSearch.Properties.NullValuePrompt = "ش.قرارداد/پرونده/کلاسه/نام شعبه/نام مدیون";
            this.txtSearch.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtSearch.Size = new System.Drawing.Size(760, 26);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtSearch_ButtonClick);
            this.txtSearch.EditValueChanged += new System.EventHandler(this.txtSearch_EditValueChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(29, 2);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(1, 1, 1, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(25, 26);
            this.btnRefresh.TabIndex = 27;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExportToXlsx
            // 
            this.btnExportToXlsx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportToXlsx.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToXlsx.ImageOptions.Image")));
            this.btnExportToXlsx.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.BottomCenter;
            this.btnExportToXlsx.Location = new System.Drawing.Point(2, 2);
            this.btnExportToXlsx.Margin = new System.Windows.Forms.Padding(1, 1, 1, 6);
            this.btnExportToXlsx.Name = "btnExportToXlsx";
            this.btnExportToXlsx.Size = new System.Drawing.Size(25, 26);
            this.btnExportToXlsx.TabIndex = 25;
            this.btnExportToXlsx.Click += new System.EventHandler(this.btnExportToXlsx_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.gridControl);
            this.pnlMain.Controls.Add(this.pnlSearch);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(964, 452);
            this.pnlMain.TabIndex = 13;
            // 
            // frmCirculationLegalFiles
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 452);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MinimumSize = new System.Drawing.Size(424, 430);
            this.Name = "frmCirculationLegalFiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گردش پرونده های حقوقی";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryShowLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFileStatus.Properties)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colbtnShowLog;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryShowLog;
        private DevExpress.XtraGrid.Columns.GridColumn colModifiedDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colFileStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colBranchName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colLevelName;
        private DevExpress.XtraGrid.Columns.GridColumn colFileId;
        private DevExpress.XtraGrid.Columns.GridColumn colContractId;
        private DevExpress.XtraGrid.Columns.GridColumn colIndicatorId;
        private DevExpress.XtraGrid.Columns.GridColumn colContractPlan;
        private DevExpress.XtraGrid.Columns.GridColumn colDateLevel;
        private DevExpress.XtraGrid.Columns.GridColumn colLevelId;
        public DevExpress.XtraEditors.ComboBoxEdit cboFileStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colExpertName;
        private DevExpress.XtraGrid.Columns.GridColumn colAgentName;
        private DevExpress.XtraGrid.Columns.GridColumn colColorName;
        private System.Windows.Forms.TableLayoutPanel pnlSearch;
        private DevExpress.XtraEditors.ButtonEdit txtSearch;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnExportToXlsx;
        public DevExpress.XtraEditors.PanelControl pnlMain;
    }
}