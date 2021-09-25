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

namespace GAM.Forms.Reports.Master
{
    public partial class dlgResume : DevExpress.XtraEditors.XtraForm
    {
        public dlgResume(DataTable dt)
        {
            InitializeComponent();
            gridControl.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DevExportToXlsx.SaveAs(gridView);
        }
    }
}
