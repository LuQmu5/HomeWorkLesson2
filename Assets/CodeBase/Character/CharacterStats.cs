using System;

public class CharacterStats
{
    private int _startLevel;
    private int _startMaxHealth;

    public int CurrentLevel { get; private set; }
    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }

    public event Action<int> LevelChanged;
    public event Action<int> HealthChanged;

    public CharacterStats(int startLevel, int startMaxHealth)
    {
        _startLevel = startLevel;
        _startMaxHealth = startMaxHealth;

        CurrentLevel = _startLevel;
        MaxHealth = _startMaxHealth;
        CurrentHealth = _startMaxHealth;

        LevelChanged?.Invoke(CurrentLevel);
        HealthChanged?.Invoke(CurrentHealth);
    }

    public void ResetStats()
    {
        CurrentLevel = _startLevel;
        MaxHealth = _startMaxHealth;
        CurrentHealth = _startMaxHealth;

        LevelChanged?.Invoke(CurrentLevel);
        HealthChanged?.Invoke(CurrentHealth);
    }

    public void IncreaseLevel(int amount = 1)
    {
        if (amount < 1)
            throw new ArgumentOutOfRangeException(nameof(amount) + " can't be less than 1");

        CurrentLevel += amount;

        LevelChanged?.Invoke(CurrentLevel);
    }

    public void DecreaseCurrentHealth(int amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount) + " can't be less than 0");

        CurrentHealth -= amount;

        if (CurrentHealth < 0)
            CurrentHealth = 0;

        HealthChanged?.Invoke(CurrentHealth);
    }
}
