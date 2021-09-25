using GAM.Connections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Forms.Reports.Library
{
    class Packs
    {
        public static DataTable GetPackCodes()
        {
            using (OleDbConnection conn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb")))
            {
                DataTable table = new DataTable();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [PackCodes]", conn);
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(table);
                conn.Close();
                return table.AsEnumerable().OrderBy(x => Numeral.AnyToInt32(x["PackID"].ToString())).CopyToDataTable();
            }
        }
    }
}
