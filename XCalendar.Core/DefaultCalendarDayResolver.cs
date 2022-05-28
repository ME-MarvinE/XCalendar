using System;
using XCalendar.Core.Interfaces;
using XCalendar.Core.Models;

namespace XCalendar.Core
{
    public class DefaultCalendarDayResolver : ICalendarDayResolver
    {
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
    }
}
