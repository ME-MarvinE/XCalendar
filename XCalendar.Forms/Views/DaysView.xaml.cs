using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XCalendar.Core.Interfaces;

namespace XCalendar.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DaysView : ContentView
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
        /// <summary>
        /// The template used to display a <see cref="ICalendarDay"/>
        /// </summary>
        public DataTemplate DayTemplate
        {
            get { return (DataTemplate)GetValue(DayTemplateProperty); }
            set { SetValue(DayTemplateProperty, value); }
        }

        #region Bindable Properties Initialisers
        public static readonly BindableProperty NavigatedDateProperty = BindableProperty.Create(nameof(NavigatedDate), typeof(DateTime), typeof(DaysView), DateTime.Today);
        public static readonly BindableProperty DaysProperty = BindableProperty.Create(nameof(DaysProperty), typeof(IEnumerable<ICalendarDay>), typeof(DaysView), propertyChanged: DaysPropertyChanged);
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
            DaysView Control = (DaysView)bindable;
            IEnumerable<ICalendarDay> NewDays = (IEnumerable<ICalendarDay>)newValue;

            Control.MainCollectionView.ItemsSource = NewDays;
        }
        #endregion

        #endregion
    }
}