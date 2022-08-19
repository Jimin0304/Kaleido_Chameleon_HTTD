using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnType : MonoBehaviour
{
    public BTNType currentType;
    //public GamaObject Shooting;
  
        public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNType.CrossyRoad:
                Debug.Log("길건너 친구들");
                SceneManager.LoadScene(3);
                break;
            case BTNType.Shooting:
                Debug.Log("슈팅게임");
                SceneManager.LoadScene(1);
                break;
            case BTNType.Flappy:
                Debug.Log("플래피드래곤");
                //Application.LoadLevel("FlappyGame");
                Time.timeScale = 1;
                SceneManager.LoadScene(2);
                break;
            case BTNType.HowCrossyRoad:
                Debug.Log("길건너친구들 설명");
                SceneManager.LoadScene(8);
                break;
            case BTNType.HowShooting:
                Debug.Log("슈팅게임 설명");
                SceneManager.LoadScene(7);
                break;
            case BTNType.HowFlappy:
                Debug.Log("플래피드래곤 설명");
                SceneManager.LoadScene(9);
                break;
            case BTNType.Back:
                Debug.Log("뒤로가기");
                SceneManager.LoadScene(0);
                break;
        }
    }


}
