using UnityEngine;

[CreateAssetMenu(menuName = "AudioEvent/Simple")]
public class SimpleAudioEvent : AudioEvent
{
    public override void PlayAudio(AudioSource source, int clipIndex)
    {
        if(clips.Length == 0) return;

        source.clip = clips[clipIndex];
        source.volume = volume;
        source.outputAudioMixerGroup = mixer;
        
        source.Play();
    }
}
