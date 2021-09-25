using GAM.Modules;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using GAM.Forms.Settings.Library;
using System.Collections.Generic;
using DevExpress.XtraEditors.Controls;
using GAM.Dialogs;

namespace GAM.Forms.Reports.Master
{
    public partial class dlgReportsList : DevExpress.XtraEditors.XtraForm
    {
        public DataRow ReportRow { get; set; }

        public dlgReportsList()
        {
            InitializeComponent();
            DataTable tbl = SourceReportsManager.GetReports();
            gridReports.DataSource = tbl;
            listCategory.SelectedIndex = 0;
            txtSearch.Select();
            UDF.ToFarsiLanguage();
        }

        private void listCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch_EditValueChanged(null, EventArgs.Empty);
        }

        private void cboSources_Properties_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 23;
        }

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (gridReports.DataSource == null)
                    return;

                string cateName = listCategory.SelectedValue.ToString();
                string search = string.Format("(Convert(ReportNo, System.String)='{0}' OR [ReportName] LIKE '%{0}%')", txtSearch.Text);

                if (cateName != "همه موارد")
                {
                    search = search + string.Format(" AND ([Category]='{0}')", cateName);
                }
                (gridReports.DataSource as DataTable).DefaultView.RowFilter = search;
                
                txtHelp.ResetText();
                DataRow row = gridview.GetFocusedDataRow();
                if (row != null)
                {
                    txtHelp.Text = row["Help"].ToString();
                }
            }
            catch
            {
                (gridReports.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void txtSearch_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            txtSearch.ResetText();
        }

        private void viewReports_DoubleClick(object sender, EventArgs e)
        {
            btnOk_Click(null, EventArgs.Empty);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DataRow row = gridview.GetDataRow(gridview.FocusedRowHandle);
            if (row != null)
            {
                this.ReportRow = row;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Hide();
            }
        }

        private void btnCancelReport_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void viewReports_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtHelp.ResetText();
            DataRow row = gridview.GetDataRow(e.FocusedRowHandle);
            if (row != null)
            {
                txtHelp.Text = row["Help"].ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
            int categoryId = listCategory.SelectedIndex;
            int rowId = gridview.FocusedRowHandle;

            btnUpdate.Enabled = false;
            Application.DoEvents();
            SourceReportsManager.Fill();
            DataTable tbl = SourceReportsManager.GetReports();
            gridReports.DataSource = tbl;
            listCategory.SelectedIndex = 0;
            listCategory.SelectedIndex = categoryId;
            gridview.FocusedRowHandle = rowId;
            txtSearch_EditValueChanged(null, EventArgs.Empty);
            txtSearch.Select();
            btnUpdate.Enabled = true;
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

    }
}
