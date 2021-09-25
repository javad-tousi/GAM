using GAM.Dialogs;
using GAM.Modules;
using GAM.Forms.Information;
using GAM.Forms.Information.Library;
using GAM.Forms.Profile.Etebarat.Library;
using GAM.Forms.Profile.Etebarat.Print;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using GAM.Forms.Profile.Etebarat.Review;
using GAM.Forms.Settings.Library;
using System.Data.OleDb;
using GAM.Connections;
using GAM.Forms.Main;
using DevExpress.XtraTab;

namespace GAM.Forms.Profile.Etebarat.MyFiles
{
    public partial class frmMyLoanFiles : DevExpress.XtraEditors.XtraForm
    {
        internal static event System.EventHandler LoadEvent;
        private BackgroundWorker bw = new BackgroundWorker();
        frmMain frmMain;
        DataTable table1;
        DataTable table2;
        DataTable table3;

        public frmMyLoanFiles(frmMain frm)
        {
            InitializeComponent();
            UDF.ToFarsiLanguage();
            frmMain = frm;
            LoadEvent += this_LoadEvent;
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
        }
      
        public void FillGridView()
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
            Application.DoEvents(); 
                
            if (tabControl.SelectedTabPageIndex == 0)
                this.table1 = RequestManager.GetRequests(Users.MyUserID, cboRequestStatus.Text);
            if (tabControl.SelectedTabPageIndex == 1)
                this.table2 = ReviewReportManager.GetReviewReports(Users.MyUserID, cboRequestStatus.Text);
            if (tabControl.SelectedTabPageIndex == 2)
                this.table3 = ExpertReportManager.GetExpertReports(Users.MyUserID, cboRequestStatus.Text);
        }

        #region Events


        private void btnAddReviewFrm_Click(object sender, EventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            if (row != null)
            {
                if (row["ReviewNo"].ToString().Length == 0)
                {
                   frmReviewLoanFile frm = new frmReviewLoanFile();
                   frmMain.AddTabPage(frm.pnlMain, "بررسی پیشنهاد اعتباری", DevExpress.Images.ImageResourceCache.Default.GetImage("images/richedit/pencolor_16x16.png"), true);
                   dlgAddRequest dlg = new dlgAddRequest(frm, row["RequestID"].ToString(), row["RequestSerial"].ToString(), true);
                   dlg.ShowDialog();
                }
                else 
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(string.Format("برای این پیشنهاد قبلا فرم بررسی به شماره {0} ایجاد گردیده است", row["ReviewNo"].ToString()), "راهنما", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void repositoryShowRequestLogs_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (row != null)
            {
                dlgDataLogs dlg = new dlgDataLogs(false);
                dlg.FillLoanFileLogs(row);
                dlg.ShowDialog();
            }
        }
     
        private void repositoryExpertReportLogs_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow row = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (row != null)
            {
                dlgDataLogs dlg = new dlgDataLogs(false);
                dlg.FillExpertReportLogs(row);
                dlg.ShowDialog();
            }
        }

        private void btnExportToXlsx_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTabPage == tabPage1)
            {
                btnExportToXlsx.Enabled = false;
                Application.DoEvents();
                DevExportToXlsx.SaveAs(gridView1);
                btnExportToXlsx.Enabled = true;
            }
            if (tabControl.SelectedTabPage == tabPage2)
            {
                btnExportToXlsx.Enabled = false;
                Application.DoEvents();
                DevExportToXlsx.SaveAs(gridView2);
                btnExportToXlsx.Enabled = true;
            }
            if (tabControl.SelectedTabPage == tabPage3)
            {
                btnExportToXlsx.Enabled = false;
                Application.DoEvents();
                DevExportToXlsx.SaveAs(gridView3);
                btnExportToXlsx.Enabled = true;
            }
        }

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTabPage == tabPage1)
            {
                if (gridControl1.DataSource != null)
                {
                    if (txtSearch.Text.Length > 0)
                    {
                        string criteria = string.Format("CONVERT(RequestID, 'System.String') LIKE '%{0}%' OR CustomerName LIKE '%{0}%' OR BranchName LIKE '%{0}%'", txtSearch.Text);
                        (gridControl1.DataSource as DataTable).DefaultView.RowFilter = criteria;
                    }
                    else
                        (gridControl1.DataSource as DataTable).DefaultView.RowFilter = "";
                }
            }
            if (tabControl.SelectedTabPage == tabPage2)
            {
                if (gridControl2.DataSource != null)
                {
                    if (txtSearch.Text.Length > 0)
                    {
                        string criteria = string.Format("CONVERT(ReviewNo, 'System.String')='{0}' OR CustomerName LIKE '%{0}%' OR BranchName LIKE '%{0}%'", txtSearch.Text);
                        (gridControl2.DataSource as DataTable).DefaultView.RowFilter = criteria;
                    }
                    else
                        (gridControl2.DataSource as DataTable).DefaultView.RowFilter = "";
                }
            }
            if (tabControl.SelectedTabPage == tabPage3)
            {
                if (gridControl3.DataSource != null)
                {
                    if (txtSearch.Text.Length > 0)
                    {
                        string criteria = string.Format("CONVERT(ExpertNo, 'System.String') = '%{0}%' OR CustomerName LIKE '%{0}%' OR BranchName LIKE '%{0}%'", txtSearch.Text);
                        (gridControl3.DataSource as DataTable).DefaultView.RowFilter = criteria;
                    }
                    else
                        (gridControl3.DataSource as DataTable).DefaultView.RowFilter = "";
                }
            }
        }

        private void cboRequestStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            this_LoadEvent(null, EventArgs.Empty);
            if (cboRequestStatus.SelectedIndex == 0)
            {
                colEditReviewReport.Visible = true;
                colEditReviewReport.VisibleIndex = 0;
                colShowReviewReport.Visible = false;
                btnStartReview.Enabled = false;
                if (tabControl.SelectedTabPage == tabPage3)
                    btnAddNote.Enabled = true;
                btnEndReview.Enabled = true;
                btnAddReviewFrm.Enabled = true;
            }
            if (cboRequestStatus.SelectedIndex == 1)
            {
                colEditReviewReport.Visible = false;
                colShowReviewReport.Visible = true;
                colShowReviewReport.VisibleIndex = 0;
                btnStartReview.Enabled = true;
                btnAddNote.Enabled = false;
                btnEndReview.Enabled = false;
                btnAddReviewFrm.Enabled = false;
            }
            txtSearch_EditValueChanged(null, EventArgs.Empty);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this_LoadEvent(null, EventArgs.Empty);
        }

        private void txtSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSearch.ResetText();
            (gridControl1.DataSource as DataTable).DefaultView.RowFilter = "";
        }

        private void btnChangeExpert_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTabPage == tabPage1)
            {
                DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
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
                            args.Text = string.Format("آیا از ارجاع پیشنهاد '{0}' به {1} اطمینان کامل حاصل دارید؟", row["CustomerName"].ToString(), Users.GetUserNameWithSexByID(dlg.UserId));
                            args.DefaultButtonIndex = 1;
                            args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                            DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                            if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                            {
                                string serial = row["RequestSerial"].ToString();
                                bool queryResult = RequestManager.UpdateExpertId(serial, dlg.UserId);
                                if (queryResult)
                                {
                                    if (row["ReviewNo"].ToString().Length > 0)
                                        ReviewReportManager.UpdateExpertId(ChkSum.DelCheck(row["ReviewNo"].ToString()), dlg.UserId);
                                    dlgDataLogs.AddRequestLog(serial, 7, "پیشنهاد به " + Users.GetUserNameWithSexByID(dlg.UserId) + " ارجاع شد");
                                    DevExpress.XtraEditors.XtraMessageBox.Show("عملیات ارجاع با موفقیت انجام شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this_LoadEvent(null, EventArgs.Empty);
                                }
                            }
                        }
                    }
                }
            }

            if (tabControl.SelectedTabPage == tabPage2)
            {
                DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
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
                            args.Text = string.Format("آیا از ارجاع فرم بررسی '{0}' به {1} اطمینان کامل حاصل دارید؟", row["CustomerName"].ToString(), Users.GetUserNameWithSexByID(dlg.UserId));
                            args.DefaultButtonIndex = 1;
                            args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                            DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                            if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                            {
                                bool result = ReviewReportManager.UpdateExpertId(row["ID"].ToString(), dlg.UserId);
                                if (result)
                                {
                                    DataTable tbl = UDF.GetXmlToDatatable(row["XmlRequests"].ToString());
                                    if (tbl != null)
                                    {
                                        List<string> serials = new List<string>();
                                        foreach (DataRow r in tbl.Rows)
                                        {
                                            string serial = r["RequestSerial"].ToString();
                                            serials.Add(serial);
                                        }
                                        if (serials.Count > 0)
                                        {
                                            bool queryResult = RequestManager.UpdateExpertId(serials.ToArray(), dlg.UserId);
                                            if (queryResult)
                                            {
                                                dlgDataLogs.AddRequestLog(serials.ToArray(), 7, "پیشنهاد به " + Users.GetUserNameWithSexByID(dlg.UserId) + " ارجاع شد");
                                                DevExpress.XtraEditors.XtraMessageBox.Show("عملیات ارجاع با موفقیت انجام شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }

                                        }

                                        this_LoadEvent(null, EventArgs.Empty);
                                    }
                                }

                            }
                        }
                    }
                }
            }

            if (tabControl.SelectedTabPage == tabPage3)
            {
                DataRow row = gridView3.GetDataRow(gridView3.FocusedRowHandle);
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
                                  
                                    this_LoadEvent(null, EventArgs.Empty);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            DataRow row = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (row != null)
            {
                dlgAddExpertReportNote dlg = new dlgAddExpertReportNote(row["CustomerName"].ToString());
                DialogResult dlgRes = dlg.ShowDialog();
                if (dlgRes == System.Windows.Forms.DialogResult.OK)
                {
                    btnAddNote.Enabled = false;
                    Application.DoEvents();
                    bool queryResult = false;
                    if (dlg.FinishReport)
                        queryResult = ExpertReportManager.UpdateLastAction(row["ID"].ToString(), dlg.Message, dlg.DateAction, Network.GetNowDateSerial());
                    else
                        queryResult = ExpertReportManager.UpdateLastAction(row["ID"].ToString(), dlg.Message, dlg.DateAction, null);

                    if (dlg.CloseReport)
                        ExpertReportManager.UpdateDateEnd(row["ID"].ToString(), Network.GetNowDateSerial());

                    if (queryResult)
                    {
                        dlgDataLogs.AddExpertLog(row["ID"].ToString(), dlg.ActionID, dlg.Message);
                        string[] serials = RequestManager.GetSerialsByExpertNo(row["ID"].ToString());
                        dlgDataLogs.AddRequestLog(serials, dlg.ActionID, dlg.Message);
                        DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات شما با موفقیت ثبت شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
               
                    this_LoadEvent(null, EventArgs.Empty);
                    btnAddNote.Enabled = true;
                }
            }
        }

        private void btnEndReview_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTabPage == tabPage1)
            {
                DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                if (row != null)
                {
                    if (row["ReviewNo"].ToString().Length > 0)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("این پیشنهاد دارای فرم بررسی می باشد لطفاً برای مختومه نمودن فرم بررسی آن را مختومه نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dlgRejectLoanFile dlg = new dlgRejectLoanFile(row["CustomerName"].ToString());
                    DialogResult dlgRes = dlg.ShowDialog();
                    if (dlgRes == System.Windows.Forms.DialogResult.OK)
                    {
                        btnEndReview.Enabled = false;
                        Application.DoEvents();
                        bool queryResult = RequestManager.UpdateDateEnd(row["RequestSerial"].ToString(), Network.GetNowDateSerial());
                        if (queryResult)
                            dlgDataLogs.AddRequestLog(row["RequestSerial"].ToString(), 11, dlg.Message);
                     
                        this_LoadEvent(null, EventArgs.Empty);
                        btnEndReview.Enabled = true;
                    }
                }
            }

            if (tabControl.SelectedTabPage == tabPage2)
            {
                DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                if (row != null)
                {
                    DialogResult dlgRes = new dlgRejectLoanFile(row["CustomerName"].ToString()).ShowDialog();
                    if (dlgRes == System.Windows.Forms.DialogResult.OK)
                    {
                        btnEndReview.Enabled = false;
                        Application.DoEvents();
                        bool queryResult = ReviewReportManager.UpdateDateEnd(row["ID"].ToString(), int.Parse(row["ReferralDate"].ToString()), Network.GetNowDateSerial());
                        if (queryResult)
                        {
                            DataTable tbl = UDF.GetXmlToDatatable(row["XmlRequests"].ToString());
                            if (tbl != null)
                            {
                                foreach (DataRow r in tbl.Rows)
                                {
                                    string serial = r["RequestSerial"].ToString();
                                    bool result = RequestManager.UpdateDateEnd(serial, Network.GetNowDateSerial());
                                    if (result)
                                        dlgDataLogs.AddRequestLog(serial, 11, "پرونده توسط کارشناس مختومه گردید");
                                }
                            }
                        }
                        this_LoadEvent(null, EventArgs.Empty);
                        btnEndReview.Enabled = true;
                    }
                }
            }

            if (tabControl.SelectedTabPage == tabPage3)
            {
                DataRow row = gridView3.GetDataRow(gridView3.FocusedRowHandle);
                if (row != null)
                {
                    if (row["LastActionName"].ToString().Length == 0)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً قبل از مختومه شدن ابتدا از طریق دکمه ثبت اقدامات کارشناسی وضعیت پرونده را مشخص نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                    args.Icon = System.Drawing.SystemIcons.Warning;
                    args.Text = string.Format("آیا از مختومه شدن پرونده '{0}' اطمینان کامل حاصل دارید؟", row["CustomerName"].ToString());
                    args.DefaultButtonIndex = 1;
                    args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                    DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                    if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                    {
                        btnEndReview.Enabled = false;
                        Application.DoEvents();
                        bool result = ExpertReportManager.UpdateDateEnd(row["ID"].ToString(), Network.GetNowDateSerial());
                        if (result)
                        {
                            dlgDataLogs.AddExpertLog(row["ID"].ToString(), 7, "پرونده توسط کارشناس مختومه گردید");
                            string[] serials = RequestManager.GetSerialsByExpertNo(row["ID"].ToString());
                            dlgDataLogs.AddRequestLog(serials, 7, "پرونده توسط کارشناس مختومه گردید");
                        }
                       
                        this_LoadEvent(null, EventArgs.Empty);
                        btnEndReview.Enabled = true;
                    }
                }
            }
        }

        private void btnStartReview_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTabPage == tabPage1)
            {
                DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                if (row != null)
                {
                    if (row["ReviewNo"].ToString().Length > 0)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("این پیشنهاد دارای فرم بررسی می باشد لطفاً برای بررسی مجدد آن فرم بررسی را انتقال دهید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                    args.Icon = System.Drawing.SystemIcons.Question;
                    args.Caption = "هشدار";
                    args.Text = string.Format("آیا از انتقال پرونده '{0}' به لیست پرونده های جاری اطمینان کامل حاصل دارید؟", row["CustomerName"]);
                    args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                    DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                    if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                    {
                        btnStartReview.Enabled = false;
                        Application.DoEvents();
                        if (RequestManager.UpdateDateEnd(row["RequestSerial"].ToString(), null))
                            dlgDataLogs.AddRequestLog(row["RequestSerial"].ToString(), 7, "پرونده مجدداً توسط کارشناس مورد بررسی قرار گرفت");
                        cboRequestStatus.SelectedIndex = 0;
                        btnStartReview.Enabled = true;
                    }
                }
            }

            if (tabControl.SelectedTabPage == tabPage2)
            {
                DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                if (row != null)
                {
                    DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                    args.Icon = System.Drawing.SystemIcons.Question;
                    args.Caption = "هشدار";
                    args.Text = string.Format("آیا از انتقال پرونده '{0}' به لیست پرونده های جاری اطمینان کامل حاصل دارید؟", row["CustomerName"]);
                    args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                    DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                    if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                    {
                        btnStartReview.Enabled = false;
                        Application.DoEvents();
                        bool queryResult = ReviewReportManager.UpdateDateEnd(row["ID"].ToString(), int.Parse(row["ReferralDate"].ToString()), null);
                        if (queryResult)
                        {
                            DataTable tbl = UDF.GetXmlToDatatable(row["XmlRequests"].ToString());
                            if (tbl != null)
                            {
                                foreach (DataRow r in tbl.Rows)
                                {
                                    string serial = r["RequestSerial"].ToString();
                                    bool result = RequestManager.UpdateDateEnd(serial, null);
                                    if (result)
                                        dlgDataLogs.AddRequestLog(serial, 7, "پرونده مجدداً توسط کارشناس مورد بررسی قرار گرفت");
                                }
                            }
                        }
                        cboRequestStatus.SelectedIndex = 0;
                        btnStartReview.Enabled = false;
                    }
                }
            }

            if (tabControl.SelectedTabPage == tabPage3)
            {
                DataRow row = gridView3.GetDataRow(gridView3.FocusedRowHandle);
                if (row != null)
                {
                    DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                    args.Icon = System.Drawing.SystemIcons.Question;
                    args.Caption = "هشدار";
                    args.Text = string.Format("آیا از انتقال پرونده '{0}' به لیست پرونده های جاری اطمینان کامل حاصل دارید؟", row["CustomerName"]);
                    args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                    DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                    if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                    {
                        btnStartReview.Enabled = false;
                        Application.DoEvents();
                        bool result = ExpertReportManager.UpdateDateEnd(row["ID"].ToString(), null);
                        if (result)
                        {
                            dlgDataLogs.AddExpertLog(row["ID"].ToString(), 7, "گزارش کارشناسی مجدداً توسط کارشناس مورد بررسی قرار گرفت");
                            string[] serials = RequestManager.GetSerialsByExpertNo(row["ID"].ToString());
                            dlgDataLogs.AddRequestLog(serials, 7, "گزارش کارشناسی مجدداً توسط کارشناس مورد بررسی قرار گرفت");
                        }
                        cboRequestStatus.SelectedIndex = 0;
                        btnStartReview.Enabled = true;
                    }
                }
            }
        }

        private void repositoryEditReviewReport_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow selectRow = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (selectRow != null)
            {
                XtraTabPage page = new XtraTabPage();
                page.BackColor = Color.FromArgb(235, 236, 239);
                page.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                page.Text = "ویرایش فرم بررسی";
                DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                if (row != null)
                {
                    DataTable table = ReviewReportManager.GetReviewReportByNo(ChkSum.DelCheck(selectRow["ReviewNo"].ToString()));
                    if (table != null && table.Rows.Count == 1)
                    {
                        page.Controls.Add(new frmReviewLoanFile(table.Rows[0], false).pnlMain);
                        frmMain.tabControl.TabPages.Add(page);
                        frmMain.tabControl.SelectedTabPage = page;
                    }
                }
            }
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("وضعیت پیشنهاد انتخاب شده تغییر کرده است", "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void repositoryShowReviewReport_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (row != null)
            {
                DataTable table = ReviewReportManager.GetReviewReportByNo(ChkSum.DelCheck(row["ReviewNo"].ToString()));
                if (table != null && table.Rows.Count == 1)
                {
                    new frmReviewLoanFile(table.Rows[0], true).ShowDialog();
                }
            }
        }

        private void repositoryExpertReportLogs_Click(object sender, EventArgs e)
        {
            DataRow row = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (row != null)
            {
                dlgDataLogs dlg = new dlgDataLogs(false);
                dlg.FillExpertReportLogs(row);
                dlg.ShowDialog();
            }
        }

        private void tabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            btnChangeExpert.Enabled = false;
            btnSendMessage.Enabled = false;
            btnStartReview.Enabled = false;
            btnAddNote.Enabled = false;
            btnAddReviewFrm.Enabled = false;

            if (tabControl.SelectedTabPage == tabPage1)
            {
                btnAddReviewFrm.Enabled = true;
                btnChangeExpert.Enabled = true;
                btnSendMessage.Enabled = true;
            }
            if (tabControl.SelectedTabPage == tabPage2)
            {
                btnChangeExpert.Enabled = true;
                if (cboRequestStatus.SelectedIndex == 1)
                    btnStartReview.Enabled = true;
            }
            if (tabControl.SelectedTabPage == tabPage3)
            {
                btnChangeExpert.Enabled = true;
                btnAddNote.Enabled = true;
                if (cboRequestStatus.SelectedIndex == 1)
                    btnStartReview.Enabled = true;
            }
            this_LoadEvent(null, EventArgs.Empty);
            txtSearch_EditValueChanged(null, EventArgs.Empty);
        }

        private void gridView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (cboRequestStatus.SelectedIndex == 0 & e.RowHandle >= 0)
            {
                string colorName = gridView3.GetRowCellValue(e.RowHandle, "Color").ToString();
                if (colorName == "سبز")
                    e.Appearance.BackColor2 = Color.PaleGreen;
                if (colorName == "زرد")
                    e.Appearance.BackColor2 = Color.Yellow;
                if (colorName == "قرمز")
                    e.Appearance.BackColor2 = Color.LightPink;
            }
        }
        #endregion
    
        #region Worker Events

        internal static void RaiseLoadEvent()
        {
            System.EventHandler handler = LoadEvent;
            if (handler != null)
            {
                handler(null, null);
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            FillGridView();
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                gridControl1.DataSource = this.table1;
                gridControl2.DataSource = this.table2;
                gridControl3.DataSource = this.table3;
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                txtSearch_EditValueChanged(null, EventArgs.Empty);
            }
        }

        private void this_LoadEvent(object sender, EventArgs e)
        {
            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }
        }

        #endregion

    }
}
