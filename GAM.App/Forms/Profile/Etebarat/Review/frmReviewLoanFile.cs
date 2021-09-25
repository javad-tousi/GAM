using DevExpress.XtraEditors;
using GAM.Dialogs;
using GAM.Modules;
using GAM.Forms.Profile.Etebarat.Library;
using GAM.Forms.Information.Library;
using GAM.Forms.Settings.Library;
using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GAM.Connections;
using GAM.Forms.Profile.Etebarat.MyFiles;
using Stimulsoft.Report;


namespace GAM.Forms.Profile.Etebarat.Review
{
    public partial class frmReviewLoanFile : DevExpress.XtraEditors.XtraForm
    {
        public DataTable TableRequests;
        public int ID;
        public int ReferralDate;
        public int DateEnd;
        private bool _readOnly;

        public frmReviewLoanFile()
        {
            InitializeComponent();
            this.TableRequests = GetRequestsTable();
            btnAddNewRequest.Enabled = true;
        }

        public frmReviewLoanFile(DataRow row, bool readOnly)
        {
            InitializeComponent();
            _readOnly = readOnly;

            this.TableRequests = GetRequestsTable();

            if (readOnly)
            {
                btnPrint.Enabled = true;
                btnOpenWord.Enabled = true;
            }
            else 
            {
                EnablePanels();
            }

            if (Numeral.IsNumber(row["ReferralDate"].ToString()))
                this.ReferralDate = int.Parse(row["ReferralDate"].ToString());
            if (Numeral.IsNumber(row["DateEnd"].ToString()))
                this.DateEnd = int.Parse(row["DateEnd"].ToString());

            txtReviewDate.Text = row["ModifiedDate"].ToString();
            txtReviewNo.Text = ChkSum.GetFull(row["ID"].ToString());
            Branches.BranchInfo bi = Branches.GetBranchById(row["BranchID"].ToString(), true);
            txtDomainName.Text = bi.Domain.DomainName;
            txtBranchID.Text = bi.BranchId;
            txtBranchName.Text = bi.BranchName;
            txtBranchDegree.Text = bi.BranchDegree;

            txtCustomerId.Text = row["CustomerID"].ToString();
            txtCustomerName.Text = row["CustomerName"].ToString();
            txtPersonalityType.Text = row["PersonalityType"].ToString();
            Startup(row, true);
            SumTextValues();
        }

        private void btnAddRequest_Click(object sender, EventArgs e)
        {
            dlgAddRequest dlg = new dlgAddRequest(this, "", "", true);
            dlg.ShowDialog();
            btnPrint.Enabled = false;
            btnOpenWord.Enabled = false;
        }

        #region Events

        private void repositoryEditRow_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgPleaseWait), true, true, false);
            Application.DoEvents();
            DataRow r = viewRequests.GetDataRow(viewRequests.FocusedRowHandle);
            DataTable dt = RequestManager.GetRequestById(long.Parse(r["RequestID"].ToString()));
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                dlgAddRequest dlg = new dlgAddRequest(this, viewRequests.GetDataRow(viewRequests.FocusedRowHandle)["RequestID"].ToString(), "", false);
                dlg.ShowDialog();
                gridRequests.DataSource = this.TableRequests;
            }
        }

        private void repositorybtnDeleteRow_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           DataRow row = viewRequests.GetDataRow(viewRequests.FocusedRowHandle);
           if (row != null)
           {
               try
               {
                  bool res = ReviewReportManager.DeleteReviewNo(row["RequestSerial"].ToString());
                  if (res)
                  {
                      viewRequests.DeleteRow(viewRequests.FocusedRowHandle);

                      this.TableRequests = gridRequests.DataSource as DataTable;
                      if (this.TableRequests.Rows.Count == 0)
                      {
                          txtCustomerId.ResetText();
                          txtCustomerName.ResetText();
                          txtPersonalityType.ResetText();
                      }
                  }
               }
               catch(Exception ex)
               {
                   DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!_readOnly)
            {
                CheckAllFields();
                if (dataGridErrors.RowCount > 0)
                    return;
            }

            if (this.DateEnd == 0)
            {
                bool result = ReviewReportManager.UpdateDateEnd(ChkSum.DelCheck(txtReviewNo.Text), ReferralDate, Network.GetNowDateSerial());
                if (result)
                {
                    this.DateEnd = Network.GetNowDateSerial();
                    List<string> serials = new List<string>();
                    DataTable dt = gridRequests.DataSource as DataTable;
                    foreach (DataRow r in dt.Rows)
                        serials.Add(r["RequestSerial"].ToString());
                    dlgDataLogs.AddRequestLog(serials.ToArray(), 0, string.Format("بررسی پیشنهاد توسط {0} انجام شد", Users.GetUserNameWithSexByID(Users.MyUserID)));
                }
            }

            btnPrint.Enabled = false;
            btnOpenWord.Enabled = false;
            Application.DoEvents();
            StiOptions.Viewer.Windows.ShowEditorTool = false;
            StiOptions.Viewer.Windows.ShowBookmarksPanel = false;
            StiOptions.Viewer.Windows.ShowFindTool = false;
            StiOptions.Viewer.Windows.ShowSendEMailButton = false;

            StiReport report = new StiReport();
            report.Load(Application.StartupPath + "\\report3.mrt");
            
            (report.GetComponentByName("DoucumentDate") as Stimulsoft.Report.Components.StiText).Text = txtReviewDate.Text;
            (report.GetComponentByName("DoucumentSerial") as Stimulsoft.Report.Components.StiText).Text = txtReviewNo.Text;
            (report.GetComponentByName("CustomerId") as Stimulsoft.Report.Components.StiText).Text = txtCustomerId.Text;

            (report.GetComponentByName("DomainName") as Stimulsoft.Report.Components.StiText).Text = txtDomainName.Text;
            (report.GetComponentByName("BranchName") as Stimulsoft.Report.Components.StiText).Text = txtBranchName.Text + " (" + txtBranchID.Text + ")";
            (report.GetComponentByName("BranchDegree") as Stimulsoft.Report.Components.StiText).Text = txtBranchDegree.Text;

            (report.GetComponentByName("CustomerName") as Stimulsoft.Report.Components.StiText).Text = txtCustomerName.Text;
            if (txtModirAmel.Text.Length > 0)
                (report.GetComponentByName("ModirAmel") as Stimulsoft.Report.Components.StiText).Text = "مدیرعامل: " + txtModirAmel.Text.Trim();
            (report.GetComponentByName("NoeFaaliyat") as Stimulsoft.Report.Components.StiText).Text = txtNoeFaaliyat.Text.Trim();
           (report.GetComponentByName("BakhshFaaliyat") as Stimulsoft.Report.Components.StiText).Text = GetCheckedComboBoxEdit(cboBakhshFaaliyat);
            (report.GetComponentByName("NoeMojavezShoghli") as Stimulsoft.Report.Components.StiText).Text = GetCheckedComboBoxEdit(cboNoeMojavezShoghli);
            (report.GetComponentByName("NoeMalekiyat") as Stimulsoft.Report.Components.StiText).Text = GetCheckedComboBoxEdit(cboNoeMalekiyat);

            if (txtTarikhGozaresh.Text != "____/__/__")
                (report.GetComponentByName("TarikhGozaresh") as Stimulsoft.Report.Components.StiText).Text = txtTarikhGozaresh.Text;
            if (txtTarikhEtelaatEtebari.Text != "____/__/__")
                (report.GetComponentByName("TarikhEtelaatEtebari") as Stimulsoft.Report.Components.StiText).Text = txtTarikhEtelaatEtebari.Text;
            (report.GetComponentByName("SarmayeSabti") as Stimulsoft.Report.Components.StiText).Text = txtSarmayeSabti.Text;

            if (txtTarikhHesabrasi.Text != "____/__/__")
                (report.GetComponentByName("TarikhHesabrasi") as Stimulsoft.Report.Components.StiText).Text = txtTarikhHesabrasi.Text;
            if (txtTarikhSoratMali.Text != "____/__/__")
                (report.GetComponentByName("TarikhSoratMali") as Stimulsoft.Report.Components.StiText).Text = txtTarikhSoratMali.Text;
            (report.GetComponentByName("MojodiKala") as Stimulsoft.Report.Components.StiText).Text = txtMojodiKala.Text;
            (report.GetComponentByName("ForoshDarSoratMali") as Stimulsoft.Report.Components.StiText).Text = txtForoshDarSoratMali.Text;
            double soodYaZiyanJari = Numeral.AnyToDouble(txtSoodYaZiyanJari.Text);
            if (soodYaZiyanJari < 0)
                (report.GetComponentByName("SoodYaZiyanJari") as Stimulsoft.Report.Components.StiText).Text = "(" + Math.Abs(soodYaZiyanJari).ToString("n0") + ")";
            else
                (report.GetComponentByName("SoodYaZiyanJari") as Stimulsoft.Report.Components.StiText).Text = txtSoodYaZiyanJari.Text;

            double soodYaZiyanAnbashteh = Numeral.AnyToDouble(txtSoodYaZiyanAnbashteh.Text);
            if (soodYaZiyanAnbashteh < 0)
                (report.GetComponentByName("SoodYaZiyanAnbashteh") as Stimulsoft.Report.Components.StiText).Text = "(" + Math.Abs(soodYaZiyanAnbashteh).ToString("n0") + ")";
            else
                (report.GetComponentByName("SoodYaZiyanAnbashteh") as Stimulsoft.Report.Components.StiText).Text = txtSoodYaZiyanAnbashteh.Text;

            (report.GetComponentByName("BedehiKotahmodat") as Stimulsoft.Report.Components.StiText).Text = txtBedehiKotahmodat.Text;
            (report.GetComponentByName("BedehiBolandmodat") as Stimulsoft.Report.Components.StiText).Text = txtBedehiBolandmodat.Text;
            (report.GetComponentByName("NesbatJari") as Stimulsoft.Report.Components.StiText).Text = txtNesbatJari.Text;
            (report.GetComponentByName("NesbatMalekaneh") as Stimulsoft.Report.Components.StiText).Text = txtNesbatMalekaneh.Text;
            if (txtTarikhTaraz.Text != "____/__/__")
                (report.GetComponentByName("TarikhTaraz") as Stimulsoft.Report.Components.StiText).Text = txtTarikhTaraz.Text;

            (report.GetComponentByName("ForoshDarTaraz") as Stimulsoft.Report.Components.StiText).Text = txtForoshDarTaraz.Text;

            (report.GetComponentByName("EstelamMellat1") as Stimulsoft.Report.Components.StiText).Text = txtEstelamMellat1.Text;
            (report.GetComponentByName("EstelamMellat2") as Stimulsoft.Report.Components.StiText).Text = txtEstelamMellat2.Text;
            (report.GetComponentByName("EstelamSayer1") as Stimulsoft.Report.Components.StiText).Text = txtEstelamSayer1.Text;
            (report.GetComponentByName("EstelamSayer2") as Stimulsoft.Report.Components.StiText).Text = txtEstelamSayer2.Text;
            (report.GetComponentByName("SumEstelam1") as Stimulsoft.Report.Components.StiText).Text = (Numeral.AnyToDouble(txtEstelamMellat1.Text) + Numeral.AnyToDouble(txtEstelamSayer1.Text)).ToString("n0");
            (report.GetComponentByName("SumEstelam2") as Stimulsoft.Report.Components.StiText).Text = (Numeral.AnyToDouble(txtEstelamMellat2.Text) + Numeral.AnyToDouble(txtEstelamSayer2.Text)).ToString("n0");
           
            (report.GetComponentByName("EstelamMostaghim1") as Stimulsoft.Report.Components.StiText).Text = txtEstelamMostaghim1.Text;
            (report.GetComponentByName("EstelamMostaghim2") as Stimulsoft.Report.Components.StiText).Text = txtEstelamMostaghim2.Text;
            (report.GetComponentByName("EstelamGhyreMostaghim1") as Stimulsoft.Report.Components.StiText).Text = txtEstelamGhyreMostaghim1.Text;
            (report.GetComponentByName("EstelamGhyreMostaghim2") as Stimulsoft.Report.Components.StiText).Text = txtEstelamGhyreMostaghim2.Text;
            (report.GetComponentByName("SumMostaghim") as Stimulsoft.Report.Components.StiText).Text = (Numeral.AnyToDouble(txtEstelamMostaghim1.Text) + Numeral.AnyToDouble(txtEstelamGhyreMostaghim1.Text)).ToString("n0");
            (report.GetComponentByName("SumGhyreMostaghim") as Stimulsoft.Report.Components.StiText).Text = (Numeral.AnyToDouble(txtEstelamMostaghim2.Text) + Numeral.AnyToDouble(txtEstelamGhyreMostaghim2.Text)).ToString("n0");

            (report.GetComponentByName("RotbehIranian") as Stimulsoft.Report.Components.StiText).Text = GetCheckedComboBoxEdit(cboRotbehIranian);
            (report.GetComponentByName("TasviyehGharardad") as Stimulsoft.Report.Components.StiText).Text = txtTasviyehGharardad.Text + " فقره";

            (report.GetComponentByName("BedehiPishnehad1") as Stimulsoft.Report.Components.StiText).Text = txtBedehiPishnehadTashilat.Text;
            (report.GetComponentByName("BedehiPishnehad2") as Stimulsoft.Report.Components.StiText).Text = txtBedehiPishnehadTaahodat.Text;

            (report.GetComponentByName("MosavabeDarrah1") as Stimulsoft.Report.Components.StiText).Text = txtMosavabeDarrahTashilat.Text;
            (report.GetComponentByName("MosavabeDarrah2") as Stimulsoft.Report.Components.StiText).Text = txtMosavabeDarrahTaahodat.Text;

            double sumSaghfTashilat = Numeral.AnyToDouble(txtSaghfBedehiHad1.Text) + Numeral.AnyToDouble(txtSaghfBedehiSaghf1.Text) + Numeral.AnyToDouble(txtSaghfBedehiMoredi1.Text);
            double sumSaghfTaahodat = Numeral.AnyToDouble(txtSaghfBedehiHad2.Text) + Numeral.AnyToDouble(txtSaghfBedehiSaghf2.Text) + Numeral.AnyToDouble(txtSaghfBedehiMoredi2.Text);
            (report.GetComponentByName("SumSaghfTashilat") as Stimulsoft.Report.Components.StiText).Text = sumSaghfTashilat.ToString("n0");
            (report.GetComponentByName("SumSaghfTaahodat") as Stimulsoft.Report.Components.StiText).Text = sumSaghfTaahodat.ToString("n0");

            double sumAfzayeshfTashilat = (Numeral.AnyToDouble(txtAfzayeshTashilat.Text) - Numeral.AnyToDouble(txtKaheshTashilat.Text));
            double sumAfzayeshfTaahodat = (Numeral.AnyToDouble(txtAfzayeshTaahodat.Text) - Numeral.AnyToDouble(txtKaheshTaahodat.Text));
            (report.GetComponentByName("AfzayeshTashilat") as Stimulsoft.Report.Components.StiText).Text = sumAfzayeshfTashilat.ToString("n0");
            (report.GetComponentByName("AfzayeshTaahodat") as Stimulsoft.Report.Components.StiText).Text = sumAfzayeshfTaahodat.ToString("n0");

            (report.GetComponentByName("TasviyehTashilat") as Stimulsoft.Report.Components.StiText).Text = txtTasviyehTashilat.Text;
            (report.GetComponentByName("TasviyehTaahodat") as Stimulsoft.Report.Components.StiText).Text = txtTasviyehTaahodat.Text;

            (report.GetComponentByName("JariBestankar1") as Stimulsoft.Report.Components.StiText).Text = txtJariBestankar1.Text;
            (report.GetComponentByName("JariBestankar2") as Stimulsoft.Report.Components.StiText).Text = txtJariBestankar2.Text;
            (report.GetComponentByName("JariMoadel1") as Stimulsoft.Report.Components.StiText).Text = txtJariMoadel1.Text;
            (report.GetComponentByName("JariMoadel2") as Stimulsoft.Report.Components.StiText).Text = txtJariMoadel2.Text;
            (report.GetComponentByName("KotahmodatBestankar1") as Stimulsoft.Report.Components.StiText).Text = txtKotahmodatBestankar1.Text;
            (report.GetComponentByName("KotahmodatBestankar2") as Stimulsoft.Report.Components.StiText).Text = txtKotahmodatBestankar2.Text;
            (report.GetComponentByName("KotahmodatMoadel1") as Stimulsoft.Report.Components.StiText).Text = txtKotahmodatMoadel1.Text;
            (report.GetComponentByName("KotahmodatMoadel2") as Stimulsoft.Report.Components.StiText).Text = txtKotahmodatMoadel2.Text;
            (report.GetComponentByName("GharzBestankar1") as Stimulsoft.Report.Components.StiText).Text = txtGharzolhasanehBestankar1.Text;
            (report.GetComponentByName("GharzBestankar2") as Stimulsoft.Report.Components.StiText).Text = txtGharzolhasanehBestankar2.Text;
            (report.GetComponentByName("GharzMoadel1") as Stimulsoft.Report.Components.StiText).Text = txtGharzolhasanehMoadel1.Text;
            (report.GetComponentByName("GharzMoadel2") as Stimulsoft.Report.Components.StiText).Text = txtGharzolhasanehMoadel2.Text;

            (report.GetComponentByName("SumBestankar1") as Stimulsoft.Report.Components.StiText).Text = (Numeral.AnyToDouble(txtJariBestankar1.Text) + Numeral.AnyToDouble(txtKotahmodatBestankar1.Text) + Numeral.AnyToDouble(txtGharzolhasanehBestankar1.Text)).ToString("n0");
            (report.GetComponentByName("SumBestankar2") as Stimulsoft.Report.Components.StiText).Text = (Numeral.AnyToDouble(txtJariBestankar2.Text) + Numeral.AnyToDouble(txtKotahmodatBestankar2.Text) + Numeral.AnyToDouble(txtGharzolhasanehBestankar2.Text)).ToString("n0");
            (report.GetComponentByName("SumMoadel1") as Stimulsoft.Report.Components.StiText).Text = (Numeral.AnyToDouble(txtJariMoadel1.Text) + Numeral.AnyToDouble(txtKotahmodatMoadel1.Text) + Numeral.AnyToDouble(txtGharzolhasanehMoadel1.Text)).ToString("n0");
            (report.GetComponentByName("SumMoadel2") as Stimulsoft.Report.Components.StiText).Text = (Numeral.AnyToDouble(txtJariMoadel2.Text) + Numeral.AnyToDouble(txtKotahmodatMoadel2.Text) + Numeral.AnyToDouble(txtGharzolhasanehMoadel2.Text)).ToString("n0");

            (report.GetComponentByName("JariOldMoadel") as Stimulsoft.Report.Components.StiText).Text = txtJariOldMoadel.Text;
            (report.GetComponentByName("KotahmodatOldMoadel") as Stimulsoft.Report.Components.StiText).Text = txtKotahmodatOldMoadel.Text;
            (report.GetComponentByName("GharzOldMoadel") as Stimulsoft.Report.Components.StiText).Text = txtGharzolhasanehOldMoadel.Text;
            (report.GetComponentByName("SumOldMoadel") as Stimulsoft.Report.Components.StiText).Text = (Numeral.AnyToDouble(txtJariOldMoadel.Text) + Numeral.AnyToDouble(txtKotahmodatOldMoadel.Text) + Numeral.AnyToDouble(txtGharzolhasanehOldMoadel.Text)).ToString("n0");

            StringBuilder sb = new StringBuilder();
            int counter2 = 0;
            if (cboAsk1.Text == "بلی")
                sb.Append(++counter2 + "-" + "طبق استعلام بانک مرکزی ج.ا.ا مشتری دارای مطالبات معوق می باشد" + " ");
            if (cboAsk2.Text == "بلی")
                sb.Append(++counter2 + "-" + "متقاضی مشتری جدید بانک می باشد" + " ");
            if (cboAsk3.Text == "خیر")
                sb.Append(++counter2 + "-" + "متقاضی فاقد اموال غیر منقول می باشد" + " ");
            if (cboAsk4.Text == "خیر")
                sb.Append(++counter2 + "-" + "در اساسنامه شرکت مجوز اخذ تسهیلات قید نشده است" + " ");
            if (cboAsk6.Text == "بلی")
                sb.Append(++counter2 + "-" + "شرکت مشمول ماده 141 قانون تجارت می باشد" + " ");
            if (cboAsk7.Text == "بلی")
                sb.Append(++counter2 + "-" + "مشتری دارای بدهی غیرجاری تقسیط شده می باشد" + " ");
            if (cboAsk8.Text == "خیر")
                sb.Append(++counter2 + "-" + "نظریه موافق حوزه قید نگردیده است" + " ");
            if (cboAsk9.Text == "بلی")
                sb.Append(++counter2 + "-" + "طبق پردازش 4915 مشتری دارای جریمه می باشد");
            if (cboAsk10.Text == "بلی")
                sb.Append(++counter2 + "-" + "مشتری دارای چک برگشتی می باشد" + " ");
            if (cboAsk11.Text == "خیر")
                sb.Append(++counter2 + "-" + "مجوز شغلی متقاضی فاقد اعتبار می باشد" + " ");
            if (cboAsk12.Text == "بلی")
                sb.Append(++counter2 + "-" + "شرکت دارای قرارداد حسابرسی می باشد" + " ");
            if (cboAsk12.Text == "خیر")
                sb.Append(++counter2 + "-" + "شرکت فاقد قرارداد حسابرسی می باشد" + " ");
            if (cboAsk13.Text == "بلی")
                sb.Append(++counter2 + "-" + "متقاضی دارای وثیقه ملکی شخص ثالث در رهن بانک می باشد" + " ");
            if (cboAsk14.Text == "خیر")
                sb.Append(++counter2 + "-" + "متقاضی شرایط تخصیص حد اعتباری را ندارد" + " ");
            if (cboAsk15.Text == "بلی")
                sb.Append(++counter2 + "-" + "متقاضی دارای تعهدات ارزی ایفاء نشده سررسید شده می باشد" + " ");
            if (cboAsk15.Text == "خیر")
                sb.Append(++counter2 + "-" + "متقاضی فاقد تعهدات ارزی ایفاء نشده سررسید شده می باشد" + " ");
            if (cboAsk16.Text == "خیر")
                sb.Append(++counter2 + "-" + "متقاضی فاقد دستگاه کارتخوان می باشد" + " ");
            if (PersianDateTime.IsValidDate(txtTarikhEtelaatEtebari.Text) && (PersianDateTime.Now - PersianDateTime.Parse(txtTarikhEtelaatEtebari.Text, "/")).Days > 365)
                sb.Append(++counter2 + "-" + "تاریخ اطلاعات اعتباری بیش از یک سال می باشد" + " ");

            if (PersianDateTime.IsValidDate(txtTarikhGozaresh.Text) && (PersianDateTime.Now - PersianDateTime.Parse(txtTarikhGozaresh.Text, "/")).Days > 365)
                sb.Append(++counter2 + "-" + "تاریخ گزارش کارشناسی بیش از یک سال می باشد" + " ");

            if (cboVazeyatSanad.Text.Length > 0 & cboVazeyatSanad.Text != "آزاد")
            {
                sb.Append(++counter2 + "-" + "وضعیت سند متقاضی " + cboVazeyatSanad.Text + " می باشد" + " ");
            }
            if (Numeral.AnyToDouble(txtVarizTashilat.Text) > 0)
                sb.Append(++counter2 + "-" + "پیشنهاد حاضر از محل واریز تسهیلات به مبلغ " + txtVarizTashilat.Text + " میلیون ریال می باشد" + " ");
            if (Numeral.AnyToDouble(txtVarizTaahodat.Text) > 0)
                sb.Append(++counter2 + "-" + "پیشنهاد حاضر از محل واریز تعهدات به مبلغ " + txtVarizTaahodat.Text + " میلیون ریال می باشد" + " ");
            if (Numeral.AnyToDouble(txtSepordeh.Text) > 0)
                sb.Append(++counter2 + "-" + "مشتری دارای سپرده بلندمدت به مبلغ " + txtSepordeh.Text + " میلیون ریال می باشد" + " ");
            if (txtSharayetAkharinMosavabeh.Text.Trim().Length > 0)
                sb.Append(++counter2 + "-" + "شرایط مندرج در مصوبه قبلی > " + txtSharayetAkharinMosavabeh.Text + " ");

            (report.GetComponentByName("Tozihat") as Stimulsoft.Report.Components.StiText).Text = sb.ToString();
            (report.GetComponentByName("NazariyeKarshenas") as Stimulsoft.Report.Components.StiText).Text = txtNazariyeKarshenas.Text.Trim();

            (report.GetComponentByName("Emza") as Stimulsoft.Report.Components.StiImage).Image = GAM.Properties.Resources.bmlogo_mainback;
            (report.GetComponentByName("ExpertName") as Stimulsoft.Report.Components.StiText).Text = Users.GetUserNameById(Users.MyUserID);
          
            DataTable tblRequest = gridRequests.DataSource as DataTable;
            report.RegData("DataSource", tblRequest);

            report.Compile();
            report.Render();
            report.Show();

            if (_readOnly)
            {
                btnPrint.Enabled = true;
                btnOpenWord.Enabled = true;
            }
        }

        private void NextControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void cboRotbehIranian_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            txtRisk.Text = GetRisk(GetCheckedComboBoxEdit(cboRotbehIranian));
        }

        private void cboRotbehIranian_TextChanged(object sender, EventArgs e)
        {
            txtRisk.Text = GetRisk(GetCheckedComboBoxEdit(cboRotbehIranian));
        }

        private void btnAddFx_Click(object sender, EventArgs e)
        {
            dlgAddFx dlg = new dlgAddFx();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtNazariyeKarshenas.Text = txtNazariyeKarshenas.Text.Insert(txtNazariyeKarshenas.SelectionStart, " " + dlg.Formula);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNazariyeKarshenas.Clear();
        }

        private void viewRequests_DataSourceChanged(object sender, EventArgs e)
        {
            cboAsk14.Enabled = false;
            cboAsk15.Enabled = false;
            cboAsk16.Enabled = false;
            cboAsk14.Text = "";
            cboAsk15.Text = "";
            cboAsk16.Text = "";

            DataTable dt = gridRequests.DataSource as DataTable;
            foreach (DataRow r in dt.Rows)
            {
                if (r["RequestType"].ToString() == "حد اعتباری")
                {
                    cboAsk14.Enabled = true;
                }
            }
            foreach (DataRow r in dt.Rows)
            {
                if (r.Table.Columns.Contains("FacilityId"))
                {
                    if (r["FacilityID"].ToString() == "10" |
                        r["FacilityID"].ToString() == "11" |
                        r["FacilityID"].ToString() == "12" |
                        r["FacilityID"].ToString() == "13")
                    {
                        cboAsk15.Enabled = true;
                    }
                }
            }
            foreach (DataRow r in dt.Rows)
            {
                if (r.Table.Columns.Contains("FacilityId"))
                {
                    if (r["FacilityID"].ToString() == "42")
                    {
                        cboAsk16.Enabled = true;
                    }
                }
            }
        }

        private void frmAddNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_readOnly)
            {
                DevExpress.XtraEditors.XtraMessageBoxArgs args = new DevExpress.XtraEditors.XtraMessageBoxArgs();
                args.Icon = System.Drawing.SystemIcons.Warning;
                args.Text = "آیا از خروج فرم اطمینان کامل حاصل دارید؟";
                args.Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No };
                DialogResult dlgRes = DevExpress.XtraEditors.XtraMessageBox.Show(args);
                if (dlgRes != System.Windows.Forms.DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnShowLastInfo_Click(object sender, EventArgs e)
        {
            if (txtCustomerId.TextLength > 0)
            {
                DataTable tbl = ReviewReportManager.GetReviewReportsByCustomerId(txtCustomerId.Text);
                dlgHistoryLog dlg = new dlgHistoryLog(tbl);
                dlg.ShowDialog();

                if (dlg.Data != null)
                {
                    txtModifiedDate.Text = dlg.Data["ModifiedDate"].ToString();
                    Startup(dlg.Data, false);
                    DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات جدید با موفقیت بارگذاری شد", "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("فیلد شماره مشتری خالی می باشد. لطفا ابتدا پبشنهادات شعبه را اضافه نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            SumTextValues();
        }

        #endregion

        #region Methods

        private void Startup(DataRow row, bool withtblRequests)
        {
            if (row != null)
            {
                if (withtblRequests)
                {
                    if (row["XmlRequests"].ToString().Length > 0)
                    {
                        gridRequests.Tag = row["XmlRequests"].ToString();
                        var tbl = UDF.GetXmlToDatatable(row["XmlRequests"].ToString());
                        if (tbl != null)
                        {
                            this.TableRequests = tbl;
                            gridRequests.DataSource = tbl;
                        }
                    }
                }

                txtModirAmel.Text = row["ModirAmel"].ToString();
                txtNoeFaaliyat.Text = row["NoeFaaliyat"].ToString();
                SetCheckedComboBoxEdit(cboBakhshFaaliyat, row["BakhshFaaliyat"].ToString());
                SetCheckedComboBoxEdit(cboNoeMojavezShoghli, row["NoeMojavezShoghli"].ToString());
                SetCheckedComboBoxEdit(cboNoeMalekiyat, row["NoeMalekiyat"].ToString());
                cboVazeyatSanad.Text = row["VazeyatSanad"].ToString();
                txtTarikhGozaresh.Text = row["TarikhGozaresh"].ToString();
                txtTarikhEtelaatEtebari.Text = row["TarikhEtelaatEtebari"].ToString();
                txtSarmayeSabti.Text = row["SarmayeSabti"].ToString();
                txtTarikhHesabrasi.Text = row["TarikhHesabrasi"].ToString();
                txtTarikhSoratMali.Text = row["TarikhSoratMali"].ToString();
                txtMojodiKala.Text = row["MojodiKala"].ToString();
                txtForoshDarSoratMali.Text = row["ForoshDarSoratMali"].ToString();
                txtSoodYaZiyanJari.Text = row["SoodYaZiyanJari"].ToString();
                txtSoodYaZiyanAnbashteh.Text = row["SoodYaZiyanAnbashteh"].ToString();
                txtBedehiKotahmodat.Text = row["BedehiKotahmodat"].ToString();
                txtBedehiBolandmodat.Text = row["BedehiBolandmodat"].ToString();
                txtNesbatJari.Text = row["NesbatJari"].ToString();
                txtNesbatMalekaneh.Text = row["NesbatMalekaneh"].ToString();
                txtTarikhTaraz.Text = row["TarikhTaraz"].ToString();
                txtForoshDarTaraz.Text = row["ForoshDarTaraz"].ToString();

                txtEstelamMellat1.Text = row["EstelamMellat1"].ToString();
                txtEstelamMellat2.Text = row["EstelamMellat2"].ToString();
                txtEstelamSayer1.Text = row["EstelamSayer1"].ToString();
                txtEstelamSayer2.Text = row["EstelamSayer2"].ToString();
                txtEstelamMostaghim1.Text = row["EstelamZinaf1"].ToString();
                txtEstelamMostaghim2.Text = row["EstelamZinaf2"].ToString();
                txtEstelamGhyreMostaghim1.Text = row["EstelamZinaf3"].ToString();
                txtEstelamGhyreMostaghim2.Text = row["EstelamZinaf4"].ToString();
                txtBedehiPishnehadTashilat.Text = row["BedehiPishnehad1"].ToString();
                txtBedehiPishnehadTaahodat.Text = row["BedehiPishnehad2"].ToString();
                txtMosavabeDarrahTashilat.Text = row["MosavabeDarrah1"].ToString();
                txtMosavabeDarrahTaahodat.Text = row["MosavabeDarrah2"].ToString();
                txtSaghfBedehiHad1.Text = row["SaghfBedehiHad1"].ToString();
                txtSaghfBedehiHad2.Text = row["SaghfBedehiHad2"].ToString();
                txtSaghfBedehiSaghf1.Text = row["SaghfBedehiSaghf1"].ToString();
                txtSaghfBedehiSaghf2.Text = row["SaghfBedehiSaghf2"].ToString();
                txtSaghfBedehiMoredi1.Text = row["SaghfBedehiMoredi1"].ToString();
                txtSaghfBedehiMoredi2.Text = row["SaghfBedehiMoredi2"].ToString();

                txtJariBestankar1.Text = row["JariBestankar1"].ToString();
                txtJariBestankar2.Text = row["JariBestankar2"].ToString();
                txtJariMoadel1.Text = row["JariMoadel1"].ToString();
                txtJariMoadel2.Text = row["JariMoadel2"].ToString();
                txtKotahmodatBestankar1.Text = row["KotahmodatBestankar1"].ToString();
                txtKotahmodatBestankar2.Text = row["KotahmodatBestankar2"].ToString();
                txtKotahmodatMoadel1.Text = row["KotahmodatMoadel1"].ToString();
                txtKotahmodatMoadel2.Text = row["KotahmodatMoadel2"].ToString();
                txtGharzolhasanehBestankar1.Text = row["GharzolhasanehBestankar1"].ToString();
                txtGharzolhasanehBestankar2.Text = row["GharzolhasanehBestankar2"].ToString();
                txtGharzolhasanehMoadel1.Text = row["GharzolhasanehMoadel1"].ToString();
                txtGharzolhasanehMoadel2.Text = row["GharzolhasanehMoadel2"].ToString();
                txtSepordeh.Text = row["Sepordeh"].ToString();

                txtJariOldMoadel.Text = row["JariOldMoadel"].ToString();
                txtKotahmodatOldMoadel.Text = row["KotahmodatOldMoadel"].ToString();
                txtGharzolhasanehOldMoadel.Text = row["GharzolhasanehOldMoadel"].ToString();

                SetCheckedComboBoxEdit(cboRotbehIranian, row["RotbehIranian"].ToString());
                txtTasviyehGharardad.Text = row["TasviyehGharardad"].ToString();

                txtTasviyehTashilat.Text = row["TasviyehTashilat"].ToString();
                txtTasviyehTaahodat.Text = row["TasviyehTaahodat"].ToString();
                txtAfzayeshTashilat.Text = row["AfzayeshTashilat"].ToString();
                txtAfzayeshTaahodat.Text = row["AfzayeshTaahodat"].ToString();
                txtKaheshTashilat.Text = row["KaheshTashilat"].ToString();
                txtKaheshTaahodat.Text = row["KaheshTaahodat"].ToString();
                txtVarizTashilat.Text = row["VarizTashilat"].ToString();
                txtVarizTaahodat.Text = row["VarizTaahodat"].ToString();

                cboAsk1.Text = row["Ask1"].ToString();
                cboAsk2.Text = row["Ask2"].ToString();
                cboAsk3.Text = row["Ask3"].ToString();
                cboAsk4.Text = row["Ask4"].ToString();
                cboAsk6.Text = row["Ask6"].ToString();
                cboAsk7.Text = row["Ask7"].ToString();
                cboAsk8.Text = row["Ask8"].ToString();
                cboAsk9.Text = row["Ask9"].ToString();
                cboAsk10.Text = row["Ask10"].ToString();
                cboAsk11.Text = row["Ask11"].ToString();
                cboAsk12.Text = row["Ask12"].ToString();
                cboAsk13.Text = row["Ask13"].ToString();
                txtSharayetAkharinMosavabeh.Text = row["SharayetAkharinMosavabeh"].ToString();
                txtNazariyeKarshenas.Text = row["NazariyeKarshenas"].ToString();
            }
        }

        public void EnablePanels() 
        {
            btnAddNewRequest.Enabled = true;
            grpRequestList.Enabled = true;
            grpCustomerInfo.Enabled = true;
            grp2.Enabled = true;
            grp3.Enabled = true;
            grp4.Enabled = true;
            grp5.Enabled = true;
            grp6.Enabled = true;
            grp7.Enabled = true;
            pnlFx.Enabled = true;
            txtSharayetAkharinMosavabeh.ReadOnly = false;
            txtNazariyeKarshenas.ReadOnly = false;
            btnSave.Enabled = true;
        }

        private void CheckAllFields()
        {
            dataGridErrors.Rows.Clear();
            if (viewRequests.RowCount == 0)
                dataGridErrors.Rows.Add("جدول پیشنهادات شعبه خالی می باشد");
            if (txtCustomerId.TextLength == 0)
                dataGridErrors.Rows.Add("فیلد شماره مشتری خالی است");
            if (txtCustomerName.TextLength == 0)
                dataGridErrors.Rows.Add("فیلد نام مشتری خالی است");
            if (txtNoeFaaliyat.TextLength == 0)
                dataGridErrors.Rows.Add("نوع فعالیت متقاضی مشخص نشده است");
            if (cboNoeMojavezShoghli.Text.Length == 0)
                dataGridErrors.Rows.Add("نوع مجوز شغلی مشخص نشده است");
            if (Numeral.ExtractDigits(txtTarikhEtelaatEtebari.Text).Length > 0 & (!PersianDateTime.IsValidDate(txtTarikhEtelaatEtebari.Text) | Numeral.AnyToInt32(Numeral.ExtractDigits(txtTarikhEtelaatEtebari.Text)) > PersianDateTime.Now.ToShortDateInt()))
                dataGridErrors.Rows.Add("تاریخ اطلاعات اعتباری اشتباه می باشد");
            if (Numeral.ExtractDigits(txtTarikhGozaresh.Text).Length > 0 & (!PersianDateTime.IsValidDate(txtTarikhGozaresh.Text) | Numeral.AnyToInt32(Numeral.ExtractDigits(txtTarikhGozaresh.Text)) > PersianDateTime.Now.ToShortDateInt()))
                dataGridErrors.Rows.Add("تاریخ گزارش کارشناسی اشتباه می باشد");
            if (Numeral.ExtractDigits(txtTarikhSoratMali.Text).Length > 0 & (!PersianDateTime.IsValidDate(txtTarikhSoratMali.Text) | Numeral.AnyToInt32(Numeral.ExtractDigits(txtTarikhSoratMali.Text)) > PersianDateTime.Now.ToShortDateInt()))
                dataGridErrors.Rows.Add("تاریخ صورت مالی اشتباه می باشد");
            if (Numeral.ExtractDigits(txtTarikhTaraz.Text).Length > 0 & (!PersianDateTime.IsValidDate(txtTarikhTaraz.Text) | Numeral.AnyToInt32(Numeral.ExtractDigits(txtTarikhTaraz.Text)) > PersianDateTime.Now.ToShortDateInt()))
                dataGridErrors.Rows.Add("تاریخ تراز آزمایشی اشتباه می باشد");
            if (Numeral.ExtractDigits(txtTarikhHesabrasi.Text).Length > 0 & (!PersianDateTime.IsValidDate(txtTarikhHesabrasi.Text) | Numeral.AnyToInt32(Numeral.ExtractDigits(txtTarikhHesabrasi.Text)) > PersianDateTime.Now.ToShortDateInt()))
                dataGridErrors.Rows.Add("تاریخ حسابرسی اشتباه می باشد");
            //////////////////////////////////////////

            if (cboAsk1.Enabled & cboAsk1.Text.Length == 0 |
                cboAsk2.Enabled & cboAsk2.Text.Length == 0 |
                cboAsk3.Enabled & cboAsk3.Text.Length == 0 |
                cboAsk4.Enabled & cboAsk4.Text.Length == 0 |
                cboAsk6.Enabled & cboAsk6.Text.Length == 0 |
                cboAsk7.Enabled & cboAsk7.Text.Length == 0 |
                cboAsk8.Enabled & cboAsk8.Text.Length == 0 |
                cboAsk9.Enabled & cboAsk9.Text.Length == 0 |
                cboAsk10.Enabled & cboAsk10.Text.Length == 0 |
                cboAsk11.Enabled & cboAsk11.Text.Length == 0 |
                cboAsk13.Enabled & cboAsk13.Text.Length == 0 |
                cboAsk14.Enabled & cboAsk14.Text.Length == 0 |
                cboAsk15.Enabled & cboAsk15.Text.Length == 0 |
                cboAsk16.Enabled & cboAsk16.Text.Length == 0)
                dataGridErrors.Rows.Add("برخی از سوالات اجباری پاسخ داده نشده است");
            if (txtPersonalityType.Text == "حقوقی")
            {
                if (txtModirAmel.Text.Length == 0)
                    dataGridErrors.Rows.Add("نام مدیر عامل مشخص نشده است");
                if (cboAsk4.Text.Length == 0 | cboAsk6.Text.Length == 0)
                    dataGridErrors.Rows.Add("برخی از سوالات اجباری بخش حقوقی پاسخ داده نشده است");
            }

            if (txtNazariyeKarshenas.Text.Length == 0)
                dataGridErrors.Rows.Add("نظریه کارشناس خالی می باشد");
            /////////////////////////////////////////
        }

        private string ReverseDate(string date)
        {
            if (PersianDateTime.IsValidDate(date))
            {
                return PersianDate.Parse(date).ToStandard(true);
            }

            return date;
        }

        static DataTable GetRequestsTable()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable("table1");
            table.Columns.Add("RequestSerial", typeof(string));
            table.Columns.Add("RequestID", typeof(string));
            table.Columns.Add("RequestType", typeof(string));
            table.Columns.Add("RequestAmount", typeof(string));
            table.Columns.Add("FacilityType", typeof(string));
            table.Columns.Add("FacilityID", typeof(string));
            table.Columns.Add("FacilityName", typeof(string));
            table.Columns.Add("BailsDetail", typeof(string));
            return table;
        }

        private string GetCheckedComboBoxEdit(CheckedComboBoxEdit control)
        {
            List<string> list = new List<string>();
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem i in control.Properties.Items)
            {
                if (i.CheckState == CheckState.Checked)
                {
                    list.Add(i.Description);
                }
            }

            return string.Join(";", list.ToArray());
        }

        private void SetCheckedComboBoxEdit(CheckedComboBoxEdit control, string text)
        {
            List<string> list = new List<string>();
            foreach (string des in text.Split(';'))
            {
                list.Add(des);
            }
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem i in control.Properties.Items)
            {
                if (list.Contains(i.Description))
                {
                    i.CheckState = CheckState.Checked;
                }
            }
        }

        private void Save()
        {
            try
            {
                dataGridErrors.Rows.Clear();
                if (this.TableRequests.Rows.Count == 0)
                    dataGridErrors.Rows.Add("هیچ پیشنهادی ثبت نشده است");
                if (txtBranchID.Text.Length == 0)
                    dataGridErrors.Rows.Add("کد شعبه مشخص نشده است");

                if (dataGridErrors.Rows.Count == 0)
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgPleaseWait), true, true, false);
                    btnSave.Enabled = false;
                    Application.DoEvents();

                    int referralDate = this.ReferralDate;
                    string reviewReportNo = txtReviewNo.Text;
                    int branchId = Numeral.AnyToInt32(txtBranchID.Text);
                    string customerId = txtCustomerId.Text;
                    string customerName = txtCustomerName.Text;
                    string personalityType = txtPersonalityType.Text;
                    string modirAmel = txtModirAmel.Text.Trim();
                    string noeFaaliyat = txtNoeFaaliyat.Text.Trim();
                    string bakhshFaaliyat = GetCheckedComboBoxEdit(cboBakhshFaaliyat);
                    string noeMojavezShoghli = GetCheckedComboBoxEdit(cboNoeMojavezShoghli);
                    string noeMalekiyat = GetCheckedComboBoxEdit(cboNoeMalekiyat);
                    string vazeyatSanad = cboVazeyatSanad.Text;
                    string tarikhGozaresh = Numeral.ExtractDigits(txtTarikhGozaresh.Text);
                    string tarikhEtelaatEtebari = Numeral.ExtractDigits(txtTarikhEtelaatEtebari.Text);
                    double sarmayeSabti = Numeral.AnyToDouble(txtSarmayeSabti.Text);

                    string tarikhHesabrasi = Numeral.ExtractDigits(txtTarikhHesabrasi.Text);
                    string tarikhSoratMali = Numeral.ExtractDigits(txtTarikhSoratMali.Text);
                    double mojodiKala =  Numeral.AnyToDouble(txtMojodiKala.Text);
                    double foroshDarSoratMali =  Numeral.AnyToDouble(txtForoshDarSoratMali.Text);
                    double soodYaZiyanJari =  Numeral.AnyToDouble(txtSoodYaZiyanJari.Text);
                    double soodYaZiyanAnbashteh =  Numeral.AnyToDouble(txtSoodYaZiyanAnbashteh.Text);
                    double bedehiKotahmodat =  Numeral.AnyToDouble(txtBedehiKotahmodat.Text);
                    double bedehiBolandmodat =  Numeral.AnyToDouble(txtBedehiBolandmodat.Text);
                    string nesbatJari = txtNesbatJari.Text;
                    string nesbatMalekaneh = txtNesbatMalekaneh.Text;
                    string tarikhTaraz = Numeral.ExtractDigits(txtTarikhTaraz.Text);
                    double foroshDarTaraz =  Numeral.AnyToDouble(txtForoshDarTaraz.Text);

                    double estelamMellat1 =  Numeral.AnyToDouble(txtEstelamMellat1.Text);
                    double estelamMellat2 =  Numeral.AnyToDouble(txtEstelamMellat2.Text);
                    double estelamSayer1 =  Numeral.AnyToDouble(txtEstelamSayer1.Text);
                    double estelamSayer2 =  Numeral.AnyToDouble(txtEstelamSayer2.Text);
                    double estelamZinaf1 =  Numeral.AnyToDouble(txtEstelamMostaghim1.Text);
                    double estelamZinaf2 =  Numeral.AnyToDouble(txtEstelamMostaghim2.Text);
                    double estelamZinaf3 =  Numeral.AnyToDouble(txtEstelamGhyreMostaghim1.Text);
                    double estelamZinaf4 =  Numeral.AnyToDouble(txtEstelamGhyreMostaghim2.Text);

                    double bedehiPishnehad1 =  Numeral.AnyToDouble(txtBedehiPishnehadTashilat.Text);
                    double bedehiPishnehad2 =  Numeral.AnyToDouble(txtBedehiPishnehadTaahodat.Text);
                    double mosavabeDarrah1 =  Numeral.AnyToDouble(txtMosavabeDarrahTashilat.Text);
                    double mosavabeDarrah2 =  Numeral.AnyToDouble(txtMosavabeDarrahTaahodat.Text);
                    double saghfBedehiHad1 =  Numeral.AnyToDouble(txtSaghfBedehiHad1.Text);
                    double saghfBedehiHad2 =  Numeral.AnyToDouble(txtSaghfBedehiHad2.Text);
                    double saghfBedehiMoredi1 =  Numeral.AnyToDouble(txtSaghfBedehiMoredi1.Text);
                    double saghfBedehiMoredi2 =  Numeral.AnyToDouble(txtSaghfBedehiMoredi2.Text);
                    double saghfBedehiSaghf1 =  Numeral.AnyToDouble(txtSaghfBedehiSaghf1.Text);
                    double saghfBedehiSaghf2 =  Numeral.AnyToDouble(txtSaghfBedehiSaghf2.Text);

                    string rotbehIranian = GetCheckedComboBoxEdit(cboRotbehIranian);
                    double tasviyehGharardad =  Numeral.AnyToDouble(txtTasviyehGharardad.Text);

                    double tasviyehTashilat =  Numeral.AnyToDouble(txtTasviyehTashilat.Text);
                    double tasviyehTaahodat =  Numeral.AnyToDouble(txtTasviyehTaahodat.Text);
                    double afzayeshTashilat =  Numeral.AnyToDouble(txtAfzayeshTashilat.Text);
                    double afzayeshTaahodat =  Numeral.AnyToDouble(txtAfzayeshTaahodat.Text);
                    double kaheshTashilat =  Numeral.AnyToDouble(txtKaheshTashilat.Text);
                    double kaheshTaahodat =  Numeral.AnyToDouble(txtKaheshTaahodat.Text);
                    double varizTashilat =  Numeral.AnyToDouble(txtVarizTashilat.Text);
                    double varizTaahodat =  Numeral.AnyToDouble(txtVarizTaahodat.Text);

                    double jariBestankar1 =  Numeral.AnyToDouble(txtJariBestankar1.Text);
                    double jariBestankar2 =  Numeral.AnyToDouble(txtJariBestankar2.Text);
                    double jariMoadel1 =  Numeral.AnyToDouble(txtJariMoadel1.Text);
                    double jariMoadel2 =  Numeral.AnyToDouble(txtJariMoadel2.Text);
                    double kotahmodatBestankar1 =  Numeral.AnyToDouble(txtKotahmodatBestankar1.Text);
                    double kotahmodatBestankar2 =  Numeral.AnyToDouble(txtKotahmodatBestankar2.Text);
                    double kotahmodatMoadel1 =  Numeral.AnyToDouble(txtKotahmodatMoadel1.Text);
                    double kotahmodatMoadel2 =  Numeral.AnyToDouble(txtKotahmodatMoadel2.Text);
                    double gharzolhasanehBestankar1 =  Numeral.AnyToDouble(txtGharzolhasanehBestankar1.Text);
                    double gharzolhasanehBestankar2 =  Numeral.AnyToDouble(txtGharzolhasanehBestankar2.Text);
                    double gharzolhasanehMoadel1 =  Numeral.AnyToDouble(txtGharzolhasanehMoadel1.Text);
                    double gharzolhasanehMoadel2 =  Numeral.AnyToDouble(txtGharzolhasanehMoadel2.Text);
                    double sepordeh =  Numeral.AnyToDouble(txtSepordeh.Text);

                    double jariOldMoadel =  Numeral.AnyToDouble(txtJariOldMoadel.Text);
                    double kotahmodatOldMoadel =  Numeral.AnyToDouble(txtKotahmodatOldMoadel.Text);
                    double gharzolhasanehOldMoadel =  Numeral.AnyToDouble(txtGharzolhasanehOldMoadel.Text);

                    string ask1 = cboAsk1.Text;
                    string ask2 = cboAsk2.Text;
                    string ask3 = cboAsk3.Text;
                    string ask4 = cboAsk4.Text;
                    string ask6 = cboAsk6.Text;
                    string ask7 = cboAsk7.Text;
                    string ask8 = cboAsk8.Text;
                    string ask9 = cboAsk9.Text;
                    string ask10 = cboAsk10.Text;
                    string ask11 = cboAsk11.Text;
                    string ask12 = cboAsk12.Text;
                    string ask13 = cboAsk13.Text;

                    string sharayetAkharinMosavabeh = txtSharayetAkharinMosavabeh.Text.Trim().TrimEnd('\r', '\n');

                    string nazariyeKarshenas = txtNazariyeKarshenas.Text.Trim().TrimEnd('\r','\n');

                    string xmlRequests = UDF.ConvertDatatableToXML((DataTable)gridRequests.DataSource, "Request");

                    string id = string.Empty;
                    bool addLogs = false;
                    if (reviewReportNo.Length == 0)
                    {
                        id = ReviewReportManager.Insert(referralDate, branchId, customerId, customerName, personalityType, modirAmel, noeFaaliyat, bakhshFaaliyat, noeMojavezShoghli, noeMalekiyat, vazeyatSanad, tarikhGozaresh, tarikhEtelaatEtebari, sarmayeSabti, tarikhHesabrasi, tarikhSoratMali, mojodiKala, foroshDarSoratMali, soodYaZiyanJari, soodYaZiyanAnbashteh, bedehiKotahmodat, bedehiBolandmodat, nesbatJari, nesbatMalekaneh, tarikhTaraz, foroshDarTaraz, estelamMellat1, estelamMellat2, estelamSayer1, estelamSayer2, estelamZinaf1, estelamZinaf2, estelamZinaf3, estelamZinaf4, bedehiPishnehad1, bedehiPishnehad2, mosavabeDarrah1, mosavabeDarrah2, saghfBedehiHad1, saghfBedehiHad2, saghfBedehiSaghf1, saghfBedehiSaghf2, saghfBedehiMoredi1, saghfBedehiMoredi2, jariBestankar1, jariBestankar2, jariMoadel1, jariMoadel2, kotahmodatBestankar1, kotahmodatBestankar2, kotahmodatMoadel1, kotahmodatMoadel2, gharzolhasanehBestankar1, gharzolhasanehBestankar2, gharzolhasanehMoadel1, gharzolhasanehMoadel2, sepordeh, jariOldMoadel, kotahmodatOldMoadel, gharzolhasanehOldMoadel, rotbehIranian, tasviyehGharardad, tasviyehTashilat, tasviyehTaahodat, afzayeshTashilat, afzayeshTaahodat, kaheshTashilat, kaheshTaahodat, varizTashilat, varizTaahodat, ask1, ask2, ask3, ask4, ask6, ask7, ask8, ask9, ask10, ask11, ask12, ask13, sharayetAkharinMosavabeh, nazariyeKarshenas, xmlRequests, viewRequests.RowCount);
                        addLogs = true;
                    }
                    else
                        id = ReviewReportManager.Update(referralDate, ChkSum.DelCheck(reviewReportNo), branchId, customerId, customerName, personalityType, modirAmel, noeFaaliyat, bakhshFaaliyat, noeMojavezShoghli, noeMalekiyat, vazeyatSanad, tarikhGozaresh, tarikhEtelaatEtebari, sarmayeSabti, tarikhHesabrasi, tarikhSoratMali, mojodiKala, foroshDarSoratMali, soodYaZiyanJari, soodYaZiyanAnbashteh, bedehiKotahmodat, bedehiBolandmodat, nesbatJari, nesbatMalekaneh, tarikhTaraz, foroshDarTaraz, estelamMellat1, estelamMellat2, estelamSayer1, estelamSayer2, estelamZinaf1, estelamZinaf2, estelamZinaf3, estelamZinaf4, bedehiPishnehad1, bedehiPishnehad2, mosavabeDarrah1, mosavabeDarrah2, saghfBedehiHad1, saghfBedehiHad2, saghfBedehiSaghf1, saghfBedehiSaghf2, saghfBedehiMoredi1, saghfBedehiMoredi2, jariBestankar1, jariBestankar2, jariMoadel1, jariMoadel2, kotahmodatBestankar1, kotahmodatBestankar2, kotahmodatMoadel1, kotahmodatMoadel2, gharzolhasanehBestankar1, gharzolhasanehBestankar2, gharzolhasanehMoadel1, gharzolhasanehMoadel2, sepordeh, jariOldMoadel, kotahmodatOldMoadel, gharzolhasanehOldMoadel, rotbehIranian, tasviyehGharardad, tasviyehTashilat, tasviyehTaahodat, afzayeshTashilat, afzayeshTaahodat, kaheshTashilat, kaheshTaahodat, varizTashilat, varizTaahodat, ask1, ask2, ask3, ask4, ask6, ask7, ask8, ask9, ask10, ask11, ask12, ask13, sharayetAkharinMosavabeh, nazariyeKarshenas, xmlRequests, viewRequests.RowCount);

                    Application.DoEvents();
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);

                    if (id.Length > 0)
                    {
                        List<string> serials = new List<string>();
                        DataTable dt = gridRequests.DataSource as DataTable;
                        foreach (DataRow r in dt.Rows)
                            serials.Add(r["RequestSerial"].ToString());

                        RequestManager.UpdateReviewNo(serials.ToArray(), Users.MyUserID, id);

                        txtReviewDate.Text = Network.GetNowDateSerial().ToString();
                        txtReviewNo.Text = ChkSum.GetFull(id);
                        if (addLogs)
                            dlgDataLogs.AddRequestLog(serials.ToArray(), 7, string.Format("فرم بررسی پیشنهاد طی شماره {0} در سیستم ثبت شد", ChkSum.GetFull(id)));

                        DevExpress.XtraEditors.XtraMessageBox.Show("اطلاعات شما با موفقیت ذخیره شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSave.Enabled = true;
                        btnPrint.Enabled = true;
                        btnOpenWord.Enabled = true;
                    }
                    else
                    {
                        btnSave.Enabled = true;
                        DevExpress.XtraEditors.XtraMessageBox.Show("متاسفانه اطلاعات شما ذخیره نگردید! لطفاً مجدداً سعی نمایید ", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                btnSave.Enabled = true;
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                DevExpress.XtraEditors.XtraMessageBox.Show("متاسفانه اطلاعات شما ذخیره نگردید! لطفاً مجدداً سعی نمایید. ", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowInWord()
        {
            try
            {
                btnPrint.Enabled = false;
                btnOpenWord.Enabled = false;
                progressBar.Show();

                progressBar.EditValue = 10;
                Application.DoEvents();

                Microsoft.Office.Interop.Word.Application app = WordDocument.GetWordApp();
                Microsoft.Office.Interop.Word.Document doc = app.Documents.Add(OLEDB.GetFormFile("120.docx"));

                doc.FormFields["DoucumentDate"].Result = ReverseDate(txtReviewDate.Text);
                doc.FormFields["DoucumentSerial"].Result = txtReviewNo.Text;
                    
                doc.FormFields["BranchName"].Result = txtBranchName.Text;
                doc.FormFields["BranchDegree"].Result = txtBranchDegree.Text;
                doc.FormFields["DomainName"].Result = txtDomainName.Text;

                progressBar.EditValue = 20;
                Application.DoEvents();

                doc.FormFields["CustomerName"].Result = txtCustomerName.Text;
                int row = 4;
                int counter1 = 0;
                DataTable dt = gridRequests.DataSource as DataTable;
                foreach (DataRow r in dt.Rows)
                {
                    doc.Tables[3].Rows.Add(
                    doc.Tables[3].Rows[row]);
                    if (dt.Columns.Contains("BailsDetail"))
                        doc.Tables[3].Cell(row, 6).Range.Text = r["BailsDetail"].ToString();
                    if (dt.Columns.Contains("FacilityName"))
                        doc.Tables[3].Cell(row, 5).Range.Text = r["FacilityName"].ToString();
                    if (dt.Columns.Contains("RequestAmount"))
                        doc.Tables[3].Cell(row, 4).Range.Text = r["RequestAmount"].ToString();
                    if (dt.Columns.Contains("RequestType"))
                        doc.Tables[3].Cell(row, 3).Range.Text = r["RequestType"].ToString();
                    if (dt.Columns.Contains("RequestID"))
                        doc.Tables[3].Cell(row, 2).Range.Text = r["RequestID"].ToString();
                    doc.Tables[3].Cell(row, 1).Range.Text = (++counter1).ToString();
                    ++row;
                }
                doc.Tables[3].Rows[row].Delete();

                progressBar.EditValue = 30;
                Application.DoEvents();

                if (txtModirAmel.Text.Length > 0)
                    doc.FormFields["ModirAmel"].Result = "مدیرعامل: " + txtModirAmel.Text.Trim();
                doc.FormFields["NoeFaaliyat"].Result = txtNoeFaaliyat.Text.Trim();
                doc.FormFields["BakhshFaaliyat"].Result = GetCheckedComboBoxEdit(cboBakhshFaaliyat);
                doc.FormFields["NoeMojavezShoghli"].Result = GetCheckedComboBoxEdit(cboNoeMojavezShoghli);
                doc.FormFields["NoeMalekiyat"].Result = GetCheckedComboBoxEdit(cboNoeMalekiyat);

                if (txtTarikhGozaresh.Text != "____/__/__")
                    doc.FormFields["TarikhGozaresh"].Result = ReverseDate(txtTarikhGozaresh.Text);
                if (txtTarikhEtelaatEtebari.Text != "____/__/__")
                    doc.FormFields["TarikhEtelaatEtebari"].Result = ReverseDate(txtTarikhEtelaatEtebari.Text);
                doc.FormFields["SarmayeSabti"].Result = txtSarmayeSabti.Text;

                progressBar.EditValue = 40;
                Application.DoEvents();

                if (txtTarikhHesabrasi.Text != "____/__/__")
                    doc.FormFields["TarikhHesabrasi"].Result = ReverseDate(txtTarikhHesabrasi.Text);
                if (txtTarikhSoratMali.Text != "____/__/__")
                    doc.FormFields["TarikhSoratMali"].Result = ReverseDate(txtTarikhSoratMali.Text);
                doc.FormFields["MojodiKala"].Result = txtMojodiKala.Text;
                doc.FormFields["ForoshDarSoratMali"].Result = txtForoshDarSoratMali.Text;
                double soodYaZiyanJari = Numeral.AnyToDouble(txtSoodYaZiyanJari.Text);
                if (soodYaZiyanJari < 0)
                    doc.FormFields["SoodYaZiyanJari"].Result = "(" + Math.Abs(soodYaZiyanJari).ToString("n0") + ")";
                else
                    doc.FormFields["SoodYaZiyanJari"].Result = txtSoodYaZiyanJari.Text;

                double soodYaZiyanAnbashteh = Numeral.AnyToDouble(txtSoodYaZiyanAnbashteh.Text);
                if (soodYaZiyanAnbashteh < 0)
                    doc.FormFields["SoodYaZiyanAnbashteh"].Result = "(" + Math.Abs(soodYaZiyanAnbashteh).ToString("n0") + ")";
                else
                    doc.FormFields["SoodYaZiyanAnbashteh"].Result = txtSoodYaZiyanAnbashteh.Text;

                doc.FormFields["BedehiKotahmodat"].Result = txtBedehiKotahmodat.Text;
                doc.FormFields["BedehiBolandmodat"].Result = txtBedehiBolandmodat.Text;
                doc.FormFields["NesbatJari"].Result = txtNesbatJari.Text;
                doc.FormFields["NesbatMalekaneh"].Result = txtNesbatMalekaneh.Text;
                if (txtTarikhTaraz.Text != "____/__/__")
                    doc.FormFields["TarikhTaraz"].Result = ReverseDate(txtTarikhTaraz.Text);

                doc.FormFields["ForoshDarTaraz"].Result = txtForoshDarTaraz.Text;

                progressBar.EditValue = 50;
                Application.DoEvents();

                doc.FormFields["EstelamMellat1"].Result = txtEstelamMellat1.Text;
                doc.FormFields["EstelamMellat2"].Result = txtEstelamMellat2.Text;
                doc.FormFields["EstelamSayer1"].Result = txtEstelamSayer1.Text;
                doc.FormFields["EstelamSayer2"].Result = txtEstelamSayer2.Text;
                doc.FormFields["SumEstelam1"].Result = (Numeral.AnyToDouble(txtEstelamMellat1.Text) + Numeral.AnyToDouble(txtEstelamSayer1.Text)).ToString("n0");
                doc.FormFields["SumEstelam2"].Result = (Numeral.AnyToDouble(txtEstelamMellat2.Text) + Numeral.AnyToDouble(txtEstelamSayer2.Text)).ToString("n0");
                doc.FormFields["EstelamZinaf1"].Result = txtEstelamMostaghim1.Text;
                doc.FormFields["EstelamZinaf2"].Result = txtEstelamMostaghim2.Text;
                doc.FormFields["EstelamZinaf3"].Result = txtEstelamGhyreMostaghim1.Text;
                doc.FormFields["EstelamZinaf4"].Result = txtEstelamGhyreMostaghim2.Text;
                doc.FormFields["RotbehIranian"].Result = GetCheckedComboBoxEdit(cboRotbehIranian);
                doc.FormFields["TasviyehGharardad"].Result = txtTasviyehGharardad.Text;

                doc.FormFields["Risk"].Result = txtRisk.Text;
                doc.FormFields["TasviyehTashilat"].Result = txtTasviyehTashilat.Text;
                doc.FormFields["TasviyehTaahodat"].Result = txtTasviyehTaahodat.Text;

                doc.FormFields["SumEstelamZinaf"].Result = (Numeral.AnyToDouble(txtEstelamMostaghim1.Text) + Numeral.AnyToDouble(txtEstelamMostaghim2.Text) + Numeral.AnyToDouble(txtEstelamGhyreMostaghim1.Text) + Numeral.AnyToDouble(txtEstelamGhyreMostaghim2.Text)).ToString("n0");
                doc.FormFields["BedehiPishnehad1"].Result = txtBedehiPishnehadTashilat.Text;
                doc.FormFields["BedehiPishnehad2"].Result = txtBedehiPishnehadTaahodat.Text;
                doc.FormFields["MosavabeDarrah1"].Result = txtMosavabeDarrahTashilat.Text;
                doc.FormFields["MosavabeDarrah2"].Result = txtMosavabeDarrahTaahodat.Text;

                double sumSaghfTashilat = Numeral.AnyToDouble(txtSaghfBedehiHad1.Text) + Numeral.AnyToDouble(txtSaghfBedehiSaghf1.Text) + Numeral.AnyToDouble(txtSaghfBedehiMoredi1.Text);
                double sumSaghfTaahodat = Numeral.AnyToDouble(txtSaghfBedehiHad2.Text) + Numeral.AnyToDouble(txtSaghfBedehiSaghf2.Text) + Numeral.AnyToDouble(txtSaghfBedehiMoredi2.Text);
                doc.FormFields["SumSaghfTashilat"].Result = sumSaghfTashilat.ToString("n0");
                doc.FormFields["SumSaghfTaahodat"].Result = sumSaghfTaahodat.ToString("n0");

                double sumAfzayeshfTashilat = (Numeral.AnyToDouble(txtAfzayeshTashilat.Text) - Numeral.AnyToDouble(txtKaheshTashilat.Text));
                double sumAfzayeshfTaahodat = (Numeral.AnyToDouble(txtAfzayeshTaahodat.Text) - Numeral.AnyToDouble(txtKaheshTaahodat.Text));
                doc.FormFields["AfzayeshTashilat"].Result = sumAfzayeshfTashilat.ToString("n0");
                doc.FormFields["AfzayeshTaahodat"].Result = sumAfzayeshfTaahodat.ToString("n0");


                progressBar.EditValue = 70;
                Application.DoEvents();

                doc.FormFields["JariBestankar1"].Result = txtJariBestankar1.Text;
                doc.FormFields["JariBestankar2"].Result = txtJariBestankar2.Text;
                doc.FormFields["JariMoadel1"].Result = txtJariMoadel1.Text;
                doc.FormFields["JariMoadel2"].Result = txtJariMoadel2.Text;
                doc.FormFields["KotahmodatBestankar1"].Result = txtKotahmodatBestankar1.Text;
                doc.FormFields["KotahmodatBestankar2"].Result = txtKotahmodatBestankar2.Text;
                doc.FormFields["KotahmodatMoadel1"].Result = txtKotahmodatMoadel1.Text;
                doc.FormFields["KotahmodatMoadel2"].Result = txtKotahmodatMoadel2.Text;
                doc.FormFields["GharzBestankar1"].Result = txtGharzolhasanehBestankar1.Text;
                doc.FormFields["GharzBestankar2"].Result = txtGharzolhasanehBestankar2.Text;
                doc.FormFields["GharzMoadel1"].Result = txtGharzolhasanehMoadel1.Text;
                doc.FormFields["GharzMoadel2"].Result = txtGharzolhasanehMoadel2.Text;

                doc.FormFields["SumBestankar1"].Result = (Numeral.AnyToDouble(txtJariBestankar1.Text) + Numeral.AnyToDouble(txtKotahmodatBestankar1.Text) + Numeral.AnyToDouble(txtGharzolhasanehBestankar1.Text)).ToString("n0");
                doc.FormFields["SumBestankar2"].Result = (Numeral.AnyToDouble(txtJariBestankar2.Text) + Numeral.AnyToDouble(txtKotahmodatBestankar2.Text) + Numeral.AnyToDouble(txtGharzolhasanehBestankar2.Text)).ToString("n0");
                doc.FormFields["SumMoadel1"].Result = (Numeral.AnyToDouble(txtJariMoadel1.Text) + Numeral.AnyToDouble(txtKotahmodatMoadel1.Text) + Numeral.AnyToDouble(txtGharzolhasanehMoadel1.Text)).ToString("n0");
                doc.FormFields["SumMoadel2"].Result = (Numeral.AnyToDouble(txtJariMoadel2.Text) + Numeral.AnyToDouble(txtKotahmodatMoadel2.Text) + Numeral.AnyToDouble(txtGharzolhasanehMoadel2.Text)).ToString("n0");

                doc.FormFields["JariOldMoadel"].Result = txtJariOldMoadel.Text;
                doc.FormFields["KotahmodatOldMoadel"].Result = txtKotahmodatOldMoadel.Text;
                doc.FormFields["GharzOldMoadel"].Result = txtGharzolhasanehOldMoadel.Text;
                doc.FormFields["SumOldMoadel"].Result = (Numeral.AnyToDouble(txtJariOldMoadel.Text) + Numeral.AnyToDouble(txtKotahmodatOldMoadel.Text) + Numeral.AnyToDouble(txtGharzolhasanehOldMoadel.Text)).ToString("n0");

                progressBar.EditValue = 80;
                Application.DoEvents();

                StringBuilder sb = new StringBuilder();
                int counter2 = 0;
                if (cboAsk1.Text == "بلی")
                    sb.Append(++counter2 + "-" + "طبق استعلام بانک مرکزی ج.ا.ا مشتری دارای مطالبات معوق می باشد" + " ");
                if (cboAsk2.Text == "بلی")
                    sb.Append(++counter2 + "-" + "متقاضی مشتری جدید بانک می باشد" + " ");
                if (cboAsk3.Text == "خیر")
                    sb.Append(++counter2 + "-" + "متقاضی فاقد اموال غیر منقول می باشد" + " ");
                if (cboAsk4.Text == "خیر")
                    sb.Append(++counter2 + "-" + "در اساسنامه شرکت مجوز اخذ تسهیلات قید نشده است" + " ");
                if (cboAsk6.Text == "بلی")
                    sb.Append(++counter2 + "-" + "شرکت مشمول ماده 141 قانون تجارت می باشد" + " ");
                if (cboAsk7.Text == "بلی")
                    sb.Append(++counter2 + "-" + "مشتری دارای بدهی غیرجاری تقسیط شده می باشد" + " ");
                if (cboAsk8.Text == "خیر")
                    sb.Append(++counter2 + "-" + "نظریه موافق حوزه قید نگردیده است" + " ");
                if (cboAsk9.Text == "بلی")
                    sb.Append(++counter2 + "-" + "طبق پردازش 4915 مشتری دارای جریمه می باشد");
                if (cboAsk10.Text == "بلی")
                    sb.Append(++counter2 + "-" + "مشتری دارای چک برگشتی می باشد" + " ");
                if (cboAsk11.Text == "خیر")
                    sb.Append(++counter2 + "-" + "مجوز شغلی متقاضی فاقد اعتبار می باشد" + " ");
                if (cboAsk12.Text == "بلی")
                    sb.Append(++counter2 + "-" + "شرکت دارای قرارداد حسابرسی می باشد" + " ");
                if (cboAsk12.Text == "خیر")
                    sb.Append(++counter2 + "-" + "شرکت فاقد قرارداد حسابرسی می باشد" + " ");
                if (cboAsk13.Text == "بلی")
                    sb.Append(++counter2 + "-" + "متقاضی دارای وثیقه ملکی شخص ثالث در رهن بانک می باشد" + " ");
                if (cboAsk14.Text == "خیر")
                    sb.Append(++counter2 + "-" + "متقاضی شرایط تخصیص حد اعتباری را ندارد" + " ");
                if (cboAsk15.Text == "بلی")
                    sb.Append(++counter2 + "-" + "متقاضی دارای تعهدات ارزی ایفاء نشده سررسید شده می باشد" + " ");
                if (cboAsk15.Text == "خیر")
                    sb.Append(++counter2 + "-" + "متقاضی فاقد تعهدات ارزی ایفاء نشده سررسید شده می باشد" + " ");
                if (cboAsk16.Text == "خیر")
                    sb.Append(++counter2 + "-" + "متقاضی فاقد دستگاه کارتخوان می باشد" + " ");
                if (PersianDateTime.IsValidDate(txtTarikhEtelaatEtebari.Text) && (PersianDateTime.Now - PersianDateTime.Parse(txtTarikhEtelaatEtebari.Text, "/")).Days > 365)
                    sb.Append(++counter2 + "-" + "تاریخ اطلاعات اعتباری بیش از یک سال می باشد" + " ");

                if (PersianDateTime.IsValidDate(txtTarikhGozaresh.Text) && (PersianDateTime.Now - PersianDateTime.Parse(txtTarikhGozaresh.Text, "/")).Days > 365)
                    sb.Append(++counter2 + "-" + "تاریخ گزارش کارشناسی بیش از یک سال می باشد" + " ");

                if (cboVazeyatSanad.Text.Length > 0 & cboVazeyatSanad.Text != "آزاد")
                {
                    sb.Append(++counter2 + "-" + "وضعیت سند متقاضی " + cboVazeyatSanad.Text + " می باشد" + " ");
                }
                if (Numeral.AnyToDouble(txtVarizTashilat.Text) > 0)
                    sb.Append(++counter2 + "-" + "پیشنهاد حاضر از محل واریز تسهیلات به مبلغ " + txtVarizTashilat.Text + " میلیون ریال می باشد" + " ");
                if (Numeral.AnyToDouble(txtVarizTaahodat.Text) > 0)
                    sb.Append(++counter2 + "-" + "پیشنهاد حاضر از محل واریز تعهدات به مبلغ " + txtVarizTaahodat.Text + " میلیون ریال می باشد" + " ");
                if (Numeral.AnyToDouble(txtSepordeh.Text) > 0)
                    sb.Append(++counter2 + "-" + "مشتری دارای سپرده بلندمدت به مبلغ " + txtSepordeh.Text + " میلیون ریال می باشد" + " ");
                if (txtSharayetAkharinMosavabeh.Text.Trim().Length > 0)
                    sb.Append(++counter2 + "-" + "شرایط مندرج در مصوبه قبلی > " + txtSharayetAkharinMosavabeh.Text + " ");

                progressBar.EditValue = 90;
                Application.DoEvents();

                doc.Tables[9].Cell(2, 1).Range.Text = sb.ToString();
                doc.Tables[10].Cell(2, 2).Range.Text = txtNazariyeKarshenas.Text.Trim();

                doc.FormFields["ExpertName"].Result = Users.GetUserNameById(Users.MyUserID);

                btnPrint.Enabled = true;
                btnOpenWord.Enabled = true;
                progressBar.EditValue = 100;
                progressBar.Hide();

                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Title = "Save Report";
                saveDlg.Filter = "Word File|*.docx";
                saveDlg.FileName = PersianDateTime.Now.ToShortDateInt() + "-" + txtCustomerName.Text;
                saveDlg.ShowDialog();
                if (saveDlg.FileName != "")
                {
                    doc.Protect(Microsoft.Office.Interop.Word.WdProtectionType.wdAllowOnlyReading, false, "7658", false, true);
                    doc.SaveAs2(saveDlg.FileName);
                    app.Quit(Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges);
                    System.Diagnostics.Process.Start(saveDlg.FileName);
                }
            }
            catch
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                btnPrint.Enabled = true;
                btnOpenWord.Enabled = true;
                progressBar.Hide();
            }
        }

        private string GetRisk(string text)
        {
            if (text.StartsWith("A"))
                return "خیلی پایین";
            if (text.StartsWith("B"))
                return "پایین";
            if (text.StartsWith("C"))
                return "متوسط";
            if (text.StartsWith("D"))
                return "بالا";
            if (text.StartsWith("E"))
                return "خیلی بالا";
            return "";
        }

        private void SumTextValues()
        {
            lblSum1.Text = (Numeral.AnyToDouble(txtJariBestankar1.Text) + Numeral.AnyToDouble(txtKotahmodatBestankar1.Text) + Numeral.AnyToDouble(txtGharzolhasanehBestankar1.Text)).ToString("n0");
            lblSum2.Text = (Numeral.AnyToDouble(txtJariBestankar2.Text) + Numeral.AnyToDouble(txtKotahmodatBestankar2.Text) + Numeral.AnyToDouble(txtGharzolhasanehBestankar2.Text)).ToString("n0");
            lblSum3.Text = (Numeral.AnyToDouble(txtJariMoadel1.Text) + Numeral.AnyToDouble(txtKotahmodatMoadel1.Text) + Numeral.AnyToDouble(txtGharzolhasanehMoadel1.Text)).ToString("n0");
            lblSum4.Text = (Numeral.AnyToDouble(txtJariMoadel2.Text) + Numeral.AnyToDouble(txtKotahmodatMoadel2.Text) + Numeral.AnyToDouble(txtGharzolhasanehMoadel2.Text)).ToString("n0");
        }

        #endregion

        private void txtPersonalityType_TextChanged(object sender, EventArgs e)
        {
            if (txtPersonalityType.Text == "حقوقی")
            {
                cboAsk4.Enabled = true;
                cboAsk6.Enabled = true;
            }
            else 
            {
                cboAsk4.Enabled = false;
                cboAsk6.Enabled = false;
            }
        }

        private void btnOpenWord_Click(object sender, EventArgs e)
        {
            try
            {
                btnPrint.Enabled = false;
                btnOpenWord.Enabled = false;
                progressBar.Show();
                progressBar.EditValue = 10;
                Application.DoEvents();

                Microsoft.Office.Interop.Word.Application app = WordDocument.GetWordApp();
                Microsoft.Office.Interop.Word.Document doc = app.Documents.Add(OLEDB.GetFormFile("120.docx"));
                StringBuilder sb = new StringBuilder();
                doc.FormFields["DoucumentDate"].Result = ReverseDate(txtReviewDate.Text);
                doc.FormFields["DoucumentSerial"].Result = txtReviewNo.Text;

                doc.FormFields["BranchName"].Result = txtBranchName.Text;
                doc.FormFields["BranchDegree"].Result = txtBranchDegree.Text;
                doc.FormFields["DomainName"].Result = txtDomainName.Text;

                progressBar.EditValue = 20;
                Application.DoEvents();

                doc.FormFields["CustomerName"].Result = txtCustomerName.Text;
                int row = 4;
                int counter1 = 0;
                DataTable dt = gridRequests.DataSource as DataTable;
                foreach (DataRow r in dt.Rows)
                {
                    doc.Tables[3].Rows.Add(
                    doc.Tables[3].Rows[row]);
                    if (dt.Columns.Contains("BailsDetail"))
                        doc.Tables[3].Cell(row, 6).Range.Text = r["BailsDetail"].ToString();
                    if (dt.Columns.Contains("FacilityName"))
                        doc.Tables[3].Cell(row, 5).Range.Text = r["FacilityName"].ToString();
                    if (dt.Columns.Contains("RequestAmount"))
                        doc.Tables[3].Cell(row, 4).Range.Text = r["RequestAmount"].ToString();
                    if (dt.Columns.Contains("RequestType"))
                        doc.Tables[3].Cell(row, 3).Range.Text = r["RequestType"].ToString();
                    if (dt.Columns.Contains("RequestID"))
                        doc.Tables[3].Cell(row, 2).Range.Text = r["RequestID"].ToString();
                    doc.Tables[3].Cell(row, 1).Range.Text = (++counter1).ToString();
                    ++row;
                }
                doc.Tables[3].Rows[row].Delete();

                progressBar.EditValue = 30;
                Application.DoEvents();

                if (txtModirAmel.Text.Length > 0)
                    doc.FormFields["ModirAmel"].Result = "مدیرعامل: " + txtModirAmel.Text.Trim();
                doc.FormFields["NoeFaaliyat"].Result = txtNoeFaaliyat.Text.Trim();
                doc.FormFields["BakhshFaaliyat"].Result = GetCheckedComboBoxEdit(cboBakhshFaaliyat);
                doc.FormFields["NoeMojavezShoghli"].Result = GetCheckedComboBoxEdit(cboNoeMojavezShoghli);
                doc.FormFields["NoeMalekiyat"].Result = GetCheckedComboBoxEdit(cboNoeMalekiyat);

                if (txtTarikhGozaresh.Text != "____/__/__")
                    doc.FormFields["TarikhGozaresh"].Result = ReverseDate(txtTarikhGozaresh.Text);
                if (txtTarikhEtelaatEtebari.Text != "____/__/__")
                    doc.FormFields["TarikhEtelaatEtebari"].Result = ReverseDate(txtTarikhEtelaatEtebari.Text);
                doc.FormFields["SarmayeSabti"].Result = txtSarmayeSabti.Text;

                progressBar.EditValue = 40;
                Application.DoEvents();

                if (txtTarikhHesabrasi.Text != "____/__/__")
                    doc.FormFields["TarikhHesabrasi"].Result = ReverseDate(txtTarikhHesabrasi.Text);
                if (txtTarikhSoratMali.Text != "____/__/__")
                    doc.FormFields["TarikhSoratMali"].Result = ReverseDate(txtTarikhSoratMali.Text);
                doc.FormFields["MojodiKala"].Result = txtMojodiKala.Text;
                doc.FormFields["ForoshDarSoratMali"].Result = txtForoshDarSoratMali.Text;
                double soodYaZiyanJari = Numeral.AnyToDouble(txtSoodYaZiyanJari.Text);
                if (soodYaZiyanJari < 0)
                    doc.FormFields["SoodYaZiyanJari"].Result = "(" + Math.Abs(soodYaZiyanJari).ToString("n0") + ")";
                else
                    doc.FormFields["SoodYaZiyanJari"].Result = txtSoodYaZiyanJari.Text;

                double soodYaZiyanAnbashteh = Numeral.AnyToDouble(txtSoodYaZiyanAnbashteh.Text);
                if (soodYaZiyanAnbashteh < 0)
                    doc.FormFields["SoodYaZiyanAnbashteh"].Result = "(" + Math.Abs(soodYaZiyanAnbashteh).ToString("n0") + ")";
                else
                    doc.FormFields["SoodYaZiyanAnbashteh"].Result = txtSoodYaZiyanAnbashteh.Text;

                doc.FormFields["BedehiKotahmodat"].Result = txtBedehiKotahmodat.Text;
                doc.FormFields["BedehiBolandmodat"].Result = txtBedehiBolandmodat.Text;
                doc.FormFields["NesbatJari"].Result = txtNesbatJari.Text;
                doc.FormFields["NesbatMalekaneh"].Result = txtNesbatMalekaneh.Text;
                if (txtTarikhTaraz.Text != "____/__/__")
                    doc.FormFields["TarikhTaraz"].Result = ReverseDate(txtTarikhTaraz.Text);

                doc.FormFields["ForoshDarTaraz"].Result = txtForoshDarTaraz.Text;

                progressBar.EditValue = 50;
                Application.DoEvents();

                doc.FormFields["EstelamMellat1"].Result = txtEstelamMellat1.Text;
                doc.FormFields["EstelamMellat2"].Result = txtEstelamMellat2.Text;
                doc.FormFields["EstelamSayer1"].Result = txtEstelamSayer1.Text;
                doc.FormFields["EstelamSayer2"].Result = txtEstelamSayer2.Text;
                doc.FormFields["SumEstelam1"].Result = (Numeral.AnyToDouble(txtEstelamMellat1.Text) + Numeral.AnyToDouble(txtEstelamSayer1.Text)).ToString("n0");
                doc.FormFields["SumEstelam2"].Result = (Numeral.AnyToDouble(txtEstelamMellat2.Text) + Numeral.AnyToDouble(txtEstelamSayer2.Text)).ToString("n0");
                doc.FormFields["Mostaghim1"].Result = txtEstelamMostaghim1.Text;
                doc.FormFields["Mostaghim2"].Result = txtEstelamMostaghim2.Text;
                doc.FormFields["GhyreMostaghim1"].Result = txtEstelamGhyreMostaghim1.Text;
                doc.FormFields["GhyreMostaghim2"].Result = txtEstelamGhyreMostaghim2.Text;
                doc.FormFields["SumZinaf1"].Result = (Numeral.AnyToDouble(txtEstelamMostaghim1.Text) + Numeral.AnyToDouble(txtEstelamGhyreMostaghim1.Text)).ToString("n0");
                doc.FormFields["SumZinaf2"].Result = (Numeral.AnyToDouble(txtEstelamGhyreMostaghim1.Text) + Numeral.AnyToDouble(txtEstelamGhyreMostaghim2.Text)).ToString("n0");
                doc.FormFields["RotbehIranian"].Result = GetCheckedComboBoxEdit(cboRotbehIranian);
                doc.FormFields["TasviyehGharardad"].Result = txtTasviyehGharardad.Text;

                doc.FormFields["Risk"].Result = txtRisk.Text;
                doc.FormFields["TasviyehTashilat"].Result = txtTasviyehTashilat.Text;
                doc.FormFields["TasviyehTaahodat"].Result = txtTasviyehTaahodat.Text;

                doc.FormFields["BedehiPishnehad1"].Result = txtBedehiPishnehadTashilat.Text;
                doc.FormFields["BedehiPishnehad2"].Result = txtBedehiPishnehadTaahodat.Text;
                doc.FormFields["MosavabeDarrah1"].Result = txtMosavabeDarrahTashilat.Text;
                doc.FormFields["MosavabeDarrah2"].Result = txtMosavabeDarrahTaahodat.Text;

                double sumSaghfTashilat = Numeral.AnyToDouble(txtSaghfBedehiHad1.Text) + Numeral.AnyToDouble(txtSaghfBedehiSaghf1.Text) + Numeral.AnyToDouble(txtSaghfBedehiMoredi1.Text);
                double sumSaghfTaahodat = Numeral.AnyToDouble(txtSaghfBedehiHad2.Text) + Numeral.AnyToDouble(txtSaghfBedehiSaghf2.Text) + Numeral.AnyToDouble(txtSaghfBedehiMoredi2.Text);
                doc.FormFields["SumSaghfTashilat"].Result = sumSaghfTashilat.ToString("n0");
                doc.FormFields["SumSaghfTaahodat"].Result = sumSaghfTaahodat.ToString("n0");

                double sumAfzayeshfTashilat = (Numeral.AnyToDouble(txtAfzayeshTashilat.Text) - Numeral.AnyToDouble(txtKaheshTashilat.Text));
                double sumAfzayeshfTaahodat = (Numeral.AnyToDouble(txtAfzayeshTaahodat.Text) - Numeral.AnyToDouble(txtKaheshTaahodat.Text));
                doc.FormFields["AfzayeshTashilat"].Result = sumAfzayeshfTashilat.ToString("n0");
                doc.FormFields["AfzayeshTaahodat"].Result = sumAfzayeshfTaahodat.ToString("n0");


                progressBar.EditValue = 70;
                Application.DoEvents();

                doc.FormFields["JariBestankar1"].Result = txtJariBestankar1.Text;
                doc.FormFields["JariBestankar2"].Result = txtJariBestankar2.Text;
                doc.FormFields["JariMoadel1"].Result = txtJariMoadel1.Text;
                doc.FormFields["JariMoadel2"].Result = txtJariMoadel2.Text;
                doc.FormFields["KotahmodatBestankar1"].Result = txtKotahmodatBestankar1.Text;
                doc.FormFields["KotahmodatBestankar2"].Result = txtKotahmodatBestankar2.Text;
                doc.FormFields["KotahmodatMoadel1"].Result = txtKotahmodatMoadel1.Text;
                doc.FormFields["KotahmodatMoadel2"].Result = txtKotahmodatMoadel2.Text;
                doc.FormFields["GharzBestankar1"].Result = txtGharzolhasanehBestankar1.Text;
                doc.FormFields["GharzBestankar2"].Result = txtGharzolhasanehBestankar2.Text;
                doc.FormFields["GharzMoadel1"].Result = txtGharzolhasanehMoadel1.Text;
                doc.FormFields["GharzMoadel2"].Result = txtGharzolhasanehMoadel2.Text;

                doc.FormFields["SumBestankar1"].Result = (Numeral.AnyToDouble(txtJariBestankar1.Text) + Numeral.AnyToDouble(txtKotahmodatBestankar1.Text) + Numeral.AnyToDouble(txtGharzolhasanehBestankar1.Text)).ToString("n0");
                doc.FormFields["SumBestankar2"].Result = (Numeral.AnyToDouble(txtJariBestankar2.Text) + Numeral.AnyToDouble(txtKotahmodatBestankar2.Text) + Numeral.AnyToDouble(txtGharzolhasanehBestankar2.Text)).ToString("n0");
                doc.FormFields["SumMoadel1"].Result = (Numeral.AnyToDouble(txtJariMoadel1.Text) + Numeral.AnyToDouble(txtKotahmodatMoadel1.Text) + Numeral.AnyToDouble(txtGharzolhasanehMoadel1.Text)).ToString("n0");
                doc.FormFields["SumMoadel2"].Result = (Numeral.AnyToDouble(txtJariMoadel2.Text) + Numeral.AnyToDouble(txtKotahmodatMoadel2.Text) + Numeral.AnyToDouble(txtGharzolhasanehMoadel2.Text)).ToString("n0");

                doc.FormFields["JariOldMoadel"].Result = txtJariOldMoadel.Text;
                doc.FormFields["KotahmodatOldMoadel"].Result = txtKotahmodatOldMoadel.Text;
                doc.FormFields["GharzOldMoadel"].Result = txtGharzolhasanehOldMoadel.Text;
                doc.FormFields["SumOldMoadel"].Result = (Numeral.AnyToDouble(txtJariOldMoadel.Text) + Numeral.AnyToDouble(txtKotahmodatOldMoadel.Text) + Numeral.AnyToDouble(txtGharzolhasanehOldMoadel.Text)).ToString("n0");

                progressBar.EditValue = 80;
                Application.DoEvents();

                int counter2 = 0;
                if (cboAsk1.Text == "بلی")
                    sb.Append(++counter2 + "-" + "طبق استعلام بانک مرکزی ج.ا.ا مشتری دارای مطالبات معوق می باشد" + " ");
                if (cboAsk2.Text == "بلی")
                    sb.Append(++counter2 + "-" + "متقاضی مشتری جدید بانک می باشد" + " ");
                if (cboAsk3.Text == "خیر")
                    sb.Append(++counter2 + "-" + "متقاضی فاقد اموال غیر منقول می باشد" + " ");
                if (cboAsk4.Text == "خیر")
                    sb.Append(++counter2 + "-" + "در اساسنامه شرکت مجوز اخذ تسهیلات قید نشده است" + " ");
                if (cboAsk6.Text == "بلی")
                    sb.Append(++counter2 + "-" + "شرکت مشمول ماده 141 قانون تجارت می باشد" + " ");
                if (cboAsk7.Text == "بلی")
                    sb.Append(++counter2 + "-" + "مشتری دارای بدهی غیرجاری تقسیط شده می باشد" + " ");
                if (cboAsk8.Text == "خیر")
                    sb.Append(++counter2 + "-" + "نظریه موافق حوزه قید نگردیده است" + " ");
                if (cboAsk9.Text == "بلی")
                    sb.Append(++counter2 + "-" + "طبق پردازش 4915 مشتری دارای جریمه می باشد");
                if (cboAsk10.Text == "بلی")
                    sb.Append(++counter2 + "-" + "مشتری دارای چک برگشتی می باشد" + " ");
                if (cboAsk11.Text == "خیر")
                    sb.Append(++counter2 + "-" + "مجوز شغلی متقاضی فاقد اعتبار می باشد" + " ");
                if (cboAsk12.Text == "بلی")
                    sb.Append(++counter2 + "-" + "شرکت دارای قرارداد حسابرسی می باشد" + " ");
                if (cboAsk12.Text == "خیر")
                    sb.Append(++counter2 + "-" + "شرکت فاقد قرارداد حسابرسی می باشد" + " ");
                if (cboAsk13.Text == "بلی")
                    sb.Append(++counter2 + "-" + "متقاضی دارای وثیقه ملکی شخص ثالث در رهن بانک می باشد" + " ");
                if (cboVazeyatSanad.Text.Length > 0 & cboVazeyatSanad.Text != "آزاد")
                {
                    sb.Append(++counter2 + "-" + "وضعیت سند متقاضی " + cboVazeyatSanad.Text + " می باشد" + " ");
                }
                if (Numeral.AnyToDouble(txtVarizTashilat.Text) > 0)
                    sb.Append(++counter2 + "-" + "پیشنهاد حاضر از محل واریز تسهیلات به مبلغ " + txtVarizTashilat.Text + " میلیون ریال می باشد" + " ");
                if (Numeral.AnyToDouble(txtVarizTaahodat.Text) > 0)
                    sb.Append(++counter2 + "-" + "پیشنهاد حاضر از محل واریز تعهدات به مبلغ " + txtVarizTaahodat.Text + " میلیون ریال می باشد" + " ");
                if (Numeral.AnyToDouble(txtSepordeh.Text) > 0)
                    sb.Append(++counter2 + "-" + "مشتری دارای سپرده بلندمدت به مبلغ " + txtSepordeh.Text + " میلیون ریال می باشد" + " ");
                if (txtSharayetAkharinMosavabeh.Text.Trim().Length > 0)
                    sb.Append(++counter2 + "-" + "شرایط مندرج در مصوبه قبلی > " + txtSharayetAkharinMosavabeh.Text + " ");

                progressBar.EditValue = 90;
                Application.DoEvents();

                doc.Tables[9].Cell(2, 1).Range.Text = sb.ToString();
                doc.Tables[10].Cell(2, 2).Range.Text = txtNazariyeKarshenas.Text.Trim();

                doc.FormFields["ExpertName"].Result = Users.GetUserNameById(Users.MyUserID);

                btnPrint.Enabled = true;
                btnOpenWord.Enabled = true;

                progressBar.EditValue = 100;
                progressBar.Hide();

                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Title = "Save Report";
                saveDlg.Filter = "Word File|*.docx";
                saveDlg.FileName = PersianDateTime.Now.ToShortDateInt() + "-" + txtCustomerName.Text;
                saveDlg.ShowDialog();
                if (saveDlg.FileName != "")
                {
                    doc.Protect(Microsoft.Office.Interop.Word.WdProtectionType.wdAllowOnlyReading, false, "7658", false, true);
                    doc.SaveAs2(saveDlg.FileName);
                    app.Quit(Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges);
                    System.Diagnostics.Process.Start(saveDlg.FileName);
                }
            }
            catch
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                btnPrint.Enabled = true;
                btnOpenWord.Enabled = true;
                progressBar.Hide();
            }
        }
    }
}