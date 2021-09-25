using GAM.Connections;
using GAM.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GAM.Forms.Settings.Library
{
    class SourceReportsManager
    {
        private static DataTable SourceTable { set; get; }
        private static DataTable ReportsTable { set; get; }

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
                    objCmd.CommandText = "SELECT * FROM [SourceReports] ORDER BY [SourceID]";
                    var dataReader = objCmd.ExecuteReader();
                    DataTable tableSourceReports = new DataTable();
                    tableSourceReports.Load(dataReader);
                   
                    DataTable tableReports = new DataTable();
                    objCmd.CommandText = "SELECT * FROM [Reports] ORDER BY [SourceID]";
                    dataReader = objCmd.ExecuteReader();
                    tableReports.Load(dataReader);
                    objConn.Close();

                    SourceTable = tableSourceReports;
                    SourceTable.Columns.Add("XmlMap");
                    SourceTable.Columns.Add("StartupMessage");
                    foreach (DataRow r in SourceTable.Rows)
                    {
                       r["XmlMap"] = LoadMap(int.Parse(r["SourceID"].ToString()));
                    }
                    ReportsTable = tableReports;
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string[] GetSourceTables(string sourceId)
        {
            string strConnection = OLEDB.GetDatabase((string.Format("DB_{0}.mdb", sourceId)));
            OleDbConnection objConn = new OleDbConnection(strConnection);
            objConn.Open();
            OleDbCommand objCmd = new OleDbCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.Text;
            string[] names = objConn.GetSchema("Tables").AsEnumerable().Where(x => Numeral.IsNumber(x["TABLE_NAME"].ToString()) & x["TABLE_TYPE"].ToString() == "TABLE" & !x["TABLE_NAME"].ToString().StartsWith("~")).Select(r => r["TABLE_NAME"].ToString()).ToArray();
            objConn.Close();
            return names;
        }

        public static void DeleteSourceTable(string sourceId, string[] tables) 
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase(string.Format("DB_{0}.mdb", sourceId))))
                {
                    objConn.Open();
                    foreach (var table in tables)
                    {
                        OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                        cmd.Connection = objConn;
                        cmd.CommandText = string.Format("DROP TABLE [{0}]", table);
                        cmd.ExecuteNonQuery();
                    }
                    objConn.Close();
                }
            }
            catch
            {
                throw;
            }
        }

        public static bool DeleteRowByID(string sourceId, string tableName, string id)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase(string.Format("DB_{0}.mdb", sourceId))))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = string.Format("DELETE FROM [{0}] WHERE ([ID]={1})", tableName, id);
                    int queryResult = cmd.ExecuteNonQuery();
                    objConn.Close();
                    if (queryResult == 1)
                        return true;
                }
            }
            catch
            {
                throw;
            }
            return false;
        }

        public static bool UpdateSourceId(string referenceName, int sourceId, string sourceName)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = string.Format("UPDATE [SourceReports] SET [ReferenceName]=@ReferenceName, [SourceName]=@SourceName WHERE ([SourceID]={0})", sourceId);
                    cmd.Parameters.AddWithValue("ReferenceName", referenceName);
                    cmd.Parameters.AddWithValue("SourceName", sourceName);

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

        public static string LoadMap(int sourceId)
        {
            try
            {
                string file = string.Format(@"{0}\{1}.xml", OLEDB.GetResourcesRoot(), sourceId);
                if (System.IO.File.Exists(file))
                    return System.IO.File.ReadAllText(file, Encoding.UTF8);
                else
                    return string.Empty;
            }
            catch
            {
                throw new Exception("Map خطا در بارگذاری اطلاعات فایل");
            }
        }

        public static void SaveMap(int sourceId, string sb)
        {
            try
            {
                string file = string.Format(@"{0}\{1}.xml", OLEDB.GetResourcesRoot(), sourceId);
                if (System.IO.File.Exists(file))
                    System.IO.File.WriteAllText(file, sb.ToString(), Encoding.UTF8);
                else
                {
                    System.IO.File.CreateText(file);
                    System.IO.File.WriteAllText(file, sb.ToString(), Encoding.UTF8);
                }
            }
            catch
            {
                throw new Exception("Map خطا در ذخیره اطلاعات فایل");
            }
        }

        public static bool InsertSource(string referenceName, int sourceId, string reportName)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = "INSERT INTO [SourceReports] ([ReferenceName], [SourceID], [SourceName]) VALUES (@ReferenceName, @SourceID, @SourceName)";
                    cmd.Parameters.AddWithValue("ReferenceName", referenceName);
                    cmd.Parameters.AddWithValue("SourceID", sourceId);
                    cmd.Parameters.AddWithValue("SourceName", reportName);

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

        public static DataRow GetRequestInfoByID(string id) 
        {
            DataRow row = SourceTable.AsEnumerable().Where(x => x["SourceID"].ToString() == id).FirstOrDefault();
            return row;
        }

        public static bool IsValidReportID(int sourceId)
        {
            DataRow row = SourceTable.AsEnumerable().Where(x => x["SourceID"].ToString() == sourceId.ToString()).FirstOrDefault();
            if (row != null)
                return true;

            return false;
        }

        public static DataTable GetAllRequestsInfo()
        {
            if (SourceTable.Rows.Count > 0)
                return SourceTable.AsEnumerable().OrderBy(x => x["SourceID"].ToString()).CopyToDataTable();
            else
                return null;
        }

        public static string GetLastRegisteredDate(string sourceId)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase(string.Format("DB_{0}.mdb", sourceId))))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    DataTable _tables = new DataTable();
                    _tables = objConn.GetSchema("Tables");
                    string lastTableName = _tables.AsEnumerable().Where(x => x["TABLE_TYPE"].ToString() == "TABLE").Select(r => r["TABLE_NAME"].ToString()).LastOrDefault();
                    if (lastTableName != null)
                    {
                        return lastTableName;
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
            return string.Empty;
        }

        public static DataRow UnknownFileDetection(DataTable reportTable)
        {
            if (reportTable.Rows.Count > 0)
            {
                for (int i = 0; i < SourceTable.Rows.Count; i++)
                {
                    DataRow row = SourceTable.Rows[i];
                    string map = row["XmlMap"].ToString();
                    XmlDocument xmap = new XmlDocument();
                    if (map.Length > 0)
                        xmap.LoadXml(map);
                    else
                        continue;

                    row["StartupMessage"] = xmap.SelectSingleNode("Map/Parameters/StartupMessage").InnerText;
                    int columnsCount = int.Parse(xmap.SelectSingleNode("Map/Parameters/ColumnsCount").InnerText);
                    List<bool> bools = new List<bool>();

                    if (reportTable.Columns.Count == columnsCount)
                    {
                        string xtitle = xmap.SelectSingleNode("Map/Parameters/ReportTitle").InnerText;
                        if (xtitle.Length > 0)
                        {
                            Point point = UDF.StringToPoint(xmap.SelectSingleNode("Map/Parameters/ReportTitleLocation").InnerText);
                            if (point != Point.Empty)
                            {
                                string title = reportTable.Rows[point.Y][point.X].ToString();
                                if (title.Contains(xtitle))
                                    bools.Add(true);
                                else
                                    bools.Add(false);
                            }
                        }
                        if (!bools.Contains(false))
                        {
                            foreach (XmlNode cols in xmap.SelectNodes("Map/BaseColumns"))
                            {
                                foreach (XmlNode col in cols.ChildNodes)
                                {
                                    string xloc = col.SelectSingleNode("HeaderLocation").InnerText;
                                    string xtext = col.SelectSingleNode("HeaderText").InnerText;
                                    System.Drawing.Point point = UDF.StringToPoint(xloc);
                                    string header = reportTable.Rows[point.Y][point.X].ToString();
                                    if (header.Contains(xtext))
                                        bools.Add(true);
                                    else
                                        bools.Add(false);
                                }
                            }
                        }
                    }

                    if (bools.Count > 0 & !bools.Contains(false))
                    {
                        row["XmlMap"] = map;
                        return row;
                    }
                }

            }

            return null;
        }

        public static DataTable FormattedReportTable(DataTable tableReport, string xmlMap)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xmlMap);
            try
            {
                string xtitle = xdoc.SelectSingleNode("Map/Parameters/ReportTitle").InnerText;
                int xprimaryColumnIndex = int.Parse(xdoc.SelectSingleNode("Map/Parameters/PrimaryColumnIndex").InnerText);
                int xfirstDataRowIndex = int.Parse(xdoc.SelectSingleNode("Map/Parameters/FirstDataRowIndex").InnerText);

                try
                {
                    xtitle = xdoc.SelectSingleNode("Map/Parameters/ReportTitle").InnerText;
                    xprimaryColumnIndex = int.Parse(xdoc.SelectSingleNode("Map/Parameters/PrimaryColumnIndex").InnerText);
                    xfirstDataRowIndex = int.Parse(xdoc.SelectSingleNode("Map/Parameters/FirstDataRowIndex").InnerText);
                }
                catch
                {
                    throw new Exception("اشکال در پارامترهای اصلی گزارش");
                }

                if (xtitle.Length > 0)
                {
                    Point point = UDF.StringToPoint(xdoc.SelectSingleNode("Map/Parameters/ReportTitleLocation").InnerText);

                    string title = tableReport.Rows[point.Y][point.X].ToString();
                    if (!title.Contains(xtitle))
                        throw new Exception("عنوان گزارش شناسایی نشد");
                }

                foreach (XmlNode baseCols in xdoc.SelectNodes("Map/BaseColumns"))
                {
                    foreach (XmlNode col in baseCols.ChildNodes)
                    {
                        string xheader = col.SelectSingleNode("HeaderText").InnerText;
                        Point point = UDF.StringToPoint(col.SelectSingleNode("HeaderLocation").InnerText);
                        string header = tableReport.Rows[point.Y][point.X].ToString();
                        if (!header.Contains(xheader))
                            throw new Exception(string.Format("ستون {0} در گزارش شناسایی نشد", xheader));
                    }
                }

                DataTable tableOutput = new DataTable();
                IDictionary<string, int> listOfBaseColumns = new Dictionary<string, int>();
                foreach (XmlNode cols in xdoc.SelectNodes("Map/BaseColumns"))
                {
                    foreach (XmlNode col in cols.ChildNodes)
                    {
                        string xindex = col.SelectSingleNode("Index").InnerText;
                        string xname = col.SelectSingleNode("Name").InnerText;
                        string xcaption = col.SelectSingleNode("Caption").InnerText;
                        string xtype = col.SelectSingleNode("Type").InnerText;
                        if (xindex.Length > 0 & xname.Length > 0 & xcaption.Length > 0 & xtype.Length > 0)
                        {
                            DataColumn newCol = new DataColumn { ColumnName = xname, Caption = xcaption, DataType = Type.GetType(xtype) };
                            tableOutput.Columns.Add(newCol);
                            listOfBaseColumns.Add(newCol.ColumnName, int.Parse(xindex));
                        }
                        else
                            throw new Exception("پارامترهای ایجاد ستون ناقص می باشد");
                    }
                }
                int warErrCounter = 0;
                int errCounter = 0;

                int counter = -1;
                foreach (DataRow row in tableReport.Rows)
                {
                    ++counter;
                    if (counter >= xfirstDataRowIndex & row[xprimaryColumnIndex].ToString().Trim().Length > 0)
                    {
                        try
                        {
                            DataRow newRow = tableOutput.NewRow();
                            foreach (var col in listOfBaseColumns)
                            {
                                string value = row[col.Value].ToString().Trim();
                                if (value.Length == 0)
                                    ++warErrCounter;

                                if (tableOutput.Columns[col.Key].DataType.FullName == "System.String")
                                {
                                    string text = value.Replace("ي", "ی").Replace("ك", "ک").Trim();
                                    text = System.Text.RegularExpressions.Regex.Replace(text, @"\s+", " ");
                                    newRow[col.Key] = text;
                                }
                                else
                                {
                                    try
                                    {
                                        if (Numeral.IsNumber(row[col.Value]))
                                        {
                                            newRow[col.Key] = Convert.ToDouble(Numeral.ToEnglish(row[col.Value].ToString()));
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }

                            tableOutput.Rows.Add(newRow);
                        }
                        catch (Exception ex)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }
                    else
                    {
                        if (counter >= xfirstDataRowIndex & row[xprimaryColumnIndex].ToString().Trim().Length == 0)
                        {
                            ++errCounter;
                        }
                    }
                }

                foreach (XmlNode cols in xdoc.SelectNodes("Map/CustomColumns"))
                {
                    foreach (XmlNode col in cols.ChildNodes)
                    {
                        string xname = col.SelectSingleNode("Name").InnerText;
                        string xcaption = col.SelectSingleNode("Caption").InnerText;
                        string xtype = col.SelectSingleNode("Type").InnerText;
                        string xextension = col.SelectSingleNode("Extension").InnerText;

                        if (xname.Length > 0 & xcaption.Length > 0 & xtype.Length > 0)
                        {
                            DataColumn newCol = new DataColumn { ColumnName = xname, Caption = xcaption, DataType = Type.GetType(xtype) };
                            newCol.Expression = xextension;
                            tableOutput.Columns.Add(newCol);
                        }
                        else
                            throw new Exception("پارامترهای ایجاد ستون ناقص می باشد");
                    }
                }
                if (warErrCounter > 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(string.Format("تعداد {0} ردیف با مقدار تهی در یک یا چند ستون اطلاعاتی در فایل یافت شد", warErrCounter), "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (errCounter > 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(string.Format("امکان ذخیره سازی {0} ردیف بدلیل تهی بودن مقدار ستون اصلی وجود ندارد", errCounter), "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return tableOutput;
            }
            catch
            {
                throw;
            }
        }

        public static DataTable GetSourceReports()
        {
            return SourceTable;
        }
        
        public static int GetSort(string status)
        {
            if (status == "به زودی")
                return 0;
            if (status == "جدید")
                return 1;
            if (status == "غیرفعال")
                return 2;
            return 10;
        }

        public static DataTable GetReports()
        {
            var rows = ReportsTable.AsEnumerable().Where(x => bool.Parse(x["IsEnable"].ToString())).OrderBy(x => GetSort(x["Status"].ToString())).ThenBy(x => x["Category"].ToString()).ThenBy(x => Numeral.AnyToInt32(x["SortKey"].ToString()));
            if (rows.Count() > 0)
                return rows.CopyToDataTable();
            return null;
        }

        public static DataTable GetReportsBySourceId(int sourceId)
        {
            var rows = ReportsTable.AsEnumerable().Where(x => int.Parse(x["SourceID"].ToString()) == sourceId).OrderBy(x => int.Parse(x["ReportNo"].ToString()));
            if (rows.Count() > 0)
                return rows.CopyToDataTable();
            return null;
        }

        public static DataRow GetReportById(int sourceId, int reportNo)
        {
            var rows = ReportsTable.AsEnumerable().Where(x => int.Parse(x["SourceID"].ToString()) == sourceId & int.Parse(x["ReportNo"].ToString()) == reportNo);
            if (rows.Count() > 0)
                return rows.First();
            return null;
        }

        public static DataRow GetMapBySourceId(int sourceId)
        {
            var rows = SourceTable.AsEnumerable().Where(x => int.Parse(x["SourceID"].ToString()) == sourceId);
            if (rows.Count() == 1)
                return rows.First();
            return null;
        }

        public static IDictionary<string, string> GetColumnsUnitPrice(int sourceId)
        {
            DataRow row = SourceTable.AsEnumerable().Where(x => int.Parse(x["SourceID"].ToString()) == sourceId).First();
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(row["XmlMap"].ToString());
            IDictionary<string, string> columns = new Dictionary<string, string>();
            foreach (XmlNode cols in xdoc.SelectNodes("Map/BaseColumns"))
            {
                foreach (XmlNode col in cols.ChildNodes)
                {
                    string xname = col.SelectSingleNode("Name").InnerText;
                    string xunitPrice = "";
                    if (col.SelectSingleNode("UnitPrice") != null)
                        xunitPrice = col.SelectSingleNode("UnitPrice").InnerText;
                    if (xunitPrice.Length > 0)
                        columns.Add(xname, xunitPrice);
                }
            }
            foreach (XmlNode cols in xdoc.SelectNodes("Map/CustomColumns"))
            {
                foreach (XmlNode col in cols.ChildNodes)
                {
                    string xname = col.SelectSingleNode("Name").InnerText;
                    string xunitPrice = "";
                    if (col.SelectSingleNode("UnitPrice") != null)
                        xunitPrice = col.SelectSingleNode("UnitPrice").InnerText;
                    if (xunitPrice.Length > 0)
                        columns.Add(xname, xunitPrice);
                }
            }

            foreach (XmlNode cols in xdoc.SelectNodes("Map/VirtualColumns"))
            {
                foreach (XmlNode col in cols.ChildNodes)
                {
                    string xname = col.SelectSingleNode("Name").InnerText;
                    string xunitPrice = "";
                    if (col.SelectSingleNode("UnitPrice") != null)
                        xunitPrice = col.SelectSingleNode("UnitPrice").InnerText;
                    if (xunitPrice.Length > 0)
                        columns.Add(xname, xunitPrice);
                }
            }
            
            return columns;
        }
    }
}
