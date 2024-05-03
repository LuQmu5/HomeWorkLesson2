using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Citizen : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] private CitizenTargetPoints _targetPoints;

    private CitizenStateMachine _stateMachine;
    private DayTimeSimulator _dayTimeSimulator;

    public NavMeshAgent Mover { get; private set; }

    public void Init(DayTimeSimulator dayTimeSimulator)
    {
        Mover = GetComponent<NavMeshAgent>();   

        _dayTimeSimulator = dayTimeSimulator;
        _dayTimeSimulator.TimeChanged += OnTimeChanged;
    }


    private void OnTimeChanged(DayTime currentTime)
    {

    }
}

public class CitizenTargetPoints : MonoBehaviour
{
    [SerializeField] private Transform _bed;
    [SerializeField] private Transform _workingPlace;

    public Transform Bed => _bed;
    public Transform WorkingPlace => _workingPlace;
}
