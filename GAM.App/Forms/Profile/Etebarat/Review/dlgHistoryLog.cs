using GAM.Forms.Information.Library;
using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Profile.Etebarat.Review
{
    public partial class dlgHistoryLog : Form
    {
        public DataRow Data { set; get; }

        public dlgHistoryLog(DataTable tbl)
        {
            InitializeComponent();
            foreach (DataRow row in tbl.Rows)
            {
                ListViewItem i = listView.Items.Add(PersianDateTime.Parse(int.Parse(row["ModifiedDate"].ToString())).ToShortDateString());
                i.SubItems.Add(Users.GetUserNameById(Numeral.AnyToInt32(row["ModifierUserID"])));
                i.Tag = row;
            }
            if (listView.Items.Count > 0)
            {
                listView.Items[0].Selected = true;
            }

            listView.Focus();
            listView.Select();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                this.Data = listView.SelectedItems[0].Tag as DataRow;
                this.Close();
            }
        }
    }
}
