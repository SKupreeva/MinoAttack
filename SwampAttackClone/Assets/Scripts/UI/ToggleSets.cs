using UnityEngine;
using UnityEngine.UI;

public class ToggleSets : MonoBehaviour
{
    [SerializeField]
    private Button _on;

    [SerializeField]
    private Button _off;

    [SerializeField]
    private AudioType _type;

    [SerializeField]
    private AudioEvents _audioEvents;

    private void Start()
    {
        if (PlayerPrefs.GetInt(_type.ToString()) == 1)
        {
            ChangeStateDisplay(false);
            return;
        }

        ChangeStateDisplay(true);
    }

    public void OnONButtonClicked()
    {
        ChangeStateDisplay(false);
        PlayerPrefs.SetInt(_type.ToString(), 1);
        PlayerPrefs.Save();
    }

    public void OnOFFButtonClicked()
    {
        ChangeStateDisplay(true);
        PlayerPrefs.SetInt(_type.ToString(), 0);
        PlayerPrefs.Save();
    }

    private void ChangeStateDisplay(bool isOn)
    {
        _off.gameObject.SetActive(!isOn);
        _on.gameObject.SetActive(isOn);
        _audioEvents.OnAudioStateChanged?.Invoke(_type, isOn);
    }
}
