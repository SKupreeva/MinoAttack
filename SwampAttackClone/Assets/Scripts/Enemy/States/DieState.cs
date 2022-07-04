using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DieState : State
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.SetTrigger("Die");
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
