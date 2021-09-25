using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GAM.Forms.Profile.Etebarat.Library;

namespace GAM.Forms.Profile.Etebarat.TehranApprovals
{
    public partial class dlgReceiveFromTehran : DevExpress.XtraEditors.XtraForm
    {
        public dlgReceiveFromTehran(DataRow row)
        {
            InitializeComponent();
            cboRequestStatus.Properties.Items.Add(RequestStatus.Mosavab);
            cboRequestStatus.Properties.Items.Add(RequestStatus.Mokhalefat);
            cboRequestStatus.Properties.Items.Add(RequestStatus.Odat);

            txtRequestID.Text = row["RequestID"].ToString();
            txtRequestID.Tag = row["RequestSerial"].ToString();
            txtProvinceLetterDate.Text = PersianDate.Parse(int.Parse(row["ProvinceLetterDate"].ToString())).ToStandard();
            txtFacilityName.Text = row["FacilityName"].ToString();
            txtRequestAmount.Text = row["RequestAmount"].ToString();
            txtCustomerName.Text = row["CustomerName"].ToString();
            Modules.UDF.ToFarsiLanguage();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (cboRequestStatus.Text.Length > 0 & txtTehranLetterNo.Text.Length > 0 & txtTehranLetterDate.Value.HasValue & txtTehranApprovedAmount.Text.Length > 0)
            {
                if (cboRequestStatus.Text == RequestStatus.Odat & Numeral.AnyToDouble(txtTehranApprovedAmount.Text) > 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("پیشنهاد عودت داده شده نمی تواند دارای مبلغ مصوب شده باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args.Icon = System.Drawing.SystemIcons.Warning;
                args.Caption = "هشدار";
                args.Text = "آیا از ثبت اطلاعات اطمینان کامل حاصل دارید؟";
                args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                args.DefaultButtonIndex = 1;
                DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    string serial = txtRequestID.Tag.ToString();
                    string requestStatus = cboRequestStatus.Text;
                    string tehranCraditCommite = cboTehranCraditCommite.Text;
                    int tehranLetterNo = int.Parse(txtTehranLetterNo.Text);
                    int tehranLetterDate = int.Parse(txtTehranLetterDate.GetText("yyyyMMdd"));
                    double tehranApprovedAmount = Numeral.AnyToDouble(txtTehranApprovedAmount.Text);
                    bool queryResult = RequestManager.UpdateApprovedAmount(serial, requestStatus, tehranCraditCommite, tehranLetterNo, tehranLetterDate, tehranApprovedAmount);
                    if (queryResult)
                    {
                        string date = txtTehranLetterDate.GetText("yyyy/MM/dd");
                        string letterNo = txtTehranLetterNo.Text;
                        dlgDataLogs.AddRequestLog(txtRequestID.Tag.ToString(), 7, string.Format("پاسخ اداره کل اعتبارات در تاریخ {0} طی شناسه نامه {1} به کمیته اعتباری مدیریت شعب ابلاغ شد", date, letterNo));
                        DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات پرونده با موفقیت ثبت شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                }
            }
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً اطلاعات ورودی را کامل نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
