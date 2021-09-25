
using GAM.Forms.Information;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using GAM.Dialogs;
using GAM.Forms.Profile.Etebarat.Library;

namespace GAM.Forms.Profile.Etebarat.Arshive
{
    public partial class dlgAllLoanFiles : DevExpress.XtraEditors.XtraForm
    {
        public string FileId { get; set; }
        public string CoverNo { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string CustomerName { get; set; }

        public dlgAllLoanFiles(string branchId)
        {
            InitializeComponent();
            Modules.UDF.ToFarsiLanguage();
            this.BranchId = branchId;
            FilesManager.LoadEvent += FilesManager_LoadEvent;
            Startup();
        }

        private void txtSearch_EditValueChanged(object sender, System.EventArgs e)
        {
            if (gridControl.DataSource != null)
            {
                string criteria = "CustomerName LIKE '%" + txtSearch.Text + "%' OR Convert([IndicatorID], System.String) LIKE '%" + txtSearch.Text + "%' OR Convert([FileID], System.String) LIKE '%" + txtSearch.Text + "%'";
                (gridControl.DataSource as DataTable).DefaultView.RowFilter = criteria;
            }
        }

        private void txtSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSearch.ResetText();
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            try
            {
                btnRefresh.Enabled = false;
                progressBar.Show();
                Application.DoEvents();
                FilesManager.FillFilesWithCovers();
                gridControl.DataSource = FilesManager.TableAllFilesAndCovers;
                btnRefresh.Enabled = true;
            }
            catch
            {
            }
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
                this.FileId = row["FileID"].ToString();
                this.CoverNo = row["CoverNo"].ToString();
                this.BranchId = row["BranchID"].ToString();
                this.BranchName = row["BranchName"].ToString();
                this.CustomerName = row["CustomerName"].ToString();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Startup()
        {
            progressBar.Show();
            Application.DoEvents();
            if (FilesManager.TableAllFilesAndCovers.Rows.Count == 0)
                FilesManager.FillFilesWithCovers();
            else
                progressBar.Hide();

            if (this.BranchId == "*" | this.BranchId == "")
                gridControl.DataSource = FilesManager.TableAllFilesAndCovers;
            else
                gridControl.DataSource = FilesManager.TableAllFilesAndCovers.AsEnumerable().Where(x => x["BranchID"].ToString() == this.BranchId).CopyToDataTable();
            txtSearch.Select();
        }

        private void gridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                string value = gridView.GetDataRow(e.RowHandle)["IsFileArchived"].ToString();
                if (value == bool.FalseString)
                    e.Appearance.BackColor2 = System.Drawing.Color.LightPink;
            }
        }

        int lastPosition = 0;
        private void FilesManager_LoadEvent(object sender, System.EventArgs e)
        {
            if (sender != null)
            {
                int currentPosition = (int)Math.Round((double)sender);
                if (lastPosition != currentPosition)
                {
                    progressBar.EditValue = currentPosition;
                    Application.DoEvents();
                }

                if (currentPosition >= 100)
                {
                    progressBar.Hide();
                    progressBar.EditValue = 0;
                }
            }
        }
    }
}
