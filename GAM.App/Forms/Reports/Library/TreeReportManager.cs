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
    class TreeReportManager
    {
        public static DataSet GetTables()
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_303.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    string[] tableNames = objConn.GetSchema("Tables").AsEnumerable().Where(x => x["TABLE_TYPE"].ToString() == "TABLE").Select(r => r["TABLE_NAME"].ToString()).ToArray();
                    DataSet ds = new DataSet();
                    foreach (string name in tableNames)
                    {
                        if (Numeral.IsNumber(name))
                        {
                            cmd.CommandText = string.Format("SELECT {0} AS ReportDate, * FROM [{0}]", name);
                            var dataReader = cmd.ExecuteReader();
                            DataTable dataTable = new DataTable(name);
                            dataTable.Load(dataReader);
                            ds.Tables.Add(dataTable);
                        }
                    }
                    objConn.Close();
                    return ds;
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
