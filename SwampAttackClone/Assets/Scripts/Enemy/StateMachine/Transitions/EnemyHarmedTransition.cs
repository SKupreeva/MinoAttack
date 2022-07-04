using UnityEngine;

public class EnemyHarmedTransition : Transition
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.OnEnemyHarmed += OnEnemyHarmed;
    }

    private void OnDisable()
    {
        _enemy.OnEnemyHarmed -= OnEnemyHarmed;
    }

    private void OnEnemyHarmed(Enemy enemy)
    {
        NeedTransit = true;
    }
}
