using XCalendar.Core.Interfaces;
using XCalendar.Core.Models;

namespace XCalendarMauiSample.Models
{
    public class ConnectableDay : ConnectableDay<Event>
    {
    }
    public class ConnectableDay<TEvent> : CalendarDay<TEvent> where TEvent : IEvent
    {
        public bool ConnectsToTop { get; set; }
        public bool ConnectsToBottom { get; set; }
        public bool ConnectsToLeft { get; set; }
        public bool ConnectsToRight { get; set; }
    }
}
