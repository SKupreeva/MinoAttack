using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioChunk : MonoBehaviour
{
    [SerializeField]
    private AudioType _audioType;

    [SerializeField]
    private AudioEvents _audioEvents;

    private AudioSource _source;

    private void OnEnable()
    {
        _source = GetComponent<AudioSource>();
        _audioEvents.OnAudioStateChanged += OnAudioStateChanged;
        if (PlayerPrefs.GetInt(_audioType.ToString()) == 1)
        {
            _source.mute = true;
            return;
        }
    }

    private void OnDisable()
    {
        _audioEvents.OnAudioStateChanged -= OnAudioStateChanged;
    }

    private void OnAudioStateChanged(AudioType type, bool isOn)
    {
        if(_audioType == type)
        {
            _source.mute = !isOn;
        }
    }
}
