using GAM.Connections;
using GAM.Forms.Information.Library;
using GAM.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Settings
{
    public partial class dlgChangePassword : DevExpress.XtraEditors.XtraForm
    {
        public dlgChangePassword()
        {
            InitializeComponent();
            txtCurrentUserName.Text = Users.GetUserNameById(Users.MyUserID);
            txtCurrentPassword.Select();
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (txtNewPassword1.TextLength > 0 & (txtNewPassword1.Text == txtNewPassword2.Text))
            {
                try
                {
                    using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb")))
                    {
                        objConn.Open();
                        btnUpdatePassword.Enabled = false;
                        Application.DoEvents();
                        OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                        cmd.Connection = objConn;
                        cmd.CommandText = "SELECT * FROM [Users] WHERE " + string.Format("([UserID] = {0} AND [Password] = '{1}')", Users.MyUserID, txtCurrentPassword.Text);
                        var dataReader = cmd.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        Application.DoEvents();

                        if (dataTable.Rows.Count == 1)
                        {
                            DataRow currentUser = dataTable.Rows[0];
                            cmd.CommandText = "UPDATE [Users] SET " + string.Format("[Password] = '{2}' WHERE ([UserID] = {0}) AND ([Password] = '{1}')", Users.MyUserID, txtCurrentPassword.Text, txtNewPassword1.Text);
                            if (cmd.ExecuteNonQuery() == 1)
                            {
                                objConn.Close();
                                this.Close();
                                DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات جدید با موفقیت ذخیره شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            objConn.Close();
                            btnUpdatePassword.Enabled = true;
                        }
                        else 
                        {
                            objConn.Close();
                            DevExpress.XtraEditors.XtraMessageBox.Show("رمز عبور فعلی صحیح نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtCurrentPassword.Focus();
                            txtCurrentPassword.SelectAll();
                            btnUpdatePassword.Enabled = true;
                        }
                    }
                }
                catch
                {
                    btnUpdatePassword.Enabled = true;
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("رمز عبور جدید و تکرار آن با هم مطابقت ندارند", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewPassword1.Focus();
                txtNewPassword1.SelectAll();
                btnUpdatePassword.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
