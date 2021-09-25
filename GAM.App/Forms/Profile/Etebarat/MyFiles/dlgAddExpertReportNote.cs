using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Profile.Etebarat.MyFiles
{
    public partial class dlgAddExpertReportNote : DevExpress.XtraEditors.XtraForm
    {
        public bool FinishReport { get; set; }
        public bool CloseReport { get; set; }
        public string Message { get; set; }
        public int DateAction { get; set; }
        public int ActionID { get; set; }

        public dlgAddExpertReportNote(string customerName)
        {
            InitializeComponent();
            txtDateAction.Value = PersianDateTime.Now;
            txtCustomerName.Text = customerName;
        }

        private void cboSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNote.ReadOnly = true;
            txtNote.ResetText();

            if (cboSubject.SelectedIndex == 0)
            {
                this.ActionID = 13;
                txtNote.Text = string.Format("کسری مدارک پرونده در تاریخ {0} به شعبه اعلام شد", txtDateAction.GetText("yyyy/MM/dd"));
            }
            if (cboSubject.SelectedIndex == 1)
            {
                this.ActionID = 13;
                txtNote.Text = string.Format("نامه دوم کسری مدارک پرونده در تاریخ {0} کتباً به شعبه اعلام شد", txtDateAction.GetText("yyyy/MM/dd"));
            }
            if (cboSubject.SelectedIndex == 2)
            {
                this.ActionID = 7;
                txtNote.Text = string.Format("تکمیل مدارک و مستندات در تاریخ {0} توسط شعبه", txtDateAction.GetText("yyyy/MM/dd"));
            }
            if (cboSubject.SelectedIndex == 3)
            {
                this.ActionID = 1;
                txtNote.Text = string.Format("در تاریخ {0} بازدید از محل مشتری انجام شد", txtDateAction.GetText("yyyy/MM/dd"));
            }
            if (cboSubject.SelectedIndex == 4)
            {
                this.ActionID = 1;
                txtNote.Text = string.Format("در تاریخ {0} گزارش کارشناسی تکمیل شد", txtDateAction.GetText("yyyy/MM/dd"));
            }
            if (cboSubject.SelectedIndex == 5)
            {
                this.ActionID = 1;
                txtNote.Text = string.Format("در تاریخ {0} ثبت اطلاعات در سامانه جامع اعتباری انجام شد", txtDateAction.GetText("yyyy/MM/dd"));
            }
            if (cboSubject.SelectedIndex == 6)
            {
                this.ActionID = 1;
                txtNote.Text = string.Format("در تاریخ {0} پرونده به تهران ارسال شد", txtDateAction.GetText("yyyy/MM/dd"));
            }
            if (cboSubject.SelectedIndex == 7)
            {
                this.ActionID = 2;
                txtNote.Text = string.Format("در تاریخ {0} پرونده به شعبه عودت داده شد", txtDateAction.GetText("yyyy/MM/dd"));
            }
            if (cboSubject.SelectedIndex == 8)
            {
                this.ActionID = 2;
                txtNote.Text = string.Format("در تاریخ {0} پرونده بدون اقدام به شعبه عودت داده شد", txtDateAction.GetText("yyyy/MM/dd"));
            }
            if (cboSubject.SelectedIndex == 9)
            {
                this.ActionID = 12;
                txtNote.ReadOnly = false;
                txtNote.ResetText();
                txtNote.Select();
                txtNote.Focus();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtNote.Text.Trim().Length > 0)
            {
                if (cboSubject.SelectedIndex == 4)
                {
                    this.FinishReport = true;
                }

                if (cboSubject.SelectedIndex == 1 | 
                    cboSubject.SelectedIndex == 4 | 
                    cboSubject.SelectedIndex == 5 | 
                    cboSubject.SelectedIndex == 6 | 
                    cboSubject.SelectedIndex == 7 | 
                    cboSubject.SelectedIndex == 8)
                {
                    DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                    args.Icon = System.Drawing.SystemIcons.Question;
                    args.Text = "آیا مایل به مختومه شدن پرونده می باشید؟";
                    args.DefaultButtonIndex = 1;
                    args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                    DialogResult dlgRes2 = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                    if (dlgRes2 == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.CloseReport = true;
                    }
                }

                this.Message = txtNote.Text;
                this.DateAction = int.Parse(txtDateAction.GetText("yyyyMMdd"));
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("فیلد توضیحات خالی می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void txtDateAction_ValueChanged(object sender, EventArgs e)
        {
            cboSubject_SelectedIndexChanged(null, EventArgs.Empty);
        }
    }
}
