using GAM.Forms.Profile.Etebarat.Library;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using GAM.Dialogs;

namespace GAM.Forms.Information
{
    public partial class dlgFacilitysList : DevExpress.XtraEditors.XtraForm
    {

        #region Main Events

        public dlgFacilitysList()
        {
            InitializeComponent();
            txtSearch.Select();
            Modules.UDF.ToFarsiLanguage();
        }

        private void dlgFacilitysList_Shown(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
            Application.DoEvents();
            DataTable table = Facilitys.GetFacilitys();
            for (int i = 0; i < table.Rows.Count; i++)
                table.Rows[i]["IsChecked"] = false;
            gridControl.DataSource = table.AsEnumerable().Where(x => x["IsEnable"].ToString() == bool.TrueString).CopyToDataTable();

            (gridControl.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        #endregion

        #region Properties

        public string FacilityId { get; set; }
        public string FacilityName { get; set; }
        public List<string> ListOfFacilityID { get; set; }

        #endregion

        #region Panel Top

        private void txtSearch_EditValueChanged(object sender, System.EventArgs e)
        {
            if (gridControl.DataSource != null)
            {
                if (Numeral.IsNumber(txtSearch.Text))
                {
                    string criteria = string.Format("CONVERT(FacilityID, 'System.String') = {0}", txtSearch.Text);
                    (gridControl.DataSource as DataTable).DefaultView.RowFilter = criteria;
                }
                else
                {
                    string criteria = string.Format("FacilityName LIKE '%{0}%'", txtSearch.Text);
                    (gridControl.DataSource as DataTable).DefaultView.RowFilter = criteria;
                }
            }
        }

        private void txtSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSearch.ResetText();
            txtSearch.Select();
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
                this.FacilityId = row["FacilityID"].ToString();
                this.FacilityName = row["FacilityName"].ToString();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion

        #region Panel Bottom

        private void btnCheckedFacilitys_Click(object sender, EventArgs e)
        {
            this.ListOfFacilityID = new List<string>();
            for (int i = 0; i < gridView.DataRowCount; i++)
            {
                string isChecked = gridView.GetRowCellValue(i, "Checked").ToString();
                if (isChecked == bool.TrueString)
                {
                    this.ListOfFacilityID.Add(gridView.GetRowCellValue(i, "FacilityID").ToString());
                    this.ListOfFacilityID.Sort();
                }
            }
            if (this.ListOfFacilityID.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("هیچ موردی انتخاب نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            DataTable table = gridControl.DataSource as DataTable;
            foreach (DataRow row in table.Rows)
                row["Checked"] = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataTable table = gridControl.DataSource as DataTable;
            foreach (DataRow row in table.Rows)
                row["Checked"] = false;
        }

        #endregion
    }
}
