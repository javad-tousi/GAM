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
    class CircularsManager
    {
        public static DataTable DataCirculars { get; set; }
        
        public static void Fill()
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_222.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = objConn;
                    cmd.CommandType = CommandType.Text;
                    string[] names = objConn.GetSchema("Tables").AsEnumerable().Where(x => x["TABLE_TYPE"].ToString() == "TABLE").Select(r => r["TABLE_NAME"].ToString()).ToArray();
                    DataTable masterTable = new DataTable();
                    foreach (var name in names)
                    {
                        if (Numeral.IsNumber(name))
                        {
                            DataTable table = new DataTable();
                            cmd.CommandText = string.Format("SELECT * FROM [{0}]", name);
                            OleDbDataReader dataReader = cmd.ExecuteReader();
                            table.Load(dataReader);
                            masterTable.Merge(table);
                        }
                    }
                                      
                    objConn.Close();
                    DataCirculars = masterTable;
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DataTable GetAllCirculars()
        {
            if (!DataCirculars.Columns.Contains("Favorite"))
                DataCirculars.Columns.Add(new DataColumn { ColumnName = "Favorite", DataType = Type.GetType("System.Int32") });
            if (!DataCirculars.Columns.Contains("DownloadLink"))
                DataCirculars.Columns.Add(new DataColumn { ColumnName = "DownloadLink", DataType = Type.GetType("System.String") });

            for (int i = 0; i < DataCirculars.Rows.Count; i++)
            {
                DataRow row = DataCirculars.Rows[i];
                //string fav = DataCirculars.Rows[i]["Favorites"].ToString();
                //if (fav.Contains(string.Format("[{0}]", Users.MyUserID)))
                //    row["Favorite"] = 1;
                //else
                //    row["Favorite"] = 0;

                row["DownloadLink"] = "https://ann.hrm.bankmellat.ir/hrmannouncement/announcement/AnnouncementFile.aspx?AnnouncementId=55699&FileExtention=.pdf&IsAuthorize=True&IsReport=False&AnnouncementNumber=" + row["DocumentID"].ToString().Replace("/", "-");
            }
            return DataCirculars;
        }
    }
}
