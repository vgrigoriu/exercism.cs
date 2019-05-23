using System;
using System.Text;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        var result = new StringBuilder();
        var beforeStartOfWord = true;
        foreach (var ch in phrase)
        {
            if (beforeStartOfWord && char.IsLetter(ch))
            {
                result.Append(char.ToUpperInvariant(ch));
            }

            beforeStartOfWord = ch == ' ' || ch == '-' || ch == '_';
        }

        return result.ToString();
    }
}