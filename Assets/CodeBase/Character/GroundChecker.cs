using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private const float LegsRadius = 0.1f;

    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _legs;

    public bool OnGround { get; private set; }

    private void FixedUpdate() => OnGround = Physics.CheckSphere(_legs.position, LegsRadius, _groundMask);
}
