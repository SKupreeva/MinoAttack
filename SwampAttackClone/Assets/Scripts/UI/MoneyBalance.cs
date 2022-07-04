using TMPro;
using UnityEngine;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text _moneyCount;

    [SerializeField] 
    private Player _player;

    private void OnEnable()
    {
        _moneyCount.text = _player.Money.ToString();
        _player.OnMoneyChanged += OnMoneyCountChanged;
    }

    private void OnDisable()
    {
        _player.OnMoneyChanged -= OnMoneyCountChanged;
    }

    private void OnMoneyCountChanged(int money)
    {
        _moneyCount.text = money.ToString();
    }
}
