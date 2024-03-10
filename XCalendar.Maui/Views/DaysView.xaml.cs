using XCalendar.Core.Interfaces;

namespace XCalendar.Maui.Views
{
    public partial class DaysView : ContentView
    {
        #region Properties

        #region Bindable Properties
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
        /// <summary>
        /// The template used to display a <see cref="ICalendarDay"/>
        /// </summary>
        public DataTemplate DayTemplate
        {
            get { return (DataTemplate)GetValue(DayTemplateProperty); }
            set { SetValue(DayTemplateProperty, value); }
        }

        #region Bindable Properties Initialisers
        public static readonly BindableProperty DaysProperty = BindableProperty.Create(nameof(DaysProperty), typeof(IEnumerable<object>), typeof(DaysView), propertyChanged: DaysPropertyChanged);
        public static readonly BindableProperty DaysOfWeekProperty = BindableProperty.Create(nameof(DaysOfWeek), typeof(IList<DayOfWeek>), typeof(DaysView));
        public static readonly BindableProperty DayTemplateProperty = BindableProperty.Create(nameof(DayTemplate), typeof(DataTemplate), typeof(DaysView));
        #endregion

        #endregion

        #endregion

        #region Constructors
        public DaysView()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods

        #region Bindable Properties Methods
        private static void DaysPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DaysView control = (DaysView)bindable;
            IEnumerable<object> newDays = (IEnumerable<object>)newValue;

            control.MainCollectionView.ItemsSource = newDays;
        }
        #endregion

        #endregion
    }
}