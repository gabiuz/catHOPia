using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    [SerializeField] Image BGmusicOn;
    [SerializeField] Image BGmusicOff;

    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip jumpSound;
    public AudioClip deathSound;
    public AudioClip CoinCollect;
    public AudioClip click;

    private float musicTimeStamp = 0;
    private bool muted = false;


    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();

        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }

        else
        {
            Load();
        }

        UpdateButtonIcon();
        AudioListener.pause = muted;

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

    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }

        else
        {
            muted = false;
            AudioListener.pause = false;
        }

        UpdateButtonIcon();
        Save();
    }

    private void UpdateButtonIcon()
    {
        if (muted == false)
        {
            BGmusicOn.enabled = true;
            BGmusicOff.enabled = false;
        }

        else
        {
            BGmusicOn.enabled = false;
            BGmusicOff.enabled = true;
        }
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

}