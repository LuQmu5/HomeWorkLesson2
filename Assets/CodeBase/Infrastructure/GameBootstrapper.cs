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

    private void InitDayTimeSimulator(DayTimeConfig dayTimeConfig)
    {
        _dayTimeSimulator = new DayTimeSimulator(this, dayTimeConfig);
    }

    private void InitCitizens()
    {
        Dictionary<DayTime, CitizenBehaviours> workerDayRoutine = new Dictionary<DayTime, CitizenBehaviours>()
        {
            [new DayTime(10)] = CitizenBehaviours.Work,
            [new DayTime(20)] = CitizenBehaviours.Sleep,
        };

        foreach (var citizen in _citizens)
        {
            citizen.Init(_dayTimeSimulator, workerDayRoutine, CitizenBehaviours.Sleep);
        }
    }

    private void InitUI(DayTimeConfig dayTimeConfig)
    {
        _clockDisplay.Init(_dayTimeSimulator, dayTimeConfig);
    }
}
