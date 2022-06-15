using System;
using XCalendar.Core.Models;

namespace XCalendar.Core.Interfaces
{
    public interface ICalendarDayResolver<T> where T : ICalendarDay
    {
        T CreateDay(DateTime? DateTime, ICalendar<T> Calendar);
        void UpdateDay(T Day, DateTime? NewDateTime, ICalendar<T> Calendar);
        bool IsDayCurrentMonth(T Day, ICalendar<T> Calendar);
        bool IsDayInvalid(T Day, ICalendar<T> Calendar);
        bool IsDayToday(T Day, ICalendar<T> Calendar);
        bool IsDaySelected(T Day, ICalendar<T> Calendar);
    }
}
