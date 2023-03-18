using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using XCalendar.Core.Collections;
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
        PageStartMode PageStartMode { get; set; }
        ObservableRangeCollection<DayOfWeek> DayNamesOrder { get; }
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
        void UpdateDay(T day, DateTime newDateTime);
        void ChangeDateSelection(DateTime dateTime);
        void CommitRangeSelection();
        int GetMonthRows(DateTime dateTime, bool isConsistent, DayOfWeek startOfWeek);
        void UpdateDays(DateTime navigationDate);
        void Navigate(TimeSpan timeSpan);
        #endregion
    }
}
