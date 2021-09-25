using System;
using System.Windows.Forms;
using GAM.Properties;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Data.OleDb;
using System.ComponentModel;
using GAM.Forms.Profile.Etebarat.TehranApprovals;
using GAM.Forms.Profile.Etebarat.Print;
using GAM.Forms.Profile;
using GAM.Forms.Reports.Master;
using GAM.Forms.Information;
using GAM.Forms.Login;
using GAM.Forms.Profile.Etebarat.Arshive;
using GAM.Forms.Information.Library;
using GAM.Forms.Reports;
using GAM.Forms.Settings;
using GAM.Forms.Reports.Etebarat.Requests;
using GAM.Forms.Settings.Library;
using GAM.Dialogs;
using MD.PersianDateTime;
using GAM.Modules;
using GAM.Forms.Profile.Etebarat.MyFiles;
using GAM.Forms.Profile.Etebarat.Review;
using GAM.Forms.Profile.LegalFile.NewFile;
using GAM.Forms.Profile.LegalFile.MyFiles;
using DevExpress.XtraEditors;
using GAM.Forms.Profile.Etebarat.AddExpertReport;
using GAM.Forms.Reports.Hoghoghi;
using GAM.Forms.Settings.SourceReports;
using GAM.Forms.Settings.ImportSourcefile;
using GAM.Forms.Profile.Kargozini.Personnel;
using DevExpress.XtraTab;
using DevExpress.XtraNavBar;
using System.Drawing;
using GAM.Forms.Profile.Etebarat.Circulation;
using GAM.Forms.Reports.OperationalReports;

namespace GAM.Forms.Main
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        private string _switchMode = string.Empty;
        public string UserForms { get; set; }
        public string UserMenus { get; set; }
        public bool IsShown { get; set; }

        public frmMain()
        {
            InitializeComponent();
        }

        #region tab_Application

        private void btnUserSetting_Click(object sender, EventArgs e)
        {
            new dlgChangePassword().ShowDialog();
        }

        private void btnAppUpdate_LinkClicked(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            btnAppUpdate.Enabled = false;
            this.Hide();
            Application.DoEvents();
            string path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"updater.exe");
            Process.Start(path);
            btnAppUpdate.Enabled = false;
            Application.DoEvents();
            _switchMode = "Update";
            this.Close();
        }

        #endregion

        #region tab_Profile

        private void btnAlerts_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            MessagesSys.FillMessages();
            btnAlerts.Enabled = false;
            Application.DoEvents();
            new dlgAlerts(false).ShowDialog();
            btnAlerts.Enabled = true;
        }

        private void btnSendComment_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            btnSendComment.Enabled = false;
            new frmSendComment().ShowDialog();
            btnSendComment.Enabled = true;
        }

        private void btnSendLetter_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            AddTabPage(new dlgSendLetter().pnlMain, btnSendLetter, true);
        }

        private void btnNewLoanExpertReport_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnNewLoanExpertReport.Enabled = false;
            Application.DoEvents();
            AddTabPage(new frmAddExpertReport().pnlMain, btnNewLoanExpertReport, false);
            btnNewLoanExpertReport.Enabled = true;
        }

        private void btnReviewLoanFile_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnReviewLoanFile.Enabled = false;
            Application.DoEvents();
            AddTabPage(new frmReviewLoanFile().pnlMain, btnReviewLoanFile, true);
            btnReviewLoanFile.Enabled = true;
        }

        private void btnNewLegalFile_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnNewLegalFile.Enabled = false;
            Application.DoEvents();
            AddTabPage(new frmNewLegalFile().pnlMain, btnNewLegalFile, true);
            btnNewLegalFile.Enabled = true;
        }

        private void btnNewPerson_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnNewPerson.Enabled = false;
            Application.DoEvents();
            AddTabPage(new frmNewPerson("").pnlMain, btnNewPerson, true);
            btnNewPerson.Enabled = true;
        }

        private void btnMyLoanFiles_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnMyLoanFiles.Enabled = false;
            Application.DoEvents();
            AddTabPage(new frmMyLoanFiles(this).pnlMain, btnMyLoanFiles, true);
            btnMyLoanFiles.Enabled = true;
        }
     
        private void btnMyLegalFiles_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddTabPage(new frmMyLegalFiles().pnlMain, btnMyLegalFiles, true);
        }

        private void btnCirculationLegalFiles_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddTabPage(new GAM.Forms.Profile.Hoghoghi.Circulation.frmCirculationLegalFiles().pnlMain, btnCirculationLegalFiles, true);
        }

        private void btnAllPersonnels_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddTabPage(new GAM.Forms.Profile.Kargozini.AllPersonnels.frmAllPersonnels().pnlMain, btnAllPersonnels, true);
        }

        private void btnFtp_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddTabPage(new GAM.Forms.Settings.ftpForm().pnlMain, btnFtpFile, true);
        }

        #endregion

        #region tab_Requests

        private void btnLoanFilePrint_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnLoanFilePrint.Enabled = false;
            Application.DoEvents();
            AddTabPage(new frmRequestPrint().pnlMain, btnLoanFilePrint, true);
            btnLoanFilePrint.Enabled = true;
        }
      
        private void btnCirculationLoanFiles_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnCirculationLoanFiles.Enabled = false;
            Application.DoEvents();
            AddTabPage(new GAM.Forms.Profile.Etebarat.Circulation.frmCirculationLoanFiles().pnlMain, btnCirculationLoanFiles, true);
            btnCirculationLoanFiles.Enabled = true;
        }

        private void btnRegTehranApproval_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnRegTehranApproval.Enabled = false;
            Application.DoEvents();
            AddTabPage(new frmTehranApprovals().pnlMain, btnRegTehranApproval, true);
            btnRegTehranApproval.Enabled = true;
        }
   
        #endregion

        #region tab_Archives

        private void btnNewLoanFile_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnNewLoanFile.Enabled = false;
            Application.DoEvents();
            AddTabPage(new frmNewLoanFile().pnlMain, btnNewLoanFile, true);
            btnNewLoanFile.Enabled = true;
        }

        private void btnAllLoanFiles_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnAllLoanFiles.Enabled = false;
            Application.DoEvents();
            AddTabPage(new dlgAllLoanFiles("*").pnlMain, btnAllLoanFiles, true);
            btnAllLoanFiles.Enabled = true;
        }

        #endregion

        #region tab_OfficeForms

        private void btnOfficialForms_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnOfficialForms.Enabled = false;
            Application.DoEvents();
            AddTabPage(new GAM.Forms.Profile.OfficialForms.frmOfficeForms("").pnlMain, btnOfficialForms, true);
            btnOfficialForms.Enabled = true;
        }

        private void btnCirculars_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnCirculars.Enabled = false;
            Application.DoEvents();
            AddTabPage(new GAM.Forms.Profile.OfficialForms.dlgCirculars().pnlMain, btnCirculars, true);
            btnCirculars.Enabled = true;
        }

        #endregion

        #region tab_Reports

        private void btnRequestsReport_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnRequestsReport.Enabled = false;
            Application.DoEvents();
            AddTabPage(new frmRequestsReports().pnlMain, btnRequestsReport, true);
            btnRequestsReport.Enabled = true;
        }
      
        private void btnCreditExpertsPerformance_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnCraditExpertsPerformance.Enabled = false;
            Application.DoEvents();
            AddTabPage(new frmExpertsPerformance().pnlMain, btnCraditExpertsPerformance, true);
            btnCraditExpertsPerformance.Enabled = true;
        }

        private void btnLegalExpertsPerformance_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnLegalExpertsPerformance.Enabled = false;
            Application.DoEvents();
            AddTabPage(new frmLegalExpertsPerformance().pnlMain, btnLegalExpertsPerformance, true);
            btnLegalExpertsPerformance.Enabled = true;
        }

        private void btnCraditExpertReports_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnCraditExpertReports.Enabled = false;
            Application.DoEvents();
            AddTabPage(new frmExpertReports().pnlMain, btnCraditExpertReports, true);
            btnCraditExpertReports.Enabled = true;
        }

        private void btnMasterReports_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnMasterReports.Enabled = false;
            AddTabPage(new frmReports().pnlMain, btnMasterReports, true);
            btnMasterReports.Enabled = true;
        }

        private void btnOperationalReports_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            btnTreeReports.Enabled = false;
            AddTabPage(new frmTreeReports().pnlMain, btnTreeReports, true);
            btnTreeReports.Enabled = true;
        }

        #endregion

        #region tab_Information

        private void btnBranchesInfo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnBranchesInfo.Enabled = false;
            Application.DoEvents();
            AddTabPage(new dlgBranchesList().pnlMain, btnBranchesInfo, true);
            btnBranchesInfo.Enabled = true;
        }

        private void btnUsersInfo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnUsersInfo.Enabled = false;
            Application.DoEvents();
            AddTabPage(new dlgUsersList(Users.GetWorkGroupUsers(true), false).pnlMain, btnUsersInfo, true);
            btnUsersInfo.Enabled = true;
        }

        #endregion

        #region tab_Settings
       
        private void btnBackupDatabases_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnBackupDatabases.Enabled = false;
            Application.DoEvents();
            Backup.Full();
            btnBackupDatabases.Enabled = true;
        }

        private void btnSourceReports_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnSourceReports.Enabled = false;
            Application.DoEvents();
            AddTabPage(new frmSourceReports().pnlMain, btnSourceReports, true);
            btnSourceReports.Enabled = true;
        }

        private void btnEditConditions_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnEditConditions.Enabled = false;
            Application.DoEvents();
            new dlgConditionsList().Show();
            btnEditConditions.Enabled = true;
        }

        private void btnEditFacility_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            new dlgFacilitysList().ShowDialog();
        }
     
        private void btnImportDataFile_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            btnImportDataFile.Enabled = false;
            Application.DoEvents();
            AddTabPage(new frmImportFile().pnlMain, btnImportDataFile, true);
            btnImportDataFile.Enabled = true;
        }

        private void btnPublicMessage_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DialogResult dlgReturn = new frmPublicMessage().ShowDialog();
            if (dlgReturn == System.Windows.Forms.DialogResult.OK)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("پیام شما با موفقیت به شبکه ارسال شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUsersComments_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            btnUsersComments.Enabled = false;
            Application.DoEvents();
            AddTabPage(new frmUsersComments().pnlMain, btnUsersComments, true);
            btnUsersComments.Enabled = true;
        }
    
        #endregion

        #region Events

        private void frmMain_Shown(object sender, EventArgs e)
        {
            pictureBox.Image = global::GAM.Properties.Resources.bmlogo_mainback;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (_switchMode == "Update")
            {
                try
                {
                    Process.Start(Application.StartupPath + @"\updater.exe");
                    Process process = Process.GetCurrentProcess();
                    process.Kill();
                }
                catch
                {
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args.Icon = System.Drawing.SystemIcons.Question;
                args.Caption = "خروج از برنامه";
                args.Text = "آیا از خروج برنامه اطمینان کامل حاصل دارید؟";
                args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Hide();
                    Process process = Process.GetCurrentProcess();
                    process.Kill();
                }
                else 
                {
                    e.Cancel = true;
                }
            }
        }

        private void timerBackup_Tick(object sender, EventArgs e)
        {
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Parse("18:00");

            if (Users.AutoBackup & dt1.Hour == dt2.Hour)
            {
                timerBackup.Stop();
                btnBackupDatabases.Enabled = false;
                Application.DoEvents();
                Backup.Full();
                btnBackupDatabases.Enabled = true;
            }
        }
       
        private void tabControl_CloseButtonClick(object sender, EventArgs e)
        {
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs arg = e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs;
            tabControl.TabPages.Remove((arg.Page as XtraTabPage));
        }

        private void tabControl_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (tabControl.SelectedTabPage.Text == btnMyLoanFiles.Caption)
                frmMyLoanFiles.RaiseLoadEvent();
            if (tabControl.SelectedTabPage.Text == btnNewLoanFile.Caption)
                frmNewLoanFile.RaiseLoadEvent();
            if (tabControl.SelectedTabPage.Text == btnCirculationLoanFiles.Caption)
                frmCirculationLoanFiles.RaiseLoadEvent();
        }

        #endregion

        #region Functions
       
        public void Startup()
        {
            lblToday.Text = "امروز: " + Numeral.ToFarsi(PersianDate.Now.ToWritten());

            CheckAlerts();

            navBarControl.BeginUpdate();
            for (int i = 0; i < navBarControl.Groups.Count; i++)
            {
                DevExpress.XtraNavBar.NavBarGroup item = navBarControl.Groups[i];
                if (item.GetType().FullName == "DevExpress.XtraNavBar.NavBarGroup")
                {
                    string name = item.Name;
                    if (Users.IsUserEnable & this.UserMenus.Contains(name))
                        item.Visible = true;
                    else
                        item.Visible = false;
                    if (i == 0)
                        item.Visible = true;
                }
            }

            foreach (DevExpress.XtraNavBar.NavBarItem item in navBarControl.Items)
            {
                if (item.GetType().FullName == "DevExpress.XtraNavBar.NavBarItem")
                {
                    string name = item.Name;
                    if (Users.IsUserEnable & this.UserForms.Contains(name))
                        item.Visible = true;
                    else
                        item.Visible = false;
                }
            }

            navBarSeparatorItem5.Visible = btnNewPerson.Visible | btnAllPersonnels.Visible;
            navBarSeparatorItem3.Visible = btnNewLegalFile.Visible | btnMyLegalFiles.Visible | btnCirculationLegalFiles.Visible;
            navBarControl.EndUpdate();
            navBarControl.Refresh();
        }

        private void AddTabPage(Control ctrl, NavBarItem navbarItem, bool fill)
        {
            foreach (XtraTabPage tab in tabControl.TabPages)
            {
                if (tab.Text != btnReviewLoanFile.Caption & tab.Text == navbarItem.Caption)
                {
                    tabControl.SelectedTabPage = tab;
                    return;
                }
            }

            XtraTabPage page = new XtraTabPage();
            page.BackColor = Color.FromArgb(235, 236, 239);
            page.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            page.Text = navbarItem.Caption;
            page.Image = navbarItem.SmallImage;
         
            if (fill)
                ctrl.Dock = DockStyle.Fill;
            else
                ctrl.Dock = DockStyle.Right;

            page.Controls.Add(ctrl);
            tabControl.TabPages.Add(page);
            tabControl.SelectedTabPage = page;
        }
        public void AddTabPage(Control ctrl, string text, Image img, bool fill)
        {

            XtraTabPage page = new XtraTabPage();
            page.BackColor = Color.FromArgb(235, 236, 239);
            page.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            page.Text = text;
            page.Image = img;

            if (fill)
                ctrl.Dock = DockStyle.Fill;
            else
                ctrl.Dock = DockStyle.Right;

            page.Controls.Add(ctrl);
            tabControl.TabPages.Add(page);
            tabControl.SelectedTabPage = page;
        }

        private void CheckAlerts()
        {
            int count = MessagesSys.GetUnreadMessagesCount();
            if (count > 0)
                new dlgAlerts(true).ShowDialog();
        }

        #endregion
    }
}
