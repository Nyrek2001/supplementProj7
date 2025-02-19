using System;
using System.Linq;
using Xunit;

public class ArrayProcessorTests
{
    private readonly int[] _array;

    public ArrayProcessorTests()
    {
        // Initialize array with values from 0 to 999,999
        _array = Enumerable.Range(0, 1_000_000).ToArray();
    }

    [Fact]
    public void GetEvenNumbers_ShouldReturnOnlyEvens()
    {
        var result = ArrayProcessor.GetEvenNumbers(_array);
        Assert.All(result, num => Assert.True(num % 2 == 0));
    }

    [Fact]
    public void GetEvenNumbers_WithSkip_ShouldSkipElements()
    {
        var result = ArrayProcessor.GetEvenNumbers(_array, 5);
        Assert.Equal(_array.Where(n => n % 2 == 0).Skip(5), result);
    }

    [Fact]
    public void GetOddNumbersAfterShuffle_ShouldReturnOnlyOdds()
    {
        var result = ArrayProcessor.GetOddNumbersAfterShuffle(_array);
        Assert.All(result, num => Assert.True(num % 2 != 0));
    }

    [Fact]
    public void GetOddNumbersAfterShuffle_WithSkip_ShouldSkipElements()
    {
        var result = ArrayProcessor.GetOddNumbersAfterShuffle(_array, 10);
        Assert.Equal(_array.Where(n => n % 2 != 0).OrderBy(_ => Guid.NewGuid()).Skip(10), result);
    }

    [Fact]
    public void GetStatistics_ShouldReturnCorrectValues()
    {
        var stats = ArrayProcessor.GetStatistics(_array);
        Assert.Equal(499999.5, stats.Average, precision: 1);
        Assert.Equal(0, stats.Min);
        Assert.Equal(999999, stats.Max);
    }
}
