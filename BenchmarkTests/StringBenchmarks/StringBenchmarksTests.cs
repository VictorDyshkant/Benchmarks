using BenchmarkDotNet.Running;
using Benchmarks.StringBenchmarks;
using Xunit;

namespace BenchmarkTests.StringBenchmarks
{
    public class StringBenchmarksTests
    {
        [Fact]
        public void TestStandartString()
        {
            BenchmarkRunner.Run<StandartString>();
        }

        [Fact]
        public void TestStringBuilderWithAdditionalMemoryAllocation()
        {
            BenchmarkRunner.Run<StringBuilderWithAdditionalMemoryAllocation>();
        }

        [Fact]
        public void TestStringBuilderWithoutAdditionalMemoryAllocation()
        {
            BenchmarkRunner.Run<StringBuilderWithoutAdditionalMemoryAllocation>();
        }
    }
}
