using FluentAssertions;
using Xunit;
using XCalendar.Core.Extensions;

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
        public void UppercaseFirstShouldReturnStringWithFirstLetterUppercased(string input, string expectedOutput)
        {
            var result = input.UppercaseFirst();

            result.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData("Hello", "Hello")]
        [InlineData("WOrld", "WOrld")]
        [InlineData("123abc", "123abc")]
        public void UppercaseFirstShouldNotChangeStringStartingWithUppercaseLetter(string input, string expectedOutput)
        {
            var result = input.UppercaseFirst();

            result.Should().Be(expectedOutput);
        }
    }
}
