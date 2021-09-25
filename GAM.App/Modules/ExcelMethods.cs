using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GAM.Modules
{
    class ExcelMethods
    {
        public static string GetColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        public static int ColumnLetterToColumnIndex(string columnLetter)
        {
            columnLetter = columnLetter.ToUpper();
            int sum = 0;

            for (int i = 0; i < columnLetter.Length; i++)
            {
                sum *= 26;
                sum += (columnLetter[i] - 'A' + 1);
            }
            return sum;
        }


        private Point CellAddressToPoint(string cellAddress) 
        {
            StringBuilder columnName = new StringBuilder();
            StringBuilder rowNo = new StringBuilder();
            Point point = new Point();
            foreach (char c in cellAddress)
            {
                if (char.IsLetter(c))
                    columnName.Append(char.IsUpper(c));
                if (char.IsDigit(c))
                    rowNo.Append(c);
            }

            if (columnName.Length > 0 & rowNo.Length > 0)
            {
                int x = ColumnLetterToColumnIndex(columnName.ToString());
                int y = int.Parse(rowNo.ToString()) - 1;
                point = new Point(x, y);
            }

            return point;
        }
    }
}
