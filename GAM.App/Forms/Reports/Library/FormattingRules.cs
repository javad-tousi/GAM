using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using GAM.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Forms.Reports.Library
{
    class FormattingRules
    {
        public static string GetColorName(DictionaryEntry de, double value) 
        {
            if (de.Key.ToString() == "R1")
            {
                double avg = Numeral.AnyToDouble(de.Value);
                if (avg > 0)
                    avg = Math.Round(avg, 2);
                else
                    avg = 0;

                if (value < 0)
                    return "Red";
                if (value <= avg)
                    return "Orange";
                if (value > avg)
                    return "Green";
            }
            if (de.Key.ToString() == "R2")
            {
                double avg = Numeral.AnyToDouble(de.Value);
                if (avg < 0)
                    avg = Math.Round(avg, 2);
                else
                    avg = 0;

                if (value > 0)
                    return "Red";
                if (value >= avg)
                    return "Orange";
                if (value < avg)
                    return "Green";
            }
            if (de.Key.ToString() == "R3")
            {
                if (value > 80)
                    return "Green";
                if (value > 60)
                    return "Blue";
                if (value > 40)
                    return "Yellow";
                if (value > 20)
                    return "Orange";
                if (value <= 20)
                    return "Red";
            }
            if (de.Key.ToString() == "R4")
            {
                if (value <= 3)
                    return "Green";
                if (value > 3)
                    return "Orange";
                if (value > 5)
                    return "Red";
            }

            return string.Empty;       
        }

        public static void SetRangeFormat(Microsoft.Office.Interop.Excel.Worksheet ShXL, DataColumn col, dynamic colRng)
        {
            if (col.ExtendedProperties.ContainsKey("FormatNumber"))
            {
                if (col.ExtendedProperties["FormatNumber"].ToString() == "N0")
                    colRng.NumberFormat = "#,##0";
                if (col.ExtendedProperties["FormatNumber"].ToString() == "N1")
                    colRng.NumberFormat = "#,##0.0";
                if (col.ExtendedProperties["FormatNumber"].ToString() == "N2")
                    colRng.NumberFormat = "#,##0.00";
            }

            if (col.ExtendedProperties.ContainsKey("FormatRule"))
            {
                DictionaryEntry de = (DictionaryEntry)col.ExtendedProperties["FormatRule"];
                if (de.Key.ToString() == "R1")
                {
                    double avg = Numeral.AnyToDouble(de.Value);
                    if (avg < 0)
                        avg = 0;

                    colRng.FormatConditions.Add(Type: Microsoft.Office.Interop.Excel.XlFormatConditionType.xlCellValue,
                                                Operator: Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlLess,
                                                Formula1: "=0");

                    colRng.FormatConditions.Add(Type: Microsoft.Office.Interop.Excel.XlFormatConditionType.xlCellValue,
                                                Operator: Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlLess,
                                                Formula1: "=" + avg);

                    colRng.FormatConditions.Add(Type: Microsoft.Office.Interop.Excel.XlFormatConditionType.xlCellValue,
                                                Operator: Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlGreaterEqual,
                                                Formula1: "=" + avg);

                    colRng.FormatConditions[1].Interior.Pattern = Microsoft.Office.Interop.Excel.XlPattern.xlPatternRectangularGradient;
                    colRng.FormatConditions[1].Interior.Gradient.RectangleLeft = 0.5;
                    colRng.FormatConditions[1].Interior.Gradient.RectangleRight = 0.5;
                    colRng.FormatConditions[1].Interior.Gradient.RectangleTop = 0.5;
                    colRng.FormatConditions[1].Interior.Gradient.RectangleBottom = 0.5;
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops.Clear();
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops.Add(0);
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops[1].ThemeColor = Microsoft.Office.Interop.Excel.XlThemeColor.xlThemeColorDark1;
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops.Add(1);
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops[2].Color = 6908415;//قرمز
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops[2].TintAndShade = 0;
                    colRng.FormatConditions[1].StopIfTrue = false;

                    colRng.FormatConditions[2].Interior.Pattern = Microsoft.Office.Interop.Excel.XlPattern.xlPatternRectangularGradient;
                    colRng.FormatConditions[2].Interior.Gradient.RectangleLeft = 0.5;
                    colRng.FormatConditions[2].Interior.Gradient.RectangleRight = 0.5;
                    colRng.FormatConditions[2].Interior.Gradient.RectangleTop = 0.5;
                    colRng.FormatConditions[2].Interior.Gradient.RectangleBottom = 0.5;
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops.Clear();
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops.Add(0);
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops[1].ThemeColor = Microsoft.Office.Interop.Excel.XlThemeColor.xlThemeColorDark1;
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops.Add(1);
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops[2].Color = 1688575;//نارنجی
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops[2].TintAndShade = 0;
                    colRng.FormatConditions[2].StopIfTrue = false;

                    colRng.FormatConditions[3].Interior.Pattern = Microsoft.Office.Interop.Excel.XlPattern.xlPatternRectangularGradient;
                    colRng.FormatConditions[3].Interior.Gradient.RectangleLeft = 0.5;
                    colRng.FormatConditions[3].Interior.Gradient.RectangleRight = 0.5;
                    colRng.FormatConditions[3].Interior.Gradient.RectangleTop = 0.5;
                    colRng.FormatConditions[3].Interior.Gradient.RectangleBottom = 0.5;
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops.Clear();
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops.Add(0);
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops[1].ThemeColor = Microsoft.Office.Interop.Excel.XlThemeColor.xlThemeColorDark1;
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops.Add(1);
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops[2].Color = 3523968;//سبز
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops[2].TintAndShade = 0;
                    colRng.FormatConditions[3].StopIfTrue = false;
                }
                if (de.Key.ToString() == "R2")
                {
                    double avg = Numeral.AnyToDouble(de.Value);
                    if (avg > 0)
                        avg = 0;

                    colRng.FormatConditions.Add(Type: Microsoft.Office.Interop.Excel.XlFormatConditionType.xlCellValue,
                                                Operator: Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlGreater,
                                                Formula1: "=0");

                    colRng.FormatConditions.Add(Type: Microsoft.Office.Interop.Excel.XlFormatConditionType.xlCellValue,
                                                Operator: Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlGreater,
                                                Formula1: "=" + avg);

                    colRng.FormatConditions.Add(Type: Microsoft.Office.Interop.Excel.XlFormatConditionType.xlCellValue,
                                                Operator: Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlLessEqual,
                                                Formula1: "=" + avg);

                    colRng.FormatConditions[1].Interior.Pattern = Microsoft.Office.Interop.Excel.XlPattern.xlPatternRectangularGradient;
                    colRng.FormatConditions[1].Interior.Gradient.RectangleLeft = 0.5;
                    colRng.FormatConditions[1].Interior.Gradient.RectangleRight = 0.5;
                    colRng.FormatConditions[1].Interior.Gradient.RectangleTop = 0.5;
                    colRng.FormatConditions[1].Interior.Gradient.RectangleBottom = 0.5;
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops.Clear();
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops.Add(0);
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops[1].ThemeColor = Microsoft.Office.Interop.Excel.XlThemeColor.xlThemeColorDark1;
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops.Add(1);
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops[2].Color = 6908415;//قرمز
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops[2].TintAndShade = 0;
                    colRng.FormatConditions[1].StopIfTrue = false;

                    colRng.FormatConditions[2].Interior.Pattern = Microsoft.Office.Interop.Excel.XlPattern.xlPatternRectangularGradient;
                    colRng.FormatConditions[2].Interior.Gradient.RectangleLeft = 0.5;
                    colRng.FormatConditions[2].Interior.Gradient.RectangleRight = 0.5;
                    colRng.FormatConditions[2].Interior.Gradient.RectangleTop = 0.5;
                    colRng.FormatConditions[2].Interior.Gradient.RectangleBottom = 0.5;
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops.Clear();
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops.Add(0);
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops[1].ThemeColor = Microsoft.Office.Interop.Excel.XlThemeColor.xlThemeColorDark1;
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops.Add(1);
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops[2].Color = 1688575;//نارنجی
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops[2].TintAndShade = 0;
                    colRng.FormatConditions[2].StopIfTrue = false;

                    colRng.FormatConditions[3].Interior.Pattern = Microsoft.Office.Interop.Excel.XlPattern.xlPatternRectangularGradient;
                    colRng.FormatConditions[3].Interior.Gradient.RectangleLeft = 0.5;
                    colRng.FormatConditions[3].Interior.Gradient.RectangleRight = 0.5;
                    colRng.FormatConditions[3].Interior.Gradient.RectangleTop = 0.5;
                    colRng.FormatConditions[3].Interior.Gradient.RectangleBottom = 0.5;
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops.Clear();
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops.Add(0);
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops[1].ThemeColor = Microsoft.Office.Interop.Excel.XlThemeColor.xlThemeColorDark1;
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops.Add(1);
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops[2].Color = 3523968;//سبز
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops[2].TintAndShade = 0;
                    colRng.FormatConditions[3].StopIfTrue = false;
                }
                if (de.Key.ToString() == "R3")
                {
                    colRng.FormatConditions.Add(Type: Microsoft.Office.Interop.Excel.XlFormatConditionType.xlCellValue,
                                                Operator: Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlGreater,
                                                Formula1: "=80");

                    colRng.FormatConditions.Add(Type: Microsoft.Office.Interop.Excel.XlFormatConditionType.xlCellValue,
                                                Operator: Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlGreater,
                                                Formula1: "=60");

                    colRng.FormatConditions.Add(Type: Microsoft.Office.Interop.Excel.XlFormatConditionType.xlCellValue,
                                                Operator: Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlGreater,
                                                Formula1: "=40");

                    colRng.FormatConditions.Add(Type: Microsoft.Office.Interop.Excel.XlFormatConditionType.xlCellValue,
                                                Operator: Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlGreater,
                                                Formula1: "=20");

                    colRng.FormatConditions.Add(Type: Microsoft.Office.Interop.Excel.XlFormatConditionType.xlCellValue,
                                                Operator: Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlLessEqual,
                                                Formula1: "=20");

                    colRng.FormatConditions[1].Interior.Pattern = Microsoft.Office.Interop.Excel.XlPattern.xlPatternRectangularGradient;
                    colRng.FormatConditions[1].Interior.Gradient.RectangleLeft = 0.5;
                    colRng.FormatConditions[1].Interior.Gradient.RectangleRight = 0.5;
                    colRng.FormatConditions[1].Interior.Gradient.RectangleTop = 0.5;
                    colRng.FormatConditions[1].Interior.Gradient.RectangleBottom = 0.5;
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops.Clear();
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops.Add(0);
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops[1].ThemeColor = Microsoft.Office.Interop.Excel.XlThemeColor.xlThemeColorDark1;
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops.Add(1);
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops[2].Color = 3523968;//سبز
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops[2].TintAndShade = 0;
                    colRng.FormatConditions[1].StopIfTrue = false;

                    colRng.FormatConditions[2].Interior.Pattern = Microsoft.Office.Interop.Excel.XlPattern.xlPatternRectangularGradient;
                    colRng.FormatConditions[2].Interior.Gradient.RectangleLeft = 0.5;
                    colRng.FormatConditions[2].Interior.Gradient.RectangleRight = 0.5;
                    colRng.FormatConditions[2].Interior.Gradient.RectangleTop = 0.5;
                    colRng.FormatConditions[2].Interior.Gradient.RectangleBottom = 0.5;
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops.Clear();
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops.Add(0);
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops[1].ThemeColor = Microsoft.Office.Interop.Excel.XlThemeColor.xlThemeColorDark1;
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops.Add(1);
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops[2].Color = 15773696;//آبی
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops[2].TintAndShade = 0;
                    colRng.FormatConditions[2].StopIfTrue = false;

                    colRng.FormatConditions[3].Interior.Pattern = Microsoft.Office.Interop.Excel.XlPattern.xlPatternRectangularGradient;
                    colRng.FormatConditions[3].Interior.Gradient.RectangleLeft = 0.5;
                    colRng.FormatConditions[3].Interior.Gradient.RectangleRight = 0.5;
                    colRng.FormatConditions[3].Interior.Gradient.RectangleTop = 0.5;
                    colRng.FormatConditions[3].Interior.Gradient.RectangleBottom = 0.5;
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops.Clear();
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops.Add(0);
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops[1].ThemeColor = Microsoft.Office.Interop.Excel.XlThemeColor.xlThemeColorDark1;
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops.Add(1);
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops[2].Color = 65279;//زرد
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops[2].TintAndShade = 0;
                    colRng.FormatConditions[3].StopIfTrue = false;

                    colRng.FormatConditions[4].Interior.Pattern = Microsoft.Office.Interop.Excel.XlPattern.xlPatternRectangularGradient;
                    colRng.FormatConditions[4].Interior.Gradient.RectangleLeft = 0.5;
                    colRng.FormatConditions[4].Interior.Gradient.RectangleRight = 0.5;
                    colRng.FormatConditions[4].Interior.Gradient.RectangleTop = 0.5;
                    colRng.FormatConditions[4].Interior.Gradient.RectangleBottom = 0.5;
                    colRng.FormatConditions[4].Interior.Gradient.ColorStops.Clear();
                    colRng.FormatConditions[4].Interior.Gradient.ColorStops.Add(0);
                    colRng.FormatConditions[4].Interior.Gradient.ColorStops[1].ThemeColor = Microsoft.Office.Interop.Excel.XlThemeColor.xlThemeColorDark1;
                    colRng.FormatConditions[4].Interior.Gradient.ColorStops.Add(1);
                    colRng.FormatConditions[4].Interior.Gradient.ColorStops[2].Color = 1688575;//نارنجی
                    colRng.FormatConditions[4].Interior.Gradient.ColorStops[2].TintAndShade = 0;
                    colRng.FormatConditions[4].StopIfTrue = false;

                    colRng.FormatConditions[5].Interior.Pattern = Microsoft.Office.Interop.Excel.XlPattern.xlPatternRectangularGradient;
                    colRng.FormatConditions[5].Interior.Gradient.RectangleLeft = 0.5;
                    colRng.FormatConditions[5].Interior.Gradient.RectangleRight = 0.5;
                    colRng.FormatConditions[5].Interior.Gradient.RectangleTop = 0.5;
                    colRng.FormatConditions[5].Interior.Gradient.RectangleBottom = 0.5;
                    colRng.FormatConditions[5].Interior.Gradient.ColorStops.Clear();
                    colRng.FormatConditions[5].Interior.Gradient.ColorStops.Add(0);
                    colRng.FormatConditions[5].Interior.Gradient.ColorStops[1].ThemeColor = Microsoft.Office.Interop.Excel.XlThemeColor.xlThemeColorDark1;
                    colRng.FormatConditions[5].Interior.Gradient.ColorStops.Add(1);
                    colRng.FormatConditions[5].Interior.Gradient.ColorStops[2].Color = 6908415;//قرمز
                    colRng.FormatConditions[5].Interior.Gradient.ColorStops[2].TintAndShade = 0;
                    colRng.FormatConditions[5].StopIfTrue = false;
                }
                if (de.Key.ToString() == "R4")
                {
                    colRng.FormatConditions.Add(Type: Microsoft.Office.Interop.Excel.XlFormatConditionType.xlCellValue,
                                                Operator: Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlGreater,
                                                Formula1: "=5");

                    colRng.FormatConditions.Add(Type: Microsoft.Office.Interop.Excel.XlFormatConditionType.xlCellValue,
                                                Operator: Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlGreater,
                                                Formula1: "=3");

                    colRng.FormatConditions.Add(Type: Microsoft.Office.Interop.Excel.XlFormatConditionType.xlCellValue,
                                                Operator: Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlLessEqual,
                                                Formula1: "=3");

                    colRng.FormatConditions[1].Interior.Pattern = Microsoft.Office.Interop.Excel.XlPattern.xlPatternRectangularGradient;
                    colRng.FormatConditions[1].Interior.Gradient.RectangleLeft = 0.5;
                    colRng.FormatConditions[1].Interior.Gradient.RectangleRight = 0.5;
                    colRng.FormatConditions[1].Interior.Gradient.RectangleTop = 0.5;
                    colRng.FormatConditions[1].Interior.Gradient.RectangleBottom = 0.5;
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops.Clear();
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops.Add(0);
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops[1].ThemeColor = Microsoft.Office.Interop.Excel.XlThemeColor.xlThemeColorDark1;
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops.Add(1);
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops[2].Color = 6908415;//قرمز
                    colRng.FormatConditions[1].Interior.Gradient.ColorStops[2].TintAndShade = 0;
                    colRng.FormatConditions[1].StopIfTrue = false;

                    colRng.FormatConditions[2].Interior.Pattern = Microsoft.Office.Interop.Excel.XlPattern.xlPatternRectangularGradient;
                    colRng.FormatConditions[2].Interior.Gradient.RectangleLeft = 0.5;
                    colRng.FormatConditions[2].Interior.Gradient.RectangleRight = 0.5;
                    colRng.FormatConditions[2].Interior.Gradient.RectangleTop = 0.5;
                    colRng.FormatConditions[2].Interior.Gradient.RectangleBottom = 0.5;
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops.Clear();
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops.Add(0);
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops[1].ThemeColor = Microsoft.Office.Interop.Excel.XlThemeColor.xlThemeColorDark1;
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops.Add(1);
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops[2].Color = 1688575;//نارنجی
                    colRng.FormatConditions[2].Interior.Gradient.ColorStops[2].TintAndShade = 0;
                    colRng.FormatConditions[2].StopIfTrue = false;

                    colRng.FormatConditions[3].Interior.Pattern = Microsoft.Office.Interop.Excel.XlPattern.xlPatternRectangularGradient;
                    colRng.FormatConditions[3].Interior.Gradient.RectangleLeft = 0.5;
                    colRng.FormatConditions[3].Interior.Gradient.RectangleRight = 0.5;
                    colRng.FormatConditions[3].Interior.Gradient.RectangleTop = 0.5;
                    colRng.FormatConditions[3].Interior.Gradient.RectangleBottom = 0.5;
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops.Clear();
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops.Add(0);
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops[1].ThemeColor = Microsoft.Office.Interop.Excel.XlThemeColor.xlThemeColorDark1;
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops.Add(1);
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops[2].Color = 3523968;//سبز
                    colRng.FormatConditions[3].Interior.Gradient.ColorStops[2].TintAndShade = 0;
                    colRng.FormatConditions[3].StopIfTrue = false;
                }
            }
        }

        //مصارفی
        public static GridFormatRule R1(BandedGridColumn bgc, decimal avg)
        {
            GridFormatRule gridFormatRule = new GridFormatRule();
            FormatConditionRuleIconSet formatConditionRuleIconSet = new FormatConditionRuleIconSet();
            FormatConditionIconSet iconSet = formatConditionRuleIconSet.IconSet = new FormatConditionIconSet();
            iconSet.Name = "TrafficLights3Unrimmed";
            iconSet.ValueType = FormatConditionValueType.Number;
          
            FormatConditionIconSetIcon icon1 = new FormatConditionIconSetIcon();
            FormatConditionIconSetIcon icon2 = new FormatConditionIconSetIcon();
            FormatConditionIconSetIcon icon3 = new FormatConditionIconSetIcon();

            icon1.Icon = Resources.ballgreen_16x16;
            icon2.Icon = Resources.ballorange_16x16;
            icon3.Icon = Resources.ballred_16x16;

            if (avg > 0)
                icon1.Value = Math.Round(avg, 2);
            else
                icon1.Value = 0;
            icon1.ValueComparison = FormatConditionComparisonType.Greater;
            icon2.Value = 0;
            icon2.ValueComparison = FormatConditionComparisonType.GreaterOrEqual;
            icon3.Value = -9999;
            icon3.ValueComparison = FormatConditionComparisonType.GreaterOrEqual;

            iconSet.Icons.Add(icon1);
            iconSet.Icons.Add(icon2);
            iconSet.Icons.Add(icon3);

            gridFormatRule.Column = bgc;
            gridFormatRule.Rule = formatConditionRuleIconSet;
            gridFormatRule.Tag = "R1";
            return gridFormatRule;
        }

        //مطالباتی
        public static GridFormatRule R2(BandedGridColumn bgc, decimal avg)
        {
            GridFormatRule gridFormatRule = new GridFormatRule();
            FormatConditionRuleIconSet formatConditionRuleIconSet = new FormatConditionRuleIconSet();
            FormatConditionIconSet iconSet = formatConditionRuleIconSet.IconSet = new FormatConditionIconSet();
            iconSet.Name = "TrafficLights3Unrimmed";
            iconSet.ValueType = FormatConditionValueType.Number;

            FormatConditionIconSetIcon icon1 = new FormatConditionIconSetIcon();
            FormatConditionIconSetIcon icon2 = new FormatConditionIconSetIcon();
            FormatConditionIconSetIcon icon3 = new FormatConditionIconSetIcon();

            icon1.Icon = Resources.ballgreen_16x16;
            icon2.Icon = Resources.ballorange_16x16;
            icon3.Icon = Resources.ballred_16x16;

            icon1.Value = -9999;
            icon1.ValueComparison = FormatConditionComparisonType.Greater;
            if (avg < 0)
                icon2.Value = Math.Round(avg, 2);
            else
                icon2.Value = 0;
            icon2.ValueComparison = FormatConditionComparisonType.GreaterOrEqual;
            icon3.Value = 0;
            icon3.ValueComparison = FormatConditionComparisonType.Greater;

            iconSet.Icons.Add(icon1);
            iconSet.Icons.Add(icon2);
            iconSet.Icons.Add(icon3);

            gridFormatRule.Column = bgc;
            gridFormatRule.Rule = formatConditionRuleIconSet;
            gridFormatRule.Tag = "R2";
            return gridFormatRule;
        }
       
        //برنامه عملیاتی
        public static GridFormatRule R3(BandedGridColumn bgc)
        {
            GridFormatRule gridFormatRule = new GridFormatRule();
            FormatConditionRuleIconSet formatConditionRuleIconSet = new FormatConditionRuleIconSet();
            FormatConditionIconSet iconSet = formatConditionRuleIconSet.IconSet = new FormatConditionIconSet();
            iconSet.Name = "TrafficLights3Unrimmed";
            iconSet.ValueType = FormatConditionValueType.Number;

            FormatConditionIconSetIcon icon1 = new FormatConditionIconSetIcon();
            FormatConditionIconSetIcon icon2 = new FormatConditionIconSetIcon();
            FormatConditionIconSetIcon icon3 = new FormatConditionIconSetIcon();
            FormatConditionIconSetIcon icon4 = new FormatConditionIconSetIcon();
            FormatConditionIconSetIcon icon5 = new FormatConditionIconSetIcon();

            icon1.Icon = Resources.ballgreen_16x16;
            icon2.Icon = Resources.ballblue_16x16;
            icon3.Icon = Resources.ballyellow_16x16;
            icon4.Icon = Resources.ballorange_16x16;
            icon5.Icon = Resources.ballred_16x16;

            icon1.Value = 80;
            icon1.ValueComparison = FormatConditionComparisonType.Greater;
            icon2.Value = 60;
            icon2.ValueComparison = FormatConditionComparisonType.Greater;
            icon3.Value = 40;
            icon3.ValueComparison = FormatConditionComparisonType.Greater;
            icon4.Value = 20;
            icon4.ValueComparison = FormatConditionComparisonType.Greater;
            icon5.Value = decimal.MinValue;
            icon5.ValueComparison = FormatConditionComparisonType.GreaterOrEqual;

            iconSet.Icons.Add(icon1);
            iconSet.Icons.Add(icon2);
            iconSet.Icons.Add(icon3);
            iconSet.Icons.Add(icon4);
            iconSet.Icons.Add(icon5);

            gridFormatRule.Column = bgc;
            gridFormatRule.Rule = formatConditionRuleIconSet;
            gridFormatRule.Tag = "R3";
            return gridFormatRule;
        }
       
        //NPL
        public static GridFormatRule R4(BandedGridColumn bgc)
        {
            GridFormatRule gridFormatRule = new GridFormatRule();
            FormatConditionRuleIconSet formatConditionRuleIconSet = new FormatConditionRuleIconSet();
            FormatConditionIconSet iconSet = formatConditionRuleIconSet.IconSet = new FormatConditionIconSet();
            iconSet.Name = "TrafficLights3Unrimmed";
            iconSet.ValueType = FormatConditionValueType.Number;

            FormatConditionIconSetIcon icon1 = new FormatConditionIconSetIcon();
            FormatConditionIconSetIcon icon2 = new FormatConditionIconSetIcon();
            FormatConditionIconSetIcon icon3 = new FormatConditionIconSetIcon();

            icon1.Icon = Resources.ballgreen_16x16;
            icon2.Icon = Resources.ballorange_16x16;
            icon3.Icon = Resources.ballred_16x16;

            icon1.Value = 0;
            icon1.ValueComparison = FormatConditionComparisonType.GreaterOrEqual;
            icon2.Value = 3;
            icon2.ValueComparison = FormatConditionComparisonType.Greater;
            icon3.Value = 5;
            icon3.ValueComparison = FormatConditionComparisonType.Greater;

            iconSet.Icons.Add(icon1);
            iconSet.Icons.Add(icon2);
            iconSet.Icons.Add(icon3);

            gridFormatRule.Column = bgc;
            gridFormatRule.Rule = formatConditionRuleIconSet;
            gridFormatRule.Tag = "R4";
            return gridFormatRule;
        }

    }
}