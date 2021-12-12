using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Text;

namespace Benchmarks.StringBenchmarks
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net461)]
    [SimpleJob(RuntimeMoniker.Net50)]
    public class StringBuilderWithAdditionalMemoryAllocation
    {
        [Params(100, 1000, 10000)]
        public int Count;

        [Benchmark]
        public void StringBuilderWithReservationAndMemoryAllocation()
        {
            var str = new StringBuilder(Count);
            object obj;

            for (int i = 0; i < Count; i++)
            {
                str.Append("o");
                obj = new object();
            }
            str.ToString();
        }

        [Benchmark]
        public void StringBuilderWithPartialReservationAndMemoryAllocation()
        {
            var str = new StringBuilder(Count / 2);
            object obj;

            for (int i = 0; i < Count; i++)
            {
                str.Append("o");
                obj = new object();
            }
            str.ToString();
        }

        [Benchmark]
        public void StringBuilderWithoutReservationAndMemoryAllocation()
        {
            var str = new StringBuilder();
            object obj;

            for (int i = 0; i < Count; i++)
            {
                str.Append("o");
                obj = new object();
            }
            str.ToString();
        }
    }
}
