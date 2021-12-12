﻿using BenchmarkDotNet.Running;
using Benchmarks.StringBenchmarks;
using Xunit;

namespace BenchmarkTests.StringBenchmarks
{
    public class StandartStringTests
    {
        [Fact]
        public void TestBenchmarks()
        {
            BenchmarkRunner.Run<StandartString>();
        }
    }
}
