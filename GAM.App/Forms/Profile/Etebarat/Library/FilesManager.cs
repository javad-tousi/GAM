using GAM.Forms.Information.Library;
using GAM.Forms.Settings.Library;
using GAM.Forms.Profile.Etebarat.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GAM.Connections;


namespace GAM.Forms.Profile.Etebarat.Library
{
    class FilesManager
    {
        internal static event System.EventHandler<System.EventArgs> LoadEvent;

        public static DataTable TableAllFilesAndCovers = new DataTable();
        public static DataTable TableUnArchivedFiles = new DataTable();

        public static void FillFilesWithCovers()
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_ArchiveFiles.mdb")))
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = objConn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[QAllFilesAndCoversCount]";
                    double allRowsCount = Numeral.AnyToDouble(cmd.ExecuteScalar());
                    Application.DoEvents();
                    cmd.CommandText = "[QAllFilesAndCovers]";
                    Application.DoEvents();
                    TableAllFilesAndCovers = new DataTable();
                    TableAllFilesAndCovers.Columns.Add("FileID");
                    TableAllFilesAndCovers.Columns.Add("IndicatorID");
                    TableAllFilesAndCovers.Columns.Add("CoverNo");
                    TableAllFilesAndCovers.Columns.Add("IsFileArchived");
                    TableAllFilesAndCovers.Columns.Add("CustomerID");
                    TableAllFilesAndCovers.Columns.Add("CustomerName");
                    TableAllFilesAndCovers.Columns.Add("BranchID");
                    TableAllFilesAndCovers.Columns.Add("Note");
                    TableAllFilesAndCovers.Columns.Add("GetterID");
                    TableAllFilesAndCovers.Columns.Add("CreationDate");
                    TableAllFilesAndCovers.Columns.Add("ModifiedDate");
                    TableAllFilesAndCovers.Columns.Add("BranchName");
                    TableAllFilesAndCovers.Columns.Add("GetterName");

                    OleDbDataReader dataReader = cmd.ExecuteReader();
                    Application.DoEvents();
                    int count = dataReader.FieldCount;
                    int counter = 0;
                    while (dataReader.Read())
                    {
                        counter++;
                        object[] itemsArray = new object[count];
                        for (int i = 0; i < count; i++)
                        {
                            itemsArray[i] = dataReader.GetValue(i);
                        }

                        DataRow row = TableAllFilesAndCovers.Rows.Add(itemsArray);
                        string branchId = row["BranchID"].ToString();
                        GAM.Forms.Information.Library.Branches.BranchInfo br = Branches.GetBranchById(branchId, true);
                        row["BranchID"] = br.BranchId;
                        row["BranchName"] = br.BranchName;
                        row["GetterName"] = Users.GetUserNameById(Numeral.AnyToInt32(row["GetterID"]));
                        RaiseLoadEvent(((double)counter / allRowsCount) * (double)100, EventArgs.Empty);
                    }

                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void FillUnArchivedFiles()
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_ArchiveFiles.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.StoredProcedure };
                    cmd.Connection = objConn;
                    cmd.CommandText = "[QUnArchivedFiles]";
                    var dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataTable dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    dataTable.Columns.Add("BranchName");
                    dataTable.Columns.Add("GetterName");

                    foreach (DataRow row in dataTable.Rows)
                    {
                        row["BranchName"] = Branches.GetBranchById(row["BranchID"].ToString(), true).BranchName;
                        row["GetterName"] = Users.GetUserNameById(Numeral.AnyToInt32(row["GetterID"]));
                    }
                    TableUnArchivedFiles = dataTable;
                }
            }
            catch
            {
            }
        }

        public static string InsertFile(string indicatorId, string branchId, string customerId, string customerName, string note)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_ArchiveFiles.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = objConn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO [Files] ([IndicatorID], [BranchID], [CustomerID], [CustomerName], [CreationDate]) VALUES (@IndicatorID, @BranchID, @CustomerID, @CustomerName, @CreationDate)";
                    cmd.Parameters.AddWithValue("IndicatorID", double.Parse(indicatorId));
                    cmd.Parameters.AddWithValue("BranchID", int.Parse(branchId));
                    cmd.Parameters.AddWithValue("CustomerID", customerId);
                    cmd.Parameters.AddWithValue("CustomerName", customerName);
                    cmd.Parameters.AddWithValue("CreationDate", Network.GetNowDateSerial());

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "Select @@Identity";
                        string id = cmd.ExecuteScalar().ToString();
                        cmd.CommandText = "INSERT INTO [Covers] ([FileID], [CoverNo], [IsFileArchived], [Note], [CreationDate]) VALUES (@FileID, @CoverNo, @IsFileArchived, @Note, @CreationDate)";
                        cmd.Parameters.AddWithValue("FileID", int.Parse(id));
                        cmd.Parameters.AddWithValue("CoverNo", 1);
                        cmd.Parameters.AddWithValue("IsFileArchived", (int)1);
                        cmd.Parameters.AddWithValue("Note", note);
                        cmd.Parameters.AddWithValue("CreationDate", Network.GetNowDateSerial());
   
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            return id;
                        }
                    }

                    objConn.Close();
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return string.Empty;
        }

        public static bool UpdateFile(string fileId, string coverNo, string indicatorId, string branchId, string customerId, string customerName, string note)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_ArchiveFiles.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = objConn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE [Files] SET [IndicatorID]=@IndicatorID, [BranchID]=@BranchID, [CustomerID]=@CustomerID, [CustomerName]=@CustomerName WHERE FileID = " + fileId;
                    cmd.Parameters.AddWithValue("IndicatorID", double.Parse(indicatorId));
                    cmd.Parameters.AddWithValue("BranchID", int.Parse(branchId));
                    cmd.Parameters.AddWithValue("CustomerID", customerId);
                    cmd.Parameters.AddWithValue("CustomerName", customerName);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = string.Format("UPDATE [Covers] SET [Note]=@Note WHERE (FileID={0}) AND (CoverNo={1})", fileId, coverNo);
                        cmd.Parameters.AddWithValue("Note", note);

                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            return true;
                        }
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

        public static bool DeleteFile(string fileId, string coverNo)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_ArchiveFiles.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = objConn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = string.Format("DELETE FROM [Covers] WHERE [FileID]={0} AND [CoverNo]={1}", fileId, coverNo);
                    int queryResult = cmd.ExecuteNonQuery();
                    objConn.Close();
                    if (queryResult == 1)
                        return true;
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public static bool SetFileStatus(int fileId, int coverNo, int? indicatorId, int? expertId, int branchId, string branchName, bool isArchived)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_ArchiveFiles.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = objConn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = string.Format("UPDATE [Covers] SET [IsFileArchived]=@IsFileArchived, ModifiedDate=@ModifiedDate, GetterID=@GetterID WHERE (FileID={0}) AND (CoverNo={1})", fileId, coverNo);
                    cmd.Parameters.AddWithValue("IsFileArchived", isArchived);
                    cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("GetterID", Numeral.DBNullForNullValue(expertId));

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO [Logs] ([RegisteredUserID], [RegisteredDateTime], [FileID], [CoverNo], [IndicatorID], [ExpertID], [BranchID], [BranchName], [IsArchived]) VALUES (@RegisteredUserID, @RegisteredDateTime, @FileID, @CoverNo, @IndicatorID, @ExpertID, @BranchID, @BranchName, @IsArchived)";
                        cmd.Parameters.AddWithValue("RegisteredUserID", Users.MyUserID);
                        cmd.Parameters.AddWithValue("RegisteredDateTime", Network.GetNowDateTimeString());
                        cmd.Parameters.AddWithValue("FileID", fileId);
                        cmd.Parameters.AddWithValue("CoverNo", coverNo);
                        cmd.Parameters.AddWithValue("IndicatorID", indicatorId);
                        cmd.Parameters.AddWithValue("ExpertID", Numeral.DBNullForNullValue(expertId));
                        cmd.Parameters.AddWithValue("BranchID", branchId);
                        cmd.Parameters.AddWithValue("BranchName", branchName);
                        cmd.Parameters.AddWithValue("IsArchived", isArchived);
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            return true;
                        }
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

        public static string GetLastIndicatorID(string branchId)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_ArchiveFiles.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = objConn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[GetLastFileNo]";
                    cmd.Parameters.AddWithValue("BranchID", int.Parse(branchId));
                    var dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataTable table = new DataTable();
                    table.Load(dataReader);
                    if (table.Rows.Count == 1)
                    {
                        DataRow row = table.Rows[0];
                        return row["IndicatorID"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return string.Empty;
        }

        public static string AddCover(string fileId, string note)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_ArchiveFiles.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = objConn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[GetCoversCount]";
                    cmd.Parameters.AddWithValue("FileID", int.Parse(fileId));
                    var resultObj = cmd.ExecuteScalar();
                    if (resultObj != null)
                    {
                        int newCoverNo = int.Parse(resultObj.ToString()) + 1;
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO [Covers] ([FileID], [CoverNo], [IsFileArchived], [Note], [CreationDate]) VALUES (@FileID, @CoverNo, @IsFileArchived, @Note, @CreationDate)";
                        cmd.Parameters.AddWithValue("FileID", int.Parse(fileId));
                        cmd.Parameters.AddWithValue("CoverNo", newCoverNo);
                        cmd.Parameters.AddWithValue("IsFileArchived", (int)1);
                        cmd.Parameters.AddWithValue("Note", note);
                        cmd.Parameters.AddWithValue("CreationDate", Network.GetNowDateSerial());

                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            objConn.Close();
                            return newCoverNo.ToString();
                        }
                    }
                    objConn.Close();
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return string.Empty;
        }

        public static string GetFileLocation(string fileId, string coverNo) 
        {
           DataRow row = TableAllFilesAndCovers.AsEnumerable().Where(x => x["FileID"].ToString() == fileId & x["CoverNo"].ToString() == coverNo).FirstOrDefault();
           if (row != null)
           {
               if (bool.Parse(row["IsFileArchived"].ToString()))
                   return "بایگانی";
               else
                   return "اداره";
           }
           return string.Empty;
        }

        internal static void RaiseLoadEvent(object sender, System.EventArgs args)
        {
            System.EventHandler<System.EventArgs> handler = LoadEvent;
            if (handler != null)
            {
                if (args == null)
                {
                    handler(sender, System.EventArgs.Empty);
                }
                else
                {
                    handler(sender, args);
                }
            }
        }
    }
}
