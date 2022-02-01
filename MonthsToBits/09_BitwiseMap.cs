using System;
using Xunit;

namespace MonthsToBits
{
    public class BitwiseMap: ILongMonth
    {
        private static readonly ushort longMonths = 0b_101011010101;
        public bool IsLongMonth(int month)
        {
            return Convert.ToBoolean((longMonths >> (month - 1)) & 1);  
        }

        #region Explainer
        ///
        ///  bits are the months in reverse order
        ///  
        ///     i.e. Dec Nov Oct Sept Aug July June May Apr Mar Feb Jan
        ///           1   0   1   0    1   1     0   1   0   1   0   1
        ///
        ///                                                      &   1
        ///                                                      
        ///  >> is a right shift operation popping the right most int off the stack
        ///  
        ///  '& 1' is the logical condition
        ///
        #endregion
    }

    public class ABitMapTests
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
            var sut = new BitwiseMap();
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
            var sut = new BitwiseMap();
            Assert.False(sut.IsLongMonth(month));
        }
    }
}