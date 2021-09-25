using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using GAM.Dialogs;
using GAM.Forms.Settings.Library;
using GAM.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace GAM.Forms.Settings.SourceReports
{
    public partial class dlgSourceMap : DevExpress.XtraEditors.XtraForm
    {
        DataRow thisRow;
        public dlgSourceMap(DataRow row)
        {
            InitializeComponent();
            thisRow = row;

            DataTable tableBaseColumns = new DataTable();
            tableBaseColumns.Columns.Add("Index");
            tableBaseColumns.Columns.Add("Name");
            tableBaseColumns.Columns.Add("HeaderText");
            tableBaseColumns.Columns.Add("HeaderLocation");
            tableBaseColumns.Columns.Add("Caption");
            tableBaseColumns.Columns.Add("Type");
            tableBaseColumns.Columns.Add("UnitPrice");
            gridBaseColumns.DataSource = tableBaseColumns;


            DataTable tableCustomColumns = new DataTable();
            tableCustomColumns.Columns.Add("Name");
            tableCustomColumns.Columns.Add("Caption");
            tableCustomColumns.Columns.Add("Type");
            tableCustomColumns.Columns.Add("Extension");
            tableCustomColumns.Columns.Add("UnitPrice");
            gridCustomColumns.DataSource = tableCustomColumns;

            DataTable tableVirtualColumns = new DataTable();
            tableVirtualColumns.Columns.Add("Name");
            tableVirtualColumns.Columns.Add("Caption");
            tableVirtualColumns.Columns.Add("Type");
            tableVirtualColumns.Columns.Add("UnitPrice");
            gridVirtualColumns.DataSource = tableVirtualColumns;

            cboReferences.Text = row["ReferenceName"].ToString();
            txtSourceName.Text = row["SourceName"].ToString();
            txtSourceId.Text = row["SourceID"].ToString();

            ReadXmlMap(row["XmlMap"].ToString());
        }

        #region Methods
     
        private void FillMasterTable(string fileName)
        {
            try
            {
                gridReport.DataSource = null;
                viewReport.ClearDocument();
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgPleaseWait), true, true);
                gridReport.DataSource = XmlSpreadSheet.ToDataTable(fileName);
                viewReport.BestFitColumns();
                txtPrimaryColumnIndex.Tag = viewReport.Columns.Count;
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
            }
            catch (Exception ex)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetXmlMap()
        {
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = Encoding.UTF8;
            XmlWriter xmlWriter = XmlWriter.Create(sb, settings);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Map");

            #region Properties
            xmlWriter.WriteStartElement("Properties");//start Properties

            xmlWriter.WriteStartElement("ReportName");
            xmlWriter.WriteString(txtSourceName.Text.Trim());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("SourceID");
            xmlWriter.WriteString(txtSourceId.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("SourceName");
            xmlWriter.WriteString(cboReferences.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("ReportType");
            xmlWriter.WriteString(cboReportType.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndElement(); //end Properties
            #endregion

            #region Parameters
            xmlWriter.WriteStartElement("Parameters");//start Parameters

            xmlWriter.WriteStartElement("ReportTitle");
            xmlWriter.WriteString(txtReportTitle.Text.Trim());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("ReportTitleLocation");
            xmlWriter.WriteString(txtReportTitleLocation.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("StartupMessage");
            xmlWriter.WriteString(txtStartupMessage.Text.Trim());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("ColumnsCount");
            xmlWriter.WriteString(txtPrimaryColumnIndex.Tag.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("PrimaryColumnIndex");
            xmlWriter.WriteString(txtPrimaryColumnIndex.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("FirstDataRowIndex");
            xmlWriter.WriteString(txtFirstDataRowIndex.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndElement(); //end Parameters
            #endregion

            #region BaseColumns
            xmlWriter.WriteStartElement("BaseColumns");//start BaseColumns

            DataTable tableBaseColumns = gridBaseColumns.DataSource as DataTable;
            foreach (DataRow row in tableBaseColumns.Rows)
            {
                xmlWriter.WriteStartElement("BaseColumn");

                foreach (DataColumn col in tableBaseColumns.Columns)
                {
                    xmlWriter.WriteStartElement(col.ColumnName);
                    xmlWriter.WriteString(row[col].ToString());
                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement(); //end BaseColumns
            #endregion

            #region CustomColumns
            xmlWriter.WriteStartElement("CustomColumns");//start CustomColumns

            DataTable tableCustomColumns = gridCustomColumns.DataSource as DataTable;
            foreach (DataRow row in tableCustomColumns.Rows)
            {
                xmlWriter.WriteStartElement("CustomColumn");

                foreach (DataColumn col in tableCustomColumns.Columns)
                {
                    xmlWriter.WriteStartElement(col.ColumnName);
                    xmlWriter.WriteString(row[col].ToString());
                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement(); //end CustomColumns
            #endregion

            #region VirtualColumns
            xmlWriter.WriteStartElement("VirtualColumns");//start VirtualColumns

            DataTable tableVirtualColumns = gridVirtualColumns.DataSource as DataTable;
            foreach (DataRow row in tableVirtualColumns.Rows)
            {
                xmlWriter.WriteStartElement("VirtualColumn");

                foreach (DataColumn col in tableVirtualColumns.Columns)
                {
                    xmlWriter.WriteStartElement(col.ColumnName);
                    xmlWriter.WriteString(row[col].ToString());
                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement(); //end VirtualColumns
            #endregion

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

            return sb.ToString();
        }

        private void ReadXmlMap(string xml)
        {
            try
            {
                XmlDocument xdoc = new XmlDocument();

                if (xml.Length > 0)
                {
                    if (System.IO.File.Exists(xml))
                        xdoc.Load(xml);
                    else
                        xdoc.LoadXml(xml);
                }
                else
                    return;

                #region ResetForm
                txtSourceName.ResetText();
                cboReferences.SelectedIndex = 0;
                txtSourceId.ResetText();
                cboReportType.SelectedIndex = 0;

                txtReportTitle.ResetText();
                txtReportTitleLocation.ResetText();
                txtStartupMessage.ResetText();
                txtPrimaryColumnIndex.ResetText();
                txtPrimaryColumnIndex.Tag = string.Empty;
                txtFirstDataRowIndex.ResetText();
                DataTable tableBaseColumns = gridBaseColumns.DataSource as DataTable;
                tableBaseColumns.Rows.Clear();
                DataTable tableCustomColumns = gridCustomColumns.DataSource as DataTable;
                tableCustomColumns.Rows.Clear();
                DataTable tableVirtualColumns = gridVirtualColumns.DataSource as DataTable;
                tableVirtualColumns.Rows.Clear();
                #endregion

                #region Properties

                txtSourceName.Text = xdoc.SelectSingleNode("Map/Properties/ReportName").InnerText;
                txtSourceId.Text = xdoc.SelectSingleNode("Map/Properties/SourceID").InnerText;
                cboReferences.Text = xdoc.SelectSingleNode("Map/Properties/SourceName").InnerText;
                cboReportType.Text = xdoc.SelectSingleNode("Map/Properties/ReportType").InnerText;

                #endregion

                #region Parameters

                txtReportTitle.Text = xdoc.SelectSingleNode("Map/Parameters/ReportTitle").InnerText;
                txtReportTitleLocation.Text = xdoc.SelectSingleNode("Map/Parameters/ReportTitleLocation").InnerText;
                txtStartupMessage.Text = xdoc.SelectSingleNode("Map/Parameters/StartupMessage").InnerText;
                txtPrimaryColumnIndex.Text = xdoc.SelectSingleNode("Map/Parameters/PrimaryColumnIndex").InnerText;
                txtPrimaryColumnIndex.Tag = xdoc.SelectSingleNode("Map/Parameters/ColumnsCount").InnerText;
                txtFirstDataRowIndex.Text = xdoc.SelectSingleNode("Map/Parameters/FirstDataRowIndex").InnerText;

                #endregion

                #region BaseColumns

                foreach (XmlNode cols in xdoc.SelectNodes("Map/BaseColumns"))
                {
                    foreach (XmlNode col in cols.ChildNodes)
                    {
                        string xindex = col.SelectSingleNode("Index").InnerText;
                        string xname = col.SelectSingleNode("Name").InnerText;
                        string xheaderText = col.SelectSingleNode("HeaderText").InnerText;
                        string xheaderLocation = col.SelectSingleNode("HeaderLocation").InnerText;
                        string xcaption = col.SelectSingleNode("Caption").InnerText;
                        string xtype = col.SelectSingleNode("Type").InnerText;
                        string xunitPrice = (col.SelectSingleNode("UnitPrice") != null) ? col.SelectSingleNode("UnitPrice").InnerText : "";

                        DataRow row = tableBaseColumns.NewRow();
                        row["Index"] = xindex;
                        row["Name"] = xname;
                        row["HeaderText"] = xheaderText;
                        row["HeaderLocation"] = xheaderLocation;
                        row["Caption"] = xcaption;
                        row["Type"] = xtype;
                        row["UnitPrice"] = xunitPrice;

                        tableBaseColumns.Rows.Add(row);
                    }
                }

                #endregion

                #region CustomColumns

                foreach (XmlNode cols in xdoc.SelectNodes("Map/CustomColumns"))
                {
                    foreach (XmlNode col in cols.ChildNodes)
                    {
                        string xname = col.SelectSingleNode("Name").InnerText;
                        string xcaption = col.SelectSingleNode("Caption").InnerText;
                        string xtype = col.SelectSingleNode("Type").InnerText;
                        string xextension = col.SelectSingleNode("Extension").InnerText;
                        string xunitPrice = col.SelectSingleNode("UnitPrice").InnerText;

                        DataRow row = tableCustomColumns.NewRow();
                        row["Name"] = xname;
                        row["Caption"] = xcaption;
                        row["Type"] = xtype;
                        row["Extension"] = xextension;
                        row["UnitPrice"] = xunitPrice;

                        tableCustomColumns.Rows.Add(row);
                    }
                }

                #endregion

                #region VirtualColumns

                foreach (XmlNode cols in xdoc.SelectNodes("Map/VirtualColumns"))
                {
                    foreach (XmlNode col in cols.ChildNodes)
                    {
                        string xname = col.SelectSingleNode("Name").InnerText;
                        string xcaption = col.SelectSingleNode("Caption").InnerText;
                        string xtype = col.SelectSingleNode("Type").InnerText;
                        string xunitPrice = col.SelectSingleNode("UnitPrice").InnerText;

                        DataRow row = tableVirtualColumns.NewRow();
                        row["Name"] = xname;
                        row["Caption"] = xcaption;
                        row["Type"] = xtype;
                        row["UnitPrice"] = xunitPrice;

                        tableVirtualColumns.Rows.Add(row);
                    }
                }

                #endregion

                viewBaseColumns.BestFitColumns();
                viewCustomColumns.BestFitColumns();
                viewVirtualColumns.BestFitColumns();
            }
            catch
            {
            }
        }
        
        #endregion

        #region Locatios

        private void txtReportTitleLocation_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (viewReport.FocusedRowHandle >= 0)
            {
                int x = viewReport.FocusedColumn.VisibleIndex;
                int y = viewReport.FocusedRowHandle;
                txtReportTitleLocation.Text = x + ", " + y;
            }
        }

        private void txtPrimaryColumnIndex_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int x = viewReport.FocusedColumn.VisibleIndex;
            txtPrimaryColumnIndex.Text = x.ToString();
            txtPrimaryColumnIndex.Tag = viewReport.VisibleColumns.Count;
        }

        private void txtFirstDataRowIndex_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int y = viewReport.FocusedRowHandle;
            txtFirstDataRowIndex.Text = y.ToString();
        }

        #endregion

        #region Base Columns
       
        private void grpBaseColumns_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (viewReport.FocusedRowHandle >= 0)
            {
                if (e.Button == grpBaseColumns.CustomHeaderButtons[3])
                {
                    DataTable table = gridBaseColumns.DataSource as DataTable;
                    dlgAddBaseColumn dlg = new dlgAddBaseColumn(viewReport, viewBaseColumns);
                    dlg.ShowDialog();
                }
            }
            if (e.Button == grpBaseColumns.CustomHeaderButtons[0])
            {
                DevExportToXlsx.SaveAs(viewBaseColumns);
            }

            if (e.Button == grpBaseColumns.CustomHeaderButtons[1])
            {
                if (viewBaseColumns.FocusedRowHandle - 1 >= 0)
                {
                    DataTable dt = gridBaseColumns.DataSource as DataTable;
                    if (dt != null)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow.ItemArray = viewBaseColumns.GetFocusedDataRow().ItemArray;
                        dt.Rows.Remove(viewBaseColumns.GetFocusedDataRow());
                        dt.Rows.InsertAt(newRow, viewBaseColumns.FocusedRowHandle - 1);
                        viewBaseColumns.FocusedRowHandle = viewBaseColumns.FocusedRowHandle - 2;
                    }
                }
            }

            if (e.Button == grpBaseColumns.CustomHeaderButtons[2])
            {
                if (viewBaseColumns.FocusedRowHandle + 1 < viewBaseColumns.RowCount)
                {
                    DataTable dt = gridBaseColumns.DataSource as DataTable;
                    if (dt != null)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow.ItemArray = viewBaseColumns.GetFocusedDataRow().ItemArray;
                        dt.Rows.Remove(viewBaseColumns.GetFocusedDataRow());
                        dt.Rows.InsertAt(newRow, viewBaseColumns.FocusedRowHandle + 1);
                        viewBaseColumns.FocusedRowHandle = viewBaseColumns.FocusedRowHandle + 1;
                    }
                }
            }
        }

        private void gridBaseColumns_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = viewBaseColumns.GetDataRow(viewBaseColumns.FocusedRowHandle);
            if (gridReport.DataSource != null && row != null)
            {
                DataTable table = gridBaseColumns.DataSource as DataTable;
                dlgAddBaseColumn dlg = new dlgAddBaseColumn(viewReport, viewBaseColumns, row);
                dlg.ShowDialog();
                viewBaseColumns.BestFitColumns();
            }
        }
      
        public void viewBaseColumns_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow row = viewBaseColumns.GetDataRow(viewBaseColumns.FocusedRowHandle);
                if (row != null && gridReport.DataSource != null)
                {
                    Point point = UDF.StringToPoint(row["HeaderLocation"].ToString());
                    viewReport.FocusedRowHandle = point.Y;
                    viewReport.FocusedColumn = viewReport.GetVisibleColumn(point.X);
                    foreach (GridColumn col in viewReport.Columns)
                    {
                        col.AppearanceCell.BackColor = Color.White;
                    }
                    viewReport.FocusedColumn.AppearanceCell.BackColor = Color.Gainsboro;
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridBaseColumns_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete & viewBaseColumns.FocusedRowHandle >= 0)
            {
                DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args.Icon = System.Drawing.SystemIcons.Warning;
                args.Caption = "سوال";
                args.Text = "آیا مایل به حذف این ستون می باشید؟";
                args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    viewBaseColumns.DeleteRow(viewBaseColumns.FocusedRowHandle);
                }
            }
        }

        #endregion

        #region Custom Columns
       
        private void grpCustomColumns_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (viewBaseColumns.RowCount > 0)
            {
                DataTable table = gridCustomColumns.DataSource as DataTable;
                dlgAddCustomColumn dlg = new dlgAddCustomColumn(table);
                DialogResult dlgResult = dlg.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    gridCustomColumns.DataSource = dlg.TableCustomColumns;
                    viewCustomColumns.BestFitColumns();
                }
            }
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً ابتدا ستون های اصلی را مشخص نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void gridCustomColumns_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = viewCustomColumns.GetDataRow(viewCustomColumns.FocusedRowHandle);
            if (row != null)
            {
                DataTable table = gridCustomColumns.DataSource as DataTable;
                dlgAddCustomColumn dlg = new dlgAddCustomColumn(row);
                DialogResult dlgResult = dlg.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    gridCustomColumns.DataSource = dlg.TableCustomColumns;
                    viewCustomColumns.BestFitColumns();
                }
            }
        }
        
        #endregion

        #region Virtual Columns

        private void grpVirtualColumns_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            DataTable table = gridVirtualColumns.DataSource as DataTable;
            dlgAddVirtualColumn dlg = new dlgAddVirtualColumn(viewVirtualColumns);
            dlg.ShowDialog();
        }

        private void gridVirtualColumns_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = viewVirtualColumns.GetDataRow(viewVirtualColumns.FocusedRowHandle);
            if (gridVirtualColumns.DataSource != null && row != null)
            {
                DataTable table = gridVirtualColumns.DataSource as DataTable;
                dlgAddVirtualColumn dlg = new dlgAddVirtualColumn(viewVirtualColumns, row);
                dlg.ShowDialog();
                viewVirtualColumns.BestFitColumns();
            }
        }

        private void gridVirtualColumns_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete & viewVirtualColumns.FocusedRowHandle >= 0)
            {
                DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args.Icon = System.Drawing.SystemIcons.Warning;
                args.Caption = "سوال";
                args.Text = "آیا مایل به حذف این ستون می باشید؟";
                args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    viewVirtualColumns.DeleteRow(viewVirtualColumns.FocusedRowHandle);
                }
            }
        } 
        #endregion

        #region Events
        
        private void viewReport_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (viewReport.FocusedRowHandle >= 0)
            {
                int x = viewReport.FocusedColumn.VisibleIndex;
                int y = viewReport.FocusedRowHandle;
                txtCurrentLocation.Text = x + ", " + y;
            }
        }

        private void viewReport_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (viewReport.FocusedRowHandle >= 0)
            {
                int x = viewReport.FocusedColumn.VisibleIndex;
                int y = viewReport.FocusedRowHandle;
                txtCurrentLocation.Text = x + ", " + y;
            }
        }
        
        #endregion  
        
        #region Save & Load
      
        private void grpGridView_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "XML Spreadsheet (*.xml)|*.xml";
                dlg.FilterIndex = 2;
                dlg.RestoreDirectory = true;
                dlg.Multiselect = true;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.FileName != string.Empty)
                    {
                        if (!Modules.UDF.IsFileLocked(dlg.FileName))
                        {
                            Application.DoEvents();
                            FillMasterTable(dlg.FileName);
                        }
                        else
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("فایل انتخاب شده هم اکنون در حال اجرا می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (thisRow != null)
            {
                DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args.Icon = System.Drawing.SystemIcons.Question;
                args.Caption = "سوال";
                args.Text = "آیا مایل به ذخیره اطلاعات می باشید؟";
                args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    SourceReportsManager.UpdateSourceId(cboReferences.Text, int.Parse(txtSourceId.Text), txtSourceName.Text);
                    SourceReportsManager.SaveMap(int.Parse(txtSourceId.Text), GetXmlMap());
                    DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات با موفقیت ذخیره شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnLoadMap_Click(object sender, EventArgs e)
        {
            try
            {
                btnLoadMap.Enabled = false;
                Application.DoEvents();

                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "XML Spreadsheet (*.xml)|*.xml";
                dlg.FilterIndex = 2;
                dlg.RestoreDirectory = true;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.FileName != string.Empty)
                    {
                        ReadXmlMap(dlg.FileName);
                        btnLoadMap.Enabled = true;
                        DevExpress.XtraEditors.XtraMessageBox.Show("فایل با موفقیت بارگذاری شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                btnLoadMap.Enabled = true;
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveMap_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Save Report";
            dlg.Filter = "XML File|*.xml";
            dlg.ShowDialog();
            if (dlg.FileName != "")
            {
                var file = System.IO.File.CreateText(dlg.FileName);
                file.Write(GetXmlMap());
                file.Close();
            }
        }

        private void btnExportToXlsx_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tableReport = gridReport.DataSource as DataTable;
                DataTable tableOutput = SourceReportsManager.FormattedReportTable(tableReport, GetXmlMap());
                DevExportToXlsx.DataTableToExcel(tableOutput);
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        #endregion
    }
}
