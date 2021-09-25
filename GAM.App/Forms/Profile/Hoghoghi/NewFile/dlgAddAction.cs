using GAM.Forms.Information.Library;
using GAM.Forms.Settings.Library;
using GAM.Forms.Profile.Etebarat.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GAM.Forms.Profile.LegalFile.Library;

namespace GAM.Forms.Profile.LegalFile.NewFile
{
    public partial class dlgSendMessage : DevExpress.XtraEditors.XtraForm
    {
        DataRow thisRow;
        List<string> contractsList = new List<string>();
        public dlgSendMessage(DataRow row, DataTable table)
        {
            InitializeComponent();
            Modules.UDF.ToFarsiLanguage();
            thisRow = row;
            txtContractId.Text = row["ContractID"].ToString();
            txtContractId.Tag = row["ContractID"].ToString();
            txtCustomerName.Text = row["CustomerName"].ToString();
            cboActivities.SelectedIndex = 0;
            txtNote.Focus();
            txtNote.Select();
            if (table != null)
            {
                foreach (DataRow r in table.Rows)
                    contractsList.Add(r["ContractID"].ToString());
            }
            if (!contractsList.Contains(row["ContractID"].ToString()))
                contractsList.Add(row["ContractID"].ToString());
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (thisRow != null)
            {
                if (cboActivities.SelectedIndex == -1)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("نوع پیام مشخص نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtNote.Text.Trim().Length == 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("هیچ متنی برای ارسال وجود ندارد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtNote.Text.Contains(".........."))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً بخش خالی متن را تکمیل نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args.Icon = System.Drawing.SystemIcons.Warning;
                args.Caption = "هشدار";
                args.Text = "آیا از ارسال پیام اطمینان کامل حاصل دارید؟";
                args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                args.DefaultButtonIndex = 1;
                DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        btnSend.Enabled = false;
                        Application.DoEvents();

                        int levelId = int.Parse(thisRow["LevelID"].ToString());
                        int actionId = int.Parse(cboActivities.Properties.Items[cboActivities.SelectedIndex].Value.ToString());
                        string[] contracts = txtContractId.Text.Split(',').Select(x => x.Trim()).ToArray();

                        if (actionId == 1)
                        {
                            LegalFilesManager.UpdateDateLastAction(contracts);
                            LegalFilesManager.UpdateFileStatus(contracts, LegalFileStatus.Action);
                        }

                        if (actionId == 2)
                            LegalFilesManager.UpdateFileStatus(contracts, LegalFileStatus.Reject);
                        if (actionId == 10)
                            LegalFilesManager.UpdateFileStatus(contracts, LegalFileStatus.Stoped);
                        if (actionId == 11)
                        {
                            LegalFilesManager.UpdateFileStatus(contracts, LegalFileStatus.Closed);
                            levelId = -1;
                        }


                        dlgDataLogs.AddLegalLog(contracts, levelId, actionId, txtNote.Text.Trim());

                        btnSend.Enabled = true;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                        DevExpress.XtraEditors.XtraMessageBox.Show("پیام شما با موفقیت ارسال گردید", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        btnSend.Enabled = true;
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboMessageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNote.ResetText();

            int actionId = int.Parse(cboActivities.Properties.Items[cboActivities.SelectedIndex].Value.ToString());
            if (actionId == 2)
                txtNote.Text = "پرونده به شعبه عودت گردید";
            if (actionId == 10)
                txtNote.Text = "طبق نامه شماره .......... شعبه اقدامات قانونی متوقف گردید";
            if (actionId == 11)
                txtNote.Text = "پرونده مختومه گردید";
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                txtContractId.Text = string.Join(", ", contractsList.ToArray());
            }
            else 
            {
                txtContractId.Text = txtContractId.Tag.ToString();
            }
        }
    }
}
 