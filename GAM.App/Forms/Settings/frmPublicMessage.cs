using DevExpress.XtraEditors.Controls;
using GAM.Forms.Information;
using GAM.Forms.Information.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GAM.Forms.Settings
{
    public partial class frmPublicMessage : DevExpress.XtraEditors.XtraForm
    {
        public frmPublicMessage()
        {
            InitializeComponent();
            Modules.UDF.ToFarsiLanguage();
        }

        private void btnSubmitQuery_Click(object sender, EventArgs e)
        {
            if (listUsers.ItemCount > 0 & cboMessageCategory.SelectedIndex >= 0 & txtMessageText.Text.Trim().Length > 0)
            {
                DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args.Icon = System.Drawing.SystemIcons.Warning;
                args.Text = "آیا از ارسال پیام اطمینان کامل حاصل دارید؟";
                args.DefaultButtonIndex = 1;
                args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    btnSubmitQuery.Enabled = false;
                    Application.DoEvents();
                    bool queryResult = MessagesSys.InsertAlert(txtMessageText.Text, cboMessageCategory.SelectedIndex, ConvertUsersToXmlString(listUsers.Items.Cast<ImageListBoxItem>().Select(i => int.Parse(i.Value.ToString())).ToList()));
                    if (queryResult)
                    {
                        btnSubmitQuery.Enabled = true;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    btnSubmitQuery.Enabled = true;
                }
            }
        }

        private void btnAddUsers_Click(object sender, EventArgs e)
        {
            dlgUsersList dlg = new dlgUsersList(Users.GetAllUsers(), true);
            DialogResult dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                if (dlg.SelectedUsersId.Count > 0)
                {
                    foreach (int usrid in dlg.SelectedUsersId)
                    {
                       int count = listUsers.Items.Cast<ImageListBoxItem>().Count(i => i.Value.ToString() == usrid.ToString());
                       if (count == 0)
                       {
                           ImageListBoxItem item = new ImageListBoxItem(usrid, Users.GetUserNameById(usrid));
                           listUsers.Items.Add(item);
                       }
                    }
                }
            }
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            listUsers.Items.Clear();
        }

        public static string ConvertUsersToXmlString(List<int> selectedUsers)
        {
            if (selectedUsers.Count > 0)
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlElement users = xmlDoc.CreateElement("Users");
                foreach (int u in selectedUsers)
                {
                    XmlElement user = xmlDoc.CreateElement("ID");
                    user.InnerText = u.ToString();
                    users.AppendChild(user);
                }
                xmlDoc.AppendChild(users);
                return xmlDoc.OuterXml;
            }

            return string.Empty;
        }
    }
}
