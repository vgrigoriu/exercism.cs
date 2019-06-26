using System.Collections.Generic;
using System.Linq;

public static class MatchingBrackets
{
    private static readonly Dictionary<char, char> brackets
        = new Dictionary<char, char> {
            ['('] = ')',
            ['['] = ']',
            ['{'] = '}'
        };

    public static bool IsPaired(string input)
    {
        var openBrackets = new Stack<char>();
        foreach (var bracket in input)
        {
            if (IsOpen(bracket))
            {
                openBrackets.Push(bracket);
            }
            else if (IsClose(bracket))
            {
                if (!openBrackets.TryPop(out var openBracket))
                {
                    // closing bracket with no corresponding opening
                    return false;
                }
                if (!AreMatch(openBracket, bracket))
                {
                    // mismatch
                    return false;
                }
            }
        }

        return openBrackets.Count == 0;
    }

    private static bool IsOpen(char ch) => brackets.Keys.Contains(ch);

    private static bool IsClose(char ch) => brackets.Values.Contains(ch);

    private static bool AreMatch(char openBracket, char closeBracket)
    {
        return IsOpen(openBracket) && brackets[openBracket] == closeBracket;
    }
}
