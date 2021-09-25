using GAM.Dialogs;
using GAM.Forms.Information.Library;
using GAM.Forms.Settings.Library;
using GAM.Forms.Reports.Etebarat.Requests;
using GAM.Forms.Profile.Etebarat.Library;
using GAM.Forms.Profile.Etebarat.Print;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using GAM.Modules;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraNavBar;
using System.Collections;
using DevExpress.XtraTab;
using GAM.Forms.Information;

namespace GAM.Forms.Reports.Etebarat.Requests
{
    public partial class frmRequestsReports : DevExpress.XtraEditors.XtraForm
    {
        public frmRequestsReports()
        {
            InitializeComponent();
            PersianDate now = Network.GetNowPersianDate();
            now.Day = 1;
            txtFromDate.Value = now;
            txtToDate.Value = Network.GetNowPersianDate();

            chklistRequestStatus.Items.Add(RequestStatus.Barasi);
            chklistRequestStatus.Items.Add(RequestStatus.Eghdam, CheckState.Checked);
            chklistRequestStatus.Items.Add(RequestStatus.Odat);
            chklistRequestStatus.Items.Add(RequestStatus.Ebtal);
            chklistRequestStatus.Items.Add(RequestStatus.Mosavab, CheckState.Checked);
            chklistRequestStatus.Items.Add(RequestStatus.Mokhalefat);
            chklistRequestStatus.Items.Add(RequestStatus.Gharardad, CheckState.Checked);

            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
            Application.DoEvents();
            DataTable table = Facilitys.GetFacilitys();
            for (int i = 0; i < table.Rows.Count; i++)
                table.Rows[i]["IsChecked"] = false;
            gridControl.DataSource = table;
            (gridControl.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);

            txtSearch.Select();
            Modules.UDF.ToFarsiLanguage();
        }

        #region Query Buttons
      
        private void btnQuery1_ItemClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            GridControl gc = tabControl.SelectedTabPage.Tag as GridControl;
            if (gc == null)
                return;

            DataTable source = gc.DataSource as DataTable;

            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn { ColumnName = "FacilityName", Caption = "نوع تسهیلات/تعهدات", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "Count", Caption = "تعداد", DataType = typeof(double) });
            table.Columns.Add(new DataColumn { ColumnName = "RequestAmount", Caption = "مبلغ قرارداد", DataType = typeof(double) });

            var flist = source.AsEnumerable().Select(x => new { FacilityId = x["FacilityID"].ToString(), FacilityName = x["FacilityName"].ToString() }).Distinct().ToDictionary(x => x.FacilityId, x => x.FacilityName); ;
            foreach (var id in flist)
            {
                DataRow[] rows = source.Select(string.Format("FacilityID={0}", id.Key));
                if (rows != null)
                {
                    DataRow newrow = table.NewRow();
                    newrow["FacilityName"] = id.Value;
                    newrow["Count"] = rows.Count();
                    newrow["RequestAmount"] = rows.Sum(x => Numeral.AnyToDouble(x["RequestAmount"]));
                    table.Rows.Add(newrow);
                }
            }

            if (table.Rows.Count > 0)
            {
                var query = table.AsEnumerable();
                table.Rows.Add("جمع کل", query.Sum(x => Numeral.AnyToDouble(x["Count"])), query.Sum(x => Numeral.AnyToDouble(x["RequestAmount"])));
            }

            new dlgShowReport(table, tabControl.SelectedTabPage.Text).ShowDialog();
        }

        private void btnQuery2_ItemClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            GridControl gc = tabControl.SelectedTabPage.Tag as GridControl;
            if (gc == null)
                return;

            DataTable source = gc.DataSource as DataTable;

            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn { ColumnName = "FacilityName", Caption = "نوع تسهیلات/تعهدات", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "Count1", Caption = "تعداد انفرادی", DataType = typeof(double) });
            table.Columns.Add(new DataColumn { ColumnName = "Sum1", Caption = "مبلغ انفرادی", DataType = typeof(double) });
            table.Columns.Add(new DataColumn { ColumnName = "Count2", Caption = "تعداد گروهی", DataType = typeof(double) });
            table.Columns.Add(new DataColumn { ColumnName = "Sum2", Caption = "مبلغ گروهی", DataType = typeof(double) });
            table.Columns.Add(new DataColumn { ColumnName = "Count", Caption = "تعداد کل", DataType = typeof(double) });
            table.Columns.Add(new DataColumn { ColumnName = "Sum", Caption = "مبلغ کل", DataType = typeof(double) });

            var flist = source.AsEnumerable().Select(x => new { FacilityId = x["FacilityID"].ToString(), FacilityName = x["FacilityName"].ToString() }).Distinct().ToDictionary(x => x.FacilityId, x => x.FacilityName); ;
            foreach (var id in flist)
            {
                DataRow[] rows = source.Select(string.Format("FacilityID={0}", id.Key));
                if (rows != null)
                {
                    DataRow newrow = table.NewRow();
                    newrow["FacilityName"] = id.Value;
                    newrow["Count1"] = rows.Where(x => Numeral.AnyToDouble(x["CustomersCount"]) == 1).Count();
                    newrow["Count2"] = rows.Where(x => Numeral.AnyToDouble(x["CustomersCount"]) > 1).Count();
                    newrow["Sum1"] = rows.Where(x => Numeral.AnyToDouble(x["CustomersCount"]) == 1).Sum(x => Convert.ToDouble(x["RequestAmount"]));
                    newrow["Sum2"] = rows.Where(x => Numeral.AnyToDouble(x["CustomersCount"]) > 1).Sum(x => Convert.ToDouble(x["RequestAmount"]));
                    newrow["Count"] = rows.Count();
                    newrow["Sum"] = rows.Sum(x => Convert.ToDouble(x["RequestAmount"]));
                    table.Rows.Add(newrow);
                }
            }

            if (table.Rows.Count > 0)
            {
                var query = table.AsEnumerable();
                table.Rows.Add("جمع کل", query.Sum(x => Numeral.AnyToDouble(x["Count1"])), query.Sum(x => Numeral.AnyToDouble(x["Sum1"])), query.Sum(x => Numeral.AnyToDouble(x["Count2"])), query.Sum(x => Numeral.AnyToDouble(x["Sum2"])), query.Sum(x => Numeral.AnyToDouble(x["Count"])), query.Sum(x => Numeral.AnyToDouble(x["Sum"])));
            }

            new dlgShowReport(table, tabControl.SelectedTabPage.Text).ShowDialog();
        }

        private void btnQuery3_ItemClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            GridControl gc = tabControl.SelectedTabPage.Tag as GridControl;
            if (gc == null)
                return;

            DataTable source = gc.DataSource as DataTable;

            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn { ColumnName = "CategoryName", Caption = "دسته بندی", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "Count", Caption = "تعداد", DataType = typeof(double) });
            table.Columns.Add(new DataColumn { ColumnName = "Sum", Caption = "مبلغ قرارداد", DataType = typeof(double) });

            string[] categories = source.AsEnumerable().Select(x => x["Category"].ToString()).Distinct().ToArray();
          
            foreach (string cat in categories)
            {
                DataRow[] rows = source.Select(string.Format("Category='{0}'", cat));
                if (rows != null)
                {
                    DataRow newrow = table.NewRow();
                    newrow["CategoryName"] = cat;
                    newrow["Count"] = rows.Count();
                    newrow["Sum"] = rows.Sum(x => Convert.ToDouble(x["RequestAmount"]));
                    table.Rows.Add(newrow);
                }
            }

            if (table.Rows.Count > 0)
            {
                var query = table.AsEnumerable();
                table.Rows.Add("جمع کل", query.Sum(x => Numeral.AnyToDouble(x["Count"])), query.Sum(x => Numeral.AnyToDouble(x["Sum"])));
            }

            new dlgShowReport(table, tabControl.SelectedTabPage.Text).ShowDialog();
        }

        private void btnQuery4_ItemClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            GridControl gc = tabControl.SelectedTabPage.Tag as GridControl;
            if (gc == null)
                return;

            DataTable source = gc.DataSource as DataTable;

            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn { ColumnName = "DomainId", Caption = "کد", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "DomainName", Caption = "نام حوزه", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "Count", Caption = "تعداد", DataType = typeof(double) });
            table.Columns.Add(new DataColumn { ColumnName = "RequestAmount", Caption = "مبلغ قرارداد", DataType = typeof(double) });

            
            foreach (Branches.DomainInfo di in Branches.GetDomains())
            {
                DataRow[] rows = source.Select(string.Format("DomainID={0}", di.DomainId));
                if (rows != null)
                {
                    DataRow newrow = table.NewRow();
                    newrow["DomainId"] = di.DomainId;
                    newrow["DomainName"] = di.DomainName;
                    newrow["Count"] = rows.Count();
                    newrow["RequestAmount"] = rows.Sum(x => Numeral.AnyToDouble(x["RequestAmount"]));
                    table.Rows.Add(newrow);
                }
            }

            if (table.Rows.Count > 0)
            {
                var query = table.AsEnumerable();
                table.Rows.Add("*", "جمع کل", query.Sum(x => Numeral.AnyToDouble(x["Count"])), query.Sum(x => Numeral.AnyToDouble(x["RequestAmount"])));
            }

            new dlgShowReport(table, tabControl.SelectedTabPage.Text).ShowDialog();
        }
     
        private void btnQuery5_ItemClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            GridControl gc = tabControl.SelectedTabPage.Tag as GridControl;
            if (gc == null)
                return;

            DataTable source = gc.DataSource as DataTable;

            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn { ColumnName = "DomainId", Caption = "کد", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "DomainName", Caption = "نام حوزه", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "FacilityName", Caption = "نوع تسهیلات/تعهدات", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "Count", Caption = "تعداد", DataType = typeof(double) });
            table.Columns.Add(new DataColumn { ColumnName = "RequestAmount", Caption = "مبلغ قرارداد", DataType = typeof(double) });

            var flist = source.AsEnumerable().Select(x => new { FacilityId = x["FacilityID"].ToString(), FacilityName = x["FacilityName"].ToString() }).Distinct().ToDictionary(x => x.FacilityId, x => x.FacilityName); ;

            foreach (Branches.DomainInfo di in Branches.GetDomains())
            {
                foreach (var id in flist)
                {
                    DataRow[] rows = source.Select(string.Format("DomainID={0} AND FacilityID={1}", di.DomainId, id.Key));
                    if (rows != null)
                    {
                        DataRow newrow = table.NewRow();
                        newrow["DomainId"] = di.DomainId;
                        newrow["DomainName"] = di.DomainName;
                        newrow["FacilityName"] = id.Value;
                        newrow["Count"] = rows.Count();
                        newrow["RequestAmount"] = rows.Sum(x => Numeral.AnyToDouble(x["RequestAmount"]));
                        table.Rows.Add(newrow);
                    }
                }
            }
            if (table.Rows.Count > 0)
            {
                var query = table.AsEnumerable();
                table.Rows.Add("*", "", "جمع کل", query.Sum(Col => Numeral.AnyToDouble(Col["Count"])), query.Sum(Col => Numeral.AnyToDouble(Col["RequestAmount"])));
            }

            new dlgShowReport(table, tabControl.SelectedTabPage.Text).ShowDialog();
        }

        private void btnQuery6_ItemClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            GridControl gc = tabControl.SelectedTabPage.Tag as GridControl;
            if (gc == null)
                return;

            DataTable source = gc.DataSource as DataTable;

            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn { ColumnName = "DomainId", Caption = "کد", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "DomainName", Caption = "نام حوزه", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "Count1", Caption = "تعداد انفرادی", DataType = typeof(double) });
            table.Columns.Add(new DataColumn { ColumnName = "Sum1", Caption = "مبلغ انفرادی", DataType = typeof(double) });
            table.Columns.Add(new DataColumn { ColumnName = "Count2", Caption = "تعداد گروهی", DataType = typeof(double) });
            table.Columns.Add(new DataColumn { ColumnName = "Sum2", Caption = "مبلغ گروهی", DataType = typeof(double) });
            table.Columns.Add(new DataColumn { ColumnName = "Count", Caption = "تعداد کل", DataType = typeof(double) });
            table.Columns.Add(new DataColumn { ColumnName = "Sum", Caption = "مبلغ کل", DataType = typeof(double) });


            foreach (Branches.DomainInfo di in Branches.GetDomains())
            {
                DataRow[] rows = source.Select(string.Format("DomainID={0}", di.DomainId));
                if (rows != null)
                {
                    DataRow newrow = table.NewRow();
                    newrow["DomainId"] = di.DomainId;
                    newrow["DomainName"] = di.DomainName;
                    newrow["Count1"] = rows.Where(x => Numeral.AnyToDouble(x["CustomersCount"]) == 1).Count();
                    newrow["Count2"] = rows.Where(x => Numeral.AnyToDouble(x["CustomersCount"]) > 1).Count();
                    newrow["Sum1"] = rows.Where(x => Numeral.AnyToDouble(x["CustomersCount"]) == 1).Sum(x => Convert.ToDouble(x["RequestAmount"]));
                    newrow["Sum2"] = rows.Where(x => Numeral.AnyToDouble(x["CustomersCount"]) > 1).Sum(x => Convert.ToDouble(x["RequestAmount"]));
                    newrow["Count"] = rows.Count();
                    newrow["Sum"] = rows.Sum(x => Convert.ToDouble(x["RequestAmount"]));
                    table.Rows.Add(newrow);
                }
            }

            if (table.Rows.Count > 0)
            {
                var query = table.AsEnumerable();
                table.Rows.Add("*", "جمع کل", query.Sum(x => Numeral.AnyToDouble(x["Count1"])), query.Sum(x => Numeral.AnyToDouble(x["Sum1"])), query.Sum(x => Numeral.AnyToDouble(x["Count2"])), query.Sum(x => Numeral.AnyToDouble(x["Sum2"])), query.Sum(x => Numeral.AnyToDouble(x["Count"])), query.Sum(x => Numeral.AnyToDouble(x["Sum"])));
            }

            new dlgShowReport(table, tabControl.SelectedTabPage.Text).ShowDialog();
        }

        private void btnQuery7_ItemClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            GridControl gc = tabControl.SelectedTabPage.Tag as GridControl;
            if (gc == null)
                return;

            DataTable source = gc.DataSource as DataTable;

            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn { ColumnName = "DomainId", Caption = "کد", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "DomainName", Caption = "نام حوزه", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "BranchId", Caption = "کد", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "BranchName", Caption = "نام شعبه", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "BranchDegree", Caption = "درجه", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "Count", Caption = "تعداد", DataType = typeof(double) });
            table.Columns.Add(new DataColumn { ColumnName = "RequestAmount", Caption = "مبلغ قرارداد", DataType = typeof(double) });


            foreach (Branches.BranchInfo bi in Branches.GetAllBranchs())
            {
                if (!bi.BranchType.Contains("شعبه"))
                    continue;

                DataRow[] rows = source.Select(string.Format("BranchID={0}", bi.BranchId));
                if (rows != null)
                {
                    DataRow newrow = table.NewRow();
                    newrow["DomainId"] = bi.Domain.DomainId;
                    newrow["DomainName"] = bi.Domain.DomainName;
                    newrow["BranchId"] = bi.BranchId;
                    newrow["BranchName"] = bi.BranchName;
                    newrow["BranchDegree"] = bi.BranchDegree;
                    newrow["Count"] = rows.Count();
                    newrow["RequestAmount"] = rows.Sum(x => Numeral.AnyToDouble(x["RequestAmount"]));
                    table.Rows.Add(newrow);
                }
            }

            if (table.Rows.Count > 0)
            {
                var query = table.AsEnumerable();
                table.Rows.Add("*", "", "", "", "جمع کل", query.Sum(Col => Numeral.AnyToDouble(Col["Count"])), query.Sum(Col => Numeral.AnyToDouble(Col["RequestAmount"])));
            }

            new dlgShowReport(table, tabControl.SelectedTabPage.Text).ShowDialog();
        }

        private void btnQuery8_ItemClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            GridControl gc = tabControl.SelectedTabPage.Tag as GridControl;
            if (gc == null)
                return;

            DataTable source = gc.DataSource as DataTable;

            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn { ColumnName = "DomainId", Caption = "کد", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "DomainName", Caption = "نام حوزه", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "BranchId", Caption = "کد", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "BranchName", Caption = "نام شعبه", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "BranchDegree", Caption = "درجه", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "FacilityName", Caption = "نوع تسهیلات/تعهدات", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "Count", Caption = "تعداد", DataType = typeof(double) });
            table.Columns.Add(new DataColumn { ColumnName = "RequestAmount", Caption = "مبلغ قرارداد", DataType = typeof(double) });

            var flist = source.AsEnumerable().Select(x => new { FacilityId = x["FacilityID"].ToString(), FacilityName = x["FacilityName"].ToString() }).Distinct().ToDictionary(x => x.FacilityId, x => x.FacilityName); ;

            foreach (Branches.BranchInfo bi in Branches.GetAllBranchs())
            {
                if (!bi.BranchType.Contains("شعبه"))
                    continue;
                foreach (var id in flist)
                {
                    DataRow[] rows = source.Select(string.Format("BranchID={0} AND FacilityID={1}", bi.BranchId, id.Key));
                    if (rows != null)
                    {
                        DataRow newrow = table.NewRow();
                        newrow["DomainId"] = bi.Domain.DomainId;
                        newrow["DomainName"] = bi.Domain.DomainName;
                        newrow["BranchId"] = bi.BranchId;
                        newrow["BranchName"] = bi.BranchName;
                        newrow["BranchDegree"] = bi.BranchDegree;
                        newrow["FacilityName"] = id.Value;
                        newrow["Count"] = rows.Count();
                        newrow["RequestAmount"] = rows.Sum(x => Numeral.AnyToDouble(x["RequestAmount"]));
                        table.Rows.Add(newrow);
                    }
                }
            }

            if (table.Rows.Count > 0)
            {
                var query = table.AsEnumerable();
                table.Rows.Add("*", "", "", "", "", "جمع کل", query.Sum(x => Numeral.AnyToDouble(x["Count"])), query.Sum(x => Numeral.AnyToDouble(x["RequestAmount"])));
            }

            new dlgShowReport(table, tabControl.SelectedTabPage.Text).ShowDialog();
        }

        private void btnQuery9_ItemClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            GridControl gc = tabControl.SelectedTabPage.Tag as GridControl;
            if (gc == null)
                return;

            DataTable source = gc.DataSource as DataTable;

            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn { ColumnName = "DomainId", Caption = "کد", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "DomainName", Caption = "نام حوزه", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "BranchId", Caption = "کد", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "BranchName", Caption = "نام شعبه", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "BranchDegree", Caption = "درجه", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "Count1", Caption = "تعداد انفرادی", DataType = typeof(double) });
            table.Columns.Add(new DataColumn { ColumnName = "Sum1", Caption = "مبلغ انفرادی", DataType = typeof(double) });
            table.Columns.Add(new DataColumn { ColumnName = "Count2", Caption = "تعداد گروهی", DataType = typeof(double) });
            table.Columns.Add(new DataColumn { ColumnName = "Sum2", Caption = "مبلغ گروهی", DataType = typeof(double) });
            table.Columns.Add(new DataColumn { ColumnName = "Count", Caption = "تعداد کل", DataType = typeof(double) });
            table.Columns.Add(new DataColumn { ColumnName = "Sum", Caption = "مبلغ کل", DataType = typeof(double) });

            foreach (Branches.BranchInfo bi in Branches.GetAllBranchs())
            {
                if (!bi.BranchType.Contains("شعبه"))
                    continue;

                DataRow[] rows = source.Select(string.Format("BranchID={0}", bi.BranchId));
                if (rows != null)
                {
                    DataRow newrow = table.NewRow();
                    newrow["DomainId"] = bi.Domain.DomainId;
                    newrow["DomainName"] = bi.Domain.DomainName;
                    newrow["BranchId"] = bi.BranchId;
                    newrow["BranchName"] = bi.BranchName;
                    newrow["BranchDegree"] = bi.BranchDegree;
                    newrow["Count1"] = rows.Where(x => Numeral.AnyToDouble(x["CustomersCount"]) == 1).Count();
                    newrow["Count2"] = rows.Where(x => Numeral.AnyToDouble(x["CustomersCount"]) > 1).Count();
                    newrow["Sum1"] = rows.Where(x => Numeral.AnyToDouble(x["CustomersCount"]) == 1).Sum(x => Convert.ToDouble(x["RequestAmount"]));
                    newrow["Sum2"] = rows.Where(x => Numeral.AnyToDouble(x["CustomersCount"]) > 1).Sum(x => Convert.ToDouble(x["RequestAmount"]));
                    newrow["Count"] = rows.Count();
                    newrow["Sum"] = rows.Sum(x => Convert.ToDouble(x["RequestAmount"]));
                    table.Rows.Add(newrow);
                }
            }

            if (table.Rows.Count > 0)
            {
                var query = table.AsEnumerable();
                table.Rows.Add("*", "", "", "", "جمع کل", query.Sum(x => Numeral.AnyToDouble(x["Count1"])), query.Sum(x => Numeral.AnyToDouble(x["Sum1"])), query.Sum(x => Numeral.AnyToDouble(x["Count2"])), query.Sum(x => Numeral.AnyToDouble(x["Sum2"])), query.Sum(x => Numeral.AnyToDouble(x["Count"])), query.Sum(x => Numeral.AnyToDouble(x["Sum"])));
            }

            new dlgShowReport(table, tabControl.SelectedTabPage.Text).ShowDialog();
        }

        private void btnQuery10_ItemClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            GridControl gc = tabControl.SelectedTabPage.Tag as GridControl;
            if (gc == null)
                return;

            DataTable source = gc.DataSource as DataTable;

            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn { ColumnName = "ExpertId", Caption = "کد", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "ExpertName", Caption = "نام کارشناس", DataType = typeof(string) });
            table.Columns.Add(new DataColumn { ColumnName = "Count", Caption = "تعداد", DataType = typeof(double) });

            var users = source.AsEnumerable().Select(x => new { ExpertId = x["ExpertID"].ToString(), ExpertName = x["ExpertName"].ToString() }).Distinct().ToDictionary(x => x.ExpertId, x => x.ExpertName); ;
         
            foreach (var id in users)
            {
                DataRow[] rows = source.Select(string.Format("ExpertID={0}", id.Key));
                if (rows != null)
                {
                    DataRow newrow = table.NewRow();
                    newrow["ExpertId"] = id.Key;
                    newrow["ExpertName"] = id.Value;
                    newrow["Count"] = rows.Count();
                    table.Rows.Add(newrow);
                }
            }

            if (table.Rows.Count > 0)
            {
                var query = table.AsEnumerable();
                table.Rows.Add("*", "جمع کل", query.Sum(x => Numeral.AnyToDouble(x["Count"])));
            }

            new dlgShowReport(table, tabControl.SelectedTabPage.Text).ShowDialog();
        }

        private void btnChart1_ItemClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            GridControl gc = tabControl.SelectedTabPage.Tag as GridControl;
            if (gc == null)
                return;

            DataTable source = gc.DataSource as DataTable;
            dlgChart dlg = new dlgChart();

            var list = source.AsEnumerable().GroupBy(r => new { BranchID = r["BranchID"], BranchName = r["BranchName"] })
            .Select(g => new
            {
                BranchID = g.Key.BranchID,
                BranchName = g.Key.BranchName,
                Count = g.Count(),
            }).OrderBy(x => x.Count);
        
            foreach (var i in list)
                dlg.chartControl.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint(i.BranchName, i.Count));
            dlg.ShowDialog();
        }

        private void btnChart2_ItemClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            GridControl gc = tabControl.SelectedTabPage.Tag as GridControl;
            if (gc == null)
                return;

            DataTable source = gc.DataSource as DataTable;
            dlgChart dlg = new dlgChart();

            var list = source.AsEnumerable().GroupBy(r => new { BranchID = r["BranchID"], BranchName = r["BranchName"] })
            .Select(g => new
            {
                BranchID = g.Key.BranchID,
                BranchName = g.Key.BranchName,
                SumOfRequestAmount = g.Sum(x => Numeral.AnyToDouble(x["RequestAmount"])),
            }).OrderBy(x => x.SumOfRequestAmount);
           
            foreach (var i in list)
                dlg.chartControl.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint(i.BranchName, i.SumOfRequestAmount / 1000));
            dlg.ShowDialog();
        }

        #endregion Query Buttons

        public void AddGridTabPage(string tabText, DataTable dt)
        {
            Dictionary<string, string> columns = new Dictionary<string, string>();
            columns.Add("ModifiedDate2", "تاریخ تغییرات");
            columns.Add("RequestStatus", "وضعیت پیشنهاد");
            columns.Add("CreditCommittee", "کمیته اعتباری");
            columns.Add("RequestID2", "شماره پیشنهاد");
            columns.Add("RequestType", "نوع پیشنهاد");
            columns.Add("DomainID", "کد حوزه");
            columns.Add("DomainName", "نام حوزه");
            columns.Add("BranchName", "نام شعبه");
            columns.Add("CustomerName", "نام مشتری");
            columns.Add("Category", "دسته بندی");
            columns.Add("FacilityName", "نوع تسهیلات");
            columns.Add("CustomersCount", "تعداد");
            columns.Add("RequestAmount", "مبلغ");
            columns.Add("FileID", "ش.پرونده");

            string[] facilitys = (gridControl.DataSource as DataTable).Rows.Cast<DataRow>().Where(x => bool.Parse(x["IsChecked"].ToString())).Select(x => x["FacilityId"].ToString()).ToArray();

            if (facilitys.Contains("0"))
                columns.Add("RequestPlane", "نوع سرفصل");
            if (txtConditions.TextLength > 0)
                columns.Add("Conditions", "شرایط مصوبه");
            if (chklistCreditCommittee.GetItemChecked(3))
            {
                columns.Add("ProvinceLetterNo", "ش.پیشنهاد استان");
                columns.Add("ProvinceLetterDate2", "تاریخ پیشنهاد");
                columns.Add("TehranLetterNo", "ش.مصوبه تهران");
                columns.Add("TehranLetterDate2", "تاریخ تصویب");
                columns.Add("TehranApprovedAmount", "مبلغ تصویب");
                columns.Add("TehranCreditCommittee", "کمیته اعتباری (تهران)");
            }

            GridControl gc = new GridControl();
            gc.Name = "gridControl";
            gc.LookAndFeel.UseDefaultLookAndFeel = false;
            gc.LookAndFeel.SkinName = "Office 2007 Silver";
            gc.DataSource = dt;

            GridView gv = new GridView();
            gv.Name = dt.TableName;
            gv.OptionsView.ColumnAutoWidth = false;
     
            gv.Appearance.HeaderPanel.Font = new System.Drawing.Font("B Yekan", 8.5F);
            gv.Appearance.HeaderPanel.Options.UseFont = true;
          
            gv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        
            gv.Appearance.Row.Font = new System.Drawing.Font("B Yekan", 8.5F);
            gv.Appearance.Row.Options.UseFont = true;

            gv.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gv.Appearance.Row.Options.UseTextOptions = true;

            gv.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            gv.Appearance.VertLine.Options.UseBackColor = true;

            gv.DetailHeight = 700;
            gv.OptionsBehavior.ReadOnly = true;
            gv.OptionsView.ShowGroupPanel = false;
            gc.MainView = gv;

            foreach (var col in columns)
            {
                GridColumn newCol = new GridColumn();
                newCol.FieldName = col.Key;
                newCol.Caption = col.Value;
                newCol.Visible = true;
                newCol.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
                newCol.AppearanceCell.Options.UseBackColor = false;
                newCol.AppearanceCell.Options.UseTextOptions = true;
                newCol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                newCol.AppearanceHeader.Options.UseTextOptions = true;
                newCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                newCol.OptionsColumn.AllowEdit = false;

                if (col.Key == "RequestAmount" | col.Key == "CustomersCount" | col.Key == "TehranApprovedAmount")
                {
                    newCol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    newCol.DisplayFormat.FormatString = "n0";
                }
                if (col.Key == "ModifiedDate")
                {
                    newCol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    newCol.DisplayFormat.FormatString = "0000/00/00";
                }
                if (col.Key == "RequestID2")
                {
                    newCol.OptionsColumn.AllowEdit = true;
                }
                gv.Columns.Add(newCol);
            }
           
            gc.Dock = System.Windows.Forms.DockStyle.Fill;

            DevExpress.XtraTab.XtraTabPage tabPage = new DevExpress.XtraTab.XtraTabPage();
            tabPage.Tag = gc;
            tabPage.Text = tabText;
            tabPage.Controls.Add(gc);
            tabControl.TabPages.Add(tabPage);
            tabControl.SelectedTabPage = tabPage;
            gv.BestFitColumns();
        }

        private void tabControl_CloseButtonClick(object sender, EventArgs e)
        {
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs arg = e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs;
            tabControl.TabPages.Remove((arg.Page as XtraTabPage));
        }

        private void tabControl_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (e.Page != null && tabControl.SelectedTabPageIndex > 0)
            {
                foreach (NavBarItemLink item in navBarGroup.ItemLinks)
                    item.Item.Enabled = true;
            }
            else 
            {
                if (tabControl.SelectedTabPageIndex == 0)
                {
                    foreach (NavBarItemLink item in navBarGroup.ItemLinks)
                        item.Item.Enabled = false;
                }
            }
        }

        private void btnExportToXlsx_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (tabControl.SelectedTabPageIndex >= 0)
            {
                if (tabControl.SelectedTabPage.Tag != null)
                {
                    GridControl gc = (GridControl)tabControl.SelectedTabPage.Tag;
                    btnExportToXlsx.Enabled = false;
                    Application.DoEvents();
                    DevExportToXlsx.SaveAs((GridView)gc.MainView);
                    btnExportToXlsx.Enabled = true;
                }
            }
        }

        private void btnAddTabReport_Click(object sender, EventArgs e)
        {
            if (txtFromDate.Value.HasValue & txtToDate.Value.HasValue)
            {
                int dateFrom = int.Parse(txtFromDate.GetText("yyyyMMdd"));
                int dateTo = int.Parse(txtToDate.GetText("yyyyMMdd"));
                if (dateTo >= dateFrom)
                {
                    if (chklistCustomersCount.CheckedItemsCount > 0 & chklistRequestStatus.CheckedItemsCount > 0 & chklistRequestType.CheckedItemsCount > 0)
                    {
                        btnAddTabReport.Enabled = false;

                        Application.DoEvents();
                        string[] facilitys = (gridControl.DataSource as DataTable).Rows.Cast<DataRow>().Where(x => bool.Parse(x["IsChecked"].ToString())).Select(x => x["FacilityId"].ToString()).ToArray();
                        string[] creditCommittee = chklistCreditCommittee.CheckedItems.Cast<DevExpress.XtraEditors.Controls.CheckedListBoxItem>().Select(x => "'" + x.Value.ToString() + "'").ToArray();
                        string[] requestTypeItems = chklistRequestType.CheckedItems.Cast<DevExpress.XtraEditors.Controls.CheckedListBoxItem>().Select(x => "'" + x.Value.ToString() + "'").ToArray();
                        string[] requestCustomersCountItems = chklistCustomersCount.CheckedItems.Cast<DevExpress.XtraEditors.Controls.CheckedListBoxItem>().Select(x => x.Value.ToString()).ToArray();
                        string[] requestStatusItems = chklistRequestStatus.CheckedItems.Cast<DevExpress.XtraEditors.Controls.CheckedListBoxItem>().Select(x => "'" + x.Value.ToString() + "'").ToArray();

                        DataTable table = RequestManager.LoadParametrs(dateFrom, dateTo, creditCommittee, requestTypeItems, requestCustomersCountItems, requestStatusItems, facilitys, txtConditions.Text);
                        btnAddTabReport.Enabled = true;
                        if (table != null && table.Rows.Count > 0)
                        {
                            string tabText = "گزارش";
                            if (facilitys.Count() == 1)
                                tabText = Facilitys.GetFacilityNameById(facilitys.First());
                            if (facilitys.Count() > 1)
                                tabText = Facilitys.GetFacilityNameById(facilitys.First()) + ",...";

                            AddGridTabPage(tabText, table);
                            this.Hide();
                        }
                        else
                            DevExpress.XtraEditors.XtraMessageBox.Show("متاسفانه اطلاعاتی براساس داده های ورودی یافت نشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً پارامترهای ورودی را کامل نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    DevExpress.XtraEditors.XtraMessageBox.Show("تاریخ مقصد می بایست کوچکتر از تاریخ مبدا باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("لطفا مقادیر تاریخ را وارد نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void gridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                string value = gridView.GetRowCellValue(e.RowHandle, "IsChecked").ToString();
                if (value == bool.TrueString)
                    e.Appearance.BackColor2 = System.Drawing.Color.Aquamarine;
            }
        }

        private void txtSearch_EditValueChanged(object sender, System.EventArgs e)
        {
            if (gridControl.DataSource != null)
            {
                if (Numeral.IsNumber(txtSearch.Text))
                {
                    string criteria = string.Format("CONVERT(FacilityID, 'System.String') = {0}", txtSearch.Text);
                    (gridControl.DataSource as DataTable).DefaultView.RowFilter = criteria;
                }
                else
                {
                    string criteria = string.Format("FacilityName LIKE '%{0}%'", txtSearch.Text);
                    (gridControl.DataSource as DataTable).DefaultView.RowFilter = criteria;
                }
            }
        }

        private void txtSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Image image1 = DevExpress.Images.ImageResourceCache.Default.GetImage("images/filter%20elements/checkbuttons_16x16.png");
            Image image2 = DevExpress.Images.ImageResourceCache.Default.GetImage("images/scheduling/changestatus_16x16.png");

            if (e.Button == txtSearch.Properties.Buttons[0])
            {
                if (bool.FalseString == txtSearch.Properties.Buttons[0].Tag.ToString())
                {
                    txtSearch.Properties.Buttons[0].Tag = true;
                    txtSearch.Properties.Buttons[0].ImageOptions.Image = image2;
                    for (int i = 0; i < gridView.RowCount; i++)
                        gridView.SetRowCellValue(i, "IsChecked", true);

                }
                else
                {
                    txtSearch.Properties.Buttons[0].Tag = false;
                    txtSearch.Properties.Buttons[0].ImageOptions.Image = image1;
                    for (int i = 0; i < gridView.RowCount; i++)
                        gridView.SetRowCellValue(i, "IsChecked", false);
                }

            }
            if (e.Button == txtSearch.Properties.Buttons[1])
            {
                txtSearch.ResetText();
                txtSearch.Select();
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                gridView.Focus();
            }
        }
    }
}