using UnityEngine;

public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] private CitizenBehaviour[] _citizens;
    [SerializeField] private ClockDisplay _clockDisplay;

    private void Awake()
    {
        float realSecondsInMinute = 0.1f;
        DayTime startDayTime = new DayTime(0, 0);
        DayStates startDayState = DayStates.Night;

        DayTimeSimulator dayTimeSimulator = new DayTimeSimulator(this, startDayTime, startDayState, realSecondsInMinute);

        foreach (var citizen in _citizens)
        {
            citizen.Init(dayTimeSimulator);
        }

        _clockDisplay.Init(dayTimeSimulator, startDayTime, startDayState);
    }
}
