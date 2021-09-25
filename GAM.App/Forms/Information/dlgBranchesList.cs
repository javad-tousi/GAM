using System.Data;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using GAM.Forms.Information.Library;
using GAM.Dialogs;
using GAM.Modules;

namespace GAM.Forms.Information
{
    public partial class dlgBranchesList : DevExpress.XtraEditors.XtraForm
    {
        public string BranchId { get; set; }
        public string BranchName { get; set; }
       
        public dlgBranchesList()
        {
            InitializeComponent();
            Modules.UDF.ToFarsiLanguage();
            Startup();
            txtSearchInBranches.Select();
        }

        #region Search

        private void txtSearchInCounters_EditValueChanged(object sender, System.EventArgs e)
        {
            if (gridControl1.DataSource != null)
            {
                try
                {
                    (gridControl1.DataSource as DataTable).DefaultView.RowFilter = string.Format("CounterName LIKE '%{0}%' OR Convert([CounterId], System.String) LIKE '%{0}%'", txtSearchInCounters.Text);
                }
                catch
                {
                    (gridControl1.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                }
            }
        }

        private void txtSearchInBranches_EditValueChanged(object sender, System.EventArgs e)
        {
            if (gridControl2.DataSource != null)
            {
                try
                {
                    (gridControl2.DataSource as DataTable).DefaultView.RowFilter = string.Format("BranchName LIKE '%{0}%' OR Convert([BranchId], System.String) LIKE '%{0}%'", txtSearchInBranches.Text);
                }
                catch
                {
                    (gridControl2.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                }
            }
        }

        private void txtSearchInDomains_EditValueChanged(object sender, System.EventArgs e)
        {
            if (gridControl3.DataSource != null)
            {
                try
                {
                    (gridControl3.DataSource as DataTable).DefaultView.RowFilter = string.Format("DomainName LIKE '%{0}%' OR Convert([DomainId], System.String) LIKE '%{0}%'", txtSearchInDomains.Text);
                }
                catch
                {
                    (gridControl3.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                }
            }
        }

        private void txtSearchInOffices_EditValueChanged(object sender, System.EventArgs e)
        {
            if (gridControl4.DataSource != null)
            {
                try
                {
                    string criteria = string.Format("OfficeName LIKE '%{0}%' OR Convert([OfficeId], System.String) LIKE '%{0}%'", txtSearchInOffices.Text);
                    (gridControl4.DataSource as DataTable).DefaultView.RowFilter = criteria;
                }
                catch
                {
                    (gridControl4.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                }
            }
        }
        
        #endregion

        private void repositorybtnTellsInfo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
           if (row != null)
           {
               new dlgEditPhones(row["BranchID"].ToString()).ShowDialog();
           }
        }

        #region Clear Filter

        private void txtSearchInCounters_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSearchInCounters.ResetText();
        }

        private void txtSearchInBranches_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSearchInBranches.ResetText();
        }

        private void txtSearchInDomains_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSearchInDomains.ResetText();
        }

        private void txtSearchInOffices_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSearchInOffices.ResetText();
        } 
        #endregion

        #region Exports

        private void btnExportToXlsx1_Click(object sender, System.EventArgs e)
        {
            btnExportToXlsx1.Enabled = false;
            Application.DoEvents();
            DevExportToXlsx.SaveAs(gridView2);
            btnExportToXlsx1.Enabled = true;
        }

        private void btnExportToXlsx2_Click(object sender, System.EventArgs e)
        {
            btnExportToXlsx2.Enabled = false;
            Application.DoEvents();
            DevExportToXlsx.SaveAs(gridView2);
            btnExportToXlsx2.Enabled = true;
        }

        private void btnExportToXlsx3_Click(object sender, System.EventArgs e)
        {
            btnExportToXlsx3.Enabled = false;
            Application.DoEvents();
            DevExportToXlsx.SaveAs(gridView2);
            btnExportToXlsx3.Enabled = true;
        }

        private void btnExportToXlsx4_Click(object sender, System.EventArgs e)
        {
            btnExportToXlsx4.Enabled = false;
            Application.DoEvents();
            DevExportToXlsx.SaveAs(gridView2);
            btnExportToXlsx4.Enabled = true;
        }
        
        #endregion

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                gridView2.Focus();
            }
        }

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SetSelectedRow((GridView)sender);
            }
        }

        private void gridView_DoubleClick(object sender, System.EventArgs e)
        {
            SetSelectedRow((GridView)sender);
        }

        private void SetSelectedRow(GridView gv)
        {
            if (gv.GetFocusedDataRow() != null)
            {
                DataRow row = gv.GetFocusedDataRow();
                if (tabControl.SelectedTabPageIndex == 0)
                {
                    this.BranchId = row["CounterID"].ToString();
                    this.BranchName = row["CounterName"].ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                if (tabControl.SelectedTabPageIndex == 1)
                {
                    this.BranchId = row["BranchID"].ToString();
                    this.BranchName = row["BranchName"].ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                if (tabControl.SelectedTabPageIndex == 2)
                {
                    this.BranchId = row["DomainID"].ToString();
                    this.BranchName = row["DomainName"].ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                if (tabControl.SelectedTabPageIndex == 3)
                {
                    this.BranchId = row["OfficeID"].ToString();
                    this.BranchName = row["OfficeName"].ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void Startup()
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
            Application.DoEvents();
            gridControl1.DataSource = Branches.CountersInfo;
            gridView1.GridControl = gridControl1;

            gridControl2.DataSource = Branches.BranchesInfo;
            gridView2.GridControl = gridControl2;

            gridControl3.DataSource = Branches.DomainsInfo;
            gridView3.GridControl = gridControl3;

            gridControl4.DataSource = Branches.OfficesInfo;
            gridView4.GridControl = gridControl4;

            (gridControl2.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            txtSearchInBranches.Select();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void gridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                string value = gridView2.GetRowCellValue(e.RowHandle, "BranchDegree").ToString();
                if (value.Contains("ممتاز"))
                    e.Appearance.BackColor2 = System.Drawing.Color.Lavender;
            }
        }
    }
}
