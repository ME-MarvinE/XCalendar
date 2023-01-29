using CommunityToolkit.Maui.Converters;
using System.Globalization;

namespace XCalendar.Maui.Converters
{
    public class StringCharLimitConverter : BaseConverterOneWay<object, string, object>
    {
        private string _defaultConvertReturnValue = "";
        public override string DefaultConvertReturnValue
        {
            get
            {
                return _defaultConvertReturnValue;
            }
            set
            {
                _defaultConvertReturnValue = value;
            }
        }
        public override string ConvertFrom(object value, object parameter, CultureInfo culture)
        {
            try
            {
                string stringValue = value.ToString();
                int targetLength = Convert.ToInt32(parameter);

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
                return DefaultConvertReturnValue;
            }
        }
    }
}

