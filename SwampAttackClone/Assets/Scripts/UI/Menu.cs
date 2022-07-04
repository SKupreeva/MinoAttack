using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    [SerializeField]
    private GameObject _loserPanel;
 
    private void OnEnable()
    {
        _player.OnPlayerDied += OnPlayerDied;
    }

    private void OnDisable()
    {
        _player.OnPlayerDied -= OnPlayerDied;
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnExitAppButtonClick()
    {
        Application.Quit();
    }

    public void RestartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    private void OnPlayerDied()
    {
        _loserPanel.SetActive(true);
    }
}
