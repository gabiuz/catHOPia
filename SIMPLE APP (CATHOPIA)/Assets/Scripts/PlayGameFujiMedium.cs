using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameFujiMedium : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadSceneAsync(12);
    }
}
