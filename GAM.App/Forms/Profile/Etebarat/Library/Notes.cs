
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
    class Notes
    {
        private static DataTable TableNotes = new DataTable();

        public static void Fill()
        {
            try
            {
                OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb"));
                objConn.Open();
                OleDbCommand objCmd = new OleDbCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.Text;
                objCmd.CommandText = "SELECT * FROM [Notes]";
                var dataReader = objCmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                TableNotes = dataTable;
                objConn.Close();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool Insert(int userId, string text)
        {
            try
            {
                OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb"));
                objConn.Open();
                OleDbCommand objCmd = new OleDbCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.Text;
                objCmd.CommandText = string.Format("INSERT INTO [Notes] ([UserID], [Note]) VALUES ('{0}', '{1}')", userId, text);
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
                objCmd.CommandText = string.Format("UPDATE [Notes] SET [Note]='{1}' WHERE ([ID]={0})", id, newtext);
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
                objCmd.CommandText = "DELETE FROM [Notes] WHERE [ID] = " + id;
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

        public static DataTable GetNotes()
        {
            return TableNotes;
        }
    }
}
