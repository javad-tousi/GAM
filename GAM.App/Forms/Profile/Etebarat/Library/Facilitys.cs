
using GAM.Connections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Profile.Etebarat.Library
{
    class Facilitys
    {
        static DataTable TableFacilitys = new DataTable();
        static DataTable TableConditions = new DataTable();

        public static void Fill() 
        {
            try
            {
                OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb"));
                objConn.Open();
                OleDbCommand objCmd = new OleDbCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.Text;
                objCmd.CommandText = "SELECT * FROM [Facilitys] ORDER BY [FacilityName]";
                var dataReader = objCmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Columns.Add("IsChecked", Type.GetType("System.Boolean"));
                table.Load(dataReader);
                DataRow newRow = table.NewRow();
                newRow["FacilityID"] = 0;
                newRow["FacilityName"] = "-";
                table.Rows.Add(newRow);
                TableFacilitys = table;
                /////////
                objCmd.CommandText = "SELECT * FROM [Conditions]";
                dataReader = objCmd.ExecuteReader();
                table = new DataTable();
                table.Load(dataReader);
                TableConditions = table;
                objConn.Close();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool Insert(string type, string text)
        {
            try
            {
                OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb"));
                objConn.Open();
                OleDbCommand objCmd = new OleDbCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.Text;
                objCmd.CommandText = string.Format("INSERT INTO [Conditions] ([IsEnable], [Category], [Content]) VALUES ({0}, '{1}', '{2}')", true, type, text);
                if (objCmd.ExecuteNonQuery() == 1)
                {
                    objConn.Close();
                    return true;
                }
                objConn.Close();
            }
            catch
            {
                return false;
            }
            return false;
        }

        public static bool Update(string id, string newtext)
        {
            try
            {
                OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb"));
                objConn.Open();
                OleDbCommand objCmd = new OleDbCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.Text;
                objCmd.CommandText = string.Format("UPDATE [Conditions] SET [Content]='{1}' WHERE ([ID]={0})", id, newtext);
                if (objCmd.ExecuteNonQuery() == 1)
                {
                    objConn.Close();
                    return true;
                }
                objConn.Close();
            }
            catch
            {
                return false;
            }
            return false;
        }

        public static bool Delete(string id)
        {
            try
            {
                OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb"));
                objConn.Open();
                OleDbCommand objCmd = new OleDbCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.Text;
                objCmd.CommandText = "DELETE FROM [Conditions] WHERE [ID] = " + id;
                if (objCmd.ExecuteNonQuery() == 1)
                {
                    objConn.Close();
                    return true;
                }
                objConn.Close();
            }
            catch
            {
                return false;
            }
            return false;
        }

        public static string GetFacilityNameById(string id)
        {
            var row = TableFacilitys.AsEnumerable().Where(x => x["FacilityID"].ToString() == id).FirstOrDefault();
          if (row != null)
              return row["FacilityName"].ToString();
          else
              return string.Empty;
        }

        public static string GetFacilityIdByName(string name)
        {
            var row = TableFacilitys.AsEnumerable().Where(x => x["FacilityName"].ToString() == name).FirstOrDefault();
            if (row != null)
                return row["FacilityID"].ToString();
            else
                return string.Empty;
        }

        public static string GetFacilityTypeByID(string id)
        {
            var row = TableFacilitys.AsEnumerable().Where(x => x["FacilityID"].ToString() == id).FirstOrDefault();
            if (row != null)
                return row["FacilityType"].ToString();
            else
                return string.Empty;
        }

        public static string GetFacilityFormId(string id)
        {
            var row = TableFacilitys.AsEnumerable().Where(x => x["FacilityID"].ToString() == id).FirstOrDefault();
            if (row != null)
                return row["FormNo"].ToString();
            else
                return string.Empty;
        }

        public static string GetFacilityCategoryByID(string id)
        {
            var row = TableFacilitys.AsEnumerable().Where(x => x["FacilityID"].ToString() == id).FirstOrDefault();
            if (row != null)
                return row["Category"].ToString();
            else
                return string.Empty;
        }

        public static string[] GetFacilityConditions(string facilityId, string type)
        {
            if (facilityId.Length > 0 & type.Length > 0)
            {
                DataRow fRow = TableFacilitys.AsEnumerable().Where(x => x["FacilityID"].ToString() == facilityId).FirstOrDefault();
                List<string> conditionsList = new List<string>();
                foreach (string c in fRow[type].ToString().Split('-'))
                {
                    DataRow cRow = TableConditions.AsEnumerable().Where(x => x["ID"].ToString() == c).FirstOrDefault();
                    if (cRow != null)
                        conditionsList.Add(cRow["Content"].ToString());
                }
                return conditionsList.ToArray();
            }
            return new string[0];
        }

        public static DataTable GetFacilitys()
        {
            return TableFacilitys;
        }

        public static DataTable GetConditions()
        {
            return TableConditions;
        }
    }
}
