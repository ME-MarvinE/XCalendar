using System;
using System.Windows.Input;
using XCalendar.Core.Interfaces;
using XCalendar.Core.Models;

namespace XCalendar.Maui.Views
{
    public partial class CalendarView : ContentView
    {
        #region Properties

        #region Bindable Properties
        public Calendar Calendar
        {
            get { return (Calendar)GetValue(CalendarProperty); }
            set { SetValue(CalendarProperty, value); }
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
        /// The template used to display a <see cref="ICalendarDay"/>
        /// </summary>
        public DataTemplate DayTemplate
        {
            get { return (DataTemplate)GetValue(DayTemplateProperty); }
            set { SetValue(DayTemplateProperty, value); }
        }
        /// <summary>
        /// The height of the view used to display the navigated date and navigation controls.
        /// </summary>
        public double NavigationHeightRequest
        {
            get { return (double)GetValue(NavigationHeightRequestProperty); }
            set { SetValue(NavigationHeightRequestProperty, value); }
        }
        public Color NavigationBackgroundColor
        {
            get { return (Color)GetValue(NavigationBackgroundColorProperty); }
            set { SetValue(NavigationBackgroundColorProperty, value); }
        }

        #region Bindable Properties Initialisers
        public static readonly BindableProperty CalendarProperty = BindableProperty.Create(nameof(Calendar), typeof(Calendar), typeof(CalendarView), new Calendar());
        public static readonly BindableProperty DayTemplateProperty = BindableProperty.Create(nameof(DayTemplate), typeof(DataTemplate), typeof(CalendarView));
        public static readonly BindableProperty DayNameTextColorProperty = BindableProperty.Create(nameof(DayNameTextColor), typeof(Color), typeof(CalendarView), Colors.Black);
        public static readonly BindableProperty DayNamesTemplateProperty = BindableProperty.Create(nameof(DayNamesTemplate), typeof(ControlTemplate), typeof(CalendarView));
        public static readonly BindableProperty DayNamesHeightRequestProperty = BindableProperty.Create(nameof(DayNamesHeightRequest), typeof(double), typeof(CalendarView), 25d);
        public static readonly BindableProperty DayNameTemplateProperty = BindableProperty.Create(nameof(DayNameTemplate), typeof(DataTemplate), typeof(CalendarView));
        public static readonly BindableProperty DayNameVerticalSpacingProperty = BindableProperty.Create(nameof(DayNameVerticalSpacing), typeof(double), typeof(CalendarView));
        public static readonly BindableProperty DayNameHorizontalSpacingProperty = BindableProperty.Create(nameof(DayNameHorizontalSpacing), typeof(double), typeof(CalendarView));
        public static readonly BindableProperty MonthViewTemplateProperty = BindableProperty.Create(nameof(MonthViewTemplate), typeof(ControlTemplate), typeof(CalendarView));
        public static readonly BindableProperty MonthViewHeightRequestProperty = BindableProperty.Create(nameof(MonthViewHeightRequest), typeof(double), typeof(CalendarView), 300d);
        public static readonly BindableProperty NavigationTemplateProperty = BindableProperty.Create(nameof(NavigationTemplate), typeof(ControlTemplate), typeof(CalendarView));
        public static readonly BindableProperty NavigationHeightRequestProperty = BindableProperty.Create(nameof(NavigationHeightRequest), typeof(double), typeof(CalendarView), 40d);
        public static readonly BindableProperty NavigationBackgroundColorProperty = BindableProperty.Create(nameof(NavigationBackgroundColor), typeof(Color), typeof(CalendarView), Color.FromArgb("#E00000"));
        public static readonly BindableProperty NavigationTextColorProperty = BindableProperty.Create(nameof(NavigationTextColor), typeof(Color), typeof(CalendarView), Colors.White);
        public static readonly BindableProperty NavigationArrowColorProperty = BindableProperty.Create(nameof(NavigationArrowColor), typeof(Color), typeof(CalendarView), Colors.White);
        public static readonly BindableProperty NavigationArrowBackgroundColorProperty = BindableProperty.Create(nameof(NavigationArrowBackgroundColor), typeof(Color), typeof(CalendarView), Colors.Transparent);
        public static readonly BindableProperty NavigationArrowCornerRadiusProperty = BindableProperty.Create(nameof(NavigationArrowCornerRadius), typeof(float), typeof(CalendarView), 100f);
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

        #region Constructors
        public CalendarView()
        {
            NavigateCalendarCommand = new Command<int>((Amount) => { Calendar.NavigateCalendar(Amount); });
            ChangeDateSelectionCommand = new Command<DateTime>((DateTime) => { Calendar.ChangeDateSelection(DateTime); });

            InitializeComponent();
        }
        #endregion
    }
}