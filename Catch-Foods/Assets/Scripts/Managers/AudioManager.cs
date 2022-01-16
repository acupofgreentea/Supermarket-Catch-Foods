using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    private float musicVolume;
    private float soundEffectVolume;
    [SerializeField] protected AudioMixerGroup musicMixerGroup;
    [SerializeField] protected AudioMixerGroup soundEffectMixerGroup;

    private void Awake() 
    {
        DontDestroyOnLoad(gameObject);
    }
    public void OnMusicSliderValueChanged(float value)
    {
        musicVolume = value;

        UpdateMusicMixerVolume();
    }
    public void OnSoundEffectValueChanged(float value)
    {
        soundEffectVolume = value;

        UpdateSoundEffectMixerVolume();
    }

    private void UpdateMusicMixerVolume()
    {
        musicMixerGroup.audioMixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume) * 20);
    }
    private void UpdateSoundEffectMixerVolume()
    {
        soundEffectMixerGroup.audioMixer.SetFloat("SoundEffectVolume", Mathf.Log10(soundEffectVolume) * 20);
    }
    
}
