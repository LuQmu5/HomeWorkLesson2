using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CitizenBehaviour : MonoBehaviour
{
    private DayTimeSimulator _dayTimeSimulator;
    private Dictionary<DayTime, CitizenBehaviours> _dayRoutineMap;
    private CitizenStateMachine _stateMachine;
    private NavMeshAgent _agent;

    public void Init(DayTimeSimulator dayTimeSimulator, Dictionary<DayTime, CitizenBehaviours> dayRoutineMap, CitizenBehaviours startBehaviour)
    {
        _dayTimeSimulator = dayTimeSimulator;
        _dayRoutineMap = dayRoutineMap;
        _stateMachine = new CitizenStateMachine(this);
        _agent = GetComponent<NavMeshAgent>();

        ChangeBehaviour(startBehaviour);

        _dayTimeSimulator.TimeChanged += OnTimeChanged;
    }

    private void OnDestroy()
    {
        _dayTimeSimulator.TimeChanged -= OnTimeChanged;
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    public void ChangeBehaviour(CitizenBehaviours newBehaviour)
    {
        switch (newBehaviour)
        {
            case CitizenBehaviours.Sleep:
                _stateMachine.SwitchState<SleepState>();
                break;

            case CitizenBehaviours.Walk:
                _stateMachine.SwitchState<WalkState>();
                break;

            case CitizenBehaviours.Work:
                _stateMachine.SwitchState<WorkState>();
                break;

            default:
                throw new NullReferenceException("no behaviour found");
        }
    }

    private void OnTimeChanged(DayTime dayTime)
    {
        if (_dayRoutineMap.ContainsKey(dayTime))
        {
            CitizenBehaviours newBehaviour = _dayRoutineMap[dayTime];
            ChangeBehaviour(newBehaviour);
        }
    }
}
