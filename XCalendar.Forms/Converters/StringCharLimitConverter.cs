using System;
using System.Globalization;
using Xamarin.Forms;
using XCalendar.Core.Extensions;

namespace XCalendar.Forms.Converters
{
    public class StringCharLimitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?
                .ToString()
                .TruncateStringToMaxLength(parameter) ?? string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
