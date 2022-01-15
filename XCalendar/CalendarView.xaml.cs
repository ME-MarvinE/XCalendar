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
        protected ObservableCollection<CalendarDay> _Days = new ObservableCollection<CalendarDay>();
        #endregion

        #region Properties
        public ReadOnlyObservableCollection<CalendarDay> Days { get; }

        #region Bindable Properties
        public DateTime NavigatedDate
        {
            get { return (DateTime)GetValue(NavigatedDateProperty); }
            set { SetValue(NavigatedDateProperty, value); }
        }
        public DateTime TodayDate
        {
            get { return (DateTime)GetValue(TodayDateProperty); }
            set { SetValue(TodayDateProperty, value); }
        }
        public DateTime DayRangeMinimumDate
        {
            get { return (DateTime)GetValue(DayRangeMinimumDateProperty); }
            set { SetValue(DayRangeMinimumDateProperty, value); }
        }
        public DateTime DayRangeMaximumDate
        {
            get { return (DateTime)GetValue(DayRangeMaximumDateProperty); }
            set { SetValue(DayRangeMaximumDateProperty, value); }
        }
        public DayOfWeek StartOfWeek
        {
            get { return (DayOfWeek)GetValue(StartOfWeekProperty); }
            set { SetValue(StartOfWeekProperty, value); }
        }
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
        public double DayNamesHeightRequest
        {
            get { return (double)GetValue(DayNamesHeightRequestProperty); }
            set { SetValue(DayNamesHeightRequestProperty, value); }
        }
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
        public ControlTemplate MonthViewTemplate
        {
            get { return (ControlTemplate)GetValue(MonthViewTemplateProperty); }
            set { SetValue(MonthViewTemplateProperty, value); }
        }
        public double MonthViewHeightRequest
        {
            get { return (double)GetValue(MonthViewHeightRequestProperty); }
            set { SetValue(MonthViewHeightRequestProperty, value); }
        }
        public bool AutoRows
        {
            get { return (bool)GetValue(AutoRowsProperty); }
            set { SetValue(AutoRowsProperty, value); }
        }
        public bool AutoRowsIsConsistent
        {
            get { return (bool)GetValue(AutoRowsIsConsistentProperty); }
            set { SetValue(AutoRowsIsConsistentProperty, value); }
        }
        public bool DayNamesOrderUsesStartOfWeek
        {
            get { return (bool)GetValue(DayNamesOrderUsesStartOfWeekProperty); }
            set { SetValue(DayNamesOrderUsesStartOfWeekProperty, value); }
        }
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
        public CalendarSelectionMode SelectionMode
        {
            get { return (CalendarSelectionMode)GetValue(SelectionModeProperty); }
            set { SetValue(SelectionModeProperty, value); }
        }
        public CalendarNavigationLimitMode NavigationLimitMode
        {
            get { return (CalendarNavigationLimitMode)GetValue(NavigationLimitModeProperty); }
            set { SetValue(NavigationLimitModeProperty, value); }
        }
        public DateTime? SelectedDate
        {
            get { return (DateTime?)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }
        public ObservableCollection<DateTime> SelectedDates
        {
            get { return (ObservableCollection<DateTime>)GetValue(SelectedDatesProperty); }
            set { SetValue(SelectedDatesProperty, value); }
        }
        public ObservableRangeCollection<DayOfWeek> DayNamesOrder
        {
            get { return (ObservableRangeCollection<DayOfWeek>)GetValue(DayNamesOrderProperty); }
            set { SetValue(DayNamesOrderProperty, value); }
        }
        public int Rows
        {
            get { return (int)GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }
        public DataTemplate DayTemplate
        {
            get { return (DataTemplate)GetValue(DayTemplateProperty); }
            set { SetValue(DayTemplateProperty, value); }
        }
        public CalendarNavigationMode NavigationMode
        {
            get { return (CalendarNavigationMode)GetValue(NavigationModeProperty); }
            set { SetValue(NavigationModeProperty, value); }
        }
        public CalendarPageStartMode PageStartMode
        {
            get { return (CalendarPageStartMode)GetValue(PageStartModeProperty); }
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
        public static readonly BindableProperty SelectionModeProperty = BindableProperty.Create(nameof(SelectionMode), typeof(CalendarSelectionMode), typeof(CalendarView), CalendarSelectionMode.None, propertyChanged: SelectionModePropertyChanged);
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
        public static readonly BindableProperty NavigationLimitModeProperty = BindableProperty.Create(nameof(NavigationLimitMode), typeof(CalendarNavigationLimitMode), typeof(CalendarView), CalendarNavigationLimitMode.LoopMinimumAndMaximum);
        public static readonly BindableProperty NavigationModeProperty = BindableProperty.Create(nameof(NavigationMode), typeof(CalendarNavigationMode), typeof(CalendarView), CalendarNavigationMode.ByMonth);
        public static readonly BindableProperty PageStartModeProperty = BindableProperty.Create(nameof(PageStartMode), typeof(CalendarPageStartMode), typeof(CalendarView), CalendarPageStartMode.NavigatedMonth, propertyChanged: PageStartModePropertyChanged);
        #endregion

        #endregion

        #endregion

        #region Commands
        public ICommand NavigateCalendarCommand { get; private set; }
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
        public void OnDateSelectionChanged()
        {
            DateSelectionChanged?.Invoke(this, new EventArgs());
        }
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
        public virtual void ChangeDateSelection(DateTime DateTime)
        {
            switch (SelectionMode)
            {
                case CalendarSelectionMode.Single:
                    if (DateTime.Date == SelectedDate?.Date)
                    {
                        SelectedDate = null;
                    }
                    else
                    {
                        SelectedDate = DateTime.Date;
                    }
                    break;

                case CalendarSelectionMode.Multiple:
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
        /// Updates the dates of the <see cref="CalendarDay"/>s in <see cref="_Days"/>.
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
                case CalendarPageStartMode.NavigatedWeek:
                    PageStartDate = NavigationDate.FirstDayOfWeek(StartOfWeek);
                    break;
                case CalendarPageStartMode.NavigatedMonth:
                    PageStartDate = NavigationDate.FirstDayOfMonth().FirstDayOfWeek(StartOfWeek);
                    break;
                case CalendarPageStartMode.NavigatedYear:
                    PageStartDate = new DateTime(NavigatedDate.Year, 1, 1).FirstDayOfWeek(StartOfWeek);
                    break;
                default:
                    throw new NotImplementedException($"{nameof(CalendarPageStartMode)} '{PageStartMode}' has not been implemented.");
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
        public virtual void NavigateCalendar(bool Forward)
        {
            try
            {
                switch (NavigationMode)
                {
                    case CalendarNavigationMode.ByWeek:
                        NavigatedDate = NavigatedDate.AddDays(Forward ? DaysOfWeek.Count : -DaysOfWeek.Count);
                        break;
                    case CalendarNavigationMode.ByMonth:
                        NavigatedDate = NavigatedDate.AddMonths(Forward ? 1 : -1);
                        break;
                    case CalendarNavigationMode.ByYear:
                        NavigatedDate = NavigatedDate.AddYears(Forward ? 1 : -1);
                        break;
                    case CalendarNavigationMode.ByPage:
                        List<CalendarDay> DaysList = _Days.ToList();
                        IEnumerable<DateTime> DistinctDates = DaysList.Select(x => x.DateTime.Date).Distinct();

                        NavigatedDate = NavigatedDate.AddDays(Forward ? DistinctDates.Count() : -DistinctDates.Count());
                        break;
                    default:
                        throw new NotImplementedException($"{nameof(CalendarNavigationMode)} {NavigationMode} is not implemented.");
                }
                
            }
            catch (ArgumentOutOfRangeException Ex) when (Ex.TargetSite.DeclaringType == typeof(DateTime))
            {
                switch (NavigationLimitMode)
                {
                    case CalendarNavigationLimitMode.Restrict:
                        if (!Forward) { NavigatedDate = DateTime.MinValue; }
                        else if (Forward) { NavigatedDate = DateTime.MaxValue; }
                        break;
                    case CalendarNavigationLimitMode.LoopMinimum:
                        if (!Forward) { NavigatedDate = DateTime.MaxValue; }
                        break;
                    case CalendarNavigationLimitMode.LoopMaximum:
                        if (Forward) { NavigatedDate = DateTime.MinValue; }
                        break;
                    case CalendarNavigationLimitMode.LoopMinimumAndMaximum:
                        if (!Forward) { NavigatedDate = DateTime.MaxValue; }
                        else if (Forward) { NavigatedDate = DateTime.MinValue; }
                        break;

                    case CalendarNavigationLimitMode.RestrictAndScopeToDayRange:
                        if (!Forward) { NavigatedDate = DayRangeMinimumDate; }
                        else if (Forward) { NavigatedDate = DayRangeMaximumDate; }
                        break;
                    case CalendarNavigationLimitMode.LoopMinimumAndScopeToDayRange:
                        if (!Forward) { NavigatedDate = DayRangeMaximumDate; }
                        break;
                    case CalendarNavigationLimitMode.LoopMaximumAndScopeToDayRange:
                        if (Forward) { NavigatedDate = DayRangeMinimumDate; }
                        break;
                    case CalendarNavigationLimitMode.LoopMinimumAndMaximumAndScopeToDayRange:
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
            return Control.SelectionMode == CalendarSelectionMode.Single ? value : null;
        }
        private static object CoerceSelectedDates(BindableObject bindable, object value)
        {
            CalendarView Control = (CalendarView)bindable;
            return Control.SelectionMode == CalendarSelectionMode.Multiple ? value : null;
        }
        private static object CoerceNavigatedDate(BindableObject bindable, object value)
        {
            DateTime BeforeValue = (DateTime)value;
            CalendarView Control = (CalendarView)bindable;

            switch (Control.NavigationLimitMode)
            {
                case CalendarNavigationLimitMode.Restrict:
                case CalendarNavigationLimitMode.LoopMinimum:
                case CalendarNavigationLimitMode.LoopMaximum:
                case CalendarNavigationLimitMode.LoopMinimumAndMaximum:
                    return BeforeValue;

                case CalendarNavigationLimitMode.RestrictAndScopeToDayRange:
                    if (BeforeValue.Date < Control.DayRangeMinimumDate.Date) { return Control.DayRangeMinimumDate; }
                    if (BeforeValue.Date > Control.DayRangeMaximumDate.Date) { return Control.DayRangeMaximumDate; }
                    return BeforeValue;

                case CalendarNavigationLimitMode.LoopMinimumAndScopeToDayRange:
                    if (BeforeValue.Date < Control.DayRangeMinimumDate.Date) { return Control.DayRangeMaximumDate; }
                    if (BeforeValue.Date > Control.DayRangeMaximumDate.Date) { return Control.DayRangeMaximumDate; }
                    return BeforeValue;

                case CalendarNavigationLimitMode.LoopMaximumAndScopeToDayRange:
                    if (BeforeValue.Date < Control.DayRangeMinimumDate.Date) { return Control.DayRangeMinimumDate; }
                    if (BeforeValue.Date > Control.DayRangeMaximumDate.Date) { return Control.DayRangeMinimumDate; }
                    return BeforeValue;

                case CalendarNavigationLimitMode.LoopMinimumAndMaximumAndScopeToDayRange:
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