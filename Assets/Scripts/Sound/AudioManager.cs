using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private AudioSource AudioSource;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        AudioSource.playOnAwake = false;
    }

    public void PlaySound(AudioClip clip, float startTime = 0f, float volume = 1f)
    {
        AudioSource.time = startTime;
        AudioSource.volume = volume;
        AudioSource.PlayOneShot(clip);
    }
}
