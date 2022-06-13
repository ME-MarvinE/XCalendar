using System;
using XCalendar.Core.Models;
using Xunit;

namespace XCalendar.Core.Tests.Models
{
    public class CalendarTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(10)]
        [InlineData(34646)]
        public void SettingRowsChangesRowCount(int Rows)
        {
            var Calendar = new Calendar()
            {
                AutoRows = false
            };

            Calendar.Rows = Rows;

            Assert.Equal(Rows, Calendar.Rows);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-34646)]
        [InlineData(int.MinValue)]
        public void SettingRowsBelow1ThrowsException(int Rows)
        {
            Assert.ThrowsAny<Exception>(() =>
            {
                var Calendar = new Calendar()
                {
                    AutoRows = false
                };

                Calendar.Rows = Rows;
            });
        }
    }
}
