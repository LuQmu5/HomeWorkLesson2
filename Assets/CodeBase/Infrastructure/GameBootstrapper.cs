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
        InitUI(dayTimeConfig);
    }

    private void InitUI(DayTimeConfig dayTimeConfig)
    {
        _clockDisplay.Init(_dayTimeSimulator, dayTimeConfig);
    }

    private void InitDayTimeSimulator(DayTimeConfig dayTimeConfig)
    {
        _dayTimeSimulator = new DayTimeSimulator(this, dayTimeConfig);
    }
}
