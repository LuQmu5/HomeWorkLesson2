using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimeSimulator
{
    private Dictionary<int, DayStates> _dayStatesStartsMap;
    private DayTime _currentTime;
    private DayStates _currentDayState;

    public DayTime CurrentTime => _currentTime;
    public DayStates CurrentDayState => _currentDayState;

    public event Action<DayTime> TimeChanged;
    public event Action<DayStates> DayStateChanged;

    public DayTimeSimulator(ICoroutineRunner coroutineRunner, DayTime startTime, DayStates startDayState, float realSecondsInMinute)
    {
        _dayStatesStartsMap = new Dictionary<int, DayStates>()
        {
            [GlobalConstants.MorningStartHour] = DayStates.Morning,
            [GlobalConstants.DayStartHour] = DayStates.Day,
            [GlobalConstants.EveningStartHour] = DayStates.Evening,
            [GlobalConstants.NightStartHour] = DayStates.Night
        };

        _currentTime = startTime;
        _currentDayState = startDayState;

        coroutineRunner.StartCoroutine(Simulating(realSecondsInMinute));
    }

    private IEnumerator Simulating(float realSecondsInMinute)
    {
        while (true)
        {
            while (_currentTime.Hour < GlobalConstants.MaxHour)
            {
                while (_currentTime.Minute < GlobalConstants.MaxMinute)
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

                _currentTime.Minute = GlobalConstants.MinMinute;
                _currentTime.Hour++;
                TimeChanged?.Invoke(_currentTime);

                CheckForSwitchDayState();
            }

            _currentTime.Hour = GlobalConstants.MinHour;
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
