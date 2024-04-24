using System;

[Serializable]
public class TimeInterval
{
    public DayTime StartRange { get; private set; }
    public DayTime EndRange { get; private set; }

    public TimeInterval(DayTime startRange, DayTime endRange)
    {
        StartRange = startRange;
        EndRange = endRange;
    }
}
