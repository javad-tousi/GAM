using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using GAM.Modules;
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
    class GridViewManager
    {

        public BandedGridView CreateView(string reportName, DataTable table, List<GridBand> allbands)
        {
            GridBand mainBand = new GridBand();
            mainBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            mainBand.AppearanceHeader.Options.UseTextOptions = true;
            mainBand.Caption = reportName;

            BandedGridView bgv = new BandedGridView();
            bgv.Name = table.TableName;
            bgv.OptionsView.ColumnAutoWidth = false;
            bgv.Appearance.BandPanel.Font = new System.Drawing.Font("B Yekan", 8.5F);
            bgv.Appearance.BandPanel.Options.UseFont = true;
            bgv.Appearance.HeaderPanel.Font = new System.Drawing.Font("B Yekan", 8.5F);
            bgv.Appearance.HeaderPanel.Options.UseFont = true;
            bgv.Appearance.Row.Font = new System.Drawing.Font("B Yekan", 8.5F);
            bgv.Appearance.Row.Options.UseFont = true;
            bgv.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            bgv.Appearance.VertLine.Options.UseBackColor = true;
            bgv.DetailHeight = 700;
            bgv.OptionsBehavior.Editable = false;
            bgv.OptionsBehavior.ReadOnly = true;
            bgv.OptionsView.ShowGroupPanel = false;
            bgv.Bands.Add(mainBand);

            DevExpress.Sparkline.LineSparklineView lineSparkline = new DevExpress.Sparkline.LineSparklineView();
            lineSparkline.MarkerSize = 3;
            lineSparkline.MarkerColor = Color.FromArgb(208, 0, 0);
            lineSparkline.Color = Color.FromArgb(55, 96, 146);
            lineSparkline.ShowMarkers = true;

            DevExpress.XtraEditors.Repository.RepositoryItemSparklineEdit sparklineEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSparklineEdit();
            sparklineEdit1.View = lineSparkline;
            DevExpress.XtraEditors.Repository.RepositoryItemSparklineEdit sparklineEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemSparklineEdit();
            sparklineEdit2.View = lineSparkline;
            DevExpress.XtraEditors.Repository.RepositoryItemSparklineEdit sparklineEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemSparklineEdit();
            sparklineEdit3.View = lineSparkline;
            DevExpress.XtraEditors.Repository.RepositoryItemSparklineEdit sparklineEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemSparklineEdit();
            sparklineEdit4.View = lineSparkline;
            DevExpress.XtraEditors.Repository.RepositoryItemSparklineEdit sparklineEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemSparklineEdit();
            sparklineEdit5.View = lineSparkline;

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit buttonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            buttonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            buttonEdit.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;

            foreach (DataColumn col in table.Columns)
            {
                GridBand currentband = mainBand;
                string[] array = col.ColumnName.Split('.');

                for (int i = 0; i < array.Length; i++)
                {
                    if (i == array.Length - 1)
                    {
                        if (currentband != null)
                        {
                            BandedGridColumn bgc = new BandedGridColumn();
                            bgc.Tag = col.Ordinal;
                            bgc.FieldName = col.ColumnName;
                            bgc.Caption = col.Caption;
                            if (col.ExtendedProperties.ContainsKey("Visible") && !bool.Parse(col.ExtendedProperties["Visible"].ToString()))
                                bgc.Visible = false;
                            else
                                bgc.Visible = true;
                            if (col.ExtendedProperties.ContainsKey("FormatNumber"))
                            {
                                bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                                bgc.DisplayFormat.FormatString = col.ExtendedProperties["FormatNumber"].ToString();
                            }
                            if (col.ExtendedProperties.ContainsKey("FormatRule"))
                            {
                                DictionaryEntry de = (DictionaryEntry)col.ExtendedProperties["FormatRule"];
                                if (de.Key.ToString() == "R1")
                                {
                                    var rule = FormattingRules.R1(bgc, Numeral.AnyToDecimal(de.Value));
                                    bgv.FormatRules.Add(rule);
                                }
                                if (de.Key.ToString() == "R2")
                                {
                                    var rule = FormattingRules.R2(bgc, Numeral.AnyToDecimal(de.Value));
                                    bgv.FormatRules.Add(rule);
                                }
                                if (de.Key.ToString() == "R3")
                                {
                                    var rule = FormattingRules.R3(bgc);
                                    bgv.FormatRules.Add(rule);
                                }
                                if (de.Key.ToString() == "R4")
                                {
                                    var rule = FormattingRules.R4(bgc);
                                    bgv.FormatRules.Add(rule);
                                }
                            }
                            bgc.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
                            bgc.AppearanceCell.Options.UseBackColor = true;
                            bgc.AppearanceCell.Options.UseTextOptions = true;
                            bgc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            bgc.AppearanceHeader.Options.UseTextOptions = true;
                            bgc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                            if (col.ColumnName.EndsWith("Sparkline1"))
                                bgc.ColumnEdit = sparklineEdit1;
                            if (col.ColumnName.EndsWith("Sparkline2"))
                                bgc.ColumnEdit = sparklineEdit2;
                            if (col.ColumnName.EndsWith("Sparkline3"))
                                bgc.ColumnEdit = sparklineEdit3;
                            if (col.ColumnName.EndsWith("Sparkline4"))
                                bgc.ColumnEdit = sparklineEdit4;
                            if (col.ColumnName.EndsWith("Sparkline5"))
                                bgc.ColumnEdit = sparklineEdit5;
                            if (col.ColumnName == "Charts.AdvChart")
                            {
                                bgc.ColumnEdit = buttonEdit;
                                buttonEdit.Buttons[0].Caption = "نمودار";
                                buttonEdit.Buttons[0].Tag = col.ExtendedProperties["Properties"];
                            }

                            currentband.Columns.Add(bgc);
                            bgv.Columns.Add(bgc);
                        }
                    }
                    else
                    {
                        GridBand band = currentband.Children[array[i]];
                        if (band != null)
                        {
                            currentband = currentband.Children[array[i]];
                        }
                        else
                        {
                            GridBand newband = new GridBand();
                            GridBand bnd = allbands.Where(x => x.Name == array[i]).First();
                            newband.Name = array[i];
                            newband.AppearanceHeader.TextOptions.HAlignment = bnd.AppearanceHeader.TextOptions.HAlignment;
                            newband.AppearanceHeader.TextOptions.WordWrap = bnd.AppearanceHeader.TextOptions.WordWrap;
                            newband.AppearanceHeader.Options.UseTextOptions = bnd.AppearanceHeader.Options.UseTextOptions;
                            newband.OptionsBand.FixedWidth = bnd.OptionsBand.FixedWidth;
                            newband.MinWidth = bnd.MinWidth;
                            newband.RowCount = bnd.RowCount;
                            newband.Caption = bnd.Caption;
                            currentband = currentband.Children.Add(newband);
                        }
                    }
                }
            }

            foreach (GridBand gb in bgv.Bands)
            {
                HideNoneColumnsBands(gb);
                HideNoneColumnsBands(gb);
            }


            return bgv;
        }

        public static GridView CreateView(DataTable table)
        {
            GridView gv = new GridView();
            gv.Name = table.TableName;
            gv.OptionsView.ColumnAutoWidth = false;
            gv.Appearance.HeaderPanel.Font = new System.Drawing.Font("B Yekan", 8.5F);
            gv.Appearance.HeaderPanel.Options.UseFont = true;
            gv.Appearance.Row.Font = new System.Drawing.Font("B Yekan", 8.5F);
            gv.Appearance.Row.Options.UseFont = true;
            gv.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            gv.Appearance.VertLine.Options.UseBackColor = true;
            gv.DetailHeight = 700;
            gv.OptionsBehavior.Editable = false;
            gv.OptionsBehavior.ReadOnly = true;
            gv.OptionsView.ShowGroupPanel = false;

            foreach (DataColumn col in table.Columns)
            {
                GridColumn gc = new GridColumn();
                gc.FieldName = col.ColumnName;
                gc.Caption = col.Caption;
                gc.Visible = true;
                gc.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
                gc.AppearanceCell.Options.UseBackColor = true;
                gc.AppearanceCell.Options.UseTextOptions = true;
                gc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gc.AppearanceHeader.Options.UseTextOptions = true;
                gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                if (col.ExtendedProperties.ContainsKey("Visible") && !bool.Parse(col.ExtendedProperties["Visible"].ToString()))
                    gc.Visible = false;
                else
                    gc.Visible = true;
                if (col.ExtendedProperties.ContainsKey("FormatNumber"))
                {
                    gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gc.DisplayFormat.FormatString = col.ExtendedProperties["FormatNumber"].ToString();
                }
                gv.Columns.Add(gc);
            }
            return gv;
        }

        public static GridBand CreateStaticBand(string name, string caption)
        {
            GridBand band = new GridBand();
            band.Name = name;
            band.AppearanceHeader.Options.UseTextOptions = true;
            band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            band.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            band.Caption = caption;
            return band;
        }
        public GridBand CreateBand(string name, string caption)
        {
            GridBand band = new GridBand();
            band.Name = name;
            band.AppearanceHeader.Options.UseTextOptions = true;
            band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            band.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            band.Caption = caption;
            return band;
        }
        public GridBand CreateBand(string name, string caption, int width)
        {
            GridBand band = new GridBand();
            band.Name = name;
            band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            band.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            band.AppearanceHeader.Options.UseTextOptions = true;
            band.OptionsBand.FixedWidth = true;
            band.MinWidth = width;
            band.Caption = caption;
            return band;
        }
        public GridBand CreateBand(string name, string caption, int width, int rowCount)
        {
            GridBand band = new GridBand();
            band.Name = name;
            band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            band.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            band.AppearanceHeader.Options.UseTextOptions = true;
            band.OptionsBand.FixedWidth = true;
            band.MinWidth = width;
            band.Caption = caption;
            band.RowCount = rowCount;
            return band;
        }

        public GridBand CreateBand2(string name, string caption, int width, int rowCount)
        {
            GridBand band = new GridBand();
            band.Name = name;
            band.AppearanceHeader.Options.UseTextOptions = true;
            band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            band.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            band.MinWidth = width;
            band.Caption = caption;
            band.RowCount = rowCount;
            return band;
        }

        private void HideNoneColumnsBands(GridBand mainband)
        {
            if (mainband.HasChildren)//a parent band 
            {
                bool visible = false;

                foreach (GridBand childBand in mainband.Children)
                {
                    if (childBand.Visible == true)
                       visible = true; 
                }
                mainband.Visible = visible;

                foreach (GridBand childBand in mainband.Children)
                {
                    HideNoneColumnsBands(childBand);
                }
            }
            else
            {
                bool visible = false;

                foreach (BandedGridColumn column in mainband.Columns)
                {
                    if (column.Visible)
                        visible = true;
                }

                if (mainband.Columns.Count > 0)
                {
                    mainband.Visible = visible;
                }
            }
        }

        public static void VisibleBranchesId(IDictionary<string, BandedGridView> bandedGridViewList, bool visible) 
        {
            foreach (var bgv in bandedGridViewList)
            {
                if (bgv.Key == "Branches")
                    GridViewManager.VisibleColumnInBands(bgv.Value.Bands[0], "Branches.BranchId", visible);
                if (bgv.Key == "Domains")
                    GridViewManager.VisibleColumnInBands(bgv.Value.Bands[0], "Domains.DomainId", visible);
                if (bgv.Key == "Province")
                    GridViewManager.VisibleColumnInBands(bgv.Value.Bands[0], "Province.ProvinceId", visible);
            }
        }

        public static void VisibleColumnInBands(GridBand mainband, string columnName, bool visible)
        {
            if (mainband.HasChildren)//a parent band 
            {
                foreach (GridBand childBand in mainband.Children)
                {
                    VisibleColumnInBands(childBand, columnName, visible);
                }
            }
            else
            {
                foreach (BandedGridColumn column in mainband.Columns)
                {
                    if (column.FieldName == columnName)
                    {
                        column.Visible = visible;
                        column.VisibleIndex = 0;
                    }
                }
            }
        }

    }
}
