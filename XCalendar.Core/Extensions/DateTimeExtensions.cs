using System;
using System.Collections.Generic;
using System.Globalization;
using XCalendar.Core.Enums;

namespace XCalendar.Core.Extensions
{
    public static class DateTimeExtensions
    {
        #region Methods
        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of weeks to the value of instance.
        /// </summary>
        /// <returns> An object whose value is the sum of the date and time represented by this instance and the number of weeks represented by <paramref name="value"/>.
        /// </returns>
        public static DateTime AddWeeks(this DateTime self, double value)
        {
            return self.AddDays(value * 7);
        }
        public static bool TryAdd(this DateTime self, TimeSpan value, out DateTime result)
        {
            try
            {
                result = self.Add(value);

                return true;
            }
            catch
            {
                result = default;

                return false;
            }
        }
        public static bool TrySubtract(this DateTime self, DateTime value, out TimeSpan result)
        {
            try
            {
                result = self.Subtract(value);

                return true;
            }
            catch
            {
                result = default;

                return false;
            }
        }
        public static bool TrySubtract(this DateTime self, TimeSpan value, out DateTime result)
        {
            try
            {
                result = self.Subtract(value);

                return true;
            }
            catch
            {
                result = default;

                return false;
            }
        }
        public static bool TryAddTicks(this DateTime self, long value, out DateTime result)
        {
            try
            {
                result = self.AddTicks(value);

                return true;
            }
            catch
            {
                result = default;

                return false;
            }
        }
        public static bool TryAddMilliseconds(this DateTime self, double value, out DateTime result)
        {
            try
            {
                result = self.AddMilliseconds(value);

                return true;
            }
            catch
            {
                result = default;

                return false;
            }
        }
        public static bool TryAddSeconds(this DateTime self, double value, out DateTime result)
        {
            try
            {
                result = self.AddSeconds(value);

                return true;
            }
            catch
            {
                result = default;

                return false;
            }
        }
        public static bool TryAddMinutes(this DateTime self, double value, out DateTime result)
        {
            try
            {
                result = self.AddMinutes(value);

                return true;
            }
            catch
            {
                result = default;

                return false;
            }
        }
        public static bool TryAddHours(this DateTime self, double value, out DateTime result)
        {
            try
            {
                result = self.AddHours(value);

                return true;
            }
            catch
            {
                result = default;

                return false;
            }
        }
        public static bool TryAddDays(this DateTime self, double value, out DateTime result)
        {
            try
            {
                result = self.AddDays(value);

                return true;
            }
            catch
            {
                result = default;

                return false;
            }
        }
        public static bool TryAddWeeks(this DateTime self, double value, out DateTime result)
        {
            try
            {
                result = self.AddWeeks(value);

                return true;
            }
            catch
            {
                result = default;

                return false;
            }
        }
        public static bool TryAddMonths(this DateTime self, int value, out DateTime result)
        {
            try
            {
                result = self.AddMonths(value);

                return true;
            }
            catch
            {
                result = default;

                return false;
            }
        }
        public static bool TryAddYears(this DateTime self, int value, out DateTime result)
        {
            try
            {
                result = self.AddYears(value);

                return true;
            }
            catch
            {
                result = default;

                return false;
            }
        }
        /// <summary>
        /// Gets the first day of this instance's week.
        /// </summary>
        /// <returns>A <see cref="DateTime"/> representing the first day of the week.</returns>
        public static DateTime FirstDayOfWeek(this DateTime self)
        {
            return self.FirstDayOfWeek(CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek);
        }
        /// <summary>
        /// Gets the first day of this instance's week using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// <param name="startingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// <returns>A <see cref="DateTime"/> representing the first day of the week.</returns>
        public static DateTime FirstDayOfWeek(this DateTime self, DayOfWeek startingDayOfWeek)
        {
            DateTime firstDayOfWeek = self.Date;

            try
            {
                while (firstDayOfWeek.DayOfWeek != startingDayOfWeek)
                {
                    firstDayOfWeek = firstDayOfWeek.AddDays(-1);
                }
            }
            catch (ArgumentOutOfRangeException ex) when (ex.TargetSite.DeclaringType == typeof(DateTime))
            {
            }

            return firstDayOfWeek;
        }
        /// <summary>
        /// Gets the last day of this instance's week
        /// </summary>
        /// <returns>A <see cref="DateTime"/> representing the first day of the week.</returns>
        public static DateTime LastDayOfWeek(this DateTime self)
        {
            return self.LastDayOfWeek(CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek);
        }
        /// <summary>
        /// Gets the last day of this instance's week using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// <param name="startingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// <returns>A <see cref="DateTime"/> representing the last day of the week.</returns>
        public static DateTime LastDayOfWeek(this DateTime self, DayOfWeek startingDayOfWeek)
        {
            DateTime lastDayOfWeek = self.Date;

            try
            {
                while (lastDayOfWeek.AddDays(1).DayOfWeek != startingDayOfWeek)
                {
                    lastDayOfWeek = lastDayOfWeek.AddDays(1);
                }
            }
            catch (ArgumentOutOfRangeException ex) when (ex.TargetSite.DeclaringType == typeof(DateTime))
            {
            }

            return lastDayOfWeek;
        }
        /// <summary>
        /// Gets the first day this instance's month.
        /// </summary>
        /// <returns>A <see cref="DateTime"/> representing the first day of the month.</returns>
        public static DateTime FirstDayOfMonth(this DateTime self)
        {
            return new DateTime(self.Year, self.Month, 1);
        }
        /// <summary>
        /// Gets the last day of this instance's month.
        /// </summary>
        /// <returns>A <see cref="DateTime"/> representing the last day of the month.</returns>
        public static DateTime LastDayOfMonth(this DateTime self)
        {
            return new DateTime(self.Year, self.Month, DateTime.DaysInMonth(self.Year, self.Month));
        }
        /// <summary>
        /// Gets the first day this instance's year.
        /// </summary>
        /// <returns>A <see cref="DateTime"/> representing the first day of the year.</returns>
        public static DateTime FirstDayOfYear(this DateTime self)
        {
            return new DateTime(self.Year, 1, 1);
        }
        /// <summary>
        /// Gets the last day of this instance's year.
        /// </summary>
        /// <returns>A <see cref="DateTime"/> representing the last day of the year.</returns>
        public static DateTime LastDayOfYear(this DateTime self)
        {
            return new DateTime(self.Year, 12, 31);
        }
        /// <summary>
        /// Gets the position of this instance's day in this instance's week.
        /// </summary>
        /// <returns>The number representing the position of this instance's day in this instance's week.</returns>
        public static int DayOfWeek(this DateTime self)
        {
            return self.DayOfWeek(CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek);
        }
        /// <summary>
        /// Gets the position of this instance's day in this instance's week using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// <param name="startingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// <returns>The number representing the position of this instance's day in this instance's week.</returns>
        public static int DayOfWeek(this DateTime self, DayOfWeek startingDayOfWeek)
        {
            IList<DayOfWeek> weekAsFirst = startingDayOfWeek.GetWeekAsFirst();

            return weekAsFirst.IndexOf(self.Date.DayOfWeek) + 1;
        }
        /// <summary>
        /// Gets which week of this instance's month this instance is in.
        /// </summary>
        /// <returns>The number corresponding to which week of this instance's month it is in</returns>
        public static int CalendarWeekOfMonth(this DateTime self)
        {
            return self.CalendarWeekOfMonth(CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek);
        }
        /// <summary>
        /// Gets which week of this instance's month this instance is in using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// <param name="startingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// <returns>The number corresponding to which week of this instance's month it is in</returns>
        /// <exception cref="ArgumentOutOfRangeException">The <see cref="DateTime"/> is not present in any of its month's weeks.</exception>
        public static int CalendarWeekOfMonth(this DateTime self, DayOfWeek startingDayOfWeek)
        {
            for (int i = self.CalendarWeeksInMonth(startingDayOfWeek); i > 0; i--)
            {
                if (self.CalendarWeekInMonth(i, startingDayOfWeek).Contains(self.Date)) { return i; }
            }

            throw new ArgumentOutOfRangeException($"The {nameof(DateTime)} is not present in any of its month's weeks.");
        }
        /// <summary>
        /// Gets the specified week in this instance's month.
        /// </summary>
        /// <param name="week">The week to get the days from relative to the start of the month.</param>
        /// <returns>The list of days inside the specified week in this instance's month.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The specified week number is outside the scope of the instance's month.</exception>
        public static List<DateTime> CalendarWeekInMonth(this DateTime self, int week)
        {
            return self.CalendarWeekInMonth(week, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
        }
        /// <summary>
        /// Gets the specified week in this instance's month using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// <param name="week">The week to get the days from relative to the start of the month.</param>
        /// <param name="startingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// <returns>The list of days inside the specified week in this instance's month.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The specified week number is outside the scope of the instance's month.</exception>
        public static List<DateTime> CalendarWeekInMonth(this DateTime self, int week, DayOfWeek startingDayOfWeek)
        {
            int checkWeek = 0;
            List<DateTime> daysInWeek = new List<DateTime>();

            if (week < 1 || week > self.CalendarWeeksInMonth(startingDayOfWeek))
            {
                throw new ArgumentOutOfRangeException("The specified week number is outside the scope of the month");
            }

            try
            {
                for (DateTime i = self.FirstDayOfMonth().FirstDayOfWeek(startingDayOfWeek); checkWeek <= week; i = i.AddDays(1))
                {
                    if (i.DayOfWeek == startingDayOfWeek) { checkWeek += 1; }
                    if (checkWeek == week)
                    {
                        daysInWeek.Add(i);
                    }
                }
            }
            catch (ArgumentOutOfRangeException ex) when (ex.TargetSite.DeclaringType == typeof(DateTime))
            {
            }
            return daysInWeek;
        }
        /// <summary>
        /// Gets the number of weeks in this instance's month counting the weeks that span into the previous or next month.
        /// </summary>
        /// <returns>The number of weeks in this instance's month counting the weeks that span into the previous or next year.</returns>
        public static int CalendarWeeksInMonth(this DateTime self)
        {
            return self.CalendarWeeksInMonth(CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek);
        }
        /// <summary>
        /// Gets the number of weeks in this instance's month counting the weeks that span into the previous or next month using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// /// <param name="startingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// <returns>The number of weeks in this instance's month counting the weeks that span into the previous or next year.</returns>
        public static int CalendarWeeksInMonth(this DateTime self, DayOfWeek startingDayOfWeek)
        {
            int calendarDaysInMonth = self.CalendarPreviousDaysInMonth(startingDayOfWeek).Count + DateTime.DaysInMonth(self.Year, self.Month) + self.CalendarNextDaysInMonth(startingDayOfWeek).Count;
            return (int)Math.Ceiling((double)calendarDaysInMonth / 7);
        }
        /// <summary>
        /// Gets the days in the month including days from weeks that spill into other months.
        /// </summary>
        /// <returns>The days in the month including days from weeks that spill into other months.</returns>
        public static List<DateTime> CalendarDaysInMonth(this DateTime self)
        {
            return self.CalendarDaysInMonth(CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
        }
        /// <summary>
        /// Gets the days in the month including days from weeks that spill into other months using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// <param name="startingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// <returns>The days in the month including days from weeks that spill into other months.</returns>
        public static List<DateTime> CalendarDaysInMonth(this DateTime self, DayOfWeek startingDayOfWeek)
        {
            List<DateTime> calendarDaysInMonth = new List<DateTime>();
            int weekCount = self.CalendarWeeksInMonth(startingDayOfWeek);

            for (int i = 0; i < weekCount; i++)
            {
                calendarDaysInMonth.AddRange(self.CalendarWeekInMonth(i + 1, startingDayOfWeek));
            }

            return calendarDaysInMonth;
        }
        /// <summary>
        /// Gets the days which are before this instance's month and within the same week as its first day.
        /// </summary>
        /// <returns>The list of days which are before this instance's month and within the same week as its first day.</returns>
        public static List<DateTime> CalendarPreviousDaysInMonth(this DateTime self)
        {
            return self.CalendarPreviousDaysInMonth(CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek);
        }
        /// <summary>
        /// Gets the days which are before this instance's month and within the same week as its first day using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// <param name="startingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// <returns>The list of days which are before this instance's month and within the same week as its first day.</returns>
        public static List<DateTime> CalendarPreviousDaysInMonth(this DateTime self, DayOfWeek startingDayOfWeek)
        {
            List<DateTime> returnValue = new List<DateTime>();

            for (DateTime i = self.FirstDayOfMonth().FirstDayOfWeek(startingDayOfWeek); i.Day > self.FirstDayOfMonth().Day; i = i.AddDays(1))
            {
                returnValue.Add(i);
            }

            return returnValue;
        }
        /// <summary>
        /// Gets the days which are after this instance's month and within the same week as its last day.
        /// </summary>
        /// <returns>The list of days which are after this instance's month and within the same week as its last day.</returns>
        public static List<DateTime> CalendarNextDaysInMonth(this DateTime self)
        {
            return self.CalendarNextDaysInMonth(CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek);
        }
        /// <summary>
        /// Gets the days which are after this instance's month and within the same week as its last day using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// <param name="startingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// <returns>The list of days which are after this instance's month and within the same week as its last day.</returns>
        public static List<DateTime> CalendarNextDaysInMonth(this DateTime self, DayOfWeek startingDayOfWeek)
        {
            List<DateTime> returnValue = new List<DateTime>();

            try
            {
                for (DateTime i = self.LastDayOfMonth().AddDays(1); i.DayOfWeek != startingDayOfWeek; i = i.AddDays(1))
                {
                    returnValue.Add(i);
                }
            }
            catch (ArgumentOutOfRangeException ex) when (ex.TargetSite.DeclaringType == typeof(DateTime))
            {
            }

            return returnValue;
        }
        /// <summary>
        /// Gets the highest number of weeks that occur inside a month within this instance's year.
        /// </summary>
        /// <returns>The highest number of weeks that occur inside a month within this instance's year.</returns>
        public static int CalendarHighestMonthWeekCountOfYear(this DateTime self)
        {
            return self.CalendarHighestMonthWeekCountOfYear(CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek);
        }
        /// <summary>
        /// Gets the highest number of weeks that occur inside a month within this instance's year using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// <param name="startingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// <returns>The highest number of weeks that occur inside a month within this instance's year.</returns>
        public static int CalendarHighestMonthWeekCountOfYear(this DateTime self, DayOfWeek startingDayOfWeek)
        {
            int highestMonthWeekCountOfYear = 0;

            try
            {
                for (DateTime i = new DateTime(self.Year, 1, 1); i.Year == self.Year; i = i.AddMonths(1))
                {
                    int weeksInMonth = i.CalendarWeeksInMonth(startingDayOfWeek);
                    if (weeksInMonth > highestMonthWeekCountOfYear) { highestMonthWeekCountOfYear = weeksInMonth; }
                }
            }
            catch (ArgumentOutOfRangeException ex) when (ex.TargetSite.DeclaringType == typeof(DateTime))
            {
            }

            return highestMonthWeekCountOfYear;
        }
        /// <summary>
        /// Gets the lowest number of weeks that occur inside a month within this instance's year.
        /// </summary>
        /// <returns>The lowest number of weeks that occur inside a month within this instance's year.</returns>
        public static int CalendarLowestMonthWeekCountOfYear(this DateTime self)
        {
            return self.CalendarLowestMonthWeekCountOfYear(CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek);
        }
        /// <summary>
        /// Gets the lowest number of weeks that occur inside a month within this instance's year using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// <param name="startingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// <returns>The lowest number of weeks that occur inside a month within this instance's year.</returns>
        public static int CalendarLowestMonthWeekCountOfYear(this DateTime self, DayOfWeek startingDayOfWeek)
        {
            int lowestMonthWeekCountOfYear = self.CalendarDaysInMonth(startingDayOfWeek).Count;

            try
            {
                for (DateTime i = new DateTime(self.Year, 1, 1); i.Year == self.Year; i = i.AddMonths(1))
                {
                    int weeksInMonth = i.CalendarWeeksInMonth(startingDayOfWeek);
                    if (weeksInMonth < lowestMonthWeekCountOfYear) { lowestMonthWeekCountOfYear = weeksInMonth; }
                }
            }
            catch (ArgumentOutOfRangeException ex) when (ex.TargetSite.DeclaringType == typeof(DateTime))
            {
            }

            return lowestMonthWeekCountOfYear;
        }
        /// <summary>
        /// Gets the dates in this instance's week.
        /// </summary>
        /// <param name="weekOffset">How many weeks to offset by from this instance's week.</param>
        /// <returns>The list of dates in this instance's week.</returns>
        public static List<DateTime> DaysOfWeek(this DateTime self, int weekOffset = 0)
        {
            return self.DaysOfWeek(CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek, weekOffset);
        }
        /// <summary>
        /// Gets the dates in this instance's week using the specified <see cref="System.DayOfWeek"/> as the week start.
        /// </summary>
        /// <param name="startingDayOfWeek">The <see cref="System.DayOfWeek"/> at which the week starts.</param>
        /// /// <param name="weekOffset">How many weeks to offset by from this instance's week.</param>
        /// <returns>The list of dates in this instance's week.</returns>
        public static List<DateTime> DaysOfWeek(this DateTime self, DayOfWeek startingDayOfWeek, int weekOffset = 0)
        {
            List<DateTime> weekDates = new List<DateTime>();
            DateTime firstDayOfTargetWeek;

            try
            {
                firstDayOfTargetWeek = self.FirstDayOfWeek(startingDayOfWeek).AddDays(weekOffset * 7);
            }
            catch (ArgumentOutOfRangeException ex) when (ex.TargetSite.DeclaringType == typeof(DateTime))
            {
                if (weekOffset > 0)
                {
                    firstDayOfTargetWeek = DateTime.MaxValue.FirstDayOfWeek(startingDayOfWeek);
                }
                else
                {
                    firstDayOfTargetWeek = DateTime.MinValue.Date.FirstDayOfWeek(startingDayOfWeek);
                }
            }

            try
            {
                for (int i = 0; i < 7; i++)
                {
                    weekDates.Add(firstDayOfTargetWeek.AddDays(i));
                }
            }
            catch (ArgumentOutOfRangeException Ex) when (Ex.TargetSite.DeclaringType == typeof(DateTime))
            {
                return weekDates;
            }

            return weekDates;
        }
        /// <summary>
        /// Gets the dates in this instance's month.
        /// </summary>
        /// <param name="monthOffset">How many months to offset by from this instance's month.</param>
        /// <returns>The list of dates in this instance's month.</returns>
        public static List<DateTime> DaysOfMonth(this DateTime self, int monthOffset = 0)
        {
            List<DateTime> monthDates = new List<DateTime>();
            DateTime firstDayOfTargetMonth;

            try
            {
                firstDayOfTargetMonth = self.FirstDayOfMonth().AddMonths(monthOffset);
            }
            catch (ArgumentOutOfRangeException ex) when (ex.TargetSite.DeclaringType == typeof(DateTime))
            {
                if (monthOffset > 0)
                {
                    firstDayOfTargetMonth = DateTime.MaxValue.FirstDayOfMonth();
                }
                else
                {
                    firstDayOfTargetMonth = DateTime.MinValue.Date.FirstDayOfMonth();
                }
            }

            try
            {
                for (DateTime i = firstDayOfTargetMonth; i.Month == firstDayOfTargetMonth.Month; i = i.AddDays(1))
                {
                    monthDates.Add(i);
                }
            }
            catch (ArgumentOutOfRangeException ex) when (ex.TargetSite.DeclaringType == typeof(DateTime))
            {
                return monthDates;
            }

            return monthDates;
        }
        /// <summary>
        /// Gets the dates in this instance's year.
        /// </summary>
        /// <param name="yearOffset">How many years to offset by from this instance's year.</param>
        /// <returns>The list of dates in this instance's year.</returns>
        public static List<DateTime> DaysOfYear(this DateTime self, int yearOffset = 0)
        {
            List<DateTime> yearDates = new List<DateTime>();
            DateTime firstDayOfTargetYear;

            try
            {
                firstDayOfTargetYear = new DateTime(self.Year, 1, 1).AddYears(yearOffset);
            }
            catch (ArgumentOutOfRangeException ex) when (ex.TargetSite.DeclaringType == typeof(DateTime))
            {
                if (yearOffset > 0)
                {
                    firstDayOfTargetYear = DateTime.MaxValue;
                }
                else
                {
                    firstDayOfTargetYear = DateTime.MinValue;
                }
            }

            try
            {
                for (DateTime i = firstDayOfTargetYear; i.Year == firstDayOfTargetYear.Year; i = i.AddDays(1))
                {
                    yearDates.Add(i);
                }
            }
            catch (ArgumentOutOfRangeException ex) when (ex.TargetSite.DeclaringType == typeof(DateTime))
            {
                return yearDates;
            }

            return yearDates;
        }
        /// <summary>
        /// Gets the list of dates in a range specified by this instance and a second date.
        /// </summary>
        /// <param name="secondDate">The second date of the range.</param>
        /// <param name="inclusive">Whether to include this instance and the <paramref name="secondDate"/> or not.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="DateTime"/>s containing the dates between this instance and the second date.</returns>
        public static List<DateTime> GetDatesBetween(this DateTime self, DateTime secondDate, bool inclusive = true)
        {
            List<DateTime> dateTimes = new List<DateTime>();

            if (self.Date == secondDate.Date)
            {
                dateTimes.Add(self.Date);
            }
            else
            {
                DateTime startDate = self.Date < secondDate.Date ? self.Date : secondDate.Date;
                DateTime endDate = self.Date > secondDate.Date ? self.Date : secondDate.Date;

                try
                {
                    for (DateTime i = startDate; i <= endDate; i = i.AddDays(1))
                    {
                        dateTimes.Add(i);
                    }
                }
                catch (ArgumentOutOfRangeException ex) when (ex.TargetSite.DeclaringType == typeof(DateTime))
                {
                }
            }

            if (!inclusive)
            {
                dateTimes.Remove(self.Date);
                dateTimes.Remove(secondDate.Date);
            }

            return dateTimes;
        }
        /// <summary>
        /// Performs navigation on a <see cref="DateTime"/> using the specified navigation rules.
        /// </summary>
        /// <param name="timeSpan">The <see cref="TimeSpan"/> to attempt to navigate by.</param>
        /// <param name="minimumDate">The lower bound of the allowed range of dates. Inclusive.</param>
        /// <param name="maximumDate">The upper bound of the allowed range of dates. Inclusive.</param>
        /// <param name="navigationLoopMode">What to do when the result of navigation is outside the range of the <paramref name="minimumDate"/> and <paramref name="maximumDate"/>.</param>
        /// <param name="startOfWeek">The start of the week.</param>
        /// <returns>The <see cref="DateTime"/> resulting from the navigation.</returns>
        public static DateTime Navigate(this DateTime self, TimeSpan timeSpan, DateTime minimumDate, DateTime maximumDate, NavigationLoopMode navigationLoopMode, DayOfWeek startOfWeek)
        {
            bool lowerThanMinimumDate;
            bool higherThanMaximumDate;

            if (self.TryAdd(timeSpan, out DateTime newNavigatedDate))
            {
                lowerThanMinimumDate = newNavigatedDate.Date < minimumDate.Date;
                higherThanMaximumDate = newNavigatedDate.Date > maximumDate.Date;
            }
            else
            {
                newNavigatedDate = timeSpan.Ticks > 0 ? maximumDate : minimumDate;

                lowerThanMinimumDate = newNavigatedDate.Date <= minimumDate.Date;
                higherThanMaximumDate = newNavigatedDate.Date >= maximumDate.Date;
            }

            if (lowerThanMinimumDate && navigationLoopMode.HasFlag(NavigationLoopMode.LoopMinimum))
            {
                newNavigatedDate = maximumDate;
                //The code below makes sure that the correct amount of weeks are added after looping.
                //However this is not possible when setting the NavigatedDate directly, so it is commented out for the sake of consistency.

                ////The difference in weeks must be made consistent because NavigatedDate could be any value within the week.
                ////The minimum date may not always have the first day of week so the last day of week is used to do this.
                //TimeSpan Difference = CurrentDateTime.LastDayOfWeek(StartOfWeek) - MinimumDate.LastDayOfWeek(StartOfWeek);

                //int WeeksUntilMinValue = (int)Math.Ceiling(Difference.TotalDays / 7);
                //DateTime NewNavigatedDate = NavigateDateTime(MinimumDate, MinimumDate, MaximumDate, Amount + WeeksUntilMinValue, NavigationLoopMode, StartOfWeek);


                ////Preserve the original time.
                //return new DateTime(NewNavigatedDate.Year, NewNavigatedDate.Month, NewNavigatedDate.DayToUpdate, CurrentDateTime.Hour, CurrentDateTime.Minute, CurrentDateTime.Second, CurrentDateTime.Millisecond);
            }
            else if (higherThanMaximumDate && navigationLoopMode.HasFlag(NavigationLoopMode.LoopMaximum))
            {
                newNavigatedDate = minimumDate;
                //The code below makes sure that the correct amount of weeks are added after looping.
                //However this is not possible when setting the NavigatedDate directly, so it is commented out for the sake of consistency.

                ////The difference in weeks must be made consistent because NavigatedDate could be any value within the week.
                ////The maximum date may not always have the last day of week so the first day of week is used to do this.
                //TimeSpan Difference = MaximumDate.FirstDayOfWeek(StartOfWeek) - CurrentDateTime.FirstDayOfWeek(StartOfWeek);

                //int WeeksUntilMaxValue = (int)Math.Ceiling(Difference.TotalDays / 7);
                //DateTime NewNavigatedDate = NavigateDateTime(MinimumDate, MinimumDate, MaximumDate, Amount - WeeksUntilMaxValue, NavigationLoopMode, StartOfWeek);

                ////Preserve the original time.
                //return new DateTime(NewNavigatedDate.Year, NewNavigatedDate.Month, NewNavigatedDate.DayToUpdate, CurrentDateTime.Hour, CurrentDateTime.Minute, CurrentDateTime.Second, CurrentDateTime.Millisecond);
            }

            return newNavigatedDate;
        }
        #endregion
    }
}
