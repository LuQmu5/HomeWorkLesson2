using System;
using UnityEngine;

[Serializable]
public class AirborneStateConfig
{
    [field: SerializeField, Min(0)] public float JumpPower { get; private set; }
    [field: SerializeField, Min(0)] public float AirborneSpeed { get; private set; }
    [field: SerializeField, Min(1)] public float BaseGravity { get; private set; }
}
