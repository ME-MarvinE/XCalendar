using System;
using System.ComponentModel;
using XCalendar.Core.Collections;

namespace XCalendar.Core.Interfaces
{
    public interface ICalendarDay : ICalendarDay<IEvent>
    {
    }
    public interface ICalendarDay<TEvent> : INotifyPropertyChanged where TEvent : IEvent
    {
        DateTime DateTime { get; set; }
        bool IsSelected { get; set; }
        bool IsCurrentMonth { get; set; }
        bool IsToday { get; set; }
        bool IsInvalid { get; set; }
        ObservableRangeCollection<TEvent> Events { get; set; }
    }
}
