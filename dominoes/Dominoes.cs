using System;
using System.Collections.Generic;
using System.Linq;

public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        if (dominoes.Count() == 0)
        {
            Console.WriteLine("No dominoes");
            return true;
        }

        var firstDomino = dominoes.First();
        var (found, chain) = FindChainStartingWith(firstDomino, dominoes.Skip(1));

        return found && IsValidChain(chain);
    }

    private static (bool, IEnumerable<(int, int)>) FindChainStartingWith((int, int) start, IEnumerable<(int,int)> candidates)
    {
        if (candidates.Count() == 0)
        {
            return (true, new List<(int,int)> {start});
        }

        var candidatesArray = candidates.ToArray();
        for (var i = 0; i < candidatesArray.Length; i++)
        {
            var domino = candidatesArray[i];
            var remainingCandidates = GetRemainingCandidates(candidatesArray, domino);
            if (domino.Item1 == start.Item2)
            {
                var (found, chain) = FindChainStartingWith(domino, remainingCandidates);
                if (found)
                {
                    return (true, new List<(int,int)> {start}.Concat(chain));
                }
            }

            if (domino.Item2 == start.Item2)
            {
                var (found, chain) = FindChainStartingWith((domino.Item2, domino.Item1), remainingCandidates);
                if (found)
                {
                    return (true, new List<(int,int)> {start}.Concat(chain));
                }
            }
        }

        return (false, null);
    }

    private static IEnumerable<(int,int)> GetRemainingCandidates((int, int)[] dominoes, (int, int) except)
    {
        var eliminated = false;
        foreach (var domino in dominoes)
        {
            if (domino.Item1 == except.Item1 && domino.Item2 == except.Item2 && !eliminated)
            {
                eliminated = true;
                continue;
            }

            yield return domino;
        }
    }

    private static bool IsValidChain(IEnumerable<(int, int)> dominoes)
    {
        var dominoesArray = dominoes.ToArray();
        for (int i = 0; i < dominoesArray.Length; i++)
        {
            var currDomino = dominoesArray[i];
            var nextDomino = dominoesArray[(i+1) % dominoesArray.Length];
            if (currDomino.Item2 != nextDomino.Item1)
            {
                return false;
            }
        }

        return true;
    }
}