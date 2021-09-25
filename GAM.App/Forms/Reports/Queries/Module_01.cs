using DevExpress.XtraGrid.Views.BandedGrid;
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
    class Module_01
    {
        public static DataSet Fill(DataTable tblMaster, string[] dates, QueryProperties properties)
        {
            if (dates.Count() == 2)
            {
                string date1Caption = PersianDateTime.Parse(int.Parse(dates[0])).ToShortDateString();
                string date2Caption = PersianDateTime.Parse(int.Parse(dates[1])).ToShortDateString();

                DataSet ds = new DataSet();
                GridViewManager gvm = new GridViewManager();
                List<GridBand> bands = new List<GridBand>();
                bands.Add(gvm.CreateBand("Header1", "نام سرفصل"));
                bands.Add(gvm.CreateBand("Header2", "مانده در مقطع"));
                bands.Add(gvm.CreateBand("Header3", "نسبت به " + date1Caption, 120));

                DataTable table = new DataTable();
                table.Columns.Add(new DataColumn { ColumnName = "Header1.AccountTitle", Caption = "اقلام آماری" });
                table.Columns.Add(new DataColumn { ColumnName = "Header2.Criteria1", DataType = Type.GetType("System.Double"), Caption = date1Caption });
                table.Columns.Add(new DataColumn { ColumnName = "Header2.Criteria2", DataType = Type.GetType("System.Double"), Caption = date2Caption });
                table.Columns.Add(new DataColumn { ColumnName = "Header3.AbsoluteValue", DataType = Type.GetType("System.Double"), Caption = "مبلغ" });
                table.Columns.Add(new DataColumn { ColumnName = "Header3.GrowthPercentage", DataType = Type.GetType("System.Double"), Caption = "درصد" });

                if (tblMaster.Rows.Count > 0)
                {
                    var GroupedItems = tblMaster.AsEnumerable().GroupBy(dr => new { Subject = dr["AccountTitle"].ToString() })
                                       .Select(g => new
                                       {
                                           AccountTitle = g.Key.Subject,
                                           Balance1 = Numeral.AnyToDouble(g.ToArray()[0]["Balance"]),
                                           Balance2 = Numeral.AnyToDouble(g.ToArray()[1]["Balance"]),
                                       });

                    foreach (var g in GroupedItems)
                    {
                        DataRow newRow = table.NewRow();
                        newRow["Header1.AccountTitle"] = g.AccountTitle;
                        newRow["Header2.Criteria1"] = g.Balance1;
                        newRow["Header2.Criteria2"] = g.Balance2;
                        newRow["Header3.AbsoluteValue"] = g.Balance2 - g.Balance1;
                        newRow["Header3.GrowthPercentage"] = Numeral.ZeroForOverflowValue(((g.Balance2 - g.Balance1) / g.Balance1) * 100);
                        table.Rows.Add(newRow);
                    }

                    #region Extended Properties

                    ds.Tables.Add(table);

                    table.Columns["Header2.Criteria1"].ExtendedProperties.Add("FormatNumber", "N0");
                    table.Columns["Header2.Criteria2"].ExtendedProperties.Add("FormatNumber", "N0");
                    table.Columns["Header3.AbsoluteValue"].ExtendedProperties.Add("FormatNumber", "N0");
                    table.Columns["Header3.GrowthPercentage"].ExtendedProperties.Add("FormatNumber", "N1");

                    ds.ExtendedProperties.Add("Bands", bands);
                    ds.ExtendedProperties.Add("MainTable", table.TableName);
                    #endregion

                    if (properties.GetStrProperty("ExportMode") == "1")
                    {
                        DatasetToXlsx.ToExcel(GetExcelSettings(dates), "", table);
                        return null;
                    }
                    else
                        return ds;
                }
            }

            if (dates.Count() == 3)
            {
                string date1Caption = PersianDateTime.Parse(int.Parse(dates[0])).ToShortDateString();
                string date2Caption = PersianDateTime.Parse(int.Parse(dates[1])).ToShortDateString();
                string date3Caption = PersianDateTime.Parse(int.Parse(dates[2])).ToShortDateString();

                DataSet ds = new DataSet();
                GridViewManager gvm = new GridViewManager();
                List<GridBand> bands = new List<GridBand>();
                bands.Add(gvm.CreateBand("Header1", "نام سرفصل"));
                bands.Add(gvm.CreateBand("Header2", "مانده در مقطع"));
                bands.Add(gvm.CreateBand2("Header3", string.Format("{0} نسبت به {1}", date3Caption, date1Caption), 113, 2));
                bands.Add(gvm.CreateBand2("Header4", string.Format("{0} نسبت به {1}", date3Caption, date2Caption), 113, 2));

                DataTable table = new DataTable();
                table.Columns.Add(new DataColumn { ColumnName = "Header1.AccountTitle", Caption = "اقلام آماری" });
                table.Columns.Add(new DataColumn { ColumnName = "Header2.Criteria1", DataType = Type.GetType("System.Double"), Caption = date1Caption });
                table.Columns.Add(new DataColumn { ColumnName = "Header2.Criteria2", DataType = Type.GetType("System.Double"), Caption = date2Caption });
                table.Columns.Add(new DataColumn { ColumnName = "Header2.Criteria3", DataType = Type.GetType("System.Double"), Caption = date3Caption });
                table.Columns.Add(new DataColumn { ColumnName = "Header3.AbsoluteValue", DataType = Type.GetType("System.Double"), Caption = "مبلغ" });
                table.Columns.Add(new DataColumn { ColumnName = "Header3.GrowthPercentage", DataType = Type.GetType("System.Double"), Caption = "درصد" });
                table.Columns.Add(new DataColumn { ColumnName = "Header4.AbsoluteValue", DataType = Type.GetType("System.Double"), Caption = "مبلغ" });
                table.Columns.Add(new DataColumn { ColumnName = "Header4.GrowthPercentage", DataType = Type.GetType("System.Double"), Caption = "درصد" });

                if (tblMaster.Rows.Count > 0)
                {
                    var GroupedItems = tblMaster.AsEnumerable().GroupBy(dr => new { Subject = dr["AccountTitle"].ToString() })
                                       .Select(g => new
                                       {
                                           AccountTitle = g.Key.Subject,
                                           Balance1 = Numeral.AnyToDouble(g.ToArray()[0]["Balance"]),
                                           Balance2 = Numeral.AnyToDouble(g.ToArray()[1]["Balance"]),
                                           Balance3 = Numeral.AnyToDouble(g.ToArray()[2]["Balance"]),
                                       });

                    foreach (var g in GroupedItems)
                    {
                        DataRow newRow = table.NewRow();
                        newRow["Header1.AccountTitle"] = g.AccountTitle;
                        newRow["Header2.Criteria1"] = g.Balance1;
                        newRow["Header2.Criteria2"] = g.Balance2;
                        newRow["Header2.Criteria3"] = g.Balance3;
                        newRow["Header3.AbsoluteValue"] = g.Balance3 - g.Balance1;
                        newRow["Header3.GrowthPercentage"] = Numeral.ZeroForOverflowValue(((g.Balance3 - g.Balance1) / g.Balance1) * 100);
                        newRow["Header4.AbsoluteValue"] = g.Balance3 - g.Balance2;
                        newRow["Header4.GrowthPercentage"] = Numeral.ZeroForOverflowValue(((g.Balance3 - g.Balance2) / g.Balance2) * 100);
                        table.Rows.Add(newRow);
                    }

                    #region Extended Properties

                    ds.Tables.Add(table);

                    table.Columns["Header2.Criteria1"].ExtendedProperties.Add("FormatNumber", "N0");
                    table.Columns["Header2.Criteria2"].ExtendedProperties.Add("FormatNumber", "N0");
                    table.Columns["Header2.Criteria3"].ExtendedProperties.Add("FormatNumber", "N0");
                    table.Columns["Header3.AbsoluteValue"].ExtendedProperties.Add("FormatNumber", "N0");
                    table.Columns["Header3.GrowthPercentage"].ExtendedProperties.Add("FormatNumber", "N1");
                    table.Columns["Header4.AbsoluteValue"].ExtendedProperties.Add("FormatNumber", "N0");
                    table.Columns["Header4.GrowthPercentage"].ExtendedProperties.Add("FormatNumber", "N1");

                    ds.ExtendedProperties.Add("Bands", bands);
                    ds.ExtendedProperties.Add("MainTable", table.TableName);
                    #endregion

                    if (properties.GetStrProperty("ExportMode") == "1")
                    {
                        DatasetToXlsx.ToExcel(GetExcelSettings(dates), "", table);
                        return null;
                    }
                    else
                        return ds;
                }
            }

            return null;
        }

        private static XlsFileSettings GetExcelSettings(string[] dates)
        {
            if (dates.Length == 2)
            {
                XlsFileSettings setting = new XlsFileSettings();
                setting.TemplateName = "115-2.xml";
                setting.ChartHeaderItems.Add(1, new string[] { PersianDate.Parse(dates[0]).ToStandard(), PersianDate.Parse(dates[1]).ToStandard(), "نسبت به " + PersianDate.Parse(dates[0]).ToStandard() });
                setting.FirstRow = 3;
                return setting;
            }
            if (dates.Length == 3)
            {
                XlsFileSettings setting = new XlsFileSettings();
                setting.TemplateName = "115-3.xml";
                setting.ChartHeaderItems.Add(1, new string[] { PersianDate.Parse(dates[0]).ToStandard(), PersianDate.Parse(dates[1]).ToStandard(), PersianDate.Parse(dates[2]).ToStandard(), "نسبت به " + PersianDate.Parse(dates[0]).ToStandard(), "نسبت به " + PersianDate.Parse(dates[1]).ToStandard() });
                setting.FirstRow = 3;
                return setting;
            }

            return null;
        }
    }
}
