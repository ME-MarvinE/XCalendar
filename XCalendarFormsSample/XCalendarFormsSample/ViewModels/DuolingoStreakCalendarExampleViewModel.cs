using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;
using XCalendar.Core.Collections;
using XCalendar.Core.Enums;
using XCalendar.Core.Extensions;
using XCalendar.Core.Models;
using XCalendarFormsSample.Models;

namespace XCalendarFormsSample.ViewModels
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
        public ImageSource DuolingoStreakFreezeImageSource { get; set; } = ImageSource.FromResource("XCalendarFormsSample.Images.duolingo_streak_freeze.png", typeof(DuolingoStreakCalendarExampleViewModel).GetTypeInfo().Assembly);
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

            DateTime firstDayOfMonth = Calendar.NavigatedDate.FirstDayOfMonth();
            DateTime lastDayOfMonth = Calendar.NavigatedDate.LastDayOfMonth();
            DateTime lastDayOfPreviousMonth = firstDayOfMonth.AddDays(-1);
            DateTime firstDayOfNextMonth = lastDayOfMonth.AddDays(1);

            for (int i = 0; i < Calendar.Days.Count; i++)
            {
                DuolingoDay day = Calendar.Days[i];

                //Days outside the month should be connected if the first day of the current month connects to the last day of the previous month or
                //the last day of the current month connects to the first day of the next month.

                if (day.DateTime.Date < firstDayOfMonth.Date)
                {
                    day.IsInsidePerfectWeek = datesInsidePerfectWeek.Any(x => x.Date == firstDayOfMonth.Date) && datesInsidePerfectWeek.Any(x => x.Date == lastDayOfPreviousMonth.Date);
                    day.DailyGoalAchieved = (DatesWhenGoalWasAchieved.Any(x => x.Date == firstDayOfMonth.Date) || DatesWhenStreakFreezeWasUsed.Any(x => x.Date == firstDayOfMonth.Date))
                        && (DatesWhenGoalWasAchieved.Any(x => x.Date == lastDayOfPreviousMonth.Date) || DatesWhenStreakFreezeWasUsed.Any(x => x.Date == lastDayOfPreviousMonth.Date));
                    day.StreakFreezeUsed = false;
                }
                else if (day.DateTime.Date > lastDayOfMonth.Date)
                {
                    day.IsInsidePerfectWeek = datesInsidePerfectWeek.Any(x => x.Date == lastDayOfMonth.Date) && datesInsidePerfectWeek.Any(x => x.Date == firstDayOfNextMonth.Date);
                    day.DailyGoalAchieved = (DatesWhenGoalWasAchieved.Any(x => x.Date == lastDayOfMonth.Date) || DatesWhenStreakFreezeWasUsed.Any(x => x.Date == lastDayOfMonth.Date))
                        && (DatesWhenGoalWasAchieved.Any(x => x.Date == firstDayOfNextMonth.Date) || DatesWhenStreakFreezeWasUsed.Any(x => x.Date == firstDayOfNextMonth.Date));
                    day.StreakFreezeUsed = false;
                }
                else
                {
                    day.IsInsidePerfectWeek = datesInsidePerfectWeek.Any(x => x.Date == day.DateTime.Date);
                    day.DailyGoalAchieved = DatesWhenGoalWasAchieved.Any(x => x.Date == day.DateTime.Date);
                    day.StreakFreezeUsed = DatesWhenStreakFreezeWasUsed.Any(x => x.Date == day.DateTime.Date);
                }
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
