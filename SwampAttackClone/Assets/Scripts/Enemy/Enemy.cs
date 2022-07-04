using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] 
    private int _health;

    [SerializeField] 
    private int _reward;

    [SerializeField]
    private AudioSource _harmedSound;

    [SerializeField]
    private TextMeshProUGUI _rewardText;

    private Player _target;

    public event UnityAction<Enemy> OnEnemyDied;
    public event UnityAction<Enemy> OnEnemyHarmed;

    public Player Target => _target;
    public int Reward => _reward;

    public void Init(Player target)
    {
        _target = target;
        _rewardText.text = "+" + _reward.ToString();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _harmedSound.Play();

        if (_health <= 0)
        {
            OnEnemyDied?.Invoke(this);
            return;
        }
        OnEnemyHarmed?.Invoke(this);
    }
}
