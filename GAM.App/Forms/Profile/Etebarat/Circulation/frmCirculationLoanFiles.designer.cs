namespace GAM.Forms.Profile.Etebarat.Circulation
{
    partial class frmCirculationLoanFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCirculationLoanFiles));
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
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtSearch = new DevExpress.XtraEditors.ButtonEdit();
            this.cboSearchType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colbtnShowLog = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositorybtnShowLog = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colModifiedDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequestStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreditCommittee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequestID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequestType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBranchName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFacilityName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequestAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpertName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlSearch = new System.Windows.Forms.TableLayoutPanel();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportToXlsx = new DevExpress.XtraEditors.SimpleButton();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSearchType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorybtnShowLog)).BeginInit();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Enabled = false;
            this.btnSearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.ImageOptions.Image")));
            this.btnSearch.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnSearch.Location = new System.Drawing.Point(57, 2);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(1, 1, 1, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 26);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.EditValue = "";
            this.txtSearch.Location = new System.Drawing.Point(281, 2);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(1, 1, 1, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Properties.Appearance.Options.UseFont = true;
            this.txtSearch.Properties.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.txtSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.txtSearch.Properties.NullValuePrompt = "نام شعبه/نام متقاضی/شماره پیشنهاد";
            this.txtSearch.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtSearch.Size = new System.Drawing.Size(603, 26);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtSearch_ButtonClick);
            this.txtSearch.EditValueChanged += new System.EventHandler(this.txtSearch_EditValueChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // cboSearchType
            // 
            this.cboSearchType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboSearchType.EditValue = "دو هفته گذشته";
            this.cboSearchType.Location = new System.Drawing.Point(139, 2);
            this.cboSearchType.Margin = new System.Windows.Forms.Padding(1, 1, 1, 6);
            this.cboSearchType.Name = "cboSearchType";
            this.cboSearchType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSearchType.Properties.Appearance.Options.UseFont = true;
            this.cboSearchType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.cboSearchType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboSearchType.Properties.AutoComplete = false;
            this.cboSearchType.Properties.AutoHeight = false;
            this.cboSearchType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cboSearchType.Properties.Items.AddRange(new object[] {
            "دو هفته گذشته",
            "یک ماه گذشته",
            "کدشعبه (یک سال)",
            "شماره پیشنهاد"});
            this.cboSearchType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboSearchType.Size = new System.Drawing.Size(140, 26);
            this.cboSearchType.TabIndex = 2;
            this.cboSearchType.TabStop = false;
            this.cboSearchType.SelectedIndexChanged += new System.EventHandler(this.cboSearchType_SelectedIndexChanged);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(2, 31);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositorybtnShowLog});
            this.gridControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl.Size = new System.Drawing.Size(886, 417);
            this.gridControl.TabIndex = 4;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colbtnShowLog,
            this.colModifiedDateTime,
            this.colRequestStatus,
            this.colCreditCommittee,
            this.colRequestID,
            this.colRequestType,
            this.colBranchName,
            this.colCustomerName,
            this.colFacilityName,
            this.colRequestAmount,
            this.colExpertName,
            this.colFileID});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.RowHeight = 22;
            // 
            // colbtnShowLog
            // 
            this.colbtnShowLog.AppearanceHeader.Options.UseTextOptions = true;
            this.colbtnShowLog.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colbtnShowLog.Caption = " ";
            this.colbtnShowLog.ColumnEdit = this.repositorybtnShowLog;
            this.colbtnShowLog.FieldName = "ShowLog";
            this.colbtnShowLog.Name = "colbtnShowLog";
            this.colbtnShowLog.OptionsColumn.FixedWidth = true;
            this.colbtnShowLog.OptionsFilter.AllowFilter = false;
            this.colbtnShowLog.Visible = true;
            this.colbtnShowLog.VisibleIndex = 0;
            this.colbtnShowLog.Width = 25;
            // 
            // repositorybtnShowLog
            // 
            this.repositorybtnShowLog.AutoHeight = false;
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.repositorybtnShowLog.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositorybtnShowLog.Name = "repositorybtnShowLog";
            this.repositorybtnShowLog.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositorybtnShowLog.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositorybtnShowLog_ButtonClick);
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
            this.colModifiedDateTime.Width = 110;
            // 
            // colRequestStatus
            // 
            this.colRequestStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colRequestStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRequestStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colRequestStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRequestStatus.Caption = "وضعیت فعلی";
            this.colRequestStatus.FieldName = "RequestStatus";
            this.colRequestStatus.Name = "colRequestStatus";
            this.colRequestStatus.OptionsColumn.AllowEdit = false;
            this.colRequestStatus.OptionsColumn.FixedWidth = true;
            this.colRequestStatus.OptionsColumn.ReadOnly = true;
            this.colRequestStatus.Visible = true;
            this.colRequestStatus.VisibleIndex = 2;
            this.colRequestStatus.Width = 80;
            // 
            // colCreditCommittee
            // 
            this.colCreditCommittee.AppearanceCell.Options.UseTextOptions = true;
            this.colCreditCommittee.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCreditCommittee.AppearanceHeader.Options.UseTextOptions = true;
            this.colCreditCommittee.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCreditCommittee.Caption = "کمیته اعتباری";
            this.colCreditCommittee.FieldName = "CreditCommittee";
            this.colCreditCommittee.Name = "colCreditCommittee";
            this.colCreditCommittee.OptionsColumn.AllowEdit = false;
            this.colCreditCommittee.OptionsColumn.FixedWidth = true;
            this.colCreditCommittee.OptionsColumn.ReadOnly = true;
            this.colCreditCommittee.Visible = true;
            this.colCreditCommittee.VisibleIndex = 3;
            this.colCreditCommittee.Width = 100;
            // 
            // colRequestID
            // 
            this.colRequestID.AppearanceCell.Options.UseTextOptions = true;
            this.colRequestID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colRequestID.AppearanceHeader.Options.UseTextOptions = true;
            this.colRequestID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRequestID.Caption = "شماره پیشنهاد";
            this.colRequestID.DisplayFormat.FormatString = "D";
            this.colRequestID.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRequestID.FieldName = "RequestID";
            this.colRequestID.Name = "colRequestID";
            this.colRequestID.OptionsColumn.FixedWidth = true;
            this.colRequestID.OptionsColumn.ReadOnly = true;
            this.colRequestID.OptionsFilter.AllowFilter = false;
            this.colRequestID.Visible = true;
            this.colRequestID.VisibleIndex = 4;
            this.colRequestID.Width = 100;
            // 
            // colRequestType
            // 
            this.colRequestType.AppearanceCell.Options.UseTextOptions = true;
            this.colRequestType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRequestType.AppearanceHeader.Options.UseTextOptions = true;
            this.colRequestType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRequestType.Caption = "نوع پیشنهاد";
            this.colRequestType.FieldName = "RequestType";
            this.colRequestType.Name = "colRequestType";
            this.colRequestType.OptionsColumn.AllowEdit = false;
            this.colRequestType.OptionsColumn.FixedWidth = true;
            this.colRequestType.OptionsColumn.ReadOnly = true;
            this.colRequestType.OptionsFilter.AllowFilter = false;
            this.colRequestType.Visible = true;
            this.colRequestType.VisibleIndex = 5;
            this.colRequestType.Width = 93;
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
            this.colBranchName.Width = 160;
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
            this.colCustomerName.VisibleIndex = 7;
            this.colCustomerName.Width = 180;
            // 
            // colFacilityName
            // 
            this.colFacilityName.AppearanceHeader.Options.UseTextOptions = true;
            this.colFacilityName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFacilityName.Caption = "نوع تسهیلات";
            this.colFacilityName.FieldName = "FacilityName";
            this.colFacilityName.Name = "colFacilityName";
            this.colFacilityName.OptionsColumn.AllowEdit = false;
            this.colFacilityName.OptionsColumn.FixedWidth = true;
            this.colFacilityName.OptionsColumn.ReadOnly = true;
            this.colFacilityName.OptionsFilter.AllowFilter = false;
            this.colFacilityName.Visible = true;
            this.colFacilityName.VisibleIndex = 8;
            this.colFacilityName.Width = 150;
            // 
            // colRequestAmount
            // 
            this.colRequestAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colRequestAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRequestAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.colRequestAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRequestAmount.Caption = "مبلغ";
            this.colRequestAmount.DisplayFormat.FormatString = "n0";
            this.colRequestAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRequestAmount.FieldName = "RequestAmount";
            this.colRequestAmount.Name = "colRequestAmount";
            this.colRequestAmount.OptionsColumn.AllowEdit = false;
            this.colRequestAmount.OptionsColumn.FixedWidth = true;
            this.colRequestAmount.OptionsColumn.ReadOnly = true;
            this.colRequestAmount.OptionsFilter.AllowFilter = false;
            this.colRequestAmount.Visible = true;
            this.colRequestAmount.VisibleIndex = 9;
            this.colRequestAmount.Width = 65;
            // 
            // colExpertName
            // 
            this.colExpertName.AppearanceCell.Options.UseTextOptions = true;
            this.colExpertName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colExpertName.AppearanceHeader.Options.UseTextOptions = true;
            this.colExpertName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colExpertName.Caption = "نام کارشناس";
            this.colExpertName.FieldName = "ExpertName";
            this.colExpertName.Image = ((System.Drawing.Image)(resources.GetObject("colExpertName.Image")));
            this.colExpertName.Name = "colExpertName";
            this.colExpertName.OptionsColumn.AllowEdit = false;
            this.colExpertName.OptionsColumn.FixedWidth = true;
            this.colExpertName.OptionsColumn.ReadOnly = true;
            this.colExpertName.Visible = true;
            this.colExpertName.VisibleIndex = 10;
            this.colExpertName.Width = 120;
            // 
            // colFileID
            // 
            this.colFileID.AppearanceCell.Options.UseTextOptions = true;
            this.colFileID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFileID.AppearanceHeader.Options.UseTextOptions = true;
            this.colFileID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFileID.Caption = "ش.پرونده";
            this.colFileID.FieldName = "FileID";
            this.colFileID.Name = "colFileID";
            this.colFileID.OptionsColumn.AllowEdit = false;
            this.colFileID.OptionsColumn.FixedWidth = true;
            this.colFileID.OptionsColumn.ReadOnly = true;
            this.colFileID.OptionsFilter.AllowFilter = false;
            this.colFileID.Visible = true;
            this.colFileID.VisibleIndex = 11;
            this.colFileID.Width = 65;
            // 
            // pnlSearch
            // 
            this.pnlSearch.ColumnCount = 5;
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlSearch.Controls.Add(this.btnRefresh, 3, 0);
            this.pnlSearch.Controls.Add(this.txtSearch, 0, 0);
            this.pnlSearch.Controls.Add(this.btnSearch, 2, 0);
            this.pnlSearch.Controls.Add(this.cboSearchType, 1, 0);
            this.pnlSearch.Controls.Add(this.btnExportToXlsx, 4, 0);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(2, 2);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(1);
            this.pnlSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlSearch.RowCount = 1;
            this.pnlSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.pnlSearch.Size = new System.Drawing.Size(886, 29);
            this.pnlSearch.TabIndex = 11;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(30, 2);
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
            this.btnExportToXlsx.Size = new System.Drawing.Size(26, 26);
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
            this.pnlMain.Size = new System.Drawing.Size(890, 450);
            this.pnlMain.TabIndex = 12;
            // 
            // frmCirculationLoanFiles
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 450);
            this.Controls.Add(this.pnlMain);
            this.HelpButton = true;
            this.Name = "frmCirculationLoanFiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گردش پرونده های اعتباری";
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSearchType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorybtnShowLog)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colbtnShowLog;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositorybtnShowLog;
        private DevExpress.XtraGrid.Columns.GridColumn colModifiedDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colRequestStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colRequestType;
        private DevExpress.XtraGrid.Columns.GridColumn colBranchName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colFacilityName;
        private DevExpress.XtraGrid.Columns.GridColumn colRequestAmount;
        private DevExpress.XtraEditors.ButtonEdit txtSearch;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraGrid.Columns.GridColumn colRequestId;
        public DevExpress.XtraEditors.ComboBoxEdit cboSearchType;
        private DevExpress.XtraGrid.Columns.GridColumn colFileID;
        private DevExpress.XtraGrid.Columns.GridColumn colCreditCommittee;
        private DevExpress.XtraGrid.Columns.GridColumn colExpertName;
        private System.Windows.Forms.TableLayoutPanel pnlSearch;
        private DevExpress.XtraEditors.SimpleButton btnExportToXlsx;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        public DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraGrid.Columns.GridColumn colRequestID;
    }
}