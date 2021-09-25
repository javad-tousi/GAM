using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using GAM.Connections;
using GAM.Dialogs;
using GAM.Forms.Information.Library;
using GAM.Forms.Profile;
using GAM.Forms.Profile.Etebarat.Library;
using GAM.Forms.Settings.Library;
using GAM.Forms.Settings.SourceReports;
using GAM.Modules;
using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace GAM.Forms.Settings.ImportSourcefile
{
    public partial class frmImportFile : DevExpress.XtraEditors.XtraForm
    {
        private DataTable ReportsTable = new DataTable();
        public bool IsProcessing { get; set; }

        public frmImportFile()
        {
            InitializeComponent();
            this.ReportsTable = GetDataTable();
            gridControl.DataSource = this.ReportsTable;
        }

        #region Methods
      
        private static DataTable GetDataTable()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable("table1");
            table.Columns.Add("DataTable", typeof(object));
            table.Columns.Add("FileName", typeof(string));
            table.Columns.Add("SourceId", typeof(string));
            table.Columns.Add("SourceName", typeof(string));
            table.Columns.Add("ReportType", typeof(string));
            table.Columns.Add("Day", typeof(int));
            table.Columns.Add("Month", typeof(int));
            table.Columns.Add("Year", typeof(int));
            table.Columns.Add("Percent", typeof(int));

            return table;
        }

        private void SaveSourceRow(DataRow srcRow, int rowHandle)
        {
            try
            {
                StartQuery:
                this.IsProcessing = true;
                DataTable dataTable = srcRow["DataTable"] as DataTable;
                string year = srcRow["Year"].ToString().Length > 0 ? int.Parse(srcRow["Year"].ToString()).ToString("D2") : string.Empty;
                string month = srcRow["Month"].ToString().Length > 0 ? int.Parse(srcRow["Month"].ToString()).ToString("D2") : string.Empty;
                string day = srcRow["Day"].ToString().Length > 0 ? int.Parse(srcRow["Day"].ToString()).ToString("D2") : string.Empty;

                string tableName = string.Format("{0}{1}{2}", year, month, day);
                if (tableName.Length == 0 | (tableName.Length == 8 && !PersianDateTime.IsValidDate(tableName)))
                    throw new Exception(string.Format("تاریخ {0} نامعتبر می باشد", tableName));

                if (dataTable.Rows.Count > 0)
                {
                    using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase(string.Format("DB_{0}.mdb", srcRow["SourceID"].ToString()))))
                    {
                        objConn.Open();
                        OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                        cmd.Connection = objConn;
                        DataTable _tables = new DataTable();
                        _tables = objConn.GetSchema("Tables");
                        bool existTable = _tables.AsEnumerable().Where(x => x["TABLE_TYPE"].ToString() == "TABLE").Select(r => r["TABLE_NAME"].ToString()).Contains(tableName);
                        if (!existTable)
                        {
                            cmd.CommandText = string.Format("Select * Into [{0}] From [Structure] Where (1=2)", tableName);
                            cmd.ExecuteNonQuery();
                            gridView.SetRowCellValue(rowHandle, "Percent", 0);
                            Application.DoEvents();
                            double insertedRow = 0;
                            double maxRows = dataTable.Rows.Count;
                            double fx = maxRows / (double)100;

                            List<string> columnNames = new List<string>();
                            columnNames.AddRange(dataTable.Columns.Cast<DataColumn>().Select(col => "[" + col.ColumnName + "]").ToArray());

                            foreach (DataRow row in dataTable.Rows)
                            {
                                StringBuilder cmdBuilder = new StringBuilder();
                                
                                cmdBuilder.Append("(");
                                foreach (DataColumn col in dataTable.Columns)
                                {
                                    if (col.Ordinal == 0)
                                    {
                                        if (col.DataType == typeof(string))
                                            cmdBuilder.Append("'" + row[col] + "'");
                                        else
                                            cmdBuilder.Append(row[col]);
                                    }
                                    else
                                    {
                                        if (col.DataType == typeof(string))
                                            cmdBuilder.Append("," + "'" + row[col] + "'");
                                        else
                                            cmdBuilder.Append("," + row[col]);
                                    }
                                }
                                cmdBuilder.Append(")");

                                cmd.CommandText = string.Format("INSERT INTO [{0}] ({1}) VALUES {2}", tableName, string.Join(",", columnNames), cmdBuilder);
                                
                                try
                                {
                                    insertedRow += cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message + " [" + cmd.CommandText + " ]");
                                }

                                if (insertedRow >= fx)
                                {
                                    fx += maxRows / (double)100;
                                    gridView.SetRowCellValue(rowHandle, "Percent", (int)((insertedRow / maxRows) * 100));
                                    Application.DoEvents();
                                }
                            }

                            if (insertedRow > 0)
                            {
                                gridView.SetRowCellValue(rowHandle, "Percent", 100);
                            }
                            objConn.Close();
                            AfterSaveRow(srcRow);
                        }
                        else
                        {
                            DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                            args.Icon = System.Drawing.SystemIcons.Warning;
                            args.Text = "این مقطع قبلا آرشیو شده است آیا مایل به حذف و بارگذاری مجدد آن می باشید؟";
                            args.DefaultButtonIndex = 1;
                            args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                            DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                            if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                            {
                                Application.DoEvents();
                                cmd.CommandText = "DROP TABLE " + tableName;
                                cmd.ExecuteNonQuery();
                                goto StartQuery;
                            }
                        }
                    }
                }
                else
                    DevExpress.XtraEditors.XtraMessageBox.Show("رکوردی برای ذخیره وجود ندارد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                this.IsProcessing = false;
                
            }
            catch (Exception ex)
            {
                this.IsProcessing = false;
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AfterSaveRow(DataRow srcRow)
        {
            if (srcRow["SourceId"].ToString() == "424")
            {
                DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args.Icon = System.Drawing.SystemIcons.Warning;
                args.Text = "آیا مایل به بروزرسانی جداول پیشنهادات می باشید؟";
                args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    Application.DoEvents();
                    DataTable table424 = (DataTable)(srcRow["DataTable"]);
                    var sortRows = table424.AsEnumerable().OrderByDescending(x => int.Parse(x["RequestDate"].ToString().Replace("/", "")));
                    Dictionary<double, DataRow> dataRows = new Dictionary<double, DataRow>();
                    foreach (var row in sortRows)
                    {
                        if (!dataRows.ContainsKey(Numeral.AnyToDouble(row["RequestID"])))
                            dataRows.Add(Numeral.AnyToDouble(row["RequestID"]), row);
                    }
                    
                    List<string> logs1 = new List<string>();
                    List<string> logs2 = new List<string>();
                    List<string> logs3 = new List<string>();
                    List<string> logs4 = new List<string>();
                    List<string> logs5 = new List<string>();

                    var tables = RequestManager.GetRequests("*");
                    foreach (DataTable tbl in tables)
                    {
                        foreach (DataRow row2 in tbl.Rows)
                        {
                            double requestId = Numeral.AnyToDouble(row2["RequestID"]);
                            if (dataRows.ContainsKey(requestId))
                            {
                                if (row2["RequestType"].ToString() == "حد اعتباری" | row2["RequestType"].ToString() == "سقف اعتباری")
                                    row2["RequestType"] = "موردی";
 
                                DataRow row1 = dataRows[requestId];

                                if (row2["RequestStatus"].ToString() != RequestStatus.Ebtal)
                                {
                                    if (row1["RequestStatus"].ToString() == "رد" | row1["RequestStatus"].ToString() == "ابطال")
                                    {
                                        row2["RequestStatus"] = RequestStatus.Ebtal;
                                        //پیشنهاد باطل شد
                                        logs1.Add(row2["RequestSerial"].ToString());
                                        continue;
                                    }
                                }
                                if (row2["RequestStatus"].ToString() == RequestStatus.Mokhalefat)
                                {
                                    continue;
                                }

                                if (row1["BranchID"].ToString() == "18")
                                {
                                    if (Numeral.AnyToLong(row2["RequestAmount"]) != (Numeral.AnyToLong(row1["RequestAmount"]) / 1000000))
                                    {
                                        row2["RequestAmount"] = Numeral.AnyToLong(row1["RequestAmount"]) / 1000000;
                                    }

                                    if (row1["RequestStatus"].ToString() == "ابلاغ شده" | row1["RequestStatus"].ToString() == "مصوب")
                                    {
                                        if (row2["RequestStatus"].ToString() != RequestStatus.Mosavab)
                                        {
                                            row2["RequestStatus"] = RequestStatus.Mosavab;
                                            //پیشنهاد مصوب شد
                                            logs2.Add(row2["RequestSerial"].ToString());
                                        }
                                    }
                                    if (row1["RequestStatus"].ToString() == "قرارداد شده")
                                    {
                                        if (row2["RequestStatus"].ToString() != RequestStatus.Gharardad)
                                        {
                                            row2["RequestStatus"] = RequestStatus.Gharardad;
                                            //مصوبه توسط شعبه اجرا گردید
                                            logs3.Add(row2["RequestSerial"].ToString());
                                        }
                                    }
                                }
                                else
                                {
                                    bool isBranch = false;
                                    if (Branches.IsBranch(row1["BranchID"].ToString()))
                                        isBranch = true;

                                    if (row1["RequestStatus"].ToString() == "ابلاغ شده" | row1["RequestStatus"].ToString() == "مصوب")
                                    {
                                        if (row2["RequestStatus"].ToString() != RequestStatus.Mosavab)
                                        {
                                            if (isBranch)
                                            {
                                                row2["CreditCommittee"] = "شعبه";
                                                //توسط شعبه مصوب گردید
                                                logs5.Add(row2["RequestSerial"].ToString());
                                            }
                                            else
                                            {
                                                row2["CreditCommittee"] = "حوزه";
                                                //توسط حوزه مصوب گردید
                                                logs4.Add(row2["RequestSerial"].ToString());
                                            }

                                            row2["RequestStatus"] = RequestStatus.Mosavab;
                                        }
                                    }
                                    if (row1["RequestStatus"].ToString() == "قرارداد شده")
                                    {
                                        if (row2["RequestStatus"].ToString() != RequestStatus.Gharardad)
                                        {
                                            if (isBranch)
                                                row2["CreditCommittee"] = "شعبه";
                                            else
                                                row2["CreditCommittee"] = "حوزه"; 
                                            
                                            row2["RequestStatus"] = RequestStatus.Gharardad;
                                            //مصوبه توسط شعبه اجرا گردید
                                            logs3.Add(row2["RequestSerial"].ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }

                    foreach (DataTable tbl in tables)
                    {
                        RequestManager.UpdateChangeRows(tbl);
                    }

                    dlgDataLogs.AddRequestLog(logs1.ToArray(), 3, "پیشنهاد باطل شد", 1);
                    dlgDataLogs.AddRequestLog(logs2.ToArray(), 4, "پیشنهاد مصوب شد", 1);
                    dlgDataLogs.AddRequestLog(logs3.ToArray(), 14, "مصوبه توسط شعبه اجرا گردید", 1);
                    dlgDataLogs.AddRequestLog(logs4.ToArray(), 15, "توسط حوزه مصوب گردید", 1);
                    dlgDataLogs.AddRequestLog(logs5.ToArray(), 15, "توسط شعبه مصوب گردید", 1);

                }
            }
        }

       #endregion   
     
        #region Events

        private void btnBrwose_Click(object sender, EventArgs e)
        {
            try
            {
                btnBrowse.Enabled = false;
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "XML Spreadsheet (*.xml)|*.xml";
                dlg.FilterIndex = 2;
                dlg.RestoreDirectory = true;
                dlg.Multiselect = true;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.FileName != string.Empty)
                    {
                        pnlBottom.Enabled = true;
                        lblFileName.Text = System.IO.Path.GetDirectoryName(dlg.FileName);
                        foreach (string fileName in dlg.FileNames)
                        {
                            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgPleaseWait), true, true, false);
                            Application.DoEvents();
                            DataTable tableInput = XmlSpreadSheet.ToDataTable(fileName);
                            DataRow mapRow = SourceReportsManager.UnknownFileDetection(tableInput);
                            if (mapRow != null)
                            {
                                if (mapRow["StartupMessage"].ToString().Length > 0)
                                    new dlgStartupMessage(mapRow["StartupMessage"].ToString()).ShowDialog();

                                DataTable tableOut = SourceReportsManager.FormattedReportTable(tableInput, mapRow["XmlMap"].ToString());
                                XmlDocument xdoc = new XmlDocument();
                                xdoc.LoadXml(mapRow["XmlMap"].ToString());
                                DataRow newRow = this.ReportsTable.NewRow();
                                newRow["DataTable"] = tableOut;
                                newRow["FileName"] = fileName;
                                newRow["SourceId"] = mapRow["SourceID"].ToString();
                                newRow["SourceName"] = mapRow["SourceID"].ToString() + "- " + mapRow["SourceName"].ToString();
                                newRow["ReportType"] = xdoc.SelectSingleNode("Map/Properties/ReportType").InnerText;
                                this.ReportsTable.Rows.Add(newRow);
                            }
                            else
                            {
                                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                                DevExpress.XtraEditors.XtraMessageBox.Show(string.Format("شناسایی نشد {0} متاسفانه محتوای فایل", fileName), "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                        }
                    }
                }

                btnBrowse.Enabled = true;
            }
            catch (Exception ex)
            {
                btnBrowse.Enabled = true;
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column.FieldName == "Day")
                {
                    string value = gridView.GetRowCellValue(e.RowHandle, gridView.Columns["ReportType"]).ToString();
                    if (value == "دوره ای")
                    {
                        e.RepositoryItem = null;
                    }
                }
            }
        }

        private void repositoryShowRow_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
            if (row != null)
            {
                if (!this.IsProcessing)
                {
                    new dlgSourceTables(row["SourceID"].ToString()).ShowDialog();
                }
            }
        }

        private void repositorySaveRow_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
            if (row != null)
            {
                if (!this.IsProcessing)
                    SaveSourceRow(row, gridView.FocusedRowHandle);
                else
                    DevExpress.XtraEditors.XtraMessageBox.Show("فایل هم اکنون در حال ذخیره می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void repositoryDeleteRow_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
            if (row != null)
            {
                if (!this.IsProcessing)
                    gridView.DeleteRow(gridView.FocusedRowHandle);
                else
                    DevExpress.XtraEditors.XtraMessageBox.Show("فایل هم اکنون در حال ذخیره می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
            if (row != null)
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook wb = excel.Workbooks.Open(row["FilePath"].ToString());
                excel.Visible = true;
            }
        }
     
        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            if (!this.IsProcessing)
            {
                pnlBottom.Enabled = false;
                Application.DoEvents();
                DataTable table = gridControl.DataSource as DataTable;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    SaveSourceRow(table.Rows[i], i);
                }
                pnlBottom.Enabled = true;
            }
        }
        
        private void btnNewArchive_Click(object sender, EventArgs e)
        {
            if (!this.IsProcessing)
            {
                pnlBottom.Enabled = false;
                this.ReportsTable = GetDataTable();
                gridControl.DataSource = this.ReportsTable;
                lblFileName.Text = string.Empty;
            }
        }

        private void frmImportDatafile_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.IsProcessing)
                e.Cancel = true;
        }
      
        #endregion    
    }
}
