using GAM.Modules;
using GAM.Forms.Information;
using GAM.Forms.Information.Library;
using GAM.Forms.Profile.Etebarat.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Profile.Etebarat.Arshive
{
    public partial class dlgArshiveReviewReport : DevExpress.XtraEditors.XtraForm
    {
        List<string> Serials = new List<string>();

        public dlgArshiveReviewReport()
        {
            InitializeComponent();
            Modules.UDF.ToFarsiLanguage();
        }

        private void btnFindSerial_Click(object sender, EventArgs e)
        {
            if (txtReviewNo.Text.Length > 0 & ChkSum.Check(txtReviewNo.Text))
            {
                try
                {
                    lblPleaseWait.Show();
                    btnFindSerial.Enabled = false;
                    Application.DoEvents();
                    DataTable table = ReviewReportManager.GetReviewReportByNo(ChkSum.DelCheck(txtReviewNo.Text));
                    lblPleaseWait.Hide();

                    if (table != null && table.Rows.Count == 1)
                    {
                        txtReviewNo.Enabled = false;
                        txtCustomerId.Focus();
                        txtCustomerId.Select();
                        this.Serials = new List<string>();
                        DataRow row = table.Rows[0];
                        txtCustomerId.Text = row["CustomerID"].ToString();
                        txtCustomerName.Text = row["CustomerName"].ToString();
                        txtBranchId.Text = row["BranchID"].ToString();
                        DataTable tbl = UDF.GetXmlToDatatable(row["XmlRequests"].ToString());
                        foreach (DataRow r in tbl.Rows)
                            this.Serials.Add(r["RequestSerial"].ToString());
                        txtRequestsCount.Text = tbl.Rows.Count.ToString();
                    }
                }
                catch
                {
                    lblPleaseWait.Hide();
                    btnFindSerial.Enabled = true;
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات ورودی اشتباه می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBranchesList_Click(object sender, EventArgs e)
        {
            txtIndicatorId.Select();
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

        private void btnGetLastIndicatorId_Click(object sender, EventArgs e)
        {
            btnGetLastIndicatorID.Enabled = false;
            Application.DoEvents();
            if (txtBranchId.TextLength > 0)
            {
                string addNumber = FilesManager.GetLastIndicatorID(txtBranchId.Text);
                if (Numeral.IsNumber(addNumber))
                    addNumber = txtBranchId.Text.Substring(0, 4) + (int.Parse(addNumber.Substring(4)) + 1).ToString();
                txtIndicatorId.Text = addNumber;
            }
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً کد شعبه را مشخص نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            btnGetLastIndicatorID.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtRequestsCount.Text) > 0 & txtBranchId.Text.Length > 0 & txtCustomerId.Text.Length > 0 & txtCustomerName.Text.Length > 0)
            {
                btnSave.Enabled = false;
                Application.DoEvents();
                string identity = FilesManager.InsertFile(txtIndicatorId.Text, txtBranchId.Text, txtCustomerId.Text, txtCustomerName.Text, string.Empty);
                if (identity.Length > 0)
                {
                    bool result = RequestManager.UpdateRequestLocation(string.Empty, txtReviewNo.Text, "بایگانی");
                    if (result)
                    {
                        foreach (string serial in this.Serials)
                            dlgDataLogs.AddRequestLog(serial, 8, "پیشنهاد در بایگانی ثبت و تشکیل پرونده شد");
                    }

                    btnSave.Enabled = true;
                    this.Hide();
                    new dlgWriteFileNo(identity).ShowDialog();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                btnSave.Enabled = true;
            }
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً اطلاعات ورودی را کامل نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NextControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtBranchId_TextChanged(object sender, EventArgs e)
        {
            lblBranchName.ResetText();
            if (txtBranchId.TextLength > 0)
            {
                lblBranchName.Text = Branches.GetBranchById(txtBranchId.Text, true).BranchName;
            }
        }
    }
}