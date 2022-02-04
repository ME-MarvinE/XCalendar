using System;
using System.Collections.Generic;
using System.Globalization;

namespace XCalendar.Extensions
{
    public static partial class DateTimeExtensions
    {
        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of weeks to the value of instance.
        /// </summary>
        /// <returns> An object whose value is the sum of the date and time represented by this instance and the number of weeks represented by <paramref name="value"/>.
        /// </returns>
        public static DateTime AddWeeks(this DateTime Self, int value)
        {
            return Self.AddDays(value * 7);
        }
        /// <summary>
        /// Gets the first day of this instance's week.
        /// </summary>
        /// <returns>A <see cref="DateTime"/> representing the first day of the week.</returns>
        public static DateTime FirstDayOfWeek(this DateTime Self)
        {
            return Self.FirstDayOfWeek(CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek);
        }
        /// <summary>
        /// Gets the first day of this instance's week using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// <param name="StartingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// <returns>A <see cref="DateTime"/> representing the first day of the week.</returns>
        public static DateTime FirstDayOfWeek(this DateTime Self, DayOfWeek StartingDayOfWeek)
        {
            DateTime FirstDayOfWeek = Self.Date;

            try
            {
                while (FirstDayOfWeek.DayOfWeek != StartingDayOfWeek)
                {
                    FirstDayOfWeek = FirstDayOfWeek.AddDays(-1);
                }
            }
            catch (ArgumentOutOfRangeException Ex) when (Ex.TargetSite.DeclaringType == typeof(DateTime))
            {
            }

            return FirstDayOfWeek;
        }
        /// <summary>
        /// Gets the last day of this instance's week
        /// </summary>
        /// <returns>A <see cref="DateTime"/> representing the first day of the week.</returns>
        public static DateTime LastDayOfWeek(this DateTime Self)
        {
            return Self.LastDayOfWeek(CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek);
        }
        /// <summary>
        /// Gets the last day of this instance's week using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// <param name="StartingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// <returns>A <see cref="DateTime"/> representing the last day of the week.</returns>
        public static DateTime LastDayOfWeek(this DateTime Self, DayOfWeek StartingDayOfWeek)
        {
            DateTime LastDayOfWeek = Self.Date;

            try
            {
                while (LastDayOfWeek.AddDays(1).DayOfWeek != StartingDayOfWeek)
                {
                    LastDayOfWeek = LastDayOfWeek.AddDays(1);
                }
            }
            catch (ArgumentOutOfRangeException Ex) when (Ex.TargetSite.DeclaringType == typeof(DateTime))
            {
            }

            return LastDayOfWeek;
        }
        /// <summary>
        /// Gets the first day this instance's month.
        /// </summary>
        /// <returns>A <see cref="DateTime"/> representing the first day of the month.</returns>
        public static DateTime FirstDayOfMonth(this DateTime Self)
        {
            return new DateTime(Self.Year, Self.Month, 1);
        }
        /// <summary>
        /// Gets the last day of this instance's month.
        /// </summary>
        /// <returns>A <see cref="DateTime"/> representing the last day of the month.</returns>
        public static DateTime LastDayOfMonth(this DateTime Self)
        {
            return new DateTime(Self.Year, Self.Month, DateTime.DaysInMonth(Self.Year, Self.Month));
        }
        /// <summary>
        /// Gets the first day this instance's year.
        /// </summary>
        /// <returns>A <see cref="DateTime"/> representing the first day of the year.</returns>
        public static DateTime FirstDayOfYear(this DateTime Self)
        {
            return new DateTime(Self.Year, 1, 1);
        }
        /// <summary>
        /// Gets the last day of this instance's year.
        /// </summary>
        /// <returns>A <see cref="DateTime"/> representing the last day of the year.</returns>
        public static DateTime LastDayOfYear(this DateTime Self)
        {
            return new DateTime(Self.Year, 12, 31);
        }
        /// <summary>
        /// Gets the position of this instance's day in this instance's week.
        /// </summary>
        /// <returns>The number representing the position of this instance's day in this instance's week.</returns>
        public static int DayOfWeek(this DateTime Self)
        {
            return Self.DayOfWeek(CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek);
        }
        /// <summary>
        /// Gets the position of this instance's day in this instance's week using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// <param name="StartingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// <returns>The number representing the position of this instance's day in this instance's week.</returns>
        public static int DayOfWeek(this DateTime Self, DayOfWeek StartingDayOfWeek)
        {
            List<DateTime> CurrentWeek = Self.DaysOfWeek(StartingDayOfWeek);
            return CurrentWeek.IndexOf(Self.Date) + 1;
        }
        /// <summary>
        /// Gets which week of this instance's month this instance is in.
        /// </summary>
        /// <returns>The number corresponding to which week of this instance's month it is in</returns>
        public static int CalendarWeekOfMonth(this DateTime Self)
        {
            return Self.CalendarWeekOfMonth(CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek);
        }
        /// <summary>
        /// Gets which week of this instance's month this instance is in using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// <param name="StartingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// <returns>The number corresponding to which week of this instance's month it is in</returns>
        public static int CalendarWeekOfMonth(this DateTime Self, DayOfWeek StartingDayOfWeek)
        {
            for (int i = Self.CalendarWeeksInMonth(StartingDayOfWeek); i > 0; i--)
            {
                if (Self.CalendarWeekInMonth(i, StartingDayOfWeek).Contains(Self.Date)) { return i; }
            }
            throw new Exception($"The {nameof(DateTime)} is not present in any of its month's weeks.");
        }
        /// <summary>
        /// Gets the specified week in this instance's month.
        /// </summary>
        /// <param name="WeekNumber">The week to get the days from relative to the start of the month.</param>
        /// <returns>The list of days inside the specified week in this instance's month.</returns>
        /// <exception cref="ArgumentOutOfRangeException">he specified week number is outside the scope of the instance's month.</exception>
        public static List<DateTime> CalendarWeekInMonth(this DateTime Self, int Week)
        {
            return Self.CalendarWeekInMonth(Week, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
        }
        /// <summary>
        /// Gets the specified week in this instance's month using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// <param name="WeekNumber">The week to get the days from relative to the start of the month.</param>
        /// <param name="StartingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// <returns>The list of days inside the specified week in this instance's month.</returns>
        /// <exception cref="ArgumentOutOfRangeException">he specified week number is outside the scope of the instance's month.</exception>
        public static List<DateTime> CalendarWeekInMonth(this DateTime Self, int Week, DayOfWeek StartingDayOfWeek)
        {
            int CheckWeek = 0;
            List<DateTime> DaysInWeek = new List<DateTime>();

            if (Week < 1 || Week > Self.CalendarWeeksInMonth(StartingDayOfWeek))
            {
                throw new ArgumentOutOfRangeException("The specified week number is outside the scope of the month");
            }

            try
            {
                for (DateTime i = Self.FirstDayOfMonth().FirstDayOfWeek(StartingDayOfWeek); CheckWeek <= Week; i = i.AddDays(1))
                {
                    if (i.DayOfWeek == StartingDayOfWeek) { CheckWeek += 1; }
                    if (CheckWeek == Week)
                    {
                        DaysInWeek.Add(i);
                    }
                }
            }
            catch (ArgumentOutOfRangeException Ex) when (Ex.TargetSite.DeclaringType == typeof(DateTime))
            {
            }
            return DaysInWeek;
        }
        /// <summary>
        /// Gets the number of weeks in this instance's month counting the weeks that span into the previous or next month.
        /// </summary>
        /// <returns>The number of weeks in this instance's month counting the weeks that span into the previous or next year.</returns>
        public static int CalendarWeeksInMonth(this DateTime Self)
        {
            return Self.CalendarWeeksInMonth(CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek);
        }
        /// <summary>
        /// Gets the number of weeks in this instance's month counting the weeks that span into the previous or next month using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// /// <param name="StartingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// <returns>The number of weeks in this instance's month counting the weeks that span into the previous or next year.</returns>
        public static int CalendarWeeksInMonth(this DateTime Self, DayOfWeek StartingDayOfWeek)
        {
            int CalendarDaysInMonth = Self.CalendarPreviousDaysInMonth(StartingDayOfWeek).Count + DateTime.DaysInMonth(Self.Year, Self.Month) + Self.CalendarNextDaysInMonth(StartingDayOfWeek).Count;
            return (int)Math.Ceiling((double)CalendarDaysInMonth / 7);
        }
        /// <summary>
        /// Gets the days in the month including days from weeks that spill into other months.
        /// </summary>
        /// <returns>The days in the month including days from weeks that spill into other months.</returns>
        public static List<DateTime> CalendarDaysInMonth(this DateTime Self)
        {
            return Self.CalendarDaysInMonth(CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
        }
        /// <summary>
        /// Gets the days in the month including days from weeks that spill into other months using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// <param name="StartingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// <returns>The days in the month including days from weeks that spill into other months.</returns>
        public static List<DateTime> CalendarDaysInMonth(this DateTime Self, DayOfWeek StartingDayOfWeek)
        {
            List<DateTime> CalendarDaysInMonth = new List<DateTime>();
            int WeekCount = Self.CalendarWeeksInMonth(StartingDayOfWeek);

            for (int i = 0; i < WeekCount; i++)
            {
                CalendarDaysInMonth.AddRange(Self.CalendarWeekInMonth(i + 1, StartingDayOfWeek));
            }

            return CalendarDaysInMonth;
        }
        /// <summary>
        /// Gets the days which are before this instance's month and within the same week as its first day.
        /// </summary>
        /// <returns>The list of days which are before this instance's month and within the same week as its first day.</returns>
        public static List<DateTime> CalendarPreviousDaysInMonth(this DateTime Self)
        {
            return Self.CalendarPreviousDaysInMonth(CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek);
        }
        /// <summary>
        /// Gets the days which are before this instance's month and within the same week as its first day using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// <param name="StartingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// <returns>The list of days which are before this instance's month and within the same week as its first day.</returns>
        public static List<DateTime> CalendarPreviousDaysInMonth(this DateTime Self, DayOfWeek StartingDayOfWeek)
        {
            List<DateTime> ReturnValue = new List<DateTime>();
            for (DateTime i = Self.FirstDayOfMonth().FirstDayOfWeek(StartingDayOfWeek); i.Day > Self.FirstDayOfMonth().Day; i = i.AddDays(1))
            {
                ReturnValue.Add(i);
            }
            return ReturnValue;
        }
        /// <summary>
        /// Gets the days which are after this instance's month and within the same week as its last day.
        /// </summary>
        /// <returns>The list of days which are after this instance's month and within the same week as its last day.</returns>
        public static List<DateTime> CalendarNextDaysInMonth(this DateTime Self)
        {
            return Self.CalendarNextDaysInMonth(CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek);
        }
        /// <summary>
        /// Gets the days which are after this instance's month and within the same week as its last day using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// <param name="StartingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// <returns>The list of days which are after this instance's month and within the same week as its last day.</returns>
        public static List<DateTime> CalendarNextDaysInMonth(this DateTime Self, DayOfWeek StartingDayOfWeek)
        {
            List<DateTime> ReturnValue = new List<DateTime>();

            try
            {
                for (DateTime i = Self.LastDayOfMonth().AddDays(1); i.DayOfWeek != StartingDayOfWeek; i = i.AddDays(1))
                {
                    ReturnValue.Add(i);
                }
            }
            catch (ArgumentOutOfRangeException Ex) when (Ex.TargetSite.DeclaringType == typeof(DateTime))
            {
            }

            return ReturnValue;
        }
        /// <summary>
        /// Gets the highest number of weeks that occur inside a month within this instance's year.
        /// </summary>
        /// <returns>The highest number of weeks that occur inside a month within this instance's year.</returns>
        public static int CalendarHighestMonthWeekCountOfYear(this DateTime Self)
        {
            return Self.CalendarHighestMonthWeekCountOfYear(CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek);
        }
        /// <summary>
        /// Gets the highest number of weeks that occur inside a month within this instance's year using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// <param name="StartingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// <returns>The highest number of weeks that occur inside a month within this instance's year.</returns>
        public static int CalendarHighestMonthWeekCountOfYear(this DateTime Self, DayOfWeek StartingDayOfWeek)
        {
            int HighestMonthWeekCountOfYear = 0;

            try
            {
                for (DateTime i = new DateTime(Self.Year, 1, 1); i.Year == Self.Year; i = i.AddMonths(1))
                {
                    int WeeksInMonth = i.CalendarWeeksInMonth(StartingDayOfWeek);
                    if (WeeksInMonth > HighestMonthWeekCountOfYear) { HighestMonthWeekCountOfYear = WeeksInMonth; }
                }
            }
            catch (ArgumentOutOfRangeException Ex) when (Ex.TargetSite.DeclaringType == typeof(DateTime))
            {
            }

            return HighestMonthWeekCountOfYear;
        }
        /// <summary>
        /// Gets the lowest number of weeks that occur inside a month within this instance's year.
        /// </summary>
        /// <returns>The lowest number of weeks that occur inside a month within this instance's year.</returns>
        public static int CalendarLowestMonthWeekCountOfYear(this DateTime Self)
        {
            return Self.CalendarLowestMonthWeekCountOfYear(CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek);
        }
        /// <summary>
        /// Gets the lowest number of weeks that occur inside a month within this instance's year using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// <param name="StartingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// <returns>The lowest number of weeks that occur inside a month within this instance's year.</returns>
        public static int CalendarLowestMonthWeekCountOfYear(this DateTime Self, DayOfWeek StartingDayOfWeek)
        {
            int LowestMonthWeekCountOfYear = Self.CalendarDaysInMonth(StartingDayOfWeek).Count;

            try
            {
                for (DateTime i = new DateTime(Self.Year, 1, 1); i.Year == Self.Year; i = i.AddMonths(1))
                {
                    int WeeksInMonth = i.CalendarWeeksInMonth(StartingDayOfWeek);
                    if (WeeksInMonth < LowestMonthWeekCountOfYear) { LowestMonthWeekCountOfYear = WeeksInMonth; }
                }
            }
            catch (ArgumentOutOfRangeException Ex) when (Ex.TargetSite.DeclaringType == typeof(DateTime))
            {
            }

            return LowestMonthWeekCountOfYear;
        }
        /// <summary>
        /// Gets the dates in this instance's week.
        /// </summary>
        /// <param name="WeekOffset">How many weeks to offset by from this instance's week.</param>
        /// <returns>The list of dates in this instance's week.</returns>
        public static List<DateTime> DaysOfWeek(this DateTime Self, int WeekOffset = 0)
        {
            return Self.DaysOfWeek(CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek, WeekOffset);
        }
        /// <summary>
        /// Gets the dates in this instance's week using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// <param name="StartingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// /// <param name="WeekOffset">How many weeks to offset by from this instance's week.</param>
        /// <returns>The list of dates in this instance's week.</returns>
        public static List<DateTime> DaysOfWeek(this DateTime Self, DayOfWeek StartingDayOfWeek, int WeekOffset = 0)
        {
            List<DateTime> WeekDates = new List<DateTime>();
            DateTime FirstDayOfTargetWeek;

            try
            {
                FirstDayOfTargetWeek = Self.FirstDayOfWeek(StartingDayOfWeek).AddDays(WeekOffset * 7);
            }
            catch (ArgumentOutOfRangeException Ex) when (Ex.TargetSite.DeclaringType == typeof(DateTime))
            {
                if (WeekOffset > 0)
                {
                    FirstDayOfTargetWeek = DateTime.MaxValue.FirstDayOfWeek(StartingDayOfWeek);
                }
                else
                {
                    FirstDayOfTargetWeek = DateTime.MinValue.Date.FirstDayOfWeek(StartingDayOfWeek);
                }
            }

            try
            {
                for (int i = 0; i < 7; i++)
                {
                    WeekDates.Add(FirstDayOfTargetWeek.AddDays(i));
                }
            }
            catch (ArgumentOutOfRangeException Ex) when (Ex.TargetSite.DeclaringType == typeof(DateTime))
            {
                return WeekDates;
            }

            return WeekDates;
        }
        /// <summary>
        /// Gets the dates in this instance's month.
        /// </summary>
        /// <param name="MonthOffset">How many months to offset by from this instance's month.</param>
        /// <returns>The list of dates in this instance's month.</returns>
        public static List<DateTime> DaysOfMonth(this DateTime Self, int MonthOffset = 0)
        {
            List<DateTime> MonthDates = new List<DateTime>();
            DateTime FirstDayOfTargetMonth;

            try
            {
                FirstDayOfTargetMonth = Self.FirstDayOfMonth().AddMonths(MonthOffset);
            }
            catch (ArgumentOutOfRangeException Ex) when (Ex.TargetSite.DeclaringType == typeof(DateTime))
            {
                if (MonthOffset > 0)
                {
                    FirstDayOfTargetMonth = DateTime.MaxValue.FirstDayOfMonth();
                }
                else
                {
                    FirstDayOfTargetMonth = DateTime.MinValue.Date.FirstDayOfMonth();
                }
            }

            try
            {
                for (DateTime i = FirstDayOfTargetMonth; i.Month == FirstDayOfTargetMonth.Month; i = i.AddDays(1))
                {
                    MonthDates.Add(i);
                }
            }
            catch (ArgumentOutOfRangeException Ex) when (Ex.TargetSite.DeclaringType == typeof(DateTime))
            {
                return MonthDates;
            }

            return MonthDates;
        }
        /// <summary>
        /// Gets the dates in this instance's year.
        /// </summary>
        /// <param name="YearOffset">How many years to offset by from this instance's year.</param>
        /// <returns>The list of dates in this instance's year.</returns>
        public static List<DateTime> DaysOfYear(this DateTime Self, int YearOffset = 0)
        {
            List<DateTime> YearDates = new List<DateTime>();
            DateTime FirstDayOfTargetYear;

            try
            {
                FirstDayOfTargetYear = new DateTime(Self.Year, 1, 1).AddYears(YearOffset);
            }
            catch (ArgumentOutOfRangeException Ex) when (Ex.TargetSite.DeclaringType == typeof(DateTime))
            {
                if (YearOffset > 0)
                {
                    FirstDayOfTargetYear = DateTime.MaxValue;
                }
                else
                {
                    FirstDayOfTargetYear = DateTime.MinValue;
                }
            }

            try
            {
                for (DateTime i = FirstDayOfTargetYear; i.Year == FirstDayOfTargetYear.Year; i = i.AddDays(1))
                {
                    YearDates.Add(i);
                }
            }
            catch (ArgumentOutOfRangeException Ex) when (Ex.TargetSite.DeclaringType == typeof(DateTime))
            {
                return YearDates;
            }

            return YearDates;
        }
        /// <summary>
        /// Gets the list of dates in a range specified by this instance and a second date.
        /// </summary>
        /// <param name="SecondDate">The second date of the range.</param>
        /// <param name="Inclusive">Whether to include this instance and the <paramref name="SecondDate"/> or not.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="DateTime"/>s containing the dates between this instance and the second date.</returns>
        public static List<DateTime> GetDatesBetween(this DateTime Self, DateTime SecondDate, bool Inclusive = true)
        {
            List<DateTime> DateTimes = new List<DateTime>();

            if (Self.Date == SecondDate.Date)
            {
                DateTimes.Add(Self.Date);
            }
            else
            {
                DateTime StartDate = Self.Date < SecondDate.Date ? Self.Date : SecondDate.Date;
                DateTime EndDate = Self.Date > SecondDate.Date ? Self.Date : SecondDate.Date;

                try
                {
                    for (DateTime i = StartDate; i <= EndDate; i = i.AddDays(1))
                    {
                        DateTimes.Add(i);
                    }
                }
                catch (ArgumentOutOfRangeException Ex) when (Ex.TargetSite.DeclaringType == typeof(DateTime))
                {
                }
            }

            if (!Inclusive)
            {
                DateTimes.Remove(Self.Date);
                DateTimes.Remove(SecondDate.Date);
            }

            return DateTimes;
        }
    }
}
