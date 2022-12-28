namespace XCalendar.Maui.Converters
{
    using System.Globalization;
    using CommunityToolkit.Maui.Converters;

    public class StringCharLimitConverter : BaseConverterOneWay<string, string, int>
    {
        public override string DefaultConvertReturnValue
        {
            get
            {
                return "";
            }
            set
            {
            }
        }
        public override string ConvertFrom(string value, int parameter, CultureInfo culture)
        {
            try
            {
                int TargetLength = parameter;

                if (TargetLength == 0)
                {
                    return "";
                }
                else if (TargetLength >= value.Length)
                {
                    return value;
                }
                else
                {
                    return value.Substring(0, TargetLength);
                }
            }
            catch
            {
                return "";
            }
        }
    }
}

