using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using GAM.Dialogs;
using GAM.Forms.Profile.Etebarat.Library;
using GAM.Forms.Reports.Library;
using GAM.Forms.Settings.Library;
using GAM.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Reports.Etebarat.Requests
{
    public partial class frmExpertsPerformance : DevExpress.XtraEditors.XtraForm
    {
        public frmExpertsPerformance()
        {
            InitializeComponent();
            PersianDate now = Network.GetNowPersianDate();
            now.Month = 1;
            now.Day = 1;
            txtFromDate.Value = now;
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
                    try
                    {
                        DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
                        btnShowQuery.Enabled = false;
                        Application.DoEvents();

                        DataTable table = new DataTable();
                        table.Columns.Add("UserId", typeof(int));
                        table.Columns.Add("UserName");
                        table.Columns.Add("Count1", typeof(int));
                        table.Columns.Add("Count2", typeof(int));
                        table.Columns.Add("Sum1", typeof(int));
                        table.Columns.Add("Count3", typeof(int));
                        table.Columns.Add("Count4", typeof(int));
                        table.Columns.Add("Count5", typeof(int));
                        table.Columns.Add("Count6", typeof(int));
                        table.Columns.Add("Count7", typeof(int));
                        table.Columns.Add("Count8", typeof(int));
                        table.Columns.Add("Count9", typeof(int));
                        table.Columns.Add("Count10", typeof(int));
                        table.Columns.Add("Count11", typeof(int));

                        List<DataRow> expertUsers = new List<DataRow>();
                        foreach (DataRow r in Information.Library.Users.GetWorkGroupUsers(true).Rows)
                        {
                            if (r["PostJob"].ToString() == "کارشناس")
                            {
                                expertUsers.Add(r);
                            }
                        }

                        progressBar.Properties.Maximum = expertUsers.Count;
                        progressBar.EditValue = 5;
                        progressBar.Show();
                        Application.DoEvents();

                        for (int i = 0; i < expertUsers.Count; i++)
                        {
                            progressBar.EditValue = i;
                            Application.DoEvents();

                            DataRow row = expertUsers[i];

                            if (row["PostJob"].ToString() == "کارشناس")
                            {
                                DataRow newRow = table.NewRow();
                                int userId = int.Parse(row["UserID"].ToString());
                                string userName = row["UserName"].ToString();
                                int count1 = 0;//پیشنهاد بررسی نشده
                                int count2 = 0;//پیشنهاد بررسی شده

                                int count3 = 0;//ارجاع گزارش
                                int count4 = 0;//تکمیل گزارش
                                int count5 = 0;//مختومه گزارش

                                int count6 = 0;//ارجاع ارسال به تهران
                                int count7 = 0;//تکمیل ارسال به تهران
                                int count8 = 0;//مختومه ارسال به تهران

                                int count9 = 0;//پیشنهادات ارجاع شده
                                int count10 = 0;//پیشنهادات بررسی شده
                                int count11 = 0;//پیشنهادات مختومه

                                foreach (DataTable t in RequestManager.GetRequests(userId.ToString()))
                                {
                                    foreach (DataRow r in t.Rows)
                                    {
                                        if (Numeral.AnyToInt32(r["ReferralDate"].ToString()) >= dateFrom & Numeral.AnyToInt32(r["ReferralDate"].ToString()) <= dateTo)
                                        {
                                            ++count9;
                                            if (r["DateEnd"].ToString().Length == 0)
                                                ++count10;
                                            else
                                                ++count11;
                                        }
                                    }
                                }


                                foreach (DataRow r in ReviewReportManager.GetReviewReports(userId, "*").Rows)
                                {
                                    if (Numeral.AnyToInt32(r["ReferralDate"].ToString()) >= dateFrom & Numeral.AnyToInt32(r["ReferralDate"].ToString()) <= dateTo)
                                    {
                                        if (r["DateEnd"].ToString().Length == 0)
                                            ++count1;
                                        else
                                            ++count2;
                                    }
                                }

                                foreach (DataRow r in ExpertReportManager.GetExpertReports(userId, "*").Rows)
                                {
                                    if (Numeral.AnyToInt32(r["ReferralDate"].ToString()) >= dateFrom & Numeral.AnyToInt32(r["ReferralDate"].ToString()) <= dateTo)
                                    {
                                        if (r["ReferralType"].ToString() == "گزارش کارشناسی")
                                        {
                                            ++count3;
                                            if (r["DateReport"].ToString().Length > 0)
                                                ++count4;
                                            if (r["DateEnd"].ToString().Length > 0)
                                                ++count5;
                                        }
                                        if (r["ReferralType"].ToString() == "ارسال به تهران")
                                        {
                                            ++count6;
                                            if (r["DateReport"].ToString().Length > 0)
                                                ++count7;
                                            if (r["DateEnd"].ToString().Length > 0)
                                                ++count8;
                                        }
                                    }
                                }

                                newRow["UserId"] = userId;
                                newRow["UserName"] = userName;
                                newRow["Count1"] = count1;
                                newRow["Count2"] = count2;
                                newRow["Sum1"] = count1 + count2;
                                newRow["Count3"] = count3;
                                newRow["Count4"] = count4;
                                newRow["Count5"] = count5;
                                newRow["Count6"] = count6;
                                newRow["Count7"] = count7;
                                newRow["Count8"] = count8;
                                newRow["Count9"] = count9;
                                newRow["Count10"] = count10;
                                newRow["Count11"] = count11;

                                table.Rows.Add(newRow);
                            }
                        }

                        gridControl.DataSource = table;
                        btnShowQuery.Enabled = true;
                        DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                        progressBar.Hide();
                    }
                    catch (Exception ex)
                    {
                        btnShowQuery.Enabled = true;
                        DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                        progressBar.Hide();
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    DevExpress.XtraEditors.XtraMessageBox.Show("تاریخ مقصد می بایست کوچکتر از تاریخ مبدا باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("لطفا مقادیر تاریخ را وارد نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnExportToXlsx_Click(object sender, EventArgs e)
        {
            btnExportToXlsx.Enabled = false;
            Application.DoEvents();
            DevExportToXlsx.SaveAs(gridView);
            btnExportToXlsx.Enabled = true;
        }

        private void gridControl_ViewRegistered(object sender, DevExpress.XtraGrid.ViewOperationEventArgs e)
        {
            GridView gv = e.View as GridView;
            gv.BestFitColumns();
        }
    }
}
