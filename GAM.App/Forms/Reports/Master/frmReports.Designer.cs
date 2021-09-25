namespace GAM.Forms.Reports.Master
{
    partial class frmReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReports));
            this.navBarControl = new DevExpress.XtraNavBar.NavBarControl();
            this.mnuReports = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.gridReports = new DevExpress.XtraGrid.GridControl();
            this.viewReports = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colReportName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlReports = new System.Windows.Forms.Panel();
            this.btnSortReports = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoadReports = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveReports = new DevExpress.XtraEditors.SimpleButton();
            this.btnResume = new DevExpress.XtraEditors.SimpleButton();
            this.btnMultiSelect = new DevExpress.XtraEditors.CheckButton();
            this.btnExportReports = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemoveReports = new DevExpress.XtraEditors.SimpleButton();
            this.btnNewReport = new DevExpress.XtraEditors.SimpleButton();
            this.checkButton = new DevExpress.XtraEditors.CheckButton();
            this.pnlCharts = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.mnuCharts = new DevExpress.XtraNavBar.NavBarGroup();
            this.tabReports = new DevExpress.XtraTab.XtraTabControl();
            this.progressBar = new DevExpress.XtraEditors.ProgressBarControl();
            this.pnlGrid = new DevExpress.XtraEditors.SplitContainerControl();
            this.tabControl = new DevExpress.XtraTab.XtraTabControl();
            this.tabPageNewReport = new DevExpress.XtraTab.XtraTabPage();
            this.tabPageReports = new DevExpress.XtraTab.XtraTabPage();
            this.pnlBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDeleteReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnRestartView = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportTables = new DevExpress.XtraEditors.SimpleButton();
            this.btnBranchInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnHelp = new DevExpress.XtraEditors.SimpleButton();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();
            this.navBarControl.SuspendLayout();
            this.navBarGroupControlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewReports)).BeginInit();
            this.pnlReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageReports.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // navBarControl
            // 
            this.navBarControl.ActiveGroup = this.mnuReports;
            this.navBarControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.navBarControl.Controls.Add(this.pnlCharts);
            this.navBarControl.Controls.Add(this.navBarGroupControlContainer);
            this.navBarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
            this.navBarControl.ExplorerBarShowGroupButtons = false;
            this.navBarControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.mnuReports,
            this.mnuCharts});
            this.navBarControl.Location = new System.Drawing.Point(0, 0);
            this.navBarControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.navBarControl.Name = "navBarControl";
            this.navBarControl.OptionsNavPane.ExpandedWidth = 187;
            this.navBarControl.OptionsNavPane.ShowExpandButton = false;
            this.navBarControl.OptionsNavPane.ShowOverflowButton = false;
            this.navBarControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.navBarControl.Size = new System.Drawing.Size(187, 497);
            this.navBarControl.SkinExplorerBarViewScrollStyle = DevExpress.XtraNavBar.SkinExplorerBarViewScrollStyle.ScrollBar;
            this.navBarControl.TabIndex = 11;
            this.navBarControl.Text = "navBarControl";
            this.navBarControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.navBarControl_MouseDoubleClick);
            this.navBarControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.navBarControl_MouseDown);
            // 
            // mnuReports
            // 
            this.mnuReports.Caption = "لیسـت گـزارشات";
            this.mnuReports.ControlContainer = this.navBarGroupControlContainer;
            this.mnuReports.Expanded = true;
            this.mnuReports.GroupClientHeight = 360;
            this.mnuReports.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.mnuReports.Name = "mnuReports";
            this.mnuReports.SmallImage = ((System.Drawing.Image)(resources.GetObject("mnuReports.SmallImage")));
            // 
            // navBarGroupControlContainer
            // 
            this.navBarGroupControlContainer.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer.Controls.Add(this.gridReports);
            this.navBarGroupControlContainer.Controls.Add(this.pnlReports);
            this.navBarGroupControlContainer.Controls.Add(this.checkButton);
            this.navBarGroupControlContainer.Name = "navBarGroupControlContainer";
            this.navBarGroupControlContainer.Size = new System.Drawing.Size(185, 360);
            this.navBarGroupControlContainer.TabIndex = 2;
            // 
            // gridReports
            // 
            this.gridReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridReports.Location = new System.Drawing.Point(0, 0);
            this.gridReports.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridReports.MainView = this.viewReports;
            this.gridReports.Name = "gridReports";
            this.gridReports.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridReports.Size = new System.Drawing.Size(185, 321);
            this.gridReports.TabIndex = 1;
            this.gridReports.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewReports});
            // 
            // viewReports
            // 
            this.viewReports.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colReportName});
            this.viewReports.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.viewReports.GridControl = this.gridReports;
            this.viewReports.Name = "viewReports";
            this.viewReports.OptionsSelection.CheckBoxSelectorColumnWidth = 23;
            this.viewReports.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.viewReports.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.viewReports.OptionsView.ShowGroupPanel = false;
            this.viewReports.OptionsView.ShowIndicator = false;
            this.viewReports.RowHeight = 23;
            this.viewReports.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.viewReports_FocusedRowChanged);
            this.viewReports.DoubleClick += new System.EventHandler(this.viewReports_DoubleClick);
            this.viewReports.RowCountChanged += new System.EventHandler(this.viewReports_RowCountChanged);
            // 
            // colReportName
            // 
            this.colReportName.AppearanceHeader.Options.UseTextOptions = true;
            this.colReportName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReportName.Caption = "نام گزارش";
            this.colReportName.FieldName = "ReportName";
            this.colReportName.Image = ((System.Drawing.Image)(resources.GetObject("colReportName.Image")));
            this.colReportName.Name = "colReportName";
            this.colReportName.OptionsColumn.AllowEdit = false;
            this.colReportName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colReportName.OptionsColumn.ReadOnly = true;
            this.colReportName.OptionsFilter.AllowFilter = false;
            this.colReportName.Visible = true;
            this.colReportName.VisibleIndex = 0;
            this.colReportName.Width = 151;
            // 
            // pnlReports
            // 
            this.pnlReports.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlReports.Controls.Add(this.btnSortReports);
            this.pnlReports.Controls.Add(this.btnLoadReports);
            this.pnlReports.Controls.Add(this.btnSaveReports);
            this.pnlReports.Controls.Add(this.btnResume);
            this.pnlReports.Controls.Add(this.btnMultiSelect);
            this.pnlReports.Controls.Add(this.btnExportReports);
            this.pnlReports.Controls.Add(this.btnRemoveReports);
            this.pnlReports.Controls.Add(this.btnNewReport);
            this.pnlReports.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlReports.Location = new System.Drawing.Point(0, 321);
            this.pnlReports.Margin = new System.Windows.Forms.Padding(0);
            this.pnlReports.Name = "pnlReports";
            this.pnlReports.Size = new System.Drawing.Size(185, 25);
            this.pnlReports.TabIndex = 3;
            // 
            // btnSortReports
            // 
            this.btnSortReports.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSortReports.Appearance.Options.UseFont = true;
            this.btnSortReports.Enabled = false;
            this.btnSortReports.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSortReports.ImageOptions.Image")));
            this.btnSortReports.Location = new System.Drawing.Point(1, 26);
            this.btnSortReports.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSortReports.Name = "btnSortReports";
            this.btnSortReports.Size = new System.Drawing.Size(60, 20);
            this.btnSortReports.TabIndex = 5;
            this.btnSortReports.Text = "تنظیمات";
            this.btnSortReports.Click += new System.EventHandler(this.btnSortReports_Click);
            // 
            // btnLoadReports
            // 
            this.btnLoadReports.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadReports.Appearance.Options.UseFont = true;
            this.btnLoadReports.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadReports.ImageOptions.Image")));
            this.btnLoadReports.Location = new System.Drawing.Point(62, 49);
            this.btnLoadReports.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnLoadReports.Name = "btnLoadReports";
            this.btnLoadReports.Size = new System.Drawing.Size(60, 20);
            this.btnLoadReports.TabIndex = 0;
            this.btnLoadReports.Text = "بارگذاری";
            this.btnLoadReports.Click += new System.EventHandler(this.btnLoadReports_Click);
            // 
            // btnSaveReports
            // 
            this.btnSaveReports.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveReports.Appearance.Options.UseFont = true;
            this.btnSaveReports.Enabled = false;
            this.btnSaveReports.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveReports.ImageOptions.Image")));
            this.btnSaveReports.Location = new System.Drawing.Point(123, 49);
            this.btnSaveReports.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSaveReports.Name = "btnSaveReports";
            this.btnSaveReports.Size = new System.Drawing.Size(60, 20);
            this.btnSaveReports.TabIndex = 3;
            this.btnSaveReports.Text = "ذخیره";
            this.btnSaveReports.Click += new System.EventHandler(this.btnSaveReports_Click);
            // 
            // btnResume
            // 
            this.btnResume.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResume.Appearance.Options.UseFont = true;
            this.btnResume.Enabled = false;
            this.btnResume.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnResume.ImageOptions.Image")));
            this.btnResume.Location = new System.Drawing.Point(62, 26);
            this.btnResume.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(60, 20);
            this.btnResume.TabIndex = 6;
            this.btnResume.Text = "کارنامه";
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnMultiSelect
            // 
            this.btnMultiSelect.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMultiSelect.Appearance.Options.UseFont = true;
            this.btnMultiSelect.Enabled = false;
            this.btnMultiSelect.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMultiSelect.ImageOptions.Image")));
            this.btnMultiSelect.Location = new System.Drawing.Point(123, 26);
            this.btnMultiSelect.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnMultiSelect.Name = "btnMultiSelect";
            this.btnMultiSelect.Size = new System.Drawing.Size(60, 20);
            this.btnMultiSelect.TabIndex = 8;
            this.btnMultiSelect.Text = "انتخاب";
            this.btnMultiSelect.CheckedChanged += new System.EventHandler(this.btnMultiSelect_CheckedChanged);
            // 
            // btnExportReports
            // 
            this.btnExportReports.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportReports.Appearance.Options.UseFont = true;
            this.btnExportReports.Enabled = false;
            this.btnExportReports.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportReports.ImageOptions.Image")));
            this.btnExportReports.Location = new System.Drawing.Point(1, 3);
            this.btnExportReports.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExportReports.Name = "btnExportReports";
            this.btnExportReports.Size = new System.Drawing.Size(60, 20);
            this.btnExportReports.TabIndex = 7;
            this.btnExportReports.Text = "Excel";
            this.btnExportReports.Click += new System.EventHandler(this.btnExportReports_Click);
            // 
            // btnRemoveReports
            // 
            this.btnRemoveReports.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveReports.Appearance.Options.UseFont = true;
            this.btnRemoveReports.Enabled = false;
            this.btnRemoveReports.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveReports.ImageOptions.Image")));
            this.btnRemoveReports.Location = new System.Drawing.Point(62, 3);
            this.btnRemoveReports.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRemoveReports.Name = "btnRemoveReports";
            this.btnRemoveReports.Size = new System.Drawing.Size(60, 20);
            this.btnRemoveReports.TabIndex = 2;
            this.btnRemoveReports.Text = "حذف";
            this.btnRemoveReports.Click += new System.EventHandler(this.btnRemoveReport_Click);
            // 
            // btnNewReport
            // 
            this.btnNewReport.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewReport.Appearance.Options.UseFont = true;
            this.btnNewReport.Enabled = false;
            this.btnNewReport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNewReport.ImageOptions.Image")));
            this.btnNewReport.Location = new System.Drawing.Point(123, 3);
            this.btnNewReport.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNewReport.Name = "btnNewReport";
            this.btnNewReport.Size = new System.Drawing.Size(60, 20);
            this.btnNewReport.TabIndex = 4;
            this.btnNewReport.Text = "افزودن";
            this.btnNewReport.Click += new System.EventHandler(this.btnNewReport_Click);
            // 
            // checkButton
            // 
            this.checkButton.Appearance.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.checkButton.Appearance.Options.UseFont = true;
            this.checkButton.Appearance.Options.UseTextOptions = true;
            this.checkButton.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.checkButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkButton.Location = new System.Drawing.Point(0, 346);
            this.checkButton.Name = "checkButton";
            this.checkButton.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.checkButton.Size = new System.Drawing.Size(185, 14);
            this.checkButton.TabIndex = 4;
            this.checkButton.Text = "";
            this.checkButton.CheckedChanged += new System.EventHandler(this.checkButton_CheckedChanged);
            // 
            // pnlCharts
            // 
            this.pnlCharts.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCharts.Appearance.Options.UseBackColor = true;
            this.pnlCharts.Name = "pnlCharts";
            this.pnlCharts.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pnlCharts.Size = new System.Drawing.Size(198, 331);
            this.pnlCharts.TabIndex = 1;
            // 
            // mnuCharts
            // 
            this.mnuCharts.Caption = "لیسـت نمـودارهـا";
            this.mnuCharts.ControlContainer = this.pnlCharts;
            this.mnuCharts.GroupClientHeight = 329;
            this.mnuCharts.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.mnuCharts.Name = "mnuCharts";
            this.mnuCharts.SmallImage = ((System.Drawing.Image)(resources.GetObject("mnuCharts.SmallImage")));
            // 
            // tabReports
            // 
            this.tabReports.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.tabReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabReports.Location = new System.Drawing.Point(0, 0);
            this.tabReports.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tabReports.MultiLine = DevExpress.Utils.DefaultBoolean.True;
            this.tabReports.Name = "tabReports";
            this.tabReports.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabReports.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.tabReports.Size = new System.Drawing.Size(633, 440);
            this.tabReports.TabIndex = 0;
            this.tabReports.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabReports_SelectedPageChanged);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 479);
            this.progressBar.Name = "progressBar";
            this.progressBar.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.progressBar.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.progressBar.Properties.ShowTitle = true;
            this.progressBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.progressBar.Size = new System.Drawing.Size(639, 18);
            this.progressBar.TabIndex = 1;
            this.progressBar.Visible = false;
            // 
            // pnlGrid
            // 
            this.pnlGrid.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.IsSplitterFixed = true;
            this.pnlGrid.Location = new System.Drawing.Point(2, 2);
            this.pnlGrid.LookAndFeel.SkinName = "Office 2013";
            this.pnlGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Panel1.Controls.Add(this.tabControl);
            this.pnlGrid.Panel1.Controls.Add(this.progressBar);
            this.pnlGrid.Panel1.Text = "Panel1";
            this.pnlGrid.Panel2.Controls.Add(this.navBarControl);
            this.pnlGrid.Panel2.MinSize = 187;
            this.pnlGrid.Panel2.Text = "Panel2";
            this.pnlGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pnlGrid.Size = new System.Drawing.Size(838, 497);
            this.pnlGrid.SplitterPosition = 644;
            this.pnlGrid.TabIndex = 8;
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tabControl.Name = "tabControl";
            this.tabControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl.SelectedTabPage = this.tabPageNewReport;
            this.tabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.tabControl.Size = new System.Drawing.Size(639, 479);
            this.tabControl.TabIndex = 3;
            this.tabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPageNewReport,
            this.tabPageReports});
            this.tabControl.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabControl_SelectedPageChanged);
            // 
            // tabPageNewReport
            // 
            this.tabPageNewReport.Name = "tabPageNewReport";
            this.tabPageNewReport.Size = new System.Drawing.Size(633, 473);
            this.tabPageNewReport.Text = "گزارش جدید";
            // 
            // tabPageReports
            // 
            this.tabPageReports.Controls.Add(this.tabReports);
            this.tabPageReports.Controls.Add(this.pnlBottom);
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.Size = new System.Drawing.Size(633, 473);
            this.tabPageReports.Text = "لیست گزارشات";
            // 
            // pnlBottom
            // 
            this.pnlBottom.AutoSize = true;
            this.pnlBottom.Controls.Add(this.btnEditReport);
            this.pnlBottom.Controls.Add(this.btnDeleteReport);
            this.pnlBottom.Controls.Add(this.btnRestartView);
            this.pnlBottom.Controls.Add(this.btnExportTables);
            this.pnlBottom.Controls.Add(this.btnBranchInfo);
            this.pnlBottom.Controls.Add(this.btnHelp);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 440);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlBottom.Size = new System.Drawing.Size(633, 33);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnDeleteReport
            // 
            this.btnDeleteReport.Enabled = false;
            this.btnDeleteReport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteReport.ImageOptions.Image")));
            this.btnDeleteReport.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnDeleteReport.Location = new System.Drawing.Point(454, 3);
            this.btnDeleteReport.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDeleteReport.Name = "btnDeleteReport";
            this.btnDeleteReport.Size = new System.Drawing.Size(85, 27);
            this.btnDeleteReport.TabIndex = 5;
            this.btnDeleteReport.Text = "حذف گزارش";
            this.btnDeleteReport.Click += new System.EventHandler(this.btnDeleteReport_ItemClick);
            // 
            // btnEditReport
            // 
            this.btnEditReport.Enabled = false;
            this.btnEditReport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEditReport.ImageOptions.Image")));
            this.btnEditReport.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnEditReport.Location = new System.Drawing.Point(545, 3);
            this.btnEditReport.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnEditReport.Name = "btnEditReport";
            this.btnEditReport.Size = new System.Drawing.Size(85, 27);
            this.btnEditReport.TabIndex = 4;
            this.btnEditReport.Text = "ویرایش";
            this.btnEditReport.Click += new System.EventHandler(this.btnEditReport_ItemClick);
            // 
            // btnRestartView
            // 
            this.btnRestartView.Enabled = false;
            this.btnRestartView.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRestartView.ImageOptions.Image")));
            this.btnRestartView.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnRestartView.Location = new System.Drawing.Point(363, 3);
            this.btnRestartView.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRestartView.Name = "btnRestartView";
            this.btnRestartView.Size = new System.Drawing.Size(85, 27);
            this.btnRestartView.TabIndex = 6;
            this.btnRestartView.Text = "بازنشانی";
            this.btnRestartView.Click += new System.EventHandler(this.btnRestartView_ItemClick);
            // 
            // btnExportTables
            // 
            this.btnExportTables.Enabled = false;
            this.btnExportTables.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportTables.ImageOptions.Image")));
            this.btnExportTables.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnExportTables.Location = new System.Drawing.Point(272, 3);
            this.btnExportTables.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExportTables.Name = "btnExportTables";
            this.btnExportTables.Size = new System.Drawing.Size(85, 27);
            this.btnExportTables.TabIndex = 11;
            this.btnExportTables.Text = "فایل اکسل";
            this.btnExportTables.Click += new System.EventHandler(this.btnExportTables_Click);
            // 
            // btnBranchInfo
            // 
            this.btnBranchInfo.Enabled = false;
            this.btnBranchInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBranchInfo.ImageOptions.Image")));
            this.btnBranchInfo.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnBranchInfo.Location = new System.Drawing.Point(181, 3);
            this.btnBranchInfo.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnBranchInfo.Name = "btnBranchInfo";
            this.btnBranchInfo.Size = new System.Drawing.Size(85, 27);
            this.btnBranchInfo.TabIndex = 13;
            this.btnBranchInfo.Text = "جزئیات واحد";
            this.btnBranchInfo.Click += new System.EventHandler(this.btnBranchInfo_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Enabled = false;
            this.btnHelp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.ImageOptions.Image")));
            this.btnHelp.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnHelp.Location = new System.Drawing.Point(151, 3);
            this.btnHelp.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(24, 27);
            this.btnHelp.TabIndex = 9;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_ItemClick);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlGrid);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlMain.Size = new System.Drawing.Size(842, 501);
            this.pnlMain.TabIndex = 13;
            this.pnlMain.Resize += new System.EventHandler(this.pnlMain_SizeChanged);
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 501);
            this.Controls.Add(this.pnlMain);
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارشات منابع، مصارف و مطالبات";
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).EndInit();
            this.navBarControl.ResumeLayout(false);
            this.navBarGroupControlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewReports)).EndInit();
            this.pnlReports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageReports.ResumeLayout(false);
            this.tabPageReports.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabReports;
        private DevExpress.XtraNavBar.NavBarControl navBarControl;
        private DevExpress.XtraNavBar.NavBarGroup mnuCharts;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer pnlCharts;
        private DevExpress.XtraEditors.ProgressBarControl progressBar;
        private DevExpress.XtraNavBar.NavBarGroup mnuReports;
        private DevExpress.XtraEditors.SplitContainerControl pnlGrid;
        public DevExpress.XtraEditors.PanelControl pnlMain;
        private System.Windows.Forms.FlowLayoutPanel pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnEditReport;
        private DevExpress.XtraEditors.SimpleButton btnDeleteReport;
        private DevExpress.XtraEditors.SimpleButton btnRestartView;
        private DevExpress.XtraEditors.SimpleButton btnHelp;
        private DevExpress.XtraEditors.SimpleButton btnExportTables;
        private DevExpress.XtraTab.XtraTabControl tabControl;
        private DevExpress.XtraTab.XtraTabPage tabPageNewReport;
        private DevExpress.XtraTab.XtraTabPage tabPageReports;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer;
        private DevExpress.XtraGrid.GridControl gridReports;
        private DevExpress.XtraGrid.Views.Grid.GridView viewReports;
        private DevExpress.XtraGrid.Columns.GridColumn colReportName;
        private DevExpress.XtraEditors.SimpleButton btnBranchInfo;
        private System.Windows.Forms.Panel pnlReports;
        private DevExpress.XtraEditors.SimpleButton btnSortReports;
        private DevExpress.XtraEditors.SimpleButton btnLoadReports;
        private DevExpress.XtraEditors.SimpleButton btnSaveReports;
        private DevExpress.XtraEditors.SimpleButton btnResume;
        private DevExpress.XtraEditors.SimpleButton btnExportReports;
        private DevExpress.XtraEditors.SimpleButton btnRemoveReports;
        private DevExpress.XtraEditors.SimpleButton btnNewReport;
        private DevExpress.XtraEditors.CheckButton btnMultiSelect;
        private DevExpress.XtraEditors.CheckButton checkButton;
    }
}