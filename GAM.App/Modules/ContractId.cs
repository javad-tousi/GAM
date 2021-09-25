using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Modules
{
    class ContractId
    {
        public static bool IsValid(string requestID)
        {
            if (Numeral.IsNumber(requestID) & requestID.Length > 2)
            {
                int chkDigit1 = int.Parse(requestID.Substring(requestID.Length - 2, 2));
                double sumOddNumbers = 0;
                double sumEvenNumbers = 0;

                for (int i = 0; i < requestID.Length - 2; i++)
                {
                    if (i % 2 == 0)
                    {
                        sumOddNumbers += int.Parse(requestID[i].ToString());
                    }
                }

                for (int i = 0; i < requestID.Length - 2; i++)
                {
                    if (i % 2 != 0)
                    {
                        sumEvenNumbers += int.Parse(requestID[i].ToString());
                    }
                }

                double var1 = (sumOddNumbers * 7) + (sumEvenNumbers * 3) + 101;
                double var2 = var1 / 97;
                int chkDigit2 = (int)var1 - (97 * (int)var2);

                if (chkDigit1 == chkDigit2)
                    return true;
            }

            return false;
        }

    }
}
