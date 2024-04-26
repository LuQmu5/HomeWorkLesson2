using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DayTimeSimulator
{
    private Dictionary<int, DayStates> _dayStatesStartsMap;
    private DayTime _currentTime;
    private DayStates _currentDayState;

    public event Action<DayTime> TimeChanged;
    public event Action<DayStates> DayStateChanged;

    public DayTimeSimulator(ICoroutineRunner coroutineRunner, DayTimeConfig dayTimeConfig)
    {
        _dayStatesStartsMap = new Dictionary<int, DayStates>()
        {
            [dayTimeConfig.DayStatesTimeConfig.MorningStartHour] = DayStates.Morning,
            [dayTimeConfig.DayStatesTimeConfig.DayStartHour] = DayStates.Day,
            [dayTimeConfig.DayStatesTimeConfig.EveningStartHour] = DayStates.Evening,
            [dayTimeConfig.DayStatesTimeConfig.NightStartHour] = DayStates.Night
        };

        _currentDayState = dayTimeConfig.StartDayState;
        _currentTime = dayTimeConfig.StartDayTime;

        coroutineRunner.StartCoroutine(Simulating(dayTimeConfig.DaySpeedTimeConfig.RealSecondsInOneMinute));
    }

    private IEnumerator Simulating(float realSecondsInMinute)
    {
        while (true)
        {
            while (_currentTime.Hour < TimeConstants.MaxHour)
            {
                while (_currentTime.Minute < TimeConstants.MaxMinute)
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

                _currentTime.Minute = TimeConstants.MinMinute;
                _currentTime.Hour++;
                TimeChanged?.Invoke(_currentTime);

                CheckForSwitchDayState();
            }

            _currentTime.Hour = TimeConstants.MinHour;
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
