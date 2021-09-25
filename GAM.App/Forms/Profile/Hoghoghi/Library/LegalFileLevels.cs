
using GAM.Connections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Profile.LegalFile.Library
{
    class LegalFileLevels
    {
        static DataTable TableLevels = new DataTable();

        public static void Fill()
        {
            try
            {
                OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb"));
                objConn.Open();
                OleDbCommand objCmd = new OleDbCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.Text;
                objCmd.CommandText = "SELECT * FROM [LegalFileLevels] ORDER BY [LevelID]";
                var dataReader = objCmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(dataReader);
                TableLevels = table;
                objConn.Close();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string GetLevelNameByID(int levelId)
        {
            var row = TableLevels.AsEnumerable().Where(x => int.Parse(x["LevelID"].ToString()) == levelId).FirstOrDefault();
            if (row != null)
                return row["LevelName"].ToString();
            else
                return string.Empty;
        }

        public static int GetLevelMaxDays(int levelId)
        {
            var row = TableLevels.AsEnumerable().Where(x => int.Parse(x["LevelID"].ToString()) == levelId).FirstOrDefault();
            if (row != null)
                return int.Parse(row["MaxDays"].ToString());
            else
                return 0;
        }

        public static DataTable GetAllLevels() 
        {
            return TableLevels;
        }
        public static DataTable GetLevelsBetween(int start, int end)
        {
            return TableLevels.AsEnumerable().Where(x => int.Parse(x["LevelID"].ToString()) >= start & int.Parse(x["LevelID"].ToString()) <= end).CopyToDataTable();
        }
    }
}
