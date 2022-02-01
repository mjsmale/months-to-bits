using System;
using Xunit;

namespace MonthsToBits
{
    public class ArrayInteger: ILongMonth
    {
        private static readonly int[] longMonths =
        {
            1, // January
            0, // Feb
            1, // March
            0, // Apr
            1, // May
            0, // June
            1, // July
            1, // August
            0, // Sept
            1, // October
            0, // Nov
            1  // December
        };

        public bool IsLongMonth(int month)
        {
            return Convert.ToBoolean(longMonths[month-1]); 
            //return longMonths[month-1] != 0;
        }

    }

    public class ArrayIntegerTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(10)]
        [InlineData(12)]
        public void LongMonths(int month)
        {
            var sut = new ArrayInteger();
            Assert.True(sut.IsLongMonth(month));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(11)]
        public void ShortMonths(int month)
        {
            var sut = new ArrayInteger();
            Assert.False(sut.IsLongMonth(month));
        }
    }
}