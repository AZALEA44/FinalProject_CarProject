using UnityEngine;
using System.Collections.Generic;

public class SoundEffectManager : MonoBehaviour
{
    public static SoundEffectManager Instance;

    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        public float volume = 1f;
        public bool loop = false;
    }

    public List<Sound> sounds = new List<Sound>();

    private Dictionary<string, AudioSource> soundSources = new Dictionary<string, AudioSource>();

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeSounds();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void InitializeSounds()
    {
        foreach (Sound s in sounds)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = s.clip;
            source.volume = s.volume;
            source.loop = s.loop;
            soundSources[s.name] = source;
        }
    }

    public void Play(string name)
    {
        if (soundSources.ContainsKey(name))
        {
            soundSources[name].Play();
        }
        else
        {
            Debug.LogWarning("Sound not found: " + name);
        }
    }

    public void Stop(string name)
    {
        if (soundSources.ContainsKey(name))
        {
            soundSources[name].Stop();
        }
    }
}
