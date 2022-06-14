using System;

namespace XCalendar.Core.Interfaces
{
    public interface ICalendarDayResolver<ICalendarDay>
    {
        ICalendarDay CreateDay(DateTime? DateTime);
        void UpdateDay(ICalendarDay Day, DateTime? NewDateTime);
    }
}
