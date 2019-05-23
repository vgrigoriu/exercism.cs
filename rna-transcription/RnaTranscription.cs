using System;
using System.Collections.Generic;
using System.Linq;

public static class RnaTranscription
{
    public static string ToRna(string nucleotide)
    {
        return new String(nucleotide.Select(c => complement[c]).ToArray());
    }

    private static readonly IDictionary<char, char> complement = new Dictionary<char, char>
    {
        {'C', 'G'},
        {'G', 'C'},
        {'T', 'A'},
        {'A', 'U'}
    };
}