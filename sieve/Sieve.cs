using System;
using System.Collections.Generic;
using System.Linq;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 2)
        {
            throw new ArgumentOutOfRangeException(nameof(limit));
        }

        return primes(Enumerable.Range(2, limit - 1)).ToArray();
    }

    private static IEnumerable<int> primes(IEnumerable<int> candidates)
    {
        if (!candidates.Any())
        {
            yield break;
        }
        var divisor = candidates.First();
        yield return divisor;

        var rest = primes(candidates.Skip(1).Where(x => x % divisor != 0));
        foreach (var prime in rest)
        {
            yield return prime;
        }
    }
}