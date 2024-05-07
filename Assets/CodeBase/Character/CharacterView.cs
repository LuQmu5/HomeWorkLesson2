using System.Collections;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _model;

    private const string IsGrounded = nameof(IsGrounded);
    private const string IsIdling = nameof(IsIdling);
    private const string IsWalking = nameof(IsWalking);
    private const string IsRunning = nameof(IsRunning);
    private const string IsSprinting = nameof(IsSprinting);

    private const string IsJumping = nameof(IsJumping);
    private const string IsFalling = nameof(IsFalling);

    private const string IsMovement = nameof(IsMovement);
    private const string IsAirborne = nameof(IsAirborne);

    private SkinnedMeshRenderer[] _renderers;

    private Coroutine _damagedAnimationCoroutine;
    private Color _normalColor = Color.white;
    private Color _damagedColor = Color.red;

    public Coroutine KnockingBackCoroutine { get; private set; }

    private void Start() => _renderers = transform.GetComponentsInChildren<SkinnedMeshRenderer>();

    public void Show()
    {
        _model.gameObject.SetActive(true);
    }

    public void Hide()
    {
        if (KnockingBackCoroutine != null)
            StopCoroutine(KnockingBackCoroutine);

        if (_damagedAnimationCoroutine != null)
            StopCoroutine(_damagedAnimationCoroutine);

        KnockingBackCoroutine = null;
        _damagedAnimationCoroutine = null;

        foreach (var renderer in _renderers)
            renderer.materials[0].color = _normalColor;

        _model.gameObject.SetActive(false);
    }

    public void PlayDamagedAnimation()
    {
        if (_damagedAnimationCoroutine != null)
            StopCoroutine(_damagedAnimationCoroutine);

        _damagedAnimationCoroutine = StartCoroutine(DamagedAnimationPlaying());
    }

    public void PlayKnockingBackAnimation(Vector3 from)
    {
        if (KnockingBackCoroutine != null)
            StopCoroutine(KnockingBackCoroutine);

        KnockingBackCoroutine = StartCoroutine(KnocningBack(from));
    }

    public void StartIdling() => _animator.SetBool(IsIdling, true);
    public void StopIdling() => _animator.SetBool(IsIdling, false);

    public void StartRunning() => _animator.SetBool(IsRunning, true);
    public void StopRunning() => _animator.SetBool(IsRunning, false);

    public void StartGrounded() => _animator.SetBool(IsGrounded, true);
    public void StopGrounded() => _animator.SetBool(IsGrounded, false);

    public void StartJumping() => _animator.SetBool(IsJumping, true);
    public void StopJumping() => _animator.SetBool(IsJumping, false);

    public void StartFalling() => _animator.SetBool(IsFalling, true);
    public void StopFalling() => _animator.SetBool(IsFalling, false);

    public void StartAirborne() => _animator.SetBool(IsAirborne, true);
    public void StopAirborne() => _animator.SetBool(IsAirborne, false);

    public void StartMovement() => _animator.SetBool(IsMovement, true);
    public void StopMovement() => _animator.SetBool(IsMovement, false);

    public void StartWalking() => _animator.SetBool(IsWalking, true);
    public void StopWalking() => _animator.SetBool(IsWalking, false);

    public void StartSprinting() => _animator.SetBool(IsSprinting, true);
    public void StopSprinting() => _animator.SetBool(IsSprinting, false);

    private IEnumerator DamagedAnimationPlaying()
    {
        int iterations = 3;
        float delayBetweenIterations = 0.1f;
        WaitForSeconds delay = new WaitForSeconds(delayBetweenIterations);

        for (int i = 0; i < iterations; i++)
        {
            foreach (var renderer in _renderers)
                renderer.materials[0].color = _damagedColor;

            yield return delay;

            foreach (var renderer in _renderers)
                renderer.materials[0].color = _normalColor;

            yield return delay;
        }

        _damagedAnimationCoroutine = null;
    }

    private IEnumerator KnocningBack(Vector3 from)
    {
        int directionX = transform.position.x < from.x ? -1 : 1;
        Vector3 firstPoint = transform.position + new Vector3(directionX * 2.2f, 0);
        Vector3 secondPoint = transform.position + new Vector3(directionX * 1.7f, 2);
        Vector3 thirdPoint = transform.position + new Vector3(directionX * 1.2f, 3);
        Vector3 fourthPoint = transform.position;
        float time = 1; // 0 - 1
        float speed = 2;

        while (time > 0)
        {
            transform.position = Bezier.GetPoint(firstPoint, secondPoint, thirdPoint, fourthPoint, time);

            time -= Time.deltaTime * speed;

            yield return null;
        }

        KnockingBackCoroutine = null;
    }
}
