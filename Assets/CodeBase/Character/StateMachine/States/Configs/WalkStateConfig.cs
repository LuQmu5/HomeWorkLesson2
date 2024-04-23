using System;
using UnityEngine;

[Serializable]
public class WalkStateConfig
{
    [SerializeField] private float _walkSpeed;

    public float WalkSpeed => _walkSpeed;
}
