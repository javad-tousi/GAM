using GAM.Connections;
using GAM.Forms.Information.Library;
using GAM.Forms.Settings.Library;
using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Forms.Profile.Kargozini.Library
{
    class PersonelsManager
    {
        public static IDictionary<long, DataRow[]> PersonelsRules = new Dictionary<long, DataRow[]>();
        public static DataTable PersonelsTable = new DataTable();
        public static IDictionary<long, DataRow> AllPersonelsInfo = new Dictionary<long, DataRow>();

        public static string[] GetTablesName(string dbName)
        {
            List<string> tableNames = new List<string>();
            string strConnection = OLEDB.GetDatabase(dbName);
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

        public static bool InsertQuery(long employmentId, string firstName, string lastName, string fatherName, string nationalCode, int birthDate, string bithCityName, bool isFemale, string maritalStatus, int childCount, string academicDegree, string fieldOfStudy, string homeTellNo, string mobailNo, string homeAddress, string employmentType, string personStatus, int dateEmployment, int? dateRetirement)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Personels.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = "INSERT INTO Personels ([RegisteredUserID], [RegisteredDate], [ModifierUserID], [ModifiedDate], [EmploymentId], [FirstName], [LastName], [FatherName], [NationalCode], [BirthDate], [BithCityName], [IsFemale], [MaritalStatus], [ChildCount], [AcademicDegree], [FieldOfStudy], [HomeTellNo], [MobailNo], [HomeAddress], [EmploymentType], [PersonStatus], [DateEmployment], [DateRetirement]) VALUES (@RegisteredUserID, @RegisteredDate, @ModifierUserID, @ModifiedDate, @EmploymentId, @FirstName, @LastName, @FatherName, @NationalCode, @BirthDate, @BithCityName, @IsFemale, @MaritalStatus, @ChildCount, @AcademicDegree, @FieldOfStudy, @HomeTellNo, @MobailNo, @HomeAddress, @EmploymentType, @PersonStatus, @DateEmployment, @DateRetirement)";
                    cmd.Parameters.AddWithValue("RegisteredUserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("RegisteredDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("ModifierUserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("EmploymentId", employmentId);
                    cmd.Parameters.AddWithValue("FirstName", firstName);
                    cmd.Parameters.AddWithValue("LastName", lastName);
                    cmd.Parameters.AddWithValue("FatherName", fatherName);
                    cmd.Parameters.AddWithValue("NationalCode", nationalCode);
                    cmd.Parameters.AddWithValue("BirthDate", birthDate);
                    cmd.Parameters.AddWithValue("BithCityName", bithCityName);
                    cmd.Parameters.AddWithValue("IsFemale", isFemale);
                    cmd.Parameters.AddWithValue("MaritalStatus", maritalStatus);
                    cmd.Parameters.AddWithValue("ChildCount", childCount);
                    cmd.Parameters.AddWithValue("AcademicDegree", academicDegree);
                    cmd.Parameters.AddWithValue("FieldOfStudy", fieldOfStudy);
                    cmd.Parameters.AddWithValue("HomeTellNo", homeTellNo);
                    cmd.Parameters.AddWithValue("MobailNo", mobailNo);
                    cmd.Parameters.AddWithValue("HomeAddress", homeAddress);
                    cmd.Parameters.AddWithValue("EmploymentType", employmentType);
                    cmd.Parameters.AddWithValue("PersonStatus", personStatus);
                    cmd.Parameters.AddWithValue("DateEmployment", dateEmployment);
                    cmd.Parameters.AddWithValue("DateRetirement", Numeral.DBNullForNullValue(dateRetirement));

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

        public static bool InsertRule(long employmentId, string personnelStatus, int ruleDate, string ruleNo, string ruleName, string comment, int branchID, int postId, int jobId)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Personels.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = "INSERT INTO InternalRules ([RegisteredUserID], [RegisteredDate], [EmploymentId], [PersonnelStatus], [RuleDate], [RuleNo], [RuleName], [Comment], [BranchID], [PostID], [JobID]) VALUES (@RegisteredUserID, @RegisteredDate, @EmploymentId, @PersonnelStatus, @RuleDate, @RuleNo, @RuleName, @Comment, @BranchID, @PostID, @JobID)";
                    cmd.Parameters.AddWithValue("RegisteredUserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("RegisteredDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("EmploymentId", employmentId);
                    cmd.Parameters.AddWithValue("PersonnelStatus", personnelStatus);
                    cmd.Parameters.AddWithValue("RuleDate", ruleDate);
                    cmd.Parameters.AddWithValue("RuleNo", ruleNo);
                    cmd.Parameters.AddWithValue("RuleName", ruleName);
                    cmd.Parameters.AddWithValue("Comment", comment);
                    cmd.Parameters.AddWithValue("BranchID", branchID);
                    cmd.Parameters.AddWithValue("PostID", postId);
                    cmd.Parameters.AddWithValue("JobID", jobId);

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

        public static bool UpdateQuery(long employmentId, string firstName, string lastName, string fatherName, string nationalCode, int birthDate, string bithCityName, bool isFemale, string maritalStatus, int childCount, string academicDegree, string fieldOfStudy, string homeTellNo, string mobailNo, string homeAddress, string employmentType, string personStatus, int dateEmployment, int? dateRetirement)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Personels.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = string.Format("UPDATE [Personels] SET [ModifierUserID]=@ModifierUserID, [ModifiedDate]=@ModifiedDate, [FirstName]=@FirstName, [LastName]=@LastName, [FatherName]=@FatherName, [NationalCode]=@NationalCode, [BirthDate]=@BirthDate, [BithCityName]=@BithCityName, [IsFemale]=@IsFemale, [MaritalStatus]=@MaritalStatus, [ChildCount]=@ChildCount, [AcademicDegree]=@AcademicDegree, [FieldOfStudy]=@FieldOfStudy, [HomeTellNo]=@HomeTellNo, [MobailNo]=@MobailNo, [HomeAddress]=@HomeAddress, [EmploymentType]=@EmploymentType, [PersonnelStatus]=@PersonnelStatus, [DateEmployment]=@DateEmployment, [DateRetirement]=@DateRetirement WHERE ([EmploymentID]={0})", employmentId);
                    cmd.Parameters.AddWithValue("ModifierUserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("FirstName", firstName);
                    cmd.Parameters.AddWithValue("LastName", lastName);
                    cmd.Parameters.AddWithValue("FatherName", fatherName);
                    cmd.Parameters.AddWithValue("NationalCode", nationalCode);
                    cmd.Parameters.AddWithValue("BirthDate", birthDate);
                    cmd.Parameters.AddWithValue("BithCityName", bithCityName);
                    cmd.Parameters.AddWithValue("IsFemale", isFemale);
                    cmd.Parameters.AddWithValue("MaritalStatus", maritalStatus);
                    cmd.Parameters.AddWithValue("ChildCount", childCount);
                    cmd.Parameters.AddWithValue("AcademicDegree", academicDegree);
                    cmd.Parameters.AddWithValue("FieldOfStudy", fieldOfStudy);
                    cmd.Parameters.AddWithValue("HomeTellNo", homeTellNo);
                    cmd.Parameters.AddWithValue("MobailNo", mobailNo);
                    cmd.Parameters.AddWithValue("HomeAddress", homeAddress);
                    cmd.Parameters.AddWithValue("EmploymentType", employmentType);
                    cmd.Parameters.AddWithValue("PersonnelStatus", personStatus);
                    cmd.Parameters.AddWithValue("DateEmployment", dateEmployment);
                    cmd.Parameters.AddWithValue("DateRetirement", Numeral.DBNullForNullValue(dateRetirement));

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

        public static bool UpdatePersonnelStatus(long employmentId, string personStatus)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Personels.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = string.Format("UPDATE [Personels] SET [ModifierUserID]=@ModifierUserID, [ModifiedDate]=@ModifiedDate, [PersonnelStatus]=@PersonnelStatus WHERE ([EmploymentID]={0})", employmentId);
                    cmd.Parameters.AddWithValue("ModifierUserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("PersonnelStatus", personStatus);

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

        public static DataRow GetEmployeeById(string id)
        {
            try
            {
                Dictionary<string, object> items = new Dictionary<string, object>();
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Personels.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = "SELECT * FROM [Personels] WHERE ([EmploymentID]=@EmploymentID)";
                    cmd.Parameters.AddWithValue("EmploymentID", id);
                    var dataReader = cmd.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    objConn.Close();
                    if (dataTable.Rows.Count == 1)
                        return dataTable.Rows[0];
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }

        public static DataRow GetFastEmployeeById(string id)
        {
            try
            {
               return AllPersonelsInfo[long.Parse(id)];
            }
            catch
            {
                throw;
            }
        }

        public static string GetFastEmployeeNameById(string id)
        {
            if (AllPersonelsInfo.ContainsKey(long.Parse(id)))
                return AllPersonelsInfo[long.Parse(id)]["FullName"].ToString();
            else
                return "تعریف نشده";
        }

        public static DataRow GetEmployeeInBranchByPostId(int branchId, int postId)
        {
            for (int i = 0; i < PersonelsTable.Rows.Count; i++)
            {
                DataRow r = PersonelsTable.Rows[i];
                if (r["BranchId"].ToString() == branchId.ToString() & r["PostId"].ToString() == postId.ToString())
                {
                    return r;
                }
            }

            return null;
        }

        public static DataTable GetAllRulesByEmploymentId(string employmentId)
        {
            try
            {
                DataTable masterTable = new DataTable();
                masterTable.Columns.Add("BranchId");
                masterTable.Columns.Add("BranchName");
                masterTable.Columns.Add("PostId");
                masterTable.Columns.Add("PostName");
                masterTable.Columns.Add("JobId");
                masterTable.Columns.Add("JobName");
                masterTable.Columns.Add("Score1");
                masterTable.Columns.Add("Score2");

                #region Internal Rules

                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Personels.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = "SELECT [ID], [EmploymentID], [PersonnelStatus], [RuleDate], 'داخلی' As RuleType, [RuleNo], [RuleName], [Comment], [BranchID], [PostID], [JobID] FROM [InternalRules] WHERE ([EmploymentID]=@EmploymentID)";
                    cmd.Parameters.AddWithValue("EmploymentID", employmentId);
                    var dataReader = cmd.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    masterTable.Merge(dataTable);
                    objConn.Close();
                }

                #endregion

                #region Tehran Rules

                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_400.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    foreach (string tblName in PersonelsManager.GetTablesName("DB_400.mdb"))
                    {
                        cmd.CommandText = string.Format("SELECT [EmploymentID], [RuleDate], 'رسمی' As RuleType, [RuleNo], [RuleName], [BranchID], [PostID], [JobID], [Score1], [Score2] FROM [{0}] WHERE ([EmploymentID]=@EmploymentID)", tblName);
                        cmd.Parameters.AddWithValue("EmploymentID", employmentId);
                        var dataReader = cmd.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        foreach (DataRow r in dataTable.Rows)
                        {
                            DataRow newRow = masterTable.NewRow();
                            foreach (DataColumn col in dataTable.Columns)
                            {
                                if (masterTable.Columns.Contains(col.ColumnName))
                                {
                                    if (col.ColumnName == "RuleDate")
                                        newRow[col.ColumnName] = int.Parse(Numeral.ExtractDigits(r["RuleDate"].ToString()));
                                    else
                                        newRow[col.ColumnName] = r[col.ColumnName];
                                }

                            }
                            masterTable.Rows.Add(newRow);
                        }
                    }
                    objConn.Close();
                } 
                #endregion

                if (masterTable.Rows.Count > 0)
                {
                    masterTable = masterTable.AsEnumerable().OrderBy(x => int.Parse(x["RuleDate"].ToString())).ThenBy(x => Numeral.AnyToInt32(x["ID"].ToString())).CopyToDataTable();

                    for (int i = 0; i < masterTable.Rows.Count; i++)
                    {
                        DataRow row = masterTable.Rows[i];
                        row["RuleDate"] = row["RuleDate"].ToString().Replace("/", "");
                        row["BranchId"] = Branches.GetUnitStandardId(row["BranchID"].ToString());
                        row["BranchName"] = Branches.GetUnitNameById(row["BranchID"].ToString());
                        row["PostId"] = row["PostID"].ToString();
                        row["PostName"] = Posts.GetPostNameById(row["PostID"].ToString());
                        row["JobId"] = row["JobID"].ToString();
                        row["JobName"] = Posts.GetJobNameById(row["JobID"].ToString());
                    }
                }

                return masterTable;
            }
            catch
            {
                throw;
            }
        }

        public static DataTable GetChangedPostsHistory(DataRow[] ruleRows, int postId) 
        {
            DataTable table = new DataTable();
            table.Columns.Add("RuleDate", typeof(int));
            table.Columns.Add("DateFrom", typeof(int));
            table.Columns.Add("DateTo", typeof(int));
            table.Columns.Add("PostName1");
            table.Columns.Add("PostName2");
            table.Columns.Add("Days", typeof(int));

            if (ruleRows == null)
                return table;

            DataRow lastRule = null;
            bool allowAddRow = true;

            for (int i = 0; i < ruleRows.Length; i++)
            {
                DataRow nowRule = ruleRows[i];

                if (i > 0)
                {
                    if (nowRule["PostID"].ToString() != lastRule["PostID"].ToString())
                    {
                        if (allowAddRow)
                        {
                            DataRow r = table.NewRow();
                            r["RuleDate"] = nowRule["RuleDate"];
                            r["PostName1"] = lastRule["PostName"];
                            r["PostName2"] = nowRule["PostName"];
                            r["DateFrom"] = lastRule["RuleDate"];
                            r["DateTo"] = nowRule["RuleDate"].ToString();
                            r["Days"] = (PersianDateTime.Parse(int.Parse(nowRule["RuleDate"].ToString())) - PersianDateTime.Parse(int.Parse(lastRule["RuleDate"].ToString()))).Days;
                            table.Rows.Add(r);
                        }

                        lastRule = nowRule;

                        if (postId > 0 && (postId.ToString() == lastRule["PostID"].ToString()))
                            return table;
                    }
                }
                else
                {
                    lastRule = ruleRows[i];
                }
            }

            if (table.Rows.Count > 0)
            {
                DataRow lastrow = table.Rows[table.Rows.Count - 1];
                DataRow r = table.NewRow();
                r["RuleDate"] = lastrow["RuleDate"];
                r["PostName1"] = lastrow["PostName2"];
                r["DateFrom"] = lastrow["RuleDate"];
                r["DateTo"] = PersianDateTime.Now.ToShortDateInt();
                r["Days"] = (PersianDateTime.Now - PersianDateTime.Parse(int.Parse(lastRule["RuleDate"].ToString()))).Days;
                table.Rows.Add(r);
            }

            return table;
        }

        public static DataTable GetChangedBranchesHistory(DataRow[] ruleRows, int branchId)
        {
            DataTable table = new DataTable();
            table.Columns.Add("RuleDate", typeof(int));
            table.Columns.Add("DateFrom", typeof(int));
            table.Columns.Add("DateTo", typeof(int));
            table.Columns.Add("BranchName1");
            table.Columns.Add("BranchName2");
            table.Columns.Add("Days", typeof(int));

            if (ruleRows == null)
                return table;

            DataRow lastRule = null;

            bool allowAddRow = true;

            for (int i = 0; i < ruleRows.Length; i++)
            {
                DataRow nowRule = ruleRows[i];

                if (i > 0)
                {
                    if (nowRule["BranchID"].ToString() != lastRule["BranchID"].ToString())
                    {
                        if (allowAddRow)
                        {
                            DataRow r = table.NewRow();
                            r["RuleDate"] = nowRule["RuleDate"];
                            r["BranchName1"] = lastRule["BranchName"];
                            r["BranchName2"] = nowRule["BranchName"];
                            r["DateFrom"] = lastRule["RuleDate"] ;
                            r["DateTo"] = nowRule["RuleDate"].ToString();
                            r["Days"] = (PersianDateTime.Parse(int.Parse(nowRule["RuleDate"].ToString())) - PersianDateTime.Parse(int.Parse(lastRule["RuleDate"].ToString()))).Days;

                            table.Rows.Add(r);
                        }

                        if (nowRule["RuleType"].ToString() == "داخلی")
                        {
                            if (nowRule["RuleName"].ToString().Contains("انتقال"))
                                allowAddRow = true;
                            if (nowRule["RuleName"].ToString() == "انتقال-قطعی")
                                allowAddRow = false;
                        }

                        lastRule = nowRule;

                        if (branchId > 0 && (branchId.ToString() == lastRule["BranchID"].ToString()))
                            return table;
                    }
                }
                else
                {
                    lastRule = ruleRows[i];
                }
            }

            if (table.Rows.Count > 0)
            {
                DataRow lastrow = table.Rows[table.Rows.Count - 1];
                DataRow r = table.NewRow();
                r["RuleDate"] = lastrow["RuleDate"];
                r["BranchName1"] = lastrow["BranchName2"];
                r["DateFrom"] = lastrow["RuleDate"];
                r["DateTo"] = PersianDateTime.Now.ToShortDateInt();
                r["Days"] = (PersianDateTime.Now - PersianDateTime.Parse(int.Parse(lastrow["RuleDate"].ToString()))).Days;
                table.Rows.Add(r);
            }

            return table;
        }

        public static DataRow GetLastPersonInfo(DataRow[] ruleRows)
        {
            DataTable table = new DataTable();
            table.Columns.Add("BranchId");
            table.Columns.Add("BranchName");
            table.Columns.Add("PostId", typeof(int));
            table.Columns.Add("PostName");
            table.Columns.Add("JobId", typeof(int));
            table.Columns.Add("JobName");
            table.Columns.Add("Score1", typeof(int));
            table.Columns.Add("Score2", typeof(int));

            if (ruleRows == null)
                return null;

            for (int i = 0; i < ruleRows.Length; i++)
            {
                if (i == ruleRows.Length - 1)
                {
                    DataRow rulerow = ruleRows[i];
                    DataRow r = table.NewRow();
                    r["BranchId"] = rulerow["BranchID"].ToString();
                    r["BranchName"] = rulerow["BranchName"].ToString();
                    r["PostId"] = rulerow["PostID"].ToString();
                    r["PostName"] = rulerow["PostName"].ToString();
                    r["JobId"] = rulerow["JobID"].ToString();
                    r["JobName"] = rulerow["JobName"].ToString();
                    table.Rows.Add(r);
                    break;
                }
            }

            foreach (DataRow row in ruleRows)
            {
                if (row["RuleType"].ToString() == "رسمی")
                {
                    if (table.Rows.Count == 1)
                    {
                        table.Rows[0]["Score1"] = row["Score1"].ToString();
                        table.Rows[0]["Score2"] = row["Score2"].ToString();
                        break;
                    }
                }
            }
            if (table.Rows.Count == 1)
            {
                return table.Rows[0];
            }
            return null;
        }


        public static void FillPersonnelsRules()
        {
            try
            {
                PersonelsRules.Clear();
                DataTable masterTable = new DataTable();
                masterTable.Columns.Add("BranchName");
                masterTable.Columns.Add("PostName");
                masterTable.Columns.Add("JobName");
                masterTable.Columns.Add("Score1");
                masterTable.Columns.Add("Score2");

                #region Internal Rules

                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Personels.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = "SELECT [ID], [EmploymentID], [PersonnelStatus], [RuleDate], 'داخلی' As RuleType, [RuleNo], [RuleName], [Comment], [BranchID], [PostID], [JobID] FROM [InternalRules]";
                    var dataReader = cmd.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    masterTable.Merge(dataTable);
                    objConn.Close();
                }
                #endregion

                #region Tehran Rules

                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_400.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    foreach (string tblName in PersonelsManager.GetTablesName("DB_400.mdb"))
                    {
                        cmd.CommandText = string.Format("SELECT [EmploymentID], [RuleDate], 'رسمی' As RuleType, [RuleNo], [RuleName], [BranchID], [PostID], [JobID], [Score1], [Score2] FROM [{0}]", tblName);
                        var dataReader = cmd.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        foreach (DataRow r in dataTable.Rows)
                        {
                            DataRow newRow = masterTable.NewRow();
                            foreach (DataColumn col in dataTable.Columns)
                            {
                                if (masterTable.Columns.Contains(col.ColumnName))
                                {
                                    if (col.ColumnName == "RuleDate")
                                        newRow[col.ColumnName] = int.Parse(Numeral.ExtractDigits(r["RuleDate"].ToString()));
                                    else
                                        newRow[col.ColumnName] = r[col.ColumnName];
                                }

                            }
                            masterTable.Rows.Add(newRow);
                        }
                    }
                    objConn.Close();
                }
                #endregion

                foreach (DataRow r in masterTable.Rows)
                {
                    r["BranchID"] = Branches.GetUnitStandardId(r["BranchID"].ToString());
                    r["BranchName"] = Branches.GetUnitNameById(r["BranchID"].ToString());
                    r["PostName"] = Posts.GetPostNameById(r["PostID"].ToString());
                    r["JobName"] = Posts.GetJobNameById(r["JobID"].ToString());
                }

                if (masterTable.Rows.Count > 0)
                {
                    masterTable = masterTable.AsEnumerable().OrderBy(x => long.Parse(x["EmploymentID"].ToString())).ThenBy(x => int.Parse(x["RuleDate"].ToString())).ThenBy(x => Numeral.AnyToInt32(x["ID"].ToString())).CopyToDataTable();

                    var groupBy = masterTable.AsEnumerable().GroupBy(x => long.Parse(x["EmploymentID"].ToString()))
                                                            .Select(g => new
                                                            {
                                                                EmploymentID = g.Key,
                                                                Rules = g,
                                                            });

                    foreach (var g in groupBy)
                    {
                        PersonelsRules.Add(g.EmploymentID, g.Rules.ToArray());
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public static void Fill()
        {
            try
            {
                PersonelsManager.FillPersonnelsRules();
                PersonelsManager.PersonelsTable.Rows.Clear();
                PersonelsManager.AllPersonelsInfo.Clear();
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Personels.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = "SELECT [FirstName] & ' ' & [LastName] As FullName, * FROM [Personels]";
                    var dataReader = cmd.ExecuteReader();
                    PersonelsTable = new DataTable();
                    PersonelsTable.Load(dataReader);
                    objConn.Close();
                    PersonelsTable.Columns.Add("Age");
                    PersonelsTable.Columns.Add("BranchId", typeof(int));
                    PersonelsTable.Columns.Add("BranchName");
                    PersonelsTable.Columns.Add("PostId", typeof(int));
                    PersonelsTable.Columns.Add("PostName");
                    PersonelsTable.Columns.Add("JobId", typeof(int));
                    PersonelsTable.Columns.Add("JobName");
                    PersonelsTable.Columns.Add("Score1");
                    PersonelsTable.Columns.Add("Score2");
                    PersonelsTable.Columns.Add("DaysFromDateEmployment");
                    PersonelsTable.Columns.Add("DaysLeftOfRetirement");
                    PersonelsTable.Columns.Add("DateNewPost", typeof(int));
                    PersonelsTable.Columns.Add("DaysFromNewPost", typeof(int));
                    PersonelsTable.Columns.Add("DateNewBranch", typeof(int));
                    PersonelsTable.Columns.Add("DaysFromNewBranch", typeof(int));

                    foreach (DataRow r in PersonelsTable.Rows)
                    {
                        int birthDate = Numeral.AnyToInt32(r["BirthDate"].ToString());
                        int dateStart = Numeral.AnyToInt32(r["DateEmployment"].ToString());
                        int dateEnd = Numeral.AnyToInt32(r["DateRetirement"].ToString());
                        if (birthDate > 0)
                            r["Age"] = ((PersianDateTime.Now - PersianDateTime.Parse(birthDate)).Days / 365).ToString("N1");
                        if (dateStart > 0)
                            r["DaysFromDateEmployment"] = (PersianDateTime.Now - PersianDateTime.Parse(dateStart)).Days.ToString();
                        if (dateStart > 0 & dateEnd > 0)
                        {
                            int leftDays = (PersianDateTime.Parse(dateEnd) - PersianDateTime.Now).Days;
                            if (leftDays >= 0)
                                r["DaysLeftOfRetirement"] = leftDays.ToString();
                            else
                                r["DaysLeftOfRetirement"] = 0;
                        }
                        AllPersonelsInfo.Add(long.Parse(r["EmploymentID"].ToString()), r);
                    }

                    foreach (DataRow row in PersonelsManager.PersonelsTable.Rows)
                    {
                        if (row["PersonnelStatus"].ToString() == "شاغل" && PersonelsManager.PersonelsRules.ContainsKey(long.Parse(row["EmploymentID"].ToString())))
                        {
                            DataRow[] ruleRows = PersonelsManager.PersonelsRules[long.Parse(row["EmploymentID"].ToString())];
                            DataTable table1 = PersonelsManager.GetChangedPostsHistory(ruleRows, 0);
                            if (table1.Rows.Count > 0)
                            {
                                int id = table1.Rows.Count - 1;
                                row["DateNewPost"] = table1.Rows[id]["RuleDate"];
                                row["DaysFromNewPost"] = table1.Rows[id]["Days"];
                            }

                            DataTable table2 = PersonelsManager.GetChangedBranchesHistory(ruleRows, 0);
                            if (table2.Rows.Count > 0)
                            {
                                int id = table2.Rows.Count - 1;
                                row["DateNewBranch"] = table2.Rows[id]["RuleDate"];
                                row["DaysFromNewBranch"] = table2.Rows[table2.Rows.Count - 1]["Days"];
                            }

                            DataRow infoRow = PersonelsManager.GetLastPersonInfo(ruleRows);
                            if (infoRow != null)
                            {
                                row["BranchId"] = infoRow["BranchId"];
                                row["BranchName"] = infoRow["BranchName"];
                                row["PostId"] = infoRow["PostId"];
                                row["PostName"] = infoRow["PostName"];
                                row["JobId"] = infoRow["JobId"];
                                row["JobName"] = infoRow["JobName"];
                                row["Score1"] = infoRow["Score1"];
                                row["Score2"] = infoRow["Score2"];
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public static bool DeleteEmployeeById(string id)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Personels.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = string.Format("DELETE FROM [Personels] WHERE ([EmploymentID]={0})", id);
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

    }
}
