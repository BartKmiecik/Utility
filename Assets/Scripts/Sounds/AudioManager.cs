using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;

    private static AudioManager Instance;
    private int backgroundIndex;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (Instance == null)
        {
            Instance = this;
            backgroundIndex = 0;
        }
        else
        {
            Destroy(gameObject);
        }
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
        PlayList();
    }

    public void SetAllVolumeLevel(float volume)
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = volume;
        }
    }

    public void PlayList()
    {
        CancelInvoke("PlayList");
        Play(sounds[backgroundIndex].name);
        Invoke("PlayList", sounds[backgroundIndex].clip.length);
       
        ++backgroundIndex;
        if (backgroundIndex >= 3)
        {
            backgroundIndex = 0;
        }
        
    }

    public void SetVolume(string name, float value)
    {
        
        foreach(Sound s in sounds)
        {
            if(s.name == name)
            {
                s.source.volume = value;
            }
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s != null)
        {
            s.source.Play();
        }
    }

    public bool CheckIfContain(string name)
    {
        foreach(Sound s in sounds)
        {
            if(s.name == name)
            {
                return true;
            }
        }
        return false;
    }
}
