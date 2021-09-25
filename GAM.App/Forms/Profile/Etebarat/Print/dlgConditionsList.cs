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

namespace GAM.Forms.Profile.Etebarat.Print
{
    public partial class dlgConditionsList : DevExpress.XtraEditors.XtraForm
    {
        public dlgConditionsList()
        {
            InitializeComponent();
            LoadData();
            txtSearch1.Select();
            Modules.UDF.ToFarsiLanguage();
        }

        private void tabPage1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tabControl.SelectedTabPageIndex == 0)
            {
                txtSearch1.Focus();
                txtSearch1.SelectAll();
            }

            if (tabControl.SelectedTabPageIndex == 1)
            {
                txtSearch2.Focus();
                txtSearch2.SelectAll();
            }
        }

        private void LoadData() 
        {
            DataTable tblConditions = Facilitys.GetConditions();
            if (tblConditions.Rows.Count > 0)
            {
                DataTable dataTable1 = tblConditions.AsEnumerable().Where(x => bool.Parse(x["IsEnable"].ToString()) & x["Category"].ToString() != "اطلاعیه").CopyToDataTable();
                DataTable dataTable2 = tblConditions.AsEnumerable().Where(x => bool.Parse(x["IsEnable"].ToString()) & x["Category"].ToString() == "اطلاعیه").CopyToDataTable();
                gridControl1.DataSource = dataTable1;
                gridControl2.DataSource = dataTable2;
                txtSearch1.Select();
            }
        }

        #region TabPage 1

        private void txtSearch1_EditValueChanged(object sender, EventArgs e)
        {
            if (gridControl1.DataSource != null)
            {
                (gridControl1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Content LIKE '%{0}%'", txtSearch1.Text.Replace("ئ", "ی").Replace("ك", "ک"));
            }
        }

        private void txtSearch1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSearch1.ResetText();
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.XtraInputBoxArgs args = new DevExpress.XtraEditors.XtraInputBoxArgs();
            args.Caption = "ورود اطلاعات";
            args.Editor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            args.Prompt = "لطفاً متن شرط خود را وارد نمایید";
            object result = DevExpress.XtraEditors.XtraInputBox.Show(args);
            if (result != null)
            {
                if (result.ToString().Length > 0)
                {
                    if (Facilitys.Insert("سایر", result.ToString()))
                    {
                        Facilitys.Fill();
                        LoadData();
                    }
                }

            }
        }

        private void repository1btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
            args.Icon = System.Drawing.SystemIcons.Warning;
            args.Text = "آیا مایل به حذف شرط مورد نظر می باشید؟";
            args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
            DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
            if (dlgRes == System.Windows.Forms.DialogResult.Yes)
            {
                if (Facilitys.Delete(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString()))
                {
                    Facilitys.Fill();
                    LoadData();
                }
            }
        }

        private void repository1btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.XtraInputBoxArgs args = new DevExpress.XtraEditors.XtraInputBoxArgs();
            args.Caption = "بروزرسانی اطلاعات";
            args.Editor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            args.Prompt = "لطفاً متن جدید خود را وارد نمایید";
            args.DefaultResponse = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Content").ToString();
            object result = DevExpress.XtraEditors.XtraInputBox.Show(args);
            if (result != null)
            {
                if (Facilitys.Update(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString(), result.ToString()))
                {
                    Facilitys.Fill();
                    LoadData();
                }
            }
        }

        #endregion

        #region TabPage 2

        private void txtSearch2_EditValueChanged(object sender, EventArgs e)
        {
            if (gridControl2.DataSource != null)
            {
                (gridControl2.DataSource as DataTable).DefaultView.RowFilter = string.Format("Content LIKE '%{0}%'", txtSearch2.Text.Replace("ئ", "ی").Replace("ك", "ک"));
            }
        }

        private void txtSearch2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSearch2.ResetText();
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.XtraInputBoxArgs args = new DevExpress.XtraEditors.XtraInputBoxArgs();
            args.Caption = "ورود اطلاعات";
            args.Editor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            args.Prompt = "لطفاً متن اطلاعیه خود را وارد نمایید";
            object result = DevExpress.XtraEditors.XtraInputBox.Show(args);

            if (result != null)
            {
                if (Facilitys.Insert("اطلاعیه", result.ToString()))
                {
                    Facilitys.Fill();
                    LoadData();
                }
            }
        }

        private void repository2btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
            args.Icon = System.Drawing.SystemIcons.Warning;
            args.Text = "آیا مایل به حذف اطلاعیه مورد نظر می باشید؟";
            args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
            DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
            if (dlgRes == System.Windows.Forms.DialogResult.Yes)
            {
                if (Facilitys.Delete(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ID").ToString()))
                {
                    Facilitys.Fill();
                    LoadData();
                }
            }
        }

        private void repository2btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.XtraInputBoxArgs args = new DevExpress.XtraEditors.XtraInputBoxArgs();
            args.Caption = "بروزرسانی اطلاعات";
            args.Editor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            args.Prompt = "لطفاً متن جدید خود را وارد نمایید";
            args.DefaultResponse = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Content").ToString();
            object result = DevExpress.XtraEditors.XtraInputBox.Show(args);
            if (result != null)
            {
                if (Facilitys.Update(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ID").ToString(), result.ToString()))
                {
                    Facilitys.Fill();
                    LoadData();
                }
            }
        }

        #endregion   
    }
}
