using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GAM.Modules
{
    class ChkSum
    {

        public static string GetFull(string digits)
        {
            if (digits.All(char.IsDigit) & digits.Length > 1)
            {
                int odd = digits.Where(c => c % 2 == 0)
                    .Select(x => int.Parse(x.ToString())).Sum();

                int even = digits.Where(c => c % 2 != 0)
                    .Select(x => int.Parse(x.ToString())).Sum();

                int avg = (odd + even) / 2;
                if (avg < 10)
                    avg = avg * 10;
                return digits + avg;
            }
            return digits;
        }

        public static string GetChkSum(string digits)
        {
            if (digits.All(char.IsDigit) & digits.Length > 1)
            {
                int odd = digits.Where(c => c % 2 == 0)
                    .Select(x => int.Parse(x.ToString())).Sum();

                int even = digits.Where(c => c % 2 != 0)
                    .Select(x => int.Parse(x.ToString())).Sum();

                int avg = (odd + even) / 2;
                if (avg < 10)
                    avg = avg * 10;
                return avg.ToString();
            }
            return string.Empty;
        }

        public static bool Check(string digits)
        {
            if (digits.All(char.IsDigit) & digits.Length > 1)
            {
                string text = digits.Substring(0, digits.Length - 2);
                int odd = text.Where(c => c % 2 == 0)
                    .Select(x => int.Parse(x.ToString())).Sum();

                int even = text.Where(c => c % 2 != 0)
                    .Select(x => int.Parse(x.ToString())).Sum();

                int avg = (odd + even) / 2;
                if (avg < 10)
                    avg = avg * 10;

                return int.Parse(digits.Substring(digits.Length - 2, 2)) == avg;
            }
            return false;
        }

        public static string DelCheck(string digits)
        {
            if (digits.Length > 2)
            {
                return digits.Substring(0, digits.Length - 2);
            }
            return digits;
        }

    }
}
