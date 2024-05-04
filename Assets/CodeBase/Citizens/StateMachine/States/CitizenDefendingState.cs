using System.Collections;
using UnityEngine;

public class CitizenDefendingState : CitizenTimedActionState
{
    public CitizenDefendingState(IStateSwitcher stateSwitcher, Citizen citizen) : base(stateSwitcher, citizen)
    {
    }

    protected override void OnTimerEnded()
    {
        Debug.Log("Просто ветер...");


        _stateSwitcher.SwitchStateForBehaviour(_citizen.CurrentRoutineBehaviour);
    }

    protected override void OnTimerStarted()
    {
        Debug.Log("Я тебе покажу как связываться со мной");
    }
}
