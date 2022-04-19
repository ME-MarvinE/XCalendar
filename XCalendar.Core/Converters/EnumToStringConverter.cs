using System;

namespace XCalendar.Core.Converters
{
    public static class EnumToStringConverter
    {
        public static string Convert(object value)
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

        public static object ConvertBack(object value, object parameter)
        {
            return Enum.Parse(Type.GetType((string)parameter, true), (string)value);
        }
    }
}
