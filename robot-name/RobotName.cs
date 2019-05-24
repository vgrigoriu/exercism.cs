using System;
using System.Collections.Generic;

public class Robot : IDisposable
{
    private static readonly ISet<string> names = new HashSet<string>();

    private static readonly Random random = new Random();

    // max number of different names made out of two English letters and three decimal digits
    private const int MAX_NAMES = 26 * 26 * 10 * 10 * 10;

    private string name;

    public Robot()
    {
        name = Generate();
    }

    public string Name => name;

    public void Reset()
    {
        names.Remove(name);
        name = Generate();
    }

    private static string Generate()
    {
        if (names.Count >= MAX_NAMES)
        {
            // we can no longer generate new names
            throw new InvalidOperationException("out of names");
        }

        string candidate;
        do
        {
            candidate = $"{Letter()}{Letter()}{Digit()}{Digit()}{Digit()}";
        }
        while(!names.Add(candidate));

        return candidate;
    }

    private static char Letter() => (char)(random.Next(26) + 'A');

    private static char Digit() => (char)(random.Next(10) + '0');

    public void Dispose()
    {
        names.Remove(name);
    }
}
