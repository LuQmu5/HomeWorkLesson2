public interface ILevelable
{
    public int CurrentLevel { get; }

    public void IncreaseLevel(int amount = 1);
}
