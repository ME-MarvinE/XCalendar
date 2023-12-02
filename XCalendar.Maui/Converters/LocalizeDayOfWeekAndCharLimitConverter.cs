﻿using System.Globalization;
using XCalendar.Core.Extensions;

namespace XCalendar.Maui.Converters
{
    public class LocalizeDayOfWeekAndCharLimitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DayOfWeek dayOfWeek))
            {
                return string.Empty;
            }

            return culture.DateTimeFormat
                .GetDayName(dayOfWeek)
                .TruncateStringToMaxLength(parameter)
                .ToTitleCase(culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
