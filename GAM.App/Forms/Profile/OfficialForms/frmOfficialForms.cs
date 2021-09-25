using GAM.Forms.Information.Library;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using GAM.Dialogs;
using GAM.Forms.Profile.Etebarat.Library;
using GAM.Connections;

namespace GAM.Forms.Profile.OfficialForms
{
    public partial class frmOfficeForms : DevExpress.XtraEditors.XtraForm
    {
        string DefaultSearch = string.Empty;

        public frmOfficeForms(string strSearch)
        {
            InitializeComponent();
            this.DefaultSearch = strSearch;
            Modules.UDF.ToFarsiLanguage();
            Startup();
        }

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            Filter(txtSearch.Text);
        }

        private void txtSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            (gridControl.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            txtSearch.ResetText();
            txtSearch.Focus();
        }

        private void repositorybtnFavoriteYellow_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
            string id = gridView.GetFocusedRowCellValue("ID").ToString();
            string favorites = gridView.GetFocusedRowCellValue("Favorites").ToString();
            bool queryResult = OfficialFormsManager.UpdateFavorites(id, favorites.Replace(string.Format("[{0}]", Users.MyUserID), ""));
            if (queryResult)
            {
                string text = txtSearch.Text;
                int focusedRowHandle = gridView.FocusedRowHandle;
                int topRowIndex = gridView.TopRowIndex;
                OfficialFormsManager.Fill();
                gridControl.DataSource = OfficialFormsManager.GetAllForms();
                gridView.FocusedRowHandle = focusedRowHandle;
                gridView.TopRowIndex = topRowIndex;
                if (text.Length > 0)
                    Filter(text);
            }
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void repositorybtnFavoriteBlue_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
            string id = gridView.GetFocusedRowCellValue("ID").ToString();
            string favorites = gridView.GetFocusedRowCellValue("Favorites").ToString();
            bool queryResult = OfficialFormsManager.UpdateFavorites(id, favorites + string.Format("[{0}]", Users.MyUserID));
            if (queryResult)
            {
                string text = txtSearch.Text;
                int focusedRowHandle = gridView.FocusedRowHandle;
                int topRowIndex = gridView.TopRowIndex;
                OfficialFormsManager.Fill();
                gridControl.DataSource = OfficialFormsManager.GetAllForms();
                gridView.FocusedRowHandle = focusedRowHandle;
                gridView.TopRowIndex = topRowIndex;
                if (text.Length > 0)
                    Filter(text);
            }
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void btnAddDocument_Click(object sender, EventArgs e)
        {
            new dlgAddOfficeForm().ShowDialog();
        }

        private void btnEditDocument_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.XtraInputBoxArgs args = new DevExpress.XtraEditors.XtraInputBoxArgs();
            args.Caption = "رمز ویرایش";
            args.Editor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            var textEdit = args.Editor as DevExpress.XtraEditors.TextEdit;
            textEdit.Properties.UseSystemPasswordChar = true;
            args.Prompt = "لطفاً رمز ویرایش فرم را وارد نمایید";
            object result = DevExpress.XtraEditors.XtraInputBox.Show(args);
            if (result != null)
            {
                if (result.ToString() == "11900")
                {
                    string id = gridView.GetFocusedRowCellValue("ID").ToString();
                    string subject = gridView.GetFocusedRowCellValue("Subject").ToString();
                    string category = gridView.GetFocusedRowCellValue("Category").ToString().Replace("(", "").Replace(")", "");
                    string receiverName = gridView.GetFocusedRowCellValue("ReceiverName").ToString();
                    string signatories = gridView.GetFocusedRowCellValue("Signatories").ToString();
                    int focusedRowHandle = gridView.FocusedRowHandle;
                    new dlgAddOfficeForm(id, subject, category, receiverName, signatories).ShowDialog();
                    btnRefresh_Click(null, EventArgs.Empty);
                    txtSearch_EditValueChanged(null, EventArgs.Empty);
                    gridView.FocusedRowHandle = focusedRowHandle;
                }
            }
        }

        private void btnOpenDocument_Click(object sender, EventArgs e)
        {
            try
            {
                btnOpenDocument.Enabled = false;
                Application.DoEvents();
                string id = gridView.GetFocusedRowCellValue("ID").ToString();
                WordDocument.OpenWordFile(OLEDB.GetFormFile(id + ".docx"), true, false, true);
                btnOpenDocument.Enabled = true;
            }
            catch
            {
            }
        }

        private void btnCopyContent_Click(object sender, EventArgs e)
        {
            if (gridView.FocusedRowHandle >= 0)
            {
                btnCopyContent.Enabled = false;
                Application.DoEvents();
                new System.Threading.Thread(delegate() { CopyForm(); }).Start();
                btnCopyContent.Enabled = true;
            }
        }

        private void btnFavoritesList_Click(object sender, EventArgs e)
        {
            (gridControl.DataSource as DataTable).DefaultView.RowFilter = "Favorite = 1";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            OfficialFormsManager.Fill();
            gridControl.DataSource = OfficialFormsManager.GetAllForms();
        }

        private void CopyForm()
        {
            try
            {
                if (gridView.FocusedRowHandle >= 0)
                {
                    string id = gridView.GetFocusedRowCellValue("ID").ToString();
                    Microsoft.Office.Interop.Word.Document doc = WordDocument.OpenWordFile(OLEDB.GetFormFile(id + ".docx"), false, true, true);
                    doc.Content.Copy();
                    doc.Close();
                    DevExpress.XtraEditors.XtraMessageBox.Show("محتوای فرم کپی شد", "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Filter(string text)
        {
            try
            {
                string criteria = string.Format("Category LIKE '%{0}%' OR Convert(ID, System.String) LIKE '%{0}%' OR Subject LIKE '%{0}%'", text);
                (gridControl.DataSource as DataTable).DefaultView.RowFilter = criteria;
            }
            catch (Exception)
            {
                (gridControl.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void gridView_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column.Name == "colbtnFavorite")
                {
                    string value = gridView.GetRowCellValue(e.RowHandle, gridView.Columns["Favorites"]).ToString();
                    if (value.Contains(string.Format("[{0}]", Users.MyUserID)))
                    {
                        e.RepositoryItem = repositorybtnFavoriteYellow;
                    }
                    else
                        e.RepositoryItem = repositorybtnFavoriteBlue;
                }
            }
        }

        private void Startup()
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
            Application.DoEvents();
            if (OfficialFormsManager.DataForms == null)
                OfficialFormsManager.Fill();
            gridControl.DataSource = OfficialFormsManager.GetAllForms();
            (gridControl.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            txtSearch.Text = this.DefaultSearch;
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }
    }
}
