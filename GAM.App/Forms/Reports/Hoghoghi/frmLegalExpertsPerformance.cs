using GAM.Dialogs;
using GAM.Forms.Profile.Etebarat.Library;
using GAM.Forms.Profile.LegalFile.Library;
using GAM.Forms.Settings.Library;
using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Reports.Hoghoghi
{
    public partial class frmLegalExpertsPerformance : DevExpress.XtraEditors.XtraForm
    {
        public frmLegalExpertsPerformance()
        {
            InitializeComponent();
            txtFromDate.Value = new PersianDateTime(1399, 1, 1);
            txtToDate.Value = Network.GetNowPersianDate();
        }

        private void btnShowQuery_Click(object sender, EventArgs e)
        {
            if (txtFromDate.Value.HasValue & txtToDate.Value.HasValue)
            {
                int dateFrom = int.Parse(txtFromDate.GetText("yyyyMMdd"));
                int dateTo = int.Parse(txtToDate.GetText("yyyyMMdd"));
                if (dateTo >= dateFrom)
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
                    btnShowQuery.Enabled = false;
                    Application.DoEvents();
                    gridControl.DataSource = LegalFilesManager.GetLegalExpertsPerformance(dateFrom, dateTo, cboReportType.Text);
                    btnShowQuery.Enabled = true;
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                }
                else
                    DevExpress.XtraEditors.XtraMessageBox.Show("تاریخ مقصد می بایست کوچکتر از تاریخ مبدا باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("لطفا مقادیر تاریخ را وارد نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnExportToXlsx_Click(object sender, EventArgs e)
        {
            if (gridView.DataSource != null)
            {
                DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG;
                btnExportToXlsx.Enabled = false;
                Application.DoEvents();
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Title = "Save Report";
                saveDlg.Filter = "Excel File|*.xlsx";
                saveDlg.ShowDialog();
                if (saveDlg.FileName != "")
                {
                    gridControl.MainView.ExportToXlsx(saveDlg.FileName);
                    System.Diagnostics.Process.Start(saveDlg.FileName);
                }
                btnExportToXlsx.Enabled = true;
            }
        }
    }
}
