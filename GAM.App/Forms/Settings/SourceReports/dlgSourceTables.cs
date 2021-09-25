using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using GAM.Forms.Settings.Library;
using GAM.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace GAM.Forms.Settings.SourceReports
{
    public partial class dlgSourceTables : DevExpress.XtraEditors.XtraForm
    {
        #region Main Events

        public dlgSourceTables(string sourceId)
        {
            InitializeComponent();
            this.Text = sourceId;
            ShowTables(sourceId);
        }

        #endregion

        private void btnDeleteTables_Click(object sender, EventArgs e)
        {
            btnDeleteTables.Enabled = false;
            Application.DoEvents();
            try
            {
                List<string> tablesList = new List<string>();
                foreach (object tableName in listTables.CheckedItems)
                {
                    tablesList.Add(tableName.ToString());
                }
                if (tablesList.Count > 0)
                    SourceReportsManager.DeleteSourceTable(this.Text, tablesList.ToArray());
                ShowTables(this.Text);

                btnDeleteTables.Enabled = true;
            }
            catch (Exception ex)
            {
                btnDeleteTables.Enabled = true;
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowTables(string sourceId)
        {
            listTables.Items.Clear();
            var tableNames = SourceReportsManager.GetSourceTables(sourceId);
            foreach (string table in tableNames)
            {
                listTables.Items.Add(table);
            }
        }
    }
}
