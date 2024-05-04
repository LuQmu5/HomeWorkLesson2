using UnityEngine;

public class CitizenWorkState : IState
{
    private readonly IStateSwitcher _stateSwitcher;
    private readonly Citizen _citizen;

    private Transform _workingPlace;

    public CitizenWorkState(IStateSwitcher stateSwitcher, Citizen citizen, Transform workingPlace)
    {
        _stateSwitcher = stateSwitcher;
        _citizen = citizen;
        _workingPlace = workingPlace;
    }

    public void Enter()
    {
        _citizen.BehaviourSwitched += OnCitizenBehaviourSwitched;

        if (Vector3.Distance(_citizen.transform.position, _workingPlace.transform.position) < 1)
        {
            Debug.Log("работаю");
        }
        else
        {
            _stateSwitcher.SwitchStateForBehaviour(CitizenBehaviours.Move);
        }
    }

    public void Exit()
    {
        _citizen.BehaviourSwitched -= OnCitizenBehaviourSwitched;
    }

    public void Update()
    {
        Debug.Log("work work work...");
    }

    private void OnCitizenBehaviourSwitched(CitizenBehaviours newBehaviour)
    {
        _stateSwitcher.SwitchStateForBehaviour(newBehaviour);
    }
}
