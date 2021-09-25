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

namespace GAM.Forms.Profile
{
    public partial class frmSendComment : DevExpress.XtraEditors.XtraForm
    {
        public frmSendComment()
        {
            InitializeComponent();
            UDF.ToFarsiLanguage();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtMessageText.Text.Trim().Length > 0)
            {
                DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args.Icon = System.Drawing.SystemIcons.Warning;
                args.Text = "آیا از ارسال پیام اطمینان کامل حاصل دارید؟";
                args.DefaultButtonIndex = 1;
                args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    btnSubmit.Enabled = false;
                    Application.DoEvents();
                    bool queryResult = MessagesSys.InsertComment(txtMessageText.Text.Trim());
                    if (queryResult)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("!پیام شما با موفقیت ارسال شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    btnSubmit.Enabled = true;
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("!متنی برای ارسال وجود ندارد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
