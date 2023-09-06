using System;
using System.Globalization;
using Xamarin.Forms;
using XCalendar.Core.Extensions;

namespace XCalendar.Forms.Converters
{
    public class LocalizeDayOfWeekAndCharLimitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DayOfWeek dayOfWeek))
            {
                return string.Empty;
            }

            string dayName = culture.DateTimeFormat.GetDayName(dayOfWeek);

            return dayName.TruncateStringToMaxLength(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
