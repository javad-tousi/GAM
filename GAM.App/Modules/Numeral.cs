using System;
using System.Linq;

public static class Textual 
{
    public static object DBNullForEmptyString(string str)
    {
        if (str.Trim().Length == 0)
            return DBNull.Value;
        return str.Trim();
    }

    public static string RemoveFromLast(string str, int count) 
    {
        return str.Substring(0, str.Length - count);
    }
}

public static class Numeral
{
    public enum IUnitPrice { Default, Rial, MillionRial, MilliardRial };

    /// <summary>
    /// Support any text like 10,256 or $123.250 or ... 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsScalar(string str)
    {
        if (str.Length > 0)
        {
            Double number;
            return Double.TryParse(str, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out number);
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// Support any text like 10,256 or $123.250 or ... 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool IsScalar(object obj)
    {
        if (obj != null)
        {
            Double number;
            return Double.TryParse(obj.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out number);
        }
        else
        {
            return false;
        }
    }



    /// <summary>
    /// Is any text like 10,256 or $123.250 or ... a Long Variable
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsLong(string str)
    {
        if (str.Length > 0)
        {
            long number;
            return long.TryParse(str, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out number);
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// Is any text like 10,256 or $123.250 or ... a Long Variable
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool IsLong(object obj)
    {
        if (obj != null)
        {
            long number;
            return long.TryParse(obj.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out number);
        }
        else
        {
            return false;
        }
    }



    /// <summary>
    /// Is any text like 10,256 or $123.250 or ... a uLong Variable
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsULong(string str)
    {
        if (str.Length > 0)
        {
            ulong number;
            return ulong.TryParse(str, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out number);
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// Is any text like 10,256 or $123.250 or ... a uLong Variable
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool IsULong(object obj)
    {
        if (obj != null)
        {
            ulong number;
            return ulong.TryParse(obj.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out number);
        }
        else
        {
            return false;
        }
    }



    /// <summary>
    /// Is any text like 10,256 or $123.250 or ... a Decimal Variable
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsDecimal(string str)
    {
        if (str.Length > 0)
        {
            long number;
            return !long.TryParse(str, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out number);
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// Is any text like 10,256 or $123.250 or ... a Decimal Variable
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool IsDecimal(object obj)
    {
        if (obj != null)
        {
            long number;
            return !long.TryParse(obj.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out number);
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Is any text like 10,256 or $123.250 or ... a positive number or Negative
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool IsNumber(object obj)
    {
        if (obj != null)
        {
            Double number;
            bool result = Double.TryParse(obj.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out number);
            if (result)
                return true;
        }
        return false;
    }

    /// <summary>
    /// Get first number from any strings like abc23 , 12-book , 999book , 1book23 or ....
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static decimal? ExtractNumbers(string str)
    {
        if (str.Length > 0)
        {
            decimal result = -1;
            decimal.TryParse(System.Text.RegularExpressions.Regex.Match(str, @"\d+").Value, out result);
            return result;
        }

        return null;
    }
    public static string ExtractDigits(string str)
    {
        if (str.Length > 0)
        {
            return new String(str.Where(Char.IsDigit).ToArray());
        }

        return string.Empty;
    }

    public static ulong Parse(string str)
    {
        if (str.Length > 0)
        {
            ulong result = 0;
            ulong.TryParse(str, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out result);
            return result;
        }

        return 0;
    }

    public static ulong AnyToULong(object obj)
    {
        if (obj != null)
        {
            ulong result = 0;
            ulong.TryParse(obj.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out result);
            return result;
        }

        return 0;
    }
    public static ulong AnyToULong(object obj, IUnitPrice currency)
    {
        if (obj != null)
        {
            ulong result = 0;
            ulong.TryParse(obj.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out result);
            switch (currency)
            {
                case IUnitPrice.MillionRial:
                    return result / 1000000;
                case IUnitPrice.MilliardRial:
                    return result / 1000000000;
                default:
                    return result;
            }
        }

        return 0;
    }


    public static long AnyToLong(object obj)
    {
        if (obj != null)
        {
            long result = 0;
            long.TryParse(obj.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out result);
            return result;
        }

        return 0;
    }
    public static long AnyToLong(object obj, IUnitPrice currency)
    {
        if (obj != null)
        {
            long result = 0;
            long.TryParse(obj.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out result);
            switch (currency)
            {
                case IUnitPrice.MillionRial:
                    return result / 1000000;
                case IUnitPrice.MilliardRial:
                    return result / 1000000000;
                default:
                    return result;
            }
        }

        return 0;
    }
   
    public static Int32 AnyToInt32(object obj)
    {
        if (obj != null)
        {
            Int32 result = 0;
            Int32.TryParse(obj.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out result);
            return result;
        }

        return 0;
    }

    public static Int32? AnyToInt32Nullable(object obj)
    {
        if (obj != null && obj.ToString().Length > 0)
        {
            Int32 result = 0;
            Int32.TryParse(obj.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out result);
            return result;
        }

        return null;
    }

    public static double AnyToDouble(object obj)
    {
        if (obj != null)
        {
            double result = 0;
            double.TryParse(obj.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out result);
            return result;
        }

        return 0;
    }

    public static double? AnyToDouble(object obj, IUnitPrice newUnitAmount)
    {
        if (obj != null)
        {
            double result = 0;
            double.TryParse(obj.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out result);
            switch (newUnitAmount)
            {
                case IUnitPrice.MillionRial:
                    return result / 1000000;
                case IUnitPrice.MilliardRial:
                    return result / 1000000000;
                default:
                    return result;
            }
        }

        return null;
    }

    public static double? AnyToDouble(object obj, IUnitPrice unitAmount, IUnitPrice newUnitAmount)
    {
        if (obj != null)
        {
            double result = 0;
            double.TryParse(obj.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out result);
            if (unitAmount == IUnitPrice.Rial)
            {
                if (newUnitAmount == IUnitPrice.Rial)
                {
                    return result;
                };
                if (newUnitAmount == IUnitPrice.MillionRial)
                {
                    return result / 1000000;
                };
                if (newUnitAmount == IUnitPrice.MilliardRial)
                {
                    return result / 1000000000;
                };
            }
            if (unitAmount == IUnitPrice.MillionRial)
            {
                if (newUnitAmount == IUnitPrice.Rial)
                {
                    return result * 1000000;
                };
                if (newUnitAmount == IUnitPrice.MillionRial)
                {
                    return result;
                };
                if (newUnitAmount == IUnitPrice.MilliardRial)
                {
                    return result / 1000;
                };
            }
            if (unitAmount == IUnitPrice.MilliardRial)
            {
                if (newUnitAmount == IUnitPrice.Rial)
                {
                    return result * 1000000000;
                };
                if (newUnitAmount == IUnitPrice.MillionRial)
                {
                    return result / 1000;
                };
                if (newUnitAmount == IUnitPrice.MilliardRial)
                {
                    return result;
                };
            }

            return result;
        }
        return null;
    }

    public static decimal AnyToDecimal(object obj)
    {
        if (obj != null)
        {
            decimal result = 0;
            decimal.TryParse(obj.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out result);
            return result;
        }

        return 0;
    }

    public static IUnitPrice StringToIUnitPrice(string text) 
    {
        switch (text)
        {
            case "ریال":
                return IUnitPrice.Rial;
            case "Rial":
                return IUnitPrice.Rial;
            case "میلیون ریال":
                return IUnitPrice.MillionRial;
            case "MillionRial":
                return IUnitPrice.MillionRial;
            case "میلیارد ریال":
                return IUnitPrice.MilliardRial;
            case "MilliardRial":
                return IUnitPrice.MilliardRial;
            default:
                return IUnitPrice.Default;
        }
    }

    public static string IUnitPriceToString(IUnitPrice iUnitPrice)
    {
        switch (iUnitPrice)
        {
            case IUnitPrice.Rial:
                return "ریال";
            case IUnitPrice.MillionRial:
                return "میلیون ریال";
            case IUnitPrice.MilliardRial:
                return "میلیارد ریال";
            default:
                return "پیش فرض";
        }
    }
    public static string IUnitPriceToString(string enUnitPrice)
    {
        switch (enUnitPrice)
        {
            case "Rial":
                return "ریال";
            case "MillionRial":
                return "میلیون ریال";
            case "MilliardRial":
                return "میلیارد ریال";
            default:
                return "پیش فرض";
        }
    }


    /// <summary>
    /// Converts an English number to it's Farsi value.
    /// </summary>
    /// <remarks>This method only converts the numbers in a string, and does not convert any non-numeric characters.</remarks>
    /// <param name="number"></param>
    /// <returns></returns>
    public static string ToFarsi(string text)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        foreach (char c in text)
        {
            switch (c)
            {
                case '0':
                    sb.Append("۰");
                    break;
                case '1':
                    sb.Append("۱");
                    break;
                case '2':
                    sb.Append("۲");
                    break;
                case '3':
                    sb.Append("۳");
                    break;
                case '4':
                    sb.Append("۴");
                    break;
                case '5':
                    sb.Append("۵");
                    break;
                case '6':
                    sb.Append("۶");
                    break;
                case '7':
                    sb.Append("۷");
                    break;
                case '8':
                    sb.Append("۸");
                    break;
                case '9':
                    sb.Append("۹");
                    break;
                default:
                    sb.Append(c);
                    break;
            }
        }

        return (sb.ToString());
    }

    public static string ToEnglish(string text)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        foreach (char c in text)
        {
            switch (c)
            {
                case '۰':
                    sb.Append("0");
                    break;
                case '۱':
                    sb.Append("1");
                    break;
                case '۲':
                    sb.Append("2");
                    break;
                case '۳':
                    sb.Append("3");
                    break;
                case '۴':
                    sb.Append("4");
                    break;
                case '۵':
                    sb.Append("5");
                    break;
                case '۶':
                    sb.Append("6");
                    break;
                case '۷':
                    sb.Append("7");
                    break;
                case '۸':
                    sb.Append("8");
                    break;
                case '۹':
                    sb.Append("9");
                    break;
                default:
                    sb.Append(c);
                    break;
            }
        }

        return (sb.ToString());
    }


    public static double ZeroForOverflowValue(object obj)
    {
        if (obj != null)
        {
            double result = 0;
            double.TryParse(obj.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out result);
            if (double.IsInfinity(result) | double.IsNaN(result))
                return 0;
            else 
                return result;
        }
        return 0;
    }

    public static object DBNullForNullValue(object obj)
    {
        if (obj != null && obj.ToString().Length > 0)
        {
            double result = 0;
            double.TryParse(obj.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out result);
            if (double.IsInfinity(result) | double.IsNaN(result))
                return 0;
            else
                return result;
        }
        return DBNull.Value;
    }
    public static object DBNullForZeroValue(object obj)
    {
        if (obj != null)
        {
            double result = 0;
            double.TryParse(obj.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out result);
            if (double.IsInfinity(result) | double.IsNaN(result))
                return DBNull.Value;
            else
            {
                if (result == 0)
                    return DBNull.Value;
                return result;
            }
        }
        return DBNull.Value;
    }

    public static int? ToInt32Nullable(string str)
    {
        int i = 0;
        return (int.TryParse(str, out i) ? i : (int?)null);
    }
   
    public static long? ToLongNullable(object str)
    {
        long i = 0;
        return (long.TryParse(str.ToString(), out i) ? i : (long?)null);
    }

    public static ulong? ToULongNullable(object str)
    {
        ulong i = 0;
        return (ulong.TryParse(str.ToString(), out i) ? i : (ulong?)null);
    }

    public static double? ToDoubleNullable(string str)
    {
        double i = 0;
        return (double.TryParse(str, out i) ? i : (double?)null);
    }

    public static decimal? ToDecimalNullable(string str)
    {
        decimal i = 0;
        return (decimal.TryParse(str, out i) ? i : (decimal?)null);
    }

}