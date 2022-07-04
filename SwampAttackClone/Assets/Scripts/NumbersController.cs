using UnityEngine;

public class NumbersController : MonoBehaviour
{
    [SerializeField]
    private Spawner _spawner;

    public bool SetSpawner { get; set; }

    private void OnAnimationEnds()
    {
        if (SetSpawner)
        {
            _spawner.SetWave(0);
        }
        else
        {
            _spawner.NextWave();
        }
        gameObject.SetActive(false);
    }
}
