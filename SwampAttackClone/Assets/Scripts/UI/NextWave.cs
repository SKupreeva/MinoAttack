using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] 
    private Spawner _spawner;

    [SerializeField] 
    private Button _nextWaveButton;

    [SerializeField]
    private NumbersController _numbersPanel;

    private void OnEnable()
    {
        _spawner.OnAllWaveEnemyDead += OnAllEnemySpawned;
        _nextWaveButton.onClick.AddListener(OnNextWaveButoonClicked);
    }

    private void OnDisable()
    {
        _spawner.OnAllWaveEnemyDead -= OnAllEnemySpawned;
        _nextWaveButton.onClick.RemoveListener(OnNextWaveButoonClicked);
    }

    private void OnAllEnemySpawned()
    {
        _nextWaveButton.gameObject.SetActive(true);
    }

    private void OnNextWaveButoonClicked()
    {
        _numbersPanel.gameObject.SetActive(true);
        _numbersPanel.SetSpawner = false;
        _nextWaveButton.gameObject.SetActive(false);
    }
}
