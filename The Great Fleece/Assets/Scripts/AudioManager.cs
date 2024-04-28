using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Singleton;
    private AudioSource _audio;
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
         Singleton = this;
    }
    public void AudioPlay(AudioClip _Audio)
    {
        _audio.PlayOneShot(_Audio);
    }
}
