using BenchmarkDotNet.Running;
using Benchmarks.ParallelBenchmarks;
using Xunit;

namespace BenchmarkTests.ParallelBenchmarks
{
    public class ParallelBenchmarksTests
    {
        [Fact]
        public void TestParallelExecutionWithDelay()
        {
            BenchmarkRunner.Run<ParallelExecutionWithDelay>();
        }

        [Fact]
        public void TestParallelExecutionWithoutCalculation()
        {
            BenchmarkRunner.Run<ParallelExecutionWithoutCalculation>();
        }
    }
}
