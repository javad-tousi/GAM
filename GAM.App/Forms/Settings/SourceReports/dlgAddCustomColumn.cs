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
    public partial class dlgAddCustomColumn : DevExpress.XtraEditors.XtraForm
    {
        public DataTable TableCustomColumns { get; set; }
        public int IndexOfRow { get; set; }

        public dlgAddCustomColumn(DataTable table)
        {
            InitializeComponent();

            this.TableCustomColumns = table;
            this.IndexOfRow = -1;
        }

        public dlgAddCustomColumn(DataRow row)
        {
            InitializeComponent();

            txtName.Text = row["Name"].ToString();
            txtCaption.Text = row["Caption"].ToString();
            cboType.Text = row["Type"].ToString();
            txtExtension.Text = row["Extension"].ToString();
            cboUnitPrice.Text = row["UnitPrice"].ToString();
            this.TableCustomColumns = row.Table;
            this.IndexOfRow = row.Table.Rows.IndexOf(row);
            btnAddCustomColumn.Text = "ویرایش اطلاعات";
            btnDeleteCustomColumn.Enabled = true;
        }

        private void btnAddCustomColumn_Click(object sender, EventArgs e)
        {
            if (!CheckInputValues())
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات ورودی ناقص می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.IndexOfRow >= 0)
            {
                DataRow row = this.TableCustomColumns.Rows[this.IndexOfRow];
                row["Name"] = txtName.Text.Trim();
                row["Caption"] = txtCaption.Text.Trim();
                row["Type"] = cboType.Text.Trim();
                row["Extension"] = txtExtension.Text.Trim();
                row["UnitPrice"] = cboUnitPrice.Text;
            }
            else
            {
                int count = this.TableCustomColumns.AsEnumerable().Count(x => x["Name"].ToString() == txtName.Text.Trim());
                if (count == 0)
                {
                    DataRow newRow = this.TableCustomColumns.NewRow();
                    newRow["Name"] = txtName.Text.Trim();
                    newRow["Caption"] = txtCaption.Text.Trim();
                    newRow["Type"] = cboType.Text.Trim();
                    newRow["Extension"] = txtExtension.Text.Trim();
                    newRow["UnitPrice"] = cboUnitPrice.Text;

                    this.TableCustomColumns.Rows.Add(newRow);
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("نام ستون سفارشی تکراری می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDeleteCustomColumn_Click(object sender, EventArgs e)
        {
            if (this.IndexOfRow >= 0)
            {
                this.TableCustomColumns.Rows.RemoveAt(this.IndexOfRow);
                this.Close();
            }
        }

        private bool CheckInputValues()
        {
            if (txtName.Text.Length > 0 &
                txtCaption.Text.Length > 0 &
                txtExtension.Text.Length > 0 &
                cboType.Text.Length > 0)
            {
                return true;
            }
            return false;
        }

    }
}
