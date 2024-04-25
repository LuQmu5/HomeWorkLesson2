public abstract class CitizenBehaviour
{
    public abstract int PrioritateWeight { get; protected set; }
    public abstract bool IsActionCompleted { get; protected set; }
    public abstract CitizenBehaviour BehaviourAfterCompleteAction { get; protected set; }
}

public class CitizenSleepBehaviour : CitizenBehaviour
{
    public override int PrioritateWeight { get => throw new System.NotImplementedException(); protected set => throw new System.NotImplementedException(); }
    public override bool IsActionCompleted { get => throw new System.NotImplementedException(); protected set => throw new System.NotImplementedException(); }
    public override CitizenBehaviour BehaviourAfterCompleteAction { get => throw new System.NotImplementedException(); protected set => throw new System.NotImplementedException(); }
}