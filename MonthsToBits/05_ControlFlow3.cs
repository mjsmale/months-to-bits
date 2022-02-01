using Xunit;

namespace MonthsToBits
{
    public class ControlFlow3 : ILongMonth
    {
        public bool IsLongMonth(int m)
        {
            if (m == 1 | m == 3 | m == 5 | m == 7 | m == 8 | m == 10 | m == 12)
            {
                return true;
            }

            return false;
        }
    }

    public class AControlFlow3Tests
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
            var sut = new ControlFlow3();
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
            var sut = new ControlFlow3();
            Assert.False(sut.IsLongMonth(month));
        }
    }
}
