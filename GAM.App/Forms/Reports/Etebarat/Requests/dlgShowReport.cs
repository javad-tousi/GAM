using DevExpress.XtraGrid.Columns;
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

namespace GAM.Forms.Reports.Etebarat.Requests
{
    public partial class dlgShowReport : DevExpress.XtraEditors.XtraForm
    {
        public dlgShowReport(DataTable tbl, string text)
        {
            InitializeComponent();
            this.Text = text;
            gridControl.DataSource = tbl;
            gridView.BestFitColumns();
            foreach (GridColumn col in gridView.Columns)
            {
                if (tbl.Columns[col.FieldName].DataType == typeof(double))
                {
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    col.DisplayFormat.FormatString = "n0";
                }
            }
        }

        private void btnExportToXlsx_Click(object sender, EventArgs e)
        {
            btnExportToXlsx.Enabled = false;
            Application.DoEvents();
            DevExportToXlsx.SaveAs(gridView);
            btnExportToXlsx.Enabled = true;
        }
    }
}
