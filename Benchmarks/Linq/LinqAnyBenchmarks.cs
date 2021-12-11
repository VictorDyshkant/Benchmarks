using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace Benchmarks.Linq
{
    public class LinqAnyBenchmarks
    {
        public static IEnumerable<int> list = Enumerable.Range(0, 100).ToList();

        [Benchmark]
        public void AnySearch()
        {
            if (list.Any(x => x == 100))
            {
                return;
            }
        }

        [Benchmark]
        public void ForeachSearch()
        {
            foreach (var x in list)
            {
                if (x == 100)
                {
                    return;
                }
            }
        }

        [Benchmark]
        public void CheckingEmptyListByAny()
        {
            var result = new List<int>().Any();
        }

        [Benchmark]
        public void CheckingEmptyListByCount()
        {
            var result = new List<int>().Count > 0;
        }

        [Benchmark]
        public void CheckingNotEmptyListByAny()
        {
            var result = list.Any();
        }

        [Benchmark]
        public void CheckingNotEmptyListByCount()
        {
            var result = list.Count() > 0;
        }
    }
}
