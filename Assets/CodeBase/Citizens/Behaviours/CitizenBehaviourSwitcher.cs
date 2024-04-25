public class CitizenBehaviourSwitcher
{
    public CitizenBehaviour CurrentBehaviour { get; private set; }

    public CitizenBehaviourSwitcher(CitizenBehaviour startBehaviour)
    {
        CurrentBehaviour = startBehaviour;
    }

    public bool TryChangeBehaviour(CitizenBehaviour newBehaviour)
    {
        if (newBehaviour == null)
            return false;

        if (IsCurrentBehaviourSwitchable(newBehaviour) == false)
            return false;

        CurrentBehaviour = newBehaviour;

        return true;
    }

    private bool IsCurrentBehaviourSwitchable(CitizenBehaviour newBehaviour)
    {
        return CurrentBehaviour == null
            || CurrentBehaviour.IsActionCompleted == true
            || CurrentBehaviour.PrioritateWeight < newBehaviour.PrioritateWeight;
    }
}
