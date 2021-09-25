using GAM;
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
using System.Xml;

   class MessagesSys
    {
        public static DataTable AllMessagesTable { get; set; }

        public static void FillMessages()
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = objConn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = string.Format("SELECT * FROM [Messages] WHERE ([MessageType] = 'Public') AND ([ToUsers] LIKE '%{0}%') AND ([DeletedUsers] NOT LIKE '%{0}%') ORDER BY [DateCreated] DESC", Users.MyUserID);
                    var dataReader = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(dataReader);
                    AllMessagesTable = table;
                    objConn.Close();
                }
            }
            catch
            {
            }
        }
       
       public static DataTable FillComments()
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Master.mdb")))
                {
                    objConn.Open();
                    DataTable table = new DataTable();
                    table.Columns.Add("UserName");
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = "SELECT * FROM [Comments]";
                    var dataReader = cmd.ExecuteReader();
                    table.Load(dataReader);

                    if (table.Rows.Count > 0)
                    {
                        table = table.AsEnumerable().OrderByDescending(x => x["RegisteredDateTime"].ToString()).CopyToDataTable();

                        foreach (DataRow row in table.Rows)
                        {
                            row["UserName"] = Users.GetUserNameById(Numeral.AnyToInt32(row["UserID"]));
                        }
                    }

                    return table;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetUnreadMessages() 
        {
            if (AllMessagesTable != null)
            {
               return AllMessagesTable.AsEnumerable().Where(row => !row["ReadUsers"].ToString().Contains(Users.MyUserID.ToString())).CopyToDataTable();
            }
            return null;
        }

        public static bool InsertAlert(string text, int category, string users)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = objConn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO [Messages] ([Category], [MessageType], [DateCreated], [FromUserID], [Content], [ToUsers]) VALUES (@Category, @MessageType, @DateCreated, @FromUserID, @Content, @ToUsers)";
                    cmd.Parameters.AddWithValue("Category", category);
                    cmd.Parameters.AddWithValue("MessageType", "Public");
                    cmd.Parameters.AddWithValue("DateCreated", Network.GetNowDateTimeString());
                    cmd.Parameters.AddWithValue("FromUserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("Content", text);
                    cmd.Parameters.AddWithValue("ToUsers", users);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        objConn.Close();
                        return true;
                    }
                    objConn.Close();
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public static bool InsertComment(string text)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = objConn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO [Comments] ([RegisteredDateTime], [UserID], [Content]) VALUES (@RegisteredDateTime, @UserID, @Content)";
                    cmd.Parameters.AddWithValue("RegisteredDateTime", Network.GetNowDateTimeString());
                    cmd.Parameters.AddWithValue("UserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("Content", text);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        objConn.Close();
                        return true;
                    }
                    objConn.Close();
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }


        public static bool DeleteQuery(string rowId, string deletedUsers)
        {
            try
            {
                OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb"));
                objConn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = objConn;
                cmd.CommandType = CommandType.Text;
                string text = "-";
                if (deletedUsers == "-")
                {
                    text = string.Format("<Users><ID>{0}</ID></Users>", Users.MyUserID);
                }
                else
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(deletedUsers);
                    XmlElement user = xmlDoc.CreateElement("ID");
                    user.InnerText = Users.MyUserID.ToString();
                    xmlDoc.DocumentElement.AppendChild(user);
                    text = xmlDoc.OuterXml;
                }
                cmd.CommandText = string.Format("UPDATE [Messages] SET [DeletedUsers] = '{0}' WHERE ([ID] = {1})", text, rowId);
                cmd.ExecuteNonQuery();
                objConn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ReadMessagesQuery(DataTable table)
        {
            try
            {
                OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb"));
                objConn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = objConn;
                cmd.CommandType = CommandType.Text;
                foreach (DataRow r in table.Rows)
                {
                    string text = "-";
                    cmd = new OleDbCommand();
                    cmd.Connection = objConn;
                    cmd.CommandType = CommandType.Text;
                    XmlDocument xmlDoc = new XmlDocument();
                    if (r["ReadUsers"].ToString() == "-")
                    {
                        text = string.Format("<Users><ID>{0}</ID></Users>", Users.MyUserID);
                    }
                    else if (!r["ReadUsers"].ToString().Contains(Users.MyUserID.ToString()))
                    {
                        xmlDoc.LoadXml(r["ReadUsers"].ToString());
                        XmlElement user = xmlDoc.CreateElement("ID");
                        user.InnerText = Users.MyUserID.ToString();
                        xmlDoc.DocumentElement.AppendChild(user);
                        text = xmlDoc.OuterXml;
                    }
                    else 
                    {
                        continue;
                    }
                    cmd.CommandText = string.Format("UPDATE [Messages] SET [ReadUsers] = '{0}' WHERE ([ID] = {1})", text, r["ID"].ToString());
                    cmd.ExecuteNonQuery();
                }
                objConn.Close();
            }
            catch
            {
                return false;
            }
            return false;
        }

        public static int GetUnreadMessagesCount()
        {
            if (AllMessagesTable != null)
                return AllMessagesTable.AsEnumerable().Count(x => !x["ReadUsers"].ToString().Contains(Users.MyUserID.ToString()));
            return 0;
        }
   }
