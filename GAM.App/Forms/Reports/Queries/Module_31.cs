using DevExpress.XtraGrid.Views.BandedGrid;
using GAM.Forms.Information.Library;
using GAM.Forms.Reports.Library;
using GAM.Modules;
using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Forms.Reports.Queries
{
    class Module_31
    {
        public static DataSet Fill(DataTable tblMaster, string[] dates, QueryProperties properties)
        {
            DataSet ds = new DataSet();
            GridViewManager gvm = new GridViewManager();
            List<GridBand> bands = new List<GridBand>();
            bands.Add(gvm.CreateBand("Province", "اطلاعات استان"));
            bands.Add(gvm.CreateBand("Domains", "اطلاعات حوزه"));
            bands.Add(gvm.CreateBand("Branches", "اطلاعات شعبه"));
            bands.Add(gvm.CreateBand("Customers", "اطلاعات مشتری"));
            bands.Add(gvm.CreateBand("PosInfo", "اطلاعات پوز"));
            bands.Add(gvm.CreateBand("ContractsInfo", "اطلاعات پرداختی"));
            bands.Add(gvm.CreateBand("AccountsInfo", "اطلاعات حساب"));
            for (int i = 1; i <= dates.Length; i++)
            {
                bands.Add(gvm.CreateBand("Category" + i, UDF.GetDateString(dates[i - 1])));
            }

            #region  Customers Table

            DataTable customersTable = new DataTable("Customers");
            customersTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceId", Caption = "کد استان", DataType = Type.GetType("System.Int32") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceName", Caption = "نام استان", DataType = typeof(string) });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Domains.DomainId", Caption = "کد حوزه", DataType = Type.GetType("System.Int32") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Domains.DomainName", Caption = "نام حوزه", DataType = Type.GetType("System.String") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Branches.BranchId", Caption = "کد شعبه", DataType = Type.GetType("System.Int32") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Branches.BranchName", Caption = "نام شعبه" });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Branches.BranchDegree", Caption = "درجه" });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Customers.CustomerId", Caption = "شماره مشتری", DataType = Type.GetType("System.String") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Customers.CustomerName", Caption = "نام بدهکار", DataType = Type.GetType("System.String") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "PosInfo.Rank", Caption = "رتبه", DataType = Type.GetType("System.String") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "PosInfo.POSCount", Caption = "تعداد پوز", DataType = Type.GetType("System.Double") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "PosInfo.TransactionCount", Caption = "تعداد تراکنش", DataType = Type.GetType("System.Double") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "AccountsInfo.AccountAVG1", Caption = "معدل در شعبه", DataType = Type.GetType("System.Double") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "AccountsInfo.AccountAVG2", Caption = "کل معدل", DataType = Type.GetType("System.Double") });

            var SelectedCustomers = tblMaster.AsEnumerable().Where(x => x["ReportDate"].ToString() == dates.Last() && Numeral.AnyToDouble(x["ContractsCount"]) == 0 && x["Rank"].ToString() == "رتبه 1" | x["Rank"].ToString() == "رتبه 2" | x["Rank"].ToString() == "رتبه 3" | x["Rank"].ToString() == "رتبه 4" | x["Rank"].ToString() == "رتبه 5").OrderByDescending(x => Numeral.AnyToDouble(x["AccountAVG2"]))
                               .Select(r => new
                               {
                                   BranchInfo = Branches.GetBranchById(r["BranchId"].ToString(), true),
                                   CustomerId = r["CustomerID"].ToString(),
                                   CustomerName = r["CustomerName"].ToString(),
                                   Rank = r["Rank"].ToString(),
                                   POSCount = Numeral.AnyToDouble(r["POSCount"]),
                                   TransactionCount = Numeral.AnyToDouble(r["TransactionCount"]),
                                   AccountAVG1 = Numeral.AnyToDouble(r["AccountAVG1"]),
                                   AccountAVG2 = Numeral.AnyToDouble(r["AccountAVG2"])
                               });

            foreach (var g in SelectedCustomers)
            {
                DataRow newRow = customersTable.NewRow();
                newRow["Province.ProvinceId"] = g.BranchInfo.Province.ProvinceId;
                newRow["Province.ProvinceName"] = g.BranchInfo.Province.ProvinceName;
                newRow["Domains.DomainId"] = g.BranchInfo.Domain.DomainId;
                newRow["Domains.DomainName"] = g.BranchInfo.Domain.DomainName;
                newRow["Branches.BranchId"] = g.BranchInfo.BranchId;
                newRow["Branches.BranchName"] = g.BranchInfo.BranchName;
                newRow["Branches.BranchDegree"] = g.BranchInfo.BranchDegree;
                newRow["Customers.CustomerId"] = g.CustomerId;
                newRow["Customers.CustomerName"] = g.CustomerName;
                newRow["PosInfo.Rank"] = g.Rank;
                newRow["PosInfo.POSCount"] = g.POSCount;
                newRow["PosInfo.TransactionCount"] = g.TransactionCount;
                newRow["AccountsInfo.AccountAVG1"] = g.AccountAVG1;
                newRow["AccountsInfo.AccountAVG2"] = g.AccountAVG2;
                customersTable.Rows.Add(newRow);
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
            for (int i = 1; i <= dates.Length; i++)
            {
                branchesTable.Columns.Add(new DataColumn { ColumnName = string.Format("Category{0}.Count1", i), Caption = "مشمولین", DataType = Type.GetType("System.Double") });
                branchesTable.Columns.Add(new DataColumn { ColumnName = string.Format("Category{0}.Count2", i), Caption = "پرداختی", DataType = Type.GetType("System.Double") });
                branchesTable.Columns.Add(new DataColumn { ColumnName = string.Format("Category{0}.Count3", i), Caption = "کل", DataType = Type.GetType("System.Double") });
                branchesTable.Columns.Add(new DataColumn { ColumnName = string.Format("Category{0}.NPL", i), Caption = "پرداختی/مشمولین", DataType = Type.GetType("System.Double") });
            }
            #endregion

            var groupByBranchId = tblMaster.AsEnumerable().GroupBy(dr => new { ReportDate = dr["ReportDate"].ToString(), BranchId = dr["BranchId"].ToString() })
                                       .Select(g => new
                                       {
                                           ReportDate = g.Key.ReportDate,
                                           BranchInfo = Branches.GetBranchById(g.Key.BranchId, true),
                                           Count1 = g.Count(x => Numeral.AnyToDouble(x["ContractsCount"]) == 0 && x["Rank"].ToString() == "رتبه 1" | x["Rank"].ToString() == "رتبه 2" | x["Rank"].ToString() == "رتبه 3" | x["Rank"].ToString() == "رتبه 4" | x["Rank"].ToString() == "رتبه 5"),
                                           Count2 = g.Count(x => Numeral.AnyToDouble(x["ContractsCount"]) > 0),
                                           Count3 = g.Count()
                                       }).GroupBy(dr => int.Parse(dr.BranchInfo.BranchId)).ToDictionary(g => g.Key, g => g);
           


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
                    int index = 0;
                    foreach (var i in row)
                    {
                        ++index;
                        newRow[string.Format("Category{0}.Count1", index)] = i.Count1;
                        newRow[string.Format("Category{0}.Count2", index)] = i.Count2;
                        newRow[string.Format("Category{0}.Count3", index)] = i.Count3;
                        newRow[string.Format("Category{0}.NPL", index)] = (Numeral.AnyToDouble(newRow[string.Format("Category{0}.Count2", index)]) / Numeral.AnyToDouble(newRow[string.Format("Category{0}.Count1", index)])) * 100;
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
                    {
                        newRow[string.Format("Category{0}.Count1", i)] = 0;
                        newRow[string.Format("Category{0}.Count2", i)] = 0;
                        newRow[string.Format("Category{0}.Count3", i)] = 0;
                        newRow[string.Format("Category{0}.NPL", i)] = 0;
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
            for (int i = 1; i <= dates.Length; i++)
            {
                domainsTable.Columns.Add(new DataColumn { ColumnName = string.Format("Category{0}.Count1", i), Caption = "مشمولین", DataType = Type.GetType("System.Double") });
                domainsTable.Columns.Add(new DataColumn { ColumnName = string.Format("Category{0}.Count2", i), Caption = "پرداختی", DataType = Type.GetType("System.Double") });
                domainsTable.Columns.Add(new DataColumn { ColumnName = string.Format("Category{0}.Count3", i), Caption = "کل", DataType = Type.GetType("System.Double") });
                domainsTable.Columns.Add(new DataColumn { ColumnName = string.Format("Category{0}.NPL", i), Caption = "پرداختی/مشمولین", DataType = Type.GetType("System.Double") });
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
                    for (int i = 1; i <= dates.Length; i++)
                    {
                        newRow[string.Format("Category{0}.Count1", i)] = brRows.Sum(x => Numeral.AnyToDouble(x[string.Format("Category{0}.Count1", i)]));
                        newRow[string.Format("Category{0}.Count2", i)] = brRows.Sum(x => Numeral.AnyToDouble(x[string.Format("Category{0}.Count2", i)]));
                        newRow[string.Format("Category{0}.Count3", i)] = brRows.Sum(x => Numeral.AnyToDouble(x[string.Format("Category{0}.Count3", i)]));
                        newRow[string.Format("Category{0}.NPL", i)] = (Numeral.AnyToDouble(newRow[string.Format("Category{0}.Count2", i)]) / Numeral.AnyToDouble(newRow[string.Format("Category{0}.Count1", i)])) * 100;
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
                    {
                        newRow[string.Format("Category{0}.Count1", i)] = 0;
                        newRow[string.Format("Category{0}.Count2", i)] = 0;
                        newRow[string.Format("Category{0}.Count3", i)] = 0;
                        newRow[string.Format("Category{0}.NPL", i)] = 0;
                    }
                    domainsTable.Rows.Add(newRow);
                }
            }

            #endregion

            #region Province Table

            DataTable provinceTable = new DataTable("Province");
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceId", Caption = "کد استان", DataType = Type.GetType("System.Int32") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceName", Caption = "نام استان", DataType = typeof(string) });
            for (int i = 1; i <= dates.Length; i++)
            {
                provinceTable.Columns.Add(new DataColumn { ColumnName = string.Format("Category{0}.Count1", i), Caption = "مشمولین", DataType = Type.GetType("System.Double") });
                provinceTable.Columns.Add(new DataColumn { ColumnName = string.Format("Category{0}.Count2", i), Caption = "پرداختی", DataType = Type.GetType("System.Double") });
                provinceTable.Columns.Add(new DataColumn { ColumnName = string.Format("Category{0}.Count3", i), Caption = "کل", DataType = Type.GetType("System.Double") });
                provinceTable.Columns.Add(new DataColumn { ColumnName = string.Format("Category{0}.NPL", i), Caption = "پرداختی/مشمولین", DataType = Type.GetType("System.Double") });
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
                    for (int i = 1; i <= dates.Length; i++)
                    {
                        newRow[string.Format("Category{0}.Count1", i)] = doRows.Sum(x => Numeral.AnyToDouble(x[string.Format("Category{0}.Count1", i)]));
                        newRow[string.Format("Category{0}.Count2", i)] = doRows.Sum(x => Numeral.AnyToDouble(x[string.Format("Category{0}.Count2", i)]));
                        newRow[string.Format("Category{0}.Count3", i)] = doRows.Sum(x => Numeral.AnyToDouble(x[string.Format("Category{0}.Count3", i)]));
                        newRow[string.Format("Category{0}.NPL", i)] = (Numeral.AnyToDouble(newRow[string.Format("Category{0}.Count2", i)]) / Numeral.AnyToDouble(newRow[string.Format("Category{0}.Count1", i)])) * 100;
                    }

                    provinceTable.Rows.Add(newRow);
                }
            }

            #endregion

            #region CustomersList Table
            DataTable customersListTable = customersTable.Copy();
            customersListTable.TableName = "CustomersList";
            #endregion

            #region Relations
            ds.Tables.Add(provinceTable);
            ds.Tables.Add(domainsTable);
            ds.Tables.Add(branchesTable);
            ds.Tables.Add(customersTable);
            ds.Tables.Add(customersListTable);

            ds.Relations.Add("حوزه ها", provinceTable.Columns["Province.ProvinceId"], domainsTable.Columns["Province.ProvinceId"]);
            ds.Relations.Add("شعب", domainsTable.Columns["Domains.DomainID"], branchesTable.Columns["Domains.DomainID"]);
            ds.Relations.Add("مشمولین", branchesTable.Columns["Branches.BranchID"], customersTable.Columns["Branches.BranchID"]);
            ds.Relations.Add("لیست مشمولین", provinceTable.Columns["Province.ProvinceId"], customersListTable.Columns["Province.ProvinceId"]);
            #endregion

            #region Extended Properties

            customersTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            customersTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            customersTable.Columns["Domains.DomainID"].ExtendedProperties["Visible"] = false;
            customersTable.Columns["Domains.DomainName"].ExtendedProperties["Visible"] = false;
            customersTable.Columns["Branches.BranchID"].ExtendedProperties["Visible"] = false;
            customersTable.Columns["Branches.BranchName"].ExtendedProperties["Visible"] = false;
            customersTable.Columns["Branches.BranchDegree"].ExtendedProperties["Visible"] = false;
            customersTable.Columns["PosInfo.POSCount"].ExtendedProperties.Add("FormatNumber", "N0");
            customersTable.Columns["PosInfo.TransactionCount"].ExtendedProperties.Add("FormatNumber", "N0");
            customersTable.Columns["AccountsInfo.AccountAVG1"].ExtendedProperties.Add("FormatNumber", "N0");
            customersTable.Columns["AccountsInfo.AccountAVG2"].ExtendedProperties.Add("FormatNumber", "N0");

            branchesTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Domains.DomainID"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Domains.DomainName"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Branches.BranchID"].ExtendedProperties["Visible"] = false;
            for (int i = 1; i <= dates.Length; i++)
            {
                branchesTable.Columns[string.Format("Category{0}.Count1", i)].ExtendedProperties.Add("FormatNumber", "N0");
                branchesTable.Columns[string.Format("Category{0}.Count2", i)].ExtendedProperties.Add("FormatNumber", "N0");
                branchesTable.Columns[string.Format("Category{0}.Count3", i)].ExtendedProperties.Add("FormatNumber", "N0");
                branchesTable.Columns[string.Format("Category{0}.NPL", i)].ExtendedProperties.Add("FormatNumber", "N1");
            }

            domainsTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            domainsTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            domainsTable.Columns["Domains.DomainID"].ExtendedProperties["Visible"] = false;
            for (int i = 1; i <= dates.Length; i++)
            {
                domainsTable.Columns[string.Format("Category{0}.Count1", i)].ExtendedProperties.Add("FormatNumber", "N0");
                domainsTable.Columns[string.Format("Category{0}.Count2", i)].ExtendedProperties.Add("FormatNumber", "N0");
                domainsTable.Columns[string.Format("Category{0}.Count3", i)].ExtendedProperties.Add("FormatNumber", "N0");
                domainsTable.Columns[string.Format("Category{0}.NPL", i)].ExtendedProperties.Add("FormatNumber", "N1");
            }


            provinceTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            for (int i = 1; i <= dates.Length; i++)
            {
                provinceTable.Columns[string.Format("Category{0}.Count1", i)].ExtendedProperties.Add("FormatNumber", "N0");
                provinceTable.Columns[string.Format("Category{0}.Count2", i)].ExtendedProperties.Add("FormatNumber", "N0");
                provinceTable.Columns[string.Format("Category{0}.Count3", i)].ExtendedProperties.Add("FormatNumber", "N0");
                provinceTable.Columns[string.Format("Category{0}.NPL", i)].ExtendedProperties.Add("FormatNumber", "N1");
            }


            customersListTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            customersListTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;

            ds.ExtendedProperties.Add("Bands", bands);
            ds.ExtendedProperties.Add("MainTable", provinceTable.TableName);
            #endregion

            return ds;
        }
    }
}
