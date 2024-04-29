using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Singleton { get; private set; }
    private AudioSource _audio;
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();

        if (Singleton == null)
        {
            Singleton = this;
        }
        else if (Singleton != null)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void AudioPlay(AudioClip _Audio)
    {
        _audio.PlayOneShot(_Audio);
    }
}
