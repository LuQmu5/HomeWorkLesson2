using System;

[Serializable]
public struct DayTime
{
    private int _hour;
    private int _minute;

    public int Hour { get => _hour; set => ValidateHour(value); }
    public int Minute { get => _minute; set => ValidateMinute(value); }

    public DayTime(int hour, int minute)
    {
        if (hour < Constants.MinHour || hour > Constants.MaxHour)
            throw new ArgumentOutOfRangeException($"{nameof(hour)} must be in interval between {Constants.MinHour} and {Constants.MaxHour}");

        if (minute < Constants.MinHour || minute > Constants.MaxMinute)
            throw new ArgumentOutOfRangeException($"{nameof(minute)} must be in interval between {Constants.MinMinute}  and  {Constants.MaxMinute}");

        _hour = hour;
        _minute = minute;
    }

    private void ValidateHour(int hour)
    {
        if (hour < Constants.MinHour || hour > Constants.MaxHour)
            throw new ArgumentOutOfRangeException($"{nameof(hour)} must be in interval between {Constants.MinHour}  and  {Constants.MaxHour}");

        _hour = hour;
    }

    private void ValidateMinute(int minute)
    {
        if (minute < Constants.MinHour || minute > Constants.MaxMinute)
            throw new ArgumentOutOfRangeException($"{nameof(minute)} must be in interval between {Constants.MinMinute}  and  {Constants.MaxMinute}");

        _minute = minute;
    }


    public static bool operator ==(DayTime dayTime1, DayTime dayTime2)
    {
        return dayTime1.Equals(dayTime2);
    }

    public static bool operator !=(DayTime dayTime1, DayTime dayTime2)
    {
        return dayTime1.Equals(dayTime2) == false;
    }

    public override bool Equals(object anotherDayTime)
    {
        DayTime dayTime2 = ((DayTime)anotherDayTime);

        return Hour == dayTime2.Hour && Minute == dayTime2.Minute;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
