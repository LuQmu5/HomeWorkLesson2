using System;
using UnityEngine;

[Serializable]
public class GroundedStateConfig
{
    [SerializeField] private float _normalSpeed;
    [SerializeField] private WalkStateConfig _walkStateConfig;
    [SerializeField] private SprintStateConfig _sprintStateConfig;

    public float NormalSpeed => _normalSpeed;
    public WalkStateConfig WalkStateConfig => _walkStateConfig;
    public SprintStateConfig SprintStateConfig => _sprintStateConfig;
}
