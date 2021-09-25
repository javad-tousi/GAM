using GAM.Dialogs;
using GAM.Forms.Profile.LegalFile.Library;
using GAM.Forms.Profile.LegalFile.NewFile;
using GAM.Forms.Profile.Etebarat.Library;
using GAM.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GAM.Forms.Profile.Kargozini.Library;

namespace GAM.Forms.Profile.Kargozini.Personnel
{
    public partial class dlgAllRules : DevExpress.XtraEditors.XtraForm
    {
        public dlgAllRules(DataTable tblRules)
        {
            InitializeComponent();
            gridControl.DataSource = tblRules;
        }
    }
}
