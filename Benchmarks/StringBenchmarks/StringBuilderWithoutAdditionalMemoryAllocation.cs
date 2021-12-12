using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Text;

namespace Benchmarks.StringBenchmarks
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net461)]
    [SimpleJob(RuntimeMoniker.Net50)]
    public class StringBuilderWithoutAdditionalMemoryAllocation
    {
        [Params(100, 1000, 10000)]
        public int Count;

        [Benchmark]
        public void StringBuilderWithReservation()
        {
            var str = new StringBuilder(Count);
            for (int i = 0; i < Count; i++)
            {
                str.Append("o");
            }
            str.ToString();
        }

        [Benchmark]
        public void StringBuilderWithPartialReservation()
        {
            var str = new StringBuilder(Count / 2);

            for (int i = 0; i < Count; i++)
            {
                str.Append("o");
            }
            str.ToString();
        }

        [Benchmark]
        public void StringBuilderWithoutReservation()
        {
            var str = new StringBuilder();

            for (int i = 0; i < Count; i++)
            {
                str.Append("o");
            }
            str.ToString();
        }
    }
}
