using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back_Button : MonoBehaviour
{
    public void BackButton()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
