using GAM.Forms.Information;
using GAM.Forms.Information.Library;
using GAM.Forms.Profile.Kargozini.Library;
using GAM.Forms.Settings.Library;
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

namespace GAM.Forms.Profile.Kargozini.Personnel
{
    public partial class dlgAddRule : DevExpress.XtraEditors.XtraForm
    {
        public dlgAddRule(string employmentId, string status, string fullName, DataRow lastRow)
        {
            InitializeComponent();
            txtRuleDate.Text = Network.GetNowDateFormat();
            txtEmploymentId.Text = employmentId;
            txtFullName.Text = fullName;
            cboPersonnelStatus.Tag = status;
            cboPersonnelStatus.Text = status;
            if (lastRow != null)
            {
                txtBranchId.Text = lastRow["BranchID"].ToString();
                lblBranchName.Text = Branches.GetUnitNameById(lastRow["BranchID"].ToString());
                txPostId.Text = lastRow["PostID"].ToString();
                lblPostName.Text = Posts.GetPostNameById(lastRow["PostID"].ToString());

                txtJobId.Text = lastRow["JobID"].ToString();
                lblJobName.Text = Posts.GetJobNameById(lastRow["JobID"].ToString());
            }
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

        private void btnPostsList_Click(object sender, EventArgs e)
        {
            dlgPostsList dlg = new dlgPostsList();
            DialogResult dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                if (dlg.PostId > 0 & dlg.PostName.Length > 0)
                {
                    txPostId.Text = dlg.PostId.ToString();
                    lblPostName.Text = dlg.PostName;
                }
            }
        }

        private void btnJobsList_Click(object sender, EventArgs e)
        {
            dlgJobsList dlg = new dlgJobsList();
            DialogResult dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                if (dlg.JobId > 0 & dlg.JobName.Length > 0)
                {
                    txtJobId.Text = dlg.JobId.ToString();
                    lblJobName.Text = dlg.JobName.ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkBox.Checked & PersianDateTime.IsValidDate(txtRuleDate.Text) & cboRuleName.Text.Length > 0 & txtBranchId.TextLength > 0 & txPostId.TextLength > 0 & cboPersonnelStatus.Text.Length > 0)
            {
                DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args.Icon = System.Drawing.SystemIcons.Warning;
                args.Caption = "هشدار";
                args.Text = "آیا از ذخیره اطلاعات اطمینان کامل دارید؟";
                args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    bool result = PersonelsManager.InsertRule(long.Parse(txtEmploymentId.Text), (cboPersonnelStatus.Tag.ToString() != cboPersonnelStatus.Text) ? cboPersonnelStatus.Text : string.Empty, int.Parse(Numeral.ExtractDigits(txtRuleDate.Text)), txtRuleNo.Text, cboRuleName.Text, txtRuleDescription.Text, int.Parse(txtBranchId.Text), int.Parse(txPostId.Text), int.Parse(txtJobId.Text));
                    if (result)
                    {
                        if (cboPersonnelStatus.Tag.ToString() != cboPersonnelStatus.Text)
                            PersonelsManager.UpdatePersonnelStatus(long.Parse(txtEmploymentId.Text), cboPersonnelStatus.Text);
                        DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات با موفقیت ذخیره شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                }
            }
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات ورودی ناقص می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NextControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboRuleName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPersonnelStatus.Enabled = false;
            btnBranchesList.Enabled = false;
            btnPostsList.Enabled = false;
            btnJobsList.Enabled = false;

            switch (cboRuleName.Text)
            {
                case "تغییر وضعیت":
                    cboPersonnelStatus.Enabled = true;
                    break;
                case "انتقال":
                    btnBranchesList.Enabled = true;
                    break;
                case "انتقال-قطعی":
                    btnBranchesList.Enabled = true;
                    DevExpress.XtraEditors.XtraMessageBox.Show("کلیه حکم های انتقالی سیستمی از تاریخ حکم جاری غیرفعال خواهند شد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "تغییر پست":
                    btnPostsList.Enabled = true;
                    break;
                case "تغییر شغل":
                    btnJobsList.Enabled = true;
                    break;
                case "تغییر پست و شغل":
                    btnPostsList.Enabled = true;
                    btnJobsList.Enabled = true;
                    break;
                case "انتقال و تغییر پست":
                    btnBranchesList.Enabled = true;
                    btnPostsList.Enabled = true;
                    break;
                case "انتقال و تغییر شغل":
                    btnBranchesList.Enabled = true;
                    btnJobsList.Enabled = true;
                    break;
                case "انتقال و تغییر پست و شغل":
                    btnBranchesList.Enabled = true;
                    btnPostsList.Enabled = true;
                    btnJobsList.Enabled = true;
                    break;
                case "تشویقی":
                    break;
                case "اخطار کتبی":
                    break;
                case "لغو حکم":
                    cboPersonnelStatus.Enabled = true;
                    btnBranchesList.Enabled = true;
                    btnPostsList.Enabled = true;
                    btnJobsList.Enabled = true;
                    break;
                default:
                    break;
            }
        }


    }
}
