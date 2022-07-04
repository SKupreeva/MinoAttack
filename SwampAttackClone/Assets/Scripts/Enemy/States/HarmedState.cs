using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HarmedState : State
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.SetTrigger("Harmed");
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
