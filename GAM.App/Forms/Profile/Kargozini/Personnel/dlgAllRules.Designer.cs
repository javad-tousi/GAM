namespace GAM.Forms.Profile.Kargozini.Personnel
{
    partial class dlgAllRules
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
            DevExpress.XtraGrid.Columns.GridColumn colJobName;
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRuleDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRuleNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRuleType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRuleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBranchName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPostName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonnelStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRuleDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colJobName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // colJobName
            // 
            colJobName.AppearanceCell.Options.UseTextOptions = true;
            colJobName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colJobName.AppearanceHeader.Options.UseTextOptions = true;
            colJobName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colJobName.Caption = "شغل";
            colJobName.FieldName = "JobName";
            colJobName.Name = "colJobName";
            colJobName.OptionsColumn.AllowEdit = false;
            colJobName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            colJobName.OptionsColumn.FixedWidth = true;
            colJobName.OptionsColumn.ReadOnly = true;
            colJobName.OptionsFilter.AllowFilter = false;
            colJobName.Visible = true;
            colJobName.VisibleIndex = 5;
            colJobName.Width = 150;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(736, 363);
            this.gridControl.TabIndex = 7;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRuleDate,
            this.colRuleNo,
            this.colRuleType,
            this.colRuleName,
            this.colBranchName,
            colJobName,
            this.colPostName,
            this.colPersonnelStatus,
            this.colRuleDescription});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsSelection.CheckBoxSelectorColumnWidth = 25;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.RowHeight = 23;
            // 
            // colRuleDate
            // 
            this.colRuleDate.AppearanceCell.Options.UseTextOptions = true;
            this.colRuleDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRuleDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colRuleDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRuleDate.Caption = "تاریخ اجرا";
            this.colRuleDate.DisplayFormat.FormatString = "0000/00/00";
            this.colRuleDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRuleDate.FieldName = "RuleDate";
            this.colRuleDate.Name = "colRuleDate";
            this.colRuleDate.OptionsColumn.AllowEdit = false;
            this.colRuleDate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colRuleDate.OptionsColumn.FixedWidth = true;
            this.colRuleDate.OptionsColumn.ReadOnly = true;
            this.colRuleDate.OptionsFilter.AllowFilter = false;
            this.colRuleDate.Visible = true;
            this.colRuleDate.VisibleIndex = 0;
            this.colRuleDate.Width = 80;
            // 
            // colRuleNo
            // 
            this.colRuleNo.AppearanceCell.Options.UseTextOptions = true;
            this.colRuleNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRuleNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colRuleNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRuleNo.Caption = "شماره";
            this.colRuleNo.FieldName = "RuleNo";
            this.colRuleNo.Name = "colRuleNo";
            this.colRuleNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colRuleNo.OptionsColumn.ReadOnly = true;
            this.colRuleNo.OptionsFilter.AllowFilter = false;
            this.colRuleNo.Visible = true;
            this.colRuleNo.VisibleIndex = 1;
            this.colRuleNo.Width = 86;
            // 
            // colRuleType
            // 
            this.colRuleType.AppearanceCell.Options.UseTextOptions = true;
            this.colRuleType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRuleType.AppearanceHeader.Options.UseTextOptions = true;
            this.colRuleType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRuleType.Caption = "نوع حکم";
            this.colRuleType.FieldName = "RuleType";
            this.colRuleType.Name = "colRuleType";
            this.colRuleType.OptionsColumn.AllowEdit = false;
            this.colRuleType.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colRuleType.OptionsColumn.FixedWidth = true;
            this.colRuleType.OptionsColumn.ReadOnly = true;
            this.colRuleType.OptionsFilter.AllowFilter = false;
            this.colRuleType.Visible = true;
            this.colRuleType.VisibleIndex = 2;
            this.colRuleType.Width = 73;
            // 
            // colRuleName
            // 
            this.colRuleName.AppearanceCell.Options.UseTextOptions = true;
            this.colRuleName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRuleName.AppearanceHeader.Options.UseTextOptions = true;
            this.colRuleName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRuleName.Caption = "موضوع";
            this.colRuleName.FieldName = "RuleName";
            this.colRuleName.Name = "colRuleName";
            this.colRuleName.OptionsColumn.AllowEdit = false;
            this.colRuleName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colRuleName.OptionsColumn.FixedWidth = true;
            this.colRuleName.OptionsColumn.ReadOnly = true;
            this.colRuleName.OptionsFilter.AllowFilter = false;
            this.colRuleName.Visible = true;
            this.colRuleName.VisibleIndex = 3;
            this.colRuleName.Width = 195;
            // 
            // colBranchName
            // 
            this.colBranchName.AppearanceCell.Options.UseTextOptions = true;
            this.colBranchName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBranchName.AppearanceHeader.Options.UseTextOptions = true;
            this.colBranchName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBranchName.Caption = "واحد سازمانی";
            this.colBranchName.FieldName = "BranchName";
            this.colBranchName.Name = "colBranchName";
            this.colBranchName.OptionsColumn.AllowEdit = false;
            this.colBranchName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colBranchName.OptionsColumn.FixedWidth = true;
            this.colBranchName.OptionsColumn.ReadOnly = true;
            this.colBranchName.OptionsFilter.AllowFilter = false;
            this.colBranchName.Visible = true;
            this.colBranchName.VisibleIndex = 4;
            this.colBranchName.Width = 157;
            // 
            // colPostName
            // 
            this.colPostName.AppearanceCell.Options.UseTextOptions = true;
            this.colPostName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPostName.AppearanceHeader.Options.UseTextOptions = true;
            this.colPostName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPostName.Caption = "پست";
            this.colPostName.FieldName = "PostName";
            this.colPostName.Name = "colPostName";
            this.colPostName.OptionsColumn.AllowEdit = false;
            this.colPostName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPostName.OptionsColumn.FixedWidth = true;
            this.colPostName.OptionsColumn.ReadOnly = true;
            this.colPostName.OptionsFilter.AllowFilter = false;
            this.colPostName.Visible = true;
            this.colPostName.VisibleIndex = 6;
            this.colPostName.Width = 150;
            // 
            // colPersonnelStatus
            // 
            this.colPersonnelStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colPersonnelStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPersonnelStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colPersonnelStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPersonnelStatus.Caption = "وضعیت";
            this.colPersonnelStatus.FieldName = "PersonnelStatus";
            this.colPersonnelStatus.Name = "colPersonnelStatus";
            this.colPersonnelStatus.OptionsColumn.AllowEdit = false;
            this.colPersonnelStatus.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPersonnelStatus.OptionsColumn.FixedWidth = true;
            this.colPersonnelStatus.OptionsColumn.ReadOnly = true;
            this.colPersonnelStatus.OptionsFilter.AllowFilter = false;
            this.colPersonnelStatus.Visible = true;
            this.colPersonnelStatus.VisibleIndex = 7;
            this.colPersonnelStatus.Width = 129;
            // 
            // colRuleDescription
            // 
            this.colRuleDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colRuleDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRuleDescription.Caption = "توضیحات";
            this.colRuleDescription.FieldName = "RuleDescription";
            this.colRuleDescription.Name = "colRuleDescription";
            this.colRuleDescription.OptionsColumn.AllowEdit = false;
            this.colRuleDescription.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colRuleDescription.OptionsColumn.FixedWidth = true;
            this.colRuleDescription.OptionsColumn.ReadOnly = true;
            this.colRuleDescription.OptionsFilter.AllowFilter = false;
            this.colRuleDescription.Visible = true;
            this.colRuleDescription.VisibleIndex = 8;
            this.colRuleDescription.Width = 250;
            // 
            // dlgAllRules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 363);
            this.Controls.Add(this.gridControl);
            this.MinimizeBox = false;
            this.Name = "dlgAllRules";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colRuleType;
        private DevExpress.XtraGrid.Columns.GridColumn colRuleDate;
        private DevExpress.XtraGrid.Columns.GridColumn colBranchName;
        private DevExpress.XtraGrid.Columns.GridColumn colRuleName;
        private DevExpress.XtraGrid.Columns.GridColumn colRuleDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colPostName;
        private DevExpress.XtraGrid.Columns.GridColumn colRuleNo;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonnelStatus;
    }
}