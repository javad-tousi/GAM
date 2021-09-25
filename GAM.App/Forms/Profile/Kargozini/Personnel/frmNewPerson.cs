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
using GAM.Forms.Profile.Kargozini.Library;
using DevExpress.Data.Mask;


namespace GAM.Forms.Profile.Kargozini.Personnel
{
    public partial class frmNewPerson : DevExpress.XtraEditors.XtraForm
    {
        public enum FormStatusEnum { Show, Edit, New, Insert };
        private FormStatusEnum FormStatus;
        private DataRow PersonDataRow;

        DataTable TableAllRules = new DataTable();

        public frmNewPerson(string id)
        {
            InitializeComponent();

            if (id.Length > 0)
            {
                txtEmploymentId.Text = id;
                btnSearch_Click(null, EventArgs.Empty);
                pnlSearch.Hide();
                pnlHeader.Hide();
                pnlSave.Hide();
                this.Height = this.Height - 120;
            }
        }

        #region Methods

        public void ViewMode(FormStatusEnum status)
        {
            this.FormStatus = status;
            lblConnectionStatus.Text = string.Empty;

            switch (status)
            {
                case FormStatusEnum.Show://زمانی که اطلاعات یافت شده اما پنل ها قفل می باشند
                    btnNewPerson.Enabled = true;
                    btnEditPerson.Enabled = true;
                    btnDeletePerson.Enabled = true;
                    btnAddRule.Enabled = false;
                    btnAllRules.Enabled = true;

                    pnlSearch.Enabled = true;
                    //txtEmploymentId.ResetText();
                    txtEmploymentId.ReadOnly = false;
                    btnSearch.Enabled = true;

                    pnlPersonInfo.Enabled = false;
                    txtFirstName.ResetText();
                    txtLastName.ResetText();
                    txtFatherName.ResetText();
                    txtNationalCode.ResetText();
                    txtBirthDate.ResetText();
                    txtBithCityName.ResetText();
                    rgGender.SelectedIndex = -1;
                    rgMaritalStatus.SelectedIndex = -1;
                    txtChildCount.Value = 0;
                    cboAcademicDegree.SelectedIndex = 0;
                    txtFieldOfStudy.ResetText();
                    txtHomeTellNo.ResetText();
                    txtMobailNo.ResetText();
                    txtHomeAddress.ResetText();

                    pnlJobInfo.Enabled = false;
                    cboEmploymentType.SelectedIndex = 0;
                    txtPersonnelStatus.ResetText();
                    txtDateEmployment.ResetText();
                    txtDateRetirement.ResetText();

                    pnlSave.Enabled = false;
                    btnSubmitQuery.Text = "ویرایش اطلاعات پرونده";

                    txtEmploymentId.Focus();
                    txtEmploymentId.Select();
                    break;

                case FormStatusEnum.Edit://زمانی که  اطلاعات یافت شده و دکمه ویرایش توسط کاربر انتخاب شده است

                    btnNewPerson.Enabled = true;
                    btnEditPerson.Enabled = false;
                    btnDeletePerson.Enabled = true;
                    btnAddRule.Enabled = true;
                    btnAllRules.Enabled = true;


                    pnlSearch.Enabled = false;
                    //txtEmploymentId.ResetText();
                    //txtEmploymentId.ReadOnly = false;
                    //btnSearch.Enabled = true;

                    pnlPersonInfo.Enabled = true;
                    //txtFirstName.ResetText();
                    //txtLastName.ResetText();
                    //txtFatherName.ResetText();
                    //txtNationalCode.ResetText();
                    //txtBirthDate.ResetText();
                    //txtBithCityName.ResetText();
                    //rgGender.SelectedIndex = -1;
                    //rgMaritalStatus.SelectedIndex = -1;
                    //txtChildCount.Value = 0;
                    //cboAcademicDegree.SelectedIndex = 0;
                    //txtFieldOfStudy.ResetText();
                    //txtHomeTellNo.ResetText();
                    //txtMobailNo.ResetText();
                    //txtHomeAddress.ResetText();

                    pnlJobInfo.Enabled = true;
                    //cboEmploymentType.SelectedIndex = 0;
                    //cboPersonStatus.SelectedIndex = 0;
                    //txtDateEmployment.ResetText();
                    //txtDateRetirement.ResetText();
                    //txtBranchName.ResetText();
                    //cboDateRelocation.ResetText();
                    //cboJobTitel.ResetText();
                    //txtDateChangePost.ResetText();
                    //cboPostName.ResetText();
                    //cboJobCategory.SelectedIndex = 0;

                    pnlSave.Enabled = true;
                    btnSubmitQuery.Text = "ویرایش اطلاعات پرونده";
                    break;

                case FormStatusEnum.New://زمانیکه کاربر دکمه جدید را انتخاب می کند یا بعد از ذخیره اطلاعات و فرم آماده جستجو جدید است
                    this.PersonDataRow = null;
                    this.TableAllRules.Rows.Clear();
                    gridControl1.DataSource = null;
                    gridControl2.DataSource = null;

                    btnNewPerson.Enabled = true;
                    btnEditPerson.Enabled = false;
                    btnDeletePerson.Enabled = false;
                    btnAddRule.Enabled = false;
                    btnAllRules.Enabled = false;

                    pnlSearch.Enabled = true;
                    txtEmploymentId.ResetText();
                    txtEmploymentId.ReadOnly = false;
                    btnSearch.Enabled = true;

                    pnlPersonInfo.Enabled = false;
                    txtFirstName.ResetText();
                    txtLastName.ResetText();
                    txtFatherName.ResetText();
                    txtNationalCode.ResetText();
                    txtBirthDate.ResetText();
                    txtBithCityName.ResetText();
                    rgGender.SelectedIndex = -1;
                    rgMaritalStatus.SelectedIndex = -1;
                    txtChildCount.Value = 0;
                    cboAcademicDegree.SelectedIndex = 0;
                    txtFieldOfStudy.ResetText();
                    txtHomeTellNo.ResetText();
                    txtMobailNo.ResetText();
                    txtHomeAddress.ResetText();

                    pnlJobInfo.Enabled = false;
                    cboEmploymentType.SelectedIndex = 0;
                    txtPersonnelStatus.ResetText();
                    txtDateEmployment.ResetText();
                    txtDateRetirement.ResetText();

                    pnlSave.Enabled = false;
                    btnSubmitQuery.Text = "ثبت اطلاعات پرونده";

                    txtEmploymentId.Focus();
                    txtEmploymentId.Select();
                    break;

                case FormStatusEnum.Insert://زمانیکه شماره قرارداد مورد نظر در سیستم وجود نداشته باشد و فرم آماده ورود اطلاعات است
                    this.PersonDataRow = null;

                    btnNewPerson.Enabled = true;
                    btnEditPerson.Enabled = false;
                    btnDeletePerson.Enabled = false;
                    btnAddRule.Enabled = false;
                    btnAllRules.Enabled = false;

                    pnlSearch.Enabled = false;
                    //txtEmploymentId.ResetText();
                    txtEmploymentId.ReadOnly = true;
                    btnSearch.Enabled = true;

                    pnlPersonInfo.Enabled = true;
                    txtFirstName.ResetText();
                    txtLastName.ResetText();
                    txtFatherName.ResetText();
                    txtNationalCode.ResetText();
                    txtBirthDate.ResetText();
                    txtBithCityName.ResetText();
                    rgGender.SelectedIndex = -1;
                    rgMaritalStatus.SelectedIndex = -1;
                    txtChildCount.Value = 0;
                    cboAcademicDegree.SelectedIndex = 0;
                    txtFieldOfStudy.ResetText();
                    txtHomeTellNo.ResetText();
                    txtMobailNo.ResetText();
                    txtHomeAddress.ResetText();

                    pnlJobInfo.Enabled = true;
                    cboEmploymentType.SelectedIndex = 0;
                    txtPersonnelStatus.Text = "شاغل";
                    txtDateEmployment.ResetText();
                    txtDateRetirement.ResetText();

                    pnlSave.Enabled = true;
                    btnSubmitQuery.Text = "ثبت اطلاعات پرونده";

                    txtFirstName.Focus();
                    txtFirstName.Select();
                    break;
                default:
                    break;
            }
        }

        private string CheckInputValues()
        {
            if (txtFirstName.Text.Length == 0)
                return "لطفاً نام همکار را وارد نمایید";
            if (txtLastName.Text.Length == 0)
                return "لطفاً نام خانوادگی را وارد نمایید";
            if (txtFatherName.TextLength == 0)
                return "لطفاً نام پدر را وارد نمایید";
            if (!UDF.IsValidCodeMeli(txtNationalCode.Text))
                return "کد ملی نامعتبر می باشد";
            if (!PersianDateTime.IsValidDate(txtBirthDate.Text))
                return "تاریخ تولد نامعتبر می باشد";
            if (txtBithCityName.TextLength == 0)
                return "لطفاً محل تولد را مشخص نمایید";
            if (rgGender.SelectedIndex == -1)
                return "لطفاً نوع جنسیت را مشخص نمایید";
            if (rgMaritalStatus.SelectedIndex == -1)
                return "لطفاً وضعیت تاهل را مشخص نمایید";
            if (cboAcademicDegree.SelectedIndex == 0)
                return "لطفاً مدرک تحصیلی را وارد نمایید";
            if (txtHomeTellNo.Text.Length > 0)
            {
                MaskManager mm = txtHomeTellNo.Properties.Mask.CreateDefaultMaskManager();
                mm.SetInitialEditText(txtHomeTellNo.Text);
                if (txtHomeTellNo.Text != mm.GetCurrentEditText() || !mm.IsMatch)
                    return "شماره تلفن منزل وارد شده نامعتبر می باشد";
            }

            if (txtMobailNo.Text.Length > 0)
            {
                MaskManager mm = txtMobailNo.Properties.Mask.CreateDefaultMaskManager();
                mm.SetInitialEditText(txtMobailNo.Text);
                if (txtMobailNo.Text != mm.GetCurrentEditText() || !mm.IsMatch)
                    return "شماره موبایل وارد شده نامعتبر می باشد";
            }

            if (txtHomeAddress.Text.Length == 0)
                return "لطفاً آدرس منزل را وارد نمایید";
            if (cboEmploymentType.SelectedIndex == 0)
                return "لطفاً نوع استخدامی را مشخص نمایید";
            if (txtPersonnelStatus.Text.Length == 0)
                return "لطفاً وضعیت کارمند را مشخص نمایید";
            if (!PersianDateTime.IsValidDate(txtDateEmployment.Text))
                return "لطفاً تاریخ استخدام را مشخص نمایید";

            return string.Empty;
        }

        public void ShowPersonData(DataRow row)
        {
            txtFirstName.Text = row["FirstName"].ToString();
            txtLastName.Text = row["LastName"].ToString();
            txtFatherName.Text = row["FatherName"].ToString();
            txtNationalCode.Text = row["NationalCode"].ToString();
            txtBirthDate.Text = row["BirthDate"].ToString();
            txtBithCityName.Text = row["BithCityName"].ToString();

            if (bool.Parse(row["IsFemale"].ToString()))
                rgGender.SelectedIndex = 1;
            else
                rgGender.SelectedIndex = 0;

            if (row["MaritalStatus"].ToString() == "مجرد")
                rgMaritalStatus.SelectedIndex = 0;
            if (row["MaritalStatus"].ToString() == "متاهل")
                rgMaritalStatus.SelectedIndex = 1;

            txtChildCount.Text = row["ChildCount"].ToString();
            cboAcademicDegree.Text = row["AcademicDegree"].ToString();
            txtFieldOfStudy.Text = row["FieldOfStudy"].ToString();
            txtHomeTellNo.Text = row["HomeTellNo"].ToString();
            txtMobailNo.Text = row["MobailNo"].ToString();
            txtHomeAddress.Text = row["HomeAddress"].ToString();
            cboEmploymentType.Text = row["EmploymentType"].ToString();
            txtPersonnelStatus.Text = row["PersonnelStatus"].ToString();
            txtDateEmployment.Text = row["DateEmployment"].ToString();
            txtDateRetirement.Text = row["DateRetirement"].ToString();
            PersianDateTime dateStart;
            PersianDateTime dateEnd;
            if (PersianDateTime.TryParse(txtDateEmployment.Text, out dateStart, "/"))
                txtDaysFromDateEmployment.Text = (PersianDateTime.Now - dateStart).Days.ToString();
            if (PersianDateTime.TryParse(txtDateEmployment.Text, out dateStart, "/") & PersianDateTime.TryParse(txtDateRetirement.Text, out dateEnd, "/"))
                txtDaysLeftOfRetirement.Text = (dateEnd - dateStart).Days.ToString();

            ///////////////////////
            DataTable tblRules = PersonelsManager.GetAllRulesByEmploymentId(row["EmploymentID"].ToString());
            DataTable tblRules1 = tblRules.Clone();
            for (int i = tblRules.Rows.Count - 1; i >= 0; i--)
                tblRules1.ImportRow(tblRules.Rows[i]);
            this.TableAllRules = tblRules1;
            ///////////////////////
            DataRow[] ruleRows = tblRules.Rows.Cast<DataRow>().ToArray();
            DataTable tblPosts = PersonelsManager.GetChangedPostsHistory(ruleRows, 0);
            DataTable tblPosts1 = tblPosts.Clone();
            for (int i = tblPosts.Rows.Count - 1; i >= 0; i--)
                tblPosts1.ImportRow(tblPosts.Rows[i]);
            gridControl1.DataSource = tblPosts1;
            ///////////////////////
            DataTable tblBranches = PersonelsManager.GetChangedBranchesHistory(ruleRows, 0);
            DataTable tblBranches1 = tblBranches.Clone();
            for (int i = tblBranches.Rows.Count - 1; i >= 0; i--)
                tblBranches1.ImportRow(tblBranches.Rows[i]);
            gridControl2.DataSource = tblBranches1;
            ///////////////////////

            #region Scores

            foreach (DataRow r in this.TableAllRules.Rows)
            {
                if (r["RuleType"].ToString() == "رسمی")
                {
                    txtScore1.Text = r["Score1"].ToString();
                    txtScore2.Text = r["Score2"].ToString();
                    break;
                }
            }
            #endregion

            txtEmploymentId.SelectAll();
        }
        #endregion

        #region Small Buttons

        private void btnNewPerson_Click(object sender, EventArgs e)
        {
            ViewMode(FormStatusEnum.New);
        }

        private void btnEditPerson_Click(object sender, EventArgs e)
        {
            ViewMode(FormStatusEnum.Edit);
        }

        private void btnDeletePerson_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
            args.Icon = System.Drawing.SystemIcons.Warning;
            args.Caption = "هشدار";
            args.Text = "آیا از حذف اطلاعات پرسنل حاضر از سیستم اطمینان کامل دارید؟";
            args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
            args.DefaultButtonIndex = 1;
            DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
            if (dlgRes == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    lblConnectionStatus.Text = "در حال اتصال به سرور ...";
                    Application.DoEvents();
                    if (PersonelsManager.DeleteEmployeeById(PersonDataRow["EmploymentID"].ToString()))
                    {
                        lblConnectionStatus.Text = string.Empty;
                        DevExpress.XtraEditors.XtraMessageBox.Show("!اطلاعات پرسنل با موفقیت حذف شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    lblConnectionStatus.Text = string.Empty;
                    ViewMode(FormStatusEnum.New);
                }
                catch
                {
                    lblConnectionStatus.Text = "خطا در برقراری ارتباط با سرور";
                }
            }

        }

        private void btnAddRule_Click(object sender, EventArgs e)
        {
            DialogResult dlgRes = System.Windows.Forms.DialogResult.None;
            if (this.TableAllRules.Rows.Count > 0)
                dlgRes = new dlgAddRule(txtEmploymentId.Text, txtPersonnelStatus.Text, txtFirstName.Text + " " + txtLastName.Text, this.TableAllRules.Rows[0]).ShowDialog();
            else
                dlgRes = new dlgAddRule(txtEmploymentId.Text, txtPersonnelStatus.Text, txtFirstName.Text + " " + txtLastName.Text, null).ShowDialog();
            if (dlgRes == System.Windows.Forms.DialogResult.OK)
            {

                DataTable tblRules = PersonelsManager.GetAllRulesByEmploymentId(txtEmploymentId.Text);
                DataTable tblRules1 = tblRules.Clone();
                for (int i = tblRules.Rows.Count - 1; i >= 0; i--)
                    tblRules1.ImportRow(tblRules.Rows[i]);
                this.TableAllRules = tblRules1;
            }
        }

        private void btnAllRules_Click(object sender, EventArgs e)
        {
            btnAllRules.Enabled = false;
            Application.DoEvents();
            if (txtEmploymentId.Text.Length > 0)
                new dlgAllRules(this.TableAllRules).ShowDialog();
            btnAllRules.Enabled = true;
        }

        #endregion

        #region Events

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtEmploymentId.Text.Length > 0)
            {
                try
                {
                    this.PersonDataRow = null;
                    this.TableAllRules.Rows.Clear();
                    gridControl1.DataSource = null;
                    gridControl2.DataSource = null;
                    btnSearch.Enabled = false;
                    lblConnectionStatus.Text = "لطفا کمی صبر کنید ...";
                    Application.DoEvents();

                    DataRow personRow = PersonelsManager.GetEmployeeById(txtEmploymentId.Text.Trim());
                    if (personRow != null)
                    {
                        this.PersonDataRow = personRow;
                        ViewMode(FormStatusEnum.Show);
                        ShowPersonData(personRow);
                    }
                    else
                        ViewMode(FormStatusEnum.Insert);
                    btnSearch.Enabled = true;
                    lblConnectionStatus.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    btnSearch.Enabled = true;
                    lblConnectionStatus.Text = ex.Message;
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

                    long employmentId = long.Parse(txtEmploymentId.Text);
                    string firstName = txtFirstName.Text.Trim();
                    string lastName = txtLastName.Text.Trim();
                    string fatherName = txtFatherName.Text.Trim();
                    string nationalCode = txtNationalCode.Text;
                    int birthDate = int.Parse(Numeral.ExtractDigits(txtBirthDate.Text));
                    string bithCityName = txtBithCityName.Text.Trim();
                    bool gender = false;
                    if (rgGender.SelectedIndex == 1)
                        gender = true;
                    string marital = rgMaritalStatus.Properties.Items[rgMaritalStatus.SelectedIndex].Value.ToString();
                    int childCount = (int)txtChildCount.Value;
                    string academicDegree = cboAcademicDegree.Text.Trim();
                    string fieldOfStudy = txtFieldOfStudy.Text.Trim();
                    string homeTellNo = txtHomeTellNo.Text;
                    string mobailNo = txtMobailNo.Text;
                    string homeAddress = txtHomeAddress.Text.Trim();
                    string employmentType = cboEmploymentType.Text;
                    string personStatus = txtPersonnelStatus.Text;
                    int dateEmployment = int.Parse(Numeral.ExtractDigits(txtDateEmployment.Text));
                    int? dateRetirement = Numeral.AnyToInt32Nullable(Numeral.ExtractDigits(txtDateRetirement.Text));

                    bool success = false;

                    if (this.FormStatus == FormStatusEnum.Insert | this.FormStatus == FormStatusEnum.New)
                    {
                        success = PersonelsManager.InsertQuery(employmentId, firstName, lastName, fatherName, nationalCode, birthDate, bithCityName, gender, marital, childCount, academicDegree, fieldOfStudy, homeTellNo, mobailNo, homeAddress, employmentType, personStatus, dateEmployment, dateRetirement);
                    }

                    if (this.FormStatus == FormStatusEnum.Edit)
                    {
                        lblConnectionStatus.Text = "لطفاً کمی صبر کنید ...";
                        Application.DoEvents();
                        success = PersonelsManager.UpdateQuery(long.Parse(PersonDataRow["EmploymentID"].ToString()), firstName, lastName, fatherName, nationalCode, birthDate, bithCityName, gender, marital, childCount, academicDegree, fieldOfStudy, homeTellNo, mobailNo, homeAddress, employmentType, personStatus, dateEmployment, dateRetirement);
                    }

                    if (success)
                    {
                        lblConnectionStatus.Text = string.Empty;
                        DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات با موفقیت ذخیره شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    ViewMode(FormStatusEnum.New);
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

        private void NextControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        #endregion
    }
}
