
using GAM.Forms.Profile.Etebarat.Library;
using GAM.Forms.Information;
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
    public partial class dlgAddLoanFile : DevExpress.XtraEditors.XtraForm
    {
        public dlgAddLoanFile()
        {
            InitializeComponent();
            Modules.UDF.ToFarsiLanguage();
        }

        public dlgAddLoanFile(string branchId, string branchName, string customerName)
        {
            InitializeComponent();
            txtBranchID.Text = branchId;
            lblBranchName.Text = branchName;
            txtCustomerName.Text = customerName;
        }

        private void btnBranchesInfo_Click(object sender, EventArgs e)
        {
            txtIndicatorID.Select();
            dlgBranchesList dlg = new dlgBranchesList();
            DialogResult dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                if (dlg.BranchId.Length > 0 & dlg.BranchName.Length > 0)
                {
                    txtBranchID.Text = dlg.BranchId;
                    lblBranchName.Text = dlg.BranchName;
                }
            }
        }

        private void btnGetLastIndicatorID_Click(object sender, EventArgs e)
        {
            btnGetLastIndicatorID.Enabled = false;
            Application.DoEvents();
            if (txtBranchID.TextLength > 0)
            {
                string addNumber = FilesManager.GetLastIndicatorID(txtBranchID.Text);
                if (Numeral.IsNumber(addNumber))
                    addNumber = addNumber.Substring(0, 4) + (int.Parse(addNumber.Substring(4)) + 1).ToString();
                txtIndicatorID.Text = addNumber;
            }
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً کد شعبه را مشخص نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            btnGetLastIndicatorID.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBranchID.Text.Length > 0 & txtCustomerID.Text.Length > 0 & txtCustomerName.Text.Length > 0)
            {
                btnSave.Enabled = false;
                Application.DoEvents();
                string identity = FilesManager.InsertFile(txtIndicatorID.Text, txtBranchID.Text, txtCustomerID.Text, txtCustomerName.Text, txtNote.Text);
                if (identity.Length > 0)
                {
                    btnSave.Enabled = true;
                    DevExpress.XtraEditors.XtraMessageBox.Show(string.Format("پرونده شما به شماره {0} در سیستم ثبت شد", identity), "ثبت", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}