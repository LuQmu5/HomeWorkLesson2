using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimeSimulator
{
    private Dictionary<int, DayStates> _dayStatesStartsMap;
    private DayTime _currentTime;
    private DayStates _currentDayState;

    public event Action<DayTime> TimeChanged;
    public event Action<DayStates> DayStateChanged;

    public DayTimeSimulator(ICoroutineRunner coroutineRunner, DayTime startTime, DayStates startDayState, float realSecondsInMinute)
    {
        _dayStatesStartsMap = new Dictionary<int, DayStates>()
        {
            [Constants.MorningStartHour] = DayStates.Morning,
            [Constants.DayStartHour] = DayStates.Day,
            [Constants.EveningStartHour] = DayStates.Evening,
            [Constants.NightStartHour] = DayStates.Night
        };

        _currentTime = startTime;
        _currentDayState = startDayState;

        coroutineRunner.StartCoroutine(Simulating(realSecondsInMinute));
    }

    private IEnumerator Simulating(float realSecondsInMinute)
    {
        while (true)
        {
            while (_currentTime.Hour < Constants.MaxHour)
            {
                while (_currentTime.Minute < Constants.MaxMinute)
                {
                    float delayTime = realSecondsInMinute;

                    while (delayTime > 0)
                    {
                        delayTime -= Time.deltaTime;

                        yield return null;
                    }

                    _currentTime.Minute++;
                    TimeChanged?.Invoke(_currentTime);
                }

                _currentTime.Minute = Constants.MinMinute;
                _currentTime.Hour++;
                TimeChanged?.Invoke(_currentTime);

                CheckForSwitchDayState();
            }

            _currentTime.Hour = Constants.MinHour;
            TimeChanged?.Invoke(_currentTime);
        }
    }

    private void CheckForSwitchDayState()
    {
        if (_dayStatesStartsMap.ContainsKey(_currentTime.Hour))
        {
            _currentDayState = _dayStatesStartsMap[_currentTime.Hour];

            DayStateChanged?.Invoke(_currentDayState);
        }
    }
}
