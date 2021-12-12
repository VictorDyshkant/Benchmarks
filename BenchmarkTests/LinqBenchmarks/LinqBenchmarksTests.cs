using BenchmarkDotNet.Running;
using Benchmarks.LinqBenchmarks;
using Xunit;

namespace BenchmarkTests.LinqBenchmarks
{
    public class LinqBenchmarksTests
    {
        [Fact]
        public void TestLinqAnyBenchmarks()
        {
            BenchmarkRunner.Run<LinqAnyBenchmarks>();
        }
    }
}
