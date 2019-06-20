using System;

public struct Clock
{
    private const int MinutesInDay = 24 * 60;

    private readonly int minutes;

    public Clock(int hours, int minutes)
    {
        this.minutes = Normalize(hours * 60 + minutes);
    }

    public int Hours => minutes / 60;

    public int Minutes => minutes % 60;

    public Clock Add(int minutesToAdd) => new Clock(Hours, Minutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract) => new Clock(Hours, Minutes - minutesToSubtract);

    public override string ToString() => $"{Hours:D2}:{Minutes:D2}";

    private static int Normalize(int totalMinutes)
    {
        var minutes = totalMinutes % MinutesInDay;
        if (minutes < 0)
        {
            minutes += MinutesInDay;
        }

        return minutes;
    }
}