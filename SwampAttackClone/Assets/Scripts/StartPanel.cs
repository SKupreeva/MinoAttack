using UnityEngine;

public class StartPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject _instructionsPanel;

    [SerializeField]
    private NumbersController _numbersPanel;

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void OnStartButtonClicked()
    {
        if(PlayerPrefs.GetInt("Instructions") != 1)
        {
            _instructionsPanel.SetActive(true);
        }
        else
        {
            _numbersPanel.gameObject.SetActive(true);
            _numbersPanel.SetSpawner = true;
        }
        gameObject.SetActive(false);
    }
}
