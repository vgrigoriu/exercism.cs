using System;
using System.Collections.Generic;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        var counts = new Dictionary<char, int>
        {
            {'A', 0},
            {'C', 0},
            {'G', 0},
            {'T', 0},
        };

        foreach (var ch in sequence)
        {
            if (!counts.ContainsKey(ch))
            {
                throw new ArgumentException("Unexpected nucleotide: " + ch);
            }

            counts[ch] += 1;
        }

        return counts;
    }
}