using DevExpress.XtraGrid.Views.BandedGrid;
using GAM.Forms.Information.Library;
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
    class Module_04
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
            bands.Add(gvm.CreateBand("SumOfDebt", "جمع مانده در مطالبات به تاریخ " + UDF.GetDateString(dates[3])));
            bands.Add(gvm.CreateBand("DebtRange", "بازه ایجاد مطالبات از تاریخ " + UDF.GetDateString(dates[3])));

            #region گروه بندی مشتریان
            DataTable baseTable = new DataTable();
            baseTable = tblMaster.Clone();
            baseTable.Columns.Add(new DataColumn { ColumnName = "Date1_VS_Date2" });
            baseTable.Columns.Add(new DataColumn { ColumnName = "Date2_VS_Date3" });
            baseTable.Columns.Add(new DataColumn { ColumnName = "Date3_VS_Date4" });

            var GroupByContractId = tblMaster.AsEnumerable().Where(x => Numeral.AnyToDouble(x["MandehAsl"]) > 0).GroupBy(dr => new { ContractID = dr["ContractID"] })
                               .Select(g => new
                               {
                                   values = g.ToArray(),
                               });

            int countColumns = tblMaster.Columns.Count;

            foreach (var g in GroupByContractId)
            {
                DataRow newRow = baseTable.NewRow();
                newRow["Date1_VS_Date2"] = "";
                newRow["Date2_VS_Date3"] = "";
                newRow["Date3_VS_Date4"] = "";

                DataRow date1_Row = g.values.Where(r => r["ReportDate"].ToString() == dates[0]).FirstOrDefault();
                DataRow date2_Row = g.values.Where(r => r["ReportDate"].ToString() == dates[1]).FirstOrDefault();
                DataRow date3_Row = g.values.Where(r => r["ReportDate"].ToString() == dates[2]).FirstOrDefault();
                DataRow date4_Row = g.values.Where(r => r["ReportDate"].ToString() == dates[3]).FirstOrDefault();


                DataRow customerRow = null;

                if (date1_Row == null & date4_Row != null)
                {
                    if (date2_Row != null)
                    {
                        newRow["Date1_VS_Date2"] = "*";
                        customerRow = date4_Row;
                    }
                    else if (date3_Row != null)
                    {
                        newRow["Date1_VS_Date2"] = "";
                        newRow["Date2_VS_Date3"] = "*";
                        customerRow = date4_Row;
                    }
                    else if (date4_Row != null)
                    {
                        newRow["Date1_VS_Date2"] = "";
                        newRow["Date2_VS_Date3"] = "";
                        newRow["Date3_VS_Date4"] = "*";
                        customerRow = date4_Row;
                    }

                    for (int i = 0; i < countColumns; i++)
                    {
                        newRow[tblMaster.Columns[i].ColumnName] = customerRow[tblMaster.Columns[i].ColumnName];
                    }

                    baseTable.Rows.Add(newRow);
                }
            }

            DataTable customersTable = new DataTable("Customers");

            if (baseTable.Rows.Count > 0)
            {
                customersTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceId", Caption = "کد استان", DataType = Type.GetType("System.Int32") });
                customersTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceName", Caption = "نام استان", DataType = typeof(string) });
                customersTable.Columns.Add(new DataColumn { ColumnName = "Domains.DomainId", Caption = "کد حوزه", DataType = Type.GetType("System.Int32") });
                customersTable.Columns.Add(new DataColumn { ColumnName = "Domains.DomainName", Caption = "نام حوزه", DataType = Type.GetType("System.String") });
                customersTable.Columns.Add(new DataColumn { ColumnName = "Branches.BranchId", Caption = "کد شعبه", DataType = Type.GetType("System.Int32") });
                customersTable.Columns.Add(new DataColumn { ColumnName = "Branches.BranchName", Caption = "نام شعبه" });
                customersTable.Columns.Add(new DataColumn { ColumnName = "Branches.BranchDegree", Caption = "درجه" });
                customersTable.Columns.Add(new DataColumn { ColumnName = "Customers.CustomerId", Caption = "شماره مشتری", DataType = Type.GetType("System.String") });
                customersTable.Columns.Add(new DataColumn { ColumnName = "Customers.CustomerName", Caption = "نام بدهکار", DataType = Type.GetType("System.String") });
                customersTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.CountOfContracts", Caption = "تعداد قرارداد", DataType = Type.GetType("System.Int32") });
                customersTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehAsl", Caption = "اصل", DataType = Type.GetType("System.Double") });
                customersTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehSood", Caption = "سود", DataType = Type.GetType("System.Double") });
                customersTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehJarimeh", Caption = "جریمه", DataType = Type.GetType("System.Double") });
                customersTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.Total", Caption = "جمع", DataType = Type.GetType("System.Double") });
                customersTable.Columns.Add(new DataColumn { ColumnName = "DebtRange.Mandeh1", Caption = UDF.GetDateString(dates[0]), DataType = Type.GetType("System.Double") });
                customersTable.Columns.Add(new DataColumn { ColumnName = "DebtRange.Mandeh2", Caption = UDF.GetDateString(dates[1]), DataType = Type.GetType("System.Double") });
                customersTable.Columns.Add(new DataColumn { ColumnName = "DebtRange.Mandeh3", Caption = UDF.GetDateString(dates[2]), DataType = Type.GetType("System.Double") });

                var GroupByCustomer = baseTable.AsEnumerable().OrderByDescending(x => Numeral.AnyToDouble(x["MandehAslVaSoodVaJarimeh"])).GroupBy(dr => new { CustomerId = dr["CustomerID"].ToString(), BranchId = dr["BranchID"].ToString() })
                                   .Select(g => new
                                   {
                                       BranchInfo = Branches.GetBranchById(g.Key.BranchId, true),
                                       CustomerId = g.Key.CustomerId,
                                       CustomerName = g.First()["CustomerName"].ToString(),
                                       CountOfContracts = g.Count(x => Numeral.AnyToDouble(x["MandehAsl"]) > 0),
                                       MandehAsl = g.Sum(x => Numeral.AnyToDouble(x["MandehAsl"])),
                                       MandehSood = g.Sum(x => Numeral.AnyToDouble(x["MandehSood"])),
                                       MandehJarimeh = g.Sum(x => Numeral.AnyToDouble(x["MandehJarimeh"])),
                                       Mandeh1 = g.Where(x => x["Date1_VS_Date2"].ToString() == "*").Sum(x => Numeral.AnyToDouble(x["MandehAslVaSoodVaJarimeh"])),
                                       Mandeh2 = g.Where(x => x["Date2_VS_Date3"].ToString() == "*").Sum(x => Numeral.AnyToDouble(x["MandehAslVaSoodVaJarimeh"])),
                                       Mandeh3 = g.Where(x => x["Date3_VS_Date4"].ToString() == "*").Sum(x => Numeral.AnyToDouble(x["MandehAslVaSoodVaJarimeh"])),
                                   });

                foreach (var g in GroupByCustomer)
                {
                    if (g.Mandeh1 > 0 | g.Mandeh2 > 0 | g.Mandeh3 > 0)
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
                        newRow["SumOfDebt.CountOfContracts"] = g.CountOfContracts;
                        newRow["SumOfDebt.MandehAsl"] = g.MandehAsl;
                        newRow["SumOfDebt.MandehSood"] = g.MandehSood;
                        newRow["SumOfDebt.MandehJarimeh"] = g.MandehJarimeh;
                        newRow["SumOfDebt.Total"] = g.MandehAsl + g.MandehSood + g.MandehJarimeh;
                        newRow["DebtRange.Mandeh1"] = g.Mandeh1;
                        newRow["DebtRange.Mandeh2"] = g.Mandeh2;
                        newRow["DebtRange.Mandeh3"] = g.Mandeh3;
                        customersTable.Rows.Add(newRow);
                    }
                }
            }

            #endregion

            #region ساخت شعب

            #region ساخت ستون ها
            DataTable branchesTable = new DataTable("Branches");
            branchesTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceId", Caption = "کد استان", DataType = Type.GetType("System.Int32") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceName", Caption = "نام استان", DataType = typeof(string) });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "Domains.DomainId", Caption = "کد حوزه", DataType = Type.GetType("System.Int32") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "Domains.DomainName", Caption = "نام حوزه", DataType = Type.GetType("System.String") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "Branches.BranchId", Caption = "کد شعبه", DataType = Type.GetType("System.Int32") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "Branches.BranchName", Caption = "نام شعبه" });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "Branches.BranchDegree", Caption = "درجه" });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.CountOfCustomers", Caption = "تعداد بدهکاران", DataType = Type.GetType("System.Double") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehAsl", Caption = "اصل", DataType = Type.GetType("System.Double") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehSood", Caption = "سود", DataType = Type.GetType("System.Double") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehJarimeh", Caption = "جریمه", DataType = Type.GetType("System.Double") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.Total", Caption = "جمع", DataType = Type.GetType("System.Double") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "DebtRange.Mandeh1", Caption = UDF.GetDateString(dates[0]), DataType = Type.GetType("System.Double") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "DebtRange.Mandeh2", Caption = UDF.GetDateString(dates[1]), DataType = Type.GetType("System.Double") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "DebtRange.Mandeh3", Caption = UDF.GetDateString(dates[2]), DataType = Type.GetType("System.Double") });
            #endregion

            var groupByBranchId = customersTable.AsEnumerable().GroupBy(dr => new { BranchId = dr["Branches.BranchId"].ToString() })
                                   .Select(g => new
                                   {
                                       BranchInfo = Branches.GetBranchById(g.Key.BranchId, true),
                                       CountOfCustomers = g.Count(),
                                       MandehAsl = g.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehAsl"])),
                                       MandehSood = g.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehSood"])),
                                       MandehJarimeh = g.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehJarimeh"])),
                                       Mandeh1 = g.Sum(x => Numeral.AnyToDouble(x["DebtRange.Mandeh1"])),
                                       Mandeh2 = g.Sum(x => Numeral.AnyToDouble(x["DebtRange.Mandeh2"])),
                                       Mandeh3 = g.Sum(x => Numeral.AnyToDouble(x["DebtRange.Mandeh3"]))
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
                    newRow["SumOfDebt.CountOfCustomers"] = row.CountOfCustomers;
                    newRow["SumOfDebt.MandehAsl"] = row.MandehAsl;
                    newRow["SumOfDebt.MandehSood"] = row.MandehSood;
                    newRow["SumOfDebt.MandehJarimeh"] = row.MandehJarimeh;
                    newRow["SumOfDebt.Total"] = row.MandehAsl + row.MandehSood + row.MandehJarimeh;
                    newRow["DebtRange.Mandeh1"] = row.Mandeh1;
                    newRow["DebtRange.Mandeh2"] = row.Mandeh2;
                    newRow["DebtRange.Mandeh3"] = row.Mandeh3;
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
                    newRow["SumOfDebt.CountOfCustomers"] = 0;
                    newRow["SumOfDebt.MandehAsl"] = 0;
                    newRow["SumOfDebt.MandehSood"] = 0;
                    newRow["SumOfDebt.MandehJarimeh"] = 0;
                    newRow["SumOfDebt.Total"] = 0;
                    newRow["DebtRange.Mandeh1"] = 0;
                    newRow["DebtRange.Mandeh2"] = 0;
                    newRow["DebtRange.Mandeh3"] = 0;
                    branchesTable.Rows.Add(newRow);
                }
            }

            #endregion

            #region ساخت حوزه ها
            DataTable domainsTable = new DataTable("Domains");
            domainsTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceId", Caption = "کد استان", DataType = Type.GetType("System.Int32") });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceName", Caption = "نام استان", DataType = typeof(string) });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "Domains.DomainId", Caption = "کد حوزه", DataType = Type.GetType("System.Int32") });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "Domains.DomainName", Caption = "نام حوزه", DataType = Type.GetType("System.String") });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.CountOfCustomers", Caption = "تعداد بدهکاران", DataType = Type.GetType("System.Double") });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehAsl", Caption = "اصل", DataType = Type.GetType("System.Double") });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehSood", Caption = "سود", DataType = Type.GetType("System.Double") });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehJarimeh", Caption = "جریمه", DataType = Type.GetType("System.Double") });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.Total", Caption = "جمع", DataType = Type.GetType("System.Double") });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "DebtRange.Mandeh1", Caption = UDF.GetDateString(dates[0]), DataType = Type.GetType("System.Double") });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "DebtRange.Mandeh2", Caption = UDF.GetDateString(dates[1]), DataType = Type.GetType("System.Double") });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "DebtRange.Mandeh3", Caption = UDF.GetDateString(dates[2]), DataType = Type.GetType("System.Double") });

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
                    newRow["SumOfDebt.CountOfCustomers"] = brRows.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.CountOfCustomers"]));
                    newRow["SumOfDebt.MandehAsl"] = brRows.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehAsl"]));
                    newRow["SumOfDebt.MandehSood"] = brRows.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehSood"]));
                    newRow["SumOfDebt.MandehJarimeh"] = brRows.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehJarimeh"]));
                    newRow["SumOfDebt.Total"] = brRows.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.Total"]));
                    newRow["DebtRange.Mandeh1"] = brRows.Sum(x => Numeral.AnyToDouble(x["DebtRange.Mandeh1"]));
                    newRow["DebtRange.Mandeh2"] = brRows.Sum(x => Numeral.AnyToDouble(x["DebtRange.Mandeh2"]));
                    newRow["DebtRange.Mandeh3"] = brRows.Sum(x => Numeral.AnyToDouble(x["DebtRange.Mandeh3"]));
                    domainsTable.Rows.Add(newRow);
                }
                else
                {
                    DataRow newRow = domainsTable.NewRow();
                    newRow["Province.ProvinceId"] = di.Province.ProvinceId;
                    newRow["Province.ProvinceName"] = di.Province.ProvinceName;
                    newRow["Domains.DomainId"] = di.DomainId;
                    newRow["Domains.DomainName"] = di.DomainName;
                    newRow["SumOfDebt.CountOfCustomers"] = 0;
                    newRow["SumOfDebt.MandehAsl"] = 0;
                    newRow["SumOfDebt.MandehSood"] = 0;
                    newRow["SumOfDebt.MandehJarimeh"] = 0;
                    newRow["SumOfDebt.Total"] = 0;
                    newRow["DebtRange.Mandeh1"] = 0;
                    newRow["DebtRange.Mandeh2"] = 0;
                    newRow["DebtRange.Mandeh3"] = 0;
                    domainsTable.Rows.Add(newRow);
                }
            }
           
            #endregion

            #region ساخت استان
            DataTable provinceTable = new DataTable("Province");
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceId", Caption = "کد استان", DataType = Type.GetType("System.Int32") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceName", Caption = "نام استان", DataType = typeof(string) });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.CountOfCustomers", Caption = "تعداد بدهکاران", DataType = Type.GetType("System.Double") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehAsl", Caption = "اصل", DataType = Type.GetType("System.Double") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehSood", Caption = "سود", DataType = Type.GetType("System.Double") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehJarimeh", Caption = "جریمه", DataType = Type.GetType("System.Double") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.Total", Caption = "جمع", DataType = Type.GetType("System.Double") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "DebtRange.Mandeh1", Caption = UDF.GetDateString(dates[0]), DataType = Type.GetType("System.Double") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "DebtRange.Mandeh2", Caption = UDF.GetDateString(dates[1]), DataType = Type.GetType("System.Double") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "DebtRange.Mandeh3", Caption = UDF.GetDateString(dates[2]), DataType = Type.GetType("System.Double") });

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
                    newRow["SumOfDebt.CountOfCustomers"] = doRows.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.CountOfCustomers"]));
                    newRow["SumOfDebt.MandehAsl"] = doRows.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehAsl"]));
                    newRow["SumOfDebt.MandehSood"] = doRows.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehSood"]));
                    newRow["SumOfDebt.MandehJarimeh"] = doRows.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehJarimeh"]));
                    newRow["SumOfDebt.Total"] = doRows.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.Total"]));
                    newRow["DebtRange.Mandeh1"] = doRows.Sum(x => Numeral.AnyToDouble(x["DebtRange.Mandeh1"]));
                    newRow["DebtRange.Mandeh2"] = doRows.Sum(x => Numeral.AnyToDouble(x["DebtRange.Mandeh2"]));
                    newRow["DebtRange.Mandeh3"] = doRows.Sum(x => Numeral.AnyToDouble(x["DebtRange.Mandeh3"]));
                    provinceTable.Rows.Add(newRow);
                }
            }

            #endregion

            #region لیست کلی بدهکاران
            DataTable customersListTable = customersTable.AsEnumerable().OrderBy(x => Branches.GetDomainSort(x["Domains.DomainId"].ToString())).ThenBy(x => Numeral.AnyToInt32(x["Branches.BranchId"])).CopyToDataTable();
            customersListTable.TableName = "CustomersList";
            foreach (DataColumn col in customersListTable.Columns)
            {
                if (customersTable.Columns.Contains(col.ColumnName))
                {
                    col.Caption = customersTable.Columns[col.ColumnName].Caption;
                }
            }

            #endregion
           
            #region ساخت روابط
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
            customersTable.Columns["SumOfDebt.CountOfContracts"].ExtendedProperties.Add("FormatNumber", "N0");
            customersTable.Columns["SumOfDebt.MandehAsl"].ExtendedProperties.Add("FormatNumber", "N0");
            customersTable.Columns["SumOfDebt.MandehSood"].ExtendedProperties.Add("FormatNumber", "N0");
            customersTable.Columns["SumOfDebt.MandehJarimeh"].ExtendedProperties.Add("FormatNumber", "N0");
            customersTable.Columns["SumOfDebt.Total"].ExtendedProperties.Add("FormatNumber", "N0");
            customersTable.Columns["DebtRange.Mandeh1"].ExtendedProperties.Add("FormatNumber", "N0");
            customersTable.Columns["DebtRange.Mandeh2"].ExtendedProperties.Add("FormatNumber", "N0");
            customersTable.Columns["DebtRange.Mandeh3"].ExtendedProperties.Add("FormatNumber", "N0");


            branchesTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Domains.DomainID"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Domains.DomainName"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Branches.BranchID"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["SumOfDebt.CountOfCustomers"].ExtendedProperties.Add("FormatNumber", "N0");
            branchesTable.Columns["SumOfDebt.MandehAsl"].ExtendedProperties.Add("FormatNumber", "N0");
            branchesTable.Columns["SumOfDebt.MandehSood"].ExtendedProperties.Add("FormatNumber", "N0");
            branchesTable.Columns["SumOfDebt.MandehJarimeh"].ExtendedProperties.Add("FormatNumber", "N0");
            branchesTable.Columns["SumOfDebt.Total"].ExtendedProperties.Add("FormatNumber", "N0");
            branchesTable.Columns["DebtRange.Mandeh1"].ExtendedProperties.Add("FormatNumber", "N0");
            branchesTable.Columns["DebtRange.Mandeh2"].ExtendedProperties.Add("FormatNumber", "N0");
            branchesTable.Columns["DebtRange.Mandeh3"].ExtendedProperties.Add("FormatNumber", "N0");

            domainsTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            domainsTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            domainsTable.Columns["Domains.DomainID"].ExtendedProperties["Visible"] = false;
            domainsTable.Columns["SumOfDebt.CountOfCustomers"].ExtendedProperties.Add("FormatNumber", "N0");
            domainsTable.Columns["SumOfDebt.MandehAsl"].ExtendedProperties.Add("FormatNumber", "N0");
            domainsTable.Columns["SumOfDebt.MandehSood"].ExtendedProperties.Add("FormatNumber", "N0");
            domainsTable.Columns["SumOfDebt.MandehJarimeh"].ExtendedProperties.Add("FormatNumber", "N0");
            domainsTable.Columns["SumOfDebt.Total"].ExtendedProperties.Add("FormatNumber", "N0");
            domainsTable.Columns["DebtRange.Mandeh1"].ExtendedProperties.Add("FormatNumber", "N0");
            domainsTable.Columns["DebtRange.Mandeh2"].ExtendedProperties.Add("FormatNumber", "N0");
            domainsTable.Columns["DebtRange.Mandeh3"].ExtendedProperties.Add("FormatNumber", "N0");

            provinceTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            provinceTable.Columns["SumOfDebt.CountOfCustomers"].ExtendedProperties.Add("FormatNumber", "N0");
            provinceTable.Columns["SumOfDebt.MandehAsl"].ExtendedProperties.Add("FormatNumber", "N0");
            provinceTable.Columns["SumOfDebt.MandehSood"].ExtendedProperties.Add("FormatNumber", "N0");
            provinceTable.Columns["SumOfDebt.MandehJarimeh"].ExtendedProperties.Add("FormatNumber", "N0");
            provinceTable.Columns["SumOfDebt.Total"].ExtendedProperties.Add("FormatNumber", "N0");
            provinceTable.Columns["DebtRange.Mandeh1"].ExtendedProperties.Add("FormatNumber", "N0");
            provinceTable.Columns["DebtRange.Mandeh2"].ExtendedProperties.Add("FormatNumber", "N0");
            provinceTable.Columns["DebtRange.Mandeh3"].ExtendedProperties.Add("FormatNumber", "N0");

            customersListTable.Columns["Province.ProvinceId"].ExtendedProperties.Add("Visible", false);
            customersListTable.Columns["Province.ProvinceName"].ExtendedProperties.Add("Visible", false);
            customersListTable.Columns["Domains.DomainID"].ExtendedProperties.Add("Visible", false);
            customersListTable.Columns["Branches.BranchID"].ExtendedProperties.Add("Visible", false);
            customersListTable.Columns["Branches.BranchDegree"].ExtendedProperties.Add("Visible", false);
            customersListTable.Columns["SumOfDebt.CountOfContracts"].ExtendedProperties.Add("FormatNumber", "N0");
            customersListTable.Columns["SumOfDebt.MandehAsl"].ExtendedProperties.Add("FormatNumber", "N0");
            customersListTable.Columns["SumOfDebt.MandehSood"].ExtendedProperties.Add("FormatNumber", "N0");
            customersListTable.Columns["SumOfDebt.MandehJarimeh"].ExtendedProperties.Add("FormatNumber", "N0");
            customersListTable.Columns["SumOfDebt.Total"].ExtendedProperties.Add("FormatNumber", "N0");
            customersListTable.Columns["DebtRange.Mandeh1"].ExtendedProperties.Add("FormatNumber", "N0");
            customersListTable.Columns["DebtRange.Mandeh2"].ExtendedProperties.Add("FormatNumber", "N0");
            customersListTable.Columns["DebtRange.Mandeh3"].ExtendedProperties.Add("FormatNumber", "N0");

            ds.ExtendedProperties.Add("Bands", bands);
            ds.ExtendedProperties.Add("MainTable", provinceTable.TableName);
            #endregion

            if (properties.GetStrProperty("ExportMode") == "1")
            {
                DatasetToXlsx.ToExcel(GetExcelSettings(dates), "", ds.Tables["CustomersList"]);
                return null;
            }
            else
                return ds;
        }

        private static XlsFileSettings GetExcelSettings(string[] dates)
        {
            if (dates.Length == 4)
            {
                string _head1 = PersianDateTime.Parse(int.Parse(dates[3])).ToShortDateString();
                string _head2 = PersianDateTime.Parse(int.Parse(dates[0])).AddDays(1).ToShortDateString() + "\n" + " لغایت " + "\n" + PersianDateTime.Parse(int.Parse(dates[1])).ToShortDateString();
                string _head3 = PersianDateTime.Parse(int.Parse(dates[1])).AddDays(1).ToShortDateString() + "\n" + " لغایت " + "\n" + PersianDateTime.Parse(int.Parse(dates[2])).ToShortDateString();
                string _head4 = PersianDateTime.Parse(int.Parse(dates[2])).AddDays(1).ToShortDateString() + "\n" + " لغایت " + "\n" + PersianDateTime.Parse(int.Parse(dates[3])).ToShortDateString();

                XlsFileSettings setting = new XlsFileSettings();
                setting.TemplateName = "410-4.xml";
                setting.ChartHeaderItems.Add(1, new string[] { "کل مطالبات مشتری در مقطع", "مطالبات ایجادی بابت اصل+سود در فاصله زمانی" });
                setting.ChartHeaderItems.Add(2, new string[] { _head1, _head2, _head3, _head4 });  
                setting.FirstRow = 4;
                return setting;
            }

            return null;
        }

    }
}
