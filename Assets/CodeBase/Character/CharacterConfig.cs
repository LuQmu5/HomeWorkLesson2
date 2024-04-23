using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig", order = 54)]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private GroundedStateConfig _groundedStateConfig;
    [SerializeField] private AirborneStateConfig _airborneStateConfig;

    public GroundedStateConfig GroundedStateConfig => _groundedStateConfig;
    public AirborneStateConfig AirborneStateConfig => _airborneStateConfig;
}
