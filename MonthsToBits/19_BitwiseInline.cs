using Xunit;

namespace MonthsToBits
{
    public class BitwiseInline : IDaysInMonth
    {
        public int DaysInMonth(int m, int y)
        {
            return 30 + (m + ((m & 8) >> 3)) % 2 +
                    (1 + (((m - 2) | (2 - m)) >> 31)) *
                    ((1 + (((y % 4) | -(y % 4)) >> 31)) -
                     (1 + (((y % 100) | -(y % 100)) >> 31)) +
                     (1 + (((y % 400) | -(y % 400)) >> 31)) - 2);
        }
    }


    public class DBitwiseInlineTests
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
            var sut = new BitwiseInline();
            Assert.Equal(31, sut.DaysInMonth(month, year));
        }

        [Theory]
        [InlineData(4, 2000)]
        [InlineData(6, 2003)]
        [InlineData(9, 2020)]
        [InlineData(11, 2022)]
        public void StandardShortMonths(int month, int year)
        {
            var sut = new BitwiseInline();
            Assert.Equal(30, sut.DaysInMonth(month, year));
        }

        [Theory]
        [InlineData(2, 1700)]
        [InlineData(2, 2003)]
        [InlineData(2, 2021)]
        [InlineData(2, 2022)]
        public void FebruaryNormalYear(int month, int year)
        {
            var sut = new BitwiseInline();
            Assert.Equal(28, sut.DaysInMonth(month, year));
        }

        [Theory]
        [InlineData(2, 2000)]
        [InlineData(2, 2004)]
        [InlineData(2, 2020)]
        [InlineData(2, 2024)]
        public void FebruaryLeapYear(int month, int year)
        {
            var sut = new BitwiseInline();
            Assert.Equal(29, sut.DaysInMonth(month, year));
        }
    }
}