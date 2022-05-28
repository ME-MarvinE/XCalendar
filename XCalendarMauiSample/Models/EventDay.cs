using System;
using XCalendar.Core.Interfaces;
using XCalendar.Core.Models;
using XCalendar.Maui;

namespace XCalendarMauiSample.Models
{
    public class EventDay : BaseObservableModel, ICalendarDay
    {
        public DateTime? DateTime { get; set; }
        public ObservableRangeCollection<Event> Events { get; } = new ObservableRangeCollection<Event>();
    }
}
