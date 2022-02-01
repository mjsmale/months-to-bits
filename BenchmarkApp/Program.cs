using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using MonthsToBits;

namespace BenchmarkApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var summary2 = BenchmarkRunner.Run<DaysInMonthBenchmarks>();
            var summary1 = BenchmarkRunner.Run<IsLongMonthBenchmarks>();
        }
    }

    public class IsLongMonthBenchmarks
    {
        [Params(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)]
        public int month { get; set; }

        [Benchmark]
        public bool SetMembershipTest()
        {
            var sut = new SetMembership();
            return sut.IsLongMonth(month);
        }

        [Benchmark]
        public bool LogicalMembershipTest()
        {
            var sut = new LogicalMembership();
            return sut.IsLongMonth(month);
        }

        [Benchmark]
        public bool ControlFlow1Test()
        {
            var sut = new ControlFlow1();
            return sut.IsLongMonth(month);
        }

        [Benchmark]
        public bool ControlFlow2Test()
        {
            var sut = new ControlFlow2();
            return sut.IsLongMonth(month);
        }

        [Benchmark]
        public bool ControlFlow3Test()
        {
            var sut = new ControlFlow3();
            return sut.IsLongMonth(month);
        }

        [Benchmark]
        public bool ControlFlow4Test()
        {
            var sut = new ControlFlow4();
            return sut.IsLongMonth(month);
        }

        [Benchmark]
        public bool ArrayBoolTest()
        {
            var sut = new ArrayBool();
            return sut.IsLongMonth(month);
        }

        [Benchmark]
        public bool ArrayIntegerTest()
        {
            var sut = new ArrayInteger();
            return sut.IsLongMonth(month);
        }

        [Benchmark]
        public bool BitwiseMapTest()
        {
            var sut = new BitwiseMap();
            return sut.IsLongMonth(month);
        }

        [Benchmark]
        public bool ModuloTest()
        {
            var sut = new Modulo();
            return sut.IsLongMonth(month);
        }
    }

    public class DaysInMonthBenchmarks
    {
        [Params(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)]
        public int month { get; set; }

        [Params(1700, 2000, 2001, 2002, 2020, 2021)]
        public int year { get; set; }

        [Benchmark]
        public int ControlFlowTest()
        {
            var sut = new ControlFlow();
            return sut.DaysInMonth(month, year);
        }

        [Benchmark]
        public int ExceptionalFebTest()
        {
            var sut = new ExceptionalFeb();
            return sut.DaysInMonth(month, year);
        }

        [Benchmark]
        public int ArrayLookup1Test()
        {
            var sut = new ArrayLookup1();
            return sut.DaysInMonth(month, year);
        }

        [Benchmark]
        public int ArrayLookup2Test()
        {
            var sut = new ArrayLookup2();
            return sut.DaysInMonth(month, year);
        }


        [Benchmark]
        public int BitwiseLookupTest()
        {
            var sut = new BitwiseLookup();
            return sut.DaysInMonth(month, year);
        }

        [Benchmark]
        public int InlineStep1Test()
        {
            var sut = new InlineStep1();
            return sut.DaysInMonth(month, year);
        }

        [Benchmark]
        public int InlineStep2Test()
        {
            var sut = new InlineStep2();
            return sut.DaysInMonth(month, year);
        }

        [Benchmark]
        public int BitwiseInlineTest()
        {
            var sut = new BitwiseInline();
            return sut.DaysInMonth(month, year);
        }

    }

}