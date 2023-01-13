using System.Windows.Input;
using XCalendar.Core.Enums;
using XCalendar.Core.Extensions;
using XCalendar.Core.Models;

namespace XCalendarMauiSample.ViewModels
{
    public class SwipableCalendarExampleViewModel : BaseViewModel
    {
        #region Properties
        public Calendar<CalendarDay> FirstPageCalendar { get; set; } = new Calendar<CalendarDay>() { SelectionAction = SelectionAction.Modify, SelectionType = SelectionType.Single };
        public Calendar<CalendarDay> SecondPageCalendar { get; set; } = new Calendar<CalendarDay>() { SelectionAction = SelectionAction.Modify, SelectionType = SelectionType.Single };
        public Calendar<CalendarDay> ThirdPageCalendar { get; set; } = new Calendar<CalendarDay>() { SelectionAction = SelectionAction.Modify, SelectionType = SelectionType.Single };
        public int CurrentPageCalendarPosition { get; set; } = 1;
        public Calendar<CalendarDay> CurrentPageCalendar
        {
            get
            {
                return Calendars[CurrentPageCalendarPosition];
            }
        }
        public ObservableRangeCollection<Calendar<CalendarDay>> Calendars { get; set; } = new ObservableRangeCollection<Calendar<CalendarDay>>();
        #endregion

        #region Commands
        public ICommand ChangeDateSelectionCommand { get; set; }
        public ICommand CurrentPageCalendarChangedCommand { get; set; }
        #endregion

        #region Constructors
        public SwipableCalendarExampleViewModel()
        {
            ChangeDateSelectionCommand = new Command<DateTime>(ChangeDateSelection);
            CurrentPageCalendarChangedCommand = new Command(CurrentPageCalendarChanged);

            SecondPageCalendar.SelectedDates = FirstPageCalendar.SelectedDates;
            SecondPageCalendar.DayNamesOrder = FirstPageCalendar.DayNamesOrder;
            SecondPageCalendar.CustomDayNamesOrder = FirstPageCalendar.CustomDayNamesOrder;

            ThirdPageCalendar.SelectedDates = FirstPageCalendar.SelectedDates;
            ThirdPageCalendar.DayNamesOrder = FirstPageCalendar.DayNamesOrder;
            ThirdPageCalendar.CustomDayNamesOrder = FirstPageCalendar.CustomDayNamesOrder;

            Calendars.Add(FirstPageCalendar);
            Calendars.Add(SecondPageCalendar);
            Calendars.Add(ThirdPageCalendar);

            UpdateCalendarPages();
        }
        #endregion

        #region Methods
        public void ChangeDateSelection(DateTime DateTime)
        {
            CurrentPageCalendar.ChangeDateSelection(DateTime);
        }
        public void CurrentPageCalendarChanged()
        {
            UpdateCalendarPages();
        }
        public void UpdateCalendarPages()
        {
            TimeSpan BackwardsNavigationTimeSpan;
            TimeSpan ForwardsNavigationTimeSpan;
            int ForwardsNavigationAmount = 1;
            int BackwardsNavigationAmount = -1;

            if (CurrentPageCalendar.NavigatedDate.TryAddMonths(BackwardsNavigationAmount, out DateTime BackwardsNavigationDateTime))
            {
                BackwardsNavigationTimeSpan = BackwardsNavigationDateTime - CurrentPageCalendar.NavigatedDate;
            }
            else
            {
                BackwardsNavigationTimeSpan = BackwardsNavigationAmount > 0 ? TimeSpan.MaxValue : TimeSpan.MinValue;
            }

            if (CurrentPageCalendar.NavigatedDate.TryAddMonths(ForwardsNavigationAmount, out DateTime ForwardsNavigationDateTime))
            {
                ForwardsNavigationTimeSpan = ForwardsNavigationDateTime - CurrentPageCalendar.NavigatedDate;
            }
            else
            {
                ForwardsNavigationTimeSpan = ForwardsNavigationAmount > 0 ? TimeSpan.MaxValue : TimeSpan.MinValue;
            }

            DateTime CurrentPageCalendarPreviousNavigatedDate = CurrentPageCalendar.NavigatedDate.Navigate(BackwardsNavigationTimeSpan, CurrentPageCalendar.NavigationLowerBound, CurrentPageCalendar.NavigationUpperBound, CurrentPageCalendar.NavigationLoopMode, CurrentPageCalendar.StartOfWeek);
            DateTime CurrentPageCalendarNextNavigatedDate = CurrentPageCalendar.NavigatedDate.Navigate(ForwardsNavigationTimeSpan, CurrentPageCalendar.NavigationLowerBound, CurrentPageCalendar.NavigationUpperBound, CurrentPageCalendar.NavigationLoopMode, CurrentPageCalendar.StartOfWeek);

            if (CurrentPageCalendar == FirstPageCalendar)
            {
                SecondPageCalendar.NavigatedDate = CurrentPageCalendarNextNavigatedDate;
                ThirdPageCalendar.NavigatedDate = CurrentPageCalendarPreviousNavigatedDate;
            }
            else if (CurrentPageCalendar == SecondPageCalendar)
            {
                FirstPageCalendar.NavigatedDate = CurrentPageCalendarPreviousNavigatedDate;
                ThirdPageCalendar.NavigatedDate = CurrentPageCalendarNextNavigatedDate;
            }
            else if (CurrentPageCalendar == ThirdPageCalendar)
            {
                FirstPageCalendar.NavigatedDate = CurrentPageCalendarNextNavigatedDate;
                SecondPageCalendar.NavigatedDate = CurrentPageCalendarPreviousNavigatedDate;
            }
        }
        #endregion
    }
}
