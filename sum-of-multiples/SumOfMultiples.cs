using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        return Enumerable.Range(1, max - 1).Where(IsDivisibleByAny).Sum();

        bool IsDivisibleByAny(int n) => multiples.Any(d => d != 0 && n % d == 0);
    }
}