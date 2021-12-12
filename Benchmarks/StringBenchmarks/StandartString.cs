using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmarks.StringBenchmarks
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net461)]
    [SimpleJob(RuntimeMoniker.Net50)]
    public class StandartString
    {
        //[Params(100, 1000, 10000)]
        public int Count = 10;

        [Benchmark]
        public void StringConcatination()
        {
            var str = string.Empty;

            for (int i = 0; i < Count; i++)
            {
                str += "o";
            }
            str.ToString();
        }
    }
}
