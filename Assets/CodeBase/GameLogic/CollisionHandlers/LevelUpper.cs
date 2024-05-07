using UnityEngine;

[RequireComponent(typeof(Collider))]
public class LevelUpper : RefreshableObject
{
    private Collider _collider;
    private Canvas _canvas;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _canvas = GetComponentInChildren<Canvas>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ILevelable levelable))
        {
            levelable.IncreaseLevel();
            _collider.enabled = false;
            _canvas.gameObject.SetActive(false);
        }
    }

    public override void Refresh()
    {
        _collider.enabled = true;
        _canvas.gameObject.SetActive(true);
    }
}
