using System;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Reflection;
using System.Linq;
using System.Text.RegularExpressions;

[TypeConverter("FarsiLibrary.Win.Design.PersianDateTypeConverter")]
[Serializable]
public sealed class PersianDate :
    IFormattable,
    ICloneable,
    IComparable,
    IComparable<PersianDate>,
    IComparer,
    IComparer<PersianDate>,
    IEquatable<PersianDate>
{

    #region Fields

    private int year;
    private int month;
    private int day;
    private int hour;
    private int minute;
    private int second;
    private int millisecond;
    private readonly TimeSpan time;
    private static readonly PersianCalendar pc;
    [NonSerialized]
    public static DateTime MinValue;

    [NonSerialized]
    public static DateTime MaxValue;

    #endregion

    #region Static Ctor

    /// <summary>
    /// Static constructor initializes Now property of PersianDate and Min/Max values.
    /// </summary>
    static PersianDate()
    {
        MinValue = new DateTime(196037280000000000L); // 12:00:00.000 AM, 22/03/0622
        MaxValue = DateTime.MaxValue;
        pc = new PersianCalendar();
    }

    #endregion

    #region Props

    /// <summary>
    /// Current date/time in PersianDate format.
    /// </summary>
    [Browsable(false)]
    [Description("Current date/time in PersianDate format")]
    public static PersianDate Now
    {
        get { return PersianDateConverter.ToPersianDate(DateTime.Now); }
    }

    /// <summary>
    /// Year value of PersianDate.
    /// </summary>
    [Description("Year value of PersianDate")]
    [NotifyParentProperty(true)]
    public int Year
    {
        get { return year; }
        set
        {
            CheckYear(value);
            year = value;
        }
    }

    /// <summary>
    /// Month value of PersianDate.
    /// </summary>
    [Description("Month value of PersianDate")]
    [NotifyParentProperty(true)]
    public int Month
    {
        get { return month; }
        set
        {
            CheckMonth(value);
            month = value;
        }
    }

    /// <summary>
    /// Day value of PersianDate.
    /// </summary>
    [Description("Day value of PersianDate")]
    [NotifyParentProperty(true)]
    public int Day
    {
        get { return day; }
        set
        {
            CheckDay(Year, Month, value);
            day = value;
        }
    }

    /// <summary>
    /// Hour value of PersianDate.
    /// </summary>
    [Description("Hour value of PersianDate")]
    [NotifyParentProperty(true)]
    public int Hour
    {
        get { return hour; }
        set
        {
            CheckHour(value);
            hour = value;
        }
    }

    /// <summary>
    /// Minute value of PersianDate.
    /// </summary>
    [Description("Minute value of PersianDate")]
    [NotifyParentProperty(true)]
    public int Minute
    {
        get { return minute; }
        set
        {
            CheckMinute(value);
            minute = value;
        }
    }

    /// <summary>
    /// Second value of PersianDate.
    /// </summary>
    [Description("Second value of PersianDate")]
    [NotifyParentProperty(true)]
    public int Second
    {
        get { return second; }
        set
        {
            CheckSecond(value);
            second = value;
        }
    }

    /// <summary>
    /// Millisecond value of PersianDate.
    /// </summary>
    [Description("Millisecond value of PersianDate")]
    [NotifyParentProperty(true)]
    public int Millisecond
    {
        get { return millisecond; }
        set
        {
            CheckMillisecond(value);
            millisecond = value;
        }
    }

    /// <summary>
    /// Time value of PersianDate in TimeSpan format.
    /// </summary>
    [Browsable(false)]
    [Description("Time value of PersianDate in TimeSpan format.")]
    public TimeSpan Time
    {
        get { return time; }
    }

    /// <summary>
    /// Returns the DayOfWeek of the date instance
    /// </summary>
    public DayOfWeek DayOfWeek
    {
        get
        {
            DateTime dt = this;
            return dt.DayOfWeek;
        }
    }

    /// <summary>
    /// Returns the DayOfWeek of the date instance
    /// </summary>
    public string WeekDayName
    {
        get
        {
            DateTime dt = this;
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    return "شنبه";
                case DayOfWeek.Sunday:
                    return "یکشنبه";
                case DayOfWeek.Monday:
                    return "دوشنبه";
                case DayOfWeek.Tuesday:
                    return "سه شنبه";
                case DayOfWeek.Wednesday:
                    return "چهارشنبه";
                case DayOfWeek.Thursday:
                    return "پنجشنبه";
                case DayOfWeek.Friday:
                    return "جمعه";
                default:
                    return "";
            }  
        }
    }
    /// <summary>
    /// Localized name of PersianDate months.
    /// </summary>
    [Browsable(false)]
    [Description("Localized name of PersianDate months")]
    public string LocalizedMonthName
    {
        get { return PersianMonthNames.Default[month - 1]; }
    }

    /// <summary>
    /// Weekday names of this instance in localized format.
    /// </summary>
    [Browsable(false)]
    [Description("Weekday names of this instance in localized format.")]
    public string LocalizedWeekDayName
    {
        get { return PersianDateConverter.DayOfWeek(this); }
    }

    /// <summary>
    /// Number of days in this month.
    /// </summary>
    [Browsable(false)]
    [Description("Number of days in this month")]
    public int MonthDays
    {
        get
        {
            if (!IsLeapYear() & month == 12)
            {
                return 29;
            }
            else
            {
                return PersianDateConverter.MonthDays(month);
            }
        }
    }

    [Browsable(false)]
    public bool IsNull
    {
        get { return Year <= MinValue.Year && Month <= MinValue.Month && Day <= MinValue.Day; }
    }

    public static PersianDateConvert Convert
    {
        get { return new PersianDateConvert(); }
    }
    #endregion

    #region Ctor

    public PersianDate(DateTime dt)
    {
        Assign(PersianDateConverter.ToPersianDate(dt));
    }

    public PersianDate()
    {
        PersianDate now = Now;
        year = now.year;
        month = now.Month;
        day = now.Day;
        hour = now.Hour;
        minute = now.Minute;
        second = now.Second;
        millisecond = now.Millisecond;
        time = now.Time;
    }

    /// <summary>
    /// Constructs a PersianDate instance with serial date provided as a string. The provided string should be in format 'yyyymmdd'.
    /// </summary>
    /// <exception cref="InvalidPersianDateException"></exception>
    /// <param name="Date"></param>
    public PersianDate(int serial)
    {
        string strValue = serial.ToString();

        if (strValue.Length == 8)
        {
            PersianDate now = Now;
            year = int.Parse(strValue.Substring(0, 4));
            month = int.Parse(strValue.Substring(4, 2));
            day = int.Parse(strValue.Substring(6, 2));
            hour = now.Hour;
            minute = now.Minute;
            second = now.Second;
            millisecond = now.Millisecond;
            time = now.Time;
        }
    }

    /// <summary>
    /// Constructs a PersianDate instance with values provided in datetime string. You should
    /// include Date part only in <c>Date</c> and set the Time of the instance as a <c>TimeSpan</c>.
    /// </summary>
    /// <exception cref="InvalidPersianDateException"></exception>
    /// <param name="Date"></param>
    /// <param name="time"></param>
    public PersianDate(string Date, TimeSpan time)
    {
        PersianDate pd = Parse(Date);

        pd.Hour = time.Hours;
        pd.Minute = time.Minutes;
        pd.Second = time.Seconds;
        pd.Millisecond = time.Milliseconds;

        Assign(pd);
    }

    /// <summary>
    /// Constructs a PersianDate instance with values provided as a string. The provided string should be in format 'yyyy/mm/dd'.
    /// </summary>
    /// <exception cref="InvalidPersianDateException"></exception>
    /// <param name="Date"></param>
    public PersianDate(string Date)
    {
        if (Date.Length >= 8)
            Assign(Parse(Date));
    }

    /// <summary>
    /// Constructs a PersianDate instance with values specified as <c>Integer</c> and default second and millisecond set to zero.
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    public PersianDate(int year, int month, int day, int hour, int minute)
        : this(year, month, day, hour, minute, 0)
    {
    }

    /// <summary>
    /// Constructs a PersianDate instance with values specified as <c>Integer</c> and default millisecond set to zero.
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    public PersianDate(int year, int month, int day, int hour, int minute, int second)
        : this(year, month, day, hour, minute, second, 0)
    {
    }

    /// <summary>
    /// Constructs a PersianDate instance with values specified as <c>Integer</c>.
    /// </summary>
    /// <exception cref="InvalidPersianDateException"></exception>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    public PersianDate(int year, int month, int day, int hour, int minute, int second, int millisecond)
    {
        CheckYear(year);
        CheckMonth(month);
        CheckDay(year, month, day);
        CheckHour(hour);
        CheckMinute(minute);
        CheckSecond(second);
        CheckMillisecond(millisecond);

        this.year = year;
        this.month = month;
        this.day = day;
        this.hour = hour;
        this.minute = minute;
        this.second = second;
        this.millisecond = millisecond;

        time = new TimeSpan(0, hour, minute, second, millisecond);
    }

    /// <summary>
    /// Constructs a PersianDate instance with values specified as <c>Integer</c>. Time value of this instance is set to <c>DateTime.Now</c>.
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    public PersianDate(int year, int month, int day)
    {
        CheckYear(year);
        CheckMonth(month);
        CheckDay(year, month, day);

        this.year = year;
        this.month = month;
        this.day = day;
        this.hour = 0;
        this.minute = 0;
        this.second = 0;
        this.millisecond = 0;
        this.time = new TimeSpan(0, hour, minute, second, millisecond);
    }

    #endregion

    #region Private Check Methods

    private static void CheckYear(int YearNo)
    {
        if (YearNo < 1 || YearNo > 9999)
        {
            throw new InvalidPersianDateException(FALocalizeManager.Instance.GetLocalizer().GetLocalizedString(StringID.PersianDate_InvalidYear), YearNo);
        }
    }

    private static void CheckMonth(int MonthNo)
    {
        if (MonthNo > 12 || MonthNo < 1)
        {
            throw new InvalidPersianDateException(FALocalizeManager.Instance.GetLocalizer().GetLocalizedString(StringID.PersianDate_InvalidMonth), MonthNo);
        }
    }

    private void CheckDay(int YearNo, int MonthNo, int DayNo)
    {
        if (MonthNo < 6 && DayNo > 31)
            throw new InvalidPersianDateException(FALocalizeManager.Instance.GetLocalizer().GetLocalizedString(StringID.PersianDate_InvalidDay), DayNo);

        if (MonthNo > 6 && DayNo > 30)
            throw new InvalidPersianDateException(FALocalizeManager.Instance.GetLocalizer().GetLocalizedString(StringID.PersianDate_InvalidDay), DayNo);

        if (MonthNo == 12 && DayNo > 29)
        {
            if (!pc.IsLeapDay(YearNo, MonthNo, DayNo) || DayNo > 30)
                throw new InvalidPersianDateException(FALocalizeManager.Instance.GetLocalizer().GetLocalizedString(StringID.PersianDate_InvalidDay), DayNo);
        }
    }

    private static void CheckHour(int HourNo)
    {
        if (HourNo > 24 || HourNo < 0)
        {
            throw new InvalidPersianDateException(FALocalizeManager.Instance.GetLocalizer().GetLocalizedString(StringID.PersianDate_InvalidHour), HourNo);
        }
    }

    private static void CheckMinute(int MinuteNo)
    {
        if (MinuteNo > 60 || MinuteNo < 0)
        {
            throw new InvalidPersianDateException(FALocalizeManager.Instance.GetLocalizer().GetLocalizedString(StringID.PersianDate_InvalidMinute), MinuteNo);
        }
    }

    private static void CheckSecond(int SecondNo)
    {
        if (SecondNo > 60 || SecondNo < 0)
        {
            throw new InvalidPersianDateException(FALocalizeManager.Instance.GetLocalizer().GetLocalizedString(StringID.PersianDate_InvalidSecond));
        }
    }

    private static void CheckMillisecond(int MillisecondNo)
    {
        if (MillisecondNo < 0 || MillisecondNo > 1000)
        {
            throw new InvalidPersianDateException(FALocalizeManager.Instance.GetLocalizer().GetLocalizedString(StringID.PersianDate_InvalidMillisecond));
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Assigns an instance of PersianDate's values to this instance.
    /// </summary>
    /// <param name="pd"></param>
    internal void Assign(PersianDate pd)
    {

        Year = pd.Year;
        Month = pd.Month;
        Day = pd.Day;
        Hour = pd.Hour;
        Minute = pd.Minute;
        Second = pd.Second;
    }

    /// <summary>
    /// Returns true is current PersianDate is leap year.
    /// </summary>
    /// <returns></returns>
    public bool IsLeapYear()
    {
        PersianCalendar jc = new PersianCalendar();
        if (jc.IsLeapYear(year))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Returns a string representation of current PersianDate value.
    /// </summary>
    /// <returns></returns>
    public string ToWritten()
    {
        return string.Format("{0} {1} {2} {3}", LocalizedWeekDayName, day, LocalizedMonthName, year);
    }

    /// <summary>
    /// Returns a pretty representation of this date instance
    /// </summary>
    /// <returns></returns>
    public DateTime ToDateTime()
    {
        System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
        DateTime dt = pc.ToDateTime(Year, Month, Day, hour, minute, second, millisecond);
        return dt;
    }

    public DateTime? ToGregorian()
    {
        if (this != null)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            DateTime dt = pc.ToDateTime(Year, Month, Day, hour, minute, second, millisecond);
            return DateTime.Parse(dt.ToString(CultureInfo.InvariantCulture));
        }
        else
            return null;
    }

    public PersianDate AddDays(double days)
    {
        System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
        DateTime dt = pc.ToDateTime(Year, Month, Day, hour, minute, second, millisecond);
        return new PersianDate(dt.AddDays(days));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Get serial date in format 'yyyymmdd'</returns>
    public int ToSerial()
    {
        if (Year > 0 & Month > 0 & Day > 0)
            return int.Parse(string.Format("{0}{1}{2}", Year, Month.ToString("D2"), Day.ToString("D2")));
        else
            return 0;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns>Get standard date in format 'yyyy/mm/dd'</returns>
    public string ToStandard()
    {
        if (Year > 0 & Month > 0 & Day > 0)
            return string.Format("{0}/{1}/{2}", Year, Month.ToString("D2"), Day.ToString("D2"));
        else
            return string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Get standard date in format 'yyyy-mm-dd'</returns>
    public string ToStandard(char divider)
    {
        if (Year > 0 & Month > 0 & Day > 0)
            return string.Format("{0}{3}{1}{3}{2}", Year, Month.ToString("D2"), Day.ToString("D2"), divider);
        else
            return string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Get standard date in format 'dd-mm-yyyy'</returns>
    public string ToStandard(bool rightoLeft, char divider)
    {
        if (Year > 0 & Month > 0 & Day > 0)
            return string.Format("{2}{3}{1}{3}{0}", Year, Month.ToString("D2"), Day.ToString("D2"), divider);
        else
            return string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Get standard date in format 'dd/mm/yyyy'</returns>
    public string ToStandard(bool rightoLeft)
    {
        if (Year > 0 & Month > 0 & Day > 0)
            return string.Format("{2}/{1}/{0}", Year, Month.ToString("D2"), Day.ToString("D2"));
        else
            return string.Empty;
    }

    #endregion

    #region Parse Methods

    /// <summary>
    /// Tries to parse a string value into a PersianDate instance. 
    /// Value can only be in 'yyyy/mm/dd' format.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="persianDate"></param>
    /// <returns></returns>
    public static bool TryParse(string value, out PersianDate persianDate)
    {
        persianDate = null;

        try
        {
            persianDate = Parse(value);
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Parse a string value into a PersianDate instance.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static PersianDate Parse(string value)
    {
        if (!string.IsNullOrEmpty(value) & value.Length >= 8)
        {
            try
            {
                int val = 0;
                int year = 0;
                int month = 0;
                int day = 0;
                if (int.TryParse(value, out val))
                {
                    year = int.Parse(value.Substring(0, 4));
                    month = int.Parse(value.Substring(4, 2));
                    day = int.Parse(value.Substring(6, 2));
                   
                    //Fixed: If year is 2 digit, it is probably 13xx.
                    if (year < 100)
                        year = 1300 + year;

                    return new PersianDate(year, month, day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
                }
                else
                {
                    DateTime dt = DateTime.Parse(value, CultureHelper.PersianCulture, DateTimeStyles.None);

                    year = pc.GetYear(dt);
                    month = pc.GetMonth(dt);
                    day = pc.GetDayOfMonth(dt);

                    //Fixed: If year is 2 digit, it is probably 13xx.
                    if (year < 100)
                        year = 1300 + year;

                    return new PersianDate(year, month, day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
                }
            }
            catch
            {
                throw new InvalidPersianDateFormatException("Can not parse the value. Format is incorrect.");
            }
        }

        return null;
    }
    public static PersianDate Parse(int serial)
    {
        string value = serial.ToString();
        if (value.ToString().Length == 8)
        {
            try
            {
                int val = 0;
                int year = 0;
                int month = 0;
                int day = 0;
                if (int.TryParse(value, out val))
                {
                    year = int.Parse(value.Substring(0, 4));
                    month = int.Parse(value.Substring(4, 2));
                    day = int.Parse(value.Substring(6, 2));

                    //Fixed: If year is 2 digit, it is probably 13xx.
                    if (year < 100)
                        year = 1300 + year;

                    return new PersianDate(year, month, day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);

                }
            }
            catch
            {
                throw new InvalidPersianDateFormatException("Can not parse the value. Format is incorrect.");
            }
        }

        throw new InvalidPersianDateFormatException("Can not parse the value. Format is incorrect.");
    }

    #endregion

    #region Overrides

    /// <summary>
    /// Returns Date in 'yyyy/mm/dd' string format.
    /// </summary>
    /// <returns>string representation of evaluated Date.</returns>
    /// <example>An example on how to get the written form of a Date.
    /// <code>
    ///		class MyClass {
    ///		   public static void Main()
    ///		   {	
    ///				Console.WriteLine(PersianDate.Now.ToString());
    ///		   }
    ///		}
    /// </code>
    /// </example>
    /// <seealso cref="ToWritten"/>
    public override string ToString()
    {
        return ToString("G", null);
    }

    #endregion

    #region Operators

    /// <summary>
    /// Compares two instance of the PersianDate for the specified operator.
    /// </summary>
    /// <param name="date1"></param>
    /// <param name="date2"></param>
    /// <returns></returns>
    public static bool operator ==(PersianDate date1, PersianDate date2)
    {
        if ((date1 as object) == null && (date2 as object) == null)
            return true;

        if ((date1 as object) == null)
            return false;

        if ((date2 as object) == null)
            return false;

        return date1.Year == date2.Year &&
               date1.Month == date2.Month &&
               date1.Day == date2.Day &&
               date1.Hour == date2.Hour &&
               date1.Minute == date2.Minute &&
               date1.Second == date2.Second &&
               date1.Millisecond == date2.Millisecond;
    }

    /// <summary>
    /// Compares two instance of the PersianDate for the specified operator.
    /// </summary>
    /// <param name="date1"></param>
    /// <param name="date2"></param>
    /// <returns></returns>
    public static bool operator !=(PersianDate date1, PersianDate date2)
    {
        if ((date1 as object) == null && (date2 as object) == null)
            return false;

        if ((date1 as object) == null)
            return true;

        if ((date2 as object) == null)
            return true;

        return date1.Year != date2.Year ||
               date1.Month != date2.Month ||
               date1.Day != date2.Day ||
               date1.Hour != date2.Hour ||
               date1.Minute != date2.Minute ||
               date1.Second != date2.Second ||
               date1.Millisecond != date2.Millisecond;
    }

    /// <summary>
    /// Compares two instance of the PersianDate for the specified operator.
    /// </summary>
    /// <param name="date1"></param>
    /// <param name="date2"></param>
    /// <returns></returns>
    public static bool operator >(PersianDate date1, PersianDate date2)
    {
        if ((date1 as object) == null && (date2 as object) == null)
            return false;

        if ((date1 as object) == null && (date2 as object) != null)
            throw new InvalidOperationException("date can not be null.");

        if ((date2 as object) == null && (date1 as object) != null)
            throw new InvalidOperationException("date can not be null.");

        if (date1.Year > date2.Year)
            return true;

        if (date1.Year == date2.Year &&
            date1.Month > date2.Month)
            return true;

        if (date1.Year == date2.Year &&
            date1.Month == date2.Month &&
            date1.Day > date2.Day)
            return true;

        if (date1.Year == date2.Year &&
            date1.Month == date2.Month &&
            date1.Day == date2.Day &&
            date1.Hour > date2.Hour)
            return true;

        if (date1.Year == date2.Year &&
            date1.Month == date2.Month &&
            date1.Day == date2.Day &&
            date1.Hour == date2.Hour &&
            date1.Minute > date2.Minute)
            return true;

        if (date1.Year == date2.Year &&
            date1.Month == date2.Month &&
            date1.Day == date2.Day &&
            date1.Hour == date2.Hour &&
            date1.Minute == date2.Minute &&
            date1.Second > date2.Second)
            return true;

        if (date1.Year == date2.Year &&
            date1.Month == date2.Month &&
            date1.Day == date2.Day &&
            date1.Hour == date2.Hour &&
            date1.Minute == date2.Minute &&
            date1.Second == date2.Second &&
            date1.Millisecond > date2.Millisecond)
            return true;

        return false;
    }

    /// <summary>
    /// Compares two instance of the PersianDate for the specified operator.
    /// </summary>
    /// <param name="date1"></param>
    /// <param name="date2"></param>
    /// <returns></returns>
    public static bool operator <(PersianDate date1, PersianDate date2)
    {
        if ((date1 as object) == null && (date2 as object) == null)
            return false;

        if ((date1 as object) == null && (date2 as object) != null)
            throw new InvalidOperationException("date can not be null.");

        if ((date2 as object) == null && (date1 as object) != null)
            throw new InvalidOperationException("date can not be null.");

        if (date1.Year < date2.Year)
            return true;

        if (date1.Year == date2.Year &&
            date1.Month < date2.Month)
            return true;

        if (date1.Year == date2.Year &&
            date1.Month == date2.Month &&
            date1.Day < date2.Day)
            return true;

        if (date1.Year == date2.Year &&
            date1.Month == date2.Month &&
            date1.Day == date2.Day &&
            date1.Hour < date2.Hour)
            return true;

        if (date1.Year == date2.Year &&
            date1.Month == date2.Month &&
            date1.Day == date2.Day &&
            date1.Hour == date2.Hour &&
            date1.Minute < date2.Minute)
            return true;

        if (date1.Year == date2.Year &&
            date1.Month == date2.Month &&
            date1.Day == date2.Day &&
            date1.Hour == date2.Hour &&
            date1.Minute == date2.Minute &&
            date1.Second < date2.Second)
            return true;

        if (date1.Year == date2.Year &&
            date1.Month == date2.Month &&
            date1.Day == date2.Day &&
            date1.Hour == date2.Hour &&
            date1.Minute == date2.Minute &&
            date1.Second == date2.Second &&
            date1.Millisecond < date2.Millisecond)
            return true;

        return false;
    }

    /// <summary>
    /// Compares two instance of the PersianDate for the specified operator.
    /// </summary>
    /// <param name="date1"></param>
    /// <param name="date2"></param>
    /// <returns></returns>
    public static bool operator <=(PersianDate date1, PersianDate date2)
    {
        return (date1 < date2) || (date1 == date2);
    }

    /// <summary>
    /// Compares two instance of the PersianDate for the specified operator.
    /// </summary>
    /// <param name="date1"></param>
    /// <param name="date2"></param>
    /// <returns></returns>
    public static bool operator >=(PersianDate date1, PersianDate date2)
    {
        return (date1 > date2) || (date1 == date2);
    }

    /// <summary>
    /// Serves as a hash function for a particular type. System.Object.GetHashCode() is suitable for use in hashing algorithms and data structures like a hash table.
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return ToString("s").GetHashCode();
    }

    /// <summary>
    /// Determines whether the specified System.Object instances are considered equal.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
        if (obj is PersianDate)
            return this == (PersianDate)obj;

        return false;
    }

    #endregion

    #region ICloneable Members

    object ICloneable.Clone()
    {
        return new PersianDate(Year, Month, Day, Hour, Minute, Second, Millisecond);
    }

    #endregion

    #region Implicit Casting

    public static implicit operator DateTime(PersianDate pd)
    {
        return PersianDateConverter.ToGregorianDateTime(pd);
    }

    public static implicit operator PersianDate(DateTime dt)
    {
        if (dt > pc.MaxSupportedDateTime || dt < pc.MinSupportedDateTime)
            return null;

        return PersianDateConverter.ToPersianDate(dt);
    }

    /// <summary>
    /// Converts a nullable DateTime to PersianDate.
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static implicit operator PersianDate(DateTime? dt)
    {
        if (dt.HasValue)
        {
            return PersianDateConverter.ToPersianDate(dt.Value);
        }

        return null;
    }

    #endregion

    #region ICompareable Interface

    ///<summary>
    ///Compares the current instance with another object of the same type.
    ///</summary>
    ///
    ///<returns>
    ///A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance is less than obj. Zero This instance is equal to obj. Greater than zero This instance is greater than obj. 
    ///</returns>
    ///
    ///<param name="obj">An object to compare with this instance. </param>
    ///<exception cref="T:System.ArgumentException">obj is not the same type as this instance. </exception><filterpriority>2</filterpriority>
    int IComparable.CompareTo(object obj)
    {
        if (!(obj is PersianDate))
            throw new InvalidOperationException("Comparing value is not of type PersianDate.");

        var pd = (PersianDate)obj;

        if (pd < this)
            return 1;

        if (pd > this)
            return -1;

        return 0;
    }

    #endregion

    #region IComparer

    ///<summary>
    ///Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
    ///</summary>
    ///
    ///<returns>
    ///Value Condition Less than zero x is less than y. Zero x equals y. Greater than zero x is greater than y. 
    ///</returns>
    ///
    ///<param name="y">The second object to compare. </param>
    ///<param name="x">The first object to compare. </param>
    ///<exception cref="T:System.ArgumentException">Neither x nor y implements the <see cref="T:System.IComparable"></see> interface.-or- x and y are of different types and neither one can handle comparisons with the other. </exception><filterpriority>2</filterpriority>
    ///<exception cref="T:System.ApplicationException">Either x or y is a null reference</exception>
    int IComparer.Compare(object x, object y)
    {
        if (x == null || y == null)
            throw new InvalidOperationException("Invalid PersianDate comparer.");

        if (!(x is PersianDate))
            throw new InvalidOperationException("x value is not of type PersianDate.");

        if (!(y is PersianDate))
            throw new InvalidOperationException("y value is not of type PersianDate.");

        var pd1 = (PersianDate)x;
        var pd2 = (PersianDate)y;

        if (pd1 > pd2)
            return 1;

        if (pd1 < pd2)
            return -1;

        return 0;
    }

    #endregion

    #region IComparer<T> Implementation

    ///<summary>
    ///Compares the current object with another object of the same type.
    ///</summary>
    ///
    ///<returns>
    ///A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the other parameter.Zero This object is equal to other. Greater than zero This object is greater than other. 
    ///</returns>
    ///
    ///<param name="other">An object to compare with this object.</param>
    public int CompareTo(PersianDate other)
    {
        if (other < this)
            return 1;

        if (other > this)
            return -1;

        return 0;
    }

    ///<summary>
    ///Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
    ///</summary>
    ///
    ///<returns>
    ///Value Condition Less than zerox is less than y.Zerox equals y.Greater than zero x is greater than y.
    ///</returns>
    ///
    ///<param name="y">The second object to compare.</param>
    ///<param name="x">The first object to compare.</param>
    public int Compare(PersianDate x, PersianDate y)
    {
        if (x > y)
            return 1;

        if (x < y)
            return -1;

        return 0;
    }

    #endregion

    #region IEquatable<T>

    ///<summary>
    ///Indicates whether the current object is equal to another object of the same type.
    ///</summary>
    ///
    ///<returns>
    ///true if the current object is equal to the other parameter; otherwise, false.
    ///</returns>
    ///
    ///<param name="other">An object to compare with this object.</param>
    public bool Equals(PersianDate other)
    {
        return this == other;
    }

    #endregion

    #region IFormattable

    /// <summary>
    /// Returns string representation of this instance in default format.
    /// </summary>
    /// <param name="format"></param>
    /// <returns></returns>
    public string ToString(string format)
    {
        return ToString(format, null);
    }

    /// <summary>
    /// Returns string representation of this instance and format it using the <see cref="IFormatProvider"/> instance.
    /// </summary>
    /// <param name="formatProvider"></param>
    /// <returns></returns>
    public string ToString(IFormatProvider formatProvider)
    {
        return ToString(null, formatProvider);
    }

    /// <summary>
    /// Returns string representation of this instance in desired format, or using provided <see cref="IFormatProvider"/> instance.
    /// </summary>
    /// <param name="format"></param>
    /// <param name="formatProvider"></param>
    /// <returns></returns>
    public string ToString(string format, IFormatProvider formatProvider)
    {
        if (format == null) format = "G";
        int smallhour = (Hour > 12) ? Hour - 12 : Hour;
        string designator = Hour > 12 ? PersianDateTimeFormatInfo.PMDesignator : PersianDateTimeFormatInfo.AMDesignator;

        if (formatProvider != null)
        {
            var formatter = formatProvider.GetFormat(typeof(ICustomFormatter)) as ICustomFormatter;
            if (formatter != null)
                return formatter.Format(format, this, formatProvider);
        }

        switch (format)
        {
            case "D":
            case "dddd, MMMM dd, yyyy":
            case "yyyy mm dd dddd":
                //'yyyy mm dd dddd' e.g. 'دوشنبه 20 شهریور 1384'
                return string.Format("{0} {1} {2} {3}", LocalizedWeekDayName, Utils.toDouble(Day), LocalizedMonthName, Year);


            case "f":
                //'hh:mm yyyy mmmm dd dddd' e.g. 'دوشنبه 20 شهریور 1384 21:30'
                return string.Format("{0} {1} {2} {3} {4}:{5}", LocalizedWeekDayName, Utils.toDouble(Day), LocalizedMonthName, Year, Utils.toDouble(Hour), Utils.toDouble(Minute));

            case "F":
            case "tt hh:mm:ss yyyy mmmm dd dddd":
            case "dddd, MMMM dd, yyyy hh:mm:ss tt":
                //'tt hh:mm:ss yyyy mmmm dd dddd' e.g. 'دوشنبه 20 شهریور 1384 02:30:22 ب.ض'
                return string.Format("{0} {1} {2} {3} {4}:{5}:{6} {7}", LocalizedWeekDayName, Utils.toDouble(Day), LocalizedMonthName, Year, Utils.toDouble(smallhour), Utils.toDouble(Minute), Utils.toDouble(Second), designator);

            case "g":
                //'yyyy/mm/dd hh:mm tt'
                return string.Format("{0}/{1}/{2} {3}:{4} {5}", Year, Utils.toDouble(Month), Utils.toDouble(Day), Utils.toDouble(smallhour), Utils.toDouble(Minute), designator);

            case "G":
                //'yyyy/mm/dd hh:mm:ss tt'
                return string.Format("{0}/{1}/{2} {3}:{4}:{5} {6}", Year, Utils.toDouble(Month), Utils.toDouble(Day), Utils.toDouble(smallhour), Utils.toDouble(Minute), Utils.toDouble(Second), designator);
            case "S":
                //'yyyy/mm/dd - hh:mm'
                return string.Format("{0}/{1}/{2} - {3}:{4}", Year, Utils.toDouble(Month), Utils.toDouble(Day), Utils.toDouble(Hour), Utils.toDouble(Minute));
            case "MMMM dd":
            case "dd MMMM":
                //MMMM dd e.g. 'تیر 10'
                return string.Format("{0} {1}", LocalizedMonthName, Utils.toDouble(Day));

            case "MMMM, yyyy":
            case "M":
            case "m":
                //'yyyy mmmm'
                return string.Format("{0} {1}", Year, LocalizedMonthName);

            case "s":
                //'yyyy-mm-ddThh:mm:ss'
                return string.Format("{0}-{1}-{2}T{3}:{4}:{5}", Year, Utils.toDouble(Month), Utils.toDouble(Day), Utils.toDouble(Hour), Utils.toDouble(Minute), Utils.toDouble(Second));

            case "hh:mm tt":
            case "HH:mm":
                return string.Format("{0}:{1}", Utils.toDouble(Hour), Utils.toDouble(Minute));
            case "t":
                //'hh:mm tt' e.g. 12:22 ب.ض
                return string.Format("{0}:{1} {2}", Utils.toDouble(smallhour), Utils.toDouble(Minute), designator);

            case "T":
            case "hh:mm:ss tt":
                //'hh:mm:ss tt' e.g. 12:22:30 ب.ض
                return string.Format("{0}:{1}:{2} {3}", Utils.toDouble(smallhour), Utils.toDouble(Minute), Utils.toDouble(Second), designator);

            case "w":
            case "W":
                return ToWritten();
            case "MM/dd/yyyy":
            default:
                //ShortDatePattern yyyy/mm/dd e.g. '1384/09/01'
                return string.Format("{0}/{1}/{2}", Year, Utils.toDouble(Month), Utils.toDouble(Day));
        }
    }

    #endregion

    #region Custom Functions
    public static bool IsValidDate(string date)
    {

        int Year = 0;
        int Month = 0;
        int Day = 0;

        if (date.Length == 8)
        {
            Year = int.Parse(date.Substring(0, 4));
            Month = int.Parse(date.Substring(4, 2));
            Day = int.Parse(date.Substring(6, 2));
        }
        else if (date.Length == 10 & (date.Contains('/') | date.Contains('-')))
        {
            string[] splitDate = date.Split('/', '-');

            if (!int.TryParse(splitDate[0], out Year))
                return false;

            if (!int.TryParse(splitDate[1], out Month))
                return false;

            if (!int.TryParse(splitDate[2], out Day))
                return false;
        }
        else
        {
            return false;
        }

        if (Day > 31 || Day <= 0)
        {
            return false;
        }

        if (Month > 12 || Month <= 0)
        {
            return false;
        }
        else
        {
            if (Month <= 6)
            {
                if (Day > 31)
                    return false;
            }

            if (Month >= 7)
            {
                if (Day > 30)
                    return false;
            }

            if (Month == 12)
            {
                var p = new System.Globalization.PersianCalendar();

                if (p.IsLeapYear(Year))
                {
                    if (Day > 30)
                        return false;
                }

                if (!p.IsLeapYear(Year))
                {
                    if (Day > 29)
                        return false;
                }
            }
        }

        return true;
    }

    public static PersianDate GetLastDayOfYear(int year)
    {
        if (year > 0)
        {
            PersianDate pd = new PersianDate(year, 1, 1);
            if (pd.IsLeapYear())
                return new PersianDate(year, 12, 30);
            else
                return new PersianDate(year, 12, 29);
        }
        return null;
    } 
    #endregion
}

#region StringID

/// <summary>
/// Various Strings that could be translater in Localizers.
/// </summary>
public enum StringID
{
    Empty,

    FADateTextBox_InvalidDate,
    FADateTextBox_Required,

    FAMonthView_None,
    FAMonthView_Today,

    Numbers_0,
    Numbers_1,
    Numbers_2,
    Numbers_3,
    Numbers_4,
    Numbers_5,
    Numbers_6,
    Numbers_7,
    Numbers_8,
    Numbers_9,

    PersianDate_InvalidDateFormat,
    PersianDate_InvalidDateTime,
    PersianDate_InvalidDateTimeLength,
    PersianDate_InvalidDay,
    PersianDate_InvalidEra,
    PersianDate_InvalidFourDigitYear,
    PersianDate_InvalidHour,
    PersianDate_InvalidLeapYear,
    PersianDate_InvalidMinute,
    PersianDate_InvalidMonth,
    PersianDate_InvalidMonthDay,
    PersianDate_InvalidSecond,
    PersianDate_InvalidMillisecond,
    PersianDate_InvalidTimeFormat,
    PersianDate_InvalidYear,

    Validation_Cancel,
    Validation_NotValid,
    Validation_Required,
    Validation_NullText,

    MessageBox_Ok,
    MessageBox_Cancel,
    MessageBox_Yes,
    MessageBox_No,
    MessageBox_Abort,
    MessageBox_Retry,
    MessageBox_Ignore,
}

#endregion

public class PersianDateConvert
{
    public PersianDateConvert(int year, int month, int day)
    {
        Year = year;
        Month = month;
        Day = day;
    }
    public PersianDateConvert()
    {
    }

    int Year { get; set; }
    int Month { get; set; }
    int Day { get; set; }

    public PersianDate SerialToPersianDate(int serial)
    {
        string strValue = serial.ToString();

        if (strValue.Length == 8)
        {
            PersianDate date = new PersianDate();
            date.Year = int.Parse(strValue.Substring(0, 4));
            date.Month = int.Parse(strValue.Substring(4, 2));
            date.Day = int.Parse(strValue.Substring(6, 2));
            date.Hour = DateTime.Now.Hour;
            date.Minute = DateTime.Now.Minute;
            date.Second = DateTime.Now.Second;
            date.Millisecond = DateTime.Now.Millisecond;
            return date;
        }

        return null;
    }

    public CDateInitialized Miladi(int year, int month, int day)
    {
        return new CDateInitialized(year, month, day, "Miladi");
    }
    public CDateInitialized Miladi(DateTime dateTime)
    {
        return new CDateInitialized(dateTime.Year, dateTime.Month, dateTime.Day, "Miladi");
    }

    public CDateInitialized Shamsi(int year, int month, int day)
    {
        return new CDateInitialized(year, month, day, "Shamsi");
    }

    public CDateInitialized Hijri(int year, int month, int day)
    {
        return new CDateInitialized(year, month, day, "Hijri");
    }

}

public class CDateInitialized
{
    public CDateInitialized(int year, int month, int day, string id)
    {
        Year = year;
        Month = month;
        Day = day;
        ID = id;
    }

    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    static string ID { get; set; }

    static System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
    static System.Globalization.HijriCalendar hc = new System.Globalization.HijriCalendar();


    public CDateConverted ToMiladi()
    {
        //تبدیل تاریخ شمسی به شمسی
        if (ID == "Miladi" & Year > 0 & Month > 0 & Day > 0)
        {
            DateTime dt1 = new DateTime(Year, Month, Day, 0, 0, 0, 0);
            CDateConverted dtOut = new CDateConverted(dt1.Year, dt1.Month, dt1.Day, dt1.DayOfWeek, "Miladi");
            return dtOut;
        }

        //تبدیل تاریخ شمسی به میلادی
        if (ID == "Shamsi" & Year > 0 & Month > 0 & Day > 0)
        {
            DateTime dt1 = pc.ToDateTime(Year, Month, Day, 0, 0, 0, 0);
            CDateConverted dtOut = new CDateConverted(dt1.Year, dt1.Month, dt1.Day, dt1.DayOfWeek, "Miladi");
            return dtOut;
        }

        //تبدیل تاریخ قمری به میلادی
        if (ID == "Hijri" & Year > 0 & Month > 0 & Day > 0)
        {
            DateTime dt2 = hc.ToDateTime(Year, Month, Day, 0, 0, 0, 0);
            CDateConverted dtOut = new CDateConverted(dt2.Year, dt2.Month, dt2.Day, dt2.DayOfWeek, "Miladi");
            return dtOut;
        }
        return null;
    }

    public CDateConverted ToShamsi()
    {
        //تبدیل تاریخ میلادی به شمسی
        if (ID == "Miladi" & Year > 0 & Month > 0 & Day > 0)
        {
            DateTime dt = new DateTime(Year, Month, Day);
            CDateConverted dtOut = new CDateConverted(pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt), pc.GetDayOfWeek(dt), "Shamsi");
            return dtOut;
        }

        //تبدیل تاریخ شمسی به شمسی
        if (ID == "Shamsi" & Year > 0 & Month > 0 & Day > 0)
        {
            DateTime dt1 = pc.ToDateTime(Year, Month, Day, 0, 0, 0, 0);
            CDateConverted dtOut = new CDateConverted(pc.GetYear(dt1), pc.GetMonth(dt1), pc.GetDayOfMonth(dt1), pc.GetDayOfWeek(dt1), "Shamsi");
            return dtOut;
        }

        //تبدیل تاریخ قمری به شمسی
        if (ID == "Hijri" & Year > 0 & Month > 0 & Day > 0)
        {
            DateTime dt2 = hc.ToDateTime(Year, Month, Day, 0, 0, 0, 0);
            CDateConverted dtOut = new CDateConverted(pc.GetYear(dt2), pc.GetMonth(dt2), pc.GetDayOfMonth(dt2), pc.GetDayOfWeek(dt2), "Shamsi");
            return dtOut;
        }

        return null;
    }

    public CDateConverted ToHijri()
    {
        //تبدیل تاریخ میلادی به قمری
        if (ID == "Miladi" & Year > 0 & Month > 0 & Day > 0)
        {
            DateTime dt = new DateTime(Year, Month, Day);
            CDateConverted dtOut = new CDateConverted(hc.GetYear(dt), hc.GetMonth(dt), hc.GetDayOfMonth(dt), hc.GetDayOfWeek(dt), "Hijri");
            return dtOut;
        }

        //تبدیل تاریخ شمسی به قمری
        if (ID == "Shamsi" & Year > 0 & Month > 0 & Day > 0)
        {
            DateTime dt1 = pc.ToDateTime(Year, Month, Day, 0, 0, 0, 0);
            CDateConverted dtOut = new CDateConverted(hc.GetYear(dt1), hc.GetMonth(dt1), hc.GetDayOfMonth(dt1), hc.GetDayOfWeek(dt1), "Hijri");
            return dtOut;
        }

        //تبدیل تاریخ قمری به قمری
        if (ID == "Hijri" & Year > 0 & Month > 0 & Day > 0)
        {
            DateTime dt1 = hc.ToDateTime(Year, Month, Day, 0, 0, 0, 0);
            CDateConverted dtOut = new CDateConverted(hc.GetYear(dt1), hc.GetMonth(dt1), hc.GetDayOfMonth(dt1), hc.GetDayOfWeek(dt1), "Hijri");
            return dtOut;
        }
        return null;
    }

}

public class CDateConverted
{
    public CDateConverted(int year, int month, int day, DayOfWeek weekDayName, string id)
    {
        Year = year;
        Month = month;
        Day = day;
        WeekDayName = weekDayName;
        ID = id;
    }

    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    DayOfWeek WeekDayName { get; set; }
    static string ID { get; set; }

    string HijriMonthName
    {
        get
        {
            switch (Month)
            {
                case 1:
                    return "محرم";
                case 2:
                    return "صفر";
                case 3:
                    return "ربیع‌الاول";
                case 4:
                    return "ربیع‌الثانی";
                case 5:
                    return "جمادی‌الاول";
                case 6:
                    return "جمادی‌الثانی";
                case 7:
                    return "رجب";
                case 8:
                    return "شعبان";
                case 9:
                    return "رمضان";
                case 10:
                    return "شوال";
                case 11:
                    return "ذی‌القعده";
                case 12:
                    return "ذی‌الحجه";
                default:
                    return "";
            }
        }
    }
    string HijriWeekDayName
    {
        get
        {
            switch (WeekDayName)
            {
                case DayOfWeek.Sunday:
                    return "الاحد";
                case DayOfWeek.Monday:
                    return "الاثنین";
                case DayOfWeek.Tuesday:
                    return "الثلاثاء";
                case DayOfWeek.Wednesday:
                    return "الاربعاء";
                case DayOfWeek.Thursday:
                    return "الخمیس";
                case DayOfWeek.Friday:
                    return "الجمعة";
                case DayOfWeek.Saturday:
                    return "السبت";
                default:
                    return "";
            }
        }
    }

    string ShamsiMonthName
    {
        get
        {
            switch (Month)
            {
                case 1:
                    return "فروردین";
                case 2:
                    return "اردیبهشت";
                case 3:
                    return "خرداد";
                case 4:
                    return "تیر‏";
                case 5:
                    return "مرداد";
                case 6:
                    return "شهریور";
                case 7:
                    return "مهر";
                case 8:
                    return "آبان";
                case 9:
                    return "آذر";
                case 10:
                    return "دی";
                case 11:
                    return "بهمن";
                case 12:
                    return "اسفند";
                default:
                    return "";
            }
        }
    }
    string ShamsiWeekDayName
    {
        get
        {
            switch (WeekDayName)
            {
                case DayOfWeek.Saturday:
                    return "شنبه";
                case DayOfWeek.Sunday:
                    return "یکشنبه";
                case DayOfWeek.Monday:
                    return "دوشنبه";
                case DayOfWeek.Tuesday:
                    return "سه شنبه";
                case DayOfWeek.Wednesday:
                    return "چهارشنبه";
                case DayOfWeek.Thursday:
                    return "پنجشنبه";
                case DayOfWeek.Friday:
                    return "جمعه";
                default:
                    return "";
            }
        }
    }

    string MiladiMonthName
    {
        get
        {
            switch (Month)
            {
                case 1:
                    return "January";
                case 2:
                    return "February";
                case 3:
                    return "March";
                case 4:
                    return "April‏";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "August";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    return "";
            }
        }
    }
    string MiladiWeekDayName
    {
        get
        {
            switch (WeekDayName)
            {
                case DayOfWeek.Saturday:
                    return "Saturday";
                case DayOfWeek.Sunday:
                    return "Sunday";
                case DayOfWeek.Monday:
                    return "Monday";
                case DayOfWeek.Tuesday:
                    return "Tuesday";
                case DayOfWeek.Wednesday:
                    return "Wednesday";
                case DayOfWeek.Thursday:
                    return "Thursday";
                case DayOfWeek.Friday:
                    return "Friday";
                default:
                    return "";
            }
        }
    }

    private string Convert(string EnglishNumber)
    {
        string numEnglish = "";
        string numTemp = "";

        for (int i = 0; i < EnglishNumber.Length; i++)
        {
            numTemp = EnglishNumber.Substring(i, 1);
            switch (numTemp)
            {
                case "0":
                    numEnglish = numEnglish + "۰";
                    break;
                case "1":
                    numEnglish = numEnglish + "۱";
                    break;
                case "2":
                    numEnglish = numEnglish + "۲";
                    break;
                case "3":
                    numEnglish = numEnglish + "۳";
                    break;
                case "4":
                    numEnglish = numEnglish + "۴";
                    break;
                case "5":
                    numEnglish = numEnglish + "۵";
                    break;
                case "6":
                    numEnglish = numEnglish + "۶";
                    break;
                case "7":
                    numEnglish = numEnglish + "۷";
                    break;
                case "8":
                    numEnglish = numEnglish + "۸";
                    break;
                case "9":
                    numEnglish = numEnglish + "۹";
                    break;
                default:
                    numEnglish = numEnglish + numTemp;
                    break;
            }
        }

        return (numEnglish);
    }

    public string ToDateWritten()
    {
        string m = string.Empty;
        string d = string.Empty;
        string y = string.Empty;

        if (ID == "Shamsi" & Year > 0 & Month > 0 & Day > 0)
        {
            switch (Month)
            {
                case 1: { m = "فروردین ماه"; break; }
                case 2: { m = "اردیبهشت ماه"; break; }
                case 3: { m = "خرداد ماه"; break; }
                case 4: { m = "تیر ماه"; break; }
                case 5: { m = "مرداد ماه"; break; }
                case 6: { m = "شهریور ماه"; break; }
                case 7: { m = "مهر ماه"; break; }
                case 8: { m = "آبان ماه"; break; }
                case 9: { m = "آذر ماه"; break; }
                case 10: { m = "دی ماه"; break; }
                case 11: { m = "بهمن ماه"; break; }
                case 12: { m = "اسفند ماه"; break; }
            }

            switch (Day)
            {
                case 1: { d = "یکم"; break; }
                case 2: { d = "دوم"; break; }
                case 3: { d = "سوم"; break; }
                case 4: { d = "چهارم"; break; }
                case 5: { d = "پنجم"; break; }
                case 6: { d = "ششم"; break; }
                case 7: { d = "هفتم"; break; }
                case 8: { d = "هشتم"; break; }
                case 9: { d = "نهم"; break; }
                case 10: { d = "دهم"; break; }
                case 11: { d = "یازدهم"; break; }
                case 12: { d = "دوازدهم"; break; }
                case 13: { d = "سیزدهم"; break; }
                case 14: { d = "چهاردهم"; break; }
                case 15: { d = "پانزدهم"; break; }
                case 16: { d = "شانزدهم"; break; }
                case 17: { d = "هفدهم"; break; }
                case 18: { d = "هجدهم"; break; }
                case 19: { d = "نوزدهم"; break; }
                case 20: { d = "بیستم"; break; }
                case 21: { d = "بیست یکم"; break; }
                case 22: { d = "بیست دوم"; break; }
                case 23: { d = "بیست سوم"; break; }
                case 24: { d = "بیست چهارم"; break; }
                case 25: { d = "بیست پنجم"; break; }
                case 26: { d = "بیست ششم"; break; }
                case 27: { d = "بیست هفتم"; break; }
                case 28: { d = "بیست هشتم"; break; }
                case 29: { d = "بیست نهم"; break; }
                case 30: { d = "سی ام"; break; }
                case 31: { d = "سی یکم"; break; }
            }

            y = "سال " + DigitsWritter.GetNumber(Year, DigitsWritter.Language.Persian);

            return string.Format("{2} {1} {0}", y, m, d);
        }
        else
        {
            return "";
        }
    }

    public int ToSerial()
    {
        return int.Parse(string.Format("{0}{1}{2}", Year, Month.ToString("D2"), Day.ToString("D2")));
    }

    /// <summary>
    /// Get date with 0000/00/00 format.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return string.Format("{0}/{1}/{2}", Year, Month.ToString("D2"), Day.ToString("D2"));
    }

    /// <summary>
    /// Get date with your divider like 0000-00-00 or 0000.00.00 format.
    /// </summary>
    /// <returns></returns>
    public string ToString(char divider)
    {
        return string.Format("{0}{3}{1}{3}{2}", Year, Month.ToString("D2"), Day.ToString("D2"), divider);
    }

    /// <summary>
    /// Get date with persian number like ۱۳۹۵/۰۳/۱۴ format.
    /// </summary>
    /// <returns></returns>
    public string ToString(bool persianNumbers)
    {
        if (ID == "Miladi")
        {
            if (!persianNumbers)
                return string.Format("{3}, {1} {2}, {0}", Year, MiladiMonthName, Day, MiladiWeekDayName);
            else
                return Convert(string.Format("{3}, {1} {2}, {0}", Year, MiladiMonthName, Day, MiladiWeekDayName));
        }

        if (ID == "Shamsi")
        {
            if (!persianNumbers)
                return string.Format("{3}, {2} {1}, {0}", Year, ShamsiMonthName, Day, ShamsiWeekDayName);
            else
                return Convert(string.Format("{3}, {2} {1}, {0}", Year, ShamsiMonthName, Day, ShamsiWeekDayName));
        }

        if (ID == "Hijri")
        {
            if (!persianNumbers)
                return string.Format("{3}, {2} {1}, {0}", Year, HijriMonthName, Day, HijriWeekDayName);
            else
                return Convert(string.Format("{3}, {2} {1}, {0}", Year, HijriMonthName, Day, HijriWeekDayName));
        }

        return string.Format("{0}/{1}/{2}", Year, Month.ToString("D2"), Day.ToString("D2"));
    }
}



/// <summary>
/// Convert a number into words
/// </summary>
public static class DigitsWritter
{

    /// <summary>
    /// Number to word languages
    /// </summary>
    public enum Language
    {
        /// <summary>
        /// English Language
        /// </summary>
        English,

        /// <summary>
        /// Persian Language
        /// </summary>
        Persian
    }

    /// <summary>
    /// Digit's groups
    /// </summary>
    private enum DigitGroup
    {
        /// <summary>
        /// Ones group
        /// </summary>
        Ones,

        /// <summary>
        /// Teens group
        /// </summary>
        Teens,

        /// <summary>
        /// Tens group
        /// </summary>
        Tens,

        /// <summary>
        /// Hundreds group
        /// </summary>
        Hundreds,

        /// <summary>
        /// Thousands group
        /// </summary>
        Thousands
    }

    /// <summary>
    /// Equivalent names of a group
    /// </summary>
    private class Converter
    {
        /// <summary>
        /// Digit's group
        /// </summary>
        public DigitGroup Group { set; get; }

        /// <summary>
        /// Number to word language
        /// </summary>
        public Language Language { set; get; }

        /// <summary>
        /// Equivalent names
        /// </summary>
        public IList<string> Names { set; get; }
    }
    #region Fields (4)

    private static readonly IDictionary<Language, string> And = new Dictionary<Language, string>
  {
   { Language.English, " " },
   { Language.Persian, " و " }
  };
    private static readonly IList<Converter> NumberWords = new List<Converter>
  {
   new Converter { Group= DigitGroup.Ones, Language= Language.English, Names=
    new List<string> { string.Empty, "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" }},
   new Converter { Group= DigitGroup.Ones, Language= Language.Persian, Names=
    new List<string> { string.Empty, "یک", "دو", "سه", "چهار", "پنج", "شش", "هفت", "هشت", "نه" }},

   new Converter { Group= DigitGroup.Teens, Language= Language.English, Names=
    new List<string> { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" }},
   new Converter { Group= DigitGroup.Teens, Language= Language.Persian, Names=
    new List<string> { "ده", "یازده", "دوازده", "سیزده", "چهارده", "پانزده", "شانزده", "هفده", "هجده", "نوزده" }},

   new Converter { Group= DigitGroup.Tens, Language= Language.English, Names=
    new List<string> { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" }},
   new Converter { Group= DigitGroup.Tens, Language= Language.Persian, Names=
    new List<string> { "بیست", "سی", "چهل", "پنجاه", "شصت", "هفتاد", "هشتاد", "نود" }},

   new Converter { Group= DigitGroup.Hundreds, Language= Language.English, Names=
    new List<string> {string.Empty, "One Hundred", "Two Hundred", "Three Hundred", "Four Hundred",
     "Five Hundred", "Six Hundred", "Seven Hundred", "Eight Hundred", "Nine Hundred" }},
   new Converter { Group= DigitGroup.Hundreds, Language= Language.Persian, Names=
    new List<string> {string.Empty, "یکصد", "دویست", "سیصد", "چهارصد", "پانصد", "ششصد", "هفتصد", "هشتصد" , "نهصد" }},

   new Converter { Group= DigitGroup.Thousands, Language= Language.English, Names=
     new List<string> { string.Empty, " Thousand", " Million", " Billion"," Trillion", " Quadrillion", " Quintillion", " Sextillian",
   " Septillion", " Octillion", " Nonillion", " Decillion", " Undecillion", " Duodecillion", " Tredecillion",
   " Quattuordecillion", " Quindecillion", " Sexdecillion", " Septendecillion", " Octodecillion", " Novemdecillion",
   " Vigintillion", " Unvigintillion", " Duovigintillion", " 10^72", " 10^75", " 10^78", " 10^81", " 10^84", " 10^87",
   " Vigintinonillion", " 10^93", " 10^96", " Duotrigintillion", " Trestrigintillion" }},
   new Converter { Group= DigitGroup.Thousands, Language= Language.Persian, Names=
     new List<string> { string.Empty, " هزار", " میلیون", " میلیارد"," تریلیون", " Quadrillion", " Quintillion", " Sextillian",
   " Septillion", " Octillion", " Nonillion", " Decillion", " Undecillion", " Duodecillion", " Tredecillion",
   " Quattuordecillion", " Quindecillion", " Sexdecillion", " Septendecillion", " Octodecillion", " Novemdecillion",
   " Vigintillion", " Unvigintillion", " Duovigintillion", " 10^72", " 10^75", " 10^78", " 10^81", " 10^84", " 10^87",
   " Vigintinonillion", " 10^93", " 10^96", " Duotrigintillion", " Trestrigintillion" }},
  };
    private static readonly IDictionary<Language, string> Negative = new Dictionary<Language, string>
  {
   { Language.English, "Negative " },
   { Language.Persian, "منهای " }
  };
    private static readonly IDictionary<Language, string> Zero = new Dictionary<Language, string>
  {
   { Language.English, "Zero" },
   { Language.Persian, "صفر" }
  };

    #endregion Fields

    #region Methods (7)

    // Public Methods (5)

    /// <summary>
    /// display a numeric value using the equivalent text
    /// </summary>
    /// <param name="number">input number</param>
    /// <param name="language">local language</param>
    /// <returns>the equivalent text</returns>
    public static string GetNumber(this int number, Language language)
    {
        return GetNumber((long)number, language);
    }


    /// <summary>
    /// display a numeric value using the equivalent text
    /// </summary>
    /// <param name="number">input number</param>
    /// <param name="language">local language</param>
    /// <returns>the equivalent text</returns>
    public static string GetNumber(this uint number, Language language)
    {
        return GetNumber((long)number, language);
    }

    /// <summary>
    /// display a numeric value using the equivalent text
    /// </summary>
    /// <param name="number">input number</param>
    /// <param name="language">local language</param>
    /// <returns>the equivalent text</returns>
    public static string GetNumber(this byte number, Language language)
    {
        return GetNumber((long)number, language);
    }

    /// <summary>
    /// display a numeric value using the equivalent text
    /// </summary>
    /// <param name="number">input number</param>
    /// <param name="language">local language</param>
    /// <returns>the equivalent text</returns>
    public static string GetNumber(this decimal number, Language language)
    {
        return GetNumber((long)number, language);
    }

    /// <summary>
    /// display a numeric value using the equivalent text
    /// </summary>
    /// <param name="number">input number</param>
    /// <param name="language">local language</param>
    /// <returns>the equivalent text</returns>
    public static string GetNumber(this double number, Language language)
    {
        return GetNumber((long)number, language);
    }

    /// <summary>
    /// display a numeric value using the equivalent text
    /// </summary>
    /// <param name="number">input number</param>
    /// <param name="language">local language</param>
    /// <returns>the equivalent text</returns>
    public static string GetNumber(this long number, Language language)
    {
        if (number == 0)
        {
            return Zero[language];
        }

        if (number < 0)
        {
            return Negative[language] + GetNumber(-number, language);
        }

        return wordify(number, language, string.Empty, 0);
    }
    // Private Methods (2)

    private static string getName(int idx, Language language, DigitGroup group)
    {
        return NumberWords.Where(x => x.Group == group && x.Language == language).First().Names[idx];
    }

    private static string wordify(long number, Language language, string leftDigitsText, int thousands)
    {
        if (number == 0)
        {
            return leftDigitsText;
        }

        var wordValue = leftDigitsText;
        if (wordValue.Length > 0)
        {
            wordValue += And[language];
        }

        if (number < 10)
        {
            wordValue += getName((int)number, language, DigitGroup.Ones);
        }
        else if (number < 20)
        {
            wordValue += getName((int)(number - 10), language, DigitGroup.Teens);
        }
        else if (number < 100)
        {
            wordValue += wordify(number % 10, language, getName((int)(number / 10 - 2), language, DigitGroup.Tens), 0);
        }
        else if (number < 1000)
        {
            wordValue += wordify(number % 100, language, getName((int)(number / 100), language, DigitGroup.Hundreds), 0);
        }
        else
        {
            wordValue += wordify(number % 1000, language, wordify(number / 1000, language, string.Empty, thousands + 1), 0);
        }

        if (number % 1000 == 0) return wordValue;
        return wordValue + getName(thousands, language, DigitGroup.Thousands);
    }

    #endregion Methods
}

public class ENLocalizer : BaseLocalizer
{
    public override string GetLocalizedString(StringID id)
    {
        switch (id)
        {
            case StringID.Empty: return string.Empty;
            case StringID.Numbers_0: return "0";
            case StringID.Numbers_1: return "1";
            case StringID.Numbers_2: return "2";
            case StringID.Numbers_3: return "3";
            case StringID.Numbers_4: return "4";
            case StringID.Numbers_5: return "5";
            case StringID.Numbers_6: return "6";
            case StringID.Numbers_7: return "7";
            case StringID.Numbers_8: return "8";
            case StringID.Numbers_9: return "9";

            case StringID.FADateTextBox_Required: return "Mandatory field";
            case StringID.FAMonthView_None: return "Empty";
            case StringID.FAMonthView_Today: return "Today";

            case StringID.PersianDate_InvalidDateFormat: return "Invalid date format";
            case StringID.PersianDate_InvalidDateTime: return "Invalid date/time value";
            case StringID.PersianDate_InvalidDateTimeLength: return "Invalid date time format";
            case StringID.PersianDate_InvalidDay: return "Invalid Day value";
            case StringID.PersianDate_InvalidEra: return "Invalid Era value";
            case StringID.PersianDate_InvalidFourDigitYear: return "Invalid four digit Year value";
            case StringID.PersianDate_InvalidHour: return "Invalid Hour value";
            case StringID.PersianDate_InvalidLeapYear: return "Not a leap year. Correct the day value.";
            case StringID.PersianDate_InvalidMinute: return "Invalid Minute value";
            case StringID.PersianDate_InvalidMonth: return "Invalid Month value";
            case StringID.PersianDate_InvalidMonthDay: return "Invalid Month/Day value";
            case StringID.PersianDate_InvalidSecond: return "Invalid Second value";
            case StringID.PersianDate_InvalidTimeFormat: return "Invalid Time format";
            case StringID.PersianDate_InvalidYear: return "Invalid Year value.";

            case StringID.Validation_Cancel: return "Cancel";
            case StringID.Validation_NotValid: return "Entered value is not in valid range.";
            case StringID.Validation_Required: return "This is a mandatory field. Please fill it in.";
            case StringID.Validation_NullText: return "[Empty Value]";

            case StringID.MessageBox_Ok: return "Ok";
            case StringID.MessageBox_Abort: return "Abort";
            case StringID.MessageBox_Cancel: return "Cancel";
            case StringID.MessageBox_Ignore: return "Ignore";
            case StringID.MessageBox_No: return "No";
            case StringID.MessageBox_Retry: return "Retry";
            case StringID.MessageBox_Yes: return "Yes";
        }

        return string.Empty;
    }

    public override string GetFormatterString(FormatterStringID stringID)
    {
        switch (stringID)
        {
            case FormatterStringID.CenturyPattern: return "%n %u";
            case FormatterStringID.CenturyFuturePrefix: return "";
            case FormatterStringID.CenturyFutureSuffix: return " from now";
            case FormatterStringID.CenturyPastPrefix: return "";
            case FormatterStringID.CenturyPastSuffix: return " ago";
            case FormatterStringID.CenturyName: return "century";
            case FormatterStringID.CenturyPluralName: return "centuries";
            case FormatterStringID.DayPattern: return "%n %u";
            case FormatterStringID.DayFuturePrefix: return "";
            case FormatterStringID.DayFutureSuffix: return " from now";
            case FormatterStringID.DayPastPrefix: return "";
            case FormatterStringID.DayPastSuffix: return " ago";
            case FormatterStringID.DayName: return "day";
            case FormatterStringID.DayPluralName: return "days";
            case FormatterStringID.DecadePattern: return "%n %u";
            case FormatterStringID.DecadeFuturePrefix: return "";
            case FormatterStringID.DecadeFutureSuffix: return " from now";
            case FormatterStringID.DecadePastPrefix: return "";
            case FormatterStringID.DecadePastSuffix: return " ago";
            case FormatterStringID.DecadeName: return "decade";
            case FormatterStringID.DecadePluralName: return "decades";
            case FormatterStringID.HourPattern: return "%n %u";
            case FormatterStringID.HourFuturePrefix: return "";
            case FormatterStringID.HourFutureSuffix: return " from now";
            case FormatterStringID.HourPastPrefix: return "";
            case FormatterStringID.HourPastSuffix: return " ago";
            case FormatterStringID.HourName: return "hour";
            case FormatterStringID.HourPluralName: return "hours";
            case FormatterStringID.JustNowPattern: return "%u";
            case FormatterStringID.JustNowFuturePrefix: return "";
            case FormatterStringID.JustNowFutureSuffix: return "moments from now";
            case FormatterStringID.JustNowPastPrefix: return "moments ago";
            case FormatterStringID.JustNowPastSuffix: return "";
            case FormatterStringID.JustNowName: return "";
            case FormatterStringID.JustNowPluralName: return "";
            case FormatterStringID.MillenniumPattern: return "%n %u";
            case FormatterStringID.MillenniumFuturePrefix: return "";
            case FormatterStringID.MillenniumFutureSuffix: return " from now";
            case FormatterStringID.MillenniumPastPrefix: return "";
            case FormatterStringID.MillenniumPastSuffix: return " ago";
            case FormatterStringID.MillenniumName: return "millennium";
            case FormatterStringID.MillenniumPluralName: return "millennia";
            case FormatterStringID.MillisecondPattern: return "%n %u";
            case FormatterStringID.MillisecondFuturePrefix: return "";
            case FormatterStringID.MillisecondFutureSuffix: return " from now";
            case FormatterStringID.MillisecondPastPrefix: return "";
            case FormatterStringID.MillisecondPastSuffix: return " ago";
            case FormatterStringID.MillisecondName: return "millisecond";
            case FormatterStringID.MillisecondPluralName: return "milliseconds";
            case FormatterStringID.MinutePattern: return "%n %u";
            case FormatterStringID.MinuteFuturePrefix: return "";
            case FormatterStringID.MinuteFutureSuffix: return " from now";
            case FormatterStringID.MinutePastPrefix: return "";
            case FormatterStringID.MinutePastSuffix: return " ago";
            case FormatterStringID.MinuteName: return "minute";
            case FormatterStringID.MinutePluralName: return "minutes";
            case FormatterStringID.MonthPattern: return "%n %u";
            case FormatterStringID.MonthFuturePrefix: return "";
            case FormatterStringID.MonthFutureSuffix: return " from now";
            case FormatterStringID.MonthPastPrefix: return "";
            case FormatterStringID.MonthPastSuffix: return " ago";
            case FormatterStringID.MonthName: return "month";
            case FormatterStringID.MonthPluralName: return "months";
            case FormatterStringID.SecondPattern: return "%n %u";
            case FormatterStringID.SecondFuturePrefix: return "";
            case FormatterStringID.SecondFutureSuffix: return " from now";
            case FormatterStringID.SecondPastPrefix: return "";
            case FormatterStringID.SecondPastSuffix: return " ago";
            case FormatterStringID.SecondName: return "second";
            case FormatterStringID.SecondPluralName: return "seconds";
            case FormatterStringID.WeekPattern: return "%n %u";
            case FormatterStringID.WeekFuturePrefix: return "";
            case FormatterStringID.WeekFutureSuffix: return " from now";
            case FormatterStringID.WeekPastPrefix: return "";
            case FormatterStringID.WeekPastSuffix: return " ago";
            case FormatterStringID.WeekName: return "week";
            case FormatterStringID.WeekPluralName: return "weeks";
            case FormatterStringID.YearPattern: return "%n %u";
            case FormatterStringID.YearFuturePrefix: return "";
            case FormatterStringID.YearFutureSuffix: return " from now";
            case FormatterStringID.YearPastPrefix: return "";
            case FormatterStringID.YearPastSuffix: return " ago";
            case FormatterStringID.YearName: return "year";
            case FormatterStringID.YearPluralName: return "years";
        }

        return string.Empty;
    }
}

/// <summary>
/// Localizer class used to get string values of Arabic language.
/// </summary>
public class ARLocalizer : FALocalizer
{
    /// <summary>
    /// Gets a localized string for Arabic culture, for specified <see cref="StringID"/>.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public override string GetLocalizedString(StringID id)
    {
        switch (id)
        {
            case StringID.FAMonthView_None: return "امح";
            case StringID.FAMonthView_Today: return "الیوم";
        }

        return base.GetLocalizedString(id);
    }
}

public abstract class BaseLocalizer
{
    #region Abstract Methods

    public abstract string GetLocalizedString(StringID id);

    public string GetFormatterString(string enumKey)
    {
        var key = (FormatterStringID)Enum.Parse(typeof(FormatterStringID), enumKey);
        return GetFormatterString(key);
    }

    public abstract string GetFormatterString(FormatterStringID stringID);

    #endregion
}

/// <summary>
/// Base culture information
/// </summary>
internal static class CultureHelper
{
    private static CultureInfo faCulture;
    private static CultureInfo arCulture;
    private static CultureInfo internalfaCulture;
    private static readonly CultureInfo neuCulture = CultureInfo.InvariantCulture;
    private static readonly PersianCalendar pc = new PersianCalendar();
    private static readonly HijriCalendar hc = new HijriCalendar();
    private static readonly GregorianCalendar gc = new GregorianCalendar();
    private static readonly Dictionary<int, DayOfWeek> PersianDoW = new Dictionary<int, DayOfWeek>();
    private static readonly Dictionary<int, DayOfWeek> GregorianDoW = new Dictionary<int, DayOfWeek>();

    static CultureHelper()
    {
        CreatePersianDayOfWeekMap();
        CreateGregorianDayOfWeekMap();
    }

    private static void CreatePersianDayOfWeekMap()
    {
        PersianDoW.Add(0, DayOfWeek.Saturday);
        PersianDoW.Add(1, DayOfWeek.Sunday);
        PersianDoW.Add(2, DayOfWeek.Monday);
        PersianDoW.Add(3, DayOfWeek.Tuesday);
        PersianDoW.Add(4, DayOfWeek.Wednesday);
        PersianDoW.Add(5, DayOfWeek.Thursday);
        PersianDoW.Add(6, DayOfWeek.Friday);
    }

    private static void CreateGregorianDayOfWeekMap()
    {
        GregorianDoW.Add(0, DayOfWeek.Sunday);
        GregorianDoW.Add(1, DayOfWeek.Monday);
        GregorianDoW.Add(2, DayOfWeek.Tuesday);
        GregorianDoW.Add(3, DayOfWeek.Wednesday);
        GregorianDoW.Add(4, DayOfWeek.Thursday);
        GregorianDoW.Add(5, DayOfWeek.Friday);
        GregorianDoW.Add(6, DayOfWeek.Saturday);
    }

    public static Calendar PersianCalendar
    {
        get { return pc; }
    }

    /// <summary>
    /// Currently selected UICulture
    /// </summary>
    public static CultureInfo CurrentCulture
    {
        get { return Thread.CurrentThread.CurrentUICulture; }
    }

    /// <summary>
    /// Instance of Arabic culture
    /// </summary>
    public static CultureInfo ArabicCulture
    {
        get
        {
            if (arCulture == null)
                arCulture = new CultureInfo("ar-SA");

            return arCulture;
        }
    }

    /// <summary>
    /// Instance of Farsi culture
    /// </summary>
    public static CultureInfo FarsiCulture
    {
        get
        {
            if (faCulture == null)
                faCulture = new CultureInfo("fa-IR");

            return faCulture;
        }
    }

    /// <summary>
    /// Instance of Persian Culture with correct date formatting.
    /// </summary>
    public static CultureInfo PersianCulture
    {
        get
        {
            if (internalfaCulture == null)
                internalfaCulture = new PersianCultureInfo();

            return internalfaCulture;
        }
    }

    /// <summary>
    /// Instance of Neutral culture
    /// </summary>
    public static CultureInfo NeutralCulture
    {
        get { return neuCulture; }
    }

    /// <summary>
    /// Returns the day of week based on calendar.
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="calendar"></param>
    /// <returns></returns>
    public static int GetDayOfWeek(DateTime dt, Calendar calendar)
    {
        var calendarType = calendar.GetType();
        if (calendarType == typeof(PersianCalendar) ||
            calendarType == typeof(System.Globalization.PersianCalendar))
        {
            return PersianDateTimeFormatInfo.GetDayIndex(dt.DayOfWeek);
        }

        return (int)dt.DayOfWeek;
    }

    /// <summary>
    /// Returns the default calendar for the current culture.
    /// </summary>
    /// <returns></returns>
    public static Calendar CurrentCalendar
    {
        get
        {
            if (IsFarsiCulture)
            {
                return pc;
            }

            if (IsArabicCulture)
            {
                return hc;
            }

            return gc;
        }
    }

    /// <summary>
    /// Finds the corresponding DayOfWeek in specified culture
    /// </summary>
    /// <param name="day"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public static DayOfWeek GetCultureDayOfWeek(int day, CultureInfo culture)
    {
        if (CultureInfoExtensions.IsFarsiCulture(culture))
        {
            return PersianDoW[day];
        }

        return GregorianDoW[day];
    }

    public static DateTime MinCultureDateTime
    {
        get { return CurrentCalendar.MinSupportedDateTime; }
    }

    public static DateTime MaxCultureDateTime
    {
        get { return CurrentCalendar.MaxSupportedDateTime; }
    }

    public static bool IsArabicCulture
    {
        get { return CurrentCulture.Equals(arCulture) || CurrentCulture.Name.Equals("ar", StringComparison.InvariantCultureIgnoreCase); }
    }

    public static bool IsDefaultCulture
    {
        get { return CurrentCulture.Equals(NeutralCulture); }
    }

    public static bool IsFarsiCulture
    {
        get { return IsCustomizedFarsiCulture || IsBuiltinFarsiCulture; }
    }

    public static bool IsCustomizedFarsiCulture
    {
        get { return CurrentCulture.Equals(PersianCulture); }
    }

    public static bool IsBuiltinFarsiCulture
    {
        get { return CurrentCulture.Name.Equals("fa", StringComparison.InvariantCultureIgnoreCase); }
    }
}

/// <summary>Class to convert PersianDate into normal DateTime value and vice versa.
/// <seealso cref="PersianDate"/>
/// </summary>
/// <remarks>
/// You can use <c>FarsiLibrary.Utils.FarsiDate.Now</c> property to access current Date.
/// </remarks>
public sealed class PersianDateConverter
{
    #region Fields

    private const double Solar = 365.25;
    private const int GYearOff = 226894;
    private static readonly int[,] GDayTable = new[,] { { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }, { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 } };
    private static readonly int[,] JDayTable = new[,] { { 31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 29 }, { 31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 30 } };
    private static readonly string[] weekdays = new[] { "شنبه", "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه" };
    private static readonly string[] weekdaysabbr = new[] { "ش", "ی", "د", "س", "چ", "پ", "ج" };

    #endregion

    #region Methods

    /// <summary>
    /// Checks if a specified Persian year is a leap one.
    /// </summary>
    /// <param name="jyear"></param>
    /// <returns>returns 1 if the year is leap, otherwise returns 0.</returns>
    private static int JLeap(int jyear)
    {
        //Is jalali year a leap year?
        int tmp;

        Math.DivRem(jyear, 33, out tmp);
        if ((tmp == 1) || (tmp == 5) || (tmp == 9) || (tmp == 13) || (tmp == 17) || (tmp == 22) || (tmp == 26) || (tmp == 30))
        {
            return 1;
        }

        return 0;
    }

    /// <summary>
    /// Checks if a year is a leap one.
    /// </summary>
    /// <param name="jyear">Year to check</param>
    /// <returns>true if the year is leap</returns>
    public static bool IsJLeapYear(int jyear)
    {
        return JLeap(jyear) == 1;
    }

    /// <summary>
    /// Checks if a specified Gregorian year is a leap one.
    /// </summary>
    /// <param name="gyear"></param>
    /// <returns>returns 1 if the year is leap, otherwise returns 0.</returns>
    private static int GLeap(int gyear)
    {
        //Is gregorian year a leap year?
        int Mod4, Mod100, Mod400;

        Math.DivRem(gyear, 4, out Mod4);
        Math.DivRem(gyear, 100, out Mod100);
        Math.DivRem(gyear, 400, out Mod400);

        if (((Mod4 == 0) && (Mod100 != 0)) || (Mod400 == 0))
        {
            return 1;
        }

        return 0;
    }

    private static int GregDays(int gYear, int gMonth, int gDay)
    {
        //Calculate total days of gregorian from calendar base
        var Div4 = (gYear - 1) / 4;
        var Div100 = (gYear - 1) / 100;
        var Div400 = (gYear - 1) / 400;
        var leap = GLeap(gYear);

        for (var i = 0; i < gMonth - 1; i++)
        {
            gDay = gDay + GDayTable[leap, i];
        }

        return ((gYear - 1) * 365 + gDay + Div4 - Div100 + Div400);
    }

    private static int JLeapYears(int jYear)
    {
        int i;
        var Div33 = jYear / 33;
        var cycle = jYear - (Div33 * 33);
        var leap = (Div33 * 8);

        if (cycle > 0)
        {
            for (i = 1; i <= 18; i = i + 4)
            {
                if (i > cycle)
                    break;

                leap++;
            }
        }

        if (cycle > 21)
        {
            for (i = 22; i <= 31; i = i + 4)
            {
                if (i > cycle)
                    break;

                leap++;
            }

        }
        return leap;
    }

    internal static int JalaliDays(int jYear, int jMonth, int jDay)
    {
        //Calculate total days of jalali years from the base calendar
        var leap = JLeap(jYear);
        for (var i = 0; i < jMonth - 1; i++)
        {
            jDay = jDay + JDayTable[leap, i];
        }

        leap = JLeapYears(jYear - 1);
        var iTotalDays = ((jYear - 1) * 365 + leap + jDay);

        return iTotalDays;
    }

    /// <summary>Converts a Gregorian Date of type <c>System.DateTime</c> class to Persian Date.</summary>
    /// <param name="date">DateTime to evaluate</param>
    /// <returns>string representation of Jalali Date</returns>
    public static PersianDate ToPersianDate(string date)
    {
        return ToPersianDate(DateTime.Parse(date, CultureHelper.NeutralCulture));
    }

    /// <summary>
    /// Converts a Gregorian Date of type <c>String</c> and a <c>TimeSpan</c> into a Persian Date.
    /// </summary>
    /// <param name="date"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    public static PersianDate ToPersianDate(string date, TimeSpan time)
    {
        var pd = ToPersianDate(date);
        pd.Hour = time.Hours;
        pd.Minute = time.Minutes;
        pd.Second = time.Seconds;

        return pd;
    }

    /// <summary>
    /// Converts a Gregorian Date of type <c>String</c> class to Persian Date.
    /// </summary>
    /// <param name="dt">Date to evaluate</param>
    /// <returns>string representation of Jalali Date.</returns>
    public static PersianDate ToPersianDate(DateTime dt)
    {
        var gyear = dt.Year;
        var gmonth = dt.Month;
        var gday = dt.Day;
        int i;

        //Calculate total days from the base of gregorian calendar
        var iTotalDays = GregDays(gyear, gmonth, gday);
        iTotalDays = iTotalDays - GYearOff;

        //Calculate total jalali years passed
        var jyear = (int)(iTotalDays / (Solar - 0.25 / 33));
        //Calculate passed leap years
        var leap = JLeapYears(jyear);

        //Calculate total days from the base of jalali calendar
        var jday = iTotalDays - (365 * jyear + leap);

        //Calculate the correct year of jalali calendar
        jyear++;

        if (jday == 0)
        {
            jyear--;
            jday = JLeap(jyear) == 1 ? 366 : 365;
        }
        else
        {
            if ((jday == 366) && (JLeap(jyear) != 1))
            {
                jday = 1;
                jyear++;
            }
        }

        //Calculate correct month of jalali calendar
        leap = JLeap(jyear);
        for (i = 0; i <= 12; i++)
        {
            if (jday <= JDayTable[leap, i])
            {
                break;
            }
            jday = jday - JDayTable[leap, i];
        }

        var iJMonth = i + 1;

        return new PersianDate(jyear, iJMonth, jday, dt.Hour, dt.Minute, dt.Second);
    }

    /// <summary>
    /// Converts a Persian Date of type <c>String</c> to Gregorian Date of type <c>DateTime</c> class.
    /// </summary>
    /// <param name="date">Date to evaluate</param>
    /// <returns>Gregorian DateTime representation of evaluated Jalali Date.</returns>
    public static DateTime ToGregorianDateTime(string date)
    {
        var pd = new PersianDate(date);
        return DateTime.Parse(ToGregorianDate(pd), CultureHelper.NeutralCulture);
    }

    public static DateTime ToGregorianDateTime(PersianDate date)
    {
        return DateTime.Parse(ToGregorianDate(date), CultureHelper.NeutralCulture);
    }

    /// <summary>
    /// Converts a Persian Date of type <c>String</c> to Gregorian Date of type <c>String</c>.
    /// </summary>
    /// <param name="date"></param>
    /// <returns>Gregorian DateTime representation in string format of evaluated Jalali Date.</returns>
    public static string ToGregorianDate(PersianDate date)
    {
        var jyear = date.Year;
        var jmonth = date.Month;
        var jday = date.Day;

        //Continue
        int i;

        var totalDays = JalaliDays(jyear, jmonth, jday);
        totalDays = totalDays + GYearOff;

        var gyear = (int)(totalDays / (Solar - 0.25 / 33));
        var Div4 = gyear / 4;
        var Div100 = gyear / 100;
        var Div400 = gyear / 400;
        var gdays = totalDays - (365 * gyear) - (Div4 - Div100 + Div400);
        gyear = gyear + 1;

        if (gdays == 0)
        {
            gyear--;
            gdays = GLeap(gyear) == 1 ? 366 : 365;
        }
        else
        {
            if (gdays == 366 && GLeap(gyear) != 1)
            {
                gdays = 1;
                gyear++;
            }
        }

        var leap = GLeap(gyear);
        for (i = 0; i <= 12; i++)
        {
            if (gdays <= GDayTable[leap, i])
            {
                break;
            }

            gdays = gdays - GDayTable[leap, i];
        }

        var iGMonth = i + 1;
        var iGDay = gdays;

        return (Utils.toDouble(iGMonth) + "/" + Utils.toDouble(iGDay) + "/" + gyear + " " + Utils.toDouble(date.Hour) + ":" + Utils.toDouble(date.Minute) + ":" + Utils.toDouble(date.Second));
    }

    internal static string DayOfWeek(PersianDate date)
    {
        if (!date.IsNull)
        {
            var dt = ToGregorianDateTime(date);
            return DayOfWeek(dt);
        }

        return string.Empty;
    }

    /// <summary>
    /// Gets Persian Weekday name from specified Gregorian Date.
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    internal static string DayOfWeek(DateTime date)
    {
        var DayOfWeek = date.DayOfWeek;
        string day = string.Empty;

        switch (DayOfWeek)
        {
            case DayOfWeek.Saturday:
                day = PersianWeekDayNames.Default.Shanbeh;
                break;
            case DayOfWeek.Sunday:
                day = PersianWeekDayNames.Default.Yekshanbeh;
                break;
            case DayOfWeek.Monday:
                day = PersianWeekDayNames.Default.Doshanbeh;
                break;
            case DayOfWeek.Tuesday:
                day = PersianWeekDayNames.Default.Seshanbeh;
                break;
            case DayOfWeek.Wednesday:
                day = PersianWeekDayNames.Default.Chaharshanbeh;
                break;
            case DayOfWeek.Thursday:
                day = PersianWeekDayNames.Default.Panjshanbeh;
                break;
            case DayOfWeek.Friday:
                day = PersianWeekDayNames.Default.Jomeh;
                break;
        }

        return day;
    }

    /// <summary>
    /// Returns number of days in specified month number.
    /// </summary>
    /// <param name="MonthNo">Month no to evaluate in integer</param>
    /// <returns>number of days in the evaluated month</returns>
    internal static int MonthDays(int MonthNo)
    {
        return (JDayTable[1, MonthNo - 1]);
    }

    #endregion
}

public static class CultureInfoExtensions
{
    public static bool IsFarsiCulture(this CultureInfo culture)
    {
        return culture.Equals(CultureHelper.FarsiCulture) || culture.Name.Equals("fa", StringComparison.InvariantCultureIgnoreCase);
    }

    public static bool IsArabicCulture(this CultureInfo culture)
    {
        return culture.Equals(CultureHelper.ArabicCulture) || culture.Name.Equals("ar", StringComparison.InvariantCultureIgnoreCase);
    }

    public static bool IsNeutralCulture(this CultureInfo culture)
    {
        return culture.Equals(CultureHelper.NeutralCulture);
    }
}

/// <summary>
/// Localizer class to work with internal localized strings.
/// </summary>
public class FALocalizeManager
{
    #region Fields

    private readonly FALocalizer fa = new FALocalizer();
    private readonly ARLocalizer ar = new ARLocalizer();
    private readonly ENLocalizer en = new ENLocalizer();
    private BaseLocalizer customLocalizer;
    private static FALocalizeManager instance;

    #endregion

    #region Ctor

    private FALocalizeManager()
    {
        FarsiCulture = new CultureInfo("fa-IR");
        ArabicCulture = new CultureInfo("ar-SA");
        InvariantCulture = CultureInfo.InvariantCulture;
    }

    #endregion

    #region Events

    /// <summary>
    /// Fired when Localizer has changed.
    /// </summary>
    public event EventHandler LocalizerChanged;

    #endregion

    #region Methods

    /// <summary>
    /// Returns an instance of the localized based on CurrentUICulture of the thread.
    /// </summary>
    /// <returns></returns>
    public BaseLocalizer GetLocalizer()
    {
        return GetLocalizerByCulture(Thread.CurrentThread.CurrentUICulture);
    }

    /// <summary>
    /// Returns a localizer instance based on the culture.
    /// </summary>
    internal BaseLocalizer GetLocalizerByCulture(CultureInfo ci)
    {
        if (customLocalizer != null)
            return customLocalizer;

        if (ci.Equals(FarsiCulture))
        {
            return fa;
        }

        if (ci.Equals(ArabicCulture))
        {
            return ar;
        }

        return en;
    }

    #endregion

    #region Props

    /// <summary>
    /// Singleton Instance of FALocalizeManager.
    /// </summary>
    public static FALocalizeManager Instance
    {
        get
        {
            if (instance == null)
                instance = new FALocalizeManager();

            return instance;
        }
    }

    /// <summary>
    /// Custom culture, when set , is used across all controls.
    /// </summary>
    public CultureInfo CustomCulture
    {
        get;
        set;
    }

    /// <summary>
    /// Farsi Culture
    /// </summary>
    public CultureInfo FarsiCulture
    {
        get;
        private set;
    }

    /// <summary>
    /// Arabic Culture
    /// </summary>
    public CultureInfo ArabicCulture
    {
        get;
        private set;
    }

    /// <summary>
    /// Invariant Culture
    /// </summary>
    public CultureInfo InvariantCulture
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets or Sets a new instance of Localizer. If this value is initialized (default is null), Localize Manager class will use the custom class provided, to interpret localized strings.
    /// </summary>
    public BaseLocalizer CustomLocalizer
    {
        get { return customLocalizer; }
        set
        {
            if (customLocalizer == value)
                return;

            customLocalizer = value;
            OnLocalizerChanged(EventArgs.Empty);
        }
    }

    /// <summary>
    /// Fires the LocalizerChanged event.
    /// </summary>
    /// <param name="e"></param>
    protected void OnLocalizerChanged(EventArgs e)
    {
        if (LocalizerChanged != null)
            LocalizerChanged(null, e);
    }

    internal bool IsCustomArabicCulture
    {
        get { return CustomCulture != null && CustomCulture.Equals(ArabicCulture); }
    }

    internal bool IsCustomFarsiCulture
    {
        get { return CustomCulture != null && CustomCulture.Equals(FarsiCulture); }
    }

    internal bool IsThreadCultureFarsi
    {
        get { return Thread.CurrentThread.CurrentUICulture.Equals(FarsiCulture); }
    }

    internal bool IsThreadCultureArabic
    {
        get { return Thread.CurrentThread.CurrentUICulture.Equals(ArabicCulture); }
    }

    #endregion
}

/// <summary>
/// Farsi Localizer
/// </summary>
public class FALocalizer : BaseLocalizer
{
    public override string GetLocalizedString(StringID id)
    {
        switch (id)
        {
            case StringID.Empty: return string.Empty;
            case StringID.Numbers_0: return "۰";
            case StringID.Numbers_1: return "۱";
            case StringID.Numbers_2: return "۲";
            case StringID.Numbers_3: return "۳";
            case StringID.Numbers_4: return "۴";
            case StringID.Numbers_5: return "۵";
            case StringID.Numbers_6: return "۶";
            case StringID.Numbers_7: return "۷";
            case StringID.Numbers_8: return "۸";
            case StringID.Numbers_9: return "۹";

            case StringID.FADateTextBox_Required: return "فیلد اجباری میباشد";
            case StringID.FAMonthView_None: return "خالی";
            case StringID.FAMonthView_Today: return "امروز";

            case StringID.PersianDate_InvalidDateFormat: return "ساختار تاریخ مجاز نمیباشد.";
            case StringID.PersianDate_InvalidDateTime: return "مقدار زمان/ساعت صحیح نمیباشد.";
            case StringID.PersianDate_InvalidDateTimeLength: return "متن وارد شده برای زمان/ساعت صحیح نمیباشد.";
            case StringID.PersianDate_InvalidDay: return "مقدار روز صحیح نمیباشد.";
            case StringID.PersianDate_InvalidEra: return "محدوده وارد شده صحیح نمیباشد.";
            case StringID.PersianDate_InvalidFourDigitYear: return "مقدار وارد شده را نمیتوان به سال تبدیل کرد.";
            case StringID.PersianDate_InvalidHour: return "مقدار ساعت صحیح نمیباشد.";
            case StringID.PersianDate_InvalidLeapYear: return "این سال ، سال کبیسه نیست. مقدار روز صحیح نمیباشد.";
            case StringID.PersianDate_InvalidMinute: return "مقدار دقیقه صحیح نمیباشد.";
            case StringID.PersianDate_InvalidMonth: return "مقدار ماه صحیح نمیباشد.";
            case StringID.PersianDate_InvalidMonthDay: return "مقدار ماه/روز صحیح نمیباشد.";
            case StringID.PersianDate_InvalidSecond: return "مقدار ثانیه صحیح نمیباشد.";
            case StringID.PersianDate_InvalidTimeFormat: return "ساختار زمان صحیح نمیباشد.";
            case StringID.PersianDate_InvalidYear: return "مقدار سال صحیح نمیباشد.";

            case StringID.Validation_Cancel: return "مقدار انتخاب شده مجاز نمیباشد.";
            case StringID.Validation_NotValid: return "مقدار انتخاب شده در محدوده مجاز نمیباشد.";
            case StringID.Validation_Required: return "انتخاب اجباری. لطفا مقداری برای این فیلد وارد کنید.";
            case StringID.Validation_NullText: return "[هیج مقداری انتخاب نشده]";

            case StringID.MessageBox_Ok: return "قبول";
            case StringID.MessageBox_Cancel: return "لغو";
            case StringID.MessageBox_Abort: return "لغو";
            case StringID.MessageBox_Ignore: return "ادامه عملیات";
            case StringID.MessageBox_Retry: return "سعی مجدد";
            case StringID.MessageBox_No: return "خیر";
            case StringID.MessageBox_Yes: return "بله";
        }

        return "";
    }

    public override string GetFormatterString(FormatterStringID stringID)
    {
        switch (stringID)
        {
            case FormatterStringID.CenturyPattern: return "%n %u";
            case FormatterStringID.CenturyFuturePrefix: return "";
            case FormatterStringID.CenturyFutureSuffix: return "بعد ";
            case FormatterStringID.CenturyPastPrefix: return "";
            case FormatterStringID.CenturyPastSuffix: return "قبل ";
            case FormatterStringID.CenturyName: return "قرن";
            case FormatterStringID.CenturyPluralName: return "قرن";
            case FormatterStringID.DayPattern: return "%n %u";
            case FormatterStringID.DayFuturePrefix: return "";
            case FormatterStringID.DayFutureSuffix: return "بعد ";
            case FormatterStringID.DayPastPrefix: return "";
            case FormatterStringID.DayPastSuffix: return "قبل ";
            case FormatterStringID.DayName: return "روز";
            case FormatterStringID.DayPluralName: return "روز";
            case FormatterStringID.DecadePattern: return "%n %u";
            case FormatterStringID.DecadeFuturePrefix: return "";
            case FormatterStringID.DecadeFutureSuffix: return "بعد ";
            case FormatterStringID.DecadePastPrefix: return "";
            case FormatterStringID.DecadePastSuffix: return "قبل ";
            case FormatterStringID.DecadeName: return "دهه";
            case FormatterStringID.DecadePluralName: return "دهه";
            case FormatterStringID.HourPattern: return "%n %u";
            case FormatterStringID.HourFuturePrefix: return "";
            case FormatterStringID.HourFutureSuffix: return "بعد ";
            case FormatterStringID.HourPastPrefix: return "";
            case FormatterStringID.HourPastSuffix: return "قبل ";
            case FormatterStringID.HourName: return "ساعت";
            case FormatterStringID.HourPluralName: return "ساعت";
            case FormatterStringID.JustNowPattern: return "%u";
            case FormatterStringID.JustNowFuturePrefix: return "";
            case FormatterStringID.JustNowFutureSuffix: return "چند لحظه بعد";
            case FormatterStringID.JustNowPastPrefix: return "چند لحظه قبل";
            case FormatterStringID.JustNowPastSuffix: return "";
            case FormatterStringID.JustNowName: return "";
            case FormatterStringID.JustNowPluralName: return "";
            case FormatterStringID.MillenniumPattern: return "%n %u";
            case FormatterStringID.MillenniumFuturePrefix: return "";
            case FormatterStringID.MillenniumFutureSuffix: return "بعد ";
            case FormatterStringID.MillenniumPastPrefix: return "";
            case FormatterStringID.MillenniumPastSuffix: return "قبل ";
            case FormatterStringID.MillenniumName: return "صده";
            case FormatterStringID.MillenniumPluralName: return "صده";
            case FormatterStringID.MillisecondPattern: return "%n %u";
            case FormatterStringID.MillisecondFuturePrefix: return "";
            case FormatterStringID.MillisecondFutureSuffix: return "بعد";
            case FormatterStringID.MillisecondPastPrefix: return "";
            case FormatterStringID.MillisecondPastSuffix: return "قبل ";
            case FormatterStringID.MillisecondName: return "هزارم ثانبه";
            case FormatterStringID.MillisecondPluralName: return "هزارم ثانیه";
            case FormatterStringID.MinutePattern: return "%n %u";
            case FormatterStringID.MinuteFuturePrefix: return "";
            case FormatterStringID.MinuteFutureSuffix: return "بعد ";
            case FormatterStringID.MinutePastPrefix: return "";
            case FormatterStringID.MinutePastSuffix: return "قبل ";
            case FormatterStringID.MinuteName: return "دقیقه";
            case FormatterStringID.MinutePluralName: return "دقیقه";
            case FormatterStringID.MonthPattern: return "%n %u";
            case FormatterStringID.MonthFuturePrefix: return "";
            case FormatterStringID.MonthFutureSuffix: return "بعد ";
            case FormatterStringID.MonthPastPrefix: return "";
            case FormatterStringID.MonthPastSuffix: return "قبل ";
            case FormatterStringID.MonthName: return "ماه";
            case FormatterStringID.MonthPluralName: return "ماه";
            case FormatterStringID.SecondPattern: return "%n %u";
            case FormatterStringID.SecondFuturePrefix: return "";
            case FormatterStringID.SecondFutureSuffix: return "بعد ";
            case FormatterStringID.SecondPastPrefix: return "";
            case FormatterStringID.SecondPastSuffix: return "قبل ";
            case FormatterStringID.SecondName: return "ثانیه";
            case FormatterStringID.SecondPluralName: return "ثانیه";
            case FormatterStringID.WeekPattern: return "%n %u";
            case FormatterStringID.WeekFuturePrefix: return "";
            case FormatterStringID.WeekFutureSuffix: return "بعد ";
            case FormatterStringID.WeekPastPrefix: return "";
            case FormatterStringID.WeekPastSuffix: return "قبل ";
            case FormatterStringID.WeekName: return "هفته";
            case FormatterStringID.WeekPluralName: return "هفته";
            case FormatterStringID.YearPattern: return "%n %u";
            case FormatterStringID.YearFuturePrefix: return "";
            case FormatterStringID.YearFutureSuffix: return "بعد ";
            case FormatterStringID.YearPastPrefix: return "";
            case FormatterStringID.YearPastSuffix: return "قبل ";
            case FormatterStringID.YearName: return "سال";
            case FormatterStringID.YearPluralName: return "سال";
        }

        return string.Empty;
    }

}

public enum FormatterStringID
{
    CenturyPattern,
    CenturyFuturePrefix,
    CenturyFutureSuffix,
    CenturyPastPrefix,
    CenturyPastSuffix,
    CenturyName,
    CenturyPluralName,
    DayPattern,
    DayFuturePrefix,
    DayFutureSuffix,
    DayPastPrefix,
    DayPastSuffix,
    DayName,
    DayPluralName,
    DecadePattern,
    DecadeFuturePrefix,
    DecadeFutureSuffix,
    DecadePastPrefix,
    DecadePastSuffix,
    DecadeName,
    DecadePluralName,
    HourPattern,
    HourFuturePrefix,
    HourFutureSuffix,
    HourPastPrefix,
    HourPastSuffix,
    HourName,
    HourPluralName,
    JustNowPattern,
    JustNowFuturePrefix,
    JustNowFutureSuffix,
    JustNowPastPrefix,
    JustNowPastSuffix,
    JustNowName,
    JustNowPluralName,
    MillenniumPattern,
    MillenniumFuturePrefix,
    MillenniumFutureSuffix,
    MillenniumPastPrefix,
    MillenniumPastSuffix,
    MillenniumName,
    MillenniumPluralName,
    MillisecondPattern,
    MillisecondFuturePrefix,
    MillisecondFutureSuffix,
    MillisecondPastPrefix,
    MillisecondPastSuffix,
    MillisecondName,
    MillisecondPluralName,
    MinutePattern,
    MinuteFuturePrefix,
    MinuteFutureSuffix,
    MinutePastPrefix,
    MinutePastSuffix,
    MinuteName,
    MinutePluralName,
    MonthPattern,
    MonthFuturePrefix,
    MonthFutureSuffix,
    MonthPastPrefix,
    MonthPastSuffix,
    MonthName,
    MonthPluralName,
    SecondPattern,
    SecondFuturePrefix,
    SecondFutureSuffix,
    SecondPastPrefix,
    SecondPastSuffix,
    SecondName,
    SecondPluralName,
    WeekPattern,
    WeekFuturePrefix,
    WeekFutureSuffix,
    WeekPastPrefix,
    WeekPastSuffix,
    WeekName,
    WeekPluralName,
    YearPattern,
    YearFuturePrefix,
    YearFutureSuffix,
    YearPastPrefix,
    YearPastSuffix,
    YearName,
    YearPluralName,
}

public class InvalidPersianDateException : Exception
{
    public InvalidPersianDateException()
        : base(string.Empty)
    {
    }

    public InvalidPersianDateException(string message)
        : base(message)
    {
    }

    public InvalidPersianDateException(string message, object value)
    {
        InvalidValue = value;
    }

    public object InvalidValue
    {
        get;
        private set;
    }
}

public class InvalidPersianDateFormatException : Exception
{
    public InvalidPersianDateFormatException(string message)
        : base(message)
    {
    }

    public InvalidPersianDateFormatException()
        : base(string.Empty)
    {
    }
}

/// <summary>
/// CultureInfo for "FA-IR" culture, which has correct calendar information.
/// </summary>
public class PersianCultureInfo : CultureInfo
{
    #region FieldNames

    private struct CultureFieldNames
    {
        public string Calendar
        {
            get { return "calendar"; }
        }

        public string IsReadonly
        {
            get { return "m_isReadOnly"; }
        }
    }

    #endregion

    #region Fields

    private static CultureFieldNames FieldNames;
    private readonly PersianCalendar calendar;
    private readonly System.Globalization.PersianCalendar systemCalendar;
    private DateTimeFormatInfo format;

    #endregion

    #region Ctor

    /// <summary>
    /// Initializes a new instance of the <see cref="PersianCultureInfo"/> class.
    /// </summary>
    public PersianCultureInfo()
        : base("fa-IR", false)
    {
        calendar = new PersianCalendar();
        systemCalendar = new System.Globalization.PersianCalendar();
        format = CreateDateTimeFormatInfo();
        SetCalendar();
    }

    #endregion

    #region Private Methods

    protected void SetCalendar()
    {
        ReflectionHelper.SetField(format, FieldNames.Calendar, systemCalendar);
        base.DateTimeFormat = format;
    }

    protected internal DateTimeFormatInfo CreateDateTimeFormatInfo()
    {
        if (format == null)
        {
            format = new DateTimeFormatInfo
            {
                AbbreviatedDayNames = PersianDateTimeFormatInfo.AbbreviatedDayNames,
                AbbreviatedMonthGenitiveNames = PersianDateTimeFormatInfo.AbbreviatedMonthGenitiveNames,
                AbbreviatedMonthNames = PersianDateTimeFormatInfo.AbbreviatedMonthNames,
                AMDesignator = PersianDateTimeFormatInfo.AMDesignator,
                DateSeparator = PersianDateTimeFormatInfo.DateSeparator,
                DayNames = PersianDateTimeFormatInfo.DayNames,
                FirstDayOfWeek = PersianDateTimeFormatInfo.FirstDayOfWeek,
                FullDateTimePattern = PersianDateTimeFormatInfo.FullDateTimePattern,
                LongDatePattern = PersianDateTimeFormatInfo.LongDatePattern,
                LongTimePattern = PersianDateTimeFormatInfo.LongTimePattern,
                MonthDayPattern = PersianDateTimeFormatInfo.MonthDayPattern,
                MonthGenitiveNames = PersianDateTimeFormatInfo.MonthGenitiveNames,
                MonthNames = PersianDateTimeFormatInfo.MonthNames,
                PMDesignator = PersianDateTimeFormatInfo.PMDesignator,
                ShortDatePattern = PersianDateTimeFormatInfo.ShortDatePattern,
                ShortestDayNames = PersianDateTimeFormatInfo.ShortestDayNames,
                ShortTimePattern = PersianDateTimeFormatInfo.ShortTimePattern,
                TimeSeparator = PersianDateTimeFormatInfo.TimeSeparator,
                YearMonthPattern = PersianDateTimeFormatInfo.YearMonthPattern
            };

            //Make format information readonly to fix
            //cloning problems that might happen with 
            //other controls.
            ReflectionHelper.SetField(format, FieldNames.IsReadonly, true);
        }

        return format;
    }

    #endregion

    #region Props

    /// <summary>
    /// Gets the default calendar used by the culture.
    /// </summary>
    /// <value></value>
    /// <returns>
    /// A <see cref="T:System.Globalization.Calendar"/> that represents the default calendar used by the culture.
    /// </returns>
    public override Calendar Calendar
    {
        get { return systemCalendar; }
    }

    /// <summary>
    /// Gets the list of calendars that can be used by the culture.
    /// </summary>
    /// <value></value>
    /// <returns>
    /// An array of type <see cref="T:System.Globalization.Calendar"/> that represents the calendars that can be used by the culture represented by the current <see cref="T:System.Globalization.CultureInfo"/>.
    /// </returns>
    public override Calendar[] OptionalCalendars
    {
        get { return new Calendar[] { systemCalendar, calendar }; }
    }

    /// <summary>
    /// Creates a copy of the current <see cref="T:System.Globalization.CultureInfo"/>.
    /// </summary>
    /// <returns>
    /// A copy of the current <see cref="T:System.Globalization.CultureInfo"/>.
    /// </returns>
    public override object Clone()
    {
        return new PersianCultureInfo();
    }

    public new bool IsReadOnly
    {
        get { return true; }
    }

    public override bool IsNeutralCulture
    {
        get { return false; }
    }

    /// <summary>
    /// Gets or sets a <see cref="T:System.Globalization.DateTimeFormatInfo"/> that defines the culturally appropriate format of displaying dates and times.
    /// </summary>
    /// <value></value>
    /// <returns>
    /// A <see cref="T:System.Globalization.DateTimeFormatInfo"/> that defines the culturally appropriate format of displaying dates and times.
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// The property is set to null.
    /// </exception>
    public override DateTimeFormatInfo DateTimeFormat
    {
        get { return format; }
        set
        {
            if (value == null)
                throw new ArgumentNullException("value", "value can not be null.");

            format = value;
        }
    }

    #endregion
}

public sealed class PersianDateTimeFormatInfo
{
    public static string[] AbbreviatedDayNames
    {
        get { return PersianWeekDayNames.Default.DaysAbbr.ToArray(); }
    }

    public static string[] AbbreviatedMonthGenitiveNames
    {
        get { return PersianMonthNames.Default.Months.ToArray(); }
    }

    public static string[] AbbreviatedMonthNames
    {
        get { return PersianMonthNames.Default.Months.ToArray(); }
    }

    public static string AMDesignator
    {
        get { return "ق.ظ"; }
    }

    public static string DateSeparator
    {
        get { return "/"; }
    }

    public static string[] DayNames
    {
        get { return PersianWeekDayNames.Default.Days.ToArray(); }
    }

    public static DayOfWeek FirstDayOfWeek
    {
        get { return DayOfWeek.Saturday; }
    }

    public static string FullDateTimePattern
    {
        get { return "tt hh:mm:ss yyyy mmmm dd dddd"; }
    }

    public static string LongDatePattern
    {
        get { return "yyyy MMMM dd, dddd"; }
    }

    public static string LongTimePattern
    {
        get { return "hh:mm:ss tt"; }
    }

    public static string MonthDayPattern
    {
        get { return "dd MMMM"; }
    }

    public static string[] MonthGenitiveNames
    {
        get { return PersianMonthNames.Default.Months.ToArray(); }
    }

    public static string[] MonthNames
    {
        get { return PersianMonthNames.Default.Months.ToArray(); }
    }

    public static string PMDesignator
    {
        get { return "ب.ظ"; }
    }

    public static string ShortDatePattern
    {
        get { return "yyyy/MM/dd"; }
    }

    public static string[] ShortestDayNames
    {
        get { return PersianWeekDayNames.Default.DaysAbbr.ToArray(); }
    }

    public static string ShortTimePattern
    {
        get { return "hh:mm tt"; }
    }

    public static string TimeSeparator
    {
        get { return ":"; }
    }

    public static string YearMonthPattern
    {
        get { return "yyyy, MMMM"; }
    }

    public static string GetWeekDay(DayOfWeek day)
    {
        return DayNames[(int)day];
    }

    public static string GetWeekDayAbbr(DayOfWeek day)
    {
        return AbbreviatedDayNames[(int)day];
    }

    public static DayOfWeek GetDayOfWeek(int day)
    {
        switch (day)
        {
            case 0:
                return DayOfWeek.Saturday;
            case 1:
                return DayOfWeek.Sunday;
            case 2:
                return DayOfWeek.Monday;
            case 3:
                return DayOfWeek.Tuesday;
            case 4:
                return DayOfWeek.Wednesday;
            case 5:
                return DayOfWeek.Thursday;
            case 6:
                return DayOfWeek.Friday;
            default:
                throw new ArgumentOutOfRangeException("day", "invalid day value");
        }
    }

    public static string GetWeekDayByIndex(int day)
    {
        return GetWeekDay(GetDayOfWeek(day));
    }

    public static string GetWeekDayAbbrByIndex(int day)
    {
        switch (day)
        {
            case 0:
                return GetWeekDayAbbr(DayOfWeek.Saturday);
            case 1:
                return GetWeekDayAbbr(DayOfWeek.Sunday);
            case 2:
                return GetWeekDayAbbr(DayOfWeek.Monday);
            case 3:
                return GetWeekDayAbbr(DayOfWeek.Tuesday);
            case 4:
                return GetWeekDayAbbr(DayOfWeek.Wednesday);
            case 5:
                return GetWeekDayAbbr(DayOfWeek.Thursday);
            case 6:
                return GetWeekDayAbbr(DayOfWeek.Friday);
            default:
                throw new ArgumentOutOfRangeException("day", "invalid day value");
        }
    }

    public static int GetDayIndex(DayOfWeek day)
    {
        switch (day)
        {
            case DayOfWeek.Sunday:
                return 1;
            case DayOfWeek.Monday:
                return 2;
            case DayOfWeek.Tuesday:
                return 3;
            case DayOfWeek.Wednesday:
                return 4;
            case DayOfWeek.Thursday:
                return 5;
            case DayOfWeek.Friday:
                return 6;
            case DayOfWeek.Saturday:
                return 0;
            default:
                throw new ArgumentOutOfRangeException("day");
        }
    }
}

internal class PersianMonthNames
{
    #region Fields

    public string Farvardin = "فروردین";
    public string Ordibehesht = "اردیبهشت";
    public string Khordad = "خرداد";
    public string Tir = "تیر";
    public string Mordad = "مرداد";
    public string Shahrivar = "شهریور";
    public string Mehr = "مهر";
    public string Aban = "آبان";
    public string Azar = "آذر";
    public string Day = "دی";
    public string Bahman = "بهمن";
    public string Esfand = "اسفند";
    private readonly List<string> months;
    private static PersianMonthNames instance;

    #endregion

    #region Ctor

    private PersianMonthNames()
    {
        months = new List<string>
                         {
                             Farvardin,
                             Ordibehesht,
                             Khordad,
                             Tir,
                             Mordad,
                             Shahrivar,
                             Mehr,
                             Aban,
                             Azar,
                             Day,
                             Bahman,
                             Esfand,
                             ""
                         };
    }

    #endregion

    #region Singleton

    public static PersianMonthNames Default
    {
        get
        {
            if (instance == null)
                instance = new PersianMonthNames();

            return instance;
        }
    }

    #endregion

    #region Indexer

    internal List<string> Months
    {
        get { return months; }
    }

    public string this[int month]
    {
        get { return months[month]; }
    }

    #endregion
}

internal class PersianWeekDayNames
{
    #region fields

    public string Shanbeh = "شنبه";
    public string Yekshanbeh = "یکشنبه";
    public string Doshanbeh = "دوشنبه";
    public string Seshanbeh = "ﺳﻪشنبه";
    public string Chaharshanbeh = "چهارشنبه";
    public string Panjshanbeh = "پنجشنبه";
    public string Jomeh = "جمعه";

    public string Sh = "ش";
    public string Ye = "ی";
    public string Do = "د";
    public string Se = "س";
    public string Ch = "چ";
    public string Pa = "پ";
    public string Jo = "ج";

    private readonly List<string> days;
    private readonly List<string> daysAbbr;
    private static PersianWeekDayNames instance;

    #endregion

    #region Ctor

    private PersianWeekDayNames()
    {
        days = new List<string>
                       {
                           Yekshanbeh,
                           Doshanbeh,
                           Seshanbeh,
                           Chaharshanbeh,
                           Panjshanbeh,
                           Jomeh,
                           Shanbeh,
                       };

        daysAbbr = new List<string>
                           {
                               Ye,
                               Do,
                               Se,
                               Ch,
                               Pa,
                               Jo,
                               Sh,
                           };
    }

    #endregion

    #region Indexer

    public static PersianWeekDayNames Default
    {
        get
        {
            if (instance == null)
                instance = new PersianWeekDayNames();

            return instance;
        }
    }

    #endregion

    #region Props

    internal List<string> Days
    {
        get { return days; }
    }

    internal List<string> DaysAbbr
    {
        get { return daysAbbr; }
    }

    #endregion
}

internal static class ReflectionHelper
{
    /// <summary>
    /// Find and returns a FieldInfo by its name, on 
    /// the specified type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="fieldName"></param>
    /// <returns></returns>
    public static FieldInfo GetField(Type type, string fieldName)
    {
        return type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
    }

    /// <summary>
    /// Sets a value to a field of the owner object
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="fieldName"></param>
    /// <param name="value"></param>
    public static void SetField(object owner, string fieldName, object value)
    {
        if (owner == null)
            throw new ArgumentNullException("owner", "owner should point to a object. works on instance fields only");

        Type type = owner.GetType();
        FieldInfo fieldinfo = GetField(type, fieldName);

        if (fieldinfo == null)
            throw new ArgumentNullException(fieldName, "fieldName can not be found on the type");

        fieldinfo.SetValue(owner, value);
    }

    /// <summary>
    /// Find and returns a FieldInfo by its name, on 
    /// the specified type.
    /// </summary>
    /// <param name="fieldName"></param>
    /// <returns></returns>
    public static TResult GetField<TResult>(object owner, string fieldName)
    {
        return (TResult)GetField(owner, fieldName);
    }

    /// <summary>
    /// returns value of a field in the owner object.
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="fieldName"></param>
    /// <returns></returns>
    public static object GetField(object owner, string fieldName)
    {
        if (owner == null)
            throw new ArgumentNullException("owner", "owner should point to a object. works on instance fields only");

        var type = owner.GetType();
        var fieldinfo = GetField(type, fieldName);

        if (fieldinfo == null)
            throw new ArgumentNullException(fieldName, "fieldName can not be found on the type");

        return fieldinfo.GetValue(owner);
    }

    /// <summary>
    /// Returns ProprtyInfo of a 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="owner"></param>
    /// <param name="propName"></param>
    /// <returns></returns>
    public static PropertyInfo GetProperty(Type type, object owner, string propName)
    {
        return type.GetProperty(propName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
    }

    /// <summary>
    /// Returns value of a property in the owner object.
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="propName"></param>
    /// <returns></returns>
    public static object GetProperty(object owner, string propName)
    {
        if (owner == null)
            throw new ArgumentNullException("owner", "owner should point to a object. works on instance fields only");

        var type = owner.GetType();
        var propInfo = GetProperty(type, owner, propName);

        if (propInfo == null)
            throw new ArgumentNullException(propName, "propName can not be found on the type");

        return propInfo.GetValue(owner, null);
    }

    /// <summary>
    /// Returns value of a property in the owner object.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="owner"></param>
    /// <param name="propName"></param>
    /// <returns></returns>
    public static TResult GetProperty<TResult>(object owner, string propName)
    {
        return (TResult)GetProperty(owner, propName);
    }

    public static void InvokeMethod(object owner, string methodName, params object[] param)
    {
        var type = owner.GetType();
        var mi = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        mi.Invoke(owner, param);
    }

    public static void InvokeStaticMethod(Type ownerType, string methodName, params object[] param)
    {
        var mi = ownerType.GetMethod(methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

        mi.Invoke(null, param);
    }
}

internal static class Utils
{
    /// <summary>
    /// Adds a preceding zero to single day or months
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    internal static string toDouble(int i)
    {
        return i > 9 ? i.ToString() : string.Format("0{0}", i);
    }

    /// <summary>
    /// Converts a number in string format e.g. 14500 to its localized version, if <c>Localized</c> value is set to <c>true</c>.
    /// </summary>
    /// <param name="num"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public static string toFarsi(string num, CultureInfo culture)
    {
        if (string.IsNullOrEmpty(num))
            return num;

        var numEnglish = "";

        for (var i = 0; i < num.Length; i++)
        {
            var s = num.Substring(i, 1);
            switch (s)
            {
                case "0":
                    numEnglish = numEnglish + FALocalizeManager.Instance.GetLocalizerByCulture(culture).GetLocalizedString(StringID.Numbers_0);
                    break;
                case "1":
                    numEnglish = numEnglish + FALocalizeManager.Instance.GetLocalizerByCulture(culture).GetLocalizedString(StringID.Numbers_1);
                    break;
                case "2":
                    numEnglish = numEnglish + FALocalizeManager.Instance.GetLocalizerByCulture(culture).GetLocalizedString(StringID.Numbers_2);
                    break;
                case "3":
                    numEnglish = numEnglish + FALocalizeManager.Instance.GetLocalizerByCulture(culture).GetLocalizedString(StringID.Numbers_3);
                    break;
                case "4":
                    numEnglish = numEnglish + FALocalizeManager.Instance.GetLocalizerByCulture(culture).GetLocalizedString(StringID.Numbers_4);
                    break;
                case "5":
                    numEnglish = numEnglish + FALocalizeManager.Instance.GetLocalizerByCulture(culture).GetLocalizedString(StringID.Numbers_5);
                    break;
                case "6":
                    numEnglish = numEnglish + FALocalizeManager.Instance.GetLocalizerByCulture(culture).GetLocalizedString(StringID.Numbers_6);
                    break;
                case "7":
                    numEnglish = numEnglish + FALocalizeManager.Instance.GetLocalizerByCulture(culture).GetLocalizedString(StringID.Numbers_7);
                    break;
                case "8":
                    numEnglish = numEnglish + FALocalizeManager.Instance.GetLocalizerByCulture(culture).GetLocalizedString(StringID.Numbers_8);
                    break;
                case "9":
                    numEnglish = numEnglish + FALocalizeManager.Instance.GetLocalizerByCulture(culture).GetLocalizedString(StringID.Numbers_9);
                    break;
                default:
                    numEnglish = numEnglish + s;
                    break;
            }
        }

        return (numEnglish);
    }

    /// <summary>
    /// Converts an English number to it's Farsi value.
    /// </summary>
    /// <remarks>This method only converts the numbers in a string, and does not convert any non-numeric characters.</remarks>
    /// <param name="num"></param>
    /// <returns></returns>
    public static string toFarsi(string num)
    {
        return toFarsi(num, FALocalizeManager.Instance.FarsiCulture);
    }

}
