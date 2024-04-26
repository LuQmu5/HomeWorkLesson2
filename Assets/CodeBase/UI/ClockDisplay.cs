using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class ClockDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private TMP_Text _dayStateText;

    private DayTimeSimulator _dayTimeSimulator;

    public void Init(DayTimeSimulator dayTimeSimulator, DayTimeConfig dayTimeConfig)
    {
        _dayTimeSimulator = dayTimeSimulator;

        _timeText.text = GetConvertedTime(dayTimeConfig.StartDayTime);
        _dayStateText.text = dayTimeConfig.StartDayState.ToString();

        _dayTimeSimulator.TimeChanged += OnTimeChanged;
        _dayTimeSimulator.DayStateChanged += OnDayStateChanged;
    }

    private void OnDestroy()
    {
        _dayTimeSimulator.TimeChanged -= OnTimeChanged;
        _dayTimeSimulator.DayStateChanged -= OnDayStateChanged;
    }

    private void OnTimeChanged(DayTime dayTime)
    {
        _timeText.text = GetConvertedTime(dayTime);
    }

    private void OnDayStateChanged(DayStates newState)
    {
        _dayStateText.text = newState.ToString();
    }

    private string GetConvertedTime(DayTime dayTime)
    {
        string result = "";

        result += dayTime.Hour < 10 ? $"0{dayTime.Hour}" : dayTime.Hour;
        result += ":";
        result += dayTime.Minute < 10 ?$"0{dayTime.Minute}" : dayTime.Minute;

        return result;
    }
}
