using System.Data;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using GAM.Forms.Information.Library;
using GAM.Dialogs;
using GAM.Forms.Profile.Etebarat.Library;
using GAM.Modules;

namespace GAM.Forms.Information
{
    public partial class dlgNotariesList : DevExpress.XtraEditors.XtraForm
    {
        public string NotaryId { get; set; }
        public string NotaryName { get; set; }

        public dlgNotariesList()
        {
            InitializeComponent();
            txtSearch.Select();
            Modules.UDF.ToFarsiLanguage();
            if (Notaries.GetNotaries().Rows.Count == 0)
                Notaries.Fill();
        }

        private void txtSearch_EditValueChanged(object sender, System.EventArgs e)
        {
            if (gridControl.DataSource != null)
            {
                try
                {
                    (gridControl.DataSource as DataTable).DefaultView.RowFilter = string.Format("NotarName LIKE '%{0}%' OR [NotaryNo]={0}", txtSearch.Text);
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

        private void btnExportToXlsx_Click(object sender, System.EventArgs e)
        {
            btnExportToXlsx.Enabled = false;
            Application.DoEvents();
            DevExportToXlsx.SaveAs(gridView);
            btnExportToXlsx.Enabled = true;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                gridView.Focus();
            }
        }

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SetSelectedRow();
            }
        }

        private void gridView_DoubleClick(object sender, System.EventArgs e)
        {
            SetSelectedRow();
        }

        private void SetSelectedRow()
        {
            if (gridView.GetFocusedDataRow() != null)
            {
                DataRow row = gridView.GetFocusedDataRow();
                this.NotaryId = row["NotaryID"].ToString();
                this.NotaryName = "دفتر اسناد رسمی شماره " + Numeral.ToFarsi(row["NotaryNo"].ToString()) + " - " + row["NotaryCity"].ToString();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dlgNotariesList_Shown(object sender, System.EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
            Application.DoEvents();
            gridControl.DataSource = Notaries.GetNotaries();
            gridView.GridControl = gridControl;
            (gridControl.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            txtSearch.Select();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }
    }
}
