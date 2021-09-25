using DevExpress.XtraGrid.Views.BandedGrid;
using GAM.Forms.Information.Library;
using GAM.Forms.Profile.Kargozini.Library;
using GAM.Forms.Reports.Library;
using GAM.Modules;
using MD.PersianDateTime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Forms.Reports.Queries
{
    class Module_17
    {
        public static DataSet Fill(DataTable tblMaster, string[] dates, QueryProperties properties)
        {
            #region Initialize Items

            List<ISeries.DataPoint> seriesPoints = new List<ISeries.DataPoint>();

            #endregion

            #region Bands

            DataSet ds = new DataSet();
            GridViewManager gvm = new GridViewManager();
            List<GridBand> bands = new List<GridBand>();
            bands.Add(gvm.CreateBand("Province", "اطلاعات استان"));
            bands.Add(gvm.CreateBand("Domains", "اطلاعات حوزه"));
            bands.Add(gvm.CreateBand("Branches", "اطلاعات شعبه"));
            bands.Add(gvm.CreateBand("PrimaryColumns", "عملکرد در"));
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
            for (int i = 1; i <= dates.Length; i++)
                branchesTable.Columns.Add(new DataColumn { ColumnName = "PrimaryColumns.NPL" + i, Caption = UDF.GetDateString(dates[i - 1]), DataType = Type.GetType("System.Double"), Namespace = UDF.GetDateString(dates[i - 1]) });

            #endregion

            var groupByBranchId = tblMaster.AsEnumerable().GroupBy(dr => new { BranchId = dr["BranchID"].ToString() })
                                   .Select(g => new
                                   {
                                       BranchId = g.Key.BranchId,
                                       Values = g,
                                   }).ToDictionary(x => x.BranchId, x => x);


            foreach (Branches.BranchInfo bi in Branches.GetAllBranchs())
            {
                if (groupByBranchId.ContainsKey(bi.BranchId))
                {
                    var row = groupByBranchId[bi.BranchId];
                    DataRow newRow = branchesTable.NewRow();
                    newRow["Province.ProvinceId"] = bi.Province.ProvinceId;
                    newRow["Province.ProvinceName"] = bi.Province.ProvinceName;
                    newRow["Domains.DomainId"] = bi.Domain.DomainId;
                    newRow["Domains.DomainName"] = bi.Domain.DomainName;
                    newRow["Branches.BranchId"] = bi.BranchId;
                    newRow["Branches.BranchName"] = bi.BranchName;
                    newRow["Branches.BranchDegree"] = bi.BranchDegree;
                    for (int i = 1; i <= dates.Length; i++)
                    {
                        double upper = Numeral.AnyToDouble(row.Values.Where(x => x["ReportDate"].ToString() == dates[i - 1]).First()["UpperValue"]);
                        double under = Numeral.AnyToDouble(row.Values.Where(x => x["ReportDate"].ToString() == dates[i - 1]).First()["UnderValue"]);
                        double npl = (upper / under) * 100;
                        newRow["PrimaryColumns.NPL" + i] = npl;

                        seriesPoints.Add(new ISeries.DataPoint(bi.BranchId, dates[i - 1], "عملکرد", npl));
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
                    for (int i = 1; i <= dates.Length; i++)
                        newRow["PrimaryColumns.NPL" + i] = 0;

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
            for (int i = 1; i <= dates.Length; i++)
                domainsTable.Columns.Add(new DataColumn { ColumnName = "PrimaryColumns.NPL" + i, Caption = UDF.GetDateString(dates[i - 1]), DataType = Type.GetType("System.Double"), Namespace = UDF.GetDateString(dates[i - 1]) });

            foreach (Branches.DomainInfo di in Branches.GetDomains())
            {
                if (groupByBranchId.ContainsKey(di.DomainId))
                {
                    var row = groupByBranchId[di.DomainId];
                    DataRow newRow = domainsTable.NewRow();
                    newRow["Province.ProvinceId"] = di.Province.ProvinceId;
                    newRow["Province.ProvinceName"] = di.Province.ProvinceName;
                    newRow["Domains.DomainId"] = di.DomainId;
                    newRow["Domains.DomainName"] = di.DomainName;
                    for (int i = 1; i <= dates.Length; i++)
                    {
                        double upper = Numeral.AnyToDouble(row.Values.Where(x => x["ReportDate"].ToString() == dates[i - 1]).First()["UpperValue"]);
                        double under = Numeral.AnyToDouble(row.Values.Where(x => x["ReportDate"].ToString() == dates[i - 1]).First()["UnderValue"]);
                        double npl = (upper / under) * 100;
                        newRow["PrimaryColumns.NPL" + i] = npl;

                        seriesPoints.Add(new ISeries.DataPoint(di.DomainId, dates[i - 1], "عملکرد", npl));
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
                    for (int i = 1; i <= dates.Length; i++)
                        newRow["PrimaryColumns.NPL" + i] = 0;

                    domainsTable.Rows.Add(newRow);
                }
            }

            #endregion

            #region Province Table

            DataTable provinceTable = new DataTable("Province");
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceId", Caption = "کد استان", DataType = Type.GetType("System.Int32") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceName", Caption = "نام استان", DataType = typeof(string) });
            for (int i = 1; i <= dates.Length; i++)
                provinceTable.Columns.Add(new DataColumn { ColumnName = "PrimaryColumns.NPL" + i, Caption = UDF.GetDateString(dates[i - 1]), DataType = Type.GetType("System.Double"), Namespace = UDF.GetDateString(dates[i - 1]) });

            foreach (Branches.ProvinceInfo pi in Branches.GetProvincesByZoneId(Users.MyZoneID))
            {
                if (Users.MyProvinceID.Length > 0 & pi.ProvinceId != Users.MyProvinceID)
                    continue;

                if (groupByBranchId.ContainsKey(pi.ProvinceId))
                {
                    var row = groupByBranchId[pi.ProvinceId];
                    DataRow newRow = provinceTable.NewRow();
                    newRow["Province.ProvinceId"] = pi.ProvinceId;
                    newRow["Province.ProvinceName"] = pi.ProvinceName;
                    for (int i = 1; i <= dates.Length; i++)
                    {
                        double upper = Numeral.AnyToDouble(row.Values.Where(x => x["ReportDate"].ToString() == dates[i - 1]).First()["UpperValue"]);
                        double under = Numeral.AnyToDouble(row.Values.Where(x => x["ReportDate"].ToString() == dates[i - 1]).First()["UnderValue"]);
                        double npl = (upper / under) * 100;
                        newRow["PrimaryColumns.NPL" + i] = npl;

                        seriesPoints.Add(new ISeries.DataPoint(pi.ProvinceId, dates[i - 1], "عملکرد", npl));
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
            ds.Relations.Add("شعب", domainsTable.Columns["Domains.DomainId"], branchesTable.Columns["Domains.DomainId"]);

            #endregion

            #region Extended Properties

            branchesTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Domains.DomainID"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Domains.DomainName"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Branches.BranchID"].ExtendedProperties["Visible"] = false;

            domainsTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            domainsTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            domainsTable.Columns["Domains.DomainID"].ExtendedProperties["Visible"] = false;

            provinceTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;

            ds.ExtendedProperties.Add("SeriesPoints", seriesPoints);
            ds.ExtendedProperties.Add("Bands", bands);
            ds.ExtendedProperties.Add("MainTable", provinceTable.TableName);
            #endregion

            return ds;
        }
    }
}
