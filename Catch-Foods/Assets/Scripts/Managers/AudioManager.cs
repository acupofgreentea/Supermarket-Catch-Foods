using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	[SerializeField] private AudioMixerGroup musicMixerGroup;
	[SerializeField] private AudioMixerGroup soundEffectMixerGroup;

	[SerializeField] private AudioEvent musicEvent;

	private AudioSource source;
	private float musicVolume;
	private float soundEffectVolume;

	private void Awake()
	{	
		source = GetComponent<AudioSource>();

		DontDestroyOnLoad(gameObject);
	}
	private void Start() => musicEvent.PlayAudio(source, 0);

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
