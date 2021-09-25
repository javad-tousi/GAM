using GAM.Connections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GAM.Forms.Profile.Etebarat.Print
{
    public partial class dlgInstalmentsTable : DevExpress.XtraEditors.XtraForm
    {
        frmRequestPrint _ownerFrm;
        Dictionary<int, string> _conditionsList = new Dictionary<int, string>();

        public dlgInstalmentsTable(frmRequestPrint ownerFrm)
        {
            InitializeComponent();
            _ownerFrm = ownerFrm;
            XmlBuilder.XNodes xnodes3;

            if (_ownerFrm.cboRequestPlane.Text == "جاری")
            {
                n21.Value = 100;
                xnodes3 = XmlBuilder.GetXmlitems("/main/class/F216/item", OLEDB.GetResourceFile("References.xml"));
            }
            else
                xnodes3 = XmlBuilder.GetXmlitems("/main/class/F215/item", OLEDB.GetResourceFile("References.xml"));

            foreach (XmlBuilder.XNode node in xnodes3)
                _conditionsList.Add(int.Parse(node.Attributes["id"]), node.Text);

            n21.Select();
        }

        private string type(string value, decimal a, decimal b, decimal c)
        {
            StringBuilder sb = new StringBuilder();
            if (Numeral.IsDecimal(c / 30))
            {
                if (a == 1 & b == 1 & c > 0)
                    sb.Append(string.Format(value, "پس از " + c + " روز مهلت به مدت " + b + " ماه"));
                else if (a == 1 & b > 1 & c > 0)
                    sb.Append(string.Format(value, " به مدت " + b + " ماه پس از " + c + " روز مهلت در اقساط مساوی ماهانه"));
                else if (a > 1 & b == 1 & c > 0)
                    sb.Append(string.Format(value, "پس از " + c + " روز مهلت به مدت " + a + " ماه راس"));
                else if (a > 1 & b > 1 & c > 0)
                    sb.Append(string.Format(value, "پس از " + c + " روز مهلت در " + b + " قسط " + a + " ماهه"));
                else
                    sb.Append(value + "..........");

                return sb.ToString();

            }
            else
            {
                if (a == 1 & b == 1 & c == 0)
                    sb.Append(string.Format(value, " به مدت " + b + " ماه"));
                else if (a == 1 & b == 1 & c > 0)
                    sb.Append(string.Format(value, "پس از " + c / 30 + " ماه مهلت به مدت " + b + " ماه"));
                else if (a == 1 & b > 1 & c == 0)
                    sb.Append(string.Format(value, " به مدت " + b + " ماه در اقساط مساوی ماهانه"));
                else if (a == 1 & b > 1 & c > 0)
                    sb.Append(string.Format(value, " به مدت " + (b + (c / 30)) + " ماه پس از " + c / 30 + " ماه مهلت در اقساط مساوی ماهانه"));
                else if (a > 1 & b == 1 & c == 0)
                    sb.Append(string.Format(value, " به مدت " + a + " ماه راس"));
                else if (a > 1 & b == 1 & c > 0)
                    sb.Append(string.Format(value, "پس از " + c / 30 + " ماه مهلت به مدت " + a + " ماه راس"));
                else if (a > 1 & b > 1 & c == 0)
                    sb.Append(string.Format(value, "به مدت " + a * b + " ماه در " + b + " قسط " + a + " ماهه"));
                else if (a > 1 & b > 1 & c > 0)
                    sb.Append(string.Format(value, "به مدت " + ((a * b) + (c / 30)) + " ماه پس از " + c / 30 + " ماه مهلت در " + b + " قسط " + a + " ماهه"));
                else
                    sb.Append(value + "..........");

                return sb.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (n21.Value == 0)
                    DevExpress.XtraEditors.XtraMessageBox.Show("درصد پیش پرداخت را کنترل کنید!", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                StringBuilder sb = new StringBuilder();
                int row = 1;

                if (_ownerFrm.cboRequestPlane.Text == "جاری")
                {
                    sb.AppendLine(string.Format(_conditionsList[10], _ownerFrm.lblBranchName.Text));
                    sb.AppendLine(string.Format(_conditionsList[11], _ownerFrm.txtCustomerName.Text));
                    sb.AppendLine(string.Format(_conditionsList[12], "پیشنهاد شماره " + _ownerFrm.txtRequestId.Text.Substring(_ownerFrm.txtRequestId.Text.Length - 2) + "/" + _ownerFrm.txtRequestId.Text.Substring(0, _ownerFrm.txtRequestId.Text.Length - 2), PersianDate.Now.ToStandard(true), PersianDate.Now.ToStandard(true), _ownerFrm.cboRequestPlane.Text));

                    if (n21.Value == 100)
                        sb.AppendLine(row + "-" + _conditionsList[13] + " " + _conditionsList[14]);
                    else
                    {
                        sb.AppendLine(row + "-" + _conditionsList[13] + " بعلاوه " + (100 - n21.Value) + "%" + " از اصل بدهی " + _conditionsList[14]);
                    }

                    if (n6.Value > 0 & n7.Value > 0)
                    {
                        ++row;

                        sb.Append(row + "-" + type(_conditionsList[15], n6.Value, n7.Value, n8.Value));

                        if (n5.Value > 0)
                        {
                            sb.AppendLine(string.Format(" " + _conditionsList[16], n5.Value));
                        }
                        else
                            sb.AppendLine("");
                    }

                    if (n14.Value > 0 & n15.Value > 0)
                    {
                        ++row;
                        if (n13.Value > 0)
                            sb.Append(string.Format(row + "-" + _conditionsList[17], n13.Value));
                        else
                            sb.Append(row + "-");

                        sb.AppendLine(" " + type(_conditionsList[18], n14.Value, n15.Value, n16.Value));
                    }

                    if (n10.Value > 0 & n11.Value > 0)
                    {
                        ++row;
                        sb.Append(row + "-");

                        sb.Append(type(_conditionsList[19], n10.Value, n11.Value, n12.Value));

                        if (n9.Value > 0)
                            sb.AppendLine(string.Format(" " + _conditionsList[20], n9.Value));
                        else
                            sb.AppendLine("");
                    }

                    if (n18.Value > 0 & n19.Value > 0)
                    {
                        ++row;
                        sb.Append(row + "-");

                        sb.Append(type(_conditionsList[21], n18.Value, n19.Value, n20.Value));

                        if (n17.Value > 0)
                            sb.AppendLine(string.Format(" " + _conditionsList[22], n17.Value));
                        else
                            sb.AppendLine("");
                    }

                    if (n5.Value > 0 & n13.Value == 0)
                    {
                        ++row;
                        sb.AppendLine(row + "-" + _conditionsList[25]);
                    }

                    if (n5.Value > 0 & n13.Value > 0)
                    {
                        ++row;
                        sb.AppendLine(row + "-" + _conditionsList[26]);
                    }

                    ++row;
                    sb.AppendLine(row + "-" + _conditionsList[28]);
                    sb.AppendLine("کمیته اعتباری مدیریت شعب استان خراسان رضوی");
                }
                else
                {
                    sb.AppendLine(string.Format(_conditionsList[10], _ownerFrm.lblBranchName.Text));
                    sb.AppendLine(string.Format(_conditionsList[11], _ownerFrm.txtCustomerName.Text));
                    sb.AppendLine(string.Format(_conditionsList[12], "پیشنهاد شماره " + _ownerFrm.txtRequestId.Text.Substring(_ownerFrm.txtRequestId.Text.Length - 2) + "/" + _ownerFrm.txtRequestId.Text.Substring(0, _ownerFrm.txtRequestId.Text.Length - 2), PersianDate.Now.ToStandard(true), PersianDate.Now.ToStandard(true), _ownerFrm.cboRequestPlane.Text));

                    sb.Append(string.Format(row + "-" + _conditionsList[13], 100 - n21.Value));//درصد بدهی
                    if (n14.Value == 0 & n15.Value == 0)
                        sb.AppendLine(_conditionsList[14]);
                    else
                        sb.AppendLine("");

                    if (n6.Value > 0 & n7.Value > 0)
                    {
                        ++row;

                        sb.Append(row + "-" + type(_conditionsList[15], n6.Value, n7.Value, n8.Value));

                        if (n5.Value > 0)
                            sb.AppendLine(string.Format(" " + _conditionsList[16], n5.Value));
                        else
                            sb.AppendLine("");
                    }

                    if (n14.Value > 0 & n15.Value > 0)
                    {
                        ++row;
                        if (n13.Value > 0)
                            sb.Append(string.Format(row + "-" + _conditionsList[17], n13.Value));
                        else
                            sb.Append(row + "-");

                        sb.AppendLine(" " + type(_conditionsList[18], n14.Value, n15.Value, n16.Value));
                    }

                    if (n14.Value == 0 & n15.Value == 0 & n16.Value > 0)//حالت خاص
                    {
                        ++row;
                        sb.Append(row + "-" + string.Format(_conditionsList[21], ""));
                        if (n13.Value > 0)
                            sb.AppendLine(" " + string.Format(_conditionsList[22], n13.Value));
                        else
                            sb.AppendLine("");
                    }

                    if (n10.Value > 0 & n11.Value > 0)
                    {
                        ++row;
                        sb.Append(row + "-");

                        sb.Append(type(_conditionsList[19], n10.Value, n11.Value, n12.Value));

                        if (n9.Value > 0)
                            sb.AppendLine(string.Format(" " + _conditionsList[20], n9.Value));
                        else
                            sb.AppendLine("");
                    }

                    if (n18.Value > 0 & n19.Value > 0)
                    {
                        ++row;
                        sb.Append(row + "-");

                        sb.Append(type(_conditionsList[21], n18.Value, n19.Value, n20.Value));

                        if (n17.Value > 0)
                            sb.AppendLine(string.Format(" " + _conditionsList[22], n17.Value));
                        else
                            sb.AppendLine("");
                    }

                    if (n13.Value > 0 & n5.Value == 0)
                    {
                        ++row;
                        sb.AppendLine(row + "-" + _conditionsList[24]);
                    }

                    if (n5.Value > 0 & n13.Value == 0)
                    {
                        ++row;
                        sb.AppendLine(row + "-" + _conditionsList[25]);
                    }

                    if (n5.Value > 0 & n13.Value > 0)
                    {
                        ++row;
                        sb.AppendLine(row + "-" + _conditionsList[26]);
                    }

                    ++row;
                    sb.AppendLine(row + "-" + _conditionsList[27]);
                    ++row;
                    sb.AppendLine(row + "-" + _conditionsList[28]);
                    ++row;
                    sb.AppendLine(row + "-" + _conditionsList[29]);
                    sb.AppendLine("کمیته تعیین تکلیف مطالبات مدیریت شعب استان خراسان رضوی");
                }
                _ownerFrm.txtConditions.Clear();
                _ownerFrm.txtConditions.Text = sb.ToString();
                this.Close();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NextControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}
