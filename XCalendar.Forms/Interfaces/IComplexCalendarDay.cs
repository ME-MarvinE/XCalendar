using XCalendar.Core.Collections;
using XCalendar.Core.Interfaces;

namespace XCalendar.Forms.Interfaces
{
    public interface IComplexCalendarDay : ICalendarDay
    {
        ObservableRangeCollection<IEvent> Events { get; }
    }
}
