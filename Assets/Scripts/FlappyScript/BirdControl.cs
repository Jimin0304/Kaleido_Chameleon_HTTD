using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdControl : MonoBehaviour
{
    public bool NeverDie;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(480, 800, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Animator>().Play("Anim_Dra_Fly_Up");
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0); //마우스를 클릭할때마다 벡터를 0,0,0으로 초기화
            gameObject.GetComponent<Rigidbody>().AddForce(0, 280, 0); //0,0,0 초기화 후에 y에 300을 더한다.
        }
        /*
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1; //게임이 종료되어 0이 되었던 timeScale을 R키를 눌렀을때 다시 1로 변경해주어 작동되도록 한다.
            Application.LoadLevel("FlappyGame"); //다시 씬(Game)으로 돌아가게 한다.
        }
        */
    }
    //충돌이 발생함을 사용하는 함수가 OnCollisionEnter이다.
    private void OnCollisionEnter(Collision collision)
    {
        if (NeverDie == false)              //죽기
        {
            Time.timeScale = 0;
            int scsc = GameObject.Find("GroundObject").GetComponent<ColumnMaker>().score; // score ColumnMaker에서 들고 오기
            Debug.Log(scsc);
            var coin = GameObject.Find("ScoreScript").GetComponent<JsonTest>().LoadGamePlusDataFromJson(scsc);  // 더해진 잔고
            Debug.Log("GameOver");
            Debug.Log(coin);
            gameObject.GetComponent<Animator>().Play("Anim_Dra_Die");
            Application.LoadLevel("EndFlappy");
        }
    }
}
