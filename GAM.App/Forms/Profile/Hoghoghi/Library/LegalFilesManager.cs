
using GAM.Connections;
using GAM.Forms.Information.Library;
using GAM.Forms.Settings.Library;
using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Profile.LegalFile.Library
{
    class LegalFilesManager
    {

        public static string InsertQuery(long contractId, string contractPlan, string bailType, int levelId, int dateLevel, int branchId, long? customerId, string customerName, string fileId, int? indicatorId, int? notaryId, string mortgageNo, long evaluationAmount1, long evaluationAmount2, long mandehAsl, long mandehSood, long mandehJarimeh, long mandehHazineh, long mandehAbonman, int dateDebtUpdate, int dateAuction, int expertId)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_LegalFiles.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = "INSERT INTO [LegalFiles] ([RegisteredUserID], [RegisteredDate], [ModifierUserID], [ModifiedDate], [ModifiedTime], [BailType], [FileStatus], [ContractID], [ContractPlan], [LevelID], [DateLevel], [BranchID], [CustomerID], [CustomerName], [FileID], [IndicatorID], [NotaryID], [MortgageNo], [EvaluationAmount1], [EvaluationAmount2], [MandehAsl], [MandehSood], [MandehJarimeh], [MandehHazineh], [MandehAbonman], [DateDebtUpdate], [DateAuction], [ExpertID], [ReferralDateTimeToExpert]) VALUES (@RegisteredUserID, @RegisteredDate, @ModifierUserID, @ModifiedDate, @ModifiedTime, @BailType, @FileStatus, @ContractID, @ContractPlan, @LevelID, @DateLevel, @BranchID, @CustomerID, @CustomerName, @FileID, @IndicatorID, @NotaryID, @MortgageNo, @EvaluationAmount1, @EvaluationAmount2, @MandehAsl, @MandehSood, @MandehJarimeh, @MandehHazineh, @MandehAbonman, @DateDebtUpdate, @DateAuction, @ExpertID, @ReferralDateTimeToExpert)";
                    cmd.Parameters.AddWithValue("RegisteredUserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("RegisteredDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("ModifierUserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());
                    cmd.Parameters.AddWithValue("BailType", bailType);
                    cmd.Parameters.AddWithValue("FileStatus", LegalFileStatus.Review);
                    cmd.Parameters.AddWithValue("ContractID", contractId);
                    cmd.Parameters.AddWithValue("ContractPlan", contractPlan);
                    cmd.Parameters.AddWithValue("LevelID", levelId);
                    cmd.Parameters.AddWithValue("DateLevel", dateLevel);
                    cmd.Parameters.AddWithValue("BranchID", branchId);
                    cmd.Parameters.AddWithValue("CustomerID", customerId);
                    cmd.Parameters.AddWithValue("CustomerName", customerName);
                    cmd.Parameters.AddWithValue("FileID", fileId); 
                    cmd.Parameters.AddWithValue("IndicatorID", Numeral.DBNullForNullValue(indicatorId)); 
                    cmd.Parameters.AddWithValue("NotaryID", Numeral.DBNullForNullValue(notaryId)); 
                    cmd.Parameters.AddWithValue("MortgageNo", mortgageNo); 
                    cmd.Parameters.AddWithValue("EvaluationAmount1", evaluationAmount1);
                    cmd.Parameters.AddWithValue("EvaluationAmount2", evaluationAmount2);
                    cmd.Parameters.AddWithValue("MandehAsl", mandehAsl);
                    cmd.Parameters.AddWithValue("MandehSood", mandehSood);
                    cmd.Parameters.AddWithValue("MandehJarimeh", mandehJarimeh);
                    cmd.Parameters.AddWithValue("MandehHazineh", mandehHazineh);
                    cmd.Parameters.AddWithValue("MandehAbonman", mandehAbonman);
                    cmd.Parameters.AddWithValue("DateDebtUpdate", dateDebtUpdate);
                    cmd.Parameters.AddWithValue("DateAuction", Numeral.DBNullForZeroValue(dateAuction));
                    cmd.Parameters.AddWithValue("ExpertID", Numeral.DBNullForNullValue(expertId));
                    cmd.Parameters.AddWithValue("ReferralDateTimeToExpert", Network.GetNowDateTimeString());

                    int queryResult = cmd.ExecuteNonQuery();
                    if (queryResult == 1)
                    {
                        cmd.Parameters.Clear();
                        objConn.Close();
                        return contractId.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return string.Empty;
        }

        public static string UpdateQuery(long contractId, string contractPlan, string bailType, int branchId, long? customerId, string customerName, string fileId, int? indicatorId, int? notaryId, string mortgageNo, long evaluationAmount1, long evaluationAmount2, long mandehAsl, long mandehSood, long mandehJarimeh, long mandehHazineh, long mandehAbonman, int dateDebtUpdate, int dateAuction, int expertId)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_LegalFiles.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = "UPDATE [LegalFiles] SET [ModifierUserID]=@ModifierUserID, [ModifiedDate]=@ModifiedDate, [ModifiedTime]=@ModifiedTime, [ContractPlan]=@ContractPlan, [BailType]=@BailType, [BranchID]=@BranchID, [CustomerID]=@CustomerID, [CustomerName]=@CustomerName, [FileID]=@FileID, [IndicatorID]=@IndicatorID, [NotaryID]=@NotaryID, [MortgageNo]=@MortgageNo, [EvaluationAmount1]=@EvaluationAmount1, [EvaluationAmount2]=@EvaluationAmount2, [MandehAsl]=@MandehAsl, [MandehSood]=@MandehSood, [MandehJarimeh]=@MandehJarimeh, [MandehHazineh]=@MandehHazineh, [MandehAbonman]=@MandehAbonman, [DateDebtUpdate]=@DateDebtUpdate, [DateAuction]=@DateAuction, [ExpertID]=@ExpertID WHERE ([ContractID]=" + contractId + ")";
                    cmd.Parameters.AddWithValue("ModifierUserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());
                    cmd.Parameters.AddWithValue("ContractPlan", contractPlan);
                    cmd.Parameters.AddWithValue("BailType", bailType);
                    cmd.Parameters.AddWithValue("BranchID", branchId);
                    cmd.Parameters.AddWithValue("CustomerID", customerId);
                    cmd.Parameters.AddWithValue("CustomerName", customerName);
                    cmd.Parameters.AddWithValue("FileID", fileId);
                    cmd.Parameters.AddWithValue("IndicatorID", Numeral.DBNullForNullValue(indicatorId));
                    cmd.Parameters.AddWithValue("NotaryID", Numeral.DBNullForNullValue(notaryId));
                    cmd.Parameters.AddWithValue("MortgageNo", mortgageNo);
                    cmd.Parameters.AddWithValue("EvaluationAmount1", evaluationAmount1);
                    cmd.Parameters.AddWithValue("EvaluationAmount2", evaluationAmount2);
                    cmd.Parameters.AddWithValue("MandehAsl", mandehAsl);
                    cmd.Parameters.AddWithValue("MandehSood", mandehSood);
                    cmd.Parameters.AddWithValue("MandehJarimeh", mandehJarimeh);
                    cmd.Parameters.AddWithValue("MandehHazineh", mandehHazineh);
                    cmd.Parameters.AddWithValue("MandehAbonman", mandehAbonman);
                    cmd.Parameters.AddWithValue("DateDebtUpdate", dateDebtUpdate);
                    cmd.Parameters.AddWithValue("DateAuction", Numeral.DBNullForZeroValue(dateAuction));
                    cmd.Parameters.AddWithValue("ExpertID", expertId);

                    int queryResult = cmd.ExecuteNonQuery();
                    if (queryResult == 1)
                    {
                        cmd.Parameters.Clear();
                        objConn.Close();
                        return contractId.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return string.Empty;
        }

        public static DataSet GetContractById(string contractId)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_LegalFiles.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    DataTable table1 = new DataTable("ContractInfo");
                    table1.Columns.Add("ModifiedDateTime");
                    table1.Columns.Add("BranchName");
                    table1.Columns.Add("ExpertName");
                    table1.Columns.Add("AgentName");
                
                    DataTable table2 = new DataTable("LinkedContracts");
                    table2.Columns.Add("LevelName");
               
                    DataTable table3 = new DataTable("LinkedPlaques");
                
                    cmd.CommandText = string.Format("SELECT * FROM [LegalFiles] WHERE ([ContractID]={0})", contractId);
                    var dataReader = cmd.ExecuteReader();
                    table1.Load(dataReader);

                    if (table1.Rows.Count == 1)
                    {
                        string fileId = table1.Rows[0]["FileID"].ToString();

                        cmd.CommandText = string.Format("SELECT * FROM [LegalFiles] WHERE ([FileID]='{0}')", fileId);
                        dataReader = cmd.ExecuteReader();
                        table2.Load(dataReader);

                        cmd.CommandText = string.Format("SELECT * FROM [Plaques] WHERE ([FileID]='{0}')", fileId);
                        dataReader = cmd.ExecuteReader();
                        table3.Load(dataReader);
                    }

                    objConn.Close();

                    if (table1.Rows.Count > 0)
                    {
                        table1 = table1.AsEnumerable().OrderByDescending(x => x["ModifiedDate"]).ThenByDescending(x => x["ModifiedTime"]).CopyToDataTable();
                        table1.TableName = "ContractInfo";

                        for (int i = 0; i < table1.Rows.Count; i++)
                        {
                            DataRow row = table1.Rows[i];
                            int modifiedDate = int.Parse(row["ModifiedDate"].ToString());
                            if (Network.GetNowDateSerial() == modifiedDate)
                                row["ModifiedDateTime"] = "امروز - " + row["ModifiedTime"].ToString();
                            else if (Network.GetNowPersianDate().AddDays(-1).ToSerial() == modifiedDate)
                                row["ModifiedDateTime"] = "دیروز - " + row["ModifiedTime"].ToString();
                            else
                                row["ModifiedDateTime"] = PersianDate.Parse(modifiedDate).ToStandard() + " - " + row["ModifiedTime"].ToString();

                            row["ExpertName"] = Users.GetUserNameById(Numeral.AnyToInt32(row["ExpertID"]));
                            row["AgentName"] = Users.GetUserNameById(Numeral.AnyToInt32(row["AgentID"]));
                            Branches.BranchInfo br = Branches.GetBranchById(row["BranchID"].ToString(), true);
                            row["BranchID"] = br.BranchId;
                            row["BranchName"] = br.BranchName;
                        }
                    }

                    for (int i = 0; i < table2.Rows.Count; i++)
                    {
                        table2.Rows[i]["LevelName"] = LegalFileLevels.GetLevelNameByID(int.Parse(table2.Rows[i]["LevelID"].ToString()));
                    }

                    DataSet ds = new DataSet();
                    ds.Tables.Add(table1);
                    ds.Tables.Add(table2);
                    ds.Tables.Add(table3);

                    return ds;
                }
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetLinkedPlaques(string fileId)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_LegalFiles.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;

                    DataTable table = new DataTable();
                    cmd.CommandText = string.Format("SELECT * FROM [Plaques] WHERE ([FileID]='{0}')", fileId);
                    var dataReader = cmd.ExecuteReader();
                    table.Load(dataReader);

                    objConn.Close();

                    return table;
                }
            }
            catch
            {
                return null;
            }
        }

        public static void UpdatePlaques(DataTable dt)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_LegalFiles.mdb")))
                {
                    objConn.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Plaques", objConn);
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

        public static string UpdateLevelId(long contractId, int levelId, int dateLevel)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_LegalFiles.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = "UPDATE [LegalFiles] SET [ModifierUserID]=@ModifierUserID, [ModifiedDate]=@ModifiedDate, [ModifiedTime]=@ModifiedTime, [LevelID]=@LevelID, [DateLevel]=@DateLevel, [FileStatus]=@FileStatus WHERE ([ContractID]=" + contractId + ")";
                    cmd.Parameters.AddWithValue("ModifierUserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());
                    cmd.Parameters.AddWithValue("LevelID", levelId);
                    cmd.Parameters.AddWithValue("DateLevel", dateLevel);
                    cmd.Parameters.AddWithValue("FileStatus", LegalFileStatus.Action);

                    int queryResult = cmd.ExecuteNonQuery();
                    if (queryResult == 1)
                    {
                        cmd.Parameters.Clear();
                        objConn.Close();
                        return contractId.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return string.Empty;
        }

        public static bool UpdateDateLastAction(string[] contracts)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_LegalFiles.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                 
                    foreach (var contractId in contracts)
                    {
                        cmd.CommandText = "UPDATE [LegalFiles] SET [ModifierUserID]=@ModifierUserID, [ModifiedDate]=@ModifiedDate, [ModifiedTime]=@ModifiedTime, [DateLastAction]=@DateLastAction WHERE ([ContractID]=" + contractId + ")";
                        cmd.Parameters.AddWithValue("ModifierUserID", Users.MyUserID);
                        cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                        cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());
                        cmd.Parameters.AddWithValue("DateLastAction", Network.GetNowDateSerial());

                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }

                    objConn.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool UpdateFileStatus(string[] contracts, string status)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_LegalFiles.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    foreach (string contractId in contracts)
                    {
                        cmd.CommandText = string.Format("UPDATE [LegalFiles] SET [ModifierUserID]=@ModifierUserID, [ModifiedDate]=@ModifiedDate, [ModifiedTime]=@ModifiedTime, [FileStatus]=@FileStatus WHERE ([ContractID]={0})", contractId);
                        cmd.Parameters.AddWithValue("ModifierUserID", Users.MyUserID);
                        cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                        cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());
                        cmd.Parameters.AddWithValue("FileStatus", status);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    objConn.Close();

                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string UpdateExpertId(long contractId, int newExpertId)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_LegalFiles.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = "UPDATE [LegalFiles] SET [ModifierUserID]=@ModifierUserID, [ModifiedDate]=@ModifiedDate, [ModifiedTime]=@ModifiedTime, [ExpertID]=@ExpertID, [ReferralDateTimeToExpert]=@ReferralDateTimeToExpert WHERE ([ContractID]=" + contractId + ")";
                    cmd.Parameters.AddWithValue("ModifierUserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());
                    cmd.Parameters.AddWithValue("ExpertID", newExpertId);
                    cmd.Parameters.AddWithValue("ReferralDateTimeToExpert", Network.GetNowDateTimeString());
                    int queryResult = cmd.ExecuteNonQuery();
                    if (queryResult == 1)
                    {
                        cmd.Parameters.Clear();
                        objConn.Close();
                        return contractId.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return string.Empty;
        }

        public static string UpdateAgentId(long contractId, int newAgentId)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_LegalFiles.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = "UPDATE [LegalFiles] SET [ModifierUserID]=@ModifierUserID, [ModifiedDate]=@ModifiedDate, [ModifiedTime]=@ModifiedTime, [AgentID]=@AgentID, [ReferralDateTimeToAgent]=@ReferralDateTimeToAgent WHERE ([ContractID]=" + contractId + ")";
                    cmd.Parameters.AddWithValue("ModifierUserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());
                    cmd.Parameters.AddWithValue("AgentID", newAgentId);
                    cmd.Parameters.AddWithValue("ReferralDateTimeToAgent", Network.GetNowDateTimeString());
                    int queryResult = cmd.ExecuteNonQuery();
                    if (queryResult == 1)
                    {
                        cmd.Parameters.Clear();
                        objConn.Close();
                        return contractId.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return string.Empty;
        }

        public static DataTable GetLegalFilesByFileStatus(string userId, int index)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_LegalFiles.mdb")))
                {
                    objConn.Open();
                    DataTable table = new DataTable();
                    table.Columns.Add("ModifiedDateTime");
                    table.Columns.Add("ReferralDateTime");
                    table.Columns.Add("BranchName");
                    table.Columns.Add("LevelName");
                    table.Columns.Add("ExpertName");
                    table.Columns.Add("AgentName");
                    table.Columns.Add("ColorName");

                    string commandText = "";

                    if (userId == "*")
                    {
                        if (index == 0)
                            commandText = string.Format("SELECT * FROM [LegalFiles] WHERE ([FileStatus] <> '{0}' AND [FileStatus] <> '{1}')", LegalFileStatus.Closed, LegalFileStatus.Stoped);
                        if (index == 1)
                            commandText = string.Format("SELECT * FROM [LegalFiles] WHERE ([FileStatus] = '{0}') OR ([FileStatus] = '{1}')", LegalFileStatus.Closed, LegalFileStatus.Stoped);
                    }
                    else
                    {
                        if (index == 0)
                            commandText = string.Format("SELECT * FROM [LegalFiles] WHERE ([ExpertID]={0} OR [AgentID]={0}) AND ([FileStatus] <> '{1}' AND [FileStatus] <> '{2}')", userId, LegalFileStatus.Closed, LegalFileStatus.Stoped);
                        if (index == 1)
                            commandText = string.Format("SELECT * FROM [LegalFiles] WHERE ([ExpertID]={0} OR [AgentID]={0}) AND ([FileStatus] = '{1}' OR [FileStatus] = '{2}')", userId, LegalFileStatus.Closed, LegalFileStatus.Stoped);
                    }

                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = commandText;
                    var dataReader = cmd.ExecuteReader();
                    table.Load(dataReader);

                    if (table.Rows.Count > 0)
                    {
                        table = table.AsEnumerable().OrderByDescending(x => x["ModifiedDate"].ToString()).ThenByDescending(x => x["ModifiedDate"].ToString()).CopyToDataTable();

                        foreach (DataRow row in table.Rows)
                        {
                            Branches.BranchInfo br = Branches.GetBranchById(row["BranchID"].ToString(), true);
                            row["ModifiedDateTime"] = PersianDate.Parse(row["ModifiedDate"].ToString()).ToStandard() + " - " + row["ModifiedTime"].ToString();
                            if (row["ExpertID"].ToString() == userId)
                                row["ReferralDateTime"] = row["ReferralDateTimeToExpert"];
                            if (row["AgentID"].ToString() == userId)
                                row["ReferralDateTime"] = row["ReferralDateTimeToAgent"];
                            row["BranchID"] = br.BranchId;
                            row["BranchName"] = br.BranchName;
                            row["LevelName"] = LegalFileLevels.GetLevelNameByID(int.Parse(row["LevelID"].ToString()));
                            row["ExpertName"] = Users.GetUserNameById(Numeral.AnyToInt32(row["ExpertID"]));
                            row["AgentName"] = Users.GetUserNameById(Numeral.AnyToInt32(row["AgentID"]));
                            row["ColorName"] = GetRowColorName(row);
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

        public static DataTable GetLegalExpertsPerformance(int dateFrom, int dateTo, string filter)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_LegalFiles.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    DataTable table = new DataTable();
                    cmd.CommandText = string.Format("SELECT * FROM [LegalFiles] WHERE ([RegisteredDate] >= {0} AND [RegisteredDate] <= {1})", dateFrom, dateTo);
                    var dataReader = cmd.ExecuteReader();
                    table.Load(dataReader);
                    table.Columns.Add(new DataColumn { ColumnName = "ColorName", DataType = typeof(string) });
                    objConn.Close();

                    foreach (DataRow row in table.Rows)
                    {
                        row["ColorName"] = GetRowColorName(row);
                    }
                    if (filter == "اقدام شده")
                    {
                        var tbl = table.AsEnumerable().Where(x => x["FileStatus"].ToString() == LegalFileStatus.Action);
                        if (tbl.Count() > 0)
                            table = tbl.CopyToDataTable();
                        else
                            table.Rows.Clear();
                    }
                    if (filter == "درحال بررسی")
                    {
                        var tbl = table.AsEnumerable().Where(x => x["FileStatus"].ToString() == LegalFileStatus.Review);
                        if (tbl.Count() > 0)
                            table = tbl.CopyToDataTable();
                        else
                            table.Rows.Clear();
                    }
                    if (filter == "متوقف شده")
                    {
                        var tbl = table.AsEnumerable().Where(x => x["FileStatus"].ToString() == LegalFileStatus.Stoped);
                        if (tbl.Count() > 0)
                            table = tbl.CopyToDataTable();
                        else
                            table.Rows.Clear();
                    }
                    if (filter == "عودت شده")
                    {
                        var tbl = table.AsEnumerable().Where(x => x["FileStatus"].ToString() == LegalFileStatus.Reject);
                        if (tbl.Count() > 0)
                            table = tbl.CopyToDataTable();
                        else
                            table.Rows.Clear();
                    }
                    if (filter == "کل پرونده ها")
                    {
                    }
                    if (filter == "پرونده های زرد")
                    {
                        var tbl = table.AsEnumerable().Where(x => x["ColorName"].ToString() == "زرد");
                        if (tbl.Count() > 0)
                            table = tbl.CopyToDataTable();
                        else 
                            table.Rows.Clear();
                    }
                    if (filter == "پرونده های قرمز")
                    {
                        var tbl = table.AsEnumerable().Where(x => x["ColorName"].ToString() == "قرمز");
                        if (tbl.Count() > 0)
                            table = tbl.CopyToDataTable();
                        else
                            table.Rows.Clear();
                    }

                    var groupBy = table.AsEnumerable().GroupBy(dr => new { LevelID = dr["LevelID"].ToString(), ExpertID = dr["ExpertID"].ToString() })
                        .Select(g => new
                        {
                            ExpertID = g.Key.ExpertID,
                            LevelID = g.Key.LevelID,
                            SubCount = g.Count(),
                        });


                    DataTable newDataTable = new DataTable();
                    newDataTable.Columns.Add(new DataColumn("ExpertID", typeof(int)));
                    newDataTable.Columns.Add(new DataColumn("ExpertName", typeof(string)));
                    DataRow subRow = newDataTable.NewRow();
                    subRow["ExpertName"] = "جمع کل";

                    foreach (var items in groupBy.GroupBy(x => x.LevelID))
                    {
                        DataColumn col = new DataColumn("Level" + items.Key, typeof(int));
                        newDataTable.Columns.Add(col);

                        foreach (var item in items)
                        {
                          DataRow expertRow =  newDataTable.AsEnumerable().Where(x => x["ExpertID"].ToString() == item.ExpertID).FirstOrDefault();
                          if (expertRow == null)
                          {
                              DataRow newRow = newDataTable.NewRow();
                              newRow["ExpertID"] = item.ExpertID;
                              newRow["ExpertName"] = Users.GetUserNameById(Numeral.AnyToInt32(item.ExpertID));
                              newRow[col] = item.SubCount;
                              newDataTable.Rows.Add(newRow);
                          }
                          else 
                          {
                              expertRow[col] = item.SubCount;
                          }
                        }

                        subRow[col] = items.Sum(x => Numeral.AnyToDouble(x.SubCount));
                    }

                    newDataTable.Rows.Add(subRow);
                    newDataTable.Columns.Add(new DataColumn("Total", typeof(int)));

                    foreach (DataRow row in newDataTable.Rows)
                    {
                        double total = 0;
                        foreach (DataColumn col in newDataTable.Columns)
                        {
                            if (col.ColumnName.StartsWith("Level"))
                                total += Numeral.AnyToDouble(row[col]);
                        }

                        row["Total"] = total;
                    }

                    return newDataTable;
                }
            }
            catch
            {
                return null;
            }
        }

        public static Color GetRowColor(DataRow row)
        {
            Color color = Color.Empty;
            if (row != null && (row["ContractPlan"].ToString() != "جاری" & row["FileStatus"].ToString() == LegalFileStatus.Action))
            {
                int levelId = int.Parse(row["LevelID"].ToString());
                int dateAction = 0;
                int dateLevel = Numeral.AnyToInt32(row["DateLevel"].ToString());
                int dateLastAction = Numeral.AnyToInt32(row["DateLastAction"].ToString());

                if (dateLastAction > dateLevel)
                    dateAction = dateLastAction;
                if (dateLevel > dateLastAction)
                    dateAction = dateLevel;

                if (PersianDateTime.IsValidDate(dateAction.ToString()))
                {
                    int maxDays = LegalFileLevels.GetLevelMaxDays(levelId);
                    int now = Network.GetNowDateSerial();
                    if (now > PersianDateTime.Parse(dateAction).AddDays(maxDays).ToShortDateInt())
                    {
                        color = Color.LightYellow;
                    }
                    if (now > PersianDateTime.Parse(dateAction).AddDays(maxDays + 7).ToShortDateInt())
                    {
                        color = Color.LightPink;
                    }
                }
            }
            return color;
        }

        public static string GetRowColorName(DataRow row)
        {
            string colorName = string.Empty;
            if (row != null && (row["ContractPlan"].ToString() != "جاری" & row["FileStatus"].ToString() == LegalFileStatus.Action))
            {
                int levelId = int.Parse(row["LevelID"].ToString());
                int dateAction = 0;
                int dateLevel = Numeral.AnyToInt32(row["DateLevel"].ToString());
                int dateLastAction = Numeral.AnyToInt32(row["DateLastAction"].ToString());

                if (dateLastAction > dateLevel)
                    dateAction = dateLastAction;
                if (dateLevel > dateLastAction)
                    dateAction = dateLevel;

                if (PersianDateTime.IsValidDate(dateAction.ToString()))
                {
                    int maxDays = LegalFileLevels.GetLevelMaxDays(levelId);
                    int now = Network.GetNowDateSerial();
                    if (now > PersianDateTime.Parse(dateAction).AddDays(maxDays).ToShortDateInt())
                    {
                        colorName = "زرد";
                    }
                    if (now > PersianDateTime.Parse(dateAction).AddDays(maxDays + 7).ToShortDateInt())
                    {
                        colorName = "قرمز";
                    }
                }
            }
            return colorName;
        }

    }
}
