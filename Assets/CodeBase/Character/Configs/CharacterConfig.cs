using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig", order = 54)]
public class CharacterConfig : ScriptableObject
{
    [field: SerializeField] public GroundedStateConfig GroundedStateConfig { get; private set; }
    [field: SerializeField] public AirborneStateConfig AirborneStateConfig { get; private set; }
    [field: SerializeField, Min(1)] public int StartLevel { get; private set; }
    [field: SerializeField, Min(1)] public int StartMaxHealth { get; private set; }
}
