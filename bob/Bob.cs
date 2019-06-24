using System.Linq;

public static class Bob
{
    public static string Response(string rawStatement)
    {
        var statement = CleanUp(rawStatement);
        if (IsSilence(statement))
        {
            return "Fine. Be that way!";
        }
        else if (IsYelling(statement) && IsQuestion(statement))
        {
            return "Calm down, I know what I'm doing!";
        }
        else if (IsYelling(statement))
        {
            return "Whoa, chill out!";
        }
        else if (IsQuestion(statement))
        {
            return "Sure.";
        }
        else
        {
            return "Whatever.";
        }
    }

    private static bool IsSilence(string statement) =>
        statement == string.Empty;

    private static bool IsYelling(string statement)
    {
        var letters = statement.Where(char.IsLetter);
        return letters.Any() && letters.All(char.IsUpper);
    }

    private static bool IsQuestion(string statement) =>
        statement.EndsWith('?');

    private static string CleanUp(string statement) =>
        statement.Trim();
}