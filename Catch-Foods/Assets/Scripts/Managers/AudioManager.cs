using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sounds[] sounds;
}


[Serializable]
public class Sounds
{
    public AudioSource source;

    public AudioClip clip;

    public AudioMixerGroup mixer;
}
