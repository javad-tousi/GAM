using GAM.Connections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GAM.Forms.Information.Library
{
    public class Users
    {
        public static int MyUserID { get; set; }
        public static string MyWorkGroup { get; set; }
        public static string MyAccLevelName = "";
        public static string MyZoneID { get; set; }
        public static string MyProvinceID { get; set; }
        public static string MyDomainID { get; set; }
        public static string MyBranchID { get; set; }
        public static bool AutoBackup { get; set; }
        public static bool IsUserEnable { get; set; }

        public class User
        {
            public string UserID;
            public string UserName;
            public string Department;
            public string WorkGroup;
            public string PostJob;
            public string Mobail;
            public string Tell;
        }

        private static DataTable dataUsers = new DataTable();
       
        public static void Fill() 
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb")))
                {
                    objConn.Open();
                    OleDbCommand objCmd = new OleDbCommand();
                    objCmd.Connection = objConn;
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = "SELECT * FROM [Users]";
                    var dataReader = objCmd.ExecuteReader();
                    dataUsers = new DataTable();
                    dataUsers.Load(dataReader);
                    dataUsers.Columns.Add("IsChecked", Type.GetType("System.Boolean"));
                    objConn.Close();
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string GetUserNameById(int id)
        {
            if (id > 0)
            {
                DataRow selectedUser = dataUsers.AsEnumerable().Where(r => int.Parse(r["UserID"].ToString()) == id).FirstOrDefault();
                if (selectedUser != null)
                    return selectedUser["UserName"].ToString();
                else
                    return string.Empty; 
            }
            else
                return string.Empty;
        }

        public static string GetUserNameWithSexByID(int id)
        {
            if (id > 0)
            {
                object[] selectedUser = dataUsers.AsEnumerable().Where(r => int.Parse(r["UserID"].ToString()) == id).Select(x => new object[] { bool.Parse(x["IsFemale"].ToString()), x["UserName"].ToString() }).FirstOrDefault();
                if (selectedUser != null)
                {
                    if ((bool)selectedUser[0])
                        return "خانم " + selectedUser[1];
                    else
                        return "آقای " + selectedUser[1];
                }
                else
                    return string.Empty;
            }
            else
                return string.Empty;
        }

        public static DataTable GetWorkGroupUsers(bool showMe)
        {
            DataTable users = new DataTable();
            if (showMe)
            {
                users = dataUsers.AsEnumerable().Where(r =>
                    r["IsEnable"].ToString() == "True" &
                    r["WorkGroup"].ToString() == Users.MyWorkGroup).CopyToDataTable();
            }
            else
            {
                users = dataUsers.AsEnumerable().Where(r =>
                 r["IsEnable"].ToString() == "True" &
                 r["WorkGroup"].ToString() == Users.MyWorkGroup &
                Numeral.AnyToInt32(r["UserID"]) != Users.MyUserID).CopyToDataTable();
            }

            return users;
        }

        public static DataTable GetAllUsers()
        {
            var users = dataUsers.AsEnumerable().Where(r => r["IsEnable"].ToString() == "True");
            if (users.Count() > 0)
            {
                DataTable table = users.CopyToDataTable();
                if (table != null)
                    return table;
            }

            return null;
        }
    }
}
