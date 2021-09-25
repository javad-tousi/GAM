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
    class Posts
    {
        static DataTable DataPosts = new DataTable();
        static DataTable DataJobs = new DataTable();

        static IDictionary<int, string> ListJobs = new Dictionary<int, string>();
        static IDictionary<int, string> ListPosts = new Dictionary<int, string>();

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
                    objCmd.CommandText = "SELECT * FROM [Posts]";
                    var dataReader = objCmd.ExecuteReader();
                    DataPosts.Load(dataReader);
                    objCmd.CommandText = "SELECT * FROM [Jobs]";
                    dataReader = objCmd.ExecuteReader();
                    DataJobs.Load(dataReader);
                    objConn.Close();
            
                    ListPosts.Clear();
                    ListJobs.Clear();

                    foreach (DataRow row in DataPosts.Rows)
                    {
                        int postId = int.Parse(row["PostID"].ToString());
                        ListPosts.Add(postId, row["PostName"].ToString());
                    }
                    foreach (DataRow row in DataJobs.Rows)
                    {
                        int jobId = int.Parse(row["JobID"].ToString());
                        ListJobs.Add(jobId, row["JobName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DataTable GetAllPosts()
        {
            if (DataPosts.Rows.Count == 0)
            {
                Fill();
            }
            return DataPosts;
        }

        public static DataTable GetAllJobs()
        {
            if (DataJobs.Rows.Count == 0)
            {
                Fill();
            }
            return DataJobs;
        }

        public static string GetPostNameById(string id)
        {
            GetAllPosts();
            if (ListPosts.ContainsKey(Numeral.AnyToInt32(id)))
            {
                return ListPosts[Numeral.AnyToInt32(id)];
            }
            return "تعریف نشده";
        }

        public static string GetJobNameById(string id)
        {
            GetAllPosts();
            if (ListJobs.ContainsKey(Numeral.AnyToInt32(id)))
            {
                return ListJobs[Numeral.AnyToInt32(id)];
            }
            return "تعریف نشده";
        }
    }
}
