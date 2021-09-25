using GAM.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Settings
{
    public partial class frmUsersComments : DevExpress.XtraEditors.XtraForm
    {
        public frmUsersComments()
        {
            InitializeComponent();
            Startup();
        }

        private void Startup()
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
            Application.DoEvents();
            gridControl.DataSource = MessagesSys.FillComments();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }
    }
}
