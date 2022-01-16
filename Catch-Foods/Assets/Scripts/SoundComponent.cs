using UnityEngine;

public class SoundComponent : MonoBehaviour
{
    [SerializeField] protected Sounds[] sounds;
    
    private void Awake() 
    {
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.mixer;
            s.source.loop = s.isLoop;
            s.source.volume = s.volume;
            s.source.playOnAwake = s.isPlayOnAwake;

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