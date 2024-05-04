using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Citizen : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] private Transform _bed;
    [SerializeField] private Transform _workingPlace;

    private CitizenWayPoints _wayPoints;
    private CitizenStateMachine _stateMachine;
    private DayTimeSimulator _dayTimeSimulator;
    private Dictionary<DayTime, CitizenBehaviours> _dayRoutine;
    private CitizenBehaviours _currentRoutineBehaviour;

    public CitizenWayPoints WayPoints => _wayPoints;
    public CitizenBehaviours CurrentRoutineBehaviour => _currentRoutineBehaviour;
    public NavMeshAgent Mover { get; private set; }

    public event Action<CitizenBehaviours> BehaviourSwitched;

    public void Init(DayTimeSimulator dayTimeSimulator, Dictionary<DayTime, CitizenBehaviours> dayRoutine, CitizenBehaviours startBehaviour)
    {
        Mover = GetComponent<NavMeshAgent>();   

        _currentRoutineBehaviour = startBehaviour;
        _dayRoutine = dayRoutine;

        _wayPoints = new CitizenWayPoints(_bed, _workingPlace);
        _wayPoints.SwitchCurrentWayPoint(startBehaviour);

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
            _wayPoints.SwitchCurrentWayPoint(_currentRoutineBehaviour);

            BehaviourSwitched?.Invoke(_currentRoutineBehaviour);
        }
    }
}
