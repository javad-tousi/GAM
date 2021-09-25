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
using GAM.Forms.Information;
using MD.PersianDateTime;

namespace GAM.Forms.Reports.Etebarat.Requests
{
    public partial class frmExpertReports : DevExpress.XtraEditors.XtraForm
    {
        public frmExpertReports()
        {
            InitializeComponent();
            FillGridView();
        }

        private void cboReportStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboReportStatus.SelectedIndex == 0)
                colDateEnd.Visible = false;
            if (cboReportStatus.SelectedIndex == 1)
                colDateEnd.Visible = true;

            FillGridView();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillGridView();
        }

        private void FillGridView()
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
            Application.DoEvents();
            gridControl.DataSource = ExpertReportManager.GetExpertReports(null, cboReportStatus.Text);
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void txtSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSearch.ResetText();
        }

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            if (gridControl.DataSource != null)
            {
                if (txtSearch.Text.Length > 0)
                {
                    string criteria = string.Format("CustomerName LIKE '%{0}%' OR ExpertName LIKE '%{0}%' OR BranchName LIKE '%{0}%'", txtSearch.Text);
                    (gridControl.DataSource as DataTable).DefaultView.RowFilter = criteria;
                }
                else
                    (gridControl.DataSource as DataTable).DefaultView.RowFilter = "";
            }
        }

        private void repositoryShowLog_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
            if (row != null)
            {
                dlgDataLogs dlg = new dlgDataLogs(false);
                dlg.FillExpertReportLogs(row);
                dlg.ShowDialog();
            }
        }

        private void repositoryChangeExpertNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
            if (row != null)
            {
                dlgUsersList dlg = new dlgUsersList(Users.GetWorkGroupUsers(false), false);
                DialogResult dlgResult = dlg.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    if (dlg.UserId > 0 & dlg.UserName.Length > 0)
                    {
                        DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                        args.Icon = System.Drawing.SystemIcons.Warning;
                        args.Text = string.Format("آیا از ارجاع گزارش کارشناسی '{0}' به {1} اطمینان کامل حاصل دارید؟", row["CustomerName"].ToString(), Users.GetUserNameWithSexByID(dlg.UserId));
                        args.DefaultButtonIndex = 1;
                        args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                        DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                        if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                        {
                            bool result = ExpertReportManager.UpdateExpertId(row["ID"].ToString(), dlg.UserId);
                            if (result)
                            {
                                dlgDataLogs.AddExpertLog(row["ID"].ToString(), 7, "گزارش کارشناسی به " + Users.GetUserNameWithSexByID(dlg.UserId) + " ارجاع شد");
                                string[] serials = RequestManager.GetSerialsByExpertNo(row["ID"].ToString());
                                dlgDataLogs.AddRequestLog(serials, 7, "گزارش کارشناسی به " + Users.GetUserNameWithSexByID(dlg.UserId) + " ارجاع شد");
                                FillGridView();
                            }
                        }
                    }
                }
            }
        }

        private void btnExportToXlsx_Click(object sender, EventArgs e)
        {
            btnExportToXlsx.Enabled = false;
            Application.DoEvents();
            DevExportToXlsx.SaveAs(gridView);
            btnExportToXlsx.Enabled = true;
        }

        private void repositoryDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
            if (row != null)
            {
                DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args.Icon = System.Drawing.SystemIcons.Warning;
                args.Text = string.Format("آیا از حذف گزارش کارشناسی '{0}' اطمینان کامل حاصل دارید؟", row["CustomerName"].ToString());
                args.DefaultButtonIndex = 1;
                args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    bool result = ExpertReportManager.DeleteById(row["ID"].ToString());
                    if (result)
                    {
                        FillGridView();
                    }
                }
            }
        }
     
        private void gridView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (cboReportStatus.SelectedIndex == 0 & e.RowHandle >= 0)
            {
                string colorName = gridView.GetRowCellValue(e.RowHandle, "Color").ToString();
                if (colorName == "سبز")
                    e.Appearance.BackColor2 = Color.PaleGreen;
                if (colorName == "زرد")
                    e.Appearance.BackColor2 = Color.Yellow;
                if (colorName == "قرمز")
                    e.Appearance.BackColor2 = Color.LightPink;
            }
        }
    
    }
}
