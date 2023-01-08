using CommunityToolkit.Maui.Converters;
using System.Globalization;

namespace XCalendar.Maui.Converters
{
    public class StringCharLimitConverter : BaseConverterOneWay<object, string, object>
    {
        private string _DefaultConvertReturnValue = "";
        public override string DefaultConvertReturnValue
        {
            get
            {
                return _DefaultConvertReturnValue;
            }
            set
            {
                _DefaultConvertReturnValue = value;
            }
        }
        public override string ConvertFrom(object value, object parameter, CultureInfo culture)
        {
            try
            {
                string StringValue = value.ToString();
                int TargetLength = Convert.ToInt32(parameter);

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
                return DefaultConvertReturnValue;
            }
        }
    }
}

