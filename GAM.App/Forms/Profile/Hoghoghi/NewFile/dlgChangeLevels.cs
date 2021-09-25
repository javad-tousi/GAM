using DevExpress.XtraEditors.Controls;
using GAM.Forms.Profile.LegalFile.Library;
using GAM.Forms.Profile.Etebarat.Library;
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

namespace GAM.Forms.Profile.LegalFile.NewFile
{
    public partial class dlgChangeLevels : DevExpress.XtraEditors.XtraForm
    {
        private DataRow thisRow { get; set; }
        private frmNewLegalFile BaseForm;

        public dlgChangeLevels(frmNewLegalFile ownwer, DataRow row)
        {
            InitializeComponent();
            this.BaseForm = ownwer;
            thisRow = row;
            foreach (DataRow levelRow in LegalFileLevels.GetAllLevels().Rows)
            {
                RadioGroupItem rg = new RadioGroupItem();
                rg.Description = levelRow["LevelName"].ToString();
                rg.Value = levelRow["LevelID"].ToString();
                rgContractLevels.Properties.Items.Add(rg);
            }

            int levelId = int.Parse(thisRow["LevelID"].ToString());
            for (int i = 0; i < levelId; i++)
            {
                if (int.Parse(rgContractLevels.Properties.Items[i].Value.ToString()) == levelId)
                    rgContractLevels.SelectedIndex = i;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (PersianDateTime.IsValidDate(txtDateLevel.Text) && (PersianDateTime.Now.ToShortDateInt() >= PersianDateTime.Parse(txtDateLevel.Text).ToShortDateInt()))
            {
                int dateLevel = int.Parse(Numeral.ExtractDigits(txtDateLevel.Text));
                RadioGroupItem newLevel = rgContractLevels.Properties.Items[rgContractLevels.SelectedIndex];
                int selectedLevelid = int.Parse(newLevel.Value.ToString());
                int lastLevelId = rgContractLevels.Properties.Items.Count;

                if (selectedLevelid < lastLevelId & selectedLevelid >= 6 & (Numeral.AnyToLong(this.BaseForm.txtIndicatorId.Text) == 0))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً شماره کلاسه پرونده را ثبت نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (selectedLevelid < lastLevelId & selectedLevelid >= 13 & (Numeral.AnyToLong(this.BaseForm.txtEvaluationAmount1.Text) == 0 | Numeral.AnyToLong(this.BaseForm.txtEvaluationAmount2.Text) == 0))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً مبلغ ارزیابی واحد را ثبت نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (selectedLevelid < lastLevelId & selectedLevelid >= 15 & !PersianDateTime.IsValidDate(this.BaseForm.txtDateAuction.Text))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً تاریخ مزایده را ثبت نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args.Icon = System.Drawing.SystemIcons.Warning;
                args.Caption = "هشدار";
                args.Text = "آیا از ثبت نهایی اطلاعات اطمینان کامل حاصل دارید؟";
                args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                args.DefaultButtonIndex = 1;
                DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        btnSave.Enabled = false;
                        Application.DoEvents();

                        string returnValue = LegalFilesManager.UpdateLevelId(long.Parse(thisRow["ContractID"].ToString()), int.Parse(newLevel.Value.ToString()), dateLevel);
                        if (returnValue.Length > 0)
                        {
                            dlgDataLogs.AddLegalLog(thisRow["ContractID"].ToString(), int.Parse(newLevel.Value.ToString()), 1, string.Format("پرونده در تاریخ {0} به مرحله شماره {1} ({2}) انتقال یافت", txtDateLevel.Text, int.Parse(newLevel.Value.ToString()), newLevel.Description));
                        }

                        btnSave.Enabled = true;
                        DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات با موفقیت ذخیره شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        btnSave.Enabled = true;
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("تاریخ وارد شده نامعتبر یا جلوتر از تاریخ روز جاری می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rgContractLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            int oldlevelId = int.Parse(thisRow["LevelID"].ToString());
            int newlevelId = int.Parse(rgContractLevels.Properties.Items[rgContractLevels.SelectedIndex].Value.ToString());

            if (oldlevelId != newlevelId)
                btnSave.Enabled = true;
        }
    }
}
