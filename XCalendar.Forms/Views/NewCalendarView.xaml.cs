using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCalendar.Core.Interfaces;

namespace XCalendar.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCalendarView : ContentView
    {
        #region Properties

        #region Bindable Properties
        public DateTime NavigatedDate
        {
            get { return (DateTime)GetValue(NavigatedDateProperty); }
            set { SetValue(NavigatedDateProperty, value); }
        }
        public IEnumerable<ICalendarDay> Days
        {
            get { return (IEnumerable<ICalendarDay>)GetValue(DaysProperty); }
            set { SetValue(DaysProperty, value); }
        }
        public IList<DayOfWeek> DaysOfWeek
        {
            get { return (IList<DayOfWeek>)GetValue(DaysOfWeekProperty); }
            set { SetValue(DaysOfWeekProperty, value); }
        }
        public ICommand ForwardsArrowCommand
        {
            get { return (ICommand)GetValue(ForwardsArrowCommandProperty); }
            set { SetValue(ForwardsArrowCommandProperty, value); }
        }
        public object ForwardsArrowCommandParameter
        {
            get { return (object)GetValue(ForwardsArrowCommandParameterProperty); }
            set { SetValue(ForwardsArrowCommandParameterProperty, value); }
        }
        public ICommand BackwardsArrowCommand
        {
            get { return (ICommand)GetValue(BackwardsArrowCommandProperty); }
            set { SetValue(BackwardsArrowCommandProperty, value); }
        }
        public object BackwardsArrowCommandParameter
        {
            get { return (object)GetValue(BackwardsArrowCommandParameterProperty); }
            set { SetValue(BackwardsArrowCommandParameterProperty, value); }
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
        public ControlTemplate DayTemplate
        {
            get { return (ControlTemplate)GetValue(DayTemplateProperty); }
            set { SetValue(DayTemplateProperty, value); }
        }

        #region Bindable Properties Initialisers
        public static readonly BindableProperty NavigatedDateProperty = BindableProperty.Create(nameof(NavigatedDate), typeof(DateTime), typeof(NewCalendarView), DateTime.Today);
        public static readonly BindableProperty DaysProperty = BindableProperty.Create(nameof(DaysProperty), typeof(IEnumerable<ICalendarDay>), typeof(NewCalendarView), propertyChanged: DaysPropertyChanged);
        public static readonly BindableProperty DaysOfWeekProperty = BindableProperty.Create(nameof(DaysOfWeek), typeof(IList<DayOfWeek>), typeof(NewCalendarView), propertyChanged: DaysOfWeekPropertyChanged);
        public static readonly BindableProperty ForwardsArrowCommandProperty = BindableProperty.Create(nameof(ForwardsArrowCommand), typeof(object), typeof(NewCalendarView));
        public static readonly BindableProperty ForwardsArrowCommandParameterProperty = BindableProperty.Create(nameof(ForwardsArrowCommandParameter), typeof(object), typeof(NewCalendarView));
        public static readonly BindableProperty BackwardsArrowCommandProperty = BindableProperty.Create(nameof(BackwardsArrowCommand), typeof(object), typeof(NewCalendarView));
        public static readonly BindableProperty BackwardsArrowCommandParameterProperty = BindableProperty.Create(nameof(BackwardsArrowCommandParameter), typeof(object), typeof(NewCalendarView));
        public static readonly BindableProperty DayTemplateProperty = BindableProperty.Create(nameof(DayTemplate), typeof(ControlTemplate), typeof(NewCalendarView));
        public static readonly BindableProperty DayNamesTemplateProperty = BindableProperty.Create(nameof(DayNamesTemplate), typeof(ControlTemplate), typeof(NewCalendarView));
        public static readonly BindableProperty DayNamesHeightRequestProperty = BindableProperty.Create(nameof(DayNamesHeightRequest), typeof(double), typeof(NewCalendarView), 25d);
        public static readonly BindableProperty DayNameTemplateProperty = BindableProperty.Create(nameof(DayNameTemplate), typeof(DataTemplate), typeof(NewCalendarView));
        public static readonly BindableProperty DayNameVerticalSpacingProperty = BindableProperty.Create(nameof(DayNameVerticalSpacing), typeof(double), typeof(NewCalendarView));
        public static readonly BindableProperty DayNameHorizontalSpacingProperty = BindableProperty.Create(nameof(DayNameHorizontalSpacing), typeof(double), typeof(NewCalendarView));
        public static readonly BindableProperty DaysViewTemplateProperty = BindableProperty.Create(nameof(DaysViewTemplate), typeof(ControlTemplate), typeof(NewCalendarView));
        public static readonly BindableProperty DaysViewHeightRequestProperty = BindableProperty.Create(nameof(DaysViewHeightRequest), typeof(double), typeof(NewCalendarView), 300d);
        public static readonly BindableProperty NavigationViewTemplateProperty = BindableProperty.Create(nameof(NavigationViewTemplate), typeof(ControlTemplate), typeof(NewCalendarView));
        #endregion

        #endregion

        #endregion

        #region Constructors
        public NewCalendarView()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods

        #region Bindable Properties Methods
        private static void DaysPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NewCalendarView Control = (NewCalendarView)bindable;
            IEnumerable<ICalendarDay> NewDays = (IEnumerable<ICalendarDay>)newValue;

            Control.MainDaysView.Days = NewDays;
        }
        private static void DaysOfWeekPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NewCalendarView Control = (NewCalendarView)bindable;
            IList<DayOfWeek> NewDaysOfWeek = (IList<DayOfWeek>)newValue;

            Control.MainDaysOfWeekView.ItemsSource = NewDaysOfWeek;
        }
        #endregion

        #endregion
    }
}