using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using XCalendarMauiSample.Models;

namespace XCalendarMauiSample.Converters
{
    public class EventWhereConverter : BindableObject, IValueConverter
    {
        public IEnumerable<Event> Items
        {
            get { return (IEnumerable<Event>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
        public bool? WhiteList
        {
            get { return (bool?)GetValue(WhiteListProperty); }
            set { SetValue(WhiteListProperty, value); }
        }
        public bool UseDateComponent
        {
            get { return (bool)GetValue(UseDateComponentProperty); }
            set { SetValue(UseDateComponentProperty, value); }
        }
        public bool UseTimeComponent
        {
            get { return (bool)GetValue(UseTimeComponentProperty); }
            set { SetValue(UseTimeComponentProperty, value); }
        }
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(IEnumerable<Event>), typeof(EventWhereConverter));
        public static readonly BindableProperty WhiteListProperty = BindableProperty.Create(nameof(WhiteList), typeof(bool?), typeof(EventWhereConverter), null);
        public static readonly BindableProperty UseDateComponentProperty = BindableProperty.Create(nameof(UseDateComponent), typeof(bool), typeof(EventWhereConverter), true);
        public static readonly BindableProperty UseTimeComponentProperty = BindableProperty.Create(nameof(UseTimeComponent), typeof(bool), typeof(EventWhereConverter), true);
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime? BindingValue = (DateTime?)value;

            if (Items == null) { return Items; }

            List<Event> ItemsList = new List<Event>(Items);

            if (WhiteList == true)
            {
                if (UseDateComponent && UseTimeComponent) { return ItemsList.Where(x => x.DateTime == BindingValue); }
                else if (UseDateComponent) { return ItemsList.Where(x => x?.DateTime.Date == BindingValue?.Date); }
                else if (UseTimeComponent) { return ItemsList.Where(x => x?.DateTime.TimeOfDay == BindingValue?.TimeOfDay); }
            }
            else if (WhiteList == false)
            {
                if (UseDateComponent && UseTimeComponent) { return ItemsList.Where(x => x.DateTime != BindingValue); }
                else if (UseDateComponent) { return ItemsList.Where(x => x?.DateTime.Date != BindingValue?.Date); }
                else if (UseTimeComponent) { return ItemsList.Where(x => x?.DateTime.TimeOfDay != BindingValue?.TimeOfDay); }
            }
            else
            {
                if (UseDateComponent && UseTimeComponent) { return ItemsList; }
                else if (UseDateComponent) { return ItemsList.Select(x => x?.DateTime.Date); }
                else if (UseTimeComponent) { return ItemsList.Select(x => x?.DateTime.TimeOfDay); }
            }
            return new List<DateTime>();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new NotImplementedException();
        }
    }
}
