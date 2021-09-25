
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
using System.Windows.Forms;

namespace GAM.Forms.Profile.Etebarat.Library
{
    class RequestManager
    {
        public static string[] GetTablesName()
        {
            List<string> tableNames = new List<string>();
            string strConnection = OLEDB.GetDatabase("DB_Requests.mdb");
            OleDbConnection objConn = new OleDbConnection(strConnection);
            objConn.Open();
            OleDbCommand objCmd = new OleDbCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.Text;
            string[] names = objConn.GetSchema("Tables").AsEnumerable().Where(x => x["TABLE_TYPE"].ToString() == "TABLE").Select(r => r["TABLE_NAME"].ToString()).ToArray();
            objConn.Close();

            foreach (string name in names)
            {
                if (Numeral.IsNumber(name))
                    tableNames.Add(name);
            }

            return tableNames.OrderBy(x => x).ToArray();
        }

        public static string InsertQuery(string requestStatus, long requestId, string requestType, string requestPlane, int branchId, int customersCount, string customerId, string customerName, bool isLegalPerson, long? fileId, long? coverNo, int facilityId, string bails1, string bails2, long requestAmount, string creditCommittee, int expertId, int? referralDate, string conditions, long? provinceLetterNo, string requestLocation)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    string tableName = RequestManager.GetTablesName().Last();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = string.Format("INSERT INTO {0} ([RegisteredUserID], [RegisteredDate], [ModifierUserID], [ModifiedDate], [ModifiedTime], [RequestStatus], [RequestID], [RequestType], [RequestPlane], [BranchID], [CustomersCount], [CustomerID], [CustomerName], [IsLegalPerson], [FileID], [CoverNo], [FacilityID], [Bails1], [Bails2], [RequestAmount], [CreditCommittee], [ExpertID], [ReferralDate], [Conditions], [ProvinceLetterNo], [RequestLocation]) VALUES (@RegisteredUserID, @RegisteredDate, @ModifierUserID, @ModifiedDate, @ModifiedTime, @RequestStatus, @RequestID, @RequestType, @RequestPlane, @BranchID, @CustomersCount, @CustomerID, @CustomerName, @IsLegalPerson, @FileID, @CoverNo, @FacilityID, @Bails1, @Bails2, @RequestAmount, @CreditCommittee, @ExpertID, @ReferralDate, @Conditions, @ProvinceLetterNo, @RequestLocation)", tableName);
                    cmd.Parameters.AddWithValue("RegisteredUserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("RegisteredDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("ModifierUserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());
                    cmd.Parameters.AddWithValue("RequestStatus", requestStatus);
                    cmd.Parameters.AddWithValue("RequestID", requestId);
                    cmd.Parameters.AddWithValue("RequestType", requestType);
                    cmd.Parameters.AddWithValue("RequestPlane", requestPlane);
                    cmd.Parameters.AddWithValue("BranchID", branchId);
                    cmd.Parameters.AddWithValue("CustomersCount", customersCount);
                    cmd.Parameters.AddWithValue("CustomerID", customerId);
                    cmd.Parameters.AddWithValue("CustomerName", customerName);
                    cmd.Parameters.AddWithValue("IsLegalPerson", Convert.ToInt32(isLegalPerson));
                    cmd.Parameters.AddWithValue("FileID", Numeral.DBNullForNullValue(fileId));
                    cmd.Parameters.AddWithValue("CoverNo", Numeral.DBNullForNullValue(coverNo));
                    cmd.Parameters.AddWithValue("FacilityID", facilityId);
                    cmd.Parameters.AddWithValue("Bails1", bails1);
                    cmd.Parameters.AddWithValue("Bails2", bails2);
                    cmd.Parameters.AddWithValue("RequestAmount", requestAmount);
                    cmd.Parameters.AddWithValue("CreditCommittee", creditCommittee);
                    cmd.Parameters.AddWithValue("ExpertID", expertId);
                    cmd.Parameters.AddWithValue("ReferralDate", Numeral.DBNullForNullValue(referralDate));
                    cmd.Parameters.AddWithValue("Conditions", conditions);
                    cmd.Parameters.AddWithValue("ProvinceLetterNo", Numeral.DBNullForNullValue(provinceLetterNo));
                    cmd.Parameters.AddWithValue("RequestLocation", Textual.DBNullForEmptyString(requestLocation));
                  
                    int queryResult = cmd.ExecuteNonQuery();
                    if (queryResult == 1)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "Select @@Identity";
                        string serial = tableName + cmd.ExecuteScalar().ToString();
                        objConn.Close();
                        return serial;
                    }
                }
            }
            catch
            {
                throw;
            }
            return string.Empty;
        }

        public static string UpdateQuery(bool updateModified, string serial, string requestStatus, long requestId, string requestType, string requestPlane, int branchId, int customersCount, string customerId, string customerName, bool isLegalPerson, long? fileId, long? coverNo, int facilityId, string bails1, string bails2, long requestAmount, string creditCommittee, string conditions, long? provinceLetterNo)
        {
            try
            {
                string tableName = serial.Substring(0, 4);
                string rowId = serial.Substring(4);
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    if (updateModified)
                    {
                        cmd.CommandText = string.Format("UPDATE [{0}] SET [ModifierUserID]=@ModifierUserID, [ModifiedDate]=@ModifiedDate, [ModifiedTime]=@ModifiedTime, [RequestStatus]=@RequestStatus, [RequestID]=@RequestID, [RequestType]=@RequestType, [RequestPlane]=@RequestPlane, [BranchID]=@BranchID, [CustomersCount]=@CustomersCount, [CustomerID]=@CustomerID, [CustomerName]=@CustomerName, [IsLegalPerson]=@IsLegalPerson, [FileID]=@FileID, [CoverNo]=@CoverNo, [FacilityID]=@FacilityID, [Bails1]=@Bails1, [Bails2]=@Bails2, [RequestAmount]=@RequestAmount, [CreditCommittee]=@CreditCommittee, [Conditions]=@Conditions, [ProvinceLetterNo]=@ProvinceLetterNo WHERE ([ID]={1})", tableName, rowId);
                        cmd.Parameters.AddWithValue("ModifierUserID", Users.MyUserID);
                        cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                        cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());
                    }
                    else 
                        cmd.CommandText = "UPDATE [" + tableName + "] SET [RequestStatus]=@RequestStatus, [RequestID]=@RequestID, [RequestType]=@RequestType, [RequestPlane]=@RequestPlane, [BranchID]=@BranchID, [CustomersCount]=@CustomersCount, [CustomerID]=@CustomerID, [CustomerName]=@CustomerName, [IsLegalPerson]=@IsLegalPerson, [FileID]=@FileID, [CoverNo]=@CoverNo, [FacilityID]=@FacilityID, [Bails1]=@Bails1, [Bails2]=@Bails2, [RequestAmount]=@RequestAmount, [CreditCommittee]=@CreditCommittee, [Conditions]=@Conditions, [ProvinceLetterNo]=@ProvinceLetterNo WHERE ([ID] = " + rowId + ")";

                    cmd.Parameters.AddWithValue("RequestStatus", requestStatus);
                    cmd.Parameters.AddWithValue("RequestID", requestId);
                    cmd.Parameters.AddWithValue("RequestType", requestType);
                    cmd.Parameters.AddWithValue("RequestPlane", requestPlane);
                    cmd.Parameters.AddWithValue("BranchID", branchId);
                    cmd.Parameters.AddWithValue("CustomersCount", customersCount);
                    cmd.Parameters.AddWithValue("CustomerID", customerId);
                    cmd.Parameters.AddWithValue("CustomerName", customerName);
                    cmd.Parameters.AddWithValue("IsLegalPerson", Convert.ToInt32(isLegalPerson));
                    cmd.Parameters.AddWithValue("FileID", Numeral.DBNullForNullValue(fileId));
                    cmd.Parameters.AddWithValue("CoverNo", Numeral.DBNullForNullValue(coverNo));
                    cmd.Parameters.AddWithValue("FacilityID", facilityId);
                    cmd.Parameters.AddWithValue("Bails1", bails1);
                    cmd.Parameters.AddWithValue("Bails2", bails2);
                    cmd.Parameters.AddWithValue("RequestAmount", requestAmount);
                    cmd.Parameters.AddWithValue("CreditCommittee", creditCommittee);
                    cmd.Parameters.AddWithValue("Conditions", conditions);
                    cmd.Parameters.AddWithValue("ProvinceLetterNo", Numeral.DBNullForNullValue(provinceLetterNo));

                    int queryResult = cmd.ExecuteNonQuery();
                    objConn.Close();
                    if (queryResult == 1)
                        return tableName + rowId;
                    else
                        return string.Empty;
                }
            }
            catch 
            {
                throw;
            }
        }

        public static string UpdateQuery(string serial, string requestStatus, string requestType, int branchId, string customerId, string customerName, bool isLegalPerson, long? fileId, long? coverNo, int facilityId, string bails1, string bailsDetail, long requestAmount, int expertId)
        {
            try
            {
                string tableName = serial.Substring(0, 4);
                string rowId = serial.Substring(4);
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = string.Format("UPDATE [{0}] SET [ModifierUserID]=@ModifierUserID, [ModifiedDate]=@ModifiedDate, [ModifiedTime]=@ModifiedTime, [RequestStatus]=@RequestStatus, [RequestType]=@RequestType, [BranchID]=@BranchID, [CustomerID]=@CustomerID, [CustomerName]=@CustomerName, [IsLegalPerson]=@IsLegalPerson, [FileID]=@FileID, [CoverNo]=@CoverNo, [FacilityID]=@FacilityID, [Bails1]=@Bails1, [BailsDetail]=@BailsDetail, [RequestAmount]=@RequestAmount, [ExpertID]=@ExpertID WHERE ([ID]={1})", tableName, rowId);
                    cmd.Parameters.AddWithValue("ModifierUserID", expertId);
                    cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());
                    cmd.Parameters.AddWithValue("RequestStatus", requestStatus);
                    cmd.Parameters.AddWithValue("RequestType", requestType);
                    cmd.Parameters.AddWithValue("BranchID", branchId);
                    cmd.Parameters.AddWithValue("CustomerID", customerId);
                    cmd.Parameters.AddWithValue("CustomerName", customerName);
                    cmd.Parameters.AddWithValue("IsLegalPerson", Convert.ToInt32(isLegalPerson));
                    cmd.Parameters.AddWithValue("FileID", Numeral.DBNullForNullValue(fileId));
                    cmd.Parameters.AddWithValue("CoverNo", Numeral.DBNullForNullValue(coverNo));
                    cmd.Parameters.AddWithValue("FacilityID", facilityId);
                    cmd.Parameters.AddWithValue("Bails1", bails1);
                    cmd.Parameters.AddWithValue("BailsDetail", bailsDetail);
                    cmd.Parameters.AddWithValue("RequestAmount", requestAmount);
                    cmd.Parameters.AddWithValue("ExpertID", expertId);

                    int queryResult = cmd.ExecuteNonQuery();
                    objConn.Close();
                    if (queryResult == 1)
                        return tableName + rowId;
                    else
                        return string.Empty;
                }
            }
            catch
            {
                throw;
            }
        }

        public static bool UpdateDateEnd(string serial, int? dateEnd)
        {
            try
            {
                string tableName = serial.Substring(0, 4);
                string rowId = serial.Substring(4);
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = string.Format("UPDATE [{0}] SET [DateEnd]=@DateEnd WHERE ([ID]={1})", tableName, rowId);
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

        public static bool UpdateRequestStatus(string[] serials, string groupId, string newStatus, string customerId, string customerName, bool dateUpdate)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    foreach (string serial in serials)
                    {
                        string tableName = serial.Substring(0, 4);
                        string rowId = serial.Substring(4);

                        if (dateUpdate)
                        {
                            cmd.CommandText = string.Format("UPDATE [{0}] SET [ModifierUserID]=@ModifierUserID, [ModifiedDate]=@ModifiedDate, [ModifiedTime]=@ModifiedTime, [RequestStatus]=@RequestStatus, [CustomerID]=@CustomerID, [CustomerName]=@CustomerName, [GroupID]=@GroupID WHERE ([ID]={1})", tableName, rowId);
                            cmd.Parameters.AddWithValue("ModifierUserID", Users.MyUserID);
                            cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                            cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());
                            cmd.Parameters.AddWithValue("RequestStatus", newStatus);
                            cmd.Parameters.AddWithValue("CustomerID", customerId);
                            cmd.Parameters.AddWithValue("CustomerName", customerName);
                            cmd.Parameters.AddWithValue("GroupID", groupId);
                        }
                        else
                        {
                            cmd.CommandText = string.Format("UPDATE [{0}] SET [RequestStatus]=@RequestStatus, [CustomerID]=@CustomerID, [CustomerName]=@CustomerName, [GroupID]=@GroupID WHERE ([ID]={1})", tableName, rowId);
                            cmd.Parameters.AddWithValue("RequestStatus", newStatus);
                            cmd.Parameters.AddWithValue("CustomerID", customerId);
                            cmd.Parameters.AddWithValue("CustomerName", customerName);
                            cmd.Parameters.AddWithValue("GroupID", groupId);
                        }

                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }

                    objConn.Close();
                    return true;
                }
            }
            catch
            {
                throw;
            }
        }

        public static bool DeleteQuery(string serial)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    string tableName = serial.Substring(0, 4);
                    string rowId = serial.Substring(4);
                    cmd.CommandText = string.Format("DELETE FROM [{0}] WHERE ([ID]={1})", tableName, rowId);
                    int queryResult = cmd.ExecuteNonQuery();
                    objConn.Close();
                    if (queryResult == 1)
                        return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public static bool UpdateExpertId(string[] serials, int newexpertId)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    foreach (string serial in serials)
                    {
                        string tableName = serial.Substring(0, 4);
                        string rowId = serial.Substring(4);

                        cmd.CommandText = string.Format("UPDATE [{0}] SET [ModifierUserID]=@ModifierUserID, [ModifiedDate]=@ModifiedDate, [ModifiedTime]=@ModifiedTime, [ExpertID]=@ExpertID, [ReferralDate]=@ReferralDate, [DateEnd]=@DateEnd, [RequestLocation]=@RequestLocation WHERE ([ID]={1})", tableName, rowId);
                        cmd.Parameters.AddWithValue("ModifierUserID", Users.MyUserID);
                        cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                        cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());
                        cmd.Parameters.AddWithValue("ExpertID", newexpertId);
                        cmd.Parameters.AddWithValue("ReferralDate", Network.GetNowDateSerial());
                        cmd.Parameters.AddWithValue("DateEnd", DBNull.Value);
                        cmd.Parameters.AddWithValue("RequestLocation", "اداره");

                        cmd.ExecuteNonQuery();
                    }

                    objConn.Close();
                    return true;
                }
            }
            catch
            {
                throw;
            }
        }
        public static bool UpdateExpertId(string serial, int newexpertId)
        {
            return UpdateExpertId(new string[] { serial }, newexpertId);
        }

        public static bool UpdateReviewNo(string[] serials, int expertId, string reviewNo)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    foreach (string serial in serials)
                    {
                        string tableName = serial.Substring(0, 4);
                        string rowId = serial.Substring(4);

                        cmd.CommandText = string.Format("UPDATE [{0}] SET [ModifierUserID]=@ModifierUserID, [ModifiedDate]=@ModifiedDate, [ModifiedTime]=@ModifiedTime, [ExpertID]=@ExpertID, [ReviewNo]=@ReviewNo, [DateEnd]=@DateEnd, [RequestLocation]=@RequestLocation WHERE ([ID]={1})", tableName, rowId);
                        cmd.Parameters.AddWithValue("ModifierUserID", Users.MyUserID);
                        cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                        cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());
                        cmd.Parameters.AddWithValue("ExpertID", expertId);
                        cmd.Parameters.AddWithValue("ReviewNo", reviewNo);
                        cmd.Parameters.AddWithValue("DateEnd", Network.GetNowDateSerial());
                        cmd.Parameters.AddWithValue("RequestLocation", "اداره");

                        cmd.ExecuteNonQuery();
                    }

                    objConn.Close();
                    return true;
                }
            }
            catch
            {
                throw;
            }
        }

        public static bool UpdateProvinceLetterDate(string serial, int dateSend)
        {
            try
            {
                string tableName = serial.Substring(0, 4);
                string rowId = serial.Substring(4);
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = string.Format("UPDATE [{0}] SET [ProvinceLetterDate]=@ProvinceLetterDate WHERE ([ID]={1})", tableName, rowId);
                    cmd.Parameters.AddWithValue("ProvinceLetterDate", dateSend);
                    int queryResult = cmd.ExecuteNonQuery();
                    objConn.Close();
                    if (queryResult == 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public static bool UpdateApprovedAmount(string serial, string requestStatus, string tehranCreditCommittee, int letterNo, int letterDate, double approvedAmount)
        {
            try
            {
                string tableName = serial.Substring(0, 4);
                string rowId = serial.Substring(4);
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = string.Format("UPDATE [{0}] SET [RequestStatus]=@RequestStatus, [TehranCreditCommittee]=@TehranCreditCommittee, [TehranLetterNo]=@TehranLetterNo, [TehranLetterDate]=@TehranLetterDate, [TehranApprovedAmount]=@TehranApprovedAmount WHERE ([ID]={1})", tableName, rowId);
                    cmd.Parameters.AddWithValue("RequestStatus", requestStatus);
                    cmd.Parameters.AddWithValue("TehranCreditCommittee", tehranCreditCommittee);
                    cmd.Parameters.AddWithValue("TehranLetterNo", letterNo);
                    cmd.Parameters.AddWithValue("TehranLetterDate", letterDate);
                    cmd.Parameters.AddWithValue("TehranApprovedAmount", approvedAmount);
                    int queryResult = cmd.ExecuteNonQuery();
                    objConn.Close();
                    if (queryResult == 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public static bool UpdateCreditCommittee(string serial, string requestStatus, string newCreditCommittee, int? provinceLetterNo, int? provinceLetterDate)
        {
            try
            {
                string tableName = serial.Substring(0, 4);
                string rowId = serial.Substring(4);
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = string.Format("UPDATE [{0}] SET [ModifierUserID]=@ModifierUserID, [ModifiedDate]=@ModifiedDate, [ModifiedTime]=@ModifiedTime, [RequestStatus]=@RequestStatus, [CreditCommittee]=@CreditCommittee, [ProvinceLetterNo]=@ProvinceLetterNo, [ProvinceLetterDate]=@ProvinceLetterDate WHERE ([ID]={1})", tableName, rowId);
                    cmd.Parameters.AddWithValue("ModifierUserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());
                    cmd.Parameters.AddWithValue("RequestStatus", requestStatus);
                    cmd.Parameters.AddWithValue("CreditCommittee", newCreditCommittee);
                    cmd.Parameters.AddWithValue("ProvinceLetterNo", Numeral.DBNullForNullValue(provinceLetterNo));
                    cmd.Parameters.AddWithValue("ProvinceLetterDate", Numeral.DBNullForNullValue(provinceLetterDate));

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

        public static DataTable GetRequestById(long requestId)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    DataTable masterTable = new DataTable();
                    masterTable.Columns.Add("ModifiedDateTime");
                    masterTable.Columns.Add("CustomerName2");
                    masterTable.Columns.Add("BranchName");
                    masterTable.Columns.Add("FacilityName");
                    masterTable.Columns.Add("ExpertName");

                    foreach (string tblName in RequestManager.GetTablesName())
                    {
                        cmd.CommandText = string.Format("SELECT {0} AS TableName, TableName & [ID] AS RequestSerial, * FROM [{0}] WHERE ([RequestID]=@RequestID)", tblName);
                        cmd.Parameters.AddWithValue("RequestID", requestId);
                        var dataReader = cmd.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        masterTable.Merge(dataTable);
                    }

                    objConn.Close();

                    if (masterTable.Rows.Count > 0)
                    {
                        masterTable = masterTable.AsEnumerable().OrderByDescending(x => x["ModifiedDate"]).ThenByDescending(x => x["ModifiedTime"]).CopyToDataTable();

                        for (int i = 0; i < masterTable.Rows.Count; i++)
                        {
                            DataRow row = masterTable.Rows[i];
                            int modifiedDate = int.Parse(row["ModifiedDate"].ToString());
                            if (Network.GetNowDateSerial() == modifiedDate)
                                row["ModifiedDateTime"] = "امروز - " + row["ModifiedTime"].ToString();
                            else if (Network.GetNowPersianDate().AddDays(-1).ToSerial() == modifiedDate)
                                row["ModifiedDateTime"] = "دیروز - " + row["ModifiedTime"].ToString();
                            else
                                row["ModifiedDateTime"] = PersianDate.Parse(modifiedDate).ToStandard() + " - " + row["ModifiedTime"].ToString();

                            row["CustomerName2"] = row["CustomerName"].ToString().Replace("آ", "ا").Replace("ئ", "ی").Replace(" ", "");
                            row["FacilityName"] = Facilitys.GetFacilityNameById(row["FacilityID"].ToString());
                            row["ExpertName"] = Users.GetUserNameById(Numeral.AnyToInt32(row["ExpertID"]));
                            Branches.BranchInfo br = Branches.GetBranchById(row["BranchID"].ToString(), true);
                            row["BranchID"] = br.BranchId;
                            row["BranchName"] = br.BranchName;
                        }
                    }

                    return masterTable;
                }
            }
            catch
            {
                throw;
            }
        }

        public static string[] GetSerialsByExpertNo(string expertNo)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    List<string> serials = new List<string>();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    DataTable masterTable = new DataTable();
                    foreach (string tblName in RequestManager.GetTablesName())
                    {
                        cmd.CommandText = string.Format("SELECT {0} AS TableName, TableName & [ID] AS RequestSerial, * FROM [{0}] WHERE ([ExpertNo]=@ExpertNo)", tblName);
                        cmd.Parameters.AddWithValue("ExpertNo", expertNo);
                        var dataReader = cmd.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        masterTable.Merge(dataTable);
                    }

                    foreach (DataRow row in masterTable.Rows)
                        serials.Add(row["RequestSerial"].ToString());

                    objConn.Close();

                    return serials.ToArray();
                }
            }
            catch
            {
                throw;
            }
        }


        public static DataTable GetBySerial(string serial)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    string tblName = serial.Substring(0, 4);
                    string rowId = serial.Substring(4);
                    cmd.CommandText = string.Format("SELECT {0} AS TableName, TableName & [ID] AS RequestSerial, * FROM {0} WHERE ([ID]={1})", tblName, rowId);
                    var dataReader = cmd.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    objConn.Close();
                    return dataTable;
                }
            }
            catch
            {
                throw;
            }
        }

        public static DataTable GetAllByModifiedDate(int dateStart, int dateEnd)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    DataTable masterTable = new DataTable();
                    masterTable.Columns.Add("ModifiedDateTime");
                    masterTable.Columns.Add("CustomerName2");
                    masterTable.Columns.Add("BranchName");
                    masterTable.Columns.Add("FacilityName");
                    masterTable.Columns.Add("ExpertName");

                    foreach (string tblName in RequestManager.GetTablesName())
                    {
                        cmd.CommandText = string.Format("SELECT {0} AS TableName, TableName & [ID] AS RequestSerial, ModifiedDate, ModifiedTime, RequestStatus, CreditCommittee, RequestID, RequestType, BranchID, CustomerName, FacilityID, RequestAmount, ExpertID, FileID FROM [{0}] WHERE ([ModifiedDate] >= @DateStart AND [ModifiedDate] <= @DateEnd)", tblName);
                        cmd.Parameters.AddWithValue("DateStart", dateStart);
                        cmd.Parameters.AddWithValue("DateEnd", dateEnd);

                        var dataReader = cmd.ExecuteReader();

                        //while (dataReader.HasRows)
                        //{
                        //    Console.WriteLine("\t{0}\t{1}", dataReader.GetName(0),
                        //        dataReader.GetName(1));

                        //    while (dataReader.Read())
                        //    {
                        //        Console.WriteLine("\t{0}\t{1}", dataReader.GetInt32(0),
                        //            dataReader.GetString(1));
                        //    }
                        //    dataReader.NextResult();
                        //}

                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);

                        if (dataTable.Rows.Count > 0)
                            masterTable.Merge(dataTable);
                    }
                    objConn.Close();

                    if (masterTable.Rows.Count > 0)
                    {
                        masterTable = masterTable.AsEnumerable().OrderByDescending(x => x["ModifiedDate"]).ThenByDescending(x => x["ModifiedTime"]).CopyToDataTable();

                        for (int i = 0; i < masterTable.Rows.Count; i++)
                        {
                            DataRow row = masterTable.Rows[i];
                            int modifiedDate = int.Parse(row["ModifiedDate"].ToString());
                            if (Network.GetNowDateSerial() == modifiedDate)
                                row["ModifiedDateTime"] = "امروز - " + row["ModifiedTime"].ToString();
                            else if (Network.GetNowPersianDate().AddDays(-1).ToSerial() == modifiedDate)
                                row["ModifiedDateTime"] = "دیروز - " + row["ModifiedTime"].ToString();
                            else
                                row["ModifiedDateTime"] = PersianDate.Parse(modifiedDate).ToStandard() + " - " + row["ModifiedTime"].ToString();

                            row["CustomerName2"] = row["CustomerName"].ToString().Replace("آ", "ا").Replace("ئ", "ی").Replace(" ", "");
                            row["FacilityName"] = Facilitys.GetFacilityNameById(row["FacilityID"].ToString());
                            row["ExpertName"] = Users.GetUserNameById(Numeral.AnyToInt32(row["ExpertID"]));
                            Branches.BranchInfo br = Branches.GetBranchById(row["BranchID"].ToString(), true);
                            row["BranchID"] = br.BranchId;
                            row["BranchName"] = br.BranchName;
                        }
                    }

                    return masterTable;
                }
            }
            catch
            {
                throw;
            }
        }

        public static DataTable GetAllByModifiedDateAndBranchID(int dateStart, int dateEnd, int branchId)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    DataTable masterTable = new DataTable();
                    masterTable.Columns.Add("ModifiedDateTime");
                    masterTable.Columns.Add("CustomerName2");
                    masterTable.Columns.Add("BranchName");
                    masterTable.Columns.Add("FacilityName");
                    masterTable.Columns.Add("ExpertName");

                    foreach (string tblName in RequestManager.GetTablesName())
                    {
                        cmd.CommandText = string.Format("SELECT {0} AS TableName, TableName & [ID] AS RequestSerial, ModifiedDate, ModifiedTime, RequestStatus, CreditCommittee, RequestID, RequestType, BranchID, CustomerName, FacilityID, RequestAmount, ExpertID, FileID FROM [{0}] WHERE ([BranchID]=@BranchID) AND ([ModifiedDate] >= DateStart AND [ModifiedDate] <= DateEnd)", tblName);
                        cmd.Parameters.AddWithValue("BranchID", branchId);
                        cmd.Parameters.AddWithValue("DateStart", dateStart);
                        cmd.Parameters.AddWithValue("DateEnd", dateEnd);

                        var dataReader = cmd.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        masterTable.Merge(dataTable);
                    }

                    objConn.Close();

                    if (masterTable.Rows.Count > 0)
                    {
                        masterTable = masterTable.AsEnumerable().OrderByDescending(x => x["ModifiedDate"]).ThenByDescending(x => x["ModifiedTime"]).CopyToDataTable();

                        for (int i = 0; i < masterTable.Rows.Count; i++)
                        {
                            DataRow row = masterTable.Rows[i];
                            int modifiedDate = int.Parse(row["ModifiedDate"].ToString());
                            if (Network.GetNowDateSerial() == modifiedDate)
                                row["ModifiedDateTime"] = "امروز - " + row["ModifiedTime"].ToString();
                            else if (Network.GetNowPersianDate().AddDays(-1).ToSerial() == modifiedDate)
                                row["ModifiedDateTime"] = "دیروز - " + row["ModifiedTime"].ToString();
                            else
                                row["ModifiedDateTime"] = PersianDate.Parse(modifiedDate).ToStandard() + " - " + row["ModifiedTime"].ToString();

                            row["CustomerName2"] = row["CustomerName"].ToString().Replace("آ", "ا").Replace("ئ", "ی").Replace(" ", "");
                            row["FacilityName"] = Facilitys.GetFacilityNameById(row["FacilityID"].ToString());
                            row["ExpertName"] = Users.GetUserNameById(Numeral.AnyToInt32(row["ExpertID"]));
                            Branches.BranchInfo br = Branches.GetBranchById(row["BranchID"].ToString(), true);
                            row["BranchID"] = br.BranchId;
                            row["BranchName"] = br.BranchName;
                        }
                    }

                    return masterTable;
                }
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetRegisteredRequestsByUserID(int registeredDate, int userId)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    DataTable masterTable = new DataTable();
                    masterTable.Columns.Add("BranchName");
                    masterTable.Columns.Add("FacilityName");
                    masterTable.Columns.Add("ExpertName");

                    foreach (string tblName in RequestManager.GetTablesName())
                    {
                        cmd.CommandText = string.Format("SELECT * FROM [{0}] WHERE ([RegisteredUserID]=@RegisteredUserID) AND ([RegisteredDate]=@RegisteredDate) ORDER BY [ID] DESC", tblName);
                        cmd.Parameters.AddWithValue("RegisteredUserID", userId);
                        cmd.Parameters.AddWithValue("RegisteredDate", registeredDate);

                        var dataReader = cmd.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        masterTable.Merge(dataTable);
                    }

                    objConn.Close();

                    if (masterTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in masterTable.Rows)
                        {
                            Branches.BranchInfo br = Branches.GetBranchById(row["BranchID"].ToString(), true);
                            row["BranchID"] = br.BranchId;
                            row["BranchName"] = br.BranchName;
                            row["FacilityName"] = Facilitys.GetFacilityNameById(row["FacilityID"].ToString());
                            row["ExpertName"] = Users.GetUserNameById(Numeral.AnyToInt32(row["ExpertID"]));
                        }
                    }

                    return masterTable;
                }
            }
            catch
            {
                throw;
            }
        }

        public static DataTable LoadParametrs(int dateStart, int dateEnd, string[] creditCommittee, string[] requestTypes, string[] customersCount, string[] requestStatus, string[] facilitys, string conditions)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    DataTable masterTable = new DataTable();
                    masterTable.Columns.Add("ModifiedDate2");
                    masterTable.Columns.Add("DomainID");
                    masterTable.Columns.Add("DomainName");
                    masterTable.Columns.Add("BranchName");
                    masterTable.Columns.Add("Category");
                    masterTable.Columns.Add("FacilityName");
                    masterTable.Columns.Add("ExpertName");
                    masterTable.Columns.Add("RequestID2");
                    masterTable.Columns.Add("ProvinceLetterDate2");
                    masterTable.Columns.Add("TehranLetterDate2");

                    foreach (string tblName in RequestManager.GetTablesName())
                    {
                        if (customersCount.Length == 1)
                        {
                            if (customersCount[0] == "موردی")
                                cmd.CommandText = string.Format("SELECT {0} AS TableName, TableName & [ID] AS RequestSerial, * FROM [{0}] WHERE ([ModifiedDate]>=@DateStart AND [ModifiedDate]<=@DateEnd) AND ([CreditCommittee] IN ({1})) AND ([CustomersCount] = 1) AND ([RequestType] IN ({2})) AND ([RequestStatus] IN ({3})) AND ([FacilityID] IN ({4}) AND ([Conditions] LIKE '%{5}%'))", tblName, string.Join(",", creditCommittee), string.Join(",", requestTypes), string.Join(",", requestStatus), string.Join(",", facilitys), conditions);
                            if (customersCount[0] == "گروهی")
                                cmd.CommandText = string.Format("SELECT {0} AS TableName, TableName & [ID] AS RequestSerial, * FROM [{0}] WHERE ([ModifiedDate]>=@DateStart AND [ModifiedDate]<=@DateEnd) AND ([CreditCommittee] IN ({1})) AND ([CustomersCount] > 1) AND ([RequestType] IN ({2})) AND ([RequestStatus] IN ({3})) AND ([FacilityID] IN ({4}) AND ([Conditions] LIKE '%{5}%'))", tblName, string.Join(",", creditCommittee), string.Join(",", requestTypes), string.Join(",", requestStatus), string.Join(",", facilitys), conditions);
                        }
                        if (customersCount.Length == 2)
                            cmd.CommandText = string.Format("SELECT {0} AS TableName, TableName & [ID] AS RequestSerial, * FROM [{0}] WHERE ([ModifiedDate]>=@DateStart AND [ModifiedDate]<=@DateEnd) AND ([CreditCommittee] IN ({1})) AND ([RequestType] IN ({2})) AND ([RequestStatus] IN ({3})) AND ([FacilityID] IN ({4}) AND ([Conditions] LIKE '%{5}%'))", tblName, string.Join(",", creditCommittee), string.Join(",", requestTypes), string.Join(",", requestStatus), string.Join(",", facilitys), conditions);

                        cmd.Parameters.AddWithValue("DateStart", dateStart);
                        cmd.Parameters.AddWithValue("DateEnd", dateEnd);

                        var dataReader = cmd.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        masterTable.Merge(dataTable);
                    }

                    objConn.Close();

                    if (masterTable.Rows.Count > 0)
                    {
                        masterTable = masterTable.AsEnumerable().OrderByDescending(x => x["ModifiedDate"]).ThenByDescending(x => x["ModifiedTime"]).CopyToDataTable();

                        for (int i = 0; i < masterTable.Rows.Count; i++)
                        {
                            DataRow row = masterTable.Rows[i];
                            row["RequestID2"] = row["RequestID"].ToString();
                            if (row["ModifiedDate"].ToString().Length > 0)
                                row["ModifiedDate2"] = PersianDateTime.Parse(int.Parse(row["ModifiedDate"].ToString())).ToShortDateString();
                            if (row["ProvinceLetterDate"].ToString().Length > 0)
                                row["ProvinceLetterDate2"] = PersianDateTime.Parse(int.Parse(row["ProvinceLetterDate"].ToString())).ToShortDateString();
                            if (row["TehranLetterDate"].ToString().Length > 0)
                                row["TehranLetterDate2"] = PersianDateTime.Parse(int.Parse(row["TehranLetterDate"].ToString())).ToShortDateString();

                            row["Category"] = Facilitys.GetFacilityCategoryByID(row["FacilityID"].ToString());
                            row["FacilityName"] = Facilitys.GetFacilityNameById(row["FacilityID"].ToString());
                            row["ExpertName"] = Users.GetUserNameById(Numeral.AnyToInt32(row["ExpertID"]));

                            Branches.BranchInfo br = Branches.GetBranchById(row["BranchID"].ToString(), true);
                            row["DomainID"] = br.Domain.DomainId;
                            row["DomainName"] = br.Domain.DomainName;
                            row["BranchID"] = br.BranchId;
                            row["BranchName"] = br.BranchName;
                        }
                    }

                    return masterTable;
                }
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetRequests(int userId, string fileStatus)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    DataTable masterTable = new DataTable();
                    masterTable.Columns.Add("ModifiedDateTime");
                    masterTable.Columns.Add("BranchName");
                    masterTable.Columns.Add("FacilityName");
                    masterTable.Columns.Add("ExpertName");
                   var tableNames = RequestManager.GetTablesName();
                   foreach (string tblName in tableNames)
                    {
                        if (userId > 0)
                        {
                            if (fileStatus == "پرونده های جاری")
                                cmd.CommandText = string.Format("SELECT {0} AS TableName, TableName & [ID] AS RequestSerial, ModifiedDate, ModifiedTime, ReferralDate, RequestStatus, CreditCommittee, RequestID, RequestType, BranchID, CustomerName, FacilityID, RequestAmount, ExpertID, ReviewNo, ExpertNo, FileID, DateEnd FROM {0} WHERE ([ExpertID]=@ExpertID) AND ([RequestStatus]='{1}') AND (LEN([ReferralDate]) > 0) AND ([DateEnd] IS NULL OR LEN([DateEnd]) = 0) AND ([RequestType] <> '{2}')", tblName, RequestStatus.Barasi, "گزارش کارشناسی");
                            if (fileStatus == "پرونده های مختومه")
                                cmd.CommandText = string.Format("SELECT {0} AS TableName, TableName & [ID] AS RequestSerial, ModifiedDate, ModifiedTime, ReferralDate, RequestStatus, CreditCommittee, RequestID, RequestType, BranchID, CustomerName, FacilityID, RequestAmount, ExpertID, ReviewNo, ExpertNo, FileID, DateEnd FROM {0} WHERE ([ExpertID]=@ExpertID) AND (LEN([ReferralDate]) > 0) AND LEN([DateEnd]) > 0  AND ([RequestType] <> '{1}')", tblName, "گزارش کارشناسی");
                            cmd.Parameters.AddWithValue("ExpertID", userId);
                        }

                        var dataReader = cmd.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        masterTable.Merge(dataTable);
                    }

                    objConn.Close();

                    if (masterTable.Rows.Count > 0)
                    {
                        masterTable = masterTable.AsEnumerable().OrderByDescending(x => x["ReferralDate"].ToString()).CopyToDataTable();
                        foreach (DataRow row in masterTable.Rows)
                        {
                            Branches.BranchInfo br = Branches.GetBranchById(row["BranchID"].ToString(), true);
                            row["BranchID"] = br.BranchId;
                            row["BranchName"] = br.BranchName;
                            row["ModifiedDateTime"] = PersianDate.Parse(row["ModifiedDate"].ToString()).ToStandard() + " - " + row["ModifiedTime"].ToString();
                            row["FacilityName"] = Facilitys.GetFacilityNameById(row["FacilityID"].ToString());
                            row["ExpertName"] = Users.GetUserNameById(Numeral.AnyToInt32(row["ExpertID"]));
                            if (row["ReviewNo"].ToString().Length > 0)
                            {
                                row["ReviewNo"] = ChkSum.GetFull(row["ReviewNo"].ToString());
                            }
                        }
                    }
                    return masterTable;
                }
            }
            catch
            {
                return null;
            }
        }

        public static List<DataTable> GetRequests(string expertId)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    List<DataTable> tables = new List<DataTable>();
                    var tableNames = RequestManager.GetTablesName();
                    foreach (string tblName in tableNames)
                    {
                        if (expertId == "*")
                            cmd.CommandText = string.Format("SELECT {0} AS TableName, TableName & [ID] AS RequestSerial, * FROM {0}", tblName);
                        else 
                            cmd.CommandText = string.Format("SELECT {0} AS TableName, TableName & [ID] AS RequestSerial, * FROM {0} WHERE ExpertID={1}", tblName, expertId);

                        var dataReader = cmd.ExecuteReader();
                        DataTable dataTable = new DataTable(tblName);
                        dataTable.Load(dataReader);
                        tables.Add(dataTable);
                    }

                    objConn.Close();

                    return tables;
                }
            }
            catch
            {
                return null;
            }
        }

        public static void UpdateChangeRows(DataTable dt)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + dt.TableName, objConn);
                    OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
                    adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    adapter.Update(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetRequestsByCreditCommittee(string requestStatus, string creditCommittee)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    DataTable masterTable = new DataTable();
                    foreach (string tblName in RequestManager.GetTablesName())
                    {
                        cmd.CommandText = string.Format("SELECT TOP 1 [RequestID] FROM {0} WHERE ([RequestStatus]=@RequestStatus) AND ([CreditCommittee]=@CreditCommittee)", tblName);
                        cmd.Parameters.AddWithValue("RequestStatus", requestStatus);
                        cmd.Parameters.AddWithValue("CreditCommittee", creditCommittee);

                        if (cmd.ExecuteScalar() != null)
                        {
                            cmd.CommandText = string.Format("SELECT {0} AS TableName, TableName & [ID] AS RequestSerial, * FROM {0} WHERE ([RequestStatus]=@RequestStatus) AND ([CreditCommittee]=@CreditCommittee)", tblName);
                            var dataReader = cmd.ExecuteReader();
                            DataTable dataTable = new DataTable();
                            dataTable.Load(dataReader);
                            masterTable.Merge(dataTable);
                        }
                    }

                    objConn.Close();

                    if (masterTable.Rows.Count > 0)
                        masterTable = masterTable.AsEnumerable().OrderByDescending(x => x["ModifiedDate"]).ThenByDescending(x => x["ModifiedTime"]).CopyToDataTable();

                    masterTable.Columns.Add("ModifiedDateTime");
                    masterTable.Columns.Add("BranchName");
                    masterTable.Columns.Add("FacilityName");
                    masterTable.Columns.Add("ExpertName");

                    foreach (DataRow row in masterTable.Rows)
                    {
                        Branches.BranchInfo br = Branches.GetBranchById(row["BranchID"].ToString(), true);
                        row["BranchID"] = br.BranchId;
                        row["BranchName"] = br.BranchName;
                        row["ModifiedDateTime"] = PersianDate.Parse(row["ModifiedDate"].ToString()).ToStandard() + " - " + row["ModifiedTime"].ToString();
                        row["FacilityName"] = Facilitys.GetFacilityNameById(row["FacilityID"].ToString());
                        row["ExpertName"] = Users.GetUserNameById(Numeral.AnyToInt32(row["ExpertID"]));
                    }
                    return masterTable;
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool UpdateRequestLocation(string serial, string reviewNo, string location)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.Parameters.AddWithValue("ModifierUserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());
                    cmd.Parameters.AddWithValue("RequestLocation", location);

                    if (reviewNo.Length > 0)
                    {
                        foreach (string table in RequestManager.GetTablesName())
                        {
                            cmd.CommandText = string.Format("UPDATE [{0}] SET [ModifierUserID]=@ModifierUserID, [ModifiedDate]=@ModifiedDate, [ModifiedTime]=@ModifiedTime, [RequestLocation]=@RequestLocation WHERE ([ReviewNo]={1})", table, reviewNo);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    if (serial.Length > 0)
                    {
                        string tableName = serial.Substring(0, 4);
                        string rowId = serial.Substring(4);
                        cmd.CommandText = string.Format("UPDATE [{0}] SET [ModifierUserID]=@ModifierUserID, [ModifiedDate]=@ModifiedDate, [ModifiedTime]=@ModifiedTime, [RequestLocation]=@RequestLocation WHERE ([ID]={1})", tableName, rowId);
                    }

                    int queryResult = cmd.ExecuteNonQuery();
                    objConn.Close();
                    if (queryResult > 0)
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

        public static Dictionary<string, string> GetSerialsByReviewNo(string reviewNo)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    DataTable masterTable = new DataTable();
                    Dictionary<string, string> serials = new Dictionary<string, string>();
                    if (reviewNo.Length > 0)
                    {
                        foreach (string table in RequestManager.GetTablesName())
                        {
                            cmd.CommandText = string.Format("SELECT {0} AS TableName, TableName & [ID] AS RequestSerial, [RequestID] FROM [{0}] WHERE ([ReviewNo]={1})", table, reviewNo);
                            var dataReader = cmd.ExecuteReader();
                            DataTable dataTable = new DataTable();
                            dataTable.Load(dataReader);
                            masterTable.Merge(dataTable);
                        }
                    }

                    objConn.Close();
                    foreach (DataRow r in masterTable.Rows)
                        serials.Add(r["RequestSerial"].ToString(), r["RequestID"].ToString());

                    return serials;
                }
            }
            catch
            {
                throw;
            }
        }

        public static Dictionary<string, string> GetSerialsByGroupID(string groupId)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    DataTable masterTable = new DataTable();
                    Dictionary<string, string> serials = new Dictionary<string, string>();
                    if (groupId.Length > 0)
                    {
                        foreach (string table in RequestManager.GetTablesName())
                        {
                            cmd.CommandText = string.Format("SELECT {0} AS TableName, TableName & [ID] AS RequestSerial, [RequestID] FROM [{0}] WHERE ([GroupID]='{1}')", table, groupId);
                            var dataReader = cmd.ExecuteReader();
                            DataTable dataTable = new DataTable();
                            dataTable.Load(dataReader);
                            masterTable.Merge(dataTable);
                        }
                    }

                    objConn.Close();
                    foreach (DataRow r in masterTable.Rows)
                        serials.Add(r["RequestSerial"].ToString(), r["RequestID"].ToString());

                    return serials;
                }
            }
            catch
            {
                throw;
            }
        }

        public static Dictionary<string, string> GetSerialsByCustomerId(string custId)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    DataTable masterTable = new DataTable();
                    Dictionary<string, string> serials = new Dictionary<string, string>();
                    if (custId.Length > 0)
                    {
                        foreach (string table in RequestManager.GetTablesName())
                        {
                            cmd.CommandText = string.Format("SELECT {0} AS TableName, TableName & [ID] AS RequestSerial, [RequestID] FROM [{0}] WHERE ([CustomerID]=@CustomerID AND [ModifiedDate] >= @DateStart AND [ModifiedDate] <= @DateEnd)", table);
                            cmd.Parameters.AddWithValue("CustomerID", custId);
                            cmd.Parameters.AddWithValue("DateStart", PersianDate.Now.AddDays(-60).ToSerial());
                            cmd.Parameters.AddWithValue("DateEnd", PersianDate.Now.ToSerial());

                            var dataReader = cmd.ExecuteReader();
                            DataTable dataTable = new DataTable();
                            dataTable.Load(dataReader);
                            masterTable.Merge(dataTable);
                            cmd.Parameters.Clear();
                        }
                    }

                    objConn.Close();
                    foreach (DataRow r in masterTable.Rows)
                        serials.Add(r["RequestSerial"].ToString(), r["RequestID"].ToString());

                    return serials;
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
