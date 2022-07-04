using UnityEngine;

public class EnemyDieTransition : Transition
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.OnEnemyDied += (enemy) => NeedTransit = true;
    }

    private void OnDisable()
    {
        _enemy.OnEnemyDied -= (enemy) => NeedTransit = true;
    }

}
