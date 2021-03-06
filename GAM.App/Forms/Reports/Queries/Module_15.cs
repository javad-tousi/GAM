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
    class Module_15
    {
        public static DataSet Fill(DataTable tblMaster, string[] dates, QueryProperties properties)
        {
            #region Bands

            var categories = Categories.ByAmount2().OrderBy(x => x.CategoryId).Select(x => new { x.CategoryId, x.CategoryName }).Distinct();
            IDictionary<int, string> categoriesList = new Dictionary<int, string>();

            DataSet ds = new DataSet();
            GridViewManager gvm = new GridViewManager();
            List<GridBand> bands = new List<GridBand>();
            bands.Add(gvm.CreateBand("Province", "اطلاعات استان"));
            bands.Add(gvm.CreateBand("Domains", "اطلاعات حوزه"));
            bands.Add(gvm.CreateBand("Branches", "اطلاعات شعبه"));
            bands.Add(gvm.CreateBand("Customers", "اطلاعات بدهکار"));
            bands.Add(gvm.CreateBand("Categories", "دسته بندی"));
            bands.Add(gvm.CreateBand("SumOfDebt", "جمع مانده در مطالبات به تاریخ " + UDF.GetDateString(dates[0])));
            bands.Add(gvm.CreateBand("Subtotal", "جمع کل"));

            int catNo = 0;
            foreach (var cat in categories)
            {
                ++catNo;
                categoriesList.Add(cat.CategoryId, "Cat" + catNo);
                bands.Add(gvm.CreateBand("Cat" + catNo, cat.CategoryName, 110));
            }
            #endregion

            #region Customers Table

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
            customersTable.Columns.Add(new DataColumn { ColumnName = "Customers.CountOfContracts", Caption = "ت.پرونده", DataType = Type.GetType("System.Int32") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehSarresid", Caption = "سررسیدگذشته", DataType = Type.GetType("System.Double") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehMoavagh", Caption = "معوق", DataType = Type.GetType("System.Double") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehMashkook", Caption = "مشکوک الوصول", DataType = Type.GetType("System.Double") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehGheyreJari", Caption = "جمع", DataType = Type.GetType("System.Double") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Categories.CategoryId", Caption = "کد", DataType = Type.GetType("System.Int32") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Categories.CategoryName", Caption = "دسته بندی", DataType = Type.GetType("System.String") });

            var GroupByCustomer = tblMaster.AsEnumerable().GroupBy(dr => new { CustomerId = dr["CustomerID"].ToString(), BranchId = dr["BranchID"].ToString() })
                               .Select(g => new
                               {
                                   BranchInfo = Branches.GetBranchById(g.Key.BranchId, true),
                                   CustomerId = g.Key.CustomerId,
                                   CustomerName = g.First()["CustomerName"].ToString(),
                                   MandehSarresid = g.Sum(x => Numeral.AnyToDouble(x["MandehSarresid"])),
                                   MandehMoavagh = g.Sum(x => Numeral.AnyToDouble(x["MandehMoavagh"])),
                                   MandehMashkook = g.Sum(x => Numeral.AnyToDouble(x["MandehMashkook"])),
                                   MandehGheyreJari = g.Sum(x => Numeral.AnyToDouble(x["MandehGheyreJari"])),
                                   Category = Categories.GetCategory(Categories.ByAmount1(), g.Sum(x => Numeral.AnyToDouble(x["MandehGheyreJari"]))),
                               }).OrderByDescending(x => x.MandehGheyreJari);

            foreach (var g in GroupByCustomer)
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
                newRow["SumOfDebt.MandehSarresid"] = g.MandehSarresid;
                newRow["SumOfDebt.MandehMoavagh"] = g.MandehMoavagh;
                newRow["SumOfDebt.MandehMashkook"] = g.MandehMashkook;
                newRow["SumOfDebt.MandehGheyreJari"] = g.MandehGheyreJari;
                newRow["Categories.CategoryId"] = g.Category.CategoryId;
                newRow["Categories.CategoryName"] = g.Category.CategoryName;

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
            foreach (var item in categoriesList)
            {
                branchesTable.Columns.Add(new DataColumn { ColumnName = item.Value + ".Count", Caption = "تعداد", DataType = Type.GetType("System.Int32") });
                branchesTable.Columns.Add(new DataColumn { ColumnName = item.Value + ".Total", Caption = "مبلغ", DataType = Type.GetType("System.Double") });
            }
            branchesTable.Columns.Add(new DataColumn { ColumnName = "Subtotal.Count", Caption = "تعداد", DataType = Type.GetType("System.Int32") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "Subtotal.Total", Caption = "مبلغ", DataType = Type.GetType("System.Double") });
            #endregion

            var groupByBranchId = customersTable.AsEnumerable().GroupBy(dr => new { BranchId = dr["Branches.BranchId"].ToString() })
                                   .Select(g => new
                                   {
                                       BranchInfo = Branches.GetBranchById(g.Key.BranchId, true),
                                       Values = g,
                                       SubCount = g.Count(),
                                       SubTotal = g.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehGheyreJari"])),
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
                    newRow["Subtotal.Count"] = row.SubCount;
                    newRow["Subtotal.Total"] = row.SubTotal;

                    foreach (var item in categoriesList)
                    {
                        if (item.Key > 0)
                        {
                            newRow[item.Value + ".Count"] = row.Values.Where(x => int.Parse(x["Categories.CategoryId"].ToString()) == item.Key).Count();
                            newRow[item.Value + ".Total"] = row.Values.Where(x => int.Parse(x["Categories.CategoryId"].ToString()) == item.Key).Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehGheyreJari"]));
                        }
                        else
                        {
                            newRow[item.Value + ".Count"] = row.SubCount;
                            newRow[item.Value + ".Total"] = row.SubTotal;
                        }
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
                    foreach (var item in categoriesList)
                    {
                        newRow[item.Value + ".Count"] = 0;
                        newRow[item.Value + ".Total"] = 0;
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
            foreach (var item in categoriesList)
            {
                domainsTable.Columns.Add(new DataColumn { ColumnName = item.Value + ".Count", Caption = "تعداد", DataType = Type.GetType("System.Int32") });
                domainsTable.Columns.Add(new DataColumn { ColumnName = item.Value + ".Total", Caption = "مبلغ", DataType = Type.GetType("System.Double") });
            }
            domainsTable.Columns.Add(new DataColumn { ColumnName = "Subtotal.Count", Caption = "تعداد", DataType = Type.GetType("System.Int32") });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "Subtotal.Total", Caption = "مبلغ", DataType = Type.GetType("System.Double") });

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
                    newRow["Subtotal.Count"] = brRows.Sum(x => Numeral.AnyToDouble(x["Subtotal.Count"]));
                    newRow["Subtotal.Total"] = brRows.Sum(x => Numeral.AnyToDouble(x["Subtotal.Total"]));

                    foreach (var item in categoriesList)
                    {
                        newRow[item.Value + ".Count"] = brRows.Sum(x => Numeral.AnyToDouble(x[item.Value + ".Count"]));
                        newRow[item.Value + ".Total"] = brRows.Sum(x => Numeral.AnyToDouble(x[item.Value + ".Total"]));
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
                    foreach (var item in categoriesList)
                    {
                        newRow[item.Value + ".Count"] = 0;
                        newRow[item.Value + ".Total"] = 0;
                    }
                    domainsTable.Rows.Add(newRow);
                }
            }

            #endregion

            #region Province Table

            DataTable provinceTable = new DataTable("Province");
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceId", Caption = "کد استان", DataType = Type.GetType("System.Int32") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceName", Caption = "نام استان", DataType = typeof(string) });
            foreach (var item in categoriesList)
            {
                provinceTable.Columns.Add(new DataColumn { ColumnName = item.Value + ".Count", Caption = "تعداد", DataType = Type.GetType("System.Int32") });
                provinceTable.Columns.Add(new DataColumn { ColumnName = item.Value + ".Total", Caption = "مبلغ", DataType = Type.GetType("System.Double") });
            }
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Subtotal.Count", Caption = "تعداد", DataType = Type.GetType("System.Int32") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Subtotal.Total", Caption = "مبلغ", DataType = Type.GetType("System.Double") });

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
                    newRow["Subtotal.Count"] = doRows.Sum(x => Numeral.AnyToDouble(x["Subtotal.Count"]));
                    newRow["Subtotal.Total"] = doRows.Sum(x => Numeral.AnyToDouble(x["Subtotal.Total"]));

                    foreach (var item in categoriesList)
                    {
                        newRow[item.Value + ".Count"] = doRows.Sum(x => Numeral.AnyToDouble(x[item.Value + ".Count"]));
                        newRow[item.Value + ".Total"] = doRows.Sum(x => Numeral.AnyToDouble(x[item.Value + ".Total"]));
                    }
                    provinceTable.Rows.Add(newRow);
                }
            }

            #endregion

            #region Customers List
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
            ds.Relations.Add("بدهکاران", branchesTable.Columns["Branches.BranchID"], customersTable.Columns["Branches.BranchID"]);
            ds.Relations.Add("لیست بدهکاران", provinceTable.Columns["Province.ProvinceId"], customersListTable.Columns["Province.ProvinceId"]);
            #endregion

            #region Extended Properties

            customersTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            customersTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            customersTable.Columns["Domains.DomainID"].ExtendedProperties["Visible"] = false;
            customersTable.Columns["Domains.DomainName"].ExtendedProperties["Visible"] = false;
            customersTable.Columns["Branches.BranchID"].ExtendedProperties["Visible"] = false;
            customersTable.Columns["Branches.BranchName"].ExtendedProperties["Visible"] = false;
            customersTable.Columns["Branches.BranchDegree"].ExtendedProperties["Visible"] = false;
            customersTable.Columns["SumOfDebt.MandehSarresid"].ExtendedProperties.Add("FormatNumber", "N0");
            customersTable.Columns["SumOfDebt.MandehMoavagh"].ExtendedProperties.Add("FormatNumber", "N0");
            customersTable.Columns["SumOfDebt.MandehMashkook"].ExtendedProperties.Add("FormatNumber", "N0");
            customersTable.Columns["SumOfDebt.MandehGheyreJari"].ExtendedProperties.Add("FormatNumber", "N0");

            branchesTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Domains.DomainID"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Domains.DomainName"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Branches.BranchID"].ExtendedProperties["Visible"] = false;
            foreach (var item in categoriesList)
            {
                branchesTable.Columns[item.Value + ".Count"].ExtendedProperties.Add("FormatNumber", "N0");
                branchesTable.Columns[item.Value + ".Total"].ExtendedProperties.Add("FormatNumber", "N0");
            }
            branchesTable.Columns["Subtotal.Count"].ExtendedProperties.Add("FormatNumber", "N0");
            branchesTable.Columns["Subtotal.Total"].ExtendedProperties.Add("FormatNumber", "N0");

            domainsTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            domainsTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            domainsTable.Columns["Domains.DomainID"].ExtendedProperties["Visible"] = false;
            foreach (var item in categoriesList)
            {
                domainsTable.Columns[item.Value + ".Count"].ExtendedProperties.Add("FormatNumber", "N0");
                domainsTable.Columns[item.Value + ".Total"].ExtendedProperties.Add("FormatNumber", "N0");
            }
            domainsTable.Columns["Subtotal.Count"].ExtendedProperties.Add("FormatNumber", "N0");
            domainsTable.Columns["Subtotal.Total"].ExtendedProperties.Add("FormatNumber", "N0");

            provinceTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            foreach (var item in categoriesList)
            {
                provinceTable.Columns[item.Value + ".Count"].ExtendedProperties.Add("FormatNumber", "N0");
                provinceTable.Columns[item.Value + ".Total"].ExtendedProperties.Add("FormatNumber", "N0");
            }
            provinceTable.Columns["Subtotal.Count"].ExtendedProperties.Add("FormatNumber", "N0");
            provinceTable.Columns["Subtotal.Total"].ExtendedProperties.Add("FormatNumber", "N0");

            customersListTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            customersListTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            customersListTable.Columns["SumOfDebt.MandehSarresid"].ExtendedProperties.Add("FormatNumber", "N0");
            customersListTable.Columns["SumOfDebt.MandehMoavagh"].ExtendedProperties.Add("FormatNumber", "N0");
            customersListTable.Columns["SumOfDebt.MandehMashkook"].ExtendedProperties.Add("FormatNumber", "N0");
            customersListTable.Columns["SumOfDebt.MandehGheyreJari"].ExtendedProperties.Add("FormatNumber", "N0");

            ds.ExtendedProperties.Add("Bands", bands);
            ds.ExtendedProperties.Add("MainTable", provinceTable.TableName);
            #endregion

            return ds;
        }
    }
}
