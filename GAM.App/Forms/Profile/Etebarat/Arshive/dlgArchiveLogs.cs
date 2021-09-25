using GAM.Connections;
using GAM.Forms.Information.Library;
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

namespace GAM.Forms.Profile.Etebarat.Arshive
{
    public partial class dlgArchiveLogs : Form
    {
        public dlgArchiveLogs()
        {
            InitializeComponent();
        }

        public void FillArchiveFileLogs(string fileId)
        {
            try
            {
                OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_ArchiveFiles.mdb"));
                objConn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = objConn;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = string.Format("SELECT * FROM [Logs] WHERE ([FileID] = {0}) ORDER BY [ID] DESC", fileId);
                var dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);

                objConn.Close();

                if (dataTable != null)
                {
                    dataTable.Columns.Add("ExpertName");

                    foreach (DataRow r in dataTable.Rows)
                    {
                        r["ExpertName"] = Users.GetUserNameById(Numeral.AnyToInt32(r["ExpertID"]));
                    }
                }

                gridControl.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
