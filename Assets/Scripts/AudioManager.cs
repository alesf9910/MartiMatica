using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource []audioSources;

    void Start()
    {
        audioSources = GetComponents<AudioSource>();
        StartCoroutine(PlayAudioSources());
    }

    void Update()
    {
        
    }

    IEnumerator PlayAudioSources()
    {
        while (true)
        {
            foreach (var audioSource in audioSources)
            {
                audioSource.Play();
                while (audioSource.isPlaying)
                {
                    yield return null;
                }
            }
        }
    }
}
