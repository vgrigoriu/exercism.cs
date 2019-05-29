using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    private readonly List<int> scores;

    public HighScores(List<int> scores) => this.scores = scores ?? throw new ArgumentNullException(nameof(scores));

    // make a defensive copy
    public List<int> Scores() => scores.ToList();

    // implemented like this for performance, Enumerable.Last() would iterate the whole list
    public int Latest() => scores[scores.Count - 1];

    public int PersonalBest() => scores.Max();

    public List<int> PersonalTopThree() => scores.OrderByDescending(x => x).Take(3).ToList();
}