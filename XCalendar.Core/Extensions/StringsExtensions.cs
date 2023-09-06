namespace XCalendar.Core.Extensions
{
    public static class StringsExtensions
    {
        public static string TruncateStringToMaxLength(this string value, object parameter)
        {
            if (parameter != null && int.TryParse(parameter.ToString(), out int maxLength))
            {
                return value.TruncateStringToMaxLength(maxLength);
            }

            return string.Empty;
        }

        public static string TruncateStringToMaxLength(this string value, int maxLength)
        {
            if (value == null)
            {
                return string.Empty;
            }

            if (maxLength <= 0)
            {
                return string.Empty;
            }
            else if (maxLength >= value.Length)
            {
                return value;
            }
            else
            {
                return value.Substring(0, maxLength);
            }
        }
    }
}
