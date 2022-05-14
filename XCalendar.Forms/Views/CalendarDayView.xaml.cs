using System;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCalendar.Core.Enums;

namespace XCalendar.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarDayView : FramedLabel
    {
        #region Properties

        #region Bindable Properties
        public DateTime? DateTime
        {
            get { return (DateTime?)GetValue(DateTimeProperty); }
            set { SetValue(DateTimeProperty, value); }
        }
        public DayState DayState
        {
            get { return (DayState)GetValue(DayStateProperty); }
            set { SetValue(DayStateProperty, value); }
        }
        public bool IsCurrentMonth
        {
            get { return (bool)GetValue(IsCurrentMonthProperty); }
            set { SetValue(IsCurrentMonthProperty, value); }
        }
        public bool IsToday
        {
            get { return (bool)GetValue(IsTodayProperty); }
            set { SetValue(IsTodayProperty, value); }
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
        public bool IsDayStateCurrentMonth
        {
            get { return (bool)GetValue(IsDayStateCurrentMonthProperty); }
            set { SetValue(IsDayStateCurrentMonthProperty, value); }
        }
        public bool IsDayStateOtherMonth
        {
            get { return (bool)GetValue(IsDayStateOtherMonthProperty); }
            set { SetValue(IsDayStateOtherMonthProperty, value); }
        }
        public bool IsDayStateToday
        {
            get { return (bool)GetValue(IsDayStateTodayProperty); }
            set { SetValue(IsDayStateTodayProperty, value); }
        }
        public bool IsDayStateSelected
        {
            get { return (bool)GetValue(IsDayStateSelectedProperty); }
            set { SetValue(IsDayStateSelectedProperty, value); }
        }
        public bool IsDayStateOutOfRange
        {
            get { return (bool)GetValue(IsDayStateOutOfRangeProperty); }
            set { SetValue(IsDayStateOutOfRangeProperty, value); }
        }
        public CalendarView CalendarView
        {
            get { return (CalendarView)GetValue(CalendarViewProperty); }
            set { SetValue(CalendarViewProperty, value); }
        }
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
        public Color CurrentMonthBorderColor
        {
            get { return (Color)GetValue(CurrentMonthBorderColorProperty); }
            set { SetValue(CurrentMonthBorderColorProperty, value); }
        }
        public ICommand CurrentMonthCommand
        {
            get { return (ICommand)GetValue(CurrentMonthCommandProperty); }
            set { SetValue(CurrentMonthCommandProperty, value); }
        }
        public object CurrentMonthCommandParameter
        {
            get { return (object)GetValue(CurrentMonthCommandParameterProperty); }
            set { SetValue(CurrentMonthCommandParameterProperty, value); }
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
        public Color TodayBorderColor
        {
            get { return (Color)GetValue(TodayBorderColorProperty); }
            set { SetValue(TodayBorderColorProperty, value); }
        }
        public ICommand TodayCommand
        {
            get { return (ICommand)GetValue(TodayCommandProperty); }
            set { SetValue(TodayCommandProperty, value); }
        }
        public object TodayCommandParameter
        {
            get { return (object)GetValue(TodayCommandParameterProperty); }
            set { SetValue(TodayCommandParameterProperty, value); }
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
        public Color OtherMonthBorderColor
        {
            get { return (Color)GetValue(OtherMonthBorderColorProperty); }
            set { SetValue(OtherMonthBorderColorProperty, value); }
        }
        public ICommand OtherMonthCommand
        {
            get { return (ICommand)GetValue(OtherMonthCommandProperty); }
            set { SetValue(OtherMonthCommandProperty, value); }
        }
        public object OtherMonthCommandParameter
        {
            get { return (object)GetValue(OtherMonthCommandParameterProperty); }
            set { SetValue(OtherMonthCommandParameterProperty, value); }
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
        public Color OutOfRangeBorderColor
        {
            get { return (Color)GetValue(OutOfRangeBorderColorProperty); }
            set { SetValue(OutOfRangeBorderColorProperty, value); }
        }
        public ICommand OutOfRangeCommand
        {
            get { return (ICommand)GetValue(OutOfRangeCommandProperty); }
            set { SetValue(OutOfRangeCommandProperty, value); }
        }
        public object OutOfRangeCommandParameter
        {
            get { return (object)GetValue(OutOfRangeCommandParameterProperty); }
            set { SetValue(OutOfRangeCommandParameterProperty, value); }
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
        public Color SelectedBorderColor
        {
            get { return (Color)GetValue(SelectedBorderColorProperty); }
            set { SetValue(SelectedBorderColorProperty, value); }
        }
        public ICommand SelectedCommand
        {
            get { return (ICommand)GetValue(SelectedCommandProperty); }
            set { SetValue(SelectedCommandProperty, value); }
        }
        public object SelectedCommandParameter
        {
            get { return (object)GetValue(SelectedCommandParameterProperty); }
            set { SetValue(SelectedCommandParameterProperty, value); }
        }
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        #endregion

        #region Bindable Properties Initialisers
        public static readonly BindableProperty CalendarViewProperty = BindableProperty.Create(nameof(CalendarView), typeof(CalendarView), typeof(CalendarDayView), propertyChanged: CalendarViewPropertyChanged);
        public static readonly BindableProperty DateTimeProperty = BindableProperty.Create(nameof(DateTime), typeof(DateTime?), typeof(CalendarDayView), System.DateTime.Today);
        public static readonly BindableProperty DayStateProperty = BindableProperty.Create(nameof(IsToday), typeof(DayState), typeof(CalendarDayView), DayState.CurrentMonth, propertyChanged: DayStatePropertyChanged);
        public static readonly BindableProperty IsCurrentMonthProperty = BindableProperty.Create(nameof(IsCurrentMonth), typeof(bool), typeof(CalendarDayView));
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(CalendarDayView));
        public static readonly BindableProperty IsOutOfRangeProperty = BindableProperty.Create(nameof(IsOutOfRange), typeof(bool), typeof(CalendarDayView));
        public static readonly BindableProperty IsTodayProperty = BindableProperty.Create(nameof(IsToday), typeof(bool), typeof(CalendarDayView));
        public static readonly BindableProperty IsDayStateCurrentMonthProperty = BindableProperty.Create(nameof(IsDayStateCurrentMonth), typeof(bool), typeof(CalendarDayView), true);
        public static readonly BindableProperty IsDayStateOtherMonthProperty = BindableProperty.Create(nameof(IsDayStateOtherMonth), typeof(bool), typeof(CalendarDayView));
        public static readonly BindableProperty IsDayStateTodayProperty = BindableProperty.Create(nameof(IsDayStateToday), typeof(bool), typeof(CalendarDayView));
        public static readonly BindableProperty IsDayStateSelectedProperty = BindableProperty.Create(nameof(IsDayStateSelected), typeof(bool), typeof(CalendarDayView));
        public static readonly BindableProperty IsDayStateOutOfRangeProperty = BindableProperty.Create(nameof(IsDayStateOutOfRange), typeof(bool), typeof(CalendarDayView));
        public static readonly BindableProperty CurrentMonthTextColorProperty = BindableProperty.Create(nameof(CurrentMonthTextColor), typeof(Color), typeof(CalendarDayView), Color.Black);
        public static readonly BindableProperty CurrentMonthBackgroundColorProperty = BindableProperty.Create(nameof(CurrentMonthBackgroundColor), typeof(Color), typeof(CalendarDayView), Color.Transparent);
        public static readonly BindableProperty CurrentMonthBorderColorProperty = BindableProperty.Create(nameof(CurrentMonthBorderColor), typeof(Color), typeof(CalendarDayView), BorderColorProperty.DefaultValue);
        public static readonly BindableProperty CurrentMonthCommandProperty = BindableProperty.Create(nameof(CurrentMonthCommand), typeof(ICommand), typeof(CalendarDayView));
        public static readonly BindableProperty CurrentMonthCommandParameterProperty = BindableProperty.Create(nameof(CurrentMonthCommandParameter), typeof(object), typeof(CalendarDayView));
        public static readonly BindableProperty TodayTextColorProperty = BindableProperty.Create(nameof(TodayTextColor), typeof(Color), typeof(CalendarDayView), Color.Black);
        public static readonly BindableProperty TodayBackgroundColorProperty = BindableProperty.Create(nameof(TodayBackgroundColor), typeof(Color), typeof(CalendarDayView), Color.Transparent);
        public static readonly BindableProperty TodayBorderColorProperty = BindableProperty.Create(nameof(TodayBorderColor), typeof(Color), typeof(CalendarDayView), Color.FromHex("#E00000"));
        public static readonly BindableProperty TodayCommandProperty = BindableProperty.Create(nameof(TodayCommand), typeof(ICommand), typeof(CalendarDayView));
        public static readonly BindableProperty TodayCommandParameterProperty = BindableProperty.Create(nameof(TodayCommandParameter), typeof(object), typeof(CalendarDayView));
        public static readonly BindableProperty OtherMonthTextColorProperty = BindableProperty.Create(nameof(OtherMonthTextColor), typeof(Color), typeof(CalendarDayView), Color.FromHex("#A0A0A0"));
        public static readonly BindableProperty OtherMonthBackgroundColorProperty = BindableProperty.Create(nameof(OtherMonthBackgroundColor), typeof(Color), typeof(CalendarDayView), Color.Transparent);
        public static readonly BindableProperty OtherMonthBorderColorProperty = BindableProperty.Create(nameof(OtherMonthBorderColor), typeof(Color), typeof(CalendarDayView), BorderColorProperty.DefaultValue);
        public static readonly BindableProperty OtherMonthCommandProperty = BindableProperty.Create(nameof(OtherMonthCommand), typeof(ICommand), typeof(CalendarDayView));
        public static readonly BindableProperty OtherMonthCommandParameterProperty = BindableProperty.Create(nameof(OtherMonthCommandParameter), typeof(object), typeof(CalendarDayView));
        public static readonly BindableProperty OutOfRangeTextColorProperty = BindableProperty.Create(nameof(OutOfRangeTextColor), typeof(Color), typeof(CalendarDayView), Color.FromHex("#FFA0A0"));
        public static readonly BindableProperty OutOfRangeBackgroundColorProperty = BindableProperty.Create(nameof(OutOfRangeBackgroundColor), typeof(Color), typeof(CalendarDayView), Color.Transparent);
        public static readonly BindableProperty OutOfRangeBorderColorProperty = BindableProperty.Create(nameof(OutOfRangeBorderColor), typeof(Color), typeof(CalendarDayView), BorderColorProperty.DefaultValue);
        public static readonly BindableProperty OutOfRangeCommandProperty = BindableProperty.Create(nameof(OutOfRangeCommand), typeof(ICommand), typeof(CalendarDayView));
        public static readonly BindableProperty OutOfRangeCommandParameterProperty = BindableProperty.Create(nameof(OutOfRangeCommandParameter), typeof(object), typeof(CalendarDayView));
        public static readonly BindableProperty SelectedTextColorProperty = BindableProperty.Create(nameof(SelectedTextColor), typeof(Color), typeof(CalendarDayView), Color.White);
        public static readonly BindableProperty SelectedBackgroundColorProperty = BindableProperty.Create(nameof(SelectedBackgroundColor), typeof(Color), typeof(CalendarDayView), Color.FromHex("#E00000"));
        public static readonly BindableProperty SelectedBorderColorProperty = BindableProperty.Create(nameof(SelectedBorderColor), typeof(Color), typeof(CalendarDayView), BorderColorProperty.DefaultValue);
        public static readonly BindableProperty SelectedCommandProperty = BindableProperty.Create(nameof(SelectedCommand), typeof(ICommand), typeof(CalendarDayView));
        public static readonly BindableProperty SelectedCommandParameterProperty = BindableProperty.Create(nameof(SelectedCommandParameter), typeof(object), typeof(CalendarDayView));
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(CalendarDayView));
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(CalendarDayView));
        #endregion

        #endregion

        #region Commands
        public ICommand UpdateCalendarViewDateSelectionCommand { get; private set; }
        #endregion

        #region Constructors
        public CalendarDayView()
        {
            UpdateCalendarViewDateSelectionCommand = new Command<DateTime>((DateTime) => { CalendarView?.ChangeDateSelection(DateTime); });

            CurrentMonthCommand = UpdateCalendarViewDateSelectionCommand;
            SetBinding(CurrentMonthCommandParameterProperty, new Binding("DateTime", source: this));

            TodayCommand = UpdateCalendarViewDateSelectionCommand;
            SetBinding(TodayCommandParameterProperty, new Binding("DateTime", source: this));

            SelectedCommand = UpdateCalendarViewDateSelectionCommand;
            SetBinding(SelectedCommandParameterProperty, new Binding("DateTime", source: this));

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
            IsCurrentMonth = DateTime != null && IsDateTimeCurrentMonth(DateTime.Value);
            IsOutOfRange = DateTime != null && IsDateTimeOutOfRange(DateTime.Value);
            IsSelected = DateTime != null && IsDateTimeSelected(DateTime.Value);
            IsToday = DateTime != null && IsDateTimeToday(DateTime.Value);
        }
        public virtual void UpdateView()
        {
            bool IsOtherMonth = !IsCurrentMonth;

            if (IsOutOfRange)
            {
                BackgroundColor = OutOfRangeBackgroundColor;
                BorderColor = OutOfRangeBorderColor;
                TextColor = OutOfRangeTextColor;
                Command = OutOfRangeCommand;
                CommandParameter = OutOfRangeCommandParameter;
            }
            else if (IsSelected && IsCurrentMonth)
            {
                BackgroundColor = SelectedBackgroundColor;
                BorderColor = SelectedBorderColor;
                TextColor = SelectedTextColor;
                Command = SelectedCommand;
                CommandParameter = SelectedCommandParameter;
            }
            else if (IsToday && IsCurrentMonth)
            {
                BackgroundColor = TodayBackgroundColor;
                BorderColor = TodayBorderColor;
                TextColor = TodayTextColor;
                Command = TodayCommand;
                CommandParameter = TodayCommandParameter;
            }
            else if (IsOtherMonth)
            {
                BackgroundColor = OtherMonthBackgroundColor;
                BorderColor = OtherMonthBorderColor;
                TextColor = OtherMonthTextColor;
                Command = OtherMonthCommand;
                CommandParameter = OtherMonthCommandParameter;
            }
            else if (IsCurrentMonth)
            {
                BackgroundColor = CurrentMonthBackgroundColor;
                BorderColor = CurrentMonthBorderColor;
                TextColor = CurrentMonthTextColor;
                Command = CurrentMonthCommand;
                CommandParameter = CurrentMonthCommandParameter;
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
            return CalendarView?.SelectedDates.Any(x => x.Date == DateTime.Date) == true;
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            UpdateProperties();
            UpdateView();
        }
        private static void DayStatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarDayView Control = (CalendarDayView)bindable;
            DayState NewDayState = (DayState)newValue;

            Control.IsDayStateCurrentMonth = NewDayState == DayState.CurrentMonth;
            Control.IsDayStateOtherMonth = NewDayState == DayState.OtherMonth;
            Control.IsDayStateToday = NewDayState == DayState.Today;
            Control.IsDayStateSelected = NewDayState == DayState.Selected;
            Control.IsDayStateOutOfRange = NewDayState == DayState.OutOfRange;
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
        #endregion

        #endregion
    }
}