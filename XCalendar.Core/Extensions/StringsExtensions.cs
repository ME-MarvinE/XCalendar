using System;
using System.Collections.Generic;
using System.Text;

namespace XCalendar.Core.Extensions
{
    public static class StringsExtensions
    {
        public static string TruncateStringToMaxLength(this string value, object parameter)
        {
            try
            {
                string stringValue = value.ToString();

                if (!int.TryParse(parameter.ToString(), out int maxLength))
                {
                    return string.Empty;
                }

                if (maxLength == 0)
                {
                    return string.Empty;
                }
                else if (maxLength >= stringValue.Length)
                {
                    return stringValue;
                }
                else
                {
                    return stringValue.Substring(0, maxLength);
                }
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
