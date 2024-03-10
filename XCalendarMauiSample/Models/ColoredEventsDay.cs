using XCalendar.Core.Models;
using XCalendar.Core.Interfaces;
using XCalendar.Maui.Models;

namespace XCalendarMauiSample.Models
{
    public class ColoredEventsDay : ColoredEventsDay<ColoredEvent>
    {
    }
    public class ColoredEventsDay<TEvent> : CalendarDay<TEvent> where TEvent : IEvent
    {
    }
}
