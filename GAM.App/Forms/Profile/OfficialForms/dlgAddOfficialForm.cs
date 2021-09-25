using GAM.Connections;
using GAM.Forms.Profile.Etebarat.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Profile.OfficialForms
{
    public partial class dlgAddOfficeForm : DevExpress.XtraEditors.XtraForm
    {
        public dlgAddOfficeForm()
        {
            InitializeComponent();
            Modules.UDF.ToFarsiLanguage();
            txtSubject.Select();
        }

        public dlgAddOfficeForm(string id, string subject, string category, string receiverName, string signatories)
        {
            InitializeComponent();
            this.Text = "ویرایش اطلاعات فرم شماره " + id;
            btnSave.Text = "ویرایش اطلاعات";
            btnBrowse.Enabled = false;
            btnEdit.Enabled = true;
            btnEdit.Tag = id;
            txtSubject.Text = subject;
            cboCategory.Text = category;
            cboReceiverName.Text = receiverName;
            cboSignatories.Text = signatories;
            Modules.UDF.ToFarsiLanguage();
            txtSubject.Select();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDlg = new OpenFileDialog();
            fDlg.Filter = "Word Document (*.docx)|*.docx";
            fDlg.FilterIndex = 2;
            fDlg.RestoreDirectory = true;
            fDlg.Multiselect = false;

            if (fDlg.ShowDialog() == DialogResult.OK)
            {
                if (fDlg.FileName != string.Empty)
                    txtFileName.Text = fDlg.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "ثبت فرم")
            {
                if (cboCategory.Text.Length > 0 & txtSubject.Text.Length > 0 & cboReceiverName.Text.Length > 0 & cboReceiverName.Text.Length > 0 & txtFileName.TextLength > 0)
                {
                    string id = OfficialFormsManager.InsertInfo(txtSubject.Text, string.Format("({0})", cboCategory.Text), cboReceiverName.Text, cboSignatories.Text);
                    if (id.Length > 0)
                    {
                        System.IO.File.Copy(txtFileName.Text, OLEDB.GetFormFile(id + ".docx"));
                        DevExpress.XtraEditors.XtraMessageBox.Show("ثبت اطلاعات فرم با موفقیت انجام شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                    DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً اطلاعات ورودی را کامل نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (btnSave.Text == "ویرایش اطلاعات")
            {
                if (cboCategory.Text.Length > 0 & txtSubject.Text.Length > 0 & cboReceiverName.Text.Length > 0 & cboReceiverName.Text.Length > 0)
                {
                    bool queryResult = OfficialFormsManager.UpdateInfo(btnEdit.Tag.ToString(), txtSubject.Text, string.Format("({0})", cboCategory.Text), cboReceiverName.Text, cboSignatories.Text);
                    if (queryResult)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("ویرایش اطلاعات فرم با موفقیت انجام شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                    DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً اطلاعات ورودی را کامل نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Process.Start(OLEDB.GetFormFile(btnEdit.Tag.ToString() + ".docx"));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
