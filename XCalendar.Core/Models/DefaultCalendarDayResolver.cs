using System;
using XCalendar.Core.Interfaces;

namespace XCalendar.Core.Models
{
    public class DefaultCalendarDayResolver : ICalendarDayResolver
    {
        #region Methods
        public ICalendarDay CreateDay(DateTime? DateTime)
        {
            CalendarDay Day = new CalendarDay();
            UpdateDay(Day, DateTime);
            return Day;
        }
        public void UpdateDay(ICalendarDay Day, DateTime? DateTime)
        {
            Day.DateTime = DateTime;
        }
        #endregion
    }
}
