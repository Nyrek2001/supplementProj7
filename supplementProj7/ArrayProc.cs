using System;
using System.Linq;

/// <summary>
/// Provides utility methods for processing arrays using LINQ.
/// </summary>
public static class ArrayProcessor
{
    /// <summary>
    /// Retrieves all even numbers from the given array.
    /// </summary>
    /// <param name="array">The array of integers to process.</param>
    /// <param name="skip">Optional parameter to skip the first N even numbers.</param>
    /// <returns>An array of even numbers with optional skipping.</returns>
    public static int[] GetEvenNumbers(int[] array, int skip = 0)
    {
        return array.Where(n => n % 2 == 0).Skip(skip).ToArray();
    }

    /// <summary>
    /// Shuffles the array and retrieves all odd numbers.
    /// </summary>
    /// <param name="array">The array of integers to process.</param>
    /// <param name="skip">Optional parameter to skip the first N odd numbers after shuffling.</param>
    /// <returns>An array of shuffled odd numbers with optional skipping.</returns>
    public static int[] GetOddNumbersAfterShuffle(int[] array, int skip = 0)
    {
        return array.OrderBy(_ => Guid.NewGuid()).Where(n => n % 2 != 0).Skip(skip).ToArray();
    }

    /// <summary>
    /// Computes the average, minimum, and maximum values of the given array.
    /// </summary>
    /// <param name="array">The array of integers to analyze.</param>
    /// <returns>A tuple containing the average, minimum, and maximum values.</returns>
    public static (double Average, int Min, int Max) GetStatistics(int[] array)
    {
        return (array.Average(), array.Min(), array.Max());
    }
}
