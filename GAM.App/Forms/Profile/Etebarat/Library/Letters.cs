
using GAM.Connections;
using GAM.Forms.Information.Library;
using GAM.Forms.Settings.Library;
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
    class Letters
    {

        public static DataTable GetLetters()
        {
            try
            {
                OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb"));
                objConn.Open();
                OleDbCommand objCmd = new OleDbCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.Text;
                objCmd.CommandText = "SELECT * FROM [Letters]";
                var dataReader = objCmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                objConn.Close();
                if (dataTable.Rows.Count > 0)
                {
                    dataTable.Columns.Add("RegisteredUserName");
                    dataTable = dataTable.AsEnumerable().OrderByDescending(x => x["RegisteredDate"]).ThenByDescending(x => x["ID"]).CopyToDataTable();

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        DataRow row = dataTable.Rows[i];
                        row["RegisteredUserName"] = Users.GetUserNameById(Numeral.AnyToInt32(row["RegisteredUserID"]));
                    }
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static bool Insert(int toUserId, string branchName, string subject, string text)
        {
            try
            {
                OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb"));
                objConn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = objConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO [Letters] ([RegisteredUserID], [RegisteredDate], [ToUserID], [BranchName], [Subject], [LetterText]) VALUES (@RegisteredUserID, @RegisteredDate, @ToUserID, @BranchName, @Subject, @LetterText)";
                cmd.Parameters.AddWithValue("RegisteredUserID", Users.MyUserID);
                cmd.Parameters.AddWithValue("RegisteredDate", Network.GetNowDateSerial());
                cmd.Parameters.AddWithValue("ToUserId", toUserId);
                cmd.Parameters.AddWithValue("BranchName", branchName);
                cmd.Parameters.AddWithValue("Subject", subject);
                cmd.Parameters.AddWithValue("LetterText", text);

                if (cmd.ExecuteNonQuery() == 1)
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
                objCmd.CommandText = string.Format("UPDATE [Letters] SET [LetterText]='{1}' WHERE ([ID]={0})", id, newtext);
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
                objCmd.CommandText = "DELETE FROM [Letters] WHERE [ID] = " + id;
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
    }
}
