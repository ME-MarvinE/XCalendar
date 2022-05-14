using System;
using System.Globalization;
using Xamarin.Forms;

namespace XCalendar.Forms.Converters
{
    public class StringCharLimitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string StringValue = (string)value;
                int TargetLength = System.Convert.ToInt32(parameter);

                if (TargetLength == 0)
                {
                    return "";
                }
                else if (TargetLength >= StringValue.Length)
                {
                    return StringValue;
                }
                else
                {
                    return StringValue.Substring(0, TargetLength);
                }
            }
            catch
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
