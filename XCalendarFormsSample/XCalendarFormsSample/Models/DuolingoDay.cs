namespace XCalendarFormsSample.Models
{
    public class DuolingoDay : ConnectableDay
    {
        public bool DailyGoalAchieved { get; set; }
        public bool StreakFreezeUsed { get; set; }
        public bool IsInsidePerfectWeek { get; set; }
    }
}
