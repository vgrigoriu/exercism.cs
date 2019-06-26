public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        var openBrackets = 0;
        foreach (var bracket in input)
        {
            if (IsOpen(bracket))
            {
                openBrackets += 1;
            }
            else if (IsClose(bracket))
            {
                openBrackets -= 1;
            }
        }

        return openBrackets == 0;
    }

    private static bool IsOpen(char bracket)
    {
        return bracket == '[';
    }

    private static bool IsClose(char bracket)
    {
        return bracket == ']';
    }
}
