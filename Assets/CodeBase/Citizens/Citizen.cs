using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Citizen : MonoBehaviour
{
    private CitizenStateMachine _stateMachine;
    private DayTimeSimulator _dayTimeSimulator;
    private Dictionary<DayTime, CitizenBehaviours> _dayRoutine;
    private CitizenBehaviours _currentRoutineBehaviour;

    public NavMeshAgent Mover { get; private set; }

    public event Action<CitizenBehaviours> BehaviourSwitched;

    public void Init(DayTimeSimulator dayTimeSimulator, Dictionary<DayTime, CitizenBehaviours> dayRoutine, CitizenBehaviours startBehaviour)
    {
        Mover = GetComponent<NavMeshAgent>();   

        _currentRoutineBehaviour = startBehaviour;
        _dayRoutine = dayRoutine;

        _stateMachine = new CitizenStateMachine(this);
        _stateMachine.SwitchStateForBehaviour(_currentRoutineBehaviour);

        _dayTimeSimulator = dayTimeSimulator;
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

    private void OnTimeChanged(DayTime currentTime)
    {
        if (_dayRoutine.ContainsKey(currentTime))
        {
            _currentRoutineBehaviour = _dayRoutine[currentTime];

            BehaviourSwitched?.Invoke(_currentRoutineBehaviour);
        }
    }
}
