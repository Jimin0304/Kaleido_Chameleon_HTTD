using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float MoveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)//트리거가 켜져있을때 꺼져있을때는 OnCollisionEnter를 쓴다.
    {
        if (other.tag == "PlayerBullet")//플레이어 Bullet에 맞으면 파괴된다.
        {
            EventDispatcher.Dispatch(message: "EnemyDied");
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * MoveSpeed * Time.deltaTime;
    }
}
