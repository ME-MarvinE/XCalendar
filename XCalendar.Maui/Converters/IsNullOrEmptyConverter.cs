using System.Globalization;

namespace XCalendar.Maui.Converters
{
    public class IsNullOrEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null || (value is string stringValue && string.IsNullOrWhiteSpace(stringValue));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
