using GAM.Forms.Information;
using GAM.Forms.Information.Library;
using GAM.Forms.Profile.Etebarat.Library;
using GAM.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Profile.Etebarat.Print
{
    public partial class dlgAddLinkedRequest : DevExpress.XtraEditors.XtraForm
    {
        public string RequestSerial { get; set; }
        public string RequestID { get; set; }
        private DataRow thisRow { get; set; }
        private dlgChangeStatus frmChangeStatus { get; set; }

        public dlgAddLinkedRequest(dlgChangeStatus frm, DataRow row)
        {
            InitializeComponent();
            thisRow = row;
            RequestSerial = string.Empty;
            RequestID = string.Empty;
            frmChangeStatus = frm;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRequestId.Text == frmChangeStatus.txtRequestID.Text | frmChangeStatus.listRequests.Items[txtRequestId.Text] != null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("این شماره پیشنهاد در لیست پیشنهادات مرتبط موجود می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtRequestId.Text.Length > 0 & cboRequestType.Text.Length > 0 & txtFacilityId.TextLength > 0 & Numeral.AnyToDouble(txtRequestAmount.Text) > 0)
            {
                if (this.RequestSerial.Length == 0)
                {
                    this.RequestSerial = RequestManager.InsertQuery(RequestStatus.Barasi, long.Parse(txtRequestId.Text), cboRequestType.Text, cboRequestPlane.Text, int.Parse(thisRow["BranchID"].ToString()), 1, thisRow["CustomerID"].ToString(), thisRow["CustomerName"].ToString(), bool.Parse(thisRow["IsLegalPerson"].ToString()), Numeral.AnyToLong(thisRow["FileID"].ToString()), Numeral.AnyToLong(thisRow["CoverNo"].ToString()), int.Parse(txtFacilityId.Text), string.Empty, string.Empty, Numeral.AnyToLong(txtRequestAmount.Text), thisRow["CreditCommittee"].ToString(), int.Parse(thisRow["ExpertID"].ToString()), null, string.Empty, null, string.Empty);
                    this.RequestID = txtRequestId.Text;
                    dlgDataLogs.AddRequestLog(this.RequestSerial, 7, string.Format("پیشنهاد در سیستم ثبت و جهت بررسی به {0} تحویل گردید", Users.GetUserNameWithSexByID(Numeral.AnyToInt32(thisRow["ExpertID"].ToString()))));
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else 
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtRequestId.Text.Length > 0)
            {
                try
                {
                    btnSearch.Enabled = false;
                    this.RequestSerial = string.Empty;
                    this.RequestID = string.Empty;
                    cboRequestType.ResetText();
                    cboRequestPlane.ResetText();
                    txtFacilityId.ResetText();
                    txtFacilityName.ResetText();
                    txtRequestAmount.ResetText();

                    Application.DoEvents();

                    DataTable table = RequestManager.GetRequestById(Numeral.AnyToLong(txtRequestId.Text.Trim()));
                    if (table != null)
                    {
                        if (table.Rows.Count > 0)
                        {
                            DataTable tableSorted = table.AsEnumerable().OrderByDescending(x => x["ModifiedDate"]).ThenByDescending(x => x["ModifiedTime"]).CopyToDataTable();
                            if (tableSorted.Rows.Count > 0)
                            {
                                DataRow row = tableSorted.Rows[0];
                                this.RequestSerial = row["RequestSerial"].ToString();
                                this.RequestID = row["RequestID"].ToString();
                                cboRequestType.Text = row["RequestType"].ToString();
                                cboRequestPlane.Text = row["RequestPlane"].ToString();
                                txtFacilityId.Text = row["FacilityID"].ToString();
                                txtFacilityName.Text = Facilitys.GetFacilityNameById(row["FacilityID"].ToString());
                                txtRequestAmount.Text = row["RequestAmount"].ToString();
                                panel1.Enabled = true;
                                btnSave.Enabled = true;
                            }
                        }
                        else
                        {
                            panel1.Enabled = true;
                            btnSave.Enabled = true;
                        }
                    }

                    btnSearch.Enabled = true;
                }
                catch (Exception ex)
                {
                    btnSearch.Enabled = true;
                }
            }
        }

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

        private void btnFacilitysList_Click(object sender, EventArgs e)
        {
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
    }
}
