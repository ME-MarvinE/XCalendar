using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using XCalendar.Core.Enums;
using XCalendar.Core.Extensions;
using XCalendar.Core.Interfaces;

namespace XCalendar.Core.Models
{
    public class Calendar : Calendar<CalendarDay>
    {
    }
    public class Calendar<T> : ICalendar<T> where T : ICalendarDay, new()
    {
        #region Fields
        protected static readonly ReadOnlyCollection<DayOfWeek> DaysOfWeek = DayOfWeekExtensions.DaysOfWeek;
        private ObservableCollection<T> _Days = new ObservableCollection<T>();
        private readonly List<DateTime> _PreviousSelectedDates = new List<DateTime>();

        private DateTime _NavigatedDate = DateTime.Today;
        private DateTime _TodayDate = DateTime.Today;
        private DateTime _NavigationLowerBound = DateTime.MinValue;
        private DateTime _NavigationUpperBound = DateTime.MaxValue;
        private DayOfWeek _StartOfWeek = CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek;
        private bool _AutoRows = true;
        private bool _AutoRowsIsConsistent = true;
        private SelectionAction _SelectionAction = SelectionAction.Modify;
        private NavigationLoopMode _NavigationLoopMode = NavigationLoopMode.LoopMinimumAndMaximum;
        private ObservableRangeCollection<DateTime> _SelectedDates = new ObservableRangeCollection<DateTime>();
        private ObservableRangeCollection<DayOfWeek> _CustomDayNamesOrder;
        private int _Rows = 6;
        private NavigationTimeUnit _NavigationTimeUnit = NavigationTimeUnit.Month;
        private PageStartMode _PageStartMode = PageStartMode.FirstDayOfMonth;
        private ReadOnlyObservableCollection<DayOfWeek> _DayNamesOrder;
        private int _ForwardsNavigationAmount = 1;
        private int _BackwardsNavigationAmount = 1;
        private DateTime? _RangeSelectionStart;
        private DateTime? _RangeSelectionEnd;
        private SelectionType _SelectionType = SelectionType.None;
        #endregion

        #region Properties
        /// <summary>
        /// The list of displayed days.
        /// </summary>
        public ObservableCollection<T> Days
        {
            get
            {
                return _Days;
            }
            protected set
            {
                if (_Days != value)
                {
                    _Days = value;

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
                return _NavigatedDate;
            }
            set
            {
                if (_NavigatedDate != value)
                {
                    var OldValue = _NavigatedDate;
                    _NavigatedDate = value;

                    OnNavigatedDateChanged(OldValue, _NavigatedDate);
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
                return _TodayDate;
            }
            set
            {
                if (_TodayDate != value)
                {
                    var OldValue = _TodayDate;
                    _TodayDate = value;

                    OnTodayDateChanged(OldValue, _TodayDate);
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
                return _NavigationLowerBound;
            }
            set
            {
                if (_NavigationLowerBound != value)
                {
                    var OldValue = _NavigationLowerBound;
                    _NavigationLowerBound = value;

                    OnNavigationLowerBoundChanged(OldValue, _NavigationLowerBound);
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
                return _NavigationUpperBound;
            }
            set
            {
                if (_NavigationUpperBound != value)
                {
                    var OldValue = _NavigationUpperBound;
                    _NavigationUpperBound = value;

                    OnNavigationUpperBoundChanged(OldValue, _NavigationUpperBound);
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
                return _StartOfWeek;
            }
            set
            {
                if (_StartOfWeek != value)
                {
                    var OldValue = _StartOfWeek;
                    _StartOfWeek = value;

                    OnStartOfWeekChanged(OldValue, _StartOfWeek);
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
                return _AutoRows;
            }
            set
            {
                if (_AutoRows != value)
                {
                    var OldValue = _AutoRows;
                    _AutoRows = value;

                    OnAutoRowsChanged(OldValue, _AutoRows);
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
                return _AutoRowsIsConsistent;
            }
            set
            {
                if (_AutoRowsIsConsistent != value)
                {
                    var OldValue = _AutoRowsIsConsistent;
                    _AutoRowsIsConsistent = value;

                    OnAutoRowsIsConsistentChanged(OldValue, _AutoRowsIsConsistent);
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
                return _SelectionAction;
            }
            set
            {
                if (_SelectionAction != value)
                {
                    _SelectionAction = value;

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
                return _NavigationLoopMode;
            }
            set
            {
                if (_NavigationLoopMode != value)
                {
                    _NavigationLoopMode = value;

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
                return _SelectedDates;
            }
            set
            {
                if (_SelectedDates != value)
                {
                    var OldValue = _SelectedDates;
                    _SelectedDates = value;

                    OnSelectedDatesChanged(OldValue, _SelectedDates);
                    OnPropertyChanged(nameof(SelectedDates));
                }
            }
        }
        public ObservableRangeCollection<DayOfWeek> CustomDayNamesOrder
        {
            get
            {
                return _CustomDayNamesOrder;
            }
            set
            {
                if (_CustomDayNamesOrder != value)
                {
                    var OldValue = _CustomDayNamesOrder;
                    _CustomDayNamesOrder = value;

                    OnCustomDayNamesOrderChanged(OldValue, _CustomDayNamesOrder);
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
                return _Rows;
            }
            set
            {
                if (_Rows != value)
                {
                    var OldValue = _Rows;
                    _Rows = value;

                    OnRowsChanged(OldValue, _Rows);
                    OnPropertyChanged(nameof(Rows));
                }
            }
        }
        /// <summary>
        /// The amount that the source date will change when navigating using <see cref="NavigateCalendar(int)"/>.
        /// </summary>
        public NavigationTimeUnit NavigationTimeUnit
        {
            get
            {
                return _NavigationTimeUnit;
            }
            set
            {
                if (_NavigationTimeUnit != value)
                {
                    _NavigationTimeUnit = value;

                    OnPropertyChanged(nameof(NavigationTimeUnit));
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
                return _PageStartMode;
            }
            set
            {
                if (_PageStartMode != value)
                {
                    var OldValue = _PageStartMode;
                    _PageStartMode = value;

                    OnPageStartModeChanged(OldValue, _PageStartMode);
                    OnPropertyChanged(nameof(PageStartMode));
                }
            }
        }
        /// <summary>
        /// The order to display the days of the week in.
        /// </summary>
        public ReadOnlyObservableCollection<DayOfWeek> DayNamesOrder
        {
            get
            {
                return _DayNamesOrder;
            }
            protected set
            {
                if (_DayNamesOrder != value)
                {
                    var OldValue = _DayNamesOrder;
                    _DayNamesOrder = value;

                    OnDayNamesOrderChanged(OldValue, _DayNamesOrder);
                    OnPropertyChanged(nameof(DayNamesOrder));
                }
            }
        }
        public int ForwardsNavigationAmount
        {
            get
            {
                return _ForwardsNavigationAmount;
            }
            set
            {
                if (_ForwardsNavigationAmount != value)
                {
                    _ForwardsNavigationAmount = value;

                    OnPropertyChanged(nameof(ForwardsNavigationAmount));
                }
            }
        }
        public int BackwardsNavigationAmount
        {
            get
            {
                return _BackwardsNavigationAmount;
            }
            set
            {
                if (_BackwardsNavigationAmount != value)
                {
                    _BackwardsNavigationAmount = value;

                    OnPropertyChanged(nameof(BackwardsNavigationAmount));
                }
            }
        }
        public DateTime? RangeSelectionStart
        {
            get
            {
                return _RangeSelectionStart;
            }
            set
            {
                if (_RangeSelectionStart != value)
                {
                    var OldValue = _RangeSelectionStart;
                    _RangeSelectionStart = value;

                    OnRangeSelectionStartChanged(OldValue, _RangeSelectionStart);
                    OnPropertyChanged(nameof(RangeSelectionStart));
                }
            }
        }
        public DateTime? RangeSelectionEnd
        {
            get
            {
                return _RangeSelectionEnd;
            }
            set
            {
                if (_RangeSelectionEnd != value)
                {
                    var OldValue = _RangeSelectionEnd;
                    _RangeSelectionEnd = value;

                    OnRangeSelectionEndChanged(OldValue, _RangeSelectionEnd);
                    OnPropertyChanged(nameof(RangeSelectionEnd));
                }
            }
        }
        public SelectionType SelectionType
        {
            get
            {
                return _SelectionType;
            }
            set
            {
                if (_SelectionType != value)
                {
                    _SelectionType = value;

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
            DayNamesOrder = new ReadOnlyObservableCollection<DayOfWeek>(new ObservableRangeCollection<DayOfWeek>(StartOfWeek.GetWeekAsFirst()));
            SelectedDates.CollectionChanged += SelectedDates_CollectionChanged;

            UpdateDays(NavigatedDate);
        }
        #endregion

        #region Methods
        /// <remarks>
        /// Called when <see cref="SelectedDates"/> changes.
        /// </remarks>
        protected virtual void OnDateSelectionChanged(IList<DateTime> OldSelection, IList<DateTime> NewSelection)
        {
            DateSelectionChanged?.Invoke(this, new DateSelectionChangedEventArgs(OldSelection, NewSelection));
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
        /// <param name="DateTime">The <see cref="DateTime"/> to select/unselect.</param>
        public virtual void ChangeDateSelection(DateTime DateTime)
        {
            switch (SelectionType)
            {
                case SelectionType.None:
                    break;

                case SelectionType.Single:
                    switch (SelectionAction)
                    {
                        case SelectionAction.Add:
                            if (!SelectedDates.Any(x => x.Date == DateTime.Date))
                            {
                                SelectedDates.Add(DateTime.Date);
                            }
                            break;

                        case SelectionAction.Remove:
                            if (SelectedDates.Any(x => x.Date == DateTime.Date))
                            {
                                SelectedDates.Remove(DateTime.Date);
                            }
                            break;

                        case SelectionAction.Modify:
                            if (SelectedDates.Any(x => x.Date == DateTime.Date))
                            {
                                SelectedDates.Remove(DateTime.Date);
                            }
                            else
                            {
                                SelectedDates.Add(DateTime.Date);
                            }
                            break;

                        case SelectionAction.Replace:
                            if (SelectedDates.Count != 1 || (SelectedDates.Count == 1 && SelectedDates.First().Date != DateTime.Date))
                            {
                                SelectedDates.Replace(DateTime.Date);
                            }
                            break;

                        default:
                            throw new NotImplementedException();
                    }
                    break;

                case SelectionType.Range:
                    if (RangeSelectionStart == null)
                    {
                        RangeSelectionStart = DateTime;
                    }
                    else if (DateTime == RangeSelectionStart)
                    {
                        RangeSelectionStart = null;
                    }
                    else if (DateTime != RangeSelectionStart)
                    {
                        RangeSelectionEnd = DateTime;
                    }
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
        /// <summary>
        ///  Performs selection on a range of dates as defined by <see cref="RangeSelectionStart"/> and <see cref="RangeSelectionEnd"/> depending on the current <see cref="SelectionType"/>.
        /// </summary>
        public virtual void CommitRangeSelection()
        {
            if (RangeSelectionStart == null || RangeSelectionEnd == null) { throw new InvalidOperationException($"{nameof(RangeSelectionStart)} and {nameof(RangeSelectionEnd)} must not be null."); }

            List<DateTime> DateRange = RangeSelectionStart.Value.GetDatesBetween(RangeSelectionEnd.Value);
            IEnumerable<DateTime> DatesToAdd = DateRange.Where(x => !SelectedDates.Contains(x.Date));
            IEnumerable<DateTime> DatesToRemove = DateRange.Where(x => SelectedDates.Contains(x.Date));

            switch (SelectionAction)
            {
                case SelectionAction.Add:
                    if (DatesToAdd.Count() != 0)
                    {
                        SelectedDates.AddRange(DatesToAdd);
                    }
                    break;

                case SelectionAction.Remove:
                    if (DatesToRemove.Count() != 0)
                    {
                        SelectedDates.RemoveRange(DatesToRemove);
                    }
                    break;

                case SelectionAction.Modify:
                    if (DatesToAdd.Count() != 0 || DatesToRemove.Count() != 0)
                    {
                        List<DateTime> NewSelectedDates = SelectedDates.Where(x => !DatesToRemove.Contains(x.Date)).ToList();
                        NewSelectedDates.AddRange(DatesToAdd);
                        SelectedDates.ReplaceRange(NewSelectedDates);
                    }
                    break;

                case SelectionAction.Replace:
                    if (SelectedDates.SequenceEqual(DateRange))
                    {
                        SelectedDates.Clear();
                    }
                    else
                    {
                        SelectedDates.ReplaceRange(DateRange);
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
        /// <param name="DateTime">The <see cref="DateTime"/> representing the month to get the number of rows for.</param>
        /// <param name="IsConsistent">Whether the return value should be the highest possible value occuring in the year or not.</param>
        /// <param name="StartOfWeek">The start of the week.</param>
        /// <returns></returns>
        public int GetMonthRows(DateTime DateTime, bool IsConsistent, DayOfWeek StartOfWeek)
        {
            if (IsConsistent)
            {
                return DateTime.CalendarHighestMonthWeekCountOfYear(StartOfWeek);
            }
            else
            {
                return DateTime.CalendarWeeksInMonth(StartOfWeek);
            }
        }
        public virtual bool IsDateTimeCurrentMonth(DateTime DateTime)
        {
            return DateTime.Month == NavigatedDate.Month && DateTime.Year == NavigatedDate.Year;
        }
        public virtual bool IsDateTimeToday(DateTime DateTime)
        {
            return DateTime.Date == TodayDate.Date;
        }
        public virtual bool IsDateTimeSelected(DateTime DateTime)
        {
            return SelectedDates.Any(x => x.Date == DateTime.Date) == true;
        }
        public virtual bool IsDateTimeInvalid(DateTime DateTime)
        {
            return DateTime.Date < NavigationLowerBound.Date || DateTime.Date > NavigationUpperBound.Date;
        }
        public virtual void UpdateDay(T Day, DateTime NewDateTime)
        {
            Day.DateTime = NewDateTime;
            Day.IsCurrentMonth = IsDateTimeCurrentMonth(Day.DateTime);
            Day.IsToday = IsDateTimeToday(Day.DateTime);
            Day.IsSelected = IsDateTimeSelected(Day.DateTime);
            Day.IsInvalid = IsDateTimeInvalid(Day.DateTime);
        }
        /// <summary>
        /// Updates the dates displayed on the calendar.
        /// </summary>
        /// <param name="NavigationDate">The <see cref="DateTime"/> who's month will be used to update the dates.</param>
        public void UpdateDays(DateTime NavigationDate)
        {
            OnDaysUpdating();

            List<DayOfWeek> DayNamesOrderList = DayNamesOrder.ToList();
            int DatesUpdated = 0;
            int RowsRequiredToNavigate = AutoRows ? GetMonthRows(NavigationDate, AutoRowsIsConsistent, StartOfWeek) : Rows;
            int DaysRequiredToNavigate = RowsRequiredToNavigate * DayNamesOrderList.Count;

            //Determine the starting date of the page.
            DateTime PageStartDate;
            switch (PageStartMode)
            {
                case PageStartMode.FirstDayOfWeek:
                    PageStartDate = NavigationDate.FirstDayOfWeek(StartOfWeek);
                    break;
                case PageStartMode.FirstDayOfMonth:
                    PageStartDate = NavigationDate.FirstDayOfMonth().FirstDayOfWeek(StartOfWeek);
                    break;
                case PageStartMode.FirstDayOfYear:
                    PageStartDate = new DateTime(NavigatedDate.Year, 1, 1).FirstDayOfWeek(StartOfWeek);
                    break;
                default:
                    throw new NotImplementedException($"{nameof(Enums.PageStartMode)} '{PageStartMode}' has not been implemented.");
            }

            //Update the dates for each row.
            for (int RowsAdded = 0; DatesUpdated < DaysRequiredToNavigate; RowsAdded++)
            {
                Dictionary<DayOfWeek, DateTime> Row = new Dictionary<DayOfWeek, DateTime>();

                //Get the updated dates for the row.
                for (int i = 0; i < DaysOfWeek.Count; i++)
                {
                    try
                    {
                        DateTime DateTime = PageStartDate.AddDays(RowsAdded * DaysOfWeek.Count + i);
                        Row.Add(DateTime.DayOfWeek, DateTime);
                    }
                    catch (ArgumentOutOfRangeException Ex) when (Ex.TargetSite.DeclaringType == typeof(DateTime))
                    {
                    }
                }

                //Update or create days for the row based on the DayNamesOrder.
                for (int i = 0; i < DayNamesOrderList.Count; i++)
                {

                    //Handle the case that a week spans into an unrepresentable DateTime. E.g After DateTime.MaxValue.
                    if (!Row.TryGetValue(DayNamesOrderList[i], out DateTime NewDateTime))
                    {
                        NewDateTime = DateTime.MaxValue;
                    }

                    if (Days.Count <= DatesUpdated)
                    {
                        T Day = new T();
                        UpdateDay(Day, NewDateTime);
                        _Days.Add(Day);
                    }
                    else
                    {
                        UpdateDay(Days[DatesUpdated], NewDateTime);
                    }

                    DatesUpdated += 1;
                }
            }

            //Remove any extra CalendarDays
            while (Days.Count > DaysRequiredToNavigate)
            {
                _Days.RemoveAt(Days.Count - 1);
            }

            OnDaysUpdated();
        }
        /// <summary>
        /// Navigates the date at which the time unit is extracted.
        /// </summary>
        /// <exception cref="NotImplementedException">The current <see cref="PageStartMode"/> is not implemented</exception>
        public virtual void NavigateCalendar(int Amount)
        {
            NavigatedDate = NavigateDateTime(NavigatedDate, NavigationLowerBound, NavigationUpperBound, Amount, NavigationLoopMode, NavigationTimeUnit, StartOfWeek);
        }
        /// <summary>
        /// Performs navigation on a DateTime.
        /// </summary>
        /// <param name="DateTime">The <see cref="DateTime"/> that will be the source of the navigation.</param>
        /// <param name="MinimumDate">The lower bound of the range of dates. Inclusive.</param>
        /// <param name="MaximumDate">The upper bound of the range of dates. Inclusive.</param>
        /// <param name="Amount">The amount of the <paramref name="NavigationTimeUnit"/> to navigate.</param>
        /// <param name="NavigationLoopMode">What to do when the result of navigation is outside the range of the <paramref name="MinimumDate"/> and <paramref name="MaximumDate"/>.</param>
        /// <param name="NavigationTimeUnit">The time unit to navigate the <paramref name="DateTime"/> by.</param>
        /// <param name="StartOfWeek">The start of the week.</param>
        /// <returns>The <see cref="DateTime"/> resulting from the navigation.</returns>
        /// <exception cref="NotImplementedException">The <see cref="NavigationTimeUnit"/> is not implemented.</exception>
        public DateTime NavigateDateTime(DateTime DateTime, DateTime MinimumDate, DateTime MaximumDate, int Amount, NavigationLoopMode NavigationLoopMode, NavigationTimeUnit NavigationTimeUnit, DayOfWeek StartOfWeek)
        {
            bool LowerThanMinimumDate;
            bool HigherThanMaximumDate;

            DateTime NewNavigatedDate;

            try
            {
                switch (NavigationTimeUnit)
                {
                    case NavigationTimeUnit.Day:
                        NewNavigatedDate = DateTime.AddDays(Amount);
                        break;

                    case NavigationTimeUnit.Week:
                        NewNavigatedDate = DateTime.AddWeeks(Amount);
                        break;

                    case NavigationTimeUnit.Month:
                        NewNavigatedDate = DateTime.AddMonths(Amount);
                        break;

                    case NavigationTimeUnit.Year:
                        NewNavigatedDate = DateTime.AddYears(Amount);
                        break;

                    default:
                        throw new NotImplementedException($"{nameof(Enums.NavigationTimeUnit)} '{NavigationTimeUnit}' is not implemented.");
                }

                LowerThanMinimumDate = NewNavigatedDate.Date < MinimumDate.Date;
                HigherThanMaximumDate = NewNavigatedDate.Date > MaximumDate.Date;
            }
            catch (ArgumentOutOfRangeException Ex) when (Ex.TargetSite.DeclaringType == typeof(DateTime))
            {
                NewNavigatedDate = Amount > 0 ? MaximumDate : MinimumDate;
                LowerThanMinimumDate = Amount < 0;
                HigherThanMaximumDate = Amount > 0;
            }

            if (LowerThanMinimumDate && NavigationLoopMode.HasFlag(NavigationLoopMode.LoopMinimum))
            {
                NewNavigatedDate = MaximumDate;
                //The code below makes sure that the correct amount of weeks are added after looping.
                //However this is not possible when setting the NavigatedDate directly, so it is commented out for the sake of consistency.

                ////The difference in weeks must be made consistent because NavigatedDate could be any value within the week.
                ////The minimum date may not always have the first day of week so the last day of week is used to do this.
                //TimeSpan Difference = DateTime.LastDayOfWeek(StartOfWeek) - MinimumDate.LastDayOfWeek(StartOfWeek);

                //int WeeksUntilMinValue = (int)Math.Ceiling(Difference.TotalDays / 7);
                //DateTime NewNavigatedDate = NavigateDateTime(MinimumDate, MinimumDate, MaximumDate, Amount + WeeksUntilMinValue, NavigationLoopMode, StartOfWeek);


                ////Preserve the original time.
                //return new DateTime(NewNavigatedDate.Year, NewNavigatedDate.Month, NewNavigatedDate.Day, DateTime.Hour, DateTime.Minute, DateTime.Second, DateTime.Millisecond);
            }
            else if (HigherThanMaximumDate && NavigationLoopMode.HasFlag(NavigationLoopMode.LoopMaximum))
            {
                NewNavigatedDate = MinimumDate;
                //The code below makes sure that the correct amount of weeks are added after looping.
                //However this is not possible when setting the NavigatedDate directly, so it is commented out for the sake of consistency.

                ////The difference in weeks must be made consistent because NavigatedDate could be any value within the week.
                ////The maximum date may not always have the last day of week so the first day of week is used to do this.
                //TimeSpan Difference = MaximumDate.FirstDayOfWeek(StartOfWeek) - DateTime.FirstDayOfWeek(StartOfWeek);

                //int WeeksUntilMaxValue = (int)Math.Ceiling(Difference.TotalDays / 7);
                //DateTime NewNavigatedDate = NavigateDateTime(MinimumDate, MinimumDate, MaximumDate, Amount - WeeksUntilMaxValue, NavigationLoopMode, StartOfWeek);

                ////Preserve the original time.
                //return new DateTime(NewNavigatedDate.Year, NewNavigatedDate.Month, NewNavigatedDate.Day, DateTime.Hour, DateTime.Minute, DateTime.Second, DateTime.Millisecond);
            }

            return NewNavigatedDate;
        }
        /// <summary>
        /// Raises an event signaling that the days' properties need to be reevaluated due to changes in the <see cref="CalendarView"/>
        /// </summary>
        private void SelectedDates_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateDays(NavigatedDate);

            OnDateSelectionChanged(_PreviousSelectedDates, SelectedDates);

            _PreviousSelectedDates.Clear();
            _PreviousSelectedDates.AddRange(SelectedDates.ToList());
        }
        private void DayNamesOrder_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateDays(NavigatedDate);
        }
        private void OnRowsChanged(int oldValue, int newValue)
        {
            int CoercedRows = CoerceRows(Rows);

            if (CoercedRows < 1) { throw new ArgumentException(nameof(newValue)); }

            if (Rows != CoercedRows)
            {
                Rows = CoercedRows;
            }
            else
            {
                UpdateDays(NavigatedDate);
            }
        }
        private void OnNavigatedDateChanged(DateTime oldValue, DateTime newValue)
        {
            NavigatedDate = CoerceNavigatedDate(newValue);

            int CoercedRows = CoerceRows(Rows);

            if (Rows != CoercedRows)
            {
                Rows = CoercedRows;
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
                DayNamesOrder = new ReadOnlyObservableCollection<DayOfWeek>(new ObservableCollection<DayOfWeek>(StartOfWeek.GetWeekAsFirst()));
            }
            else
            {
                UpdateDays(NavigatedDate);
            }
        }
        private void OnNavigationLowerBoundChanged(DateTime oldValue, DateTime newValue)
        {
            NavigatedDate = CoerceNavigatedDate(NavigatedDate);
        }
        private void OnNavigationUpperBoundChanged(DateTime oldValue, DateTime newValue)
        {
            NavigatedDate = CoerceNavigatedDate(NavigatedDate);
        }
        private void OnSelectedDatesChanged(ObservableRangeCollection<DateTime> oldValue, ObservableRangeCollection<DateTime> newValue)
        {
            if (newValue == null) { throw new ArgumentException(nameof(newValue)); }

            if (oldValue != null) { oldValue.CollectionChanged -= SelectedDates_CollectionChanged; }
            if (newValue != null) { newValue.CollectionChanged += SelectedDates_CollectionChanged; }

            _PreviousSelectedDates.Clear();
            _PreviousSelectedDates.AddRange(oldValue);

            if (oldValue == null || !oldValue.SequenceEqual(newValue))
            {
                UpdateDays(NavigatedDate);
                OnDateSelectionChanged(_PreviousSelectedDates, newValue);
            }
        }
        private void OnCustomDayNamesOrderChanged(ObservableRangeCollection<DayOfWeek> oldValue, ObservableRangeCollection<DayOfWeek> newValue)
        {
            if (newValue == null)
            {
                DayNamesOrder = new ReadOnlyObservableCollection<DayOfWeek>(new ObservableCollection<DayOfWeek>(StartOfWeek.GetWeekAsFirst()));
            }
            else
            {
                DayNamesOrder = new ReadOnlyObservableCollection<DayOfWeek>(newValue);
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
        private void OnDayNamesOrderChanged(ReadOnlyObservableCollection<DayOfWeek> oldValue, ReadOnlyObservableCollection<DayOfWeek> newValue)
        {
            if (newValue == null || newValue.Count == 0) { throw new ArgumentException(nameof(newValue)); }

            if (oldValue != null) { ((INotifyCollectionChanged)oldValue).CollectionChanged -= DayNamesOrder_CollectionChanged; }
            if (newValue != null) { ((INotifyCollectionChanged)newValue).CollectionChanged += DayNamesOrder_CollectionChanged; }

            if (oldValue == null || !oldValue.SequenceEqual(newValue))
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
            DateTime MinimumDate = NavigationLowerBound;
            DateTime MaximumDate = NavigationUpperBound;

            switch (NavigationLoopMode)
            {
                case NavigationLoopMode.DontLoop:
                    if (value.Date < MinimumDate.Date) { return MinimumDate; }
                    if (value.Date > MaximumDate.Date) { return MaximumDate; }
                    break;
                case NavigationLoopMode.LoopMinimum:
                    if (value.Date < MinimumDate.Date) { return MaximumDate; }
                    if (value.Date > MaximumDate.Date) { return MaximumDate; }
                    break;

                case NavigationLoopMode.LoopMaximum:
                    if (value.Date < MinimumDate.Date) { return MinimumDate; }
                    if (value.Date > MaximumDate.Date) { return MinimumDate; }
                    break;

                case NavigationLoopMode.LoopMinimumAndMaximum:
                    if (value.Date < MinimumDate.Date) { return MaximumDate; }
                    if (value.Date > MaximumDate.Date) { return MinimumDate; }
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
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion
    }
}