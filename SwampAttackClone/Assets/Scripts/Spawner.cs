using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] 
    private List<Wave> _waves;

    [SerializeField] 
    private Transform _spawnPoint;

    [SerializeField] 
    private Player _player;

    [SerializeField]
    private GameObject _winnerPanel;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;

    private int _spawnedSum;
    private bool _allSpawned = false;

    private List<Enemy> _spawnedEnemies = new List<Enemy>();

    public event UnityAction OnAllWaveEnemyDead;
    public event UnityAction<int, int> OnEnemyCountChanged;

    private void Start()
    {
        SetSpawnedSum();
    }

    private void Update()
    {
        if (_currentWave == null)
        {
            return;
        }

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstanciateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
            OnEnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
        }

        if (_currentWave.Count <= _spawned)
        {
            _spawnedSum -= _spawned;
            _allSpawned = true;
            _currentWave = null;
        } 
    }

    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0;
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.OnEnemyDied -= OnEnemyDying;
        _player.AddMoney(enemy.Reward);
        if(_spawnedSum == 0)
        {
            _winnerPanel.SetActive(true);
        }

        if (_spawnedEnemies.Count <= 1 && _allSpawned && _waves.Count > _currentWaveNumber + 1)
        {
            OnAllWaveEnemyDead?.Invoke();
        }
        _spawnedEnemies.Remove(enemy);
    }

    private void InstanciateEnemy()
    {
        var enemy = Instantiate(_currentWave.Template, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_player);
        enemy.OnEnemyDied += OnEnemyDying;
        _spawnedEnemies.Add(enemy);
    }

    public void SetWave(int index)
    {
        _currentWave = _waves[index];
        OnEnemyCountChanged?.Invoke(0, 1);
    }

    private void SetSpawnedSum()
    {
        _spawnedSum = 0;
        foreach (var wave in _waves)
        {
            _spawnedSum += wave.Count;
        }
    }
}

[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;
}