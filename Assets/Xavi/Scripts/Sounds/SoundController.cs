using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
class SoundData
{
    public AudioClip clip;
    public bool play_on_awake;
    public bool loop;

    [Range(0.0f, 1f)]
    public float volume = 1f;

    public AudioMixerGroup amg;
}

public class SoundController : MonoBehaviour
{
    [SerializeField]
    private List<SoundData> sounds_list = new List<SoundData>();

    private Dictionary<string, AudioSource> sounds = new Dictionary<string, AudioSource>();

    private static SoundController _instance;
    public static SoundController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SoundController>();
            }
            return _instance;
        }
    }

    private void Start()
    {
        InitializeSounds();
    }

    private void InitializeSounds()
    {
        foreach (SoundData data in sounds_list)
        {
            AudioSource tmp = gameObject.AddComponent<AudioSource>();
            tmp.clip = data.clip;
            tmp.playOnAwake = data.play_on_awake;
            tmp.volume = data.volume;
            tmp.outputAudioMixerGroup = data.amg;
            if (tmp.playOnAwake) tmp.Play();

            tmp.loop = data.loop;

            sounds.Add(data.clip.name, tmp);
        }
    }

    public void PlaySound(string name)
    {
        sounds[name].Play();
    }

    public bool IsPlaying(string name)
    {
        return sounds[name].isPlaying;
    }

    public void PlayButtonSound()
    {
        sounds["ButtonClick"].Play();
    }
}
