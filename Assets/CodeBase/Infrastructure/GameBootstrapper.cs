using UnityEngine;

public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] private ClockDisplay _clockDisplay;

    private void Awake()
    {
        float realSecondsInMinute = 0.1f;
        DayTime startDayTime = new DayTime(0, 0);
        DayStates startDayState = DayStates.Night;

        DayTimeSimulator dayTimeSimulator = new DayTimeSimulator(this, startDayTime, startDayState, realSecondsInMinute);
        _clockDisplay.Init(dayTimeSimulator, startDayTime.Hour, startDayTime.Minute, startDayState);
    }
}
