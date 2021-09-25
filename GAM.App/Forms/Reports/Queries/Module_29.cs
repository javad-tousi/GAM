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
    class Module_29
    {
        public static DataSet Fill(DataTable tblMaster, string[] dates, QueryProperties properties)
        {
            #region Bands

            IDictionary<int, string> categoriesList = new Dictionary<int, string>();

            DataSet ds = new DataSet();
            GridViewManager gvm = new GridViewManager();
            List<GridBand> bands = new List<GridBand>();
            bands.Add(gvm.CreateBand("Province", "اطلاعات استان"));
            bands.Add(gvm.CreateBand("Domains", "اطلاعات حوزه"));
            bands.Add(gvm.CreateBand("Branches", "اطلاعات شعبه"));
            bands.Add(gvm.CreateBand("Request", "اطلاعات مصوبه"));
            bands.Add(gvm.CreateBand("CreditCommittee", "کمیته اعتباری"));

            int catNo = 1;
            foreach (string date in dates)
            {
                categoriesList.Add(int.Parse(date), "Cat" + catNo);
                bands.Add(gvm.CreateBand("Cat" + catNo, UDF.GetDateString(date), 113, 1));
                ++catNo;

            }
            bands.Add(gvm.CreateBand("Cat" + catNo, "جمع"));
            categoriesList.Add(0, "Cat" + catNo);

            #endregion

            #region Customers Table

            DataTable customersTable = new DataTable("Customers");
            customersTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceId", Caption = "کد استان", DataType = Type.GetType("System.Int32") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "CreditCommittee.Id", Caption = "کد مرجع", DataType = Type.GetType("System.Int32") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "CreditCommittee.Name", Caption = "نام مرجع" });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Request.CustomerName", Caption = "نام مشتری", DataType = Type.GetType("System.String") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Request.RequestId", Caption = "ش.پیشنهاد", DataType = Type.GetType("System.String") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Request.FacilityName", Caption = "نوع تسهیلات", DataType = Type.GetType("System.String") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Request.RequestDate", Caption = "تاریخ مصوبه", DataType = Type.GetType("System.String") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Request.RequestAmount", Caption = "مبلغ مصوبه", DataType = Type.GetType("System.Double") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Request.Status", Caption = "وضعیت", DataType = Type.GetType("System.String") });

            var SelectedCustomers = tblMaster.AsEnumerable().OrderByDescending(x => Numeral.AnyToDouble(x["RequestAmount"]))
                               .Select(r => new
                               {
                                   UnitId = r["BranchId"].ToString(),
                                   RequestId = r["RequestID"].ToString(),
                                   CustomerName = r["CustomerName"].ToString(),
                                   RequestDate = r["RequestDate"],
                                   RequestAmount = Numeral.AnyToDouble(r["RequestAmount"]),
                                   FacilityName = r["FacilityName"].ToString(),
                                   Status = r["RequestStatus"].ToString()
                               });

            foreach (var g in SelectedCustomers)
            {
                DataRow newRow = customersTable.NewRow();
                newRow["Province.ProvinceId"] = Users.MyProvinceID;
                newRow["CreditCommittee.Id"] = g.UnitId;
                newRow["CreditCommittee.Name"] = Branches.GetUnitNameById(g.UnitId);
                newRow["Request.CustomerName"] = g.CustomerName;
                newRow["Request.RequestId"] = g.RequestId;
                newRow["Request.FacilityName"] = g.FacilityName;
                newRow["Request.RequestDate"] = g.RequestDate;
                newRow["Request.RequestAmount"] = g.RequestAmount;
                newRow["Request.Status"] = g.Status;
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
            foreach (var cat in categoriesList)
            {
                if (cat.Key > 0)
                {
                    branchesTable.Columns.Add(new DataColumn { ColumnName = cat.Value + ".Count", Caption = "تعداد", DataType = Type.GetType("System.Int32"), Namespace = UDF.GetDateString(cat.Key.ToString()) });
                    branchesTable.Columns.Add(new DataColumn { ColumnName = cat.Value + ".Total", Caption = "مبلغ", DataType = Type.GetType("System.Double"), Namespace = UDF.GetDateString(cat.Key.ToString()) });
                }
                else
                {
                    branchesTable.Columns.Add(new DataColumn { ColumnName = cat.Value + ".Count", Caption = "تعداد", DataType = Type.GetType("System.Int32") });
                    branchesTable.Columns.Add(new DataColumn { ColumnName = cat.Value + ".Total", Caption = "مبلغ", DataType = Type.GetType("System.Double") });
                }
            }
            #endregion

            var groupByBranchId = tblMaster.AsEnumerable().GroupBy(dr => new { BranchId = dr["BranchID"].ToString() })
                                   .Select(g => new
                                   {
                                       BranchId = int.Parse(g.Key.BranchId),
                                       Values = g,
                                       SubCount = g.Count(),
                                       SubTotal = g.Sum(x => Numeral.AnyToDouble(x["RequestAmount"])),
                                   }).Where(x => x.BranchId > 0).ToDictionary(x => x.BranchId, x => x);


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
                    foreach (var cat in categoriesList)
                    {
                        if (cat.Key > 0)
                        {
                            newRow[cat.Value + ".Count"] = row.Values.Where(x => int.Parse(x["ReportDate"].ToString()) == cat.Key).Count();
                            newRow[cat.Value + ".Total"] = row.Values.Where(x => int.Parse(x["ReportDate"].ToString()) == cat.Key).Sum(x => Numeral.AnyToDouble(x["RequestAmount"]));
                        }
                        else
                        {
                            newRow[cat.Value + ".Count"] = row.SubCount;
                            newRow[cat.Value + ".Total"] = row.SubTotal;
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

            foreach (Branches.DomainInfo di in Branches.GetDomains())
            {
                int domainId = int.Parse(di.DomainId);
                if (groupByBranchId.ContainsKey(domainId))
                {
                    var row = groupByBranchId[domainId];
                    DataRow newRow = domainsTable.NewRow();
                    newRow["Province.ProvinceId"] = di.Province.ProvinceId;
                    newRow["Province.ProvinceName"] = di.Province.ProvinceName;
                    newRow["Domains.DomainId"] = di.DomainId;
                    newRow["Domains.DomainName"] = di.DomainName;

                    foreach (var cat in categoriesList)
                    {
                        if (cat.Key > 0)
                        {
                            newRow[cat.Value + ".Count"] = row.Values.Where(x => int.Parse(x["ReportDate"].ToString()) == cat.Key).Count();
                            newRow[cat.Value + ".Total"] = row.Values.Where(x => int.Parse(x["ReportDate"].ToString()) == cat.Key).Sum(x => Numeral.AnyToDouble(x["RequestAmount"]));
                        }
                        else
                        {
                            newRow[cat.Value + ".Count"] = row.SubCount;
                            newRow[cat.Value + ".Total"] = row.SubTotal;
                        }
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

            foreach (Branches.ProvinceInfo pi in Branches.GetProvincesByZoneId(Users.MyZoneID))
            {
                if (Users.MyProvinceID.Length > 0 & pi.ProvinceId != Users.MyProvinceID)
                    continue;

                int provinceId = int.Parse(pi.ProvinceId);
                if (groupByBranchId.ContainsKey(provinceId))
                {
                    var row = groupByBranchId[provinceId];
                    DataRow newRow = provinceTable.NewRow();
                    newRow["Province.ProvinceId"] = pi.ProvinceId;
                    newRow["Province.ProvinceName"] = pi.ProvinceName;
                    foreach (var cat in categoriesList)
                    {
                        if (cat.Key > 0)
                        {
                            newRow[cat.Value + ".Count"] = row.Values.Where(x => int.Parse(x["ReportDate"].ToString()) == cat.Key).Count();
                            newRow[cat.Value + ".Total"] = row.Values.Where(x => int.Parse(x["ReportDate"].ToString()) == cat.Key).Sum(x => Numeral.AnyToDouble(x["RequestAmount"]));
                        }
                        else
                        {
                            newRow[cat.Value + ".Count"] = row.SubCount;
                            newRow[cat.Value + ".Total"] = row.SubTotal;
                        }
                    }
                    provinceTable.Rows.Add(newRow);
                }
            }

            #endregion

            #region Relations

            ds.Tables.Add(provinceTable);
            ds.Tables.Add(domainsTable);
            ds.Tables.Add(branchesTable);
            ds.Tables.Add(customersTable);

            ds.Relations.Add("حوزه ها", provinceTable.Columns["Province.ProvinceId"], domainsTable.Columns["Province.ProvinceId"]);
            ds.Relations.Add("شعب", domainsTable.Columns["Domains.DomainID"], branchesTable.Columns["Domains.DomainID"]);
            ds.Relations.Add("ریز مصوبات", provinceTable.Columns["Province.ProvinceId"], customersTable.Columns["Province.ProvinceId"]);
            #endregion

            #region Extended Properties
            customersTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            customersTable.Columns["Request.RequestAmount"].ExtendedProperties.Add("FormatNumber", "N0");

            branchesTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Domains.DomainID"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Domains.DomainName"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Branches.BranchID"].ExtendedProperties["Visible"] = false;
            foreach (var cat in categoriesList)
            {
                branchesTable.Columns[cat.Value + ".Count"].ExtendedProperties.Add("FormatNumber", "N0");
                branchesTable.Columns[cat.Value + ".Total"].ExtendedProperties.Add("FormatNumber", "N0");
            }

            domainsTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            domainsTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            domainsTable.Columns["Domains.DomainID"].ExtendedProperties["Visible"] = false;
            foreach (var cat in categoriesList)
            {
                domainsTable.Columns[cat.Value + ".Count"].ExtendedProperties.Add("FormatNumber", "N0");
                domainsTable.Columns[cat.Value + ".Total"].ExtendedProperties.Add("FormatNumber", "N0");
            }


            provinceTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            foreach (var cat in categoriesList)
            {
                provinceTable.Columns[cat.Value + ".Count"].ExtendedProperties.Add("FormatNumber", "N0");
                provinceTable.Columns[cat.Value + ".Total"].ExtendedProperties.Add("FormatNumber", "N0");
            }

           ds.ExtendedProperties.Add("Bands", bands);
            ds.ExtendedProperties.Add("MainTable", provinceTable.TableName);
            #endregion

            return ds;
        }
    }
}
