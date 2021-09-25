using GAM.Connections;
using GAM.Forms.Information.Library;
using GAM.Forms.Settings.Library;
using GAM.Modules;
using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Forms.Profile.Etebarat.Library
{
    class ExpertReportManager
    {
        public static int InsertExpertReport(OleDbConnection objConn, List<string> serials, int branchId, long customerId, string customerName, int? fileId, int? coverNo, int expertId, int referralDate, string referralType)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                cmd.Connection = objConn;
                cmd.CommandText = "INSERT INTO [ExpertReports] ([RegisteredDate], [ModifiedDate], [ModifiedTime], [BranchID], [CustomerID], [CustomerName], [FileID], [FromUserID], [ToUserID], [ReferralType], [ReferralDate], [ReferralTime], [LastActionName]) VALUES (@RegisteredDate, @ModifiedDate, @ModifiedTime, @BranchID, @CustomerID, @CustomerName, @FileID, @FromUserID, @ToUserID, @ReferralType, @ReferralDate, @ReferralTime, @LastActionName)";
                cmd.Parameters.AddWithValue("RegisteredDate", Network.GetNowDateSerial());
                cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());
                cmd.Parameters.AddWithValue("BranchID", branchId);
                cmd.Parameters.AddWithValue("CustomerID", customerId);
                cmd.Parameters.AddWithValue("CustomerName", customerName);
                cmd.Parameters.AddWithValue("FileID", Numeral.DBNullForNullValue(fileId));
                cmd.Parameters.AddWithValue("FromUserID", Users.MyUserID);
                cmd.Parameters.AddWithValue("ToUserID", expertId);
                cmd.Parameters.AddWithValue("ReferralType", referralType);
                cmd.Parameters.AddWithValue("ReferralDate", referralDate);
                cmd.Parameters.AddWithValue("ReferralTime", Network.GetNowTimeString());
                cmd.Parameters.AddWithValue("LastActionName", string.Empty);
                int queryResult = cmd.ExecuteNonQuery();
                if (queryResult == 1)
                {
                    cmd.CommandText = "Select @@Identity";
                    string id = cmd.ExecuteScalar().ToString();
                    foreach (string serial in serials)
                    {
                        cmd.Parameters.Clear();
                        string tableName = serial.Substring(0, 4);
                        string rowId = serial.Substring(4);
                        cmd.CommandText = string.Format("UPDATE [{0}] SET [ModifierUserID]=@ModifierUserID, [ModifiedDate]=@ModifiedDate, [ModifiedTime]=@ModifiedTime, [CustomerID]=@CustomerID, [CustomerName]=@CustomerName, [FileID]=@FileID, [CoverNo]=@CoverNo, [ExpertID]=@ExpertID, [ExpertNo]=@ExpertNo WHERE ([ID]={1})", tableName, rowId);
                        cmd.Parameters.AddWithValue("ModifierUserID", Users.MyUserID);
                        cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                        cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());
                        cmd.Parameters.AddWithValue("CustomerID", customerId);
                        cmd.Parameters.AddWithValue("CustomerName", customerName);
                        cmd.Parameters.AddWithValue("FileID", Numeral.DBNullForNullValue(fileId));
                        cmd.Parameters.AddWithValue("CoverNo", Numeral.DBNullForNullValue(coverNo));
                        cmd.Parameters.AddWithValue("ExpertID", expertId);
                        cmd.Parameters.AddWithValue("ExpertNo", id);
                        cmd.ExecuteNonQuery();
                    }
                    return queryResult;
                }
            }
            catch
            {
                throw;
            }
            return -1;
        }

        public static string[] InsertExpertReportByLetterNo(long requestId, int branchId, long customerId, string customerName, bool isLegalPerson, int? fileId, int? coverNo, int expertId, int referralDate, string referralType)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    string tableName = RequestManager.GetTablesName().Last();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = "INSERT INTO [ExpertReports] ([RegisteredDate], [ModifiedDate], [ModifiedTime], [BranchID], [CustomerID], [CustomerName], [FileID], [FromUserID], [ToUserID], [ReferralType], [ReferralDate], [ReferralTime], [LastActionName]) VALUES (@RegisteredDate, @ModifiedDate, @ModifiedTime, @BranchID, @CustomerID, @CustomerName, @FileID, @FromUserID, @ToUserID, @ReferralType, @ReferralDate, @ReferralTime, @LastActionName)";
                    cmd.Parameters.AddWithValue("RegisteredDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());
                    cmd.Parameters.AddWithValue("BranchID", branchId);
                    cmd.Parameters.AddWithValue("CustomerID", customerId);
                    cmd.Parameters.AddWithValue("CustomerName", customerName);
                    cmd.Parameters.AddWithValue("FileID", Numeral.DBNullForNullValue(fileId));
                    cmd.Parameters.AddWithValue("FromUserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("ToUserID", expertId);
                    cmd.Parameters.AddWithValue("ReferralType", referralType);
                    cmd.Parameters.AddWithValue("ReferralDate", referralDate);
                    cmd.Parameters.AddWithValue("ReferralTime", Network.GetNowTimeString());
                    cmd.Parameters.AddWithValue("LastActionName", RequestStatus.Barasi);

                    int queryResult = cmd.ExecuteNonQuery();
                    if (queryResult == 1)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "Select @@Identity";
                        string id = cmd.ExecuteScalar().ToString();
                        cmd.CommandText = string.Format("INSERT INTO {0} ([RegisteredUserID], [RegisteredDate], [ModifierUserID], [ModifiedDate], [ModifiedTime], [RequestStatus], [RequestID], [RequestType], [BranchID], [CustomersCount], [CustomerID], [CustomerName], [IsLegalPerson], [FileID], [CoverNo], [CreditCommittee], [ExpertNo], [ExpertID], [ReferralDate]) VALUES (@RegisteredUserID, @RegisteredDate, @ModifierUserID, @ModifiedDate, @ModifiedTime, @RequestStatus, @RequestID, @RequestType, @BranchID, @CustomersCount, @CustomerID, @CustomerName, @IsLegalPerson, @FileID, @CoverNo, @CreditCommittee, @ExpertNo, @ExpertID, @ReferralDate)", tableName);
                        cmd.Parameters.AddWithValue("RegisteredUserID", Users.MyUserID);
                        cmd.Parameters.AddWithValue("RegisteredDate", Network.GetNowDateSerial());
                        cmd.Parameters.AddWithValue("ModifierUserID", Users.MyUserID);
                        cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                        cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());
                        cmd.Parameters.AddWithValue("RequestStatus", RequestStatus.Barasi);
                        cmd.Parameters.AddWithValue("RequestID", requestId);
                        cmd.Parameters.AddWithValue("RequestType", "گزارش کارشناسی");
                        cmd.Parameters.AddWithValue("BranchID", branchId);
                        cmd.Parameters.AddWithValue("CustomersCount", 1);
                        cmd.Parameters.AddWithValue("CustomerID", customerId);
                        cmd.Parameters.AddWithValue("CustomerName", customerName);
                        cmd.Parameters.AddWithValue("IsLegalPerson", Convert.ToInt32(isLegalPerson));
                        cmd.Parameters.AddWithValue("FileID", Numeral.DBNullForNullValue(fileId));
                        cmd.Parameters.AddWithValue("CoverNo", Numeral.DBNullForNullValue(coverNo));
                        cmd.Parameters.AddWithValue("CreditCommittee", "-");
                        cmd.Parameters.AddWithValue("ExpertNo", id);
                        cmd.Parameters.AddWithValue("ExpertID", expertId);
                        cmd.Parameters.AddWithValue("ReferralDate", referralDate);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        cmd.CommandText = "Select @@Identity";
                        string serial = tableName + cmd.ExecuteScalar().ToString();
                        return new string[] { serial, id };
                    }
                }
            }
            catch
            {
                throw;
            }

            return null;
        }

        public static bool DeleteById(string id)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = string.Format("DELETE FROM [ExpertReports] WHERE ([ID]={0})", id);
                    int queryResult = cmd.ExecuteNonQuery();
                    if (queryResult == 1)
                    {
                        objConn.Close();
                        return true;
                    }
                }
            }
            catch
            {
                throw;
            }
            return false;
        }

        public static DataTable GetExpertReports(int? userId, string requestStatus)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;

                    if (userId.HasValue)
                    {
                        if (requestStatus == "پرونده های جاری")
                            cmd.CommandText = "SELECT ID, RegisteredDate, ModifiedDate, ModifiedTime, ToUserID, ReferralDate, ReferralType, BranchID, CustomerName, FileID, LastActionName, DateReport, DateEnd FROM [ExpertReports] WHERE ([ToUserID]=@ToUserID) AND (([DateEnd] IS NULL) OR (LEN([DateEnd]) = 0))";
                        if (requestStatus == "پرونده های مختومه")
                            cmd.CommandText = "SELECT ID, RegisteredDate, ModifiedDate, ModifiedTime, ToUserID, ReferralDate, ReferralType, BranchID, CustomerName, FileID, LastActionName, DateReport, DateEnd FROM [ExpertReports] WHERE ([ToUserID]=@ToUserID) AND LEN([DateEnd]) > 0";
                        if (requestStatus == "*")
                            cmd.CommandText = "SELECT ID, RegisteredDate, ModifiedDate, ModifiedTime, ToUserID, ReferralDate, ReferralType, BranchID, CustomerName, FileID, LastActionName, DateReport, DateEnd FROM [ExpertReports] WHERE ([ToUserID]=@ToUserID)";
                        cmd.Parameters.AddWithValue("ToUserID", userId);
                    }
                    else
                    {
                        if (requestStatus == "پرونده های جاری")
                            cmd.CommandText = "SELECT ID, RegisteredDate, ModifiedDate, ModifiedTime, ToUserID, ReferralDate, ReferralType, BranchID, CustomerName, FileID, LastActionName, DateEnd FROM [ExpertReports] WHERE ([DateEnd] IS NULL) OR (LEN([DateEnd]) = 0)";
                        if (requestStatus == "پرونده های مختومه")
                            cmd.CommandText = "SELECT ID, RegisteredDate, ModifiedDate, ModifiedTime, ToUserID, ReferralDate, ReferralType, BranchID, CustomerName, FileID, LastActionName, DateEnd FROM [ExpertReports] WHERE LEN([DateEnd]) > 0";
                        if (requestStatus == "*")
                            cmd.CommandText = "SELECT ID, RegisteredDate, ModifiedDate, ModifiedTime, ToUserID, ReferralDate, ReferralType, BranchID, CustomerName, FileID, LastActionName, DateEnd FROM [ExpertReports]";
                    }

                    var dataReader = cmd.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("BranchName");
                    dataTable.Columns.Add("ModifiedDateTime");
                    dataTable.Columns.Add("ExpertNo", typeof(int));
                    dataTable.Columns.Add("ExpertName");
                    dataTable.Columns.Add("Color");

                    dataTable.Load(dataReader);

                    objConn.Close();

                    if (dataTable.Rows.Count > 0)
                    {
                        dataTable = dataTable.AsEnumerable().OrderByDescending(x => int.Parse(x["ReferralDate"].ToString())).CopyToDataTable();
                        foreach (DataRow row in dataTable.Rows)
                        {
                            Branches.BranchInfo br = Branches.GetBranchById(row["BranchID"].ToString(), true);
                            row["BranchID"] = br.BranchId;
                            row["BranchName"] = br.BranchName;
                            row["ModifiedDateTime"] = PersianDate.Parse(row["ModifiedDate"].ToString()).ToStandard() + " - " + row["ModifiedTime"].ToString();
                            row["ExpertNo"] = ChkSum.GetFull(row["ID"].ToString());
                            row["ExpertName"] = Users.GetUserNameById(int.Parse(row["ToUserID"].ToString()));

                            PersianDateTime modifiedDate = PersianDateTime.Parse(int.Parse(row["ModifiedDate"].ToString()));
                            PersianDateTime referralDate = PersianDateTime.Parse(int.Parse(row["ReferralDate"].ToString()));
                            if (referralDate > modifiedDate)
                                modifiedDate = referralDate;

                            if ((PersianDateTime.Now - modifiedDate).Days <= 7)
                                row["Color"] = "سبز";
                            if ((PersianDateTime.Now - modifiedDate).Days > 7)
                                row["Color"] = "زرد";
                            if ((PersianDateTime.Now - modifiedDate).Days > 10)
                                row["Color"] = "قرمز";
                        }
                    }
                    return dataTable;
                }
            }
            catch
            {
                throw;
            }
        }

        public static bool UpdateExpertId(string id, int newUserId)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = string.Format("UPDATE [ExpertReports] SET [FromUserID]=@FromUserID, [ToUserID]=@ToUserID, [ReferralDate]=@ReferralDate, [DateEnd]=@DateEnd WHERE ([ID]={0})", id);
                    cmd.Parameters.AddWithValue("FromUserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("ToUserID", newUserId);
                    cmd.Parameters.AddWithValue("ReferralDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("DateEnd", DBNull.Value);

                    int queryResult = cmd.ExecuteNonQuery();
                    if (queryResult == 1)
                    {
                        objConn.Close();
                        return true;
                    }
                }
            }
            catch
            {
                throw;
            }
            return false;
        }

        public static bool UpdateDateEnd(string id, int? dateEnd)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = string.Format("UPDATE [ExpertReports] SET [DateEnd]=@DateEnd WHERE ([ID]={0})", id);
                    if (dateEnd.HasValue)
                        cmd.Parameters.AddWithValue("DateEnd", Network.GetNowDateSerial());
                    else
                        cmd.Parameters.AddWithValue("DateEnd", DBNull.Value);
                    int queryResult = cmd.ExecuteNonQuery();
                    objConn.Close();
                    if (queryResult == 1)
                        return true;
                    else
                        return false;
                }
            }
            catch
            {
                throw;
            }
        }

        public static bool UpdateLastAction(string id, string message, int dateAction, int? expertReportDate)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = string.Format("UPDATE [ExpertReports] SET [ModifiedDate]=@ModifiedDate, [ModifiedTime]=@ModifiedTime, [DateReport]=@DateReport, [LastActionName]=@LastActionName WHERE ([ID]={0})", id);
                    cmd.Parameters.AddWithValue("ModifiedDate", dateAction);
                    cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());
                    cmd.Parameters.AddWithValue("DateReport", Numeral.DBNullForNullValue(expertReportDate));
                    cmd.Parameters.AddWithValue("LastActionName", message);

                    int queryResult = cmd.ExecuteNonQuery();
                    objConn.Close();
                    if (queryResult == 1)
                        return true;
                    else
                        return false;
                }
            }
            catch
            {
                throw;
            }
        }

        public static bool UpdateModifiedDate(string id)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = string.Format("UPDATE [ExpertReports] SET [ModifiedDate]=@ModifiedDate, [ModifiedTime]=@ModifiedTime WHERE ([ID]={0})", id);
                    cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());

                    int queryResult = cmd.ExecuteNonQuery();
                    objConn.Close();
                    if (queryResult == 1)
                        return true;
                    else
                        return false;
                }
            }
            catch
            {
                throw;
            }
        }

    
    }
}
