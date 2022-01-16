using XCalendar.Extensions;
using XCalendar.Enums;
using XCalendar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XCalendar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarView : ContentView
    {
        #region Fields
        protected readonly List<DayOfWeek> DaysOfWeek = new List<DayOfWeek>()
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday,
        };
        /// <summary>
        /// The list of displayed dates.
        /// </summary>
        protected ObservableCollection<CalendarDay> _Days = new ObservableCollection<CalendarDay>();
        #endregion

        #region Properties
        public ReadOnlyObservableCollection<CalendarDay> Days { get; }

        #region Bindable Properties
        /// <summary>
        /// The date the calendar will use to get the dates representing a time unit.
        /// </summary>
        public DateTime NavigatedDate
        {
            get { return (DateTime)GetValue(NavigatedDateProperty); }
            set { SetValue(NavigatedDateProperty, value); }
        }
        /// <summary>
        /// The date that the calendar should consider as 'Today'.
        /// </summary>
        public DateTime TodayDate
        {
            get { return (DateTime)GetValue(TodayDateProperty); }
            set { SetValue(TodayDateProperty, value); }
        }
        /// <summary>
        /// The lower bound of the day range.
        /// </summary>
        /// <seealso cref="NavigationLimitMode"/>
        public DateTime DayRangeMinimumDate
        {
            get { return (DateTime)GetValue(DayRangeMinimumDateProperty); }
            set { SetValue(DayRangeMinimumDateProperty, value); }
        }
        /// <summary>
        /// The upper bound of the day range.
        /// </summary>
        /// <seealso cref="NavigationLimitMode"/>
        public DateTime DayRangeMaximumDate
        {
            get { return (DateTime)GetValue(DayRangeMaximumDateProperty); }
            set { SetValue(DayRangeMaximumDateProperty, value); }
        }
        /// <summary>
        /// The day of week that should be considered as the start of the week.
        /// </summary>
        /// <seealso cref="DayNamesOrder"/>
        public DayOfWeek StartOfWeek
        {
            get { return (DayOfWeek)GetValue(StartOfWeekProperty); }
            set { SetValue(StartOfWeekProperty, value); }
        }
        /// <summary>
        /// The individual height of the displayed <see cref="Days"/>.
        /// </summary>
        public double DayHeightRequest
        {
            get { return (double)GetValue(DayHeightRequestProperty); }
            set { SetValue(DayHeightRequestProperty, value); }
        }
        public Color DayCurrentMonthTextColor
        {
            get { return (Color)GetValue(DayCurrentMonthTextColorProperty); }
            set { SetValue(DayCurrentMonthTextColorProperty, value); }
        }
        public Color DayTodayTextColor
        {
            get { return (Color)GetValue(DayTodayTextColorProperty); }
            set { SetValue(DayTodayTextColorProperty, value); }
        }
        public Color DayOtherMonthTextColor
        {
            get { return (Color)GetValue(DayOtherMonthTextColorProperty); }
            set { SetValue(DayOtherMonthTextColorProperty, value); }
        }
        public Color DayOutOfRangeTextColor
        {
            get { return (Color)GetValue(DayOutOfRangeTextColorProperty); }
            set { SetValue(DayOutOfRangeTextColorProperty, value); }
        }
        public Color DaySelectedTextColor
        {
            get { return (Color)GetValue(DaySelectedTextColorProperty); }
            set { SetValue(DaySelectedTextColorProperty, value); }
        }
        public ControlTemplate DayNamesTemplate
        {
            get { return (ControlTemplate)GetValue(DayNamesTemplateProperty); }
            set { SetValue(DayNamesTemplateProperty, value); }
        }
        /// <summary>
        /// The height of the view showing the days of the week.
        /// </summary>
        public double DayNamesHeightRequest
        {
            get { return (double)GetValue(DayNamesHeightRequestProperty); }
            set { SetValue(DayNamesHeightRequestProperty, value); }
        }
        /// <summary>
        /// The template used to display the days of the week.
        /// </summary>
        public DataTemplate DayNameTemplate
        {
            get { return (DataTemplate)GetValue(DayNameTemplateProperty); }
            set { SetValue(DayNameTemplateProperty, value); }
        }
        public double DayNameVerticalSpacing
        {
            get { return (double)GetValue(DayNameVerticalSpacingProperty); }
            set { SetValue(DayNameVerticalSpacingProperty, value); }
        }
        public double DayNameHorizontalSpacing
        {
            get { return (double)GetValue(DayNameHorizontalSpacingProperty); }
            set { SetValue(DayNameHorizontalSpacingProperty, value); }
        }
        public Color DayNameTextColor
        {
            get { return (Color)GetValue(DayNameTextColorProperty); }
            set { SetValue(DayNameTextColorProperty, value); }
        }
        /// <summary>
        /// The template used to display the <see cref="Days"/>.
        /// </summary>
        public ControlTemplate MonthViewTemplate
        {
            get { return (ControlTemplate)GetValue(MonthViewTemplateProperty); }
            set { SetValue(MonthViewTemplateProperty, value); }
        }
        /// <summary>
        /// The height of the view used to display the <see cref="Days"/>
        /// </summary>
        public double MonthViewHeightRequest
        {
            get { return (double)GetValue(MonthViewHeightRequestProperty); }
            set { SetValue(MonthViewHeightRequestProperty, value); }
        }
        /// <summary>
        /// Whether to automatically add as many rows as needed to represent the time unit or not.
        /// </summary>
        /// <seealso cref="AutoRowsIsConsistent"/>
        public bool AutoRows
        {
            get { return (bool)GetValue(AutoRowsProperty); }
            set { SetValue(AutoRowsProperty, value); }
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
            get { return (bool)GetValue(AutoRowsIsConsistentProperty); }
            set { SetValue(AutoRowsIsConsistentProperty, value); }
        }
        /// <summary>
        /// Whether to shift the values in <see cref="DayNamesOrder"/> so that the <see cref="StartOfWeek"/> is the first value.
        /// </summary>
        public bool DayNamesOrderUsesStartOfWeek
        {
            get { return (bool)GetValue(DayNamesOrderUsesStartOfWeekProperty); }
            set { SetValue(DayNamesOrderUsesStartOfWeekProperty, value); }
        }
        /// <summary>
        /// The template used to display the view for navigating the calendar.
        /// </summary>
        public ControlTemplate NavigationTemplate
        {
            get { return (ControlTemplate)GetValue(NavigationTemplateProperty); }
            set { SetValue(NavigationTemplateProperty, value); }
        }
        public Color NavigationTextColor
        {
            get { return (Color)GetValue(NavigationTextColorProperty); }
            set { SetValue(NavigationTextColorProperty, value); }
        }
        public Color NavigationArrowColor
        {
            get { return (Color)GetValue(NavigationArrowColorProperty); }
            set { SetValue(NavigationArrowColorProperty, value); }
        }
        public Color NavigationArrowBackgroundColor
        {
            get { return (Color)GetValue(NavigationArrowBackgroundColorProperty); }
            set { SetValue(NavigationArrowBackgroundColorProperty, value); }
        }
        public float NavigationArrowCornerRadius
        {
            get { return (float)GetValue(NavigationArrowCornerRadiusProperty); }
            set { SetValue(NavigationArrowCornerRadiusProperty, value); }
        }
        /// <summary>
        /// How the calendar handles selection of dates.
        /// </summary>
        public Enums.SelectionMode SelectionMode
        {
            get { return (Enums.SelectionMode)GetValue(SelectionModeProperty); }
            set { SetValue(SelectionModeProperty, value); }
        }
        /// <summary>
        /// How the calendar handles navigation past the <see cref="DateTime.MinValue"/>, <see cref="DateTime.MaxValue"/>, <see cref="DayRangeMinimumDate"/>, and <see cref="DayRangeMaximumDate"/>.
        /// </summary>
        /// <seealso cref="NavigateCalendar(bool)"/>
        public NavigationLimitMode NavigationLimitMode
        {
            get { return (NavigationLimitMode)GetValue(NavigationLimitModeProperty); }
            set { SetValue(NavigationLimitModeProperty, value); }
        }
        /// <summary>
        /// The date that is currently selected. Null when the <see cref="Enums.SelectionMode"/> is not set to <see cref="Enums.SelectionMode.Single"/>.
        /// </summary>
        public DateTime? SelectedDate
        {
            get { return (DateTime?)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }
        /// <summary>
        /// The date that is currently selected. Empty when the <see cref="Enums.SelectionMode"/> is not set to <see cref="Enums.SelectionMode.Multiple"/>.
        /// </summary>
        public ObservableCollection<DateTime> SelectedDates
        {
            get { return (ObservableCollection<DateTime>)GetValue(SelectedDatesProperty); }
            set { SetValue(SelectedDatesProperty, value); }
        }
        /// <summary>
        /// The order to display the days of the week in.
        /// </summary>
        /// <remarks>Duplicate values are allowed. Does not affect logic.</remarks>
        /// <seealso cref="DayNamesOrderUsesStartOfWeek"/>
        public ObservableRangeCollection<DayOfWeek> DayNamesOrder
        {
            get { return (ObservableRangeCollection<DayOfWeek>)GetValue(DayNamesOrderProperty); }
            set { SetValue(DayNamesOrderProperty, value); }
        }
        /// <summary>
        /// The number of rows to display.
        /// </summary>
        /// <seealso cref="AutoRows"/>
        public int Rows
        {
            get { return (int)GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }
        /// <summary>
        /// The template used to display a <see cref="CalendarDay"/>
        /// </summary>
        public DataTemplate DayTemplate
        {
            get { return (DataTemplate)GetValue(DayTemplateProperty); }
            set { SetValue(DayTemplateProperty, value); }
        }
        /// <summary>
        /// The amount that the source date will change when navigating using <see cref="NavigateCalendar(bool)"/>.
        /// </summary>
        public NavigationMode NavigationMode
        {
            get { return (NavigationMode)GetValue(NavigationModeProperty); }
            set { SetValue(NavigationModeProperty, value); }
        }
        /// <summary>
        /// The date to extract from the <see cref="NavigatedDate"/> and use as the first date of the first row.
        /// </summary>
        /// <example>If the <see cref="StartOfWeek"/> is Monday and the navigated date is 15th July 2022:
        /// <see cref="PageStartMode.NavigatedWeek"/> will extract 11th July 2022.
        /// <see cref="PageStartMode.NavigatedMonth"/> will extract 1st July 2022.
        /// <see cref="PageStartMode.NavigatedYear"/> will extract 1st January 2022.</example>
        public PageStartMode PageStartMode
        {
            get { return (PageStartMode)GetValue(PageStartModeProperty); }
            set { SetValue(PageStartModeProperty, value); }
        }

        #region Bindable Properties Initialisers
        public static readonly BindableProperty NavigatedDateProperty = BindableProperty.Create(nameof(NavigatedDate), typeof(DateTime), typeof(CalendarView), DateTime.Now, defaultBindingMode: BindingMode.TwoWay, propertyChanged: NavigatedDatePropertyChanged, coerceValue: CoerceNavigatedDate);
        public static readonly BindableProperty RowsProperty = BindableProperty.Create(nameof(Rows), typeof(int), typeof(CalendarView), 5, propertyChanged: RowsPropertyChanged, coerceValue: CoerceRows);
        public static readonly BindableProperty AutoRowsProperty = BindableProperty.Create(nameof(AutoRows), typeof(bool), typeof(CalendarView), true, propertyChanged: AutoRowsPropertyChanged);
        public static readonly BindableProperty AutoRowsIsConsistentProperty = BindableProperty.Create(nameof(AutoRowsIsConsistent), typeof(bool), typeof(CalendarView), true, propertyChanged: AutoRowsIsConsistentPropertyChanged);
        public static readonly BindableProperty DayRangeMinimumDateProperty = BindableProperty.Create(nameof(DayRangeMinimumDate), typeof(DateTime), typeof(CalendarView), DateTime.MinValue, propertyChanged: DayRangeMinimumDatePropertyChanged);
        public static readonly BindableProperty DayRangeMaximumDateProperty = BindableProperty.Create(nameof(DayRangeMaximumDate), typeof(DateTime), typeof(CalendarView), DateTime.MaxValue, propertyChanged: DayRangeMaximumDatePropertyChanged);
        public static readonly BindableProperty TodayDateProperty = BindableProperty.Create(nameof(TodayDate), typeof(DateTime), typeof(CalendarView), DateTime.Now, propertyChanged: TodayDatePropertyChanged);
        public static readonly BindableProperty StartOfWeekProperty = BindableProperty.Create(nameof(StartOfWeek), typeof(DayOfWeek), typeof(CalendarView), CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek, propertyChanged: StartOfWeekPropertyChanged);
        public static readonly BindableProperty SelectionModeProperty = BindableProperty.Create(nameof(SelectionMode), typeof(Enums.SelectionMode), typeof(CalendarView), Enums.SelectionMode.None, propertyChanged: SelectionModePropertyChanged);
        public static readonly BindableProperty SelectedDateProperty = BindableProperty.Create(nameof(SelectedDate), typeof(DateTime?), typeof(CalendarView), defaultBindingMode: BindingMode.TwoWay, propertyChanged: SelectedDatePropertyChanged, coerceValue: CoerceSelectedDate);
        public static readonly BindableProperty SelectedDatesProperty = BindableProperty.Create(nameof(SelectedDates), typeof(ObservableCollection<DateTime>), typeof(CalendarView), defaultBindingMode: BindingMode.TwoWay, propertyChanged: SelectedDatesPropertyChanged, coerceValue: CoerceSelectedDates);
        public static readonly BindableProperty DayTemplateProperty = BindableProperty.Create(nameof(DayTemplate), typeof(DataTemplate), typeof(CalendarView));
        public static readonly BindableProperty DayHeightRequestProperty = BindableProperty.Create(nameof(DayHeightRequest), typeof(double), typeof(CalendarView), 50d);
        public static readonly BindableProperty DayCurrentMonthTextColorProperty = BindableProperty.Create(nameof(DayCurrentMonthTextColor), typeof(Color), typeof(CalendarView), Color.Black);
        public static readonly BindableProperty DayTodayTextColorProperty = BindableProperty.Create(nameof(DayTodayTextColor), typeof(Color), typeof(CalendarView), Color.Green);
        public static readonly BindableProperty DayOtherMonthTextColorProperty = BindableProperty.Create(nameof(DayOtherMonthTextColor), typeof(Color), typeof(CalendarView), Color.Gray);
        public static readonly BindableProperty DayOutOfRangeTextColorProperty = BindableProperty.Create(nameof(DayOutOfRangeTextColor), typeof(Color), typeof(CalendarView), Color.Pink);
        public static readonly BindableProperty DaySelectedTextColorProperty = BindableProperty.Create(nameof(DaySelectedTextColor), typeof(Color), typeof(CalendarView), Color.Red);
        public static readonly BindableProperty DayNameTextColorProperty = BindableProperty.Create(nameof(DayNameTextColor), typeof(Color), typeof(CalendarView), Color.Black);
        public static readonly BindableProperty DayNamesOrderProperty = BindableProperty.Create(nameof(DayNamesOrder), typeof(ObservableRangeCollection<DayOfWeek>), typeof(CalendarView), defaultValueCreator: DayNamesOrderDefaultValueCreator, coerceValue: CoerceDayNamesOrder);
        public static readonly BindableProperty DayNamesOrderUsesStartOfWeekProperty = BindableProperty.Create(nameof(DayNamesOrderUsesStartOfWeek), typeof(bool), typeof(CalendarView), true, propertyChanged: DayNamesOrderUsesStartOfWeekPropertyChanged);
        public static readonly BindableProperty DayNamesTemplateProperty = BindableProperty.Create(nameof(DayNamesTemplate), typeof(ControlTemplate), typeof(CalendarView));
        public static readonly BindableProperty DayNamesHeightRequestProperty = BindableProperty.Create(nameof(DayNamesHeightRequest), typeof(double), typeof(CalendarView), 25d);
        public static readonly BindableProperty DayNameTemplateProperty = BindableProperty.Create(nameof(DayNameTemplate), typeof(DataTemplate), typeof(CalendarView));
        public static readonly BindableProperty DayNameVerticalSpacingProperty = BindableProperty.Create(nameof(DayNameVerticalSpacing), typeof(double), typeof(CalendarView));
        public static readonly BindableProperty DayNameHorizontalSpacingProperty = BindableProperty.Create(nameof(DayNameHorizontalSpacing), typeof(double), typeof(CalendarView));
        public static readonly BindableProperty MonthViewTemplateProperty = BindableProperty.Create(nameof(MonthViewTemplate), typeof(ControlTemplate), typeof(CalendarView));
        public static readonly BindableProperty MonthViewHeightRequestProperty = BindableProperty.Create(nameof(MonthViewHeightRequest), typeof(double), typeof(CalendarView), 250d);
        public static readonly BindableProperty NavigationTemplateProperty = BindableProperty.Create(nameof(NavigationTemplate), typeof(ControlTemplate), typeof(CalendarView));
        public static readonly BindableProperty NavigationTextColorProperty = BindableProperty.Create(nameof(NavigationTextColor), typeof(Color), typeof(CalendarView), Color.Black);
        public static readonly BindableProperty NavigationArrowColorProperty = BindableProperty.Create(nameof(NavigationArrowColor), typeof(Color), typeof(CalendarView), Color.Black);
        public static readonly BindableProperty NavigationArrowBackgroundColorProperty = BindableProperty.Create(nameof(NavigationArrowBackgroundColor), typeof(Color), typeof(CalendarView), Color.White);
        public static readonly BindableProperty NavigationArrowCornerRadiusProperty = BindableProperty.Create(nameof(NavigationArrowCornerRadius), typeof(float), typeof(CalendarView), 200f);
        public static readonly BindableProperty NavigationLimitModeProperty = BindableProperty.Create(nameof(NavigationLimitMode), typeof(NavigationLimitMode), typeof(CalendarView), NavigationLimitMode.LoopMinimumAndMaximum);
        public static readonly BindableProperty NavigationModeProperty = BindableProperty.Create(nameof(NavigationMode), typeof(NavigationMode), typeof(CalendarView), NavigationMode.ByMonth);
        public static readonly BindableProperty PageStartModeProperty = BindableProperty.Create(nameof(PageStartMode), typeof(PageStartMode), typeof(CalendarView), PageStartMode.NavigatedMonth, propertyChanged: PageStartModePropertyChanged);
        #endregion

        #endregion

        #endregion

        #region Commands
        /// <summary>
        /// The command used to navigate the calendar.
        /// </summary>
        public ICommand NavigateCalendarCommand { get; private set; }
        /// <summary>
        /// The command used to change the date selection.
        /// </summary>
        public ICommand ChangeDateSelectionCommand { get; private set; }
        #endregion

        #region Events
        public event EventHandler DateSelectionChanged;
        public event EventHandler MonthViewDaysInvalidated;
        #endregion

        #region Constructors
        public CalendarView()
        {
            Days = new ReadOnlyObservableCollection<CalendarDay>(_Days);
            NavigateCalendarCommand = new Command<bool>(NavigateCalendar);
            ChangeDateSelectionCommand = new Command<DateTime>(ChangeDateSelection);
            InitializeComponent();
            UpdateMonthViewDates(NavigatedDate);
            OnMonthViewDaysInvalidated();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Called when either <see cref="SelectedDate"/> changes or <see cref="SelectedDates"/> changes/updates.
        /// </summary>
        /// <remarks>
        /// This may be called as a result of changing the <see cref="Enums.SelectionMode"/>.
        /// </remarks>
        public void OnDateSelectionChanged()
        {
            DateSelectionChanged?.Invoke(this, new EventArgs());
        }
        /// <summary>
        /// Called when the <see cref="CalendarView"/> needs to notify <see cref="CalendarDayView"/>s to reevaluate their properties due to a change.
        /// </summary>
        public void OnMonthViewDaysInvalidated()
        {
            MonthViewDaysInvalidated?.Invoke(this, new EventArgs());
        }
        /// <summary>
        /// Gets the distance of a <see cref="DayOfWeek"/> from the week start according to the specified <paramref name="DayOfWeekOrder"/>
        /// </summary>
        /// <param name="DayNamesOrder">The days occurring in a week in chronological order.</param>
        /// <param name="DayOfWeek">The <see cref="DayOfWeek"/> to find the distance from the week start.</param>
        /// <returns>The distance of a <see cref="DayOfWeek"/> from the week start.</returns>
        /// <exception cref="ArgumentNullException">The specified <paramref name="DayOfWeekOrder"/> is null.</exception>
        /// <exception cref="ArgumentException">The specified <paramref name="DayOfWeek"/> does not occur in the specified <paramref name="DayOfWeekOrder"/>.</exception>
        public static int GetDistanceFromBeginningOfWeek(IEnumerable<DayOfWeek> DayNamesOrder, DayOfWeek DayOfWeek)
        {
            if (DayNamesOrder == null) { throw new ArgumentNullException(nameof(DayNamesOrder)); }
            if (DayNamesOrder.Contains(DayOfWeek) == false) { throw new ArgumentException($"The specified {nameof(DayOfWeek)} must occur at least once in the {nameof(DayNamesOrder)}."); }
            
            List<DayOfWeek> DayOfWeekOrderList = new List<DayOfWeek>(DayNamesOrder);
            int ReturnValue = 0;

            while (DayOfWeekOrderList[ReturnValue] != DayOfWeek)
            {
                ReturnValue += 1;
            }
            return ReturnValue;
        }
        /// <summary>
        /// Selects or unselects a <see cref="DateTime"/> depending on the current <see cref="SelectionMode"/>.
        /// </summary>
        /// <param name="DateTime">The <see cref="DateTime"/> to select/unselect.</param>
        public virtual void ChangeDateSelection(DateTime DateTime)
        {
            switch (SelectionMode)
            {
                case Enums.SelectionMode.Single:
                    if (DateTime.Date == SelectedDate?.Date)
                    {
                        SelectedDate = null;
                    }
                    else
                    {
                        SelectedDate = DateTime.Date;
                    }
                    break;

                case Enums.SelectionMode.Multiple:
                    if (SelectedDates == null)
                    {
                        SelectedDates = new ObservableCollection<DateTime>() { DateTime.Date };
                    }
                    else if (SelectedDates.Any(x => x.Date == DateTime.Date))
                    {
                        SelectedDates.Remove(DateTime.Date);
                    }
                    else
                    {
                        SelectedDates.Add(DateTime.Date);
                    }
                    break;
            }
        }
        /// <summary>
        /// Gets the number of <see cref="CalendarDay"/>s that need to be displayed for a specific date.
        /// </summary>
        /// <param name="NavigationDate">The <see cref="DateTime"/> to get the number of <see cref="CalendarDay"/>s for.</param>
        /// <returns></returns>
        public int GetCalendarDaysRequiredToNavigate(DateTime NavigationDate)
        {
            if (AutoRows && AutoRowsIsConsistent)
            {
                return NavigationDate.CalendarHighestMonthWeekCountOfYear(StartOfWeek) * DayNamesOrder.Count;
            }
            else if (AutoRows)
            {
                return NavigationDate.CalendarWeeksInMonth(StartOfWeek) * DayNamesOrder.Count;
            }

            return Rows * DayNamesOrder.Count;
        }
        /// <summary>
        /// Updates the dates displayed on the calendar.
        /// </summary>
        /// <param name="NavigationDate">The <see cref="DateTime"/> who's month will be used to update the dates.</param>
        /// <remarks>
        /// Doesn't work correctly in the case that a week spans into an unrepresentable <see cref="DateTime"/> and the <see cref="DayNamesOrder"/> 
        /// isn't chronological.
        /// </remarks>
        public void UpdateMonthViewDates(DateTime NavigationDate)
        {
            List<DayOfWeek> DayNamesOrderList = new List<DayOfWeek>(DayNamesOrder);
            int DatesUpdated = 0;
            int DaysRequiredToNavigate = GetCalendarDaysRequiredToNavigate(NavigationDate);

            DateTime PageStartDate;
            switch (PageStartMode)
            {
                case PageStartMode.NavigatedWeek:
                    PageStartDate = NavigationDate.FirstDayOfWeek(StartOfWeek);
                    break;
                case PageStartMode.NavigatedMonth:
                    PageStartDate = NavigationDate.FirstDayOfMonth().FirstDayOfWeek(StartOfWeek);
                    break;
                case PageStartMode.NavigatedYear:
                    PageStartDate = new DateTime(NavigatedDate.Year, 1, 1).FirstDayOfWeek(StartOfWeek);
                    break;
                default:
                    throw new NotImplementedException($"{nameof(Enums.PageStartMode)} '{PageStartMode}' has not been implemented.");
            }

            //Using a fixed value instead of _Days.Count because multiple methods may be adding and removing days at the same time.
            //This would mean they would be adding and removing days between each other to reach their targets for potentially forever.
            int DayDifference = DaysRequiredToNavigate - _Days.Count;
            while (DayDifference != 0)
            {
                if (DayDifference > 0)
                {
                    _Days.Add(new CalendarDay());
                    DayDifference -= 1;
                }
                else
                {
                    _Days.RemoveAt(_Days.Count - 1);
                    DayDifference += 1;
                }
            }

            for (int RowsAdded = 0; DatesUpdated < DaysRequiredToNavigate; RowsAdded++)
            {
                List<DateTime> RowDates = new List<DateTime>();

                for (int i = 0; i < DaysOfWeek.Count; i++)
                {
                    try
                    {
                        RowDates.Add(PageStartDate.AddDays(RowsAdded * DaysOfWeek.Count + i));
                    }
                    catch (ArgumentOutOfRangeException Ex) when (Ex.TargetSite.DeclaringType == typeof(DateTime))
                    {
                    }
                }

                for (int i = 0; i < DayNamesOrderList.Count; i++)
                {
                    try
                    {
                        //Get the updated date by indexing the RowDates based on their DayOfWeek
                        _Days[DatesUpdated].DateTime = RowDates.First(x => x.DayOfWeek == DayNamesOrderList[i]);
                        DatesUpdated += 1;
                    }
                    catch (InvalidOperationException)
                    {
                        //Catch for when RowDates may not have a certain DayOfWeek, for example when the week spans into unrepresentable DateTimes.
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        //_days list should have been updated to the correct count at the beginning of this method.
                        //if there is an ArgumentOutOfRangeException here, something else has modified that collection, most likely another instance of this method.
                        //if this is the case, instead of possibly having these multiple methods modifying for a correct count infinitely, just exit the method.
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// Navigates date at which the time unit is extracted.
        /// </summary>
        /// <param name="Forward">Whether the source will be navigated forwards or backwards</param>
        /// <exception cref="NotImplementedException">The current <see cref="PageStartMode"/> is not implemented</exception>
        public virtual void NavigateCalendar(bool Forward)
        {
            try
            {
                switch (NavigationMode)
                {
                    case NavigationMode.ByWeek:
                        NavigatedDate = NavigatedDate.AddDays(Forward ? DaysOfWeek.Count : -DaysOfWeek.Count);
                        break;
                    case NavigationMode.ByMonth:
                        NavigatedDate = NavigatedDate.AddMonths(Forward ? 1 : -1);
                        break;
                    case NavigationMode.ByYear:
                        NavigatedDate = NavigatedDate.AddYears(Forward ? 1 : -1);
                        break;
                    case NavigationMode.ByPage:
                        List<CalendarDay> DaysList = _Days.ToList();
                        IEnumerable<DateTime> DistinctDates = DaysList.Select(x => x.DateTime.Date).Distinct();

                        NavigatedDate = NavigatedDate.AddDays(Forward ? DistinctDates.Count() : -DistinctDates.Count());
                        break;
                    default:
                        throw new NotImplementedException($"{nameof(Enums.NavigationMode)} {NavigationMode} is not implemented.");
                }
                
            }
            catch (ArgumentOutOfRangeException Ex) when (Ex.TargetSite.DeclaringType == typeof(DateTime))
            {
                switch (NavigationLimitMode)
                {
                    case NavigationLimitMode.Restrict:
                        if (!Forward) { NavigatedDate = DateTime.MinValue; }
                        else if (Forward) { NavigatedDate = DateTime.MaxValue; }
                        break;
                    case NavigationLimitMode.LoopMinimum:
                        if (!Forward) { NavigatedDate = DateTime.MaxValue; }
                        break;
                    case NavigationLimitMode.LoopMaximum:
                        if (Forward) { NavigatedDate = DateTime.MinValue; }
                        break;
                    case NavigationLimitMode.LoopMinimumAndMaximum:
                        if (!Forward) { NavigatedDate = DateTime.MaxValue; }
                        else if (Forward) { NavigatedDate = DateTime.MinValue; }
                        break;

                    case NavigationLimitMode.RestrictAndScopeToDayRange:
                        if (!Forward) { NavigatedDate = DayRangeMinimumDate; }
                        else if (Forward) { NavigatedDate = DayRangeMaximumDate; }
                        break;
                    case NavigationLimitMode.LoopMinimumAndScopeToDayRange:
                        if (!Forward) { NavigatedDate = DayRangeMaximumDate; }
                        break;
                    case NavigationLimitMode.LoopMaximumAndScopeToDayRange:
                        if (Forward) { NavigatedDate = DayRangeMinimumDate; }
                        break;
                    case NavigationLimitMode.LoopMinimumAndMaximumAndScopeToDayRange:
                        if (!Forward) { NavigatedDate = DayRangeMaximumDate; }
                        else if (Forward) { NavigatedDate = DayRangeMinimumDate; }
                        break;
                }
            }
        }
        private void SelectedDates_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnMonthViewDaysInvalidated();
            OnDateSelectionChanged();
        }
        private void DayNamesOrder_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CoerceValue(DayNamesOrderProperty);
            ValidateDayNamesOrder();
        }
        public void ValidateDayNamesOrder()
        {
            if (DayNamesOrder == null) { throw new ArgumentNullException($"{nameof(DayNamesOrder)} must not be null."); }
            if (DayNamesOrder.Count == 0) { throw new InvalidOperationException($"{nameof(DayNamesOrder)} must contain at least one {nameof(DayOfWeek)}."); }
        }

        #region Bindable Properties Methods
        private static void RowsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            Control.UpdateMonthViewDates(Control.NavigatedDate);
            Control.OnMonthViewDaysInvalidated();
        }
        private static void NavigatedDatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            Control.UpdateMonthViewDates(Control.NavigatedDate);
            Control.OnMonthViewDaysInvalidated();

        }
        private static void TodayDatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            Control.OnMonthViewDaysInvalidated();
        }
        private static void StartOfWeekPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            Control.CoerceValue(DayNamesOrderProperty);
            Control.UpdateMonthViewDates(Control.NavigatedDate);
            Control.OnMonthViewDaysInvalidated();
        }
        private static void DayRangeMinimumDatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            Control.OnMonthViewDaysInvalidated();
        }
        private static void DayRangeMaximumDatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            Control.OnMonthViewDaysInvalidated();
        }
        private static void SelectedDatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            Control.OnMonthViewDaysInvalidated();
            Control.OnDateSelectionChanged();
        }
        private static void SelectedDatesPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            ObservableCollection<DateTime> OldSelectedDates = (ObservableCollection<DateTime>)oldValue;
            ObservableCollection<DateTime> NewSelectedDates = (ObservableCollection<DateTime>)newValue;
            if (OldSelectedDates != null) { OldSelectedDates.CollectionChanged -= Control.SelectedDates_CollectionChanged; }
            if (NewSelectedDates != null) { NewSelectedDates.CollectionChanged += Control.SelectedDates_CollectionChanged; }
            Control.OnMonthViewDaysInvalidated();
            Control.OnDateSelectionChanged();
        }
        private static void SelectionModePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            Control.CoerceValue(SelectedDateProperty);
            Control.CoerceValue(SelectedDatesProperty);
        }
        private static void AutoRowsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            Control.CoerceValue(RowsProperty);
        }
        private static void AutoRowsIsConsistentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            Control.CoerceValue(RowsProperty);
        }
        private static void DayNamesOrderUsesStartOfWeekPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            if ((bool)newValue)
            {
                Control.CoerceValue(DayNamesOrderProperty);
            }
        }
        private static void PageStartModePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            Control.UpdateMonthViewDates(Control.NavigatedDate);
            Control.OnMonthViewDaysInvalidated();
        }
        private static object CoerceSelectedDate(BindableObject bindable, object value)
        {
            CalendarView Control = (CalendarView)bindable;
            return Control.SelectionMode == Enums.SelectionMode.Single ? value : null;
        }
        private static object CoerceSelectedDates(BindableObject bindable, object value)
        {
            CalendarView Control = (CalendarView)bindable;
            return Control.SelectionMode == Enums.SelectionMode.Multiple ? value : null;
        }
        private static object CoerceNavigatedDate(BindableObject bindable, object value)
        {
            DateTime BeforeValue = (DateTime)value;
            CalendarView Control = (CalendarView)bindable;

            switch (Control.NavigationLimitMode)
            {
                case NavigationLimitMode.Restrict:
                case NavigationLimitMode.LoopMinimum:
                case NavigationLimitMode.LoopMaximum:
                case NavigationLimitMode.LoopMinimumAndMaximum:
                    return BeforeValue;

                case NavigationLimitMode.RestrictAndScopeToDayRange:
                    if (BeforeValue.Date < Control.DayRangeMinimumDate.Date) { return Control.DayRangeMinimumDate; }
                    if (BeforeValue.Date > Control.DayRangeMaximumDate.Date) { return Control.DayRangeMaximumDate; }
                    return BeforeValue;

                case NavigationLimitMode.LoopMinimumAndScopeToDayRange:
                    if (BeforeValue.Date < Control.DayRangeMinimumDate.Date) { return Control.DayRangeMaximumDate; }
                    if (BeforeValue.Date > Control.DayRangeMaximumDate.Date) { return Control.DayRangeMaximumDate; }
                    return BeforeValue;

                case NavigationLimitMode.LoopMaximumAndScopeToDayRange:
                    if (BeforeValue.Date < Control.DayRangeMinimumDate.Date) { return Control.DayRangeMinimumDate; }
                    if (BeforeValue.Date > Control.DayRangeMaximumDate.Date) { return Control.DayRangeMinimumDate; }
                    return BeforeValue;

                case NavigationLimitMode.LoopMinimumAndMaximumAndScopeToDayRange:
                    if (BeforeValue.Date < Control.DayRangeMinimumDate.Date) { return Control.DayRangeMaximumDate; }
                    if (BeforeValue.Date > Control.DayRangeMaximumDate.Date) { return Control.DayRangeMinimumDate; }
                    return BeforeValue;

                default:
                    throw new NotImplementedException($"{nameof(CoerceNavigatedDate)} does not have logic returning a value.");
            }
        }
        private static object CoerceDayNamesOrder(BindableObject bindable, object value)
        {
            CalendarView Control = (CalendarView)bindable;
            ObservableRangeCollection<DayOfWeek> OriginalValue = (ObservableRangeCollection<DayOfWeek>)value;

            if (Control.DayNamesOrderUsesStartOfWeek)
            {
                List<DayOfWeek> OriginalValueList = new List<DayOfWeek>(OriginalValue);

                //Make a list where the indexes in the DaysOfWeek have shifted in order to get the StartOfWeek to the first position.
                List<DayOfWeek> StartOfWeekDayNamesOrder = new List<DayOfWeek>();
                for (int i = 0; i < Control.DaysOfWeek.Count; i++)
                {
                    int Offset = Control.DaysOfWeek.IndexOf(Control.StartOfWeek);
                    int DayNameIndex = (i + Offset) < Control.DaysOfWeek.Count ? (i + Offset) : (i + Offset) - Control.DaysOfWeek.Count;
                    StartOfWeekDayNamesOrder.Add(Control.DaysOfWeek[DayNameIndex]);
                }

                if (OriginalValueList.Count != StartOfWeekDayNamesOrder.Count)
                {
                    OriginalValue.ReplaceRange(StartOfWeekDayNamesOrder);
                    return value;
                }

                for (int i = 0; i < StartOfWeekDayNamesOrder.Count; i++)
                {
                    if (OriginalValueList[i] != StartOfWeekDayNamesOrder[i])
                    {
                        OriginalValue.ReplaceRange(StartOfWeekDayNamesOrder);
                        return value;
                    }
                }
            }

            return value;
        }
        private static object CoerceRows(BindableObject bindable, object value)
        {
            CalendarView Control = (CalendarView)bindable;

            if (Control.AutoRows && Control.AutoRowsIsConsistent)
            {
                return Control.NavigatedDate.CalendarHighestMonthWeekCountOfYear(Control.StartOfWeek);
            }
            else if (Control.AutoRows)
            {
                return Control.NavigatedDate.CalendarWeeksInMonth(Control.StartOfWeek);
            }

            return value;
        }
        private static object DayNamesOrderDefaultValueCreator(BindableObject bindable)
        {
            CalendarView Control = (CalendarView)bindable;
            return new ObservableRangeCollection<DayOfWeek>(Control.DaysOfWeek);
        }
        #endregion

        #endregion
    }
}