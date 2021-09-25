using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Settings.ImportSourcefile
{
    public partial class dlgStartupMessage : DevExpress.XtraEditors.XtraForm
    {
        public dlgStartupMessage(string msg)
        {
            InitializeComponent();
            txtMessage.Text = msg;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
