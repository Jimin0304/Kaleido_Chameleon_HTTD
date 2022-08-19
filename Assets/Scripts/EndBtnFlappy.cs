using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndBtnFlappy : MonoBehaviour
{
    public BTnType currentType;
    public Text countText;

    void update(){
        var i = GameObject.Find("ScoreScript").GetComponent<JsonTest>().LoadGameDataFromJson();
        Debug.Log(i);
        countText.text = "" + GameObject.Find("ScoreScript").GetComponent<JsonTest>().LoadGameDataFromJson();
    }
    

    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTnType.Again:
                Debug.Log("다시하기");
                Time.timeScale = 1;
                Application.LoadLevel("FlappyGame");
                //SceneManager.LoadScene(2);
                break;
            case BTnType.Home:
                Debug.Log("홈으로");
                Time.timeScale = 1;
                SceneManager.LoadScene(0);
                break;
            case BTnType.Before:
                Debug.Log("이전으로");
                Time.timeScale = 1;
                SceneManager.LoadScene(12);
                break;
        }
    }
}
