using UnityEngine;

public class LevelUpper : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ILevelable levelable))
        {
            levelable.IncreaseLevel();
        }
    }
}