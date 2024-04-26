using UnityEngine;

public class CitizenTradingState : IState
{
    private Citizen _citizen;

    public CitizenTradingState(Citizen citizen)
    {
        _citizen = citizen;
    }

    public void Enter()
    {
        Debug.Log("Ну го трейданем...");
        _citizen.Mover.isStopped = true;
    }

    public void Exit()
    {
        Debug.Log("Приходи еще!");
    }

    public void Update()
    {
    }
}