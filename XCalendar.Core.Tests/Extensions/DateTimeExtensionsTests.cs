using System;
using System.Globalization;
using XCalendar.Core.Extensions;
using Xunit;

namespace XCalendar.Core.Tests.Extensions
{
    public class DateTimeExtensionsTests
    {
        [Theory]
        [InlineData(2023, 9, 15, 2023, 9, 29)]
        [InlineData(2024, 1, 7, 2024, 1, 21)]
        [InlineData(2022, 12, 25, 2023, 1, 8)]
        public void AddWeeksShouldReturnCorrectDate(
            int year, int month, int day, 
            int expectedYear, int expectedMonth, int expectedDay)
        {
            var date = new DateTime(year, month, day);

            var result = date.AddWeeks(2);

            Assert.Equal(new DateTime(expectedYear, expectedMonth, expectedDay), result);
        }

        [Theory]
        [InlineData(2023, 9, 15, 2023, 9, 29)]
        [InlineData(2024, 1, 7, 2024, 1, 21)]
        [InlineData(2022, 12, 25, 2023, 1, 8)]
        public void TryAddWeeksShouldReturnTrue(
            int year, int month, int day,
            int expectedYear, int expectedMonth, int expectedDay)
        {
            var date = new DateTime(year, month, day);

            var success = date.TryAddWeeks(2, out DateTime result);

            Assert.True(success);
            Assert.Equal(new DateTime(expectedYear, expectedMonth, expectedDay), result);
        }

        [Theory]
        [InlineData(2023, 9, 15, DayOfWeek.Sunday, 2023, 9, 10)]
        [InlineData(2024, 1, 7, DayOfWeek.Sunday, 2024, 1, 7)]
        [InlineData(2022, 12, 25, DayOfWeek.Sunday, 2022, 12, 25)]
        public void FirstDayOfWeekShouldReturnCorrectDate(
            int year, int month, int day, DayOfWeek dayOfWeek,
            int expectedYear, int expectedMonth, int expectedDay)
        {
            var date = new DateTime(year, month, day);

            var result = date.FirstDayOfWeek(dayOfWeek);

            Assert.Equal(new DateTime(expectedYear, expectedMonth, expectedDay), result);
        }

        [Theory]
        [InlineData(2023, 9, 15, DayOfWeek.Sunday, 2023, 9, 16)]
        [InlineData(2024, 1, 7, DayOfWeek.Sunday, 2024, 1, 13)]
        [InlineData(2022, 12, 25, DayOfWeek.Sunday, 2022, 12, 31)]
        public void LastDayOfWeekShouldReturnCorrectDate(
            int year, int month, int day, DayOfWeek dayOfWeek,
            int expectedYear, int expectedMonth, int expectedDay)
        {
            var date = new DateTime(year, month, day);

            var result = date.LastDayOfWeek(dayOfWeek);

            Assert.Equal(new DateTime(expectedYear, expectedMonth, expectedDay), result);
        }

        [Theory]
        [InlineData(2023, 9, 15, DayOfWeek.Sunday, 3)]
        [InlineData(2024, 1, 7, DayOfWeek.Sunday, 2)]
        [InlineData(2022, 12, 25, DayOfWeek.Sunday, 5)]
        public void CalendarWeekOfMonthShouldReturnCorrectWeek(int year, int month, int day, DayOfWeek dayOfWeek, int expectedWeekOfMonth)
        {
            var date = new DateTime(year, month, day);

            var result = date.CalendarWeekOfMonth(dayOfWeek);

            Assert.Equal(expectedWeekOfMonth, result);
        }
    }
}
