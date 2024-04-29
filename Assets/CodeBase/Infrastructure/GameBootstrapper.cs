using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    private const string CharacterConfigPath = "StaticData/CharacterConfig/CharacterConfig";

    [SerializeField] private Character _character;
    [SerializeField] private CharacterStatsDisplay _characterStatsDisplay;
    [SerializeField] private GameOverPanel _gameOverPanel;
    [SerializeField] private GameObject[] _resetableObjects;

    private void Awake()
    {
        CharacterConfig characterConfig = Resources.Load<CharacterConfig>(CharacterConfigPath);

        CharacterStats characterStats = new CharacterStats();
        GameManagement gameManagement = new GameManagement(characterStats, _character, _resetableObjects);
        GameManagementMediator gameManagementMediator = new GameManagementMediator(_gameOverPanel, characterStats, gameManagement);

        _character.Init(characterConfig, characterStats);
        _characterStatsDisplay.Init(characterStats);
    }
}
