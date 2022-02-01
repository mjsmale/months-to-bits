using Xunit;

namespace MonthsToBits
{
    public class ControlFlow4 : ILongMonth
    {
        public bool IsLongMonth(int month)
        {
            if (month == 1)
                return true;

            if (month == 3)
                return true;

            if (month == 5)
                return true;

            if (month == 7)
                return true;

            if (month == 8)
                return true;

            if (month == 10)
                return true;

            if (month == 12)
                return true;

            return false;
        }

    }

    public class AControlFlow4Tests
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
            var sut = new ControlFlow4();
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
            var sut = new ControlFlow4();
            Assert.False(sut.IsLongMonth(month));
        }
    }
}