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
        if (hour < GlobalConstants.MinHour || hour > GlobalConstants.MaxHour)
            throw new ArgumentOutOfRangeException($"{nameof(hour)} must be in interval between {GlobalConstants.MinHour} and {GlobalConstants.MaxHour}");

        if (minute < GlobalConstants.MinHour || minute > GlobalConstants.MaxMinute)
            throw new ArgumentOutOfRangeException($"{nameof(minute)} must be in interval between {GlobalConstants.MinMinute}  and  {GlobalConstants.MaxMinute}");

        _hour = hour;
        _minute = minute;
    }

    private void ValidateHour(int hour)
    {
        if (hour < GlobalConstants.MinHour || hour > GlobalConstants.MaxHour)
            throw new ArgumentOutOfRangeException($"{nameof(hour)} must be in interval between {GlobalConstants.MinHour}  and  {GlobalConstants.MaxHour}");

        _hour = hour;
    }

    private void ValidateMinute(int minute)
    {
        if (minute < GlobalConstants.MinHour || minute > GlobalConstants.MaxMinute)
            throw new ArgumentOutOfRangeException($"{nameof(minute)} must be in interval between {GlobalConstants.MinMinute}  and  {GlobalConstants.MaxMinute}");

        _minute = minute;
    }


    public override bool Equals(object obj)
    {
        return obj is DayTime time &&
               _hour == time._hour &&
               _minute == time._minute &&
               Hour == time.Hour &&
               Minute == time.Minute;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_hour, _minute, Hour, Minute);
    }


    public static bool operator ==(DayTime dayTime1, DayTime dayTime2)
    {
        return dayTime1.Equals(dayTime2);
    }

    public static bool operator !=(DayTime dayTime1, DayTime dayTime2)
    {
        return dayTime1.Equals(dayTime2) == false;
    }
}
