using GAM.Dialogs;
using GAM.Forms.Information;
using GAM.Forms.Information.Library;
using GAM.Forms.Profile.Etebarat.Library;
using GAM.Forms.Profile.Etebarat.Print;
using GAM.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GAM.Forms.Profile.Etebarat.Review
{
    public partial class dlgAddRequest : DevExpress.XtraEditors.XtraForm
    {
        frmReviewLoanFile frmBarasi;
        string RequestId;
        string RequestSerial;
        bool NewRequestId = true;

        public dlgAddRequest(frmReviewLoanFile ownver, string requestId, string requestSerial, bool newRequest)
        {
            InitializeComponent();

            this.RequestId = requestId;
            this.RequestSerial = requestSerial;
            this.frmBarasi = ownver;
            this.NewRequestId = newRequest;

            txtRequestId.Select();
            if (requestId.Length > 0)
            {
                txtRequestId.Text = requestId;
                btnSearch_Click(null, EventArgs.Empty);
            }
        
            if (!newRequest)
                btnSave.Text = "ویرایش اطلاعات پیشنهاد";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtRequestId.Text.Length > 0)
            {
                try
                {
                    pnlSearch.Enabled = false;
                    lblPleaseWait.Show();
                    Application.DoEvents();
                    DataTable dt = new DataTable();
                    if (this.RequestSerial.Length > 0)
                        dt = RequestManager.GetBySerial(this.RequestSerial);
                    else
                        dt = RequestManager.GetRequestById(long.Parse(txtRequestId.Text));
                    
                    lblPleaseWait.Hide();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        if (this.RequestId.Length == 0 & row["ReviewNo"].ToString().Length > 0)
                        {
                            if (frmBarasi.txtReviewNo.Text != row["ReviewNo"].ToString())
                            {
                                lblPleaseWait.Hide();
                                if (row["ExpertID"].ToString() == Users.MyUserID.ToString())
                                    DevExpress.XtraEditors.XtraMessageBox.Show(string.Format("این پیشنهاد با شماره بررسی {0} در سیستم ثبت شده است"+ "\n" +"لطفاً جهت بررسی این پیشنهاد به بخش فرم های بررسی (کارتابل) مراجعه و فرم مربوطه را ویرایش نمایید", ChkSum.GetFull(row["ReviewNo"].ToString())), "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                else
                                    DevExpress.XtraEditors.XtraMessageBox.Show(string.Format("این پیشنهاد با شماره بررسی {1} در سیستم ثبت شده است" + "\n" + "جهت بررسی این پیشنهاد می بایست ابتدا توسط {0} یا مسئول بایگانی به شما ارجاع گردد", Users.GetUserNameWithSexByID(int.Parse(row["ExpertID"].ToString())), ChkSum.GetFull(row["ReviewNo"].ToString())), "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                pnlSearch.Enabled = true;
                                txtRequestId.Focus();
                                txtRequestId.SelectAll();
                                return;
                            }
                        }

                        string serial = row["RequestSerial"].ToString();
                        string customerId = row["CustomerID"].ToString();
                        string branchId = row["BranchID"].ToString();
                        string fileId = row["FileID"].ToString();
                        string coverNo = row["CoverNo"].ToString();
                        string customerName = row["CustomerName"].ToString();
                        string isLegalPerson = (bool.Parse(row["IsLegalPerson"].ToString())) ? "حقوقی" : "حقیقی";
                        string requestId = row["RequestID"].ToString();
                        string requestType = row["RequestType"].ToString();
                        string facilityId = row["FacilityID"].ToString();
                        string facilityName = Facilitys.GetFacilityNameById(facilityId);
                        string bails1 = row["Bails1"].ToString();
                        string bailsDetail = row["BailsDetail"].ToString();
                        string requestAmount = Numeral.AnyToLong(row["RequestAmount"]).ToString("n0");
                        string referralDate = row["ReferralDate"].ToString();

                        txtRequestId.Tag = serial;
                        txtRequestId.Text = requestId;
                        txtReferralDate.Text = referralDate;
                        txtCustomerId.Text = customerId;
                        txtBranchId.Text = branchId;
                        lblBranchName.Text = Branches.GetBranchById(branchId, true).BranchName;
                        txtFileId.Text = fileId;
                        txtCoverNo.Text = coverNo;
                        txtCustomerName.Text = customerName;
                        cboPersonType.Text = isLegalPerson;
                        cboRequestType.Text = requestType;
                        txtFacilityID.Text = facilityId;
                        txtFacilityName.Text = facilityName;
                        cboBails1.Text = bails1;
                        txtBailsDetail.Text = bailsDetail;
                        txtRequestAmount.Text = requestAmount;
                        pnlRequestInfo.Enabled = true;
                        pnlSave.Enabled = true;
                        txtCustomerId.Focus();
                        txtCustomerId.Select();
                    }
                    else
                    {
                        lblPleaseWait.Hide();
                        pnlSearch.Enabled = true;
                        DevExpress.XtraEditors.XtraMessageBox.Show("شماره پیشنهاد وارد شده در سیستم وجود ندارد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    lblPleaseWait.Hide();
                    pnlSearch.Enabled = true;
                }
            }
        }

        private void btnBranchesInfo_Click(object sender, EventArgs e)
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

        private void btnFacilitysList_Click(object sender, EventArgs e)
        {
            dlgFacilitysList dlg = new dlgFacilitysList();
            DialogResult dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                if (dlg.FacilityId.Length > 0 & dlg.FacilityName.Length > 0)
                {
                    txtFacilityID.Text = dlg.FacilityId;
                    txtFacilityName.Text = dlg.FacilityName;
                }
            }
        }
      
        private void NextControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void cboRequestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnFacilitysList.Enabled = false;
            txtFacilityID.Clear();
            txtFacilityName.Clear();
            cboBails1.Enabled = false;
            txtBailsDetail.Enabled = false;
            cboBails1.Text = string.Empty;
            lblRequestAmount.Text = "مبلغ پیشنهادی";
            txtRequestAmount.Text = "0";
            txtRequestAmount.Enabled = false;

            if (cboRequestType.Text == "موردی" | cboRequestType.Text == "حد اعتباری" | cboRequestType.Text == "سقف اعتباری" | cboRequestType.Text == "متمم")
            {
                btnFacilitysList.Enabled = true;
                cboBails1.Enabled = true;
                txtBailsDetail.Enabled = true;
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
                cboBails1.Enabled = true;
                txtBailsDetail.Enabled = true;
            }
            if (cboRequestType.Text == "تخفیف کارمزد")
            {
                lblRequestAmount.Text = "% درصد تخفیف";
                txtRequestAmount.Enabled = true;
                btnFacilitysList.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string errMessage = CheckInputValues();
            if (errMessage.Length == 0)
            {
                int requestIdCount = this.frmBarasi.TableRequests.AsEnumerable().Count(x => x["RequestID"].ToString() == txtRequestId.Text);
                if (this.RequestId.Length == 0 & requestIdCount > 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("شماره پیشنهاد تکراری می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.frmBarasi.txtCustomerId.Text.Length > 0 && txtCustomerId.Text != this.frmBarasi.txtCustomerId.Text)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("بدلیل مغایرت شماره مشتری این پیشنهاد نمی تواند به لیست اضافه شود", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.frmBarasi.txtCustomerName.Text.Length > 0 && txtCustomerName.Text.Trim() != this.frmBarasi.txtCustomerName.Text)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("به دلیل مغایرت نام مشتری این پیشنهاد نمی تواند به لیست اضافه شود", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.frmBarasi.txtBranchName.Text.Length > 0 && lblBranchName.Text != this.frmBarasi.txtBranchName.Text)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("به دلیل مغایرت نام شعبه این پیشنهاد نمی تواند به لیست اضافه شود", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    btnSave.Enabled = false;
                    Application.DoEvents();

                    string serial = txtRequestId.Tag.ToString();
                    string requestID = txtRequestId.Text;
                    string requestType = cboRequestType.Text;
                    int branchId = int.Parse(txtBranchId.Text);
                    string customerId = txtCustomerId.Text;
                    string customerName = txtCustomerName.Text.Trim();
                    bool isLegalPerson = (cboPersonType.Text == "حقوقی") ? true : false;
                    long? fileId = Numeral.ToLongNullable(txtFileId.Text);
                    long? coverNo = Numeral.ToLongNullable(txtCoverNo.Text);
                    int facilityId = int.Parse(txtFacilityID.Text);
                    string bails1 = cboBails1.Text;
                    string bailsDetail = txtBailsDetail.Text;
                    long requestAmount = Numeral.AnyToLong(txtRequestAmount.Text);
                    int referralDate = int.Parse(Numeral.ExtractDigits(txtReferralDate.Text));

                    serial = RequestManager.UpdateQuery(serial, RequestStatus.Barasi, requestType, branchId, customerId, customerName, isLegalPerson, fileId, coverNo, facilityId, bails1, bailsDetail, requestAmount, Users.MyUserID);
                    if (serial.Length > 0)
                    {
                        if (this.NewRequestId)
                        {
                            DataRow row = this.frmBarasi.TableRequests.NewRow();
                            row["RequestSerial"] = serial;
                            row["RequestID"] = requestID;
                            row["RequestType"] = requestType;
                            row["RequestAmount"] = requestAmount.ToString("n0");
                            row["FacilityType"] = Facilitys.GetFacilityTypeByID(txtFacilityID.Text);
                            row["FacilityID"] = txtFacilityID.Text;
                            row["FacilityName"] = Facilitys.GetFacilityNameById(txtFacilityID.Text);
                            row["BailsDetail"] = bailsDetail;
                            this.frmBarasi.TableRequests.Rows.Add(row);
                        }
                        else
                        {
                            foreach (DataRow r in this.frmBarasi.TableRequests.Rows)
                            {
                                if (r["RequestID"].ToString() == this.RequestId)
                                {
                                    r["RequestSerial"] = serial;
                                    r["RequestID"] = requestID;
                                    r["RequestType"] = requestType;
                                    r["RequestAmount"] = requestAmount.ToString("n0");
                                    r["FacilityType"] = Facilitys.GetFacilityTypeByID(txtFacilityID.Text);
                                    r["FacilityID"] = txtFacilityID.Text;
                                    r["FacilityName"] = Facilitys.GetFacilityNameById(txtFacilityID.Text);
                                    r["BailsDetail"] = bailsDetail;
                                }
                            }
                        }

                        if (referralDate > this.frmBarasi.ReferralDate)
                            this.frmBarasi.ReferralDate = referralDate;
                        this.frmBarasi.txtDomainName.Text = Branches.GetBranchById(txtBranchId.Text, true).Domain.DomainName;
                        this.frmBarasi.txtBranchID.Text = txtBranchId.Text;
                        this.frmBarasi.txtBranchName.Text = Branches.GetBranchById(txtBranchId.Text, true).BranchName;
                        this.frmBarasi.txtBranchDegree.Text = Branches.GetBranchById(txtBranchId.Text, true).BranchDegree;

                        this.frmBarasi.txtPersonalityType.Text = cboPersonType.Text;
                        this.frmBarasi.txtCustomerId.Text = txtCustomerId.Text;
                        this.frmBarasi.txtCustomerName.Text = txtCustomerName.Text;
                        this.frmBarasi.pnlMain.Enabled = true;
                        this.frmBarasi.EnablePanels();

                        btnSave.Enabled = true;
                        if (this.NewRequestId)
                            DevExpress.XtraEditors.XtraMessageBox.Show("پیشنهاد با موفقیت به لیست پیشنهادات اضافه شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            DevExpress.XtraEditors.XtraMessageBox.Show("ویرایش اطلاعات با موفقیت انجام شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.frmBarasi.gridRequests.DataSource = this.frmBarasi.TableRequests;

                        this.Close();
                    }

                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = true;
                    Application.DoEvents();
                }
            }
            else
                DevExpress.XtraEditors.XtraMessageBox.Show(errMessage, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private string CheckInputValues()
        {
            if (!MD.PersianDateTime.PersianDateTime.IsValidDate(txtReferralDate.Text))
                return "این پیشنهاد ارجاع نشده است";
            if (btnFacilitysList.Enabled & txtFacilityID.TextLength == 0)
                return "فیلد نوع تسهیلات خالی می باشد";
            if (txtCustomerId.Text.Length <= 2)
                return "فیلد شماره مشتری نامعتبر می باشد";
            if (cboRequestType.Text.Length == 0)
                return "لطفا نوع پیشنهاد را مشخص کنید";
            if (txtCustomerName.Text.Length == 0)
                return "لطفا نام متقاضی را وارد کنید";
            if (lblBranchName.Text.Length == 0)
                return "لطفا نام شعبه را مشخص کنید";
            if (cboRequestType.Text == "تخفیف کارمزد" & Numeral.AnyToDouble(txtRequestAmount.Text) == 0)
                return "لطفا درصد تخفیف کارمزد را وارد نمایید";
            if (txtBailsDetail.Enabled & txtBailsDetail.Text.Trim().Length == 0)
                return "لطفا شرح وثایق پیشنهادی شعبه را مشخص کنید";
            if (txtBailsDetail.Enabled & (!txtBailsDetail.Text.Contains("%") & !txtBailsDetail.Text.Contains("درصد")))
                return "شرح وثایق نامعتبر می باشد";
            if (txtBailsDetail.Enabled & Numeral.ExtractDigits(txtBailsDetail.Text).Length == 0)
                return "شرح وثایق نامعتبر می باشد";

            return string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

    }
}
