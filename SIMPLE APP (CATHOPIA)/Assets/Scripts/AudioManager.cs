using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{


    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip jumpSound;
    public AudioClip deathSound;
    public AudioClip CoinCollect;

    private float musicTimeStamp = 0;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }


    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void StopBackground()
    {
        musicTimeStamp = musicSource.time;
        musicSource.Stop();
    }

    public void PlayBackground()
    {
        musicSource.time = musicTimeStamp;
        musicSource.Play();
    }
}