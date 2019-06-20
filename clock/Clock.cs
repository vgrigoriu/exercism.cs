public struct Clock
{
    private const int MinutesInDay = 24 * 60;

    private readonly int minutes;

    public Clock(int hours, int minutes) : this(hours * 60 + minutes)
    {
    }

    private Clock(int totalMinutes)
    {
        this.minutes = Normalize(totalMinutes);
    }

    public int Hours => minutes / 60;

    public int Minutes => minutes % 60;

    public Clock Add(int minutesToAdd) => new Clock(minutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract) => new Clock(minutes - minutesToSubtract);

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