using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MD.PersianDateTime;
using GAM.Forms.Information.Library;
using DevExpress.XtraEditors;
using GAM.Modules;
using System.Xml;
using System.IO;
using GAM.Forms.Settings.Library;
using System.Collections;
using DevExpress.XtraGrid.Views.BandedGrid;
using GAM.Connections;
using GAM.Forms.Reports.Queries;
using GAM.Forms.Reports.Library;
using DevExpress.XtraEditors.Controls;
using System.Text.RegularExpressions;
using System.Xml.Linq;


namespace GAM.Forms.Reports.Master
{
    #region Structurs

    struct ListItem
    {
        public ListItem(string id, string name, string value)
        {
            Id = id;
            Name = name;
            Value = value;
        }

        public string Id;
        public string Name;
        public string Value;

        public override string ToString()
        {
            return Id + "- " + Name;
        }
    }

    struct DateCompare
    {
        public DataColumn Column1 { get; set; }
        public DataColumn Column2 { get; set; }
        public string Text
        {
            get
            {
                return Column2.Namespace + " نسبت به " + Column1.Namespace;
            }
        }
    }

    #endregion

    public partial class dlgNewReport : DevExpress.XtraEditors.XtraForm
    {
        #region Propertise

        string Guid;
        DataTable TableDates = new DataTable();
        QueryProperties Properties = new QueryProperties();
        frmReports ReportsForm;
        dlgReportsList ReportsListForm = new dlgReportsList();
        string SavedDates = string.Empty;
        #endregion

        public dlgNewReport(frmReports frm)
        {
            InitializeComponent();
            this.TableDates = GetDateTable();
            this.ReportsForm = frm;
            this.Properties.Clear();
            txtReportsList.Focus();
            txtReportsList.Select();
            NewReport();
        }
        public dlgNewReport(frmReports frm, QueryProperties qpro)//حالت بارگذاری فایل
        {
            InitializeComponent();
            this.TableDates = GetDateTable();
            this.ReportsForm = frm;
            NewReport();
            InitializeForm(qpro);
            btnSubmitQuery_Click(null, EventArgs.Empty);
        }

        #region Events

        private void cboCompareOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCompareOrder.SelectedIndex > 0)
                cboComparisonsItems.Enabled = true;
            else
            {
                cboComparisonsItems.Enabled = false;
                foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in cboComparisonsItems.Properties.Items)
                    item.CheckState = CheckState.Unchecked;
            }
        }

        private void btnReportsList_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DialogResult dlgRes = this.ReportsListForm.ShowDialog();
            if (dlgRes == System.Windows.Forms.DialogResult.OK & this.ReportsListForm.ReportRow != null)
            {
                Dictionary<string, object> pList = new Dictionary<string, object>();
                pList = this.ReportsListForm.ReportRow.Table.Columns
                    .Cast<DataColumn>()
                    .ToDictionary(c => c.ColumnName, c => this.ReportsListForm.ReportRow[c]);
                pList.Add("CompareOrder", string.Empty);
                pList.Add("CompareItems", string.Empty);
                pList.Add("EvaluationItems1", string.Empty);
                pList.Add("EvaluationItems2", string.Empty);
                pList.Add("EvaluationItems3", string.Empty);
                pList.Add("OtherEvaluationItems", string.Empty);
                pList.Add("EvaluationType1", string.Empty);
                pList.Add("EvaluationType2", string.Empty);
                pList.Add("EvaluationType3", string.Empty);
                pList.Add("SelectedDates", string.Empty);
                pList.Add("PrimaryColumnName", string.Empty);
                pList.Add("PrimaryColumnText", string.Empty);
                pList.Add("PrimaryColumnFormat", string.Empty);
                pList.Add("PrimaryColumnRule", string.Empty);
                pList.Add("PrimaryPercentageRule", string.Empty);
                pList.Add("ExportMode", string.Empty);
                pList["SelectedDates"] = this.SavedDates;

                InitializeForm(QueryProperties.Fill(pList));
            }
        }
       
        private void txtReportsList_Click(object sender, EventArgs e)
        {
            btnReportsList_ButtonClick(null, null);
        }

        private async void btnSubmitQuery_Click(object sender, EventArgs e)
        {
            if (this.GetSelectedDates() == null || this.GetSelectedDates().Count() == 0)
            {
                lblMessage.Show();
                lblMessage.BackColor = Color.LightPink;
                lblMessage.Text = "هیچ تاریخی برای ارائه گزارش به لیست اضافه نشده است!";
                return;
            }
            if (GetCheckedComboBoxEdit(cboEvaluationItems1).Length > 0 & cboEvaluationType1.Text.Length == 0 |
                GetCheckedComboBoxEdit(cboEvaluationItems2).Length > 0 & cboEvaluationType2.Text.Length == 0 |
                GetCheckedComboBoxEdit(cboEvaluationItems3).Length > 0 & cboEvaluationType3.Text.Length == 0)
            {
                lblMessage.Show();
                lblMessage.BackColor = Color.LightPink;
                lblMessage.Text = "هیچ ستونی برای ارزیابی انتخاب نشده است!";
                return;
            }

            try
            {
                btnSubmitQuery.Enabled = false;
                lblMessage.Show();
                lblMessage.BackColor = SystemColors.Info;
                lblMessage.Text = "سیستم در حال تهیه گزارش می باشد ...";
                lblMessage.Appearance.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/refresh_16x16.png");
                Application.DoEvents();

                this.Properties["ReportName"] = txtReportName.Text.Trim();
                this.Properties["SelectedDates"] = string.Join(",", this.GetSelectedDates());
                this.Properties["UnitAmount"] = cboUnitAmount.Text;
                this.Properties["CompareItems"] = GetCheckedComboBoxEdit(cboComparisonsItems);
                this.Properties["EvaluationItems1"] = GetCheckedComboBoxEdit(cboEvaluationItems1);
                this.Properties["EvaluationItems2"] = GetCheckedComboBoxEdit(cboEvaluationItems2);
                this.Properties["EvaluationItems3"] = GetCheckedComboBoxEdit(cboEvaluationItems3);
                this.Properties["OtherEvaluationItems"] = GetCheckedComboBoxEdit(cboOtherEvaluationItems);
                this.Properties["EvaluationType1"] = (cboEvaluationType1.SelectedIndex >=0) ? cboEvaluationType1.Properties.Items[cboEvaluationType1.SelectedIndex].Value.ToString() : string.Empty;
                this.Properties["EvaluationType2"] = (cboEvaluationType2.SelectedIndex >=0) ? cboEvaluationType2.Properties.Items[cboEvaluationType2.SelectedIndex].Value.ToString() : string.Empty;
                this.Properties["EvaluationType3"] = (cboEvaluationType3.SelectedIndex >= 0) ? cboEvaluationType3.Properties.Items[cboEvaluationType3.SelectedIndex].Value.ToString() : string.Empty;

                this.Properties["CompareOrder"] = cboCompareOrder.Text;
                this.Properties["Bands"] = null;
                this.Properties["SeriesPoints"] = null;
                this.Properties["ExportMode"] = cboExportMode.SelectedIndex;

                #region Primary Column
                if (cboPrimaryColumns.SelectedIndex >= 0)
                {
                    IComboBoxEditItem item = (IComboBoxEditItem)cboPrimaryColumns.Properties.Items[cboPrimaryColumns.SelectedIndex];
                    this.Properties["PrimaryColumnName"] = item.Name;
                    this.Properties["PrimaryColumnText"] = item.Text;
                    this.Properties["PrimaryColumnFormat"] = item.FormatNumber;
                    this.Properties["PrimaryColumnRule"] = item.ColumnRuleName;
                    this.Properties["PrimaryPercentageRule"] = item.PercentageRuleName;

                }
                #endregion

                DataSet ds = SendQuery(this.Properties);
                if (ds != null)
                {
                    this.ReportsForm.NewGridControl(ds, this.Guid);
                    btnSubmitQuery.Enabled = true;
                    lblMessage.BackColor = Color.Honeydew;
                    lblMessage.Appearance.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png");
                    lblMessage.Text = "گزارش شما با موفقیت ایجاد شد";
                    await Task.Delay(1000);
                    lblMessage.Hide();
                    await Task.Delay(300);
                    lblMessage.Show();
                    await Task.Delay(200);
                    lblMessage.Hide();
                    this.SavedDates = this.Properties["SelectedDates"].ToString();
                }

                btnSubmitQuery.Enabled = true;
                lblMessage.Hide();
            }
            catch (Exception ex)
            {
                btnSubmitQuery.Enabled = true;
                lblMessage.Hide();
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboFilterDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (int id in viewDates.GetSelectedRows())
                viewDates.UnselectRow(id);
            try
            {
                if (gridDates.DataSource == null)
                    return;

                (gridDates.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                if (cboFilterDates.Text == "مقاطع پایان ماه + روزانه ماه جاری")
                    (gridDates.DataSource as DataTable).DefaultView.RowFilter = "Default=True OR IsLastDayOfMonth=True";
                else if (cboFilterDates.Text == "مقاطع پایان ماه")
                    (gridDates.DataSource as DataTable).DefaultView.RowFilter = "IsLastDayOfMonth=True";
                else if (cboFilterDates.Text == "مقاطع پایان سال")
                    (gridDates.DataSource as DataTable).DefaultView.RowFilter = "IsLastDayOfYear=True";
                else if (cboFilterDates.Text == "همه مقاطع")
                    (gridDates.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                else
                {
                    (gridDates.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert([ReportDate], System.String) LIKE '%{0}%' OR WeekdayName='{0}'", cboFilterDates.Text);
                }
            }
            catch (Exception)
            {
                (gridDates.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void viewDates_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                bool isChecked = bool.Parse(viewDates.GetRowCellValue(e.RowHandle, "IsChecked").ToString());
                string reportDate = viewDates.GetRowCellValue(e.RowHandle, "ReportDate").ToString();
                string weekdayName = viewDates.GetRowCellValue(e.RowHandle, "WeekdayName").ToString();
                if (isChecked)
                {
                    e.Appearance.BackColor2 = Color.LightSkyBlue;
                    return;
                }

                if (PersianDateTime.IsValidDate(reportDate))
                {
                    PersianDateTime pd = PersianDateTime.Parse(reportDate);
                    if (pd.IsLastDayOfYear)
                        e.Appearance.BackColor2 = Color.FromArgb(181, 230, 29);
                    else if (pd.IsLastDayOfMonth)
                        e.Appearance.BackColor2 = Color.Yellow;
                }
                else if (weekdayName == "اسفند")
                {
                    e.Appearance.BackColor2 = Color.FromArgb(181, 230, 29);
                }
                

            }
        }

        private void txtReportsList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnReportsList_ButtonClick(null, null);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < viewDates.RowCount; i++)
                viewDates.SetRowCellValue(i, "IsChecked", false);
            lblMaxDate.Text = "تعداد مقاطع مجاز قابل انتخاب " + lblMaxDate.Tag;

            cboCompareOrder.SelectedIndex = 0;
            UncheckComboBoxItems(cboComparisonsItems);
            UncheckComboBoxItems(cboEvaluationItems1);
            UncheckComboBoxItems(cboEvaluationItems2);
            UncheckComboBoxItems(cboEvaluationItems3);
            UncheckComboBoxItems(cboOtherEvaluationItems);
        }

        private async void viewDates_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Value is bool)
            {
                string[] counts = this.GetSelectedDates();
                int left = int.Parse(lblMaxDate.Tag.ToString()) - counts.Length;
                if (e.Value.ToString() == bool.TrueString)
                    left = left - 1;
                else
                    left = left + 1;

                if (left >= 0)
                {
                    await Task.Delay(1);
                    viewDates.DetailVerticalIndent = viewDates.DetailVerticalIndent - 1;
                    viewDates.DetailVerticalIndent = viewDates.DetailVerticalIndent + 1;
                    viewDates.SetFocusedRowCellValue("IsChecked", (bool)e.Value);
                    viewDates.PostEditor();
                }
                else
                {
                    if (e.Value.ToString() == bool.TrueString)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("سقف مقاطع قابل انتخاب در این گزارش تکمیل شده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cboFilterDates.Select();
                        return;
                    }
                }

                lblMaxDate.Text = "تعداد مقاطع مجاز قابل انتخاب " + left;
            }
        }

        private void cboFilterDates_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            Image image1 = DevExpress.Images.ImageResourceCache.Default.GetImage("images/filter%20elements/checkbuttons_16x16.png");
            Image image2 = DevExpress.Images.ImageResourceCache.Default.GetImage("images/scheduling/changestatus_16x16.png");

            if (e.Button == cboFilterDates.Properties.Buttons[0])
            {
                if (bool.FalseString == cboFilterDates.Properties.Buttons[0].Tag.ToString())
                {
                    cboFilterDates.Properties.Buttons[0].Tag = true;
                    cboFilterDates.Properties.Buttons[0].ImageOptions.Image = image2;
                    for (int i = 0; i < viewDates.RowCount; i++)
                    {
                        string[] counts = this.GetSelectedDates();
                        int left = int.Parse(lblMaxDate.Tag.ToString()) - counts.Length;
                        if (left > 0)
                            viewDates.SetRowCellValue(i, "IsChecked", true);
                        lblMaxDate.Text = "تعداد مقاطع مجاز قابل انتخاب " + left;
                    }

                }
                else
                {
                    cboFilterDates.Properties.Buttons[0].Tag = false;
                    cboFilterDates.Properties.Buttons[0].ImageOptions.Image = image1;
                    for (int i = 0; i < viewDates.RowCount; i++)
                        viewDates.SetRowCellValue(i, "IsChecked", false);
                    lblMaxDate.Text = "تعداد مقاطع مجاز قابل انتخاب " + lblMaxDate.Tag;
                }

            }
        }

        private void txtReportsList_EditValueChanged(object sender, EventArgs e)
        {
            if (txtReportsList.Text.Length > 0)
                cboFilterDates.Enabled = true;
            else
                cboFilterDates.Enabled = false;
        }

        #endregion

        #region Methods
     
        public void NewReport()//حالت جدید
        {
            this.Guid = System.Guid.NewGuid().ToString();
            btnSubmitQuery.Text = "افزودن گزارش به لیست گزارشات";
        }

        public void LoadParameters(DataSet ds, string guid)//حالت ویرایش
        {
            btnNew_Click(null, EventArgs.Empty);
            btnSubmitQuery.Text = "ویرایش اطلاعات";
            this.Guid = guid;
            this.Properties.Clear();
            this.TableDates = GetDateTable();
            foreach (System.Collections.DictionaryEntry p in ds.ExtendedProperties)
                this.Properties.Add(p.Key.ToString(), p.Value);
            InitializeForm(this.Properties);
            txtReportsList.Focus();
            txtReportsList.Select();
        }

        public static DataSet Comparing(DataSet ds)
        {
            #region مقداردهی اولیه

            string reportNo = ds.ExtendedProperties["ReportNo"].ToString();
            string rankMode = ds.ExtendedProperties["RankMode"].ToString();
            string primaryColumnName = ds.ExtendedProperties["PrimaryColumnName"].ToString();
            string primaryColumnFormat = ds.ExtendedProperties["PrimaryColumnFormat"].ToString();
            string primaryColumnRule = ds.ExtendedProperties["PrimaryColumnRule"].ToString();
            string primaryPercentageRule = ds.ExtendedProperties["PrimaryPercentageRule"].ToString();
            string evaluationType1 = ds.ExtendedProperties["EvaluationType1"].ToString();
            string evaluationType2 = ds.ExtendedProperties["EvaluationType2"].ToString();
            string evaluationType3 = ds.ExtendedProperties["EvaluationType3"].ToString();
            string otherEvaluationItems = ds.ExtendedProperties["OtherEvaluationItems"].ToString();

            string primary_caption = string.Empty;
            List<string> list_PrimaryColumns = new List<string>();
            List<string> list_absoluteValueColumns = new List<string>();
            List<string> list_coveragePercentageColumns = new List<string>();
            List<string> list_percentageShareColumns = new List<string>();
            List<string> list_GrowthPercentageColumns = new List<string>();

            List<DataColumn> primaryColumns = new List<DataColumn>();
            GridViewManager gvm = new GridViewManager();

            List<string> compareItems = new List<string>();
            if (ds.ExtendedProperties.ContainsKey("CompareItems"))
                compareItems = ds.ExtendedProperties["CompareItems"].ToString().Split(',').ToList();
            if (compareItems == null)
                compareItems = new List<string>();

            List<string> evaluationItems1 = new List<string>();
            if (ds.ExtendedProperties.ContainsKey("EvaluationItems1") && ds.ExtendedProperties["EvaluationItems1"].ToString().Length > 0)
                evaluationItems1 = ds.ExtendedProperties["EvaluationItems1"].ToString().Split(',').ToList();

            List<string> evaluationItems2 = new List<string>();
            if (ds.ExtendedProperties.ContainsKey("EvaluationItems2") && ds.ExtendedProperties["EvaluationItems2"].ToString().Length > 0)
                evaluationItems2 = ds.ExtendedProperties["EvaluationItems2"].ToString().Split(',').ToList();

            List<string> evaluationItems3 = new List<string>();
            if (ds.ExtendedProperties.ContainsKey("EvaluationItems3") && ds.ExtendedProperties["EvaluationItems3"].ToString().Length > 0)
                evaluationItems3 = ds.ExtendedProperties["EvaluationItems3"].ToString().Split(',').ToList();

            List<GridBand> bands = ds.ExtendedProperties["Bands"] as List<GridBand>;
            if (ds.ExtendedProperties.ContainsKey("Bands"))
                bands = ds.ExtendedProperties["Bands"] as List<GridBand>;
            if (bands == null)
                bands = new List<GridBand>();
            bands.Add(gvm.CreateBand("Charts", "نمودارها"));

            List<ISeries.DataPoint> seriesPoints = new List<ISeries.DataPoint>();
            if (ds.ExtendedProperties.ContainsKey("SeriesPoints"))
                seriesPoints = ds.ExtendedProperties["SeriesPoints"] as List<ISeries.DataPoint>;
            if (seriesPoints == null)
                seriesPoints = new List<ISeries.DataPoint>();

            #endregion

            #region  Primary Columns افزودن
            if (ds.Tables.Contains("Branches"))
            {
                foreach (DataColumn col in ds.Tables["Branches"].Columns)
                {
                    if (IsMatchRegex(primaryColumnName, col.ColumnName.Split('.').Last()))
                        primaryColumns.Add(col);

                    if (IsMatchRegex(evaluationType1, col.ColumnName.Split('.').Last()))
                        evaluationType1 = "@PrimaryColumns";

                    if (IsMatchRegex(evaluationType2, col.ColumnName.Split('.').Last()))
                        evaluationType2 = "@PrimaryColumns";

                    if (IsMatchRegex(evaluationType3, col.ColumnName.Split('.').Last()))
                        evaluationType3 = "@PrimaryColumns";
                }
            }
            #endregion

            #region Primary Columns Rules افزودن

            foreach (DataTable tbl in ds.Tables)
            {
                if (tbl.TableName == "Province" | tbl.TableName == "Domains" | tbl.TableName == "Branches")
                {
                    foreach (DataColumn col in tbl.Columns)
                    {
                        foreach (IComboBoxEditItem item in GetPrimaryColumnsFromXml(ds.ExtendedProperties["XmlBandMap"].ToString()))
                        {
                            if (item.ColumnRuleName.Length > 0)
                            {
                                if (IsMatchRegex(item.Name, col.ColumnName.Split('.').Last()))
                                {
                                    col.ExtendedProperties.Add("FormatRule", new DictionaryEntry(item.ColumnRuleName, 0));
                                }
                            }
                            if (item.FormatNumber.Length > 0)
                            {
                                if (IsMatchRegex(item.Name, col.ColumnName.Split('.').Last()))
                                {
                                    if (!col.ExtendedProperties.ContainsKey("FormatNumber"))
                                        col.ExtendedProperties.Add("FormatNumber", item.FormatNumber);
                                }
                            }
                        }

                    }
                }
            }

            #endregion

            #region افزودن تعداد شعب

            if (compareItems.Contains("CountAllBranches"))
            {
                ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = "Domains.CountAllBranches", Caption = "تعداد شعب", DataType = typeof(int) });
                ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = "Province.CountAllBranches", Caption = "تعداد شعب", DataType = typeof(int) });

                foreach (DataRow row in ds.Tables["Domains"].Rows)
                    row["Domains.CountAllBranches"] = Branches.GetDomainBranchesCount(row["Domains.DomainId"].ToString());

                foreach (DataRow row in ds.Tables["Province"].Rows)
                    row["Province.CountAllBranches"] = Branches.GetAllBranchsCount();
            }
            #endregion

            #region SUM افزودن

            if (compareItems.Contains("Sum"))
            {
                ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = "PrimaryColumns.Sum", Caption = "جمع مقاطع", DataType = typeof(double) });
                ds.Tables["Branches"].Columns["PrimaryColumns.Sum"].ExtendedProperties.Add("FormatNumber", primaryColumnFormat);
                ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = "PrimaryColumns.Sum", Caption = "جمع مقاطع", DataType = typeof(double) });
                ds.Tables["Domains"].Columns["PrimaryColumns.Sum"].ExtendedProperties.Add("FormatNumber", primaryColumnFormat);
                ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = "PrimaryColumns.Sum", Caption = "جمع مقاطع", DataType = typeof(double) });
                ds.Tables["Province"].Columns["PrimaryColumns.Sum"].ExtendedProperties.Add("FormatNumber", primaryColumnFormat);

                foreach (DataRow row in ds.Tables["Branches"].Rows)
                {
                    List<double> list = new List<double>();
                    foreach (DataColumn col in primaryColumns)
                        list.Add(Numeral.AnyToDouble(row[col.ColumnName]));
                    row["PrimaryColumns.Sum"] = list.Sum();
                }

                foreach (DataRow row in ds.Tables["Domains"].Rows)
                {
                    List<double> list = new List<double>();
                    foreach (DataColumn col in primaryColumns)
                        list.Add(Numeral.AnyToDouble(row[col.ColumnName]));
                    row["PrimaryColumns.Sum"] = list.Sum();
                }

                foreach (DataRow row in ds.Tables["Province"].Rows)
                {
                    List<double> list = new List<double>();
                    foreach (DataColumn col in primaryColumns)
                        list.Add(Numeral.AnyToDouble(row[col.ColumnName]));
                    row["PrimaryColumns.Sum"] = list.Sum();
                }
            }
            #endregion

            #region Average افزودن

            if (compareItems.Contains("Average"))
            {
                ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = "PrimaryColumns.Average", Caption = "میانگین مقاطع", DataType = typeof(double) });
                ds.Tables["Branches"].Columns["PrimaryColumns.Average"].ExtendedProperties.Add("FormatNumber", primaryColumnFormat);
                ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = "PrimaryColumns.Average", Caption = "میانگین مقاطع", DataType = typeof(double) });
                ds.Tables["Domains"].Columns["PrimaryColumns.Average"].ExtendedProperties.Add("FormatNumber", primaryColumnFormat);
                ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = "PrimaryColumns.Average", Caption = "میانگین مقاطع", DataType = typeof(double) });
                ds.Tables["Province"].Columns["PrimaryColumns.Average"].ExtendedProperties.Add("FormatNumber", primaryColumnFormat);

                foreach (DataRow row in ds.Tables["Branches"].Rows)
                {
                    List<double> list = new List<double>();
                    foreach (DataColumn col in primaryColumns)
                        list.Add(Numeral.AnyToDouble(row[col.ColumnName]));
                    row["PrimaryColumns.Average"] = list.Average();
                }

                foreach (DataRow row in ds.Tables["Domains"].Rows)
                {
                    List<double> list = new List<double>();
                    foreach (DataColumn col in primaryColumns)
                        list.Add(Numeral.AnyToDouble(row[col.ColumnName]));
                    row["PrimaryColumns.Average"] = list.Average();
                }

                foreach (DataRow row in ds.Tables["Province"].Rows)
                {
                    List<double> list = new List<double>();
                    foreach (DataColumn col in primaryColumns)
                        list.Add(Numeral.AnyToDouble(row[col.ColumnName]));
                    row["PrimaryColumns.Average"] = list.Average();
                }
            }
            #endregion

            #region مقایسه مقاطع

            if (ds.ExtendedProperties.ContainsKey("CompareOrder"))
            {
                var CompareColumns = GetComparisonList(ds.Tables["Branches"], ds.ExtendedProperties["CompareOrder"].ToString(), primaryColumns);
                int number = 0;
                foreach (DateCompare com in CompareColumns)
                {
                    string reportDate = com.Column2.Namespace.Replace("/", "");

                    ++number;
                    string ns_GrowthPercentage = string.Empty;
                    string ns_AbsoluteValue = string.Empty;
                    string ns_CoveragePercentage = string.Empty;
                    string ns_RankInProvince = string.Empty;
                    string ns_RankInDomain = string.Empty;
                    string ns_RankInEqualBranches = string.Empty;
                    string ns_CountPositiveBranches = string.Empty;
                    string ns_CountNegativeBranches = string.Empty;
                    string ns_CountLessAvgBranches = string.Empty;
                    string ns_CountGreaterAvgBranches = string.Empty;

                    bands.Add(gvm.CreateBand("Compares" + number, com.Text, 190));

                    ns_GrowthPercentage = string.Format("Compares{0}.GrowthPercentage{0}", number);
                    ns_AbsoluteValue = string.Format("Compares{0}.AbsoluteValue{0}", number);
                    ns_CoveragePercentage = string.Format("Compares{0}.CoveragePercentage{0}", number);
                    ns_RankInProvince = string.Format("Compares{0}.RankInProvince{0}", number);
                    ns_RankInDomain = string.Format("Compares{0}.RankInDomain{0}", number);
                    ns_RankInEqualBranches = string.Format("Compares{0}.RankInEqualBranches{0}", number);
                    ns_CountPositiveBranches = string.Format("Compares{0}.CountPositiveBranches{0}", number);
                    ns_CountNegativeBranches = string.Format("Compares{0}.CountNegativeBranches{0}", number);
                    ns_CountLessAvgBranches = string.Format("Compares{0}.CountLessAvgBranches{0}", number);
                    ns_CountGreaterAvgBranches = string.Format("Compares{0}.CountGreaterAvgBranches{0}", number);

                    #region ستونهای نموداری

                    string ns_evalColumnName = string.Empty;
                    if (evaluationType1 == "GrowthPercentage" | evaluationType2 == "GrowthPercentage" | evaluationType3 == "GrowthPercentage")
                    {
                        ns_evalColumnName = ns_GrowthPercentage;
                        if (evaluationItems1.Contains("Sparkline") | evaluationItems2.Contains("Sparkline") | evaluationItems3.Contains("Sparkline"))
                        {
                            if (!list_GrowthPercentageColumns.Contains(ns_GrowthPercentage))
                                list_GrowthPercentageColumns.Add(ns_GrowthPercentage);
                        }
                    }
                    if (evaluationType1 == "AbsoluteValue" | evaluationType2 == "AbsoluteValue" | evaluationType3 == "AbsoluteValue")
                    {
                        ns_evalColumnName = ns_AbsoluteValue;
                        if (evaluationItems1.Contains("Sparkline") | evaluationItems2.Contains("Sparkline") | evaluationItems3.Contains("Sparkline"))
                        {
                            if (!list_absoluteValueColumns.Contains(ns_AbsoluteValue))
                                list_absoluteValueColumns.Add(ns_AbsoluteValue);
                        }
                    }
                    if (evaluationType1 == "CoveragePercentage" | evaluationType2 == "CoveragePercentage" | evaluationType3 == "CoveragePercentage")
                    {
                        ns_evalColumnName = ns_CoveragePercentage;
                        if (!list_coveragePercentageColumns.Contains(ns_CoveragePercentage))
                            list_coveragePercentageColumns.Add(ns_CoveragePercentage);
                    } 
                    #endregion
                  
                    #region میزان تغییرات
                    if (compareItems.Contains("AbsoluteValue"))
                    {
                        if (ds.Tables.Contains("Branches"))
                        {
                            ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_AbsoluteValue, Caption = "میزان تغییرات", DataType = typeof(double) });
                            ds.Tables["Branches"].Columns[ns_AbsoluteValue].ExtendedProperties.Add("FormatNumber", primaryColumnFormat);
                            foreach (DataRow row in ds.Tables["Branches"].Rows)
                            {
                                row[ns_AbsoluteValue] = Numeral.AnyToDouble(row[com.Column2.ColumnName]) - Numeral.AnyToDouble(row[com.Column1.ColumnName]);
                                seriesPoints.Add(new ISeries.DataPoint(row["Branches.BranchId"].ToString(), reportDate, "قدر مطلق", Numeral.AnyToDouble(row[ns_AbsoluteValue])));
                            }
                        }

                        if (ds.Tables.Contains("Domains"))
                        {
                            ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_AbsoluteValue, Caption = "میزان تغییرات", DataType = typeof(double) });
                            ds.Tables["Domains"].Columns[ns_AbsoluteValue].ExtendedProperties.Add("FormatNumber", primaryColumnFormat);
                            foreach (DataRow row in ds.Tables["Domains"].Rows)
                            {
                                row[ns_AbsoluteValue] = Numeral.AnyToDouble(row[com.Column2.ColumnName]) - Numeral.AnyToDouble(row[com.Column1.ColumnName]);
                                seriesPoints.Add(new ISeries.DataPoint(row["Domains.DomainId"].ToString(), reportDate, "قدر مطلق", Numeral.AnyToDouble(row[ns_AbsoluteValue])));
                            }
                        }

                        if (ds.Tables.Contains("Province"))
                        {
                            ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_AbsoluteValue, Caption = "میزان تغییرات", DataType = typeof(double) });
                            ds.Tables["Province"].Columns[ns_AbsoluteValue].ExtendedProperties.Add("FormatNumber", primaryColumnFormat);
                            foreach (DataRow row in ds.Tables["Province"].Rows)
                            {
                                row[ns_AbsoluteValue] = Numeral.AnyToDouble(row[com.Column2.ColumnName]) - Numeral.AnyToDouble(row[com.Column1.ColumnName]);
                                seriesPoints.Add(new ISeries.DataPoint(row["Province.ProvinceId"].ToString(), reportDate, "قدر مطلق", Numeral.AnyToDouble(row[ns_AbsoluteValue])));
                            }
                        }
                    }
                    #endregion

                    #region درصد رشد

                    if (compareItems.Contains("GrowthPercentage"))
                    {
                        if (ds.Tables.Contains("Branches"))
                        {
                            ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_GrowthPercentage, Caption = "درصد رشد", DataType = typeof(double) });
                            ds.Tables["Branches"].Columns[ns_GrowthPercentage].ExtendedProperties.Add("FormatNumber", "N1");
                            ds.Tables["Branches"].Columns[ns_GrowthPercentage].ExtendedProperties.Add("FormatRule", new DictionaryEntry(primaryPercentageRule, 0));

                            foreach (DataRow row in ds.Tables["Branches"].Rows)
                            {
                                if (Numeral.AnyToDouble(row[com.Column1.ColumnName]) != 0)
                                    row[ns_GrowthPercentage] = Numeral.ZeroForOverflowValue(((Numeral.AnyToDouble(row[com.Column2.ColumnName]) - Numeral.AnyToDouble(row[com.Column1.ColumnName])) / Numeral.AnyToDouble(row[com.Column1.ColumnName])) * 100);
                                else
                                {
                                    if (Numeral.AnyToDouble(row[com.Column2.ColumnName]) > 0)
                                        row[ns_GrowthPercentage] = 100;
                                    if (Numeral.AnyToDouble(row[com.Column2.ColumnName]) < 0)
                                        row[ns_GrowthPercentage] = -100;
                                    if (Numeral.AnyToDouble(row[com.Column2.ColumnName]) == 0)
                                        row[ns_GrowthPercentage] = 0;
                                }

                                seriesPoints.Add(new ISeries.DataPoint(row["Branches.BranchId"].ToString(), reportDate, "درصد رشد", Numeral.AnyToDouble(row[ns_GrowthPercentage])));
                            }

                            list_GrowthPercentageColumns.Add(ns_GrowthPercentage);
                        }

                        if (ds.Tables.Contains("Domains"))
                        {
                            ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_GrowthPercentage, Caption = "درصد رشد", DataType = typeof(double) });
                            ds.Tables["Domains"].Columns[ns_GrowthPercentage].ExtendedProperties.Add("FormatNumber", "N1");
                            ds.Tables["Domains"].Columns[ns_GrowthPercentage].ExtendedProperties.Add("FormatRule", new DictionaryEntry(primaryPercentageRule, 0));

                            foreach (DataRow row in ds.Tables["Domains"].Rows)
                            {
                                if (Numeral.AnyToDouble(row[com.Column1.ColumnName]) != 0)
                                    row[ns_GrowthPercentage] = Numeral.ZeroForOverflowValue(((Numeral.AnyToDouble(row[com.Column2.ColumnName]) - Numeral.AnyToDouble(row[com.Column1.ColumnName])) / Numeral.AnyToDouble(row[com.Column1.ColumnName])) * 100);
                                else
                                {
                                    if (Numeral.AnyToDouble(row[com.Column2.ColumnName]) > 0)
                                        row[ns_GrowthPercentage] = 100;
                                    if (Numeral.AnyToDouble(row[com.Column2.ColumnName]) < 0)
                                        row[ns_GrowthPercentage] = -100;
                                    if (Numeral.AnyToDouble(row[com.Column2.ColumnName]) == 0)
                                        row[ns_GrowthPercentage] = 0;
                                }
                                seriesPoints.Add(new ISeries.DataPoint(row["Domains.DomainId"].ToString(), reportDate, "درصد رشد", Numeral.AnyToDouble(row[ns_GrowthPercentage])));
                            }
                        }

                        if (ds.Tables.Contains("Province"))
                        {
                            ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_GrowthPercentage, Caption = "درصد رشد", DataType = typeof(double) });
                            ds.Tables["Province"].Columns[ns_GrowthPercentage].ExtendedProperties.Add("FormatNumber", "N1");
                            ds.Tables["Province"].Columns[ns_GrowthPercentage].ExtendedProperties.Add("FormatRule", new DictionaryEntry(primaryPercentageRule, 0));//افزودن میانگین استان

                            foreach (DataRow row in ds.Tables["Province"].Rows)
                            {
                                if (Numeral.AnyToDouble(row[com.Column1.ColumnName]) != 0)
                                    row[ns_GrowthPercentage] = Numeral.ZeroForOverflowValue(((Numeral.AnyToDouble(row[com.Column2.ColumnName]) - Numeral.AnyToDouble(row[com.Column1.ColumnName])) / Numeral.AnyToDouble(row[com.Column1.ColumnName])) * 100);
                                else
                                {
                                    if (Numeral.AnyToDouble(row[com.Column2.ColumnName]) > 0)
                                        row[ns_GrowthPercentage] = 100;
                                    if (Numeral.AnyToDouble(row[com.Column2.ColumnName]) < 0)
                                        row[ns_GrowthPercentage] = -100;
                                    if (Numeral.AnyToDouble(row[com.Column2.ColumnName]) == 0)
                                        row[ns_GrowthPercentage] = 0;
                                }

                                seriesPoints.Add(new ISeries.DataPoint(row["Province.ProvinceId"].ToString(), reportDate, "درصد رشد", Numeral.AnyToDouble(row[ns_GrowthPercentage])));
                            }

                            if (ds.Tables["Province"].Rows.Count == 1)
                            {
                                DataRow pr = ds.Tables["Province"].Rows[0];
                                if (ds.Tables.Contains("Branches"))
                                {
                                    DictionaryEntry di = new DictionaryEntry(primaryPercentageRule, pr[ns_GrowthPercentage]);
                                    ds.Tables["Branches"].Columns[ns_GrowthPercentage].ExtendedProperties["FormatRule"] = di;//افزودن میانگین استان
                                }
                                if (ds.Tables.Contains("Domains"))
                                {
                                    DictionaryEntry di = new DictionaryEntry(primaryPercentageRule, pr[ns_GrowthPercentage]);
                                    ds.Tables["Domains"].Columns[ns_GrowthPercentage].ExtendedProperties["FormatRule"] = di;//افزودن میانگین استان
                                }
                            }
                        }
                    }
                    #endregion

                    #region درصد پوشش
                    if (compareItems.Contains("CoveragePercentage"))
                    {
                        if (ds.Tables.Contains("Branches"))
                        {
                            ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_CoveragePercentage, Caption = "درصد پوشش", DataType = typeof(double) });
                            ds.Tables["Branches"].Columns[ns_CoveragePercentage].ExtendedProperties.Add("FormatNumber", "N1");
                            foreach (DataRow row in ds.Tables["Branches"].Rows)
                            {
                                row[ns_CoveragePercentage] = Numeral.ZeroForOverflowValue((Numeral.AnyToDouble(row[com.Column2.ColumnName]) / Numeral.AnyToDouble(row[com.Column1.ColumnName])) * 100);
                                seriesPoints.Add(new ISeries.DataPoint(row["Branches.BranchId"].ToString(), reportDate, "درصد پوشش", Numeral.AnyToDouble(row[ns_CoveragePercentage])));
                            }
                        }

                        if (ds.Tables.Contains("Domains"))
                        {
                            ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_CoveragePercentage, Caption = "درصد پوشش", DataType = typeof(double) });
                            ds.Tables["Domains"].Columns[ns_CoveragePercentage].ExtendedProperties.Add("FormatNumber", "N1");
                            foreach (DataRow row in ds.Tables["Domains"].Rows)
                            {
                                row[ns_CoveragePercentage] = Numeral.ZeroForOverflowValue((Numeral.AnyToDouble(row[com.Column2.ColumnName]) / Numeral.AnyToDouble(row[com.Column1.ColumnName])) * 100);
                                seriesPoints.Add(new ISeries.DataPoint(row["Domains.DomainId"].ToString(), reportDate, "درصد پوشش", Numeral.AnyToDouble(row[ns_CoveragePercentage])));
                            }
                        }

                        if (ds.Tables.Contains("Province"))
                        {
                            ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_CoveragePercentage, Caption = "درصد پوشش", DataType = typeof(double) });
                            ds.Tables["Province"].Columns[ns_CoveragePercentage].ExtendedProperties.Add("FormatNumber", "N1");
                            foreach (DataRow row in ds.Tables["Province"].Rows)
                            {
                                row[ns_CoveragePercentage] = Numeral.ZeroForOverflowValue((Numeral.AnyToDouble(row[com.Column2.ColumnName]) / Numeral.AnyToDouble(row[com.Column1.ColumnName])) * 100);
                                seriesPoints.Add(new ISeries.DataPoint(row["Province.ProvinceId"].ToString(), reportDate, "درصد پوشش", Numeral.AnyToDouble(row[ns_CoveragePercentage])));
                            }
                        }
                    }
                    #endregion

                    if (ns_evalColumnName.Length > 0)
                    {
                        #region رتبه در استان
                        if (evaluationItems1.Contains("RankInProvince") | evaluationItems2.Contains("RankInProvince") | evaluationItems3.Contains("RankInProvince"))
                        {
                            ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_RankInProvince, Caption = "رتبه در استان", DataType = typeof(int) });
                            ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_RankInProvince, Caption = "رتبه در استان", DataType = typeof(int) });

                            ds.Tables["Branches"].DefaultView.Sort = ns_evalColumnName + " " + rankMode;
                            int rank = 1;
                            foreach (DataRowView r in ds.Tables["Branches"].DefaultView)
                            {
                                string branchId = r["Branches.BranchId"].ToString();
                                if (Branches.IsBranch(branchId))
                                {
                                    string type = Branches.GetBranchById(r["Branches.BranchId"].ToString(), false).BranchType;
                                    if (type == "شعبه" | type == "شعبه مستقل")
                                        r[ns_RankInProvince] = rank++;
                                }
                            }

                            ds.Tables["Branches"].DefaultView.RowFilter = "";

                            ds.Tables["Domains"].DefaultView.Sort = ns_evalColumnName + " " + rankMode;
                            rank = 1;
                            foreach (DataRowView r in ds.Tables["Domains"].DefaultView)
                                r[ns_RankInProvince] = rank++;
                            ds.Tables["Domains"].DefaultView.RowFilter = "";
                        }
                        #endregion

                        #region رتبه در حوزه
                        if (evaluationItems1.Contains("RankInDomain") | evaluationItems2.Contains("RankInDomain") | evaluationItems3.Contains("RankInDomain"))
                        {
                            ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_RankInDomain, Caption = "رتبه در حوزه", DataType = typeof(int) });

                            foreach (DataRow row in ds.Tables["Domains"].Rows)
                            {
                                int rank = 1;
                                ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = {1}", "Domains.DomainId", row["Domains.DomainId"].ToString());
                                ds.Tables["Branches"].DefaultView.Sort = ns_evalColumnName + " " + rankMode;
                                foreach (DataRowView r in ds.Tables["Branches"].DefaultView)
                                {
                                    string branchId = r["Branches.BranchId"].ToString();
                                    if (Branches.IsBranch(branchId))
                                    {
                                        string type = Branches.GetBranchById(r["Branches.BranchId"].ToString(), false).BranchType;
                                        if (type == "شعبه" | type == "شعبه مستقل")
                                            r[ns_RankInDomain] = rank++;
                                    }
                                }

                            }
                            ds.Tables["Branches"].DefaultView.RowFilter = "";
                        }
                        #endregion

                        #region رتبه در هم درجه
                        if (evaluationItems1.Contains("RankInEqualBranches") | evaluationItems2.Contains("RankInEqualBranches") | evaluationItems3.Contains("RankInEqualBranches"))
                        {
                            ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_RankInEqualBranches, Caption = "رتبه در هم درجه", DataType = typeof(int) });

                            foreach (string degree in Branches.GetAllBranchDegree())
                            {
                                int rank = 1;
                                ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = '{1}'", "Branches.BranchDegree", degree);
                                ds.Tables["Branches"].DefaultView.Sort = ns_evalColumnName + " " + rankMode;
                                foreach (DataRowView r in ds.Tables["Branches"].DefaultView)
                                {
                                    string branchId = r["Branches.BranchId"].ToString();
                                    if (Branches.IsBranch(branchId))
                                    {
                                        string type = Branches.GetBranchById(r["Branches.BranchId"].ToString(), false).BranchType;
                                        if (type == "شعبه" | type == "شعبه مستقل")
                                            r[ns_RankInEqualBranches] = rank++;
                                    }
                                }
                            }
                            ds.Tables["Branches"].DefaultView.RowFilter = "";
                        }
                        #endregion  

                        #region تعداد شعب مثبت
                        if (evaluationItems1.Contains("CountPositiveBranches") | evaluationItems2.Contains("CountPositiveBranches") | evaluationItems3.Contains("CountPositiveBranches"))
                        {
                            ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_CountPositiveBranches, Caption = "تعداد شعب مثبت", DataType = typeof(int) });
                            ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_CountPositiveBranches, Caption = "تعداد شعب مثبت", DataType = typeof(int) });
                            ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_CountPositiveBranches, Caption = "تعداد شعب مثبت", DataType = typeof(int) });

                            foreach (DataRow row in ds.Tables["Branches"].Rows)
                            {
                                string type = Branches.GetBranchById(row["Branches.BranchId"].ToString(), false).BranchType;
                                if (type == "شعبه" | type == "شعبه مستقل")
                                {
                                    if (Numeral.AnyToDouble(row[ns_evalColumnName]) > 0)
                                        row[ns_CountPositiveBranches] = 1;
                                }
                            }

                            foreach (DataRow row in ds.Tables["Domains"].Rows)
                            {
                                ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = {1} AND {2} = 1", "Domains.DomainId", row["Domains.DomainId"].ToString(), ns_CountPositiveBranches);
                                row[ns_CountPositiveBranches] = ds.Tables["Branches"].DefaultView.Count;
                            }
                            ds.Tables["Branches"].DefaultView.RowFilter = "";

                            foreach (DataRow row in ds.Tables["Province"].Rows)
                            {
                                ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = 1", ns_CountPositiveBranches);
                                row[ns_CountPositiveBranches] = ds.Tables["Branches"].DefaultView.Count;
                            }
                            ds.Tables["Branches"].DefaultView.RowFilter = "";
                        }
                        #endregion

                        #region تعداد شعب منفی
                        if (evaluationItems1.Contains("CountNegativeBranches") | evaluationItems2.Contains("CountNegativeBranches") | evaluationItems3.Contains("CountNegativeBranches"))
                        {
                            ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_CountNegativeBranches, Caption = "تعداد شعب منفی", DataType = typeof(int) });
                            ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_CountNegativeBranches, Caption = "تعداد شعب منفی", DataType = typeof(int) });
                            ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_CountNegativeBranches, Caption = "تعداد شعب منفی", DataType = typeof(int) });

                            foreach (DataRow row in ds.Tables["Branches"].Rows)
                            {
                                string type = Branches.GetBranchById(row["Branches.BranchId"].ToString(), false).BranchType;
                                if (type == "شعبه" | type == "شعبه مستقل")
                                {
                                    if (Numeral.AnyToDouble(row[ns_evalColumnName]) <= 0)
                                        row[ns_CountNegativeBranches] = 1;
                                }
                            }

                            foreach (DataRow row in ds.Tables["Domains"].Rows)
                            {
                                ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = {1} AND {2} = 1", "Domains.DomainId", row["Domains.DomainId"].ToString(), ns_CountNegativeBranches);
                                row[ns_CountNegativeBranches] = ds.Tables["Branches"].DefaultView.Count;
                            }
                            ds.Tables["Branches"].DefaultView.RowFilter = "";

                            foreach (DataRow row in ds.Tables["Province"].Rows)
                            {
                                ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = 1", ns_CountNegativeBranches);
                                row[ns_CountNegativeBranches] = ds.Tables["Branches"].DefaultView.Count;
                            }
                            ds.Tables["Branches"].DefaultView.RowFilter = "";
                        }
                        #endregion

                        #region تعداد شعب کمتر از استان
                        if (evaluationItems1.Contains("CountLessAvgBranches") | evaluationItems2.Contains("CountLessAvgBranches") | evaluationItems3.Contains("CountLessAvgBranches"))
                        {
                            ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_CountLessAvgBranches, Caption = "کمتر از استان", DataType = typeof(int) });
                            ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_CountLessAvgBranches, Caption = "تعداد شعب کمتر از استان", DataType = typeof(int) });
                            ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_CountLessAvgBranches, Caption = "تعداد شعب کمتر از استان", DataType = typeof(int) });

                            double prAvg = double.Parse(ds.Tables["Province"].Rows[0][ns_evalColumnName].ToString());//رشد استان

                            foreach (DataRow row in ds.Tables["Branches"].Rows)
                            {
                                string type = Branches.GetBranchById(row["Branches.BranchId"].ToString(), false).BranchType;
                                if (type == "شعبه" | type == "شعبه مستقل")
                                {
                                    if (Numeral.AnyToDouble(row[ns_evalColumnName]) <= prAvg)
                                        row[ns_CountLessAvgBranches] = 1;
                                }
                            }

                            foreach (DataRow row in ds.Tables["Domains"].Rows)
                            {
                                ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = {1} AND {2} = 1", "Domains.DomainId", row["Domains.DomainId"].ToString(), ns_CountLessAvgBranches);
                                row[ns_CountLessAvgBranches] = ds.Tables["Branches"].DefaultView.Count;
                            }
                            ds.Tables["Branches"].DefaultView.RowFilter = "";

                            foreach (DataRow row in ds.Tables["Province"].Rows)
                            {
                                ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = 1", ns_CountLessAvgBranches);
                                row[ns_CountLessAvgBranches] = ds.Tables["Branches"].DefaultView.Count;
                            }
                            ds.Tables["Branches"].DefaultView.RowFilter = "";
                        }
                        #endregion

                        #region تعداد شعب بالاتر از استان
                        if (evaluationItems1.Contains("CountGreaterAvgBranches") | evaluationItems2.Contains("CountGreaterAvgBranches") | evaluationItems3.Contains("CountGreaterAvgBranches"))
                        {
                            ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_CountGreaterAvgBranches, Caption = "بیشتر از استان", DataType = typeof(int) });
                            ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_CountGreaterAvgBranches, Caption = "تعداد شعب بیشتر از استان", DataType = typeof(int) });
                            ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_CountGreaterAvgBranches, Caption = "تعداد شعب بیشتر از استان", DataType = typeof(int) });

                            double prAvg = double.Parse(ds.Tables["Province"].Rows[0][ns_evalColumnName].ToString());//رشد استان

                            foreach (DataRow row in ds.Tables["Branches"].Rows)
                            {
                                string type = Branches.GetBranchById(row["Branches.BranchId"].ToString(), false).BranchType;
                                if (type == "شعبه" | type == "شعبه مستقل")
                                {
                                    if (Numeral.AnyToDouble(row[ns_evalColumnName]) > prAvg)
                                        row[ns_CountGreaterAvgBranches] = 1;
                                }
                            }

                            foreach (DataRow row in ds.Tables["Domains"].Rows)
                            {
                                ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = {1} AND {2} = 1", "Domains.DomainId", row["Domains.DomainId"].ToString(), ns_CountGreaterAvgBranches);
                                row[ns_CountGreaterAvgBranches] = ds.Tables["Branches"].DefaultView.Count;
                            }
                            ds.Tables["Branches"].DefaultView.RowFilter = "";

                            foreach (DataRow row in ds.Tables["Province"].Rows)
                            {
                                ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = 1", ns_CountGreaterAvgBranches);
                                row[ns_CountGreaterAvgBranches] = ds.Tables["Branches"].DefaultView.Count;
                            }
                            ds.Tables["Branches"].DefaultView.RowFilter = "";
                        }
                        #endregion
                    }
                }
            }
            #endregion

            #region ارزیابی یک

            if (evaluationItems1.Count > 0)
            {
                int number = 0;
                List<DataColumn> ns_evalColumnNames = new List<DataColumn>();
                if (evaluationType1 == "Average")
                    ns_evalColumnNames.Add(ds.Tables["Branches"].Columns["PrimaryColumns.Average"]);
                if (evaluationType1 == "Sum")
                    ns_evalColumnNames.Add(ds.Tables["Branches"].Columns["PrimaryColumns.Sum"]);
                if (evaluationType1 == "@PrimaryColumns")
                {
                    ns_evalColumnNames = primaryColumns;
                    list_PrimaryColumns = primaryColumns.Select(x => x.ColumnName).ToList();
                    primary_caption = ds.ExtendedProperties[ds.ExtendedProperties["EvaluationType1"].ToString()].ToString();
                }

                foreach (DataColumn col in ns_evalColumnNames)
                {
                    ++number;
                    string ns_RankInProvince = string.Empty;
                    string ns_RankInDomain = string.Empty;
                    string ns_RankInEqualBranches = string.Empty;
                    string ns_PercentageShare = string.Empty;
                    string ns_CountPositiveBranches = string.Empty;
                    string ns_CountNegativeBranches = string.Empty;
                    string ns_CountLessAvgBranches = string.Empty;
                    string ns_CountGreaterAvgBranches = string.Empty;

                    bands.Add(gvm.CreateBand("Evaluation" + number, col.Namespace, 80));

                    ns_RankInProvince = string.Format("Evaluation{0}.RankInProvince{0}", number);
                    ns_RankInDomain = string.Format("Evaluation{0}.RankInDomain{0}", number);
                    ns_RankInEqualBranches = string.Format("Evaluation{0}.RankInEqualBranches{0}", number);
                    ns_PercentageShare = string.Format("Evaluation{0}.PercentageShare{0}", number);
                    ns_CountPositiveBranches = string.Format("Evaluation{0}.CountPositiveBranches{0}", number);
                    ns_CountNegativeBranches = string.Format("Evaluation{0}.CountNegativeBranches{0}", number);
                    ns_CountLessAvgBranches = string.Format("Evaluation{0}.CountLessAvgBranches{0}", number);
                    ns_CountGreaterAvgBranches = string.Format("Evaluation{0}.CountGreaterAvgBranches{0}", number);

                    #region رتبه در استان
                    if (evaluationItems1.Contains("RankInProvince"))
                    {
                        ///////////////////////////////////
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_RankInProvince, Caption = "رتبه در استان", DataType = typeof(int) });
                        ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_RankInProvince, Caption = "رتبه در استان", DataType = typeof(int) });
                        ///////////////////////////////////
                        ds.Tables["Branches"].DefaultView.Sort = col.ColumnName + " " + rankMode;
                        int rank = 1;
                        foreach (DataRowView r in ds.Tables["Branches"].DefaultView)
                        {
                            string branchId = r["Branches.BranchId"].ToString();
                            if (Branches.IsBranch(branchId))
                            {
                                string type = Branches.GetBranchById(r["Branches.BranchId"].ToString(), false).BranchType;
                                if (type == "شعبه" | type == "شعبه مستقل")
                                    r[ns_RankInProvince] = rank++;
                            }
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";
                        ///////////////////////////////////
                        ds.Tables["Domains"].DefaultView.Sort = col.ColumnName + " " + rankMode;
                        rank = 1;
                        foreach (DataRowView r in ds.Tables["Domains"].DefaultView)
                            r[ns_RankInProvince] = rank++;
                        ds.Tables["Domains"].DefaultView.RowFilter = "";
                        ///////////////////////////////////
                    }
                    #endregion

                    #region رتبه در حوزه
                    if (evaluationItems1.Contains("RankInDomain"))
                    {
                        ///////////////////////////////////
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_RankInDomain, Caption = "رتبه در حوزه", DataType = typeof(int) });
                        ///////////////////////////////////
                        foreach (DataRow row in ds.Tables["Domains"].Rows)
                        {
                            int rank = 1;
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = {1}", "Domains.DomainId", row["Domains.DomainId"].ToString());
                            ds.Tables["Branches"].DefaultView.Sort = col.ColumnName + " " + rankMode;
                            foreach (DataRowView r in ds.Tables["Branches"].DefaultView)
                            {
                                string branchId = r["Branches.BranchId"].ToString();
                                if (Branches.IsBranch(branchId))
                                {
                                    string type = Branches.GetBranchById(r["Branches.BranchId"].ToString(), false).BranchType;
                                    if (type == "شعبه" | type == "شعبه مستقل")
                                        r[ns_RankInDomain] = rank++;
                                }
                            }
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";
                    }
                    #endregion

                    #region رتبه بین هم درجه
                    if (evaluationItems1.Contains("RankInEqualBranches"))
                    {
                        ///////////////////////////////////
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_RankInEqualBranches, Caption = "رتبه بین هم درجه", DataType = typeof(int) });
                        ///////////////////////////////////
                        foreach (string degree in Branches.GetAllBranchDegree())
                        {
                            int rank = 1;
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = '{1}'", "Branches.BranchDegree", degree);
                            ds.Tables["Branches"].DefaultView.Sort = col.ColumnName + " " + rankMode;
                            foreach (DataRowView r in ds.Tables["Branches"].DefaultView)
                            {
                                string branchId = r["Branches.BranchId"].ToString();
                                if (Branches.IsBranch(branchId))
                                {
                                    string type = Branches.GetBranchById(r["Branches.BranchId"].ToString(), false).BranchType;
                                    if (type == "شعبه" | type == "شعبه مستقل")
                                        r[ns_RankInEqualBranches] = rank++;
                                }
                            }
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";     
                        ///////////////////////////////////
                    }
                    #endregion

                    #region سهم درصد
                    if (evaluationItems1.Contains("PercentageShare"))
                    {
                        ///////////////////////////////////
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_PercentageShare, Caption = "سهم درصد", DataType = typeof(double) });
                        ds.Tables["Branches"].Columns[ns_PercentageShare].ExtendedProperties.Add("FormatNumber", "N1");
                        ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_PercentageShare, Caption = "سهم درصد", DataType = typeof(double) });
                        ds.Tables["Domains"].Columns[ns_PercentageShare].ExtendedProperties.Add("FormatNumber", "N1");
                        ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_PercentageShare, Caption = "سهم درصد", DataType = typeof(double) });
                        ds.Tables["Province"].Columns[ns_PercentageShare].ExtendedProperties.Add("FormatNumber", "N1");
                        ///////////////////////////////////
                        double prValue = double.Parse(ds.Tables["Province"].Rows[0][col.ColumnName].ToString());//مانده استان
                        ///////////////////////////////////
                        foreach (DataRow row in ds.Tables["Branches"].Rows)
                            row[ns_PercentageShare] = (Numeral.AnyToDouble(row[col.ColumnName]) / prValue) * 100;
                        ///////////////////////////////////
                        foreach (DataRow row in ds.Tables["Domains"].Rows)
                            row[ns_PercentageShare] = (Numeral.AnyToDouble(row[col.ColumnName]) / prValue) * 100;
                        ///////////////////////////////////
                        foreach (DataRow row in ds.Tables["Province"].Rows)
                            row[ns_PercentageShare] = 100;
                        ///////////////////////////////////
                        if (!list_percentageShareColumns.Contains(ns_PercentageShare))
                            list_percentageShareColumns.Add(ns_PercentageShare);
                        ///////////////////////////////////

                    }
                    #endregion

                    #region تعداد شعب مثبت
                    if (evaluationItems1.Contains("CountPositiveBranches"))
                    {                       
                        ///////////////////////////////////
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_CountPositiveBranches, Caption = "تعداد شعب مثبت", DataType = typeof(int) });
                        ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_CountPositiveBranches, Caption = "تعداد شعب مثبت", DataType = typeof(int) });
                        ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_CountPositiveBranches, Caption = "تعداد شعب مثبت", DataType = typeof(int) });
                        ///////////////////////////////////
                        foreach (DataRow row in ds.Tables["Branches"].Rows)
                        {
                            string type = Branches.GetBranchById(row["Branches.BranchId"].ToString(), false).BranchType;
                            if (type == "شعبه" | type == "شعبه مستقل")
                            {
                                if (Numeral.AnyToDouble(row[col.ColumnName]) > 0)
                                    row[ns_CountPositiveBranches] = 1;
                            }
                        }
                        ///////////////////////////////////
                        foreach (DataRow row in ds.Tables["Domains"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = {1} AND {2} = 1", "Domains.DomainId", row["Domains.DomainId"].ToString(), ns_CountPositiveBranches);
                            row[ns_CountPositiveBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";
                        ///////////////////////////////////
                        foreach (DataRow row in ds.Tables["Province"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = 1", ns_CountPositiveBranches);
                            row[ns_CountPositiveBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";
                        ///////////////////////////////////
                    }
                    #endregion

                    #region تعداد شعب منفی
                    if (evaluationItems1.Contains("CountNegativeBranches"))
                    {
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_CountNegativeBranches, Caption = "تعداد شعب منفی", DataType = typeof(int) });
                        ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_CountNegativeBranches, Caption = "تعداد شعب منفی", DataType = typeof(int) });
                        ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_CountNegativeBranches, Caption = "تعداد شعب منفی", DataType = typeof(int) });

                        foreach (DataRow row in ds.Tables["Branches"].Rows)
                        {
                            string type = Branches.GetBranchById(row["Branches.BranchId"].ToString(), false).BranchType;
                            if (type == "شعبه" | type == "شعبه مستقل")
                            {
                                if (Numeral.AnyToDouble(row[col.ColumnName]) <= 0)
                                    row[ns_CountNegativeBranches] = 1;
                            }
                        }

                        foreach (DataRow row in ds.Tables["Domains"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = {1} AND {2} = 1", "Domains.DomainId", row["Domains.DomainId"].ToString(), ns_CountNegativeBranches);
                            row[ns_CountNegativeBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";

                        foreach (DataRow row in ds.Tables["Province"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = 1", ns_CountNegativeBranches);
                            row[ns_CountNegativeBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";
                    }
                    #endregion

                    #region تعداد شعب کمتر از استان
                    if (evaluationItems1.Contains("CountLessAvgBranches"))
                    {
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_CountLessAvgBranches, Caption = "کمتر از استان", DataType = typeof(int) });
                        ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_CountLessAvgBranches, Caption = "تعداد شعب کمتر از استان", DataType = typeof(int) });
                        ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_CountLessAvgBranches, Caption = "تعداد شعب کمتر از استان", DataType = typeof(int) });

                        double prAvg = double.Parse(ds.Tables["Province"].Rows[0][col.ColumnName].ToString());//رشد استان

                        foreach (DataRow row in ds.Tables["Branches"].Rows)
                        {
                            string type = Branches.GetBranchById(row["Branches.BranchId"].ToString(), false).BranchType;
                            if (type == "شعبه" | type == "شعبه مستقل")
                            {
                                if (Numeral.AnyToDouble(row[col.ColumnName]) <= prAvg)
                                    row[ns_CountLessAvgBranches] = 1;
                            }
                        }

                        foreach (DataRow row in ds.Tables["Domains"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = {1} AND {2} = 1", "Domains.DomainId", row["Domains.DomainId"].ToString(), ns_CountLessAvgBranches);
                            row[ns_CountLessAvgBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";

                        foreach (DataRow row in ds.Tables["Province"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = 1", ns_CountLessAvgBranches);
                            row[ns_CountLessAvgBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";
                    }
                    #endregion

                    #region تعداد شعب بالاتر از استان
                    if (evaluationItems1.Contains("CountGreaterAvgBranches"))
                    {
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_CountGreaterAvgBranches, Caption = "بیشتر از استان", DataType = typeof(int) });
                        ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_CountGreaterAvgBranches, Caption = "تعداد شعب بیشتر از استان", DataType = typeof(int) });
                        ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_CountGreaterAvgBranches, Caption = "تعداد شعب بیشتر از استان", DataType = typeof(int) });

                        double prAvg = double.Parse(ds.Tables["Province"].Rows[0][col.ColumnName].ToString());//رشد استان

                        foreach (DataRow row in ds.Tables["Branches"].Rows)
                        {
                            string type = Branches.GetBranchById(row["Branches.BranchId"].ToString(), false).BranchType;
                            if (type == "شعبه" | type == "شعبه مستقل")
                            {
                                if (Numeral.AnyToDouble(row[col.ColumnName]) > prAvg)
                                    row[ns_CountGreaterAvgBranches] = 1;
                            }
                        }

                        foreach (DataRow row in ds.Tables["Domains"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = {1} AND {2} = 1", "Domains.DomainId", row["Domains.DomainId"].ToString(), ns_CountGreaterAvgBranches);
                            row[ns_CountGreaterAvgBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";

                        foreach (DataRow row in ds.Tables["Province"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = 1", ns_CountGreaterAvgBranches);
                            row[ns_CountGreaterAvgBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";
                    }
                    #endregion
                }
            }

            #endregion

            #region ارزیابی دو

            if (evaluationItems2.Count > 0)
            {
                int number = 0;
                List<DataColumn> ns_evalColumnNames = new List<DataColumn>();
                if (evaluationType2 == "Average")
                    ns_evalColumnNames.Add(ds.Tables["Branches"].Columns["PrimaryColumns.Average"]);
                if (evaluationType2 == "Sum")
                    ns_evalColumnNames.Add(ds.Tables["Branches"].Columns["PrimaryColumns.Sum"]);
                if (evaluationType2 == "@PrimaryColumns")
                {
                    ns_evalColumnNames = primaryColumns;
                    list_PrimaryColumns = primaryColumns.Select(x => x.ColumnName).ToList();
                    primary_caption = ds.ExtendedProperties[ds.ExtendedProperties["EvaluationType2"].ToString()].ToString();
                }

                foreach (DataColumn col in ns_evalColumnNames)
                {
                    ++number;
                    string ns_RankInProvince = string.Empty;
                    string ns_RankInDomain = string.Empty;
                    string ns_RankInEqualBranches = string.Empty;
                    string ns_PercentageShare = string.Empty;
                    string ns_CountPositiveBranches = string.Empty;
                    string ns_CountNegativeBranches = string.Empty;
                    string ns_CountLessAvgBranches = string.Empty;
                    string ns_CountGreaterAvgBranches = string.Empty;

                    bands.Add(gvm.CreateBand("Evaluation" + number, col.Namespace, 80));

                    ns_RankInProvince = string.Format("Evaluation{0}.RankInProvince{0}", number);
                    ns_RankInDomain = string.Format("Evaluation{0}.RankInDomain{0}", number);
                    ns_RankInEqualBranches = string.Format("Evaluation{0}.RankInEqualBranches{0}", number);
                    ns_PercentageShare = string.Format("Evaluation{0}.PercentageShare{0}", number);
                    ns_CountPositiveBranches = string.Format("Evaluation{0}.CountPositiveBranches{0}", number);
                    ns_CountNegativeBranches = string.Format("Evaluation{0}.CountNegativeBranches{0}", number);
                    ns_CountLessAvgBranches = string.Format("Evaluation{0}.CountLessAvgBranches{0}", number);
                    ns_CountGreaterAvgBranches = string.Format("Evaluation{0}.CountGreaterAvgBranches{0}", number);

                    #region رتبه در استان
                    if (evaluationItems2.Contains("RankInProvince"))
                    {
                        ///////////////////////////////////
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_RankInProvince, Caption = "رتبه در استان", DataType = typeof(int) });
                        ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_RankInProvince, Caption = "رتبه در استان", DataType = typeof(int) });
                        ///////////////////////////////////
                        ds.Tables["Branches"].DefaultView.Sort = col.ColumnName + " " + rankMode;
                        int rank = 1;
                        foreach (DataRowView r in ds.Tables["Branches"].DefaultView)
                        {
                            string branchId = r["Branches.BranchId"].ToString();
                            if (Branches.IsBranch(branchId))
                            {
                                string type = Branches.GetBranchById(r["Branches.BranchId"].ToString(), false).BranchType;
                                if (type == "شعبه" | type == "شعبه مستقل")
                                    r[ns_RankInProvince] = rank++;
                            }
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";
                        ///////////////////////////////////
                        ds.Tables["Domains"].DefaultView.Sort = col.ColumnName + " " + rankMode;
                        rank = 1;
                        foreach (DataRowView r in ds.Tables["Domains"].DefaultView)
                            r[ns_RankInProvince] = rank++;
                        ds.Tables["Domains"].DefaultView.RowFilter = "";
                        ///////////////////////////////////
                    }
                    #endregion

                    #region رتبه در حوزه
                    if (evaluationItems2.Contains("RankInDomain"))
                    {
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_RankInDomain, Caption = "رتبه در حوزه", DataType = typeof(int) });

                        foreach (DataRow row in ds.Tables["Domains"].Rows)
                        {
                            int rank = 1;
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = {1}", "Domains.DomainId", row["Domains.DomainId"].ToString());
                            ds.Tables["Branches"].DefaultView.Sort = col.ColumnName + " " + rankMode;
                            foreach (DataRowView r in ds.Tables["Branches"].DefaultView)
                            {
                                string branchId = r["Branches.BranchId"].ToString();
                                if (Branches.IsBranch(branchId))
                                {
                                    string type = Branches.GetBranchById(r["Branches.BranchId"].ToString(), false).BranchType;
                                    if (type == "شعبه" | type == "شعبه مستقل")
                                        r[ns_RankInDomain] = rank++;
                                }
                            }
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";
                    }
                    #endregion

                    #region رتبه بین هم درجه
                    if (evaluationItems2.Contains("RankInEqualBranches"))
                    {
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_RankInEqualBranches, Caption = "رتبه بین هم درجه", DataType = typeof(int) });

                        foreach (string degree in Branches.GetAllBranchDegree())
                        {
                            int rank = 1;
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = '{1}'", "Branches.BranchDegree", degree);
                            ds.Tables["Branches"].DefaultView.Sort = col.ColumnName + " " + rankMode;
                            foreach (DataRowView r in ds.Tables["Branches"].DefaultView)
                            {
                                string branchId = r["Branches.BranchId"].ToString();
                                if (Branches.IsBranch(branchId))
                                {
                                    string type = Branches.GetBranchById(r["Branches.BranchId"].ToString(), false).BranchType;
                                    if (type == "شعبه" | type == "شعبه مستقل")
                                        r[ns_RankInEqualBranches] = rank++;
                                }
                            }
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";
                    }
                    #endregion

                    #region سهم درصد
                    if (evaluationItems2.Contains("PercentageShare"))
                    {
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_PercentageShare, Caption = "سهم درصد", DataType = typeof(double) });
                        ds.Tables["Branches"].Columns[ns_PercentageShare].ExtendedProperties.Add("FormatNumber", "N1");
                        ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_PercentageShare, Caption = "سهم درصد", DataType = typeof(double) });
                        ds.Tables["Domains"].Columns[ns_PercentageShare].ExtendedProperties.Add("FormatNumber", "N1");
                        ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_PercentageShare, Caption = "سهم درصد", DataType = typeof(double) });
                        ds.Tables["Province"].Columns[ns_PercentageShare].ExtendedProperties.Add("FormatNumber", "N1");

                        double prAvg = double.Parse(ds.Tables["Province"].Rows[0][col.ColumnName].ToString());//رشد استان

                        foreach (DataRow row in ds.Tables["Branches"].Rows)
                            row[ns_PercentageShare] = (Numeral.AnyToDouble(row[col.ColumnName]) / prAvg) * 100;

                        foreach (DataRow row in ds.Tables["Domains"].Rows)
                            row[ns_PercentageShare] = (Numeral.AnyToDouble(row[col.ColumnName]) / prAvg) * 100;

                        foreach (DataRow row in ds.Tables["Province"].Rows)
                            row[ns_PercentageShare] = 100;
                       
                        if (!list_percentageShareColumns.Contains(ns_PercentageShare))
                            list_percentageShareColumns.Add(ns_PercentageShare);
                    }
                    #endregion

                    #region تعداد شعب مثبت
                    if (evaluationItems2.Contains("CountPositiveBranches"))
                    {
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_CountPositiveBranches, Caption = "تعداد شعب مثبت", DataType = typeof(int) });
                        ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_CountPositiveBranches, Caption = "تعداد شعب مثبت", DataType = typeof(int) });
                        ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_CountPositiveBranches, Caption = "تعداد شعب مثبت", DataType = typeof(int) });

                        foreach (DataRow row in ds.Tables["Branches"].Rows)
                        {
                            string type = Branches.GetBranchById(row["Branches.BranchId"].ToString(), false).BranchType;
                            if (type == "شعبه" | type == "شعبه مستقل")
                            {
                                if (Numeral.AnyToDouble(row[col.ColumnName]) > 0)
                                    row[ns_CountPositiveBranches] = 1;
                            }
                        }

                        foreach (DataRow row in ds.Tables["Domains"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = {1} AND {2} = 1", "Domains.DomainId", row["Domains.DomainId"].ToString(), ns_CountPositiveBranches);
                            row[ns_CountPositiveBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";

                        foreach (DataRow row in ds.Tables["Province"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = 1", ns_CountPositiveBranches);
                            row[ns_CountPositiveBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";
                    }
                    #endregion

                    #region تعداد شعب منفی
                    if (evaluationItems2.Contains("CountNegativeBranches"))
                    {
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_CountNegativeBranches, Caption = "تعداد شعب منفی", DataType = typeof(int) });
                        ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_CountNegativeBranches, Caption = "تعداد شعب منفی", DataType = typeof(int) });
                        ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_CountNegativeBranches, Caption = "تعداد شعب منفی", DataType = typeof(int) });

                        foreach (DataRow row in ds.Tables["Branches"].Rows)
                        {
                            string type = Branches.GetBranchById(row["Branches.BranchId"].ToString(), false).BranchType;
                            if (type == "شعبه" | type == "شعبه مستقل")
                            {
                                if (Numeral.AnyToDouble(row[col.ColumnName]) <= 0)
                                    row[ns_CountNegativeBranches] = 1;
                            }
                        }

                        foreach (DataRow row in ds.Tables["Domains"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = {1} AND {2} = 1", "Domains.DomainId", row["Domains.DomainId"].ToString(), ns_CountNegativeBranches);
                            row[ns_CountNegativeBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";

                        foreach (DataRow row in ds.Tables["Province"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = 1", ns_CountNegativeBranches);
                            row[ns_CountNegativeBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";
                    }
                    #endregion

                    #region تعداد شعب کمتر از استان
                    if (evaluationItems2.Contains("CountLessAvgBranches"))
                    {
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_CountLessAvgBranches, Caption = "کمتر از استان", DataType = typeof(int) });
                        ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_CountLessAvgBranches, Caption = "تعداد شعب کمتر از استان", DataType = typeof(int) });
                        ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_CountLessAvgBranches, Caption = "تعداد شعب کمتر از استان", DataType = typeof(int) });

                        double prAvg = double.Parse(ds.Tables["Province"].Rows[0][col.ColumnName].ToString());//رشد استان

                        foreach (DataRow row in ds.Tables["Branches"].Rows)
                        {
                            string type = Branches.GetBranchById(row["Branches.BranchId"].ToString(), false).BranchType;
                            if (type == "شعبه" | type == "شعبه مستقل")
                            {
                                if (Numeral.AnyToDouble(row[col.ColumnName]) <= prAvg)
                                    row[ns_CountLessAvgBranches] = 1;
                            }
                        }

                        foreach (DataRow row in ds.Tables["Domains"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = {1} AND {2} = 1", "Domains.DomainId", row["Domains.DomainId"].ToString(), ns_CountLessAvgBranches);
                            row[ns_CountLessAvgBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";

                        foreach (DataRow row in ds.Tables["Province"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = 1", ns_CountLessAvgBranches);
                            row[ns_CountLessAvgBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";
                    }
                    #endregion

                    #region تعداد شعب بالاتر از استان
                    if (evaluationItems2.Contains("CountGreaterAvgBranches"))
                    {
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_CountGreaterAvgBranches, Caption = "بیشتر از استان", DataType = typeof(int) });
                        ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_CountGreaterAvgBranches, Caption = "تعداد شعب بیشتر از استان", DataType = typeof(int) });
                        ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_CountGreaterAvgBranches, Caption = "تعداد شعب بیشتر از استان", DataType = typeof(int) });

                        double prAvg = double.Parse(ds.Tables["Province"].Rows[0][col.ColumnName].ToString());//رشد استان

                        foreach (DataRow row in ds.Tables["Branches"].Rows)
                        {
                            string type = Branches.GetBranchById(row["Branches.BranchId"].ToString(), false).BranchType;
                            if (type == "شعبه" | type == "شعبه مستقل")
                            {
                                if (Numeral.AnyToDouble(row[col.ColumnName]) > prAvg)
                                    row[ns_CountGreaterAvgBranches] = 1;
                            }
                        }

                        foreach (DataRow row in ds.Tables["Domains"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = {1} AND {2} = 1", "Domains.DomainId", row["Domains.DomainId"].ToString(), ns_CountGreaterAvgBranches);
                            row[ns_CountGreaterAvgBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";

                        foreach (DataRow row in ds.Tables["Province"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = 1", ns_CountGreaterAvgBranches);
                            row[ns_CountGreaterAvgBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";
                    }
                    #endregion
                }
            }

            #endregion

            #region ارزیابی سه

            if (evaluationItems3.Count > 0)
            {
                int number = 0;
                List<DataColumn> ns_evalColumnNames = new List<DataColumn>();
                if (evaluationType3 == "Average")
                    ns_evalColumnNames.Add(ds.Tables["Branches"].Columns["PrimaryColumns.Average"]);
                if (evaluationType3 == "Sum")
                    ns_evalColumnNames.Add(ds.Tables["Branches"].Columns["PrimaryColumns.Sum"]);
                if (evaluationType3 == "@PrimaryColumns")
                {
                    ns_evalColumnNames = primaryColumns;
                    list_PrimaryColumns = primaryColumns.Select(x => x.ColumnName).ToList();
                    primary_caption = ds.ExtendedProperties[ds.ExtendedProperties["EvaluationType3"].ToString()].ToString();
                }

                foreach (DataColumn col in ns_evalColumnNames)
                {
                    ++number;
                    string ns_RankInProvince = string.Empty;
                    string ns_RankInDomain = string.Empty;
                    string ns_RankInEqualBranches = string.Empty;
                    string ns_PercentageShare = string.Empty;
                    string ns_CountPositiveBranches = string.Empty;
                    string ns_CountNegativeBranches = string.Empty;
                    string ns_CountLessAvgBranches = string.Empty;
                    string ns_CountGreaterAvgBranches = string.Empty;

                    bands.Add(gvm.CreateBand("Evaluation" + number, col.Namespace, 80));

                    ns_RankInProvince = string.Format("Evaluation{0}.RankInProvince{0}", number);
                    ns_RankInDomain = string.Format("Evaluation{0}.RankInDomain{0}", number);
                    ns_RankInEqualBranches = string.Format("Evaluation{0}.RankInEqualBranches{0}", number);
                    ns_PercentageShare = string.Format("Evaluation{0}.PercentageShare{0}", number);
                    ns_CountPositiveBranches = string.Format("Evaluation{0}.CountPositiveBranches{0}", number);
                    ns_CountNegativeBranches = string.Format("Evaluation{0}.CountNegativeBranches{0}", number);
                    ns_CountLessAvgBranches = string.Format("Evaluation{0}.CountLessAvgBranches{0}", number);
                    ns_CountGreaterAvgBranches = string.Format("Evaluation{0}.CountGreaterAvgBranches{0}", number);

                    #region رتبه در استان
                    if (evaluationItems3.Contains("RankInProvince"))
                    {
                        ///////////////////////////////////
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_RankInProvince, Caption = "رتبه در استان", DataType = typeof(int) });
                        ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_RankInProvince, Caption = "رتبه در استان", DataType = typeof(int) });
                        ///////////////////////////////////
                        ds.Tables["Branches"].DefaultView.Sort = col.ColumnName + " " + rankMode;
                        int rank = 1;
                        foreach (DataRowView r in ds.Tables["Branches"].DefaultView)
                        {
                            string branchId = r["Branches.BranchId"].ToString();
                            if (Branches.IsBranch(branchId))
                            {
                                string type = Branches.GetBranchById(r["Branches.BranchId"].ToString(), false).BranchType;
                                if (type == "شعبه" | type == "شعبه مستقل")
                                    r[ns_RankInProvince] = rank++;
                            }
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";
                        ///////////////////////////////////
                        ds.Tables["Domains"].DefaultView.Sort = col.ColumnName + " " + rankMode;
                        rank = 1;
                        foreach (DataRowView r in ds.Tables["Domains"].DefaultView)
                            r[ns_RankInProvince] = rank++;
                        ds.Tables["Domains"].DefaultView.RowFilter = "";
                        ///////////////////////////////////
                    }
                    #endregion

                    #region رتبه در حوزه
                    if (evaluationItems3.Contains("RankInDomain"))
                    {
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_RankInDomain, Caption = "رتبه در حوزه", DataType = typeof(int) });

                        foreach (DataRow row in ds.Tables["Domains"].Rows)
                        {
                            int rank = 1;
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = {1}", "Domains.DomainId", row["Domains.DomainId"].ToString());
                            ds.Tables["Branches"].DefaultView.Sort = col.ColumnName + " " + rankMode;
                            foreach (DataRowView r in ds.Tables["Branches"].DefaultView)
                            {
                                string branchId = r["Branches.BranchId"].ToString();
                                if (Branches.IsBranch(branchId))
                                {
                                    string type = Branches.GetBranchById(r["Branches.BranchId"].ToString(), false).BranchType;
                                    if (type == "شعبه" | type == "شعبه مستقل")
                                        r[ns_RankInDomain] = rank++;
                                }
                            }
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";
                    }
                    #endregion

                    #region رتبه بین هم درجه
                    if (evaluationItems3.Contains("RankInEqualBranches"))
                    {
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_RankInEqualBranches, Caption = "رتبه بین هم درجه", DataType = typeof(int) });

                        foreach (string degree in Branches.GetAllBranchDegree())
                        {
                            int rank = 1;
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = '{1}'", "Branches.BranchDegree", degree);
                            ds.Tables["Branches"].DefaultView.Sort = col.ColumnName + " " + rankMode;
                            foreach (DataRowView r in ds.Tables["Branches"].DefaultView)
                            {
                                string branchId = r["Branches.BranchId"].ToString();
                                if (Branches.IsBranch(branchId))
                                {
                                    string type = Branches.GetBranchById(r["Branches.BranchId"].ToString(), false).BranchType;
                                    if (type == "شعبه" | type == "شعبه مستقل")
                                        r[ns_RankInEqualBranches] = rank++;
                                }
                            }
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";
                    }
                    #endregion

                    #region سهم درصد
                    if (evaluationItems3.Contains("PercentageShare"))
                    {
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_PercentageShare, Caption = "سهم درصد", DataType = typeof(double) });
                        ds.Tables["Branches"].Columns[ns_PercentageShare].ExtendedProperties.Add("FormatNumber", "N1");
                        ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_PercentageShare, Caption = "سهم درصد", DataType = typeof(double) });
                        ds.Tables["Domains"].Columns[ns_PercentageShare].ExtendedProperties.Add("FormatNumber", "N1");
                        ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_PercentageShare, Caption = "سهم درصد", DataType = typeof(double) });
                        ds.Tables["Province"].Columns[ns_PercentageShare].ExtendedProperties.Add("FormatNumber", "N1");

                        double prAvg = double.Parse(ds.Tables["Province"].Rows[0][col.ColumnName].ToString());//رشد استان

                        foreach (DataRow row in ds.Tables["Branches"].Rows)
                            row[ns_PercentageShare] = (Numeral.AnyToDouble(row[col.ColumnName]) / prAvg) * 100;

                        foreach (DataRow row in ds.Tables["Domains"].Rows)
                            row[ns_PercentageShare] = (Numeral.AnyToDouble(row[col.ColumnName]) / prAvg) * 100;

                        foreach (DataRow row in ds.Tables["Province"].Rows)
                            row[ns_PercentageShare] = 100;

                        if (!list_percentageShareColumns.Contains(ns_PercentageShare))
                            list_percentageShareColumns.Add(ns_PercentageShare);
                    }
                    #endregion

                    #region تعداد شعب مثبت
                    if (evaluationItems3.Contains("CountPositiveBranches"))
                    {
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_CountPositiveBranches, Caption = "تعداد شعب مثبت", DataType = typeof(int) });
                        ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_CountPositiveBranches, Caption = "تعداد شعب مثبت", DataType = typeof(int) });
                        ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_CountPositiveBranches, Caption = "تعداد شعب مثبت", DataType = typeof(int) });

                        foreach (DataRow row in ds.Tables["Branches"].Rows)
                        {
                            string type = Branches.GetBranchById(row["Branches.BranchId"].ToString(), false).BranchType;
                            if (type == "شعبه" | type == "شعبه مستقل")
                            {
                                if (Numeral.AnyToDouble(row[col.ColumnName]) > 0)
                                    row[ns_CountPositiveBranches] = 1;
                            }
                        }

                        foreach (DataRow row in ds.Tables["Domains"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = {1} AND {2} = 1", "Domains.DomainId", row["Domains.DomainId"].ToString(), ns_CountPositiveBranches);
                            row[ns_CountPositiveBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";

                        foreach (DataRow row in ds.Tables["Province"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = 1", ns_CountPositiveBranches);
                            row[ns_CountPositiveBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";
                    }
                    #endregion

                    #region تعداد شعب منفی
                    if (evaluationItems3.Contains("CountNegativeBranches"))
                    {
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_CountNegativeBranches, Caption = "تعداد شعب منفی", DataType = typeof(int) });
                        ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_CountNegativeBranches, Caption = "تعداد شعب منفی", DataType = typeof(int) });
                        ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_CountNegativeBranches, Caption = "تعداد شعب منفی", DataType = typeof(int) });

                        foreach (DataRow row in ds.Tables["Branches"].Rows)
                        {
                            string type = Branches.GetBranchById(row["Branches.BranchId"].ToString(), false).BranchType;
                            if (type == "شعبه" | type == "شعبه مستقل")
                            {
                                if (Numeral.AnyToDouble(row[col.ColumnName]) <= 0)
                                    row[ns_CountNegativeBranches] = 1;
                            }
                        }

                        foreach (DataRow row in ds.Tables["Domains"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = {1} AND {2} = 1", "Domains.DomainId", row["Domains.DomainId"].ToString(), ns_CountNegativeBranches);
                            row[ns_CountNegativeBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";

                        foreach (DataRow row in ds.Tables["Province"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = 1", ns_CountNegativeBranches);
                            row[ns_CountNegativeBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";
                    }
                    #endregion

                    #region تعداد شعب کمتر از استان
                    if (evaluationItems3.Contains("CountLessAvgBranches"))
                    {
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_CountLessAvgBranches, Caption = "کمتر از استان", DataType = typeof(int) });
                        ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_CountLessAvgBranches, Caption = "تعداد شعب کمتر از استان", DataType = typeof(int) });
                        ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_CountLessAvgBranches, Caption = "تعداد شعب کمتر از استان", DataType = typeof(int) });

                        double prAvg = double.Parse(ds.Tables["Province"].Rows[0][col.ColumnName].ToString());//رشد استان

                        foreach (DataRow row in ds.Tables["Branches"].Rows)
                        {
                            string type = Branches.GetBranchById(row["Branches.BranchId"].ToString(), false).BranchType;
                            if (type == "شعبه" | type == "شعبه مستقل")
                            {
                                if (Numeral.AnyToDouble(row[col.ColumnName]) <= prAvg)
                                    row[ns_CountLessAvgBranches] = 1;
                            }
                        }

                        foreach (DataRow row in ds.Tables["Domains"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = {1} AND {2} = 1", "Domains.DomainId", row["Domains.DomainId"].ToString(), ns_CountLessAvgBranches);
                            row[ns_CountLessAvgBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";

                        foreach (DataRow row in ds.Tables["Province"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = 1", ns_CountLessAvgBranches);
                            row[ns_CountLessAvgBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";
                    }
                    #endregion

                    #region تعداد شعب بالاتر از استان
                    if (evaluationItems3.Contains("CountGreaterAvgBranches"))
                    {
                        ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_CountGreaterAvgBranches, Caption = "بیشتر از استان", DataType = typeof(int) });
                        ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_CountGreaterAvgBranches, Caption = "تعداد شعب بیشتر از استان", DataType = typeof(int) });
                        ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_CountGreaterAvgBranches, Caption = "تعداد شعب بیشتر از استان", DataType = typeof(int) });

                        double prAvg = double.Parse(ds.Tables["Province"].Rows[0][col.ColumnName].ToString());//رشد استان

                        foreach (DataRow row in ds.Tables["Branches"].Rows)
                        {
                            string type = Branches.GetBranchById(row["Branches.BranchId"].ToString(), false).BranchType;
                            if (type == "شعبه" | type == "شعبه مستقل")
                            {
                                if (Numeral.AnyToDouble(row[col.ColumnName]) > prAvg)
                                    row[ns_CountGreaterAvgBranches] = 1;
                            }
                        }

                        foreach (DataRow row in ds.Tables["Domains"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = {1} AND {2} = 1", "Domains.DomainId", row["Domains.DomainId"].ToString(), ns_CountGreaterAvgBranches);
                            row[ns_CountGreaterAvgBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";

                        foreach (DataRow row in ds.Tables["Province"].Rows)
                        {
                            ds.Tables["Branches"].DefaultView.RowFilter = string.Format("{0} = 1", ns_CountGreaterAvgBranches);
                            row[ns_CountGreaterAvgBranches] = ds.Tables["Branches"].DefaultView.Count;
                        }
                        ds.Tables["Branches"].DefaultView.RowFilter = "";
                    }
                    #endregion
                }
            }

            #endregion
       
            if (evaluationItems1.Contains("Sparkline") | evaluationItems2.Contains("Sparkline") | evaluationItems3.Contains("Sparkline"))
            {
                #region Sparkline 1

                if (list_PrimaryColumns.Count > 0)
                {
                    ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = "Charts.Sparkline1", Caption = primary_caption, DataType = typeof(double[]) });
                    ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = "Charts.Sparkline1", Caption = primary_caption, DataType = typeof(double[]) });
                    ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = "Charts.Sparkline1", Caption = primary_caption, DataType = typeof(double[]) });

                    foreach (DataRow row in ds.Tables["Branches"].Rows)
                    {
                        List<double> list = new List<double>();
                        foreach (string colName in list_PrimaryColumns)
                            list.Add(Numeral.AnyToDouble(row[colName]));
                        row["Charts.Sparkline1"] = list.ToArray();
                    }

                    foreach (DataRow row in ds.Tables["Domains"].Rows)
                    {
                        List<double> list = new List<double>();
                        foreach (string colName in list_PrimaryColumns)
                            list.Add(Numeral.AnyToDouble(row[colName]));
                        row["Charts.Sparkline1"] = list.ToArray();
                    }

                    foreach (DataRow row in ds.Tables["Province"].Rows)
                    {
                        List<double> list = new List<double>();
                        foreach (string colName in list_PrimaryColumns)
                            list.Add(Numeral.AnyToDouble(row[colName]));
                        row["Charts.Sparkline1"] = list.ToArray();
                    }
                }
                #endregion

                #region Sparkline 2

                if (list_GrowthPercentageColumns.Count > 0)
                {
                    ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = "Charts.Sparkline2", Caption = "درصد رشد", DataType = typeof(double[]) });
                    ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = "Charts.Sparkline2", Caption = "درصد رشد", DataType = typeof(double[]) });
                    ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = "Charts.Sparkline2", Caption = "درصد رشد", DataType = typeof(double[]) });

                    foreach (DataRow row in ds.Tables["Branches"].Rows)
                    {
                        List<double> list = new List<double>();
                        foreach (string colName in list_GrowthPercentageColumns)
                            list.Add(Numeral.AnyToDouble(row[colName]));
                        row["Charts.Sparkline2"] = list.ToArray();
                    }

                    foreach (DataRow row in ds.Tables["Domains"].Rows)
                    {
                        List<double> list = new List<double>();
                        foreach (string colName in list_GrowthPercentageColumns)
                            list.Add(Numeral.AnyToDouble(row[colName]));
                        row["Charts.Sparkline2"] = list.ToArray();
                    }

                    foreach (DataRow row in ds.Tables["Province"].Rows)
                    {
                        List<double> list = new List<double>();
                        foreach (string colName in list_GrowthPercentageColumns)
                            list.Add(Numeral.AnyToDouble(row[colName]));
                        row["Charts.Sparkline2"] = list.ToArray();
                    }
                }
                #endregion

                #region Sparkline 3

                if (list_absoluteValueColumns.Count > 0)
                {
                    ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = "Charts.Sparkline3", Caption = "قدر مطلق", DataType = typeof(double[]) });
                    ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = "Charts.Sparkline3", Caption = "قدر مطلق", DataType = typeof(double[]) });
                    ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = "Charts.Sparkline3", Caption = "قدر مطلق", DataType = typeof(double[]) });

                    foreach (DataRow row in ds.Tables["Branches"].Rows)
                    {
                        List<double> list = new List<double>();
                        foreach (string colName in list_absoluteValueColumns)
                            list.Add(Numeral.AnyToDouble(row[colName]));
                        row["Charts.Sparkline3"] = list.ToArray();
                    }

                    foreach (DataRow row in ds.Tables["Domains"].Rows)
                    {
                        List<double> list = new List<double>();
                        foreach (string colName in list_absoluteValueColumns)
                            list.Add(Numeral.AnyToDouble(row[colName]));
                        row["Charts.Sparkline3"] = list.ToArray();
                    }

                    foreach (DataRow row in ds.Tables["Province"].Rows)
                    {
                        List<double> list = new List<double>();
                        foreach (string colName in list_absoluteValueColumns)
                            list.Add(Numeral.AnyToDouble(row[colName]));
                        row["Charts.Sparkline3"] = list.ToArray();
                    }
                }
                #endregion

                #region Sparkline 4

                if (list_coveragePercentageColumns.Count > 0)
                {
                    ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = "Charts.Sparkline4", Caption = "درصد پوشش", DataType = typeof(double[]) });
                    ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = "Charts.Sparkline4", Caption = "درصد پوشش", DataType = typeof(double[]) });
                    ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = "Charts.Sparkline4", Caption = "درصد پوشش", DataType = typeof(double[]) });

                    foreach (DataRow row in ds.Tables["Branches"].Rows)
                    {
                        List<double> list = new List<double>();
                        foreach (string colName in list_coveragePercentageColumns)
                            list.Add(Numeral.AnyToDouble(row[colName]));
                        row["Charts.Sparkline4"] = list.ToArray();
                    }

                    foreach (DataRow row in ds.Tables["Domains"].Rows)
                    {
                        List<double> list = new List<double>();
                        foreach (string colName in list_coveragePercentageColumns)
                            list.Add(Numeral.AnyToDouble(row[colName]));
                        row["Charts.Sparkline4"] = list.ToArray();
                    }

                    foreach (DataRow row in ds.Tables["Province"].Rows)
                    {
                        List<double> list = new List<double>();
                        foreach (string colName in list_coveragePercentageColumns)
                            list.Add(Numeral.AnyToDouble(row[colName]));
                        row["Charts.Sparkline4"] = list.ToArray();
                    }
                }
                #endregion

                #region Sparkline 5

                if (list_percentageShareColumns.Count > 0)
                {
                    ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = "Charts.Sparkline5", Caption = "سهم درصد", DataType = typeof(double[]) });
                    ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = "Charts.Sparkline5", Caption = "سهم درصد", DataType = typeof(double[]) });
                    ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = "Charts.Sparkline5", Caption = "سهم درصد", DataType = typeof(double[]) });

                    foreach (DataRow row in ds.Tables["Branches"].Rows)
                    {
                        List<double> list = new List<double>();
                        foreach (string colName in list_percentageShareColumns)
                            list.Add(Numeral.AnyToDouble(row[colName]));
                        row["Charts.Sparkline5"] = list.ToArray();
                    }

                    foreach (DataRow row in ds.Tables["Domains"].Rows)
                    {
                        List<double> list = new List<double>();
                        foreach (string colName in list_percentageShareColumns)
                            list.Add(Numeral.AnyToDouble(row[colName]));
                        row["Charts.Sparkline5"] = list.ToArray();
                    }

                    foreach (DataRow row in ds.Tables["Province"].Rows)
                    {
                        List<double> list = new List<double>();
                        foreach (string colName in list_percentageShareColumns)
                            list.Add(Numeral.AnyToDouble(row[colName]));
                        row["Charts.Sparkline5"] = list.ToArray();
                    }
                }
                #endregion
            }
            if (otherEvaluationItems.Contains("AdvChart"))
            {
               
                ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = "Charts.AdvChart", Caption = "نمودار"});
                ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = "Charts.AdvChart", Caption = "نمودار" });
                ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = "Charts.AdvChart", Caption = "نمودار"});
                ds.Tables["Branches"].Columns["Charts.AdvChart"].ExtendedProperties.Add("Properties", ds.ExtendedProperties);
                ds.Tables["Domains"].Columns["Charts.AdvChart"].ExtendedProperties.Add("Properties", ds.ExtendedProperties);
                ds.Tables["Province"].Columns["Charts.AdvChart"].ExtendedProperties.Add("Properties", ds.ExtendedProperties);
            }

            #region افزودن میانگین درصد رشد

            if (otherEvaluationItems.Contains("AvarageGrowth"))
            {
                bands.Add(gvm.CreateBand("AvarageGrowth", "میانگین درصدرشد", 100));

                string ns_percentage = "AvarageGrowth.Percentage";
                string ns_rank = "AvarageGrowth.Rank";

                ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_percentage, Caption = "درصد", DataType = typeof(double) });
                ds.Tables["Branches"].Columns["AvarageGrowth.Percentage"].ExtendedProperties.Add("FormatNumber", "N1");
                ds.Tables["Branches"].Columns.Add(new DataColumn { ColumnName = ns_rank, Caption = "رتبه", DataType = typeof(int) });

                ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_percentage, Caption = "درصد", DataType = typeof(double) });
                ds.Tables["Domains"].Columns["AvarageGrowth.Percentage"].ExtendedProperties.Add("FormatNumber", "N1");
                ds.Tables["Domains"].Columns.Add(new DataColumn { ColumnName = ns_rank, Caption = "رتبه", DataType = typeof(int) });

                ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_percentage, Caption = "درصد", DataType = typeof(double) });
                ds.Tables["Province"].Columns["AvarageGrowth.Percentage"].ExtendedProperties.Add("FormatNumber", "N1");
                ds.Tables["Province"].Columns.Add(new DataColumn { ColumnName = ns_rank, Caption = "رتبه", DataType = typeof(int) });

                foreach (DataRow row in ds.Tables["Branches"].Rows)
                {
                    List<double> list = new List<double>();
                    foreach (string item in list_GrowthPercentageColumns)
                        list.Add(Numeral.AnyToDouble(row[item]));
                    row[ns_percentage] = list.Average();
                }

                foreach (DataRow row in ds.Tables["Domains"].Rows)
                {
                    List<double> list = new List<double>();
                    foreach (string item in list_GrowthPercentageColumns)
                        list.Add(Numeral.AnyToDouble(row[item]));
                    row[ns_percentage] = list.Average();
                }

                foreach (DataRow row in ds.Tables["Province"].Rows)
                {
                    List<double> list = new List<double>();
                    foreach (string item in list_GrowthPercentageColumns)
                        list.Add(Numeral.AnyToDouble(row[item]));
                    row[ns_percentage] = list.Average();
                }


                ds.Tables["Branches"].DefaultView.Sort = ns_percentage + " " + rankMode;
                int rank = 1;
                foreach (DataRowView r in ds.Tables["Branches"].DefaultView)
                    r[ns_rank] = rank++;
                ds.Tables["Branches"].DefaultView.RowFilter = "";

                ds.Tables["Domains"].DefaultView.Sort = ns_percentage + " " + rankMode;
                rank = 1;
                foreach (DataRowView r in ds.Tables["Domains"].DefaultView)
                    r[ns_rank] = rank++;
                ds.Tables["Domains"].DefaultView.RowFilter = "";
            }
            #endregion

            #region Series Points
            
            if (seriesPoints.Count > 0)
            {
                IDictionary<int, ISeries.BranchSeries> brSeries = new Dictionary<int, ISeries.BranchSeries>();
                var groupSeries = seriesPoints.GroupBy(x => new { x.BranchId, x.Caption, x.ReportDate });
                foreach (var g in groupSeries)
                {
                    foreach (ISeries.DataPoint p in g)
                    {
                        int branchId = int.Parse(g.Key.BranchId);
                        ISeries.DatePoints dp = new ISeries.DatePoints();
                        ISeries.BranchSeries bs = new ISeries.BranchSeries();

                        dp.Points.Add(p.Argument, p);
                        bs.Comparisons.Add(p.Caption, dp);

                        if (!brSeries.ContainsKey(int.Parse(g.Key.BranchId)))
                        {
                            brSeries.Add(branchId, bs);
                        }
                        else
                        {
                            if (brSeries[branchId].Comparisons.ContainsKey(p.Caption))
                            {
                                if (!brSeries[branchId].Comparisons[p.Caption].Points.ContainsKey(p.Argument))
                                    brSeries[branchId].Comparisons[p.Caption].Points.Add(p.Argument, p);
                            }
                            else
                            {
                                brSeries[branchId].Comparisons.Add(p.Caption, dp);
                                if (!brSeries[branchId].Comparisons[p.Caption].Points.ContainsKey(p.Argument))
                                    brSeries[branchId].Comparisons[p.Caption].Points.Add(p.Argument, p);
                            }
                        }

                    }
                }

                if (ds.ExtendedProperties.ContainsKey("BranchesSeries"))
                    ds.ExtendedProperties["BranchesSeries"] = brSeries;
                else
                    ds.ExtendedProperties.Add("BranchesSeries", brSeries);
            }
            #endregion

            #region Add BranchesList

            if (ds.Tables.Contains("Province") & ds.Tables.Contains("Branches"))
            {
                DataTable branchesListTable = ds.Tables["Branches"].Copy();
                branchesListTable.TableName = "BranchesList";
                branchesListTable.Columns["Domains.DomainName"].ExtendedProperties["Visible"] = true;
                branchesListTable.Columns["Branches.BranchId"].ExtendedProperties["Visible"] = true;
                ds.Tables.Add(branchesListTable);
                ds.Relations.Add("لیست شعب", ds.Tables["Province"].Columns["Province.ProvinceId"], branchesListTable.Columns["Province.ProvinceId"]);
                int relationsCount = ds.Relations.Count;
                for (int i = 0; i < relationsCount; i++)
                {
                    DataRelation dr = ds.Relations[i];
                    if (dr.ParentColumns[0].ColumnName == "Branches.BranchId")
                    {
                        ds.Relations.Add(dr.RelationName + "   ", branchesListTable.Columns["Branches.BranchId"], dr.ChildColumns[0].Table.Columns["Branches.BranchId"]);
                    }
                }
            }

            #endregion

            #region Create BandedGridView

            IDictionary<string, BandedGridView> bandedGridViewList = new Dictionary<string, BandedGridView>();
            foreach (DataTable table in ds.Tables)
            {
                bandedGridViewList.Add(table.TableName, gvm.CreateView(ds.ExtendedProperties["ReportName"].ToString(), table, bands));
            }

            if (ds.ExtendedProperties.ContainsKey("BandedGridViewList"))
                ds.ExtendedProperties["BandedGridViewList"] = bandedGridViewList;
            else
                ds.ExtendedProperties.Add("BandedGridViewList", bandedGridViewList);

            #endregion

            return ds;
        }

        public static DataSet SendQuery(QueryProperties properties)
        {
            try
            {
                DataSet dataSet = null;
                dataSet = QueryManager.QueryBuilder(properties);
                if (dataSet != null)
                {
                    foreach (var p in properties)
                    {
                        if (!dataSet.ExtendedProperties.ContainsKey(p.Key))
                            dataSet.ExtendedProperties.Add(p.Key, p.Value);
                    }

                    DataSet res = Comparing(dataSet);
                    return res;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        private void InitializeForm(QueryProperties qpro)
        {
            this.TableDates = GetDateTable();
            gridDates.DataSource = this.TableDates;
            cboPrimaryColumns.Properties.Items.Clear();
            cboEvaluationType1.Properties.Items.Clear();
            cboEvaluationType2.Properties.Items.Clear();
            cboEvaluationType3.Properties.Items.Clear();
          
            cboEvaluationType1.Properties.Items.Add("", "", -1);
            cboEvaluationType2.Properties.Items.Add("", "", -1);
            cboEvaluationType3.Properties.Items.Add("", "", -1);

            foreach (IComboBoxEditItem item in GetPrimaryColumnsFromXml(qpro["XmlBandMap"].ToString()))
            {
                cboPrimaryColumns.Properties.Items.Add(item);
                cboEvaluationType1.Properties.Items.Add(item.Text, item.Name, -1);
                cboEvaluationType2.Properties.Items.Add(item.Text, item.Name, -1);
                cboEvaluationType3.Properties.Items.Add(item.Text, item.Name, -1);
                if (!qpro.ContainsKey(item.Name))
                    qpro.Add(item.Name, item.Text);
            }

            if (qpro["ReportNo"].ToString() == "109")
                FillReportDates(qpro["SourceID"].ToString(), "100");
            else
                FillReportDates(qpro["SourceID"].ToString(), string.Empty);

            this.Properties = qpro;
            lblMaxDate.Tag = qpro["MaxDateCount"].ToString();
            lblMaxDate.Text = "تعداد مقاطع مجاز قابل انتخاب " + lblMaxDate.Tag;
            txtReportName.Text = qpro["ReportName"].ToString();
            txtReportsList.Text = qpro["ReportName"].ToString();
            pnlCompute.Visible = bool.Parse(qpro["ShowComputePanel"].ToString());
            pnlEvaluations.Visible = bool.Parse(qpro["ShowComputePanel"].ToString());
            if (qpro["PrimaryColumnText"].ToString().Length == 0)
                cboPrimaryColumns.SelectedIndex = cboPrimaryColumns.Properties.Items.Count - 1;
            else
                cboPrimaryColumns.Text = qpro["PrimaryColumnText"].ToString(); 

            if (this.Properties["CompareOrder"].ToString().Length > 0)
                cboCompareOrder.Text = qpro["CompareOrder"].ToString();

            SetCheckedComboBoxEdit(cboComparisonsItems, qpro["CompareItems"].ToString());
            SetCheckedComboBoxEdit(cboEvaluationItems1, qpro["EvaluationItems1"].ToString());
            SetCheckedComboBoxEdit(cboEvaluationItems2, qpro["EvaluationItems2"].ToString());
            SetCheckedComboBoxEdit(cboEvaluationItems3, qpro["EvaluationItems3"].ToString());
            SetCheckedComboBoxEdit(cboOtherEvaluationItems, qpro["OtherEvaluationItems"].ToString());

            cboComparisonsItems_EditValueChanged(null, EventArgs.Empty);
            cboEvaluationType1.Text = qpro["EvaluationType1"].ToString();
            cboEvaluationType2.Text = qpro["EvaluationType2"].ToString();
            cboEvaluationType3.Text = qpro["EvaluationType3"].ToString();

            if (this.Properties["UnitAmount"].ToString().Length > 0)
            {
                cboUnitAmount.Enabled = true;
                cboUnitAmount.Text = this.Properties["UnitAmount"].ToString();
            }
            else
            {
                cboUnitAmount.Enabled = false;
                cboUnitAmount.SelectedIndex = 0;
            }

            List<string> selectedDates = qpro["SelectedDates"].ToString().Split(',').ToList();
            selectedDates.Sort();

            for (int i = 0; i < viewDates.RowCount; i++)
            {
                DataRow dateRow = viewDates.GetDataRow(i);
                if (dateRow != null)
                {
                    string date = dateRow["ReportDate"].ToString().Replace("/", "");
                    string[] counts = this.GetSelectedDates();
                    int left = int.Parse(lblMaxDate.Tag.ToString()) - counts.Length;
                    if (left > 0)
                    {
                        if (selectedDates.Contains(date))
                            viewDates.SetRowCellValue(i, "IsChecked", true);
                        lblMaxDate.Text = "تعداد مقاطع مجاز قابل انتخاب " + left;
                    }
                }
            }
        }

        private int GetCheckedComparisonsItemsCount()
        {
            int count = 0;
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in cboComparisonsItems.Properties.Items)
            {
                if (item.CheckState == CheckState.Checked)
                    ++count;
            }

            return count;
        }

        private void FillReportDates(string sourceId1, string sourceId2)
        {
            List<string> listDates1 = new List<string>();
            List<string> listDates2 = new List<string>();
            List<string> listDatesMatched = new List<string>();

            if (sourceId1.Length > 0)
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase(string.Format("DB_{0}.mdb", sourceId1))))
                {
                    DataTable table = new DataTable();
                    objConn.Open();
                    table = objConn.GetSchema("Tables");
                    listDates1 = table.AsEnumerable().Where(x => x["TABLE_TYPE"].ToString() == "TABLE" & Numeral.IsULong(x["TABLE_NAME"].ToString())).OrderByDescending(x => Numeral.AnyToLong(x["TABLE_NAME"])).Select(r => r["TABLE_NAME"].ToString()).ToList();
                    objConn.Close();
                }
            }

            if (sourceId2.Length > 0)
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase(string.Format("DB_{0}.mdb", sourceId2))))
                {
                    DataTable table = new DataTable();
                    objConn.Open();
                    table = objConn.GetSchema("Tables");
                    listDates2 = table.AsEnumerable().Where(x => x["TABLE_TYPE"].ToString() == "TABLE" & Numeral.IsULong(x["TABLE_NAME"].ToString())).OrderByDescending(x => Numeral.AnyToLong(x["TABLE_NAME"])).Select(r => r["TABLE_NAME"].ToString()).ToList();
                    objConn.Close();
                }
            }

            if (sourceId1.Length > 0 & sourceId2.Length == 0)
            {
                listDatesMatched = listDates1;
            }
            if (sourceId1.Length > 0 & sourceId2.Length > 0)
            {
                foreach (string date in listDates1)
                {
                    if (listDates2.Contains(date))
                        listDatesMatched.Add(date);
                }
            }

            foreach (string date in listDatesMatched)
            {
                if (Numeral.IsULong(date))
                {
                    DataRow row = this.TableDates.NewRow();
                    row["IsChecked"] = false;
                    row["ReportDate"] = date;
                    if (date.Length == 8 & PersianDateTime.IsValidDate(date))
                    {
                        var pd = PersianDateTime.Parse(int.Parse(date));
                        row["ReportDate"] = pd.ToShortDateString();
                        row["Year"] = pd.Year;
                        row["Month"] = pd.Month;
                        row["Day"] = pd.Day;
                        row["WeekdayName"] = pd.GetLongDayOfWeekName;
                        row["IsLastDayOfMonth"] = pd.IsLastDayOfMonth;
                        row["IsLastDayOfYear"] = pd.IsLastDayOfYear;
                        if (PersianDateTime.Now.Year == pd.Year & PersianDateTime.Now.Month == pd.Month)
                            row["Default"] = true;
                    }
                    if (date.Length == 6)
                    {
                        row["ReportDate"] = UDF.GetDateSerialAsFormated(int.Parse(date));
                        row["Year"] = date.Substring(0, 4);
                        row["Month"] = date.Substring(4, 2);
                        row["WeekdayName"] = UDF.GetMonthName(date.Substring(4, 2));
                        row["IsLastDayOfMonth"] = true;
                        if (int.Parse(row["Year"].ToString()) == 12)
                            row["IsLastDayOfYear"] = true;
                    }
                    this.TableDates.Rows.Add(row);
                }
            }

            cboFilterDates_SelectedIndexChanged(null, EventArgs.Empty);
        }

        private string[] GetSelectedDates()
        {
            DataTable table = gridDates.DataSource as DataTable;
            if (table != null)
                return table.AsEnumerable().Where(x => bool.Parse(x["IsChecked"].ToString())).Select(x => x["ReportDate"].ToString().Replace("/", "")).Reverse().ToArray();
            return null;
        }

        static DataTable GetDateTable()
        {
            DataTable table = new DataTable("table1");
            table.Columns.Add("IsChecked", typeof(bool));
            table.Columns.Add("Year", typeof(int));
            table.Columns.Add("Month", typeof(int));
            table.Columns.Add("Day", typeof(int));
            table.Columns.Add("ReportDate", typeof(string));
            table.Columns.Add("WeekdayName", typeof(string));
            table.Columns.Add("IsLastDayOfMonth", typeof(bool));
            table.Columns.Add("IsLastDayOfYear", typeof(bool));
            table.Columns.Add("Default", typeof(bool));
            return table;
        }

        static bool IsMatchRegex(string valid, string test)
        {
            string reg = string.Format("^{0}$|{0}[0-9]$|^{0}[1-9][0-9]$", valid);
            Regex regex = new Regex(reg);
            return regex.IsMatch(test);
        }

        private static List<IComboBoxEditItem> GetPrimaryColumnsFromXml(string xmlBandMap)
        {
            List<IComboBoxEditItem> list = new List<IComboBoxEditItem>();
            if (xmlBandMap.Length > 0)
            {
                XmlDocument xbandMap = new XmlDocument();
                xbandMap.LoadXml(xmlBandMap);
                foreach (XmlNode column in xbandMap.GetElementsByTagName("Column"))
                {
                    IComboBoxEditItem item = new IComboBoxEditItem();
                    item.Name = column.Attributes["Name"].Value;
                    item.Text = column.Attributes["CriteriaText"].Value;
                    item.FormatNumber = column.Attributes["FormatNumber"].Value;
                    if (column.Attributes["ColumnRule"] != null)
                        item.ColumnRuleName = column.Attributes["ColumnRule"].Value;
                    else
                        item.ColumnRuleName = string.Empty;

                    if (column.Attributes["PercentageRule"] != null)
                        item.PercentageRuleName = column.Attributes["PercentageRule"].Value;
                    else
                        item.PercentageRuleName = string.Empty;

                    list.Add(item);
                }
            }

            return list;
        }

        private static List<DateCompare> GetComparisonList(DataTable table, string orderMode, List<DataColumn> primaryColumns)
        {
            List<DataColumn> columns = new List<DataColumn>();
            List<DateCompare> list = new List<DateCompare>();

            foreach (DataColumn col in primaryColumns)
            {
                if (table.Columns[col.ColumnName].Namespace.Length > 0)
                    columns.Add(table.Columns[col.ColumnName]);
            }

            if (columns.Count > 0)
            {
                if (orderMode == "همه مقاطع نسبت به مبدا")
                {
                    for (int i = 0; i < columns.Count; i++)
                    {
                        if (i > 0)
                        {
                            list.Add(new DateCompare { Column1 = columns[0], Column2 = columns[i] });
                        }
                    }
                }

                if (orderMode == "هر مقطع نسبت به مقطع قبل")
                {
                    for (int i = 0; i < columns.Count; i++)
                    {
                        if (i > 0)
                        {
                            list.Add(new DateCompare { Column1 = columns[i - 1], Column2 = columns[i] });
                        }
                    }
                }

                if (orderMode == "هر مقطع نسبت به مقطع قبل و مبدا")
                {
                    for (int i = 0; i < columns.Count; i++)
                    {
                        if (i > 0)
                        {
                            if (i - 1 > 0)
                                list.Add(new DateCompare { Column1 = columns[i - 1], Column2 = columns[i] });
                            list.Add(new DateCompare { Column1 = columns[0], Column2 = columns[i] });
                        }
                    }
                }

                if (orderMode == "فقط مبدا و مقصد")
                {
                    list.Add(new DateCompare { Column1 = columns.First(), Column2 = columns.Last() });
                }
            }
            return list;
        }

        private string GetCheckedComboBoxEdit(CheckedComboBoxEdit control)
        {
            List<string> list = new List<string>();
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem i in control.Properties.Items)
            {
                if (i.CheckState == CheckState.Checked)
                {
                    list.Add(i.Value.ToString());
                }
            }

            return string.Join(",", list.ToArray());
        }

        private void UncheckComboBoxItems(CheckedComboBoxEdit control)
        {
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem i in control.Properties.Items)
            {
                i.CheckState = CheckState.Unchecked;
            }
        }

        private void SetCheckedComboBoxEdit(CheckedComboBoxEdit control, string text)
        {
            List<string> list = new List<string>();
            foreach (string des in text.Split(','))
            {
                list.Add(des);
            }
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem i in control.Properties.Items)
            {
                if (list.Contains(i.Value))
                {
                    i.CheckState = CheckState.Checked;
                }
            }
        }

        private void cboComparisonsItems_EditValueChanged(object sender, EventArgs e)
        {
            cboEvaluationType1.Properties.Items.Clear();
            cboEvaluationType2.Properties.Items.Clear();
            cboEvaluationType3.Properties.Items.Clear();

            cboEvaluationType1.Properties.Items.Add("", "", -1);
            cboEvaluationType2.Properties.Items.Add("", "", -1);
            cboEvaluationType3.Properties.Items.Add("", "", -1);

            foreach (IComboBoxEditItem item in cboPrimaryColumns.Properties.Items)
            {
                cboEvaluationType1.Properties.Items.Add(item.Text, item.Name, -1);
                cboEvaluationType2.Properties.Items.Add(item.Text, item.Name, -1);
                cboEvaluationType3.Properties.Items.Add(item.Text, item.Name, -1);
            }

            foreach (CheckedListBoxItem item in cboComparisonsItems.Properties.Items)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    cboEvaluationType1.Properties.Items.Add(item.Description, item.Value, -1);
                    cboEvaluationType2.Properties.Items.Add(item.Description, item.Value, -1);
                    cboEvaluationType3.Properties.Items.Add(item.Description, item.Value, -1);
                }
            }
        }

        #endregion

    }
}
