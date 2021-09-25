using DevExpress.XtraGrid.Views.BandedGrid;
using GAM.Connections;
using GAM.Forms.Information.Library;
using GAM.Forms.Reports.Library;
using GAM.Modules;
using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Forms.Reports.Queries
{
    class Module_27
    {
        public static DataSet Fill(DataTable tblMaster, string[] dates, QueryProperties properties)
        {
            List<ISeries.DataPoint> seriesPoints = new List<ISeries.DataPoint>();
            string[] selectedDates = null;
            DataTable tblManabe = new DataTable();
            DataTable tblMasaref = tblMaster.Clone();
            DataTable tblMerged = new DataTable();
            tblMerged.Columns.Add("ReportDate", typeof(int));
            tblMerged.Columns.Add("BranchID", typeof(int));
            tblMerged.Columns.Add("MandehMasaref", typeof(double));
            tblMerged.Columns.Add("MandehManabe", typeof(double));

            OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_100.mdb"));
            objConn.Open();
            OleDbCommand objCmd = new OleDbCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.Text;
            string[] names = objConn.GetSchema("Tables").AsEnumerable().Where(x => x["TABLE_TYPE"].ToString() == "TABLE").Select(r => r["TABLE_NAME"].ToString()).ToArray();

            foreach (DataRow r in tblMaster.Rows)
            {
                if (names.Contains(r["ReportDate"].ToString()))
                    tblMasaref.Rows.Add(r.ItemArray);
            }

            foreach (string date in dates)
            {
                if (names.Contains(date))
                {
                    DataTable tblData = new DataTable();
                    objCmd.CommandText = string.Format("SELECT {0} AS ReportDate, [BranchID], [SumOf4SepordehKhososi] FROM [{0}]", date);
                    var dataReader = objCmd.ExecuteReader();
                    tblData.Load(dataReader);
                    tblManabe.Merge(tblData);
                }
            }
            for (int i = 0; i < tblManabe.Rows.Count; i++)
            {
                DataRow r = tblManabe.Rows[i];
                string id = r["BranchID"].ToString();
                if (Branches.IsBranch(id))
                    r["BranchID"] = Branches.GetBranchById(id, true).BranchId;
            }
            objConn.Close();


            foreach (var g in tblMasaref.AsEnumerable().GroupBy(x => x["ReportDate"].ToString()))
            {
                foreach (DataRow r in g)
                {
                    DataRow[] rows = tblManabe.Select(string.Format("ReportDate={0} AND BranchID={1}", r["ReportDate"].ToString() , r["BranchID"].ToString()));
                    if (rows.Count() > 0)
                    {
                        DataRow newRow = tblMerged.NewRow();
                        newRow["ReportDate"] = r["ReportDate"].ToString();
                        newRow["BranchID"] = r["BranchID"].ToString();
                        newRow["MandehMasaref"] = r["KhalesMasaref"].ToString();
                        newRow["MandehManabe"] = rows.Sum(x => Numeral.AnyToDouble(x["SumOf4SepordehKhososi"], Numeral.StringToIUnitPrice(properties.GetStrProperty("UnitAmount")))).ToString();
                        tblMerged.Rows.Add(newRow);
                    }
                }
            }

            selectedDates = tblMerged.AsEnumerable().Select(x => x["ReportDate"].ToString()).Distinct().ToArray();

            #region Bands
            IDictionary<string, string> bandNames = new Dictionary<string, string>();
            DataSet ds = new DataSet();
            GridViewManager gvm = new GridViewManager();
            List<GridBand> bands = new List<GridBand>();
            bands.Add(gvm.CreateBand("Province", "اطلاعات استان"));
            bands.Add(gvm.CreateBand("Domains", "اطلاعات حوزه"));
            bands.Add(gvm.CreateBand("Branches", "اطلاعات شعبه"));
            int bandNo = 0;
            foreach (var date in selectedDates)
            {
                ++bandNo;
                bandNames.Add(date, "Band" + bandNo);
                bands.Add(gvm.CreateBand("Band" + bandNo, UDF.GetDateString(date), 110));
            }
            #endregion

            #region Branches Table

            #region ساخت ستون ها
            DataTable branchesTable = new DataTable("Branches");
            branchesTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceId", Caption = "کد استان", DataType = Type.GetType("System.Int32") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceName", Caption = "نام استان", DataType = typeof(string) });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "Domains.DomainId", Caption = "کد حوزه", DataType = Type.GetType("System.Int32") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "Domains.DomainName", Caption = "نام حوزه", DataType = Type.GetType("System.String") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "Branches.BranchId", Caption = "کد شعبه", DataType = Type.GetType("System.Int32") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "Branches.BranchName", Caption = "نام شعبه" });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "Branches.BranchDegree", Caption = "درجه" });
            for (int i = 1; i <= selectedDates.Length; i++)
            {
                branchesTable.Columns.Add(new DataColumn { ColumnName = bandNames[selectedDates[i - 1]] + ".MandehMasaref", Caption = "مصارف", DataType = Type.GetType("System.Double"), Namespace = UDF.GetDateString(selectedDates[i - 1]) });
                branchesTable.Columns.Add(new DataColumn { ColumnName = bandNames[selectedDates[i - 1]] + ".MandehManabe", Caption = "منابع", DataType = Type.GetType("System.Double"), Namespace = UDF.GetDateString(selectedDates[i - 1]) });
                branchesTable.Columns.Add(new DataColumn { ColumnName = bandNames[selectedDates[i - 1]] + ".Ratio", Caption = "نسبت", DataType = Type.GetType("System.Double"), Namespace = UDF.GetDateString(selectedDates[i - 1]) });
            }
            #endregion

            var groupByBranchId = tblMerged.AsEnumerable().GroupBy(dr => new { BranchId = dr["BranchID"].ToString() })
                                   .Select(g => new
                                   {
                                       BranchInfo = Branches.GetBranchById(g.Key.BranchId, true),
                                       Values = g,
                                       MandehMasaref = g.Sum(x => Numeral.AnyToDouble(x["MandehMasaref"])),
                                       MandehManabe = g.Sum(x => Numeral.AnyToDouble(x["MandehManabe"])),
                                   }).ToDictionary(x => int.Parse(x.BranchInfo.BranchId), x => x);


            foreach (Branches.BranchInfo bi in Branches.GetAllBranchs())
            {
                int branchId = int.Parse(bi.BranchId);
                if (groupByBranchId.ContainsKey(branchId))
                {
                    var row = groupByBranchId[branchId];
                    DataRow newRow = branchesTable.NewRow();
                    newRow["Province.ProvinceId"] = bi.Province.ProvinceId;
                    newRow["Province.ProvinceName"] = bi.Province.ProvinceName;
                    newRow["Domains.DomainId"] = bi.Domain.DomainId;
                    newRow["Domains.DomainName"] = bi.Domain.DomainName;
                    newRow["Branches.BranchId"] = bi.BranchId;
                    newRow["Branches.BranchName"] = bi.BranchName;
                    newRow["Branches.BranchDegree"] = bi.BranchDegree;
                    for (int i = 1; i <= selectedDates.Length; i++)
                    {
                        DataRow brow = row.Values.Where(x => x["ReportDate"].ToString() == selectedDates[i - 1]).First();
                        double masaref = Numeral.AnyToDouble(brow["MandehMasaref"]);
                        double manabe = Numeral.AnyToDouble(brow["MandehManabe"]);
                        double ratio = Numeral.ZeroForOverflowValue((masaref / manabe) * 100);
                      
                        newRow[bandNames[selectedDates[i - 1]] + ".MandehMasaref"] = masaref;
                        newRow[bandNames[selectedDates[i - 1]] + ".MandehManabe"] = manabe;
                        newRow[bandNames[selectedDates[i - 1]] + ".Ratio"] = ratio;
                     
                        seriesPoints.Add(new ISeries.DataPoint(bi.BranchId, selectedDates[i - 1], "مصارف", masaref));
                        seriesPoints.Add(new ISeries.DataPoint(bi.BranchId, selectedDates[i - 1], "منابع", manabe));
                        seriesPoints.Add(new ISeries.DataPoint(bi.BranchId, selectedDates[i - 1], "نسبت", ratio));
                    }
                    branchesTable.Rows.Add(newRow);
                }
                else
                {
                    DataRow newRow = branchesTable.NewRow();
                    newRow["Province.ProvinceId"] = bi.Province.ProvinceId;
                    newRow["Province.ProvinceName"] = bi.Province.ProvinceName;
                    newRow["Domains.DomainId"] = bi.Domain.DomainId;
                    newRow["Domains.DomainName"] = bi.Domain.DomainName;
                    newRow["Branches.BranchId"] = bi.BranchId;
                    newRow["Branches.BranchName"] = bi.BranchName;
                    newRow["Branches.BranchDegree"] = bi.BranchDegree;
                    for (int i = 1; i <= selectedDates.Length; i++)
                    {
                        newRow[bandNames[selectedDates[i - 1]] + ".MandehMasaref"] = 0;
                        newRow[bandNames[selectedDates[i - 1]] + ".MandehManabe"] = 0;
                        newRow[bandNames[selectedDates[i - 1]] + ".Ratio"] = 0;
                   
                        seriesPoints.Add(new ISeries.DataPoint(bi.BranchId, selectedDates[i - 1], "مصارف", 0));
                        seriesPoints.Add(new ISeries.DataPoint(bi.BranchId, selectedDates[i - 1], "منابع", 0));
                        seriesPoints.Add(new ISeries.DataPoint(bi.BranchId, selectedDates[i - 1], "نسبت", 0));
                    }
                    branchesTable.Rows.Add(newRow);
                }
            }

            #endregion

            #region Domains Table

            DataTable domainsTable = new DataTable("Domains");
            domainsTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceId", Caption = "کد استان", DataType = Type.GetType("System.Int32") });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceName", Caption = "نام استان", DataType = typeof(string) });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "Domains.DomainId", Caption = "کد حوزه", DataType = Type.GetType("System.Int32") });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "Domains.DomainName", Caption = "نام حوزه", DataType = Type.GetType("System.String") });
            for (int i = 1; i <= selectedDates.Length; i++)
            {
                domainsTable.Columns.Add(new DataColumn { ColumnName = bandNames[selectedDates[i - 1]] + ".MandehMasaref", Caption = "مصارف", DataType = Type.GetType("System.Double") });
                domainsTable.Columns.Add(new DataColumn { ColumnName = bandNames[selectedDates[i - 1]] + ".MandehManabe", Caption = "منابع", DataType = Type.GetType("System.Double") });
                domainsTable.Columns.Add(new DataColumn { ColumnName = bandNames[selectedDates[i - 1]] + ".Ratio", Caption = "نسبت", DataType = Type.GetType("System.Double") });
            }

            foreach (Branches.DomainInfo di in Branches.GetDomains())
            {
                DataRow[] brRows = branchesTable.Select(string.Format("Domains.DomainId={0}", di.DomainId));
                if (brRows != null)
                {
                    DataRow newRow = domainsTable.NewRow();
                    newRow["Province.ProvinceId"] = di.Province.ProvinceId;
                    newRow["Province.ProvinceName"] = di.Province.ProvinceName;
                    newRow["Domains.DomainId"] = di.DomainId;
                    newRow["Domains.DomainName"] = di.DomainName;
                    for (int i = 1; i <= selectedDates.Length; i++)
                    {
                        double masaref = brRows.Sum(x => Numeral.AnyToDouble(x[bandNames[selectedDates[i - 1]] + ".MandehMasaref"]));
                        double manabe = brRows.Sum(x => Numeral.AnyToDouble(x[bandNames[selectedDates[i - 1]] + ".MandehManabe"]));
                        double ratio = Numeral.ZeroForOverflowValue((masaref / manabe) * 100);

                        newRow[bandNames[selectedDates[i - 1]] + ".MandehMasaref"] = masaref;
                        newRow[bandNames[selectedDates[i - 1]] + ".MandehManabe"] = manabe;
                        newRow[bandNames[selectedDates[i - 1]] + ".Ratio"] = ratio;
                       
                        seriesPoints.Add(new ISeries.DataPoint(di.DomainId, selectedDates[i - 1], "مصارف", masaref));
                        seriesPoints.Add(new ISeries.DataPoint(di.DomainId, selectedDates[i - 1], "منابع", manabe));
                        seriesPoints.Add(new ISeries.DataPoint(di.DomainId, selectedDates[i - 1], "نسبت", ratio));
                    }
                    domainsTable.Rows.Add(newRow);
                }
                else
                {
                    DataRow newRow = domainsTable.NewRow();
                    newRow["Province.ProvinceId"] = di.Province.ProvinceId;
                    newRow["Province.ProvinceName"] = di.Province.ProvinceName;
                    newRow["Domains.DomainId"] = di.DomainId;
                    newRow["Domains.DomainName"] = di.DomainName;
                    for (int i = 1; i <= selectedDates.Length; i++)
                    {
                        newRow[bandNames[selectedDates[i - 1]] + ".MandehMasaref"] = 0;
                        newRow[bandNames[selectedDates[i - 1]] + ".MandehManabe"] = 0;
                        newRow[bandNames[selectedDates[i - 1]] + ".Ratio"] = 0;
                       
                        seriesPoints.Add(new ISeries.DataPoint(di.DomainId, selectedDates[i - 1], "مصارف", 0));
                        seriesPoints.Add(new ISeries.DataPoint(di.DomainId, selectedDates[i - 1], "منابع", 0));
                        seriesPoints.Add(new ISeries.DataPoint(di.DomainId, selectedDates[i - 1], "نسبت", 0));
                    }
                    domainsTable.Rows.Add(newRow);
                }
            }

            #endregion

            #region Province Table

            DataTable provinceTable = new DataTable("Province");
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceId", Caption = "کد استان", DataType = Type.GetType("System.Int32") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceName", Caption = "نام استان", DataType = typeof(string) });
            for (int i = 1; i <= selectedDates.Length; i++)
            {
                provinceTable.Columns.Add(new DataColumn { ColumnName = bandNames[selectedDates[i - 1]] + ".MandehMasaref", Caption = "مصارف", DataType = Type.GetType("System.Double") });
                provinceTable.Columns.Add(new DataColumn { ColumnName = bandNames[selectedDates[i - 1]] + ".MandehManabe", Caption = "منابع", DataType = Type.GetType("System.Double") });
                provinceTable.Columns.Add(new DataColumn { ColumnName = bandNames[selectedDates[i - 1]] + ".Ratio", Caption = "نسبت", DataType = Type.GetType("System.Double") });
            }

            foreach (Branches.ProvinceInfo pi in Branches.GetProvincesByZoneId(Users.MyZoneID))
            {
                if (Users.MyProvinceID.Length > 0 & pi.ProvinceId != Users.MyProvinceID)
                    continue;

                DataRow[] doRows = domainsTable.Select(string.Format("Province.ProvinceId={0}", pi.ProvinceId));
                if (doRows != null)
                {
                    DataRow newRow = provinceTable.NewRow();
                    newRow["Province.ProvinceId"] = pi.ProvinceId;
                    newRow["Province.ProvinceName"] = pi.ProvinceName;
                    for (int i = 1; i <= selectedDates.Length; i++)
                    {
                        double masaref = doRows.Sum(x => Numeral.AnyToDouble(x[bandNames[selectedDates[i - 1]] + ".MandehMasaref"]));
                        double manabe = doRows.Sum(x => Numeral.AnyToDouble(x[bandNames[selectedDates[i - 1]] + ".MandehManabe"]));
                        double ratio = Numeral.ZeroForOverflowValue((masaref / manabe) * 100);
                      
                        newRow[bandNames[selectedDates[i - 1]] + ".MandehMasaref"] = masaref;
                        newRow[bandNames[selectedDates[i - 1]] + ".MandehManabe"] = manabe;
                        newRow[bandNames[selectedDates[i - 1]] + ".Ratio"] = ratio;
                      
                        seriesPoints.Add(new ISeries.DataPoint(pi.ProvinceId, selectedDates[i - 1], "مصارف", masaref));
                        seriesPoints.Add(new ISeries.DataPoint(pi.ProvinceId, selectedDates[i - 1], "منابع", manabe));
                        seriesPoints.Add(new ISeries.DataPoint(pi.ProvinceId, selectedDates[i - 1], "نسبت", ratio));
                    }
                    provinceTable.Rows.Add(newRow);
                }
            }

            #endregion

            #region Relations

            ds.Tables.Add(provinceTable);
            ds.Tables.Add(domainsTable);
            ds.Tables.Add(branchesTable);

            ds.Relations.Add("حوزه ها", provinceTable.Columns["Province.ProvinceId"], domainsTable.Columns["Province.ProvinceId"]);
            ds.Relations.Add("شعب", domainsTable.Columns["Domains.DomainID"], branchesTable.Columns["Domains.DomainID"]);
            #endregion

            #region Extended Properties

            branchesTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Domains.DomainID"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Domains.DomainName"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Branches.BranchID"].ExtendedProperties["Visible"] = false;
            for (int i = 1; i <= selectedDates.Length; i++)
            {
                branchesTable.Columns[bandNames[selectedDates[i - 1]] + ".MandehMasaref"].ExtendedProperties.Add("FormatNumber", "N0");
                branchesTable.Columns[bandNames[selectedDates[i - 1]] + ".MandehManabe"].ExtendedProperties.Add("FormatNumber", "N0");
                branchesTable.Columns[bandNames[selectedDates[i - 1]] + ".Ratio"].ExtendedProperties.Add("FormatNumber", "N1");
            }

            domainsTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            domainsTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            domainsTable.Columns["Domains.DomainID"].ExtendedProperties["Visible"] = false;
            for (int i = 1; i <= selectedDates.Length; i++)
            {
                domainsTable.Columns[bandNames[selectedDates[i - 1]] + ".MandehMasaref"].ExtendedProperties.Add("FormatNumber", "N0");
                domainsTable.Columns[bandNames[selectedDates[i - 1]] + ".MandehManabe"].ExtendedProperties.Add("FormatNumber", "N0");
                domainsTable.Columns[bandNames[selectedDates[i - 1]] + ".Ratio"].ExtendedProperties.Add("FormatNumber", "N1");
            }

            provinceTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            for (int i = 1; i <= selectedDates.Length; i++)
            {
                provinceTable.Columns[bandNames[selectedDates[i - 1]] + ".MandehMasaref"].ExtendedProperties.Add("FormatNumber", "N0");
                provinceTable.Columns[bandNames[selectedDates[i - 1]] + ".MandehManabe"].ExtendedProperties.Add("FormatNumber", "N0");
                provinceTable.Columns[bandNames[selectedDates[i - 1]] + ".Ratio"].ExtendedProperties.Add("FormatNumber", "N1");
            }

            ds.ExtendedProperties.Add("SeriesPoints", seriesPoints);
            ds.ExtendedProperties.Add("Bands", bands);
            ds.ExtendedProperties.Add("MainTable", provinceTable.TableName);
            #endregion

            return ds;
        }
    }
}
