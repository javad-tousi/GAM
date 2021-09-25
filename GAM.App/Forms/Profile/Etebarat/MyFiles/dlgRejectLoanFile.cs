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
    public partial class dlgRejectLoanFile : DevExpress.XtraEditors.XtraForm
    {
        public string Message { get; set; }

        public dlgRejectLoanFile(string customerName)
        {
            InitializeComponent();
            txtCustomerName.Text = customerName;
            Modules.UDF.ToFarsiLanguage();
        }
        public dlgRejectLoanFile(string customerName, string message)
        {
            InitializeComponent();
            txtCustomerName.Text = customerName;
            cboRejectType.Enabled = false;
            txtNote.Text = message;
            txtNote.ReadOnly = true;
            Modules.UDF.ToFarsiLanguage();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtNote.Text.Trim().Length > 0)
            {
                this.Message = txtNote.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else 
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً علت مختومه شدن را مشخص نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboRejectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNote.ReadOnly = true;
            txtNote.ResetText();

            if (cboRejectType.SelectedIndex == 0)
                txtNote.Text = "پرونده تکمیل و مورد بررسی قرار گرفت";
            if (cboRejectType.SelectedIndex == 1)
                txtNote.Text = "پرونده رفع نقص و مجدداً مورد بررسی قرار گرفت";
            if (cboRejectType.SelectedIndex == 2)
                txtNote.Text = "پرونده در حدود اختیارات حوزه/شعبه می باشد";
            if (cboRejectType.SelectedIndex == 3)
                txtNote.Text = "پرونده ناقص و کسری مدارک به شعبه اعلام گردید";
            if (cboRejectType.SelectedIndex == 4)
                txtNote.Text = "پرونده بدلیل عدم تکمیل مدارک توسط شعبه مختومه شد";
            if (cboRejectType.SelectedIndex == 5)
                txtNote.Text = "پرونده طی مذاکره تلفنی با شعبه برگشت داده شد";
            if (cboRejectType.SelectedIndex == 6)
            {
                txtNote.ReadOnly = false;
                txtNote.ResetText();
                txtNote.Select();
                txtNote.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
