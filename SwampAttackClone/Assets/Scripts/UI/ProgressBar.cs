using UnityEngine;

public class ProgressBar : Bar
{
    [SerializeField] 
    private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.OnEnemyCountChanged += OnValueChanged;
        Slider.value = 0;
    }

    private void OnDisable()
    {
        _spawner.OnEnemyCountChanged -= OnValueChanged;
    }
}
