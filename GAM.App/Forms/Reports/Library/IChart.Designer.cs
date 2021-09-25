namespace GAM.Forms.Reports.Library
{
    partial class IChart
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IChart));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.RectangleGradientFillOptions rectangleGradientFillOptions1 = new DevExpress.XtraCharts.RectangleGradientFillOptions();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.radioGroup = new DevExpress.XtraEditors.RadioGroup();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnSaveImage = new DevExpress.XtraEditors.SimpleButton();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.chartControl = new DevExpress.XtraCharts.ChartControl();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.radioGroup, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.checkBox1, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.btnSaveImage, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.checkBox2, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 303);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(576, 30);
            this.tableLayoutPanel.TabIndex = 7;
            // 
            // radioGroup
            // 
            this.radioGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroup.Location = new System.Drawing.Point(193, 2);
            this.radioGroup.Margin = new System.Windows.Forms.Padding(1, 2, 0, 1);
            this.radioGroup.Name = "radioGroup";
            this.radioGroup.Properties.AllowFocused = false;
            this.radioGroup.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.radioGroup.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroup.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup.Properties.Appearance.Options.UseFont = true;
            this.radioGroup.Properties.ItemHorzAlignment = DevExpress.XtraEditors.RadioItemHorzAlignment.Near;
            this.radioGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "عملکرد"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "درصدرشد")});
            this.radioGroup.Properties.ItemsLayout = DevExpress.XtraEditors.RadioGroupItemsLayout.Flow;
            this.radioGroup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioGroup.Size = new System.Drawing.Size(383, 27);
            this.radioGroup.TabIndex = 4;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox1.Location = new System.Drawing.Point(116, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(73, 24);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "برچسب ها";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveImage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveImage.ImageOptions.Image")));
            this.btnSaveImage.Location = new System.Drawing.Point(1, 2);
            this.btnSaveImage.Margin = new System.Windows.Forms.Padding(1, 2, 0, 1);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(22, 27);
            toolTipTitleItem1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem1.Appearance.Options.UseImage = true;
            toolTipTitleItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem1.Image")));
            toolTipTitleItem1.Text = "راهنما";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "با نام کد واحد D:\\ ذخیره تصویر در ابتدای";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnSaveImage.SuperTip = superToolTip1;
            this.btnSaveImage.TabIndex = 6;
            this.btnSaveImage.Visible = false;
            // 
            // checkBox2
            // 
            this.checkBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox2.Location = new System.Drawing.Point(26, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(84, 24);
            this.checkBox2.TabIndex = 7;
            this.checkBox2.Text = "مسئول واحد";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            // 
            // chartControl
            // 
            this.chartControl.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnLoad;
            this.chartControl.CrosshairOptions.CrosshairLabelTextOptions.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartControl.CrosshairOptions.GroupHeaderPattern = "{A}";
            this.chartControl.CrosshairOptions.GroupHeaderTextOptions.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chartControl.DataBindings = null;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Title.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.EnableAxisXScrolling = true;
            xyDiagram1.EnableAxisXZooming = true;
            xyDiagram1.EnableAxisYScrolling = true;
            xyDiagram1.EnableAxisYZooming = true;
            this.chartControl.Diagram = xyDiagram1;
            this.chartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Gradient;
            rectangleGradientFillOptions1.GradientMode = DevExpress.XtraCharts.RectangleGradientMode.TopLeftToBottomRight;
            this.chartControl.FillStyle.Options = rectangleGradientFillOptions1;
            this.chartControl.Legend.Name = "Default Legend";
            this.chartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl.Location = new System.Drawing.Point(0, 0);
            this.chartControl.Name = "chartControl";
            series1.Name = "Series 1";
            series1.View = lineSeriesView1;
            this.chartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl.Size = new System.Drawing.Size(576, 303);
            this.chartControl.TabIndex = 8;
            // 
            // IChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartControl);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "IChart";
            this.Size = new System.Drawing.Size(576, 333);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private DevExpress.XtraEditors.RadioGroup radioGroup;
        private System.Windows.Forms.CheckBox checkBox1;
        private DevExpress.XtraEditors.SimpleButton btnSaveImage;
        private System.Windows.Forms.CheckBox checkBox2;
        public DevExpress.XtraCharts.ChartControl chartControl;


    }
}
