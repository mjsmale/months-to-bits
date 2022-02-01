using Xunit;

namespace MonthsToBits
{
    public class ArrayBool: ILongMonth
    {
        private static readonly bool[] longMonths =
        {
            true, // January
            false, // Feb
            true, // March
            false, // Apr
            true, // May
            false, // June
            true, // July
            true, // August
            false, // Sept
            true, // October
            false, // Nov
            true // December
        };

        public bool IsLongMonth(int month)
        {
            return longMonths[month-1];  
        }

    }

    public class ArrayBoolTests
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
            var sut = new ArrayBool();
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
            var sut = new ArrayBool();
            Assert.False(sut.IsLongMonth(month));
        }
    }
}