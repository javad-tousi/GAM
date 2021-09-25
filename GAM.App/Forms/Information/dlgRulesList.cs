using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using GAM.Dialogs;
using GAM.Forms.Profile.Kargozini.Library;
using GAM.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace GAM.Forms.Information
{
    public partial class dlgRulesList : DevExpress.XtraEditors.XtraForm
    {
        #region Main Events

        public dlgRulesList()
        {
            InitializeComponent();
            txtSearch.Select();
            Modules.UDF.ToFarsiLanguage();
        }

        #endregion

        #region Properties

        public int RuleId { get; set; }
        public string RuleName { get; set; }

        #endregion

        #region Panel Top

        private void txtSearch_EditValueChanged(object sender, System.EventArgs e)
        {
            if (gridControl.DataSource != null)
            {
                try
                {
                    (gridControl.DataSource as DataTable).DefaultView.RowFilter = string.Format("RuleName LIKE '%{0}%' OR Convert([RuleID], System.String) LIKE '%{0}%'", txtSearch.Text);
                }
                catch
                {
                    (gridControl.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                }
            }
        }

        private void txtSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSearch.ResetText();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                gridView.Focus();
            }
        }

        #endregion

        #region GridView

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SetSelectedRow();
            }
        }

        private void gridView_DoubleClick(object sender, System.EventArgs e)
        {
            SetSelectedRow();
        }

        private void SetSelectedRow()
        {
            if (gridView.GetFocusedDataRow() != null)
            {
                DataRow row = gridView.GetFocusedDataRow();
                this.RuleId = Numeral.AnyToInt32(row["RuleID"]);
                this.RuleName = row["RuleName"].ToString();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion

        private void btnExportToXlsx_Click(object sender, EventArgs e)
        {
            btnExportToXlsx.Enabled = false;
            Application.DoEvents();
            DevExportToXlsx.SaveAs(gridView);
            btnExportToXlsx.Enabled = true;
        }

        private void dlgRulesList_Shown(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
            Application.DoEvents();
            gridControl.DataSource = Rules.GetRules();
            gridView.GridControl = gridControl;
            (gridControl.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            txtSearch.Select();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }
    }
}
