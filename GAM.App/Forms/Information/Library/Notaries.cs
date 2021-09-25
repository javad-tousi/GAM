using GAM.Connections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Information.Library
{
    class Notaries
    {
        static DataTable TableNotaries = new DataTable();

        public static void Fill()
        {
            try
            {
                OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb"));
                objConn.Open();
                OleDbCommand objCmd = new OleDbCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.Text;
                objCmd.CommandText = "SELECT * FROM [Notaries] ORDER BY [NotaryID]";
                var dataReader = objCmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(dataReader);
                TableNotaries = table;
                objConn.Close();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string GetNotarNameByID(string id)
        {
            var row = TableNotaries.AsEnumerable().Where(x => x["NotaryID"].ToString() == id).FirstOrDefault();
            if (row != null)
                return "دفتر اسناد رسمی شماره " + Numeral.ToFarsi(row["NotaryNo"].ToString()) + " - " + row["NotaryCity"].ToString();
            else
                return string.Empty;
        }

        public static DataTable GetNotaries()
        {
            return TableNotaries;
        }
    }
}
