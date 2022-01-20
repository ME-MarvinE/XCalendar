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
        protected static readonly List<DayOfWeek> DaysOfWeek = new List<DayOfWeek>()
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday,
        };

        private readonly ObservableCollection<CalendarDay> _Days = new ObservableCollection<CalendarDay>();
        private readonly ObservableRangeCollection<DayOfWeek> _StartOfWeekDayNamesOrder = new ObservableRangeCollection<DayOfWeek>(DaysOfWeek);
        #endregion

        #region Properties

        #region Bindable Properties
        /// <summary>
        /// The list of displayed days.
        /// </summary>
        public ReadOnlyObservableCollection<CalendarDay> Days
        {
            get { return (ReadOnlyObservableCollection<CalendarDay>)GetValue(DaysProperty); }
            protected set { SetValue(DaysPropertyKey, value); }
        }
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
        /// <seealso cref="NavigationLoopMode"/>
        public DateTime DayRangeMinimumDate
        {
            get { return (DateTime)GetValue(DayRangeMinimumDateProperty); }
            set { SetValue(DayRangeMinimumDateProperty, value); }
        }
        /// <summary>
        /// The upper bound of the day range.
        /// </summary>
        /// <seealso cref="NavigationLoopMode"/>
        public DateTime DayRangeMaximumDate
        {
            get { return (DateTime)GetValue(DayRangeMaximumDateProperty); }
            set { SetValue(DayRangeMaximumDateProperty, value); }
        }
        /// <summary>
        /// The day of week that should be considered as the start of the week.
        /// </summary>
        /// <seealso cref="CustomDayNamesOrder"/>
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
        /// Whether to use <see cref="CustomDayNamesOrder"/> for displaying the page or not.
        /// </summary>
        public bool UseCustomDayNamesOrder
        {
            get { return (bool)GetValue(UseCustomDayNamesOrderProperty); }
            set { SetValue(UseCustomDayNamesOrderProperty, value); }
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
        /// The type of selection to use for selecting dates.
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
        public NavigationLoopMode NavigationLoopMode
        {
            get { return (NavigationLoopMode)GetValue(NavigationLoopModeProperty); }
            set { SetValue(NavigationLoopModeProperty, value); }
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
        public ObservableRangeCollection<DateTime> SelectedDates
        {
            get { return (ObservableRangeCollection<DateTime>)GetValue(SelectedDatesProperty); }
            set { SetValue(SelectedDatesProperty, value); }
        }
        /// <summary>
        /// The order to display the days of the week in when <see cref="UseCustomDayNamesOrder"/> is set to true.
        /// </summary>
        /// <remarks>Does not affect logic.</remarks>
        /// <seealso cref="UseCustomDayNamesOrder"/>
        public ObservableRangeCollection<DayOfWeek> CustomDayNamesOrder
        {
            get { return (ObservableRangeCollection<DayOfWeek>)GetValue(CustomDayNamesOrderProperty); }
            set { SetValue(CustomDayNamesOrderProperty, value); }
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
        public NavigationTimeUnit NavigationTimeUnit
        {
            get { return (NavigationTimeUnit)GetValue(NavigationTimeUnitProperty); }
            set { SetValue(NavigationTimeUnitProperty, value); }
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
            get { return (PageStartMode)GetValue(PageStartModeProperty); }
            set { SetValue(PageStartModeProperty, value); }
        }
        /// <summary>
        /// The days of the week ordered chronologically according to the <see cref="StartOfWeek"/>.
        /// </summary>
        public ReadOnlyObservableCollection<DayOfWeek> StartOfWeekDayNamesOrder
        {
            get { return (ReadOnlyObservableCollection<DayOfWeek>)GetValue(StartOfWeekDayNamesOrderProperty); }
            protected set { SetValue(StartOfWeekDayNamesOrderPropertyKey, value); }
        }
        /// <summary>
        /// The order to display the days of the week in.
        /// </summary>
        public ReadOnlyObservableCollection<DayOfWeek> DayNamesOrder
        {
            get { return (ReadOnlyObservableCollection<DayOfWeek>)GetValue(DayNamesOrderProperty); }
            protected set { SetValue(DayNamesOrderPropertyKey, value); }
        }
        public bool ClampNavigatedDateToDayRange
        {
            get { return (bool)GetValue(ClampNavigatedDateToDayRangeProperty); }
            set { SetValue(ClampNavigatedDateToDayRangeProperty, value); }
        }

        #region Bindable Properties Initialisers
        public static readonly BindableProperty NavigatedDateProperty = BindableProperty.Create(nameof(NavigatedDate), typeof(DateTime), typeof(CalendarView), DateTime.Now, defaultBindingMode: BindingMode.TwoWay, propertyChanged: NavigatedDatePropertyChanged, coerceValue: CoerceNavigatedDate);
        private static readonly BindablePropertyKey DaysPropertyKey = BindableProperty.CreateReadOnly(nameof(Days), typeof(ReadOnlyObservableCollection<CalendarDay>), typeof(CalendarView), null, defaultValueCreator: DaysDefaultValueCreator);
        public static readonly BindableProperty DaysProperty = DaysPropertyKey.BindableProperty;
        public static readonly BindableProperty RowsProperty = BindableProperty.Create(nameof(Rows), typeof(int), typeof(CalendarView), 6, defaultBindingMode: BindingMode.TwoWay, propertyChanged: RowsPropertyChanged, coerceValue: CoerceRows);
        public static readonly BindableProperty AutoRowsProperty = BindableProperty.Create(nameof(AutoRows), typeof(bool), typeof(CalendarView), true, propertyChanged: AutoRowsPropertyChanged);
        public static readonly BindableProperty AutoRowsIsConsistentProperty = BindableProperty.Create(nameof(AutoRowsIsConsistent), typeof(bool), typeof(CalendarView), true, propertyChanged: AutoRowsIsConsistentPropertyChanged);
        public static readonly BindableProperty DayRangeMinimumDateProperty = BindableProperty.Create(nameof(DayRangeMinimumDate), typeof(DateTime), typeof(CalendarView), DateTime.MinValue, propertyChanged: DayRangeMinimumDatePropertyChanged);
        public static readonly BindableProperty DayRangeMaximumDateProperty = BindableProperty.Create(nameof(DayRangeMaximumDate), typeof(DateTime), typeof(CalendarView), DateTime.MaxValue, propertyChanged: DayRangeMaximumDatePropertyChanged);
        public static readonly BindableProperty TodayDateProperty = BindableProperty.Create(nameof(TodayDate), typeof(DateTime), typeof(CalendarView), DateTime.Now, propertyChanged: TodayDatePropertyChanged);
        public static readonly BindableProperty StartOfWeekProperty = BindableProperty.Create(nameof(StartOfWeek), typeof(DayOfWeek), typeof(CalendarView), CultureInfo.CurrentUICulture.DateTimeFormat.FirstDayOfWeek, propertyChanged: StartOfWeekPropertyChanged);
        public static readonly BindableProperty SelectionModeProperty = BindableProperty.Create(nameof(SelectionMode), typeof(Enums.SelectionMode), typeof(CalendarView), Enums.SelectionMode.None, propertyChanged: SelectionModePropertyChanged);
        public static readonly BindableProperty SelectedDateProperty = BindableProperty.Create(nameof(SelectedDate), typeof(DateTime?), typeof(CalendarView), defaultBindingMode: BindingMode.TwoWay, propertyChanged: SelectedDatePropertyChanged);
        public static readonly BindableProperty SelectedDatesProperty = BindableProperty.Create(nameof(SelectedDates), typeof(ObservableRangeCollection<DateTime>), typeof(CalendarView), propertyChanged: SelectedDatesPropertyChanged, defaultValueCreator: SelectedDatesDefaultValueCreator);
        public static readonly BindableProperty DayTemplateProperty = BindableProperty.Create(nameof(DayTemplate), typeof(DataTemplate), typeof(CalendarView));
        public static readonly BindableProperty DayHeightRequestProperty = BindableProperty.Create(nameof(DayHeightRequest), typeof(double), typeof(CalendarView), 50d);
        public static readonly BindableProperty DayCurrentMonthTextColorProperty = BindableProperty.Create(nameof(DayCurrentMonthTextColor), typeof(Color), typeof(CalendarView), Color.Black);
        public static readonly BindableProperty DayTodayTextColorProperty = BindableProperty.Create(nameof(DayTodayTextColor), typeof(Color), typeof(CalendarView), Color.Green);
        public static readonly BindableProperty DayOtherMonthTextColorProperty = BindableProperty.Create(nameof(DayOtherMonthTextColor), typeof(Color), typeof(CalendarView), Color.Gray);
        public static readonly BindableProperty DayOutOfRangeTextColorProperty = BindableProperty.Create(nameof(DayOutOfRangeTextColor), typeof(Color), typeof(CalendarView), Color.Pink);
        public static readonly BindableProperty DaySelectedTextColorProperty = BindableProperty.Create(nameof(DaySelectedTextColor), typeof(Color), typeof(CalendarView), Color.Red);
        public static readonly BindableProperty DayNameTextColorProperty = BindableProperty.Create(nameof(DayNameTextColor), typeof(Color), typeof(CalendarView), Color.Black);
        private static readonly BindablePropertyKey DayNamesOrderPropertyKey = BindableProperty.CreateReadOnly(nameof(DayNamesOrder), typeof(ReadOnlyObservableCollection<DayOfWeek>), typeof(CalendarView), null, defaultValueCreator: DayNamesOrderDefaultValueCreator, propertyChanged: DayNamesOrderPropertyChanged);
        public static readonly BindableProperty DayNamesOrderProperty = DayNamesOrderPropertyKey.BindableProperty;
        private static readonly BindablePropertyKey StartOfWeekDayNamesOrderPropertyKey = BindableProperty.CreateReadOnly(nameof(StartOfWeekDayNamesOrder), typeof(ReadOnlyObservableCollection<DayOfWeek>), typeof(CalendarView), null, defaultValueCreator: StartOfWeekDayNamesOrderDefaultValueCreator);
        public static readonly BindableProperty StartOfWeekDayNamesOrderProperty = StartOfWeekDayNamesOrderPropertyKey.BindableProperty;
        public static readonly BindableProperty CustomDayNamesOrderProperty = BindableProperty.Create(nameof(CustomDayNamesOrder), typeof(ObservableRangeCollection<DayOfWeek>), typeof(CalendarView), defaultValueCreator: CustomDayNamesOrderDefaultValueCreator, propertyChanged: CustomDayNamesOrderPropertyChanged);
        public static readonly BindableProperty UseCustomDayNamesOrderProperty = BindableProperty.Create(nameof(UseCustomDayNamesOrder), typeof(bool), typeof(CalendarView), false, propertyChanged: UseCustomDayNamesOrderPropertyChanged);
        public static readonly BindableProperty DayNamesTemplateProperty = BindableProperty.Create(nameof(DayNamesTemplate), typeof(ControlTemplate), typeof(CalendarView));
        public static readonly BindableProperty DayNamesHeightRequestProperty = BindableProperty.Create(nameof(DayNamesHeightRequest), typeof(double), typeof(CalendarView), 25d);
        public static readonly BindableProperty DayNameTemplateProperty = BindableProperty.Create(nameof(DayNameTemplate), typeof(DataTemplate), typeof(CalendarView));
        public static readonly BindableProperty DayNameVerticalSpacingProperty = BindableProperty.Create(nameof(DayNameVerticalSpacing), typeof(double), typeof(CalendarView));
        public static readonly BindableProperty DayNameHorizontalSpacingProperty = BindableProperty.Create(nameof(DayNameHorizontalSpacing), typeof(double), typeof(CalendarView));
        public static readonly BindableProperty MonthViewTemplateProperty = BindableProperty.Create(nameof(MonthViewTemplate), typeof(ControlTemplate), typeof(CalendarView));
        public static readonly BindableProperty MonthViewHeightRequestProperty = BindableProperty.Create(nameof(MonthViewHeightRequest), typeof(double), typeof(CalendarView), 300d);
        public static readonly BindableProperty NavigationTemplateProperty = BindableProperty.Create(nameof(NavigationTemplate), typeof(ControlTemplate), typeof(CalendarView));
        public static readonly BindableProperty NavigationTextColorProperty = BindableProperty.Create(nameof(NavigationTextColor), typeof(Color), typeof(CalendarView), Color.Black);
        public static readonly BindableProperty NavigationArrowColorProperty = BindableProperty.Create(nameof(NavigationArrowColor), typeof(Color), typeof(CalendarView), Color.Black);
        public static readonly BindableProperty NavigationArrowBackgroundColorProperty = BindableProperty.Create(nameof(NavigationArrowBackgroundColor), typeof(Color), typeof(CalendarView), Color.White);
        public static readonly BindableProperty NavigationArrowCornerRadiusProperty = BindableProperty.Create(nameof(NavigationArrowCornerRadius), typeof(float), typeof(CalendarView), 200f);
        public static readonly BindableProperty NavigationLoopModeProperty = BindableProperty.Create(nameof(NavigationLoopMode), typeof(NavigationLoopMode), typeof(CalendarView), NavigationLoopMode.LoopMinimumAndMaximum);
        public static readonly BindableProperty NavigationTimeUnitProperty = BindableProperty.Create(nameof(NavigationTimeUnit), typeof(NavigationTimeUnit), typeof(CalendarView), NavigationTimeUnit.Month);
        public static readonly BindableProperty PageStartModeProperty = BindableProperty.Create(nameof(PageStartMode), typeof(PageStartMode), typeof(CalendarView), PageStartMode.FirstDayOfMonth, propertyChanged: PageStartModePropertyChanged);
        public static readonly BindableProperty ClampNavigatedDateToDayRangeProperty = BindableProperty.Create(nameof(ClampNavigatedDateToDayRange), typeof(bool), typeof(CalendarView), true, propertyChanged: ClampNavigatedDateToDayRangePropertyChanged);
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
            NavigateCalendarCommand = new Command<bool>(NavigateCalendar);
            ChangeDateSelectionCommand = new Command<DateTime>(ChangeDateSelection);

            InitializeComponent();
            UpdateMonthViewDates(NavigatedDate);
            OnMonthViewDaysInvalidated();
        }
        #endregion

        #region Methods
        /// <remarks>
        /// Called when <see cref="SelectedDate"/> changes and <see cref="SelectionMode"/> is set to <see cref="Enums.SelectionMode.Single"/>,
        /// or when <see cref="SelectedDates"/> changes/updates and <see cref="SelectionMode"/> is set to <see cref="Enums.SelectionMode.Multiple"/>.
        /// or when <see cref="SelectionMode"/> changes and the <see cref="SelectedDate"/> and <see cref="SelectedDates"/> don't match exactly.
        /// </remarks>
        /// <example>
        /// Called when <see cref="SelectionMode"/> changes from <see cref="Enums.SelectionMode.Single"/> to/from <see cref="Enums.SelectionMode.Multiple"/> and <see cref="SelectedDate"/> is 10th January 2022 and <see cref="SelectedDates"/> doesn't contain only 10th January 2022.
        /// Not called when <see cref="SelectionMode"/> changes from <see cref="Enums.SelectionMode.None"/> to <see cref="Enums.SelectionMode.Single"/> and <see cref="SelectedDate"/> is null.
        /// Not called when <see cref="SelectionMode"/> changes from <see cref="Enums.SelectionMode.None"/> to <see cref="Enums.SelectionMode.Multiple"/> and <see cref="SelectedDates"/> is empty.</example>
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
        /// Selects or unselects a <see cref="DateTime"/> depending on the current <see cref="SelectionMode"/>.
        /// </summary>
        /// <param name="DateTime">The <see cref="DateTime"/> to select/unselect.</param>
        public virtual void ChangeDateSelection(DateTime DateTime)
        {
            switch (SelectionMode)
            {
                case Enums.SelectionMode.None:
                    break;

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
                    if (SelectedDates.Any(x => x.Date == DateTime.Date))
                    {
                        SelectedDates.Remove(DateTime.Date);
                    }
                    else
                    {
                        SelectedDates.Add(DateTime.Date);
                    }
                    break;
                default:
                    throw new NotImplementedException();
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
        public void UpdateMonthViewDates(DateTime NavigationDate)
        {
            List<DayOfWeek> DayNamesOrderList = new List<DayOfWeek>(DayNamesOrder);
            int DatesUpdated = 0;
            int DaysRequiredToNavigate = GetCalendarDaysRequiredToNavigate(NavigationDate);

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

            //Add/Remove days until reaching the required count.
            while (DaysRequiredToNavigate - Days.Count != 0)
            {
                if (DaysRequiredToNavigate - Days.Count > 0)
                {
                    _Days.Add(new CalendarDay());
                }
                else
                {
                    _Days.RemoveAt(Days.Count - 1);
                }
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

                //Update the dates in the row based on the DayNamesOrder.
                for (int i = 0; i < DayNamesOrderList.Count; i++)
                {
                    try
                    {
                        Days[DatesUpdated].DateTime = Row[DayNamesOrderList[i]];
                    }
                    catch (KeyNotFoundException)
                    {
                        //Catch for when RowDates may not have a certain DayOfWeek, for example when the week spans into unrepresentable DateTimes.
                        Days[DatesUpdated].DateTime = DateTime.MaxValue;
                    }

                    DatesUpdated += 1;
                }
            }
        }
        /// <summary>
        /// Navigates the date at which the time unit is extracted.
        /// </summary>
        /// <param name="Forward">Whether the source will be navigated forwards or backwards</param>
        /// <exception cref="NotImplementedException">The current <see cref="PageStartMode"/> is not implemented</exception>
        public virtual void NavigateCalendar(bool Forward)
        {
            DateTime MinimumDate = ClampNavigatedDateToDayRange ? DayRangeMinimumDate : DateTime.MinValue;
            DateTime MaximumDate = ClampNavigatedDateToDayRange ? DayRangeMaximumDate : DateTime.MaxValue;

            NavigatedDate = NavigateDateByWeeks(NavigatedDate, MinimumDate, MaximumDate, Forward ? 1 : -1, NavigationLoopMode, NavigationTimeUnit, StartOfWeek);
        }
        public DateTime NavigateDateByWeeks(DateTime DateTime, DateTime MinimumDate, DateTime MaximumDate, int Amount, NavigationLoopMode NavigationLoopMode, NavigationTimeUnit NavigationTimeUnit, DayOfWeek StartOfWeek)
        {
            bool LowerThanMinimumDate;
            bool HigherThanMaximumDate;

            DateTime NewNavigatedDate;

            try
            {
                switch (NavigationTimeUnit)
                {
                    case NavigationTimeUnit.None:
                        NewNavigatedDate = DateTime;
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

                    case NavigationTimeUnit.Page:
                        NewNavigatedDate = DateTime.AddWeeks(Rows * Amount);
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

            if (LowerThanMinimumDate)
            {
                if (NavigationLoopMode.HasFlag(NavigationLoopMode.LoopMinimum))
                {
                    NewNavigatedDate = MaximumDate;
                    //The code below makes sure that the correct amount of weeks are added after looping.
                    //However this is not possible when setting the NavigatedDate directly, so it is commented out for the sake of consistency.
                    
                    ////The difference in weeks must be made consistent because NavigatedDate could be any value within the week.
                    ////The minimum date may not always have the first day of week so the last day of week is used to do this.
                    //TimeSpan Difference = DateTime.LastDayOfWeek(StartOfWeek) - MinimumDate.LastDayOfWeek(StartOfWeek);

                    //int WeeksUntilMinValue = (int)Math.Ceiling(Difference.TotalDays / 7);
                    //DateTime NewNavigatedDate = NavigateDateByWeeks(MinimumDate, MinimumDate, MaximumDate, Amount + WeeksUntilMinValue, NavigationLoopMode, StartOfWeek);


                    ////Preserve the original time.
                    //return new DateTime(NewNavigatedDate.Year, NewNavigatedDate.Month, NewNavigatedDate.Day, DateTime.Hour, DateTime.Minute, DateTime.Second, DateTime.Millisecond);
                }
            }
            else if (HigherThanMaximumDate)
            {
                if (NavigationLoopMode.HasFlag(NavigationLoopMode.LoopMaximum))
                {
                    NewNavigatedDate = MinimumDate;
                    //The code below makes sure that the correct amount of weeks are added after looping.
                    //However this is not possible when setting the NavigatedDate directly, so it is commented out for the sake of consistency.
                    
                    ////The difference in weeks must be made consistent because NavigatedDate could be any value within the week.
                    ////The maximum date may not always have the last day of week so the first day of week is used to do this.
                    //TimeSpan Difference = MaximumDate.FirstDayOfWeek(StartOfWeek) - DateTime.FirstDayOfWeek(StartOfWeek);

                    //int WeeksUntilMaxValue = (int)Math.Ceiling(Difference.TotalDays / 7);
                    //DateTime NewNavigatedDate = NavigateDateByWeeks(MinimumDate, MinimumDate, MaximumDate, Amount - WeeksUntilMaxValue, NavigationLoopMode, StartOfWeek);

                    ////Preserve the original time.
                    //return new DateTime(NewNavigatedDate.Year, NewNavigatedDate.Month, NewNavigatedDate.Day, DateTime.Hour, DateTime.Minute, DateTime.Second, DateTime.Millisecond);
                }
            }

            return NewNavigatedDate;
        }
        private void SelectedDates_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (SelectionMode == Enums.SelectionMode.Multiple)
            {
                OnMonthViewDaysInvalidated();
                OnDateSelectionChanged();
            }
        }
        private void DayNamesOrder_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (DayNamesOrder.Count == 0) { throw new InvalidOperationException($"{nameof(DayNamesOrder)} must contain at least one {nameof(DayOfWeek)}."); }
            UpdateMonthViewDates(NavigatedDate);
            OnMonthViewDaysInvalidated();
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
        private static void ClampNavigatedDateToDayRangePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            Control.NavigatedDate = (DateTime)CoerceNavigatedDate(Control, Control.NavigatedDate);
            //Control.CoerceValue(NavigatedDateProperty);
        }
        private static void TodayDatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            Control.OnMonthViewDaysInvalidated();
        }
        private static void StartOfWeekPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;

            List<DayOfWeek> NewStartOfWeekDayNamesOrder = new List<DayOfWeek>();
            for (int i = 0; i < DaysOfWeek.Count; i++)
            {
                int Offset = DaysOfWeek.IndexOf(Control.StartOfWeek);
                int DayNameIndex = (i + Offset) < DaysOfWeek.Count ? (i + Offset) : (i + Offset) - DaysOfWeek.Count;
                NewStartOfWeekDayNamesOrder.Add(DaysOfWeek[DayNameIndex]);
            }
            Control._StartOfWeekDayNamesOrder.ReplaceRange(NewStartOfWeekDayNamesOrder);

            if (Control.UseCustomDayNamesOrder)
            {
                Control.UpdateMonthViewDates(Control.NavigatedDate);
                Control.OnMonthViewDaysInvalidated();
            }
            else
            {
                Control.DayNamesOrder = new ReadOnlyObservableCollection<DayOfWeek>(Control._StartOfWeekDayNamesOrder);
            }
        }
        private static void DayRangeMinimumDatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            Control.NavigatedDate = (DateTime)CoerceNavigatedDate(Control, Control.NavigatedDate);
        }
        private static void DayRangeMaximumDatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            Control.NavigatedDate = (DateTime)CoerceNavigatedDate(Control, Control.NavigatedDate);
        }
        private static void SelectedDatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            if (Control.SelectionMode == Enums.SelectionMode.Single)
            {
                Control.OnMonthViewDaysInvalidated();
                Control.OnDateSelectionChanged();
            }
        }
        private static void SelectedDatesPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            ObservableRangeCollection<DateTime> OldSelectedDates = (ObservableRangeCollection<DateTime>)oldValue;
            ObservableRangeCollection<DateTime> NewSelectedDates = (ObservableRangeCollection<DateTime>)newValue;

            if (OldSelectedDates != null) { OldSelectedDates.CollectionChanged -= Control.SelectedDates_CollectionChanged; }
            if (NewSelectedDates != null) { NewSelectedDates.CollectionChanged += Control.SelectedDates_CollectionChanged; }
            if (Control.SelectionMode == Enums.SelectionMode.Multiple)
            {
                Control.OnMonthViewDaysInvalidated();
                Control.OnDateSelectionChanged();
            }
        }
        private static void CustomDayNamesOrderPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;

            if (Control.UseCustomDayNamesOrder)
            {
                Control.DayNamesOrder = new ReadOnlyObservableCollection<DayOfWeek>(Control.CustomDayNamesOrder);
            }
        }
        private static void DayNamesOrderPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            ReadOnlyObservableCollection<DayOfWeek> OldDayNamesOrder = (ReadOnlyObservableCollection<DayOfWeek>)oldValue;
            ReadOnlyObservableCollection<DayOfWeek> NewDayNamesOrder = (ReadOnlyObservableCollection<DayOfWeek>)newValue;

            if (OldDayNamesOrder != null) { ((INotifyCollectionChanged)OldDayNamesOrder).CollectionChanged -= Control.DayNamesOrder_CollectionChanged; }
            if (NewDayNamesOrder != null) { ((INotifyCollectionChanged)NewDayNamesOrder).CollectionChanged += Control.DayNamesOrder_CollectionChanged; }

            if (OldDayNamesOrder == null || !NewDayNamesOrder.SequenceEqual(OldDayNamesOrder))
            {
                Control.UpdateMonthViewDates(Control.NavigatedDate);
                Control.OnMonthViewDaysInvalidated();
            }
        }
        private static void SelectionModePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            Enums.SelectionMode OldSelectionMode = (Enums.SelectionMode)oldValue;
            Enums.SelectionMode NewSelectionMode = (Enums.SelectionMode)newValue;
            bool HasSelectionChanged;

            DateTime? ExactMultipleDate = null;
            if (Control.SelectedDates.Count == 1)
            {
                ExactMultipleDate = Control.SelectedDates[0];
            }

            switch (OldSelectionMode)
            {
                case Enums.SelectionMode.None:
                    switch (NewSelectionMode)
                    {
                        case Enums.SelectionMode.Single:
                            HasSelectionChanged = Control.SelectedDate != null;
                            break;
                        case Enums.SelectionMode.Multiple:
                            HasSelectionChanged = Control.SelectedDates.Count != 0;
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    break;

                case Enums.SelectionMode.Single:
                    switch (NewSelectionMode)
                    {
                        case Enums.SelectionMode.None:
                            HasSelectionChanged = Control.SelectedDate != null;
                            break;
                        case Enums.SelectionMode.Multiple:
                            HasSelectionChanged = Control.SelectedDate?.Date != ExactMultipleDate?.Date;
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    break;

                case Enums.SelectionMode.Multiple:
                    switch (NewSelectionMode)
                    {
                        case Enums.SelectionMode.None:
                            HasSelectionChanged = Control.SelectedDates.Count != 0;
                            break;
                        case Enums.SelectionMode.Single:
                            HasSelectionChanged = ExactMultipleDate?.Date != Control.SelectedDate?.Date;
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }

            if (HasSelectionChanged)
            {
                Control.OnMonthViewDaysInvalidated();
                Control.OnDateSelectionChanged();
            }
        }
        private static void AutoRowsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            if (Control.Rows == (int)CoerceRows(Control, Control.Rows))
            {
                Control.UpdateMonthViewDates(Control.NavigatedDate);
                Control.OnMonthViewDaysInvalidated();
            }
            else
            {
                Control.Rows = (int)CoerceRows(Control, Control.Rows);
            }
            //Control.CoerceValue(RowsProperty);
        }
        private static void AutoRowsIsConsistentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            if (Control.Rows == (int)CoerceRows(Control, Control.Rows))
            {
                Control.UpdateMonthViewDates(Control.NavigatedDate);
                Control.OnMonthViewDaysInvalidated();
            }
            else
            {
                Control.Rows = (int)CoerceRows(Control, Control.Rows);
            }
            //Control.CoerceValue(RowsProperty);
        }
        private static void UseCustomDayNamesOrderPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;

            if ((bool)newValue)
            {
                Control.DayNamesOrder = new ReadOnlyObservableCollection<DayOfWeek>(Control.CustomDayNamesOrder);
            }
            else
            {
                Control.DayNamesOrder = new ReadOnlyObservableCollection<DayOfWeek>(Control._StartOfWeekDayNamesOrder);
            }
        }
        private static void PageStartModePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView Control = (CalendarView)bindable;
            Control.UpdateMonthViewDates(Control.NavigatedDate);
            Control.OnMonthViewDaysInvalidated();
        }
        private static object CoerceNavigatedDate(BindableObject bindable, object value)
        {
            DateTime InitialValue = (DateTime)value;
            CalendarView Control = (CalendarView)bindable;

            DateTime MinimumDate = Control.ClampNavigatedDateToDayRange ? Control.DayRangeMinimumDate : DateTime.MinValue;
            DateTime MaximumDate = Control.ClampNavigatedDateToDayRange ? Control.DayRangeMaximumDate : DateTime.MaxValue;

            switch (Control.NavigationLoopMode)
            {
                case NavigationLoopMode.DontLoop:
                    if (InitialValue.Date < MinimumDate.Date) { return MinimumDate; }
                    if (InitialValue.Date > MaximumDate.Date) { return MaximumDate; }
                    break;
                case NavigationLoopMode.LoopMinimum:
                    if (InitialValue.Date < MinimumDate.Date) { return MaximumDate; }
                    if (InitialValue.Date > MaximumDate.Date) { return MaximumDate; }
                    break;

                case NavigationLoopMode.LoopMaximum:
                    if (InitialValue.Date < MinimumDate.Date) { return MinimumDate; }
                    if (InitialValue.Date > MaximumDate.Date) { return MinimumDate; }
                    break;

                case NavigationLoopMode.LoopMinimumAndMaximum:
                    if (InitialValue.Date < MinimumDate.Date) { return MaximumDate; }
                    if (InitialValue.Date > MaximumDate.Date) { return MinimumDate; }
                    break;

                default:
                    throw new NotImplementedException($"{nameof(NavigationLoopMode)} is not implemented.");
            }

            return InitialValue;
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
        private static object StartOfWeekDayNamesOrderDefaultValueCreator(BindableObject bindable)
        {
            CalendarView Control = (CalendarView)bindable;
            return new ReadOnlyObservableCollection<DayOfWeek>(Control._StartOfWeekDayNamesOrder);
        }
        private static object CustomDayNamesOrderDefaultValueCreator(BindableObject bindable)
        {
            return new ObservableRangeCollection<DayOfWeek>(DaysOfWeek);
        }
        private static object DayNamesOrderDefaultValueCreator(BindableObject bindable)
        {
            CalendarView Control = (CalendarView)bindable;

            if (Control.UseCustomDayNamesOrder)
            {
                return new ReadOnlyObservableCollection<DayOfWeek>(Control.CustomDayNamesOrder);
            }
            else
            {
                return new ReadOnlyObservableCollection<DayOfWeek>(Control._StartOfWeekDayNamesOrder);
            }
        }
        private static object SelectedDatesDefaultValueCreator(BindableObject bindable)
        {
            CalendarView Control = (CalendarView)bindable;
            ObservableRangeCollection<DateTime> DefaultValue = new ObservableRangeCollection<DateTime>();

            DefaultValue.CollectionChanged += Control.SelectedDates_CollectionChanged;
            return DefaultValue;
        }
        private static object DaysDefaultValueCreator(BindableObject bindable)
        {
            CalendarView Control = (CalendarView)bindable;
            return new ReadOnlyObservableCollection<CalendarDay>(Control._Days);
        }
        #endregion

        #endregion
    }
}