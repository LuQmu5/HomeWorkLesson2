using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CitizenStateMachine
{
    public CitizenStateMachine()
    {
        
    }
}

public class MoveState : IUpdatableState
{
    private Citizen _citizen;
    private Vector3 _movePoint;

    public MoveState(Citizen citizen, Vector3 movePoint)
    {
        _citizen = citizen;
        _movePoint = movePoint;
    }

    public void Enter()
    {
        _citizen.Agent.SetDestination(_movePoint);
    }

    public void Exit()
    {
        _citizen.Agent.isStopped = true;
    }

    public void Update()
    {
        
    }
}
