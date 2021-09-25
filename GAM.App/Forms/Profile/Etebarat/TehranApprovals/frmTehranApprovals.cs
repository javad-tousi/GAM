using System;
using System.Windows.Forms;
using System.Xml.Linq;
using MoreLinq;
using System.Linq;
using System.Data;
using GAM.Forms.Information.Library;
using GAM.Forms.Profile.Etebarat.Library;
using DevExpress.XtraEditors.Repository;
using GAM.Forms.Profile.Etebarat.Print;
using GAM.Dialogs;
using GAM.Modules;

namespace GAM.Forms.Profile.Etebarat.TehranApprovals
{
    public partial class frmTehranApprovals : DevExpress.XtraEditors.XtraForm
    {
        public frmTehranApprovals()
        {
            InitializeComponent();
            cboRequestStatus.Properties.Items.Add(RequestStatus.Barasi);
            cboRequestStatus.Properties.Items.Add(RequestStatus.Mosavab);
            cboRequestStatus.Properties.Items.Add(RequestStatus.Mokhalefat);
            cboRequestStatus.Properties.Items.Add(RequestStatus.Odat);
            cboRequestStatus.SelectedIndex = 0;
          
            txtSearch.Select();
            Modules.UDF.ToFarsiLanguage();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            if (gridControl.DataSource != null)
            {
                try
                {
                    string criteria = string.Format("CustomerName LIKE '%{0}%' OR " + "Convert(RequestID, System.String) LIKE '%{0}%'", txtSearch.Text);
                    (gridControl.DataSource as DataTable).DefaultView.RowFilter = criteria;
                }
                catch
                {
                    (gridControl.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                }
            }
        }

        private void repositorybtnLog_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
            if (row != null)
            {
                dlgDataLogs dlg = new dlgDataLogs(false);
                dlg.FillLoanFileLogs(row);
                dlg.ShowDialog();
            }
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            new dlgAddRequest(this).ShowDialog();
            txtSearch_EditValueChanged(null, EventArgs.Empty);
        }

        private void btnSendToTehran_Click(object sender, EventArgs e)
        {
            DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
            if (row != null)
                new dlgSendToTehran(row).ShowDialog();
            int focusedRowHandle = gridView.FocusedRowHandle;
            int topRowIndex = gridView.TopRowIndex;
            FillDataGrid();
            gridView.FocusedRowHandle = focusedRowHandle;
            gridView.TopRowIndex = topRowIndex;
            txtSearch_EditValueChanged(null, EventArgs.Empty);
        }

        private void btnReceiveFromTehran_Click(object sender, EventArgs e)
        {
            DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
            if (row != null)
            {
                dlgReceiveFromTehran dlg = new dlgReceiveFromTehran(row);
                DialogResult dlgResult = dlg.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    int focusedRowHandle = gridView.FocusedRowHandle;
                    int topRowIndex = gridView.TopRowIndex;
                    FillDataGrid();
                    gridView.FocusedRowHandle = focusedRowHandle;
                    gridView.TopRowIndex = topRowIndex;
                    txtSearch_EditValueChanged(null, EventArgs.Empty);
                }
            }
        }

        private void btnReturnToProvince_Click(object sender, EventArgs e)
        {
            DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
            if (row != null)
            {
                DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args.Icon = System.Drawing.SystemIcons.Warning;
                args.Caption = "هشدار";
                args.Text = "آیا از برگشت پیشنهاد به کمیته اعتباری مدیریت شعب اطمینان کامل حاصل دارید؟";
                args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                args.DefaultButtonIndex = 1;
                DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    string serial = row["RequestSerial"].ToString();
                    string letterNo = row["ProvinceLetterNo"].ToString();

                    RequestManager.UpdateCreditCommittee(serial, RequestStatus.Eghdam, CraditCommitee.ModiritShoab, int.Parse(letterNo), null);
                    dlgDataLogs.AddRequestLog(serial, 7, "پیشنهاد به کمیته اعتباری مدیریت شعب برگشت شد");
                    DevExpress.XtraEditors.XtraMessageBox.Show("پیشنهاد با موفقیت برگشت شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillDataGrid();
                    txtSearch_EditValueChanged(null, EventArgs.Empty);
                }
            }
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void cboRequestStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDataGrid();
        }
      
        private void btnExportToXlsx_Click(object sender, EventArgs e)
        {
            btnExportToXlsx.Enabled = false;
            Application.DoEvents();
            DevExportToXlsx.SaveAs(gridView);
            btnExportToXlsx.Enabled = true;
        }
   
        public void FillDataGrid() 
        {
            gridView.FormatRules.Clear();

            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
            Application.DoEvents();
            this.gridControl.DataSource = RequestManager.GetRequestsByCreditCommittee(cboRequestStatus.Text, CraditCommitee.Tehran);
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            gridView.FocusedRowHandle = 1;
            gridView.FocusedRowHandle = 0;

            if (cboRequestStatus.Text == RequestStatus.Barasi)
            {
                DevExpress.XtraGrid.GridFormatRule rule = new DevExpress.XtraGrid.GridFormatRule();
                DevExpress.XtraEditors.FormatConditionRuleExpression ruleExpression = new DevExpress.XtraEditors.FormatConditionRuleExpression();
                rule.ApplyToRow = true;
                ruleExpression.Appearance.BackColor = System.Drawing.Color.White;
                ruleExpression.Appearance.BackColor2 = System.Drawing.Color.FromArgb(192, 255, 192);
                ruleExpression.Appearance.Options.UseBackColor = true;
                ruleExpression.Expression = "Len([ProvinceLetterDate]) > 0";
                rule.Rule = ruleExpression;
                gridView.FormatRules.Add(rule);
            }
            else
            {
                btnSendToTehran.Enabled = false;
                btnReceiveFromTehran.Enabled = false;
            }
        }

        private void gridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow row = gridView.GetDataRow(e.RowHandle);
            if (row != null)
            {
                if (cboRequestStatus.Text == RequestStatus.Barasi)
                {
                    if (row["ProvinceLetterDate"].ToString().Length == 0)
                    {
                        btnSendToTehran.Enabled = true;
                        btnReceiveFromTehran.Enabled = false;
                    }
                    else
                    {
                        btnSendToTehran.Enabled = false;
                        btnReceiveFromTehran.Enabled = true;
                    }
                }
            }
        }

        private void txtSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSearch.ResetText();
        }
    }
}
