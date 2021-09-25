namespace GAM.Forms.Profile.Etebarat.Print
{
    partial class dlgHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgHistory));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colShowRow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryShowRow = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colRequestSerial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModifiedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequestType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBranchID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBranchName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFacilityID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFacilityName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequestAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryShowRow)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryShowRow});
            this.gridControl.Size = new System.Drawing.Size(595, 331);
            this.gridControl.TabIndex = 7;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colShowRow,
            this.colRequestSerial,
            this.colModifiedDate,
            this.colRequestType,
            this.colBranchID,
            this.colBranchName,
            this.colCustomerName,
            this.colFacilityID,
            this.colFacilityName,
            this.colRequestAmount});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            // 
            // colShowRow
            // 
            this.colShowRow.AppearanceHeader.Options.UseTextOptions = true;
            this.colShowRow.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShowRow.Caption = " ";
            this.colShowRow.ColumnEdit = this.repositoryShowRow;
            this.colShowRow.Name = "colShowRow";
            this.colShowRow.OptionsFilter.AllowFilter = false;
            this.colShowRow.Visible = true;
            this.colShowRow.VisibleIndex = 0;
            this.colShowRow.Width = 25;
            // 
            // repositoryShowRow
            // 
            this.repositoryShowRow.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.repositoryShowRow.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryShowRow.Name = "repositoryShowRow";
            this.repositoryShowRow.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryShowRow.Click += new System.EventHandler(this.repositoryShowRow_Click);
            // 
            // colRequestSerial
            // 
            this.colRequestSerial.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.colRequestSerial.AppearanceCell.Options.UseBackColor = true;
            this.colRequestSerial.AppearanceHeader.Options.UseTextOptions = true;
            this.colRequestSerial.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRequestSerial.Caption = "سریال";
            this.colRequestSerial.FieldName = "RequestSerial";
            this.colRequestSerial.Name = "colRequestSerial";
            this.colRequestSerial.OptionsColumn.AllowEdit = false;
            this.colRequestSerial.OptionsColumn.ReadOnly = true;
            this.colRequestSerial.OptionsFilter.AllowFilter = false;
            // 
            // colModifiedDate
            // 
            this.colModifiedDate.AppearanceCell.Options.UseTextOptions = true;
            this.colModifiedDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colModifiedDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colModifiedDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colModifiedDate.Caption = "تاریخ ثبت";
            this.colModifiedDate.FieldName = "ModifiedDate";
            this.colModifiedDate.Name = "colModifiedDate";
            this.colModifiedDate.OptionsColumn.AllowEdit = false;
            this.colModifiedDate.OptionsColumn.FixedWidth = true;
            this.colModifiedDate.OptionsColumn.ReadOnly = true;
            this.colModifiedDate.OptionsFilter.AllowFilter = false;
            this.colModifiedDate.Visible = true;
            this.colModifiedDate.VisibleIndex = 1;
            this.colModifiedDate.Width = 90;
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
            this.colRequestType.VisibleIndex = 2;
            // 
            // colBranchID
            // 
            this.colBranchID.AppearanceCell.Options.UseTextOptions = true;
            this.colBranchID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBranchID.AppearanceHeader.Options.UseTextOptions = true;
            this.colBranchID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBranchID.Caption = "کد شعبه";
            this.colBranchID.FieldName = "BranchID";
            this.colBranchID.Name = "colBranchID";
            this.colBranchID.OptionsColumn.AllowEdit = false;
            this.colBranchID.OptionsColumn.FixedWidth = true;
            this.colBranchID.OptionsColumn.ReadOnly = true;
            this.colBranchID.OptionsFilter.AllowFilter = false;
            this.colBranchID.Width = 50;
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
            this.colBranchName.VisibleIndex = 3;
            this.colBranchName.Width = 165;
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
            this.colCustomerName.VisibleIndex = 4;
            this.colCustomerName.Width = 190;
            // 
            // colFacilityID
            // 
            this.colFacilityID.AppearanceCell.Options.UseTextOptions = true;
            this.colFacilityID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFacilityID.AppearanceHeader.Options.UseTextOptions = true;
            this.colFacilityID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFacilityID.Caption = "کد";
            this.colFacilityID.FieldName = "FacilityID";
            this.colFacilityID.Name = "colFacilityID";
            this.colFacilityID.OptionsColumn.AllowEdit = false;
            this.colFacilityID.OptionsColumn.FixedWidth = true;
            this.colFacilityID.OptionsColumn.ReadOnly = true;
            this.colFacilityID.OptionsFilter.AllowFilter = false;
            this.colFacilityID.Visible = true;
            this.colFacilityID.VisibleIndex = 5;
            this.colFacilityID.Width = 45;
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
            this.colFacilityName.VisibleIndex = 6;
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
            this.colRequestAmount.VisibleIndex = 7;
            this.colRequestAmount.Width = 50;
            // 
            // dlgHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 331);
            this.Controls.Add(this.gridControl);
            this.Name = "dlgHistory";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryShowRow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colModifiedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colRequestType;
        private DevExpress.XtraGrid.Columns.GridColumn colBranchID;
        private DevExpress.XtraGrid.Columns.GridColumn colBranchName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colFacilityID;
        private DevExpress.XtraGrid.Columns.GridColumn colFacilityName;
        private DevExpress.XtraGrid.Columns.GridColumn colRequestAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colShowRow;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryShowRow;
        private DevExpress.XtraGrid.Columns.GridColumn colRequestSerial;
    }
}