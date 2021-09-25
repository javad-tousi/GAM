using GAM.Forms.Profile.Etebarat.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Profile.Etebarat.Print
{
    public partial class dlgHistory : DevExpress.XtraEditors.XtraForm
    {
       public DataTable TableHistory = new DataTable();
       frmRequestPrint OwnerFrm = null;

        public dlgHistory(frmRequestPrint owner)
        {
            InitializeComponent();
            this.OwnerFrm = owner;
            this.TableHistory = GetTable();
            gridControl.DataSource = this.TableHistory;
             
        }

        DataTable GetTable()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable("table1");
            table.Columns.Add("RequestSerial", typeof(string));
            table.Columns.Add("ModifiedDate", typeof(string));
            table.Columns.Add("RequestType", typeof(string));
            table.Columns.Add("BranchID", typeof(string));
            table.Columns.Add("BranchName", typeof(string));
            table.Columns.Add("CustomerName", typeof(string));
            table.Columns.Add("FacilityID", typeof(string));
            table.Columns.Add("FacilityName", typeof(string));
            table.Columns.Add("RequestAmount", typeof(string));
            return table;
        }

        private void repositoryShowRow_Click(object sender, EventArgs e)
        {
           DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
           if (row != null)
            {
                this.OwnerFrm.ChangeView(frmRequestPrint.FormStatusEnum.Show);
                DataTable table = RequestManager.GetBySerial(row["RequestSerial"].ToString());
                if (table != null)
                    this.OwnerFrm.ShowRequestValues(table);
            }
        }
    }
}
