using Xunit;

namespace MonthsToBits
{
    public class InlineStep1 : IDaysInMonth
    {

        public int DaysInMonth(int month, int year)
        {
            return 30 
                + InlineHelper.IsLongMonth(month)
                + ((month == 2) ? 1 : 0) * (InlineHelper.DayOffset(year) - 2);
        }
    }


    public static class InlineHelper
    {
        public static int DayOffset(int year)
        {
            return ((year % 4 == 0 && 
                    year % 100 != 0 | 
                    year % 400 == 0) ? 1 : 0);
        }

        public static int IsLongMonth(int month)
        {
            return ((month + (month > 7 ? 1 : 0)) % 2);
        }
    }
    public class DInlineStep1Tests
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
            var sut = new InlineStep1();
            Assert.Equal(31, sut.DaysInMonth(month, year));
        }

        [Theory]
        [InlineData(4, 2000)]
        [InlineData(6, 2003)]
        [InlineData(9, 2020)]
        [InlineData(11, 2022)]
        public void StandardShortMonths(int month, int year)
        {
            var sut = new InlineStep1();
            Assert.Equal(30, sut.DaysInMonth(month, year));
        }

        [Theory]
        [InlineData(2, 1700)]
        [InlineData(2, 2003)]
        [InlineData(2, 2021)]
        [InlineData(2, 2022)]
        public void FebruaryNormalYear(int month, int year)
        {
            var sut = new InlineStep1();
            Assert.Equal(28, sut.DaysInMonth(month, year));
        }

        [Theory]
        [InlineData(2, 2000)]
        [InlineData(2, 2004)]
        [InlineData(2, 2020)]
        [InlineData(2, 2024)]
        public void FebruaryLeapYear(int month, int year)
        {
            var sut = new InlineStep1();
            Assert.Equal(29, sut.DaysInMonth(month, year));
        }
    }
}