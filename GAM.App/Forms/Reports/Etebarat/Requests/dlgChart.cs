using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GAM.Forms.Reports.Etebarat.Requests
{
    public partial class dlgChart : DevExpress.XtraEditors.XtraForm
    {
        public dlgChart()
        {
            InitializeComponent();
        }

        private void btnExportToImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Title = "Save Report";
            saveDlg.Filter = "PNG File|*.png";
            saveDlg.ShowDialog();
            if (saveDlg.FileName != "")
            {
                chartControl.ExportToImage(saveDlg.FileName, System.Drawing.Imaging.ImageFormat.Png);
                System.Diagnostics.Process.Start(saveDlg.FileName);
            }
        }
    }
}
