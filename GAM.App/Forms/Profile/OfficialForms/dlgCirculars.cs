using GAM.Forms.Information.Library;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using GAM.Dialogs;
using GAM.Forms.Profile.Etebarat.Library;
using GAM.Connections;

namespace GAM.Forms.Profile.OfficialForms
{
    public partial class dlgCirculars : DevExpress.XtraEditors.XtraForm
    {
        public dlgCirculars()
        {
            InitializeComponent();
            Modules.UDF.ToFarsiLanguage();
            Startup();
        }

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            Filter(txtSearch.Text);
        }

        private void txtSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            (gridControl.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            txtSearch.ResetText();
            txtSearch.Focus();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CircularsManager.Fill();
            gridControl.DataSource = CircularsManager.GetAllCirculars();
        }

        private void Filter(string text)
        {
            try
            {
                string criteria = string.Format("Category LIKE '%{0}%' OR DocumentID LIKE '%{0}%' OR Subject LIKE '%{0}%'", text);
                (gridControl.DataSource as DataTable).DefaultView.RowFilter = criteria;
            }
            catch (Exception)
            {
                (gridControl.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void gridView_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column.Name == "colFavorite")
                {
                    string value = gridView.GetRowCellValue(e.RowHandle, gridView.Columns["Favorites"]).ToString();
                    if (value.Contains(string.Format("[{0}]", Users.MyUserID)))
                        e.RepositoryItem = repositorybtnFavoriteYellow;
                    else
                        e.RepositoryItem = repositorybtnFavoriteBlue;
                }
            }
        }

        private void Startup()
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
            Application.DoEvents();
            if (CircularsManager.DataCirculars == null)
                CircularsManager.Fill();
            gridControl.DataSource = CircularsManager.GetAllCirculars();
            (gridControl.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void repositoryDownloadLink_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (gridView.GetFocusedDataRow() != null)
            {
                Process.Start(gridView.GetFocusedDataRow()["DownloadLink"].ToString());
            }
        }
    }
}
