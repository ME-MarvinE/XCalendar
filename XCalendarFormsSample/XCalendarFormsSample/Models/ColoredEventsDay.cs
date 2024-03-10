using XCalendar.Core.Models;
using XCalendar.Core.Interfaces;
using XCalendar.Forms.Models;

namespace XCalendarFormsSample.Models
{
    public class ColoredEventsDay : ColoredEventsDay<ColoredEvent>
    {
    }
    public class ColoredEventsDay<TEvent> : CalendarDay<TEvent> where TEvent : IEvent
    {
    }
}
