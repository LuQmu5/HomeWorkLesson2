using System;
using UnityEngine;

[Serializable]
public class SprintStateConfig
{
    [SerializeField] private float _sprintSpeed;

    public float SprintSpeed => _sprintSpeed;
}
