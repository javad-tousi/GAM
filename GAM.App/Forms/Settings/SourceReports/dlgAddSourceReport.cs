using GAM.Forms.Settings.Library;
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
    public partial class dlgAddSourceReport : DevExpress.XtraEditors.XtraForm
    {
        public dlgAddSourceReport()
        {
            InitializeComponent();
        }

        private void btnAddSource_Click(object sender, EventArgs e)
        {
            if (cboReferenceNames.Text.Length > 0 & txtSourceName.Text.Length > 0 & txtSourceId.Text.Length > 0)
            {
                try
                {
                    SourceReportsManager.InsertSource(cboReferenceNames.Text, int.Parse(txtSourceId.Text), txtSourceName.Text);
                    DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات با موفقیت ذخیره شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SourceReportsManager.Fill();
                    this.Close();
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات ورودی ناقص می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
