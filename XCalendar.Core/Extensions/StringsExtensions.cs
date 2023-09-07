namespace XCalendar.Core.Extensions
{
    public static class StringsExtensions
    {
        public static string TruncateStringToMaxLength(this string value, object parameter)
        {
            int maxLength = 0;

            bool parameterIsNotNullAndIsAInt = parameter != null && int.TryParse(parameter.ToString(), out maxLength);

            if (parameterIsNotNullAndIsAInt)
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

        public static string UppercaseFirst(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            return char.ToUpper(text[0]) + text.Substring(1);
        }
    }
}
