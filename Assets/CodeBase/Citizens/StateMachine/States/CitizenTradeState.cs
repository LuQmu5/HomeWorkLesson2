using UnityEngine;

public class CitizenTradeState : CitizenFailableActionState
{
    private CitizenTrader _citizenTrader;

    public CitizenTradeState(IStateSwitcher stateSwitcher, CitizenTrader citizen) : base(stateSwitcher, citizen)
    {
        _citizenTrader = citizen;
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("ПОДХОДИТЕ, НОВЫЕ ТОВАРЫ!");
    }

    protected override bool IsActionCanStarted()
    {
        return _citizen.IsWayPointReached();
    }

    protected override void OnActionStartFailed()
    {
        _stateSwitcher.SwitchStateForBehaviour(CitizenBehaviours.Move);
    }

    protected override void StartAction()
    {
        _citizenTrader.TradingStarted += StartTrade;
        _citizenTrader.TradingEnded += EndTrade;
    }

    protected override void StopAction()
    {
        _citizenTrader.TradingStarted -= StartTrade;
        _citizenTrader.TradingEnded -= EndTrade;

        EndTrade();
    }

    private void EndTrade()
    {
        Debug.Log("end trade");
    }

    private void StartTrade()
    {
        Debug.Log("start trade");
    }
}
