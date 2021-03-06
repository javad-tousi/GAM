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
using GAM.Forms.Profile.LegalFile.Library;
using GAM.Forms.Profile.LegalFile.NewFile;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using GAM.Forms.Settings.Library;
using MD.PersianDateTime;

namespace GAM.Forms.Profile.LegalFile.MyFiles
{
    public partial class frmMyLegalFiles : DevExpress.XtraEditors.XtraForm
    {
        public frmMyLegalFiles()
        {
            InitializeComponent();
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

        private void btnExportToXlsx_Click(object sender, EventArgs e)
        {
            btnExportToXlsx.Enabled = false;
            Application.DoEvents();
            DevExportToXlsx.SaveAs(gridView);
            btnExportToXlsx.Enabled = true;
        }

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            if (gridControl.DataSource != null)
            {
                if (txtSearch.Text.Length > 0)
                {
                    string criteria = string.Format("CONVERT(ContractID, 'System.String')='{0}' OR FileID='{0}' OR CONVERT(IndicatorID, 'System.String')='{0}' OR CONVERT(CustomerName, 'System.String') LIKE '%{0}%' OR BranchName LIKE '%{0}%'", txtSearch.Text);
                    (gridControl.DataSource as DataTable).DefaultView.RowFilter = criteria;
                }
                else
                    (gridControl.DataSource as DataTable).DefaultView.RowFilter = "";
            }
        }

        private void cboFileStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
            Application.DoEvents();
            gridControl.DataSource = LegalFilesManager.GetLegalFilesByFileStatus(Users.MyUserID.ToString(), cboFileStatus.SelectedIndex);
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void frmMyLegalFiles_Shown(object sender, EventArgs e)
        {
            cboFileStatus.SelectedIndex = 0;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cboFileStatus_SelectedIndexChanged(null, EventArgs.Empty);
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

    }
}
