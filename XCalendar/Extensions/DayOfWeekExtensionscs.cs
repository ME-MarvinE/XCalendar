using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace XCalendar.Extensions
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
        public static List<DayOfWeek> GetWeekAsFirst(this DayOfWeek Self)
        {
            List<DayOfWeek> Week = new List<DayOfWeek>();
            int StartOfWeekIndex = DaysOfWeek.IndexOf(Self);

            for (int i = StartOfWeekIndex; Week.Count != DaysOfWeek.Count; i = i < DaysOfWeek.Count - 1 ? i + 1 : 0)
            {
                Week.Add(DaysOfWeek[i]);
            }

            return Week;
        }
        /// <summary>
        /// Gets a chronological list of every <see cref="DayOfWeek"/> in which the last element is this instance.
        /// </summary>
        public static List<DayOfWeek> GetWeekAsLast(this DayOfWeek Self)
        {
            List<DayOfWeek> Week = new List<DayOfWeek>();
            int StartOfWeekIndex = DaysOfWeek.IndexOf(Self) + 1;

            if (StartOfWeekIndex == DaysOfWeek.Count)
            {
                StartOfWeekIndex = 0;
            }

            for (int i = StartOfWeekIndex; Week.Count != DaysOfWeek.Count; i = i < DaysOfWeek.Count - 1 ? i + 1 : 0)
            {
                Week.Add(DaysOfWeek[i]);
            }

            return Week;
        }
        #endregion
    }
}
