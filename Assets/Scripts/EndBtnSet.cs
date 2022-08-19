using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndBtnSet : MonoBehaviour
{
    public BTnType currentType;

    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTnType.Again:
                Debug.Log("다시하기");
                SceneManager.LoadScene(1);
                break;
            case BTnType.Home:
                Debug.Log("홈으로");
                SceneManager.LoadScene(0);
                break;
            case BTnType.Before:
                Debug.Log("이전으로");
                SceneManager.LoadScene(12);
                break;
        }
    }

}
