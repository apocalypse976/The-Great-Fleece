using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VOTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip _voiceOver;
    private Collider _collider;


    private void Start()
    {
        _collider = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioManager.Singleton.AudioPlay(_voiceOver);
          _collider.enabled = false;
        }
    }
}
