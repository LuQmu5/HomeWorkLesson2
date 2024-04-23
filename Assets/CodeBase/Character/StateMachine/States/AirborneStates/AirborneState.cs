using UnityEngine;

public class AirborneState : MovementState
{
    private readonly AirborneStateConfig _config;

    public AirborneState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.AirborneStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.Speed;

        View.StartAirborne();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopAirborne();    
    }

    public override void Update()
    {
        base.Update();

        Data.YVelocity -= _config.BaseGravity * Time.deltaTime;    
    }
}
