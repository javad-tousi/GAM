using DevExpress.XtraGrid.Views.BandedGrid;
using GAM.Forms.Information.Library;
using GAM.Forms.Profile.Kargozini.Library;
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
    class Module_26
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
            bands.Add(gvm.CreateBand("Employees", "اطلاعات همکار"));
            bands.Add(gvm.CreateBand("Doc", "تعداد اسناد ثبتی طی دوره"));

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

            #region Employees Table

            DataTable customersTable = new DataTable("Employees");
            customersTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceId", Caption = "کد استان", DataType = Type.GetType("System.Int32") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceName", Caption = "نام استان", DataType = typeof(string) });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Domains.DomainId", Caption = "کد حوزه", DataType = Type.GetType("System.Int32") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Domains.DomainName", Caption = "نام حوزه", DataType = Type.GetType("System.String") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Branches.BranchId", Caption = "کد شعبه", DataType = Type.GetType("System.Int32") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Branches.BranchName", Caption = "نام شعبه" });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Branches.BranchDegree", Caption = "درجه" });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Employees.EmploymentId", Caption = "شماره همکار", DataType = Type.GetType("System.String") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Employees.EmployeeName", Caption = "نام همکار", DataType = Type.GetType("System.String") });
            customersTable.Columns.Add(new DataColumn { ColumnName = "Doc.Documents", Caption = "مبلغ اعطایی", DataType = Type.GetType("System.Double") });

            var selectedEmployees = tblMaster.AsEnumerable().OrderByDescending(x => Numeral.AnyToDouble(x["Count"]))
                               .Select(r => new
                               {
                                   BranchInfo = Branches.GetBranchById(r["BranchId"].ToString(), true),
                                   EmploymentId = r["EmploymentID"].ToString(),
                                   EmployeeName = PersonelsManager.GetFastEmployeeNameById(r["EmploymentID"].ToString()),
                                   Documents = Numeral.AnyToDouble(r["Count"]),
                               });

            foreach (var g in selectedEmployees)
            {
                DataRow newRow = customersTable.NewRow();
                newRow["Province.ProvinceId"] = g.BranchInfo.Province.ProvinceId;
                newRow["Province.ProvinceName"] = g.BranchInfo.Province.ProvinceName;
                newRow["Domains.DomainId"] = g.BranchInfo.Domain.DomainId;
                newRow["Domains.DomainName"] = g.BranchInfo.Domain.DomainName;
                newRow["Branches.BranchId"] = g.BranchInfo.BranchId;
                newRow["Branches.BranchName"] = g.BranchInfo.BranchName;
                newRow["Branches.BranchDegree"] = g.BranchInfo.BranchDegree;
                newRow["Employees.EmploymentId"] = g.EmploymentId;
                newRow["Employees.EmployeeName"] = g.EmployeeName;
                newRow["Doc.Documents"] = g.Documents;
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
                    branchesTable.Columns.Add(new DataColumn { ColumnName = cat.Value + ".Total", Caption = "مبلغ", DataType = Type.GetType("System.Double"), Namespace = UDF.GetDateString(cat.Key.ToString()) });
                else
                    branchesTable.Columns.Add(new DataColumn { ColumnName = cat.Value + ".Total", Caption = "مبلغ", DataType = Type.GetType("System.Double") });
            }
            #endregion

            var groupByBranchId = tblMaster.AsEnumerable().GroupBy(dr => new { BranchId = dr["BranchID"].ToString() })
                                   .Select(g => new
                                   {
                                       BranchInfo = Branches.GetBranchById(g.Key.BranchId, true),
                                       Values = g,
                                       SubTotal = g.Sum(x => Numeral.AnyToDouble(x["Count"])),
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
                    foreach (var cat in categoriesList)
                    {
                        if (cat.Key > 0)
                            newRow[cat.Value + ".Total"] = row.Values.Where(x => int.Parse(x["ReportDate"].ToString()) == cat.Key).Sum(x => Numeral.AnyToDouble(x["Documents"]));
                        else
                            newRow[cat.Value + ".Total"] = row.SubTotal;
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
                        newRow[item.Value + ".Total"] = 0;
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
                domainsTable.Columns.Add(new DataColumn { ColumnName = item.Value + ".Total", Caption = "مبلغ", DataType = Type.GetType("System.Double") });

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
                    foreach (var cat in categoriesList)
                        newRow[cat.Value + ".Total"] = brRows.Sum(x => Numeral.AnyToDouble(x[cat.Value + ".Total"]));
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
                        newRow[item.Value + ".Total"] = 0;
                    domainsTable.Rows.Add(newRow);
                }
            }

            #endregion

            #region Province Table

            DataTable provinceTable = new DataTable("Province");
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceId", Caption = "کد استان", DataType = Type.GetType("System.Int32") });
            provinceTable.Columns.Add(new DataColumn { ColumnName = "Province.ProvinceName", Caption = "نام استان", DataType = typeof(string) });
            foreach (var item in categoriesList)
                provinceTable.Columns.Add(new DataColumn { ColumnName = item.Value + ".Total", Caption = "مبلغ", DataType = Type.GetType("System.Double") });

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
                    foreach (var item in categoriesList)
                        newRow[item.Value + ".Total"] = doRows.Sum(x => Numeral.AnyToDouble(x[item.Value + ".Total"]));
                    provinceTable.Rows.Add(newRow);
                }
            }

            #endregion

            #region Employees List
            DataTable customersListTable = customersTable.Copy();
            customersListTable.TableName = "EmployeesList";
            #endregion

            #region Relations

            ds.Tables.Add(provinceTable);
            ds.Tables.Add(domainsTable);
            ds.Tables.Add(branchesTable);
            ds.Tables.Add(customersTable);
            ds.Tables.Add(customersListTable);

            ds.Relations.Add("حوزه ها", provinceTable.Columns["Province.ProvinceId"], domainsTable.Columns["Province.ProvinceId"]);
            ds.Relations.Add("شعب", domainsTable.Columns["Domains.DomainID"], branchesTable.Columns["Domains.DomainID"]);
            ds.Relations.Add("همکاران", branchesTable.Columns["Branches.BranchID"], customersTable.Columns["Branches.BranchID"]);
            ds.Relations.Add("لیست همکاران", provinceTable.Columns["Province.ProvinceId"], customersListTable.Columns["Province.ProvinceId"]);
            #endregion

            #region Extended Properties
            customersTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            customersTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            customersTable.Columns["Domains.DomainID"].ExtendedProperties["Visible"] = false;
            customersTable.Columns["Domains.DomainName"].ExtendedProperties["Visible"] = false;
            customersTable.Columns["Branches.BranchID"].ExtendedProperties["Visible"] = false;
            customersTable.Columns["Branches.BranchName"].ExtendedProperties["Visible"] = false;
            customersTable.Columns["Branches.BranchDegree"].ExtendedProperties["Visible"] = false;
            customersTable.Columns["Doc.Documents"].ExtendedProperties.Add("FormatNumber", "N0");

            branchesTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Domains.DomainID"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Domains.DomainName"].ExtendedProperties["Visible"] = false;
            branchesTable.Columns["Branches.BranchID"].ExtendedProperties["Visible"] = false;
            foreach (var cat in categoriesList)
                branchesTable.Columns[cat.Value + ".Total"].ExtendedProperties.Add("FormatNumber", "N0");

            domainsTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            domainsTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            domainsTable.Columns["Domains.DomainID"].ExtendedProperties["Visible"] = false;
            foreach (var cat in categoriesList)
                domainsTable.Columns[cat.Value + ".Total"].ExtendedProperties.Add("FormatNumber", "N0");

            provinceTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            foreach (var cat in categoriesList)
                provinceTable.Columns[cat.Value + ".Total"].ExtendedProperties.Add("FormatNumber", "N0");

            customersListTable.Columns["Province.ProvinceId"].ExtendedProperties["Visible"] = false;
            customersListTable.Columns["Province.ProvinceName"].ExtendedProperties["Visible"] = false;
            customersListTable.Columns["Doc.Documents"].ExtendedProperties.Add("FormatNumber", "N0");

            ds.ExtendedProperties.Add("Bands", bands);
            ds.ExtendedProperties.Add("MainTable", provinceTable.TableName);
            #endregion

            return ds;
        }
    }
}
