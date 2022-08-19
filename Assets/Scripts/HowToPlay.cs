using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            Debug.Log("게임메뉴로 돌아가기");
            SceneManager.LoadScene(12);
        }
        
        else if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("게임메뉴로 돌아가기");
            SceneManager.LoadScene(12);
        }
    }
}
