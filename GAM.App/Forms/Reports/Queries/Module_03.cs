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
    class Module_03
    {
        public static DataSet Fill(DataTable tblMaster, string[] dates, QueryProperties properties)
        {
            DataSet ds = new DataSet();
            GridViewManager gvm = new GridViewManager();
            List<GridBand> bands = new List<GridBand>();
            bands.Add(gvm.CreateBand("Province", "اطلاعات استان"));
            bands.Add(gvm.CreateBand("Domains", "اطلاعات حوزه"));
            bands.Add(gvm.CreateBand("Branches", "اطلاعات شعبه"));
            bands.Add(gvm.CreateBand("Customers", "اطلاعات بدهکار"));
            bands.Add(gvm.CreateBand("SumOfDebt", "جمع مانده در مطالبات به تاریخ " + UDF.GetDateString(dates[0])));

            #region گروه بندی مشتریان

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
            customersTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehAsl", Caption = "اصل", DataType = Type.GetType("System.Double") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehSood", Caption = "سود", DataType = Type.GetType("System.Double") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehJarimeh", Caption = "جریمه", DataType = Type.GetType("System.Double") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehHazineh", Caption = "هزینه قانونی", DataType = Type.GetType("System.Double") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehGheyreJari", Caption = "جمع", DataType = Type.GetType("System.Double") });

            var GroupByCustomer = tblMaster.AsEnumerable().GroupBy(dr => new { CustomerId = dr["CustomerID"].ToString(), BranchId = dr["BranchID"].ToString() })
                               .Select(g => new
                               {
                                   BranchInfo = Branches.GetBranchById(g.Key.BranchId, true),
                                   CustomerId = g.Key.CustomerId,
                                   CustomerName = g.First()["CustomerName"].ToString(),
                                   CountOfContracts = g.Count(),
                                   MandehAsl = g.Sum(x => Numeral.AnyToDouble(x["MandehAsl"])),
                                   MandehSood = g.Sum(x => Numeral.AnyToDouble(x["MandehSood"])),
                                   MandehJarimeh = g.Sum(x => Numeral.AnyToDouble(x["MandehJarimeh"])),
                                   MandehHazineh = g.Sum(x => Numeral.AnyToDouble(x["MandehHazineh"])),
                                   MandehGheyreJari = g.Sum(x => Numeral.AnyToDouble(x["MandehGheyreJari"])),
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
                newRow["Customers.CountOfContracts"] = g.CountOfContracts;
                newRow["SumOfDebt.MandehAsl"] = g.MandehAsl;
                newRow["SumOfDebt.MandehSood"] = g.MandehSood;
                newRow["SumOfDebt.MandehJarimeh"] = g.MandehJarimeh;
                newRow["SumOfDebt.MandehHazineh"] = g.MandehHazineh;
                newRow["SumOfDebt.MandehGheyreJari"] = g.MandehGheyreJari;
                customersTable.Rows.Add(newRow);
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
            branchesTable.Columns.Add(new DataColumn { ColumnName = "Branches.CountOfCustomers", Caption = "ت.بدهکاران", DataType = Type.GetType("System.Double") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehAsl", Caption = "اصل", DataType = Type.GetType("System.Double") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehSood", Caption = "سود", DataType = Type.GetType("System.Double") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehJarimeh", Caption = "جریمه", DataType = Type.GetType("System.Double") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehHazineh", Caption = "هزینه قانونی", DataType = Type.GetType("System.Double") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehGheyreJari", Caption = "جمع", DataType = Type.GetType("System.Double") });
            #endregion

            var groupByBranchId = customersTable.AsEnumerable().GroupBy(dr => new { BranchId = dr["Branches.BranchId"].ToString() })
                                   .Select(g => new
                                   {
                                       BranchInfo = Branches.GetBranchById(g.Key.BranchId, true),
                                       CountOfCustomers = g.Count(),
                                       MandehAsl = g.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehAsl"])),
                                       MandehSood = g.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehSood"])),
                                       MandehJarimeh = g.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehJarimeh"])),
                                       MandehHazineh = g.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehHazineh"])),
                                       MandehGheyreJari = g.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehGheyreJari"])),
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
                    newRow["Branches.CountOfCustomers"] = row.CountOfCustomers;
                    newRow["SumOfDebt.MandehAsl"] = row.MandehAsl;
                    newRow["SumOfDebt.MandehSood"] = row.MandehSood;
                    newRow["SumOfDebt.MandehJarimeh"] = row.MandehJarimeh;
                    newRow["SumOfDebt.MandehHazineh"] = row.MandehHazineh;
                    newRow["SumOfDebt.MandehGheyreJari"] = row.MandehGheyreJari;
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
                    newRow["Branches.CountOfCustomers"] = 0;
                    newRow["SumOfDebt.MandehAsl"] = 0;
                    newRow["SumOfDebt.MandehSood"] = 0;
                    newRow["SumOfDebt.MandehJarimeh"] = 0;
                    newRow["SumOfDebt.MandehHazineh"] = 0;
                    newRow["SumOfDebt.MandehGheyreJari"] = 0;
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
            domainsTable.Columns.Add(new DataColumn { ColumnName = "Domains.CountOfCustomers", Caption = "ت.بدهکاران", DataType = Type.GetType("System.Double") });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehAsl", Caption = "اصل", DataType = Type.GetType("System.Double") });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehSood", Caption = "سود", DataType = Type.GetType("System.Double") });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehJarimeh", Caption = "جریمه", DataType = Type.GetType("System.Double") });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehHazineh", Caption = "هزینه قانونی", DataType = Type.GetType("System.Double") });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehGheyreJari", Caption = "جمع", DataType = Type.GetType("System.Double") });

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
                    newRow["Domains.CountOfCustomers"] = brRows.Sum(x => Numeral.AnyToDouble(x["Branches.CountOfCustomers"]));
                    newRow["SumOfDebt.MandehAsl"] = brRows.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehAsl"]));
                    newRow["SumOfDebt.MandehSood"] = brRows.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehSood"]));
                    newRow["SumOfDebt.MandehJarimeh"] = brRows.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehJarimeh"]));
                    newRow["SumOfDebt.MandehHazineh"] = brRows.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehHazineh"]));
                    newRow["SumOfDebt.MandehGheyreJari"] = brRows.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehGheyreJari"]));
                    domainsTable.Rows.Add(newRow);
                }
                else
                {
                    DataRow newRow = domainsTable.NewRow();
                    newRow["Province.ProvinceId"] = di.Province.ProvinceId;
                    newRow["Province.ProvinceName"] = di.Province.ProvinceName;
                    newRow["Domains.DomainId"] = di.DomainId;
                    newRow["Domains.DomainName"] = di.DomainName;
                    newRow["Domains.CountOfCustomers"] = 0;
                    newRow["SumOfDebt.MandehAsl"] = 0;
                    newRow["SumOfDebt.MandehSood"] = 0;
                    newRow["SumOfDebt.MandehJarimeh"] = 0;
                    newRow["SumOfDebt.MandehHazineh"] = 0;
                    newRow["SumOfDebt.MandehGheyreJari"] = 0;
                    domainsTable.Rows.Add(newRow);
                }
            }

            #endregion

            #region ساخت استان
            DataTable provinceTable = new DataTable("Province");
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceId", Caption = "کد استان", DataType = Type.GetType("System.Int32") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceName", Caption = "نام استان", DataType = typeof(string) });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Province.CountOfCustomers", Caption = "ت.بدهکاران", DataType = Type.GetType("System.Double") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehAsl", Caption = "اصل", DataType = Type.GetType("System.Double") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehSood", Caption = "سود", DataType = Type.GetType("System.Double") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehJarimeh", Caption = "جریمه", DataType = Type.GetType("System.Double") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehHazineh", Caption = "هزینه قانونی", DataType = Type.GetType("System.Double") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "SumOfDebt.MandehGheyreJari", Caption = "جمع", DataType = Type.GetType("System.Double") });

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
                    newRow["Province.CountOfCustomers"] = doRows.Sum(x => Numeral.AnyToDouble(x["Domains.CountOfCustomers"]));
                    newRow["SumOfDebt.MandehAsl"] = doRows.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehAsl"]));
                    newRow["SumOfDebt.MandehSood"] = doRows.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehSood"]));
                    newRow["SumOfDebt.MandehJarimeh"] = doRows.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehJarimeh"]));
                    newRow["SumOfDebt.MandehHazineh"] = doRows.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehHazineh"]));
                    newRow["SumOfDebt.MandehGheyreJari"] = doRows.Sum(x => Numeral.AnyToDouble(x["SumOfDebt.MandehGheyreJari"]));
                    provinceTable.Rows.Add(newRow);
                }
            }

            #endregion

            #region لیست کلی بدهکاران
            DataTable customersListTable = customersTable.Copy();
            customersListTable.TableName = "CustomersList";
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
            customersTable.Columns["Customers.CountOfContracts"].ExtendedProperties.Add("FormatNumber", "N0");
            customersTable.Columns["SumOfDebt.MandehAsl"].ExtendedProperties.Add("FormatNumber", "N0");
            customersTable.Columns["SumOfDebt.MandehSood"].ExtendedProperties.Add("FormatNumber", "N0");
            customersTable.Columns["SumOfDebt.MandehJarimeh"].ExtendedProperties.Add("FormatNumber", "N0");
            customersTable.Columns["SumOfDebt.MandehHazineh"].ExtendedProperties.Add("FormatNumber", "N0");
            customersTable.Columns["SumOfDebt.MandehGheyreJari"].ExtendedProperties.Add("FormatNumber", "N0");


            branchesTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Domains.DomainID"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Domains.DomainName"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Branches.BranchID"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Branches.CountOfCustomers"].ExtendedProperties.Add("FormatNumber", "N0");
            branchesTable.Columns["SumOfDebt.MandehAsl"].ExtendedProperties.Add("FormatNumber", "N0");
            branchesTable.Columns["SumOfDebt.MandehSood"].ExtendedProperties.Add("FormatNumber", "N0");
            branchesTable.Columns["SumOfDebt.MandehJarimeh"].ExtendedProperties.Add("FormatNumber", "N0");
            branchesTable.Columns["SumOfDebt.MandehHazineh"].ExtendedProperties.Add("FormatNumber", "N0");
            branchesTable.Columns["SumOfDebt.MandehGheyreJari"].ExtendedProperties.Add("FormatNumber", "N0");

            domainsTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            domainsTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            domainsTable.Columns["Domains.DomainID"].ExtendedProperties["Visible"] = false;
            domainsTable.Columns["Domains.CountOfCustomers"].ExtendedProperties.Add("FormatNumber", "N0");
            domainsTable.Columns["SumOfDebt.MandehAsl"].ExtendedProperties.Add("FormatNumber", "N0");
            domainsTable.Columns["SumOfDebt.MandehSood"].ExtendedProperties.Add("FormatNumber", "N0");
            domainsTable.Columns["SumOfDebt.MandehJarimeh"].ExtendedProperties.Add("FormatNumber", "N0");
            domainsTable.Columns["SumOfDebt.MandehHazineh"].ExtendedProperties.Add("FormatNumber", "N0");
            domainsTable.Columns["SumOfDebt.MandehGheyreJari"].ExtendedProperties.Add("FormatNumber", "N0");

            provinceTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            provinceTable.Columns["Province.CountOfCustomers"].ExtendedProperties.Add("FormatNumber", "N0");
            provinceTable.Columns["SumOfDebt.MandehAsl"].ExtendedProperties.Add("FormatNumber", "N0");
            provinceTable.Columns["SumOfDebt.MandehSood"].ExtendedProperties.Add("FormatNumber", "N0");
            provinceTable.Columns["SumOfDebt.MandehJarimeh"].ExtendedProperties.Add("FormatNumber", "N0");
            provinceTable.Columns["SumOfDebt.MandehHazineh"].ExtendedProperties.Add("FormatNumber", "N0");
            provinceTable.Columns["SumOfDebt.MandehGheyreJari"].ExtendedProperties.Add("FormatNumber", "N0");

            customersListTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            customersListTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            customersListTable.Columns["SumOfDebt.MandehAsl"].ExtendedProperties.Add("FormatNumber", "N0");
            customersListTable.Columns["SumOfDebt.MandehSood"].ExtendedProperties.Add("FormatNumber", "N0");
            customersListTable.Columns["SumOfDebt.MandehJarimeh"].ExtendedProperties.Add("FormatNumber", "N0");
            customersListTable.Columns["SumOfDebt.MandehHazineh"].ExtendedProperties.Add("FormatNumber", "N0");
            customersListTable.Columns["SumOfDebt.MandehGheyreJari"].ExtendedProperties.Add("FormatNumber", "N0");

            ds.ExtendedProperties.Add("Bands", bands);
            ds.ExtendedProperties.Add("MainTable", provinceTable.TableName);
            #endregion

            return ds;
        }
    }
}
