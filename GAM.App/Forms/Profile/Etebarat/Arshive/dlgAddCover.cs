using GAM.Forms.Profile.Etebarat.Library;
using GAM.Forms.Information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Profile.Etebarat.Arshive
{
    public partial class dlgAddCover : DevExpress.XtraEditors.XtraForm
    {
        public dlgAddCover(string fileId, string IndicatorId, string branchId, string branchName, string customerName, string coverNo)
        {
            InitializeComponent();
            txtFileID.Text = fileId;
            txtCoverNo.Text = coverNo;
            txtIndicatorID.Text = IndicatorId;
            txtBranchID.Text = branchId;
            lblBranchName.Text = branchName;
            txtCustomerName.Text = customerName;
            Modules.UDF.ToFarsiLanguage();
        }

        private void btnBranchesInfo_Click(object sender, EventArgs e)
        {
            dlgBranchesList dlg = new dlgBranchesList();
            dlg.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          string coverNo = FilesManager.AddCover(txtFileID.Text, txtNote.Text);
          if (coverNo.Length > 0)
          {
              DevExpress.XtraEditors.XtraMessageBox.Show(string.Format("جلد شماره {0} پرونده در سیستم ایجاد شد", coverNo), "ثبت", MessageBoxButtons.OK, MessageBoxIcon.Information);
              this.Close();
          }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
