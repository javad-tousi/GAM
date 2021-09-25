using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using GAM.Forms.Reports.Master;
using GAM.Forms.Information.Library;

namespace GAM.Forms.Reports.Library
{
    public partial class IChart : UserControl
    {
        public bool ZoomChart { get; set; }
        public string Guid { get; set; }
        public string HeaderText { get; set; }
        public string UnitId { get; set; }
        public IDictionary<int, ISeries.BranchSeries> ISeries1 { get; set; }
        public IDictionary<int, ISeries.BranchSeries> ISeries2 { get; set; }
        public bool ShowProvince { get; set; }
        public int SelectedRadioIndex { get; set; }


        public IChart()
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            this.ZoomChart = true;
        }

        public void ShowChart()
        {
            if (this.UnitId.Length == 0)
                return;

            chartControl.Series.Clear();
            chartControl.Titles[0].Text = this.HeaderText + " - " + Branches.GetUnitNameById(this.UnitId);
            radioGroup.Properties.Items.Clear();
            foreach (var cat in ISeries1.First().Value.Comparisons)
            {
                DevExpress.XtraEditors.Controls.RadioGroupItem rgi = new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "دزصد رشد");
                rgi.Value = cat.Key;
                rgi.Description = cat.Key;
                radioGroup.Properties.Items.Add(rgi);
            }
            radioGroup.SelectedIndex = this.SelectedRadioIndex;
            radioGroup_SelectedIndexChanged(null, EventArgs.Empty);
        }

        private void radioGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox1_CheckedChanged(null, EventArgs.Empty);
            string caption = radioGroup.Properties.Items[radioGroup.SelectedIndex].Value.ToString();
            chartControl.Series.Clear();

            ISeries.BranchSeries branch18 = null;//استان
            ISeries.BranchSeries branchSeries1 = null;//سال جاری
            ISeries.BranchSeries branchSeries2 = null;//سال گذشته
            if (this.ShowProvince && ISeries1 != null)
                branch18 = ISeries1[int.Parse("18")];
            if (ISeries1 != null && ISeries1.ContainsKey(int.Parse(this.UnitId)))
                branchSeries1 = ISeries1[int.Parse(this.UnitId)];
            if (ISeries2 != null && ISeries1.ContainsKey(int.Parse(this.UnitId)))
                branchSeries2 = ISeries2[int.Parse(this.UnitId)];

            if (branchSeries1 == null & branchSeries2 == null)
            {
                chartControl.Titles[0].Text = string.Empty;
                return;
            }

            if (branchSeries1 != null && branchSeries1.Comparisons[caption].Points.Count() > 1)
            {
                double? maxValue = null;
                double? minValue = null;
                string f = branchSeries1.Comparisons[caption].Points.First().Value.Format;
                chartControl.Series.Add(caption, ViewType.Line);
                chartControl.Series.Add(caption, ViewType.Line);
                chartControl.Series.Add(caption, ViewType.Line);

                #region Series Options
                foreach (Series ser in chartControl.Series)//Options
                {
                    XYMarkerWidenAnimation animation = new XYMarkerWidenAnimation();
                    animation.BeginTime = System.TimeSpan.Parse("00:00:00.5000000");
                    ser.ArgumentScaleType = ScaleType.Qualitative;
                    LineSeriesView view = ser.View as LineSeriesView;
                    view.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                    view.LineMarkerOptions.Size = 7;
                    view.SeriesPointAnimation = animation;
                }
                #endregion

                if (branchSeries2 != null)
                {
                    branchSeries2.Visible = true;
                    chartControl.Series[1].View.Color = Color.FromArgb(60, 147, 211);

                    #region Min & Max
                    maxValue = branchSeries2.Comparisons[caption].Points.Max(x => x.Value.Value);
                    minValue = branchSeries2.Comparisons[caption].Points.Min(x => x.Value.Value);
                    #endregion

                    foreach (var item in branchSeries2.Comparisons[caption].Points)
                    {
                        SeriesPoint sp = new SeriesPoint(item.Value.Argument, item.Value.Value);
                        sp.Tag = branchSeries2;
                        chartControl.Series[1].Points.Add(sp);
                    }
                }

                if (branchSeries1 != null)
                {
                    branchSeries1.Visible = true;
                    chartControl.Series[0].View.Color = Color.FromArgb(255, 127, 39);

                    #region Min & Max
                    double max = branchSeries1.Comparisons[caption].Points.Max(x => x.Value.Value);
                    double min = branchSeries1.Comparisons[caption].Points.Min(x => x.Value.Value);
                    if (maxValue == null)
                        maxValue = max;
                    else
                    {
                        if (max > maxValue)
                            maxValue = max;
                    }
                    if (minValue == null)
                        minValue = min;
                    else
                    {
                        if (min < minValue)
                            minValue = min;
                    }
                    #endregion
                    
                    List<TextAnnotation> maxAnnotations = new List<TextAnnotation>();
                    List<TextAnnotation> minAnnotations = new List<TextAnnotation>();

                    foreach (var item in branchSeries1.Comparisons[caption].Points)
                    {
                        SeriesPoint sp = new SeriesPoint(item.Value.Argument, item.Value.Value);
                        sp.Tag = branchSeries1;
                        chartControl.Series[0].Points.Add(sp);
                        if (item.Value.Value == maxValue)
                        {
                            if (!this.ZoomChart & maxAnnotations.Count == 0)
                            {
                                var txtAnn = sp.Annotations.AddTextAnnotation("Max", "Max");
                                maxAnnotations.Add(txtAnn);
                            }
                        }
                        if (item.Value.Value == minValue)
                        {
                            if (!this.ZoomChart & minAnnotations.Count == 0)
                            {
                                var txtAnn = sp.Annotations.AddTextAnnotation("Min", "Min");
                                minAnnotations.Add(txtAnn);
                            }
                        }
                    }
                }

                if (branch18 != null && this.UnitId != "18")
                {
                    chartControl.Series[2].View.Color = Color.LightGray;

                    #region Min & Max
                    double max = branch18.Comparisons[caption].Points.Max(x => x.Value.Value);
                    double min = branch18.Comparisons[caption].Points.Min(x => x.Value.Value);
                    if (maxValue == null)
                        maxValue = max;
                    else
                    {
                        if (max > maxValue)
                            maxValue = max;
                    }
                    if (minValue == null)
                        minValue = min;
                    else
                    {
                        if (min < minValue)
                            minValue = min;
                    }
                    #endregion

                    foreach (var item in branch18.Comparisons[caption].Points)
                    {
                        branch18.Visible = false;
                        SeriesPoint sp = new SeriesPoint(item.Value.Argument, item.Value.Value);
                        sp.Tag = branch18;
                        chartControl.Series[2].Points.Add(sp);
                    }
                }

                #region Diagram Options
                if (chartControl.Diagram != null)
                {
                    XYDiagram xyDiagram = chartControl.Diagram as XYDiagram;
                    xyDiagram.AxisY.WholeRange.MaxValue = maxValue.Value;
                    xyDiagram.AxisY.WholeRange.MinValue = minValue.Value;
                    xyDiagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                    xyDiagram.AxisY.Title.Text = caption;
                    xyDiagram.AxisY.Label.TextPattern = "{V:" + f + "}";

                    foreach (Series ser in chartControl.Series)
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

            this.SelectedRadioIndex = radioGroup.SelectedIndex;
        }

        private void chartControl_CustomDrawCrosshair(object sender, CustomDrawCrosshairEventArgs e)
        {
            foreach (CrosshairElementGroup crosshairGroup in e.CrosshairElementGroups)
            {
                foreach (CrosshairElement crosshairElement in crosshairGroup.CrosshairElements)
                {
                    CrosshairLabelElement labelElement = crosshairElement.LabelElement;
                    labelElement.MarkerSize = new System.Drawing.Size(0, 0);
                    SeriesPoint sp = crosshairElement.SeriesPoint;
                    if (sp.Tag != null)
                    {
                        ISeries.BranchSeries brSer = sp.Tag as ISeries.BranchSeries;
                        StringBuilder sb = new StringBuilder();

                        #region محاسبه طول نوع سری
                        int len = 0;
                        foreach (var cat in brSer.Comparisons)
                        {
                            if (cat.Value.Points.ContainsKey(sp.Argument))
                            {
                                var i = cat.Value.Points[sp.Argument].Caption.Length;
                                if (i > len)
                                {
                                    len = i;
                                }
                            }
                        }
                        #endregion

                        #region نمایش نوع سری انتخاب شده بعنوان اولین
                        foreach (var cat in brSer.Comparisons)
                        {
                            if (cat.Key == crosshairElement.Series.Name)
                            {
                                if (cat.Value.Points.ContainsKey(sp.Argument))
                                {
                                    if (brSer.Year.Length > 0)
                                        sb.AppendLine("(" + brSer.Year + ")");

                                    var i = cat.Value.Points[sp.Argument];
                                    sb.Append(string.Format("{0}\t\t{1}", InsertSpace(cat.Value.Points[sp.Argument].Caption, len), i.Value.ToString(i.Format)));
                                }
                            }
                        }
                        #endregion

                        #region نمایش سایر نوع سری ها
                        foreach (var cat in brSer.Comparisons)
                        {
                            if (cat.Key != crosshairElement.Series.Name)
                            {
                                if (cat.Value.Points.ContainsKey(sp.Argument))
                                {
                                    var i = cat.Value.Points[sp.Argument];
                                    if (sb.Length > 0)
                                        sb.Append(string.Format("\n{0}\t\t{1}", InsertSpace(cat.Value.Points[sp.Argument].Caption, len), i.Value.ToString(i.Format)));
                                    else
                                        sb.Append(string.Format("{0}\t\t{1}", InsertSpace(cat.Value.Points[sp.Argument].Caption, len), i.Value.ToString(i.Format)));
                                }
                            }
                        }
                        #endregion

                        if (sb.Length > 0)
                        {
                            if (brSer.Visible)
                                crosshairElement.Series.CrosshairLabelPattern = sb.ToString();
                            else
                                crosshairElement.Series.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.False;
                        }
                    }
                }
            }
        }

        private string InsertSpace(string text, int len)
        {
            string str = text;
            for (int i = 0; i < len - text.Length; i++)
            {
                str = "  " + str;
            }
            return str;
        }

        private void chartControl_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ZoomChart)
                {
                    IChart chart = new IChart();
                    chart.ZoomChart = false;
                    chart.chartControl.Cursor = System.Windows.Forms.Cursors.Default;
                    chart.Dock = DockStyle.Fill;
                    chart.HeaderText = this.HeaderText;
                    chart.UnitId = this.UnitId;
                    chart.ISeries1 = this.ISeries1;
                    chart.ISeries2 = this.ISeries2;
                    chart.ShowProvince = this.ShowProvince;
                    chart.SelectedRadioIndex = radioGroup.SelectedIndex;
                    chart.ShowChart();

                    XtraForm dlg = new XtraForm();
                    dlg.MinimizeBox = false;
                    dlg.TopMost = true;
                    dlg.Text = "نمودار " + this.HeaderText;
                    dlg.Size = new Size(652, 364);
                    dlg.LookAndFeel.SkinName = "Office 2016 Colorful";
                    dlg.LookAndFeel.UseDefaultLookAndFeel = false;
                    dlg.Controls.Add(chart);
                    dlg.Show();
                }
            }
            catch
            {
            }
        }

        private void groupControl_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            XYDiagram xyDiagram = chartControl.Diagram as XYDiagram;

            foreach (Series ser in chartControl.Series)
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

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            chartControl.ExportToImage("D:\\" + UnitId + ".png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
