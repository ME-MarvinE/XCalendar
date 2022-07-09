using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using XCalendar.Core.Enums;
using XCalendar.Core.Models;

namespace XCalendar.Core.Interfaces
{
    public interface ICalendar<T> : INotifyPropertyChanged where T : ICalendarDay, new()
    {
        #region Properties
        ObservableCollection<T> Days { get; }
        DateTime NavigatedDate { get; set; }
        DateTime TodayDate { get; set; }
        DateTime NavigationLowerBound { get; set; }
        DateTime NavigationUpperBound { get; set; }
        DayOfWeek StartOfWeek { get; set; }
        bool AutoRows { get; set; }
        bool AutoRowsIsConsistent { get; set; }
        SelectionAction SelectionAction { get; set; }
        NavigationLoopMode NavigationLoopMode { get; set; }
        ObservableRangeCollection<DateTime> SelectedDates { get; set; }
        ObservableRangeCollection<DayOfWeek> CustomDayNamesOrder { get; set; }
        int Rows { get; set; }
        NavigationTimeUnit NavigationTimeUnit { get; set; }
        PageStartMode PageStartMode { get; set; }
        ReadOnlyObservableCollection<DayOfWeek> DayNamesOrder { get; }
        int ForwardsNavigationAmount { get; set; }
        int BackwardsNavigationAmount { get; set; }
        DateTime? RangeSelectionStart { get; set; }
        DateTime? RangeSelectionEnd { get; set; }
        SelectionType SelectionType { get; set; }
        #endregion

        #region Events
        event EventHandler<DateSelectionChangedEventArgs> DateSelectionChanged;
        event EventHandler DaysUpdated;
        event EventHandler DaysUpdating;
        #endregion

        #region Methods
        void UpdateDay(T Day, DateTime NewDateTime);
        void ChangeDateSelection(DateTime DateTime);
        void CommitRangeSelection();
        int GetMonthRows(DateTime DateTime, bool IsConsistent, DayOfWeek StartOfWeek);
        void UpdateDays(DateTime NavigationDate);
        void NavigateCalendar(int Amount);
        DateTime NavigateDateTime(DateTime DateTime, DateTime MinimumDate, DateTime MaximumDate, int Amount, NavigationLoopMode NavigationLoopMode, NavigationTimeUnit NavigationTimeUnit, DayOfWeek StartOfWeek);
        #endregion
    }
}
