using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimeSimulator
{
    private Dictionary<int, DayStates> _dayStatesStartsMap;

    public static DayTime CurrentTime { get; private set; }
    public static DayStates CurrentDayState { get; private set; }

    public static event Action<int, int> TimeChanged;
    public static event Action<DayStates> DayStateChanged;

    public DayTimeSimulator(ICoroutineRunner coroutineRunner, DayTime startTime, DayStates startDayState, float realSecondsInMinute)
    {
        _dayStatesStartsMap = new Dictionary<int, DayStates>()
        {
            [Constants.MorningStartHour] = DayStates.Morning,
            [Constants.DayStartHour] = DayStates.Day,
            [Constants.EveningStartHour] = DayStates.Evening,
            [Constants.NightStartHour] = DayStates.Night
        };

        CurrentTime = startTime;
        CurrentDayState = startDayState;

        coroutineRunner.StartCoroutine(Simulating(realSecondsInMinute));
    }

    private IEnumerator Simulating(float realSecondsInMinute)
    {
        while (true)
        {
            while (CurrentTime.Hour < Constants.MaxHour)
            {
                while (CurrentTime.Minute < Constants.MaxMinute)
                {
                    float delayTime = realSecondsInMinute;

                    while (delayTime > 0)
                    {
                        delayTime -= Time.deltaTime;

                        yield return null;
                    }

                    CurrentTime.Minute++;
                    TimeChanged?.Invoke(CurrentTime.Hour, CurrentTime.Minute);
                }

                CurrentTime.Minute = Constants.MinMinute;
                CurrentTime.Hour++;
                TimeChanged?.Invoke(CurrentTime.Hour, CurrentTime.Minute);

                CheckForSwitchDayState();
            }

            CurrentTime.Hour = Constants.MinHour;
            TimeChanged?.Invoke(CurrentTime.Hour, CurrentTime.Minute);
        }
    }

    private void CheckForSwitchDayState()
    {
        if (_dayStatesStartsMap.ContainsKey(CurrentTime.Hour))
        {
            CurrentDayState = _dayStatesStartsMap[CurrentTime.Hour];

            DayStateChanged?.Invoke(CurrentDayState);
        }
    }
}
