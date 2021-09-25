namespace GAM.Forms.Settings.SourceReports
{
    partial class dlgSourceTables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgSourceTables));
            this.pnlBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDeleteTables = new DevExpress.XtraEditors.SimpleButton();
            this.repositoryChecked = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.listTables = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryChecked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listTables)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnDeleteTables);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 433);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlBottom.Size = new System.Drawing.Size(444, 32);
            this.pnlBottom.TabIndex = 13;
            this.pnlBottom.Text = "flowLayoutPanel1";
            // 
            // btnDeleteTables
            // 
            this.btnDeleteTables.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteTables.ImageOptions.Image")));
            this.btnDeleteTables.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnDeleteTables.Location = new System.Drawing.Point(293, 3);
            this.btnDeleteTables.Name = "btnDeleteTables";
            this.btnDeleteTables.Size = new System.Drawing.Size(148, 27);
            this.btnDeleteTables.TabIndex = 3;
            this.btnDeleteTables.Text = "حذف جداول انتخاب شده";
            this.btnDeleteTables.Click += new System.EventHandler(this.btnDeleteTables_Click);
            // 
            // repositoryChecked
            // 
            this.repositoryChecked.AutoHeight = false;
            this.repositoryChecked.Name = "repositoryChecked";
            this.repositoryChecked.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // listTables
            // 
            this.listTables.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listTables.Appearance.Options.UseFont = true;
            this.listTables.CheckOnClick = true;
            this.listTables.Cursor = System.Windows.Forms.Cursors.Default;
            this.listTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTables.Location = new System.Drawing.Point(0, 0);
            this.listTables.MultiColumn = true;
            this.listTables.Name = "listTables";
            this.listTables.Size = new System.Drawing.Size(444, 433);
            this.listTables.TabIndex = 15;
            // 
            // dlgSourceTables
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 465);
            this.Controls.Add(this.listTables);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.LookAndFeel.SkinName = "Office 2010 Silver";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgSourceTables";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryChecked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listTables)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.FlowLayoutPanel pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnDeleteTables;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryChecked;
        private DevExpress.XtraEditors.CheckedListBoxControl listTables;
    }
}