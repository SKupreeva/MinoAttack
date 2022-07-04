using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CelebrationState : State
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.SetTrigger("Celebrate");
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
