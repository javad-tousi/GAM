namespace GAM.Forms.Reports.Hoghoghi
{
    partial class frmLegalExpertsPerformance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLegalExpertsPerformance));
            this.pnlSearch = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDate1 = new System.Windows.Forms.Label();
            this.txtFromDate = new Atf.UI.DateTimeSelector();
            this.lblDate2 = new System.Windows.Forms.Label();
            this.txtToDate = new Atf.UI.DateTimeSelector();
            this.label1 = new System.Windows.Forms.Label();
            this.cboReportType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnShowQuery = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colExpertID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colExpertName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colLevel1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colLevel2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colLevel3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colLevel4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colLevel5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colLevel6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colLevel7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colLevel8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colLevel9 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colLevel10 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colLevel11 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colLevel12 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colLevel13 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colLevel14 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colLevel15 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colLevel16 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colLevel17 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colLevel18 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTotal = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.pnlBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExportToXlsx = new DevExpress.XtraEditors.SimpleButton();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboReportType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.lblDate1);
            this.pnlSearch.Controls.Add(this.txtFromDate);
            this.pnlSearch.Controls.Add(this.lblDate2);
            this.pnlSearch.Controls.Add(this.txtToDate);
            this.pnlSearch.Controls.Add(this.label1);
            this.pnlSearch.Controls.Add(this.cboReportType);
            this.pnlSearch.Controls.Add(this.btnShowQuery);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(1);
            this.pnlSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlSearch.Size = new System.Drawing.Size(823, 28);
            this.pnlSearch.TabIndex = 2;
            // 
            // lblDate1
            // 
            this.lblDate1.AutoSize = true;
            this.lblDate1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblDate1.Location = new System.Drawing.Point(781, 8);
            this.lblDate1.Margin = new System.Windows.Forms.Padding(2, 7, 3, 0);
            this.lblDate1.Name = "lblDate1";
            this.lblDate1.Size = new System.Drawing.Size(38, 13);
            this.lblDate1.TabIndex = 185;
            this.lblDate1.Text = "از تاریخ";
            // 
            // txtFromDate
            // 
            this.txtFromDate.CustomFormat = "dd/MM/yyyy";
            this.txtFromDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromDate.Format = Atf.UI.DateTimeSelectorFormat.Custom;
            this.txtFromDate.Location = new System.Drawing.Point(665, 2);
            this.txtFromDate.Margin = new System.Windows.Forms.Padding(1);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFromDate.Size = new System.Drawing.Size(112, 24);
            this.txtFromDate.TabIndex = 1;
            this.txtFromDate.UsePersianFormat = true;
            // 
            // lblDate2
            // 
            this.lblDate2.AutoSize = true;
            this.lblDate2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblDate2.Location = new System.Drawing.Point(624, 8);
            this.lblDate2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.lblDate2.Name = "lblDate2";
            this.lblDate2.Size = new System.Drawing.Size(37, 13);
            this.lblDate2.TabIndex = 187;
            this.lblDate2.Text = "تا تاریخ";
            // 
            // txtToDate
            // 
            this.txtToDate.CustomFormat = "dd/MM/yyyy";
            this.txtToDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToDate.Format = Atf.UI.DateTimeSelectorFormat.Custom;
            this.txtToDate.Location = new System.Drawing.Point(508, 2);
            this.txtToDate.Margin = new System.Windows.Forms.Padding(1);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtToDate.Size = new System.Drawing.Size(112, 24);
            this.txtToDate.TabIndex = 2;
            this.txtToDate.UsePersianFormat = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(433, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 189;
            this.label1.Text = "وضعیت پرونده";
            // 
            // cboReportType
            // 
            this.cboReportType.EditValue = "اقدام شده";
            this.cboReportType.Location = new System.Drawing.Point(312, 2);
            this.cboReportType.Margin = new System.Windows.Forms.Padding(1);
            this.cboReportType.Name = "cboReportType";
            this.cboReportType.Properties.AllowMouseWheel = false;
            this.cboReportType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReportType.Properties.Appearance.Options.UseFont = true;
            this.cboReportType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.cboReportType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboReportType.Properties.AutoComplete = false;
            this.cboReportType.Properties.AutoHeight = false;
            this.cboReportType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.cboReportType.Properties.Items.AddRange(new object[] {
            "اقدام شده",
            "درحال بررسی",
            "متوقف شده",
            "عودت شده",
            "کل پرونده ها",
            "پرونده های زرد",
            "پرونده های قرمز"});
            this.cboReportType.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboReportType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboReportType.Size = new System.Drawing.Size(117, 24);
            this.cboReportType.TabIndex = 188;
            this.cboReportType.TabStop = false;
            // 
            // btnShowQuery
            // 
            this.btnShowQuery.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnShowQuery.ImageOptions.Image")));
            this.btnShowQuery.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnShowQuery.Location = new System.Drawing.Point(200, 2);
            this.btnShowQuery.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnShowQuery.Margin = new System.Windows.Forms.Padding(1);
            this.btnShowQuery.Name = "btnShowQuery";
            this.btnShowQuery.Size = new System.Drawing.Size(110, 24);
            this.btnShowQuery.TabIndex = 3;
            this.btnShowQuery.Text = "نمایش اطلاعات";
            this.btnShowQuery.Click += new System.EventHandler(this.btnShowQuery_Click);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 28);
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl.Size = new System.Drawing.Size(823, 353);
            this.gridControl.TabIndex = 4;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2,
            this.gridBand1});
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colExpertID,
            this.colExpertName,
            this.colLevel1,
            this.colLevel2,
            this.colLevel3,
            this.colLevel4,
            this.colLevel5,
            this.colLevel6,
            this.colLevel7,
            this.colLevel8,
            this.colLevel9,
            this.colLevel10,
            this.colLevel11,
            this.colLevel12,
            this.colLevel13,
            this.colLevel14,
            this.colLevel15,
            this.colLevel16,
            this.colLevel17,
            this.colLevel18,
            this.colTotal});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.RowHeight = 22;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "مشخصات کارشناس";
            this.gridBand2.Columns.Add(this.colExpertID);
            this.gridBand2.Columns.Add(this.colExpertName);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 0;
            this.gridBand2.Width = 214;
            // 
            // colExpertID
            // 
            this.colExpertID.AppearanceCell.Options.UseTextOptions = true;
            this.colExpertID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colExpertID.AppearanceHeader.Options.UseTextOptions = true;
            this.colExpertID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colExpertID.Caption = "ش.کارمندی";
            this.colExpertID.FieldName = "ExpertID";
            this.colExpertID.Name = "colExpertID";
            this.colExpertID.OptionsColumn.AllowEdit = false;
            this.colExpertID.OptionsColumn.FixedWidth = true;
            this.colExpertID.OptionsColumn.ReadOnly = true;
            this.colExpertID.OptionsFilter.AllowFilter = false;
            this.colExpertID.Visible = true;
            this.colExpertID.Width = 64;
            // 
            // colExpertName
            // 
            this.colExpertName.AppearanceHeader.Options.UseTextOptions = true;
            this.colExpertName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colExpertName.Caption = "نام و نام خانوادگی";
            this.colExpertName.FieldName = "ExpertName";
            this.colExpertName.Image = ((System.Drawing.Image)(resources.GetObject("colExpertName.Image")));
            this.colExpertName.Name = "colExpertName";
            this.colExpertName.OptionsColumn.AllowEdit = false;
            this.colExpertName.OptionsColumn.FixedWidth = true;
            this.colExpertName.OptionsColumn.ReadOnly = true;
            this.colExpertName.OptionsFilter.AllowFilter = false;
            this.colExpertName.Visible = true;
            this.colExpertName.Width = 150;
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "مراحل قانونی";
            this.gridBand1.Columns.Add(this.colLevel1);
            this.gridBand1.Columns.Add(this.colLevel2);
            this.gridBand1.Columns.Add(this.colLevel3);
            this.gridBand1.Columns.Add(this.colLevel4);
            this.gridBand1.Columns.Add(this.colLevel5);
            this.gridBand1.Columns.Add(this.colLevel6);
            this.gridBand1.Columns.Add(this.colLevel7);
            this.gridBand1.Columns.Add(this.colLevel8);
            this.gridBand1.Columns.Add(this.colLevel9);
            this.gridBand1.Columns.Add(this.colLevel10);
            this.gridBand1.Columns.Add(this.colLevel11);
            this.gridBand1.Columns.Add(this.colLevel12);
            this.gridBand1.Columns.Add(this.colLevel13);
            this.gridBand1.Columns.Add(this.colLevel14);
            this.gridBand1.Columns.Add(this.colLevel15);
            this.gridBand1.Columns.Add(this.colLevel16);
            this.gridBand1.Columns.Add(this.colLevel17);
            this.gridBand1.Columns.Add(this.colLevel18);
            this.gridBand1.Columns.Add(this.colTotal);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 1;
            this.gridBand1.Width = 536;
            // 
            // colLevel1
            // 
            this.colLevel1.AppearanceCell.Options.UseTextOptions = true;
            this.colLevel1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel1.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevel1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel1.Caption = "1";
            this.colLevel1.FieldName = "Level1";
            this.colLevel1.Name = "colLevel1";
            this.colLevel1.OptionsColumn.AllowEdit = false;
            this.colLevel1.OptionsColumn.FixedWidth = true;
            this.colLevel1.OptionsColumn.ReadOnly = true;
            this.colLevel1.OptionsFilter.AllowFilter = false;
            this.colLevel1.ToolTip = "بررسی مدارک و مستندات";
            this.colLevel1.Visible = true;
            this.colLevel1.Width = 27;
            // 
            // colLevel2
            // 
            this.colLevel2.AppearanceCell.Options.UseTextOptions = true;
            this.colLevel2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel2.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevel2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel2.Caption = "2";
            this.colLevel2.FieldName = "Level2";
            this.colLevel2.Name = "colLevel2";
            this.colLevel2.OptionsColumn.AllowEdit = false;
            this.colLevel2.OptionsColumn.FixedWidth = true;
            this.colLevel2.OptionsColumn.ReadOnly = true;
            this.colLevel2.OptionsFilter.AllowFilter = false;
            this.colLevel2.ToolTip = "تشکیل پرونده در اداره حقوقی";
            this.colLevel2.Visible = true;
            this.colLevel2.Width = 27;
            // 
            // colLevel3
            // 
            this.colLevel3.AppearanceCell.Options.UseTextOptions = true;
            this.colLevel3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel3.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevel3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel3.Caption = "3";
            this.colLevel3.FieldName = "Level3";
            this.colLevel3.Name = "colLevel3";
            this.colLevel3.OptionsColumn.AllowEdit = false;
            this.colLevel3.OptionsColumn.FixedWidth = true;
            this.colLevel3.OptionsColumn.ReadOnly = true;
            this.colLevel3.OptionsFilter.AllowFilter = false;
            this.colLevel3.ToolTip = "تقاضای صدور اجرائیه از دفترخانه";
            this.colLevel3.Visible = true;
            this.colLevel3.Width = 27;
            // 
            // colLevel4
            // 
            this.colLevel4.AppearanceCell.Options.UseTextOptions = true;
            this.colLevel4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel4.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevel4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel4.Caption = "4";
            this.colLevel4.FieldName = "Level4";
            this.colLevel4.Name = "colLevel4";
            this.colLevel4.OptionsColumn.AllowEdit = false;
            this.colLevel4.OptionsColumn.FixedWidth = true;
            this.colLevel4.OptionsColumn.ReadOnly = true;
            this.colLevel4.OptionsFilter.AllowFilter = false;
            this.colLevel4.ToolTip = "صدور اجرائیه توسط دفترخانه";
            this.colLevel4.Visible = true;
            this.colLevel4.Width = 27;
            // 
            // colLevel5
            // 
            this.colLevel5.AppearanceCell.Options.UseTextOptions = true;
            this.colLevel5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel5.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevel5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel5.Caption = "5";
            this.colLevel5.FieldName = "Level5";
            this.colLevel5.Name = "colLevel5";
            this.colLevel5.OptionsColumn.AllowEdit = false;
            this.colLevel5.OptionsColumn.FixedWidth = true;
            this.colLevel5.OptionsColumn.ReadOnly = true;
            this.colLevel5.OptionsFilter.AllowFilter = false;
            this.colLevel5.ToolTip = "تشکیل پرونده در سازمان ثبت و املاک";
            this.colLevel5.Visible = true;
            this.colLevel5.Width = 27;
            // 
            // colLevel6
            // 
            this.colLevel6.AppearanceCell.Options.UseTextOptions = true;
            this.colLevel6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel6.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevel6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel6.Caption = "6";
            this.colLevel6.FieldName = "Level6";
            this.colLevel6.Name = "colLevel6";
            this.colLevel6.OptionsColumn.AllowEdit = false;
            this.colLevel6.OptionsColumn.FixedWidth = true;
            this.colLevel6.OptionsColumn.ReadOnly = true;
            this.colLevel6.OptionsFilter.AllowFilter = false;
            this.colLevel6.ToolTip = "اخذ کلاسه اجرائی از سازمان ثبت و املاک";
            this.colLevel6.Visible = true;
            this.colLevel6.Width = 27;
            // 
            // colLevel7
            // 
            this.colLevel7.AppearanceCell.Options.UseTextOptions = true;
            this.colLevel7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel7.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevel7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel7.Caption = "7";
            this.colLevel7.FieldName = "Level7";
            this.colLevel7.Name = "colLevel7";
            this.colLevel7.OptionsColumn.AllowEdit = false;
            this.colLevel7.OptionsColumn.FixedWidth = true;
            this.colLevel7.OptionsColumn.ReadOnly = true;
            this.colLevel7.OptionsFilter.AllowFilter = false;
            this.colLevel7.ToolTip = "ابلاغ اجرائیه به مدیونین توسط سازمان ثبت و املاک";
            this.colLevel7.Visible = true;
            this.colLevel7.Width = 27;
            // 
            // colLevel8
            // 
            this.colLevel8.AppearanceCell.Options.UseTextOptions = true;
            this.colLevel8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel8.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevel8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel8.Caption = "8";
            this.colLevel8.FieldName = "Level8";
            this.colLevel8.Name = "colLevel8";
            this.colLevel8.OptionsColumn.AllowEdit = false;
            this.colLevel8.OptionsColumn.FixedWidth = true;
            this.colLevel8.OptionsColumn.ReadOnly = true;
            this.colLevel8.OptionsFilter.AllowFilter = false;
            this.colLevel8.ToolTip = "اخذ استعلام جریان ثبتی سازمان ثبت و املاک";
            this.colLevel8.Visible = true;
            this.colLevel8.Width = 27;
            // 
            // colLevel9
            // 
            this.colLevel9.AppearanceCell.Options.UseTextOptions = true;
            this.colLevel9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel9.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevel9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel9.Caption = "9";
            this.colLevel9.FieldName = "Level9";
            this.colLevel9.Name = "colLevel9";
            this.colLevel9.OptionsColumn.AllowEdit = false;
            this.colLevel9.OptionsColumn.FixedWidth = true;
            this.colLevel9.OptionsColumn.ReadOnly = true;
            this.colLevel9.OptionsFilter.AllowFilter = false;
            this.colLevel9.ToolTip = "کارشناسی و ارزیابی ملک توسط کارشناس";
            this.colLevel9.Visible = true;
            this.colLevel9.Width = 27;
            // 
            // colLevel10
            // 
            this.colLevel10.AppearanceCell.Options.UseTextOptions = true;
            this.colLevel10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel10.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevel10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel10.Caption = "10";
            this.colLevel10.FieldName = "Level10";
            this.colLevel10.Name = "colLevel10";
            this.colLevel10.OptionsColumn.AllowEdit = false;
            this.colLevel10.OptionsColumn.FixedWidth = true;
            this.colLevel10.OptionsColumn.ReadOnly = true;
            this.colLevel10.OptionsFilter.AllowFilter = false;
            this.colLevel10.ToolTip = "اخذ مجوز فک قفل - عدم همکاری مدیون از انجام کارشناسی";
            this.colLevel10.Visible = true;
            this.colLevel10.Width = 27;
            // 
            // colLevel11
            // 
            this.colLevel11.AppearanceCell.Options.UseTextOptions = true;
            this.colLevel11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel11.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevel11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel11.Caption = "11";
            this.colLevel11.FieldName = "Level11";
            this.colLevel11.Name = "colLevel11";
            this.colLevel11.OptionsColumn.AllowEdit = false;
            this.colLevel11.OptionsColumn.FixedWidth = true;
            this.colLevel11.OptionsColumn.ReadOnly = true;
            this.colLevel11.OptionsFilter.AllowFilter = false;
            this.colLevel11.ToolTip = "کارشناسی دوم - اعتراض بانک یا مشتری از انجام کارشناسی";
            this.colLevel11.Visible = true;
            this.colLevel11.Width = 27;
            // 
            // colLevel12
            // 
            this.colLevel12.AppearanceCell.Options.UseTextOptions = true;
            this.colLevel12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel12.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevel12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel12.Caption = "12";
            this.colLevel12.FieldName = "Level12";
            this.colLevel12.Name = "colLevel12";
            this.colLevel12.OptionsColumn.AllowEdit = false;
            this.colLevel12.OptionsColumn.FixedWidth = true;
            this.colLevel12.OptionsColumn.ReadOnly = true;
            this.colLevel12.OptionsFilter.AllowFilter = false;
            this.colLevel12.ToolTip = "کارشناسی سوم - اعتراض بانک یا مشتری از انجام کارشناسی";
            this.colLevel12.Visible = true;
            this.colLevel12.Width = 27;
            // 
            // colLevel13
            // 
            this.colLevel13.AppearanceCell.Options.UseTextOptions = true;
            this.colLevel13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel13.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevel13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel13.Caption = "13";
            this.colLevel13.FieldName = "Level13";
            this.colLevel13.Name = "colLevel13";
            this.colLevel13.OptionsColumn.AllowEdit = false;
            this.colLevel13.OptionsColumn.FixedWidth = true;
            this.colLevel13.OptionsColumn.ReadOnly = true;
            this.colLevel13.OptionsFilter.AllowFilter = false;
            this.colLevel13.ToolTip = "اخذ آگهی مزایده و انتشار آن";
            this.colLevel13.Visible = true;
            this.colLevel13.Width = 27;
            // 
            // colLevel14
            // 
            this.colLevel14.AppearanceCell.Options.UseTextOptions = true;
            this.colLevel14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel14.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevel14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel14.Caption = "14";
            this.colLevel14.FieldName = "Level14";
            this.colLevel14.Name = "colLevel14";
            this.colLevel14.OptionsColumn.AllowEdit = false;
            this.colLevel14.OptionsColumn.FixedWidth = true;
            this.colLevel14.OptionsColumn.ReadOnly = true;
            this.colLevel14.OptionsFilter.AllowFilter = false;
            this.colLevel14.ToolTip = "اخذ کمیسیون معاملات بانک جهت برگزاری مزایده";
            this.colLevel14.Visible = true;
            this.colLevel14.Width = 27;
            // 
            // colLevel15
            // 
            this.colLevel15.AppearanceCell.Options.UseTextOptions = true;
            this.colLevel15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel15.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevel15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel15.Caption = "15";
            this.colLevel15.FieldName = "Level15";
            this.colLevel15.Name = "colLevel15";
            this.colLevel15.OptionsColumn.AllowEdit = false;
            this.colLevel15.OptionsColumn.FixedWidth = true;
            this.colLevel15.OptionsColumn.ReadOnly = true;
            this.colLevel15.OptionsFilter.AllowFilter = false;
            this.colLevel15.ToolTip = "پیش نویس سند انتقال اجرائی";
            this.colLevel15.Visible = true;
            this.colLevel15.Width = 27;
            // 
            // colLevel16
            // 
            this.colLevel16.AppearanceCell.Options.UseTextOptions = true;
            this.colLevel16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel16.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevel16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel16.Caption = "16";
            this.colLevel16.FieldName = "Level16";
            this.colLevel16.Name = "colLevel16";
            this.colLevel16.OptionsColumn.AllowEdit = false;
            this.colLevel16.OptionsColumn.FixedWidth = true;
            this.colLevel16.OptionsColumn.ReadOnly = true;
            this.colLevel16.OptionsFilter.AllowFilter = false;
            this.colLevel16.ToolTip = "اخذ سند انتقال اجرائی";
            this.colLevel16.Visible = true;
            this.colLevel16.Width = 27;
            // 
            // colLevel17
            // 
            this.colLevel17.AppearanceCell.Options.UseTextOptions = true;
            this.colLevel17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel17.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevel17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel17.Caption = "17";
            this.colLevel17.FieldName = "Level17";
            this.colLevel17.Name = "colLevel17";
            this.colLevel17.OptionsColumn.AllowEdit = false;
            this.colLevel17.OptionsColumn.FixedWidth = true;
            this.colLevel17.OptionsColumn.ReadOnly = true;
            this.colLevel17.OptionsFilter.AllowFilter = false;
            this.colLevel17.ToolTip = "اخذ سند مالکیت تک برگی";
            this.colLevel17.Visible = true;
            this.colLevel17.Width = 27;
            // 
            // colLevel18
            // 
            this.colLevel18.AppearanceCell.Options.UseTextOptions = true;
            this.colLevel18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel18.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevel18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel18.Caption = "18";
            this.colLevel18.FieldName = "Level18";
            this.colLevel18.Name = "colLevel18";
            this.colLevel18.OptionsColumn.AllowEdit = false;
            this.colLevel18.OptionsColumn.ReadOnly = true;
            this.colLevel18.OptionsFilter.AllowFilter = false;
            this.colLevel18.ToolTip = "اخذ سند تسویه از اداره امور مالی";
            this.colLevel18.Visible = true;
            this.colLevel18.Width = 27;
            // 
            // colTotal
            // 
            this.colTotal.AppearanceCell.BackColor = System.Drawing.SystemColors.Info;
            this.colTotal.AppearanceCell.Options.UseBackColor = true;
            this.colTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotal.Caption = "جمع";
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.OptionsColumn.FixedWidth = true;
            this.colTotal.OptionsColumn.ReadOnly = true;
            this.colTotal.OptionsFilter.AllowFilter = false;
            this.colTotal.Visible = true;
            this.colTotal.Width = 50;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExportToXlsx);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 381);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlBottom.Size = new System.Drawing.Size(823, 33);
            this.pnlBottom.TabIndex = 201;
            this.pnlBottom.Text = "flowLayoutPanel1";
            // 
            // btnExportToXlsx
            // 
            this.btnExportToXlsx.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToXlsx.ImageOptions.Image")));
            this.btnExportToXlsx.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnExportToXlsx.Location = new System.Drawing.Point(700, 3);
            this.btnExportToXlsx.Name = "btnExportToXlsx";
            this.btnExportToXlsx.Size = new System.Drawing.Size(120, 27);
            this.btnExportToXlsx.TabIndex = 5;
            this.btnExportToXlsx.Text = "خروجی اکسل";
            this.btnExportToXlsx.Click += new System.EventHandler(this.btnExportToXlsx_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.gridControl);
            this.pnlMain.Controls.Add(this.pnlSearch);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(823, 381);
            this.pnlMain.TabIndex = 202;
            // 
            // frmLegalExpertsPerformance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 414);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLegalExpertsPerformance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "عملکرد کارشناسان حقوقی";
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboReportType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlSearch;
        private System.Windows.Forms.Label lblDate1;
        private Atf.UI.DateTimeSelector txtFromDate;
        private System.Windows.Forms.Label lblDate2;
        private Atf.UI.DateTimeSelector txtToDate;
        private DevExpress.XtraEditors.SimpleButton btnShowQuery;
        private DevExpress.XtraGrid.GridControl gridControl;
        private System.Windows.Forms.FlowLayoutPanel pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnExportToXlsx;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gridView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colExpertID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colExpertName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLevel1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLevel2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLevel3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLevel4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLevel5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLevel6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLevel7;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLevel8;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLevel9;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLevel10;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLevel11;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLevel12;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLevel13;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLevel14;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLevel15;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLevel16;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLevel17;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTotal;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLevel18;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private System.Windows.Forms.Label label1;
        public DevExpress.XtraEditors.ComboBoxEdit cboReportType;
        public DevExpress.XtraEditors.PanelControl pnlMain;
    }
}