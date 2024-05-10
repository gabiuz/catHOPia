using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    private AudioManager audioManager;


    void Start()
    {
        PausePanel.SetActive(false);
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;

        audioManager.StopBackground();

    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;

        audioManager.PlayBackground();

    }
}
