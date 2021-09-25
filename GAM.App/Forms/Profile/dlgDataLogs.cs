using GAM.Forms.Information.Library;
using GAM.Forms.Profile.Etebarat.Library;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GAM.Modules;
using GAM.Forms.Profile.LegalFile.Library;
using GAM.Connections;
using GAM.Forms.Settings.Library;
using GAM.Dialogs;


namespace GAM.Forms.Profile
{
    public partial class dlgDataLogs : DevExpress.XtraEditors.XtraForm
    {
        static DevExpress.Utils.ImageCollection Images = null;
        public dlgDataLogs(bool alowDeleteRow)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.UpdateSkinPainter();
            Images = imageCollection;
            RepositoryItemImageComboBox imgCombo = gridControl.RepositoryItems.Add("ImageComboBoxEdit") as RepositoryItemImageComboBox;
            imgCombo.SmallImages = this.imageCollection;
            imgCombo.Items.Add(new ImageComboBoxItem(0));
            imgCombo.Items.Add(new ImageComboBoxItem(1));
            imgCombo.Items.Add(new ImageComboBoxItem(2));
            imgCombo.Items.Add(new ImageComboBoxItem(3));
            imgCombo.Items.Add(new ImageComboBoxItem(4));
            imgCombo.Items.Add(new ImageComboBoxItem(5));
            imgCombo.Items.Add(new ImageComboBoxItem(6));
            imgCombo.Items.Add(new ImageComboBoxItem(7));
            imgCombo.Items.Add(new ImageComboBoxItem(8));
            imgCombo.Items.Add(new ImageComboBoxItem(9));
            imgCombo.Items.Add(new ImageComboBoxItem(10));
            imgCombo.Items.Add(new ImageComboBoxItem(11));
            imgCombo.Items.Add(new ImageComboBoxItem(12));
            imgCombo.Items.Add(new ImageComboBoxItem(13));
            imgCombo.Items.Add(new ImageComboBoxItem(14));
            imgCombo.Items.Add(new ImageComboBoxItem(15));
            imgCombo.Items.Add(new ImageComboBoxItem(16));

            imgCombo.Buttons[0].Kind = ButtonPredefines.Glyph;
            imgCombo.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Columns["ActionID"].ColumnEdit = imgCombo;
            if (!alowDeleteRow)
                colDelete.Visible = false;
        }

        public void FillLoanFileLogs(DataRow row)
        {
            try
            {
                OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_RequestsLog.mdb"));
                objConn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = objConn;
                cmd.CommandType = CommandType.Text;
                string[] tableNames = objConn.GetSchema("Tables").AsEnumerable().Where(x => x["TABLE_TYPE"].ToString() == "TABLE").Select(r => r["TABLE_NAME"].ToString()).ToArray();
                List<string> logTables = new List<string>();

                foreach (string name in tableNames)
                {
                    if (Numeral.IsNumber(name))
                        logTables.Add(name);
                }

                logTables.Sort();

                if (logTables.Count > 0)
                {
                    DataTable masterTable = new DataTable();

                    foreach (string tblName in logTables)
                    {
                        cmd.CommandText = string.Format("SELECT {0} AS TableName, * FROM {0} WHERE ([Serial] = {1}) ORDER BY [ID] DESC", tblName, row["RequestSerial"]);
                        var dataReader = cmd.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        masterTable.Merge(dataTable);
                    }

                    objConn.Close();

                    if (masterTable.Rows.Count > 0)
                        masterTable = masterTable.AsEnumerable().OrderByDescending(x => x["ActionDateTime"]).CopyToDataTable();

                    if (masterTable != null)
                    {
                        masterTable.Columns.Add("ActionName");
                        masterTable.Columns.Add("UserName");
                        masterTable.Columns.Add("SourceID");

                        foreach (DataRow r in masterTable.Rows)
                        {
                            r["UserName"] = Users.GetUserNameById(Numeral.AnyToInt32(r["UserID"]));
                            r["ActionName"] = GetActionNameByID(Numeral.AnyToInt32(r["ActionID"]));
                            r["SourceID"] = "RequestsLog";
                        }
                    }

                    gridControl.DataSource = masterTable;
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FillLegalFileLogs(DataRow row)
        {
            try
            {
                OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_LegalFilesLog.mdb"));
                objConn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = objConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = string.Format("SELECT  {0} AS TableName, * FROM [Logs] WHERE ([ContractID] = {0}) ORDER BY [ID] DESC", row["ContractID"]);
                var dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);

                objConn.Close();

                if (dataTable.Rows.Count > 0)
                    dataTable = dataTable.AsEnumerable().OrderByDescending(x => x["ActionDateTime"]).CopyToDataTable();

                if (dataTable != null)
                {
                    dataTable.Columns.Add("ActionName");
                    dataTable.Columns.Add("UserName");
                    dataTable.Columns.Add("SourceID");

                    foreach (DataRow r in dataTable.Rows)
                    {
                        r["UserName"] = Users.GetUserNameById(Numeral.AnyToInt32(r["UserID"]));
                        r["ActionName"] = GetActionNameByID(Numeral.AnyToInt32(r["ActionID"]));
                        r["SourceID"] = "LegalFilesLog";
                    }
                }

                gridControl.DataSource = dataTable;

            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FillExpertReportLogs(DataRow row)
        {
            try
            {
                OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_ExpertReportsLog.mdb"));
                objConn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = objConn;
                cmd.CommandType = CommandType.Text;
                string[] tableNames = objConn.GetSchema("Tables").AsEnumerable().Where(x => x["TABLE_TYPE"].ToString() == "TABLE").Select(r => r["TABLE_NAME"].ToString()).ToArray();
                List<string> logTables = new List<string>();

                foreach (string name in tableNames)
                {
                    if (Numeral.IsNumber(name))
                        logTables.Add(name);
                }

                logTables.Sort();

                if (logTables.Count > 0)
                {
                    DataTable masterTable = new DataTable();

                    foreach (string tblName in logTables)
                    {
                        cmd.CommandText = string.Format("SELECT {0} AS TableName, * FROM {0} WHERE ([Serial] = {1}) ORDER BY [ID] DESC", tblName, row["ID"]);
                        var dataReader = cmd.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        masterTable.Merge(dataTable);
                    }

                    objConn.Close();

                    if (masterTable.Rows.Count > 0)
                        masterTable = masterTable.AsEnumerable().OrderByDescending(x => x["ActionDateTime"]).CopyToDataTable();

                    if (masterTable != null)
                    {
                        masterTable.Columns.Add("ActionName");
                        masterTable.Columns.Add("UserName");
                        masterTable.Columns.Add("SourceID");
                        foreach (DataRow r in masterTable.Rows)
                        {
                            r["UserName"] = Users.GetUserNameById(Numeral.AnyToInt32(r["UserID"]));
                            r["ActionName"] = GetActionNameByID(Numeral.AnyToInt32(r["ActionID"]));
                            r["SourceID"] = "ExpertReportsLog";
                        }
                    }

                    gridControl.DataSource = masterTable;
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static void AddRequestLog(string[] serials, int actionId, string note, int userId)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_RequestsLog.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    string[] tableNames = objConn.GetSchema("Tables").AsEnumerable().Where(x => x["TABLE_TYPE"].ToString() == "TABLE").Select(r => r["TABLE_NAME"].ToString()).ToArray();
                    foreach (string serial in serials)
                    {
                        cmd.CommandText = string.Format("INSERT INTO {0} ([Serial], [UserID], [ActionID], [ActionDateTime], [Note]) VALUES (@Serial, @UserID, @ActionID, @ActionDateTime, @Note)", tableNames.Last());
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("Serial", long.Parse(serial));
                        cmd.Parameters.AddWithValue("UserID", userId);
                        cmd.Parameters.AddWithValue("ActionID", actionId);
                        cmd.Parameters.AddWithValue("ActionDateTime", Network.GetNowDateTimeString());
                        cmd.Parameters.AddWithValue("Note", note);
                        cmd.ExecuteNonQuery();
                    }
                    objConn.Close();
                }
            }
            catch
            {
            }
        }
        public static void AddRequestLog(string[] serials, int actionId, string note) 
        {
            AddRequestLog(serials, actionId, note, Users.MyUserID);
        }
        public static void AddRequestLog(string serial, int actionId, string note)
        {
            AddRequestLog(new string[] { serial }, actionId, note);
        }


        public static void AddLegalLog(string[] contracts, int levelId, int actionId, string note)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_LegalFilesLog.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    foreach (string contractId in contracts)
                    {
                        cmd.CommandText = "INSERT INTO [Logs] ([ContractID], [UserID], [LevelID], [ActionID], [ActionDateTime], [Note]) VALUES (@ContractID, @UserID, @LevelID, @ActionID, @ActionDateTime, @Note)";
                        cmd.Parameters.AddWithValue("ContractID", contractId);
                        cmd.Parameters.AddWithValue("UserID", Users.MyUserID);
                        cmd.Parameters.AddWithValue("LevelID", levelId);
                        cmd.Parameters.AddWithValue("ActionID", actionId);
                        cmd.Parameters.AddWithValue("ActionDateTime", Network.GetNowDateTimeString());
                        cmd.Parameters.AddWithValue("Note", note);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }

                    objConn.Close();
                }
            }
            catch
            {
            }
        }
        public static void AddLegalLog(string contract, int levelId, int actionId, string note)
        {
            AddLegalLog(new string[] { contract }, levelId, actionId, note);
        }
        
        public static void AddExpertLog(string serial, int actionId, string note)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_ExpertReportsLog.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    string[] tableNames = objConn.GetSchema("Tables").AsEnumerable().Where(x => x["TABLE_TYPE"].ToString() == "TABLE").Select(r => r["TABLE_NAME"].ToString()).ToArray();
                    cmd.CommandText = string.Format("INSERT INTO {0} ([Serial], [UserID], [ActionID], [ActionDateTime], [Note]) VALUES (@Serial, @UserID, @ActionID, @ActionDateTime, @Note)", tableNames.Last());
                    cmd.Parameters.AddWithValue("Serial", serial);
                    cmd.Parameters.AddWithValue("UserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("ActionID", actionId);
                    cmd.Parameters.AddWithValue("ActionDateTime", Network.GetNowDateTimeString());
                    cmd.Parameters.AddWithValue("Note", note);
                    cmd.ExecuteNonQuery();
                    objConn.Close();
                }
            }
            catch
            {
            }
        }


        public static string GetActionNameByID(int actionId)
        {
            switch (actionId)
            {
                case 0:
                    return "بررسی";
                case 1:
                    return "اقدام";
                case 2:
                    return "عودت";
                case 3:
                    return "ابطال";
                case 4:
                    return "مصوب";
                case 5:
                    return "مرجع بالاتر";
                case 6:
                    return "پیام";
                case 7:
                    return "اطلاع";
                case 8:
                    return "بایگانی";
                case 9:
                    return "هشدار";
                case 10:
                    return "توقف";
                case 11:
                    return "مختومه";
                case 12:
                    return "توضیحات";
                case 13:
                    return "کسری مدارک";
                case 14:
                    return "قرارداد";
                case 15:
                    return "مرجع پایین تر";
                case 16:
                    return "مخالفت";
                default:
                    return "نامشخص";
            }
        }

        private void zoomTrackBar_EditValueChanged(object sender, EventArgs e)
        {
            gridView.Appearance.FilterPanel.FontSizeDelta = zoomTrackBar.Value;
            gridView.Appearance.Row.FontSizeDelta = zoomTrackBar.Value;
            gridView.Appearance.HeaderPanel.FontSizeDelta = zoomTrackBar.Value;
        }

        private void repositoryDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
            Application.DoEvents();
            if (gridView.FocusedRowHandle >= 0)
            {
                DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
                bool queryResult = SourceReportsManager.DeleteRowByID(row["SourceID"].ToString(), row["TableName"].ToString(), row["ID"].ToString());
                if (queryResult)
                {
                    gridView.DeleteRow(gridView.FocusedRowHandle);
                }
            }
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }
    }
}
