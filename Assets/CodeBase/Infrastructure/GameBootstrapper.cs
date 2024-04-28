using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    private const string CharacterConfigPath = "StaticData/CharacterConfig/CharacterConfig";

    [SerializeField] private Character _character;
    [SerializeField] private CharacterStatsDisplay _characterStatsDisplay;

    private void Awake()
    {
        CharacterConfig characterConfig = Resources.Load<CharacterConfig>(CharacterConfigPath);
        CharacterStats characterStats = new CharacterStats();

        _character.Init(characterConfig, characterStats);
        _characterStatsDisplay.Init(characterStats);
    }
}