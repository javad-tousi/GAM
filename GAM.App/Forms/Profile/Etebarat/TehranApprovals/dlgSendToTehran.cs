using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GAM.Forms.Profile.Etebarat.Library;
using GAM.Forms.Settings.Library;

namespace GAM.Forms.Profile.Etebarat.TehranApprovals
{
    public partial class dlgSendToTehran : DevExpress.XtraEditors.XtraForm
    {
        private DataRow thisRow { set; get; }

        public dlgSendToTehran(DataRow row)
        {
            InitializeComponent();
            thisRow = row;
            txtDate.Value = Network.GetNowPersianDate();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtDate.Value.HasValue)
            {
                string serial = thisRow["RequestSerial"].ToString();
                string provinceLetterNo = thisRow["ProvinceLetterNo"].ToString();

                bool queryResult = RequestManager.UpdateProvinceLetterDate(serial, int.Parse(txtDate.GetText("yyyyMMdd")));
                if (queryResult)
                {
                    dlgDataLogs.AddRequestLog(serial, 7, string.Format("پیشنهاد کمیته اعتباری مدیریت شعب در تاریخ {0} طی شناسه نامه {1} به اداره کل اعتبارات ارسال شد", txtDate.GetText("yyyy/MM/dd"), provinceLetterNo));
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
