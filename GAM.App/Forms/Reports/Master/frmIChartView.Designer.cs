namespace GAM.Forms.Reports.Master
{
    partial class frmIChartView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIChartView));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.RectangleGradientFillOptions rectangleGradientFillOptions1 = new DevExpress.XtraCharts.RectangleGradientFillOptions();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            this.pnlGrid = new DevExpress.XtraEditors.SplitContainerControl();
            this.tabControl = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.lblReportName = new System.Windows.Forms.Label();
            this.progressBar = new DevExpress.XtraEditors.ProgressBarControl();
            this.navBarControl = new DevExpress.XtraNavBar.NavBarControl();
            this.mnuBranches = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.treeBranches = new System.Windows.Forms.TreeView();
            this.txtSearch = new DevExpress.XtraEditors.TextEdit();
            this.pnlCharts = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.radioGroup = new DevExpress.XtraEditors.RadioGroup();
            this.mnuChartTypes = new DevExpress.XtraNavBar.NavBarGroup();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnSubmitQuery = new DevExpress.XtraEditors.SimpleButton();
            this.chartControl = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();
            this.navBarControl.SuspendLayout();
            this.navBarGroupControlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            this.pnlCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGrid
            // 
            this.pnlGrid.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.IsSplitterFixed = true;
            this.pnlGrid.Location = new System.Drawing.Point(0, 0);
            this.pnlGrid.LookAndFeel.SkinName = "Office 2013";
            this.pnlGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Panel1.Controls.Add(this.tabControl);
            this.pnlGrid.Panel1.Controls.Add(this.lblReportName);
            this.pnlGrid.Panel1.Controls.Add(this.progressBar);
            this.pnlGrid.Panel1.Text = "Panel1";
            this.pnlGrid.Panel2.Controls.Add(this.navBarControl);
            this.pnlGrid.Panel2.Controls.Add(this.checkBox1);
            this.pnlGrid.Panel2.Controls.Add(this.btnSubmitQuery);
            this.pnlGrid.Panel2.MinSize = 187;
            this.pnlGrid.Panel2.Text = "Panel2";
            this.pnlGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pnlGrid.Size = new System.Drawing.Size(736, 569);
            this.pnlGrid.SplitterPosition = 644;
            this.pnlGrid.TabIndex = 9;
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.False;
            this.tabControl.Location = new System.Drawing.Point(0, 25);
            this.tabControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tabControl.MultiLine = DevExpress.Utils.DefaultBoolean.True;
            this.tabControl.Name = "tabControl";
            this.tabControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl.SelectedTabPage = this.xtraTabPage1;
            this.tabControl.Size = new System.Drawing.Size(537, 526);
            this.tabControl.TabIndex = 5;
            this.tabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.chartControl);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(531, 498);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // lblReportName
            // 
            this.lblReportName.BackColor = System.Drawing.SystemColors.Info;
            this.lblReportName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReportName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportName.Location = new System.Drawing.Point(0, 0);
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Size = new System.Drawing.Size(537, 25);
            this.lblReportName.TabIndex = 4;
            this.lblReportName.Text = "عنوان گزارش";
            this.lblReportName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 551);
            this.progressBar.Name = "progressBar";
            this.progressBar.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.progressBar.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.progressBar.Properties.ShowTitle = true;
            this.progressBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.progressBar.Size = new System.Drawing.Size(537, 18);
            this.progressBar.TabIndex = 1;
            this.progressBar.Visible = false;
            // 
            // navBarControl
            // 
            this.navBarControl.ActiveGroup = this.mnuBranches;
            this.navBarControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.navBarControl.Controls.Add(this.pnlCharts);
            this.navBarControl.Controls.Add(this.navBarGroupControlContainer);
            this.navBarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
            this.navBarControl.ExplorerBarShowGroupButtons = false;
            this.navBarControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.mnuChartTypes,
            this.mnuBranches});
            this.navBarControl.Location = new System.Drawing.Point(0, 0);
            this.navBarControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.navBarControl.Name = "navBarControl";
            this.navBarControl.OptionsNavPane.ExpandedWidth = 187;
            this.navBarControl.OptionsNavPane.ShowExpandButton = false;
            this.navBarControl.OptionsNavPane.ShowOverflowButton = false;
            this.navBarControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.navBarControl.Size = new System.Drawing.Size(187, 523);
            this.navBarControl.SkinExplorerBarViewScrollStyle = DevExpress.XtraNavBar.SkinExplorerBarViewScrollStyle.ScrollBar;
            this.navBarControl.TabIndex = 14;
            this.navBarControl.Text = "navBarControl";
            // 
            // mnuBranches
            // 
            this.mnuBranches.Caption = "لیست واحدها";
            this.mnuBranches.ControlContainer = this.navBarGroupControlContainer;
            this.mnuBranches.Expanded = true;
            this.mnuBranches.GroupClientHeight = 385;
            this.mnuBranches.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.mnuBranches.Name = "mnuBranches";
            // 
            // navBarGroupControlContainer
            // 
            this.navBarGroupControlContainer.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer.Controls.Add(this.treeBranches);
            this.navBarGroupControlContainer.Controls.Add(this.txtSearch);
            this.navBarGroupControlContainer.Name = "navBarGroupControlContainer";
            this.navBarGroupControlContainer.Size = new System.Drawing.Size(185, 390);
            this.navBarGroupControlContainer.TabIndex = 2;
            // 
            // treeBranches
            // 
            this.treeBranches.BackColor = System.Drawing.Color.Ivory;
            this.treeBranches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeBranches.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.treeBranches.HideSelection = false;
            this.treeBranches.ItemHeight = 25;
            this.treeBranches.Location = new System.Drawing.Point(0, 24);
            this.treeBranches.Name = "treeBranches";
            this.treeBranches.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.treeBranches.RightToLeftLayout = true;
            this.treeBranches.Size = new System.Drawing.Size(185, 366);
            this.treeBranches.TabIndex = 6;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.AutoHeight = false;
            this.txtSearch.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtSearch.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("txtSearch.Properties.ContextImageOptions.Image")));
            this.txtSearch.Size = new System.Drawing.Size(185, 24);
            this.txtSearch.TabIndex = 5;
            // 
            // pnlCharts
            // 
            this.pnlCharts.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlCharts.Appearance.Options.UseBackColor = true;
            this.pnlCharts.Controls.Add(this.radioGroup);
            this.pnlCharts.Name = "pnlCharts";
            this.pnlCharts.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pnlCharts.Size = new System.Drawing.Size(185, 390);
            this.pnlCharts.TabIndex = 1;
            // 
            // radioGroup
            // 
            this.radioGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioGroup.Location = new System.Drawing.Point(0, 0);
            this.radioGroup.Name = "radioGroup";
            this.radioGroup.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.radioGroup.Properties.Appearance.Options.UseFont = true;
            this.radioGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "نمودار مقاطع جاری"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "نمودار سال جاری"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "نمودار سال جاری + آخرین مقطع"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "نمودار سال جاری + روزانه ماه جاری"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "نمودار سال جاری و سال گذشته"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "نمودار سال گذشته و سال ما قبل آن")});
            this.radioGroup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioGroup.Size = new System.Drawing.Size(185, 222);
            this.radioGroup.TabIndex = 1;
            // 
            // mnuChartTypes
            // 
            this.mnuChartTypes.Caption = "مقـاطع نمـودار";
            this.mnuChartTypes.ControlContainer = this.pnlCharts;
            this.mnuChartTypes.GroupClientHeight = 329;
            this.mnuChartTypes.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.mnuChartTypes.Name = "mnuChartTypes";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBox1.Location = new System.Drawing.Point(0, 523);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(187, 17);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "نمایش گزارش در صفحه جدید (+)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnSubmitQuery
            // 
            this.btnSubmitQuery.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitQuery.Appearance.Options.UseFont = true;
            this.btnSubmitQuery.Appearance.Options.UseTextOptions = true;
            this.btnSubmitQuery.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnSubmitQuery.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSubmitQuery.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSubmitQuery.ImageOptions.Image")));
            this.btnSubmitQuery.Location = new System.Drawing.Point(0, 540);
            this.btnSubmitQuery.Name = "btnSubmitQuery";
            this.btnSubmitQuery.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnSubmitQuery.Size = new System.Drawing.Size(187, 29);
            this.btnSubmitQuery.TabIndex = 12;
            this.btnSubmitQuery.Text = "نمایش نمودار";
            // 
            // chartControl
            // 
            this.chartControl.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnLoad;
            this.chartControl.CrosshairOptions.CrosshairLabelTextOptions.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartControl.CrosshairOptions.GroupHeaderPattern = "{A}";
            this.chartControl.CrosshairOptions.GroupHeaderTextOptions.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chartControl.DataBindings = null;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Title.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.EnableAxisXScrolling = true;
            xyDiagram1.EnableAxisXZooming = true;
            xyDiagram1.EnableAxisYScrolling = true;
            xyDiagram1.EnableAxisYZooming = true;
            this.chartControl.Diagram = xyDiagram1;
            this.chartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Gradient;
            rectangleGradientFillOptions1.GradientMode = DevExpress.XtraCharts.RectangleGradientMode.TopLeftToBottomRight;
            this.chartControl.FillStyle.Options = rectangleGradientFillOptions1;
            this.chartControl.Legend.Name = "Default Legend";
            this.chartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl.Location = new System.Drawing.Point(0, 0);
            this.chartControl.Name = "chartControl";
            series1.Name = "Series 1";
            series1.View = lineSeriesView1;
            this.chartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl.Size = new System.Drawing.Size(531, 498);
            this.chartControl.TabIndex = 9;
            // 
            // frmIChartView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 569);
            this.Controls.Add(this.pnlGrid);
            this.Name = "frmIChartView";
            this.Text = "IChartView";
            this.SizeChanged += new System.EventHandler(this.frmIChartView_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).EndInit();
            this.navBarControl.ResumeLayout(false);
            this.navBarGroupControlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            this.pnlCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl pnlGrid;
        private DevExpress.XtraEditors.ProgressBarControl progressBar;
        private DevExpress.XtraTab.XtraTabControl tabControl;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl;
        private DevExpress.XtraNavBar.NavBarGroup mnuBranches;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer;
        private DevExpress.XtraEditors.TextEdit txtSearch;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer pnlCharts;
        private DevExpress.XtraEditors.RadioGroup radioGroup;
        private DevExpress.XtraNavBar.NavBarGroup mnuChartTypes;
        private System.Windows.Forms.CheckBox checkBox1;
        private DevExpress.XtraEditors.SimpleButton btnSubmitQuery;
        private System.Windows.Forms.TreeView treeBranches;
        public System.Windows.Forms.Label lblReportName;
        public DevExpress.XtraCharts.ChartControl chartControl;
    }
}