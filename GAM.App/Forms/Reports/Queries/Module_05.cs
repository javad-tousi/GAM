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
    class Module_05
    {
        public static DataSet Fill(DataTable tblMaster, string[] dates, QueryProperties properties)
        {
            string date2Caption = PersianDateTime.Parse(int.Parse(dates[1])).ToShortDateString();

            DataSet ds = new DataSet();
            GridViewManager gvm = new GridViewManager();
            List<GridBand> bands = new List<GridBand>();
            bands.Add(gvm.CreateBand("Province", "اطلاعات استان"));
            bands.Add(gvm.CreateBand("Domains", "اطلاعات حوزه"));
            bands.Add(gvm.CreateBand("Branches", "اطلاعات شعبه"));
            bands.Add(gvm.CreateBand("Customers", "اطلاعات مشتری"));
            bands.Add(gvm.CreateBand("Contract", "اطلاعات قرارداد"));
            bands.Add(gvm.CreateBand("Debt", "مانده در مطالبات به تاریخ " + UDF.GetDateString(dates[1]), 195));

            #region گروه بندی مشتریان
            DataTable baseTable = new DataTable();
            baseTable = tblMaster.Clone();
            baseTable.Columns.Add(new DataColumn { ColumnName = "Date1_VS_Date2" });


            var GroupByContractId = tblMaster.AsEnumerable().Where(x => Numeral.AnyToDouble(x["MandehAsl"]) > 0).GroupBy(dr => new { ContractID = dr["ContractID"] })
                               .Select(g => new
                               {
                                   values = g.ToArray(),
                               });

            foreach (var g in GroupByContractId)
            {
                DataRow newRow = baseTable.NewRow();
                newRow["Date1_VS_Date2"] = "";

                DataRow date1_Row = g.values.Where(r => r["ReportDate"].ToString() == dates[0]).FirstOrDefault();
                DataRow date2_Row = g.values.Where(r => r["ReportDate"].ToString() == dates[1]).FirstOrDefault();

                if (date2_Row != null)
                {
                    if (date1_Row == null)
                    {
                        foreach (DataColumn col in tblMaster.Columns)
                        {
                            newRow[col.ColumnName] = date2_Row[col.ColumnName];
                        }
                        baseTable.Rows.Add(newRow);
                    }
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
                customersTable.Columns.Add(new DataColumn { ColumnName = "Contract.ContractId", Caption = "ش.قرارداد", DataType = Type.GetType("System.String") });
                customersTable.Columns.Add(new DataColumn { ColumnName = "Contract.FacilityName", Caption = "نوع تسهیلات", DataType = Type.GetType("System.String") });
                customersTable.Columns.Add(new DataColumn { ColumnName = "Contract.ContractStatus", Caption = "طبقه", DataType = Type.GetType("System.String") });
                customersTable.Columns.Add(new DataColumn { ColumnName = "Contract.DateSWPlane", Caption = "تاریخ انتقال", DataType = Type.GetType("System.String") });
                customersTable.Columns.Add(new DataColumn { ColumnName = "Debt.MandehAsl", Caption = "اصل", DataType = Type.GetType("System.Double") });
                customersTable.Columns.Add(new DataColumn { ColumnName = "Debt.MandehSood", Caption = "سود", DataType = Type.GetType("System.Double") });
                customersTable.Columns.Add(new DataColumn { ColumnName = "Debt.MandehJarimeh", Caption = "جریمه", DataType = Type.GetType("System.Double") });
                customersTable.Columns.Add(new DataColumn { ColumnName = "Debt.MandehHazineh", Caption = "هزینه قانونی", DataType = Type.GetType("System.Double") });
                customersTable.Columns.Add(new DataColumn { ColumnName = "Debt.MandehGheyreJari", Caption = "جمع", DataType = Type.GetType("System.Double") });

                var SelectedCustomers = baseTable.AsEnumerable().OrderByDescending(x => Numeral.AnyToDouble(x["MandehGheyreJari"]))
                                   .Select(r => new
                                   {
                                       BranchInfo = Branches.GetBranchById(r["BranchId"].ToString(), true),
                                       ContractId = r["ContractID"].ToString(),
                                       FacilityName = r["FacilityName"].ToString(),
                                       ContractStatus = r["ContractStatus"].ToString(),
                                       DateSWPlane = r["DateSWPlane"].ToString(),
                                       CustomerId = r["CustomerID"].ToString(),
                                       CustomerName = r["CustomerName"].ToString(),
                                       MandehAsl = Numeral.AnyToDouble(r["MandehAsl"]),
                                       MandehSood = Numeral.AnyToDouble(r["MandehSood"]),
                                       MandehJarimeh = Numeral.AnyToDouble(r["MandehJarimeh"]),
                                       MandehHazineh = Numeral.AnyToDouble(r["MandehHazineh"]),
                                       MandehGheyreJari = Numeral.AnyToDouble(r["MandehGheyreJari"]),
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
                    newRow["Contract.ContractId"] = g.ContractId;
                    newRow["Contract.FacilityName"] = g.FacilityName;
                    newRow["Contract.ContractStatus"] = g.ContractStatus;
                    newRow["Contract.DateSWPlane"] = g.DateSWPlane;
                    newRow["Debt.MandehAsl"] = g.MandehAsl;
                    newRow["Debt.MandehSood"] = g.MandehSood;
                    newRow["Debt.MandehJarimeh"] = g.MandehJarimeh;
                    newRow["Debt.MandehHazineh"] = g.MandehHazineh;
                    newRow["Debt.MandehGheyreJari"] = g.MandehGheyreJari;
                    customersTable.Rows.Add(newRow);
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
            branchesTable.Columns.Add(new DataColumn { ColumnName = "Debt.CountOfContracts", Caption = "تعداد", DataType = Type.GetType("System.Double") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "Debt.MandehAsl", Caption = "اصل", DataType = Type.GetType("System.Double") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "Debt.MandehSood", Caption = "سود", DataType = Type.GetType("System.Double") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "Debt.MandehJarimeh", Caption = "جریمه", DataType = Type.GetType("System.Double") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "Debt.MandehHazineh", Caption = "هزینه قانونی", DataType = Type.GetType("System.Double") });
            branchesTable.Columns.Add(new DataColumn { ColumnName = "Debt.MandehGheyreJari", Caption = "جمع", DataType = Type.GetType("System.Double") });
            #endregion

            var groupByBranchId = customersTable.AsEnumerable().GroupBy(dr => new { BranchId = dr["Branches.BranchId"].ToString() })
                                   .Select(g => new
                                   {
                                       BranchInfo = Branches.GetBranchById(g.Key.BranchId, true),
                                       CountOfContracts = g.Count(),
                                       MandehAsl = g.Sum(x => Numeral.AnyToDouble(x["Debt.MandehAsl"])),
                                       MandehSood = g.Sum(x => Numeral.AnyToDouble(x["Debt.MandehSood"])),
                                       MandehJarimeh = g.Sum(x => Numeral.AnyToDouble(x["Debt.MandehJarimeh"])),
                                       MandehHazineh = g.Sum(x => Numeral.AnyToDouble(x["Debt.MandehHazineh"])),
                                       MandehGheyreJari = g.Sum(x => Numeral.AnyToDouble(x["Debt.MandehGheyreJari"])),
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
                    newRow["Debt.CountOfContracts"] = row.CountOfContracts;
                    newRow["Debt.MandehAsl"] = row.MandehAsl;
                    newRow["Debt.MandehSood"] = row.MandehSood;
                    newRow["Debt.MandehJarimeh"] = row.MandehJarimeh;
                    newRow["Debt.MandehHazineh"] = row.MandehHazineh;
                    newRow["Debt.MandehGheyreJari"] = row.MandehGheyreJari;
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
                    newRow["Debt.CountOfContracts"] = 0;
                    newRow["Debt.MandehAsl"] = 0;
                    newRow["Debt.MandehSood"] = 0;
                    newRow["Debt.MandehJarimeh"] = 0;
                    newRow["Debt.MandehHazineh"] = 0;
                    newRow["Debt.MandehGheyreJari"] = 0;
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
            domainsTable.Columns.Add(new DataColumn { ColumnName = "Debt.CountOfContracts", Caption = "تعداد", DataType = Type.GetType("System.Double") });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "Debt.MandehAsl", Caption = "اصل", DataType = Type.GetType("System.Double") });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "Debt.MandehSood", Caption = "سود", DataType = Type.GetType("System.Double") });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "Debt.MandehJarimeh", Caption = "جریمه", DataType = Type.GetType("System.Double") });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "Debt.MandehHazineh", Caption = "هزینه قانونی", DataType = Type.GetType("System.Double") });
            domainsTable.Columns.Add(new DataColumn { ColumnName = "Debt.MandehGheyreJari", Caption = "جمع", DataType = Type.GetType("System.Double") });

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
                    newRow["Debt.CountOfContracts"] = brRows.Sum(x => Numeral.AnyToDouble(x["Debt.CountOfContracts"]));
                    newRow["Debt.MandehAsl"] = brRows.Sum(x => Numeral.AnyToDouble(x["Debt.MandehAsl"]));
                    newRow["Debt.MandehSood"] = brRows.Sum(x => Numeral.AnyToDouble(x["Debt.MandehSood"]));
                    newRow["Debt.MandehJarimeh"] = brRows.Sum(x => Numeral.AnyToDouble(x["Debt.MandehJarimeh"]));
                    newRow["Debt.MandehHazineh"] = brRows.Sum(x => Numeral.AnyToDouble(x["Debt.MandehHazineh"]));
                    newRow["Debt.MandehGheyreJari"] = brRows.Sum(x => Numeral.AnyToDouble(x["Debt.MandehGheyreJari"]));
                    domainsTable.Rows.Add(newRow);
                }
                else
                {
                    DataRow newRow = domainsTable.NewRow();
                    newRow["Province.ProvinceId"] = di.Province.ProvinceId;
                    newRow["Province.ProvinceName"] = di.Province.ProvinceName;
                    newRow["Domains.DomainId"] = di.DomainId;
                    newRow["Domains.DomainName"] = di.DomainName;
                    newRow["Debt.CountOfContracts"] = 0;
                    newRow["Debt.MandehAsl"] = 0;
                    newRow["Debt.MandehSood"] = 0;
                    newRow["Debt.MandehJarimeh"] = 0;
                    newRow["Debt.MandehHazineh"] = 0;
                    newRow["Debt.MandehGheyreJari"] = 0;
                    domainsTable.Rows.Add(newRow);
                }
            }

            #endregion

            #region ساخت استان
            DataTable provinceTable = new DataTable("Province");
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceId", Caption = "کد استان", DataType = Type.GetType("System.Int32") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceName", Caption = "نام استان", DataType = typeof(string) });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Debt.CountOfContracts", Caption = "تعداد", DataType = Type.GetType("System.Double") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Debt.MandehAsl", Caption = "اصل", DataType = Type.GetType("System.Double") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Debt.MandehSood", Caption = "سود", DataType = Type.GetType("System.Double") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Debt.MandehJarimeh", Caption = "جریمه", DataType = Type.GetType("System.Double") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Debt.MandehHazineh", Caption = "هزینه قانونی", DataType = Type.GetType("System.Double") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Debt.MandehGheyreJari", Caption = "جمع", DataType = Type.GetType("System.Double") });

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
                    newRow["Debt.CountOfContracts"] = doRows.Sum(x => Numeral.AnyToDouble(x["Debt.CountOfContracts"]));
                    newRow["Debt.MandehAsl"] = doRows.Sum(x => Numeral.AnyToDouble(x["Debt.MandehAsl"]));
                    newRow["Debt.MandehSood"] = doRows.Sum(x => Numeral.AnyToDouble(x["Debt.MandehSood"]));
                    newRow["Debt.MandehJarimeh"] = doRows.Sum(x => Numeral.AnyToDouble(x["Debt.MandehJarimeh"]));
                    newRow["Debt.MandehHazineh"] = doRows.Sum(x => Numeral.AnyToDouble(x["Debt.MandehHazineh"]));
                    newRow["Debt.MandehGheyreJari"] = doRows.Sum(x => Numeral.AnyToDouble(x["Debt.MandehGheyreJari"]));
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
            customersTable.Columns["Debt.MandehAsl"].ExtendedProperties.Add("FormatNumber", "N0");
            customersTable.Columns["Debt.MandehSood"].ExtendedProperties.Add("FormatNumber", "N0");
            customersTable.Columns["Debt.MandehJarimeh"].ExtendedProperties.Add("FormatNumber", "N0");
            customersTable.Columns["Debt.MandehHazineh"].ExtendedProperties.Add("FormatNumber", "N0");
            customersTable.Columns["Debt.MandehGheyreJari"].ExtendedProperties.Add("FormatNumber", "N0");


            branchesTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Domains.DomainID"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Domains.DomainName"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Branches.BranchID"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Debt.CountOfContracts"].ExtendedProperties.Add("FormatNumber", "N0");
            branchesTable.Columns["Debt.MandehAsl"].ExtendedProperties.Add("FormatNumber", "N0");
            branchesTable.Columns["Debt.MandehSood"].ExtendedProperties.Add("FormatNumber", "N0");
            branchesTable.Columns["Debt.MandehJarimeh"].ExtendedProperties.Add("FormatNumber", "N0");
            branchesTable.Columns["Debt.MandehHazineh"].ExtendedProperties.Add("FormatNumber", "N0");
            branchesTable.Columns["Debt.MandehGheyreJari"].ExtendedProperties.Add("FormatNumber", "N0");

            domainsTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            domainsTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            domainsTable.Columns["Domains.DomainID"].ExtendedProperties["Visible"] = false;
            domainsTable.Columns["Debt.CountOfContracts"].ExtendedProperties.Add("FormatNumber", "N0");
            domainsTable.Columns["Debt.MandehAsl"].ExtendedProperties.Add("FormatNumber", "N0");
            domainsTable.Columns["Debt.MandehSood"].ExtendedProperties.Add("FormatNumber", "N0");
            domainsTable.Columns["Debt.MandehJarimeh"].ExtendedProperties.Add("FormatNumber", "N0");
            domainsTable.Columns["Debt.MandehHazineh"].ExtendedProperties.Add("FormatNumber", "N0");
            domainsTable.Columns["Debt.MandehGheyreJari"].ExtendedProperties.Add("FormatNumber", "N0");

            provinceTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            provinceTable.Columns["Debt.CountOfContracts"].ExtendedProperties.Add("FormatNumber", "N0");
            provinceTable.Columns["Debt.MandehAsl"].ExtendedProperties.Add("FormatNumber", "N0");
            provinceTable.Columns["Debt.MandehSood"].ExtendedProperties.Add("FormatNumber", "N0");
            provinceTable.Columns["Debt.MandehJarimeh"].ExtendedProperties.Add("FormatNumber", "N0");
            provinceTable.Columns["Debt.MandehHazineh"].ExtendedProperties.Add("FormatNumber", "N0");
            provinceTable.Columns["Debt.MandehGheyreJari"].ExtendedProperties.Add("FormatNumber", "N0");

            customersListTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            customersListTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            customersListTable.Columns["Debt.MandehAsl"].ExtendedProperties.Add("FormatNumber", "N0");
            customersListTable.Columns["Debt.MandehSood"].ExtendedProperties.Add("FormatNumber", "N0");
            customersListTable.Columns["Debt.MandehJarimeh"].ExtendedProperties.Add("FormatNumber", "N0");
            customersListTable.Columns["Debt.MandehHazineh"].ExtendedProperties.Add("FormatNumber", "N0");
            customersListTable.Columns["Debt.MandehGheyreJari"].ExtendedProperties.Add("FormatNumber", "N0");

            ds.ExtendedProperties.Add("Bands", bands);
            ds.ExtendedProperties.Add("MainTable", provinceTable.TableName);
            #endregion

            return ds;
        }
    }
}
