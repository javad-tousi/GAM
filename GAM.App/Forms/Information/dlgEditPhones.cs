using GAM.Forms.Information;
using GAM.Forms.Information.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GAM.Forms.Information
{
    public partial class dlgEditPhones : DevExpress.XtraEditors.XtraForm
    {
        private string BranchID { get; set; }

        public dlgEditPhones(string branchID)
        {
            InitializeComponent();
            this.BranchID = branchID;
            Branches.BranchInfo br = Branches.GetBranchById(branchID, true);
            this.Text = string.Format("شعبه {0} - {1}", br.BranchName, br.BranchId);
            DataTable tblTells = Branches.GetBranchTells(branchID);
            gridControl.DataSource = Branches.GetBranchTells(branchID);
            Modules.UDF.ToFarsiLanguage();
        }

        public string ConvertDatatableToXML(DataTable dt)
        {
            dt.TableName = "Contracts";
            System.IO.MemoryStream str = new System.IO.MemoryStream();
            dt.WriteXml(str, true);
            str.Seek(0, System.IO.SeekOrigin.Begin);
            System.IO.StreamReader sr = new System.IO.StreamReader(str);
            string xmlstr;
            xmlstr = sr.ReadToEnd();
            return (xmlstr);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = gridControl.DataSource as DataTable;
            bool res = Branches.UpdateBranchTells(this.BranchID, dt.Rows[0]["Tells"].ToString(), dt.Rows[1]["Tells"].ToString(), dt.Rows[2]["Tells"].ToString(), dt.Rows[3]["Tells"].ToString(), dt.Rows[4]["Tells"].ToString(), dt.Rows[5]["Tells"].ToString());
           if (res)
           {
               DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات با موفقیت ثبت شد", "ثبت", MessageBoxButtons.OK, MessageBoxIcon.Information);
               Branches.Fill();
               this.Close();
           }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            gridView.OptionsBehavior.Editable = true;
            gridView.OptionsBehavior.ReadOnly = false;
            colTells.AppearanceCell.BackColor = System.Drawing.SystemColors.Info;
            btnSave.Enabled = true;
        }
    }
}
