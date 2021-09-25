using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace GAM.Modules
{
    class XmlSpreadSheet
    {
        public static DataTable ToDataTable(string fileName)
        {
            try
            {
                DataTable datatable = new DataTable();
                int columnIndex = -1;
                DataRow newRow = null;
                using (XmlReader reader = XmlReader.Create(fileName))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.Name == "Table")
                            {
                                if (datatable.Columns.Count > 0)
                                    break;

                                int columnsCount = int.Parse(reader.GetAttribute("ss:ExpandedColumnCount"));
                                for (int i = 0; i < columnsCount; i++)
                                {
                                    datatable.Columns.Add(ExcelMethods.GetColumnName(i + 1));
                                }
                            }

                            if (datatable.Columns.Count > 0)
                            {
                                if (reader.Name == "Row")
                                {
                                    newRow = datatable.NewRow();
                                    columnIndex = -1;
                                }

                                if (reader.Name == "Cell")
                                {
                                    if (reader.GetAttribute("ss:Index") != null)
                                    {
                                        int index = int.Parse(reader.GetAttribute("ss:Index"));
                                        columnIndex = index - 1;
                                    }
                                    else
                                    {
                                        columnIndex += 1;
                                    }
                                }

                                if (reader.Name == "Data")
                                {
                                    newRow[columnIndex] = reader.ReadInnerXml();
                                }
                            }
                        }

                        if (newRow != null && reader.Name == "Row" & reader.NodeType == XmlNodeType.EndElement)
                        {
                            datatable.Rows.Add(newRow);
                        }
                    }
                }

                return datatable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
