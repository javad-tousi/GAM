
using GAM.Connections;
using GAM.Forms.Information.Library;
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
    class OfficialFormsManager
    {
        public static DataTable DataForms { get; set; }

        public static void Fill()
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = objConn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM [Forms] WHERE [IsVisible] = True ORDER BY [Category], [Subject]";
                    OleDbDataReader dataReader = cmd.ExecuteReader();
                    DataForms = new DataTable(); 
                    DataForms.Load(dataReader);
                    objConn.Close();
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string InsertInfo(string subject, string category, string receiverName, string signatories)
        {
            try
            {
                OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb"));
                objConn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = objConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = string.Format("INSERT INTO [Forms] ([Subject], [Category], [ReceiverName], [Signatories]) VALUES ('{0}', '{1}', '{2}', '{3}')", subject, category, receiverName, signatories);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    cmd.CommandText = "Select @@Identity";
                    string id = cmd.ExecuteScalar().ToString();
                    objConn.Close();
                    return id;
                }
                objConn.Close();
            }
            catch
            {
                return string.Empty;
            }
            return string.Empty;
        }

        public static bool UpdateInfo(string id, string subject, string category, string receiverName, string signatories)
        {
            try
            {
                OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb"));
                objConn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = objConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = string.Format("UPDATE [Forms] SET [Subject]='{1}', [Category]='{2}', [ReceiverName]='{3}', [Signatories]='{4}' WHERE (ID = {0})", id, subject, category, receiverName, signatories);
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

        public static bool UpdateFavorites(string formId, string favorite)
        {
            string strConnection = OLEDB.GetMasterDatabase("DB_Master.mdb");
            OleDbConnection objConn = new OleDbConnection(strConnection);
            objConn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = objConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = string.Format("UPDATE [Forms] SET [Favorites]='{0}' WHERE [ID] = {1}", favorite, formId);
            int queryResult = cmd.ExecuteNonQuery();
            objConn.Close();
            if (queryResult == 1)
                return true;

            return false;
        }

        public static DataTable GetAllForms()
        {
            if (!DataForms.Columns.Contains("Favorite"))
                DataForms.Columns.Add(new DataColumn { ColumnName = "Favorite", DataType = Type.GetType("System.Int32") });
           
            for (int i = 0; i < DataForms.Rows.Count; i++)
            {
                string fav = DataForms.Rows[i]["Favorites"].ToString();
                if (fav.Contains(string.Format("[{0}]", Users.MyUserID)))
                    DataForms.Rows[i]["Favorite"] = 1;
                else
                    DataForms.Rows[i]["Favorite"] = 0;
            }
            return DataForms;
        }
    }
}
