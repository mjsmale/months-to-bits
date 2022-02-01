using Xunit;

namespace MonthsToBits
{
    public class ControlFlow2 : ILongMonth
    {
        public bool IsLongMonth(int month)
        {
            switch (month)
            {
                case 1:
                    return true;
                case 3:
                    return true;
                case 5:
                    return true;
                case 7:
                    return true;
                case 8:
                    return true;
                case 10:
                    return true;
                case 12:
                    return true;
                default:
                    return false;
            }

        }

    }

    public class AControlFlow2Tests
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
            var sut = new ControlFlow2();
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
            var sut = new ControlFlow2();
            Assert.False(sut.IsLongMonth(month));
        }
    }
}