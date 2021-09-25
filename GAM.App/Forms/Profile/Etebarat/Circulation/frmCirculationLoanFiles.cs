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

namespace GAM.Forms.Profile.Etebarat.Circulation
{
    public partial class frmCirculationLoanFiles : DevExpress.XtraEditors.XtraForm
    {
        internal static event System.EventHandler LoadEvent;

        public frmCirculationLoanFiles()
        {
            InitializeComponent();
            LoadEvent += this_LoadEvent;
            txtSearch.Select();
            Modules.UDF.ToFarsiLanguage();
        }

        internal static void RaiseLoadEvent()
        {
            System.EventHandler handler = LoadEvent;
            if (handler != null)
            {
                handler(null, null);
            }
        }

        private void this_LoadEvent(object sender, EventArgs e)
        {
            FillGridView();
        }

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            if (gridControl.DataSource != null)
            {
                string criteria = string.Format("CONVERT(CustomerName2, 'System.String') LIKE '%{0}%' OR " + "BranchName LIKE '%{1}%' OR " + "CONVERT(RequestID, 'System.String') LIKE '%{1}%'", txtSearch.Text.Replace("آ", "ا").Replace("ئ", "ی").Replace(" ", ""), txtSearch.Text.Replace("ئ", "ی"));
                (gridControl.DataSource as DataTable).DefaultView.RowFilter = criteria;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillGridView();
        }

        private void cboSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridControl.DataSource = null;
            txtSearch.ResetText();

            if (cboSearchType.Text == "دو هفته گذشته")
            {
                txtSearch.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
                txtSearch.Properties.NullValuePrompt = "نام متقاضی / نام شعبه";
                txtSearch.Properties.Buttons[0].Visible = false;
                btnSearch.Enabled = false;
                btnRefresh.Enabled = true;
                Application.DoEvents();
            }
            if (cboSearchType.Text == "یک ماه گذشته")
            {
                txtSearch.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
                txtSearch.Properties.NullValuePrompt = "نام متقاضی / نام شعبه";
                btnSearch.Enabled = false;
                btnRefresh.Enabled = true;
                Application.DoEvents();
            }
            if (cboSearchType.Text == "کدشعبه (یک سال)")
            {
                txtSearch.ResetText();
                txtSearch.Properties.NullValuePrompt = "کد شعبه (5 رقمی)";
                btnSearch.Enabled = true;
                btnRefresh.Enabled = false;
                gridControl.DataSource = null;
            }
            if (cboSearchType.Text == "شماره پیشنهاد")
            {
                txtSearch.ResetText();
                txtSearch.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                txtSearch.Properties.Mask.EditMask = @"\d+";
                txtSearch.Properties.NullValuePrompt = "شماره پیشنهاد";
                btnSearch.Enabled = true;
                btnRefresh.Enabled = false;
                gridControl.DataSource = null;
            }

            FillGridView();
        }

        private void repositorybtnShowLog_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
            if (row != null)
            {
                dlgDataLogs dlg = new dlgDataLogs(false);
                dlg.FillLoanFileLogs(row);
                dlg.ShowDialog();
            }
        }

        private void FillGridView() 
        {
            if (cboSearchType.Text.Length > 0)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
                Application.DoEvents(); 
                
                if (cboSearchType.Text == "دو هفته گذشته")
                    gridControl.DataSource = RequestManager.GetAllByModifiedDate(PersianDate.Now.AddDays(-14).ToSerial(), PersianDate.Now.ToSerial());
                if (cboSearchType.Text == "یک ماه گذشته")
                    gridControl.DataSource = RequestManager.GetAllByModifiedDate(PersianDate.Now.AddDays(-30).ToSerial(), PersianDate.Now.ToSerial());
                if (cboSearchType.Text == "شماره پیشنهاد" & txtSearch.Text.Length > 0)
                    gridControl.DataSource = RequestManager.GetRequestById(Numeral.AnyToLong(txtSearch.Text));
                if (cboSearchType.Text == "کدشعبه (یک سال)" & txtSearch.Text.Length > 0)
                {
                    gridControl.DataSource = RequestManager.GetAllByModifiedDateAndBranchID(PersianDate.Now.AddDays(-365).ToSerial(), PersianDate.Now.ToSerial(), Numeral.AnyToInt32(txtSearch.Text));
                    txtSearch.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
                    txtSearch.Properties.NullValuePrompt = "کد شعبه (5 رقمی) / نام متقاضی";
                    txtSearch.ResetText();
                    txtSearch.Select();
                    Application.DoEvents();
                }
                txtSearch_EditValueChanged(null, EventArgs.Empty);

                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            }

        }

        private void btnExportToXlsx_Click(object sender, EventArgs e)
        {
            btnExportToXlsx.Enabled = false;
            Application.DoEvents();
            DevExportToXlsx.SaveAs(gridView);
            btnExportToXlsx.Enabled = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillGridView();
        }

        private void txtSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSearch.ResetText();
        }
      
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
            {
                txtSearch.ResetText();
            }
        }
    }
}
