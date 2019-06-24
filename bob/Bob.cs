using System.Linq;

public static class Bob
{
    public static string Response(string statement)
    {
        if (statement.IsYelling())
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

    private static bool IsYelling(this string statement)
    {
        return statement
            .Where(char.IsLetter)
            .All(char.IsUpper);
    }

    private static bool IsQuestion(this string statement)
    {
        return statement.EndsWith('?');
    }
}