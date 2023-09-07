using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;

namespace XCalendar.Core.Extensions
{
    public static class DayOfWeekExtensions
    {
        #region Properties
        public static readonly ReadOnlyCollection<DayOfWeek> DaysOfWeek = new List<DayOfWeek>()
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday
        }.AsReadOnly();
        #endregion

        #region Methods
        /// <summary>
        /// Gets a chronological list of every <see cref="DayOfWeek"/> in which the first element is this instance.
        /// </summary>
        public static List<DayOfWeek> GetWeekAsFirst(this DayOfWeek self)
        {
            List<DayOfWeek> week = new List<DayOfWeek>();
            int startOfWeekIndex = DaysOfWeek.IndexOf(self);

            for (int i = startOfWeekIndex; week.Count != DaysOfWeek.Count; i = i < DaysOfWeek.Count - 1 ? i + 1 : 0)
            {
                week.Add(DaysOfWeek[i]);
            }

            return week;
        }
        /// <summary>
        /// Gets a chronological list of every <see cref="DayOfWeek"/> in which the last element is this instance.
        /// </summary>
        public static List<DayOfWeek> GetWeekAsLast(this DayOfWeek self)
        {
            List<DayOfWeek> week = new List<DayOfWeek>();
            int startOfWeekIndex = DaysOfWeek.IndexOf(self) + 1;

            if (startOfWeekIndex == DaysOfWeek.Count)
            {
                startOfWeekIndex = 0;
            }

            for (int i = startOfWeekIndex; week.Count != DaysOfWeek.Count; i = i < DaysOfWeek.Count - 1 ? i + 1 : 0)
            {
                week.Add(DaysOfWeek[i]);
            }

            return week;
        }

        public static string LocalizeDayOfWeek(this DayOfWeek self, CultureInfo culture)
        {
            return culture.DateTimeFormat.GetDayName(self);
        }
        #endregion
    }
}
