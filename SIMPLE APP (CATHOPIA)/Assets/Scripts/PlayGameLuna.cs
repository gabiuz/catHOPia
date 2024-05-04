using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameLuna : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadSceneAsync(4);
    }
}
