using XCalendar.Core.Interfaces;
using XCalendar.Core.Models;

namespace XCalendarMauiSample.Models
{
    public class DuolingoDay : DuolingoDay<Event>
    {
        public bool DailyGoalAchieved { get; set; }
        public bool StreakFreezeUsed { get; set; }
        public bool IsInsidePerfectWeek { get; set; }
    }
    public class DuolingoDay<TEvent> : ConnectableDay<TEvent> where TEvent : IEvent
    {
    }
}
