using UnityEngine;
using UnityEngine.Audio;
using System;

[Serializable]
public class Sounds
{
    [HideInInspector] public AudioSource source;
    
    public AudioClip clip;

    public AudioMixerGroup mixer;

    public bool isLoop;

    public bool isPlayOnAwake;

    public float volume;
}
