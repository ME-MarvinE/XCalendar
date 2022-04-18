using System;
using System.Globalization;
using Xamarin.Forms;

namespace XCalendar.Forms.Converters
{
    public class EnumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Core.Converters.EnumToStringConverter.Convert(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Core.Converters.EnumToStringConverter.ConvertBack(value, parameter);
        }
    }
}
