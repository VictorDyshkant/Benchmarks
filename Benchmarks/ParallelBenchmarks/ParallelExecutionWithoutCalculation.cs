using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Benchmarks.ParallelBenchmarks
{
    [SimpleJob(RuntimeMoniker.Net461)]
    [SimpleJob(RuntimeMoniker.Net50)]
    public class ParallelExecutionWithoutCalculation
    {
        [Params(100, 250, 500)]
        public static int N;
        private static int[][] _initialData = GetInitialData(N, N);

        [Benchmark]
        public void ExecuteParallel()
        {
            int counter = 0;

            Parallel.ForEach(_initialData, (int[] collection) =>
            {
                for (int i = 0; i < collection.Length; i++)
                {
                    Interlocked.Add(ref counter, collection[i]);
                }
            });
        }

        [Benchmark]
        public void ExecuteAsParallel()
        {
            int counter = 0;

            _initialData.AsParallel().ForAll((int[] collection) =>
            {
                for (int i = 0; i < collection.Length; i++)
                {
                    Interlocked.Add(ref counter, collection[i]);
                }
            });
        }

        [Benchmark]
        public void ExecuteNonParallel()
        {
            int counter = 0;

            for (int i = 0; i < _initialData.Length; i++)
            {
                for (int y = 0; y < _initialData[i].Length; y++)
                {
                    Thread.Sleep(1);
                    counter += _initialData[i][y];
                }
            }
        }

        private static int[][] GetInitialData(int colls, int rows)
        {
            int[][] arr = new int[colls][];
            for (int i = 0; i < colls; i++)
            {
                arr[i] = new int[rows];
                for (int y = 0; y < rows; y++)
                {
                    arr[i][y] = 1;
                }
            }

            return arr;
        }
    }
}
