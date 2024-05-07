public class DamagedState : BaseState
{
    public DamagedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Character.View.PlayDamagedAnimation();
    }

    public override void Update()
    {
        if (Character.KnockingBackCoroutine == null)
            StateSwitcher.SwitchState<IdlingState>();
    }
}
