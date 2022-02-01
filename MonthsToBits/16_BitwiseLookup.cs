using System;
using Xunit;

namespace MonthsToBits
{
    public class BitwiseLookup : IDaysInMonth
    {
        private static readonly long days =
        31L << 0  | 
        28L << 5  |
        31L << 10 |
        30L << 15 |
        31L << 20 |
        30L << 25 |
        31L << 30 |
        31L << 35 |
        30L << 40 |
        31L << 45 |
        30L << 50 |
        31L << 55;

        public int DaysInMonth(int month, int year)
        {
            var result = (days >> ((month - 1) * 5) & 0b11111) + (month == 2 ? LeapYear.DayOffset(year) : 0);
            return Convert.ToInt32(result);
        }
    }


    public class DBitwiseLookupTests
    {
        [Theory]
        [InlineData(1, 2000)]
        [InlineData(3, 2002)]
        [InlineData(5, 2003)]
        [InlineData(7, 2021)]
        [InlineData(8, 2022)]
        [InlineData(10, 2023)]
        [InlineData(12, 2024)]
        public void LongMonths(int month, int year)
        {
            var sut = new BitwiseLookup();
            Assert.Equal(31, sut.DaysInMonth(month, year));
        }

        [Theory]
        [InlineData(4, 2000)]
        [InlineData(6, 2003)]
        [InlineData(9, 2020)]
        [InlineData(11, 2022)]
        public void StandardShortMonths(int month, int year)
        {
            var sut = new BitwiseLookup();
            Assert.Equal(30, sut.DaysInMonth(month, year));
        }

        [Theory]
        [InlineData(2, 1700)]
        [InlineData(2, 2003)]
        [InlineData(2, 2021)]
        [InlineData(2, 2022)]
        public void FebruaryNormalYear(int month, int year)
        {
            var sut = new BitwiseLookup();
            Assert.Equal(28, sut.DaysInMonth(month, year));
        }

        [Theory]
        [InlineData(2, 2000)]
        [InlineData(2, 2004)]
        [InlineData(2, 2020)]
        [InlineData(2, 2024)]
        public void FebruaryLeapYear(int month, int year)
        {
            var sut = new BitwiseLookup();
            Assert.Equal(29, sut.DaysInMonth(month, year));
        }
    }
}