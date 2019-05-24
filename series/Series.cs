using System;
using System.Linq;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (sliceLength <= 0 || numbers.Length < sliceLength) {
            throw new ArgumentException(nameof(sliceLength));
        }

        return Enumerable.Range(0, numbers.Length - sliceLength + 1)
            .Select(index => numbers.Substring(index, sliceLength))
            .ToArray();
    }
}