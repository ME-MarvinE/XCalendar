namespace XCalendar.Maui.Converters;
using System.Globalization;
using CommunityToolkit.Maui.Converters;

public class EnumToStringConverter : BaseConverter<object, string, int?>
{
    public override object ConvertBackTo(string value, int? parameter, CultureInfo culture)
    {
        return Core.Converters.EnumToStringConverter.ConvertBack(value, parameter);
    }

    public override string ConvertFrom(object value, int? parameter, CultureInfo culture)
    {
        return Core.Converters.EnumToStringConverter.Convert(value);
    }
}
