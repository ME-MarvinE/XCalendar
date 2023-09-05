using FluentAssertions;
using Xunit;
using XCalendar.Core.Extensions;

namespace XCalendar.Core.Tests.Models
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
        public void TruncateStringToMaxLengthWithValidInputReturnsTruncatedString(string input, int maxLength, string expected)
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
        [InlineData(null, "5", "")]
        public void TruncateStringToMaxLengthWithInvalidParameterReturnsEmptyString(string input, object maxLength, string expected)
        {
            string result = input.TruncateStringToMaxLength(maxLength);

            result.Should().Be(expected);
        }
    }
}
