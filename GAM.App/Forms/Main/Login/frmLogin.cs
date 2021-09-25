using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Data;
using GAM.Forms.Profile.Etebarat.Print;
using GAM.Forms.Information.Library;
using GAM.Forms.Settings.Library;
using GAM.Forms.Main;
using GAM.Modules;
using System.Net;
using System.ComponentModel;
using System.Diagnostics;
using System.Configuration;
using System.Xml.Linq;
using GAM.Connections;
using System.Drawing;

namespace GAM.Forms.Login
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        bool isLogin = false;
        string OfflinePath;
        BackgroundWorker bw = new BackgroundWorker();
        frmMain main = null;

        public frmLogin()
        {
            InitializeComponent();
            this.OfflinePath = string.Empty;
            this.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        }

        #region Events

        private void StartLogin(BackgroundWorker worker)
        {
            string connStrings = connStrings = OLEDB.GetMasterDatabase("DB_Master.mdb");

            #region Connection Status
          
            if (this.OfflinePath.Length > 0)
            {
                OLEDB.Startup("", "", this.OfflinePath);
                OLEDB.ConnectionMode = OLEDB.ConnectionModeType.Local;
                connStrings = OLEDB.GetDatabase("DB_Master.mdb");
            }
            #endregion

            using (OleDbConnection objConn = new OleDbConnection(connStrings))
            {
                objConn.Open();
                OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text, CommandTimeout = 20 };
                cmd.Connection = objConn;
                cmd.CommandText = "SELECT * FROM [Users] WHERE " + string.Format("(UserID = {0} AND Password = '{1}')", txtUserName.Text, txtPassword.Text);
                var dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                worker.ReportProgress(5);
                Application.DoEvents();

                if (dataTable.Rows.Count == 1)
                {
                    DataRow currentUser = dataTable.Rows[0];

                    #region Set Connection Type
                    if (OLEDB.ConnectionMode != OLEDB.ConnectionModeType.Local)
                    {
                        if (currentUser["ServerName"].ToString() == "Master")
                            OLEDB.ConnectionMode = OLEDB.ConnectionModeType.Master;
                        if (currentUser["ServerName"].ToString() == "Backup")
                            OLEDB.ConnectionMode = OLEDB.ConnectionModeType.Backup;
                    }
                    #endregion

                    #region Fill Branches
                    GAM.Forms.Information.Library.Branches.Fill();
                    worker.ReportProgress(10);
                    #endregion

                    #region Get User Accsess
                    Users.MyUserID = Numeral.AnyToInt32(currentUser["UserID"].ToString());
                    Users.MyWorkGroup = currentUser["WorkGroup"].ToString();
                    Users.MyZoneID = currentUser["ZoneID"].ToString();
                    Users.MyProvinceID = currentUser["ProvinceID"].ToString();
                    Users.MyDomainID = currentUser["DomainID"].ToString();
                    Users.MyBranchID = currentUser["BranchID"].ToString();
                    Users.AutoBackup = bool.Parse(currentUser["AutoBackup"].ToString());
                    Users.IsUserEnable = bool.Parse(currentUser["IsEnable"].ToString());

                    worker.ReportProgress(10);
                    #endregion

                    #region Fill Helpers Classes

                    GAM.Forms.Information.Library.Users.Fill();
                    worker.ReportProgress(20);
                                        
                    GAM.Forms.Settings.Library.SourceReportsManager.Fill();
                    worker.ReportProgress(40);

                    //GAM.Forms.Profile.Kargozini.Library.PersonelsManager.Fill();
                    //worker.ReportProgress(50);

                    GAM.Forms.Information.Library.Notaries.Fill();
                    worker.ReportProgress(60);

                    GAM.Forms.Profile.LegalFile.Library.LegalFileLevels.Fill();
                    worker.ReportProgress(70);

                    GAM.Forms.Profile.Etebarat.Library.Facilitys.Fill();
                    worker.ReportProgress(80);

                    MessagesSys.FillMessages();
                    worker.ReportProgress(90);
                    #endregion

                    #region Registered Login info

                    worker.ReportProgress(100);
                    cmd.CommandText = "UPDATE Users SET " + string.Format("IPAddress = '{0}', ModifiedDate = '{1}', AppVersion = '{2}' WHERE UserID = {3}", Network.GetThisPCIPv4().ToString(), Network.GetNowDateTimeString(), Application.ProductVersion.ToString(), txtUserName.Text);
                    cmd.ExecuteNonQuery();

                    #endregion

                    #region Set Main info
                    main = new frmMain();
                    main.UserForms = currentUser["UserForms"].ToString();
                    main.UserMenus = currentUser["UserMenus"].ToString();
                    if (bool.Parse(currentUser["IsFemale"].ToString()))
                        main.lblUserName.Text = currentUser["UserName"].ToString() + " (" + Numeral.ToFarsi(currentUser["UserID"].ToString()) + ")";
                    else
                        main.lblUserName.Text = currentUser["UserName"].ToString() + " (" + Numeral.ToFarsi(currentUser["UserID"].ToString()) + ")";

                    main.lblUserPost.Text = "سمت: " + currentUser["PostJob"].ToString();
                    main.lblWorkGroup.Text = "عضو گروه: " + currentUser["WorkGroup"].ToString();
                    main.lblUserStatus.Text = "وضعیت: " + (bool.Parse(currentUser["IsEnable"].ToString()) ? "فعال" : "غیرفعال");
                    if (!Users.IsUserEnable)
                        main.lblUserStatus.ForeColor = Color.Red;

                    if (Users.MyProvinceID.Length > 0)
                        main.lblUserProvinceName.Text = "استان: " + Branches.GetProvinceById(Users.MyProvinceID).ProvinceName;
                    if (Users.MyDomainID.Length > 0)
                        main.lblUserDomainName.Text = "حــوزه: " + Branches.GetDomainById(Users.MyDomainID, true).DomainName;
                    if (Users.MyBranchID.Length > 0)
                        main.lblUserBranchName.Text = "شعبه: " + Branches.GetBranchById(Users.MyBranchID, true).BranchName;

                    main.lblAppVer.Text = "نسخه فعلی: " + Numeral.ToFarsi(this.Text);
                    main.lblLastLoginDate.Text = "آخرین ورود: " + Numeral.ToFarsi(currentUser["ModifiedDate"].ToString());
                    main.lblMachineName.Text = "نام سیستم: " + Network.GetMachineName();
                    objConn.Close();
                    this.isLogin = true;
                    #endregion
                }
                else
                {
                    objConn.Close();
                    throw new ArgumentException("نام کاربری یا کلمه عبور اشتباه است");
                }
            }
        }
  
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                StartLogin(sender as BackgroundWorker);
            }
            catch (ArgumentException ex)
            {
                e.Cancel = true;
                this.Invoke(new MethodInvoker(delegate()
                {
                    this.isLogin = false;
                    lblSetting.Show();
                    progressBar.Hide();
                    btnLogin.Text = "ورود به برنامه";
                    btnLogin.Enabled = true;
                    txtPassword.Select();
                    lblMessage.Show();
                    lblMessage.Text = ex.Message;
                    return;
                }));
            }
            catch
            {
                e.Cancel = true;
                this.Invoke(new MethodInvoker(delegate()
                {
                    this.isLogin = false;
                    lblSetting.Show();
                    progressBar.Hide();
                    btnLogin.Text = "ورود به برنامه";
                    btnLogin.Enabled = true;
                    txtPassword.Select();
                    lblMessage.Show();
                    lblMessage.Text = "امکان برقراری ارتباط با سرور وجود ندارد";
                    return;
                }));
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            btnLogin.Text = "در حال دریافت اطلاعات ...";
            progressBar.Position = e.ProgressPercentage;
            Application.DoEvents();
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {
                if (this.isLogin)
                {
                    this.Hide();
                    main.Startup();
                    main.Show();
                }
            }
        }

        public void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text.Length > 0 & txtPassword.Text.Length > 0)
                {
                    if (bw.IsBusy != true)
                    {
                        this.isLogin = false;
                        lblMessage.Text = "";
                        lblMessage.Hide();
                        btnLogin.Enabled = false;
                        btnLogin.Text = "در حال ارتباط با سرور ...";
                        lblSetting.Hide();
                        progressBar.Show();
                        bw.RunWorkerAsync();
                    }
                }
                else
                {
                    lblSetting.Show();
                    progressBar.Hide();
                    btnLogin.Enabled = true;
                    if (txtPassword.Text.Length == 0)
                        txtPassword.Select();
                    if (txtUserName.Text.Length == 0)
                        txtUserName.Select();
                    btnLogin.Text = "ورود به برنامه";
                    lblMessage.Text = "لطفا مقادیر ورودی را وارد کنید";
                    lblMessage.Show();
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            if (this.isLogin)
                this.Hide();
        }

        private void NextControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        #endregion

        private void lblSetting_Click(object sender, EventArgs e)
        {
            msgLocalConnection dlg = new msgLocalConnection();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.OfflinePath = dlg.Path;
            }
        }
    }
}
