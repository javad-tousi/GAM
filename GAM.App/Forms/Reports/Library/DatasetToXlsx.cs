using GAM.Forms.Information.Library;
using GAM.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GAM.Forms.Reports.Library
{
    class DatasetToXlsx
    {
        public static void ToExcel(XlsFileSettings param, string title, params DataTable[] sheets)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(param.FilePath);

            XmlNodeList worksheets = doc.GetElementsByTagName("Worksheet");

            int _counter = -1;
            foreach (XmlNode worksheet in worksheets)
            {
                _counter++;
                string worksheetName = worksheet.Attributes["ss:Name"].Value;
                XmlNode xtable = worksheet.Cast<XmlNode>().Where(tbl => tbl.LocalName == "Table").FirstOrDefault();
                List<XmlNode> rowsList = xtable.ChildNodes.Cast<XmlNode>().Where(tbl => tbl.LocalName == "Row").ToList();

                if (title.Length > 0)
                    rowsList[0].ChildNodes[0]["Data"].InnerText = title;

                #region Header:
                foreach (var header in param.ChartHeaderItems)
                {
                    foreach (XmlNode headerRow in rowsList[header.Key].ChildNodes)
                    {
                        if (headerRow["Data"] != null)
                        {
                            if (headerRow["Data"].InnerText.StartsWith("head_"))
                            {
                                int headNumber = Numeral.AnyToInt32(headerRow["Data"].InnerText.Replace("head_", ""));
                                if (headNumber <= header.Value.Length)
                                {
                                    headerRow["Data"].InnerText = header.Value[headNumber - 1];
                                }
                            }
                        }
                    }
                }
                #endregion

                if (_counter <= sheets.Length - 1)
                {
                    for (int iRow = 0; iRow < sheets[_counter].Rows.Count; iRow++)
                    {
                        XmlNode newRow = null;
                        if (iRow == 0)
                            newRow = rowsList[param.FirstRow];
                        else
                            newRow = rowsList[param.FirstRow].Clone();

                        for (int iCol = 0; iCol < sheets[_counter].Columns.Count; iCol++)
                        {
                            string dataRowValue = sheets[_counter].Rows[iRow][iCol].ToString();

                            if (Numeral.IsNumber(dataRowValue))
                                newRow.ChildNodes[iCol]["Data"].Attributes["ss:Type"].Value = "Number";
                            else
                                newRow.ChildNodes[iCol]["Data"].Attributes["ss:Type"].Value = "String";

                            newRow.ChildNodes[iCol]["Data"].InnerText = dataRowValue;
                        }
                        xtable.AppendChild(newRow);
                    }
                }

                XmlAttribute att_rowCount = xtable.Attributes["ss:ExpandedRowCount"];
                att_rowCount.InnerText = xtable.ChildNodes.Count.ToString();
            }

            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.Filter = "Excel files (*.xls)|*.xls";
            dlgSave.RestoreDirectory = true;
            dlgSave.FileName = title;
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                doc.Save(dlgSave.FileName);
                System.Diagnostics.Process.Start(dlgSave.FileName);
            }
        }
    }
}
