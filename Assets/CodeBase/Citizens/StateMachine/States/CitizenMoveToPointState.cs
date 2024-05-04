
using UnityEngine;

public class CitizenMoveToPointState : IState
{
    private readonly IStateSwitcher _stateSwitcher;
    private readonly Citizen _citizen;

    private Vector3 _targetPoint;

    public CitizenMoveToPointState(IStateSwitcher stateSwitcher, Citizen citizen)
    {
        _stateSwitcher = stateSwitcher;
        _citizen = citizen;
    }

    public void Enter()
    {
        _citizen.BehaviourSwitched += OnCitizenBehaviourSwitched;

        _targetPoint = _citizen.WayPoints.CurrentWayPoint;
        _citizen.Mover.SetDestination(_targetPoint);
        Debug.Log("начинаю идти");
    }

    public void Exit()
    {
        _citizen.BehaviourSwitched -= OnCitizenBehaviourSwitched;
    }

    public void Update()
    {
        Debug.Log("иду");

        if (Vector3.Distance(_citizen.transform.position, _targetPoint) < 1)
        {
            _stateSwitcher.SwitchStateForBehaviour(_citizen.CurrentRoutineBehaviour);
        }
    }

    private void OnCitizenBehaviourSwitched(CitizenBehaviours newBehaviour)
    {
        _stateSwitcher.SwitchStateForBehaviour(newBehaviour);
    }
}
