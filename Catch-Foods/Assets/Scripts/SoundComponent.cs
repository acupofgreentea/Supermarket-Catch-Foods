using UnityEngine;

public class SoundComponent : AudioManager
{
    [SerializeField] protected Sounds[] sounds;
    
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

    public void PlaySound(int index)
    {
        sounds[index].source.Play();
    }
}