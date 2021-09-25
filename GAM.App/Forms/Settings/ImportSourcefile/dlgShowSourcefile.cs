using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GAM.Forms.Settings.ImportSourcefile
{
    public partial class dlgShowSourcefile : DevExpress.XtraEditors.XtraForm
    {
        public dlgShowSourcefile()
        {
            InitializeComponent();
        }

        private void dlgShowSourcefile_Load(object sender, EventArgs e)
        {
            if (gridControl.DataSource != null)
            {
                gridView.OptionsView.ColumnAutoWidth = false;
                gridView.BestFitColumns();
            }
        }
    }
}
