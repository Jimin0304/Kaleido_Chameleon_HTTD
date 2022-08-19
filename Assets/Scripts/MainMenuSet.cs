using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSet : MonoBehaviour
{

    public GameObject menuSet;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("ScoreScript").GetComponent<JsonTest>().WriteJsonFile();
        //GameLoad();
    }

    // Update is called once per frame
    void Update()
    {
        //Sub Menu

        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else
            {
                menuSet.SetActive(true);
            }
        }

        //player = CoinDrag.DragonList[CoinDrag.random];
        
    }
    
    public void GameSave()
    {
        //player.x
        //player.y
        /*
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.Save();
        */
        menuSet.SetActive(false);

        Debug.Log("게임 저장하기");
    }
    /*
    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("PlayerX"))
        {
            return;
        }

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        player.transform.position = new Vector3(x, y, 0);

        Debug.Log("게임 불러오기");
    }
    */
    public void GameExit()
    {
        Debug.Log("게임종료");
        Application.Quit();
    }

}