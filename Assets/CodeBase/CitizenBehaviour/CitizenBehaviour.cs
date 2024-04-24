using System;
using System.Collections.Generic;
using UnityEngine;

public class CitizenBehaviour : MonoBehaviour
{
    private DayTimeSimulator _dayTimeSimulator;

    private TimeInterval _doSomeActionTimeInterval;
    private TimeInterval _sleepTimeInterval;
    private string _currentAction;

    public void Init(DayTimeSimulator dayTimeSimulator)
    {
        _dayTimeSimulator = dayTimeSimulator;

        _doSomeActionTimeInterval = new TimeInterval(new DayTime(10, 0), new DayTime(22, 0));
        _sleepTimeInterval = new TimeInterval(new DayTime(22, 0), new DayTime(10, 0));

        _dayTimeSimulator.TimeChanged += OnTimeChanged;
    }

    private void OnDestroy()
    {
        _dayTimeSimulator.TimeChanged -= OnTimeChanged;
    }

    private void Update()
    {
        print(_currentAction);
    }

    private void OnTimeChanged(int hour, int minute)
    {
    }
}

public class DayRoutine
{
    private Dictionary<CitizenBehaviours, TimeInterval> _dayRoutineMap;
}

public enum CitizenBehaviours
{
    Sleep,
    Walking,
    Working
}
