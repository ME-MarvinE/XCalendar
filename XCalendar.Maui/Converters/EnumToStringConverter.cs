namespace XCalendar.Maui.Converters;
using System.Globalization;
using CommunityToolkit.Maui.Converters;

public class EnumToStringConverter : BaseConverterOneWay<Enum, string>
{
    public override string ConvertFrom(Enum value, CultureInfo culture)
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
}
