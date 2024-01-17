using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using XCalendar.Core.Collections;
using XCalendar.Core.Enums;
using XCalendar.Core.Extensions;
using XCalendar.Core.Interfaces;

namespace XCalendar.Core.Models
{
    /// <summary>
    /// A class representing a calendar.
    /// </summary>
    public class Calendar : Calendar<CalendarDay>
    {
    }
    /// <summary>
    /// A class representing a calendar.
    /// </summary>
    /// <typeparam name="T">A model implementing <see cref="ICalendarDay"/> to be used to represent each day in a page.</typeparam>
    public class Calendar<T> : ICalendar<T> where T : ICalendarDay, new()
    {
        #region Fields
        protected static readonly ReadOnlyCollection<DayOfWeek> DaysOfWeek = DayOfWeekExtensions.DaysOfWeek;
        private ObservableCollection<T> _days = new ObservableCollection<T>();
        private readonly List<DateTime> _previousSelectedDates = new List<DateTime>();
        private DateTime _navigatedDate = DateTime.Today;
        private DateTime _todayDate = DateTime.Today;
        private DateTime _navigationLowerBound = DateTime.MinValue;
        private DateTime _navigationUpperBound = DateTime.MaxValue;
        private DayOfWeek _startOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
        private bool _autoRows = true;
        private bool _autoRowsIsConsistent = true;
        private SelectionAction _selectionAction = SelectionAction.Modify;
        private NavigationLoopMode _navigationLoopMode = NavigationLoopMode.LoopMinimumAndMaximum;
        private ObservableRangeCollection<DateTime> _selectedDates = new ObservableRangeCollection<DateTime>();
        private ObservableRangeCollection<DayOfWeek> _customDayNamesOrder;
        private int _rows = 6;
        private PageStartMode _pageStartMode = PageStartMode.FirstDayOfMonth;
        private ObservableRangeCollection<DayOfWeek> _dayNamesOrder = new ObservableRangeCollection<DayOfWeek>();
        private DateTime? _rangeSelectionStart;
        private DateTime? _rangeSelectionEnd;
        private SelectionType _selectionType = SelectionType.None;
        #endregion

        #region Properties
        /// <summary>
        /// The list of displayed days.
        /// </summary>
        public ObservableCollection<T> Days
        {
            get
            {
                return _days;
            }
            protected set
            {
                if (_days != value)
                {
                    _days = value;

                    OnPropertyChanged(nameof(Days));
                }
            }
        }
        /// <summary>
        /// The date the calendar will use to get the dates representing a time unit.
        /// </summary>
        public DateTime NavigatedDate
        {
            get
            {
                return _navigatedDate;
            }
            set
            {
                if (_navigatedDate != value)
                {
                    var oldValue = _navigatedDate;
                    _navigatedDate = value;

                    OnNavigatedDateChanged(oldValue, _navigatedDate);
                    OnPropertyChanged(nameof(NavigatedDate));
                }
            }
        }
        /// <summary>
        /// The date that the calendar should consider as 'Today'.
        /// </summary>
        public DateTime TodayDate
        {
            get
            {
                return _todayDate;
            }
            set
            {
                if (_todayDate != value)
                {
                    var oldValue = _todayDate;
                    _todayDate = value;

                    OnTodayDateChanged(oldValue, _todayDate);
                    OnPropertyChanged(nameof(TodayDate));
                }
            }
        }
        /// <summary>
        /// The lower bound of the day range.
        /// </summary>
        /// <seealso cref="NavigationLoopMode"/>
        public DateTime NavigationLowerBound
        {
            get
            {
                return _navigationLowerBound;
            }
            set
            {
                if (_navigationLowerBound != value)
                {
                    var oldValue = _navigationLowerBound;
                    _navigationLowerBound = value;

                    OnNavigationLowerBoundChanged(oldValue, _navigationLowerBound);
                    OnPropertyChanged(nameof(NavigationLowerBound));
                }
            }
        }
        /// <summary>
        /// The upper bound of the day range.
        /// </summary>
        /// <seealso cref="NavigationLoopMode"/>
        public DateTime NavigationUpperBound
        {
            get
            {
                return _navigationUpperBound;
            }
            set
            {
                if (_navigationUpperBound != value)
                {
                    var oldValue = _navigationUpperBound;
                    _navigationUpperBound = value;

                    OnNavigationUpperBoundChanged(oldValue, _navigationUpperBound);
                    OnPropertyChanged(nameof(NavigationUpperBound));
                }
            }
        }
        /// <summary>
        /// The day of week that should be considered as the start of the week.
        /// </summary>
        /// <seealso cref="CustomDayNamesOrder"/>
        public DayOfWeek StartOfWeek
        {
            get
            {
                return _startOfWeek;
            }
            set
            {
                if (_startOfWeek != value)
                {
                    var oldValue = _startOfWeek;
                    _startOfWeek = value;

                    OnStartOfWeekChanged(oldValue, _startOfWeek);
                    OnPropertyChanged(nameof(StartOfWeek));
                }
            }
        }
        /// <summary>
        /// Whether to automatically add as many rows as needed to represent the time unit or not.
        /// </summary>
        /// <seealso cref="AutoRowsIsConsistent"/>
        public bool AutoRows
        {
            get
            {
                return _autoRows;
            }
            set
            {
                if (_autoRows != value)
                {
                    var oldValue = _autoRows;
                    _autoRows = value;

                    OnAutoRowsChanged(oldValue, _autoRows);
                    OnPropertyChanged(nameof(AutoRows));
                }
            }
        }
        /// <summary>
        /// Whether to make sure the amount of rows stays the same across the time unit.
        /// </summary>
        /// <example>If the <see cref="StartOfWeek"/> is Monday, the highest number of rows needed to display a month in 2022 is 6 rows (May, October etc).
        /// If this property is true, the calendar will display 6 rows regardless of whether a month needs less or not (April, November etc).
        /// Otherwise it will display as needed: (5 for April and November, 6 for May and October etc).</example>
        /// <seealso cref="AutoRows"/>
        public bool AutoRowsIsConsistent
        {
            get
            {
                return _autoRowsIsConsistent;
            }
            set
            {
                if (_autoRowsIsConsistent != value)
                {
                    var oldValue = _autoRowsIsConsistent;
                    _autoRowsIsConsistent = value;

                    OnAutoRowsIsConsistentChanged(oldValue, _autoRowsIsConsistent);
                    OnPropertyChanged(nameof(AutoRowsIsConsistent));
                }
            }
        }
        /// <summary>
        /// The type of selection to use for selecting dates.
        /// </summary>
        public SelectionAction SelectionAction
        {
            get
            {
                return _selectionAction;
            }
            set
            {
                if (_selectionAction != value)
                {
                    _selectionAction = value;

                    OnPropertyChanged(nameof(SelectionAction));
                }
            }
        }
        /// <summary>
        /// How the calendar handles navigation past the <see cref="DateTime.MinValue"/>, <see cref="DateTime.MaxValue"/>, <see cref="NavigationLowerBound"/>, and <see cref="NavigationUpperBound"/>.
        /// </summary>
        /// <seealso cref="NavigateCalendar(int)"/>
        public NavigationLoopMode NavigationLoopMode
        {
            get
            {
                return _navigationLoopMode;
            }
            set
            {
                if (_navigationLoopMode != value)
                {
                    _navigationLoopMode = value;

                    OnPropertyChanged(nameof(NavigationLoopMode));
                }
            }
        }
        /// <summary>
        /// The dates that are currently selected.
        /// </summary>
        public ObservableRangeCollection<DateTime> SelectedDates
        {
            get
            {
                return _selectedDates;
            }
            set
            {
                if (_selectedDates != value)
                {
                    var oldValue = _selectedDates;
                    _selectedDates = value;

                    OnSelectedDatesChanged(oldValue, _selectedDates);
                    OnPropertyChanged(nameof(SelectedDates));
                }
            }
        }
        /// <summary>
        /// The custom order to display the days of the week in. Replaces the values inside <see cref="DayNamesOrder"/> when this value is not null.
        /// First, the calendar uses the <see cref="StartOfWeek"/> to get the <see cref="DateTime"/>s
        /// for every day of the week, then it uses those <see cref="DateTime"/>s to construct the dates in the order of the values inside this collection.
        /// </summary>
        public ObservableRangeCollection<DayOfWeek> CustomDayNamesOrder
        {
            get
            {
                return _customDayNamesOrder;
            }
            set
            {
                if (_customDayNamesOrder != value)
                {
                    var oldValue = _customDayNamesOrder;
                    _customDayNamesOrder = value;

                    OnCustomDayNamesOrderChanged(oldValue, _customDayNamesOrder);
                    OnPropertyChanged(nameof(CustomDayNamesOrder));
                }
            }
        }
        /// <summary>
        /// The number of rows to display.
        /// </summary>
        /// <seealso cref="AutoRows"/>
        public int Rows
        {
            get
            {
                return _rows;
            }
            set
            {
                if (_rows != value)
                {
                    var oldValue = _rows;
                    _rows = value;

                    OnRowsChanged(oldValue, _rows);
                    OnPropertyChanged(nameof(Rows));
                }
            }
        }
        /// <summary>
        /// The way in which to extract a date from the <see cref="NavigatedDate"/> to use as the first date of the first row.
        /// </summary>
        /// <example>If the <see cref="StartOfWeek"/> is Monday and the navigated date is 15th July 2022:
        /// <see cref="PageStartMode.FirstDayOfWeek"/> will extract 11th July 2022.
        /// <see cref="PageStartMode.FirstDayOfMonth"/> will extract 27th June 2022 (First day in the week of 1st July 2022).
        /// <see cref="PageStartMode.FirstDayOfYear"/> will extract 27th December 2021 (First day in the week of 1st January 2022).</example>
        public PageStartMode PageStartMode
        {
            get
            {
                return _pageStartMode;
            }
            set
            {
                if (_pageStartMode != value)
                {
                    var oldValue = _pageStartMode;
                    _pageStartMode = value;

                    OnPageStartModeChanged(oldValue, _pageStartMode);
                    OnPropertyChanged(nameof(PageStartMode));
                }
            }
        }
        /// <summary>
        /// The order to display the days of the week in.
        /// </summary>
        public ObservableRangeCollection<DayOfWeek> DayNamesOrder
        {
            get
            {
                return _dayNamesOrder;
            }
            set
            {
                if (_dayNamesOrder != value)
                {
                    var oldValue = _dayNamesOrder;
                    _dayNamesOrder = value;

                    OnDayNamesOrderChanged(oldValue, _dayNamesOrder);
                    OnPropertyChanged(nameof(DayNamesOrder));
                }
            }
        }
        /// <summary>
        /// The start of the range of dates to perform selection on inclusive.

        ///If <see cref="RangeSelectionStart"/> and <see cref="RangeSelectionEnd"/> are not null, <see cref="CommitRangeSelection"/> will be called and their values will be set back to null.
        /// </summary>
        public DateTime? RangeSelectionStart
        {
            get
            {
                return _rangeSelectionStart;
            }
            set
            {
                if (_rangeSelectionStart != value)
                {
                    var oldValue = _rangeSelectionStart;
                    _rangeSelectionStart = value;

                    OnRangeSelectionStartChanged(oldValue, _rangeSelectionStart);
                    OnPropertyChanged(nameof(RangeSelectionStart));
                }
            }
        }
        /// <summary>
        /// The end of the range of dates to perform selection on inclusive.
        ///If <see cref="RangeSelectionStart"/> and <see cref="RangeSelectionEnd"/> are not null, <see cref="CommitRangeSelection"/> will be called and their values will be set back to null.
        /// </summary>
        public DateTime? RangeSelectionEnd
        {
            get
            {
                return _rangeSelectionEnd;
            }
            set
            {
                if (_rangeSelectionEnd != value)
                {
                    var oldValue = _rangeSelectionEnd;
                    _rangeSelectionEnd = value;

                    OnRangeSelectionEndChanged(oldValue, _rangeSelectionEnd);
                    OnPropertyChanged(nameof(RangeSelectionEnd));
                }
            }
        }
        /// <summary>
        /// Defines how the user is able to select dates.
        /// </summary>
        public SelectionType SelectionType
        {
            get
            {
                return _selectionType;
            }
            set
            {
                if (_selectionType != value)
                {
                    _selectionType = value;

                    OnPropertyChanged(nameof(SelectionType));
                }
            }
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DateSelectionChangedEventArgs> DateSelectionChanged;
        public event EventHandler DaysUpdated;
        public event EventHandler DaysUpdating;
        #endregion

        #region Constructors
        public Calendar()
        {
            if (CustomDayNamesOrder == null)
            {
                DayNamesOrder.ReplaceRange(StartOfWeek.GetWeekAsFirst());
            }
            else
            {
                DayNamesOrder.ReplaceRange(CustomDayNamesOrder);
            }

            if (DayNamesOrder != null)
            {
                DayNamesOrder.CollectionChanged += DayNamesOrder_CollectionChanged;
            }
            if (CustomDayNamesOrder != null)
            {
                CustomDayNamesOrder.CollectionChanged += CustomDayNamesOrder_CollectionChanged;
            }
            if (SelectedDates != null)
            {
                SelectedDates.CollectionChanged += SelectedDates_CollectionChanged;
            }

            //Not needed because days are updated in previous lines of code.
            UpdateDays(NavigatedDate);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Called when <see cref="SelectedDates"/> changes.
        /// </summary>
        /// <param name="oldSelection">The previously selected dates.</param>
        /// <param name="newSelection">The newely selected dates.</param>
        protected virtual void OnDateSelectionChanged(IList<DateTime> oldSelection, IList<DateTime> newSelection)
        {
            DateSelectionChanged?.Invoke(this, new DateSelectionChangedEventArgs(oldSelection, newSelection));
        }
        protected virtual void OnDaysUpdated()
        {
            DaysUpdated?.Invoke(this, new EventArgs());
        }
        protected virtual void OnDaysUpdating()
        {
            DaysUpdating?.Invoke(this, new EventArgs());
        }
        /// <summary>
        /// Performs selection of a <see cref="DateTime"/> depending on the current <see cref="SelectionAction"/> and <see cref="SelectionType"/>.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to select/unselect.</param>
        public virtual void ChangeDateSelection(DateTime dateTime)
        {
            switch (SelectionType)
            {
                case SelectionType.None:
                    break;

                case SelectionType.Single:
                    switch (SelectionAction)
                    {
                        case SelectionAction.Add:
                            if (!SelectedDates.Any(x => x.Date == dateTime.Date))
                            {
                                SelectedDates.Add(dateTime.Date);
                            }
                            break;

                        case SelectionAction.Remove:
                            if (SelectedDates.Any(x => x.Date == dateTime.Date))
                            {
                                SelectedDates.Remove(dateTime.Date);
                            }
                            break;

                        case SelectionAction.Modify:
                            if (SelectedDates.Any(x => x.Date == dateTime.Date))
                            {
                                SelectedDates.Remove(dateTime.Date);
                            }
                            else
                            {
                                SelectedDates.Add(dateTime.Date);
                            }
                            break;

                        case SelectionAction.Replace:
                            if (SelectedDates.Count != 1 || (SelectedDates.Count == 1 && SelectedDates.First().Date != dateTime.Date))
                            {
                                SelectedDates.Replace(dateTime.Date);
                            }
                            break;

                        default:
                            throw new NotImplementedException();
                    }
                    break;

                case SelectionType.Range:
                    if (RangeSelectionStart == null)
                    {
                        RangeSelectionStart = dateTime;
                    }
                    else if (dateTime == RangeSelectionStart)
                    {
                        RangeSelectionStart = null;
                    }
                    else if (dateTime != RangeSelectionStart)
                    {
                        RangeSelectionEnd = dateTime;
                    }
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
        /// <summary>
        ///  Performs selection on a range of dates as defined by <see cref="RangeSelectionStart"/> and <see cref="RangeSelectionEnd"/> depending on the current <see cref="SelectionType"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="RangeSelectionStart"/> and <see cref="RangeSelectionEnd"/> must not be null."</exception>
        public virtual void CommitRangeSelection()
        {
            if (RangeSelectionStart == null || RangeSelectionEnd == null) { throw new InvalidOperationException($"{nameof(RangeSelectionStart)} and {nameof(RangeSelectionEnd)} must not be null."); }

            List<DateTime> dateRange = RangeSelectionStart.Value.GetDatesBetween(RangeSelectionEnd.Value);
            IEnumerable<DateTime> datesToAdd = dateRange.Where(x => !SelectedDates.Contains(x.Date));
            IEnumerable<DateTime> datesToRemove = dateRange.Where(x => SelectedDates.Contains(x.Date));

            switch (SelectionAction)
            {
                case SelectionAction.Add:
                    if (datesToAdd.Any())
                    {
                        SelectedDates.AddRange(datesToAdd);
                    }
                    break;

                case SelectionAction.Remove:
                    if (datesToRemove.Any())
                    {
                        SelectedDates.RemoveRange(datesToRemove);
                    }
                    break;

                case SelectionAction.Modify:
                    if (datesToAdd.Any() || datesToRemove.Any())
                    {
                        List<DateTime> newSelectedDates = SelectedDates.Where(x => !datesToRemove.Contains(x.Date)).ToList();
                        newSelectedDates.AddRange(datesToAdd);
                        SelectedDates.ReplaceRange(newSelectedDates);
                    }
                    break;

                case SelectionAction.Replace:
                    if (SelectedDates.SequenceEqual(dateRange))
                    {
                        SelectedDates.Clear();
                    }
                    else
                    {
                        SelectedDates.ReplaceRange(dateRange);
                    }
                    break;

                default:
                    throw new NotImplementedException();
            }

            RangeSelectionStart = null;
            RangeSelectionEnd = null;
        }
        /// <summary>
        /// Gets the number of rows needed to display the days of a month based on how many weeks the months has.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> representing the month to get the number of rows for.</param>
        /// <param name="isConsistent">Whether the return value should be the highest possible value occuring in the year or not.</param>
        /// <param name="startOfWeek">The start of the week.</param>
        /// <returns></returns>
        public int GetMonthRows(DateTime dateTime, bool isConsistent, DayOfWeek startOfWeek)
        {
            if (isConsistent)
            {
                return dateTime.CalendarHighestMonthWeekCountOfYear(startOfWeek);
            }
            else
            {
                return dateTime.CalendarWeeksInMonth(startOfWeek);
            }
        }
        /// <summary>
        /// Evaluates if the specified <see cref="DateTime"/> is in the <see cref="NavigatedDate"/>'s Calendar month.
        /// </summary>
        /// <param name="dateTime">The value to evaluate.</param>
        /// <returns></returns>
        public virtual bool IsDateTimeCurrentMonth(DateTime dateTime)
        {
            return dateTime.Month == NavigatedDate.Month && dateTime.Year == NavigatedDate.Year;
        }
        /// <summary>
        /// Evaluates if the specified <see cref="DateTime"/> is considered as 'Today' by the calendar.
        /// </summary>
        /// <param name="dateTime">The value to evaluate.</param>
        /// <returns></returns>
        public virtual bool IsDateTimeToday(DateTime dateTime)
        {
            return dateTime.Date == TodayDate.Date;
        }
        /// <summary>
        /// Evaluates if the specified <see cref="DateTime"/> is considered as selected by the Calendar.
        /// </summary>
        /// <param name="dateTime">The value to evaluate.</param>
        /// <returns></returns>
        public virtual bool IsDateTimeSelected(DateTime dateTime)
        {
            return SelectedDates.Any(x => x.Date == dateTime.Date) == true;
        }
        /// <summary>
        /// Evaluates if the specified <see cref="DateTime"/> is not in a valid range for the Calendar.
        /// </summary>
        /// <param name="dateTime">The value to evaluate.</param>
        /// <returns></returns>
        public virtual bool IsDateTimeInvalid(DateTime dateTime)
        {
            return dateTime.Date < NavigationLowerBound.Date || dateTime.Date > NavigationUpperBound.Date;
        }
        /// <summary>
        /// Updates a day to represent the <see cref="DateTime"/> specified by <paramref name="newDateTime"/>.
        /// </summary>
        /// <param name="day">The day to update.</param>
        /// <param name="newDateTime">The new <see cref="DateTime"/> that '<see cref="day"/>' should represent.</param>
        public virtual void UpdateDay(T day, DateTime newDateTime)
        {
            day.DateTime = newDateTime;
            day.IsCurrentMonth = IsDateTimeCurrentMonth(day.DateTime);
            day.IsToday = IsDateTimeToday(day.DateTime);
            day.IsSelected = IsDateTimeSelected(day.DateTime);
            day.IsInvalid = IsDateTimeInvalid(day.DateTime);
        }
        /// <summary>
        /// Updates the dates displayed on the calendar.
        /// </summary>
        /// <param name="navigationDate">The <see cref="DateTime"/> who's month will be used to update the dates.</param>
        public void UpdateDays(DateTime navigationDate)
        {
            OnDaysUpdating();

            int rowsRequiredToNavigate = AutoRows ? GetMonthRows(navigationDate, AutoRowsIsConsistent, StartOfWeek) : Rows;
            int daysRequiredToNavigate = rowsRequiredToNavigate * DayNamesOrder.Count;

            //Determine the starting date of the page.
            DateTime pageStartDate;
            switch (PageStartMode)
            {
                case PageStartMode.FirstDayOfWeek:
                    pageStartDate = navigationDate.FirstDayOfWeek(StartOfWeek);
                    break;
                case PageStartMode.FirstDayOfMonth:
                    pageStartDate = navigationDate.FirstDayOfMonth().FirstDayOfWeek(StartOfWeek);
                    break;
                case PageStartMode.FirstDayOfYear:
                    pageStartDate = new DateTime(NavigatedDate.Year, 1, 1).FirstDayOfWeek(StartOfWeek);
                    break;
                default:
                    throw new NotImplementedException($"{nameof(Enums.PageStartMode)} '{PageStartMode}' has not been implemented.");
            }

            //Update the dates for each row.
            int daysUpdated = 0;

            for (int rowsUpdated = 0; daysUpdated < daysRequiredToNavigate; rowsUpdated++)
            {
                Dictionary<DayOfWeek, DateTime> row = new Dictionary<DayOfWeek, DateTime>();

                //Get the updated dates for the row.
                for (int i = 0; i < DaysOfWeek.Count; i++)
                {
                    try
                    {
                        DateTime dateTime = pageStartDate.AddDays(rowsUpdated * DaysOfWeek.Count + i);
                        row.Add(dateTime.DayOfWeek, dateTime);
                    }
                    catch (ArgumentOutOfRangeException ex) when (ex.TargetSite.DeclaringType == typeof(DateTime))
                    {
                        row.Add(DaysOfWeek[i], DateTime.MaxValue);
                    }
                }

                //Update or create days for the row based on the DayNamesOrder.
                foreach (DayOfWeek dayOfWeek in DayNamesOrder)
                {
                    DateTime newDateTime = row[dayOfWeek];

                    if (Days.Count <= daysUpdated)
                    {
                        T newDay = new T();
                        UpdateDay(newDay, newDateTime);
                        Days.Add(newDay);
                    }
                    else
                    {
                        UpdateDay(Days[daysUpdated], newDateTime);
                    }

                    daysUpdated += 1;
                }
            }

            //Remove any extra days.
            while (Days.Count > daysRequiredToNavigate)
            {
                Days.RemoveAt(Days.Count - 1);
            }

            OnDaysUpdated();
        }
        /// <summary>
        /// Navigates the calendar by the specified <see cref="TimeSpan"/> using the navigation rule properties set in the calendar (<see cref="NavigationLowerBound"/>, <see cref="NavigationUpperBound"/> <see cref="NavigationLoopMode"/>).
        /// </summary>
        public virtual void Navigate(TimeSpan timeSpan)
        {
            NavigatedDate = NavigatedDate.Navigate(timeSpan, NavigationLowerBound, NavigationUpperBound, NavigationLoopMode, StartOfWeek);
        }
        /// <summary>
        /// Raises an event signaling that the days' properties need to be reevaluated due to changes in the <see cref="CalendarView"/>
        /// </summary>
        private void SelectedDates_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateDays(NavigatedDate);

            OnDateSelectionChanged(_previousSelectedDates, SelectedDates);

            _previousSelectedDates.Clear();
            _previousSelectedDates.AddRange(SelectedDates.ToList());
        }
        private void DayNamesOrder_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateDays(NavigatedDate);
        }
        private void CustomDayNamesOrder_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (!DayNamesOrder.SequenceEqual(CustomDayNamesOrder))
            {
                DayNamesOrder.ReplaceRange(CustomDayNamesOrder);
            }
        }
        private void OnRowsChanged(int oldValue, int newValue)
        {
            int coercedRows = CoerceRows(Rows);

            if (coercedRows < 1) { throw new ArgumentOutOfRangeException(nameof(newValue)); }

            if (Rows != coercedRows)
            {
                Rows = coercedRows;
            }
            else
            {
                UpdateDays(NavigatedDate);
            }
        }
        private void OnNavigatedDateChanged(DateTime oldValue, DateTime newValue)
        {
            NavigatedDate = CoerceNavigatedDate(newValue);

            int coercedRows = CoerceRows(Rows);

            if (Rows != coercedRows)
            {
                Rows = coercedRows;
            }
            else
            {
                UpdateDays(NavigatedDate);
            }
        }
        private void OnTodayDateChanged(DateTime oldValue, DateTime newValue)
        {
            UpdateDays(NavigatedDate);
        }
        private void OnStartOfWeekChanged(DayOfWeek oldValue, DayOfWeek newValue)
        {
            if (CustomDayNamesOrder == null)
            {
                DayNamesOrder.ReplaceRange(StartOfWeek.GetWeekAsFirst());
            }
            else
            {
                UpdateDays(NavigatedDate);
            }
        }
        private void OnNavigationLowerBoundChanged(DateTime oldValue, DateTime newValue)
        {
            NavigatedDate = CoerceNavigatedDate(newValue);

            //Days are already updated if the coerced value is different from the new value.
            if (NavigatedDate == newValue)
            {
                UpdateDays(newValue);
            }
        }
        private void OnNavigationUpperBoundChanged(DateTime oldValue, DateTime newValue)
        {
            NavigatedDate = CoerceNavigatedDate(newValue);

            //Days are already updated if the coerced value is different from the new value.
            if (NavigatedDate == newValue)
            {
                UpdateDays(newValue);
            }
        }
        private void OnSelectedDatesChanged(ObservableRangeCollection<DateTime> oldValue, ObservableRangeCollection<DateTime> newValue)
        {
            if (newValue == null) { throw new ArgumentException(nameof(newValue)); }

            if (oldValue != null) { oldValue.CollectionChanged -= SelectedDates_CollectionChanged; }
            if (newValue != null) { newValue.CollectionChanged += SelectedDates_CollectionChanged; }

            _previousSelectedDates.Clear();
            _previousSelectedDates.AddRange(oldValue);

            if (oldValue == null || !oldValue.SequenceEqual(newValue))
            {
                UpdateDays(NavigatedDate);
                OnDateSelectionChanged(_previousSelectedDates, newValue);
            }
        }
        private void OnCustomDayNamesOrderChanged(ObservableRangeCollection<DayOfWeek> oldValue, ObservableRangeCollection<DayOfWeek> newValue)
        {
            if (oldValue != null) { oldValue.CollectionChanged -= CustomDayNamesOrder_CollectionChanged; }
            if (newValue != null) { newValue.CollectionChanged += CustomDayNamesOrder_CollectionChanged; }

            if (newValue == null)
            {
                DayNamesOrder.ReplaceRange(StartOfWeek.GetWeekAsFirst());
            }
            else if (!DayNamesOrder.SequenceEqual(newValue))
            {
                DayNamesOrder.ReplaceRange(newValue);
            }
        }
        private void OnAutoRowsChanged(bool oldValue, bool newValue)
        {
            Rows = CoerceRows(Rows);
        }
        private void OnAutoRowsIsConsistentChanged(bool oldValue, bool newValue)
        {
            Rows = CoerceRows(Rows);
        }
        private void OnDayNamesOrderChanged(ObservableRangeCollection<DayOfWeek> oldValue, ObservableRangeCollection<DayOfWeek> newValue)
        {
            if (newValue == null) { throw new ArgumentNullException(nameof(newValue)); }
            if (newValue.Count == 0) { throw new ArgumentException(nameof(newValue)); }

            if (oldValue != null) { oldValue.CollectionChanged -= DayNamesOrder_CollectionChanged; }
            if (newValue != null) { newValue.CollectionChanged += DayNamesOrder_CollectionChanged; }

            if (CustomDayNamesOrder != null && !CustomDayNamesOrder.SequenceEqual(newValue))
            {
                newValue.ReplaceRange(CustomDayNamesOrder);
            }
            else if (oldValue == null || !oldValue.SequenceEqual(newValue))
            {
                UpdateDays(NavigatedDate);
            }
        }
        private void OnPageStartModeChanged(PageStartMode oldValue, PageStartMode newValue)
        {
            UpdateDays(NavigatedDate);
        }
        private void OnRangeSelectionStartChanged(DateTime? oldValue, DateTime? newValue)
        {
            if (RangeSelectionStart != null && RangeSelectionEnd != null)
            {
                CommitRangeSelection();
            }
        }
        private void OnRangeSelectionEndChanged(DateTime? oldValue, DateTime? newValue)
        {
            if (RangeSelectionStart != null && RangeSelectionEnd != null)
            {
                CommitRangeSelection();
            }
        }
        private DateTime CoerceNavigatedDate(DateTime value)
        {
            DateTime minimumDate = NavigationLowerBound;
            DateTime maximumDate = NavigationUpperBound;

            switch (NavigationLoopMode)
            {
                case NavigationLoopMode.DontLoop:
                    if (value.Date < minimumDate.Date) { return minimumDate; }
                    if (value.Date > maximumDate.Date) { return maximumDate; }
                    break;
                case NavigationLoopMode.LoopMinimum:
                    if (value.Date < minimumDate.Date) { return maximumDate; }
                    if (value.Date > maximumDate.Date) { return maximumDate; }
                    break;

                case NavigationLoopMode.LoopMaximum:
                    if (value.Date < minimumDate.Date) { return minimumDate; }
                    if (value.Date > maximumDate.Date) { return minimumDate; }
                    break;

                case NavigationLoopMode.LoopMinimumAndMaximum:
                    if (value.Date < minimumDate.Date) { return maximumDate; }
                    if (value.Date > maximumDate.Date) { return minimumDate; }
                    break;

                default:
                    throw new NotImplementedException($"{nameof(NavigationLoopMode)} is not implemented.");
            }

            return value;
        }
        private int CoerceRows(int value)
        {
            return AutoRows ? GetMonthRows(NavigatedDate, AutoRowsIsConsistent, StartOfWeek) : value;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}