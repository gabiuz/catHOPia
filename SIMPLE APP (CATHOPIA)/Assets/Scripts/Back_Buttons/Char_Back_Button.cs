using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Char_Back_Button : MonoBehaviour
{
    public void BackButton()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
