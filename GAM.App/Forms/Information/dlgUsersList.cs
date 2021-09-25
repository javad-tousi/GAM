using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using GAM.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace GAM.Forms.Information
{
    public partial class dlgUsersList : DevExpress.XtraEditors.XtraForm
    {
        #region Main Events

        public dlgUsersList(DataTable users, bool multiSelect)
        {
            InitializeComponent();
            if (multiSelect)
            {
                colIsChecked.VisibleIndex = 0;
                this.IsMultiSelect = multiSelect;
                pnlBottom.Visible = true;
            }

            gridControl.DataSource = users;

            for (int i = 0; i < users.Rows.Count; i++)
                users.Rows[i]["IsChecked"] = false;

            Modules.UDF.ToFarsiLanguage();
            txtSearch.Select();
        }

        #endregion   
   
        #region Properties

        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<int> SelectedUsersId { get; set; }
        bool IsMultiSelect = false;

        #endregion

        #region Panel Top

        private void txtSearch_EditValueChanged(object sender, System.EventArgs e)
        {
            if (gridControl.DataSource != null)
            {
                try
                {
                    (gridControl.DataSource as DataTable).DefaultView.RowFilter = string.Format("UserName LIKE '%{0}%' OR Convert([UserID], System.String) LIKE '%{0}%'", txtSearch.Text);
                }
                catch
                {
                    (gridControl.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                }
            }
        }

        private void txtSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSearch.ResetText();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                gridView.Focus();
            }
        }

        #endregion

        #region GridView

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (!this.IsMultiSelect)
            {
                if (e.KeyData == Keys.Enter)
                {
                    SetSelectedRow();
                }
            }
        }

        private void gridView_DoubleClick(object sender, System.EventArgs e)
        {
            if (!this.IsMultiSelect)
            {
                SetSelectedRow();
            }
        }

        private void gridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                string value = gridView.GetRowCellValue(e.RowHandle, "IsChecked").ToString();
                if (value == bool.TrueString)
                    e.Appearance.BackColor2 = System.Drawing.Color.Aquamarine;
            }
        }

        private void SetSelectedRow()
        {
            if (gridView.GetFocusedDataRow() != null)
            {
                DataRow row = gridView.GetFocusedDataRow();
                this.UserId = Numeral.AnyToInt32(row["UserID"]);
                this.UserName = row["UserName"].ToString();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        
        #endregion

        #region Panel Bottom

        private void btnOk_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < gridView.RowCount; i++)
            {
                DataRow row = gridView.GetDataRow(i);
                if (bool.Parse(row["IsChecked"].ToString()))
                    list.Add(int.Parse(row["UserID"].ToString()));
            }

            this.SelectedUsersId = list;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion

        private void btnExportToXlsx_Click(object sender, EventArgs e)
        {
            btnExportToXlsx.Enabled = false;
            Application.DoEvents();
            DevExportToXlsx.SaveAs(gridView);
            btnExportToXlsx.Enabled = true;
        }
    }
}
