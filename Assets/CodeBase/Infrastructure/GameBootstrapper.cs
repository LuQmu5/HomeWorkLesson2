using System.Collections.Generic;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] private CitizenBehaviour[] _citizens;
    [SerializeField] private ClockDisplay _clockDisplay;

    private void Awake()
    {
        float realSecondsInMinute = 0.01f;
        DayTime startDayTime = new DayTime(0, 0);
        DayStates startDayState = DayStates.Night;

        Dictionary<DayTime, CitizenBehaviours> workerDayRoutine = new Dictionary<DayTime, CitizenBehaviours>()
        {
            [new DayTime(6, 0)] = CitizenBehaviours.Walk,
            [new DayTime(8, 0)] = CitizenBehaviours.Work,
            [new DayTime(12, 0)] = CitizenBehaviours.Walk,
            [new DayTime(13, 0)] = CitizenBehaviours.Work,
            [new DayTime(18, 0)] = CitizenBehaviours.Walk,
            [new DayTime(22, 0)] = CitizenBehaviours.Sleep,
        };

        DayTimeSimulator dayTimeSimulator = new DayTimeSimulator(this, startDayTime, startDayState, realSecondsInMinute);

        foreach (var citizen in _citizens)
        {
            citizen.Init(dayTimeSimulator, workerDayRoutine, CitizenBehaviours.Sleep);
        }

        _clockDisplay.Init(dayTimeSimulator, startDayTime, startDayState);
    }
}
