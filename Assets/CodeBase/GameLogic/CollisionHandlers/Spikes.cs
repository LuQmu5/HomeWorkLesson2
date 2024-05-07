using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamagable damagable))
        {
            if (other.TryGetComponent(out IKnockbackable knockbackable))
                knockbackable.Knockback(transform.position);

            damagable.ApplyDamage(_damage);
        }
    }
}