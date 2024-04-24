using System;

[Serializable]
public class DayTime
{
    private int _hour;
    private int _minute;

    public int Hour { get => _hour; set => ValidateHour(value); }
    public int Minute { get => _minute; set => ValidateMinute(value); }

    public DayTime(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
    }

    public void SetTime(int hour, int minute)
    {
        Hour = hour; 
        Minute = minute;
    }

    private void ValidateHour(int hour)
    {
        if (hour < Constants.MinHour || hour > Constants.MaxHour)
            throw new ArgumentOutOfRangeException($"{nameof(hour)} must be in interval between {Constants.MinHour} and {Constants.MaxHour}");

        _hour = hour;
    }

    private void ValidateMinute(int minute)
    {
        if (minute < Constants.MinMinute || minute > Constants.MaxMinute)
            throw new ArgumentOutOfRangeException($"{nameof(minute)} must be in interval between {Constants.MinMinute} and {Constants.MaxMinute}");

        _minute = minute;
    }
}
