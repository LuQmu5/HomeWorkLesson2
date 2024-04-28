using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    private const string CharacterConfigPath = "StaticData/CharacterConfig/CharacterConfig";

    [SerializeField] private Character _character;

    private void Awake()
    {
        CharacterConfig characterConfig = Resources.Load<CharacterConfig>(CharacterConfigPath);
        _character.Init(characterConfig);
    }
}