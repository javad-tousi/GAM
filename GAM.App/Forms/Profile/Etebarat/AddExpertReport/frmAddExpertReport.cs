using GAM.Forms.Profile.Etebarat.Arshive;
using GAM.Forms.Profile.Etebarat.Library;
using GAM.Forms.Information;
using GAM.Forms.Information.Library;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
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
using GAM.Forms.Settings.Library;
using GAM.Connections;
using MD.PersianDateTime;
using GAM.Modules;

namespace GAM.Forms.Profile.Etebarat.AddExpertReport
{
    public partial class frmAddExpertReport : DevExpress.XtraEditors.XtraForm
    {
        public frmAddExpertReport()
        {
            InitializeComponent();

            colRequestId.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            colRequestType.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            colCustomerName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            colRequestAmount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            txtReferralDate.Value = Network.GetNowPersianDate();
            txtRequestId.Focus();
            txtRequestId.Select();
        }

        private void btnBranchesList_Click(object sender, EventArgs e)
        {
            btnFilesList.Select();
            dlgBranchesList dlg = new dlgBranchesList();
            DialogResult dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                if (dlg.BranchId.Length > 0 & dlg.BranchName.Length > 0)
                {
                    txtBranchId.Text = dlg.BranchId;
                    lblBranchName.Text = dlg.BranchName;
                }
            }
        }

        private void btnShowAllFiles_Click(object sender, EventArgs e)
        {
            btnUsersInfo.Select();
            dlgAllLoanFiles dlg = new dlgAllLoanFiles(txtBranchId.Text);
            DialogResult dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                if (dlg.FileId.Length > 0 & dlg.CustomerName.Length > 0)
                {
                    txtBranchId.Text = dlg.BranchId;
                    lblBranchName.Text = dlg.BranchName;
                    txtFileId.Text = dlg.FileId;
                    txtCoverNo.Text = dlg.CoverNo;
                    txtCustomerName.Text = dlg.CustomerName;
                }
            }
        }

        private void btnUsersInfo_Click(object sender, EventArgs e)
        {
            dlgUsersList dlg = new dlgUsersList(Users.GetWorkGroupUsers(false), false);
            DialogResult dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                if (dlg.UserId > 0 & dlg.UserName.Length > 0)
                {
                    txtExpertId.Text = dlg.UserId.ToString();
                    lblExpertName.Text = dlg.UserName;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtReferralDate.GetText("yyyyMMdd")) > PersianDateTime.Now.ToShortDateInt())
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("تاریخ ارجاع نمی تواند بزرگتر از تاریخ جاری باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtRequestId.Text.Length > 0 & txtBranchId.Text.Length > 0 & txtCustomerName.Text.Length > 0 & txtExpertId.Text.Length > 0)
            {
                if ((rgInputType.SelectedIndex == 0 | rgInputType.SelectedIndex == 1) &
                    dataGrid.Rows.Cast<DataGridViewRow>().Count(row => bool.Parse(row.Cells["colCheckbox"].Value.ToString())) == 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("هیچ پیشنهادی انتخاب نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Numeral.AnyToLong(txtFileId.Text) > 0 & Numeral.AnyToLong(txtCoverNo.Text) == 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("شماره جلد پرونده مشخص نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!txtReferralDate.Value.HasValue)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("تاریخ ارجاع مشخص نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtCustomerId.Text.Length == 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("شماره مشتری مشخص نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    btnSave.Enabled = false;
                    Application.DoEvents();
                    int referralDate = int.Parse(txtReferralDate.GetText("yyyyMMdd"));
                    string referralType = cboReferralType.Text;

                    if (rgInputType.SelectedIndex == 0 | rgInputType.SelectedIndex == 1)
                    {
                        int branchId = int.Parse(txtBranchId.Text);
                        long customerId = long.Parse(txtCustomerId.Text);
                        string customerName = txtCustomerName.Text.Trim();
                        int? fileId = Numeral.ToInt32Nullable(txtFileId.Text);
                        int? coverNo = Numeral.ToInt32Nullable(txtCoverNo.Text);
                        int expertId = int.Parse(txtExpertId.Text);
                        using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                        {
                            objConn.Open();
                            List<string> serials = new List<string>();
                            List<string> reviewsNo = new List<string>();

                            foreach (DataGridViewRow row in dataGrid.Rows)
                            {
                                if (bool.Parse(row.Cells["colCheckbox"].Value.ToString()))
                                {
                                    string ser = row.Cells["colSerial"].Value.ToString();
                                    serials.Add(ser);
                                    string review = row.Cells["colReviewNo"].Value.ToString();
                                    if (review.Length > 0)
                                        reviewsNo.Add(review);
                                }
                            }
                            bool queryResult = RequestManager.UpdateExpertId(serials.ToArray(), expertId);
                            if (queryResult)
                            {
                                ReviewReportManager.UpdateExpertId(reviewsNo.ToArray(), expertId);
                                dlgDataLogs.AddRequestLog(serials.ToArray(), 7, string.Format("پیشنهاد جهت تنظیم گزارش کارشناسی به {0} ارجاع شد", Users.GetUserNameWithSexByID(Numeral.AnyToInt32(txtExpertId.Text))));
                                ExpertReportManager.InsertExpertReport(objConn, serials, branchId, customerId, customerName, fileId, coverNo, expertId, referralDate, referralType);
                            }
                            objConn.Close();
                        }

                        DevExpress.XtraEditors.XtraMessageBox.Show("عملیات ارجاع با موفقیت انجام شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        rgInputType_SelectedIndexChanged(null, EventArgs.Empty);
                    }
                    if (rgInputType.SelectedIndex == 2)
                    {
                        long requestId = long.Parse(txtRequestId.Text.Trim());
                        int branchId = int.Parse(txtBranchId.Text);
                        long customerId = long.Parse(txtCustomerId.Text);
                        string customerName = txtCustomerName.Text.Trim();
                        int? fileId = Numeral.ToInt32Nullable(txtFileId.Text);
                        int? coverNo = Numeral.ToInt32Nullable(txtCoverNo.Text);
                        int expertId = int.Parse(txtExpertId.Text);
                        string[] outputs = ExpertReportManager.InsertExpertReportByLetterNo(requestId, branchId, customerId, customerName, chkIsLegalPerson.Checked, fileId, coverNo, expertId, referralDate, referralType);
                        if (outputs.Length > 0)
                        {
                            dlgDataLogs.AddRequestLog(outputs[0], 7, string.Format("گزارش کارشناسی طی شماره {0} در سیستم ثبت و به {1} ارجاع شد", ChkSum.GetFull(outputs[1]), Users.GetUserNameWithSexByID(Numeral.AnyToInt32(txtExpertId.Text))));
                            DevExpress.XtraEditors.XtraMessageBox.Show("عملیات ارجاع با موفقیت انجام شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            rgInputType_SelectedIndexChanged(null, EventArgs.Empty);
                        }
                    }

                    btnSearch.Text = "جستجو";
                    btnSave.Enabled = true;
                }
                catch (Exception ex)
                {
                    btnSave.Enabled = true;
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً اطلاعات ورودی را کامل نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NextControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void rgInputType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGrid.Rows.Clear();
            txtRequestId.ResetText();
            txtBranchId.ResetText();
            lblBranchName.ResetText();
            txtFileId.ResetText();
            txtCoverNo.ResetText();
            txtCustomerId.ResetText();
            txtCustomerName.ResetText();
            txtExpertId.ResetText();
            lblExpertName.ResetText();
            pnlSearch.Enabled = true;

            switch (rgInputType.SelectedIndex)
            {
                case 0:
                    txtRequestId.ResetText();
                    lblIdRequestId.Text = "ش.پیشنهاد";
                    btnSearch.Enabled = true;
                    grpRequests.Enabled = true;
                    pnlCustomerInfo.Enabled = false;
                    break;
                case 1:
                    txtRequestId.ResetText();
                    lblIdRequestId.Text = "شماره بررسی";
                    btnSearch.Enabled = true;
                    grpRequests.Enabled = true;
                    pnlCustomerInfo.Enabled = false;
                    break;
                case 2:
                    txtRequestId.ResetText();
                    lblIdRequestId.Text = "ش.نامه شعبه";
                    btnSearch.Enabled = false;
                    grpRequests.Enabled = false;
                    pnlCustomerInfo.Enabled = true;
                    break;
                default:
                    break;
            }

            txtRequestId.Focus();
            txtRequestId.Select();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtRequestId.Text.Length > 0)
            {
                try
                {
                    if (rgInputType.SelectedIndex == 0)
                    {
                        DataTable dt = RequestManager.GetRequestById(Numeral.AnyToLong(txtRequestId.Text));
                        if (dt.Rows.Count > 0)
                        {
                            pnlCustomerInfo.Enabled = true;
                            Application.DoEvents();
                            DataRow row = dt.Rows[0];
                            string requestSerial = row["RequestSerial"].ToString();
                            string reviewNo = row["ReviewNo"].ToString();
                            string requestId = row["RequestID"].ToString();
                            string requestType = row["RequestType"].ToString();
                            string customerName = row["CustomerName"].ToString();
                            string requestAmount = Numeral.AnyToDouble(row["RequestAmount"]).ToString("n0");
                            bool allowed = true;
                            if (row["ExpertNo"].ToString().Length > 0)
                                DevExpress.XtraEditors.XtraMessageBox.Show("برای این شماره پیشنهاد قبلا گزارش کارشناسی ثبت شده است", "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            foreach (DataGridViewRow r in dataGrid.Rows)
                            {
                                if (r.Cells["colCustomerName"].Value.ToString() != customerName)
                                    allowed = false;
                                if (r.Cells["colRequestId"].Value.ToString() == requestId)
                                    allowed = false;
                            }

                            if (allowed)
                            {
                                dataGrid.Rows.Add(false, requestSerial, reviewNo, requestId, requestType, customerName, requestAmount);
                            }
                            else 
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("به دلیل مغایرت نام مشتری یا تکراری بودن شماره پیشنهاد امکان افزودن این پیشنهاد وجود ندارد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            Branches.BranchInfo br = Branches.GetBranchById(row["BranchID"].ToString(), true);
                            txtBranchId.Text = br.BranchId;
                            lblBranchName.Text = br.BranchName;
                            txtCustomerId.Text = row["CustomerID"].ToString();
                            txtCustomerName.Text = row["CustomerName"].ToString();
                            txtFileId.Text = row["FileID"].ToString();
                            txtCoverNo.Text = row["CoverNo"].ToString();
                            if (row["ExpertID"].ToString().Length > 0)
                            {
                                txtExpertId.Text = row["ExpertID"].ToString();
                                lblExpertName.Text = Users.GetUserNameById(int.Parse(row["ExpertID"].ToString()));
                            }

                            btnSearch.Text = "افزودن";
                        }
                        else
                            throw new Exception("متاسفانه اطلاعات پیشنهاد در سیستم موجود نمی باشد");
                    }

                    if (rgInputType.SelectedIndex == 1)
                    {
                        DataTable dt = ReviewReportManager.GetRequestsByReviewNo(Numeral.AnyToULong(txtRequestId.Text));
                        if (dt.Rows.Count > 0)
                        {
                            pnlCustomerInfo.Enabled = true;
                            pnlSearch.Enabled = false;
                            Application.DoEvents(); 
                            DataRow row = dt.Rows[0];
                            Branches.BranchInfo br = Branches.GetBranchById(row["BranchID"].ToString(), true);
                            txtBranchId.Text = br.BranchId;
                            lblBranchName.Text = br.BranchName;
                            txtCustomerId.Text = row["CustomerID"].ToString();
                            txtCustomerName.Text = row["CustomerName"].ToString();
                            chkIsLegalPerson.Checked = bool.Parse(row["IsLegalPerson"].ToString());
                            txtFileId.Text = row["FileID"].ToString();
                            txtCoverNo.Text = row["CoverNo"].ToString();
                            foreach (DataRow r in dt.Rows)
                            {
                                string requestSerial = r["RequestSerial"].ToString();
                                string reviewNo = row["ReviewNo"].ToString();
                                string requestId = r["RequestID"].ToString();
                                string requestType = r["RequestType"].ToString();
                                string customerName = r["CustomerName"].ToString();
                                string requestAmount = Numeral.AnyToDouble(r["RequestAmount"]).ToString("n0");
                                dataGrid.Rows.Add(false, requestSerial, reviewNo, requestId, requestType, customerName, requestAmount);
                            }
                            if (row["ExpertID"].ToString().Length > 0)
                            {
                                txtExpertId.Text = row["ExpertID"].ToString();
                                lblExpertName.Text = Users.GetUserNameById(int.Parse(row["ExpertID"].ToString()));
                            }

                            if (row["ExpertNo"].ToString().Length > 0)
                                DevExpress.XtraEditors.XtraMessageBox.Show("برای این شماره فرم بررسی قبلا گزارش کارشناسی ثبت شده است", "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            throw new Exception("متاسفانه اطلاعات پیشنهاد در سیستم موجود نمی باشد");
                    }

                    pnlSearch.Enabled = true;
                }
                catch (Exception ex)
                {
                    pnlSearch.Enabled = true;
                    rgInputType_SelectedIndexChanged(null, EventArgs.Empty);
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            if (!txtCustomerName.Text.Contains("معرفی شدگان"))
            {
                if (txtCustomerName.Text.Contains("شرکت ") |
                    txtCustomerName.Text.Contains("صنایع ") |
                    txtCustomerName.Text.Contains("گروه ") |
                    txtCustomerName.Text.Contains("بازرگانی ") |
                    txtCustomerName.Text.Contains("حفاظت ") |
                    txtCustomerName.Text.Contains("تولیدی ") |
                    txtCustomerName.Text.Contains("موسسه ") |
                    txtCustomerName.Text.Contains("اداره ") |
                    txtCustomerName.Text.Contains("آژانس ") |
                    txtCustomerName.Text.Contains("سازمان ") |
                    txtCustomerName.Text.Contains("بانک ") |
                    txtCustomerName.Text.Contains("ارتش ") |
                    txtCustomerName.Text.Contains("دانشکده ") |
                    txtCustomerName.Text.Contains("دانشگاه ") |
                    txtCustomerName.Text.Contains("دبیرستان ") |
                    txtCustomerName.Text.Contains("مدرسه ") |
                    txtCustomerName.Text.Contains("دبستان ") |
                    txtCustomerName.Text.Contains("نمایندگی ") |
                    txtCustomerName.Text.Contains("اتحادیه ") |
                    txtCustomerName.Text.Contains("تعاونی ") |
                    txtCustomerName.Text.Contains("تعاونیهای ") |
                    txtCustomerName.Text.Contains("استانداری ") |
                    txtCustomerName.Text.Contains("فرمانداری ") |
                    txtCustomerName.Text.Contains("فرماندهی ") |
                    txtCustomerName.Text.Contains("فروشگاه ") |
                    txtCustomerName.Text.Contains("صنایع ") |
                    txtCustomerName.Text.Contains("کمیته ") |
                    txtCustomerName.Text.Contains("مدیریت ") |
                    txtCustomerName.Text.Contains("معاونت ") |
                    txtCustomerName.Text.Contains("ستاد ") |
                    txtCustomerName.Text.Contains("وزارت ") |
                    txtCustomerName.Text.Contains("آستان قدس") |
                    txtCustomerName.Text.Contains("آستانقدس") |
                    txtCustomerName.Text.Contains("هلال احمر") |
                    txtCustomerName.Text.Contains("مهندسی ") |
                    txtCustomerName.Text.Contains("مجتمع ") |
                    txtCustomerName.Text.Contains("روزنامه ") |
                    txtCustomerName.Text.Contains("كشتارگاه ") |
                    txtCustomerName.Text.Contains("سردخانه ") |
                    txtCustomerName.Text.Contains("انجمن ") |
                    txtCustomerName.Text.Contains("کارخانه ") |
                    txtCustomerName.Text.Contains("قرارگاه ") |
                    txtCustomerName.Text.Contains("ارتش ") |
                    txtCustomerName.Text.Contains("بنیاد ") |
                    txtCustomerName.Text.Contains("مرکز ") |
                    txtCustomerName.Text.Contains("هتل ") |
                    txtCustomerName.Text.Contains("پلیس "))
                {
                    chkIsLegalPerson.Checked = true;
                }
                else
                {
                    chkIsLegalPerson.Checked = false;
                }
            }
        }
    }
}
