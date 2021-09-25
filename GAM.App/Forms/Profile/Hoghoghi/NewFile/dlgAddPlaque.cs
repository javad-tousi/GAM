using GAM.Forms.Profile.LegalFile.NewFile;
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

namespace GAM.Forms.Profile.Hoghoghi.NewFile
{
    public partial class dlgAddPlaque : DevExpress.XtraEditors.XtraForm
    {
        public DataTable TablePlagues { set; get; }
        public DataRow EditRow { set; get; }
        private string FileId;

        public dlgAddPlaque(DataRow editRow, DataTable dt, string fileId)
        {
            InitializeComponent();
            TablePlagues = dt;
            FileId = fileId;
            EditRow = editRow;
            if (editRow != null)
            {
                txtMortgagorName.Text = editRow["MortgagorName"].ToString();
                txtMortgagorId.Text = editRow["MortgagorId"].ToString();
                txtPlaqueLeft1.Text = editRow["PlaqueLeft1"].ToString();
                txtPlaquePart1.Text = editRow["PlaquePart1"].ToString();
                txtPlaqueLeft2.Text = editRow["PlaqueLeft2"].ToString();
                txtPlaquePart2.Text = editRow["PlaquePart2"].ToString();
                txtPlaquePart.Text = editRow["PlaquePart"].ToString();
                txtPlaqueSection.Text = editRow["PlaqueSection"].ToString();
                txtPlaqueCity.Text = editRow["PlaqueCity"].ToString();
                txtPlaqueAddress.Text = editRow["PlaqueAddress"].ToString();
            }
            UDF.ToFarsiLanguage();
        }

        private void NextControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboLegalPerson.SelectedIndex == 0)
            {
                if (!Modules.UDF.IsValidCodeMeli(Numeral.ExtractDigits(txtMortgagorId.Text)))
                    DevExpress.XtraEditors.XtraMessageBox.Show("کد ملی راهن اشتباه می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cboLegalPerson.SelectedIndex == 1)
            {
                if (!Modules.UDF.IsValidShenaseMeli(txtMortgagorId.Text))
                    DevExpress.XtraEditors.XtraMessageBox.Show("شناسه ملی راهن اشتباه می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtMortgagorName.Text.Length == 0 | txtPlaquePart.Value == 0 | txtPlaqueSection.Value == 0 | txtPlaqueCity.Text.Trim().Length == 0 | txtPlaqueAddress.Text.Trim().Length == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً اطلاعات ورودی را کامل نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtPlaqueAddress.Text.Contains("*") | (txtPlaqueCity.Text.Trim() == txtPlaqueSection.Text.Trim()))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("آدرس وارد می باشد نامعتبر می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.EditRow == null)
            {
                DataRow newrow = TablePlagues.NewRow();
                newrow["FileId"] = this.FileId;
                newrow["MortgagorName"] = txtMortgagorName.Text.Trim();
                newrow["MortgagorId"] = txtMortgagorId.Text;
                newrow["PlaqueLeft1"] = txtPlaqueLeft1.Text;
                newrow["PlaquePart1"] = txtPlaquePart1.Text;
                newrow["PlaqueLeft2"] = txtPlaqueLeft2.Text;
                newrow["PlaquePart2"] = txtPlaquePart2.Text;
                newrow["PlaquePart"] = txtPlaquePart.Text;
                newrow["PlaqueSection"] = txtPlaqueSection.Text;
                newrow["PlaqueCity"] = txtPlaqueCity.Text.Trim();
                newrow["PlaqueAddress"] = txtPlaqueAddress.Text.Trim();
                TablePlagues.Rows.Add(newrow);
                this.Close();
            }
            else 
            {
                DataRow newrow = TablePlagues.Rows[TablePlagues.Rows.IndexOf(this.EditRow)];
                newrow["MortgagorName"] = txtMortgagorName.Text.Trim();
                newrow["MortgagorId"] = txtMortgagorId.Text;
                newrow["PlaqueLeft1"] = txtPlaqueLeft1.Text;
                newrow["PlaquePart1"] = txtPlaquePart1.Text;
                newrow["PlaqueLeft2"] = txtPlaqueLeft2.Text;
                newrow["PlaquePart2"] = txtPlaquePart2.Text;
                newrow["PlaquePart"] = txtPlaquePart.Text;
                newrow["PlaqueSection"] = txtPlaqueSection.Text;
                newrow["PlaqueCity"] = txtPlaqueCity.Text.Trim();
                newrow["PlaqueAddress"] = txtPlaqueAddress.Text.Trim();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboLegalPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLegalPerson.SelectedIndex == 0)
            {
                txtMortgagorId.ResetText();
                lblMortgagorId.Text = "کد ملی";
                txtMortgagorId.Properties.Mask.EditMask = "999-999999-9";
                txtMortgagorId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
                txtMortgagorId.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
            if (cboLegalPerson.SelectedIndex == 1)
            {
                txtMortgagorId.ResetText();
                lblMortgagorId.Text = "شناسه ملی";
                txtMortgagorId.Properties.Mask.EditMask = "99999999999";
                txtMortgagorId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
                txtMortgagorId.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
            txtMortgagorId.Focus();
            txtMortgagorId.SelectAll();
        }

    }
}
