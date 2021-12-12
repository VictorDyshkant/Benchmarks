using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Benchmarks
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net461)]
    [SimpleJob(RuntimeMoniker.Net50)]
    public class DictionaryBenchmarks
    {
        [Params(100, 1000, 10000)]
        public int Count;

        [Benchmark]
        public void WithDictionary()
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < Count; i++)
            {
                 if(dict.TryGetValue(i, out int value)) 
                    dict[i] = value++;
            }

            for (int i = 0; i < Count; i++)
            {
                if (dict.TryGetValue(i, out int value))
                    dict[i] = value++;
            }
        }

        [Benchmark]
        public void WithConcurrentDictionary()
        {
            var dict = new ConcurrentDictionary<int, int>();
            for (int i = 0; i < Count; i++)
            {
                dict.AddOrUpdate(i, 1, (id, count) => count + 1);
            }

            for (int i = 0; i < Count; i++)
            {
                dict.AddOrUpdate(i, 1, (id, count) => count + 1);
            }
        }
    }
}
