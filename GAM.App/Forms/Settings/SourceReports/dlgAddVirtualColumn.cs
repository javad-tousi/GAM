using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
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

namespace GAM.Forms.Settings.SourceReports
{
    public partial class dlgAddVirtualColumn : DevExpress.XtraEditors.XtraForm
    {
        GridView viewVirtualColumns;

        public dlgAddVirtualColumn(GridView dg)
        {
            InitializeComponent();
            this.viewVirtualColumns = dg;
            UDF.ToEnglishLanguage();
        }
        public dlgAddVirtualColumn(GridView dg, DataRow row)
        {
            InitializeComponent();
            this.viewVirtualColumns = dg;

            txtName.Text = row["Name"].ToString();
            txtCaption.Text = row["Caption"].ToString();
            cboType.Text = row["Type"].ToString();
            cboUnitPrice.Text = row["UnitPrice"].ToString();
            btnAddColumn.Text = "ویرایش اطلاعات";
            UDF.ToEnglishLanguage();
        }

        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            if (!CheckInputValues())
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات ورودی ناقص می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable table = (DataTable)viewVirtualColumns.GridControl.DataSource;
            if (btnAddColumn.Text == "ویرایش اطلاعات")
            {
                DataRow row = viewVirtualColumns.GetFocusedDataRow();
                row["Name"] = txtName.Text.Trim();
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
                    newRow["Name"] = txtName.Text.Trim();
                    newRow["Caption"] = txtCaption.Text.Replace("ي", "ی").Replace("ك", "ک").Trim();
                    newRow["Type"] = cboType.Text;
                    newRow["UnitPrice"] = cboUnitPrice.Text;

                    table.Rows.Add(newRow);
                    viewVirtualColumns.GridControl.DataSource = table;
                    viewVirtualColumns.BestFitColumns();
                    DevExpress.XtraEditors.XtraMessageBox.Show("ستون شما با موفقیت ایجاد شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    viewVirtualColumns.FocusedRowHandle = viewVirtualColumns.RowCount - 1;
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
            if (txtName.Text.Length > 0 &
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
    }
}
