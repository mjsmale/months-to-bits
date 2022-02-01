using System.Collections.Generic;
using Xunit;

namespace MonthsToBits
{
    public class SetMembership: ILongMonth
    {
        private static readonly List<int> longMonths = new()
        {
            1, // January
            3, // March
            5, // May
            7, // July
            8, // August
            10,// October
            12 // December
        };

        public bool IsLongMonth(int month)
        {
            return longMonths.Contains(month);  
        }

    }

    public class ASetMembershipTests
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
            var sut = new SetMembership();
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
            var sut = new SetMembership();
            Assert.False(sut.IsLongMonth(month));
        }
    }
}