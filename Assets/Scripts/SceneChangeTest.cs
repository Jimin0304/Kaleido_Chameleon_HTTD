using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTest : MonoBehaviour
{
    public void ChangeFirstScene()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void ChangeSecondScene()
    {
        SceneManager.LoadScene("Game");
    }
}
