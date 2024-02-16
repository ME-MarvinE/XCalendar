using XCalendar.Core.Collections;
using XCalendar.Core.Interfaces;

namespace XCalendar.Maui.Interfaces
{
    public interface IComplexCalendarDay : ICalendarDay
    {
        ObservableRangeCollection<IEvent> Events { get; }
    }
}
