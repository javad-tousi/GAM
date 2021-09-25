namespace GAM.Forms.Settings
{
    partial class frmPublicMessage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPublicMessage));
            this.lblMessageCategory = new System.Windows.Forms.Label();
            this.btnSubmitQuery = new DevExpress.XtraEditors.SimpleButton();
            this.lblMessageText = new System.Windows.Forms.Label();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.cboMessageCategory = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.txtMessageText = new DevExpress.XtraEditors.MemoEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listUsers = new DevExpress.XtraEditors.ImageListBoxControl();
            this.lblTitel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddUsers = new DevExpress.XtraEditors.SimpleButton();
            this.btnClearList = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMessageCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessageText.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listUsers)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessageCategory
            // 
            this.lblMessageCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessageCategory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblMessageCategory.Location = new System.Drawing.Point(584, 27);
            this.lblMessageCategory.Name = "lblMessageCategory";
            this.lblMessageCategory.Size = new System.Drawing.Size(54, 27);
            this.lblMessageCategory.TabIndex = 136;
            this.lblMessageCategory.Text = "نوع پـیام";
            this.lblMessageCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSubmitQuery
            // 
            this.btnSubmitQuery.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSubmitQuery.Appearance.Options.UseFont = true;
            this.tableLayoutPanel1.SetColumnSpan(this.btnSubmitQuery, 2);
            this.btnSubmitQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSubmitQuery.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSubmitQuery.ImageOptions.Image")));
            this.btnSubmitQuery.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnSubmitQuery.Location = new System.Drawing.Point(23, 450);
            this.btnSubmitQuery.Name = "btnSubmitQuery";
            this.btnSubmitQuery.Size = new System.Drawing.Size(555, 30);
            this.btnSubmitQuery.TabIndex = 4;
            this.btnSubmitQuery.Text = "ارسال پیام";
            this.btnSubmitQuery.Click += new System.EventHandler(this.btnSubmitQuery_Click);
            // 
            // lblMessageText
            // 
            this.lblMessageText.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMessageText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblMessageText.Location = new System.Drawing.Point(584, 185);
            this.lblMessageText.Name = "lblMessageText";
            this.lblMessageText.Size = new System.Drawing.Size(54, 22);
            this.lblMessageText.TabIndex = 139;
            this.lblMessageText.Text = "متن پیام";
            this.lblMessageText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.InsertGalleryImage("reminder_16x16.png", "images/scheduling/reminder_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/scheduling/reminder_16x16.png"), 0);
            this.imageCollection.Images.SetKeyName(0, "reminder_16x16.png");
            this.imageCollection.InsertGalleryImage("suggestion_16x16.png", "images/support/suggestion_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/suggestion_16x16.png"), 1);
            this.imageCollection.Images.SetKeyName(1, "suggestion_16x16.png");
            this.imageCollection.InsertGalleryImage("warning_16x16.png", "images/status/warning_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/status/warning_16x16.png"), 2);
            this.imageCollection.Images.SetKeyName(2, "warning_16x16.png");
            this.imageCollection.InsertGalleryImage("convert_16x16.png", "images/actions/convert_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/convert_16x16.png"), 3);
            this.imageCollection.Images.SetKeyName(3, "convert_16x16.png");
            this.imageCollection.InsertGalleryImage("about_16x16.png", "devav/actions/about_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("devav/actions/about_16x16.png"), 4);
            this.imageCollection.Images.SetKeyName(4, "about_16x16.png");
            // 
            // cboMessageCategory
            // 
            this.cboMessageCategory.Location = new System.Drawing.Point(457, 30);
            this.cboMessageCategory.Name = "cboMessageCategory";
            this.cboMessageCategory.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMessageCategory.Properties.Appearance.Options.UseFont = true;
            this.cboMessageCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMessageCategory.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("هشدار", "هشدار", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("راهنما", "راهنما", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("احتیاط", "احتیاط", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("بروزرسانی", "بروزرسانی", 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("اطلاع", "اطلاع", 4)});
            this.cboMessageCategory.Properties.SmallImages = this.imageCollection;
            this.cboMessageCategory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboMessageCategory.Size = new System.Drawing.Size(121, 24);
            this.cboMessageCategory.TabIndex = 2;
            // 
            // txtMessageText
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtMessageText, 2);
            this.txtMessageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessageText.Location = new System.Drawing.Point(23, 188);
            this.txtMessageText.Name = "txtMessageText";
            this.txtMessageText.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessageText.Properties.Appearance.Options.UseFont = true;
            this.txtMessageText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMessageText.Size = new System.Drawing.Size(555, 256);
            this.txtMessageText.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(584, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 25);
            this.label4.TabIndex = 223;
            this.label4.Text = "گیرندگان";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.txtMessageText, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblMessageText, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnSubmitQuery, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.listUsers, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboMessageCategory, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMessageCategory, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTitel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(641, 483);
            this.tableLayoutPanel1.TabIndex = 224;
            // 
            // listUsers
            // 
            this.listUsers.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listUsers.Appearance.Options.UseFont = true;
            this.listUsers.Cursor = System.Windows.Forms.Cursors.Default;
            this.listUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listUsers.Location = new System.Drawing.Point(53, 57);
            this.listUsers.MultiColumn = true;
            this.listUsers.Name = "listUsers";
            this.listUsers.Size = new System.Drawing.Size(525, 125);
            this.listUsers.TabIndex = 224;
            // 
            // lblTitel
            // 
            this.lblTitel.BackColor = System.Drawing.SystemColors.Info;
            this.tableLayoutPanel1.SetColumnSpan(this.lblTitel, 2);
            this.lblTitel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.Location = new System.Drawing.Point(23, 0);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(555, 27);
            this.lblTitel.TabIndex = 225;
            this.lblTitel.Text = "ارسال هشدار سیستمی در زمان ورود به برنامه";
            this.lblTitel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAddUsers);
            this.flowLayoutPanel1.Controls.Add(this.btnClearList);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 54);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(30, 131);
            this.flowLayoutPanel1.TabIndex = 226;
            // 
            // btnAddUsers
            // 
            this.btnAddUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddUsers.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddUsers.ImageOptions.Image")));
            this.btnAddUsers.Location = new System.Drawing.Point(2, 3);
            this.btnAddUsers.Name = "btnAddUsers";
            this.btnAddUsers.Size = new System.Drawing.Size(25, 60);
            this.btnAddUsers.TabIndex = 36;
            this.btnAddUsers.Click += new System.EventHandler(this.btnAddUsers_Click);
            // 
            // btnClearList
            // 
            this.btnClearList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClearList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClearList.ImageOptions.Image")));
            this.btnClearList.Location = new System.Drawing.Point(2, 69);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(25, 60);
            this.btnClearList.TabIndex = 37;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // frmPublicMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 483);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPublicMessage";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ارسال هشدار عمومی";
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMessageCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessageText.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listUsers)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMessageCategory;
        private DevExpress.XtraEditors.SimpleButton btnSubmitQuery;
        private System.Windows.Forms.Label lblMessageText;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraEditors.ImageComboBoxEdit cboMessageCategory;
        private DevExpress.XtraEditors.MemoEdit txtMessageText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.ImageListBoxControl listUsers;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnAddUsers;
        private DevExpress.XtraEditors.SimpleButton btnClearList;

    }
}