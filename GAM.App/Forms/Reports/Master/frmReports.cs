using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraNavBar;
using DevExpress.XtraPrinting;
using DevExpress.XtraTab;
using DevExpress.XtraVerticalGrid.Rows;
using GAM.Dialogs;
using GAM.Forms.Information.Library;
using GAM.Forms.Profile.Kargozini.Library;
using GAM.Forms.Reports.Library;
using GAM.Forms.Reports.Queries;
using GAM.Modules;
using MD.PersianDateTime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace GAM.Forms.Reports.Master
{
    public partial class frmReports : DevExpress.XtraEditors.XtraForm
    {
        Dictionary<string, object> SavedSeries1 = new Dictionary<string, object>();
        Dictionary<string, object> SavedSeries2 = new Dictionary<string, object>();
        Dictionary<string, object> SavedSeries3 = new Dictionary<string, object>();
        Dictionary<string, object> SavedSeries4 = new Dictionary<string, object>();
        Dictionary<string, object> SavedSeries5 = new Dictionary<string, object>();
        Dictionary<string, object[]> SavedSeries6 = new Dictionary<string, object[]>();
        Dictionary<string, object> SavedSeries7 = new Dictionary<string, object>();

        dlgNewReport frmNewReport = null;
        DataTable TableReports = new DataTable();

        public frmReports()
        {
            InitializeComponent();
            this.frmNewReport = new dlgNewReport(this);
            this.frmNewReport.btnCancel.Click += btnCancel_Click;
            tabPageNewReport.Controls.Add(this.frmNewReport.pnlMain);
            TableReports.Columns.Add("Guid", typeof(string));
            TableReports.Columns.Add("ReportName", typeof(string));
            TableReports.Columns.Add("DataSet", typeof(DataSet));
            TableReports.Columns.Add("GridControl", typeof(GridControl));
            gridReports.DataSource = this.TableReports;
        }

        #region Methods

        private void DrawChart()
        {
            try
            {
                    DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgPleaseWait), true, true, false);
                    Application.DoEvents();
                    switch (1)
                    {
                        case 1:
                            Chart1();
                            break;
                        case 2:
                            Chart2();
                            break;
                        case 3:
                            Chart3();
                            break;
                        case 4:
                            Chart4();
                            break;
                        case 5:
                            Chart5();
                            break;
                        case 6:
                            break;
                        case 7:
                            Chart7();
                            break;
                        default:
                            break;
                    }
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            }
            catch
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            }
        }

        private static void WriteTableToRange(int firstRow, Point startCell, Point endCell, List<DataColumn> sortColumns, DataTable table, Microsoft.Office.Interop.Excel.Worksheet worksheet)
        {
            int rows = table.Rows.Count;
            int columns = endCell.X - startCell.X + 1;

            var data = new object[rows, columns];
            for (var row = 1; row <= rows; row++)
            {
                int counter = 0;
                foreach (DataColumn col in sortColumns)
                {
                    ++counter;
                    data[row - 1, counter - 1] = table.Rows[row - 1][col.ColumnName];
                }
            }

            var writeRange = worksheet.Range[worksheet.Cells[firstRow, startCell.X], worksheet.Cells[endCell.Y, startCell.X + columns - 1]];

            writeRange.Value2 = data;
        }

        private void SetXBandedRowsFormat(Microsoft.Office.Interop.Excel.Worksheet ShXL, dynamic rngBands, long colorIndex)
        {
            rngBands.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            rngBands.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            rngBands.Font.Name = "B Yekan";
            rngBands.Font.Size = 10F;
            rngBands.Borders.Color = Color.DarkGray;
            rngBands.Interior.Pattern = Microsoft.Office.Interop.Excel.XlPattern.xlPatternRectangularGradient;
            rngBands.Interior.Gradient.RectangleLeft = 0.5;
            rngBands.Interior.Gradient.RectangleRight = 0.5;
            rngBands.Interior.Gradient.RectangleTop = 0.5;
            rngBands.Interior.Gradient.RectangleBottom = 0.5;
            rngBands.Interior.Gradient.ColorStops.Clear();
            rngBands.Interior.Gradient.ColorStops.Add(0);/////
            rngBands.Interior.Gradient.ColorStops[1].ThemeColor = Microsoft.Office.Interop.Excel.XlThemeColor.xlThemeColorDark1;
            rngBands.Interior.Gradient.ColorStops.Add(1);/////
            rngBands.Interior.Gradient.ColorStops[2].Color = colorIndex;
            rngBands.Interior.Gradient.ColorStops[2].TintAndShade = 0;
            rngBands.ReadingOrder = (int)Microsoft.Office.Interop.Excel.Constants.xlRTL;

        }

        private void SetXRangeRowsFormat(Microsoft.Office.Interop.Excel.Worksheet ShXL, dynamic rngRows, long colorIndex)
        {
            rngRows.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            rngRows.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            rngRows.Font.Name = "B Yekan";
            rngRows.Font.Size = 10F;
            rngRows.Borders.Color = Color.DarkGray;
            rngRows.Interior.Pattern = Microsoft.Office.Interop.Excel.XlPattern.xlPatternLinearGradient;
            rngRows.Interior.Gradient.Degree = 270;
            rngRows.Interior.Gradient.ColorStops.Clear();
            rngRows.Interior.Gradient.ColorStops.Add(0);/////
            rngRows.Interior.Gradient.ColorStops[1].ThemeColor = Microsoft.Office.Interop.Excel.XlThemeColor.xlThemeColorDark1;
            rngRows.Interior.Gradient.ColorStops.Add(1);/////
            rngRows.Interior.Gradient.ColorStops[2].Color = colorIndex;
            rngRows.Interior.Gradient.ColorStops[2].TintAndShade = 0;
        }

        private void SetXLastRowFormat(Microsoft.Office.Interop.Excel.Worksheet ShXL, dynamic rngLastRow, long colorIndex)
        {
            rngLastRow.Interior.Pattern = Microsoft.Office.Interop.Excel.XlPattern.xlPatternLinearGradient;
            rngLastRow.Interior.Gradient.Degree = 270;
            rngLastRow.Interior.Gradient.ColorStops.Clear();
            rngLastRow.Interior.Gradient.ColorStops.Add(0);/////
            rngLastRow.Interior.Gradient.ColorStops[1].ThemeColor = Microsoft.Office.Interop.Excel.XlThemeColor.xlThemeColorDark1;
            rngLastRow.Interior.Gradient.ColorStops.Add(1);/////
            rngLastRow.Interior.Gradient.ColorStops[2].Color = colorIndex;
            rngLastRow.Interior.Gradient.ColorStops[2].TintAndShade = 0;
        }

        public GridControl NewGridControl(DataSet ds, string guid)
        {
            GridControl gridControl = new GridControl();
            gridControl.Name = "gridControl";
            gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            gridControl.LookAndFeel.SkinName = "Office 2007 Silver";
            gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControl.ViewRegistered += gridControl_ViewRegistered;
            if (ds.ExtendedProperties.ContainsKey("BandedGridViewList"))
            {
                IDictionary<string, BandedGridView> bandedGridViewList = ds.ExtendedProperties["BandedGridViewList"] as IDictionary<string, BandedGridView>;
                foreach (var bgv in bandedGridViewList)
                {
                    gridControl.ViewCollection.AddRange(new BaseView[] { bgv.Value });
                    bgv.Value.RowCellClick += gridView_RowCellClick;
                    bgv.Value.DoubleClick += gridView_DoubleClick;
                    bgv.Value.MasterRowExpanded += gridView_MasterRowExpanded;
                    bgv.Value.Appearance.FocusedCell.BackColor = Color.Yellow;
                    bgv.Value.Appearance.FocusedRow.BackColor = Color.Yellow;
                    bgv.Value.Appearance.SelectedRow.BackColor = Color.Yellow;
                    bgv.Value.Appearance.HideSelectionRow.BackColor = Color.Yellow;

                }

                foreach (DataRelation re in ds.Relations)
                {
                    DevExpress.XtraGrid.GridLevelNode level = new DevExpress.XtraGrid.GridLevelNode();
                    level.LevelTemplate = bandedGridViewList[re.ChildTable.TableName];
                    level.RelationName = re.RelationName;
                    gridControl.LevelTree.Nodes.Add(level);
                }
                foreach (DataRelation re in ds.Relations)
                {
                    if (re.ChildTable.ChildRelations.Count > 0)
                    {
                        foreach (DataRelation cre in re.ChildTable.ChildRelations)
                        {
                            var le = gridControl.LevelTree.Nodes[re.RelationName];
                            le.Nodes.Add(gridControl.LevelTree.Nodes[cre.RelationName]);
                        }
                    }
                }
                string mainView = ds.ExtendedProperties["MainTable"].ToString();
                gridControl.MainView = bandedGridViewList[mainView];
                gridControl.DataSource = ds.Tables[mainView];
                GridView gv = gridControl.MainView as GridView;
                gv.BestFitColumns();

                if (guid.Length > 0)
                {
                    DataRow row = this.TableReports.AsEnumerable().Where(x => x["Guid"].ToString() == guid).FirstOrDefault();
                    if (row != null)
                    {
                        int id = this.TableReports.Rows.IndexOf(row);
                        this.TableReports.Rows[id]["DataSet"] = ds;
                        this.TableReports.Rows[id]["ReportName"] = ds.ExtendedProperties["ReportName"].ToString();
                        this.TableReports.Rows[id]["GridControl"] = gridControl;
                        SavedSeries1.Remove(row["Guid"].ToString());
                        SavedSeries2.Remove(row["Guid"].ToString());
                        SavedSeries3.Remove(row["Guid"].ToString());
                        SavedSeries4.Remove(row["Guid"].ToString());
                        SavedSeries5.Remove(row["Guid"].ToString());
                        SavedSeries6.Remove(row["Guid"].ToString());
                        SavedSeries7.Remove(row["Guid"].ToString());
                        List<IChart> list = new List<IChart>();
                        foreach (Control c in pnlCharts.Controls)
                        {
                            if (c is IChart)
                            {
                                IChart chart = c as IChart;
                                if (chart.Guid == row["Guid"].ToString())
                                    list.Add(chart);
                            }
                        }
                        foreach (IChart i in list)
                        {
                            pnlCharts.Controls.Remove(i);
                        }
                        tabControl.SelectedTabPageIndex = 1;
                    }
                    else 
                    {
                        DataRow newRow = this.TableReports.NewRow();
                        newRow["Guid"] = guid;
                        newRow["ReportName"] = ds.ExtendedProperties["ReportName"].ToString();
                        newRow["DataSet"] = ds;
                        newRow["GridControl"] = gridControl;
                        this.TableReports.Rows.Add(newRow);
                        frmNewReport.NewReport();
                    }
                }

                RefreshTabPages(guid);
            }
            return gridControl;
        }

        private long GetRandomColor()
        {
            List<long> colors = new List<long>();
            colors.Add(13823478);
            colors.Add(14803455);
            colors.Add(14281983);
            colors.Add(13762550);
            colors.Add(14548965);
            colors.Add(16383965);
            colors.Add(16772829);
            colors.Add(16770539);
            colors.Add(16769526);
            colors.Add(16245247);
            colors.Add(14350065);
            colors.Add(15264490);
            colors.Add(14409181);
            colors.Add(13753322);
            colors.Add(13755385);
            colors.Add(14152443);
            colors.Add(15199189);
            colors.Add(16115667);
            colors.Add(16046565);
            colors.Add(15193078);
            colors.Add(14013435);
            colors.Add(15135231);
            colors.Add(15000317);
            colors.Add(14799610);
            colors.Add(14540485);
            colors.Add(15001563);
            colors.Add(15462384);
            colors.Add(15127740);
            colors.Add(16316644);
            colors.Add(16112623);

            Random rnd = new Random();
            rnd.Next(0, colors.Count - 1);
            return colors[rnd.Next(0, colors.Count - 1)];
        }

        private void RefreshTabPages(string guid)
        {
            gridReports.DataSource = this.TableReports;
            viewReports.Focus();
            viewReports.FocusedRowHandle = 0;
            tabReports.TabPages.Clear();
            int focusedIndex = -1;
            foreach (DataRow r in this.TableReports.Rows)
            {
                ++focusedIndex;
                XtraTabPage xpage = new XtraTabPage();
                xpage.Tag = r["Guid"].ToString();
                xpage.Text = r["ReportName"].ToString();
                xpage.Controls.Add(r["GridControl"] as GridControl);
                tabReports.TabPages.Add(xpage);
                if (r["Guid"].ToString() == guid)
                {
                    tabReports.SelectedTabPage = xpage;
                    viewReports.FocusedRowHandle = focusedIndex;
                }
            }
        }

        private void SaveReports()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Save Report";
            dlg.Filter = "GAM Report File|*.grf";
            dlg.ShowDialog();
            if (dlg.FileName != "")
            {
                if (tabReports.TabPages.Count > 0)
                {
                    XDocument xdoc = new XDocument();
                    XElement xtabs = new XElement("XTabs");

                    for (int i = 0; i < viewReports.RowCount; i++)
                    {
                        DataRow row = viewReports.GetDataRow(i);
                        Application.DoEvents();
                        DataSet ds = row["DataSet"] as DataSet;
                        if (ds != null)
                        {
                            XElement xtab = new XElement("XTab");
                            foreach (System.Collections.DictionaryEntry item in ds.ExtendedProperties)
                            {
                                if (item.Value != null)
                                {
                                    XElement xproperty = new XElement(item.Key.ToString(), item.Value.ToString());
                                    xtab.Add(xproperty);
                                }
                            }
                            Application.DoEvents();

                            xtabs.Add(xtab);
                        }

                    }

                    xdoc.Add(xtabs);
                    xdoc.Save(dlg.FileName);
                    DevExpress.XtraEditors.XtraMessageBox.Show("فایل شما با موفقیت ذخیره شد", "ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void LoadReports()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "GAM Report File (*.grf)|*.grf";
            dlg.FilterIndex = 0;
            dlg.RestoreDirectory = true;
            dlg.Multiselect = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.FileName != string.Empty)
                {
                    tabReports.TabPages.Clear();
                    mnuCharts.ItemLinks.Clear();
                    try
                    {
                        XmlDocument xdoc = new XmlDocument();
                        xdoc.Load(dlg.FileName);
                        XmlNodeList list = xdoc.GetElementsByTagName("XTab");
                        progressBar.Show();
                        pnlBottom.Hide();
                        Application.DoEvents();
                        for (int i = 0; i < list.Count; i++)
                        {
                            XmlNode xn = list[i];
                            QueryProperties properties = new QueryProperties();
                            foreach (XmlNode xnode in xn.ChildNodes)
                                properties.Add(xnode.Name, xnode.InnerText);

                            new dlgNewReport(this, properties);
                            progressBar.EditValue = ((double)i + (double)1) / (double)list.Count * (double)100;
                            Application.DoEvents();
                        }
                        progressBar.Hide();
                        pnlBottom.Show();
                        DevExpress.XtraEditors.XtraMessageBox.Show("فایل شما با موفقیت بارگذاری شد", "پیام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        progressBar.Hide();
                        pnlBottom.Show();
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExportTables(DataSet[] dataSets) 
        {
            try
            {
                dlgExportList dlg = new dlgExportList(dataSets);
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ShowBranchesId(true);
                    switch (dlg.SaveNumber)
                    {
                        case 1:
                            Export1(dataSets, dlg.SaveFormat);
                            ShowBranchesId(false);
                            break;
                        case 2:
                            Export2(dataSets, dlg.SaveFormat);
                            ShowBranchesId(false);
                            break;
                        case 3:
                            Export3(dataSets, dlg.SaveFormat);
                            ShowBranchesId(false);
                            break;
                        case 4:
                            Export4(dataSets, dlg.SaveFormat);
                            ShowBranchesId(false);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch
            {
            }
        }
    
        private void ShowBranchesId(bool show)
        {
            foreach (XtraTabPage page in tabReports.TabPages)
            {
                foreach (Control c in page.Controls)
                {
                    if (c is GridControl)
                    {
                        GridControl gc = c as GridControl;
                        foreach (BaseView v in gc.ViewCollection)
                        {
                            if (v is BandedGridView)
                            {
                                BandedGridView bgv = v as BandedGridView;
                                if (bgv.Name == "Province")
                                {
                                    foreach (BandedGridColumn col in bgv.Columns)
                                    {
                                        if (col.FieldName == "Province.ProvinceId")
                                        {
                                            col.Visible = show;
                                            if (show)
                                            {
                                                col.VisibleIndex = int.Parse(col.Tag.ToString());
                                                col.MinWidth = 30;
                                            }
                                        }
                                    }

                                    bgv.BestFitColumns();
                                }
                                if (bgv.Name == "Domains")
                                {
                                    foreach (BandedGridColumn col in bgv.Columns)
                                    {
                                        if (col.FieldName == "Domains.DomainId")
                                        {
                                            col.Visible = show;
                                            if (show)
                                            {
                                                col.VisibleIndex = int.Parse(col.Tag.ToString());
                                                col.MinWidth = 37;
                                            }
                                        }
                                    }

                                    bgv.BestFitColumns();

                                }
                                if (bgv.Name == "Branches")
                                {
                                    foreach (BandedGridColumn col in bgv.Columns)
                                    {
                                        if (col.FieldName == "Branches.BranchId")
                                        {
                                            col.Visible = show;
                                            if (show)
                                            {
                                                col.VisibleIndex = int.Parse(col.Tag.ToString());
                                                col.MinWidth = 40;
                                            }
                                        }
                                    }

                                    bgv.BestFitColumns();
                                }
                            }
                        }
                    }
                }
            }

        }

        private void FocusGridRow(GridView view) 
        {
            btnBranchInfo.Enabled = false;
            btnBranchInfo.Tag = null;

            if (view != null)
            {
                view.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
                DataRow row = view.GetFocusedDataRow();
                if (row != null)
                {
                    btnBranchInfo.Enabled = true;

                    if (row.Table.Columns.Contains("Branches.BranchId"))
                        btnBranchInfo.Tag = row["Branches.BranchId"].ToString();
                    else if (row.Table.Columns.Contains("Domains.DomainId"))
                        btnBranchInfo.Tag = row["Domains.DomainId"].ToString();
                    else if (row.Table.Columns.Contains("Province.ProvinceId"))
                        btnBranchInfo.Tag = row["Province.ProvinceId"].ToString();
                    

                    if (btnBranchInfo.Tag != null)
                    {
                        foreach (Control c in pnlCharts.Controls)
                        {
                            if (c is IChart)
                            {
                                IChart chart = c as IChart;
                                if (chart.Visible)
                                {
                                    chart.UnitId = btnBranchInfo.Tag.ToString();
                                    chart.ShowChart();
                                }
                            }
                        }
                    }
                }
                else 
                {
                    view.BestFitColumns();
                }
            }
        }

        private void ProgressBar(int i, int max, int step)
        {
            if (max > 1)
                progressBar.EditValue = ((double)i + (double)1) / (double)max * (double)100;
            else
                progressBar.EditValue = step;

            Application.DoEvents();
        }
       
        #endregion

        #region Events

        private async void gridControl_ViewRegistered(object sender, DevExpress.XtraGrid.ViewOperationEventArgs e)
        {
            await Task.Delay(50);
            BandedGridView gv = e.View as BandedGridView;
            gv.BestFitColumns();
        }

        private void gridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
           GridView view = (GridView)sender;
           FocusGridRow(view);
            if (e.Column.ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit)
            {
                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit advChart = e.Column.ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit;
                if (btnBranchInfo.Tag != null & advChart.Buttons[0].Tag != null)
                {
                    IChartLinks.Run(btnBranchInfo.Tag.ToString(), view.GetDataRow(e.RowHandle), advChart.Buttons[0].Tag);
                }
            }
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            if (sender != null)
            {
                BandedGridView view = sender as BandedGridView;
                if (view.IsZoomedView)
                    view.NormalView();
                else
                    view.ZoomView();
                view.Focus();
                FocusGridRow(view);
            }
        }

        private void options_CustomizeCell(DevExpress.Export.CustomizeCellEventArgs e)
        {
            if (e.AreaType == DevExpress.Export.SheetAreaType.DataArea)
            {
                e.Formatting.Font.Name = "Tahoma";
                e.Formatting.Font.Size = 10F;
                e.Handled = true;
            }
            if (e.AreaType == DevExpress.Export.SheetAreaType.Header)
            {
                e.Formatting.BackColor = Color.GhostWhite;
                e.Formatting.Alignment = new DevExpress.Export.Xl.XlCellAlignment();
                e.Formatting.Alignment.HorizontalAlignment = DevExpress.Export.Xl.XlHorizontalAlignment.Center;
                e.Formatting.Alignment.VerticalAlignment = DevExpress.Export.Xl.XlVerticalAlignment.Center;
                e.Formatting.Font.Name = "Tahoma";
                e.Formatting.Font.Size = 10F;
                e.Formatting.Font.Bold = true;
                e.Handled = true;
            }
        }

        private void gridView_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            BandedGridView view = (sender as BandedGridView);
            view.BestFitColumns();
            for (int i = 0; i < view.RowCount; i++)
            {
                if (i != e.RowHandle)
                    view.CollapseMasterRow(i);
            }
        }

        private void tabReports_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            btnEditReport.Enabled = false;
            btnDeleteReport.Enabled = false;
            btnRestartView.Enabled = false;
            btnExportTables.Enabled = false;
            btnHelp.Enabled = false;

            if (e.Page != null & btnBranchInfo.Tag != null)
                ExpandGridView.Expand(e.Page, btnBranchInfo.Tag.ToString());

            if (e.Page != null && tabReports.SelectedTabPageIndex >= 0)
            {
                btnEditReport.Enabled = true;
                btnDeleteReport.Enabled = true;
                btnRestartView.Enabled = true;
                btnExportTables.Enabled = true;
                btnHelp.Enabled = true;
            }
        }

        private void pnlMain_SizeChanged(object sender, EventArgs e)
        {
            pnlGrid.SplitterPosition = 1000;
        }

        private void navBarControl_MouseDown(object sender, MouseEventArgs e)
        {
            var hitiInfo = navBarControl.CalcHitInfo(e.Location);
            if (hitiInfo.InLink && (hitiInfo.HitTest == NavBarHitTest.LinkImage & hitiInfo.Link.Group == mnuReports))
            {
                DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args.Icon = System.Drawing.SystemIcons.Warning;
                args.Text = "آیا از حذف این گزارش اطمینان کامل حاصل دارید؟";
                args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    tabReports.TabPages.Remove((XtraTabPage)hitiInfo.Link.Item.Tag);
                    navBarControl.Items.Remove(hitiInfo.Link.Item);
                }
                else
                {
                    return;
                }
            }
        }

        private void navBarControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var hitiInfo = navBarControl.CalcHitInfo(e.Location);
            if (hitiInfo.HitTest == NavBarHitTest.LinkCaption)
            {
                if (hitiInfo.InLink & hitiInfo.Link.Group == mnuReports)
                {
                    btnEditReport_ItemClick(null, null);
                }
            }
        }

        private void viewReports_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            DataRow row = viewReports.GetFocusedDataRow();
            if (row != null)
            {
                tabControl.SelectedTabPageIndex = 1;

                foreach (XtraTabPage xpage in tabReports.TabPages)
                {
                    if (xpage.Tag.ToString() == row["Guid"].ToString())
                    {
                        tabReports.SelectedTabPage = xpage;
                        return;
                    }
                }
            }
        }

        private void viewReports_DoubleClick(object sender, EventArgs e)
        {
            btnEditReport_ItemClick(null, EventArgs.Empty);
        }

        private void viewReports_RowCountChanged(object sender, EventArgs e)
        {
            if (viewReports.RowCount > 0)
            {
                btnExportReports.Enabled = true;
                btnSaveReports.Enabled = true;
                btnRemoveReports.Enabled = true;
                btnResume.Enabled = true;
            }
            else 
            {
                btnExportReports.Enabled = false;
                btnSaveReports.Enabled = false;
                btnRemoveReports.Enabled = false;
                btnResume.Enabled = false;
            }
            if (viewReports.RowCount > 1)
            {
                btnMultiSelect.Enabled = true;
                btnSortReports.Enabled = true;
            }
            else
            {
                btnMultiSelect.Enabled = false;
                btnSortReports.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) 
        {
            btnMultiSelect.Checked = false;
            tabControl.SelectedTabPageIndex = 1;
        }
        
        private void btnBranchInfo_Click(object sender, EventArgs e)
        {
            if (btnBranchInfo.Tag != null)
            {
                new dlgBranchInfo(btnBranchInfo.Tag.ToString()).Show();
            }
        }

        private void tabControl_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (tabControl.SelectedTabPageIndex == 0)
                btnNewReport.Enabled = false;
            else
                btnNewReport.Enabled = true;
        }

        #endregion

        #region Bar Views

        private void btnEditReport_ItemClick(object sender, EventArgs e)
        {
            DataRow row = viewReports.GetFocusedDataRow();
            if (row != null)
            {
                btnMultiSelect.Checked = false;
                this.frmNewReport.LoadParameters(row["DataSet"] as DataSet, row["Guid"].ToString());
                tabControl.SelectedTabPageIndex = 0;
                if (viewReports.RowCount > 0)
                    frmNewReport.btnCancel.Enabled = true;
                else
                    frmNewReport.btnCancel.Enabled = false;
            }
        }

        private void btnDeleteReport_ItemClick(object sender, EventArgs e)
        {
            if (tabReports.TabPages.Count > 0)
            {
                DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args.Icon = System.Drawing.SystemIcons.Warning;
                args.Caption = "هشدار";
                args.Text = "آیا از حذف گزارش جاری اطمینان کامل حاصل دارید؟";
                args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    viewReports.DeleteRow(viewReports.FocusedRowHandle);
                    RefreshTabPages(string.Empty);
                }
            }
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("نمایه ای برای حذف موجود نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnRestartView_ItemClick(object sender, EventArgs e)
        {
            DevExpress.XtraTab.XtraTabPage currentTab = tabReports.SelectedTabPage;
            if (currentTab == null)
                return;

            GridControl gridControl = currentTab.Controls["gridControl"] as GridControl;
            if (gridControl != null)
            {
                foreach (GridView gv in gridControl.ViewCollection)
                {
                    gv.ActiveFilter.Clear();
                    gv.SortInfo.ClearSorting();

                    if (gv is BandedGridView)
                    {
                        BandedGridView bgv = (BandedGridView)gv;
                        foreach (GridBand gb in bgv.Bands)
                        {
                            gb.Visible = true;
                        }
                    }
                }
            }
        }

        private void btnExportTables_Click(object sender, EventArgs e)
        {
            ShowBranchesId(true);
            ExportView();
            ShowBranchesId(false);
        }
       

        private void btnHelp_ItemClick(object sender, EventArgs e)
        {
            DataRow row = viewReports.GetFocusedDataRow();
            if (row != null)
            {
                DataSet ds = row["DataSet"] as DataSet;
                string text = ds.ExtendedProperties["Help"].ToString();
                if (text.Length > 0)
                    DevExpress.XtraEditors.XtraMessageBox.Show(text, "راهنما", MessageBoxButtons.OK, MessageBoxIcon.Question);
                else
                    DevExpress.XtraEditors.XtraMessageBox.Show("!متاسفانه راهنمایی برای این گزارش ثبت نشده است", "راهنما", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        #endregion

        #region Charts Modules

        private void Chart1()
        {
            DataRow row = viewReports.GetFocusedDataRow();
            if (row == null || btnBranchInfo.Tag == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعاتی موجود نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSet dataSet = row["DataSet"] as DataSet;

            if (this.SavedSeries1.ContainsKey(row["Guid"].ToString()))
            {
                IChart c = new IChart();
                c.Guid = row["Guid"].ToString();
                c.HeaderText = tabReports.SelectedTabPage.Text;
                c.UnitId = btnBranchInfo.Tag.ToString();
                c.ISeries1 = (IDictionary<int, ISeries.BranchSeries>)this.SavedSeries1[row["Guid"].ToString()];
                c.ShowChart();
                pnlCharts.Controls.Add(c);
                mnuCharts.Expanded = true;
                return;
            }

            if (dataSet.ExtendedProperties.ContainsKey("BranchesSeries"))
            {
                this.SavedSeries1.Add(row["Guid"].ToString(), dataSet.ExtendedProperties["BranchesSeries"]);
                IChart c = new IChart();
                c.Guid = row["Guid"].ToString();
                c.HeaderText = tabReports.SelectedTabPage.Text;
                c.UnitId = btnBranchInfo.Tag.ToString();
                c.ISeries1 = (IDictionary<int, ISeries.BranchSeries>)dataSet.ExtendedProperties["BranchesSeries"];
                c.ShowChart();
                pnlCharts.Controls.Add(c);
                mnuCharts.Expanded = true;
            }
        }

        private void Chart2()
        {
            DataRow row = viewReports.GetFocusedDataRow();

            if (row == null || btnBranchInfo.Tag == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعاتی موجود نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSet dataSet = row["DataSet"] as DataSet;

            if (this.SavedSeries2.ContainsKey(row["Guid"].ToString()))
            {
                IChart c = new IChart();
                c.Guid = row["Guid"].ToString();
                c.HeaderText = tabReports.SelectedTabPage.Text;
                c.UnitId = btnBranchInfo.Tag.ToString();
                c.ISeries1 = (IDictionary<int, ISeries.BranchSeries>)this.SavedSeries2[row["Guid"].ToString()];
                c.ShowChart();
                pnlCharts.Controls.Add(c);
                mnuCharts.Expanded = true;
                return;
            }

            #region افزودن تاریخ های مورد نیاز
            List<int> allDaysInYear = PersianDateTime.GetAllLastDayMonthInYearAsDateInt(PersianDateTime.Now.Year);
            List<int> dateList = new List<int>();//مقاطع مورد نیاز در این لیست ذخیره خواهند شد
            List<string> dateMatched = new List<string>();

            int firstDate = PersianDateTime.GetLastDayOfYear(PersianDateTime.Now.Year - 1).Value.ToShortDateInt();
            int now = PersianDateTime.Now.ToShortDateInt();

            dateList.Add(firstDate);
            foreach (int day in allDaysInYear)
            {
                if (day <= now)
                {
                    dateList.Add(day);
                }
            }
            #endregion

            #region استخراج تاریخ های موجود
            QueryProperties properties = new QueryProperties();
            if (dataSet.ExtendedProperties.ContainsKey("SourceID"))
            {
                string sourceId = dataSet.ExtendedProperties["SourceID"].ToString();
                string[] dates = QueryManager.GetAccessTables(string.Format("DB_{0}.mdb", sourceId));

                foreach (string date in dates)
                {
                    foreach (int d in dateList)
                    {
                        if (date.StartsWith(d.ToString()))
                        {
                            dateMatched.Add(date);
                        }
                    }
                }
            }
            #endregion

            foreach (System.Collections.DictionaryEntry item in dataSet.ExtendedProperties)
                properties.Add(item.Key.ToString(), item.Value);

            dateMatched.Sort();
            properties["FirstDate"] = firstDate;
            properties["CompareOrder"] = "همه مقاطع نسبت به مبدا";
            properties["SelectedDates"] = string.Join(",", dateMatched.ToArray());
            DataSet ds = dlgNewReport.SendQuery(properties);

            if (ds != null && ds.ExtendedProperties.ContainsKey("BranchesSeries"))
            {
                this.SavedSeries2.Add(row["Guid"].ToString(), ds.ExtendedProperties["BranchesSeries"]);
                IChart c = new IChart();
                c.Guid = row["Guid"].ToString();
                c.HeaderText = tabReports.SelectedTabPage.Text;
                c.UnitId = btnBranchInfo.Tag.ToString();
                c.ISeries1 = (IDictionary<int, ISeries.BranchSeries>)ds.ExtendedProperties["BranchesSeries"];
                c.ShowChart();
                pnlCharts.Controls.Add(c);
                mnuCharts.Expanded = true;
            }
        }

        private void Chart3()
        {
            DataRow row = viewReports.GetFocusedDataRow();

            if (row == null || btnBranchInfo.Tag == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعاتی موجود نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSet dataSet = row["DataSet"] as DataSet;

            if (this.SavedSeries3.ContainsKey(row["Guid"].ToString()))
            {
                IChart c = new IChart();
                c.Guid = row["Guid"].ToString();
                c.HeaderText = tabReports.SelectedTabPage.Text;
                c.UnitId = btnBranchInfo.Tag.ToString();
                c.ISeries1 = (IDictionary<int, ISeries.BranchSeries>)this.SavedSeries3[row["Guid"].ToString()];
                c.ShowChart();
                pnlCharts.Controls.Add(c);
                mnuCharts.Expanded = true;
                return;
            }

            #region افزودن تاریخ های مورد نیاز
            List<int> allDaysInYear = PersianDateTime.GetAllLastDayMonthInYearAsDateInt(PersianDateTime.Now.Year);
            List<int> dateList = new List<int>();//مقاطع مورد نیاز در این لیست ذخیره خواهند شد
            List<string> dateMatched = new List<string>();

            int firstDate = PersianDateTime.GetLastDayOfYear(PersianDateTime.Now.Year - 1).Value.ToShortDateInt();
            int now = PersianDateTime.Now.ToShortDateInt();

            dateList.Add(firstDate);
            foreach (int day in allDaysInYear)
            {
                if (day <= now)
                {
                    dateList.Add(day);
                }
            }
            #endregion

            #region استخراج تاریخ های موجود
            QueryProperties properties = new QueryProperties();
            if (dataSet.ExtendedProperties.ContainsKey("SourceID"))
            {
                string sourceId = dataSet.ExtendedProperties["SourceID"].ToString();
                string[] dates = QueryManager.GetAccessTables(string.Format("DB_{0}.mdb", sourceId));

                foreach (string date in dates)
                {
                    foreach (int d in dateList)
                    {
                        if (date.StartsWith(d.ToString()))
                        {
                            dateMatched.Add(date);
                        }
                    }
                }
                dateMatched.Add(dates.Last());
                dateMatched.Distinct();
            }
            #endregion

            foreach (System.Collections.DictionaryEntry item in dataSet.ExtendedProperties)
                properties.Add(item.Key.ToString(), item.Value);

            dateMatched.Sort();
            properties["FirstDate"] = firstDate;
            properties["CompareOrder"] = "همه مقاطع نسبت به مبدا";
            properties["SelectedDates"] = string.Join(",", dateMatched.ToArray());
            DataSet ds = dlgNewReport.SendQuery(properties);

            if (ds != null && ds.ExtendedProperties.ContainsKey("BranchesSeries"))
            {
                this.SavedSeries3.Add(row["Guid"].ToString(), ds.ExtendedProperties["BranchesSeries"]);
                IChart c = new IChart();
                c.Guid = row["Guid"].ToString();
                c.HeaderText = tabReports.SelectedTabPage.Text;
                c.UnitId = btnBranchInfo.Tag.ToString();
                c.ISeries1 = (IDictionary<int, ISeries.BranchSeries>)ds.ExtendedProperties["BranchesSeries"];
                c.ShowChart();
                pnlCharts.Controls.Add(c);
                mnuCharts.Expanded = true;
            }
        }

        private void Chart4()
        {
            DataRow row = viewReports.GetFocusedDataRow();

            if (row == null || btnBranchInfo.Tag == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعاتی موجود نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSet dataSet = row["DataSet"] as DataSet;

            if (this.SavedSeries4.ContainsKey(row["Guid"].ToString()))
            {
                IChart c = new IChart();
                c.Guid = row["Guid"].ToString();
                c.HeaderText = tabReports.SelectedTabPage.Text;
                c.UnitId = btnBranchInfo.Tag.ToString();
                c.ISeries1 = (IDictionary<int, ISeries.BranchSeries>)this.SavedSeries4[row["Guid"].ToString()];
                c.ShowChart();
                pnlCharts.Controls.Add(c);
                mnuCharts.Expanded = true;
                return;
            }

            #region افزودن تاریخ های مورد نیاز
            List<int> allDaysInYear = PersianDateTime.GetAllLastDayMonthInYearAsDateInt(PersianDateTime.Now.Year);
            List<int> allDaysInMonth = PersianDateTime.GetAllDaysInMonth(PersianDateTime.Now.Year, PersianDateTime.Now.Month);
            List<int> dateList = new List<int>();//مقاطع مورد نیاز در این لیست ذخیره خواهند شد
            List<string> dateMatched = new List<string>();

            int firstDate = PersianDateTime.GetLastDayOfYear(PersianDateTime.Now.Year - 1).Value.ToShortDateInt();
            int now = PersianDateTime.Now.ToShortDateInt();

            dateList.Add(firstDate);
            foreach (int day in allDaysInYear)
            {
                if (day <= now)
                {
                    dateList.Add(day);
                }
            }
            foreach (int day in allDaysInMonth)
            {
                if (day <= now & !dateList.Contains(day))
                {
                    dateList.Add(day);
                }
            }
            #endregion

            #region استخراج تاریخ های موجود
            QueryProperties properties = new QueryProperties();
            if (dataSet.ExtendedProperties.ContainsKey("SourceID"))
            {
                string sourceId = dataSet.ExtendedProperties["SourceID"].ToString();
                string[] dates = QueryManager.GetAccessTables(string.Format("DB_{0}.mdb", sourceId));

                foreach (string date in dates)
                {
                    foreach (int d in dateList)
                    {
                        if (date.StartsWith(d.ToString()))
                        {
                            dateMatched.Add(date);
                        }
                    }
                }
            }
            #endregion

            foreach (System.Collections.DictionaryEntry item in dataSet.ExtendedProperties)
                properties.Add(item.Key.ToString(), item.Value);

            dateMatched.Sort();
            properties["FirstDate"] = firstDate;
            properties["CompareOrder"] = "همه مقاطع نسبت به مبدا";
            properties["SelectedDates"] = string.Join(",", dateMatched.ToArray());
            DataSet ds = dlgNewReport.SendQuery(properties);

            if (ds != null && ds.ExtendedProperties.ContainsKey("BranchesSeries"))
            {
                this.SavedSeries4.Add(row["Guid"].ToString(), ds.ExtendedProperties["BranchesSeries"]);
                IChart c = new IChart();
                c.Guid = row["Guid"].ToString();
                c.HeaderText = tabReports.SelectedTabPage.Text;
                c.UnitId = btnBranchInfo.Tag.ToString();
                c.ISeries1 = (IDictionary<int, ISeries.BranchSeries>)ds.ExtendedProperties["BranchesSeries"];
                c.ShowChart();
                pnlCharts.Controls.Add(c);
                mnuCharts.Expanded = true;
            }
        }

        private void Chart5()
        {
            DataRow row = viewReports.GetFocusedDataRow();

            if (row == null || btnBranchInfo.Tag == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعاتی موجود نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSet dataSet = row["DataSet"] as DataSet;

            if (this.SavedSeries5.ContainsKey(row["Guid"].ToString()))
            {
                IChart c = new IChart();
                c.Guid = row["Guid"].ToString();
                c.HeaderText = tabReports.SelectedTabPage.Text;
                c.UnitId = btnBranchInfo.Tag.ToString();
                c.ShowProvince = true;
                c.ISeries1 = (IDictionary<int, ISeries.BranchSeries>)this.SavedSeries5[row["Guid"].ToString()];
                c.ShowChart();
                pnlCharts.Controls.Add(c);
                mnuCharts.Expanded = true;
                return;
            }

            #region افزودن تاریخ های مورد نیاز
            List<int> allDaysInYear = PersianDateTime.GetAllLastDayMonthInYearAsDateInt(PersianDateTime.Now.Year);
            List<int> allDaysInMonth = PersianDateTime.GetAllDaysInMonth(PersianDateTime.Now.Year, PersianDateTime.Now.Month);
            List<int> dateList = new List<int>();//مقاطع مورد نیاز در این لیست ذخیره خواهند شد
            List<string> dateMatched = new List<string>();

            int firstDate = PersianDateTime.GetLastDayOfYear(PersianDateTime.Now.Year - 1).Value.ToShortDateInt();
            int now = PersianDateTime.Now.ToShortDateInt();

            dateList.Add(firstDate);
            foreach (int day in allDaysInYear)
            {
                if (day <= now)
                {
                    dateList.Add(day);
                }
            }
            foreach (int day in allDaysInMonth)
            {
                if (day <= now & !dateList.Contains(day))
                {
                    dateList.Add(day);
                }
            }
            #endregion

            #region استخراج تاریخ های موجود
            QueryProperties properties = new QueryProperties();
            if (dataSet.ExtendedProperties.ContainsKey("SourceID"))
            {
                string sourceId = dataSet.ExtendedProperties["SourceID"].ToString();
                string[] dates = QueryManager.GetAccessTables(string.Format("DB_{0}.mdb", sourceId));

                foreach (string date in dates)
                {
                    foreach (int d in dateList)
                    {
                        if (date.StartsWith(d.ToString()))
                        {
                            dateMatched.Add(date);
                        }
                    }
                }
            }
            #endregion

            foreach (System.Collections.DictionaryEntry item in dataSet.ExtendedProperties)
                properties.Add(item.Key.ToString(), item.Value);

            dateMatched.Sort();
            properties["FirstDate"] = firstDate;
            properties["CompareOrder"] = "همه مقاطع نسبت به مبدا";
            properties["SelectedDates"] = string.Join(",", dateMatched.ToArray());
            DataSet ds = dlgNewReport.SendQuery(properties);

            if (ds != null && ds.ExtendedProperties.ContainsKey("BranchesSeries"))
            {
                this.SavedSeries5.Add(row["Guid"].ToString(), ds.ExtendedProperties["BranchesSeries"]);
                IChart c = new IChart();
                c.Guid = row["Guid"].ToString();
                c.HeaderText = tabReports.SelectedTabPage.Text;
                c.UnitId = btnBranchInfo.Tag.ToString();
                c.ShowProvince = true;
                c.ISeries1 = (IDictionary<int, ISeries.BranchSeries>)ds.ExtendedProperties["BranchesSeries"];
                c.ShowChart();
                pnlCharts.Controls.Add(c);
                mnuCharts.Expanded = true;
            }
        }

        private void Chart6()
        {
            DataRow row = viewReports.GetFocusedDataRow();

            if (row == null || btnBranchInfo.Tag == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعاتی موجود نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSet dataSet = row["DataSet"] as DataSet;

            if (this.SavedSeries6.ContainsKey(row["Guid"].ToString()))
            {
                IChart c = new IChart();
                c.Guid = row["Guid"].ToString();
                c.HeaderText = tabReports.SelectedTabPage.Text;
                c.UnitId = btnBranchInfo.Tag.ToString();
                c.ISeries1 = (IDictionary<int, ISeries.BranchSeries>)this.SavedSeries6[row["Guid"].ToString()][0];
                c.ISeries2 = (IDictionary<int, ISeries.BranchSeries>)this.SavedSeries6[row["Guid"].ToString()][1];
                c.ShowChart();
                pnlCharts.Controls.Add(c);
                mnuCharts.Expanded = true;
                return;
            }

            #region افزودن تاریخ های مورد نیاز
            List<int> allDaysInYear1 = PersianDateTime.GetAllLastDayMonthInYearAsDateInt(PersianDateTime.Now.Year);
            List<int> allDaysInYear2 = PersianDateTime.GetAllLastDayMonthInYearAsDateInt(PersianDateTime.Now.Year - 1);

            List<int> dateList1 = new List<int>();
            List<int> dateList2 = new List<int>();

            List<string> dateMatched1 = new List<string>();
            List<string> dateMatched2 = new List<string>();

            int firstDate1 = PersianDateTime.GetLastDayOfYear(PersianDateTime.Now.Year - 1).Value.ToShortDateInt();
            int firstDate2 = PersianDateTime.GetLastDayOfYear(PersianDateTime.Now.Year - 2).Value.ToShortDateInt();

            int now = PersianDateTime.Now.ToShortDateInt();

            dateList1.Add(firstDate1);
            foreach (int day in allDaysInYear1)
            {
                if (day <= now)
                {
                    dateList1.Add(day);
                }
            }

            dateList2.Add(firstDate2);
            foreach (int day in allDaysInYear2)
            {
                if (day <= now)
                {
                    dateList2.Add(day);
                }
            }
            #endregion

            #region استخراج تاریخ های موجود
            QueryProperties properties = new QueryProperties();
            if (dataSet.ExtendedProperties.ContainsKey("SourceID"))
            {
                string sourceId = dataSet.ExtendedProperties["SourceID"].ToString();
                string[] dates = QueryManager.GetAccessTables(string.Format("DB_{0}.mdb", sourceId));

                foreach (string date in dates)
                {
                    foreach (int d in dateList1)
                    {
                        if (date.StartsWith(d.ToString()))
                        {
                            dateMatched1.Add(date);
                        }
                    }
                }

                foreach (string date in dates)
                {
                    foreach (int d in dateList2)
                    {
                        if (date.StartsWith(d.ToString()))
                        {
                            dateMatched2.Add(date);
                        }
                    }
                }
            }
            #endregion

            foreach (System.Collections.DictionaryEntry item in dataSet.ExtendedProperties)
                properties.Add(item.Key.ToString(), item.Value);

            dateMatched1.Sort();
            dateMatched2.Sort();

            DataSet ds1 = new DataSet();

            properties["FirstDate"] = firstDate1;
            properties["CompareOrder"] = "همه مقاطع نسبت به مبدا";
            properties["SelectedDates"] = string.Join(",", dateMatched1.ToArray());
            ds1 = dlgNewReport.SendQuery(properties);
            if (ds1 != null && ds1.ExtendedProperties.ContainsKey("BranchesSeries"))
            {
                #region حذف روز از تاریخ ها و تبدیل تاریخ ها به ماه
                IDictionary<int, ISeries.BranchSeries> branchesSeries = (IDictionary<int, ISeries.BranchSeries>)ds1.ExtendedProperties["BranchesSeries"];
                foreach (var series in branchesSeries)
                {
                    series.Value.Year = PersianDateTime.Now.Year.ToString();

                    foreach (var cat in series.Value.Comparisons)
                    {
                        IDictionary<string, ISeries.DataPoint> items = new Dictionary<string, ISeries.DataPoint>();

                        foreach (var i in cat.Value.Points)
                        {
                            if (PersianDateTime.IsValidDate(i.Key))
                            {
                                if (!i.Value.ReportDate.ToString().StartsWith(firstDate1.ToString()))
                                {
                                    string monthName = PersianDateTime.Parse(i.Key).MonthName;
                                    items.Add(monthName, i.Value);
                                }
                            }
                        }
                        cat.Value.Points.Clear();
                        foreach (var item in items)
                        {
                            item.Value.Argument = item.Key;
                            cat.Value.Points.Add(item.Key, item.Value);
                        }
                    }
                }
                #endregion
            }

            DataSet ds2 = new DataSet();
            properties["FirstDate"] = firstDate2;
            properties["CompareOrder"] = "همه مقاطع نسبت به مبدا";
            properties["SelectedDates"] = string.Join(",", dateMatched2.ToArray());
            ds2 = dlgNewReport.SendQuery(properties);
            if (ds2 != null && ds2.ExtendedProperties.ContainsKey("BranchesSeries"))
            {
                #region حذف روز از تاریخ ها و تبدیل تاریخ ها به ماه
                IDictionary<int, ISeries.BranchSeries> branchesSeries = (IDictionary<int, ISeries.BranchSeries>)ds2.ExtendedProperties["BranchesSeries"];
                foreach (var series in branchesSeries)
                {
                    series.Value.Year = (PersianDateTime.Now.Year - 1).ToString();

                    foreach (var cat in series.Value.Comparisons)
                    {
                        IDictionary<string, ISeries.DataPoint> items = new Dictionary<string, ISeries.DataPoint>();

                        foreach (var i in cat.Value.Points)
                        {
                            if (PersianDateTime.IsValidDate(i.Key))
                            {
                                if (!i.Value.ReportDate.ToString().StartsWith(firstDate2.ToString()))
                                {
                                    string monthName = PersianDateTime.Parse(i.Key).MonthName;
                                    items.Add(monthName, i.Value);
                                }
                            }
                        }
                        cat.Value.Points.Clear();
                        foreach (var item in items)
                        {
                            item.Value.Argument = item.Key;
                            cat.Value.Points.Add(item.Key, item.Value);
                        }
                    }
                }
                #endregion
            }

            if (ds1.ExtendedProperties.ContainsKey("BranchesSeries") & ds2.ExtendedProperties.ContainsKey("BranchesSeries"))
            {
                this.SavedSeries6.Add(row["Guid"].ToString(), new object[] { ds1.ExtendedProperties["BranchesSeries"], ds2.ExtendedProperties["BranchesSeries"] });

                IChart c = new IChart();
                c.Guid = row["Guid"].ToString();
                c.HeaderText = tabReports.SelectedTabPage.Text;
                c.UnitId = btnBranchInfo.Tag.ToString();
                c.ISeries1 = (IDictionary<int, ISeries.BranchSeries>)ds1.ExtendedProperties["BranchesSeries"];
                c.ISeries2 = (IDictionary<int, ISeries.BranchSeries>)ds2.ExtendedProperties["BranchesSeries"];
                c.ShowChart();
                pnlCharts.Controls.Add(c);
                mnuCharts.Expanded = true;
            }
        }

        private void Chart7()
        {

        }

        #endregion

        #region Bar Exports

        private void Export1(DataSet[] dataSets, int saveformat)
        {
            if (dataSets.Length > 0)
            {
                progressBar.Show();
                progressBar.EditValue = 0;
                this.Enabled = false;

                #region New excel and add worksheet
                Microsoft.Office.Interop.Excel.Application AppXL = new Microsoft.Office.Interop.Excel.Application();
                AppXL.Visible = false;
                AppXL.DisplayAlerts = false;
                Microsoft.Office.Interop.Excel.Workbook WbXl = null;
                Microsoft.Office.Interop.Excel.Worksheet ShXL = null;
                WbXl = AppXL.Workbooks.Add();
                if (WbXl.Sheets.Count > 1)
                {
                    for (int i = 1; i < WbXl.Sheets.Count + 1; i++)
                        WbXl.Sheets[i].Delete();
                }

                ShXL = WbXl.Sheets[1];
                ShXL.Name = "GAM.REPORT";
                ShXL.DisplayRightToLeft = true;
                #endregion

                Point startCell = new Point(1, 1);
                Point endCell = new Point(1, 1);
                int firstDataRowNo = 1;
                int maxBandlevel = 1;
                List<int> levels = new List<int>();
                List<string> hiddenColumns = new List<string>();

                try
                {
                    foreach (var item in dataSets)
                    {
                        BandedGridView bgv = (item.ExtendedProperties["BandedGridViewList"] as Dictionary<string, BandedGridView>)["Branches"];
                        var map = new GridBandExcelMap();
                        map.Fill(bgv, null, 0);
                        levels.Add(map.LastBandLevelNo);
                    }
                    maxBandlevel = levels.Max();

                    for (int i = 0; i < dataSets.Length; i++)
                    {
                        #region Save Format

                        if (saveformat == 2)
                        {
                            if (i > 0)
                            {
                                ShXL = WbXl.Sheets.Add(Type.Missing , ShXL);
                                ShXL.DisplayRightToLeft = true;
                            }
                            startCell = new Point(1, 1);
                            endCell = new Point(1, 1);
                            ShXL.Name = UDF.SetSheetName(dataSets[i].ExtendedProperties["ReportName"].ToString());
                        } 
                        #endregion

                        #region Initialize

                        DataTable tableProvince = dataSets[i].Tables["Province"];
                        DataTable tableBranches = dataSets[i].Tables["BranchesList"];
                        DataTable tableMaster = tableBranches.Clone();
                        BandedGridView bgv = (dataSets[i].ExtendedProperties["BandedGridViewList"] as Dictionary<string, BandedGridView>)["BranchesList"];

                        var dataMap = new GridBandExcelMap();
                        dataMap.Fill(bgv, tableMaster, maxBandlevel);

                        foreach (DataRow row in tableBranches.Rows)
                        {
                            string type = Branches.GetBranchById(row["Branches.BranchId"].ToString(), false).BranchType;
                            if (type == "شعبه" | type == "شعبه مستقل")
                            {
                                DataRow newRow = tableMaster.NewRow();
                                tableMaster.Rows.Add(row.ItemArray);
                            }
                        }

                        foreach (DataRow row in tableProvince.Rows)
                        {
                            DataRow newRow = tableMaster.NewRow();
                            newRow["Branches.BranchId"] = row["Province.ProvinceId"];
                            newRow["Branches.BranchName"] = row["Province.ProvinceName"];
                            foreach (DataColumn col in dataMap.BandColumns)
                            {
                                if (row.Table.Columns.Contains(col.ColumnName))
                                    newRow[col.ColumnName] = row[col.ColumnName];
                            }

                            tableMaster.Rows.Add(newRow);
                        }
                        #endregion
                       
                        ProgressBar(i, dataSets.Length, 10);

                        #region Ranges & Locations
                        firstDataRowNo = startCell.Y + dataMap.LastBandLevelNo + 1;
                        endCell.X = (startCell.X + dataMap.BandColumns.Count) - 1;
                        endCell.Y = firstDataRowNo + tableMaster.Rows.Count - 1;

                        dynamic rngReportName = ShXL.Range[ShXL.Cells[startCell.Y, startCell.X], ShXL.Cells[startCell.Y, startCell.X]];
                        dynamic rngBands = ShXL.Range[ShXL.Cells[startCell.Y, startCell.X], ShXL.Cells[firstDataRowNo - 1, endCell.X]];
                        dynamic rngHeader = ShXL.Range[ShXL.Cells[firstDataRowNo - 1, startCell.X], ShXL.Cells[firstDataRowNo - 1, endCell.X]];
                        dynamic rngRows = ShXL.Range[ShXL.Cells[firstDataRowNo, startCell.X], ShXL.Cells[endCell.Y, endCell.X]];
                        dynamic rngLastRow = ShXL.Range[ShXL.Cells[endCell.Y, startCell.X], ShXL.Cells[endCell.Y, endCell.X]];
                        #endregion
                     
                        ProgressBar(i, dataSets.Length, 30);

                        #region Set Range Formats

                        long colorIndex = GetRandomColor();

                        rngReportName.Font.Bold = true;

                        SetXBandedRowsFormat(ShXL, rngBands, colorIndex);

                        SetXRangeRowsFormat(ShXL, rngRows, -1);

                        SetXLastRowFormat(ShXL, rngLastRow, colorIndex);

                        #endregion
                        
                        ProgressBar(i, dataSets.Length, 50);

                        #region Add Bands
                        foreach (var item in dataMap.BandCells)
                        {
                            var cell1 = ShXL.Cells[startCell.Y + item.Row - 1, startCell.X + item.Column - 1];
                            cell1.Value = item.Text;

                            if (item.Length > 0 | item.Height > 0)
                            {
                                var cell2 = ShXL.Cells[startCell.Y + item.Row - 1 + item.Height, startCell.X + item.Column - 1 + item.Length];
                                ShXL.Range[cell1, cell2].Merge();
                            }
                        }

                        #endregion
                      
                        ProgressBar(i, dataSets.Length, 70);

                        #region Add Columns
                        int counter = 0;
                        foreach (DataColumn col in dataMap.BandColumns)
                        {
                            ++counter;
                            var cell = ShXL.Cells[firstDataRowNo - 1, startCell.X - 1 + counter];
                            cell.Value = col.Caption;

                            FormattingRules.SetRangeFormat(ShXL, col, ShXL.Range[ShXL.Cells[firstDataRowNo, startCell.X - 1 + counter], ShXL.Cells[endCell.Y, startCell.X - 1 + counter]]);

                            if (i > 0 & (col.ColumnName == "Domains.DomainName" | col.ColumnName == "Branches.BranchId" | col.ColumnName == "Branches.BranchName" | col.ColumnName == "Branches.BranchDegree"))
                                hiddenColumns.Add(string.Format("{0}:{0}", GridBandExcelMap.GetXlsColNameByNo(startCell.X - 1 + counter)));
                        }
                        #endregion
                        
                        ProgressBar(i, dataSets.Length, 80);

                        #region Add Rows

                        WriteTableToRange(firstDataRowNo, startCell, endCell, dataMap.BandColumns, tableMaster, ShXL);

                        #endregion

                        ProgressBar(i, dataSets.Length, 100);

                        rngHeader.EntireColumn.AutoFit();
                        startCell.X = endCell.X + 1;
                    }

                    #region Page Setup
                   
                    if (saveformat == 1)
                    {
                        foreach (string name in hiddenColumns)
                            ShXL.Range[name].EntireColumn.Hidden = true;
                    }

                    ShXL.PageSetup.FooterMargin = 0;
                    ShXL.PageSetup.HeaderMargin = 0;
                    ShXL.PageSetup.LeftMargin = 0;
                    ShXL.PageSetup.RightMargin = 0;
                    ShXL.PageSetup.TopMargin = 0;
                    ShXL.PageSetup.BottomMargin = 0;
                    ShXL.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
                    ShXL.PageSetup.CenterHorizontally = true;
                    ShXL.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                    ShXL.PageSetup.FitToPagesWide = 1;
                    ShXL.PageSetup.FitToPagesTall = false;
                    ShXL.PageSetup.PrintTitleRows = string.Format("${0}:${1}", 1, firstDataRowNo - 1);
                    WbXl.Sheets[1].Activate();
                    AppXL.Visible = true;
                    #endregion
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    progressBar.Hide();
                    this.Enabled = true;
                }

                progressBar.Hide();
                this.Enabled = true;
            }
        }

        private void Export2(DataSet[] dataSets, int saveformat)
        {
            if (dataSets.Length > 0)
            {
                progressBar.Show();
                progressBar.EditValue = 0;
                this.Enabled = false;

                #region New excel and add worksheet
                Microsoft.Office.Interop.Excel.Application AppXL = new Microsoft.Office.Interop.Excel.Application();
                AppXL.Visible = false;
                AppXL.DisplayAlerts = false;
                Microsoft.Office.Interop.Excel.Workbook WbXl = null;
                Microsoft.Office.Interop.Excel.Worksheet ShXL = null;
                WbXl = AppXL.Workbooks.Add();
                if (WbXl.Sheets.Count > 1)
                {
                    for (int i = 1; i < WbXl.Sheets.Count + 1; i++)
                        WbXl.Sheets[i].Delete();
                }

                ShXL = WbXl.Sheets[1];
                ShXL.Name = "GAM.REPORT";
                ShXL.DisplayRightToLeft = true;
                #endregion

                Point startCell = new Point(1, 1);
                Point endCell = new Point(1, 1);
                int firstDataRowNo = 1;
                int maxBandlevel = 1;
                List<int> levels = new List<int>();
                List<string> hiddenColumns = new List<string>();

                try
                {
                    foreach (var item in dataSets)
                    {
                        BandedGridView bgv = (item.ExtendedProperties["BandedGridViewList"] as Dictionary<string, BandedGridView>)["Domains"];
                        var map = new GridBandExcelMap();
                        map.Fill(bgv, null, 0);
                        levels.Add(map.LastBandLevelNo);
                    }
                    maxBandlevel = levels.Max();

                    for (int i = 0; i < dataSets.Length; i++)
                    {
                        #region Save Format

                        if (saveformat == 2)
                        {
                            if (i > 0)
                            {
                                ShXL = WbXl.Sheets.Add(Type.Missing, ShXL);
                                ShXL.DisplayRightToLeft = true;
                            }
                            startCell = new Point(1, 1);
                            endCell = new Point(1, 1);
                            ShXL.Name = UDF.SetSheetName(dataSets[i].ExtendedProperties["ReportName"].ToString());
                        }
                        #endregion

                        #region Initialize
                        DataTable tableProvince = dataSets[i].Tables["Province"];
                        DataTable tableDomains = dataSets[i].Tables["Domains"];
                        DataTable tableMaster = tableDomains.Clone();
                    
                        BandedGridView bgv = (dataSets[i].ExtendedProperties["BandedGridViewList"] as Dictionary<string, BandedGridView>)["Domains"];

                        var dataMap = new GridBandExcelMap();
                        dataMap.Fill(bgv, tableMaster, maxBandlevel);

                        foreach (DataRow row in tableDomains.Rows)
                        {
                            DataRow newRow = tableMaster.NewRow();
                            tableMaster.Rows.Add(row.ItemArray);
                        }

                        foreach (DataRow row in tableProvince.Rows)
                        {
                            DataRow newRow = tableMaster.NewRow();
                            newRow["Domains.DomainId"] = row["Province.ProvinceId"];
                            newRow["Domains.DomainName"] = row["Province.ProvinceName"];
                            foreach (DataColumn col in dataMap.BandColumns)
                            {
                                if (row.Table.Columns.Contains(col.ColumnName))
                                    newRow[col.ColumnName] = row[col.ColumnName];
                            }

                            tableMaster.Rows.Add(newRow);
                        }

                        #endregion
                       
                        ProgressBar(i, dataSets.Length, 10);

                        #region Ranges & Locations
                        firstDataRowNo = startCell.Y + dataMap.LastBandLevelNo + 1;
                        endCell.X = (startCell.X + dataMap.BandColumns.Count) - 1;
                        endCell.Y = firstDataRowNo + tableMaster.Rows.Count - 1;

                        dynamic rngReportName = ShXL.Range[ShXL.Cells[startCell.Y, startCell.X], ShXL.Cells[startCell.Y, startCell.X]];
                        dynamic rngBands = ShXL.Range[ShXL.Cells[startCell.Y, startCell.X], ShXL.Cells[firstDataRowNo - 1, endCell.X]];
                        dynamic rngHeader = ShXL.Range[ShXL.Cells[firstDataRowNo - 1, startCell.X], ShXL.Cells[firstDataRowNo - 1, endCell.X]];
                        dynamic rngRows = ShXL.Range[ShXL.Cells[firstDataRowNo, startCell.X], ShXL.Cells[endCell.Y, endCell.X]];
                        dynamic rngLastRow = ShXL.Range[ShXL.Cells[endCell.Y, startCell.X], ShXL.Cells[endCell.Y, endCell.X]];
                        #endregion
                       
                        ProgressBar(i, dataSets.Length, 30);

                        #region Set Range Formats

                        long colorIndex = GetRandomColor();

                        rngReportName.Font.Bold = true;

                        SetXBandedRowsFormat(ShXL, rngBands, colorIndex);

                        SetXRangeRowsFormat(ShXL, rngRows, 13882323);

                        SetXLastRowFormat(ShXL, rngLastRow, colorIndex);

                        #endregion
                       
                        ProgressBar(i, dataSets.Length, 50);

                        #region Add Bands
                        foreach (var item in dataMap.BandCells)
                        {
                            var cell1 = ShXL.Cells[startCell.Y + item.Row - 1, startCell.X + item.Column - 1];
                            cell1.Value = item.Text;

                            if (item.Length > 0 | item.Height > 0)
                            {
                                var cell2 = ShXL.Cells[startCell.Y + item.Row - 1 + item.Height, startCell.X + item.Column - 1 + item.Length];
                                ShXL.Range[cell1, cell2].Merge();
                            }
                        }

                        #endregion
                    
                        ProgressBar(i, dataSets.Length, 70);

                        #region Add Columns
                        int counter = 0;
                        foreach (DataColumn col in dataMap.BandColumns)
                        {
                            ++counter;
                            var cell = ShXL.Cells[firstDataRowNo - 1, startCell.X - 1 + counter];
                            cell.Value = col.Caption;

                            FormattingRules.SetRangeFormat(ShXL, col, ShXL.Range[ShXL.Cells[firstDataRowNo, startCell.X - 1 + counter], ShXL.Cells[endCell.Y, startCell.X - 1 + counter]]);

                            if (i > 0 & (col.ColumnName == "Domains.DomainId" | col.ColumnName == "Domains.DomainName"))
                                hiddenColumns.Add(string.Format("{0}:{0}", GridBandExcelMap.GetXlsColNameByNo(startCell.X - 1 + counter)));
                        }
                        #endregion
                      
                        ProgressBar(i, dataSets.Length, 80);

                        #region Add Rows

                        WriteTableToRange(firstDataRowNo, startCell, endCell, dataMap.BandColumns, tableMaster, ShXL);

                        #endregion

                        ProgressBar(i, dataSets.Length, 100);

                        rngHeader.EntireColumn.AutoFit();
                        startCell.X = endCell.X + 1;
                    }

                    #region Page Setup
                   
                    if (saveformat == 1)
                    {
                        foreach (string name in hiddenColumns)
                            ShXL.Range[name].EntireColumn.Hidden = true;
                    }
                    ShXL.PageSetup.FooterMargin = 0;
                    ShXL.PageSetup.HeaderMargin = 0;
                    ShXL.PageSetup.LeftMargin = 0;
                    ShXL.PageSetup.RightMargin = 0;
                    ShXL.PageSetup.TopMargin = 0;
                    ShXL.PageSetup.BottomMargin = 0;
                    ShXL.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
                    ShXL.PageSetup.CenterHorizontally = true;
                    ShXL.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                    ShXL.PageSetup.FitToPagesWide = 1;
                    ShXL.PageSetup.FitToPagesTall = false;
                    ShXL.PageSetup.PrintTitleRows = string.Format("${0}:${1}", 1, firstDataRowNo - 1);
                    WbXl.Sheets[1].Activate();
                    AppXL.Visible = true;
                    #endregion
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    progressBar.Hide();
                    this.Enabled = true;
                }

                progressBar.Hide();
                this.Enabled = true;
            }
        }

        private void Export3(DataSet[] dataSets, int saveformat)
        {
            if (dataSets.Length > 0)
            {
                progressBar.Show();
                progressBar.EditValue = 0;
                this.Enabled = false;

                #region New excel and add worksheet
                Microsoft.Office.Interop.Excel.Application AppXL = new Microsoft.Office.Interop.Excel.Application();
                AppXL.Visible = false;
                AppXL.DisplayAlerts = false;
                Microsoft.Office.Interop.Excel.Workbook WbXl = null;
                Microsoft.Office.Interop.Excel.Worksheet ShXL = null;
                WbXl = AppXL.Workbooks.Add();
                if (WbXl.Sheets.Count > 1)
                {
                    for (int i = 1; i < WbXl.Sheets.Count + 1; i++)
                        WbXl.Sheets[i].Delete();
                }

                ShXL = WbXl.Sheets[1];
                ShXL.Name = "GAM.REPORT";
                ShXL.DisplayRightToLeft = true;
                #endregion

                Point startCell = new Point(1, 1);
                Point endCell = new Point(1, 1);
                int firstDataRowNo = 1;
                int maxBandlevel = 1;
                List<int> levels = new List<int>();
                List<string> hiddenColumns = new List<string>();

                try
                {
                    foreach (var item in dataSets)
                    {
                        BandedGridView bgv = (item.ExtendedProperties["BandedGridViewList"] as Dictionary<string, BandedGridView>)["Branches"];
                        var map = new GridBandExcelMap();
                        map.Fill(bgv, null, 0);
                        levels.Add(map.LastBandLevelNo);
                    }
                    maxBandlevel = levels.Max();

                    for (int i = 0; i < dataSets.Length; i++)
                    {
                        #region Save Format

                        if (saveformat == 2)
                        {
                            if (i > 0)
                            {
                                ShXL = WbXl.Sheets.Add(Type.Missing, ShXL);
                                ShXL.DisplayRightToLeft = true;
                            }
                            startCell = new Point(1, 1);
                            endCell = new Point(1, 1);
                            ShXL.Name = UDF.SetSheetName(dataSets[i].ExtendedProperties["ReportName"].ToString());
                        }
                        #endregion

                        #region Initialize
                        DataTable tableProvince = dataSets[i].Tables["Province"];
                        DataTable tableDomains = dataSets[i].Tables["Domains"];
                        DataTable tableBranches = dataSets[i].Tables["Branches"];
                        DataTable tableMaster = tableBranches.Clone();
                        List<Tuple<int, int>> groupRows = new List<Tuple<int, int>>();
                        BandedGridView bgv = (dataSets[i].ExtendedProperties["BandedGridViewList"] as Dictionary<string, BandedGridView>)["Branches"];

                        var dataMap = new GridBandExcelMap();
                        dataMap.Fill(bgv, tableMaster, maxBandlevel);

                        foreach (DataRow row in tableDomains.Rows)
                        {
                            int Y1 = tableMaster.Rows.Count;
                            foreach (DataRow r in tableBranches.Rows)
                            {
                                string type = Branches.GetBranchById(r["Branches.BranchId"].ToString(), false).BranchType;
                                if (type == "شعبه" | type == "شعبه مستقل")
                                {
                                    if (r["Domains.DomainId"].ToString() == row["Domains.DomainId"].ToString())
                                    {
                                        tableMaster.Rows.Add(r.ItemArray);
                                    }
                                }
                            }

                            DataRow newRow = tableMaster.NewRow();
                            foreach (DataColumn col in dataMap.BandColumns)
                            {
                                if (row.Table.Columns.Contains(col.ColumnName))
                                    newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            newRow["Branches.BranchId"] = row["Domains.DomainId"].ToString();
                            newRow["Branches.BranchName"] = row["Domains.DomainName"].ToString();
                            tableMaster.Rows.Add(newRow);
                            int Y2 = tableMaster.Rows.Count - 1;
                            groupRows.Add(Tuple.Create(Y1, Y2));
                        }

                        foreach (DataRow row in tableProvince.Rows)
                        {
                            DataRow newRow = tableMaster.NewRow();
                            newRow["Branches.BranchId"] = row["Province.ProvinceId"];
                            newRow["Branches.BranchName"] = row["Province.ProvinceName"];
                            foreach (DataColumn col in dataMap.BandColumns)
                            {
                                if (row.Table.Columns.Contains(col.ColumnName))
                                    newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            tableMaster.Rows.Add(newRow);
                        }
                        #endregion
                      
                        ProgressBar(i, dataSets.Length, 10);

                        #region Ranges & Locations
                        firstDataRowNo = startCell.Y + dataMap.LastBandLevelNo + 1;
                        endCell.X = (startCell.X + dataMap.BandColumns.Count) - 1;
                        endCell.Y = firstDataRowNo + tableMaster.Rows.Count - 1;

                        dynamic rngReportName = ShXL.Range[ShXL.Cells[startCell.Y, startCell.X], ShXL.Cells[startCell.Y, startCell.X]];
                        dynamic rngBands = ShXL.Range[ShXL.Cells[startCell.Y, startCell.X], ShXL.Cells[firstDataRowNo - 1, endCell.X]];
                        dynamic rngHeader = ShXL.Range[ShXL.Cells[firstDataRowNo - 1, startCell.X], ShXL.Cells[firstDataRowNo - 1, endCell.X]];
                        dynamic rngRows = ShXL.Range[ShXL.Cells[firstDataRowNo, startCell.X], ShXL.Cells[endCell.Y, endCell.X]];
                        dynamic rngLastRow = ShXL.Range[ShXL.Cells[endCell.Y, startCell.X], ShXL.Cells[endCell.Y, endCell.X]];
                        #endregion
                   
                        ProgressBar(i, dataSets.Length, 20);

                        #region Set Formats

                        long colorIndex = GetRandomColor();
                        rngReportName.Font.Bold = true;

                        SetXBandedRowsFormat(ShXL, rngBands, colorIndex);

                        SetXRangeRowsFormat(ShXL, rngRows, 13882323);

                        SetXLastRowFormat(ShXL, rngLastRow, colorIndex);

                        #endregion

                        ProgressBar(i, dataSets.Length, 40);

                        #region Group Rows

                        foreach (var grp in groupRows)
                        {
                            int y1 = startCell.Y + dataMap.LastBandLevelNo + 1 + grp.Item1;
                            int y2 = startCell.Y + dataMap.LastBandLevelNo + 1 + grp.Item2 - 1;
                            if (y2 > y1)
                            {
                                dynamic rngBrRows = ShXL.Range[ShXL.Cells[y1, startCell.X], ShXL.Cells[y2, endCell.X]];
                                if (i == 0)
                                    rngBrRows.Rows.Group();
                                rngBrRows.Interior.Color = -1;
                            }
                        }

                        #endregion

                        ProgressBar(i, dataSets.Length, 50);

                        #region Add Bands
                        foreach (var item in dataMap.BandCells)
                        {
                            var cell1 = ShXL.Cells[startCell.Y + item.Row - 1, startCell.X + item.Column - 1];
                            cell1.Value = item.Text;

                            if (item.Length > 0 | item.Height > 0)
                            {
                                var cell2 = ShXL.Cells[startCell.Y + item.Row - 1 + item.Height, startCell.X + item.Column - 1 + item.Length];
                                ShXL.Range[cell1, cell2].Merge();
                            }
                        }

                        #endregion

                        ProgressBar(i, dataSets.Length, 70);

                        #region Add Columns
                        int counter = 0;
                        foreach (DataColumn col in dataMap.BandColumns)
                        {
                            ++counter;
                            var cell = ShXL.Cells[firstDataRowNo - 1, startCell.X - 1 + counter];
                            cell.Value = col.Caption;

                            FormattingRules.SetRangeFormat(ShXL, col, ShXL.Range[ShXL.Cells[firstDataRowNo, startCell.X - 1 + counter], ShXL.Cells[endCell.Y, startCell.X - 1 + counter]]);

                            if (i > 0 & (col.ColumnName == "Branches.BranchId" | col.ColumnName == "Branches.BranchName" | col.ColumnName == "Branches.BranchDegree"))
                                hiddenColumns.Add(string.Format("{0}:{0}", GridBandExcelMap.GetXlsColNameByNo(startCell.X - 1 + counter)));
                        }
                        #endregion
                    
                        ProgressBar(i, dataSets.Length, 80);

                        #region Add Rows

                        WriteTableToRange(firstDataRowNo, startCell, endCell, dataMap.BandColumns, tableMaster, ShXL);

                        #endregion

                        ProgressBar(i, dataSets.Length, 100);

                        rngHeader.EntireColumn.AutoFit();
                        startCell.X = endCell.X + 1;
                    }

                    #region Page Setup

                    if (saveformat == 1)
                    {
                        foreach (string name in hiddenColumns)
                            ShXL.Range[name].EntireColumn.Hidden = true;
                    }
                    ShXL.PageSetup.FooterMargin = 0;
                    ShXL.PageSetup.HeaderMargin = 0;
                    ShXL.PageSetup.LeftMargin = 0;
                    ShXL.PageSetup.RightMargin = 0;
                    ShXL.PageSetup.TopMargin = 0;
                    ShXL.PageSetup.BottomMargin = 0;
                    ShXL.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
                    ShXL.PageSetup.CenterHorizontally = true;
                    ShXL.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                    ShXL.PageSetup.FitToPagesWide = 1;
                    ShXL.PageSetup.FitToPagesTall = false;
                    ShXL.PageSetup.PrintTitleRows = string.Format("${0}:${1}", 1, firstDataRowNo - 1);
                    WbXl.Sheets[1].Activate();
                    AppXL.Visible = true;
                    #endregion
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    progressBar.Hide();
                    this.Enabled = true;
                }

                progressBar.Hide();
                this.Enabled = true;
            }
        }

        private void Export4(DataSet[] dataSets, int saveformat)
        {
            if (dataSets.Length > 0)
            {
                progressBar.Show();
                progressBar.EditValue = 0;
                this.Enabled = false;

                #region New excel and add worksheet
                Microsoft.Office.Interop.Excel.Application AppXL = new Microsoft.Office.Interop.Excel.Application();
                AppXL.Visible = false;
                AppXL.DisplayAlerts = false;
                Microsoft.Office.Interop.Excel.Workbook WbXl = null;
                Microsoft.Office.Interop.Excel.Worksheet ShXL = null;
                WbXl = AppXL.Workbooks.Add();
                if (WbXl.Sheets.Count > 1)
                {
                    for (int i = 1; i < WbXl.Sheets.Count + 1; i++)
                        WbXl.Sheets[i].Delete();
                }

                ShXL = WbXl.Sheets[1];
                ShXL.Name = "GAM.REPORT";
                ShXL.DisplayRightToLeft = true;
                #endregion

                Point startCell = new Point(1, 1);
                Point endCell = new Point(1, 1);
                int firstDataRowNo = 1;
                int maxBandlevel = 1;
                List<int> levels = new List<int>();
                List<string> hiddenColumns = new List<string>();

                try
                {
                    foreach (var item in dataSets)
                    {
                        BandedGridView bgv = (item.ExtendedProperties["BandedGridViewList"] as Dictionary<string, BandedGridView>)["Domains"];
                        var map = new GridBandExcelMap();
                        map.Fill(bgv, null, 0);
                        levels.Add(map.LastBandLevelNo);
                    }
                    maxBandlevel = levels.Max();

                    for (int i = 0; i < dataSets.Length; i++)
                    {
                        #region Save Format

                        if (saveformat == 2)
                        {
                            if (i > 0)
                            {
                                ShXL = WbXl.Sheets.Add(Type.Missing, ShXL);
                                ShXL.DisplayRightToLeft = true;
                            }
                            startCell = new Point(1, 1);
                            endCell = new Point(1, 1);
                            ShXL.Name = UDF.SetSheetName(dataSets[i].ExtendedProperties["ReportName"].ToString());
                        }
                        #endregion

                        #region Initialize
                        DataTable tableProvince = dataSets[i].Tables["Province"];
                        DataTable tableDomains = dataSets[i].Tables["Domains"];
                        DataTable tableBranches = dataSets[i].Tables["Branches"];
                        DataTable tableMaster = tableDomains.Clone();
                        List<Tuple<int, int>> groupRows = new List<Tuple<int, int>>();
                        BandedGridView bgv = (dataSets[i].ExtendedProperties["BandedGridViewList"] as Dictionary<string, BandedGridView>)["Domains"];

                        var dataMap = new GridBandExcelMap();
                        dataMap.Fill(bgv, tableMaster, maxBandlevel);

                        foreach (DataRow row in tableDomains.Rows)
                        {
                            int Y1 = tableMaster.Rows.Count;

                            if (row["Domains.DomainId"].ToString() == "16")
                            {
                                foreach (DataRow r in tableBranches.Rows)
                                {
                                    if (r["Domains.DomainId"].ToString() == "16" & Branches.GetBranchById(r["Branches.BranchId"].ToString(), false).BranchType == "شعبه مستقل")
                                    {
                                        DataRow newRow = tableMaster.NewRow();
                                        foreach (DataColumn col in dataMap.BandColumns)
                                        {
                                            if (r.Table.Columns.Contains(col.ColumnName))
                                                newRow[col.ColumnName] = r[col.ColumnName];
                                        }
                                        newRow["Domains.DomainId"] = r["Branches.BranchId"].ToString();
                                        newRow["Domains.DomainName"] = r["Branches.BranchName"].ToString();
                                        tableMaster.Rows.Add(newRow);
                                    }
                                }
                            }
                            tableMaster.Rows.Add(row.ItemArray);

                            int Y2 = tableMaster.Rows.Count - 1;
                            groupRows.Add(Tuple.Create(Y1, Y2));
                        }

                        foreach (DataRow row in tableProvince.Rows)
                        {
                            DataRow newRow = tableMaster.NewRow();
                            newRow["Domains.DomainId"] = row["Province.ProvinceId"];
                            newRow["Domains.DomainName"] = row["Province.ProvinceName"];
                            foreach (DataColumn col in dataMap.BandColumns)
                            {
                                if (row.Table.Columns.Contains(col.ColumnName))
                                    newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            tableMaster.Rows.Add(newRow);
                        }
                        #endregion
                     
                        ProgressBar(i, dataSets.Length, 10);

                        #region Ranges & Locations
                        firstDataRowNo = startCell.Y + dataMap.LastBandLevelNo + 1;
                        endCell.X = (startCell.X + dataMap.BandColumns.Count) - 1;
                        endCell.Y = firstDataRowNo + tableMaster.Rows.Count - 1;

                        dynamic rngReportName = ShXL.Range[ShXL.Cells[startCell.Y, startCell.X], ShXL.Cells[startCell.Y, startCell.X]];
                        dynamic rngBands = ShXL.Range[ShXL.Cells[startCell.Y, startCell.X], ShXL.Cells[firstDataRowNo - 1, endCell.X]];
                        dynamic rngHeader = ShXL.Range[ShXL.Cells[firstDataRowNo - 1, startCell.X], ShXL.Cells[firstDataRowNo - 1, endCell.X]];
                        dynamic rngRows = ShXL.Range[ShXL.Cells[firstDataRowNo, startCell.X], ShXL.Cells[endCell.Y, endCell.X]];
                        dynamic rngLastRow = ShXL.Range[ShXL.Cells[endCell.Y, startCell.X], ShXL.Cells[endCell.Y, endCell.X]];
                        #endregion
                      
                        ProgressBar(i, dataSets.Length, 20);

                        #region Set Formats

                        long colorIndex = GetRandomColor();
                        rngReportName.Font.Bold = true;

                        SetXBandedRowsFormat(ShXL, rngBands, colorIndex);

                        SetXRangeRowsFormat(ShXL, rngRows, 13882323);

                        SetXLastRowFormat(ShXL, rngLastRow, colorIndex);

                        #endregion
                  
                        ProgressBar(i, dataSets.Length, 40);

                        #region Group Rows

                        foreach (var grp in groupRows)
                        {
                            int y1 = startCell.Y + dataMap.LastBandLevelNo + 1 + grp.Item1;
                            int y2 = startCell.Y + dataMap.LastBandLevelNo + 1 + grp.Item2 - 1;
                            if (y2 > y1)
                            {
                                dynamic rngBrRows = ShXL.Range[ShXL.Cells[y1, startCell.X], ShXL.Cells[y2, endCell.X]];
                                if (i == 0)
                                    rngBrRows.Rows.Group();
                                rngBrRows.Interior.Color = -1;
                            }
                        }

                        #endregion
                      
                        ProgressBar(i, dataSets.Length, 50);

                        #region Add Bands
                        foreach (var item in dataMap.BandCells)
                        {
                            var cell1 = ShXL.Cells[startCell.Y + item.Row - 1, startCell.X + item.Column - 1];
                            cell1.Value = item.Text;

                            if (item.Length > 0 | item.Height > 0)
                            {
                                var cell2 = ShXL.Cells[startCell.Y + item.Row - 1 + item.Height, startCell.X + item.Column - 1 + item.Length];
                                ShXL.Range[cell1, cell2].Merge();
                            }
                        }

                        #endregion
                  
                        ProgressBar(i, dataSets.Length, 70);

                        #region Add Columns
                        int counter = 0;
                        foreach (DataColumn col in dataMap.BandColumns)
                        {
                            ++counter;
                            var cell = ShXL.Cells[firstDataRowNo - 1, startCell.X - 1 + counter];
                            cell.Value = col.Caption;

                            FormattingRules.SetRangeFormat(ShXL, col, ShXL.Range[ShXL.Cells[firstDataRowNo, startCell.X - 1 + counter], ShXL.Cells[endCell.Y, startCell.X - 1 + counter]]);

                            if (i > 0 & (col.ColumnName == "Domains.DomainId" | col.ColumnName == "Domains.DomainName"))
                                hiddenColumns.Add(string.Format("{0}:{0}", GridBandExcelMap.GetXlsColNameByNo(startCell.X - 1 + counter)));
                        }
                        #endregion
                       
                        ProgressBar(i, dataSets.Length, 80);

                        #region Add Rows

                        WriteTableToRange(firstDataRowNo, startCell, endCell, dataMap.BandColumns, tableMaster, ShXL);

                        #endregion

                        ProgressBar(i, dataSets.Length, 100);

                        rngHeader.EntireColumn.AutoFit();
                        startCell.X = endCell.X + 1;
                    }

                    #region Page Setup

                    if (saveformat == 1)
                    {
                        foreach (string name in hiddenColumns)
                            ShXL.Range[name].EntireColumn.Hidden = true;
                    }
                    ShXL.PageSetup.FooterMargin = 0;
                    ShXL.PageSetup.HeaderMargin = 0;
                    ShXL.PageSetup.LeftMargin = 0;
                    ShXL.PageSetup.RightMargin = 0;
                    ShXL.PageSetup.TopMargin = 0;
                    ShXL.PageSetup.BottomMargin = 0;
                    ShXL.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
                    ShXL.PageSetup.CenterHorizontally = true;
                    ShXL.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                    ShXL.PageSetup.FitToPagesWide = 1;
                    ShXL.PageSetup.FitToPagesTall = false;
                    ShXL.PageSetup.PrintTitleRows = string.Format("${0}:${1}", 1, firstDataRowNo - 1);
                    WbXl.Sheets[1].Activate();
                    AppXL.Visible = true;
                    #endregion
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    progressBar.Hide();
                    this.Enabled = true;
                }

                progressBar.Hide();
                this.Enabled = true;
            }
        }

        private void ExportView() 
        {
            DevExpress.XtraTab.XtraTabPage currentTab = tabReports.SelectedTabPage;
            if (currentTab == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("نمایه ای برای ذخیره فایل اکسل موجود نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GridControl gc = currentTab.Controls["gridControl"] as GridControl;
            if (gc != null)
            {
                DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.DataAware;

                XlsxExportOptionsEx options = new XlsxExportOptionsEx();//Dev Express Migration issue fix  
                options.CustomizeCell += options_CustomizeCell;

                options.ShowGridLines = false;
                options.RightToLeftDocument = DevExpress.Utils.DefaultBoolean.True;
                options.ExportMode = XlsxExportMode.SingleFile;
                options.AllowFixedColumns = DevExpress.Utils.DefaultBoolean.True;
                options.AllowFixedColumnHeaderPanel = DevExpress.Utils.DefaultBoolean.True;
                options.AllowSortingAndFiltering = DevExpress.Utils.DefaultBoolean.True;

                GridView view = gc.FocusedView as GridView;
                view.ZoomView();
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Title = "Save File";
                saveDlg.Filter = "Excel File|*.xlsx";
                saveDlg.ShowDialog();
                if (saveDlg.FileName != "")
                {
                    foreach (GridFormatRule rule in view.FormatRules)
                    {
                        if (rule.Tag.ToString() == "R2")
                            rule.Enabled = false;
                    }
                    view.ExportToXlsx(saveDlg.FileName, options);
                    foreach (GridFormatRule rule in view.FormatRules)
                    {
                        if (rule.Tag.ToString() == "R2")
                            rule.Enabled = true;
                    }
                    view.NormalView();
                    System.Diagnostics.Process.Start(saveDlg.FileName);
                }
            }
        }

        #endregion

        #region Reports Buttons
       
        private void btnNewReport_Click(object sender, EventArgs e)
        {
            btnMultiSelect.Checked = false;
            frmNewReport.NewReport();
            tabControl.SelectedTabPageIndex = 0;
            if (viewReports.RowCount > 0)
                frmNewReport.btnCancel.Enabled = true;
            else
                frmNewReport.btnCancel.Enabled = false;
        }

        private void btnRemoveReport_Click(object sender, EventArgs e)
        {
            DataRow row = viewReports.GetFocusedDataRow();
            if (row != null)
            {
                DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args.Icon = System.Drawing.SystemIcons.Warning;
                args.Caption = "هشدار";
                args.Text = "آیا از حذف گزارش/گزارشات انتخاب شده اطمینان کامل حاصل دارید؟";
                args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    List<XtraTabPage> deletedPages = new List<XtraTabPage>();
                    List<DataRow> deletedRows = new List<DataRow>();

                    foreach (int id in viewReports.GetSelectedRows())
                        deletedRows.Add(viewReports.GetDataRow(id));

                    foreach (DataRow drow in deletedRows)
                    {
                        for (int i = 0; i < viewReports.RowCount; i++)
                        {
                            DataRow r = viewReports.GetDataRow(i);
                            if (r != null && deletedRows.Contains(r))
                            {
                                foreach (XtraTabPage xpage in tabReports.TabPages)
                                {
                                    if (xpage.Tag.ToString() == r["Guid"].ToString())
                                    {
                                        deletedPages.Add(xpage);
                                        viewReports.DeleteRow(i);
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    foreach (XtraTabPage xpage in deletedPages)
                    {
                        tabReports.TabPages.Remove(xpage);
                    }

                    btnMultiSelect.Checked = false;
                }
            }

            RefreshTabPages(string.Empty);
        }

        private void btnExportReports_Click(object sender, EventArgs e)
        {
            List<DataSet> list = new List<DataSet>();
            foreach (int index in viewReports.GetSelectedRows())
            {
                DataRow row = viewReports.GetDataRow(index);
                if (row["DataSet"] != null)
                    list.Add((DataSet)row["DataSet"]);
            }
            if (list.Count > 0)
                ExportTables(list.ToArray());

            btnMultiSelect.Checked = false;
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("BranchId");
            table.Columns.Add("BranchName");
            table.Columns.Add("ReportName");
            table.Columns.Add("Red", typeof(int));
            table.Columns.Add("Orange", typeof(int));
            table.Columns.Add("Green", typeof(int));
            table.Columns.Add("Rank", typeof(double));

            for (int i = 0; i < viewReports.RowCount; i++)
            {
                DataRow row = viewReports.GetDataRow(i);

                if (row != null && row["DataSet"] != null)
                {
                    DataSet ds = row["DataSet"] as DataSet;

                    //if (Branches.IsBranch(branchId))
                    //    unitId = ds.Tables["Branches"].Rows.Cast<DataRow>().Where(x => x["Branches.BranchId"].ToString() == branchId).FirstOrDefault();
                    //if (Branches.IsDomain(branchId))
                    //    unitId = ds.Tables["Domains"].Rows.Cast<DataRow>().Where(x => x["Domains.DomainId"].ToString() == branchId).FirstOrDefault();
                    //if (Branches.IsProvince(branchId))
                    //    unitId = ds.Tables["Province"].Rows.Cast<DataRow>().Where(x => x["Province.ProvinceId"].ToString() == branchId).FirstOrDefault();

                    foreach (Branches.BranchInfo bi in Branches.GetAllBranchs("شعبه"))
                    {
                        DataRow id = ds.Tables["Branches"].Rows.Cast<DataRow>().Where(x => x["Branches.BranchId"].ToString() == bi.BranchId).FirstOrDefault();

                        if (id != null)
                        {
                            int red = 0;
                            int orange = 0;
                            int green = 0;

                            DataRow r = table.NewRow();
                            r["BranchId"] = bi.BranchId;
                            r["BranchName"] = bi.BranchName;
                            r["ReportName"] = row["ReportName"].ToString();

                            foreach (DataColumn col in id.Table.Columns)
                            {
                                if (col.ExtendedProperties.ContainsKey("FormatRule"))
                                {
                                    DictionaryEntry de = (DictionaryEntry)col.ExtendedProperties["FormatRule"];

                                    string colorName = FormattingRules.GetColorName(de, Numeral.AnyToDouble(id[col]));

                                    double vRank = Math.Abs(Numeral.AnyToDouble(id[col]));
                                    if (colorName == "Red")
                                        red += 1;
                                    if (colorName == "Orange")
                                        orange += 1;
                                    if (colorName == "Green")
                                        green += 1;
                                }
                            }

                            r["Red"] = red;
                            r["Orange"] = orange;
                            r["Green"] = green;
                            r["Rank"] = (green + (orange / 2)) - red;
                            table.Rows.Add(r);
                        }
                    }
                }
            }

            new dlgResume(table).ShowDialog();
        }

        private void btnSaveReports_Click(object sender, EventArgs e)
        {
            SaveReports();
        }

        private void btnLoadReports_Click(object sender, EventArgs e)
        {
            btnMultiSelect.Checked = false;
            LoadReports();
        }

        private void btnSortReports_Click(object sender, EventArgs e)
        {
            btnMultiSelect.Checked = false;
            dlgSortList dlg = new dlgSortList(this.TableReports);
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.TableReports = dlg.OutTable;
                RefreshTabPages(string.Empty);
            }
        }

        private void btnMultiSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (btnMultiSelect.Checked)
            {
                viewReports.OptionsSelection.MultiSelect = true;
                for (int i = 0; i < viewReports.RowCount; i++)
                {
                    viewReports.SelectRow(i);
                }
            }
            else
                viewReports.OptionsSelection.MultiSelect = false;
        }
       
        private void checkButton_CheckedChanged(object sender, EventArgs e)
        {
            if (checkButton.Checked)
            {
                checkButton.Text = "";
                pnlReports.Height = 70;
            }
            else 
            {
                checkButton.Text = "";
                pnlReports.Height = 25;
            }
        }

        #endregion
    }
}
