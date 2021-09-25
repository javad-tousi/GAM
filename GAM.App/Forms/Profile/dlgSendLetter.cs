using DevExpress.XtraEditors;
using GAM.Dialogs;
using GAM.Modules;
using GAM.Forms.Profile.Etebarat.Library;
using GAM.Forms.Information.Library;
using GAM.Forms.Settings.Library;
using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using Stimulsoft.Report;
using GAM.Forms.Information;

namespace GAM.Forms.Profile
{
    public partial class dlgSendLetter : DevExpress.XtraEditors.XtraForm
    {
        public dlgSendLetter()
        {
            InitializeComponent();
            Modules.UDF.ToFarsiLanguage();
            Notes.Fill();
            LoadNotesRows();
            radioGroup1_SelectedIndexChanged(null, EventArgs.Empty);
            radioGroup2_SelectedIndexChanged(null, EventArgs.Empty);
            txtLetterText.Text = "باسلام و احترام/ عطف به پیشنهاد شماره ................. مورخ ........... شایسته است مدارک و مستندات مشروحه ذیل را حداکثر ظرف مدت 7 روزکاری و بصورت کتبی از طریق اتوماسیون اداری جهت تکمیل پرونده متقاضی به این اداره ارسال فرمایند:";
            txtLetterText.Select();
        }

        private void txtSearch1_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSearch1.Text.Length > 0)
                (gridControl1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Note LIKE '%{0}%'", txtSearch1.Text.Replace("آ", "ا").Replace("ئ", "ی").Replace("ك", "ک"));
            else
                (gridControl1.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
        }

        private void txtSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSearch1.ResetText();
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridview = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DevExpress.Utils.DXMouseEventArgs mouseEventArgs = e as DevExpress.Utils.DXMouseEventArgs;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo = gridview.CalcHitInfo(mouseEventArgs.Location);

            if (hitInfo.InRow)
            {
                AddText(gridView1.GetFocusedRowCellValue("Note").ToString());
            }
        }

        private void repositorybtnInsert_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            AddText(gridView1.GetFocusedRowCellValue("Note").ToString());
        }

        #region Methods

        private void LoadNotesRows()
        {
            DataTable tblNotes = Notes.GetNotes();
            if (tblNotes.Rows.Count > 0)
            {
                var table = tblNotes.AsEnumerable().Where(x => x["UserID"].ToString().Length == 0 | x["UserID"].ToString() == Users.MyUserID.ToString());
                if (table.Count() > 0)
                    gridControl1.DataSource = table.CopyToDataTable();
                txtSearch1.Select();
            }
        }
    
        private void AddText(string text)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(txtLetterText.Text);
            txtLetterText.ResetText();
            sb.Append("> " + text);
            txtLetterText.Text = sb.ToString().Trim();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            InputBox input = new InputBox("لطفاً مینوت مورد نظر خود را در کادر بالا وارد نمایید");
            DialogResult dlgRes = input.ShowDialog();
            if (dlgRes == System.Windows.Forms.DialogResult.OK & input.InputValue.Trim().Length > 0)
            {
               bool res = Notes.Insert(Users.MyUserID, input.InputValue.Trim());
               if (res)
               {
                   DevExpress.XtraEditors.XtraMessageBox.Show("متن شما با موفقیت به لیست اضافه شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   Notes.Fill();
                   LoadNotesRows();
                   gridView1.FocusedRowHandle = gridView1.RowCount - 1;
               }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            if (row != null)
            {
                if (row["UserId"].ToString() != Users.MyUserID.ToString())
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("شما مجوز ویرایش این مینوت را ندارید", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int focusedRowHandle = gridView1.FocusedRowHandle;
                InputBox input = new InputBox("", row["Note"].ToString());
                DialogResult dlgRes = input.ShowDialog();
                if (dlgRes == System.Windows.Forms.DialogResult.OK & input.InputValue.Trim().Length > 0)
                {
                    bool res = Notes.Update(row["ID"].ToString(), input.InputValue.Trim());
                    if (res)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات شما موفقیت با ویرایش شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Notes.Fill();
                        LoadNotesRows();
                        gridView1.FocusedRowHandle = focusedRowHandle;
                        txtSearch1_EditValueChanged(null, EventArgs.Empty);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            if (row != null)
            {
                if (row["UserId"].ToString() != Users.MyUserID.ToString())
                {
                   DevExpress.XtraEditors.XtraMessageBox.Show("شما مجوز حذف این مینوت را ندارید", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   return;
                }
                DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args.Icon = System.Drawing.SystemIcons.Warning;
                args.Text = "آیا از حذف مینوت انتخاب شده اطمینان کامل حاصل دارید؟";
                args.DefaultButtonIndex = 1;
                args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    bool res = Notes.Delete(row["ID"].ToString());
                    if (res)
                    {
                        Notes.Fill();
                        LoadNotesRows();
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnPrint.Enabled = false;
            Application.DoEvents();
            StiOptions.Viewer.Windows.ShowEditorTool = false;
            StiOptions.Viewer.Windows.ShowBookmarksPanel = false;
            StiOptions.Viewer.Windows.ShowFindTool = false;
            StiOptions.Viewer.Windows.ShowSendEMailButton = false;

            StiReport report = new StiReport();
            report.Load(Application.StartupPath + "\\report1.mrt");
            (report.GetComponentByName("txtLetter") as Stimulsoft.Report.Components.StiText).Text = txtBranchName.Text.Trim() + "\n" + "موضوع: " + txtSubject.Text.Trim() + "\n" + txtLetterText.Text.Trim();

            report.Compile();
            report.Render();
            report.Show();
            btnPrint.Enabled = true;
        }

        #endregion
       
        private void btnSubmitMessage_Click(object sender, EventArgs e)
        {
            if (txtLetterText.Text.Length > 0)
            {

            }
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("متنی برای ارسال وجود ندارد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSendToUser_Click(object sender, EventArgs e)
        {
            if (txtBranchName.Text.Length == 0 | txtBranchName.Text == "نام گیرنده/شعبه")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("لطفا نام گیرنده را مشخص نمایید", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtSubject.Text.Length == 0 | txtSubject.Text == "موضوع نامه")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("لطفا موضوع نامه را مشخص نمایید", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtLetterText.TextLength == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("متن نامه خالی می باشد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dlgUsersList dlg = new dlgUsersList(Users.GetWorkGroupUsers(true), false);
            DialogResult dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                if (dlg.UserId > 0 & dlg.UserName.Length > 0)
                {
                    Letters.Insert(dlg.UserId, txtBranchName.Text, txtSubject.Text, txtLetterText.Text);
                    DevExpress.XtraEditors.XtraMessageBox.Show("نامه شما با موفقیت در سیستم ثبت و ارسال شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBranchName.Text = "نام گیرنده/شعبه";
                    txtSubject.Text = "موضوع نامه";
                    txtLetterText.Clear();
                    txtLetterText.Text = "باسلام و احترام/ عطف به پیشنهاد شماره ................. مورخ ........... شایسته است مدارک و مستندات مشروحه ذیل را حداکثر ظرف مدت 7 روزکاری و بصورت کتبی از طریق اتوماسیون اداری جهت تکمیل پرونده متقاضی به این اداره ارسال فرمایند:";
                    txtLetterText.Focus();
                    txtLetterText.Select();
                }
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
            args.Icon = System.Drawing.SystemIcons.Warning;
            args.Text = "آیا پاک کردن متن نامه اطمینان کامل حاصل دارید؟";
            args.DefaultButtonIndex = 1;
            args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
            DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
            if (dlgRes == System.Windows.Forms.DialogResult.Yes)
            {
                txtLetterText.Clear();
            }
        }

        private void txtSearch2_EditValueChanged(object sender, EventArgs e)
        {
            if (gridControl2.DataSource != null)
            {
                if (txtSearch2.Text.Length > 0)
                {
                    string criteria = string.Format("RegisteredUserName LIKE '%{0}%' OR Subject LIKE '%{0}%'", txtSearch2.Text);
                    (gridControl2.DataSource as DataTable).DefaultView.RowFilter = criteria;
                }
                else
                    (gridControl2.DataSource as DataTable).DefaultView.RowFilter = "";
            }
        }

        private void tabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tabControl.SelectedTabPage == tabPage2)
            {
                gridControl2.DataSource = Letters.GetLetters();
            }
        }

        private void repositoryCopyText_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (row != null)
            {
                string txt = row["BranchName"].ToString() + "\n" + "موضوع: " + row["Subject"].ToString() + "\n" + row["LetterText"].ToString();
                Clipboard.SetText(txt);
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex >= 0)
            {
                string value = radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Value.ToString();
                (gridControl1.DataSource as DataTable).DefaultView.RowFilter = string.Format("LegalPerson = '{0}'", value);
            }
        }

        private void radioGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup2.SelectedIndex >= 0)
            {
                string value = radioGroup2.Properties.Items[radioGroup2.SelectedIndex].Value.ToString();
                (gridControl1.DataSource as DataTable).DefaultView.RowFilter = string.Format("{0} = True", value);
            }
        }
    }
}