public class DamagedState : IState
{
    private CharacterStateMachine _stateMachine;
    private Character _character;

    public DamagedState(CharacterStateMachine stateMachine, Character character)
    {
        _stateMachine = stateMachine;
        _character = character;
    }

    public void Enter()
    {
        
    }

    public void Exit()
    {
        
    }

    public void HandleInput()
    {
        
    }

    public void Update()
    {
        
    }
}
