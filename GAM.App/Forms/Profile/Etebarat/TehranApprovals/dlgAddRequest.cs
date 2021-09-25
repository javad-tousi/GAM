using GAM.Forms.Profile.Etebarat.Library;
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

namespace GAM.Forms.Profile.Etebarat.TehranApprovals
{
    public partial class dlgAddRequest : DevExpress.XtraEditors.XtraForm
    {
        frmTehranApprovals ParentForm;

        public struct Request
        {
            public Request(string id, string serial) 
            {
                this.Id = id;
                this.Serial = serial;
            }
            public string Id;
            public string Serial;
            public override string ToString() { return Id; }
        }

        public dlgAddRequest(frmTehranApprovals frm)
        {
            InitializeComponent();
            this.ParentForm = frm;
            colRequestType.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            colCustomerName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            colFacilityName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            colRequestAmount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            colCreditCommitee.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtRequestId.Text.Length > 0)
            {
                dataGrid.Rows.Clear();
                txtProvinceLetterNo.ResetText();
                try
                {
                    lblPleaseWait.Show();
                    Application.DoEvents();
                    DataTable dt = RequestManager.GetRequestById(long.Parse(txtRequestId.Text));
                    lblPleaseWait.Hide();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            string requestSerial = r["RequestSerial"].ToString();
                            string modifiedDate = UDF.GetDateSerialAsFormated(int.Parse(r["ModifiedDate"].ToString()));
                            string requestType = r["RequestType"].ToString();
                            string customerName = r["CustomerName"].ToString();
                            string facilityName = Facilitys.GetFacilityNameById(r["FacilityID"].ToString());
                            string requestAmount = Numeral.AnyToDouble(r["RequestAmount"]).ToString("n0");
                            string creditCommittee = r["CreditCommittee"].ToString();
                            dataGrid.Rows.Add(false, requestSerial, modifiedDate, requestType, customerName, facilityName, requestAmount, creditCommittee);
                        }
                    }
                    else
                    {
                        lblPleaseWait.Hide();
                        DevExpress.XtraEditors.XtraMessageBox.Show("شماره پیشنهاد وارد شده در سیستم وجود ندارد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    lblPleaseWait.Hide();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dataGrid.Rows.Cast < DataGridViewRow>().Count(row => bool.Parse(row.Cells["colCheckbox"].Value.ToString())) == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("هیچ پیشنهادی جهت افزودن به لیست انتخاب نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dataGrid.Rows.Cast<DataGridViewRow>().Count(row => bool.Parse(row.Cells["colCheckbox"].Value.ToString()) & row.Cells["colCreditCommitee"].Value.ToString() == CraditCommitee.Tehran) > 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("برخی از پیشنهادات انتخاب شده قبلاً به لیست پیشنهادات مدیریت شعب اضافه گردیده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtProvinceLetterNo.Text.Length == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً شناسه نامه پیشنهاد استان را وارد نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                foreach (DataGridViewRow row in dataGrid.Rows)
                {
                    if (bool.Parse(row.Cells["colCheckbox"].Value.ToString()))
                    {
                        if (row.Cells["colRequestType"].Value.ToString() != "گزارش کارشناسی" && row.Cells["colRequestType"].Value.ToString() != "بازدید")
                        {
                            string ser = row.Cells["colSerial"].Value.ToString();
                            RequestManager.UpdateCreditCommittee(ser, RequestStatus.Barasi, CraditCommitee.Tehran, int.Parse(txtProvinceLetterNo.Text), null);
                            dlgDataLogs.AddRequestLog(ser, 7, string.Format("تنظیم پیشنهاد استان طی شناسه نامه {0} جهت ارسال به اداره کل اعتبارات انجام شد", txtProvinceLetterNo.Text));
                        }
                        else 
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("امکان ارسال پیشنهاد در قالب گزارش کارشناسی/بازدید به تهران وجود ندارد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                DevExpress.XtraEditors.XtraMessageBox.Show("موارد انتخاب شده با موفقیت به لیست اضافه گردید", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ParentForm.FillDataGrid();
                dataGrid.Rows.Clear();
                txtRequestId.Focus();
                txtRequestId.Select();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtRequestId.ResetText();
                txtProvinceLetterNo.ResetText();
            }
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

    }
}
