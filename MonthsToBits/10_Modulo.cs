using System;
using Xunit;

namespace MonthsToBits
{
    public class Modulo: ILongMonth
    {
        public bool IsLongMonth(int month)
        {
            int bias = month > 7 ? 1 : 0;
            return Convert.ToBoolean((month + bias) % 2);  
        }

        #region Explainer
        /// Jan   Feb   Mar   Apr   May   Jun   Jul  | Aug   Sep   Oct   Nov   Dec
        ///  1     0     1     0     1     0     1   |  1     0     1     0     1 
        ///                                          | bias
        #endregion

    }

    public class AModuloTests
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
            var sut = new Modulo();
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
            var sut = new Modulo();
            Assert.False(sut.IsLongMonth(month));
        }
    }
}