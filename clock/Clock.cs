using System;

public struct Clock
{
    private readonly int minutes;

    public Clock(int hours, int minutes)
    {
        this.minutes = hours * 60 + minutes;
    }

    public int Hours => minutes / 60;

    public int Minutes => minutes % 60;

    public Clock Add(int minutesToAdd)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public Clock Subtract(int minutesToSubtract)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public override string ToString() => $"{Hours:D2}:{Minutes:D2}";
}