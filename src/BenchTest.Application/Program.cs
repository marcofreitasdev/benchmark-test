using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

Console.WriteLine("Executando Benchmark...");

var summary = BenchmarkRunner.Run<MaxValueBenchmark>();

[MemoryDiagnoser]
public class MaxValueBenchmark
{
    private List<int> _numbers;

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random();
        _numbers = Enumerable.Range(1, 10_000_000).Select(_ => random.Next(1, 100)).ToList();
    }

    [Benchmark]
    public int MaxUsingForLoop()
    {
        //Parallel
        //var max = int.MinValue;
        //Parallel.For(0, _numbers.Count, i =>
        //{
        //    lock (_numbers)
        //    {
        //        if (_numbers[i] > max)
        //        {
        //            max = _numbers[i];
        //        }
        //    }
        //});

        var max = int.MinValue;
        for (var i = 0; i < _numbers.Count; i++)
        {
            if (_numbers[i] > max)
            {
                max = _numbers[i];
            }
        }
        return max;
    }

    [Benchmark]
    public int MaxUsingLinq()
    {
        //Parallel
        //return _numbers.AsParallel().Max();

        return _numbers.Max();
    }
}