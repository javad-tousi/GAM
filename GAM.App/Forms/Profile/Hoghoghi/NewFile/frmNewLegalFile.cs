using GAM.Forms.Profile.Etebarat.Library;
using GAM.Forms.Profile.Etebarat.Arshive;
using GAM.Forms.Information;
using GAM.Forms.Information.Library;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using GAM.Forms.Settings.Library;
using GAM.Modules;
using GAM.Forms.Profile.Etebarat.Print;
using MD.PersianDateTime;
using GAM.Forms.Profile.LegalFile.Library;
using GAM.Dialogs;
using GAM.Forms.Reports.Queries;
using GAM.Forms.Profile.Hoghoghi.NewFile;
using GAM.Connections;

namespace GAM.Forms.Profile.LegalFile.NewFile
{
    public partial class frmNewLegalFile : DevExpress.XtraEditors.XtraForm
    {
        private DataRow thisRow { get; set; }
        public enum FormStatusEnum { Show, Edit, New, Insert, Clone };
        private FormStatusEnum FormStatus;

        public frmNewLegalFile()
        {
            InitializeComponent();
        }
        public frmNewLegalFile(DataRow row)
        {
            InitializeComponent();
            txtContractId.Text = row["ContractID"].ToString();
            btnSearch_Click(null, EventArgs.Empty);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;
            if (ContractId.IsValid(txtContractId.Text))
            {
                try
                {
                    btnSearch.Enabled = false;
                    lblConnectionStatus.Text = "لطفا کمی صبر کنید ...";
                    Application.DoEvents();
                    DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgPleaseWait), true, true, false);

                    DataSet ds = LegalFilesManager.GetContractById(txtContractId.Text);

                    if (ds != null && ds.Tables["ContractInfo"].Rows.Count > 0)
                    {
                        ShowContractValues(ds.Tables["ContractInfo"].Rows[0]);
                        gridControl1.DataSource = ds.Tables["LinkedContracts"];
                        gridControl2.DataSource = ds.Tables["LinkedPlaques"];

                        DevExpress.XtraEditors.FormatConditionRuleValue rule = (DevExpress.XtraEditors.FormatConditionRuleValue)this.gridView1.FormatRules[0].Rule;
                        rule.Value1 = txtContractId.Text;

                    }
                    else
                    {
                        ViewMode(FormStatusEnum.Insert);
                        btnDebtUpdate_Click(null, EventArgs.Empty);
                    }

                    btnSearch.Enabled = true;
                    lblConnectionStatus.Text = string.Empty;
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                }
                catch (Exception ex)
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                    btnSearch.Enabled = true;
                    lblConnectionStatus.Text = ex.Message;
                }
            }
            else 
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("شماره قرارداد وارد شده معتبر نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContractId.Focus();
                txtContractId.SelectAll();
            }
        }

        private void btnBranchesList_Click(object sender, EventArgs e)
        {
            txtCustomerName.Focus();
            dlgBranchesList dlg = new dlgBranchesList();
            DialogResult dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                if (dlg.BranchId.Length > 0 & dlg.BranchName.Length > 0)
                {
                    txtBranchId.Text = dlg.BranchId;
                    lblBranchName.Text = dlg.BranchName;
                }
            }
        }

        private void btnSubmitQuery_Click(object sender, EventArgs e)
        {
            string errMessage = CheckInputValues();
            if (errMessage.Length == 0)
            {
                try
                {
                    lblConnectionStatus.Text = "لطفاً کمی صبر کنید ...";
                    Application.DoEvents();

                    long contractId = long.Parse(txtContractId.Text);
                    string contractPlan = cboContractPlan.Text;
                    string bailType = cboBailType.Text;
                    int levelId = 1;
                    int dateLevel = PersianDateTime.Now.ToShortDateInt();
                    int branchId = Numeral.AnyToInt32(txtBranchId.Text);
                    long? customerId = Numeral.ToLongNullable(txtCustomerId.Text);
                    string customerName = txtCustomerName.Text.Trim();
                    string fileId = txtFileId.Text.Trim();
                    int? indicatorId = Numeral.ToInt32Nullable(txtIndicatorId.Text);
                    int? notaryId = Numeral.ToInt32Nullable(txtNotaryId.Text);
                    string mortgageNo = txtMortgageNo.Text;
                    long evaluationAmount1 = Numeral.AnyToLong(txtEvaluationAmount1.Text);
                    long evaluationAmount2 = Numeral.AnyToLong(txtEvaluationAmount2.Text);
                    long mandehAsl = Numeral.AnyToLong(txtMandehAsl.Text);
                    long mandehSood = Numeral.AnyToLong(txtMandehSood.Text);
                    long mandehJarimeh = Numeral.AnyToLong(txtMandehJarimeh.Text);
                    long mandehHazineh = Numeral.AnyToLong(txtMandehHazineh.Text);
                    long mandehAbonman = Numeral.AnyToLong(txtMandehAbonman.Text);
                    int dateDebtUpdate = int.Parse(Numeral.ExtractDigits(txtDateDebtUpdate.Text));
                    int dateAuction = Numeral.AnyToInt32(Numeral.ExtractDigits(txtDateAuction.Text));
                    int expertId = int.Parse(txtExpertId.Text);
                    DataTable tablePlaques = (DataTable)gridControl2.DataSource;

                    string returnValue = string.Empty;

                    if (this.FormStatus == FormStatusEnum.New | this.FormStatus == FormStatusEnum.Insert | this.FormStatus == FormStatusEnum.Clone)
                        returnValue = LegalFilesManager.InsertQuery(contractId, contractPlan, bailType, levelId, dateLevel, branchId, customerId, customerName, fileId, indicatorId, notaryId, mortgageNo, evaluationAmount1, evaluationAmount2, mandehAsl, mandehSood, mandehJarimeh, mandehHazineh, mandehAbonman, dateDebtUpdate, dateAuction, expertId);
                    if (this.FormStatus == FormStatusEnum.Edit)
                        returnValue = LegalFilesManager.UpdateQuery(contractId, contractPlan, bailType, branchId, customerId, customerName, fileId, indicatorId, notaryId, mortgageNo, evaluationAmount1, evaluationAmount2, mandehAsl, mandehSood, mandehJarimeh, mandehHazineh, mandehAbonman, dateDebtUpdate, dateAuction, expertId);

                    if (returnValue.Length > 0)
                    {
                        if (tablePlaques.GetChanges() != null)
                        {
                            LegalFilesManager.UpdatePlaques(tablePlaques);
                        }

                        if (this.FormStatus == FormStatusEnum.New | this.FormStatus == FormStatusEnum.Insert | this.FormStatus == FormStatusEnum.Clone)
                        {
                            dlgDataLogs.AddLegalLog(contractId.ToString(), levelId, 7, string.Format("پرونده در سیستم ثبت و جهت بررسی به {0} ارجاع شد ", Users.GetUserNameWithSexByID(expertId)));
                        }

                        lblConnectionStatus.Text = string.Empty;
                        DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات با موفقیت ذخیره شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ViewMode(FormStatusEnum.New);
                        txtContractId.Text = contractId.ToString();
                    }

                    lblConnectionStatus.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    lblConnectionStatus.Text = string.Empty;
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                DevExpress.XtraEditors.XtraMessageBox.Show(errMessage, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NextControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btnExpertsList_Click(object sender, EventArgs e)
        {
            dlgUsersList dlg = new dlgUsersList(Users.GetWorkGroupUsers(true), false);
            DialogResult dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                if (dlg.UserId > 0 & dlg.UserName.Length > 0)
                {
                    txtExpertId.Text = dlg.UserId.ToString();
                    lblExpertName.Text = dlg.UserName;
                }
            }
        }

        private string CheckInputValues()
        {
            if (txtFileId.Text.Trim().Length == 0)
                return "لطفا شماره پرونده را وارد نمایید";
            if (cboBailType.Text.Length == 0)
                return "لطفا نوع وثیقه را مشخص کنید";
            if (cboContractPlan.Text.Length == 0)
                return "لطفا نوع سرفصل قرارداد را مشخص کنید";
            if (txtBranchId.Text.Length == 0)
                return "لطفا نام شعبه را مشخص کنید";
            if (txtCustomerName.Text.Length == 0)
                return "لطفا نام مدیون را وارد کنید";
            if (txtCustomerId.Text.Length == 0)
                return "لطفا شماره مشتری را وارد کنید";
            if (Numeral.AnyToLong(txtMandehAsl.Text) == 0 & Numeral.AnyToLong(txtMandehSood.Text) == 0 & Numeral.AnyToLong(txtMandehJarimeh.Text) == 0)
                return "لطفا مانده بدهی قرارداد را وارد کنید";
            if (!PersianDateTime.IsValidDate(txtDateDebtUpdate.Text))
                return "تاریخ محاسبه بدهی اشتباه می باشد";
            if (txtNotaryId.Text.Length == 0)
                return "لطفا شماره دفترخانه را وارد کنید";
            if (txtExpertId.Text.Length == 0)
                return "لطفا نام کارشناس پرونده را مشخص کنید";
            if (gridView2.RowCount == 0)
            {
                DataTable tbl = (DataTable)gridControl2.DataSource;
                if (tbl.GetChanges() == null)
                    gridControl2.DataSource = LegalFilesManager.GetLinkedPlaques(txtFileId.Text.Trim());
                if (gridView2.RowCount == 0)
                    return "لطفاً شماره پلاکهای ثبتی پرونده را ثبت نمایید";
            }

            return string.Empty;
        }

        public void ShowContractValues(DataRow row)
        {
            if (row != null)
            {
                pnlHeader.Enabled = false;

                ViewMode(FormStatusEnum.Show);

                this.thisRow = row;
                txtContractId.Text = row["ContractID"].ToString();
                cboBailType.Text = row["BailType"].ToString();
                txtFileId.Text = row["FileID"].ToString();

                Branches.BranchInfo branch = Branches.GetBranchById(row["BranchID"].ToString(), true);
                txtBranchId.Text = branch.BranchId;
                lblBranchName.Text = branch.BranchName;
                txtCustomerId.Text = row["CustomerID"].ToString();
                txtCustomerName.Text = row["CustomerName"].ToString();
                txtMandehAsl.Text = row["MandehAsl"].ToString();
                txtMandehSood.Text = row["MandehSood"].ToString();
                txtMandehJarimeh.Text = row["MandehJarimeh"].ToString();
                txtMandehHazineh.Text = row["MandehHazineh"].ToString();
                txtMandehAbonman.Text = row["MandehAbonman"].ToString();
                cboContractPlan.Text = row["ContractPlan"].ToString();
                txtDateDebtUpdate.Text = row["DateDebtUpdate"].ToString();
                txtLevelId.Text = row["LevelID"].ToString();
                txtContractLevelName.Text = LegalFileLevels.GetLevelNameByID(int.Parse(row["LevelID"].ToString()));

                txtNotaryId.Text = row["NotaryID"].ToString();
                txtNotaryName.Text = Notaries.GetNotarNameByID(row["NotaryID"].ToString());
                txtEvaluationAmount1.Text = row["EvaluationAmount1"].ToString();
                txtEvaluationAmount2.Text = row["EvaluationAmount2"].ToString();
                txtIndicatorId.Text = row["IndicatorID"].ToString();
                txtMortgageNo.Text = row["MortgageNo"].ToString();
                txtDateAuction.Text = row["DateAuction"].ToString();
                txtModifiedDate.Text = row["ModifiedDate"].ToString();

                txtExpertId.Text = row["ExpertID"].ToString();
                lblExpertName.Text = Users.GetUserNameById(Numeral.AnyToInt32(row["ExpertID"]));
                lblAgentName.Tag = row["AgentID"].ToString();
                lblAgentName.Text = Users.GetUserNameById(Numeral.AnyToInt32(row["AgentID"]));

                if (row["FileStatus"].ToString() == LegalFileStatus.Review)
                    lblFileStatus.Text = "وضعیت: " + LegalFileStatus.Review;
                if (row["FileStatus"].ToString() == LegalFileStatus.Action)
                    lblFileStatus.Text = "وضعیت: " + LegalFileStatus.Action;
                if (row["FileStatus"].ToString() == LegalFileStatus.Reject)
                    lblFileStatus.Text = "وضعیت: " + LegalFileStatus.Reject;
                if (row["FileStatus"].ToString() == LegalFileStatus.Stoped)
                    lblFileStatus.Text = "وضعیت: " + LegalFileStatus.Stoped;
                if (row["FileStatus"].ToString() == LegalFileStatus.Closed)
                {
                    btnEditLegalFile.Enabled = false;
                    btnChangeLevels.Enabled = false;
                    btnSendMessage.Enabled = false;
                    btnChangeExpertId.Enabled = false;
                    btnChangeAgentId.Enabled = false;
                    lblFileStatus.Text = "وضعیت: " + LegalFileStatus.Closed;
                }

                pnlHeader.Enabled = true;
            }
        }

        public void ViewMode(FormStatusEnum status)
        {
            this.FormStatus = status;

            switch (status)
            {
                case FormStatusEnum.Show://زمانی که اطلاعات یافت شده اما پنل ها قفل می باشند
                    btnNewLegalFile.Enabled = true;
                    btnClone.Enabled = true;
                    btnEditLegalFile.Enabled = true;
                    btnChangeLevels.Enabled = true;
                    btnSendMessage.Enabled = true;
                    btnChangeExpertId.Enabled = true;
                    btnChangeAgentId.Enabled = true;
                    btnLogs.Enabled = true;
                    pnlPlaques.Enabled = false;
                    colDeleteRow.Visible = false;

                    pnlSearch.Enabled = true;
                    //txtContractId.ResetText();
                    txtContractId.ReadOnly = false;
                    btnSearch.Enabled = true;
                    lblFileStatus.ResetText();

                    pnlFileInfo.Enabled = false;
                    cboBailType.SelectedIndex = 0;
                    txtFileId.ResetText();
                    txtBranchId.ResetText();
                    lblBranchName.ResetText();
                    txtCustomerId.ResetText();
                    txtCustomerName.ResetText();
                    txtMandehAsl.ResetText();
                    txtMandehSood.ResetText();
                    txtMandehJarimeh.ResetText();
                    txtMandehHazineh.ResetText();
                    txtMandehAbonman.ResetText();
                    cboContractPlan.SelectedIndex = 0;
                    txtDateDebtUpdate.ResetText();
                    txtLevelId.ResetText();
                    txtContractLevelName.ResetText();
                   
                    pnlLegalInfo.Enabled = false;
                    txtNotaryId.ResetText();
                    txtNotaryName.ResetText();
                    txtEvaluationAmount1.ResetText();
                    txtEvaluationAmount2.ResetText();
                    txtMortgageNo.ResetText();
                    txtIndicatorId.ResetText();
                    txtDateAuction.ResetText();
                    txtModifiedDate.ResetText();

                    grpExpertsInfo.Enabled = false;
                    txtExpertId.ResetText();
                    lblExpertName.ResetText();
                    lblAgentName.Tag = string.Empty;
                    lblAgentName.ResetText();

                    pnlSave.Enabled = false;

                    txtContractId.Focus();
                    txtContractId.Select();
                    break;

                case FormStatusEnum.Edit://زمانی که اطلاعات یافت شده و دکمه ویرایش توسط کاربر انتخاب شده است
                    btnNewLegalFile.Enabled = true;
                    btnClone.Enabled = false;
                    btnEditLegalFile.Enabled = false;
                    //btnChangeLevels.Enabled = true;
                    btnSendMessage.Enabled = true;
                    btnChangeExpertId.Enabled = true;
                    btnChangeAgentId.Enabled = true;
                    btnLogs.Enabled = true;
                    pnlPlaques.Enabled = true;
                    colDeleteRow.Visible = true;
                    colDeleteRow.VisibleIndex = 0;

                    pnlSearch.Enabled = false;
                    //txtContractId.ResetText();
                    //txtContractId.ReadOnly = true;
                    //btnSearch.Enabled = false;
                    //lblFileStatus.ResetText();

                    pnlFileInfo.Enabled = true;
                    //cboBailType.SelectedIndex = 0;
                    //txtFileId.ResetText();
                    //txtBranchId.ResetText();
                    //lblBranchName.ResetText();
                    //txtCustomerId.ResetText();
                    //txtCustomerName.ResetText();
                    //txtMortgagorNationalCode.ResetText();
                    //txtMortgagorName.ResetText();
                    //txtMandehAsl.ResetText();
                    //txtMandehSood.ResetText();
                    //txtMandehJarimeh.ResetText();
                    //txtMandehHazineh.ResetText();
                    //txtMandehAbonman.ResetText();
                    //cboContractPlan.SelectedIndex = 0;
                    //txtDateDebtUpdate.ResetText();
                    //txtLevelId.ResetText();
                    //txtContractLevelName.ResetText();
                   
                    pnlLegalInfo.Enabled = true;
                    //txtNotaryId.ResetText();
                    //txtNotaryName.ResetText();
                    //txtPlaqueNo.ResetText();
                    //txtPlaqueAddress.ResetText();
                    //txtEvaluationAmount1.ResetText();
                    //txtEvaluationAmount2.ResetText();
                    //txtMortgageNo.ResetText();
                    //txtIndicatorId.ResetText();
                    //txtDateAuction.ResetText();
                    //txtModifiedDate.ResetText();

                    grpExpertsInfo.Enabled = false;
                    //txtExpertId.ResetText();
                    //lblExpertName.ResetText();
                    //lblAgentName.Tag = string.Empty;
                    //lblAgentName.ResetText();


                    pnlSave.Enabled = true;

                    cboBailType.Focus();
                    cboBailType.Select();
                    break;

                case FormStatusEnum.New://زمانیکه کاربر دکمه جدید را انتخاب می کند یا بعد از ذخیره اطلاعات و فرم آماده جستجو جدید است
                    this.thisRow = null;

                    btnNewLegalFile.Enabled = true;
                    btnClone.Enabled = false;
                    btnEditLegalFile.Enabled = false;
                    btnChangeLevels.Enabled = false;
                    btnSendMessage.Enabled = false;
                    btnChangeExpertId.Enabled = false;
                    btnChangeAgentId.Enabled = false;
                    btnLogs.Enabled = false;
                    pnlPlaques.Enabled = false;
                    colDeleteRow.Visible = false;

                    pnlSearch.Enabled = true;
                    txtContractId.ResetText();
                    txtContractId.ReadOnly = false;
                    btnSearch.Enabled = true;
                    lblFileStatus.ResetText();

                    pnlFileInfo.Enabled = false;
                    cboBailType.SelectedIndex = 0;
                    txtFileId.ResetText();
                    txtBranchId.ResetText();
                    lblBranchName.ResetText();
                    txtCustomerId.ResetText();
                    txtCustomerName.ResetText();
                    txtMandehAsl.ResetText();
                    txtMandehSood.ResetText();
                    txtMandehJarimeh.ResetText();
                    txtMandehHazineh.ResetText();
                    txtMandehAbonman.ResetText();
                    cboContractPlan.SelectedIndex = 0;
                    txtDateDebtUpdate.ResetText();
                    txtLevelId.ResetText();
                    txtContractLevelName.ResetText();
                   
                    pnlLegalInfo.Enabled = false;
                    txtNotaryId.ResetText();
                    txtNotaryName.ResetText();
                    txtEvaluationAmount1.ResetText();
                    txtEvaluationAmount2.ResetText();
                    txtMortgageNo.ResetText();
                    txtIndicatorId.ResetText();
                    txtDateAuction.ResetText();
                    txtModifiedDate.ResetText();

                    grpExpertsInfo.Enabled = false;
                    txtExpertId.ResetText();
                    lblExpertName.ResetText();
                    lblAgentName.Tag = string.Empty;
                    lblAgentName.ResetText();

                    pnlSave.Enabled = false;

                    txtContractId.Focus();
                    txtContractId.Select();
                    break;
              
                case FormStatusEnum.Insert://زمانیکه شماره قرارداد مورد نظر در سیستم وجود نداشته باشد و فرم آماده ورود اطلاعات است
                    this.thisRow = null;

                    btnNewLegalFile.Enabled = true;
                    btnClone.Enabled = false;
                    btnEditLegalFile.Enabled = false;
                    btnChangeLevels.Enabled = false;
                    btnSendMessage.Enabled = false;
                    btnChangeExpertId.Enabled = false;
                    btnChangeAgentId.Enabled = false;
                    btnLogs.Enabled = false;
                    pnlPlaques.Enabled = true;
                    colDeleteRow.Visible = true;
                    colDeleteRow.VisibleIndex = 0;

                    pnlSearch.Enabled = false;
                    //txtContractId.ResetText();
                    txtContractId.ReadOnly = true;
                    btnSearch.Enabled = false;
                    lblFileStatus.Text = "وضعیت: جدید";

                    pnlFileInfo.Enabled = true;
                    cboBailType.SelectedIndex = 0;
                    txtFileId.ResetText();
                    txtBranchId.ResetText();
                    lblBranchName.ResetText();
                    txtCustomerId.ResetText();
                    txtCustomerName.ResetText();
                    txtMandehAsl.ResetText();
                    txtMandehSood.ResetText();
                    txtMandehJarimeh.ResetText();
                    txtMandehHazineh.ResetText();
                    txtMandehAbonman.ResetText();
                    cboContractPlan.SelectedIndex = 0;
                    txtDateDebtUpdate.ResetText();
                    txtLevelId.ResetText();
                    txtContractLevelName.ResetText();
                  
                    pnlLegalInfo.Enabled = true;
                    txtNotaryId.ResetText();
                    txtNotaryName.ResetText();
                    txtEvaluationAmount1.ResetText();
                    txtEvaluationAmount2.ResetText();
                    txtMortgageNo.ResetText();
                    txtIndicatorId.ResetText();
                    txtDateAuction.ResetText();
                    txtModifiedDate.ResetText();

                    grpExpertsInfo.Enabled = true;
                    txtExpertId.ResetText();
                    lblExpertName.ResetText();
                    lblAgentName.Tag = string.Empty;
                    lblAgentName.ResetText();

                    pnlSave.Enabled = true;

                    txtFileId.Focus();
                    txtFileId.Select();
                    break;
               
                case FormStatusEnum.Clone://زمانی که  دکمه کلون توسط کاربر انتخاب شده است
                    btnNewLegalFile.Enabled = true;
                    btnClone.Enabled = false;
                    btnEditLegalFile.Enabled = false;
                    btnChangeLevels.Enabled = false;
                    btnSendMessage.Enabled = false;
                    btnChangeExpertId.Enabled = false;
                    btnChangeAgentId.Enabled = false;
                    btnLogs.Enabled = false;
                    pnlPlaques.Enabled = true;
                    colDeleteRow.Visible = true;
                    colDeleteRow.VisibleIndex = 0;

                    pnlSearch.Enabled = true;
                    txtContractId.ResetText();
                    txtContractId.ReadOnly = false;
                    btnSearch.Enabled = false;
                    lblFileStatus.ResetText();

                    pnlFileInfo.Enabled = true;
                    //cboBailType.SelectedIndex = 0;
                    //txtFileId.ResetText();
                    //txtBranchId.ResetText();
                    //lblBranchName.ResetText();
                    txtCustomerId.ResetText();
                    txtCustomerName.ResetText();
                    //txtMortgagorNationalCode.ResetText();
                    //txtMortgagorName.ResetText();
                    txtMandehAsl.ResetText();
                    txtMandehSood.ResetText();
                    txtMandehJarimeh.ResetText();
                    txtMandehHazineh.ResetText();
                    txtMandehAbonman.ResetText();
                    cboContractPlan.SelectedIndex = 0;
                    txtDateDebtUpdate.ResetText();
                    txtLevelId.ResetText();
                    txtContractLevelName.ResetText();

                    pnlLegalInfo.Enabled = true;
                    //txtNotaryId.ResetText();
                    //txtNotaryName.ResetText();
                    //txtPlaqueNo1.ResetText();
                    //txtPlaqueNo2.ResetText();
                    //txtPlaqueNo3.ResetText();
                    //txtPlaqueAddress.ResetText();
                    //txtEvaluationAmount1.ResetText();
                    //txtEvaluationAmount2.ResetText();
                    txtMortgageNo.ResetText();
                    txtIndicatorId.ResetText();
                    txtDateAuction.ResetText();
                    txtModifiedDate.ResetText();

                    grpExpertsInfo.Enabled = true;
                    //txtExpertId.ResetText();
                    //lblExpertName.ResetText();
                    lblAgentName.Tag = string.Empty;
                    lblAgentName.ResetText();

                    pnlSave.Enabled = true;

                    txtContractId.Focus();
                    txtContractId.Select();
                    break;
                default:
                    break;
            }
        }

        private void btnNewLegalFile_Click(object sender, EventArgs e)
        {
            this.ViewMode(FormStatusEnum.New);
        }
      
        private void btnClone_Click(object sender, EventArgs e)
        {
            this.ViewMode(FormStatusEnum.Clone);
        }

        private void btnEditLegalFile_Click(object sender, EventArgs e)
        {
            this.ViewMode(FormStatusEnum.Edit);
        }
      
        private void btnNotariesList_Click(object sender, EventArgs e)
        {
            btnExpertsList.Select();
            dlgNotariesList dlg = new dlgNotariesList();
            DialogResult dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                if (dlg.NotaryId.Length > 0)
                {
                    txtNotaryId.Text = dlg.NotaryId;
                    txtNotaryName.Text = dlg.NotaryName;
                }
            }

        }

        private void txtContractId_EditValueChanged(object sender, EventArgs e)
        {
            if (txtContractId.Text.Length > 0)
            {
                if (!ContractId.IsValid(txtContractId.Text))
                {
                    txtContractId.BackColor = Color.MistyRose;
                    txtContractId.Properties.ContextImageOptions.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/status/warning_16x16.png");
                }
                else
                {
                    txtContractId.BackColor = Color.White;
                    txtContractId.Properties.ContextImageOptions.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/conditional%20formatting/iconsetsymbols3_16x16.png");
                }
            }
            else
            {
                txtContractId.BackColor = Color.White;
                txtContractId.Properties.ContextImageOptions.Image = null;
            }
        }

        private void btnLegalFileStatus_Click(object sender, EventArgs e)
        {
            if (txtFileId.Text.Trim().Length == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً ابتدا شماره پرونده را ثبت نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (gridView2.RowCount == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً ابتدا شماره پلاکهای ثبتی پرونده را ثبت نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dlgRes = new dlgChangeLevels(this, thisRow).ShowDialog();
            if (dlgRes == System.Windows.Forms.DialogResult.OK)
                btnSearch_Click(null, EventArgs.Empty);
        }

        private void btnChangeExpertId_Click(object sender, EventArgs e)
        {
            if (thisRow != null)
            {
                long contractId = long.Parse(thisRow["ContractID"].ToString());
                int levelId = int.Parse(thisRow["LevelID"].ToString());

                dlgUsersList dlg = new dlgUsersList(Users.GetWorkGroupUsers(true), false);
                DialogResult dlgResult = dlg.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    if (dlg.UserId > 0 & dlg.UserName.Length > 0)
                    {
                        if (txtExpertId.Text == dlg.UserId.ToString())
                        {
                            string message = string.Format("این پرونده قبلاً به {0} ارجاع گردیده است", Users.GetUserNameWithSexByID(dlg.UserId));
                            DevExpress.XtraEditors.XtraMessageBox.Show(message, "تایید", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                            args.Icon = System.Drawing.SystemIcons.Warning;
                            args.Caption = "تغییر کارشناس";
                            args.Text = string.Format("آیا از ارجاع پرونده به {0} اطمینان کامل حاصل دارید؟", Users.GetUserNameWithSexByID(dlg.UserId));
                            args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                            DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                            if (dlgRes != System.Windows.Forms.DialogResult.Yes)
                                return;
                        }

                        string queryResult = LegalFilesManager.UpdateExpertId(contractId, dlg.UserId);
                        if (queryResult.Length > 0)
                        {
                            dlgDataLogs.AddLegalLog(contractId.ToString(), levelId, 7, "پرونده جهت بررسی به " + Users.GetUserNameWithSexByID(dlg.UserId) + " ارجاع شد");
                            DevExpress.XtraEditors.XtraMessageBox.Show("عملیات ارجاع با موفقیت انجام شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void btnChangeAgentId_Click(object sender, EventArgs e)
        {
            if (thisRow != null)
            {
                long contractId = long.Parse(thisRow["ContractID"].ToString());
                int levelId = int.Parse(thisRow["LevelID"].ToString());

                dlgUsersList dlg = new dlgUsersList(Users.GetWorkGroupUsers(true), false);
                DialogResult dlgResult = dlg.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    if (dlg.UserId > 0 & dlg.UserName.Length > 0)
                    {
                        if (Numeral.AnyToInt32(lblAgentName.Tag) == dlg.UserId)
                        {
                            string message = string.Format("این پرونده قبلاً به {0} ارجاع گردیده است", Users.GetUserNameWithSexByID(dlg.UserId));
                            DevExpress.XtraEditors.XtraMessageBox.Show(message, "تایید", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {

                            DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                            args.Icon = System.Drawing.SystemIcons.Warning;
                            args.Caption = "تغییر مامور اجرا";
                            args.Text = string.Format("آیا از ارجاع پرونده به {0} اطمینان کامل حاصل دارید؟", Users.GetUserNameWithSexByID(dlg.UserId));
                            args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                            DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                            if (dlgRes != System.Windows.Forms.DialogResult.Yes)
                                return;
                        }
                    }

                    string queryResult = LegalFilesManager.UpdateAgentId(contractId, dlg.UserId);
                    if (queryResult.Length > 0)
                    {
                        dlgDataLogs.AddLegalLog(contractId.ToString(), levelId, 7, "پرونده جهت پیگیری حقوقی به " + Users.GetUserNameWithSexByID(dlg.UserId) + " ارجاع شد");
                        DevExpress.XtraEditors.XtraMessageBox.Show("عملیات ارجاع با موفقیت انجام شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnAddPlaque_Click(object sender, EventArgs e)
        {
            if (txtFileId.Text.Length > 0)
                new dlgAddPlaque(null, (DataTable)gridControl2.DataSource, txtFileId.Text).ShowDialog();
        }

        private void btnEditPlaque_Click(object sender, EventArgs e)
        {
            DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (row != null)
            {
                new dlgAddPlaque(row, (DataTable)gridControl2.DataSource, txtFileId.Text).ShowDialog();
            }
        }

        private void btnDeletePlaque_Click(object sender, EventArgs e)
        {
            DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (row != null)
            {
                DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args.Icon = System.Drawing.SystemIcons.Warning;
                args.Caption = "هشدار";
                args.Text = "آیا از حذف پلاک ثبتی انتخاب شده اطمینان کامل حاصل دارید؟";
                args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    gridView2.DeleteRow(gridView2.FocusedRowHandle);
                }
            }
        }

        private void btnDebtUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ContractId.IsValid(txtContractId.Text))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("شماره قرارداد وارد شده معتبر نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                btnDebtUpdate.Enabled = false;
                Application.DoEvents();
                DataRow reportRow = SourceReportsManager.GetReportById(468, 122);
                Dictionary<string, object> properties = reportRow.Table.Columns
                    .Cast<DataColumn>()
                    .ToDictionary(c => c.ColumnName, c => reportRow[c]);
                properties.Add("SelectedDates", string.Empty);

                DataTable misTbl = QueryManager.QueryBuilder(QueryProperties.Fill(properties), txtContractId.Text).Tables[0];
                if (misTbl != null && misTbl.Rows.Count == 1)
                {
                    DataRow row = misTbl.Rows[0];
                    Branches.BranchInfo br = Branches.GetBranchById(row["BranchID"].ToString(), true);
                    txtBranchId.Text = br.BranchId;
                    lblBranchName.Text = br.BranchName;
                    txtCustomerId.Text = row["CustomerID"].ToString();
                    txtCustomerName.Text = row["CustomerName"].ToString().Replace(" - ", " ");
                    txtMandehAsl.Text = row["MandehAsl"].ToString();
                    txtMandehSood.Text = row["MandehSood"].ToString();
                    txtMandehJarimeh.Text = row["MandehJarimeh"].ToString();
                    cboContractPlan.Text = row["ContractPlan"].ToString();
                    txtDateDebtUpdate.Text = misTbl.TableName;
                }
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                btnDebtUpdate.Enabled = true;
            }
            catch (Exception ex)
            {
                btnDebtUpdate.Enabled = true;
                lblConnectionStatus.Text = string.Empty;
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            if (thisRow != null)
            {
                dlgDataLogs dlg = new dlgDataLogs(false);
                dlg.FillLegalFileLogs(thisRow);
                dlg.ShowDialog();
            }
        }

        private void btnAddMessage_Click(object sender, EventArgs e)
        {
            if (txtFileId.Text.Trim().Length == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً ابتدا شماره پرونده را ثبت نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (gridView2.RowCount == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً شماره پلاکهای ثبتی پرونده را ثبت نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else 
            {
                DataTable tablePlaques = (DataTable)gridControl2.DataSource;
                if (tablePlaques.GetChanges() != null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("لطفاً ابتدا شماره پلاکهای ثبت شده را ذخیره نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            DataTable table = (DataTable)gridControl1.DataSource;
            new dlgSendMessage(thisRow, table).ShowDialog();
        }

        private void txtMandeh_EditValueChanged(object sender, EventArgs e)
        {
            double total =  Numeral.AnyToLong(txtMandehAsl.Text) + Numeral.AnyToLong(txtMandehSood.Text)+Numeral.AnyToLong(txtMandehJarimeh.Text) + Numeral.AnyToLong(txtMandehHazineh.Text) + Numeral.AnyToLong(txtMandehAbonman.Text);
            txtTotalDebt.Text = total.ToString();
        }

        private void repositoryShowLog_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (row != null)
            {
                dlgDataLogs dlg = new dlgDataLogs(false);
                dlg.FillLegalFileLogs(row);
                dlg.ShowDialog();
            }
        }

        private void repositoryEditRow_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (row != null)
                ShowContractValues(row);
        }

        private void repositoryItemDeleteRow_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            btnDeletePlaque_Click(null, EventArgs.Empty);
        }

    }
}
