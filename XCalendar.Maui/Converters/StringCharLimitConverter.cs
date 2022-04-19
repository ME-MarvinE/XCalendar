namespace XCalendar.Maui.Converters;
using System.Globalization;
using CommunityToolkit.Maui.Converters;

public class StringCharLimitConverter : BaseConverterOneWay<string, string, int>
{
    public override string ConvertFrom(string value, int parameter, CultureInfo culture)
    {
        return Core.Converters.StringCharLimitConverter.Convert(value, parameter);
    }
}

