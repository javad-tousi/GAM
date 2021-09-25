using GAM.Dialogs;
using GAM.Modules;
using GAM.Forms.Information;
using GAM.Forms.Information.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using GAM.Forms.Settings.Library;
using MD.PersianDateTime;
using GAM.Forms.Profile.LegalFile.NewFile;
using GAM.Forms.Profile;
using GAM.Forms.Profile.LegalFile.Library;

namespace GAM.Forms.Profile.Hoghoghi.Circulation
{
    public partial class frmCirculationLegalFiles : DevExpress.XtraEditors.XtraForm
    {
        public frmCirculationLegalFiles()
        {
            InitializeComponent();
            Modules.UDF.ToFarsiLanguage();
            Startup();
        }

        private void repositoryShowLog_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
            if (row != null)
            {
                dlgDataLogs dlg = new dlgDataLogs(false);
                dlg.FillLegalFileLogs(row);
                dlg.ShowDialog();
            }
        }

        private void repositoryEditRequest_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
            if (row != null)
                new frmNewLegalFile(row).Show();
        }

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            if (gridControl.DataSource != null)
            {
                if (txtSearch.Text.Length > 0)
                {
                    string criteria = string.Format("CONVERT(ContractID, 'System.String')='{0}' OR FileID='{0}' OR CONVERT(IndicatorID, 'System.String')='{0}' OR CustomerName LIKE '%{0}%' OR BranchName LIKE '%{0}%'", txtSearch.Text.Replace("ك", "ک").Replace("ئ", "ی"));
                    (gridControl.DataSource as DataTable).DefaultView.RowFilter = criteria;
                }
                else
                    (gridControl.DataSource as DataTable).DefaultView.RowFilter = "";
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
            {
                txtSearch.ResetText();
            }
        }

        private void Startup()
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
            Application.DoEvents();
            gridControl.DataSource = LegalFilesManager.GetLegalFilesByFileStatus("*", cboFileStatus.SelectedIndex);
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Startup();
        }

        private void txtSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSearch.ResetText();
            (gridControl.DataSource as DataTable).DefaultView.RowFilter = "";
        }

        private void gridView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DataRow row = gridView.GetDataRow(e.RowHandle);
                e.Appearance.BackColor2 = LegalFilesManager.GetRowColor(row);
            }
        }

        private void cboFileStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Startup();
        }

        private void btnExportToXlsx_Click(object sender, EventArgs e)
        {
            btnExportToXlsx.Enabled = false;
            Application.DoEvents();
            DevExportToXlsx.SaveAs(gridView);
            btnExportToXlsx.Enabled = true;
        }
    }
}
