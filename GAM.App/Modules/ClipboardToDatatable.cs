using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Modules
{
    class ClipboardToDatatable
    {
        public static DataTable GetDataTable()
        {
            var rows = Regex.Split(Clipboard.GetText(), @"\r\n");

            DataTable table = new DataTable();

            for (int row = 0; row < rows.Length; row++)
            {
                if (rows[row].Length > 0)
                {
                    string[] columns = Regex.Split(rows[row], @"\t");

                    for (int col = 0; col < columns.Length; col++)
                    {
                        if (row == 0)
                            table.Columns.Add(columns[col]);
                    }
                    if (row > 0)
                    {
                        table.Rows.Add(columns);
                    }
                }
            }

            return table;
        }
    }
}
