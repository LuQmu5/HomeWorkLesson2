using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DayTimeConfig", menuName = "StaticData/DayTimeConfig", order = 54)]
public class DayTimeConfig : ScriptableObject
{
    [SerializeField] private DayStates _startDayState;
    [SerializeField] private DayStatesTimeConfig _dayStatesTimeConfig;
    [SerializeField] private DaySpeedTimeConfig _daySpeedTimeConfig;

    public DayStatesTimeConfig DayStatesTimeConfig => _dayStatesTimeConfig;
    public DaySpeedTimeConfig DaySpeedTimeConfig => _daySpeedTimeConfig;
    public DayStates StartDayState => _startDayState;
    public DayTime StartDayTime { get; private set; }

    private void OnValidate()
    {
        switch (_startDayState)
        {
            case DayStates.Morning:
                StartDayTime = new DayTime(_dayStatesTimeConfig.MorningStartHour);
                break;

            case DayStates.Day:
                StartDayTime = new DayTime(_dayStatesTimeConfig.DayStartHour);
                break;

            case DayStates.Evening:
                StartDayTime = new DayTime(_dayStatesTimeConfig.EveningStartHour);
                break;

            case DayStates.Night:
                StartDayTime = new DayTime(_dayStatesTimeConfig.NightStartHour);
                break;
        }
    }
}

[Serializable]
public class DayStatesTimeConfig
{
    [SerializeField, Range(TimeConstants.MinHour, TimeConstants.MaxHour)] private int _morningStartHour = 6;
    [SerializeField, Range(TimeConstants.MinHour, TimeConstants.MaxHour)] private int _dayStartHour = 12;
    [SerializeField, Range(TimeConstants.MinHour, TimeConstants.MaxHour)] private int _eveningStartHour = 18;
    [SerializeField, Range(TimeConstants.MinHour, TimeConstants.MaxHour)] private int _nightStartHour = 0;

    public int MorningStartHour => _morningStartHour;
    public int DayStartHour => _dayStartHour;
    public int EveningStartHour => _eveningStartHour;
    public int NightStartHour => _nightStartHour;
}

[Serializable]
public class DaySpeedTimeConfig
{
    [SerializeField, Min(0.01f)] private float _realSecondsInOneMinute = 0.01f;

    public float RealSecondsInOneMinute => _realSecondsInOneMinute;
}
