using GAM.Forms.Profile.Etebarat.Print;
using GAM.Forms.Information;
using GAM.Forms.Information.Library;
using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using GAM.Forms.Profile.Etebarat.Library;
using System.Drawing;
using GAM.Forms.Settings.Library;
using System.Collections.Generic;
using GAM.Dialogs;
using GAM.Modules;
using MD.PersianDateTime;
using System.ComponentModel;
using GAM.Forms.Reports.Queries;

namespace GAM.Forms.Profile.Etebarat.Arshive
{
    public partial class frmNewLoanFile : DevExpress.XtraEditors.XtraForm
    {
        internal static event System.EventHandler LoadEvent;

        public frmNewLoanFile()
        {
            InitializeComponent();
            LoadEvent += this_LoadEvent;
            cboRequestType.SelectedIndex = 0;
            txtRequestId.Select();
            Modules.UDF.ToFarsiLanguage();
            FilesManager.LoadEvent += FilesManager_LoadEvent;
        }

        #region Page 1
       
        #region Properties

        private DataRow thisRow { get; set; }

        private enum FormStatusEnum { Show, New, Edit, asNew, exitFile, Restart };

        private FormStatusEnum FormStatus;

        #endregion

        #region Events

        #region Panel Right
   
        private void btnNewRequest_Click(object sender, EventArgs e)
        {
            txtRequestId.ResetText();
            ChangeView(FormStatusEnum.Restart);
            txtRequestId.Focus();
            txtRequestId.Select();
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            ChangeView(FormStatusEnum.asNew);
            if (txtRequestId.Text == "111")
            {
                txtCustomerId.ResetText();
                txtFileId.ResetText();
                txtCoverNo.ResetText();
                txtIndicatorId.ResetText();
                txtCustomerName.Focus();
                txtCustomerName.Select();
            }
            else
            {
                txtRequestId.Text = string.Empty;
                txtRequestId.Focus();
                txtRequestId.Select();
            }

        }

        private void btnExitFile_Click(object sender, EventArgs e)
        {
            ChangeView(FormStatusEnum.exitFile);
        }

        private void btnChangeExpertID_Click(object sender, EventArgs e)
        {
            ChangeView(FormStatusEnum.Edit);
        }

        private void txtRequestID_EditValueChanged(object sender, EventArgs e)
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
            try
            {
                btnSearch.Enabled = false;
                Application.DoEvents();

                if (!ContractId.IsValid(txtRequestId.Text))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("شماره پیشنهاد وارد شده معتبر نمی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRequestId.Focus();
                    txtRequestId.SelectAll();
                    btnSearch.Enabled = true;
                    return;
                }

                lblConnectionStatus.Text = "لطفا کمی صبر کنید ...";
                Application.DoEvents();

                DataTable table = RequestManager.GetRequestById(Numeral.AnyToLong(txtRequestId.Text.Trim()));
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        ChangeView(FormStatusEnum.Show);
                        ShowRequestItems(table);
                    }
                    else
                    {
                        ChangeView(FormStatusEnum.New);
                       
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
                else
                    ChangeView(FormStatusEnum.New);

                btnSearch.Enabled = true;
                lblConnectionStatus.Text = string.Empty;
            }
            catch (Exception ex)
            {
                btnSearch.Enabled = true;
                lblConnectionStatus.Text = ex.Message;
            }
        }


        private void cboRequestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnFacilitysList.Enabled = false;
            txtFacilityId.ResetText();
            txtFacilityName.ResetText();
            lblRequestAmount.Text = "مبلغ پیشنهادی";
            txtRequestAmount.Text = "0";
            txtRequestAmount.Enabled = false;

            if (cboRequestType.Text == "موردی" | cboRequestType.Text == "حد اعتباری" | cboRequestType.Text == "سقف اعتباری" | cboRequestType.Text == "متمم")
            {
                btnFacilitysList.Enabled = true;
                txtRequestAmount.Enabled = true;
            }
            if (cboRequestType.Text == "مصوبه خاص")
            {
                btnFacilitysList.Enabled = true;
                lblRequestAmount.Text = "کل مبلغ";
                txtRequestAmount.Enabled = true;
            }
            if (cboRequestType.Text == "تقسیط")
            {
                lblRequestAmount.Text = "مبلغ تقسیط";
                txtRequestAmount.Enabled = true;
            }
            if (cboRequestType.Text == "تمدید" | cboRequestType.Text == "تبدیل")
            {
                btnFacilitysList.Enabled = true;
            }

            if (cboRequestType.Text == "تغییر وثیقه")
            {
            }
            if (cboRequestType.Text == "تخفیف کارمزد")
            {
                lblRequestAmount.Text = "% درصد تخفیف";
                txtRequestAmount.Enabled = true;
                btnFacilitysList.Enabled = true;
            }
        }

        private void txtBranchID_TextChanged(object sender, EventArgs e)
        {
            FilterFiles();
        }

        private void btnBranchesList_Click(object sender, EventArgs e)
        {
            txtCustomerName.Select();
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

        private void btnFacilitysList_Click(object sender, EventArgs e)
        {
            txtRequestAmount.Select();
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

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            FilterFiles();

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

        private void btnUsersList_Click(object sender, EventArgs e)
        {
            btnSaveAndReferral.Select();
            dlgUsersList dlg = new dlgUsersList(Users.GetWorkGroupUsers(false), false);
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

        private void btnSaveAndReferral_Click(object sender, EventArgs e)
        {
            SubmitQuery(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SubmitQuery(true);
        }

        private void SubmitQuery(bool saveChanges)
        {
            string errMessage = CheckInputValues();
            if (errMessage.Length == 0)
            {
                try
                {
                    lblConnectionStatus.Text = "لطفاً کمی صبر کنید ...";
                    btnSaveAndReferral.Enabled = false;
                    Application.DoEvents();
                    int? fileId = Numeral.AnyToInt32Nullable(txtFileId.Text);
                    int? indicatorId = Numeral.AnyToInt32Nullable(txtIndicatorId.Text);
                    int? coverNo = Numeral.AnyToInt32Nullable(txtCoverNo.Text);
                    int branchId = int.Parse(txtBranchId.Text);
                    string branchName = lblBranchName.Text;
                    int expertId = int.Parse(txtExpertId.Text);
                    int? referralDate = Network.GetNowDateSerial();

                    if (this.FormStatus == FormStatusEnum.exitFile)
                    {
                        bool queryResult = FilesManager.SetFileStatus(fileId.Value, coverNo.Value, indicatorId.Value, expertId, branchId, branchName, false);
                        if (queryResult)
                        {
                            lblConnectionStatus.Text = string.Empty;
                            DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات با موفقیت ذخیره شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ChangeView(FormStatusEnum.exitFile);
                            lblConnectionStatus.Text = string.Empty;
                            btnSaveAndReferral.Enabled = true;
                            return;
                        }
                    }

                    List<string> serialsList = new List<string>();
                    string requestLocation = txtRequestLocation.Text;
                    string requestStatus = txtRequestStatus.Text;
                    int? reviewNo = Numeral.AnyToInt32Nullable(txtReviewNo.Text);
                    string reviewId = string.Empty;
                    if (reviewNo.HasValue)
                        reviewId = ChkSum.DelCheck(reviewNo.Value.ToString());


                    long requestId = long.Parse(txtRequestId.Text.Trim());
                    string requestType = cboRequestType.Text;
                    string requestPlane = string.Empty;
                    int customersCount = 1;
                    string customerId = txtCustomerId.Text;
                    string customerName = txtCustomerName.Text.Trim();
                    bool isLegalPerson = chkIsLegalPerson.Checked;
                    int facilityId = Numeral.AnyToInt32(txtFacilityId.Text);
                    string bails1 = string.Empty;
                    string bails2 = string.Empty;
                    long requestAmount = Numeral.AnyToLong(txtRequestAmount.Text);
                    string creditCommittee = CraditCommitee.ModiritShoab;
                    string note = string.Empty;
                    string conditions = string.Empty;

                    if (this.FormStatus == FormStatusEnum.asNew)
                    {
                        if (RequestManager.GetRequestById(requestId).Rows.Count > 0)
                        {
                            lblConnectionStatus.Text = string.Empty;
                            DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                            args.Icon = System.Drawing.SystemIcons.Warning;
                            args.Caption = "هشدار";
                            args.Text = "این شماره پیشنهاد قبلا مصوب شده است آیا مایل به ثبت مجدد آن می باشید؟";
                            args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                            args.DefaultButtonIndex = 1;
                            DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                            if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                                this.FormStatus = FormStatusEnum.New;
                            else
                                return;
                        }
                        this.FormStatus = FormStatusEnum.New;
                    }

                    lblConnectionStatus.Text = "لطفاً کمی صبر کنید ...";
                    Application.DoEvents();

                    if (this.FormStatus == FormStatusEnum.New)
                    {
                        serialsList.Clear();

                        if (txtFileId.TextLength == 0)
                        {
                            lblConnectionStatus.Text = string.Empty;
                            DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                            args.Icon = System.Drawing.SystemIcons.Question;
                            args.Text = "آیا پیشنهاد حاضر دارای پرونده اعتباری می باشد؟";
                            args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No, DialogResult.Cancel };
                            DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                            if (dlgRes == System.Windows.Forms.DialogResult.No)
                            {
                                serialsList.Add(RequestManager.InsertQuery(RequestStatus.Barasi, requestId, requestType, requestPlane, branchId, customersCount, customerId, customerName, isLegalPerson, fileId, coverNo, facilityId, bails1, bails2, requestAmount, creditCommittee, expertId, referralDate, conditions, null, "اداره"));
                            }
                            else
                            {
                                lblConnectionStatus.Text = string.Empty;
                                btnSaveAndReferral.Enabled = true;
                                txtSearchInAllFiles.Focus();
                                txtSearchInAllFiles.SelectAll();
                                return;
                            }
                        }
                        else
                        {
                            serialsList.Add(RequestManager.InsertQuery(RequestStatus.Barasi, requestId, requestType, requestPlane, branchId, customersCount, customerId, customerName, isLegalPerson, fileId, coverNo, facilityId, bails1, bails2, requestAmount, creditCommittee, expertId, referralDate, conditions, null, "اداره"));
                        }
                    }

                    if (this.FormStatus == FormStatusEnum.Edit)
                    {
                        serialsList.Clear();
                        if (reviewId.Length > 0)
                        {
                            string[] linkedSerials = RequestManager.GetSerialsByReviewNo(reviewId).Select(x => x.Key).ToArray();
                            if (!saveChanges & linkedSerials.Count() > 1)
                            {
                                DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                                args.Icon = System.Drawing.SystemIcons.Question;
                                args.Text = string.Format("پیشنهاد حاضر دارای {0} پیشنهاد مرتبط می باشد آیا مایل به ارجاع پیشنهادات مرتبط هم می باشید؟", linkedSerials.Count() - 1);
                                args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                                DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                                if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                                {
                                    foreach (string ser in linkedSerials)
                                    {
                                        serialsList.Add(ser);
                                        if (ser == thisRow["RequestSerial"].ToString())
                                        {
                                            RequestManager.UpdateQuery(ser, thisRow["RequestStatus"].ToString(), requestType, branchId, customerId, customerName, isLegalPerson, fileId, coverNo, facilityId, thisRow["Bails1"].ToString(), thisRow["BailsDetail"].ToString(), requestAmount, expertId);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                string ser = thisRow["RequestSerial"].ToString();
                                RequestManager.UpdateQuery(ser, thisRow["RequestStatus"].ToString(), requestType, branchId, customerId, customerName, isLegalPerson, fileId, coverNo, facilityId, thisRow["Bails1"].ToString(), thisRow["BailsDetail"].ToString(), requestAmount, expertId);
                                serialsList.Add(ser);
                            }
                            ReviewReportManager.UpdateExpertId(reviewId, int.Parse(txtExpertId.Text));
                        }
                        else
                        {
                            string ser = thisRow["RequestSerial"].ToString();
                            RequestManager.UpdateQuery(ser, thisRow["RequestStatus"].ToString(), requestType, branchId, customerId, customerName, isLegalPerson, fileId, coverNo, facilityId, thisRow["Bails1"].ToString(), thisRow["BailsDetail"].ToString(), requestAmount, expertId);
                            serialsList.Add(ser);
                        }
                    }


                    if (txtFileId.TextLength > 0)
                    {
                        FilesManager.SetFileStatus(fileId.Value, coverNo.Value, indicatorId.Value, expertId, branchId, branchName, false);
                    }

                    if (serialsList.Count > 0)
                    {
                        RequestManager.UpdateExpertId(serialsList.ToArray(), expertId);

                        lblConnectionStatus.Text = string.Empty;
                        DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات با موفقیت ذخیره شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (!saveChanges & (this.FormStatus == FormStatusEnum.New | this.FormStatus == FormStatusEnum.Edit))
                            dlgDataLogs.AddRequestLog(serialsList.ToArray(), 7, string.Format("پیشنهاد در بایگانی ثبت و جهت بررسی به {0} تحویل گردید", Users.GetUserNameWithSexByID(Numeral.AnyToInt32(txtExpertId.Text))));
                   }

                    ChangeView(FormStatusEnum.Restart);
                    lblConnectionStatus.Text = string.Empty;
                    btnSaveAndReferral.Enabled = true;
                    txtSearchInAllFiles.Focus();
                    txtSearchInAllFiles.SelectAll();
                }
                catch (Exception ex)
                {
                    btnSaveAndReferral.Enabled = true;
                    lblConnectionStatus.Text = ex.Message;
                    System.Windows.Forms.Application.DoEvents();
                }
            }
            else
                DevExpress.XtraEditors.XtraMessageBox.Show(errMessage, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnArshiveRequest_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
            args.Icon = System.Drawing.SystemIcons.Warning;
            args.Text = "آیا مایل به انتقال این پیشنهاد به بایگانی می باشید؟";
            args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
            args.DefaultButtonIndex = 1;
            DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
            if (dlgRes == System.Windows.Forms.DialogResult.Yes)
            {
                string serial = this.thisRow["RequestSerial"].ToString();
                string reviewNo = this.thisRow["ReviewNo"].ToString();
                bool result = RequestManager.UpdateRequestLocation(serial, reviewNo, "بایگانی");
                if (txtFileId.TextLength > 0)
                {
                    int fileId = int.Parse(txtFileId.Text);
                    int coverNo = int.Parse(txtCoverNo.Text);
                    int indicatorId = int.Parse(txtIndicatorId.Text);
                    int expertId = int.Parse(txtExpertId.Text);
                    int branchId = int.Parse(txtBranchId.Text);
                    string branchName = lblBranchName.Text;
                    FilesManager.SetFileStatus(fileId, coverNo, indicatorId, expertId, branchId, branchName, true);
                }
                if (result)
                {
                    dlgDataLogs.AddRequestLog(serial, 7, "پیشنهاد بایگانی شد");
                    DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات شما با موفقیت ثبت شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChangeView(FormStatusEnum.Restart);
                }
            }
        }

        private void btnRequestLogs_Click(object sender, EventArgs e)
        {
            if (thisRow != null)
            {
                dlgDataLogs dlg = new dlgDataLogs(false);
                dlg.FillLoanFileLogs(thisRow);
                dlg.ShowDialog();
            }
        }    

        #endregion

        #region Panel Left
        private void gridViewAllFiles_Click(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridview = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DevExpress.Utils.DXMouseEventArgs mouseEventArgs = e as DevExpress.Utils.DXMouseEventArgs;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo = gridview.CalcHitInfo(mouseEventArgs.Location);

            if (hitInfo.InRow)
            {
                btnEditFile.Enabled = true;
                btnAddCover.Enabled = true;
                btnDeleteFile.Enabled = true;
                btnFileLogs.Enabled = true;
            }
            else
            {
                btnEditFile.Enabled = false;
                btnAddCover.Enabled = false;
                btnDeleteFile.Enabled = false;
                btnFileLogs.Enabled = false;
            }
        }

        private void gridViewAllFiles_DoubleClick(object sender, EventArgs e)
        {
            if (gridViewAllFiles.FocusedRowHandle >= 0 & pnlFileInfo.Enabled)
            {
                DataRow row = gridViewAllFiles.GetDataRow(gridViewAllFiles.FocusedRowHandle);
                txtBranchId.Text = row["BranchID"].ToString();
                lblBranchName.Text = row["BranchName"].ToString();
                txtCustomerId.Text = row["CustomerID"].ToString();
                txtCustomerName.Text = row["CustomerName"].ToString();
                txtFileId.Text = row["FileID"].ToString();
                txtCoverNo.Text = row["CoverNo"].ToString();
                txtIndicatorId.Text = row["IndicatorID"].ToString();
            }
        }

        private void txtSearchInAllFiles_EditValueChanged(object sender, EventArgs e)
        {
            if (gridControlAllFiles.DataSource != null)
            {
                try
                {
                    if (Numeral.IsNumber(txtSearchInAllFiles.Text))
                    {
                        string criteria = string.Format("FileID={0} OR IndicatorID={0} OR BranchID={0}", txtSearchInAllFiles.Text);
                        (gridControlAllFiles.DataSource as DataTable).DefaultView.RowFilter = criteria;
                    }
                    else
                    {
                        string criteria = string.Format("CustomerName LIKE '%{0}%' OR BranchName LIKE '%{0}%'", txtSearchInAllFiles.Text);
                        (gridControlAllFiles.DataSource as DataTable).DefaultView.RowFilter = criteria;
                    }
                }
                catch
                {
                    (gridControlAllFiles.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                }
            }
        }

        private void txtSearchInAllFiles_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSearchInAllFiles.ResetText();
            (gridControlAllFiles.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            new dlgAddLoanFile().ShowDialog();
        }
        
        private void btnArshiveReviewReport_Click(object sender, EventArgs e)
        {
            new dlgArshiveReviewReport().ShowDialog();
        }

        private void btnEditFile_Click(object sender, EventArgs e)
        {
            if (gridViewAllFiles.FocusedRowHandle >= 0)
            {
                DataRow row = gridViewAllFiles.GetDataRow(gridViewAllFiles.FocusedRowHandle);
                string fileID = row["FileID"].ToString();
                string IndicatorId = row["IndicatorID"].ToString();
                string branchID = row["BranchID"].ToString();
                string branchName = row["BranchName"].ToString();
                string customerID = row["CustomerID"].ToString();
                string customerName = row["CustomerName"].ToString();
                string coverNo = row["CoverNo"].ToString();
                string note = row["Note"].ToString();
                new dlgEditFile(fileID, IndicatorId, branchID, branchName, customerID, customerName, coverNo, note).ShowDialog();
            }
        }

        private void btnAddCover_Click(object sender, EventArgs e)
        {
            if (gridViewAllFiles.FocusedRowHandle >= 0)
            {
                DataRow row = gridViewAllFiles.GetDataRow(gridViewAllFiles.FocusedRowHandle);
                string fileID = row["FileID"].ToString();
                string IndicatorId = row["IndicatorID"].ToString();
                string branchID = row["BranchID"].ToString();
                string branchName = row["BranchName"].ToString();
                string customerName = row["CustomerName"].ToString();
                string coverNo = row["CoverNo"].ToString();
                string note = row["Note"].ToString();
                new dlgAddCover(fileID, IndicatorId, branchID, branchName, customerName, coverNo).ShowDialog();
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            if (gridViewAllFiles.FocusedRowHandle >= 0)
            {
                DataRow row = gridViewAllFiles.GetDataRow(gridViewAllFiles.FocusedRowHandle);
                string coverNo = row["CoverNo"].ToString();
                string fileID = row["FileID"].ToString();
                string customerName = row["CustomerName"].ToString();

                DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args.Icon = System.Drawing.SystemIcons.Question;
                args.Text = string.Format("آیا از حذف جلد {0} شماره پرونده {1} بنام {2} اطمینان کامل حاصل دارید؟", coverNo, fileID, customerName);
                args.DefaultButtonIndex = 1;
                args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                if (dlgRes == System.Windows.Forms.DialogResult.Yes)
                {
                    bool queryResult = FilesManager.DeleteFile(fileID, coverNo);
                    if (queryResult)
                    {
                        gridViewAllFiles.DeleteRow(gridViewAllFiles.FocusedRowHandle);
                        txtSearchInAllFiles.Select();
                    }
                }
            }
        }


        private void btnFileLogs_Click(object sender, EventArgs e)
        {
          DataRow row = gridViewAllFiles.GetDataRow(gridViewAllFiles.FocusedRowHandle);
          if (row != null)
            {
                dlgArchiveLogs dlg = new dlgArchiveLogs();
                dlg.FillArchiveFileLogs(row["FileID"].ToString());
                dlg.ShowDialog();
            }
        }

        private void btnRefreshAllFiles_Click(object sender, EventArgs e)
        {
            progressBar.Show();
            btnRefreshAllFilesAndCovers.Enabled = false;
            Application.DoEvents();
            FilesManager.FillFilesWithCovers();
            RefreshAllFilesAndCovers(true);
            btnRefreshAllFilesAndCovers.Enabled = true;
        }

        private void btn1ExportToXlsx_Click(object sender, EventArgs e)
        {
            btn1ExportToXlsx.Enabled = false;
            Application.DoEvents();
            DevExportToXlsx.SaveAs(gridViewAllFiles);
            btn1ExportToXlsx.Enabled = true;
        }

        private void gridViewAllFiles_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                string value = gridViewAllFiles.GetDataRow(e.RowHandle)["IsFileArchived"].ToString();
                if (value == bool.FalseString )
                    e.Appearance.BackColor2 = System.Drawing.Color.LightPink;
            }
        }

        #endregion

        #endregion

        #region Views

        #endregion

        #region Methods
      
        private string CheckInputValues()
        {
            if (cboRequestType.Text.Length == 0 & this.FormStatus != FormStatusEnum.exitFile)
                return "لطفا نوع پیشنهاد را مشخص کنید";
            if (txtCustomerName.TextLength == 0)
                return "لطفا نام متقاضی را وارد کنید";
            if (txtBranchId.TextLength == 0)
                return "لطفا نام شعبه را مشخص کنید";
            if (txtExpertId.TextLength == 0)
                return "لطفا نام تحویل گیرنده را مشخص کنید";
            if (Numeral.AnyToLong(txtFileId.Text) > 0 & (Numeral.AnyToLong(txtCoverNo.Text) == 0 | Numeral.AnyToLong(txtIndicatorId.Text) == 0))
                return "شماره جلد/کلاسه پرونده مشخص نشده است";
            return string.Empty;
        }

        public void ShowRequestItems(DataTable dt)
        {
            int rowsCount = dt.Rows.Count;
            DataTable tableSorted = dt.AsEnumerable().OrderByDescending(x => x["ModifiedDate"]).ThenByDescending(x => x["ModifiedTime"]).CopyToDataTable();
            if (rowsCount > 0)
            {
                DataRow row = tableSorted.Rows[0];
                this.thisRow = row;
                string requestStatus = row["RequestStatus"].ToString();
                txtRequestStatus.Text = requestStatus;
                cboRequestType.Text = row["RequestType"].ToString();
                Branches.BranchInfo branch = Branches.GetBranchById(row["BranchID"].ToString(), true);
                txtBranchId.Text = branch.BranchId;
                lblBranchName.Text = branch.BranchName;
                txtCustomerId.Text = row["CustomerID"].ToString();
                txtCustomerName.Text = row["CustomerName"].ToString();
                chkIsLegalPerson.Checked = bool.Parse(row["IsLegalPerson"].ToString());
                txtRequestAmount.Text = row["RequestAmount"].ToString();
                txtReviewNo.Text = ChkSum.GetFull(row["ReviewNo"].ToString());
                if (Numeral.AnyToLong(row["FileID"]) > 0)
                    txtRequestLocation.Text = FilesManager.GetFileLocation(row["FileID"].ToString(), row["CoverNo"].ToString());
                else
                    txtRequestLocation.Text = row["RequestLocation"].ToString();


                txtFileId.Text = row["FileID"].ToString();
                txtCoverNo.Text = row["CoverNo"].ToString();
                txtFacilityId.Text = row["FacilityID"].ToString();
                txtFacilityName.Text = Facilitys.GetFacilityNameById(row["FacilityID"].ToString());
                txtExpertId.Text = row["ExpertID"].ToString();
                lblExpertName.Text = Users.GetUserNameById(Numeral.AnyToInt32(row["ExpertID"]));
            }
            FilterFiles();
            txtRequestId.SelectAll();
        }

        private void FilterFiles()
        {
            if (gridControlAllFiles.DataSource != null)
            {
                if (txtBranchId.TextLength > 0 & txtCustomerName.TextLength == 0)
                {
                    string criteria = string.Format("BranchID = {0}", txtBranchId.Text);
                    (gridControlAllFiles.DataSource as DataTable).DefaultView.RowFilter = criteria;
                }
                else if (txtBranchId.TextLength == 0 & txtCustomerName.TextLength > 0)
                {
                    string criteria = string.Format("CustomerName LIKE '%{0}%'", txtCustomerName.Text);
                    (gridControlAllFiles.DataSource as DataTable).DefaultView.RowFilter = criteria;
                }
                else if (txtBranchId.TextLength > 0 & txtCustomerName.TextLength > 0)
                {
                    string criteria = string.Format("BranchID = {0} AND CustomerName LIKE '%{1}%'", txtBranchId.Text, txtCustomerName.Text);
                    (gridControlAllFiles.DataSource as DataTable).DefaultView.RowFilter = criteria;
                }
            }
        }

        private void RefreshAllFilesAndCovers(bool showloading)
        {
            if (showloading)
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
            btnRefreshAllFilesAndCovers.Enabled = false;
            System.Windows.Forms.Application.DoEvents();
            gridControlAllFiles.DataSource = FilesManager.TableAllFilesAndCovers;
            btnRefreshAllFilesAndCovers.Enabled = true;
            if (showloading)
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }
       
        private void ChangeView(FormStatusEnum status)
        {
            this.FormStatus = status;
        
            switch (status)
            {
                case FormStatusEnum.Restart:
                    this.thisRow = null;
                    btnChangeExpertID.Enabled = false;
                    btnArshiveRequest.Enabled = false;
                    btnClone.Enabled = false;
                    btnLogs.Enabled = false;

                    txtRequestId.ReadOnly = false;
                    btnSearch.Enabled = true;
                    txtRequestStatus.Text = string.Empty;
                    cboRequestType.SelectedIndex = 0;
                    txtFacilityId.ResetText();
                    txtFacilityName.ResetText();
                    txtBranchId.ResetText();
                    lblBranchName.ResetText();
                    txtFileId.ResetText();
                    txtCoverNo.Enabled = false;
                    txtCoverNo.ResetText();
                    txtIndicatorId.ResetText();
                    txtCustomerId.ResetText();
                    txtCustomerName.ResetText();
                    chkIsLegalPerson.Checked = false;
                    txtRequestAmount.Text = "0";
                    txtReviewNo.ResetText();
                    txtRequestLocation.ResetText();

                    txtExpertId.ResetText();
                    lblExpertName.Text = string.Empty;

                    pnlSearch.Enabled = true;
                    pnlRequestInfo.Enabled = false;
                    pnlFileInfo.Enabled = false;
                    pnlSave.Enabled = false;

                    txtRequestId.Focus();
                    txtRequestId.Select();
                    if (gridControlAllFiles.DataSource != null)
                        (gridControlAllFiles.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                    break;

                case FormStatusEnum.Show:
                    this.thisRow = null;
                    btnChangeExpertID.Enabled = true;
                    btnArshiveRequest.Enabled = true;
                    btnClone.Enabled = true;
                    btnLogs.Enabled = true;

                    txtRequestId.ReadOnly = false;
                    btnSearch.Enabled = true;
                    txtRequestStatus.Text = string.Empty;
                    cboRequestType.SelectedIndex = 0;
                    txtFacilityId.ResetText();
                    txtFacilityName.ResetText();
                    txtBranchId.ResetText();
                    lblBranchName.ResetText();
                    txtFileId.ResetText();
                    txtCoverNo.Enabled = false;
                    txtCoverNo.Text = "0";
                    txtCoverNo.ResetText();
                    txtIndicatorId.ResetText();
                    txtCustomerId.ResetText();
                    txtCustomerName.ResetText();
                    chkIsLegalPerson.Checked = false;
                    txtRequestAmount.Text = "0";
                    txtReviewNo.ResetText();
                    txtRequestLocation.ResetText();



                    txtExpertId.ResetText();
                    lblExpertName.Text = string.Empty;

                    pnlSearch.Enabled = true;
                    pnlRequestInfo.Enabled = false;
                    pnlFileInfo.Enabled = false;
                    pnlSave.Enabled = false;

                    txtRequestId.Focus();
                    txtRequestId.SelectAll();
                    if (gridControlAllFiles.DataSource != null)
                        (gridControlAllFiles.DataSource as DataTable).DefaultView.RowFilter = string.Empty;

                    break;

                case FormStatusEnum.New:
                    this.thisRow = null;
                    btnChangeExpertID.Enabled = false;
                    btnArshiveRequest.Enabled = false;
                    btnClone.Enabled = false;
                    btnLogs.Enabled = false;

                    txtRequestId.ReadOnly = true;
                    btnSearch.Enabled = true;
                    txtRequestStatus.Text = string.Empty;
                    cboRequestType.SelectedIndex = 0;
                    txtFacilityId.ResetText();
                    txtFacilityName.ResetText();
                    txtBranchId.ResetText();
                    lblBranchName.ResetText();
                    txtFileId.ResetText();
                    txtCoverNo.Enabled = false;
                    txtCoverNo.Text = "0";
                    txtCoverNo.ResetText();
                    txtIndicatorId.ResetText();
                    txtCustomerId.ResetText();
                    txtCustomerName.ResetText();
                    chkIsLegalPerson.Checked = false;
                    txtRequestAmount.Text = "0";
                    txtReviewNo.ResetText();
                    txtRequestLocation.ResetText();


                    txtExpertId.ResetText();
                    lblExpertName.Text = string.Empty;

                    pnlSearch.Enabled = false;
                    pnlRequestInfo.Enabled = true;
                    pnlFileInfo.Enabled = true;
                    pnlSave.Enabled = true;

                    cboRequestType.Focus();
                    cboRequestType.Select();
                    if (gridControlAllFiles.DataSource != null)
                        (gridControlAllFiles.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                    break;

                case FormStatusEnum.exitFile:
                    this.thisRow = null;
                    btnChangeExpertID.Enabled = false;
                    btnArshiveRequest.Enabled = false;
                    btnClone.Enabled = false;
                    btnLogs.Enabled = false;

                    txtRequestId.ReadOnly = false;
                    txtRequestId.Text = string.Empty;
                    btnSearch.Enabled = true;
                    txtRequestStatus.Text = string.Empty;
                    cboRequestType.SelectedIndex = 0;
                    txtFacilityId.ResetText();
                    txtFacilityName.ResetText();
                    txtBranchId.ResetText();
                    lblBranchName.Text = string.Empty;
                    txtFileId.ResetText();
                    txtCoverNo.Enabled = false;
                    txtCoverNo.ResetText();
                    txtIndicatorId.ResetText();
                    txtCustomerId.ResetText();
                    txtCustomerName.ResetText();
                    chkIsLegalPerson.Checked = false;
                    txtRequestAmount.Text = "0";

                    txtExpertId.ResetText();
                    lblExpertName.Text = string.Empty;

                    pnlSearch.Enabled = false;
                    pnlRequestInfo.Enabled = false;
                    pnlFileInfo.Enabled = true;
                    pnlSave.Enabled = true;

                    btnBranchesList.Select();
                    if (gridControlAllFiles.DataSource != null)
                        (gridControlAllFiles.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                    break;

                case FormStatusEnum.Edit:
                    txtRequestId.ReadOnly = true;
                    btnSearch.Enabled = false;
                    pnlRequestInfo.Enabled = true;
                    pnlFileInfo.Enabled = true;
                    pnlSave.Enabled = true;
                    break;

                case FormStatusEnum.asNew:
                    Clipboard.SetText(txtRequestId.Text);

                    this.thisRow = null;
                    btnChangeExpertID.Enabled = false;
                    btnArshiveRequest.Enabled = false;
                    btnClone.Enabled = false;
                    btnLogs.Enabled = false;

                    txtRequestId.ReadOnly = false;
                    btnSearch.Enabled = false;
                    txtRequestStatus.Text = string.Empty;
                    txtReviewNo.ResetText();
                    txtRequestLocation.ResetText();

                    pnlRequestInfo.Enabled = true;
                    pnlFileInfo.Enabled = true;
                    pnlSave.Enabled = true;
                    pnlSearch.Enabled = true;

                    txtRequestId.Focus();
                    txtRequestId.SelectAll();
                    if (gridControlAllFiles.DataSource != null)
                        (gridControlAllFiles.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                    break;

                default:
                    break;
            }
        }
      
        #endregion 
      
        #endregion

        #region Page 2

        private void txtSearchInUnArchivedFiles_EditValueChanged(object sender, EventArgs e)
        {
            if (gridControlUnArchivedFiles.DataSource != null)
            {
                try
                {
                    string criteria = string.Format("CONVERT(FileID, 'System.String')='{0}' OR CONVERT(IndicatorID, 'System.String')='{0}' OR CustomerName LIKE '%{0}%' OR CONVERT(BranchID, 'System.String')='{0}' OR BranchName LIKE '%{0}%'", txtSearchInUnArchivedFiles.Text);
                    (gridControlUnArchivedFiles.DataSource as DataTable).DefaultView.RowFilter = criteria;
                }
                catch
                {
                    (gridControlUnArchivedFiles.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                }
            }
        }
      
        private void txtSearchInUnArchivedFiles_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSearchInUnArchivedFiles.ResetText();
            (gridControlUnArchivedFiles.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
        }

        private void btn2ExportToXlsx_Click(object sender, EventArgs e)
        {
            btn2ExportToXlsx.Enabled = false;
            Application.DoEvents();
            DevExportToXlsx.SaveAs(gridViewUnArchivedFiles);
            btn2ExportToXlsx.Enabled = true;
        }
      
        private void btnRefreshUnArchivedFiles_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
            btnRefreshUnArchivedFiles.Enabled = false;
            Application.DoEvents();
            FilesManager.FillUnArchivedFiles();
            RefreshUnArchivedFiles();
            btnRefreshUnArchivedFiles.Enabled = true;
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void repositorybtnArchiveFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
            args.Icon = System.Drawing.SystemIcons.Question;
            args.Text = "آیا مایل به بایگانی پرونده می باشید؟";
            args.DefaultButtonIndex = 1;
            args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
            DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
            if (dlgRes == System.Windows.Forms.DialogResult.Yes)
            {
                DataRow row = gridViewUnArchivedFiles.GetDataRow(gridViewUnArchivedFiles.FocusedRowHandle);
                int fileId = int.Parse(row["FileID"].ToString());
                int coverNo = int.Parse(row["CoverNo"].ToString());
                int indicatorId = int.Parse(row["IndicatorID"].ToString());
                int expertId = int.Parse(row["GetterID"].ToString());
                int branchId = int.Parse(row["BranchID"].ToString());
                string branchName = row["BranchName"].ToString();

                bool result = FilesManager.SetFileStatus(fileId, coverNo, indicatorId, expertId, branchId, branchName, true);
                if (result)
                {
                    gridViewUnArchivedFiles.DeleteRow(gridViewUnArchivedFiles.FocusedRowHandle);
                }
            }
        }

        private void RefreshUnArchivedFiles()
        {
            txtSearchInUnArchivedFiles.ResetText();
            DataTable table = FilesManager.TableUnArchivedFiles;
            if (table.Rows.Count > 0)
            {
                tabControl.TabPages[1].Text = string.Format("پرونده ها ({0})", table.Rows.Count);
                gridControlUnArchivedFiles.DataSource = table;
            }
            else
            {
                tabControl.TabPages[1].Text = "پرونده ها";
                gridControlUnArchivedFiles.DataSource = null;
            }
        }

        #endregion

        #region Page 3
       
        private void btn3ExportToXlsx_Click(object sender, EventArgs e)
        {
            btn3ExportToXlsx.Enabled = false;
            Application.DoEvents();
            DevExportToXlsx.SaveAs(gridViewTodayRequests);
            btn3ExportToXlsx.Enabled = true;
        }
     
        private void txtSearchInTodayRequests_EditValueChanged(object sender, EventArgs e)
        {
            if (gridControlTodayRequests.DataSource != null)
            {
                try
                {
                    string criteria = string.Format("CONVERT(RequestID, 'System.String')='{0}' OR CustomerName LIKE '%{0}%' OR CONVERT(BranchID, 'System.String')='{0}' OR BranchName LIKE '%{0}%'", txtSearchInTodayRequests.Text);
                    (gridControlTodayRequests.DataSource as DataTable).DefaultView.RowFilter = criteria;
                }
                catch
                {
                    (gridControlTodayRequests.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                }
            }
        }
       
        private void txtSearchInTodayRequests_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtSearchInTodayRequests.ResetText();
            (gridControlTodayRequests.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
        }
      
        private void btnRefreshTodayRequests_Click(object sender, EventArgs e)
        {
            btnRefreshTodayRequests.Enabled = false;
            Application.DoEvents();
            RefreshTodayRequests();
            btnRefreshTodayRequests.Enabled = true;
        }

        private void repositorybtnEditRequest_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            object requestId = gridViewTodayRequests.GetRowCellValue(gridViewTodayRequests.FocusedRowHandle, "RequestID");
            if (requestId != null)
            {
                txtRequestId.Text = requestId.ToString();
                btnSearch_Click(null, EventArgs.Empty);
                tabControl.SelectedTabPageIndex = 0;
            }
        }

        private void RefreshTodayRequests()
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
            txtSearchInTodayRequests.ResetText();
            DataTable table = RequestManager.GetRegisteredRequestsByUserID(Network.GetNowDateSerial(), Users.MyUserID);
            if (table.Rows.Count > 0)
            {
                tabControl.TabPages[2].Text = string.Format("پیشنهادات امروز ({0})", table.Rows.Count);
                gridControlTodayRequests.DataSource = table;
            }
            else
            {
                tabControl.TabPages[2].Text = "پیشنهادات امروز";
                gridControlTodayRequests.DataSource = null;
            }
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        #endregion

        #region Main Events
       
        private void tabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
            System.Windows.Forms.Application.DoEvents();

            switch (tabControl.SelectedTabPageIndex)
            {
                case 0:
                    RefreshAllFilesAndCovers(false);
                    break;
                case 1:
                    RefreshUnArchivedFiles();
                    break;
                default:
                    break;
            }


            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }
     
        private void NextControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void Srartup()
        {
            progressBar.Show();
            Application.DoEvents();
            FilesManager.FillFilesWithCovers();
            gridControlAllFiles.DataSource = FilesManager.TableAllFilesAndCovers;
        }

        internal static void RaiseLoadEvent()
        {
            System.EventHandler handler = LoadEvent;
            if (handler != null)
            {
                handler(null, null);
            }
        }

        private void this_LoadEvent(object sender, EventArgs e)
        {
            Srartup();
        }

        int lastPosition = 0;
        private void FilesManager_LoadEvent(object sender, System.EventArgs e)
        {
            if (sender != null)
            {
                int currentPosition = (int)Math.Round((double)sender);
                if (lastPosition != currentPosition)
                {
                    progressBar.EditValue = currentPosition;
                    Application.DoEvents();
                }

                if (currentPosition >= 100)
                {
                    progressBar.Hide();
                    progressBar.EditValue = 0;
                }
            }
        }

        #endregion
     }
}
