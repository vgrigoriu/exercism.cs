﻿using System;
using System.Collections.Generic;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var letters = new HashSet<char>();
        foreach (var ch in word)
        {
            if (char.IsLetter(ch) && !letters.Add(char.ToLowerInvariant(ch)))
            {
                return false;
            }
        }

        return true;
    }
}
