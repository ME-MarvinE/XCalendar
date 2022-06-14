using System;
using XCalendar.Core.Models;

namespace XCalendar.Core.Interfaces
{
    public interface ICalendarDayResolver<T> where T : ICalendarDay
    {
        T CreateDay(DateTime? DateTime, Calendar<T> Calendar);
        void UpdateDay(T Day, DateTime? NewDateTime, Calendar<T> Calendar);
        bool IsDayCurrentMonth(T Day, Calendar<T> Calendar);
        bool IsDayInvalid(T Day, Calendar<T> Calendar);
        bool IsDayToday(T Day, Calendar<T> Calendar);
        bool IsDaySelected(T Day, Calendar<T> Calendar);
    }
}
