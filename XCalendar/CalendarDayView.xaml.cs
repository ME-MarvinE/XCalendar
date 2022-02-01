using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCalendar.Enums;

namespace XCalendar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarDayView : ContentView
    {
        #region Properties

        #region Bindable Properties
        public Color CurrentMonthTextColor
        {
            get { return (Color)GetValue(CurrentMonthTextColorProperty); }
            set { SetValue(CurrentMonthTextColorProperty, value); }
        }
        public Color CurrentMonthBackgroundColor
        {
            get { return (Color)GetValue(CurrentMonthBackgroundColorProperty); }
            set { SetValue(CurrentMonthBackgroundColorProperty, value); }
        }
        public Color TodayTextColor
        {
            get { return (Color)GetValue(TodayTextColorProperty); }
            set { SetValue(TodayTextColorProperty, value); }
        }
        public Color TodayBackgroundColor
        {
            get { return (Color)GetValue(TodayBackgroundColorProperty); }
            set { SetValue(TodayBackgroundColorProperty, value); }
        }
        public Color OtherMonthTextColor
        {
            get { return (Color)GetValue(OtherMonthTextColorProperty); }
            set { SetValue(OtherMonthTextColorProperty, value); }
        }
        public Color OtherMonthBackgroundColor
        {
            get { return (Color)GetValue(OtherMonthBackgroundColorProperty); }
            set { SetValue(OtherMonthBackgroundColorProperty, value); }
        }
        public Color OutOfRangeTextColor
        {
            get { return (Color)GetValue(OutOfRangeTextColorProperty); }
            set { SetValue(OutOfRangeTextColorProperty, value); }
        }
        public Color OutOfRangeBackgroundColor
        {
            get { return (Color)GetValue(OutOfRangeBackgroundColorProperty); }
            set { SetValue(OutOfRangeBackgroundColorProperty, value); }
        }
        public Color SelectedTextColor
        {
            get { return (Color)GetValue(SelectedTextColorProperty); }
            set { SetValue(SelectedTextColorProperty, value); }
        }
        public Color SelectedBackgroundColor
        {
            get { return (Color)GetValue(SelectedBackgroundColorProperty); }
            set { SetValue(SelectedBackgroundColorProperty, value); }
        }
        public DateTime DateTime
        {
            get { return (DateTime)GetValue(DateTimeProperty); }
            set { SetValue(DateTimeProperty, value); }
        }
        public bool IsCurrentMonth
        {
            get { return (bool)GetValue(IsCurrentMonthProperty); }
            set { SetValue(IsCurrentMonthProperty, value); }
        }
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }
        public bool IsOutOfRange
        {
            get { return (bool)GetValue(IsOutOfRangeProperty); }
            set { SetValue(IsOutOfRangeProperty, value); }
        }
        public bool IsToday
        {
            get { return (bool)GetValue(IsTodayProperty); }
            set { SetValue(IsTodayProperty, value); }
        }
        public CalendarView CalendarView
        {
            get { return (CalendarView)GetValue(CalendarViewProperty); }
            set { SetValue(CalendarViewProperty, value); }
        }

        #endregion

        #region Bindable Properties Initialisers
        public static readonly BindableProperty CalendarViewProperty = BindableProperty.Create(nameof(CalendarView), typeof(CalendarView), typeof(CalendarDayView), propertyChanged: CalendarViewPropertyChanged);
        public static readonly BindableProperty DateTimeProperty = BindableProperty.Create(nameof(DateTime), typeof(DateTime), typeof(CalendarDayView));
        public static readonly BindableProperty IsCurrentMonthProperty = BindableProperty.Create(nameof(IsCurrentMonth), typeof(bool), typeof(CalendarDayView));
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(CalendarDayView));
        public static readonly BindableProperty IsOutOfRangeProperty = BindableProperty.Create(nameof(IsOutOfRange), typeof(bool), typeof(CalendarDayView));
        public static readonly BindableProperty IsTodayProperty = BindableProperty.Create(nameof(IsToday), typeof(bool), typeof(CalendarDayView));
        public static readonly BindableProperty CurrentMonthTextColorProperty = BindableProperty.Create(nameof(CurrentMonthTextColor), typeof(Color), typeof(CalendarDayView), Color.Black);
        public static readonly BindableProperty CurrentMonthBackgroundColorProperty = BindableProperty.Create(nameof(CurrentMonthBackgroundColor), typeof(Color), typeof(CalendarDayView), Color.Transparent);
        public static readonly BindableProperty TodayTextColorProperty = BindableProperty.Create(nameof(TodayTextColor), typeof(Color), typeof(CalendarDayView), Color.FromHex("#009000"));
        public static readonly BindableProperty TodayBackgroundColorProperty = BindableProperty.Create(nameof(TodayBackgroundColor), typeof(Color), typeof(CalendarDayView), Color.Transparent);
        public static readonly BindableProperty OtherMonthTextColorProperty = BindableProperty.Create(nameof(OtherMonthTextColor), typeof(Color), typeof(CalendarDayView), Color.Gray);
        public static readonly BindableProperty OtherMonthBackgroundColorProperty = BindableProperty.Create(nameof(OtherMonthBackgroundColor), typeof(Color), typeof(CalendarDayView), Color.Transparent);
        public static readonly BindableProperty OutOfRangeTextColorProperty = BindableProperty.Create(nameof(OutOfRangeTextColor), typeof(Color), typeof(CalendarDayView), Color.Pink);
        public static readonly BindableProperty OutOfRangeBackgroundColorProperty = BindableProperty.Create(nameof(OutOfRangeBackgroundColor), typeof(Color), typeof(CalendarDayView), Color.Transparent);
        public static readonly BindableProperty SelectedTextColorProperty = BindableProperty.Create(nameof(SelectedTextColor), typeof(Color), typeof(CalendarDayView), Color.White);
        public static readonly BindableProperty SelectedBackgroundColorProperty = BindableProperty.Create(nameof(SelectedBackgroundColor), typeof(Color), typeof(CalendarDayView), Color.FromHex("#E00000"));
        #endregion

        #endregion

        #region Constructors
        public CalendarDayView()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void CalendarView_MonthViewDaysInvalidated(object sender, EventArgs e)
        {
            UpdateProperties();
            UpdateView();
        }
        public virtual void UpdateProperties()
        {
            IsCurrentMonth = IsDateTimeCurrentMonth(DateTime);
            IsOutOfRange = IsDateTimeOutOfRange(DateTime);
            IsSelected = IsDateTimeSelected(DateTime);
            IsToday = IsDateTimeToday(DateTime);
        }
        public virtual void UpdateView()
        {
            if (IsOutOfRange)
            {
                MainLabel.BackgroundColor = OutOfRangeBackgroundColor;
                MainLabel.TextColor = OutOfRangeTextColor;
            }
            else if (IsSelected && IsCurrentMonth)
            {
                MainLabel.BackgroundColor = SelectedBackgroundColor;
                MainLabel.TextColor = SelectedTextColor;
            }
            else if (IsToday && IsCurrentMonth)
            {
                MainLabel.BackgroundColor = TodayBackgroundColor;
                MainLabel.TextColor = TodayTextColor;
            }
            else if (!IsCurrentMonth)
            {
                MainLabel.BackgroundColor = OtherMonthBackgroundColor;
                MainLabel.TextColor = OtherMonthTextColor;
            }
            else if (IsCurrentMonth)
            {
                MainLabel.BackgroundColor = CurrentMonthBackgroundColor;
                MainLabel.TextColor = CurrentMonthTextColor;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public virtual bool IsDateTimeCurrentMonth(DateTime DateTime)
        {
            return DateTime.Month == CalendarView?.NavigatedDate.Month && DateTime.Year == CalendarView?.NavigatedDate.Year;
        }
        public virtual bool IsDateTimeOutOfRange(DateTime DateTime)
        {
            return DateTime.Date < CalendarView?.DayRangeMinimumDate.Date || DateTime.Date > CalendarView?.DayRangeMaximumDate.Date;
        }
        public virtual bool IsDateTimeToday(DateTime DateTime)
        {
            return DateTime.Date == CalendarView?.TodayDate.Date;
        }
        public virtual bool IsDateTimeSelected(DateTime DateTime)
        {
            switch (CalendarView?.SelectionMode)
            {
                case null:
                case Enums.SelectionMode.None: return false;
                case Enums.SelectionMode.Single: return CalendarView?.SelectedDate?.Date == DateTime.Date;
                case Enums.SelectionMode.Multiple: return CalendarView?.SelectedDates?.Any(x => x.Date == DateTime.Date) == true;
                default:
                    throw new NotImplementedException($"{nameof(Enums.SelectionMode)} is not implemented.");
            }
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            UpdateProperties();
            UpdateView();
        }

        #region Bindable Properties Methods
        private static void CalendarViewPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarDayView Control = (CalendarDayView)bindable;
            CalendarView OldCalendarView = (CalendarView)oldValue;
            CalendarView NewCalendarView = (CalendarView)newValue;

            if (OldCalendarView != null)
            {
                OldCalendarView.MonthViewDaysInvalidated -= Control.CalendarView_MonthViewDaysInvalidated;
            }
            if (NewCalendarView != null)
            {
                NewCalendarView.MonthViewDaysInvalidated += Control.CalendarView_MonthViewDaysInvalidated;
            }
        }
        #endregion

        #endregion
    }
}