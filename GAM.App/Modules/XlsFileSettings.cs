using GAM.Forms.Information.Library;
using GAM.Forms.Settings.Library;
using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using GAM.Connections;
using System.IO;

namespace GAM.Modules
{
    public class XlsFileSettings
    {
        public string TemplateName; //قالب فرم

        public Dictionary<int, string[]> ChartHeaderItems = new Dictionary<int,string[]>();

        public int FirstRow; //اولین ردیفی که می بایست اطلاعات شعبه وارد گردد

        public int[] RepeatedRows; //ردیف های تکرار شونده در بالای صفحه ی چاپ
       
        public string FilePath
        {
            get
            {
                return OLEDB.GetTemplateFile(TemplateName);
            }
        }
    }
}
