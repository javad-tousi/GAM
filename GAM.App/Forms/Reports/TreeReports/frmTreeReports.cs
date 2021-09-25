using DevExpress.Diagram.Core;
using DevExpress.XtraDiagram;
using DevExpress.XtraNavBar;
using DevExpress.XtraTab;
using DevExpress.XtraVerticalGrid.Rows;
using GAM.Forms.Information.Library;
using GAM.Forms.Profile.Kargozini.Library;
using GAM.Forms.Reports.Library;
using GAM.Modules;
using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Reports.OperationalReports
{
    public partial class frmTreeReports : DevExpress.XtraEditors.XtraForm
    {
        DataSet MainReports = new DataSet();
        string UnitId = string.Empty;
        string ReportDate = string.Empty;
        List<DiagramShape> ShapesList = new List<DiagramShape>();
        public frmTreeReports()
        {
            InitializeComponent();
            diagramShape1.Tag = null;
            diagramShape2.Tag = 303;
            diagramShape3.Tag = 2110;
            diagramShape4.Tag = 1501;
            diagramShape5.Tag = 2130;
            diagramShape6.Tag = 2160;
            diagramShape7.Tag = 2140;
            diagramShape8.Tag = 2170;
            diagramShape9.Tag = 2180;
            diagramShape10.Tag = 101;
            diagramShape11.Tag = 102;
            diagramShape12.Tag = 1501;
            diagramShape13.Tag = 1607;
            diagramShape14.Tag = 1601;
            diagramShape15.Tag = 1602;
            diagramShape16.Tag = 1603;
            diagramShape17.Tag = 201;
            diagramShape18.Tag = 202;
            diagramShape19.Tag = 150303;
            diagramShape20.Tag = 1502;
            diagramShape21.Tag = 1608;
            diagramShape22.Tag = 2211;
            diagramShape23.Tag = 1103;
            diagramShape24.Tag = 1104;
            diagramShape25.Tag = 1106;
            diagramShape26.Tag = 1105;
            this.ShapesList.Add(diagramShape2);
            this.ShapesList.Add(diagramShape3);
            this.ShapesList.Add(diagramShape5);
            this.ShapesList.Add(diagramShape6);
            this.ShapesList.Add(diagramShape7);
            this.ShapesList.Add(diagramShape8);
            this.ShapesList.Add(diagramShape9);

            Startup();
        }

        #region Colors
        Color ColorGreen = System.Drawing.Color.FromArgb(60, 179, 113);
        Color ColorBlue = System.Drawing.Color.FromArgb(0, 191, 255);
        Color ColorYellow = System.Drawing.Color.FromArgb(255, 255, 0);
        Color ColorOrange = System.Drawing.Color.FromArgb(255, 192, 0);
        Color ColorRed = System.Drawing.Color.FromArgb(255, 69, 0);
        #endregion

        #region Events
   
        private void pnlMain_SizeChanged(object sender, EventArgs e)
        {
            pnlGrid.SplitterPosition = 1080;
        }

        private void diagramControl_MouseDown(object sender, MouseEventArgs e)
        {
            DiagramControl diagram = sender as DiagramControl;
            DiagramShape item = diagramControl1.CalcHitItem(e.Location) as DiagramShape;
            if (item != null && item.Tag != null)
            {

            }
        }

        private void diagramControl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Default;
            DiagramControl diagram = sender as DiagramControl;
            DiagramShape item = diagramControl1.CalcHitItem(e.Location) as DiagramShape;

            if (item != null && item.Tag != null)
            {
                Cursor.Current = Cursors.Hand;
            }
        }

        private void btnPlans_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnPlan1.Enabled = true;
            btnPlan2.Enabled = true;
            btnPlan3.Enabled = true;
            btnPlan4.Enabled = true;
            btnPlan5.Enabled = true;
            btnPlan6.Enabled = true;
            btnPlan7.Enabled = true;

            if (sender == null)
                return;
            if ((NavBarItem)sender == btnPlan1)
            {
                btnPlan1.Enabled = false;
                tabControlMain.SelectedTabPageIndex = 0;
            }
            if ((NavBarItem)sender == btnPlan2)
            {
                btnPlan2.Enabled = false;
                tabControlMain.SelectedTabPageIndex = 1;
            }
            if ((NavBarItem)sender == btnPlan3)
            {
                btnPlan3.Enabled = false;
                tabControlMain.SelectedTabPageIndex = 2;
            }
            if ((NavBarItem)sender == btnPlan4)
            {
                btnPlan4.Enabled = false;
                tabControlMain.SelectedTabPageIndex = 3;
            }
            if ((NavBarItem)sender == btnPlan5)
            {
                btnPlan5.Enabled = false;
                tabControlMain.SelectedTabPageIndex = 4;
            } 
            if ((NavBarItem)sender == btnPlan6)
            {
                btnPlan6.Enabled = false;
                tabControlMain.SelectedTabPageIndex = 5;
            } 
            if ((NavBarItem)sender == btnPlan7)
            {
                btnPlan7.Enabled = false;
                tabControlMain.SelectedTabPageIndex = 6;
            }
        }

        private void treeBranches_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                vGridControl.Rows.Clear();

                if (Branches.IsBranch(e.Node.Name))
                {
                    Branches.BranchInfo bi =  Branches.GetBranchById(e.Node.Name, false);
                    tabFlowchart1.Text = "چارت سودآوری " + "(شعبه " + bi.BranchName + ")";
                  
                    vGridControl.Rows.Add(AddCatRow("مشخصات اصلی"));
                    vGridControl.Rows.Add(AddHERow("Unit", "", bi));
                    vGridControl.Rows.Add(AddERow("UnitId", "کد", bi.BranchId));
                    vGridControl.Rows.Add(AddERow("UnitName", "نام", bi.BranchName));
                    vGridControl.Rows.Add(AddERow("BranchDegree", "درجه", bi.BranchDegree));
                    DataRow r = PersonelsManager.GetEmployeeInBranchByPostId(int.Parse(bi.BranchId), 35997);
                    if (r != null)
                    {
                        vGridControl.Rows.Add(AddCatRow("اطلاعات مسئول"));
                        vGridControl.Rows.Add(AddERow("FullName", "نام مسئول", r["FullName"].ToString()));
                        if (PersianDateTime.IsValidDate(r["DateNewBranch"].ToString()))
                            vGridControl.Rows.Add(AddERow("DateNewBranch", "تاریخ جابجایی", PersianDateTime.Parse(int.Parse(r["DateNewBranch"].ToString())).ToShortDateString()));
                        if (PersianDateTime.IsValidDate(r["DateNewPost"].ToString()))
                            vGridControl.Rows.Add(AddERow("DateNewPost", "تاریخ تغییر پست", PersianDateTime.Parse(int.Parse(r["DateNewPost"].ToString())).ToShortDateString()));
                    }
                }
                else if (Branches.IsDomain(e.Node.Name))
                {
                    Branches.DomainInfo di = Branches.GetDomainById(e.Node.Name, true);
                    tabFlowchart1.Text = "چارت سودآوری " + "(" + di.DomainName + ")";

                    vGridControl.Rows.Add(AddCatRow("مشخصات اصلی"));
                    vGridControl.Rows.Add(AddHERow("Unit", "", di));
                    vGridControl.Rows.Add(AddERow("UnitId", "کد", di.DomainId));
                    vGridControl.Rows.Add(AddERow("UnitName", "نام", di.DomainName));
                    DataRow r = PersonelsManager.GetEmployeeInBranchByPostId(int.Parse(di.DomainId), 30100);
                    if (r != null)
                    {
                        vGridControl.Rows.Add(AddCatRow("اطلاعات مسئول"));
                        vGridControl.Rows.Add(AddERow("FullName", "نام مسئول", r["FullName"].ToString()));
                        if (PersianDateTime.IsValidDate(r["DateNewBranch"].ToString()))
                            vGridControl.Rows.Add(AddERow("DateNewBranch", "تاریخ جابجایی", PersianDateTime.Parse(int.Parse(r["DateNewBranch"].ToString())).ToShortDateString()));
                        if (PersianDateTime.IsValidDate(r["DateNewPost"].ToString()))
                            vGridControl.Rows.Add(AddERow("DateNewPost", "تاریخ تغییر پست", PersianDateTime.Parse(int.Parse(r["DateNewPost"].ToString())).ToShortDateString()));
                    }
                }
                else if (Branches.IsProvince(e.Node.Name))
                {
                    Branches.ProvinceInfo pi = Branches.GetProvinceById(e.Node.Name);
                    tabFlowchart1.Text = "چارت سودآوری استان " + "(" + pi.ProvinceName + ")";

                    vGridControl.Rows.Add(AddCatRow("مشخصات اصلی"));
                    vGridControl.Rows.Add(AddHERow("Unit", "", pi));
                    vGridControl.Rows.Add(AddERow("UnitId", "کد", pi.ProvinceId));
                    vGridControl.Rows.Add(AddERow("UnitName", "نام", pi.ProvinceName));
                    DataRow r = PersonelsManager.GetEmployeeInBranchByPostId(int.Parse(pi.ProvinceId), 20101);
                    if (r != null)
                    {
                        vGridControl.Rows.Add(AddCatRow("اطلاعات مسئول"));
                        vGridControl.Rows.Add(AddERow("FullName", "نام مسئول", r["FullName"].ToString()));
                        if (PersianDateTime.IsValidDate(r["DateNewBranch"].ToString()))
                            vGridControl.Rows.Add(AddERow("DateNewBranch", "تاریخ جابجایی", PersianDateTime.Parse(int.Parse(r["DateNewBranch"].ToString())).ToShortDateString()));
                        if (PersianDateTime.IsValidDate(r["DateNewPost"].ToString()))
                            vGridControl.Rows.Add(AddERow("DateNewPost", "تاریخ تغییر پست", PersianDateTime.Parse(int.Parse(r["DateNewPost"].ToString())).ToShortDateString()));
                    }
                }
                this.UnitId = e.Node.Name;
                FillFlowchart();
            }
        }
     
        private void navBarControl_MouseDown(object sender, MouseEventArgs e)
        {
            var hitiInfo = navBarControl.CalcHitInfo(e.Location);
            if (hitiInfo.InLink && hitiInfo.Link.Group == mnuDates)
            {
                foreach (NavBarItemLink i in mnuDates.ItemLinks)
                {
                    if (i == hitiInfo.Link)
                    {
                        i.Item.Enabled = false;
                        this.ReportDate = i.Item.Tag.ToString();
                        FillFlowchart();
                    }
                    else
                        i.Item.Enabled = true;
                }
            }
        }

        #endregion

        #region Methods

        private void Startup() 
        {
            this.MainReports = TreeReportManager.GetTables();
            foreach (DataTable table in MainReports.Tables)
            {
                NavBarItem item = new NavBarItem();
                item.Caption = UDF.GetDateString(table.TableName);
                item.Tag = table;
                mnuDates.ItemLinks.Add(item);
            }
            if (mnuDates.ItemLinks.Count > 0)
            {
                this.ReportDate = mnuDates.ItemLinks[0].Item.Tag.ToString();
                mnuDates.ItemLinks[0].Item.Enabled = false;
            }
            FillTreeBranches();
            treeBranches.SelectedNode = treeBranches.Nodes[0];
        }

        private void FillFlowchart()
        {
            if (this.UnitId.Length > 0 & this.ReportDate.Length > 0)
            {
                DataTable dt = this.MainReports.Tables[this.ReportDate];
                dt.DefaultView.RowFilter = "BranchID=" + this.UnitId;
                if (dt.DefaultView.Count == 1)
                {
                    DataRow row = dt.DefaultView[0].Row;
                    foreach (DiagramShape shape in this.ShapesList)
                    {
                        shape.Appearance.ForeColor = Color.White;
                        string id = shape.Tag.ToString();
                        string columnName = "V" + id + "_PercentOfGoal";
                        if (row.Table.Columns.Contains(columnName))
                        {
                            double value = Numeral.AnyToDouble(row[columnName]);
                            if (value <= 20)
                                shape.Appearance.BackColor = this.ColorRed;
                            if (value > 20 & value < 40)
                                shape.Appearance.BackColor = this.ColorOrange;
                            if (value >= 40 & value < 60)
                                shape.Appearance.BackColor = this.ColorYellow;
                            if (value >= 60 & value < 80)
                                shape.Appearance.BackColor = this.ColorBlue;
                            if (value >= 80)
                                shape.Appearance.BackColor = this.ColorGreen;
                        }


                        if (shape.Appearance.BackColor == this.ColorYellow)
                        {
                            shape.Appearance.ForeColor = Color.Black;
                        }
                    }
                }

            }
        }

        private void FillTreeBranches()
        {
            treeBranches.Nodes.Add(Branches.GetMyProvince().ProvinceId, Branches.GetMyProvince().ProvinceName);
            foreach (Branches.DomainInfo di in Branches.GetDomains())
            {
                TreeNode tree = treeBranches.Nodes[0].Nodes.Add(di.DomainId, di.DomainName);
                foreach (Branches.BranchInfo br in Branches.GetBranchesByDomainId(di.DomainId))
                {
                    tree.Nodes.Add(br.BranchId, br.BranchName);
                }
            }
        }

        private EditorRow AddERow(string name, string caption, string value)
        {
            EditorRow row = new EditorRow();
            row.Properties.Caption = caption;
            row.Properties.Value = value;
            row.Properties.FieldName = name;
            return row;
        }
        private EditorRow AddHERow(string name, string caption, object value)
        {
            EditorRow row = new EditorRow();
            row.Properties.Caption = caption;
            row.Properties.Value = value;
            row.Properties.FieldName = name;
            row.Visible = false;
            return row;
        }

        private CategoryRow AddCatRow(string caption)
        {
            CategoryRow row = new CategoryRow();
            row.Properties.Caption = caption;
            return row;
        }
        
        #endregion

    }
}
