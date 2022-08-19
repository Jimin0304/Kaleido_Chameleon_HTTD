using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float BulletSpeed = 10f;

    private Vector3 bulletDirection = Vector3.zero;//플레이어가 쏠때와 적이 쏠때 방향을 지정해주어야 하기때문에 사용한다.

    public void SetBulletDirection(Vector3 direction)
    {
        bulletDirection = direction;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)//총알이 관통되어 나가지 않고 하나를 맞추면 사라지도록 한다.
    {
        if (gameObject.tag == "PlayerBullet")//내가 플레이어불렛 이라면
        {
            if(other.tag == "Enemy" || other.tag == "Asteroid")//적이나 소행성에 맞으면 파괴
            {
                Destroy(gameObject);
            }
           
        }
        else if(gameObject.tag == "EnemyBullet")//내가 적이라면
        {
            if(other.tag == "Player")//플레이어에 맞으면 파괴
            {
                Destroy(gameObject);
            }
        }
       /* bool isPlayerBulletDestory =
            gameObject.tag == "PlayerBullet" && (other.tag == "Enemy" || other.tag == "Asteroid");
        bool isEnemyBulletDestroy = gameObject*/
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += bulletDirection * BulletSpeed * Time.deltaTime;
    }
}
