using BenchmarkDotNet.Running;
using Benchmarks.Linq;
using System;

namespace Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<LinqAnyBenchmarks>();
            //BenchmarkRunner.Run<DictionaryBenchmarks>();
            Console.ReadKey();
        }
    }
}
