using System;
using XCalendar.Core.Interfaces;

namespace XCalendar.Core.Models
{
    public class DefaultCalendarDayResolver<T> : ICalendarDayResolver<T> where T : ICalendarDay, new()
    {
        #region Methods
        public T CreateDay(DateTime? DateTime)
        {
            T Day = new T();
            UpdateDay(Day, DateTime);
            return Day;
        }
        public void UpdateDay(T Day, DateTime? NewDateTime)
        {
            Day.DateTime = NewDateTime;
        }
        #endregion
    }
}
