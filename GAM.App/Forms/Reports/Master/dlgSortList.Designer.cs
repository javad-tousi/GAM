namespace GAM.Forms.Reports.Master
{
    partial class dlgSortList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgSortList));
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions2 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions3 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.group1 = new DevExpress.XtraEditors.GroupControl();
            this.list1 = new DevExpress.XtraEditors.ImageListBoxControl();
            this.group2 = new DevExpress.XtraEditors.GroupControl();
            this.list2 = new DevExpress.XtraEditors.ImageListBoxControl();
            this.pnlBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnShiftAllToLeft = new DevExpress.XtraEditors.SimpleButton();
            this.btnHelp = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.group1)).BeginInit();
            this.group1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.list1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.group2)).BeginInit();
            this.group2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.list2)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoScroll = true;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.group1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.group2, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.63314F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(506, 375);
            this.tableLayoutPanel.TabIndex = 4;
            // 
            // group1
            // 
            this.group1.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("group1.CaptionImageOptions.Image")));
            this.group1.Controls.Add(this.list1);
            buttonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions1.Image")));
            this.group1.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Button", false, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, false, null, true, false, true, null, -1)});
            this.group1.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.group1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group1.Location = new System.Drawing.Point(256, 3);
            this.group1.Name = "group1";
            this.group1.Size = new System.Drawing.Size(247, 369);
            this.group1.TabIndex = 0;
            this.group1.Text = "ترتیب نمایش فعلی";
            // 
            // list1
            // 
            this.list1.AllowDrop = true;
            this.list1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.list1.Appearance.Options.UseFont = true;
            this.list1.Cursor = System.Windows.Forms.Cursors.Default;
            this.list1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list1.Location = new System.Drawing.Point(2, 29);
            this.list1.Name = "list1";
            this.list1.Size = new System.Drawing.Size(243, 338);
            this.list1.TabIndex = 1;
            this.list1.DoubleClick += new System.EventHandler(this.list1_DoubleClick);
            // 
            // group2
            // 
            this.group2.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("group2.CaptionImageOptions.Image")));
            this.group2.Controls.Add(this.list2);
            buttonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions2.Image")));
            buttonImageOptions3.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions3.Image")));
            this.group2.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("پایین", true, buttonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("بالا", true, buttonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1)});
            this.group2.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.group2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group2.Location = new System.Drawing.Point(3, 3);
            this.group2.Name = "group2";
            this.group2.Size = new System.Drawing.Size(247, 369);
            this.group2.TabIndex = 2;
            this.group2.Text = "ترتیب نمایش جدید";
            this.group2.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.group2_CustomButtonClick);
            // 
            // list2
            // 
            this.list2.AllowDrop = true;
            this.list2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.list2.Appearance.Options.UseFont = true;
            this.list2.Cursor = System.Windows.Forms.Cursors.Default;
            this.list2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list2.Location = new System.Drawing.Point(2, 29);
            this.list2.Name = "list2";
            this.list2.Size = new System.Drawing.Size(243, 338);
            this.list2.TabIndex = 1;
            this.list2.DoubleClick += new System.EventHandler(this.list2_DoubleClick);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnOk);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnShiftAllToLeft);
            this.pnlBottom.Controls.Add(this.btnHelp);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 375);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlBottom.Size = new System.Drawing.Size(506, 33);
            this.pnlBottom.TabIndex = 5;
            // 
            // btnOk
            // 
            this.btnOk.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Appearance.Options.UseFont = true;
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnOk.Location = new System.Drawing.Point(379, 2);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(124, 28);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "اعمال تغییرات";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(257, 2);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 28);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnShiftAllToLeft
            // 
            this.btnShiftAllToLeft.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShiftAllToLeft.Appearance.Options.UseFont = true;
            this.btnShiftAllToLeft.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnShiftAllToLeft.ImageOptions.Image")));
            this.btnShiftAllToLeft.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnShiftAllToLeft.Location = new System.Drawing.Point(94, 2);
            this.btnShiftAllToLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.btnShiftAllToLeft.Name = "btnShiftAllToLeft";
            this.btnShiftAllToLeft.Size = new System.Drawing.Size(157, 28);
            this.btnShiftAllToLeft.TabIndex = 7;
            this.btnShiftAllToLeft.Text = "انتقال همه به جدول خروجی";
            this.btnShiftAllToLeft.Click += new System.EventHandler(this.btnShiftAllToLeft_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Appearance.Options.UseFont = true;
            this.btnHelp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.ImageOptions.Image")));
            this.btnHelp.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnHelp.Location = new System.Drawing.Point(3, 2);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(85, 28);
            this.btnHelp.TabIndex = 6;
            this.btnHelp.Text = "رهنما";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // dlgChangeTabs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 408);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.pnlBottom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgChangeTabs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جابجایی صفحات گزارش";
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.group1)).EndInit();
            this.group1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.list1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.group2)).EndInit();
            this.group2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.list2)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private DevExpress.XtraEditors.GroupControl group1;
        private DevExpress.XtraEditors.GroupControl group2;
        private DevExpress.XtraEditors.ImageListBoxControl list2;
        private DevExpress.XtraEditors.ImageListBoxControl list1;
        private System.Windows.Forms.FlowLayoutPanel pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnHelp;
        private DevExpress.XtraEditors.SimpleButton btnShiftAllToLeft;
    }
}