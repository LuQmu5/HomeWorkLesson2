using System;
using System.Collections.Generic;
using UnityEngine;

public class CitizenBehaviour : MonoBehaviour
{
    private DayTimeSimulator _dayTimeSimulator;
    private Dictionary<DayTime, CitizenBehaviours> _dayRoutineMap;
    private CitizenBehaviours _currentBehaviour;

    public void Init(DayTimeSimulator dayTimeSimulator, Dictionary<DayTime, CitizenBehaviours> dayRoutineMap, CitizenBehaviours startBehaviour)
    {
        _dayTimeSimulator = dayTimeSimulator;
        _dayRoutineMap = dayRoutineMap;
        _currentBehaviour = startBehaviour;

        _dayTimeSimulator.TimeChanged += OnTimeChanged;
    }

    private void OnDestroy()
    {
        _dayTimeSimulator.TimeChanged -= OnTimeChanged;
    }

    private void Update()
    {
        print("I'm " + _currentBehaviour);
    }

    private void OnTimeChanged(DayTime dayTime)
    {
        if (_dayRoutineMap.ContainsKey(dayTime))
        {
            _currentBehaviour = _dayRoutineMap[dayTime];
        }
    }
}
