using System.Collections.Generic;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] private Citizen[] _citizens;
    [SerializeField] private ClockDisplay _clockDisplay;

    private DayTimeSimulator _dayTimeSimulator;

    private void Awake()
    {
        InitDayTimeSimulator();
        InitCitizens();
        InitUI();
    }

    private void InitUI()
    {
        _clockDisplay.Init(_dayTimeSimulator, _dayTimeSimulator.CurrentTime, _dayTimeSimulator.CurrentDayState);
    }

    private void InitCitizens()
    {   
        CitizenSleepBehaviour startBehaviour = new CitizenSleepBehaviour();

        foreach (var citizen in _citizens)
        {
            citizen.Init(new CitizenBehaviourSwitcher(startBehaviour));
        }
    }

    private void InitDayTimeSimulator()
    {
        float realSecondsInMinute = 0.01f;
        DayTime startDayTime = new DayTime(0, 0);
        DayStates startDayState = DayStates.Night;
        _dayTimeSimulator = new DayTimeSimulator(this, startDayTime, startDayState, realSecondsInMinute);
    }
}
