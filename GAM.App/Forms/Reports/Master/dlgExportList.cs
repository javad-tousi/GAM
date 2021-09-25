using DevExpress.XtraEditors.Controls;
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
    public partial class dlgExportList : DevExpress.XtraEditors.XtraForm
    {
        public int SaveNumber { set; get; }
        public int SaveFormat { set; get; }

        public dlgExportList(DataSet[] items)
        {
            InitializeComponent();
            radioGroup1.SelectedIndex = 2;
            if (items.Length > 1)
            {
                radioGroup2.Enabled = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.SaveNumber = radioGroup1.SelectedIndex + 1;
            this.SaveFormat = radioGroup2.SelectedIndex + 1;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
