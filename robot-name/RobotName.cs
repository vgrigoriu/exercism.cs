using System;
using System.Collections.Generic;

public class Robot : IDisposable
{
    private static ISet<string> names = new HashSet<string>();

    private static Random random = new Random();

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
