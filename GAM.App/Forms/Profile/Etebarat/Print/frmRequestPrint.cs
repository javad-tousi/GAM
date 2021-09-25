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
using MD.PersianDateTime;
using GAM.Connections;
using GAM.Forms.Profile.Etebarat.Review;
using GAM.Forms.Reports.Queries;
using System.Diagnostics;


namespace GAM.Forms.Profile.Etebarat.Print
{
    public partial class frmRequestPrint : DevExpress.XtraEditors.XtraForm
    {
        public frmRequestPrint()
        {
            InitializeComponent();
            LoadData();
            ChangeView(FormStatusEnum.New);
            UDF.ToFarsiLanguage();
        }

        #region Properties

        private DataRow thisRow { get; set; }

        public enum FormStatusEnum { Show, New, Edit, Clone, Insert };
        private FormStatusEnum FormStatus;

        private dlgHistory dlgHistory;
        #endregion

        #region Print
       
        private string SetNumberConditions()
        {
            StringBuilder sb = new StringBuilder();
            int row = 0;
            for (int i = 0; i < txtConditions.Lines.Length; i++)
            {
                if (txtConditions.Lines[i].Length > 0)
                {
                    sb.AppendLine(++row + "-" + txtConditions.Lines[i]);
                }
            }

            return sb.ToString().Trim();
        }

      
        #endregion 

        #region Methods
        
        private void LoadData()
        {
            DataTable tblConditions = Facilitys.GetConditions();
            if (tblConditions.Rows.Count > 0)
            {
                DataTable dataTable1 = tblConditions.AsEnumerable().Where(x => bool.Parse(x["IsEnable"].ToString()) & x["Category"].ToString() != "اطلاعیه").CopyToDataTable();
                DataTable dataTable2 = tblConditions.AsEnumerable().Where(x => bool.Parse(x["IsEnable"].ToString()) & x["Category"].ToString() == "اطلاعیه").CopyToDataTable();
                gridControl1.DataSource = dataTable1;
                gridControl2.DataSource = dataTable2;
                txtSearch1.Select();
            }
        }

        private string GetConditions(string facilityId, string type, string bails1, string bails2)
        {
            StringBuilder note = new StringBuilder();

            if (type == "موردی")
            {
                foreach (string text in Facilitys.GetFacilityConditions(facilityId, "Moredi"))
                    note.AppendLine(text);
            }
            if (type == "حد اعتباری")
            {
                foreach (string text in Facilitys.GetFacilityConditions(facilityId, "Had"))
                    note.AppendLine(text);
            }
            if (type == "سقف اعتباری")
            {
                foreach (string text in Facilitys.GetFacilityConditions(facilityId, "Saghf"))
                    note.AppendLine(text);
            }
            if (type == "تمدید")
            {
                foreach (string text in Facilitys.GetFacilityConditions(facilityId, "Tamdid"))
                    note.AppendLine(text);
            }
            if (type == "تبدیل")
            {
                foreach (string text in Facilitys.GetFacilityConditions(facilityId, "Tabdil"))
                    note.AppendLine(text);
            }
            if (type == "متمم")
            {
                foreach (string text in Facilitys.GetFacilityConditions(facilityId, "Motamem"))
                    note.AppendLine(text);
            }
            if (type == "تخفیف کارمزد")
            {
                foreach (string text in Facilitys.GetFacilityConditions(facilityId, "Takhfif"))
                    note.AppendLine(text);
            }
            if (type == "موردی" | type == "حد اعتباری" | type == "سقف اعتباری" | type == "تغییر وثیقه")
            {

                string str1 = string.Empty;
                string str2 = string.Empty;

                if (chkIsLegalPerson.Checked)
                {
                    if (bails1 == "سپرده + ملک + سفته")
                        str1 = ("به نحوی که ظهر سفته ها علاوه بر ضامنین توسط راهنین وثیقه ملکی، صاحبان سپرده و صاحبان اصلی شرکت نیز تعهد و تضمین گردد");
                    if (bails1 == "سپرده + ملک + قرارداد")
                        str1 = ("به نحوی که ذیل قراردادها علاوه بر ضامنین توسط راهنین وثیقه ملکی، صاحبان سپرده و صاحبان اصلی شرکت نیز تعهد و تضمین گردد");
                    if (bails1 == "سپرده + سفته")
                        str1 = ("به نحوی که ظهر سفته ها علاوه بر ضامنین توسط صاحبان سپرده و صاحبان اصلی شرکت نیز تعهد و تضمین گردد");
                    if (bails1 == "سپرده + قرارداد")
                        str1 = ("به نحوی که ذیل قراردادها علاوه بر ضامنین توسط صاحبان سپرده و صاحبان اصلی شرکت نیز تعهد و تضمین گردد");
                    if (bails1 == "ملک + سفته")
                        str1 = ("به نحوی که ظهر سفته ها علاوه بر ضامنین توسط راهنین وثیقه ملکی و صاحبان اصلی شرکت نیز تعهد و تضمین گردد");
                    if (bails1 == "ملک + قرارداد")
                        str1 = ("به نحوی که ذیل قراردادها علاوه بر ضامنین توسط راهنین وثیقه ملکی و صاحبان اصلی شرکت نیز تعهد و تضمین گردد");
                    if (bails1 == "سفته")
                        str1 = ("به نحوی که ظهر سفته ها علاوه بر ضامنین توسط صاحبان اصلی شرکت نیز تعهد و تضمین گردد");
                    if (bails1 == "قرارداد")
                        str1 = ("به نحوی که ذیل قراردادها علاوه بر ضامنین توسط صاحبان اصلی شرکت نیز تعهد و تضمین گردد");

                    if (txtCustomerName.Text.Contains("رضوی") |
                        txtCustomerName.Text.Contains("تلاشگران فهیم توس") |
                        txtCustomerName.Text.Contains("یارا طب") |
                        txtCustomerName.Text.Contains("یاراطب") |
                        txtCustomerName.Text.Contains("داروسازی ثامن") |
                        txtCustomerName.Text.Contains("سامان دارو") |
                        txtCustomerName.Text.Contains("سنگاه") |
                        txtCustomerName.Text.Contains("شهاب خودرو") |
                        txtCustomerName.Text.Contains("قند آبکوه") |
                        txtCustomerName.Text.Contains("قندآبکوه") |
                        txtCustomerName.Text.Contains("همیاران قدس") |
                        txtCustomerName.Text.Contains("فهیم توس") |
                        txtCustomerName.Text.Contains("موقوفات چناران") |
                        txtCustomerName.Text.Contains("ثابت خراسان") |
                        txtCustomerName.Text.Contains("نساجی خسروی"))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("توجه: در شرکت های وابسته به آستان قدس جمله به نحوی که ظهر سفته ها ... لازم نیست!", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (bails1 == "سپرده + ملک + سفته")
                        str1 = ("به نحوی که ظهر سفته ها علاوه بر ضامنین توسط راهنین وثیقه ملکی و صاحبان سپرده نیز تعهد و تضمین گردد");
                    if (bails1 == "سپرده + ملک + قرارداد")
                        str1 = ("به نحوی که ذیل قراردادها علاوه بر ضامنین توسط راهنین وثیقه ملکی و صاحبان سپرده نیز تعهد و تضمین گردد");
                    if (bails1 == "سپرده + سفته")
                        str1 = ("به نحوی که ظهر سفته ها علاوه بر ضامنین توسط صاحبان سپرده نیز تعهد و تضمین گردد");
                    if (bails1 == "سپرده + قرارداد")
                        str1 = ("به نحوی که ذیل قراردادها علاوه بر ضامنین توسط صاحبان سپرده نیز تعهد و تضمین گردد");
                    if (bails1 == "ملک + سفته")
                        str1 = ("به نحوی که ظهر سفته ها علاوه بر ضامنین توسط راهنین وثیقه ملکی نیز تعهد و تضمین گردد");
                    if (bails1 == "ملک + قرارداد")
                        str1 = ("به نحوی که ذیل قراردادها علاوه بر ضامنین توسط راهنین وثیقه ملکی نیز تعهد و تضمین گردد");
                }

                if (str1.Length > 0 & txtZamenCount.Value > 0)
                {
                    str1 = str1 + string.Format(" (حداقل {0} ضامن ..........)" , txtZamenCount.Value);
                }

                if (bails2.Contains("سفته") & !bails1.Contains("سفته"))
                    str2 = "اخذ سفته های کاملا معتبر جهت تعهد ارائه پروانه سبز گمرکی " + str1.Replace("ذیل قراردادها", "ظهر سفته ها");

                if (bails2.Contains("قرارداد") & !bails1.Contains("قرارداد"))
                    str2 = "اخذ قرارداد لازم الاجرا جهت تعهد ارائه پروانه سبز گمرکی " + str1.Replace("ظهر سفته ها", "ذیل قراردادها");

                if (bails2.Contains("چک") & str1 == string.Empty)
                    str2 = str2 + (" و اخذ یک برگ چک بعنوان پوشش اضافی");

                if (bails2.Contains("چک") & str2 == string.Empty)
                    str1 = str1 + (" و اخذ یک برگ چک بعنوان پوشش اضافی");

                if (bails2.Contains("چک") & str1.Length > 0 & str2.Length > 0)
                    str2 = str2 + (" و اخذ یک برگ چک بعنوان پوشش اضافی");

                if (bails1.Contains("سفته") & chkValidBails.Checked)
                {
                    str1 = "در قبال سفته های کاملا معتبر و متفاوت " + str1;
                }

                if (str1.Length > 0)
                    note.AppendLine(str1);

                if (str2.Length > 0)
                    note.AppendLine(str2);

                if (txtCustomerName.Text.Contains("تعاونی ") | txtCustomerName.Text.Contains("تعاونیهای "))
                {
                    if (facilityId.Contains("اعتبار اسنادی") | facilityId.Contains("ضمانت نامه"))
                        note.AppendLine("ایجاد تعهدات منوط به موافقت مجمع عمومی عادی شرکت و ارائه آن به شعبه می‌باشد");
                    else
                        note.AppendLine("اعطای تسهیلات منوط به موافقت مجمع عمومی عادی شرکت و ارائه آن به شعبه می‌باشد");
                }
            }

            if (type == "تقسیط" & cboRequestPlane.Text.Length > 0)
            {
                new dlgInstalmentsTable(this).ShowDialog();
            }

            return note.ToString();
        }

        private string CheckInputValues()
        {
            if (cboRequestType.Text.Length == 0)
                return "لطفا نوع پیشنهاد را مشخص کنید";
            if (cboRequestType.Text == "موردی" & txtFacilityId.TextLength == 0)
                return "لطفا نوع تسهیلات را مشخص کنید";
            if (cboRequestType.Text == "موردی" & Numeral.AnyToDouble(txtRequestAmount.Text) == 0)
                return "لطفا مبلغ تسهیلات را مشخص کنید";
            if (txtCustomerName.Text.Length == 0)
                return "لطفا نام متقاضی را وارد کنید";
            if (txtBranchId.TextLength == 0)
                return "لطفا نام شعبه را مشخص کنید";
            if (txtExpertId.TextLength == 0)
                return "لطفا نام کارشناس را مشخص کنید";
            if (cboRequestType.Text == "تقسیط" & cboRequestPlane.Text.Length == 0)
                return "لطفا نوع طبقه تقسیط را مشخص کنید";
            if ((cboRequestType.Text == "مصوبه خاص" | cboRequestType.Text == "تقسیط" | txtFacilityName.Text.Contains("زندانیان")) & txtProvinceLetterNo.Text.Length == 0)
               return "لطفا شناسه نامه مصوبه را وارد نمائید";
            if (cboRequestType.Text == "تخفیف کارمزد" & txtRequestAmount.Text == "0")
                return "لطفا درصد تخفیف کارمزد را وارد نمایید";
            if (Numeral.AnyToLong(txtFileId.Text) > 0 & Numeral.AnyToLong(txtCoverNo.Text) == 0)
                return "شماره جلد پرونده مشخص نشده است";
            return string.Empty;
        }

        public void ShowRequestValues(DataTable dt)
        {
            int rowsCount = dt.Rows.Count;
            DataTable tableSorted = dt.AsEnumerable().OrderByDescending(x => x["ModifiedDate"]).ThenByDescending(x => x["ModifiedTime"]).CopyToDataTable();
            if (rowsCount > 0)
            {
                DataRow row = tableSorted.Rows[0];
                thisRow = row;
                lblRequestStatus.Text = row["RequestStatus"].ToString();
                cboRequestType.Text = row["RequestType"].ToString();
                cboRequestPlane.Text = row["RequestPlane"].ToString();
                Branches.BranchInfo branch = Branches.GetBranchById(row["BranchID"].ToString(), true);
                txtBranchId.Text = branch.BranchId;
                lblBranchName.Text = branch.BranchName;
                if (Numeral.AnyToInt32(row["CustomersCount"]) > 0)
                    txtCustomersCount.Value = Numeral.AnyToInt32(row["CustomersCount"]);
                txtCustomerId.Text = row["CustomerID"].ToString();
                txtCustomerName.Text = row["CustomerName"].ToString();
                chkIsLegalPerson.Checked = bool.Parse(row["IsLegalPerson"].ToString());
                txtFileId.Text = row["FileID"].ToString();
                txtCoverNo.Text = row["CoverNo"].ToString();
                txtFacilityId.Text = row["FacilityID"].ToString();
                txtFacilityName.Text = Facilitys.GetFacilityNameById(row["FacilityID"].ToString());
                cboBails1.Text = row["Bails1"].ToString();
                cboBails2.Text = row["Bails2"].ToString();
                txtRequestAmount.Text = row["RequestAmount"].ToString();
                txtCreditCommittee.Text = row["CreditCommittee"].ToString();
                txtExpertId.Text = row["ExpertID"].ToString();
                lblExpertName.Text = Users.GetUserNameById(Numeral.AnyToInt32(row["ExpertID"]));
                txtExpertId.Text = row["ExpertId"].ToString();
                txtModifiedDate.Text = row["ModifiedDate"].ToString();
                txtConditions.Text = row["Conditions"].ToString();
                txtProvinceLetterNo.Text = row["ProvinceLetterNo"].ToString();
                if (rowsCount - 1 > 0)
                    btnRequestHistory.Enabled = true;

                if (row["ReviewNo"].ToString().Length > 0)
                    btnShowReviewReport.Enabled = true;
            }

            if (rowsCount > 1)
            {
                dlgHistory = new dlgHistory(this);
                foreach (DataRow row in tableSorted.Rows)
                {
                    string serial = row["RequestSerial"].ToString();
                    string modifiedDate = PersianDate.Parse(row["ModifiedDate"].ToString()).ToStandard();
                    string requestType = row["RequestType"].ToString();
                    string branchId = row["BranchID"].ToString();
                    string branchName = Branches.GetBranchById(branchId, true).BranchName;
                    string customerName = row["CustomerName"].ToString();
                    string facilityId = row["FacilityID"].ToString();
                    string facilityName = Facilitys.GetFacilityNameById(facilityId);
                    string requestAmount = row["RequestAmount"].ToString();
                    dlgHistory.TableHistory.Rows.Add(serial, modifiedDate, requestType, branchId, branchName, customerName, facilityId, facilityName, requestAmount);
                }
            }

            txtRequestId.SelectAll();
        }
       
        public void ChangeView(FormStatusEnum status)
        {
            this.FormStatus = status;

            switch (status)
            {
                case FormStatusEnum.Show://زمانی که اطلاعات یافت شده اما پنل ها قفل می باشند
                    btnPrintPreview.Enabled = true;
                    btnNewRequest.Enabled = true;
                    btnClone.Enabled = true;
                    btnEditRequest.Enabled = true;
                    btnChangeExpertId.Enabled = true;
                    btnChangeStatus.Enabled = true;
                    btnDeleteRequest.Enabled = true;
                    btnShowReviewReport.Enabled = true;
                    btnRequestHistory.Enabled = true;
                    btnShowLogs.Enabled = true;
                    btnShowReviewReport.Enabled = false;

                    pnlSearch.Enabled = true;
                    txtRequestId.ReadOnly = false;
                    btnSearch.Enabled = true;
                    lblRequestStatus.ResetText();

                    pnlRequestInfo.Enabled = false;
                    cboRequestType.SelectedIndex = 0;
                    cboRequestPlane.SelectedIndex = 0;
                    txtBranchId.ResetText();
                    lblBranchName.ResetText();
                    txtCustomersCount.Value = 1;
                    txtFileId.ResetText();
                    txtCoverNo.ResetText();
                    txtCustomerId.ResetText();
                    txtCustomerName.ResetText();
                    chkIsLegalPerson.Checked = false;
                    txtFacilityId.ResetText();
                    txtFacilityName.ResetText();
                    cboBails1.ResetText();
                    cboBails2.ResetText();
                    txtRequestAmount.Text = "0";

                    pnlExpertInfo.Enabled = false;
                    txtExpertId.ResetText();
                    lblExpertName.ResetText();
                    txtExpertId.ResetText();
                    txtModifiedDate.ResetText();

                    pnlCreditCommittee.Enabled = false;
                    txtCreditCommittee.Text = "مدیریت شعب";
                    txtProvinceLetterNo.ResetText();
                    txtConditions.ResetText();
                    chkValidBails.Checked = false;

                    pnlSave.Enabled = false;
                    btnEditQuery.Enabled = true;

                    txtRequestId.Focus();
                    txtRequestId.SelectAll();
                    break;

                case FormStatusEnum.Edit://زمانی که  اطلاعات یافت شده و دکمه ویرایش توسط کاربر انتخاب شده است
                    btnPrintPreview.Enabled = true;
                    btnNewRequest.Enabled = true;
                    btnClone.Enabled = true;
                    btnEditRequest.Enabled = false;
                    btnChangeExpertId.Enabled = true;
                    btnChangeStatus.Enabled = true;
                    btnDeleteRequest.Enabled = true;
                    btnShowReviewReport.Enabled = true;
                    btnRequestHistory.Enabled = true;
                    btnShowLogs.Enabled = true;

                    pnlSearch.Enabled = false;
                    txtRequestId.ReadOnly = true;
                    btnSearch.Enabled = true;
                    //lblRequestStatus.ResetText();

                    pnlRequestInfo.Enabled = true;
                    //cboRequestType.SelectedIndex = 0;
                    //cboRequestPlane.SelectedIndex = 0;
                    //txtBranchId.ResetText();
                    //lblBranchName.ResetText();
                    //txtCustomersCount.Value = 1;
                    //txtFileId.ResetText();
                    //txtCoverNo.ResetText();
                    //txtCustomerId.ResetText();
                    //txtCustomerName.ResetText();
                    //chkIsLegalPerson.Checked = false;
                    //txtFacilityId.ResetText();
                    //txtFacilityName.ResetText();
                    //cboBails1.ResetText();
                    //cboBails2.ResetText();
                    //txtRequestAmount.Text = "0";

                    pnlExpertInfo.Enabled = false;
                    //txtExpertId.ResetText();
                    //lblExpertName.ResetText();
                    //txtModifiedDate.ResetText();

                    pnlCreditCommittee.Enabled = true;
                    //txtCreditCommittee.Text = "مدیریت شعب";
                    //txtProvinceLetterNo.ResetText();
                    //txtConditions.ResetText();
                    chkValidBails.Checked = false;

                    pnlSave.Enabled = true;
                    btnEditQuery.Enabled = true;

                    cboRequestType.Focus();
                    cboRequestType.Select();
                    break;

                case FormStatusEnum.New://زمانیکه کاربر دکمه جدید را انتخاب می کند یا بعد از ذخیره اطلاعات و فرم آماده جستجو جدید است
                    btnNewRequest.Enabled = false;
                    btnClone.Enabled = false;
                    btnEditRequest.Enabled = false;
                    btnChangeExpertId.Enabled = false;
                    btnChangeStatus.Enabled = false;
                    btnDeleteRequest.Enabled = false;
                    btnShowReviewReport.Enabled = false;
                    btnRequestHistory.Enabled = false;
                    btnShowLogs.Enabled = false;
                    btnShowReviewReport.Enabled = false;

                    pnlSearch.Enabled = true;
                    txtRequestId.ReadOnly = false;
                    btnSearch.Enabled = true;
                    lblRequestStatus.ResetText();

                    pnlRequestInfo.Enabled = false;
                    cboRequestType.SelectedIndex = 0;
                    cboRequestPlane.SelectedIndex = 0;
                    txtBranchId.ResetText();
                    lblBranchName.ResetText();
                    txtCustomersCount.Value = 1;
                    txtFileId.ResetText();
                    txtCoverNo.ResetText();
                    txtCustomerId.ResetText();
                    txtCustomerName.ResetText();
                    chkIsLegalPerson.Checked = false;
                    txtFacilityId.ResetText();
                    txtFacilityName.ResetText();
                    cboBails1.ResetText();
                    cboBails2.ResetText();
                    txtRequestAmount.Text = "0";

                    pnlExpertInfo.Enabled = false;
                    txtExpertId.ResetText();
                    lblExpertName.ResetText();
                    txtExpertId.ResetText();
                    txtModifiedDate.ResetText();

                    pnlCreditCommittee.Enabled = false;
                    txtCreditCommittee.Text = "مدیریت شعب";
                    txtProvinceLetterNo.ResetText();
                    txtConditions.ResetText();
                    chkValidBails.Checked = false;

                    pnlSave.Enabled = false;
                    btnEditQuery.Enabled = true;

                    txtRequestId.ResetText();
                    txtRequestId.Focus();
                    txtRequestId.SelectAll();
                    break;

                case FormStatusEnum.Insert://زمانیکه شماره قرارداد مورد نظر در سیستم وجود نداشته باشد و فرم آماده ورود اطلاعات است
                    btnNewRequest.Enabled = true;
                    btnClone.Enabled = false;
                    btnEditRequest.Enabled = false;
                    btnChangeExpertId.Enabled = false;
                    btnChangeStatus.Enabled = false;
                    btnDeleteRequest.Enabled = false;
                    btnShowReviewReport.Enabled = false;
                    btnRequestHistory.Enabled = false;
                    btnShowLogs.Enabled = false;
                    btnShowReviewReport.Enabled = false;

                    pnlSearch.Enabled = false;
                    txtRequestId.ReadOnly = true;
                    btnSearch.Enabled = false;
                    lblRequestStatus.ResetText();

                    pnlRequestInfo.Enabled = true;
                    cboRequestType.SelectedIndex = 0;
                    cboRequestPlane.SelectedIndex = 0;
                    txtBranchId.ResetText();
                    lblBranchName.ResetText();
                    txtCustomersCount.Value = 1;
                    txtFileId.ResetText();
                    txtCoverNo.ResetText();
                    txtCustomerId.ResetText();
                    txtCustomerName.ResetText();
                    chkIsLegalPerson.Checked = false;
                    txtFacilityId.ResetText();
                    txtFacilityName.ResetText();
                    cboBails1.ResetText();
                    cboBails2.ResetText();
                    txtRequestAmount.Text = "0";

                    pnlExpertInfo.Enabled = true;
                    txtExpertId.ResetText();
                    lblExpertName.ResetText();
                    txtExpertId.ResetText();
                    txtModifiedDate.ResetText();
                        
                    pnlCreditCommittee.Enabled = true;
                    txtCreditCommittee.Text = "مدیریت شعب";
                    txtProvinceLetterNo.ResetText();
                    txtConditions.ResetText();
                    chkValidBails.Checked = false;

                    pnlSave.Enabled = true;
                    btnEditQuery.Enabled = false;

                    cboRequestType.Focus();
                    cboRequestType.Select();
                    break;

                case FormStatusEnum.Clone://زمانی که  دکمه کلون توسط کاربر انتخاب شده است
                    Clipboard.SetText(txtRequestId.Text);
                    btnPrintPreview.Enabled = true;
                    btnNewRequest.Enabled = true;
                    btnClone.Enabled = false;
                    btnEditRequest.Enabled = false;
                    btnChangeExpertId.Enabled = false;
                    btnChangeStatus.Enabled = false;
                    btnDeleteRequest.Enabled = false;
                    btnShowReviewReport.Enabled = false;
                    btnRequestHistory.Enabled = false;
                    btnShowLogs.Enabled = false;
                    btnShowReviewReport.Enabled = false;

                    pnlSearch.Enabled = true;
                    txtRequestId.ReadOnly = false;
                    btnSearch.Enabled = false;
                    lblRequestStatus.ResetText();

                    pnlRequestInfo.Enabled = true;
                    //cboRequestType.SelectedIndex = 0;
                    //cboRequestPlane.SelectedIndex = 0;
                    //txtBranchId.ResetText();
                    //lblBranchName.ResetText();
                    //txtCustomersCount.Value = 1;
                    //txtFileId.ResetText();
                    //txtCoverNo.ResetText();
                    //txtCustomerId.ResetText();
                    //txtCustomerName.ResetText();
                    //chkIsLegalPerson.Checked = false;
                    //txtFacilityId.ResetText();
                    //txtFacilityName.ResetText();
                    //cboBails1.ResetText();
                    //cboBails2.ResetText();
                    //txtRequestAmount.Text = "0";

                    pnlExpertInfo.Enabled = true;
                    //txtExpertId.ResetText();
                    //lblExpertName.ResetText();
                    txtModifiedDate.ResetText();


                    pnlCreditCommittee.Enabled = true;
                    txtCreditCommittee.Text = "مدیریت شعب";
                    txtProvinceLetterNo.ResetText();
                    txtConditions.ResetText();
                    chkValidBails.Checked = false;

                    pnlSave.Enabled = true;
                    btnEditQuery.Enabled = false;

                    txtRequestId.ResetText();
                    txtRequestId.Focus();
                    txtRequestId.Select();
                    break;
                default:
                    break;
            }
        }

        public void SubmitQuery(bool sendtoCommittee) 
        {
            string errMessage = CheckInputValues();
            if (errMessage.Length == 0)
            {
                try
                {
                    lblConnectionStatus.Text = "لطفاً کمی صبر کنید ...";
                    Application.DoEvents();

                    if (this.FormStatus == FormStatusEnum.Clone)
                    {
                        if (RequestManager.GetRequestById(Numeral.AnyToLong(txtRequestId.Text.Trim())).Rows.Count > 0)
                        {
                            lblConnectionStatus.Text = string.Empty;
                            DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                            args.Icon = System.Drawing.SystemIcons.Warning;
                            args.Caption = "هشدار";
                            args.Text = "این شماره پیشنهاد قبلا مصوب شده است آیا مایل به ثبت مجدد آن می باشید؟";
                            args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                            args.DefaultButtonIndex = 1;
                            DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                            if (dlgRes != System.Windows.Forms.DialogResult.Yes)
                                return;
                        }
                    }

                    lblConnectionStatus.Text = "لطفاً کمی صبر کنید ...";
                    Application.DoEvents();

                    string serial = string.Empty;
                    string requestStatus = lblRequestStatus.Text;
                    long requestId = long.Parse(txtRequestId.Text.Trim());
                    string requestType = cboRequestType.Text;
                    string requestPlane = cboRequestPlane.Text;
                    int branchId = int.Parse(txtBranchId.Text);
                    int customersCount = (int)txtCustomersCount.Value;
                    string customerId = txtCustomerId.Text;
                    string customerName = txtCustomerName.Text.Trim();
                    bool isLegalPerson = chkIsLegalPerson.Checked;
                    long? fileId = Numeral.ToLongNullable(txtFileId.Text);
                    long? coverNo = Numeral.ToLongNullable(txtCoverNo.Text);
                    int facilityId = Numeral.AnyToInt32(txtFacilityId.Text);
                    string bails1 = cboBails1.Text;
                    string bails2 = cboBails2.Text;
                    long requestAmount = Numeral.AnyToLong(txtRequestAmount.Text);
                    string creditCommittee = txtCreditCommittee.Text;
                    long? provinceLetterNo = Numeral.ToLongNullable(txtProvinceLetterNo.Text);
                    int expertId = Numeral.AnyToInt32(txtExpertId.Text);
                    string conditions = txtConditions.Text.Trim();

                    if (this.FormStatus == FormStatusEnum.Insert | this.FormStatus == FormStatusEnum.New | this.FormStatus == FormStatusEnum.Clone)
                    {
                        lblConnectionStatus.Text = "لطفاً کمی صبر کنید ...";
                        Application.DoEvents();

                        if (sendtoCommittee)
                        {
                            serial = RequestManager.InsertQuery(RequestStatus.Eghdam, requestId, requestType, requestPlane, branchId, customersCount, customerId, customerName, isLegalPerson, fileId, coverNo, facilityId, bails1, bails2, requestAmount, creditCommittee, expertId, null, conditions, provinceLetterNo, string.Empty);
                            if (txtProvinceLetterNo.Text.Length > 0)
                                dlgDataLogs.AddRequestLog(serial, 1, string.Format("پیشنهاد طی شناسه نامه {0} به کمیته اعتباری مدیریت شعب ارسال شد", txtProvinceLetterNo.Text));
                            else
                                dlgDataLogs.AddRequestLog(serial, 1, "پیشنهاد به کمیته اعتباری مدیریت شعب ارسال شد");
                        }
                        else
                        {
                            serial = RequestManager.InsertQuery(RequestStatus.Barasi, requestId, requestType, requestPlane, branchId, customersCount, customerId, customerName, isLegalPerson, fileId, coverNo, facilityId, bails1, bails2, requestAmount, creditCommittee, expertId, null, conditions, provinceLetterNo, string.Empty);
                            dlgDataLogs.AddRequestLog(serial, 7, "پیشنهاد در سیستم ثبت شد");
                        }
                    }

                    if (this.FormStatus == FormStatusEnum.Edit)
                    {
                        lblConnectionStatus.Text = "لطفاً کمی صبر کنید ...";
                        Application.DoEvents();

                        if (sendtoCommittee)
                        {
                            serial = RequestManager.UpdateQuery(true, thisRow["RequestSerial"].ToString(), RequestStatus.Eghdam, requestId, requestType, requestPlane, branchId, customersCount, customerId, customerName, isLegalPerson, fileId, coverNo, facilityId, bails1, bails2, requestAmount, "مدیریت شعب", conditions, provinceLetterNo);
                            if (txtProvinceLetterNo.Text.Length > 0)
                                dlgDataLogs.AddRequestLog(serial, 1, string.Format("پیشنهاد طی شناسه نامه {0} به کمیته اعتباری مدیریت شعب ارسال شد", txtProvinceLetterNo.Text));
                            else
                                dlgDataLogs.AddRequestLog(serial, 1, "پیشنهاد به کمیته اعتباری مدیریت شعب ارسال شد");
                        }
                        else
                            serial = RequestManager.UpdateQuery(false, thisRow["RequestSerial"].ToString(), requestStatus, requestId, requestType, requestPlane, branchId, customersCount, customerId, customerName, isLegalPerson, fileId, coverNo, facilityId, bails1, bails2, requestAmount, creditCommittee, conditions, provinceLetterNo);
                    }

                    if (serial.Length > 0)
                    {
                        lblConnectionStatus.Text = string.Empty;
                        DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات با موفقیت ذخیره شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (sendtoCommittee & txtConditions.TextLength > 0)
                        {
                            new dlgFormNo(SetNumberConditions()).ShowDialog();
                        }
                    }
                    ChangeView(FormStatusEnum.New);
                    txtRequestId.Text = requestId.ToString();
                    txtRequestId.SelectAll();
                }
                catch (Exception ex)
                {
                    lblConnectionStatus.Text = ex.Message;
                    Application.DoEvents();
                }
            }
            else
                DevExpress.XtraEditors.XtraMessageBox.Show(errMessage, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
     
        #region Small Buttons Events
     
        private void btnEditRequest_Click(object sender, EventArgs e)
        {
            int date1 = PersianDateTime.Parse(int.Parse(thisRow["ModifiedDate"].ToString())).ToShortDateInt();
            int date2 = Network.GetNowPersianDate().AddDays(-30).ToSerial();
            if (date1 <= date2)
            {
                DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args.Icon = System.Drawing.SystemIcons.Warning;
                args.Text = "توجه: از آخرین اقدام برروی این پرونده به بیش از یک ماه گذشته می باشد آیا از ویرایش آن اطمینان دارید؟";
                args.DefaultButtonIndex = 1;
                args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                    ChangeView(FormStatusEnum.Edit);
                else
                    return;
            }
            ChangeView(FormStatusEnum.Edit);
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            if (thisRow != null)
            {
                var list = new Dictionary<string, string>();
                if (thisRow["ReviewNo"].ToString().Length > 0)
                {
                    list = RequestManager.GetSerialsByReviewNo(thisRow["ReviewNo"].ToString());
                }
                else if (thisRow["GroupID"].ToString().Length > 0)
                {
                    list = RequestManager.GetSerialsByGroupID(thisRow["GroupID"].ToString());
                }
                else if (thisRow["CustomerID"].ToString().Length > 0 && thisRow["CustomerID"].ToString() != "1")
                {
                    list = RequestManager.GetSerialsByCustomerId(thisRow["CustomerID"].ToString());
                }
                    
                DialogResult dlgReturn = new dlgChangeStatus(thisRow, list).ShowDialog();
                if (dlgReturn == System.Windows.Forms.DialogResult.OK)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("تغییرات با موفقیت اعمال شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChangeView(FormStatusEnum.Show);
                }
            }
            else 
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("فیلد شماره مشتری خالی می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            ChangeView(FormStatusEnum.Clone);
        }
 
        private void btnNewRequest_Click(object sender, EventArgs e)
        {
            txtRequestId.ResetText();
            ChangeView(FormStatusEnum.New);
        }

        private void btnDeleteRequest_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
            args.Icon = System.Drawing.SystemIcons.Warning;
            args.Caption = "هشدار";
            args.Text = "آیا از حذف پیشنهاد حاضر از سیستم اطمینان کامل دارید؟";
            args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
            args.DefaultButtonIndex = 1;
            DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
            if (dlgRes == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    lblConnectionStatus.Text = "در حال اتصال به سرور ...";
                    Application.DoEvents();
                    if (RequestManager.DeleteQuery(thisRow["RequestSerial"].ToString()))
                    {
                        lblConnectionStatus.Text = string.Empty;
                        DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات پیشنهاد با موفقیت حذف شد!", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    lblConnectionStatus.Text = string.Empty;
                    ChangeView(FormStatusEnum.New);
                }
                catch
                {
                    lblConnectionStatus.Text = "خطا در برقراری ارتباط با سرور";
                }
            }
        }

        private void btnChangeExpertId_Click(object sender, EventArgs e)
        {
            if (thisRow != null)
            {
                dlgUsersList dlg = new dlgUsersList(Users.GetWorkGroupUsers(false), false);
                DialogResult dlgResult = dlg.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    if (dlg.UserId > 0 & dlg.UserName.Length > 0)
                    {
                        bool ask2 = true;
                        if (this.thisRow["ExpertID"].ToString() == dlg.UserId.ToString())
                        {
                            DevExpress.XtraEditors.XtraMessageBoxArgs args1 = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                            args1.Icon = System.Drawing.SystemIcons.Warning;
                            args1.Caption = "تغییر کارشناس پرونده";
                            args1.Text = string.Format("این پرونده قبلاً به {0} ارجاع گردیده است آیا مایل به ارجاع مجدد آن می باشید؟", Users.GetUserNameWithSexByID(dlg.UserId));
                            args1.DefaultButtonIndex = 1;
                            args1.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                            DialogResult dlgRes1 = DevExpress.XtraEditors.XtraMessageBox.Show(args1);
                            if (dlgRes1 != System.Windows.Forms.DialogResult.Yes)
                                return;
                            else
                                ask2 = false;
                        }

                        DevExpress.XtraEditors.XtraMessageBoxArgs args2 = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                        args2.Icon = System.Drawing.SystemIcons.Warning;
                        args2.Caption = "تغییر کارشناس پرونده";
                        args2.Text = string.Format("آیا از ارجاع پیشنهاد به {0} اطمینان کامل حاصل دارید؟", Users.GetUserNameWithSexByID(dlg.UserId));
                        args2.DefaultButtonIndex = 1;
                        args2.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                        DialogResult dlgRes2 = dlgRes2 = System.Windows.Forms.DialogResult.None;

                        if (ask2)
                            dlgRes2 = DevExpress.XtraEditors.XtraMessageBox.Show(args2);
                        else
                            dlgRes2 = System.Windows.Forms.DialogResult.Yes;

                        if (dlgRes2 == System.Windows.Forms.DialogResult.Yes)
                        {
                            string serial = thisRow["RequestSerial"].ToString();
                            bool queryResult = RequestManager.UpdateExpertId(serial, dlg.UserId);
                            if (queryResult)
                            {
                                if (thisRow["ReviewNo"].ToString().Length > 0)
                                    ReviewReportManager.UpdateExpertId(thisRow["ReviewNo"].ToString(), dlg.UserId);
                                dlgDataLogs.AddRequestLog(serial, 7, "پیشنهاد به " + Users.GetUserNameWithSexByID(dlg.UserId) + " ارجاع شد");
                                DevExpress.XtraEditors.XtraMessageBox.Show("عملیات ارجاع با موفقیت انجام شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ChangeView(FormStatusEnum.Show);
                            }
                        }
                    }
                }
            }
        }

        private void btnRequestHistory_Click(object sender, EventArgs e)
        {
            if (dlgHistory != null)
                dlgHistory.ShowDialog();
        }
      
        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            new dlgFormNo(SetNumberConditions()).ShowDialog();
        }

        private void btnShowLogs_Click(object sender, EventArgs e)
        {
            if (thisRow != null)
            {
                btnShowLogs.Enabled = false;
                Application.DoEvents();
                dlgDataLogs dlg = new dlgDataLogs(true);
                dlg.FillLoanFileLogs(thisRow);
                dlg.ShowDialog();
                btnShowLogs.Enabled = true;
            }
        }

        private void btnShowReviewReport_Click(object sender, EventArgs e)
        {
           DataTable tbl = ReviewReportManager.GetReviewReportByNo(thisRow["ReviewNo"].ToString());
           if (tbl != null && tbl.Rows.Count == 1)
               new frmReviewLoanFile(tbl.Rows[0], true).Show();
        }

        private void btnConditions_Click(object sender, EventArgs e)
        {
            txtConditions.ResetText();
            txtConditions.AppendText(GetConditions(txtFacilityId.Text, cboRequestType.Text, cboBails1.Text, cboBails2.Text).Trim() + Environment.NewLine);
            txtConditions.Select();
            txtConditions.SelectionStart = 0;
        }

        private void btnClearText_Click(object sender, EventArgs e)
        {
            txtConditions.ResetText();
        }

        #endregion

        #region Events
      
        private void tabControl_TabIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTabPageIndex == 0)
            {
                txtSearch1.Focus();
                txtSearch1.SelectAll();
            }

            if (tabControl.SelectedTabPageIndex == 1)
            {
                txtSearch2.Focus();
                txtSearch2.SelectAll();
            }
        }

        #region TabPage 1

        private void txtSearch1_EditValueChanged(object sender, EventArgs e)
        {
            if (gridControl1.DataSource != null)
            {
                (gridControl1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Content LIKE '%{0}%'", txtSearch1.Text.Replace("ئ", "ی").Replace("ك", "ک"));
            }
        }

        private void txtSearch1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSearch1.ResetText();
        }

        private void txtSearch1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
            {
                txtSearch1.ResetText();
            }
        }

        private void repository1btnInsert_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            AppendedText1();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            AppendedText1();
        }

        private void AppendedText1()
        {
            if (txtConditions.Enabled & gridView1.FocusedRowHandle >= 0)
            {
                txtConditions.AppendText(gridView1.GetFocusedRowCellValue("Content").ToString() + Environment.NewLine);
            }
        }

        #endregion

        #region TabPage 2

        private void txtSearch2_EditValueChanged(object sender, EventArgs e)
        {
            if (gridControl2.DataSource != null)
            {
                (gridControl2.DataSource as DataTable).DefaultView.RowFilter = string.Format("Content LIKE '%{0}%'", txtSearch2.Text.Replace("ئ", "ی").Replace("ك", "ک"));
            }
        }

        private void txtSearch2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSearch2.ResetText();
        }

        private void txtSearch2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
            {
                txtSearch2.ResetText();
            }
        }
        
        private void repository2btnInsert_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            AppendedText2();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            AppendedText2();
        }

        private void AppendedText2()
        {
            if (txtConditions.Enabled & gridView2.FocusedRowHandle >= 0)
            {
                txtConditions.AppendText(gridView2.GetFocusedRowCellValue("Content").ToString() + Environment.NewLine);
            }
        }

        #endregion

        private void txtRequestId_EditValueChanged(object sender, EventArgs e)
        {
            if (txtRequestId.Text.Length > 0)
            {
                if (!ContractId.IsValid(txtRequestId.Text))
                {
                    txtRequestId.BackColor = Color.MistyRose;
                    txtRequestId.Properties.ContextImageOptions.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/status/warning_16x16.png");
                }
                else
                {
                    txtRequestId.BackColor = Color.White;
                    txtRequestId.Properties.ContextImageOptions.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/conditional%20formatting/iconsetsymbols3_16x16.png");
                }
            }
            else 
            {
                txtRequestId.BackColor = Color.White;
                txtRequestId.Properties.ContextImageOptions.Image = null;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtRequestId.Text.Length > 0)
            {
                try
                {
                    dlgHistory = new dlgHistory(this);
                    btnSearch.Enabled = false;
                    lblConnectionStatus.Text = "لطفا کمی صبر کنید ...";
                    Application.DoEvents();

                    DataTable table = RequestManager.GetRequestById(Numeral.AnyToLong(txtRequestId.Text.Trim()));
                    if (table != null)
                    {
                        if (table.Rows.Count > 0)
                        {
                            ChangeView(FormStatusEnum.Show);
                            ShowRequestValues(table);
                        }
                        else
                        {
                            ChangeView(FormStatusEnum.Insert);
                            DataRow reportRow = SourceReportsManager.GetReportById(424, 535);
                            Dictionary<string, object> properties = reportRow.Table.Columns
                                .Cast<DataColumn>()
                                .ToDictionary(c => c.ColumnName, c => reportRow[c]);
                            properties.Add("SelectedDates", string.Empty);

                            DataTable misTbl = QueryManager.QueryBuilder(QueryProperties.Fill(properties), txtRequestId.Text).Tables[0];
                            if (misTbl != null && misTbl.Rows.Count >= 1)
                            {
                                DataRow row = misTbl.Rows[0];
                                cboRequestType.SelectedIndex = 1;
                                if (Branches.IsBranch(row["BranchID"].ToString()))
                                {
                                    Branches.BranchInfo bi = Branches.GetBranchById(row["BranchID"].ToString(), true);
                                    txtBranchId.Text = bi.BranchId;
                                    lblBranchName.Text = bi.BranchName;
                                }

                                string customerName = System.Text.RegularExpressions.Regex.Replace(row["CustomerName"].ToString().Replace("-", " "), @"\s+", " ");
                                txtCustomerName.Text = customerName;
                                txtFacilityName.Text = row["FacilityName"].ToString();
                                txtRequestAmount.Text = (Numeral.AnyToLong(row["RequestAmount"].ToString()) / 1000000).ToString("n0");
                            }
                        }
                    }

                    btnSearch.Enabled = true;
                    lblConnectionStatus.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    btnSearch.Enabled = true;
                    lblConnectionStatus.Text = ex.Message;
                }
            }
            else 
            {
                DataTable table = ClipboardToDatatable.GetDataTable();
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        btnNewRequest_Click(null, EventArgs.Empty);
                        txtRequestId.Text = row["شماره پیشنهاد"].ToString();
                        btnSearch_Click(null, EventArgs.Empty);
                        if (btnSaveAndSentQuery.Enabled)
                        {
                            cboRequestType.Text = row["نوع پیشنهاد"].ToString();
                            txtBranchId.Text = row["کد شعبه"].ToString();
                            lblBranchName.Text = Branches.GetBranchById(txtBranchId.Text, true).BranchName;
                            txtCustomerName.Text = row["نام متقاضی"].ToString();
                            txtFacilityId.Text = row["کد تسهیلات"].ToString();
                            txtFacilityName.Text = Facilitys.GetFacilityNameById(txtFacilityId.Text);
                            cboBails1.Text = row["وثایق"].ToString();
                            txtRequestAmount.Text = row["مبلغ"].ToString();
                            txtExpertId.Text = row["کد کارشناس"].ToString();
                            lblExpertName.Text = Users.GetUserNameById(int.Parse(txtExpertId.Text));
                            txtProvinceLetterNo.Text = row["شناسه مصوبه"].ToString();
                            btnSaveAndSentQuery_Click(null, EventArgs.Empty);
                        }
                        else
                        {
                            ChangeView(FormStatusEnum.Clone);
                            txtRequestId.Text = row["شماره پیشنهاد"].ToString();
                            cboRequestType.Text = row["نوع پیشنهاد"].ToString();
                            txtBranchId.Text = row["کد شعبه"].ToString();
                            lblBranchName.Text = Branches.GetBranchById(txtBranchId.Text, true).BranchName;
                            txtCustomerName.Text = row["نام متقاضی"].ToString();
                            txtFacilityId.Text = row["کد تسهیلات"].ToString();
                            txtFacilityName.Text = Facilitys.GetFacilityNameById(txtFacilityId.Text);
                            cboBails1.Text = row["وثایق"].ToString();
                            txtRequestAmount.Text = row["مبلغ"].ToString();
                            txtExpertId.Text = row["کد کارشناس"].ToString();
                            lblExpertName.Text = Users.GetUserNameById(int.Parse(txtExpertId.Text));
                            txtProvinceLetterNo.Text = row["شناسه مصوبه"].ToString();
                            btnSaveAndSentQuery_Click(null, EventArgs.Empty);
                        }
                    }
                }
            }
        }
   
        private void cboRequestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCustomersCount.Value = 1;
            txtCustomersCount.Enabled = false;
            btnFacilitysList.Enabled = false;
            txtFacilityId.ResetText();
            txtFacilityName.ResetText();
            cboBails1.Enabled = false;
            cboBails1.ResetText();
            cboBails2.ResetText();
            lblRequestAmount.Text = "خالص اعطایی";
            txtRequestAmount.Text = "0";
            txtRequestAmount.Enabled = false;
            cboRequestPlane.Text = string.Empty;
            cboRequestPlane.Enabled = false;

            if (cboRequestType.Text == "موردی" | cboRequestType.Text == "حد اعتباری"  | cboRequestType.Text == "سقف اعتباری" | cboRequestType.Text == "متمم")
            {
                pnlSearch.BackColor = System.Drawing.SystemColors.Control;
                pnlRequestInfo.BackColor = System.Drawing.SystemColors.Control;
                pnlExpertInfo.BackColor = System.Drawing.SystemColors.Control;
                pnlCreditCommittee.BackColor = System.Drawing.SystemColors.Control;

                btnFacilitysList.Enabled = true;
                cboBails1.Enabled = true;
                txtRequestAmount.Enabled = true;
            }
            if (cboRequestType.Text == "مصوبه خاص")
            {
                pnlSearch.BackColor = System.Drawing.Color.AliceBlue;
                pnlRequestInfo.BackColor = System.Drawing.Color.AliceBlue;
                pnlExpertInfo.BackColor = System.Drawing.Color.AliceBlue;
                pnlCreditCommittee.BackColor = System.Drawing.Color.AliceBlue;

                txtCustomersCount.Enabled = true;
                txtCustomersCount.Value = 1;
                btnFacilitysList.Enabled = true;
                lblRequestAmount.Text = "کل مبلغ";
                txtRequestAmount.Enabled = true;
            }
            if (cboRequestType.Text == "تقسیط")
            {
                pnlSearch.BackColor = System.Drawing.Color.MistyRose;
                pnlRequestInfo.BackColor = System.Drawing.Color.MistyRose;
                pnlExpertInfo.BackColor = System.Drawing.Color.MistyRose;
                pnlCreditCommittee.BackColor = System.Drawing.Color.MistyRose;
                lblRequestAmount.Text = "مبلغ تقسیط";
                txtRequestAmount.Enabled = true;
                cboRequestPlane.Enabled = true;
            }
            if (cboRequestType.Text == "تمدید" | cboRequestType.Text == "تبدیل")
            {
                pnlSearch.BackColor = System.Drawing.SystemColors.Control;
                pnlRequestInfo.BackColor = System.Drawing.SystemColors.Control;
                pnlExpertInfo.BackColor = System.Drawing.SystemColors.Control;
                pnlCreditCommittee.BackColor = System.Drawing.SystemColors.Control;

                btnFacilitysList.Enabled = true;
            }

            if (cboRequestType.Text == "تغییر وثیقه")
            {
                pnlSearch.BackColor = System.Drawing.SystemColors.Control;
                pnlRequestInfo.BackColor = System.Drawing.SystemColors.Control;
                pnlExpertInfo.BackColor = System.Drawing.SystemColors.Control;
                pnlCreditCommittee.BackColor = System.Drawing.SystemColors.Control;

                cboBails1.Enabled = true;
            }
            if (cboRequestType.Text == "تخفیف کارمزد")
            {
                pnlSearch.BackColor = System.Drawing.SystemColors.Control;
                pnlRequestInfo.BackColor = System.Drawing.SystemColors.Control;
                pnlExpertInfo.BackColor = System.Drawing.SystemColors.Control;
                pnlCreditCommittee.BackColor = System.Drawing.SystemColors.Control;
                lblRequestAmount.Text = "% درصد تخفیف";
                txtRequestAmount.Enabled = true;

                btnFacilitysList.Enabled = true;
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
 
        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            if (!txtCustomerName.Text.Contains("معرفی شدگان"))
            {
                if (txtCustomerName.Text.Contains("شرکت ") |
                    txtCustomerName.Text.Contains("صنایع ") |
                    txtCustomerName.Text.Contains("گروه ") |
                    txtCustomerName.Text.Contains("بازرگانی ") |
                    txtCustomerName.Text.Contains("حفاظت ") |
                    txtCustomerName.Text.Contains("تولیدی ") |
                    txtCustomerName.Text.Contains("موسسه ") |
                    txtCustomerName.Text.Contains("اداره ") |
                    txtCustomerName.Text.Contains("آژانس ") |
                    txtCustomerName.Text.Contains("سازمان ") |
                    txtCustomerName.Text.Contains("بانک ") |
                    txtCustomerName.Text.Contains("ارتش ") |
                    txtCustomerName.Text.Contains("دانشکده ") |
                    txtCustomerName.Text.Contains("دانشگاه ") |
                    txtCustomerName.Text.Contains("دبیرستان ") |
                    txtCustomerName.Text.Contains("مدرسه ") |
                    txtCustomerName.Text.Contains("دبستان ") |
                    txtCustomerName.Text.Contains("نمایندگی ") |
                    txtCustomerName.Text.Contains("اتحادیه ") |
                    txtCustomerName.Text.Contains("تعاونی ") |
                    txtCustomerName.Text.Contains("تعاونیهای ") |
                    txtCustomerName.Text.Contains("استانداری ") |
                    txtCustomerName.Text.Contains("فرمانداری ") |
                    txtCustomerName.Text.Contains("فرماندهی ") |
                    txtCustomerName.Text.Contains("فروشگاه ") |
                    txtCustomerName.Text.Contains("صنایع ") |
                    txtCustomerName.Text.Contains("کمیته ") |
                    txtCustomerName.Text.Contains("مدیریت ") |
                    txtCustomerName.Text.Contains("معاونت ") |
                    txtCustomerName.Text.Contains("ستاد ") |
                    txtCustomerName.Text.Contains("وزارت ") |
                    txtCustomerName.Text.Contains("آستان قدس") |
                    txtCustomerName.Text.Contains("آستانقدس") |
                    txtCustomerName.Text.Contains("هلال احمر") |
                    txtCustomerName.Text.Contains("مهندسی ") |
                    txtCustomerName.Text.Contains("مجتمع ") |
                    txtCustomerName.Text.Contains("روزنامه ") |
                    txtCustomerName.Text.Contains("كشتارگاه ") |
                    txtCustomerName.Text.Contains("سردخانه ") |
                    txtCustomerName.Text.Contains("انجمن ") |
                    txtCustomerName.Text.Contains("کارخانه ") |
                    txtCustomerName.Text.Contains("قرارگاه ") |
                    txtCustomerName.Text.Contains("ارتش ") |
                    txtCustomerName.Text.Contains("بنیاد ") |
                    txtCustomerName.Text.Contains("مرکز ") |
                    txtCustomerName.Text.Contains("هتل ") |
                    txtCustomerName.Text.Contains("پلیس "))
                {
                    chkIsLegalPerson.Checked = true;
                }
                else
                {
                    chkIsLegalPerson.Checked = false;
                }
            }
        }
     
        private void btnFilesList_Click(object sender, EventArgs e)
        {
            btnFacilitysList.Select();
            dlgAllLoanFiles dlg = new dlgAllLoanFiles(txtBranchId.Text);
            DialogResult dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                if (dlg.FileId != null && (dlg.FileId.Length > 0 & dlg.CustomerName.Length > 0))
                {
                    txtFileId.Text = dlg.FileId;
                    txtCoverNo.Text = dlg.CoverNo;
                    txtCustomerName.Text = dlg.CustomerName;
                    txtBranchId.Text = dlg.BranchId;
                    lblBranchName.Text = dlg.BranchName;
                }
            }
        }    
      
        private void btnFacilitysList_Click(object sender, EventArgs e)
        {
            cboBails1.Select();
            dlgFacilitysList dlg = new dlgFacilitysList();
            DialogResult dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                if (dlg.FacilityId.Length > 0 & dlg.FacilityName.Length > 0)
                {
                    txtFacilityId.Text = dlg.FacilityId;
                    txtFacilityName.Text = dlg.FacilityName;    
                }
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            Calc calc = new Calc();
            calc.ShowDialog();
            if (calc.ResultValue.Length > 0)
                txtRequestAmount.Text = calc.ResultValue;
        }

        private void btnUsersList_Click(object sender, EventArgs e)
        {
            txtProvinceLetterNo.Select();
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

        private void btnCopyConditionsText_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtConditions.Rtf, TextDataFormat.Rtf);
            DevExpress.XtraEditors.XtraMessageBox.Show("محتوای شرایط مصوبه کپی شد", "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditQuery_Click(object sender, EventArgs e)
        {
            SubmitQuery(false);
        }

        private void btnSaveQuery_Click(object sender, EventArgs e)
        {
            SubmitQuery(false);
        }

        private void btnSaveAndSentQuery_Click(object sender, EventArgs e)
        {
            SubmitQuery(true);
        }

        private void frmApprovalPrint_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void NextControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        #endregion
     
        #region txtConditions

        #region Find Location

        int start = 0;
        int indexOfSearchText = 0;
        public int FindMyText(string txtToSearch, int searchStart, int searchEnd)
        {
            // Set the return value to -1 by default.
            int retVal = -1;

            // A valid starting index should be specified.
            // if indexOfSearchText = -1, the end of search
            if (searchStart >= 0 && indexOfSearchText >= 0)
            {
                // A valid ending index
                if (searchEnd > searchStart || searchEnd == -1)
                {
                    // Find the position of search string in RichTextBox
                    indexOfSearchText = txtConditions.Find(txtToSearch, searchStart, searchEnd, RichTextBoxFinds.None);
                    // Determine whether the text was found in richTextBox1.
                    if (indexOfSearchText != -1)
                    {
                        // Return the index to the specified search text.
                        retVal = indexOfSearchText;
                    }
                }
            }
            return retVal;
        }
        private void FindNext(string txtSearch)
        {
            start = txtConditions.SelectionStart + 1;
            int startindex = 0;

            if (txtSearch.Length > 0)
                startindex = FindMyText(txtSearch.Trim(), start, txtConditions.Text.Length);

            // If string was found in the RichTextBox, highlight it

            if (startindex >= 0)
            {
                // Set the highlight color as red
                txtConditions.SelectionColor = System.Drawing.Color.Red;
                // Find the end index. End Index = number of characters in textbox
                int endindex = txtSearch.Length;
                // Highlight the search string
                txtConditions.Select(startindex, endindex);
                // mark the start position after the position of
                // last search string

                // start = startindex + endindex;
                start = startindex + 1;
            }
            else
            {
                startindex = 0;
                start = 0;
                indexOfSearchText = 0;
                btnSaveAndSentQuery.Select();
            }
        }
        private void txtConditions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = true;
                FindNext("..........");
                return;
            }
        }
        
        #endregion

        #region Menu Strip

        private void txtConditions_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {   //click event
                //MessageBox.Show("you got it!");
                ContextMenuStrip contextMenu = new System.Windows.Forms.ContextMenuStrip();
                contextMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

                ToolStripMenuItem menuItem = new ToolStripMenuItem("Cut", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/cut_16x16.png"));
                menuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
                menuItem.Click += new EventHandler(CutAction);
                contextMenu.Items.Add(menuItem);

                menuItem = new ToolStripMenuItem("Copy", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/copy_16x16.png"));
                menuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
                menuItem.Click += new EventHandler(CopyAction);
                contextMenu.Items.Add(menuItem);

                menuItem = new ToolStripMenuItem("Paste", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/paste_16x16.png"));
                menuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
                menuItem.Click += new EventHandler(PasteAction);
                contextMenu.Items.Add(menuItem);

                menuItem = new ToolStripMenuItem("Select All", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/selectall_16x16.png"));
                menuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
                menuItem.Click += new EventHandler(SelectAllAction);
                contextMenu.Items.Add(menuItem);

                txtConditions.ContextMenuStrip = contextMenu;
            }
        }

        void CutAction(object sender, EventArgs e)
        {
            txtConditions.Cut();
        }

        void CopyAction(object sender, EventArgs e)
        {
            Clipboard.SetText(txtConditions.Rtf, TextDataFormat.Rtf);
        }

        void PasteAction(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Rtf))
            {
                txtConditions.SelectedRtf = Clipboard.GetData(DataFormats.Rtf).ToString();
            }
        }

        void SelectAllAction(object sender, EventArgs e)
        {
            txtConditions.SelectAll();
        } 
        #endregion

        #endregion
    }
}
