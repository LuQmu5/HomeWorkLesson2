using UnityEngine;

public class AirborneState : MovementState
{
    public AirborneState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {

    }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = Character.Config.AirborneStateConfig.AirborneSpeed;

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

        Data.YVelocity -= Mathf.Pow(Character.Config.AirborneStateConfig.BaseGravity, 2) * Time.deltaTime;    
    }
}
