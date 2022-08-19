using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 10f;

    public GameObject BulletPrefab = null;

    private void GenerateBullet()
    {
        GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);//생성해줄변수, 어느위치에 변수를 생성할지 넘겨줄 수 있다
        bullet.tag = "PlayerBullet";//플레이어가 생성하는 Bullet은 PlayerBullet tag를 가져야한다.
        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.SetBulletDirection(Vector3.up);
    }

    private void OnTriggerEnter(Collider other)//트리거가 켜져있을때 꺼져있을때는 OnCollisionEnter를 쓴다.
    {
        if (other.tag != "PlayerBullet")//충돌한 오브젝트의 tag가 PlayerBullet이 아닌경우 파괴한다.
        {
            Destroy(gameObject);
            EventDispatcher.Dispatch(message: "PlayerDied");//EnemyDied라는 이벤트를 쏘고
            SceneManager.LoadScene(4);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Axis라는 개념 자체가 키를 누르면 서서히 값이 변하도록 해서 부드럽게 움직인다.
        float vertical = Input.GetAxis("Vertical");//수직 값(W나 방향키 위쪽을 누르면 1, S나 방향키 아래쪽을 누르면 -1)
        float horizontal = Input.GetAxis("Horizontal");//수평 값(A,D)

        transform.position += Vector3.up * vertical * MoveSpeed * Time.deltaTime;//up만 해줘도 vertical이 아래키를 누를때 -1이 이므로 곱해줌으로써 down은 따로 없어도 되도록 한다.
        transform.position += Vector3.right * horizontal * MoveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateBullet();
        }

        int i = 0;
        while(i<Input.touchCount)
            {
               Touch t = Input.GetTouch(i);
               if(t.phase == TouchPhase.Began)
               {
                  Debug.Log("불꽃 발사");
                  GenerateBullet();
                }
            ++i;
            }

        /*    
        if (Input.GetMouseButtonDown(0))
        {
            GenerateBullet();
        }
        */
        // 특정 키를 입력했을 때 움직이도록 하는 코드
        /*
        if (Input.GetKey(KeyCode.W))//GetKeyDown은 버튼을 누를때 딱 그때만 작동, GetKey는 누르고 있으면 작동한다.
        {
            transform.position += Vector3.up * MoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * MoveSpeed * Time.deltaTime;
        }
        */
    }
}
