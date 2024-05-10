using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScenes : MonoBehaviour
{
    private bool musicPaused = false;
    private AudioSource mainMenuMusic;

    void Start()
    {

        mainMenuMusic = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (SceneManager.GetActiveScene().name == "New Game_Reeses")
        {
            if (!musicPaused)
            {
                mainMenuMusic.Pause();
                musicPaused = true;
            }
        }
        else
        {
            if (musicPaused)
            {
                mainMenuMusic.UnPause();
                musicPaused = false;
            }
        }
    }
}
