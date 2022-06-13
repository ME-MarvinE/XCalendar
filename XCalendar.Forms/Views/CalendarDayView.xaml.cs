using System;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCalendar.Core.Enums;
using XCalendar.Core.Models;

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
        public bool IsInvalid
        {
            get { return (bool)GetValue(IsInvalidProperty); }
            set { SetValue(IsInvalidProperty, value); }
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
        public bool IsDayStateInvalid
        {
            get { return (bool)GetValue(IsDayStateInvalidProperty); }
            set { SetValue(IsDayStateInvalidProperty, value); }
        }
        public Calendar Calendar
        {
            get { return (Calendar)GetValue(CalendarProperty); }
            set { SetValue(CalendarProperty, value); }
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
        public Color InvalidTextColor
        {
            get { return (Color)GetValue(InvalidTextColorProperty); }
            set { SetValue(InvalidTextColorProperty, value); }
        }
        public Color InvalidBackgroundColor
        {
            get { return (Color)GetValue(InvalidBackgroundColorProperty); }
            set { SetValue(InvalidBackgroundColorProperty, value); }
        }
        public Color InvalidBorderColor
        {
            get { return (Color)GetValue(InvalidBorderColorProperty); }
            set { SetValue(InvalidBorderColorProperty, value); }
        }
        public ICommand InvalidCommand
        {
            get { return (ICommand)GetValue(InvalidCommandProperty); }
            set { SetValue(InvalidCommandProperty, value); }
        }
        public object InvalidCommandParameter
        {
            get { return (object)GetValue(InvalidCommandParameterProperty); }
            set { SetValue(InvalidCommandParameterProperty, value); }
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
        public static readonly BindableProperty CalendarProperty = BindableProperty.Create(nameof(Calendar), typeof(Calendar), typeof(CalendarDayView), propertyChanged: CalendarPropertyChanged);
        public static readonly BindableProperty DateTimeProperty = BindableProperty.Create(nameof(DateTime), typeof(DateTime?), typeof(CalendarDayView), System.DateTime.Today);
        public static readonly BindableProperty DayStateProperty = BindableProperty.Create(nameof(IsToday), typeof(DayState), typeof(CalendarDayView), DayState.CurrentMonth, propertyChanged: DayStatePropertyChanged);
        public static readonly BindableProperty IsCurrentMonthProperty = BindableProperty.Create(nameof(IsCurrentMonth), typeof(bool), typeof(CalendarDayView));
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(CalendarDayView));
        public static readonly BindableProperty IsInvalidProperty = BindableProperty.Create(nameof(IsInvalid), typeof(bool), typeof(CalendarDayView));
        public static readonly BindableProperty IsTodayProperty = BindableProperty.Create(nameof(IsToday), typeof(bool), typeof(CalendarDayView));
        public static readonly BindableProperty IsDayStateCurrentMonthProperty = BindableProperty.Create(nameof(IsDayStateCurrentMonth), typeof(bool), typeof(CalendarDayView), true);
        public static readonly BindableProperty IsDayStateOtherMonthProperty = BindableProperty.Create(nameof(IsDayStateOtherMonth), typeof(bool), typeof(CalendarDayView));
        public static readonly BindableProperty IsDayStateTodayProperty = BindableProperty.Create(nameof(IsDayStateToday), typeof(bool), typeof(CalendarDayView));
        public static readonly BindableProperty IsDayStateSelectedProperty = BindableProperty.Create(nameof(IsDayStateSelected), typeof(bool), typeof(CalendarDayView));
        public static readonly BindableProperty IsDayStateInvalidProperty = BindableProperty.Create(nameof(IsDayStateInvalid), typeof(bool), typeof(CalendarDayView));
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
        public static readonly BindableProperty InvalidTextColorProperty = BindableProperty.Create(nameof(InvalidTextColor), typeof(Color), typeof(CalendarDayView), Color.FromHex("#FFA0A0"));
        public static readonly BindableProperty InvalidBackgroundColorProperty = BindableProperty.Create(nameof(InvalidBackgroundColor), typeof(Color), typeof(CalendarDayView), Color.Transparent);
        public static readonly BindableProperty InvalidBorderColorProperty = BindableProperty.Create(nameof(InvalidBorderColor), typeof(Color), typeof(CalendarDayView), BorderColorProperty.DefaultValue);
        public static readonly BindableProperty InvalidCommandProperty = BindableProperty.Create(nameof(InvalidCommand), typeof(ICommand), typeof(CalendarDayView));
        public static readonly BindableProperty InvalidCommandParameterProperty = BindableProperty.Create(nameof(InvalidCommandParameter), typeof(object), typeof(CalendarDayView));
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
        public ICommand UpdateCalendarDateSelectionCommand { get; private set; }
        #endregion

        #region Constructors
        public CalendarDayView()
        {
            UpdateCalendarDateSelectionCommand = new Command<DateTime>((DateTime) => { Calendar?.ChangeDateSelection(DateTime); });

            CurrentMonthCommand = UpdateCalendarDateSelectionCommand;
            SetBinding(CurrentMonthCommandParameterProperty, new Binding("DateTime", source: this));

            TodayCommand = UpdateCalendarDateSelectionCommand;
            SetBinding(TodayCommandParameterProperty, new Binding("DateTime", source: this));

            SelectedCommand = UpdateCalendarDateSelectionCommand;
            SetBinding(SelectedCommandParameterProperty, new Binding("DateTime", source: this));

            InitializeComponent();
        }
        #endregion

        #region Methods
        private void Calendar_DaysUpdated(object sender, EventArgs e)
        {
            UpdateProperties();
            EvaluateDayState();
        }
        public virtual void UpdateProperties()
        {
            IsCurrentMonth = DateTime != null && IsDateTimeCurrentMonth(DateTime.Value);
            IsInvalid = DateTime != null && IsDateTimeInvalid(DateTime.Value);
            IsSelected = DateTime != null && IsDateTimeSelected(DateTime.Value);
            IsToday = DateTime != null && IsDateTimeToday(DateTime.Value);
        }
        public virtual void EvaluateDayState()
        {
            bool IsOtherMonth = !IsCurrentMonth;

            if (IsInvalid)
            {
                DayState = DayState.Invalid;
                BackgroundColor = InvalidBackgroundColor;
                BorderColor = InvalidBorderColor;
                TextColor = InvalidTextColor;
                Command = InvalidCommand;
                CommandParameter = InvalidCommandParameter;
            }
            else if (IsSelected && IsCurrentMonth)
            {
                DayState = DayState.Selected;
                BackgroundColor = SelectedBackgroundColor;
                BorderColor = SelectedBorderColor;
                TextColor = SelectedTextColor;
                Command = SelectedCommand;
                CommandParameter = SelectedCommandParameter;
            }
            else if (IsToday && IsCurrentMonth)
            {
                DayState = DayState.Today;
                BackgroundColor = TodayBackgroundColor;
                BorderColor = TodayBorderColor;
                TextColor = TodayTextColor;
                Command = TodayCommand;
                CommandParameter = TodayCommandParameter;
            }
            else if (IsOtherMonth)
            {
                DayState = DayState.OtherMonth;
                BackgroundColor = OtherMonthBackgroundColor;
                BorderColor = OtherMonthBorderColor;
                TextColor = OtherMonthTextColor;
                Command = OtherMonthCommand;
                CommandParameter = OtherMonthCommandParameter;
            }
            else if (IsCurrentMonth)
            {
                DayState = DayState.CurrentMonth;
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
            return DateTime.Month == Calendar?.NavigatedDate.Month && DateTime.Year == Calendar?.NavigatedDate.Year;
        }
        public virtual bool IsDateTimeInvalid(DateTime DateTime)
        {
            return DateTime.Date < Calendar?.NavigationLowerBound.Date || DateTime.Date > Calendar?.NavigationUpperBound.Date;
        }
        public virtual bool IsDateTimeToday(DateTime DateTime)
        {
            return DateTime.Date == Calendar?.TodayDate.Date;
        }
        public virtual bool IsDateTimeSelected(DateTime DateTime)
        {
            return Calendar?.SelectedDates.Any(x => x.Date == DateTime.Date) == true;
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            UpdateProperties();
            EvaluateDayState();
        }
        private static void DayStatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarDayView Control = (CalendarDayView)bindable;
            DayState NewDayState = (DayState)newValue;

            Control.IsDayStateCurrentMonth = NewDayState == DayState.CurrentMonth;
            Control.IsDayStateOtherMonth = NewDayState == DayState.OtherMonth;
            Control.IsDayStateToday = NewDayState == DayState.Today;
            Control.IsDayStateSelected = NewDayState == DayState.Selected;
            Control.IsDayStateInvalid = NewDayState == DayState.Invalid;
        }

        #region Bindable Properties Methods
        private static void CalendarPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarDayView Control = (CalendarDayView)bindable;
            Calendar OldCalendar = (Calendar)oldValue;
            Calendar NewCalendar = (Calendar)newValue;

            if (OldCalendar != null) { OldCalendar.DaysUpdated -= Control.Calendar_DaysUpdated; }
            if (NewCalendar != null) { NewCalendar.DaysUpdated += Control.Calendar_DaysUpdated; }

            Control.UpdateProperties();
            Control.EvaluateDayState();
        }
        #endregion

        #endregion
    }
}