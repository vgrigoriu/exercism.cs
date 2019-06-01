using System;
using System.Linq;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
        {
            throw new ArgumentException("Strands must be of equal length");
        }

        return firstStrand
            .Zip(secondStrand, (ch1, ch2) => ch1 == ch2)
            .Where(same => !same)
            .Count();
    }
}
