using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using GAM.Forms.Settings.Library;
using GAM.Connections;
using GAM.Forms.Information.Library;
using System.Xml;
using DevExpress.XtraGrid.Views.BandedGrid;
using GAM.Modules;
using System.Collections;
using GAM.Forms.Reports.Library;
using DevExpress.XtraCharts;

namespace GAM.Forms.Reports.Queries
{
    class QueryManager
    {
        public static string[] GetAccessTables(string mdbName)
        {
            List<string> tableNames = new List<string>();
            string strConnection = OLEDB.GetDatabase(mdbName);
            System.Data.OleDb.OleDbConnection objConn = new System.Data.OleDb.OleDbConnection(strConnection);
            objConn.Open();
            System.Data.OleDb.OleDbCommand objCmd = new System.Data.OleDb.OleDbCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = System.Data.CommandType.Text;
            string[] names = objConn.GetSchema("Tables").AsEnumerable().Where(x => x["TABLE_TYPE"].ToString() == "TABLE").Select(r => r["TABLE_NAME"].ToString()).ToArray();
            objConn.Close();

            foreach (string name in names)
            {
                if (Numeral.IsNumber(name))
                    tableNames.Add(name);
            }

            return tableNames.OrderByDescending(x => x).ToArray();
        }

        public static DataSet QueryBuilder(QueryProperties properties, params string[] args)
        {
            try
            {
                #region Connect to Database
                string[] dates = null;
                if (properties["SelectedDates"].ToString().Length == 0)
                    dates = new string[] { GetAccessTables(string.Format("DB_{0}.mdb", properties["SourceID"])).First() };
                else
                    dates = properties["SelectedDates"].ToString().Split(',');

                OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase(string.Format("DB_{0}.mdb", properties["SourceID"])));
                objConn.Open();

                DataTable tblMaster = new DataTable(dates.Last());
                DataSet ds = new DataSet();
                IDictionary<string, string> columnsUnitPrice = SourceReportsManager.GetColumnsUnitPrice(int.Parse(properties["SourceID"].ToString()));
                List<ISeries.DataPoint> seriesPoints = new List<ISeries.DataPoint>();

                foreach (string date in dates)
                {
                    List<string> paramsList = new List<string>();
                    paramsList.Add(date);
                    paramsList.AddRange(args);

                    OleDbCommand objCmd = new OleDbCommand();
                    objCmd.Connection = objConn;
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = string.Format(properties["SelectQuery"].ToString(), paramsList.ToArray());
                    var dataReader = objCmd.ExecuteReader();
                    tblMaster.Load(dataReader);
                }
                objConn.Close();
                #endregion

                #region Change UnitPrice

                foreach (System.Data.DataColumn col in tblMaster.Columns) col.ReadOnly = false;
                foreach (DataRow row in tblMaster.Rows)
                {
                    foreach (DataColumn col in tblMaster.Columns)
                    {
                        if (columnsUnitPrice.ContainsKey(col.ColumnName))
                        {
                            string unit = columnsUnitPrice[col.ColumnName];
                            row[col] = Numeral.AnyToDouble(row[col], Numeral.StringToIUnitPrice(unit), Numeral.IUnitPrice.Rial);
                            row[col] = Numeral.AnyToDouble(row[col], Numeral.IUnitPrice.Rial, Numeral.StringToIUnitPrice(properties["UnitAmount"].ToString()));
                        }
                    }
                }
                #endregion

                #region Update BranchId

                bool updateBranch = bool.Parse(properties["UpdateMergedBranches"].ToString());
                if (tblMaster.Columns.Contains("BranchID"))
                {
                    for (int i = 0; i < tblMaster.Rows.Count; i++)
                    {
                        DataRow r = tblMaster.Rows[i];
                        string id = r["BranchId"].ToString();
                        if (Branches.IsBranch(id))
                            r["BranchId"] = Branches.GetBranchById(id, updateBranch).BranchId;
                        else if (Branches.IsDomain(id))
                            r["BranchId"] = Branches.GetDomainById(id, updateBranch).DomainId;
                        else if (Branches.IsProvince(id))
                            r["BranchId"] = Branches.GetProvinceById(id).ProvinceId;
                    }
                }
                #endregion

                #region Modules

                switch (properties.GetStrProperty("ModuleName"))
                {
                    case "Module_01":
                        return Module_01.Fill(tblMaster, dates, properties);
                    case "Module_02":
                        return Module_02.Fill(tblMaster, dates, properties);
                    case "Module_03":
                        return Module_03.Fill(tblMaster, dates, properties);
                    case "Module_04":
                        return Module_04.Fill(tblMaster, dates, properties);
                    case "Module_05":
                        return Module_05.Fill(tblMaster, dates, properties);
                    case "Module_06":
                        return Module_06.Fill(tblMaster, dates, properties);
                    case "Module_07":
                        return Module_07.Fill(tblMaster, dates, properties);
                    case "Module_08":
                        return Module_08.Fill(tblMaster, dates, properties);
                    case "Module_09":
                        return Module_09.Fill(tblMaster, dates, properties);
                    case "Module_10":
                        return Module_10.Fill(tblMaster, dates, properties);
                    case "Module_11":
                        return Module_11.Fill(tblMaster, dates, properties);
                    case "Module_12":
                        return Module_12.Fill(tblMaster, dates, properties);
                    case "Module_13":
                        return Module_13.Fill(tblMaster, dates, properties);
                    case "Module_14":
                        return Module_14.Fill(tblMaster, dates, properties);
                    case "Module_15":
                        return Module_15.Fill(tblMaster, dates, properties);
                    case "Module_16":
                        return Module_16.Fill(tblMaster, dates, properties);
                    case "Module_17":
                        return Module_17.Fill(tblMaster, dates, properties);
                    case "Module_18":
                        return Module_18.Fill(tblMaster, dates, properties);
                    case "Module_19":
                        return Module_19.Fill(tblMaster, dates, properties);
                    case "Module_20":
                        return Module_20.Fill(tblMaster, dates, properties);
                    case "Module_21":
                        return Module_21.Fill(tblMaster, dates, properties);
                    case "Module_22":
                        return Module_22.Fill(tblMaster, dates, properties);
                    case "Module_23":
                        return Module_23.Fill(tblMaster, dates, properties);
                    case "Module_24":
                        return Module_24.Fill(tblMaster, dates, properties);
                    case "Module_25":
                        return Module_25.Fill(tblMaster, dates, properties);
                    case "Module_26":
                        return Module_26.Fill(tblMaster, dates, properties);
                    case "Module_27":
                        return Module_27.Fill(tblMaster, dates, properties);
                    case "Module_28":
                        return Module_28.Fill(tblMaster, dates, properties);
                    case "Module_29":
                        return Module_29.Fill(tblMaster, dates, properties);
                    case "Module_30":
                        return Module_30.Fill(tblMaster, dates, properties);
                    case "Module_31":
                        return Module_31.Fill(tblMaster, dates, properties);
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
                #endregion

                #region Create Bands & NameSpaces

                List<GridBand> listOfBands = new List<GridBand>();
                XmlDocument xbandMap = new XmlDocument();
                bool multiBand = false;
                xbandMap.LoadXml(properties["XmlBandMap"].ToString());
                listOfBands.Add(GridViewManager.CreateStaticBand("Province", "اطلاعات استان"));
                listOfBands.Add(GridViewManager.CreateStaticBand("Domains", "اطلاعات حوزه"));
                listOfBands.Add(GridViewManager.CreateStaticBand("Branches", "اطلاعات شعبه"));

                foreach (XmlNode band in xbandMap.GetElementsByTagName("Band"))
                {
                    if (band.ChildNodes.Count == 1)//یک شاخص
                    {
                        string bandName = band.Attributes["Name"].Value;
                        string header = band.Attributes["HeaderText"].Value;
                        listOfBands.Add(GridViewManager.CreateStaticBand(bandName, header));
                    }
                    if (band.ChildNodes.Count > 1)//چند شاخص
                    {
                        multiBand = true;
                        for (int i = 1; i <= dates.Length; i++)
                        {
                            string bandName = band.Attributes["Name"].Value + i;
                            string header = band.Attributes["HeaderText"].Value.Replace("[ReportDate]", UDF.GetDateString(dates[i - 1]));
                            listOfBands.Add(GridViewManager.CreateStaticBand(bandName, header));
                        }
                    }
                }

                IDictionary<string, DataColumn> primaryColumnsNS = new Dictionary<string, DataColumn>();
                foreach (XmlNode column in xbandMap.GetElementsByTagName("Column"))
                {
                    for (int i = 1; i <= dates.Length; i++)
                    {
                        DataColumn col = new DataColumn();
                        if (multiBand)
                            col.ColumnName = UDF.GetNodeXPath(column, i) + column.Attributes["Name"].Value;
                        else
                            col.ColumnName = UDF.GetNodeXPath(column) + column.Attributes["Name"].Value + i;

                        col.DataType = Type.GetType(column.Attributes["Type"].Value);
                        col.Caption = column.Attributes["HeaderText"].Value.Replace("[ReportDate]", UDF.GetDateString(dates[i - 1]));
                        col.Namespace = UDF.GetDateString(dates[i - 1]);
                        primaryColumnsNS.Add(column.Attributes["Name"].Value + i, col);
                    }
                }
                #endregion

                #region Add Sum & Count Columns
              
                List<string> listOfCountColumns = new List<string>();
                foreach (string colName in properties["CountColumns"].ToString().Split(','))
                {
                    if (colName.Length > 0)
                        listOfCountColumns.Add(colName.Trim());
                }

                List<string> listOfSumColumns = new List<string>();
                foreach (string colName in properties["SumColumns"].ToString().Split(','))
                {
                    if (colName.Length > 0)
                        listOfSumColumns.Add(colName.Trim());
                }

                #endregion

                #region Branches Table

                DataTable branchesTable = new DataTable("Branches");
                branchesTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceId", Caption = "کد استان", DataType = typeof(int) });
                branchesTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceName", Caption = "نام استان", DataType = typeof(string) });
                branchesTable.Columns.Add(new DataColumn { ColumnName = "Domains.DomainId", Caption = "کد حوزه", DataType = typeof(int) });
                branchesTable.Columns.Add(new DataColumn { ColumnName = "Domains.DomainName", Caption = "نام حوزه", DataType = typeof(string) });
                branchesTable.Columns.Add(new DataColumn { ColumnName = "Branches.BranchId", Caption = "کد شعبه", DataType = typeof(int) });
                branchesTable.Columns.Add(new DataColumn { ColumnName = "Branches.BranchName", Caption = "نام شعبه", DataType = typeof(string) });
                branchesTable.Columns.Add(new DataColumn { ColumnName = "Branches.BranchDegree", Caption = "درجه", DataType = typeof(string) });
               
                foreach (string colName in listOfCountColumns)
                {
                    if (colName.Length > 0)
                    {
                        for (int i = 1; i <= dates.Length; i++)
                        {
                            DataColumn newcol = new DataColumn();
                            newcol.ColumnName = primaryColumnsNS[colName + i].ColumnName;
                            newcol.DataType = primaryColumnsNS[colName + i].DataType;
                            newcol.Caption = primaryColumnsNS[colName + i].Caption;
                            newcol.Namespace = primaryColumnsNS[colName + i].Namespace;
                            foreach (DictionaryEntry item in primaryColumnsNS[colName + i].ExtendedProperties)
                                newcol.ExtendedProperties.Add(item.Key, item.Value);
                            branchesTable.Columns.Add(newcol);
                        }
                    }
                }

                foreach (string colName in listOfSumColumns)
                {
                    if (colName.Length > 0)
                    {
                        for (int i = 1; i <= dates.Length; i++)
                        {
                            DataColumn newcol = new DataColumn();
                            newcol.ColumnName = primaryColumnsNS[colName + i].ColumnName;
                            newcol.DataType = primaryColumnsNS[colName + i].DataType;
                            newcol.Caption = primaryColumnsNS[colName + i].Caption;
                            newcol.Namespace = primaryColumnsNS[colName + i].Namespace;
                            foreach (DictionaryEntry item in primaryColumnsNS[colName + i].ExtendedProperties)
                                newcol.ExtendedProperties.Add(item.Key, item.Value);
                            branchesTable.Columns.Add(newcol);
                        }
                    }
                }

                #endregion

                #region Add Branches Rows

                foreach (Branches.BranchInfo bi in Branches.GetAllBranchs())
                {
                    if (Users.MyBranchID.Length > 0 & bi.BranchId != Users.MyBranchID)
                        continue;
                    DataRow[] branchRows = tblMaster.Select(string.Format("BranchID={0}", bi.BranchId));
                    DataRow newRow = branchesTable.NewRow();
                    newRow["Province.ProvinceId"] = bi.Province.ProvinceId;
                    newRow["Province.ProvinceName"] = bi.Province.ProvinceName;
                    newRow["Domains.DomainId"] = bi.Domain.DomainId;
                    newRow["Domains.DomainName"] = bi.Domain.DomainName;
                    newRow["Branches.BranchId"] = bi.BranchId;
                    newRow["Branches.BranchName"] = bi.BranchName;
                    newRow["Branches.BranchDegree"] = bi.BranchDegree;

                    foreach (string colName in listOfCountColumns)
                    {
                        if (colName.Length > 0)
                        {
                            for (int i = 1; i <= dates.Length; i++)
                            {
                                int countValues = branchRows
                                    .Where(x => x["ReportDate"].ToString() == dates[i - 1])
                                    .Count(x => x[colName].ToString().Length > 0);
                                newRow[primaryColumnsNS[colName + i].ColumnName] = countValues;
                                seriesPoints.Add(new ISeries.DataPoint(bi.BranchId, dates[i - 1], properties[colName].ToString(), countValues));
                            }
                        }
                    }

                    foreach (string colName in listOfSumColumns)
                    {
                        if (colName.Length > 0)
                        {
                            for (int i = 1; i <= dates.Length; i++)
                            {
                                double sumValues = branchRows
                                    .Where(x => x["ReportDate"].ToString() == dates[i - 1])
                                    .Sum(x => Numeral.AnyToDouble(x[colName]));
                                newRow[primaryColumnsNS[colName + i].ColumnName] = sumValues;
                                seriesPoints.Add(new ISeries.DataPoint(bi.BranchId, dates[i - 1], properties[colName].ToString(), sumValues));
                            }
                        }
                    }

                    branchesTable.Rows.Add(newRow);
                }
                #endregion

                #region Domains Table

                DataTable domainsTable = new DataTable("Domains");
                domainsTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceId", Caption = "کد استان", DataType = typeof(int) });
                domainsTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceName", Caption = "نام استان", DataType = typeof(string) });
                domainsTable.Columns.Add(new DataColumn { ColumnName = "Domains.DomainId", Caption = "کد حوزه", DataType = typeof(int) });
                domainsTable.Columns.Add(new DataColumn { ColumnName = "Domains.DomainName", Caption = "نام حوزه", DataType = typeof(string) });
              
                foreach (string colName in listOfCountColumns)
                {
                    for (int i = 1; i <= dates.Length; i++)
                    {
                        DataColumn newcol = new DataColumn();
                        newcol.ColumnName = primaryColumnsNS[colName + i].ColumnName;
                        newcol.DataType = primaryColumnsNS[colName + i].DataType;
                        newcol.Caption = primaryColumnsNS[colName + i].Caption;
                        foreach (DictionaryEntry item in primaryColumnsNS[colName + i].ExtendedProperties)
                            newcol.ExtendedProperties.Add(item.Key, item.Value);
                        domainsTable.Columns.Add(newcol);
                    }
                }

                foreach (string colName in listOfSumColumns)
                {
                    for (int i = 1; i <= dates.Length; i++)
                    {
                        DataColumn newcol = new DataColumn();
                        newcol.ColumnName = primaryColumnsNS[colName + i].ColumnName;
                        newcol.DataType = primaryColumnsNS[colName + i].DataType;
                        newcol.Caption = primaryColumnsNS[colName + i].Caption;
                        foreach (DictionaryEntry item in primaryColumnsNS[colName + i].ExtendedProperties)
                            newcol.ExtendedProperties.Add(item.Key, item.Value);
                        domainsTable.Columns.Add(newcol);
                    }
                }

                #endregion

                #region Add Domains Rows

                foreach (Branches.DomainInfo di in Branches.GetDomains())
                {
                    if (Users.MyDomainID.Length > 0 & di.DomainId != Users.MyDomainID)
                        continue;

                    DataRow[] domainRows = branchesTable.Select(string.Format("Domains.DomainId={0}", di.DomainId));
                    DataRow newRow = domainsTable.NewRow();
                    newRow["Province.ProvinceId"] = di.Province.ProvinceId;
                    newRow["Province.ProvinceName"] = di.Province.ProvinceName;
                    newRow["Domains.DomainId"] = di.DomainId;
                    newRow["Domains.DomainName"] = di.DomainName;
                   
                    foreach (string colName in listOfCountColumns)
                    {
                        if (colName.Length > 0)
                        {
                            for (int i = 1; i <= dates.Length; i++)
                            {
                                string name = primaryColumnsNS[colName + i].ColumnName;
                                int countValues = domainRows
                                    .Sum(x => Numeral.AnyToInt32(x[name]));
                                newRow[name] = countValues;
                                seriesPoints.Add(new ISeries.DataPoint(di.DomainId, dates[i - 1], properties[colName].ToString(), countValues));
                            }
                        }
                    }

                    foreach (string colName in listOfSumColumns)
                    {
                        if (colName.Length > 0)
                        {
                            for (int i = 1; i <= dates.Length; i++)
                            {
                                string name = primaryColumnsNS[colName + i].ColumnName;
                                double sumValues = domainRows
                                    .Sum(x => Numeral.AnyToDouble(x[name]));
                                newRow[name] = sumValues;
                                seriesPoints.Add(new ISeries.DataPoint(di.DomainId, dates[i - 1], properties[colName].ToString(), sumValues));
                            }
                        }
                    }

                    domainsTable.Rows.Add(newRow);

                }
                #endregion

                #region Province Table

                DataTable provinceTable = new DataTable("Province");
                provinceTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceId", Caption = "کد استان", DataType = typeof(int) });
                provinceTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceName", Caption = "نام استان", DataType = typeof(string) });

                foreach (string colName in listOfCountColumns)
                {
                    if (colName.Length > 0)
                    {
                        for (int i = 1; i <= dates.Length; i++)
                        {
                            DataColumn newcol = new DataColumn();
                            newcol.ColumnName = primaryColumnsNS[colName + i].ColumnName;
                            newcol.DataType = primaryColumnsNS[colName + i].DataType;
                            newcol.Caption = primaryColumnsNS[colName + i].Caption;
                            foreach (DictionaryEntry item in primaryColumnsNS[colName + i].ExtendedProperties)
                                newcol.ExtendedProperties.Add(item.Key, item.Value);
                            provinceTable.Columns.Add(newcol);
                        }
                    }
                }

                foreach (string colName in listOfSumColumns)
                {
                    if (colName.Length > 0)
                    {
                        for (int i = 1; i <= dates.Length; i++)
                        {
                            DataColumn newcol = new DataColumn();
                            newcol.ColumnName = primaryColumnsNS[colName + i].ColumnName;
                            newcol.DataType = primaryColumnsNS[colName + i].DataType;
                            newcol.Caption = primaryColumnsNS[colName + i].Caption;
                            foreach (DictionaryEntry item in primaryColumnsNS[colName + i].ExtendedProperties)
                                newcol.ExtendedProperties.Add(item.Key, item.Value);
                            provinceTable.Columns.Add(newcol);
                        }
                    }
                }
                #endregion

                #region Add Province Rows

                foreach (Branches.ProvinceInfo pi in Branches.GetProvincesByZoneId(Users.MyZoneID))
                {
                    if (Users.MyProvinceID.Length > 0 & pi.ProvinceId != Users.MyProvinceID)
                        continue;

                    DataRow[] provinceRows = domainsTable.Select(string.Format("Province.ProvinceId={0}", pi.ProvinceId));
                    DataRow newRow = provinceTable.NewRow();
                    newRow["Province.ProvinceId"] = pi.ProvinceId;
                    newRow["Province.ProvinceName"] = pi.ProvinceName;

                    foreach (string colName in listOfCountColumns)
                    {
                        for (int i = 1; i <= dates.Length; i++)
                        {
                            string name = primaryColumnsNS[colName + i].ColumnName;
                            int countValues = provinceRows
                                .Sum(x => Numeral.AnyToInt32(x[name]));
                            newRow[name] = countValues;
                            seriesPoints.Add(new ISeries.DataPoint(pi.ProvinceId, dates[i - 1], properties[colName].ToString(), countValues));
                        }
                    }

                    foreach (string colName in listOfSumColumns)
                    {
                        for (int i = 1; i <= dates.Length; i++)
                        {
                            string name = primaryColumnsNS[colName + i].ColumnName;
                            double sumValues = provinceRows
                                .Sum(x => Numeral.AnyToDouble(x[name]));
                            newRow[name] = sumValues;
                            seriesPoints.Add(new ISeries.DataPoint(pi.ProvinceId, dates[i - 1], properties[colName].ToString(), sumValues));
                        }
                    }

                    provinceTable.Rows.Add(newRow);
                }
                #endregion

                #region BranchesList Table

                DataTable branchesListTable = branchesTable.Copy();
                branchesListTable.TableName = "BranchesList";
                branchesListTable.Columns["Domains.DomainId"].ExtendedProperties["Visible"] = true;
                branchesListTable.Columns["Domains.DomainName"].ExtendedProperties["Visible"] = true;
                branchesListTable.Columns["Branches.BranchId"].ExtendedProperties["Visible"] = true;
                #endregion

                #region Relations

                ds.Tables.Add(provinceTable);
                ds.Tables.Add(domainsTable);
                ds.Tables.Add(branchesTable);
                ds.Relations.Add("حوزه ها", provinceTable.Columns["Province.ProvinceId"], domainsTable.Columns["Province.ProvinceId"]);
                ds.Relations.Add("شعب", domainsTable.Columns["Domains.DomainId"], branchesTable.Columns["Domains.DomainId"]);

                #endregion

                #region Extended Properties
                
                branchesTable.Columns["Province.ProvinceId"].ExtendedProperties.Add("Visible", false);
                branchesTable.Columns["Province.ProvinceName"].ExtendedProperties.Add("Visible", false);
                branchesTable.Columns["Domains.DomainId"].ExtendedProperties.Add("Visible", false);
                branchesTable.Columns["Domains.DomainName"].ExtendedProperties.Add("Visible", false);
                branchesTable.Columns["Branches.BranchId"].ExtendedProperties.Add("Visible", false);

                domainsTable.Columns["Province.ProvinceId"].ExtendedProperties.Add("Visible", false);
                domainsTable.Columns["Province.ProvinceName"].ExtendedProperties.Add("Visible", false);
                domainsTable.Columns["Domains.DomainId"].ExtendedProperties.Add("Visible", false);

                provinceTable.Columns["Province.ProvinceId"].ExtendedProperties.Add("Visible", false);

                ds.ExtendedProperties.Add("SeriesPoints", seriesPoints);
                ds.ExtendedProperties.Add("Bands", listOfBands);
                ds.ExtendedProperties.Add("MainTable", "Province");

                #endregion

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
