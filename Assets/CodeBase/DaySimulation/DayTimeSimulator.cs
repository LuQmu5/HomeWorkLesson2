using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimeSimulator
{
    private WaitForSeconds _oneMinuteDelay;
    private Dictionary<int, DayStates> _dayStatesStartsMap;

    public static DayTime CurrentTime { get; private set; }
    public static DayStates CurrentDayState { get; private set; }

    public DayTimeSimulator(ICoroutineRunner coroutineRunner, DayTime startTime, int realSecondsInMinute)
    {
        _oneMinuteDelay = new WaitForSeconds(realSecondsInMinute);
        _dayStatesStartsMap = new Dictionary<int, DayStates>()
        {
            [Constants.MorningStartHour] = DayStates.Morning,
            [Constants.DayStartHour] = DayStates.Day,
            [Constants.EveningStartHour] = DayStates.Evening,
            [Constants.NightStartHour] = DayStates.Night
        };

        CurrentTime = startTime;

        coroutineRunner.StartCoroutine(Simulating());
    }

    private IEnumerator Simulating()
    {
        while (true)
        {
            while (CurrentTime.Hour <= Constants.MaxHour)
            {
                while (CurrentTime.Minute <= Constants.MaxMinute)
                {
                    yield return _oneMinuteDelay;

                    CurrentTime.Minute++;
                }

                CurrentTime.Minute = Constants.MinMinute;
                CurrentTime.Hour++;

                CheckForSwitchDayState();
            }

            CurrentTime.Hour = Constants.MinHour;
        }
    }

    private void CheckForSwitchDayState()
    {
        if (_dayStatesStartsMap.ContainsKey(CurrentTime.Hour))
            CurrentDayState = _dayStatesStartsMap[CurrentTime.Hour];
    }
}
