using BenchmarkDotNet.Running;
using Benchmarks.DictionaryBenchmarks;
using Xunit;

namespace BenchmarkTests.DictionaryBenchmarks
{
    public class DictionaryBenchmarksTests
    {
        [Fact]
        public void TestDictionaryBenchmarks()
        {
            BenchmarkRunner.Run<DictionaryAndConcurrentBenchmarks>();
        }
    }
}
