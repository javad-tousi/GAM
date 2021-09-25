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
    public partial class dlgWriteFileNo : Form
    {
        public dlgWriteFileNo(string text)
        {
            InitializeComponent();
            txtFileNo.Text = text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
