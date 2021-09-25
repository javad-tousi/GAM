namespace GAM.Forms.Reports.Etebarat.Requests
{
    partial class frmExpertsPerformance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpertsPerformance));
            this.btnExportToXlsx = new DevExpress.XtraEditors.SimpleButton();
            this.lblDate1 = new System.Windows.Forms.Label();
            this.txtFromDate = new Atf.UI.DateTimeSelector();
            this.lblDate2 = new System.Windows.Forms.Label();
            this.txtToDate = new Atf.UI.DateTimeSelector();
            this.btnShowQuery = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colUserId = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colUserName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colCount9 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCount10 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCount11 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colCount1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCount2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSum1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colCount3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCount4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCount5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colCount6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCount7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCount8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.pnlSearch = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.lblHelp = new DevExpress.XtraEditors.LabelControl();
            this.progressBar = new DevExpress.XtraEditors.ProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportToXlsx
            // 
            this.btnExportToXlsx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportToXlsx.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToXlsx.ImageOptions.Image")));
            this.btnExportToXlsx.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnExportToXlsx.Location = new System.Drawing.Point(2, 2);
            this.btnExportToXlsx.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExportToXlsx.Margin = new System.Windows.Forms.Padding(1);
            this.btnExportToXlsx.Name = "btnExportToXlsx";
            this.btnExportToXlsx.Size = new System.Drawing.Size(25, 24);
            this.btnExportToXlsx.TabIndex = 5;
            this.btnExportToXlsx.TabStop = false;
            this.btnExportToXlsx.Click += new System.EventHandler(this.btnExportToXlsx_Click);
            // 
            // lblDate1
            // 
            this.lblDate1.AutoSize = true;
            this.lblDate1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblDate1.Location = new System.Drawing.Point(606, 8);
            this.lblDate1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.lblDate1.Name = "lblDate1";
            this.lblDate1.Size = new System.Drawing.Size(65, 13);
            this.lblDate1.TabIndex = 185;
            this.lblDate1.Text = "از تاریخ ارجاع";
            // 
            // txtFromDate
            // 
            this.txtFromDate.CustomFormat = "dd/MM/yyyy";
            this.txtFromDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromDate.Format = Atf.UI.DateTimeSelectorFormat.Custom;
            this.txtFromDate.Location = new System.Drawing.Point(490, 2);
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
            this.lblDate2.Location = new System.Drawing.Point(449, 8);
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
            this.txtToDate.Location = new System.Drawing.Point(333, 2);
            this.txtToDate.Margin = new System.Windows.Forms.Padding(1);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtToDate.Size = new System.Drawing.Size(112, 24);
            this.txtToDate.TabIndex = 2;
            this.txtToDate.UsePersianFormat = true;
            // 
            // btnShowQuery
            // 
            this.btnShowQuery.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnShowQuery.ImageOptions.Image")));
            this.btnShowQuery.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnShowQuery.Location = new System.Drawing.Point(221, 2);
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
            this.gridControl.Location = new System.Drawing.Point(2, 30);
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl.Size = new System.Drawing.Size(675, 369);
            this.gridControl.TabIndex = 4;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            this.gridControl.ViewRegistered += new DevExpress.XtraGrid.ViewOperationEventHandler(this.gridControl_ViewRegistered);
            // 
            // gridView
            // 
            this.gridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand7,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4,
            this.gridBand5,
            this.gridBand6});
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colUserId,
            this.colUserName,
            this.colCount9,
            this.colCount10,
            this.colCount11,
            this.colCount1,
            this.colCount2,
            this.colSum1,
            this.colCount3,
            this.colCount4,
            this.colCount5,
            this.colCount6,
            this.colCount7,
            this.colCount8});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.RowHeight = 21;
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "اطلاعات کارشناس";
            this.gridBand1.Columns.Add(this.colUserId);
            this.gridBand1.Columns.Add(this.colUserName);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 183;
            // 
            // colUserId
            // 
            this.colUserId.AppearanceCell.Options.UseTextOptions = true;
            this.colUserId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserId.AppearanceHeader.Options.UseTextOptions = true;
            this.colUserId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserId.Caption = "ش.کارمندی";
            this.colUserId.FieldName = "UserId";
            this.colUserId.Name = "colUserId";
            this.colUserId.OptionsColumn.AllowEdit = false;
            this.colUserId.OptionsColumn.FixedWidth = true;
            this.colUserId.OptionsColumn.ReadOnly = true;
            this.colUserId.OptionsFilter.AllowFilter = false;
            this.colUserId.Visible = true;
            this.colUserId.Width = 63;
            // 
            // colUserName
            // 
            this.colUserName.AppearanceHeader.Options.UseTextOptions = true;
            this.colUserName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserName.Caption = "نام و نام خانوادگی";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.OptionsColumn.AllowEdit = false;
            this.colUserName.OptionsColumn.FixedWidth = true;
            this.colUserName.OptionsColumn.ReadOnly = true;
            this.colUserName.OptionsFilter.AllowFilter = false;
            this.colUserName.Visible = true;
            this.colUserName.Width = 120;
            // 
            // gridBand7
            // 
            this.gridBand7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand7.Caption = "پیشنهادات اعتباری";
            this.gridBand7.Columns.Add(this.colCount9);
            this.gridBand7.Columns.Add(this.colCount10);
            this.gridBand7.Columns.Add(this.colCount11);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.VisibleIndex = 1;
            this.gridBand7.Width = 135;
            // 
            // colCount9
            // 
            this.colCount9.AppearanceCell.Options.UseTextOptions = true;
            this.colCount9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount9.AppearanceHeader.Options.UseTextOptions = true;
            this.colCount9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount9.Caption = "ارجاع";
            this.colCount9.FieldName = "Count9";
            this.colCount9.Name = "colCount9";
            this.colCount9.ToolTip = "تعداد پیشنهاد ارجاع شده";
            this.colCount9.Visible = true;
            this.colCount9.Width = 45;
            // 
            // colCount10
            // 
            this.colCount10.AppearanceCell.Options.UseTextOptions = true;
            this.colCount10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount10.AppearanceHeader.Options.UseTextOptions = true;
            this.colCount10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount10.Caption = "اقدام";
            this.colCount10.FieldName = "Count10";
            this.colCount10.Name = "colCount10";
            this.colCount10.ToolTip = "تعداد پیشنهاد دارای فرم بررسی";
            this.colCount10.Visible = true;
            this.colCount10.Width = 45;
            // 
            // colCount11
            // 
            this.colCount11.AppearanceCell.BackColor = System.Drawing.Color.Honeydew;
            this.colCount11.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.colCount11.AppearanceCell.Options.UseBackColor = true;
            this.colCount11.AppearanceCell.Options.UseForeColor = true;
            this.colCount11.AppearanceCell.Options.UseTextOptions = true;
            this.colCount11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount11.AppearanceHeader.Options.UseTextOptions = true;
            this.colCount11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount11.Caption = "مختومه";
            this.colCount11.FieldName = "Count11";
            this.colCount11.Name = "colCount11";
            this.colCount11.ToolTip = "تعداد پیشنهاد خاتمه یافته";
            this.colCount11.Visible = true;
            this.colCount11.Width = 45;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "فرم های بررسی";
            this.gridBand2.Columns.Add(this.colCount1);
            this.gridBand2.Columns.Add(this.colCount2);
            this.gridBand2.Columns.Add(this.colSum1);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 2;
            this.gridBand2.Width = 135;
            // 
            // colCount1
            // 
            this.colCount1.AppearanceCell.Options.UseTextOptions = true;
            this.colCount1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount1.AppearanceHeader.Options.UseTextOptions = true;
            this.colCount1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount1.Caption = "اقدام";
            this.colCount1.FieldName = "Count1";
            this.colCount1.Name = "colCount1";
            this.colCount1.OptionsColumn.AllowEdit = false;
            this.colCount1.OptionsColumn.FixedWidth = true;
            this.colCount1.OptionsColumn.ReadOnly = true;
            this.colCount1.OptionsFilter.AllowFilter = false;
            this.colCount1.ToolTip = "تعداد فرم بررسی ثبت شده (ثبت اولیه) در سیستم";
            this.colCount1.Visible = true;
            this.colCount1.Width = 45;
            // 
            // colCount2
            // 
            this.colCount2.AppearanceCell.BackColor = System.Drawing.Color.Honeydew;
            this.colCount2.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.colCount2.AppearanceCell.Options.UseBackColor = true;
            this.colCount2.AppearanceCell.Options.UseForeColor = true;
            this.colCount2.AppearanceCell.Options.UseTextOptions = true;
            this.colCount2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount2.AppearanceHeader.Options.UseTextOptions = true;
            this.colCount2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount2.Caption = "تکمیل";
            this.colCount2.FieldName = "Count2";
            this.colCount2.Name = "colCount2";
            this.colCount2.OptionsColumn.AllowEdit = false;
            this.colCount2.OptionsColumn.FixedWidth = true;
            this.colCount2.OptionsColumn.ReadOnly = true;
            this.colCount2.OptionsFilter.AllowFilter = false;
            this.colCount2.ToolTip = "تعداد فرم بررسی تکمیل و چاپ شده";
            this.colCount2.Visible = true;
            this.colCount2.Width = 45;
            // 
            // colSum1
            // 
            this.colSum1.AppearanceCell.Options.UseTextOptions = true;
            this.colSum1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSum1.AppearanceHeader.Options.UseTextOptions = true;
            this.colSum1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSum1.Caption = "جمع";
            this.colSum1.FieldName = "Sum1";
            this.colSum1.Name = "colSum1";
            this.colSum1.OptionsColumn.AllowEdit = false;
            this.colSum1.OptionsColumn.FixedWidth = true;
            this.colSum1.OptionsColumn.ReadOnly = true;
            this.colSum1.OptionsFilter.AllowFilter = false;
            this.colSum1.Visible = true;
            this.colSum1.Width = 45;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "گزارشات کارشناسی";
            this.gridBand3.Columns.Add(this.colCount3);
            this.gridBand3.Columns.Add(this.colCount4);
            this.gridBand3.Columns.Add(this.colCount5);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 3;
            this.gridBand3.Width = 135;
            // 
            // colCount3
            // 
            this.colCount3.AppearanceCell.Options.UseTextOptions = true;
            this.colCount3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount3.AppearanceHeader.Options.UseTextOptions = true;
            this.colCount3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount3.Caption = "ارجاع";
            this.colCount3.FieldName = "Count3";
            this.colCount3.Name = "colCount3";
            this.colCount3.OptionsColumn.AllowEdit = false;
            this.colCount3.OptionsColumn.FixedWidth = true;
            this.colCount3.OptionsColumn.ReadOnly = true;
            this.colCount3.OptionsFilter.AllowFilter = false;
            this.colCount3.ToolTip = "تعداد گزارش ارجاع شده";
            this.colCount3.Visible = true;
            this.colCount3.Width = 45;
            // 
            // colCount4
            // 
            this.colCount4.AppearanceCell.BackColor = System.Drawing.Color.Honeydew;
            this.colCount4.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.colCount4.AppearanceCell.Options.UseBackColor = true;
            this.colCount4.AppearanceCell.Options.UseForeColor = true;
            this.colCount4.AppearanceCell.Options.UseTextOptions = true;
            this.colCount4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount4.AppearanceHeader.Options.UseTextOptions = true;
            this.colCount4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount4.Caption = "تکمیل";
            this.colCount4.FieldName = "Count4";
            this.colCount4.Name = "colCount4";
            this.colCount4.OptionsColumn.AllowEdit = false;
            this.colCount4.OptionsColumn.FixedWidth = true;
            this.colCount4.OptionsColumn.ReadOnly = true;
            this.colCount4.OptionsFilter.AllowFilter = false;
            this.colCount4.ToolTip = "تعداد گزارش بررسی شده";
            this.colCount4.Visible = true;
            this.colCount4.Width = 45;
            // 
            // colCount5
            // 
            this.colCount5.AppearanceCell.Options.UseTextOptions = true;
            this.colCount5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount5.AppearanceHeader.Options.UseTextOptions = true;
            this.colCount5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount5.Caption = "مختومه";
            this.colCount5.FieldName = "Count5";
            this.colCount5.Name = "colCount5";
            this.colCount5.OptionsColumn.AllowEdit = false;
            this.colCount5.OptionsColumn.FixedWidth = true;
            this.colCount5.OptionsColumn.ReadOnly = true;
            this.colCount5.OptionsFilter.AllowFilter = false;
            this.colCount5.ToolTip = "تعداد گزارش خاتمه یافته (توضیح: شامل موارد خاتمه یافته اعم از تکمیل گزارش، کسری پ" +
    "رونده (عودت شده) و موارد بدون اقدام می باشد)";
            this.colCount5.Visible = true;
            this.colCount5.Width = 45;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "تعداد مختومه";
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.Visible = false;
            this.gridBand4.VisibleIndex = -1;
            this.gridBand4.Width = 60;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.Caption = "ارسال به تهران";
            this.gridBand5.Columns.Add(this.colCount6);
            this.gridBand5.Columns.Add(this.colCount7);
            this.gridBand5.Columns.Add(this.colCount8);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 4;
            this.gridBand5.Width = 135;
            // 
            // colCount6
            // 
            this.colCount6.AppearanceCell.Options.UseTextOptions = true;
            this.colCount6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount6.AppearanceHeader.Options.UseTextOptions = true;
            this.colCount6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount6.Caption = "ارجاع";
            this.colCount6.FieldName = "Count6";
            this.colCount6.Name = "colCount6";
            this.colCount6.OptionsColumn.AllowEdit = false;
            this.colCount6.OptionsColumn.ReadOnly = true;
            this.colCount6.OptionsFilter.AllowFilter = false;
            this.colCount6.ToolTip = "تعداد پرونده ارجاع شده جهت ثبت در سامانه";
            this.colCount6.Visible = true;
            this.colCount6.Width = 45;
            // 
            // colCount7
            // 
            this.colCount7.AppearanceCell.BackColor = System.Drawing.Color.Honeydew;
            this.colCount7.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.colCount7.AppearanceCell.Options.UseBackColor = true;
            this.colCount7.AppearanceCell.Options.UseForeColor = true;
            this.colCount7.AppearanceCell.Options.UseTextOptions = true;
            this.colCount7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount7.AppearanceHeader.Options.UseTextOptions = true;
            this.colCount7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount7.Caption = "تکمیل";
            this.colCount7.FieldName = "Count7";
            this.colCount7.Name = "colCount7";
            this.colCount7.OptionsColumn.AllowEdit = false;
            this.colCount7.OptionsColumn.ReadOnly = true;
            this.colCount7.OptionsFilter.AllowFilter = false;
            this.colCount7.ToolTip = "تعداد پرونده ثبت شده در سامانه";
            this.colCount7.Visible = true;
            this.colCount7.Width = 45;
            // 
            // colCount8
            // 
            this.colCount8.AppearanceCell.Options.UseTextOptions = true;
            this.colCount8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount8.AppearanceHeader.Options.UseTextOptions = true;
            this.colCount8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount8.Caption = "مختومه";
            this.colCount8.FieldName = "Count8";
            this.colCount8.Name = "colCount8";
            this.colCount8.OptionsColumn.AllowEdit = false;
            this.colCount8.OptionsColumn.ReadOnly = true;
            this.colCount8.OptionsFilter.AllowFilter = false;
            this.colCount8.ToolTip = "تعداد پرونده خاتمه یافته (توضیح: شامل موارد خاتمه یافته اعم از ثبت پرونده، کسری پ" +
    "رونده (عودت شده) و موارد بدون اقدام می باشد)";
            this.colCount8.Visible = true;
            this.colCount8.Width = 45;
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand6.Caption = "گزارش کارشناسی و ارسال به تهران";
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.Visible = false;
            this.gridBand6.VisibleIndex = -1;
            this.gridBand6.Width = 45;
            // 
            // pnlSearch
            // 
            this.pnlSearch.ColumnCount = 6;
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlSearch.Controls.Add(this.lblDate1, 0, 0);
            this.pnlSearch.Controls.Add(this.btnExportToXlsx, 5, 0);
            this.pnlSearch.Controls.Add(this.btnShowQuery, 4, 0);
            this.pnlSearch.Controls.Add(this.txtFromDate, 1, 0);
            this.pnlSearch.Controls.Add(this.txtToDate, 3, 0);
            this.pnlSearch.Controls.Add(this.lblDate2, 2, 0);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(2, 2);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(1);
            this.pnlSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlSearch.RowCount = 1;
            this.pnlSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlSearch.Size = new System.Drawing.Size(675, 28);
            this.pnlSearch.TabIndex = 5;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.gridControl);
            this.pnlMain.Controls.Add(this.pnlSearch);
            this.pnlMain.Controls.Add(this.lblHelp);
            this.pnlMain.Controls.Add(this.progressBar);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(679, 421);
            this.pnlMain.TabIndex = 6;
            // 
            // lblHelp
            // 
            this.lblHelp.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.lblHelp.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblHelp.Appearance.Image")));
            this.lblHelp.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblHelp.Appearance.Options.UseBackColor = true;
            this.lblHelp.Appearance.Options.UseImage = true;
            this.lblHelp.Appearance.Options.UseImageAlign = true;
            this.lblHelp.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblHelp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblHelp.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.lblHelp.Location = new System.Drawing.Point(2, 399);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(675, 20);
            this.lblHelp.TabIndex = 6;
            this.lblHelp.Text = "لطفاً جهت کسب اطلاعات بیشتر درباره مقادیر نمایشی نشانگر موس را بر روی عنوان ستون " +
    "نگه دارید";
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.EditValue = "0";
            this.progressBar.Location = new System.Drawing.Point(2, 381);
            this.progressBar.Name = "progressBar";
            this.progressBar.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.progressBar.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.progressBar.Properties.ShowTitle = true;
            this.progressBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.progressBar.Size = new System.Drawing.Size(675, 18);
            this.progressBar.TabIndex = 7;
            this.progressBar.Visible = false;
            // 
            // frmExpertsPerformance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 421);
            this.Controls.Add(this.pnlMain);
            this.MinimizeBox = false;
            this.Name = "frmExpertsPerformance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "عملکرد کارشناسان اعتباری";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDate1;
        private Atf.UI.DateTimeSelector txtFromDate;
        private System.Windows.Forms.Label lblDate2;
        private Atf.UI.DateTimeSelector txtToDate;
        private DevExpress.XtraEditors.SimpleButton btnShowQuery;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraEditors.SimpleButton btnExportToXlsx;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gridView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colUserId;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colUserName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCount1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCount3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCount4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCount2;
        private System.Windows.Forms.TableLayoutPanel pnlSearch;
        public DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSum1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCount5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCount6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCount7;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCount8;
        private DevExpress.XtraEditors.LabelControl lblHelp;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCount9;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCount10;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCount11;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraEditors.ProgressBarControl progressBar;
    }
}