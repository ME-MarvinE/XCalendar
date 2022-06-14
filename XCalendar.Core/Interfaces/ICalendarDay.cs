using System;

namespace XCalendar.Core.Interfaces
{
    public interface ICalendarDay
    {
        DateTime? DateTime { get; set; }
        bool IsSelected { get; set; }
        bool IsCurrentMonth { get; set; }
        bool IsToday { get; set; }
        bool IsInvalid { get; set; }
    }
}
