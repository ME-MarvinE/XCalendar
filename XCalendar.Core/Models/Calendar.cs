using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using XCalendar.Core.Enums;
using XCalendar.Core.Extensions;
using XCalendar.Core.Interfaces;

namespace XCalendar.Core.Models
{
    public class Calendar : Calendar<CalendarDay>
    {
    }
    public class Calendar<T> : BaseObservableModel, ICalendar<T> where T : ICalendarDay, new()
    {
        #region Fields
        protected static readonly ReadOnlyCollection<DayOfWeek> DaysOfWeek = DayOfWeekExtensions.DaysOfWeek;
        private readonly ObservableCollection<T> _Days = new ObservableCollection<T>();
        private readonly List<DateTime> _PreviousSelectedDates = new List<DateTime>();
        private readonly ObservableRangeCollection<DayOfWeek> _StartOfWeekDayNamesOrder = new ObservableRangeCollection<DayOfWeek>();
        #endregion

        #region Properties
        /// <summary>
        /// The list of displayed days.
        /// </summary>
        public ReadOnlyObservableCollection<T> Days { get; protected set; }
        /// <summary>
        /// The date the calendar will use to get the dates representing a time unit.
        /// </summary>
        [OnChangedMethod(nameof(OnNavigatedDateChanged))]
        public DateTime NavigatedDate { get; set; } = DateTime.Today;
        /// <summary>
        /// The date that the calendar should consider as 'Today'.
        /// </summary>
        [OnChangedMethod(nameof(OnTodayDateChanged))]
        public DateTime TodayDate { get; set; } = DateTime.Today;
        /// <summary>
        /// The lower bound of the day range.
        /// </summary>
        /// <seealso cref="NavigationLoopMode"/>
        [OnChangedMethod(nameof(OnNavigationLowerBoundChanged))]
        public DateTime NavigationLowerBound { get; set; } = DateTime.MinValue;
        /// <summary>
        /// The upper bound of the day range.
        /// </summary>
        /// <seealso cref="NavigationLoopMode"/>
        [OnChangedMethod(nameof(OnNavigationUpperBoundChanged))]
        public DateTime NavigationUpperBound { get; set; } = DateTime.MaxValue;
        /// <summary>
        /// The day of week that should be considered as the start of the week.
        /// </summary>
        /// <seealso cref="CustomDayNamesOrder"/>
        [OnChangedMethod(nameof(OnStartOfWeekChanged))]
        public DayOfWeek StartOfWeek { get; set; } = CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek;
        /// <summary>
        /// Whether to automatically add as many rows as needed to represent the time unit or not.
        /// </summary>
        /// <seealso cref="AutoRowsIsConsistent"/>
        [OnChangedMethod(nameof(OnAutoRowsChanged))]
        public bool AutoRows { get; set; } = true;
        /// <summary>
        /// Whether to make sure the amount of rows stays the same across the time unit.
        /// </summary>
        /// <example>If the <see cref="StartOfWeek"/> is Monday, the highest number of rows needed to display a month in 2022 is 6 rows (May, October etc).
        /// If this property is true, the calendar will display 6 rows regardless of whether a month needs less or not (April, November etc).
        /// Otherwise it will display as needed: (5 for April and November, 6 for May and October etc).</example>
        /// <seealso cref="AutoRows"/>
        [OnChangedMethod(nameof(OnAutoRowsIsConsistentChanged))]
        public bool AutoRowsIsConsistent { get; set; } = true;
        /// <summary>
        /// Whether to use <see cref="CustomDayNamesOrder"/> for displaying the page or not.
        /// </summary>
        [OnChangedMethod(nameof(OnUseCustomDayNamesOrderChanged))]
        public bool UseCustomDayNamesOrder { get; set; }
        /// <summary>
        /// The type of selection to use for selecting dates.
        /// </summary>
        public SelectionAction SelectionAction { get; set; } = SelectionAction.Modify;
        /// <summary>
        /// How the calendar handles navigation past the <see cref="DateTime.MinValue"/>, <see cref="DateTime.MaxValue"/>, <see cref="NavigationLowerBound"/>, and <see cref="NavigationUpperBound"/>.
        /// </summary>
        /// <seealso cref="NavigateCalendar(int)"/>
        public NavigationLoopMode NavigationLoopMode { get; set; } = NavigationLoopMode.LoopMinimumAndMaximum;
        /// <summary>
        /// The dates that are currently selected.
        /// </summary>
        [OnChangedMethod(nameof(OnSelectedDatesChanged))]
        public ObservableRangeCollection<DateTime> SelectedDates { get; set; } = new ObservableRangeCollection<DateTime>();
        /// <summary>
        /// The order to display the days of the week in when <see cref="UseCustomDayNamesOrder"/> is set to true.
        /// </summary>
        /// <remarks>Does not affect logic.</remarks>
        /// <seealso cref="UseCustomDayNamesOrder"/>
        [OnChangedMethod(nameof(OnCustomDayNamesOrderChanged))]
        public ObservableRangeCollection<DayOfWeek> CustomDayNamesOrder { get; set; } = new ObservableRangeCollection<DayOfWeek>(DaysOfWeek);
        /// <summary>
        /// The number of rows to display.
        /// </summary>
        /// <seealso cref="AutoRows"/>
        [OnChangedMethod(nameof(OnRowsChanged))]
        public int Rows { get; set; } = 6;
        /// <summary>
        /// The amount that the source date will change when navigating using <see cref="NavigateCalendar(int)"/>.
        /// </summary>
        public NavigationTimeUnit NavigationTimeUnit { get; set; } = NavigationTimeUnit.Month;
        /// <summary>
        /// The way in which to extract a date from the <see cref="NavigatedDate"/> to use as the first date of the first row.
        /// </summary>
        /// <example>If the <see cref="StartOfWeek"/> is Monday and the navigated date is 15th July 2022:
        /// <see cref="PageStartMode.FirstDayOfWeek"/> will extract 11th July 2022.
        /// <see cref="PageStartMode.FirstDayOfMonth"/> will extract 27th June 2022 (First day in the week of 1st July 2022).
        /// <see cref="PageStartMode.FirstDayOfYear"/> will extract 27th December 2021 (First day in the week of 1st January 2022).</example>
        [OnChangedMethod(nameof(OnPageStartModeChanged))]
        public PageStartMode PageStartMode { get; set; } = PageStartMode.FirstDayOfMonth;
        /// <summary>
        /// The order to display the days of the week in.
        /// </summary>
        [OnChangedMethod(nameof(OnDayNamesOrderChanged))]
        public ReadOnlyObservableCollection<DayOfWeek> DayNamesOrder { get; protected set; }
        [OnChangedMethod(nameof(OnStartOfWeekDayNamesOrderChanged))]
        public ReadOnlyObservableCollection<DayOfWeek> StartOfWeekDayNamesOrder { get; protected set; }
        public int ForwardsNavigationAmount { get; set; } = 1;
        public int BackwardsNavigationAmount { get; set; } = -1;
        [OnChangedMethod(nameof(OnRangeSelectionStartChanged))]
        public DateTime? RangeSelectionStart { get; set; }
        [OnChangedMethod(nameof(OnRangeSelectionEndChanged))]
        public DateTime? RangeSelectionEnd { get; set; }
        public SelectionType SelectionType { get; set; } = SelectionType.None;
        #endregion

        #region Events
        public event EventHandler<DateSelectionChangedEventArgs> DateSelectionChanged;
        public event EventHandler DaysUpdated;
        public event EventHandler DaysUpdating;
        #endregion

        #region Constructors
        public Calendar()
        {
            _StartOfWeekDayNamesOrder.AddRange(StartOfWeek.GetWeekAsFirst());

            Days = new ReadOnlyObservableCollection<T>(_Days);
            StartOfWeekDayNamesOrder = new ReadOnlyObservableCollection<DayOfWeek>(_StartOfWeekDayNamesOrder);
            DayNamesOrder = new ReadOnlyObservableCollection<DayOfWeek>(_StartOfWeekDayNamesOrder);
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

            if (Rows == CoercedRows)
            {
                UpdateDays(NavigatedDate);
            }
            else
            {
                Rows = CoercedRows;
            }
        }
        private void OnTodayDateChanged(DateTime oldValue, DateTime newValue)
        {
            UpdateDays(NavigatedDate);
        }
        private void OnStartOfWeekChanged(DayOfWeek oldValue, DayOfWeek newValue)
        {
            List<DayOfWeek> CorrectStartOfWeekDayNamesOrder = newValue.GetWeekAsFirst();
            bool UpdateStartOfWeekDayNamesOrder = !_StartOfWeekDayNamesOrder.SequenceEqual(CorrectStartOfWeekDayNamesOrder);

            if (UpdateStartOfWeekDayNamesOrder)
            {
                _StartOfWeekDayNamesOrder.ReplaceRange(CorrectStartOfWeekDayNamesOrder);
            }
            //If the dates haven't been updated and invalidated, do so.
            if (!UpdateStartOfWeekDayNamesOrder || UseCustomDayNamesOrder)
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
        private void OnStartOfWeekDayNamesOrderChanged(ReadOnlyObservableCollection<DayOfWeek> oldValue, ReadOnlyObservableCollection<DayOfWeek> newValue)
        {
            if (newValue == null || newValue.Count == 0) { throw new ArgumentException(nameof(newValue)); }
        }
        private void OnCustomDayNamesOrderChanged(ObservableRangeCollection<DayOfWeek> oldValue, ObservableRangeCollection<DayOfWeek> newValue)
        {
            if (UseCustomDayNamesOrder)
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
        private void OnUseCustomDayNamesOrderChanged(bool oldValue, bool newValue)
        {
            ObservableRangeCollection<DayOfWeek> CorrectDayNamesOrder = newValue ? CustomDayNamesOrder : _StartOfWeekDayNamesOrder;

            DayNamesOrder = new ReadOnlyObservableCollection<DayOfWeek>(CorrectDayNamesOrder);
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
        #endregion
    }
}