namespace GAM.Forms.Settings
{
    partial class ftpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ftpForm));
            this.pnlBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteFile = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlDrop = new DevExpress.XtraEditors.PanelControl();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDrop)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.btnDeleteFile);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.btnBrowse);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 380);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlBottom.Size = new System.Drawing.Size(521, 35);
            this.pnlBottom.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(417, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 29);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "ذخیره فایل";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Enabled = false;
            this.btnDeleteFile.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteFile.ImageOptions.Image")));
            this.btnDeleteFile.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnDeleteFile.Location = new System.Drawing.Point(310, 3);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(101, 29);
            this.btnDeleteFile.TabIndex = 19;
            this.btnDeleteFile.Text = "حذف فایل";
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnRefresh.Location = new System.Drawing.Point(189, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(115, 29);
            this.btnRefresh.TabIndex = 18;
            this.btnRefresh.Text = "بروزرسانی فایل ها";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowse.ImageOptions.Image")));
            this.btnBrowse.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnBrowse.Location = new System.Drawing.Point(60, 3);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(123, 29);
            this.btnBrowse.TabIndex = 16;
            this.btnBrowse.Text = "راهنما ارسال فایل";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl.Size = new System.Drawing.Size(521, 334);
            this.gridControl.TabIndex = 12;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFileName,
            this.colFileDate});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsSelection.CheckBoxSelectorColumnWidth = 25;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.RowHeight = 24;
            // 
            // colFileName
            // 
            this.colFileName.AppearanceHeader.Options.UseTextOptions = true;
            this.colFileName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFileName.Caption = "نام فایل";
            this.colFileName.FieldName = "FileName";
            this.colFileName.Image = ((System.Drawing.Image)(resources.GetObject("colFileName.Image")));
            this.colFileName.Name = "colFileName";
            this.colFileName.OptionsColumn.AllowEdit = false;
            this.colFileName.OptionsColumn.ReadOnly = true;
            this.colFileName.OptionsFilter.AllowFilter = false;
            this.colFileName.Visible = true;
            this.colFileName.VisibleIndex = 1;
            this.colFileName.Width = 368;
            // 
            // colFileDate
            // 
            this.colFileDate.AppearanceCell.Options.UseTextOptions = true;
            this.colFileDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFileDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colFileDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFileDate.Caption = "تاریخ ارسال";
            this.colFileDate.DisplayFormat.FormatString = "0000/00/00";
            this.colFileDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFileDate.FieldName = "FileDateTime";
            this.colFileDate.Image = ((System.Drawing.Image)(resources.GetObject("colFileDate.Image")));
            this.colFileDate.Name = "colFileDate";
            this.colFileDate.OptionsColumn.AllowEdit = false;
            this.colFileDate.OptionsColumn.FixedWidth = true;
            this.colFileDate.OptionsColumn.ReadOnly = true;
            this.colFileDate.OptionsFilter.AllowFilter = false;
            this.colFileDate.Visible = true;
            this.colFileDate.VisibleIndex = 2;
            this.colFileDate.Width = 110;
            // 
            // pnlDrop
            // 
            this.pnlDrop.AllowDrop = true;
            this.pnlDrop.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlDrop.Appearance.Options.UseBackColor = true;
            this.pnlDrop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.pnlDrop.ContentImage = ((System.Drawing.Image)(resources.GetObject("pnlDrop.ContentImage")));
            this.pnlDrop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDrop.Location = new System.Drawing.Point(0, 334);
            this.pnlDrop.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.pnlDrop.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlDrop.Name = "pnlDrop";
            this.pnlDrop.Size = new System.Drawing.Size(521, 46);
            this.pnlDrop.TabIndex = 13;
            this.pnlDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlDrop_DragDrop);
            this.pnlDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlDrop_DragEnter);
            this.pnlDrop.DragLeave += new System.EventHandler(this.pnlDrop_DragLeave);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.gridControl);
            this.pnlMain.Controls.Add(this.pnlDrop);
            this.pnlMain.Controls.Add(this.pnlBottom);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(521, 415);
            this.pnlMain.TabIndex = 14;
            // 
            // ftpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 415);
            this.Controls.Add(this.pnlMain);
            this.Name = "ftpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "فایل های من";
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDrop)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnBrowse;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colFileDate;
        private DevExpress.XtraEditors.SimpleButton btnDeleteFile;
        private DevExpress.XtraEditors.PanelControl pnlDrop;
        public System.Windows.Forms.Panel pnlMain;
    }
}