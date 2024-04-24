using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClockDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private TMP_Text _dayStateText;

    private DayTimeSimulator _dayTimeSimulator;

    public void Init(DayTimeSimulator dayTimeSimulator, int startHour, int startMinute, DayStates startDayState)
    {
        _dayTimeSimulator = dayTimeSimulator;

        _timeText.text = GetConvertedTime(startHour, startMinute);
        _dayStateText.text = startDayState.ToString();

        _dayTimeSimulator.TimeChanged += OnTimeChanged;
        _dayTimeSimulator.DayStateChanged += OnDayStateChanged;
    }

    private void OnDestroy()
    {
        _dayTimeSimulator.TimeChanged -= OnTimeChanged;
        _dayTimeSimulator.DayStateChanged -= OnDayStateChanged;
    }

    private void OnTimeChanged(int hour, int minute)
    {
        _timeText.text = GetConvertedTime(hour, minute);
    }

    private void OnDayStateChanged(DayStates newState)
    {
        _dayStateText.text = newState.ToString();
    }

    private string GetConvertedTime(int hour, int minute)
    {
        string result = "";

        result = hour < 10 ? result + $"0{hour}" : result + hour;
        result += ":";
        result = minute < 10 ? result + $"0{minute}" : result + minute;

        return result;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = Convert.ToInt32(Time.timeScale == 0);
        }
    }
}
