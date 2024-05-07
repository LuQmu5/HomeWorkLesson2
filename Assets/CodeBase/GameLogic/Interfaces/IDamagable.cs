public interface IDamagable
{
    public int MaxHealth { get; }
    public int CurrentHealth { get; }

    public void ApplyDamage(int amount);
}
