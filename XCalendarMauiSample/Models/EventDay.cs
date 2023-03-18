using XCalendar.Core.Collections;
using XCalendar.Core.Interfaces;

namespace XCalendarMauiSample.Models
{
    public class EventDay : BaseObservableModel, ICalendarDay
    {
        public DateTime DateTime { get; set; }
        public ObservableRangeCollection<Event> Events { get; } = new ObservableRangeCollection<Event>();
        public bool IsSelected { get;set; }
        public bool IsCurrentMonth { get; set; }
        public bool IsToday { get; set; }
        public bool IsInvalid { get; set; }
    }
}
