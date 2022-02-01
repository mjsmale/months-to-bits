using Xunit;

namespace MonthsToBits
{
    public class ControlFlow : IDaysInMonth
    {
        public int DaysInMonth(int month, int year)
        {
            switch(month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    return 28 + LeapYear.DayOffset(year);
                default:
                    return 30;
            }
        }
    }

    public static class LeapYear
    {
        public static bool IsLeapYear(int year)
        {
            return year % 4 == 0 && year % 100 != 0 | year % 400 == 0;
        }

        public static int DayOffset(int year)
        {
            return IsLeapYear(year) ? 1 : 0;
        }

    }

    public class DControlFlowTests
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
            var sut = new ControlFlow();
            Assert.Equal(31, sut.DaysInMonth(month, year));
        }

        [Theory]
        [InlineData(4, 2000)]
        [InlineData(6, 2003)]
        [InlineData(9, 2020)]
        [InlineData(11, 2022)]
        public void StandardShortMonths(int month, int year)
        {
            var sut = new ControlFlow();
            Assert.Equal(30, sut.DaysInMonth(month, year));
        }

        [Theory]
        [InlineData(2, 1700)]
        [InlineData(2, 2003)]
        [InlineData(2, 2021)]
        [InlineData(2, 2022)]
        public void FebruaryNormalYear(int month, int year)
        {
            var sut = new ControlFlow();
            Assert.Equal(28, sut.DaysInMonth(month, year));
        }

        [Theory]
        [InlineData(2, 2000)]
        [InlineData(2, 2004)]
        [InlineData(2, 2020)]
        [InlineData(2, 2024)]
        public void FebruaryLeapYear(int month, int year)
        {
            var sut = new ControlFlow();
            Assert.Equal(29, sut.DaysInMonth(month, year));
        }
    }
}