using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Alex Huang

public class ContinuousAudio : MonoBehaviour
{
    AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    public void play()
    {
        if (audioSource.isPlaying)
        {
            return;
        }
        audioSource.Play();
    }

    public void stop()
    {
        audioSource.Stop();
    }
}