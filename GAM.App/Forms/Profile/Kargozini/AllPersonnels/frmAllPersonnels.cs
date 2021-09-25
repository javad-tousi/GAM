using GAM.Forms.Profile;
using GAM.Forms.Information.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using GAM.Forms.Profile.Etebarat.Library;
using GAM.Dialogs;
using GAM.Modules;
using GAM.Forms.Profile.Kargozini.Library;
using MD.PersianDateTime;
using GAM.Forms.Profile.Kargozini.Personnel;

namespace GAM.Forms.Profile.Kargozini.AllPersonnels
{
    public partial class frmAllPersonnels : DevExpress.XtraEditors.XtraForm
    {
        DataTable TableMaster = new DataTable();

        public frmAllPersonnels()
        {
            InitializeComponent();
            txtSearch.Select();
            Modules.UDF.ToFarsiLanguage();
            Startup();
        }

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            if (gridControl.DataSource != null)
            {
                if (txtSearch.Text.Length > 0)
                {
                    string criteria = string.Format("CONVERT(EmploymentID, 'System.String')='{0}' OR FullName LIKE '%{0}%' OR BranchName LIKE '%{0}%'", txtSearch.Text.Replace("ك", "ک").Replace("ئ", "ی"));
                    (gridControl.DataSource as DataView).RowFilter = criteria;
                }
                else
                    (gridControl.DataSource as DataView).RowFilter = "";
            }
        }

        private void cboSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
                Application.DoEvents();
                PersonelsManager.PersonelsTable.DefaultView.RowFilter = string.Format("PersonnelStatus='{0}'", cboSearchType.Text);
                gridControl.DataSource = PersonelsManager.PersonelsTable.DefaultView;
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            }
            catch (Exception ex)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void repositorybtnShowLog_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
            if (row != null)
            {
                new frmNewPerson(row["EmploymentID"].ToString()).ShowDialog();
            }
        }

        private void Startup()
        {
            try
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgPleaseWait), true, true, false);
                Application.DoEvents();

                if (PersonelsManager.PersonelsTable.Rows.Count == 0)
                    PersonelsManager.Fill();

                cboSearchType.SelectedIndex = 0;
                PersonelsManager.PersonelsTable.DefaultView.RowFilter = string.Format("PersonnelStatus='{0}'", cboSearchType.Text);
                gridControl.DataSource = PersonelsManager.PersonelsTable.DefaultView;
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            }
            catch (Exception ex)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            Application.DoEvents();
            PersonelsManager.PersonelsRules.Clear();
            PersonelsManager.PersonelsTable.Clear();
            Startup();
            txtSearch_EditValueChanged(null, EventArgs.Empty);
            btnRefresh.Enabled = true;
        }

        private void txtSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSearch.ResetText();
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
