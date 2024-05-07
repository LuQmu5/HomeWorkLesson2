using System;
using UnityEngine;

[Serializable]
public class GroundedStateConfig
{
    [field: SerializeField, Min(1)] public float NormalRunSpeed { get; private set; }
    [field: SerializeField, Min(1)] public float WalkSpeed { get; private set; }
    [field: SerializeField, Min(1)] public float SprintSpeed { get; private set; }
}
