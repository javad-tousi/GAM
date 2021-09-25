using GAM.Connections;
using GAM.Forms.Reports.Master;
using GAM.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Reports.Library
{
    class IChartLinks
    {
        public static void Run(string branchId, DataRow row, object properties)
        {
            PropertyCollection propertyItems = properties as PropertyCollection;
            DataRow r = row;
            if (propertyItems["ReportNo"].ToString() == "14")
            {
                frmIChartView frm = new frmIChartView();
                frm.Text = propertyItems["ReportName"].ToString();
                frm.Run();

                OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase(string.Format("DB_{0}.mdb", propertyItems["SourceID"].ToString())));
                objConn.Open();
                Application.DoEvents();

                string[] dates = propertyItems["SelectedDates"].ToString().Split(',');
                frm.ProgressMax(dates.Length + 1);

                DataTable tblMaster = new DataTable(dates.Last());
             
                Dictionary<string, double> line1 = new Dictionary<string, double>();

                for (int i = 0; i < dates.Length; i++)
                {
                    OleDbCommand objCmd = new OleDbCommand();
                    objCmd.Connection = objConn;
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = "SELECT SUM([KhalesMasaref]) As MyValue FROM [" + dates[i] + "] WHERE [BranchID] IN (" + branchId + ")";
                    double myValue = Numeral.AnyToDouble(objCmd.ExecuteScalar());
                    line1.Add(UDF.GetDateString(dates[i]), myValue);
                    frm.ProgressOn(i + 1);
                }

                objConn.Close();
                frm.AddSeries(branchId, line1);
                frm.ProgressOn(100);
            }
        }
    }
}
