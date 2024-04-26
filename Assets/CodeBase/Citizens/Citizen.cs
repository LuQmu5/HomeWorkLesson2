using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Citizen : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] private Transform _bed;
    [SerializeField] private Transform _workingPlace;

    private CitizenStateMachine _stateMachine;
    private Dictionary<DayTime, CitizenBehaviour> _dayRoutine;
    private DayTimeSimulator _dayTimeSimulator;
    private CitizenBehaviour _currentDayRoutineBehaviour;

    public bool IsTrading { get; private set; } = false;
    public Transform Bed => _bed;
    public Transform WorkingPlace => _workingPlace;
    public NavMeshAgent Mover { get; private set; }

    public void Init(CitizenBehaviour startBehaviour, Dictionary<DayTime, CitizenBehaviour> dayRoutine, DayTimeSimulator dayTimeSimulator)
    {
        Mover = GetComponent<NavMeshAgent>();   

        _stateMachine = new CitizenStateMachine(this);
        _stateMachine.SwitchStateForBehaviour(startBehaviour);
        _currentDayRoutineBehaviour = startBehaviour;

        _dayRoutine = dayRoutine;
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

    private void OnMouseDown()
    {
        IsTrading = !IsTrading;

        if (IsTrading)
            TryChangeBehaviour(new CitizenTradingBehaviour());
        else
            TryChangeBehaviour(_currentDayRoutineBehaviour);
    }

    public bool TryChangeBehaviour(CitizenBehaviour newBehaviour)
    {
        if (newBehaviour == null)
            return false;

        _stateMachine.SwitchStateForBehaviour(newBehaviour);

        return false;
    }

    private void OnTimeChanged(DayTime currentTime)
    {
        if (_dayRoutine.ContainsKey(currentTime))
        {
            CitizenBehaviour newBehaviour = _dayRoutine[currentTime];

            if (TryChangeBehaviour(newBehaviour))
                _currentDayRoutineBehaviour = newBehaviour;
        }
    }
}
