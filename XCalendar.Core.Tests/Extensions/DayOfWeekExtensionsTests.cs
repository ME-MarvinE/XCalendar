using System;
using Xunit;
using XCalendar.Core.Extensions;
using FluentAssertions;

namespace XCalendar.Core.Tests.Extensions
{
    public class DayOfWeekExtensionsTests
    {
        [Theory]
        [InlineData(DayOfWeek.Sunday, new[] { DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday })]
        [InlineData(DayOfWeek.Monday, new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday })]
        [InlineData(DayOfWeek.Tuesday, new[] { DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday, DayOfWeek.Monday })]
        [InlineData(DayOfWeek.Wednesday, new[] { DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday })]
        [InlineData(DayOfWeek.Thursday, new[] { DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday })]
        [InlineData(DayOfWeek.Friday, new[] { DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday })]
        [InlineData(DayOfWeek.Saturday, new[] { DayOfWeek.Saturday, DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday })]
        public void GetWeekAsFirst_Should_Return_Correct_Order(DayOfWeek inputDayOfWeek, DayOfWeek[] expectedOrder)
        {
            // Act
            var week = inputDayOfWeek.GetWeekAsFirst();

            // Assert
            week.Should().ContainInOrder(expectedOrder);
        }

        [Theory]
        [InlineData(DayOfWeek.Sunday, new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday })]
        [InlineData(DayOfWeek.Monday, new[] { DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday })]
        [InlineData(DayOfWeek.Tuesday, new[] { DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday, DayOfWeek.Monday })]
        [InlineData(DayOfWeek.Wednesday, new[] { DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday })]
        [InlineData(DayOfWeek.Thursday, new[] { DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday })]
        [InlineData(DayOfWeek.Friday, new[] { DayOfWeek.Saturday, DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday })]
        [InlineData(DayOfWeek.Saturday, new[] { DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday })]
        public void GetWeekAsLast_Should_Return_Correct_Order(DayOfWeek inputDayOfWeek, DayOfWeek[] expectedOrder)
        {
            // Act
            var week = inputDayOfWeek.GetWeekAsLast();

            // Assert
            week.Should().ContainInOrder(expectedOrder);
        }
    }
}
