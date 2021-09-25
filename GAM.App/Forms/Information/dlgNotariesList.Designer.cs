namespace GAM.Forms.Information
{
    partial class dlgNotariesList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgNotariesList));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlTop = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearch = new DevExpress.XtraEditors.ButtonEdit();
            this.btnExportToXlsx = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNotaryID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotarName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotaryCity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotaryAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotaryTells = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.ColumnCount = 2;
            this.pnlTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.pnlTop.Controls.Add(this.txtSearch, 0, 0);
            this.pnlTop.Controls.Add(this.btnExportToXlsx, 1, 0);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlTop.RowCount = 1;
            this.pnlTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlTop.Size = new System.Drawing.Size(511, 29);
            this.pnlTop.TabIndex = 12;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.EditValue = "";
            this.txtSearch.Location = new System.Drawing.Point(33, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Properties.Appearance.Options.UseFont = true;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.txtSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.txtSearch.Properties.NullValuePrompt = "شماره دفتر/نام سر دفتر";
            this.txtSearch.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtSearch.Size = new System.Drawing.Size(475, 24);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtSearch_ButtonClick);
            this.txtSearch.EditValueChanged += new System.EventHandler(this.txtSearch_EditValueChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnExportToXlsx
            // 
            this.btnExportToXlsx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportToXlsx.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToXlsx.ImageOptions.Image")));
            this.btnExportToXlsx.Location = new System.Drawing.Point(3, 3);
            this.btnExportToXlsx.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.btnExportToXlsx.Name = "btnExportToXlsx";
            this.btnExportToXlsx.Size = new System.Drawing.Size(24, 24);
            this.btnExportToXlsx.TabIndex = 2;
            this.btnExportToXlsx.Click += new System.EventHandler(this.btnExportToXlsx_Click);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 29);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl.Size = new System.Drawing.Size(511, 395);
            this.gridControl.TabIndex = 3;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNotaryID,
            this.colNotarName,
            this.colNotaryCity,
            this.colNotaryAddress,
            this.colNotaryTells});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.RowHeight = 22;
            this.gridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyDown);
            this.gridView.DoubleClick += new System.EventHandler(this.gridView_DoubleClick);
            // 
            // colNotaryID
            // 
            this.colNotaryID.AppearanceCell.Options.UseTextOptions = true;
            this.colNotaryID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNotaryID.AppearanceHeader.Options.UseTextOptions = true;
            this.colNotaryID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNotaryID.Caption = "شماره";
            this.colNotaryID.FieldName = "NotaryNo";
            this.colNotaryID.Name = "colNotaryID";
            this.colNotaryID.OptionsColumn.AllowEdit = false;
            this.colNotaryID.OptionsColumn.FixedWidth = true;
            this.colNotaryID.OptionsColumn.ReadOnly = true;
            this.colNotaryID.OptionsFilter.AllowFilter = false;
            this.colNotaryID.Visible = true;
            this.colNotaryID.VisibleIndex = 0;
            this.colNotaryID.Width = 50;
            // 
            // colNotarName
            // 
            this.colNotarName.AppearanceHeader.Options.UseTextOptions = true;
            this.colNotarName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNotarName.Caption = "سر دفتر";
            this.colNotarName.FieldName = "NotarName";
            this.colNotarName.Image = ((System.Drawing.Image)(resources.GetObject("colNotarName.Image")));
            this.colNotarName.Name = "colNotarName";
            this.colNotarName.OptionsColumn.AllowEdit = false;
            this.colNotarName.OptionsColumn.FixedWidth = true;
            this.colNotarName.OptionsColumn.ReadOnly = true;
            this.colNotarName.OptionsFilter.AllowFilter = false;
            this.colNotarName.Visible = true;
            this.colNotarName.VisibleIndex = 1;
            this.colNotarName.Width = 150;
            // 
            // colNotaryCity
            // 
            this.colNotaryCity.AppearanceCell.Options.UseTextOptions = true;
            this.colNotaryCity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNotaryCity.AppearanceHeader.Options.UseTextOptions = true;
            this.colNotaryCity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNotaryCity.Caption = "شهر";
            this.colNotaryCity.FieldName = "NotaryCity";
            this.colNotaryCity.Name = "colNotaryCity";
            this.colNotaryCity.OptionsColumn.AllowEdit = false;
            this.colNotaryCity.OptionsColumn.ReadOnly = true;
            this.colNotaryCity.Visible = true;
            this.colNotaryCity.VisibleIndex = 2;
            this.colNotaryCity.Width = 70;
            // 
            // colNotaryAddress
            // 
            this.colNotaryAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colNotaryAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNotaryAddress.Caption = "آدرس";
            this.colNotaryAddress.FieldName = "NotaryAddress";
            this.colNotaryAddress.Name = "colNotaryAddress";
            this.colNotaryAddress.OptionsColumn.AllowEdit = false;
            this.colNotaryAddress.OptionsColumn.ReadOnly = true;
            this.colNotaryAddress.OptionsFilter.AllowFilter = false;
            this.colNotaryAddress.Visible = true;
            this.colNotaryAddress.VisibleIndex = 3;
            this.colNotaryAddress.Width = 300;
            // 
            // colNotaryTells
            // 
            this.colNotaryTells.AppearanceCell.Options.UseTextOptions = true;
            this.colNotaryTells.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNotaryTells.AppearanceHeader.Options.UseTextOptions = true;
            this.colNotaryTells.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNotaryTells.Caption = "تلفن";
            this.colNotaryTells.FieldName = "NotaryTells";
            this.colNotaryTells.Name = "colNotaryTells";
            this.colNotaryTells.OptionsColumn.AllowEdit = false;
            this.colNotaryTells.OptionsColumn.FixedWidth = true;
            this.colNotaryTells.OptionsColumn.ReadOnly = true;
            this.colNotaryTells.Visible = true;
            this.colNotaryTells.VisibleIndex = 4;
            this.colNotaryTells.Width = 100;
            // 
            // dlgNotariesList
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 424);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(424, 430);
            this.Name = "dlgNotariesList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "دفاتر اسناد رسمی";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.dlgNotariesList_Shown);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlTop;
        private DevExpress.XtraEditors.SimpleButton btnExportToXlsx;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colNotaryID;
        private DevExpress.XtraGrid.Columns.GridColumn colNotarName;
        private DevExpress.XtraGrid.Columns.GridColumn colNotaryTells;
        private DevExpress.XtraGrid.Columns.GridColumn colNotaryCity;
        private DevExpress.XtraGrid.Columns.GridColumn colNotaryAddress;
        private DevExpress.XtraEditors.ButtonEdit txtSearch;
    }
}