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
    public partial class dlgEditFile : DevExpress.XtraEditors.XtraForm
    {
        public dlgEditFile(string fileId, string IndicatorId, string branchId, string branchName, string customerId, string customerName, string coverNo, string note)
        {
            InitializeComponent();
            txtFileId.Text = fileId;
            txtCoverNo.Text = coverNo;
            txtIndicatorId.Text = IndicatorId;
            txtBranchId.Text = branchId;
            lblBranchName.Text = branchName;
            txtCustomerId.Text = customerId;
            txtCustomerName.Text = customerName;
            txtNote.Text = note;
            Modules.UDF.ToFarsiLanguage();
        }

        private void btnGetLastIndicatorId_Click(object sender, EventArgs e)
        {
            if (txtBranchId.TextLength > 0)
                txtIndicatorId.Text = FilesManager.GetLastIndicatorID(txtBranchId.Text);
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً کد شعبه را مشخص نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnBranchesList_Click(object sender, EventArgs e)
        {
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool result = FilesManager.UpdateFile(txtFileId.Text, txtCoverNo.Text, txtIndicatorId.Text, txtBranchId.Text, txtCustomerId.Text, txtCustomerName.Text, txtNote.Text);
            if (result)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات پرونده شما با موفقیت ویرایش شد", "ثبت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
