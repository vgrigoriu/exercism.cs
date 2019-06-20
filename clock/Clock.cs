public struct Clock
{
    private const int MinutesInDay = 24 * 60;

    private readonly int totalMinutes;

    public Clock(int hours, int minutes) : this(hours * 60 + minutes)
    {
    }

    private Clock(int totalMinutes)
    {
        this.totalMinutes = Normalize(totalMinutes);
    }

    public int Hours => totalMinutes / 60;

    public int Minutes => totalMinutes % 60;

    public Clock Add(int minutesToAdd) => new Clock(totalMinutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract) => new Clock(totalMinutes - minutesToSubtract);

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