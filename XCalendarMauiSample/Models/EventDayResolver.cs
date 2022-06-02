using XCalendar.Core.Interfaces;

namespace XCalendarMauiSample.Models
{
    public class EventDayResolver : ICalendarDayResolver
    {
        #region Properties
        public IEnumerable<Event> Events { get; set; }
        #endregion

        #region Methods
        public ICalendarDay CreateDay(DateTime? DateTime)
        {
            EventDay EventDay = new EventDay();
            UpdateDay(EventDay, DateTime);
            return EventDay;
        }
        public void UpdateDay(ICalendarDay Day, DateTime? DateTime)
        {
            EventDay EventDay = (EventDay)Day;
            EventDay.Events.ReplaceRange(Events.Where(x => x.DateTime.Date == DateTime?.Date));
            EventDay.DateTime = DateTime;
        }
        #endregion
    }
}
