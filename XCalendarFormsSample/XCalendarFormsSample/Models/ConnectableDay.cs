using XCalendar.Core.Models;

namespace XCalendarFormsSample.Models
{
    public class ConnectableDay : CalendarDay
    {
        public bool ConnectsToTop { get; set; }
        public bool ConnectsToBottom { get; set; }
        public bool ConnectsToLeft { get; set; }
        public bool ConnectsToRight { get; set; }
    }
}
