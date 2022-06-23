using System;
using System.Collections.Generic;
using System.Linq;
using XCalendar.Core.Interfaces;
using XCalendar.Core.Models;

namespace XCalendarFormsSample.Models
{
    public class EventCalendar : Calendar<EventDay>
    {
        #region Properties
        public ObservableRangeCollection<Event> Events { get; set; } = new ObservableRangeCollection<Event>();
        #endregion

        #region Methods
        public override void UpdateDay(EventDay Day, DateTime? NewDateTime)
        {
            base.UpdateDay(Day, NewDateTime);
            Day.Events.ReplaceRange(Events.Where(x => x.DateTime.Date == NewDateTime?.Date));
        }
        #endregion
    }
}
