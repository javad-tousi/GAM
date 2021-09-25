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
using GAM.Connections;
using GAM.Modules;
using DevExpress.XtraEditors.Controls;


namespace GAM.Forms.Profile.Etebarat.Print
{
    public partial class dlgChangeStatus : DevExpress.XtraEditors.XtraForm
    {
        DataRow thisRow { get; set; }
        int ActionId = -1;

        public dlgChangeStatus(DataRow row, Dictionary<string, string> serials)
        {
            InitializeComponent();
            thisRow = row;
            txtRequestID.Text = row["RequestID"].ToString();
            txtSerial.Text = row["RequestSerial"].ToString();
            txtReviewNo.Text = ChkSum.GetFull(row["ReviewNo"].ToString());
            txtGroupId.Text = row["GroupID"].ToString();
            txtExpertNo.Text = ChkSum.GetFull(row["ExpertNo"].ToString());
            txtCustomerId.Text = row["CustomerID"].ToString();
            txtCustomerName.Text = row["CustomerName"].ToString();
            txtOldRequestStatus.Text = row["RequestStatus"].ToString();

            cboNewRequestStatus.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(7, RequestStatus.Barasi));
            cboNewRequestStatus.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(1, RequestStatus.Eghdam));
            cboNewRequestStatus.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(2, RequestStatus.Odat));
            cboNewRequestStatus.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(3, RequestStatus.Ebtal));
            cboNewRequestStatus.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(4, RequestStatus.Mosavab));
            cboNewRequestStatus.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(16, RequestStatus.Mokhalefat));

            foreach (var ser in serials)
            {
                if (ser.Key != txtSerial.Text)
                {
                    listRequests.Items.Add(ser.Key, ser.Value, CheckState.Checked, true);
                }
            }

            Modules.UDF.ToFarsiLanguage();
        }

        private void btnDeleteReviewNo_Click(object sender, EventArgs e)
        {
            if (txtReviewNo.Text.Length > 0)
            {
                DevExpress.XtraEditors.XtraMessageBoxArgs args1 = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args1.Icon = System.Drawing.SystemIcons.Question;
                args1.Text = "آیا از حذف فرم بررسی پیشنهاد حاضر اطمینان کامل حاصل دارید؟";
                args1.DefaultButtonIndex = 1;
                args1.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                DialogResult dlgRes1 = DevExpress.XtraEditors.XtraMessageBox.Show(args1);
                if (dlgRes1 == System.Windows.Forms.DialogResult.Yes)
                {
                    ReviewReportManager.DeleteReviewNo(txtSerial.Text);
                    txtReviewNo.ResetText();
                    DevExpress.XtraEditors.XtraMessageBox.Show("درخواست شما با موفقیت انجام شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
       
        private void btnDeleteExpertNo_Click(object sender, EventArgs e)
        {
            if (txtExpertNo.Text.Length > 0)
            {
                DevExpress.XtraEditors.XtraMessageBoxArgs args1 = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args1.Icon = System.Drawing.SystemIcons.Question;
                args1.Text = "آیا از حذف گزارش کارشناسی پیشنهاد حاضر اطمینان کامل حاصل دارید؟";
                args1.DefaultButtonIndex = 1;
                args1.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                DialogResult dlgRes1 = DevExpress.XtraEditors.XtraMessageBox.Show(args1);
                if (dlgRes1 == System.Windows.Forms.DialogResult.Yes)
                {
                    ReviewReportManager.DeleteExpertNo(txtSerial.Text);
                    txtExpertNo.ResetText();
                    DevExpress.XtraEditors.XtraMessageBox.Show("درخواست شما با موفقیت انجام شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtOldRequestStatus.Text == cboNewRequestStatus.Text)
            {
                DevExpress.XtraEditors.XtraMessageBoxArgs args1 = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args1.Icon = System.Drawing.SystemIcons.Question;
                args1.Text = "وضعیت قدیم و جدید هر دو یکی می باشند آیا درخواست شما صحیح می باشد؟";
                args1.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                DialogResult dlgRes1 = DevExpress.XtraEditors.XtraMessageBox.Show(args1);
                if (dlgRes1 != System.Windows.Forms.DialogResult.Yes)
                    return;
            }

            if (txtNote.Text.Contains(".........."))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً بخش خالی متن را تکمیل نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DevExpress.XtraEditors.XtraMessageBoxArgs args2 = new DevExpress.XtraEditors.XtraMessageBoxArgs();
            args2.Icon = System.Drawing.SystemIcons.Question;
            args2.Text = "آیا از انجام عملیات اطمینان کامل دارید؟";
            args2.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
            DialogResult dlgRes2 = DevExpress.XtraEditors.XtraMessageBox.Show(args2);
            if (dlgRes2 == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    List<string> serials = new List<string>();
                    serials.Add(txtSerial.Text);
                    foreach (CheckedListBoxItem item in listRequests.Items)
                    {
                        if (item.CheckState == CheckState.Checked)
                            serials.Add(item.Value.ToString());
                    }

                    btnSave.Enabled = false;
                    Application.DoEvents();

                    string groupId = txtGroupId.Text;
                    if (groupId.Length == 0)
                    {
                        groupId = Guid.NewGuid().ToString();
                    }

                    bool result = RequestManager.UpdateRequestStatus(serials.ToArray(), groupId, cboNewRequestStatus.Text, txtCustomerId.Text, txtCustomerName.Text, checkBox.Checked);
                    if (result & txtNote.Text.Trim().Length > 0)
                    {
                        dlgDataLogs.AddRequestLog(serials.ToArray(), this.ActionId, txtNote.Text.Trim());
                        if (txtExpertNo.Text.Length > 0)
                        {
                            dlgDataLogs.AddExpertLog(ChkSum.DelCheck(txtExpertNo.Text), this.ActionId, txtNote.Text.Trim());
                            ExpertReportManager.UpdateModifiedDate(ChkSum.DelCheck(txtExpertNo.Text));
                        }
                    }

                    btnSave.Enabled = true;
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

        private void cboNewRequestStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboNotes.Properties.Items.Clear();
            cboNotes.Text = string.Empty;
            cboNotes.Enabled = false;

            txtNote.Clear();
            txtNote.Enabled = false;
            btnSave.Enabled = true;

            if (cboNewRequestStatus.SelectedIndex == 0)//بررسی
            {
                this.ActionId = 7;
                txtNote.Text = string.Format("تغییر وضعیت پیشنهاد از حالت {0} به حالت {1}", txtOldRequestStatus.Text, cboNewRequestStatus.Text);
                txtNote.Enabled = false;
            }

            if (cboNewRequestStatus.SelectedIndex == 1)//اقدام
            {
                this.ActionId = 1;
                txtNote.Text = string.Format("تغییر وضعیت پیشنهاد از حالت {0} به حالت {1}", txtOldRequestStatus.Text, cboNewRequestStatus.Text);
                txtNote.Enabled = false;
            }

            if (cboNewRequestStatus.SelectedIndex == 2)//عودت
            {
                this.ActionId = 2;
                cboNotes.Enabled = true;
                cboNotes.Properties.Items.Add("طی نامه شماره .......... عودت گردید");
                cboNotes.Properties.Items.Add("طبق دستور آقای .......... عودت گردید");
                cboNotes.Properties.Items.Add("طبق نظر کارشناس عودت گردید");
                cboNotes.Properties.Items.Add("به دلیل .......... عودت گردید");
                cboNotes.Properties.Items.Add("پیشنهاد در حدود اختیارات حوزه/شعبه می باشد");
                cboNotes.Properties.Items.Add("ارسال سیستمی پیشنهاد طبق پردازش 41941 انجام نشده است");
                cboNotes.Properties.Items.Add("عدم ارائه مستندات درآمدی");
                cboNotes.Properties.Items.Add("مستندات درآمدی پوشش بدهی نامبرده را نمی دهد");
                cboNotes.Properties.Items.Add("نداشتن معدل حساب");
                cboNotes.Properties.Items.Add("NPL شعبه بالا می باشد");
                cboNotes.Properties.Items.Add("پایین بودن رتبه اعتبارسنجی");
                cboNotes.Properties.Items.Add("عدم ارائه نامه کتبی جهت معرفی متقاضی از صاحب حساب دارای معدل مطلوب");
                cboNotes.Properties.Items[0].CheckState = CheckState.Checked;
                txtNote.Text = cboNotes.Properties.Items[0].Value.ToString();
                cboNotes.Enabled = true;
                txtNote.Enabled = true;
            }

            if (cboNewRequestStatus.SelectedIndex == 3)//ابطال
            {
                this.ActionId = 3;
                cboNotes.Properties.Items.Add("پیشنهاد باطل شد");
                cboNotes.Properties.Items.Add("طبق درخواست شعبه پیشنهاد باطل شد");
                cboNotes.Properties.Items.Add("طبق درخواست حوزه پیشنهاد باطل شد");
                cboNotes.Properties.Items.Add("طبق نظر کارشناس باطل گردید");
                cboNotes.Properties.Items[0].CheckState = CheckState.Checked;
                txtNote.Text = cboNotes.Properties.Items[0].Value.ToString();
                cboNotes.Enabled = true;
                txtNote.Enabled = true;
            }

            if (cboNewRequestStatus.SelectedIndex == 4)//مصوب
            {
                this.ActionId = 4;
                txtNote.Text = "مصوبه به شعبه ابلاغ شد";
            }
            if (cboNewRequestStatus.SelectedIndex == 5)//مخالفت
            {
                this.ActionId = 16;
                txtNote.Text = "با پیشنهاد شعبه طی نامه شماره .......... مخالفت گردید";
                txtNote.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboNotes_EditValueChanged(object sender, EventArgs e)
        {
            txtNote.ResetText();
            List<string> list = new List<string>();
            foreach (CheckedListBoxItem item in cboNotes.Properties.Items)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    list.Add(item.Value.ToString());
                }
            }

            if (list.Count > 1)
            {
                StringBuilder sb = new StringBuilder();
                int counter = 0;
                sb.AppendLine("پیشنهاد حاضر به دلایل ذیل عودت گردید:");
                foreach (string str in list)
                    sb.AppendLine(++counter + "-" + str);
                txtNote.Text = sb.ToString().Trim();
            }
            else if (list.Count == 1)
            {
                txtNote.Text = list[0];
            }
        }

        private void btnAddLinkedRequest_Click(object sender, EventArgs e)
        {
            dlgAddLinkedRequest dlg = new dlgAddLinkedRequest(this, thisRow);
            DialogResult dlgRes = dlg.ShowDialog();
            if (dlgRes == System.Windows.Forms.DialogResult.OK)
            {
                listRequests.Items.Add(dlg.RequestSerial, dlg.RequestID, CheckState.Checked, true);
            }
        }
    }
}
