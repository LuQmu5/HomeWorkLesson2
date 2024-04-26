using System.Collections.Generic;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
{
    private const string DayTimeConfigPath = "StaticData/DayTimeConfigs/DayTimeConfig";

    [SerializeField] private Citizen[] _citizens;
    [SerializeField] private ClockDisplay _clockDisplay;

    private DayTimeSimulator _dayTimeSimulator;

    private void Awake()
    {
        DayTimeConfig dayTimeConfig = Resources.Load<DayTimeConfig>(DayTimeConfigPath);

        InitDayTimeSimulator(dayTimeConfig);
        InitCitizens();
        InitUI(dayTimeConfig);
    }

    private void InitUI(DayTimeConfig dayTimeConfig)
    {
        _clockDisplay.Init(_dayTimeSimulator, dayTimeConfig);
    }

    private void InitCitizens()
    {
        Dictionary<DayTime, CitizenBehaviour> workerDayRoutine = new Dictionary<DayTime, CitizenBehaviour>()
        {
            [new DayTime(8, 0)] = new CitizenWorkBehaviour(),
            [new DayTime(20, 0)] = new CitizenSleepBehaviour(),
        };

        foreach (var citizen in _citizens)
        {
            CitizenSleepBehaviour startBehaviour = new CitizenSleepBehaviour();
            citizen.Init(startBehaviour, workerDayRoutine, _dayTimeSimulator);
        }
    }

    private void InitDayTimeSimulator(DayTimeConfig dayTimeConfig)
    {
        _dayTimeSimulator = new DayTimeSimulator(this, dayTimeConfig);
    }
}
