using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Shop : MonoBehaviour
{
    [SerializeField] 
    private List<Weapon> _weapons;

    [SerializeField] 
    private Player _player;

    [SerializeField] 
    private WeaponView _template;

    [SerializeField] 
    private GameObject _itemContainer;

    [SerializeField]
    private GameObject _noMoneyPanel;

    private AudioSource _source;

    private List<Weapon> _spawnedWeapons = new List<Weapon>();

    private void OnEnable()
    {
        _source = GetComponent<AudioSource>();

        if(_spawnedWeapons.Count != 0)
        {
            return;
        }

        foreach (var weap in _weapons)
        {
            AddItem(weap);
            if (_player.Weapons.Contains(weap))
            {
                weap.Buy();
            }
        }
    }

    private void AddItem(Weapon weapon)
    {
        var view = Instantiate(_template.gameObject, _itemContainer.transform).GetComponent<WeaponView>();
        view.OnSellButtonClicked += OnSellButtonClick;

        var weap = Instantiate(weapon.gameObject, view.transform).GetComponent<Weapon>();
        view.Render(weap);

        _spawnedWeapons.Add(weap);
    }

    private void OnSellButtonClick(Weapon weapon, WeaponView view)
    {
        TrySellWeapon(weapon, view);
    }

    private void TrySellWeapon(Weapon weapon, WeaponView view)
    {
        if(weapon.Price <= _player.Money)
        {
            _player.BuyWeapon(weapon);
            weapon.Buy();
            _source.Play();
            view.OnSellButtonClicked -= OnSellButtonClick;
        }
        else
        {
            _noMoneyPanel.SetActive(true);
        }
    }
}