using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Login
{
    public partial class msgLocalConnection : DevExpress.XtraEditors.XtraForm
    {
        public string Path { set; get; }

        public msgLocalConnection()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (txtPath.Text.Length > 0)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Path = txtPath.Text;
            }
            else 
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("مسیری جهت اجرای برنامه بصورت آفلاین انتخاب نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.SelectedPath != string.Empty)
                {
                    var dir = System.IO.Path.GetFileName(dlg.SelectedPath);
                    if (dir != null && dir == "Data")
                    {
                        txtPath.Text = dlg.SelectedPath;
                    }
                    else 
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("انتخاب نمایید Data لطفاً مسیری منتهی به پوشه", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("مسیری جهت اجرای برنامه بصورت آفلاین انتخاب نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
    }
}
