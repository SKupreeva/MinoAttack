using UnityEngine;
using UnityEngine.UI;

public class AttackControl : MonoBehaviour
{
    [SerializeField] 
    private Button _control;

    [SerializeField] 
    private Player _player;

    private void OnEnable()
    {
        _control.onClick.AddListener(OnControlClick);
        _player.OnPlayerDied += RemoveListener;
    }

    private void OnDisable()
    {
        RemoveListener();
        _player.OnPlayerDied -= RemoveListener;
    }

    private void OnControlClick()
    {
        _player.Shoot();
    }

    private void RemoveListener()
    {
        _control.onClick.RemoveListener(OnControlClick);
    }
}
