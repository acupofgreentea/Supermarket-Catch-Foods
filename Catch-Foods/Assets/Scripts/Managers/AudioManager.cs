using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sounds[] sounds;

    [SerializeField] private AudioMixerGroup musicMixerGroup;
    [SerializeField] private AudioMixerGroup soundEffectMixerGroup;

    private float musicVolume;
    
    private void Awake() 
    {
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.isLoop;
            s.source.volume = s.volume;
            s.source.playOnAwake = s.isPlayOnAwake;

            switch (s.audioTypes)
            {
                case Sounds.AudioTypes.SoundEffect:
                    s.source.outputAudioMixerGroup = soundEffectMixerGroup;
                    break;

                case Sounds.AudioTypes.Music:
                    s.source.outputAudioMixerGroup = musicMixerGroup;
                    break;
            }
            if(s.isPlayOnAwake)
            {
                s.source.Play();
            }
        }
    }

    //play method



    public void OnMusicSliderValueChanged(float value)
    {
        musicVolume = value;

        UpdateMixerVolume();
    }

    private void UpdateMixerVolume()
    {
        musicMixerGroup.audioMixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume) * 20);
    }
}

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
