using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Citizen : MonoBehaviour, IAttackable
{
    private const float MinDistanceToReachWayPoint = 1f;

    [field: SerializeField] public Transform Bed { get; private set; }

    protected CitizenStateMachine _stateMachine;

    private DayTimeSimulator _dayTimeSimulator;

    private Dictionary<DayTime, CitizenBehaviours> _dayRoutine;
    private Dictionary<CitizenBehaviours, Transform> _behaviourWayPoints;

    public CitizenBehaviours CurrentRoutineBehaviour { get; private set; }
    public NavMeshAgent Mover { get; private set; }
    public Transform CurrentWayPoint => _behaviourWayPoints[CurrentRoutineBehaviour];

    public event Action<CitizenBehaviours> BehaviourSwitched;

    public void Init(DayTimeSimulator dayTimeSimulator, CitizenBehaviours startBehaviour)
    {
        Mover = GetComponent<NavMeshAgent>();   

        CurrentRoutineBehaviour = startBehaviour;
        _dayRoutine = GetDayRoutineMap();
        _behaviourWayPoints = GetBehaviourWayPointsMap();

        _stateMachine = new CitizenStateMachine();
        _stateMachine.Init(GetStatesBehaviourMap());
        _stateMachine.SwitchStateForBehaviour(CurrentRoutineBehaviour);

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

    public bool IsWayPointReached()
    {
        return Vector3.Distance(transform.position, CurrentWayPoint.position) < MinDistanceToReachWayPoint;
    }

    public abstract void Attack();

    private void OnTimeChanged(DayTime currentTime)
    {
        if (_dayRoutine.ContainsKey(currentTime))
        {
            CurrentRoutineBehaviour = _dayRoutine[currentTime];

            BehaviourSwitched?.Invoke(CurrentRoutineBehaviour);
        }
    }

    protected abstract Dictionary<CitizenBehaviours, IState> GetStatesBehaviourMap();
    protected abstract Dictionary<DayTime, CitizenBehaviours> GetDayRoutineMap();
    protected abstract Dictionary<CitizenBehaviours, Transform> GetBehaviourWayPointsMap();
}
