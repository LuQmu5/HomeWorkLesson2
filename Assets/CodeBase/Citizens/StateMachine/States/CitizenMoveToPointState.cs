﻿using UnityEngine;

public class CitizenMoveToPointState : CitizenBaseState
{
    public CitizenMoveToPointState(IStateSwitcher stateSwitcher, Citizen citizen) : base(stateSwitcher, citizen)
    {
        
    }

    public override void Enter()
    {
        base.Enter();

        _citizen.Mover.SetDestination(_citizen.transform.position);
    }
}
