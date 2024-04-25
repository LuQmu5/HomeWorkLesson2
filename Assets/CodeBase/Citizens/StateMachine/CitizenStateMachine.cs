public class CitizenStateMachine
{
    private Citizen _citizen;
    private IState _currentState;

    public CitizenStateMachine(Citizen citizen)
    {
        _citizen = citizen;
    }

    public void SwitchStateForBehaviour(CitizenBehaviour newBehaviour)
    {
        if (newBehaviour is CitizenSleepBehaviour)
        {
            _currentState?.Exit();
            _currentState = new CitizenSleepState(_citizen);
            _currentState.Enter();
        }
        else if (newBehaviour is CitizenWorkBehaviour)
        {
            _currentState?.Exit();
            _currentState = new CitizenWorkState(_citizen);
            _currentState.Enter();
        }
    }

    public void Update() => _currentState?.Update();
}
