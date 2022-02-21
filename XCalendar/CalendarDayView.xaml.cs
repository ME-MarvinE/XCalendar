using System;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCalendar.Models;

namespace XCalendar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarDayView : Frame
    {
        #region Properties

        #region Bindable Properties
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
        public CalendarDayCustomization Customization
        {
            get { return (CalendarDayCustomization)GetValue(CustomizationProperty); }
            set { SetValue(CustomizationProperty, value); }
        }
        public FormattedString FormattedText
        {
            get { return (FormattedString)GetValue(FormattedTextProperty); }
            set { SetValue(FormattedTextProperty, value); }
        }
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        #endregion

        #region Bindable Properties Initialisers
        public static readonly BindableProperty CalendarViewProperty = BindableProperty.Create(nameof(CalendarView), typeof(CalendarView), typeof(CalendarDayView), propertyChanged: CalendarViewPropertyChanged);
        public static readonly BindableProperty CustomizationProperty = BindableProperty.Create(nameof(Customization), typeof(CalendarDayCustomization), typeof(CalendarDayView), propertyChanged: CustomizationPropertyChanged, defaultValueCreator: CustomizationDefaultValueCreator, validateValue: IsCustomizationValidValue);
        public static readonly BindableProperty DateTimeProperty = BindableProperty.Create(nameof(DateTime), typeof(DateTime), typeof(CalendarDayView));
        public static readonly BindableProperty IsCurrentMonthProperty = BindableProperty.Create(nameof(IsCurrentMonth), typeof(bool), typeof(CalendarDayView));
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(CalendarDayView));
        public static readonly BindableProperty IsOutOfRangeProperty = BindableProperty.Create(nameof(IsOutOfRange), typeof(bool), typeof(CalendarDayView));
        public static readonly BindableProperty IsTodayProperty = BindableProperty.Create(nameof(IsToday), typeof(bool), typeof(CalendarDayView));
        public static readonly BindableProperty FormattedTextProperty = BindableProperty.Create(nameof(FormattedText), typeof(FormattedString), typeof(CalendarDayView), Label.FormattedTextProperty.DefaultValue);
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(CalendarDayView), Label.TextProperty.DefaultValue);
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
            if (Customization != null)
            {
                Padding = Customization.Padding;
                Margin = Customization.Margin;
                WidthRequest = Customization.WidthRequest;
                HeightRequest = Customization.HeightRequest;
                HorizontalOptions = Customization.HorizontalOptions;
                VerticalOptions = Customization.VerticalOptions;
                CornerRadius = Customization.CornerRadius;
                HasShadow = Customization.HasShadow;

                if (IsOutOfRange)
                {
                    BackgroundColor = Customization.OutOfRangeBackgroundColor;
                    BorderColor = Customization.OutOfRangeBorderColor;
                    MainLabel.TextColor = Customization.OutOfRangeTextColor;
                }
                else if (IsSelected && IsCurrentMonth)
                {
                    BackgroundColor = Customization.SelectedBackgroundColor;
                    BorderColor = Customization.SelectedBorderColor;
                    MainLabel.TextColor = Customization.SelectedTextColor;
                }
                else if (IsToday && IsCurrentMonth)
                {
                    BackgroundColor = Customization.TodayBackgroundColor;
                    BorderColor = Customization.TodayBorderColor;
                    MainLabel.TextColor = Customization.TodayTextColor;
                }
                else if (!IsCurrentMonth)
                {
                    BackgroundColor = Customization.OtherMonthBackgroundColor;
                    BorderColor = Customization.OtherMonthBorderColor;
                    MainLabel.TextColor = Customization.OtherMonthTextColor;
                }
                else if (IsCurrentMonth)
                {
                    BackgroundColor = Customization.CurrentMonthBackgroundColor;
                    BorderColor = Customization.CurrentMonthBorderColor;
                    MainLabel.TextColor = Customization.CurrentMonthTextColor;
                }
                else
                {
                    throw new NotImplementedException();
                }
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
            return CalendarView?.SelectedDates.Any(x => x.Date == DateTime.Date) == true;
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

            if (OldCalendarView != null) { OldCalendarView.MonthViewDaysInvalidated -= Control.CalendarView_MonthViewDaysInvalidated; }
            if (NewCalendarView != null) { NewCalendarView.MonthViewDaysInvalidated += Control.CalendarView_MonthViewDaysInvalidated; }

            Control.UpdateProperties();
            Control.UpdateView();
        }
        private static void CustomizationPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarDayView Control = (CalendarDayView)bindable;
            CalendarDayCustomization OldCustomization = (CalendarDayCustomization)oldValue;
            CalendarDayCustomization NewCustomiation = (CalendarDayCustomization)newValue;

            if (OldCustomization != null) { OldCustomization.PropertyChanged -= Control.Customization_PropertyChanged; }
            if (NewCustomiation != null) {  NewCustomiation.PropertyChanged += Control.Customization_PropertyChanged; }

            Control.UpdateView();
        }
        private static bool IsCustomizationValidValue(BindableObject bindable, object value)
        {
            return value != null;
        }
        private static object CustomizationDefaultValueCreator(BindableObject bindable)
        {
            CalendarDayView Control = (CalendarDayView)bindable;

            CalendarDayCustomization DefaultValue = new CalendarDayCustomization();
            DefaultValue.SetBinding(BindingContextProperty, new Binding(nameof(BindingContext)));
            DefaultValue.PropertyChanged += Control.Customization_PropertyChanged;

            return DefaultValue;
        }

        private void Customization_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateView();
        }
        #endregion

        #endregion
    }
}