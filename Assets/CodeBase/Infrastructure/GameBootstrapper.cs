using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    private const string CharacterConfigPath = "StaticData/CharacterConfig/CharacterConfig";

    [SerializeField] private Character _character;
    [SerializeField] private GameOverPanel _gameOverPanel;
    [SerializeField] private CharacterStatsDisplay _characterStatsDisplay;
    [SerializeField] private RefreshableObject[] _refreshableObjects;

    private void Awake()
    {
        CharacterStats characterStats = InitCharacter();
        InitManagers(characterStats);
        InitUI(characterStats);
    }

    private CharacterStats InitCharacter()
    {
        CharacterConfig characterConfig = Resources.Load<CharacterConfig>(CharacterConfigPath);
        CharacterStats characterStats = new CharacterStats(characterConfig.StartLevel, characterConfig.StartMaxHealth);
        _character.Init(characterConfig, characterStats);

        return characterStats;
    }

    private void InitManagers(CharacterStats characterStats)
    {
        GameManagement gameManagement = new GameManagement(characterStats, _character, _refreshableObjects);
        GameManagementMediator gameManagementMediator = new GameManagementMediator(_gameOverPanel, _character, gameManagement);
    }

    private void InitUI(CharacterStats characterStats)
    {
        _characterStatsDisplay.Init(characterStats);
    }
}
