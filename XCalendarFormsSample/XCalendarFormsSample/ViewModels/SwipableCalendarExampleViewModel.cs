using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using XCalendar.Core.Enums;
using XCalendar.Core.Extensions;
using XCalendar.Core.Interfaces;
using XCalendar.Core.Models;

namespace XCalendarFormsSample.ViewModels
{
    public class SwipableCalendarExampleViewModel : BaseViewModel
    {
        #region Properties
        public Calendar<CalendarDay> FirstPageCalendar { get; set; } = new Calendar<CalendarDay>() { SelectionAction = SelectionAction.Modify, SelectionType = SelectionType.Single };
        public Calendar<CalendarDay> SecondPageCalendar { get; set; } = new Calendar<CalendarDay>() { SelectionAction = SelectionAction.Modify, SelectionType = SelectionType.Single };
        public Calendar<CalendarDay> ThirdPageCalendar { get; set; } = new Calendar<CalendarDay>() { SelectionAction = SelectionAction.Modify, SelectionType = SelectionType.Single };
        public Calendar<CalendarDay> CurrentPageCalendar { get; set; }
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

            CurrentPageCalendar = SecondPageCalendar;

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
            DateTime CurrentPageCalendarPreviousNavigatedDate = CurrentPageCalendar.NavigateDateTime(CurrentPageCalendar.NavigatedDate, CurrentPageCalendar.NavigationLowerBound, CurrentPageCalendar.NavigationUpperBound, CurrentPageCalendar.BackwardsNavigationAmount, CurrentPageCalendar.NavigationLoopMode, CurrentPageCalendar.NavigationTimeUnit, CurrentPageCalendar.StartOfWeek);
            DateTime CurrentPageCalendarNextNavigatedDate = CurrentPageCalendar.NavigateDateTime(CurrentPageCalendar.NavigatedDate, CurrentPageCalendar.NavigationLowerBound, CurrentPageCalendar.NavigationUpperBound, CurrentPageCalendar.ForwardsNavigationAmount, CurrentPageCalendar.NavigationLoopMode, CurrentPageCalendar.NavigationTimeUnit, CurrentPageCalendar.StartOfWeek);

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
