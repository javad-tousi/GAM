namespace GAM.Forms.Profile.Etebarat.TehranApprovals
{
    partial class frmTehranApprovals
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTehranApprovals));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlSearch = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearch = new DevExpress.XtraEditors.ButtonEdit();
            this.btnExportToXlsx = new DevExpress.XtraEditors.SimpleButton();
            this.cboRequestStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colbtnShowLog = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositorybtnLog = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colModifiedDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequestStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreditCommittee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequestId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequestType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBranchName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFacilityName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequestAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpertName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProvinceLetterNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProvinceLetterDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddToList = new DevExpress.XtraEditors.SimpleButton();
            this.btnSendToTehran = new DevExpress.XtraEditors.SimpleButton();
            this.btnReceiveFromTehran = new DevExpress.XtraEditors.SimpleButton();
            this.btnReturnToProvince = new DevExpress.XtraEditors.SimpleButton();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRequestStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorybtnLog)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.ColumnCount = 4;
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.btnExportToXlsx, 3, 0);
            this.pnlSearch.Controls.Add(this.cboRequestStatus, 1, 0);
            this.pnlSearch.Controls.Add(this.btnRefresh, 2, 0);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(1);
            this.pnlSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlSearch.RowCount = 1;
            this.pnlSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.pnlSearch.Size = new System.Drawing.Size(803, 29);
            this.pnlSearch.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.EditValue = "";
            this.txtSearch.Location = new System.Drawing.Point(171, 2);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(1, 1, 1, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Properties.Appearance.Options.UseFont = true;
            this.txtSearch.Properties.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.txtSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.txtSearch.Properties.NullValuePrompt = "نام متقاضی - شماره پیشنهاد شعبه";
            this.txtSearch.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtSearch.Size = new System.Drawing.Size(630, 27);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Tag = "";
            this.txtSearch.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtSearch_ButtonClick);
            this.txtSearch.EditValueChanged += new System.EventHandler(this.txtSearch_EditValueChanged);
            // 
            // btnExportToXlsx
            // 
            this.btnExportToXlsx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExportToXlsx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportToXlsx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportToXlsx.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToXlsx.ImageOptions.Image")));
            this.btnExportToXlsx.Location = new System.Drawing.Point(2, 2);
            this.btnExportToXlsx.Margin = new System.Windows.Forms.Padding(1, 1, 1, 6);
            this.btnExportToXlsx.Name = "btnExportToXlsx";
            this.btnExportToXlsx.Size = new System.Drawing.Size(26, 27);
            this.btnExportToXlsx.TabIndex = 2;
            this.btnExportToXlsx.TabStop = false;
            this.btnExportToXlsx.Click += new System.EventHandler(this.btnExportToXlsx_Click);
            // 
            // cboRequestStatus
            // 
            this.cboRequestStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboRequestStatus.Location = new System.Drawing.Point(56, 2);
            this.cboRequestStatus.Margin = new System.Windows.Forms.Padding(1, 1, 1, 6);
            this.cboRequestStatus.Name = "cboRequestStatus";
            this.cboRequestStatus.Properties.AllowMouseWheel = false;
            this.cboRequestStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRequestStatus.Properties.Appearance.Options.UseFont = true;
            this.cboRequestStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.cboRequestStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboRequestStatus.Properties.AutoComplete = false;
            this.cboRequestStatus.Properties.AutoHeight = false;
            this.cboRequestStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cboRequestStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboRequestStatus.Size = new System.Drawing.Size(113, 27);
            this.cboRequestStatus.TabIndex = 4;
            this.cboRequestStatus.TabStop = false;
            this.cboRequestStatus.SelectedIndexChanged += new System.EventHandler(this.cboRequestStatus_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(30, 2);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(1, 1, 1, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 27);
            this.btnRefresh.TabIndex = 27;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 29);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositorybtnLog});
            this.gridControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl.Size = new System.Drawing.Size(803, 389);
            this.gridControl.TabIndex = 13;
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
            this.colRequestId,
            this.colRequestType,
            this.colBranchName,
            this.colCustomerName,
            this.colFacilityName,
            this.colRequestAmount,
            this.colFileId,
            this.colExpertName,
            this.colProvinceLetterNo,
            this.colProvinceLetterDate});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsSelection.CheckBoxSelectorColumnWidth = 27;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView_RowClick);
            this.gridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
            // 
            // colbtnShowLog
            // 
            this.colbtnShowLog.AppearanceHeader.Options.UseTextOptions = true;
            this.colbtnShowLog.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colbtnShowLog.Caption = " ";
            this.colbtnShowLog.ColumnEdit = this.repositorybtnLog;
            this.colbtnShowLog.FieldName = "btnShowLog";
            this.colbtnShowLog.Name = "colbtnShowLog";
            this.colbtnShowLog.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.colbtnShowLog.OptionsFilter.AllowFilter = false;
            this.colbtnShowLog.Visible = true;
            this.colbtnShowLog.VisibleIndex = 0;
            this.colbtnShowLog.Width = 25;
            // 
            // repositorybtnLog
            // 
            this.repositorybtnLog.AutoHeight = false;
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.repositorybtnLog.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositorybtnLog.Name = "repositorybtnLog";
            this.repositorybtnLog.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositorybtnLog.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositorybtnLog_ButtonClick);
            // 
            // colModifiedDateTime
            // 
            this.colModifiedDateTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colModifiedDateTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colModifiedDateTime.Caption = "آخرین تغییرات";
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
            this.colRequestStatus.Caption = "وضعیت";
            this.colRequestStatus.FieldName = "RequestStatus";
            this.colRequestStatus.Name = "colRequestStatus";
            this.colRequestStatus.OptionsColumn.AllowEdit = false;
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
            this.colCreditCommittee.OptionsColumn.ReadOnly = true;
            this.colCreditCommittee.Visible = true;
            this.colCreditCommittee.VisibleIndex = 3;
            this.colCreditCommittee.Width = 100;
            // 
            // colRequestId
            // 
            this.colRequestId.AppearanceCell.Options.UseTextOptions = true;
            this.colRequestId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colRequestId.AppearanceHeader.Options.UseTextOptions = true;
            this.colRequestId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRequestId.Caption = "شماره پیشنهاد";
            this.colRequestId.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRequestId.FieldName = "RequestID";
            this.colRequestId.Name = "colRequestId";
            this.colRequestId.OptionsColumn.ReadOnly = true;
            this.colRequestId.Visible = true;
            this.colRequestId.VisibleIndex = 4;
            this.colRequestId.Width = 92;
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
            this.colRequestType.Visible = true;
            this.colRequestType.VisibleIndex = 5;
            this.colRequestType.Width = 80;
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
            this.colCustomerName.Width = 205;
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
            this.colRequestAmount.Width = 67;
            // 
            // colFileId
            // 
            this.colFileId.AppearanceCell.Options.UseTextOptions = true;
            this.colFileId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
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
            this.colFileId.VisibleIndex = 10;
            this.colFileId.Width = 65;
            // 
            // colExpertName
            // 
            this.colExpertName.AppearanceCell.Options.UseTextOptions = true;
            this.colExpertName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colExpertName.AppearanceHeader.Options.UseTextOptions = true;
            this.colExpertName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colExpertName.Caption = "کارشناس";
            this.colExpertName.Name = "colExpertName";
            this.colExpertName.OptionsColumn.AllowEdit = false;
            this.colExpertName.OptionsColumn.FixedWidth = true;
            this.colExpertName.OptionsColumn.ReadOnly = true;
            this.colExpertName.OptionsFilter.AllowFilter = false;
            this.colExpertName.Visible = true;
            this.colExpertName.VisibleIndex = 11;
            this.colExpertName.Width = 112;
            // 
            // colProvinceLetterNo
            // 
            this.colProvinceLetterNo.AppearanceCell.Options.UseTextOptions = true;
            this.colProvinceLetterNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProvinceLetterNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colProvinceLetterNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProvinceLetterNo.Caption = "شناسه نامه";
            this.colProvinceLetterNo.FieldName = "ProvinceLetterNo";
            this.colProvinceLetterNo.Name = "colProvinceLetterNo";
            this.colProvinceLetterNo.OptionsColumn.AllowEdit = false;
            this.colProvinceLetterNo.OptionsColumn.FixedWidth = true;
            this.colProvinceLetterNo.OptionsColumn.ReadOnly = true;
            this.colProvinceLetterNo.OptionsFilter.AllowFilter = false;
            this.colProvinceLetterNo.Visible = true;
            this.colProvinceLetterNo.VisibleIndex = 12;
            // 
            // colProvinceLetterDate
            // 
            this.colProvinceLetterDate.AppearanceCell.Options.UseTextOptions = true;
            this.colProvinceLetterDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProvinceLetterDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colProvinceLetterDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProvinceLetterDate.Caption = "تاریخ ارسال";
            this.colProvinceLetterDate.DisplayFormat.FormatString = "0000/00/00";
            this.colProvinceLetterDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colProvinceLetterDate.FieldName = "ProvinceLetterDate";
            this.colProvinceLetterDate.Name = "colProvinceLetterDate";
            this.colProvinceLetterDate.OptionsColumn.AllowEdit = false;
            this.colProvinceLetterDate.OptionsColumn.FixedWidth = true;
            this.colProvinceLetterDate.OptionsColumn.ReadOnly = true;
            this.colProvinceLetterDate.OptionsFilter.AllowFilter = false;
            this.colProvinceLetterDate.Visible = true;
            this.colProvinceLetterDate.VisibleIndex = 13;
            this.colProvinceLetterDate.Width = 74;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnAddToList);
            this.pnlBottom.Controls.Add(this.btnSendToTehran);
            this.pnlBottom.Controls.Add(this.btnReceiveFromTehran);
            this.pnlBottom.Controls.Add(this.btnReturnToProvince);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 418);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlBottom.Size = new System.Drawing.Size(803, 32);
            this.pnlBottom.TabIndex = 202;
            this.pnlBottom.Text = "flowLayoutPanel1";
            // 
            // btnAddToList
            // 
            this.btnAddToList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddToList.ImageOptions.Image")));
            this.btnAddToList.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnAddToList.Location = new System.Drawing.Point(620, 3);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(180, 27);
            this.btnAddToList.TabIndex = 6;
            this.btnAddToList.Text = "افزودن پیشنهاد استان به لیست";
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // btnSendToTehran
            // 
            this.btnSendToTehran.Enabled = false;
            this.btnSendToTehran.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSendToTehran.ImageOptions.Image")));
            this.btnSendToTehran.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnSendToTehran.Location = new System.Drawing.Point(455, 3);
            this.btnSendToTehran.Name = "btnSendToTehran";
            this.btnSendToTehran.Size = new System.Drawing.Size(159, 27);
            this.btnSendToTehran.TabIndex = 7;
            this.btnSendToTehran.Text = "ارسال به اداره کل اعتبارات";
            this.btnSendToTehran.Click += new System.EventHandler(this.btnSendToTehran_Click);
            // 
            // btnReceiveFromTehran
            // 
            this.btnReceiveFromTehran.Enabled = false;
            this.btnReceiveFromTehran.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReceiveFromTehran.ImageOptions.Image")));
            this.btnReceiveFromTehran.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnReceiveFromTehran.Location = new System.Drawing.Point(276, 3);
            this.btnReceiveFromTehran.Name = "btnReceiveFromTehran";
            this.btnReceiveFromTehran.Size = new System.Drawing.Size(173, 27);
            this.btnReceiveFromTehran.TabIndex = 9;
            this.btnReceiveFromTehran.Text = "پاسخ نهایی اداره کل اعتبارات";
            this.btnReceiveFromTehran.Click += new System.EventHandler(this.btnReceiveFromTehran_Click);
            // 
            // btnReturnToProvince
            // 
            this.btnReturnToProvince.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReturnToProvince.ImageOptions.Image")));
            this.btnReturnToProvince.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnReturnToProvince.Location = new System.Drawing.Point(50, 3);
            this.btnReturnToProvince.Name = "btnReturnToProvince";
            this.btnReturnToProvince.Size = new System.Drawing.Size(220, 27);
            this.btnReturnToProvince.TabIndex = 8;
            this.btnReturnToProvince.Text = "برگشت پیشنهاد به کمیته اعتباری استان";
            this.btnReturnToProvince.Click += new System.EventHandler(this.btnReturnToProvince_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.gridControl);
            this.pnlMain.Controls.Add(this.pnlBottom);
            this.pnlMain.Controls.Add(this.pnlSearch);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(803, 450);
            this.pnlMain.TabIndex = 203;
            // 
            // frmTehranApprovals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 450);
            this.Controls.Add(this.pnlMain);
            this.Name = "frmTehranApprovals";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "پیشنهادات مدیریت شعب";
            this.pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRequestStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorybtnLog)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlSearch;
        private DevExpress.XtraEditors.ButtonEdit txtSearch;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colbtnShowLog;
        private DevExpress.XtraGrid.Columns.GridColumn colModifiedDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colRequestStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colCreditCommittee;
        private DevExpress.XtraGrid.Columns.GridColumn colRequestId;
        private DevExpress.XtraGrid.Columns.GridColumn colRequestType;
        private DevExpress.XtraGrid.Columns.GridColumn colBranchName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colFacilityName;
        private DevExpress.XtraGrid.Columns.GridColumn colRequestAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colFileId;
        private DevExpress.XtraGrid.Columns.GridColumn colExpertName;
        private DevExpress.XtraGrid.Columns.GridColumn colProvinceLetterDate;
        private DevExpress.XtraGrid.Columns.GridColumn colProvinceLetterNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositorybtnLog;
        private DevExpress.XtraEditors.SimpleButton btnExportToXlsx;
        private System.Windows.Forms.FlowLayoutPanel pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnAddToList;
        private DevExpress.XtraEditors.SimpleButton btnSendToTehran;
        private DevExpress.XtraEditors.SimpleButton btnReturnToProvince;
        private DevExpress.XtraEditors.SimpleButton btnReceiveFromTehran;
        public DevExpress.XtraEditors.ComboBoxEdit cboRequestStatus;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        public DevExpress.XtraEditors.PanelControl pnlMain;
    }
}