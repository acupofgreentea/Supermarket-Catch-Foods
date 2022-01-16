using UnityEngine;
using System;

[Serializable]
public class Sounds
{
    [HideInInspector] public AudioSource source;
    public AudioClip clip;

    public enum AudioTypes{SoundEffect, Music}

    public AudioTypes audioTypes;

    public bool isLoop;

    public bool isPlayOnAwake;

    public float volume;
}
