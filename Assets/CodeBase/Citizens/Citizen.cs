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

    private bool _isTrading = false;

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
        print(_currentDayRoutineBehaviour);
    }

    public void StartFlee()
    {
        _stateMachine.SwitchStateForBehaviour(new CitizenFleeBehaviour());
    }

    public void BackToDayRoutine()
    {
        _stateMachine.SwitchStateForBehaviour(_currentDayRoutineBehaviour);
    }

    public void SwitchTradeState()
    {
        _isTrading = !_isTrading;

        if (_isTrading)
            _stateMachine.SwitchStateForBehaviour(new CitizenTradingBehaviour());
        else
            _stateMachine.SwitchStateForBehaviour(_currentDayRoutineBehaviour);
    }

    private void OnTimeChanged(DayTime currentTime)
    {
        if (_dayRoutine.ContainsKey(currentTime))
        {
            _currentDayRoutineBehaviour = _dayRoutine[currentTime];
            _stateMachine.SwitchStateForBehaviour(_currentDayRoutineBehaviour);
        }
    }
}
