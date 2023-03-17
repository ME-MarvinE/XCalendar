using System.Globalization;

namespace XCalendar.Maui.Converters
{
    public class StringCharLimitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value == null) {
                    return null;
                }

                string stringValue = value?.ToString() ?? string.Empty;
                int targetLength = System.Convert.ToInt32(parameter);

                if (targetLength == 0)
                {
                    return "";
                }
                else if (targetLength >= stringValue.Length)
                {
                    return stringValue;
                }
                else
                {
                    return stringValue.Substring(0, targetLength);
                }
            }
            catch
            {
                return "";
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}

