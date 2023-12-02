using FluentAssertions;
using Xunit;
using XCalendar.Core.Extensions;
using System.Globalization;

namespace XCalendar.Core.Tests.Extensions
{
    public class StringsExtensionsTests
    {
        [Theory]
        [InlineData("Hello, World!", 5, "Hello")]
        [InlineData("Testing", 7, "Testing")]
        [InlineData("12345", 3, "123")]
        [InlineData("Short", 10, "Short")]
        [InlineData("", 5, "")]
        [InlineData(null, 5, "")]
        public void TruncateStringToMaxLengthWithValidInputIntReturnsTruncatedString(string input, int maxLength, string expected)
        {
            string result = input.TruncateStringToMaxLength(maxLength);

            result.Should().Be(expected);
        }
        
        [Theory]
        [InlineData("Hello, World!", "5", "Hello")]
        [InlineData("Testing", "7", "Testing")]
        [InlineData("12345", "3", "123")]
        [InlineData("Short", "10", "Short")]
        [InlineData("", "5", "")]
        [InlineData("Hello, World!", "3", "Hel")]
        [InlineData("Hello, World!", "4", "Hell")]
        public void TruncateStringToMaxLengthWithValidInputObjectReturnsTruncatedString(string input, object maxLength, string expected)
        {
            string result = input.TruncateStringToMaxLength(maxLength);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("Hello, World!", 0, "")]
        [InlineData("Testing", -1, "")]
        [InlineData("12345", 0, "")]
        [InlineData("", 0, "")]
        public void TruncateStringToMaxLengthWithZeroOrNegativeMaxLengthReturnsEmptyString(string input, int maxLength, string expected)
        {
            string result = input.TruncateStringToMaxLength(maxLength);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("Hello, World!", "invalid", "")]
        [InlineData("12345", true, "")]
        [InlineData(null, "5L", "")]
        [InlineData(null, null, "")]
        public void TruncateStringToMaxLengthWithInvalidParameterReturnsEmptyString(string input, object maxLength, string expected)
        {
            string result = input.TruncateStringToMaxLength(maxLength);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("hello", "Hello")]
        [InlineData("world", "World")]
        [InlineData("t", "T")]
        [InlineData("123", "123")]
        [InlineData("", "")]
        [InlineData(null, "")]
        public void ToTitleCaseShouldReturnStringWithFirstLetterUppercased(string input, string expectedOutput)
        {
            var result = input.ToTitleCase(CultureInfo.InvariantCulture);

            result.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData("monday tuesday wednesday thursday friday saturday sunday", "en-US", "Monday Tuesday Wednesday Thursday Friday Saturday Sunday")]
        [InlineData("lundi mardi mercredi jeudi vendredi samedi dimanche", "fr-FR", "Lundi Mardi Mercredi Jeudi Vendredi Samedi Dimanche")]
        [InlineData("lunes martes miércoles jueves viernes sábado domingo", "es-ES", "Lunes Martes Miércoles Jueves Viernes Sábado Domingo")]
        [InlineData("الاثنين الثلاثاء الأربعاء الخميس الجمعة السبت الأحد", "ar-SA", "الاثنين الثلاثاء الأربعاء الخميس الجمعة السبت الأحد")]
        [InlineData("星期一 星期二 星期三 星期四 星期五 星期六 星期日", "zh-CN", "星期一 星期二 星期三 星期四 星期五 星期六 星期日")]
        public void ToTitleCaseShouldConvertToTitleCaseWithDifferentCultures(string input, string cultureName, string expectedOutput)
        {
            CultureInfo culture = new CultureInfo(cultureName);

            string result = input.ToTitleCase(culture);

            result.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData("Hello", "Hello")]
        [InlineData("World", "World")]
        public void ToTitleCaseShouldNotChangeStringStartingWithUppercaseLetter(string input, string expectedOutput)
        {
            var result = input.ToTitleCase(CultureInfo.InvariantCulture);

            result.Should().Be(expectedOutput);
        }
    }
}
