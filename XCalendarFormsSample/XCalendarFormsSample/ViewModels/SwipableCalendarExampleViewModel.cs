using System;
using System.Windows.Input;
using Xamarin.Forms;
using XCalendar.Core.Enums;
using XCalendar.Core.Extensions;
using XCalendar.Core.Models;

namespace XCalendarFormsSample.ViewModels
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
        public void ChangeDateSelection(DateTime dateTime)
        {
            CurrentPageCalendar.ChangeDateSelection(dateTime);
        }
        public void CurrentPageCalendarChanged()
        {
            UpdateCalendarPages();
        }
        public void UpdateCalendarPages()
        {
            TimeSpan backwardsNavigationTimeSpan;
            TimeSpan forwardsNavigationTimeSpan;
            int forwardsNavigationAmount = 1;
            int backwardsNavigationAmount = -1;

            if (CurrentPageCalendar.NavigatedDate.TryAddMonths(backwardsNavigationAmount, out DateTime backwardsNavigationDateTime))
            {
                backwardsNavigationTimeSpan = backwardsNavigationDateTime - CurrentPageCalendar.NavigatedDate;
            }
            else
            {
                backwardsNavigationTimeSpan = backwardsNavigationAmount > 0 ? TimeSpan.MaxValue : TimeSpan.MinValue;
            }

            if (CurrentPageCalendar.NavigatedDate.TryAddMonths(forwardsNavigationAmount, out DateTime forwardsNavigationDateTime))
            {
                forwardsNavigationTimeSpan = forwardsNavigationDateTime - CurrentPageCalendar.NavigatedDate;
            }
            else
            {
                forwardsNavigationTimeSpan = forwardsNavigationAmount > 0 ? TimeSpan.MaxValue : TimeSpan.MinValue;
            }

            DateTime currentPageCalendarPreviousNavigatedDate = CurrentPageCalendar.NavigatedDate.Navigate(backwardsNavigationTimeSpan, CurrentPageCalendar.NavigationLowerBound, CurrentPageCalendar.NavigationUpperBound, CurrentPageCalendar.NavigationLoopMode, CurrentPageCalendar.StartOfWeek);
            DateTime currentPageCalendarNextNavigatedDate = CurrentPageCalendar.NavigatedDate.Navigate(forwardsNavigationTimeSpan, CurrentPageCalendar.NavigationLowerBound, CurrentPageCalendar.NavigationUpperBound, CurrentPageCalendar.NavigationLoopMode, CurrentPageCalendar.StartOfWeek);

            if (CurrentPageCalendar == FirstPageCalendar)
            {
                SecondPageCalendar.NavigatedDate = currentPageCalendarNextNavigatedDate;
                ThirdPageCalendar.NavigatedDate = currentPageCalendarPreviousNavigatedDate;
            }
            else if (CurrentPageCalendar == SecondPageCalendar)
            {
                FirstPageCalendar.NavigatedDate = currentPageCalendarPreviousNavigatedDate;
                ThirdPageCalendar.NavigatedDate = currentPageCalendarNextNavigatedDate;
            }
            else if (CurrentPageCalendar == ThirdPageCalendar)
            {
                FirstPageCalendar.NavigatedDate = currentPageCalendarNextNavigatedDate;
                SecondPageCalendar.NavigatedDate = currentPageCalendarPreviousNavigatedDate;
            }
        }
        #endregion
    }
}
