using System.Windows.Input;
using XCalendar.Core.Interfaces;

namespace XCalendar.Maui.Views
{
    public partial class CalendarView : ContentView
    {
        #region Properties

        #region Bindable Properties
        public DateTime NavigatedDate
        {
            get { return (DateTime)GetValue(NavigatedDateProperty); }
            set { SetValue(NavigatedDateProperty, value); }
        }
        public IEnumerable<object> Days
        {
            get { return (IEnumerable<object>)GetValue(DaysProperty); }
            set { SetValue(DaysProperty, value); }
        }
        public IList<DayOfWeek> DaysOfWeek
        {
            get { return (IList<DayOfWeek>)GetValue(DaysOfWeekProperty); }
            set { SetValue(DaysOfWeekProperty, value); }
        }
        public ICommand RightArrowCommand
        {
            get { return (ICommand)GetValue(RightArrowCommandProperty); }
            set { SetValue(RightArrowCommandProperty, value); }
        }
        public object RightArrowCommandParameter
        {
            get { return (object)GetValue(RightArrowCommandParameterProperty); }
            set { SetValue(RightArrowCommandParameterProperty, value); }
        }
        public ICommand LeftArrowCommand
        {
            get { return (ICommand)GetValue(LeftArrowCommandProperty); }
            set { SetValue(LeftArrowCommandProperty, value); }
        }
        public object LeftArrowCommandParameter
        {
            get { return (object)GetValue(LeftArrowCommandParameterProperty); }
            set { SetValue(LeftArrowCommandParameterProperty, value); }
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
        /// <summary>
        /// The template used to display the <see cref="Days"/>.
        /// </summary>
        public ControlTemplate DaysViewTemplate
        {
            get { return (ControlTemplate)GetValue(DaysViewTemplateProperty); }
            set { SetValue(DaysViewTemplateProperty, value); }
        }
        /// <summary>
        /// The height of the view used to display the <see cref="Days"/>
        /// </summary>
        public double DaysViewHeightRequest
        {
            get { return (double)GetValue(DaysViewHeightRequestProperty); }
            set { SetValue(DaysViewHeightRequestProperty, value); }
        }
        /// <summary>
        /// The template used to display the view for navigating the calendar.
        /// </summary>
        public ControlTemplate NavigationViewTemplate
        {
            get { return (ControlTemplate)GetValue(NavigationViewTemplateProperty); }
            set { SetValue(NavigationViewTemplateProperty, value); }
        }
        /// <summary>
        /// The template used to display a <see cref="ICalendarDay"/>
        /// </summary>
        public DataTemplate DayTemplate
        {
            get { return (DataTemplate)GetValue(DayTemplateProperty); }
            set { SetValue(DayTemplateProperty, value); }
        }

        #region Bindable Properties Initialisers
        public static readonly BindableProperty NavigatedDateProperty = BindableProperty.Create(nameof(NavigatedDate), typeof(DateTime), typeof(CalendarView), DateTime.Today);
        public static readonly BindableProperty DaysProperty = BindableProperty.Create(nameof(DaysProperty), typeof(IEnumerable<object>), typeof(CalendarView), propertyChanged: DaysPropertyChanged);
        public static readonly BindableProperty DaysOfWeekProperty = BindableProperty.Create(nameof(DaysOfWeek), typeof(IList<DayOfWeek>), typeof(CalendarView), propertyChanged: DaysOfWeekPropertyChanged);
        public static readonly BindableProperty RightArrowCommandProperty = BindableProperty.Create(nameof(RightArrowCommand), typeof(object), typeof(CalendarView));
        public static readonly BindableProperty RightArrowCommandParameterProperty = BindableProperty.Create(nameof(RightArrowCommandParameter), typeof(object), typeof(CalendarView));
        public static readonly BindableProperty LeftArrowCommandProperty = BindableProperty.Create(nameof(LeftArrowCommand), typeof(object), typeof(CalendarView));
        public static readonly BindableProperty LeftArrowCommandParameterProperty = BindableProperty.Create(nameof(LeftArrowCommandParameter), typeof(object), typeof(CalendarView));
        public static readonly BindableProperty DayTemplateProperty = BindableProperty.Create(nameof(DayTemplate), typeof(DataTemplate), typeof(CalendarView));
        public static readonly BindableProperty DayNamesTemplateProperty = BindableProperty.Create(nameof(DayNamesTemplate), typeof(ControlTemplate), typeof(CalendarView));
        public static readonly BindableProperty DayNamesHeightRequestProperty = BindableProperty.Create(nameof(DayNamesHeightRequest), typeof(double), typeof(CalendarView), 25d);
        public static readonly BindableProperty DayNameTemplateProperty = BindableProperty.Create(nameof(DayNameTemplate), typeof(DataTemplate), typeof(CalendarView));
        public static readonly BindableProperty DayNameVerticalSpacingProperty = BindableProperty.Create(nameof(DayNameVerticalSpacing), typeof(double), typeof(CalendarView));
        public static readonly BindableProperty DayNameHorizontalSpacingProperty = BindableProperty.Create(nameof(DayNameHorizontalSpacing), typeof(double), typeof(CalendarView));
        public static readonly BindableProperty DaysViewTemplateProperty = BindableProperty.Create(nameof(DaysViewTemplate), typeof(ControlTemplate), typeof(CalendarView));
        public static readonly BindableProperty DaysViewHeightRequestProperty = BindableProperty.Create(nameof(DaysViewHeightRequest), typeof(double), typeof(CalendarView), 300d);
        public static readonly BindableProperty NavigationViewTemplateProperty = BindableProperty.Create(nameof(NavigationViewTemplate), typeof(ControlTemplate), typeof(CalendarView));
        #endregion

        #endregion

        #endregion

        #region Constructors
        public CalendarView()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods

        #region Bindable Properties Methods
        private static void DaysPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView control = (CalendarView)bindable;
            IEnumerable<object> newDays = (IEnumerable<object>)newValue;

            control.MainDaysView.Days = newDays;
        }
        private static void DaysOfWeekPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarView control = (CalendarView)bindable;
            IList<DayOfWeek> newDaysOfWeek = (IList<DayOfWeek>)newValue;

            control.MainDaysOfWeekView.ItemsSource = newDaysOfWeek;
        }
        #endregion

        #endregion
    }
}