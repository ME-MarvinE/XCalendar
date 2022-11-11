using System.Collections;
using System.Collections.Specialized;
using XCalendar.Core.Interfaces;

namespace XCalendar.Maui.Views
{
    public partial class NewDaysView : ContentView
    {

        #region Fields
        private ControlTemplate _DefaultDayTemplate;
        #endregion

        #region Properties

        #region Bindable Properties
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
        public ControlTemplate DayTemplate
        {
            get { return (ControlTemplate)GetValue(DayTemplateProperty); }
            set { SetValue(DayTemplateProperty, value); }
        }
        public GridLength ColumnWidth
        {
            get { return (GridLength)GetValue(ColumnWidthProperty); }
            set { SetValue(ColumnWidthProperty, value); }
        }
        public GridLength RowHeight
        {
            get { return (GridLength)GetValue(RowHeightProperty); }
            set { SetValue(RowHeightProperty, value); }
        }

        #region Bindable Properties Initialisers
        public static readonly BindableProperty DaysProperty = BindableProperty.Create(nameof(DaysProperty), typeof(IEnumerable<ICalendarDay>), typeof(NewDaysView), propertyChanged: DaysPropertyChanged);
        public static readonly BindableProperty DaysOfWeekProperty = BindableProperty.Create(nameof(DaysOfWeek), typeof(IList<DayOfWeek>), typeof(NewDaysView), propertyChanged: DaysOfWeekPropertyChanged);
        public static readonly BindableProperty DayTemplateProperty = BindableProperty.Create(nameof(DayTemplate), typeof(ControlTemplate), typeof(NewDaysView), propertyChanged: DayTemplatePropertyChanged);
        public static readonly BindableProperty ColumnWidthProperty = BindableProperty.Create(nameof(ColumnWidth), typeof(GridLength), typeof(NewDaysView), GridLength.Star);
        public static readonly BindableProperty RowHeightProperty = BindableProperty.Create(nameof(RowHeight), typeof(GridLength), typeof(NewDaysView), GridLength.Star);
        #endregion

        #endregion

        #endregion

        #region Constructors
        public NewDaysView()
        {
            InitializeComponent();
            _DefaultDayTemplate = (ControlTemplate)Resources["DefaultDayTemplate"];
        }
        #endregion

        #region Methods

        public void UpdateDaysGrid()
        {
            if (Days == null || DaysOfWeek == null)
            {
                DaysGrid.Children.Clear();
            }
            else
            {
                IList DaysList = Days as IList;

                if (DaysList == null)
                {
                    DaysList = Days.ToList();
                }

                int RequiredColumnDefinitionCount = DaysOfWeek.Count;
                int RequiredRowDefinitionCount = (int)Math.Ceiling(DaysList.Count / (double)RequiredColumnDefinitionCount);
                int RequiredAmountOfChildren = DaysList.Count;
                bool ColumnDefinitionsChanged = false;
                bool RowDefinitionsChanged = false;



                //Add the required amount of columns to support the amount of days.
                while (DaysGrid.ColumnDefinitions.Count != RequiredColumnDefinitionCount)
                {
                    if (DaysGrid.ColumnDefinitions.Count > RequiredColumnDefinitionCount)
                    {
                        DaysGrid.ColumnDefinitions.RemoveAt(DaysGrid.ColumnDefinitions.Count - 1);
                    }
                    else
                    {
                        DaysGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = ColumnWidth });
                    }

                    ColumnDefinitionsChanged = true;
                }

                //Add the required amount of rows to support the amount of days.
                while (DaysGrid.RowDefinitions.Count != RequiredRowDefinitionCount)
                {
                    if (DaysGrid.RowDefinitions.Count > RequiredRowDefinitionCount)
                    {
                        DaysGrid.RowDefinitions.RemoveAt(DaysGrid.RowDefinitions.Count - 1);
                    }
                    else
                    {
                        DaysGrid.RowDefinitions.Add(new RowDefinition() { Height = RowHeight });
                    }

                    RowDefinitionsChanged = true;
                }

                //Remove the amount of views not needed for representing all days.
                while (DaysGrid.Children.Count > RequiredAmountOfChildren)
                {
                    DaysGrid.Children.RemoveAt(DaysGrid.Children.Count - 1);
                }

                //Add the amount of views needed to represent all days.
                while (DaysGrid.Children.Count < RequiredAmountOfChildren)
                {
                    View LastChild = DaysGrid.Children.Count == 0 ? null : (View)DaysGrid.Children[DaysGrid.Children.Count - 1];

                    int NewChildColumnIndex;
                    int NewChildRowIndex;

                    if (LastChild == null)
                    {
                        NewChildColumnIndex = 0;
                        NewChildRowIndex = 0;
                    }
                    else
                    {
                        int LastChildColumnIndex = Grid.GetColumn(LastChild);
                        int LastChildRowIndex = Grid.GetRow(LastChild);

                        if (LastChildColumnIndex == DaysGrid.ColumnDefinitions.Count - 1)
                        {
                            NewChildColumnIndex = 0;
                            NewChildRowIndex = LastChildRowIndex + 1;
                        }
                        else
                        {
                            NewChildColumnIndex = LastChildColumnIndex + 1;
                            NewChildRowIndex = LastChildRowIndex;
                        }
                    }

                    ContentView NewChild = new ContentView { ControlTemplate = DayTemplate ?? _DefaultDayTemplate };

                    Grid.SetColumn(NewChild, NewChildColumnIndex);
                    Grid.SetRow(NewChild, NewChildRowIndex);

                    DaysGrid.Children.Add(NewChild);
                }

                //Update the views' BindingContext so they can represent the collection of days.
                for (int i = 0; i < DaysGrid.Children.Count; i++)
                {
                    ContentView Child = (ContentView)DaysGrid.Children[i];
                    int NewChildColumnIndex = i % RequiredColumnDefinitionCount;
                    int NewChildRowIndex = (int)Math.Floor(i / (double)RequiredColumnDefinitionCount);

                    Grid.SetColumn(Child, NewChildColumnIndex);
                    Grid.SetRow(Child, NewChildRowIndex);

                    Child.BindingContext = DaysList[i];
                }
            }
        }

        private void Days_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateDaysGrid();
        }
        private void DaysOfWeek_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateDaysGrid();
        }

        #region Bindable Properties Methods
        private static void DaysPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NewDaysView Control = (NewDaysView)bindable;

            if (oldValue != null && oldValue is INotifyCollectionChanged ObservableOldDays)
            {
                ObservableOldDays.CollectionChanged -= Control.Days_CollectionChanged;
            }

            if (newValue is INotifyCollectionChanged ObservableNewDays)
            {
                ObservableNewDays.CollectionChanged += Control.Days_CollectionChanged;
            }

            Control.UpdateDaysGrid();
        }
        private static void DaysOfWeekPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NewDaysView Control = (NewDaysView)bindable;

            if (oldValue is INotifyCollectionChanged ObservableOldDaysOfWeek)
            {
                ObservableOldDaysOfWeek.CollectionChanged -= Control.DaysOfWeek_CollectionChanged; ;
            }

            if (newValue is INotifyCollectionChanged ObservableNewDaysOfWeek)
            {
                ObservableNewDaysOfWeek.CollectionChanged += Control.DaysOfWeek_CollectionChanged;
            }

            Control.UpdateDaysGrid();
        }
        private static void DayTemplatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NewDaysView Control = (NewDaysView)bindable;

            ControlTemplate NewDayTemplate = (ControlTemplate)newValue;

            for (int i = 0; i < Control.DaysGrid.Children.Count; i++)
            {
                ContentView Child = (ContentView)Control.DaysGrid.Children[i];

                Child.ControlTemplate = NewDayTemplate ?? Control._DefaultDayTemplate;
            }
        }
        #endregion

        #endregion
    }
}