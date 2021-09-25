using GAM.Dialogs;
using GAM.Forms.Settings.Library;
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
    public partial class frmSourceReports : DevExpress.XtraEditors.XtraForm
    {
        public frmSourceReports()
        {
            InitializeComponent();
            btnRefresh_Click(null, EventArgs.Empty);
        }

        private void repositoryShowMap_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
            if (row != null)
            {
                new dlgSourceMap(row).ShowDialog();
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
                Application.DoEvents(); 
                SourceReportsManager.Fill();
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            }
        }

        private void btnAddSource_Click(object sender, EventArgs e)
        {
            new dlgAddSourceReport().ShowDialog();
            gridControl.DataSource = SourceReportsManager.GetSourceReports();
        }

        private void repositoryShowTables_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
            if (row != null)
            {
                new dlgSourceTables(row["SourceID"].ToString()).ShowDialog();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
            btnRefresh.Enabled = false;
            Application.DoEvents();
            int id = gridView.FocusedRowHandle;
            SourceReportsManager.Fill();
            DataTable table = SourceReportsManager.GetSourceReports();
            table.Columns.Add("LastDate");
            foreach (DataRow r in table.Rows)
            {
                r["LastDate"] = UDF.GetDateSerialAsFormated(int.Parse(SourceReportsManager.GetSourceTables(r["SourceID"].ToString()).Last()));
            }

            gridControl.DataSource = table;
            gridView.FocusedRowHandle = id;
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            btnRefresh.Enabled = true;
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            repositoryShowMap_ButtonClick(null, null);
        }
    }
}
