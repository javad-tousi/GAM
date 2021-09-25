using GAM.Forms.Information.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Reports.Master
{
    public partial class frmIChartView : DevExpress.XtraEditors.XtraForm
    {
        string SelectedBranchId;

        public frmIChartView()
        {
            InitializeComponent();
        }

        public void Run() 
        {
            FillTreeBranches();
            lblReportName.Text = this.Text;
            treeBranches.Focus();
            treeBranches.Select();
            this.Show();
        }

        public void ProgressMax(int value)
        {
            progressBar.Properties.Maximum = value;
        }

        public int ProgressOn(int value)
        {
            Application.DoEvents();
            if (value < 100)
            {
                progressBar.Show();
                progressBar.EditValue = value;
            }
            else 
            {
                progressBar.EditValue = 0;
                progressBar.Hide();
            }
            Application.DoEvents();
            return value;
        }

        public void AddSeries(string caption, Dictionary<string, double> series)
        {
           int serIndex = chartControl.Series.Add(caption, DevExpress.XtraCharts.ViewType.Line);
           foreach (var ser in series)
           {
               DevExpress.XtraCharts.SeriesPoint point = new DevExpress.XtraCharts.SeriesPoint(ser.Key, ser.Value);
               chartControl.Series[serIndex].Points.Add(point);
           }

            #region Series Options
            foreach (DevExpress.XtraCharts.Series ser in chartControl.Series)//Options
            {
                DevExpress.XtraCharts.XYMarkerWidenAnimation animation = new DevExpress.XtraCharts.XYMarkerWidenAnimation();
                animation.BeginTime = System.TimeSpan.Parse("00:00:00.5000000");
                ser.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
                DevExpress.XtraCharts.LineSeriesView view = ser.View as DevExpress.XtraCharts.LineSeriesView;
                view.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                view.LineMarkerOptions.Size = 7;
                view.SeriesPointAnimation = animation;
            }
            #endregion
        
            #region Diagram Options
            if (chartControl.Diagram != null)
            {
                DevExpress.XtraCharts.XYDiagram xyDiagram = chartControl.Diagram as DevExpress.XtraCharts.XYDiagram;
                //xyDiagram.AxisY.WholeRange.MaxValue = maxValue.Value;
                //xyDiagram.AxisY.WholeRange.MinValue = minValue.Value;
                xyDiagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                xyDiagram.AxisY.Title.Text = caption;
                xyDiagram.AxisY.Label.TextPattern = "{V:" + "  " + "}";

                foreach (DevExpress.XtraCharts.Series ser in chartControl.Series)
                {
                    if (checkBox1.Checked)
                    {
                        ser.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        ser.Label.TextPattern = xyDiagram.AxisY.Label.TextPattern;
                        ser.Label.Font = new Font("Tahoma", 10);
                    }
                    else
                    {
                        ser.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
                    }
                }
            }
            #endregion

        }

        public void AddPoint(string serName, string date, double value)
        {
            if (chartControl.Series[serName] == null)
            {
                chartControl.Series.Add(serName, DevExpress.XtraCharts.ViewType.Line);
                var ser = chartControl.Series[serName];
                DevExpress.XtraCharts.XYMarkerWidenAnimation animation = new DevExpress.XtraCharts.XYMarkerWidenAnimation();
                animation.BeginTime = System.TimeSpan.Parse("00:00:00.5000000");
                ser.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
                DevExpress.XtraCharts.LineSeriesView view = ser.View as DevExpress.XtraCharts.LineSeriesView;
                view.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                view.LineMarkerOptions.Size = 7;
                view.SeriesPointAnimation = animation;

                DevExpress.XtraCharts.SeriesPoint point = new DevExpress.XtraCharts.SeriesPoint(date, value);
                chartControl.Series[serName].Points.Add(point);
            }
            else 
            {
                DevExpress.XtraCharts.SeriesPoint point = new DevExpress.XtraCharts.SeriesPoint(date, value);
                chartControl.Series[serName].Points.Add(point);
            }

            Application.DoEvents();

            #region Diagram Options
            if (chartControl.Diagram != null)
            {
                DevExpress.XtraCharts.XYDiagram xyDiagram = chartControl.Diagram as DevExpress.XtraCharts.XYDiagram;
                //xyDiagram.AxisY.WholeRange.MaxValue = maxValue.Value;
                //xyDiagram.AxisY.WholeRange.MinValue = minValue.Value;
                xyDiagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                //xyDiagram.AxisY.Title.Text = caption;
                xyDiagram.AxisY.Label.TextPattern = "{V:" + "  " + "}";

                foreach (DevExpress.XtraCharts.Series ser in chartControl.Series)
                {
                    if (checkBox1.Checked)
                    {
                        ser.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                        ser.Label.TextPattern = xyDiagram.AxisY.Label.TextPattern;
                        ser.Label.Font = new Font("Tahoma", 10);
                    }
                    else
                    {
                        ser.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
                    }
                }
            }
            #endregion

        }

        private void FillTreeBranches()
        {
            TreeNode masterNode = treeBranches.Nodes.Add(Branches.GetMyProvince().ProvinceId, Branches.GetMyProvince().ProvinceName);
            if (Branches.GetMyProvince().ProvinceId == SelectedBranchId)
                treeBranches.SelectedNode = masterNode;

            foreach (Branches.DomainInfo di in Branches.GetDomains())
            {
                TreeNode tree = treeBranches.Nodes[0].Nodes.Add(di.DomainId, di.DomainName);
                if (di.DomainId == SelectedBranchId)
                    treeBranches.SelectedNode = tree;

                foreach (Branches.BranchInfo br in Branches.GetBranchesByDomainId(di.DomainId))
                {
                    TreeNode node = tree.Nodes.Add(br.BranchId, br.BranchName);

                    if (br.BranchId == SelectedBranchId)
                        treeBranches.SelectedNode = node;
                }
            }
        }

        private void frmIChartView_SizeChanged(object sender, EventArgs e)
        {
            pnlGrid.SplitterPosition = 1000;
        }
    }
}
