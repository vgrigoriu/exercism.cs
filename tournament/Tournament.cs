﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Tournament
{   
    public static void Tally(Stream inStream, Stream outStream)
    {
        var teams = new Teams();
        using (var reader = new StreamReader(inStream)) {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                teams.Add(Match.Parse(line));
            }
        }
        using (var writer = new StreamWriter(outStream))
        {
            writer.Write("Team                           | MP |  W |  D |  L |  P");
            foreach (var team in teams.Tally)
            {
                writer.WriteLine();
                writer.Write($"{team.Name,-30} | {team.MatchesPlayed,2} | {team.Wins,2} | {team.Draws,2} | {team.Losses,2} | {team.Points,2}");
            }
        }
    }
}

public class Team
{
    private int wins;
    private int draws;
    private int losses;
    public Team(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public string Name { get; }

    public int Points => wins * 3 + draws * 1;

    public int MatchesPlayed => wins + draws + losses;

    public int Wins => wins;

    public int Draws => draws;

    public int Losses => losses;

    public void AddWin() => wins += 1;
    public void AddDraw() => draws += 1;
    public void AddLoss() => losses += 1;
}

public class Teams
{
    private Dictionary<string, Team> teams = new Dictionary<string, Team>();

    public void Add(Match match)
    {
        switch (match.Result)
        {
            case Result.Win:
            case Result.Loss:
                Team(match.Winner).AddWin();
                Team(match.Loser).AddLoss();
                break;
            case Result.Draw:
                Team(match.HomeTeam).AddDraw();
                Team(match.AwayTeam).AddDraw();
                break;
        }
    }

    public IEnumerable<Team> Tally
    {
        get
        {
            return teams.Values
                .OrderByDescending(t => t.Points)
                .ThenBy(t => t.Name);
        }
    }

    private Team Team(string name)
    {
        if (!teams.ContainsKey(name))
        {
            teams.Add(name, new Team(name));
        }

        return teams[name];
    }
}

public enum Result
{
    Win,
    Draw,
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
                case "draw":
                    return Result.Draw;
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

    private Match(string homeTeam, string awayTeam, Result result)
    {
        HomeTeam = homeTeam ?? throw new ArgumentNullException(nameof(homeTeam));
        AwayTeam = awayTeam ?? throw new ArgumentNullException(nameof(awayTeam));
        Result = result;
    }

    public string HomeTeam { get; }
    public string AwayTeam { get; }
    public Result Result { get; }

    public string Winner => Result == Result.Win ? HomeTeam : AwayTeam;
    public string Loser => Result == Result.Win ? AwayTeam : HomeTeam;
}