using System;
using System.Globalization;
using Xamarin.Forms;

namespace XCalendar.Forms.Converters
{
    public class EnumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return Enum.GetName(value.GetType(), value);
            }

            catch
            {
                return value?.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
