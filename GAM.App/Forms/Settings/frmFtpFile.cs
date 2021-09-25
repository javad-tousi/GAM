using GAM.Dialogs;
using GAM.Forms.Information;
using GAM.Forms.Information.Library;
using GAM.Modules;
using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Settings
{
    public partial class ftpForm : DevExpress.XtraEditors.XtraForm
    {
        DataTable dataTable = new DataTable();

        public ftpForm()
        {
            InitializeComponent();
            dataTable.Columns.Add("FilePath");
            dataTable.Columns.Add("FileName");
            dataTable.Columns.Add("FileDate", typeof(int));
            dataTable.Columns.Add("FileTime", typeof(string));
            dataTable.Columns.Add("FileDateTime", typeof(string));
            UDF.ToFarsiLanguage();
            LoadFiles();
        }

        private void LoadFiles()
        {
            try
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgPleaseWait), true, true, false);
                Application.DoEvents();
                dataTable.Rows.Clear();
                string path = GAM.Connections.OLEDB.GetShareRoot() + @"\" + Users.MyUserID;
                if (!System.IO.Directory.Exists(path))
                    System.IO.Directory.CreateDirectory(path);
                foreach (string file in System.IO.Directory.GetFiles(path))
                {

                    DateTime dt1 = System.IO.File.GetCreationTime(file);
                    DateTime dt2 = System.IO.File.GetLastWriteTime(file);
                    var pd = PersianDateTime.Convert.Miladi(dt1).ToShamsi();
                    if (dt2 > dt1)
                        pd = PersianDateTime.Convert.Miladi(dt2).ToShamsi();
                     
                    string str = string.Format("{0}/{1}/{2}", pd.Year.ToString(), pd.Month.ToString(), pd.Day.ToString());
                    dataTable.Rows.Add(file, System.IO.Path.GetFileName(file), PersianDateTime.Parse(str).ToShortDateInt(), dt1.ToString("HH:mm:ss"), PersianDateTime.Parse(str).ToShortDateString() + " - " + dt1.ToString("HH:mm"));
                }
                foreach (string file in System.IO.Directory.GetDirectories(path))
                {

                    DateTime dt1 = System.IO.File.GetCreationTime(file);
                    DateTime dt2 = System.IO.File.GetLastWriteTime(file);
                    var pd = PersianDateTime.Convert.Miladi(dt1).ToShamsi();
                    if (dt2 > dt1)
                        pd = PersianDateTime.Convert.Miladi(dt2).ToShamsi();

                    string str = string.Format("{0}/{1}/{2}", pd.Year.ToString(), pd.Month.ToString(), pd.Day.ToString());
                    dataTable.Rows.Add(file, System.IO.Path.GetFileName(file), PersianDateTime.Parse(str).ToShortDateInt(), dt1.ToString("HH:mm:ss"), PersianDateTime.Parse(str).ToShortDateString() + " - " + dt1.ToString("HH:mm"));
                }

                if (dataTable.Rows.Count > 0)
                    gridControl.DataSource = dataTable.AsEnumerable().OrderByDescending(x => int.Parse(x["FileDate"].ToString())).ThenByDescending(x => x["FileTime"].ToString()).CopyToDataTable();
                else
                    gridControl.DataSource = dataTable;
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
               
                if (gridView.RowCount > 0)
                {
                    btnSave.Enabled = true;
                    btnDeleteFile.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                    btnDeleteFile.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadFiles();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً جهت ارسال فایل/پوشه ابتدا فایل/پوشه خود را توسط نشانه گر موس انتخاب و به داخل کادر زرد رنگ بیاندازید", "راهنما", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView.SelectedRowsCount == 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("هیچ فایلی جهت ذخیره انتخاب نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int rowIndex = gridView.FocusedRowHandle;
                DataRow row = gridView.GetDataRow(rowIndex);
                if (row != null)
                {
                    try
                    {
                        string despath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\GAMFiles\" + PersianDateTime.Now.ToShortDateInt();
                        System.IO.Directory.CreateDirectory(despath);

                        btnSave.Enabled = false;
                        Application.DoEvents();
                        foreach (int id in gridView.GetSelectedRows())
                        {
                            string filePath = gridView.GetRowCellValue(id, "FilePath").ToString();
                            if (System.IO.File.GetAttributes(filePath) == System.IO.FileAttributes.Directory)
                            {
                                DirectoryCopy.Start(filePath, despath + @"\" + System.IO.Path.GetFileName(filePath), true);
                            }
                            else
                            {
                                System.IO.File.Copy(filePath, despath + @"\" + System.IO.Path.GetFileName(filePath), true);
                            }
                        }
                        btnSave.Enabled = true;

                        gridView.FocusedRowHandle = rowIndex;
                        DevExpress.XtraEditors.XtraMessageBox.Show("ذخیره شد GAMFiles شما پوشه Desktop فایل های انتخاب شده با موفقیت در", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.Start(despath);
                    }
                    catch
                    {
                        btnSave.Enabled = true;
                        DevExpress.XtraEditors.XtraMessageBox.Show("فایلی با همین نام در مسیر انتخاب شده وجود دارد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadFiles();
                    gridView.FocusedRowHandle = rowIndex;
                }
                else 
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("هیچ فایلی جهت ذخیره انتخاب نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                LoadFiles();
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView.SelectedRowsCount == 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("هیچ فایلی جهت حذف انتخاب نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                btnDeleteFile.Enabled = false;
                Application.DoEvents();
                foreach (int id in gridView.GetSelectedRows())
                {
                    string filePath = gridView.GetRowCellValue(id, "FilePath").ToString();
                    if (System.IO.File.GetAttributes(filePath) == System.IO.FileAttributes.Directory)
                        System.IO.Directory.Delete(filePath, true);
                    else
                        System.IO.File.Delete(filePath);
                }
                btnDeleteFile.Enabled = true;
                LoadFiles();
            }
            catch
            {
                btnDeleteFile.Enabled = true;
                LoadFiles();
            }
        }

        private void pnlDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                pnlDrop.BackColor = Color.PaleGreen;
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void pnlDrop_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                pnlDrop.BackColor = Color.FromArgb(235, 236, 239);

                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Count() > 0)
                {
                    dlgUsersList usersdlg = new dlgUsersList(Users.GetAllUsers(), true);
                    DialogResult dlgResult = usersdlg.ShowDialog();
                    if (dlgResult == DialogResult.OK)
                    {
                        if (usersdlg.SelectedUsersId.Count > 0)
                        {
                            foreach (int userId in usersdlg.SelectedUsersId)
                            {
                                foreach (string name in files)
                                {
                                    if (name != string.Empty)
                                    {
                                        string path = GAM.Connections.OLEDB.GetShareRoot() + @"\" + userId;

                                        if (System.IO.File.GetAttributes(name) == System.IO.FileAttributes.Directory)
                                        {
                                            System.IO.Directory.CreateDirectory(path + @"\" + System.IO.Path.GetFileName(name));
                                            DirectoryCopy.Start(name, path + @"\" + System.IO.Path.GetFileName(name), true);
                                        }
                                        else
                                        {
                                            System.IO.Directory.CreateDirectory(path);
                                            System.IO.File.Copy(name, path + @"\" + System.IO.Path.GetFileName(name), true);
                                        }
                                    }
                                }
                            }
                            DevExpress.XtraEditors.XtraMessageBox.Show("فایل شما با موفقیت ارسال شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                btnBrowse.Enabled = true;
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pnlDrop_DragLeave(object sender, EventArgs e)
        {
            pnlDrop.BackColor = Color.FromArgb(235, 236, 239);
        }
    }
}
