using GAM.Connections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Profile.Kargozini.Library
{
    class Rules
    {
        static DataTable DataRules = new DataTable();
        static IDictionary<int, string> ListRules = new Dictionary<int, string>();

        private static void Fill()
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb")))
                {
                    objConn.Open();
                    OleDbCommand objCmd = new OleDbCommand();
                    objCmd.Connection = objConn;
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = "SELECT * FROM [PersonnelRules]";
                    var dataReader = objCmd.ExecuteReader();
                    DataRules.Load(dataReader);
                    objConn.Close();
                    ListRules.Clear();
                    foreach (DataRow row in DataRules.Rows)
                        ListRules.Add(int.Parse(row["RuleID"].ToString()), row["RuleName"].ToString());
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DataTable GetRules()
        {
            if (DataRules.Rows.Count == 0)
            {
                Fill();
            }
            return DataRules;
        }

        public static string GetRuleNameById(string id)
        {
            GetRules();
            if (ListRules.ContainsKey(Numeral.AnyToInt32(id)))
            {
                return ListRules[Numeral.AnyToInt32(id)];
            }
            return string.Empty;
        }
    }
}
