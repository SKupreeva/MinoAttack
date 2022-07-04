using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scriptables/AudioEvent")]
public class AudioEvents : ScriptableObject
{
    public UnityAction<AudioType, bool> OnAudioStateChanged;
}

public enum AudioType
{
    Music,
    Sound
}