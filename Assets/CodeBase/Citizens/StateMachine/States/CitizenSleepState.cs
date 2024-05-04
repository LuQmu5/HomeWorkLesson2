using UnityEngine;

public class CitizenSleepState : IState
{
    private readonly IStateSwitcher _stateSwitcher;
    private readonly Citizen _citizen;

    private Transform _bed;

    public CitizenSleepState(IStateSwitcher stateSwitcher, Citizen citizen, Transform bed)
    {
        _stateSwitcher = stateSwitcher;
        _citizen = citizen; 
        _bed = bed;
    }

    public void Enter()
    {
        _citizen.BehaviourSwitched += OnCitizenBehaviourSwitched;

        if (Vector3.Distance(_citizen.transform.position, _bed.transform.position) < 1)
        {
            Debug.Log("сплу");
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
        Debug.Log("Zzz...");
    }

    private void OnCitizenBehaviourSwitched(CitizenBehaviours newBehaviour)
    {
        _stateSwitcher.SwitchStateForBehaviour(newBehaviour);
    }
}
