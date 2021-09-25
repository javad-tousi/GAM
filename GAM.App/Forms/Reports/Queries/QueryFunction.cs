using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using GAM.Helpers;
using GAM.Interfaces.Information.Library;
using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Interfaces.Reports.Querys
{
    class ExecuteQuery
    {
        public List<Indicator> Indicators = new List<Indicator>();

        public enum ModifyType { None, AllWithFirstDate, WithBackAndFirstDate, JustLastAndFirstDate };

        public GridControl MyGridControl { get; set; }

        public class Column
        {
            public Column()
            {
                this.Guid = UDF.GetRndStr(4);
            }
            public Column(string fieldName, string fieldCaption)
            {
                this.Guid = UDF.GetRndStr(4);
                this.FieldName = fieldName;
                this.FieldCaption = fieldCaption;
                this.ShowVolModify = true;
                this.ShowPerModify = true;
                this.Visible = true;
                this.RoundDigits = 0;
            }

            public string Guid { get; private set; }
          
            public string FieldCaption { get; set; }

            public string FieldName { get; set; }

            public bool Visible { get; set; }

            public int RoundDigits { get; set; }

            public bool ShowPerModify { get; set; }

            public bool ShowVolModify { get; set; }

            public string Expression { get; set; }


        }

        public class Indicator
        {
            public List<Column> BaseColumns = new List<Column>();

            public List<Column> ModifyColumns = new List<Column>();

            public Indicator()
            {
            }
            public Indicator(List<Column> columns, string[] dates, bool addtotalRow, bool replaceNewBranchesID, DataTable dataTable)
            {
                this.BaseColumns = columns;
                this.Dates = dates;
                this.AddTotalRow = addtotalRow;
                this.ReplaceNewBranchesID = replaceNewBranchesID;
                this.DataTable = dataTable;
            }
            public bool AddTotalRow { get; set; }

            public DataTable DataTable { get; set; }

            public string[] Dates { get; set; }

            public ModifyType ModifyType { get; set; }

            public bool ReplaceNewBranchesID { get; set; }

            public string ReportName { get; set; }

            public int GetVisibleBaseColumnsCount()
            {
                return BaseColumns.Count(x => x.Visible == true);
            }
        }

        GridView ProvinceGridView;
        GridView DomainsGridView;
        GridView BranchesGridView;

        public void Run()
        {
            #region Create Grid Control

            GridControl gridControl = new GridControl();
            gridControl.Name = "gridControl";
            gridControl.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            //gridControl.LookAndFeel.SkinName = "Office 2007 Silver";
            //gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            BandedGridView gridView1 = new BandedGridView();
            gridView1.GridControl = gridControl;
            gridControl.MainView = gridView1;
            gridControl.ViewCollection.Add(gridView1);
            gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            gridControl.DoubleClick += gridControl_DoubleClick;
            gridControl.DataSourceChanged += gridControl_DataSourceChanged;
            #endregion

            #region Create Banded Grid Views

            BandedGridView viewProvince = CreateBandView();
            BandedGridView viewDomains = CreateBandView();
            BandedGridView viewBranches = CreateBandView();
            #endregion

            #region Create Data Tables

            DataSet dataSet = new DataSet();

            DataTable provinceTable = new DataTable();
            {
                DataColumn colProvinceID = new DataColumn { ColumnName = "ProvinceID", Caption = "کد", DataType = Type.GetType("System.Int32") };
                DataColumn colProvinceName = new DataColumn { ColumnName = "ProvinceName", Caption = "نام استان", DataType = Type.GetType("System.String") };
                provinceTable.Columns.Add(colProvinceID);
                provinceTable.Columns.Add(colProvinceName);
                GridBand band = CreateBand(viewProvince, "مشخصات استان");
                colProvinceID.ExtendedProperties.Add("ColumnWidth", 70);
                colProvinceName.ExtendedProperties.Add("ColumnWidth", 209);
                AddColumnToBand(viewProvince, band, colProvinceID);
                AddColumnToBand(viewProvince, band, colProvinceName);
            }

            DataTable domainsTable = new DataTable();
            {
                DataColumn colProvinceID = new DataColumn { ColumnName = "ProvinceID", Caption = "کد", DataType = Type.GetType("System.Int32") };
                DataColumn colProvinceName = new DataColumn { ColumnName = "ProvinceName", Caption = "نام استان", DataType = Type.GetType("System.String") };
                DataColumn colDomainID = new DataColumn { ColumnName = "DomainID", Caption = "کد", DataType = Type.GetType("System.Int32") };
                DataColumn colDomainName = new DataColumn { ColumnName = "DomainName", Caption = "نام حوزه", DataType = Type.GetType("System.String") };
                domainsTable.Columns.Add(colProvinceID);
                domainsTable.Columns.Add(colProvinceName);
                domainsTable.Columns.Add(colDomainID);
                domainsTable.Columns.Add(colDomainName);
                GridBand band = CreateBand(viewDomains, "مشخصات حوزه");
                colDomainID.ExtendedProperties.Add("ColumnWidth", 70);
                colDomainName.ExtendedProperties.Add("ColumnWidth", 173);
                AddColumnToBand(viewDomains, band, colDomainID);
                AddColumnToBand(viewDomains, band, colDomainName);
            }

            DataTable branchesTable = new DataTable();
            {
                DataColumn colProvinceID = new DataColumn { ColumnName = "ProvinceID", Caption = "کد", DataType = Type.GetType("System.Int32") };
                DataColumn colProvinceName = new DataColumn { ColumnName = "ProvinceName", Caption = "نام استان", DataType = Type.GetType("System.String") };
                DataColumn colDomainID = new DataColumn { ColumnName = "DomainID", Caption = "کد", DataType = Type.GetType("System.Int32") };
                DataColumn colDomainName = new DataColumn { ColumnName = "DomainName", Caption = "نام حوزه", DataType = Type.GetType("System.String") };
                DataColumn colBranchID = new DataColumn { ColumnName = "BranchID", Caption = "کد", DataType = Type.GetType("System.Int32") };
                DataColumn colBranchName = new DataColumn { ColumnName = "BranchName", Caption = "نام شعبه" };
                DataColumn colBranchDegree = new DataColumn { ColumnName = "BranchDegree", Caption = "درجه" };
                branchesTable.Columns.Add(colProvinceID);
                branchesTable.Columns.Add(colProvinceName);
                branchesTable.Columns.Add(colDomainID);
                branchesTable.Columns.Add(colDomainName);
                branchesTable.Columns.Add(colBranchID);
                branchesTable.Columns.Add(colBranchName);
                branchesTable.Columns.Add(colBranchDegree);
                GridBand band = CreateBand(viewBranches, "مشخصات شعبه");
                colBranchID.ExtendedProperties.Add("ColumnWidth", 52);
                colBranchName.ExtendedProperties.Add("ColumnWidth", 155);
                colBranchDegree.ExtendedProperties.Add("ColumnWidth", 50);
                AddColumnToBand(viewBranches, band, colBranchID);
                AddColumnToBand(viewBranches, band, colBranchName);
                AddColumnToBand(viewBranches, band, colBranchDegree, false);
            }
            #endregion

            foreach (Indicator indc in this.Indicators)
            {
                GridBand bandProvince = CreateBand(viewProvince, indc.ReportName);
                GridBand bandDomains = CreateBand(viewDomains, indc.ReportName);
                GridBand bandBranches = CreateBand(viewBranches, indc.ReportName);

                DataTable dt = indc.DataTable.AsEnumerable().CopyToDataTable();

                #region Create Base Columns

                GridBand bandBase1 = CreateBand(viewProvince, "عملکرد");
                GridBand bandBase2 = CreateBand(viewDomains, "عملکرد");
                GridBand bandBase3 = CreateBand(viewBranches, "عملکرد");

                foreach (string date in indc.Dates)
                {
                    foreach (Column col in indc.BaseColumns)
                    {
                        string colName = col.Guid + date;
                        DataColumn colBase1 = new DataColumn { ColumnName = colName, Caption = DateFormat(date), DataType = typeof(double) };
                        DataColumn colBase2 = new DataColumn { ColumnName = colName, Caption = DateFormat(date), DataType = typeof(double) };
                        DataColumn colBase3 = new DataColumn { ColumnName = colName, Caption = DateFormat(date), DataType = typeof(double) };

                        provinceTable.Columns.Add(colBase1);
                        domainsTable.Columns.Add(colBase2);
                        branchesTable.Columns.Add(colBase3);

                        if (col.Visible)
                        {
                            if (indc.GetVisibleBaseColumnsCount() > 1)
                            {
                                GridBand band1 = CreateBand(viewProvince, col.FieldCaption);
                                GridBand band2 = CreateBand(viewDomains, col.FieldCaption);
                                GridBand band3 = CreateBand(viewBranches, col.FieldCaption);

                                AddColumnToBand(viewProvince, band1, colBase1);
                                AddColumnToBand(viewDomains, band2, colBase2);
                                AddColumnToBand(viewBranches, band3, colBase3);

                                bandBase1.Children.Add(band1);
                                bandBase2.Children.Add(band2);
                                bandBase3.Children.Add(band3);
                            }
                            else
                            {
                                AddColumnToBand(viewProvince, bandBase1, colBase1);
                                AddColumnToBand(viewDomains, bandBase2, colBase2);
                                AddColumnToBand(viewBranches, bandBase3, colBase3);
                            }
                        }
                    }
                }


                bandProvince.Children.Add(bandBase1);
                bandDomains.Children.Add(bandBase2);
                bandBranches.Children.Add(bandBase3);

                #endregion

                #region Replace New Branches ID

                if (indc.ReplaceNewBranchesID)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string id = row["BranchID"].ToString();
                        if (Branches.IsBranch(id))
                        {
                            row["BranchID"] = Branches.GetBranchByID(row["BranchID"].ToString()).BranchID;
                        }
                    }
                }
                #endregion

                #region Fill Data Branchs

                foreach (Branches.BranchInfo br in Branches.GetAllBranchs())
                {
                    var dataQuery = dt.AsEnumerable();

                    DataRow newRow = branchesTable.NewRow();
                    newRow["ProvinceID"] = br.Province.ProvinceID;
                    newRow["ProvinceName"] = br.Province.ProvinceName;
                    newRow["DomainID"] = br.Domain.DomainID;
                    newRow["DomainName"] = br.Domain.DomainName;
                    newRow["BranchID"] = br.BranchID;
                    newRow["BranchName"] = br.BranchName;
                    newRow["BranchDegree"] = br.BranchDegree;

                    foreach (string date in indc.Dates)
                    {
                        #region Base Columns

                        foreach (Column col in indc.BaseColumns)
                        {
                            newRow[col.Guid + date] = dataQuery.Where(x => x["BranchID"].ToString() == br.BranchID & x["ReportDate"].ToString() == date).Sum(x => Math.Round(double.Parse(x[col.FieldName].ToString()), col.RoundDigits));
                        }
                        #endregion
                    }

                    branchesTable.Rows.Add(newRow);
                }
                #endregion

                #region Fill Data Domains

                foreach (Branches.DomainInfo dm in Branches.GetDomains())
                {

                    var dataQuery = branchesTable.AsEnumerable();

                    DataRow newRow = domainsTable.NewRow();
                    newRow["ProvinceID"] = dm.Province.ProvinceID;
                    newRow["ProvinceName"] = dm.Province.ProvinceName;
                    newRow["DomainID"] = dm.DomainID;
                    newRow["DomainName"] = dm.DomainName;

                    foreach (string date in indc.Dates)
                    {
                        #region Base Columns

                        foreach (Column col in indc.BaseColumns)
                        {
                            if (indc.AddTotalRow)
                                newRow[col.Guid + date] = dataQuery.Where(x => x["DomainID"].ToString() == dm.DomainID).Sum(x => double.Parse(x[col.Guid + date].ToString()));
                            else
                                newRow[col.Guid + date] = dataQuery.Where(x => x["BranchID"].ToString() == dm.DomainID).Sum(x => double.Parse(x[col.Guid + date].ToString()));
                        }
                        #endregion
                    }

                    domainsTable.Rows.Add(newRow);
                }
                #endregion

                #region Fill Data Provinces
                {
                    var dataQuery = dt.AsEnumerable();

                    DataRow newRow = provinceTable.NewRow();
                    newRow["ProvinceID"] = int.Parse(Branches.GetMyProvince().ProvinceID);
                    newRow["ProvinceName"] = Branches.GetMyProvince().ProvinceName;
                    foreach (string date in indc.Dates)
                    {
                        #region Base Columns

                        foreach (Column col in indc.BaseColumns)
                        {
                            if (indc.AddTotalRow)
                                newRow[col.Guid + date] = dataQuery.Where(x => x["ReportDate"].ToString() == date).Sum(x => Math.Round(double.Parse(x[col.FieldName].ToString()), col.RoundDigits));
                            else
                                newRow[col.Guid + date] = dataQuery.Where(x => x["BranchID"].ToString() == Branches.GetMyProvince().ProvinceID & x["ReportDate"].ToString() == date).Sum(x => Math.Round(double.Parse(x[col.FieldName].ToString()), col.RoundDigits));
                        }
                        #endregion
                    }

                    provinceTable.Rows.Add(newRow);
                }
                #endregion

                #region Modify Columns

                if (indc.ModifyColumns.Count > 0)
                {
                    List<string> list = GetModifyList(indc.Dates, indc.ModifyType);

                    foreach (Column col in indc.ModifyColumns)
                    {
                        #region Create Modify Columns

                        foreach (string item in list)
                        {
                            GridBand bandModify1 = CreateBand(viewProvince, DateFormat(item), 2);
                            GridBand bandModify2 = CreateBand(viewDomains, DateFormat(item), 2);
                            GridBand bandModify3 = CreateBand(viewBranches, DateFormat(item), 2);

                            if (col.ShowVolModify)
                            {
                                string name = "Vol" + col.Guid + item;
                                DataColumn colVol1 = new DataColumn { ColumnName = name, Caption = "میزان", DataType = typeof(double) };
                                DataColumn colVol2 = new DataColumn { ColumnName = name, Caption = "میزان", DataType = typeof(double) };
                                DataColumn colVol3 = new DataColumn { ColumnName = name, Caption = "میزان", DataType = typeof(double) };


                                provinceTable.Columns.Add(colVol1);
                                domainsTable.Columns.Add(colVol2);
                                branchesTable.Columns.Add(colVol3);

                                if (!(col.ShowVolModify & col.ShowPerModify))
                                {
                                    colVol1.ExtendedProperties.Add("ColumnWidth", 120);
                                    colVol2.ExtendedProperties.Add("ColumnWidth", 120);
                                    colVol3.ExtendedProperties.Add("ColumnWidth", 120);
                                }

                                if (indc.GetVisibleBaseColumnsCount() > 1)
                                {
                                    colVol1.Caption = col.FieldCaption;
                                    colVol2.Caption = col.FieldCaption;
                                    colVol3.Caption = col.FieldCaption;
                                }
                            }
                            if (col.ShowPerModify)
                            {
                                string name = "Per" + col.Guid + item;
                                DataColumn colPer1 = new DataColumn { ColumnName = name, Caption = "درصد", DataType = typeof(double) };
                                DataColumn colPer2 = new DataColumn { ColumnName = name, Caption = "درصد", DataType = typeof(double) };
                                DataColumn colPer3 = new DataColumn { ColumnName = name, Caption = "درصد", DataType = typeof(double) };

                                provinceTable.Columns.Add(colPer1);
                                domainsTable.Columns.Add(colPer2);
                                branchesTable.Columns.Add(colPer3);

                                if (!(col.ShowVolModify & col.ShowPerModify))
                                {
                                    colPer1.ExtendedProperties.Add("ColumnWidth", 120);
                                    colPer2.ExtendedProperties.Add("ColumnWidth", 120);
                                    colPer3.ExtendedProperties.Add("ColumnWidth", 120);
                                }

                                if (indc.GetVisibleBaseColumnsCount() > 1)
                                {
                                    colPer1.Caption = col.FieldCaption;
                                    colPer2.Caption = col.FieldCaption;
                                    colPer3.Caption = col.FieldCaption;
                                }

                                AddColumnToBand(viewProvince, bandModify1, colPer1);
                                AddColumnToBand(viewDomains, bandModify2, colPer2);
                                AddColumnToBand(viewBranches, bandModify3, colPer3);
                            }

                            if (col.ShowVolModify | col.ShowPerModify)
                            {
                                bandProvince.Children.Add(bandModify1);
                                bandDomains.Children.Add(bandModify2);
                                bandBranches.Children.Add(bandModify3);
                            }
                        }
                        #endregion

                        #region Modify Branches Table

                        foreach (DataRow row in branchesTable.Rows)
                        {
                            foreach (string item in list)
                            {
                                string[] dates = item.Split('~');
                                if (col.ShowVolModify)
                                {
                                    string name = "Vol" + col.Guid + item;
                                    double vol = IsNumeric.AnyToDouble(row[col.Guid + dates[1]]) - IsNumeric.AnyToDouble(row[col.Guid + dates[0]]);
                                    row[name] = Math.Round(vol, 0);
                                }
                                if (col.ShowPerModify)
                                {
                                    string name = "Per" + col.Guid + item;
                                    double per = IsNumeric.InfinityOrNaN_GetZero(((IsNumeric.AnyToDouble(row[col.Guid + dates[1]]) - IsNumeric.AnyToDouble(row[col.Guid + dates[0]])) / IsNumeric.AnyToDouble(row[col.Guid + dates[0]])) * 100);
                                    row[name] = Math.Round(per, 1);
                                }
                            }
                        }
                        #endregion

                        #region Modify Domains Table

                        foreach (DataRow row in domainsTable.Rows)
                        {
                            foreach (string item in list)
                            {
                                string[] dates = item.Split('~');
                                if (col.ShowVolModify)
                                {
                                    string name = "Vol" + col.Guid + item;
                                    double vol = IsNumeric.AnyToDouble(row[col.Guid + dates[1]]) - IsNumeric.AnyToDouble(row[col.Guid + dates[0]]);
                                    row[name] = Math.Round(vol, 0);
                                }
                                if (col.ShowPerModify)
                                {
                                    string name = "Per" + col.Guid + item;
                                    double per = IsNumeric.InfinityOrNaN_GetZero(((IsNumeric.AnyToDouble(row[col.Guid + dates[1]]) - IsNumeric.AnyToDouble(row[col.Guid + dates[0]])) / IsNumeric.AnyToDouble(row[col.Guid + dates[0]])) * 100);
                                    row[name] = Math.Round(per, 1);
                                }
                            }
                        }
                        #endregion

                        #region Modify Province Table

                        foreach (DataRow row in provinceTable.Rows)
                        {
                            foreach (string item in list)
                            {
                                string[] dates = item.Split('~');
                                if (col.ShowVolModify)
                                {
                                    string name = "Vol" + col.Guid + item;
                                    double vol = IsNumeric.AnyToDouble(row[col.Guid + dates[1]]) - IsNumeric.AnyToDouble(row[col.Guid + dates[0]]);
                                    row[name] = Math.Round(vol, 0);
                                }
                                if (col.ShowPerModify)
                                {
                                    string name = "Per" + col.Guid + item;
                                    double per = IsNumeric.InfinityOrNaN_GetZero(((IsNumeric.AnyToDouble(row[col.Guid + dates[1]]) - IsNumeric.AnyToDouble(row[col.Guid + dates[0]])) / IsNumeric.AnyToDouble(row[col.Guid + dates[0]])) * 100);
                                    row[name] = Math.Round(per, 1);
                                }
                            }
                        }
                        #endregion
                    }
                }
                #endregion

            }

            #region Add Relations

            dataSet.Tables.Add(provinceTable);
            dataSet.Tables.Add(domainsTable);
            dataSet.Tables.Add(branchesTable);
            dataSet.Relations.Add("حوزه ها", provinceTable.Columns["ProvinceID"], domainsTable.Columns["ProvinceID"]);
            dataSet.Relations.Add("شعب", domainsTable.Columns["DomainID"], branchesTable.Columns["DomainID"]);
            #endregion

            gridControl.ViewCollection.Add(viewProvince);
            gridControl.ViewCollection.Add(viewDomains);
            gridControl.ViewCollection.Add(viewBranches);

            DevExpress.XtraGrid.GridLevelNode level1 = new DevExpress.XtraGrid.GridLevelNode();
            level1.LevelTemplate = viewDomains;
            level1.RelationName = "حوزه ها";
            DevExpress.XtraGrid.GridLevelNode level2 = new DevExpress.XtraGrid.GridLevelNode();
            level2.LevelTemplate = viewBranches;
            level2.RelationName = "شعب";
            level1.Nodes.Add(level2);
            gridControl.LevelTree.Nodes.Add(level1);
            gridControl.MainView = viewProvince;
            gridControl.DataSource = dataSet.Tables[0];
            viewProvince.BestFitColumns();

            foreach (BandedGridColumn col in viewProvince.Columns)
            {
                if (viewDomains.Columns.ColumnByFieldName(col.FieldName) != null)
                    viewDomains.Columns[col.FieldName].Width = col.Width;

                if (viewBranches.Columns.ColumnByFieldName(col.FieldName) != null)
                    viewBranches.Columns[col.FieldName].Width = col.Width;
            }

            viewProvince.LeftCoordChanged += viewProvince_LeftCoordChanged;
            viewProvince.MasterRowExpanded += viewProvince_MasterRowExpanded;
            viewDomains.LeftCoordChanged += viewDomains_LeftCoordChanged;
            viewDomains.MasterRowExpanded += viewDomains_MasterRowExpanded;
            viewBranches.LeftCoordChanged += viewBranches_LeftCoordChanged;

            viewDomains.RowCellStyle += BandedGridView_RowCellStyle;

            viewProvince.Bands[0].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            viewDomains.Bands[0].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            viewBranches.Bands[0].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            
            #region Hide bands with any columns

            foreach (GridBand bnd in viewProvince.Bands)
            {
                if (!bnd.HasChildren & bnd.Columns.Count == 0)
                {
                    bnd.Visible = false;
                }
            }

            foreach (GridBand bnd in viewDomains.Bands)
            {
                if (!bnd.HasChildren & bnd.Columns.Count == 0)
                {
                    bnd.Visible = false;
                }
            }

            foreach (GridBand bnd in viewBranches.Bands)
            {
                if (!bnd.HasChildren & bnd.Columns.Count == 0)
                {
                    bnd.Visible = false;
                }
            } 
            #endregion

            this.MyGridControl = gridControl;
            this.ProvinceGridView = viewProvince;
            this.DomainsGridView = viewDomains;
            this.BranchesGridView = viewBranches;

            System.Windows.Forms.Form frm1 = new System.Windows.Forms.Form();
            frm1.Controls.Add(gridControl);
            frm1.ShowDialog();
        }

        private GridBand AddColumnToBand(BandedGridView view, GridBand band, DataColumn column)
        {
            BandedGridColumn bgc = view.Columns.AddField(column.ColumnName);
            bgc.Name = column.ColumnName;
            bgc.Caption = column.Caption;
            bgc.AppearanceHeader.Options.UseTextOptions = true;
            bgc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            bgc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            bgc.AppearanceCell.Options.UseTextOptions = true;
            bgc.AppearanceCell.Options.UseBackColor = true;
            bgc.Visible = true;
            if (column.ExtendedProperties.ContainsKey("ColumnWidth"))
            {
                bgc.Width = int.Parse(column.ExtendedProperties["ColumnWidth"].ToString());
                bgc.OptionsColumn.FixedWidth = true;
            }
            band.Columns.Add(bgc);
            return band;
        }
        private GridBand AddColumnToBand(BandedGridView view, GridBand band, DataColumn column, bool visible)
        {
            BandedGridColumn bgc = view.Columns.AddField(column.ColumnName);
            bgc.Name = column.ColumnName;
            bgc.Caption = column.Caption;
            bgc.Visible = visible;
            bgc.AppearanceHeader.Options.UseTextOptions = true;
            bgc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            bgc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            bgc.AppearanceCell.Options.UseTextOptions = true;
            bgc.AppearanceCell.Options.UseBackColor = true;
            if (column.ExtendedProperties.ContainsKey("ColumnWidth"))
            {
                bgc.Width = int.Parse(column.ExtendedProperties["ColumnWidth"].ToString());
                bgc.OptionsColumn.FixedWidth = true;
            }  
            band.Columns.Add(bgc);
            return band;
        }


        private GridBand CreateBand(BandedGridView view, string caption)
        {
            GridBand band = new GridBand();
            band.AppearanceHeader.Font = new Font("B Yekan", 11F);
            band.AppearanceHeader.ForeColor = Color.Black;
            band.AppearanceHeader.Options.UseForeColor = true;
            band.Caption = caption;
            band.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            band.RowCount = 1;
            band.AppearanceHeader.Options.UseTextOptions = true;
            band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Bands.Add(band);
            return band;
        }
        private GridBand CreateBand(BandedGridView view, string caption, int rowCount)
        {
            GridBand band = new GridBand();
            band.AppearanceHeader.Font = new Font("B Yekan", 11F);
            band.AppearanceHeader.ForeColor = Color.Black;
            band.AppearanceHeader.Options.UseForeColor = true;
            band.Caption = caption;
            band.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            band.RowCount = rowCount;
            band.AppearanceHeader.Options.UseTextOptions = true;
            band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Bands.Add(band);
            return band;
        }

        private BandedGridView CreateBandView()
        {
            BandedGridView mainband = new BandedGridView();
            mainband.Appearance.VertLine.BackColor = Color.Silver;
            mainband.Appearance.VertLine.Options.UseBackColor = true;
            mainband.Appearance.BandPanel.Font = new Font("B Yekan", 9.75F);
            mainband.Appearance.HeaderPanel.Font = new Font("B Yekan", 9.75F);
            mainband.Appearance.Row.Font = new Font("B Yekan", 9.75F);
            mainband.Appearance.Row.ForeColor = Color.Black;
            mainband.Appearance.Row.Options.UseForeColor = true;
            mainband.OptionsView.ShowGroupPanel = false;
            mainband.OptionsView.ColumnAutoWidth = false;
            mainband.DetailHeight = 700;
            //mainband.OptionsView.ShowIndicator = false;
            mainband.OptionsBehavior.ReadOnly = true;
            mainband.OptionsBehavior.Editable = false;
            mainband.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.CellFocus;
            mainband.OptionsSelection.EnableAppearanceFocusedCell = true;
            mainband.OptionsSelection.EnableAppearanceFocusedRow = false;
            return mainband;
        }

        private List<string> GetModifyList(string[] dates, ModifyType modifyType)
        {
            List<string> list = new List<string>();

            if (dates.Length > 0)
            {
                if (modifyType == ModifyType.AllWithFirstDate)
                {
                    for (int i = 0; i < dates.Length; i++)
                    {
                        if (i > 0)
                        {
                            list.Add(dates[i] + "~" + dates[0]);
                        }
                    }
                }

                if (modifyType == ModifyType.WithBackAndFirstDate)
                {
                    for (int i = 0; i < dates.Length; i++)
                    {
                        if (i > 0)
                        {
                            if (i - 1 > 0)
                                list.Add(dates[i] + "~" + dates[i - 1]);
                            list.Add(dates[i] + "~" + dates[0]);
                        }
                    }
                }
                if (modifyType == ModifyType.JustLastAndFirstDate)
                {
                    list.Add(list.Last() + "~" + list.First());
                }
            }
            return list;
        }

        private void gridControl_DataSourceChanged(object sender, EventArgs e)
        {
            if (sender is DevExpress.XtraGrid.GridControl)
            {
                GridControl gridControl = sender as DevExpress.XtraGrid.GridControl;
                foreach (BandedGridView gv in gridControl.ViewCollection)
                {
                    gv.Appearance.FilterPanel.FontSizeDelta = Properties.Settings.Default.CRSZoom;
                    gv.Appearance.Row.FontSizeDelta = Properties.Settings.Default.CRSZoom;
                    gv.Appearance.HeaderPanel.FontSizeDelta = Properties.Settings.Default.CRSZoom;
                    gv.BestFitColumns();
                }
            }
        }

        void gridControl_DoubleClick(object sender, EventArgs e)
        {
            GridControl gridControl = sender as GridControl;
            GridView currentView = gridControl.FocusedView as GridView;
            currentView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            if (currentView.IsZoomedView)
                currentView.NormalView();
            else
                currentView.ZoomView();
        }

        void viewProvince_LeftCoordChanged(object sender, EventArgs e)
        {
            this.ProvinceGridView = sender as GridView;
            this.DomainsGridView.LeftCoord = this.ProvinceGridView.LeftCoord;
            this.BranchesGridView.LeftCoord = this.ProvinceGridView.LeftCoord;

            if (this.ProvinceGridView.LeftCoord > 0 & this.DomainsGridView.LeftCoord == 0)
            {
            }
        }

        void viewDomains_LeftCoordChanged(object sender, EventArgs e)
        {
            this.DomainsGridView = sender as GridView;
        }

        void viewBranches_LeftCoordChanged(object sender, EventArgs e)
        {
            this.BranchesGridView = sender as GridView;
        }

        private string DateFormat(object obj)
        {
            if (obj == null)
                return string.Empty;

            if (obj.ToString().Contains("~"))
            {
                string[] dates = obj.ToString().Split('~');
                if (dates.Length == 2)
                {
                    StringBuilder sb = new StringBuilder();
                    if (dates[0].Length == 8 & IsNumeric.IsNumber(dates[0]))
                    {
                        sb.Append(PersianDateTime.Parse(int.Parse(dates[0])).ToShortDateString());
                    }
                    if (dates[0].Length == 6 & IsNumeric.IsNumber(dates[0]))
                    {
                    }
                    sb.Append(" نسبت به ");
                    if (dates[1].Length == 8 & IsNumeric.IsNumber(dates[1]))
                    {
                        sb.Append(PersianDateTime.Parse(int.Parse(dates[1])).ToShortDateString());
                    }
                    if (dates[1].Length == 6 & IsNumeric.IsNumber(dates[1]))
                    {

                    }

                    return sb.ToString();
                }
            }
            else
            {
                if (obj.ToString().Length == 8 & IsNumeric.IsNumber(obj))
                {
                    return PersianDateTime.Parse(int.Parse(obj.ToString())).ToShortDateString();
                }
                if (obj.ToString().Length == 6 & IsNumeric.IsNumber(obj))
                {

                }
            }

            return string.Empty;
        }

        private void viewProvince_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            BandedGridView fgv = this.MyGridControl.FocusedView as BandedGridView;
            fgv.TopRowIndex = fgv.FocusedRowHandle;
            GridView gv = fgv.GetDetailView(e.RowHandle, (sender as GridView).GetVisibleDetailRelationIndex(e.RowHandle)) as GridView;
            gv.LeftCoord = 1;
            gv.LeftCoord = 0;
        }

        private void viewDomains_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            BandedGridView fgv = this.MyGridControl.FocusedView as BandedGridView;
            fgv.TopRowIndex = fgv.FocusedRowHandle;
            GridView gv = fgv.GetDetailView(e.RowHandle, (sender as GridView).GetVisibleDetailRelationIndex(e.RowHandle)) as GridView;
            gv.LeftCoord = 1;
            gv.LeftCoord = 0;
        }

        private void BandedGridView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            BandedGridColumn column = (BandedGridColumn)e.Column;
            if (column.OwnerBand.VisibleIndex == 0)
            {
                e.Appearance.BackColor = Color.LightPink;
            }
            else
            {
                if (column.OwnerBand.VisibleIndex % 2 == 0)
                    e.Appearance.BackColor = Color.WhiteSmoke;
                else
                    e.Appearance.BackColor = Color.White;
            }
        }

    }
}
