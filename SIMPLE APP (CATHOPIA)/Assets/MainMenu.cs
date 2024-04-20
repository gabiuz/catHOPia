using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseCharacter : MonoBehaviour
{
    public void Choose_Character()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
