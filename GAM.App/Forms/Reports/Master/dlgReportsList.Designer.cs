using System.Windows.Forms;
namespace GAM.Forms.Reports.Master
{
    partial class dlgReportsList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgReportsList));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression4 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule5 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression5 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule6 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression6 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlBottom = new System.Windows.Forms.TableLayoutPanel();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.gridReports = new DevExpress.XtraGrid.GridControl();
            this.gridview = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colReportNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReportName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnltblMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblReports = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.listCategory = new DevExpress.XtraEditors.ListBoxControl();
            this.txtSearch = new DevExpress.XtraEditors.ButtonEdit();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.grpHelp = new DevExpress.XtraEditors.GroupControl();
            this.txtHelp = new System.Windows.Forms.RichTextBox();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridview)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnltblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpHelp)).BeginInit();
            this.grpHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.ColumnCount = 3;
            this.pnlBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 367F));
            this.pnlBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlBottom.Controls.Add(this.btnOk, 0, 0);
            this.pnlBottom.Controls.Add(this.btnCancel, 1, 0);
            this.pnlBottom.Controls.Add(this.btnUpdate, 2, 0);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 528);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlBottom.RowCount = 1;
            this.pnlBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlBottom.Size = new System.Drawing.Size(619, 34);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Appearance.Options.UseFont = true;
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnOk.Location = new System.Drawing.Point(492, 2);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(124, 28);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "انتخاب گزارش";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(370, 2);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 28);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancelReport_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnUpdate.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnUpdate.Location = new System.Drawing.Point(236, 2);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(128, 28);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "بروزرسانی گزارشات";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // gridReports
            // 
            this.gridReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridReports.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridReports.Location = new System.Drawing.Point(4, 35);
            this.gridReports.MainView = this.gridview;
            this.gridReports.Name = "gridReports";
            this.gridReports.Size = new System.Drawing.Size(406, 373);
            this.gridReports.TabIndex = 26;
            this.gridReports.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridview});
            // 
            // gridview
            // 
            this.gridview.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colReportNo,
            this.colReportName,
            this.colStatus});
            this.gridview.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            gridFormatRule4.ApplyToRow = true;
            gridFormatRule4.Name = "Format0";
            formatConditionRuleExpression4.Appearance.BackColor = System.Drawing.Color.Transparent;
            formatConditionRuleExpression4.Appearance.BackColor2 = System.Drawing.Color.PaleGreen;
            formatConditionRuleExpression4.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression4.Expression = "[Status] = \'جدید\'";
            gridFormatRule4.Rule = formatConditionRuleExpression4;
            gridFormatRule5.ApplyToRow = true;
            gridFormatRule5.Name = "Format1";
            formatConditionRuleExpression5.Appearance.BackColor = System.Drawing.Color.Transparent;
            formatConditionRuleExpression5.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            formatConditionRuleExpression5.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression5.Expression = "[Status] = \'به زودی\'";
            gridFormatRule5.Rule = formatConditionRuleExpression5;
            gridFormatRule6.ApplyToRow = true;
            gridFormatRule6.Name = "Format2";
            formatConditionRuleExpression6.Appearance.BackColor = System.Drawing.Color.Transparent;
            formatConditionRuleExpression6.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            formatConditionRuleExpression6.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression6.Expression = "[Status] = \'غیرفعال\'";
            gridFormatRule6.Rule = formatConditionRuleExpression6;
            this.gridview.FormatRules.Add(gridFormatRule4);
            this.gridview.FormatRules.Add(gridFormatRule5);
            this.gridview.FormatRules.Add(gridFormatRule6);
            this.gridview.GridControl = this.gridReports;
            this.gridview.Name = "gridview";
            this.gridview.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridview.OptionsView.ColumnAutoWidth = false;
            this.gridview.OptionsView.ShowGroupPanel = false;
            this.gridview.RowHeight = 25;
            this.gridview.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.viewReports_FocusedRowChanged);
            this.gridview.DoubleClick += new System.EventHandler(this.viewReports_DoubleClick);
            // 
            // colReportNo
            // 
            this.colReportNo.AppearanceCell.Options.UseTextOptions = true;
            this.colReportNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReportNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colReportNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReportNo.Caption = "کد";
            this.colReportNo.FieldName = "ReportNo";
            this.colReportNo.Name = "colReportNo";
            this.colReportNo.OptionsColumn.AllowEdit = false;
            this.colReportNo.OptionsColumn.AllowMove = false;
            this.colReportNo.OptionsColumn.FixedWidth = true;
            this.colReportNo.OptionsColumn.ReadOnly = true;
            this.colReportNo.OptionsFilter.AllowFilter = false;
            this.colReportNo.Visible = true;
            this.colReportNo.VisibleIndex = 0;
            this.colReportNo.Width = 34;
            // 
            // colReportName
            // 
            this.colReportName.AppearanceHeader.Options.UseTextOptions = true;
            this.colReportName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReportName.Caption = "نام گزارش";
            this.colReportName.FieldName = "ReportName";
            this.colReportName.Name = "colReportName";
            this.colReportName.OptionsColumn.AllowEdit = false;
            this.colReportName.OptionsColumn.AllowMove = false;
            this.colReportName.OptionsColumn.FixedWidth = true;
            this.colReportName.OptionsColumn.ReadOnly = true;
            this.colReportName.OptionsFilter.AllowFilter = false;
            this.colReportName.Visible = true;
            this.colReportName.VisibleIndex = 1;
            this.colReportName.Width = 341;
            // 
            // colStatus
            // 
            this.colStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus.Caption = " ";
            this.colStatus.CustomizationCaption = " ";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.OptionsColumn.ReadOnly = true;
            this.colStatus.OptionsFilter.AllowFilter = false;
            this.colStatus.Width = 48;
            // 
            // pnlMain
            // 
            this.pnlMain.ColumnCount = 1;
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlMain.Controls.Add(this.pnltblMain, 0, 1);
            this.pnlMain.Controls.Add(this.lblTitle, 0, 0);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.RowCount = 2;
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlMain.Size = new System.Drawing.Size(619, 436);
            this.pnlMain.TabIndex = 20;
            // 
            // pnltblMain
            // 
            this.pnltblMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pnltblMain.ColumnCount = 3;
            this.pnltblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnltblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.pnltblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnltblMain.Controls.Add(this.lblReports, 0, 1);
            this.pnltblMain.Controls.Add(this.lblSearch, 0, 0);
            this.pnltblMain.Controls.Add(this.gridReports, 2, 1);
            this.pnltblMain.Controls.Add(this.listCategory, 1, 1);
            this.pnltblMain.Controls.Add(this.txtSearch, 2, 0);
            this.pnltblMain.Controls.Add(this.lblCategory, 1, 0);
            this.pnltblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnltblMain.Location = new System.Drawing.Point(0, 24);
            this.pnltblMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnltblMain.Name = "pnltblMain";
            this.pnltblMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnltblMain.RowCount = 2;
            this.pnltblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.pnltblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnltblMain.Size = new System.Drawing.Size(619, 412);
            this.pnltblMain.TabIndex = 23;
            // 
            // lblReports
            // 
            this.lblReports.BackColor = System.Drawing.Color.Transparent;
            this.lblReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReports.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblReports.ForeColor = System.Drawing.Color.Black;
            this.lblReports.Location = new System.Drawing.Point(568, 32);
            this.lblReports.Margin = new System.Windows.Forms.Padding(0);
            this.lblReports.Name = "lblReports";
            this.lblReports.Size = new System.Drawing.Size(50, 379);
            this.lblReports.TabIndex = 24;
            this.lblReports.Text = "گزارشات";
            this.lblReports.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSearch
            // 
            this.lblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSearch.ForeColor = System.Drawing.Color.Black;
            this.lblSearch.Location = new System.Drawing.Point(568, 1);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(50, 30);
            this.lblSearch.TabIndex = 23;
            this.lblSearch.Text = "جستجو";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listCategory
            // 
            this.listCategory.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.listCategory.Appearance.Options.UseFont = true;
            this.listCategory.Cursor = System.Windows.Forms.Cursors.Default;
            this.listCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listCategory.ItemHeight = 20;
            this.listCategory.Items.AddRange(new object[] {
            "همه موارد",
            "منابع",
            "مصارف",
            "مطالبات",
            "تعهدات",
            "بدهکاران",
            "مصارف بسته ها",
            "حجم بسته ها",
            "مطالبات بسته ها",
            "تسهیلات پرداختی",
            "اقلام مطالباتی",
            "سرفصل های مالی",
            "سرفصل های عملیاتی",
            "شـاخص های عملیاتی",
            "نسبت ها",
            "پرسنلی"});
            this.listCategory.Location = new System.Drawing.Point(417, 35);
            this.listCategory.Name = "listCategory";
            this.listCategory.Size = new System.Drawing.Size(147, 373);
            this.listCategory.TabIndex = 0;
            this.listCategory.TabStop = false;
            this.listCategory.SelectedIndexChanged += new System.EventHandler(this.listCategory_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(3, 3);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Properties.Appearance.Options.UseFont = true;
            this.txtSearch.Properties.AutoHeight = false;
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            serializableAppearanceObject5.Image = ((System.Drawing.Image)(resources.GetObject("serializableAppearanceObject5.Image")));
            serializableAppearanceObject5.Options.UseImage = true;
            this.txtSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.txtSearch.Properties.NullValuePrompt = "کد / نام گزارش";
            this.txtSearch.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtSearch.Size = new System.Drawing.Size(408, 26);
            this.txtSearch.TabIndex = 26;
            this.txtSearch.TabStop = false;
            this.txtSearch.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtSearch_ButtonClick);
            this.txtSearch.EditValueChanged += new System.EventHandler(this.txtSearch_EditValueChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.BackColor = System.Drawing.Color.Transparent;
            this.lblCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCategory.Location = new System.Drawing.Point(417, 1);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(150, 30);
            this.lblCategory.TabIndex = 32;
            this.lblCategory.Text = "طبقه بندی گزارشات";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FloralWhite;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTitle.Size = new System.Drawing.Size(613, 24);
            this.lblTitle.TabIndex = 21;
            this.lblTitle.Text = "فهرست گزارشات";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.InsertGalleryImage("summary_16x16.png", "devav/print/summary_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("devav/print/summary_16x16.png"), 0);
            this.imageCollection.Images.SetKeyName(0, "summary_16x16.png");
            // 
            // grpHelp
            // 
            this.grpHelp.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("grpHelp.CaptionImageOptions.Image")));
            this.grpHelp.Controls.Add(this.txtHelp);
            this.grpHelp.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpHelp.Location = new System.Drawing.Point(0, 436);
            this.grpHelp.Name = "grpHelp";
            this.grpHelp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpHelp.Size = new System.Drawing.Size(619, 90);
            this.grpHelp.TabIndex = 23;
            this.grpHelp.Text = "راهنما";
            // 
            // txtHelp
            // 
            this.txtHelp.BackColor = System.Drawing.Color.Ivory;
            this.txtHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHelp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHelp.Location = new System.Drawing.Point(2, 21);
            this.txtHelp.Name = "txtHelp";
            this.txtHelp.ReadOnly = true;
            this.txtHelp.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtHelp.Size = new System.Drawing.Size(615, 67);
            this.txtHelp.TabIndex = 10;
            this.txtHelp.Text = "";
            // 
            // dlgReportsList
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 562);
            this.Controls.Add(this.grpHelp);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LookAndFeel.SkinName = "Office 2010 Silver";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgReportsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تهیه گزارش";
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridview)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnltblMain.ResumeLayout(false);
            this.pnltblMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpHelp)).EndInit();
            this.grpHelp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private TableLayoutPanel pnlBottom;
        private DevExpress.XtraGrid.GridControl gridReports;
        private DevExpress.XtraGrid.Views.Grid.GridView gridview;
        private DevExpress.XtraGrid.Columns.GridColumn colReportNo;
        private DevExpress.XtraGrid.Columns.GridColumn colReportName;
        private TableLayoutPanel pnlMain;
        private Label lblTitle;
        private TableLayoutPanel pnltblMain;
        public Label lblReports;
        public Label lblSearch;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.ButtonEdit txtSearch;
        private DevExpress.XtraEditors.GroupControl grpHelp;
        private RichTextBox txtHelp;
        private DevExpress.XtraEditors.ListBoxControl listCategory;
        private Label lblCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
    }
}