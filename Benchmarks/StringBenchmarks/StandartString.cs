using BenchmarkDotNet.Attributes;

namespace Benchmarks.StringBenchmarks
{
    [MemoryDiagnoser]
    public class SimpleString
    {
        [Params(100, 1000, 10000)]
        public int Count;

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
