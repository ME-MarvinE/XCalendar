using System.Reflection;
using System.Windows.Input;
using XCalendar.Core.Collections;
using XCalendar.Core.Enums;
using XCalendar.Core.Extensions;
using XCalendar.Core.Models;
using XCalendarMauiSample.Models;

namespace XCalendarMauiSample.ViewModels
{
    public class DuolingoStreakCalendarExampleViewModel : BaseViewModel
    {
        #region Properties
        public Calendar<DuolingoDay> Calendar { get; set; } = new Calendar<DuolingoDay>()
        {
            SelectionType = SelectionType.Single,
            SelectionAction = SelectionAction.Modify,
            AutoRowsIsConsistent = false,
            StartOfWeek = DayOfWeek.Sunday
        };
        public ObservableRangeCollection<DateTime> DatesWhenGoalWasAchieved { get; set; } = new ObservableRangeCollection<DateTime>();
        public ObservableRangeCollection<DateTime> DatesWhenStreakFreezeWasUsed { get; set; } = new ObservableRangeCollection<DateTime>();
        public ImageSource DuolingoStreakFreezeImageSource { get; set; } = ImageSource.FromResource("XCalendarMauiSample.Images.duolingo_streak_freeze.png", typeof(DuolingoStreakCalendarExampleViewModel).GetTypeInfo().Assembly);
        #endregion

        #region Commands
        public ICommand NavigateCalendarCommand { get; set; }
        public ICommand ToggleDayCommand { get; set; }
        #endregion

        #region Constructors
        public DuolingoStreakCalendarExampleViewModel()
        {
            NavigateCalendarCommand = new Command<int>(NavigateCalendar);
            ToggleDayCommand = new Command<DateTime>(ToggleDay);
            DatesWhenGoalWasAchieved.CollectionChanged += DatesWhenGoalWasAchieved_CollectionChanged;
            DatesWhenStreakFreezeWasUsed.CollectionChanged += DatesWhenStreakFreezeWasUsed_CollectionChanged;
            Calendar.DaysUpdated += Calendar_DaysUpdated;
        }
        #endregion

        #region Methods
        public void NavigateCalendar(int amount)
        {
            if (Calendar.NavigatedDate.TryAddMonths(amount, out DateTime targetDate))
            {
                Calendar.Navigate(targetDate - Calendar.NavigatedDate);
            }
            else
            {
                Calendar.Navigate(amount > 0 ? TimeSpan.MaxValue : TimeSpan.MinValue);
            }
        }
        public void ToggleDay(DateTime dateTime)
        {
            if (DatesWhenGoalWasAchieved.Any(x => x.Date == dateTime.Date))
            {
                DatesWhenGoalWasAchieved.Remove(dateTime.Date);
                DatesWhenStreakFreezeWasUsed.Add(dateTime.Date);
            }
            else if (DatesWhenStreakFreezeWasUsed.Any(x => x.Date == dateTime.Date))
            {
                DatesWhenStreakFreezeWasUsed.Remove(dateTime.Date);
            }
            else
            {
                DatesWhenGoalWasAchieved.Add(dateTime.Date);
            }
        }
        public void EvaluateDaysWithStreak()
        {
            List<DuolingoDay> daysWhenGoalWasAchieved = new List<DuolingoDay>();
            List<DuolingoDay> daysWhenStreakFreezeWasUsed = new List<DuolingoDay>();

            int weeksInMonth = Calendar.NavigatedDate.CalendarWeeksInMonth(Calendar.StartOfWeek);
            List<DateTime> datesInsidePerfectWeek = new List<DateTime>();

            for (int i = 0; i < weeksInMonth; i++)
            {
                List<DateTime> weekOfMonth = Calendar.NavigatedDate.CalendarWeekInMonth(i + 1, Calendar.StartOfWeek);

                if (weekOfMonth.All(x => DatesWhenGoalWasAchieved.Any(y => y.Date == x.Date)))
                {
                    datesInsidePerfectWeek.AddRange(weekOfMonth);
                }
            }

            for (int i = 0; i < Calendar.Days.Count; i++)
            {
                DuolingoDay day = Calendar.Days[i];

                day.IsInsidePerfectWeek = datesInsidePerfectWeek.Any(x => x.Date == day.DateTime.Date);
                if (day.IsInsidePerfectWeek)
                {
                    var thing = 2;
                }
                day.DailyGoalAchieved = DatesWhenGoalWasAchieved.Any(x => x.Date == day.DateTime.Date);
                day.StreakFreezeUsed = DatesWhenStreakFreezeWasUsed.Any(x => x.Date == day.DateTime.Date);
            }

            for (int i = 0; i < Calendar.Days.Count; i++)
            {
                //Using indexes is faster than performing operations on the current day's date and also supports the Calendar's 'CustomDayNamesOrder' property.
                DuolingoDay day = Calendar.Days[i];

                int dayToLeftIndex = i - 1;
                int dayToRightIndex = i + 1;

                DuolingoDay dayToLeft = Calendar.Days.ElementAtOrDefault(dayToLeftIndex);
                DuolingoDay dayToRight = Calendar.Days.ElementAtOrDefault(dayToRightIndex);

                int daysPerRow = (int)Math.Ceiling(Calendar.Days.Count / (double)Calendar.Rows);

                bool dayIsFirstInRow = i == 0 || (i + 1) % daysPerRow == 1;
                bool dayIsLastInRow = i == Calendar.Days.Count - 1 || (i + 1) % daysPerRow == 0;

                //This could be made more efficient by storing which days' sides have already been checked and skipping the calculation for that side when it's that day's turn to be processed.
                day.ConnectsToLeft = !dayIsFirstInRow && (day.DailyGoalAchieved || day.StreakFreezeUsed) && !day.IsInvalid && dayToLeft != null && (dayToLeft.DailyGoalAchieved || dayToLeft.StreakFreezeUsed) && !dayToLeft.IsInvalid;
                day.ConnectsToRight = !dayIsLastInRow && (day.DailyGoalAchieved || day.StreakFreezeUsed) && !day.IsInvalid && dayToRight != null && (dayToRight.DailyGoalAchieved || dayToRight.StreakFreezeUsed) && !dayToRight.IsInvalid;
                day.ConnectsToTop = false;
                day.ConnectsToBottom = false;
            }
        }
        private void Calendar_DaysUpdated(object sender, EventArgs e)
        {
            EvaluateDaysWithStreak();
        }
        private void DatesWhenGoalWasAchieved_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            EvaluateDaysWithStreak();
        }
        private void DatesWhenStreakFreezeWasUsed_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            EvaluateDaysWithStreak();
        }
        #endregion
    }
}
