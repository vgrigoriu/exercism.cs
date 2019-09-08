using System;
using System.Collections.Generic;
using System.Linq;

public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        return IsValidChain(dominoes);
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