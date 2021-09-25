namespace GAM.Forms.Reports.Etebarat.Requests
{
    partial class dlgChart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgChart));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            this.pnlBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExportToImage = new DevExpress.XtraEditors.SimpleButton();
            this.chartControl = new DevExpress.XtraCharts.ChartControl();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExportToImage);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 406);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlBottom.Size = new System.Drawing.Size(743, 36);
            this.pnlBottom.TabIndex = 201;
            this.pnlBottom.Text = "flowLayoutPanel1";
            // 
            // btnExportToImage
            // 
            this.btnExportToImage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToImage.ImageOptions.Image")));
            this.btnExportToImage.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnExportToImage.Location = new System.Drawing.Point(640, 3);
            this.btnExportToImage.Name = "btnExportToImage";
            this.btnExportToImage.Size = new System.Drawing.Size(100, 30);
            this.btnExportToImage.TabIndex = 1;
            this.btnExportToImage.Text = "دریافت تصویر";
            this.btnExportToImage.Click += new System.EventHandler(this.btnExportToImage_Click);
            // 
            // chartControl
            // 
            this.chartControl.DataBindings = null;
            xyDiagram1.AxisX.Label.Angle = 90;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.EnableAxisXScrolling = true;
            xyDiagram1.EnableAxisXZooming = true;
            this.chartControl.Diagram = xyDiagram1;
            this.chartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl.Legend.Name = "Default Legend";
            this.chartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl.Location = new System.Drawing.Point(0, 0);
            this.chartControl.Name = "chartControl";
            sideBySideBarSeriesLabel1.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            sideBySideBarSeriesLabel1.Position = DevExpress.XtraCharts.BarSeriesLabelPosition.Top;
            sideBySideBarSeriesLabel1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series1.Label = sideBySideBarSeriesLabel1;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "Series 1";
            sideBySideBarSeriesView1.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(241)))), ((int)(((byte)(221)))));
            sideBySideBarSeriesView1.Border.Visibility = DevExpress.Utils.DefaultBoolean.True;
            sideBySideBarSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(187)))), ((int)(((byte)(89)))));
            sideBySideBarSeriesView1.Shadow.Color = System.Drawing.Color.Gainsboro;
            sideBySideBarSeriesView1.Shadow.Size = 3;
            sideBySideBarSeriesView1.Shadow.Visible = true;
            series1.View = sideBySideBarSeriesView1;
            this.chartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl.Size = new System.Drawing.Size(743, 406);
            this.chartControl.TabIndex = 202;
            // 
            // dlgChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 442);
            this.Controls.Add(this.chartControl);
            this.Controls.Add(this.pnlBottom);
            this.Name = "dlgChart";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnExportToImage;
        public DevExpress.XtraCharts.ChartControl chartControl;
    }
}