using UnityEngine;
using UnityEngine.Audio;

public abstract class AudioEvent : ScriptableObject
{
    [Range(0,1)]
    [SerializeField] protected float volume;

    [SerializeField] protected AudioClip[] clips;

    [SerializeField] protected AudioMixerGroup mixer;
    
    public abstract void PlayAudio(AudioSource source, int clipIndex);
}
