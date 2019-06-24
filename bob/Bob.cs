using System.Linq;

public static class Bob
{
    public static string Response(string rawStatement)
    {
        var statement = rawStatement.Cleanup();
        if (statement.IsSilence())
        {
            return "Fine. Be that way!";
        }
        else if (statement.IsYelling() && statement.IsQuestion())
        {
            return "Calm down, I know what I'm doing!";
        }
        else if (statement.IsYelling())
        {
            return "Whoa, chill out!";
        }
        else if (statement.IsQuestion())
        {
            return "Sure.";
        }
        else
        {
            return "Whatever.";
        }
    }

    private static bool IsSilence(this string statement)
    {
        return statement == string.Empty;
    }

    private static bool IsYelling(this string statement)
    {
        var letters = statement.Where(char.IsLetter);
        return letters.Any() && letters.All(char.IsUpper);
    }

    private static bool IsQuestion(this string statement)
    {
        return statement.EndsWith('?');
    }

    private static string Cleanup(this string statement)
    {
        return statement.Trim();
    }
}