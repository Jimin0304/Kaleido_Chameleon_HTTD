using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float MoveSpeed = 5f;

    public GameObject BulletPrefab = null;

    private void GenerateBullet()
    {
        GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);//생성해줄변수, 어느위치에 변수를 생성할지 넘겨줄 수 있다
        bullet.tag = "EnemyBullet";
        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.SetBulletDirection(Vector3.down);
    }

    public float BulletGenerateTime = 1f;
    private float bulletGenerateTimer = 0f;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)//트리거가 켜져있을때 꺼져있을때는 OnCollisionEnter를 쓴다.
    {
        if (other.tag == "PlayerBullet")//플레이어 Bullet에 맞으면 파괴된다.
        {
            Destroy(gameObject);
            EventDispatcher.Dispatch(message: "EnemyDied");//EnemyDied라는 이벤트를 쏘고
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * MoveSpeed * Time.deltaTime;
        bulletGenerateTimer += Time.deltaTime;

        if(bulletGenerateTimer >= BulletGenerateTime)
        {
            GenerateBullet();
            bulletGenerateTimer = 0f;
        }
    }
}
