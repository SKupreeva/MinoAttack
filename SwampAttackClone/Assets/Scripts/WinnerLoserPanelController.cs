using UnityEngine;

public class WinnerLoserPanelController : MonoBehaviour
{
    [SerializeField]
    private GameObject _restartPanel;

    private void OnAnimationEnd()
    {
        _restartPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
