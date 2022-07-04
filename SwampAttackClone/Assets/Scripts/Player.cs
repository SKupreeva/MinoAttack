using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] 
    private int _health;

    [SerializeField] 
    private List<Weapon> _weapons;

    [SerializeField] 
    private Transform _shootPoint;

    [SerializeField]
    private AudioSource _changeWeaponSound;

    [SerializeField]
    private AudioSource _harmedSound;

    [SerializeField]
    private AudioSource _shotSound;

    public int Money { get; private set; }

    public List<Weapon> Weapons => _weapons;

    public event UnityAction<int, int> OnHealthChanged;
    public event UnityAction<int> OnMoneyChanged;
    public event UnityAction OnPlayerDied;

    private Weapon _currentWeapon;
    private int _currentWeaponNumber = 0;
    private int _currentHealth;
    private Animator _animator;

    private void Start()
    {
        ChangeWeapon();
        _currentHealth = _health;
        _animator = GetComponent<Animator>();
    }

    public void Shoot()
    {
        _currentWeapon.Shoot(_shootPoint);
        _animator.SetTrigger("Shoot");
        _shotSound.Play();
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        Weapons.Add(weapon);
        OnMoneyChanged?.Invoke(Money);
        _currentWeaponNumber++;
        ChangeWeapon();
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        OnHealthChanged?.Invoke(_currentHealth, _health);
        _animator.SetTrigger("Harmed");
        _harmedSound.Play();

        if (_currentHealth <= 0)
        {
            OnPlayerDied?.Invoke();
            _animator.SetTrigger("Dead");
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
        OnMoneyChanged?.Invoke(Money);
    }

    public void OnDeathAnimationEnd()
    {
        Destroy(gameObject);
    }

    private void ChangeWeapon()
    {
        if(_currentWeapon != Weapons[_currentWeaponNumber] || !_currentWeapon)
        {
            var newWeap = Instantiate(Weapons[_currentWeaponNumber].gameObject, transform).GetComponent<Weapon>();
            _currentWeapon = newWeap;
            _changeWeaponSound.Play();
        }
    }
}
