using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Settings.SourceReports
{
    public partial class dlgAddBaseColumn : DevExpress.XtraEditors.XtraForm
    {
        GridView viewReport;
        GridView viewBaseColumns;

        public dlgAddBaseColumn(GridView gv, GridView dg)
        {
            InitializeComponent();
            this.viewReport = gv;
            this.viewBaseColumns = dg;

            txtIndex.Value = viewReport.FocusedColumn.VisibleIndex;
            txtHeaderLocationX.Value = viewReport.FocusedColumn.VisibleIndex;
            txtHeaderLocationY.Value = viewReport.FocusedRowHandle;
        }
        public dlgAddBaseColumn(GridView gv, GridView dg, DataRow row)
        {
            InitializeComponent();
            this.viewReport = gv;
            this.viewBaseColumns = dg;

            txtIndex.Text = row["Index"].ToString();
            txtName.Text = row["Name"].ToString();
            txtHeaderText.Text = row["HeaderText"].ToString();
            txtHeaderLocationX.Text = row["HeaderLocation"].ToString().Split(',').First();
            txtHeaderLocationY.Text = row["HeaderLocation"].ToString().Split(',').Last();
            txtCaption.Text = row["Caption"].ToString();
            cboType.Text = row["Type"].ToString();
            cboUnitPrice.Text = row["UnitPrice"].ToString();
            btnAddColumn.Text = "ویرایش اطلاعات";
        }

        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            if (!CheckInputValues())
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات ورودی ناقص می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable table = (DataTable)viewBaseColumns.GridControl.DataSource;
            if (btnAddColumn.Text == "ویرایش اطلاعات")
            {
                DataRow row = viewBaseColumns.GetFocusedDataRow();
                row["Index"] = txtIndex.Text.Trim();
                row["Name"] = txtName.Text.Trim();
                row["HeaderText"] = txtHeaderText.Text.Trim();
                row["HeaderLocation"] = string.Format("{0}, {1}", txtHeaderLocationX.Value, txtHeaderLocationY.Value);
                row["Caption"] = txtCaption.Text.Replace("ي", "ی").Replace("ك", "ک").Trim();
                row["Type"] = cboType.Text;
                row["UnitPrice"] = cboUnitPrice.Text;
                this.Close();
            }
            else
            {
                int count = table.AsEnumerable().Count(x => x["Name"].ToString() == txtName.Text.Trim());
                if (count == 0)
                {
                    DataRow newRow = table.NewRow();
                    newRow["Index"] = txtIndex.Text.Trim();
                    newRow["Name"] = txtName.Text.Trim();
                    newRow["HeaderText"] = txtHeaderText.Text.Trim();
                    newRow["HeaderLocation"] = string.Format("{0}, {1}", txtHeaderLocationX.Value, txtHeaderLocationY.Value);
                    newRow["Caption"] = txtCaption.Text.Replace("ي", "ی").Replace("ك", "ک").Trim();
                    newRow["Type"] = cboType.Text;
                    newRow["UnitPrice"] = cboUnitPrice.Text;

                    table.Rows.Add(newRow);
                    viewBaseColumns.GridControl.DataSource = table;
                    viewBaseColumns.BestFitColumns();
                    DevExpress.XtraEditors.XtraMessageBox.Show("ستون شما با موفقیت ایجاد شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    viewBaseColumns.FocusedRowHandle = viewBaseColumns.RowCount - 1;
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("نام ستون تکراری می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private bool CheckInputValues() 
        {
            if (txtIndex.Text.Length > 0 & 
                txtName.Text.Length > 0 & 
                txtHeaderLocationX.Value >= 0 &
                txtHeaderLocationY.Value >= 0 & 
                txtCaption.Text.Length > 0 & 
                cboType.Text.Length > 0)
            {
                return true;
            }
            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtIndex_EditValueChanged(object sender, EventArgs e)
        {
            txtHeaderLocationX.Value = (int)txtIndex.Value;
            viewReport.FocusedColumn = viewReport.GetVisibleColumn((int)txtIndex.Value);
            foreach (GridColumn col in viewReport.Columns)
            {
                col.AppearanceCell.BackColor = Color.White;
            }
            viewReport.FocusedColumn.AppearanceCell.BackColor = Color.Gainsboro;
        }

        private void txtHeaderLocationX_EditValueChanged(object sender, EventArgs e)
        {
            viewReport.FocusedColumn = viewReport.GetVisibleColumn((int)txtHeaderLocationX.Value);
        }

        private void txtHeaderLocationY_EditValueChanged(object sender, EventArgs e)
        {
            viewReport.FocusedRowHandle = (int)txtHeaderLocationY.Value;
        }

        private void btnSetHeaderText_Click(object sender, EventArgs e)
        {
            int x = viewReport.FocusedColumn.VisibleIndex;
            int y = viewReport.FocusedRowHandle;
            txtHeaderText.Text = viewReport.GetFocusedRowCellValue(viewReport.FocusedColumn.FieldName).ToString();
        }
    }
}
