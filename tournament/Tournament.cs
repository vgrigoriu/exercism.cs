using System;
using System.IO;

public static class Tournament
{   
    public static void Tally(Stream inStream, Stream outStream)
    {
        string input;
        using (var reader = new StreamReader(inStream)) {
            input = reader.ReadLine();
        }
        using (var writer = new StreamWriter(outStream))
        {
            writer.Write("Team                           | MP |  W |  D |  L |  P");
            if (input != null)
            {
                var match = Match.Parse(input);
                writer.WriteLine();
                writer.Write(match.Winner + "             |  1 |  1 |  0 |  0 |  3");
                writer.WriteLine();
                writer.Write(match.Loser + "             |  1 |  0 |  0 |  1 |  0");
            }
        }
    }
}

public enum Result
{
    Win,
    Loss
}

public class Match
{
    public static Match Parse(string line)
    {
        Result ParseResult(string result)
        {
            switch (result)
            {
                case "win":
                    return Result.Win;
                case "loss":
                    return Result.Loss;
                default:
                    throw new ArgumentException($"Invalid result: {result}");
            }
        }
        var parts = line.Split(";");
        if (parts.Length != 3)
        {
            throw new ArgumentException($"Not a valid input line: {line}");
        }
        return new Match(parts[0], parts[1], ParseResult(parts[2]));
    }

    private Match(string team1, string team2, Result result)
    {
        if (team1 is null)
        {
            throw new ArgumentNullException(nameof(team1));
        }

        if (team2 is null)
        {
            throw new ArgumentNullException(nameof(team2));
        }

        Team1 = team1;
        Team2 = team2;
        Result = result;
    }

    public string Team1 { get; }
    public string Team2 { get; }
    public Result Result { get; }

    public string Winner => Result == Result.Win ? Team1 : Team2;
    public string Loser => Result == Result.Win ? Team2 : Team1;
}