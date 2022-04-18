namespace XCalendar.Core.Converters
{
    public static class StringCharLimitConverter
    {
        public static object Convert(object value, object parameter)
        {
            try
            {
                string StringValue = (string)value;
                int TargetLength = System.Convert.ToInt32(parameter);

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
                return "";
            }
        }
    }
}
