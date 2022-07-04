using UnityEngine;

public class InstructionsPanel : MonoBehaviour
{
    [SerializeField]
    private NumbersController _numbersPanel;

    public void OnScreenClicked()
    {
        PlayerPrefs.SetInt("Instructions", 1);
        _numbersPanel.gameObject.SetActive(true);
        _numbersPanel.SetSpawner = true;
        gameObject.SetActive(false);
    }
}
