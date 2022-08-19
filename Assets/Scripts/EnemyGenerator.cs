using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public Transform[] generatePoints = null;

    public GameObject EnemyPrefab = null;

    public float EnemyGenerateTime = 1f;
    private float enemyGenerateTimer = 0f;

    private void GenerateEnemy()
    {
        //Random.Range 사용해서 point를 랜덤으로 가져오도록
        //Random.Range에는 min값과 max값을 넘겨줘야하는데
        //Random.Range를 통해서 나오는 값은 min <= value < max
        Transform generatePoint = generatePoints[Random.Range(0, generatePoints.Length)];
        //랜덤으로 얻어온 point에 생성
        Instantiate(EnemyPrefab, generatePoint.position, Quaternion.Euler(90, 0, 180));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyGenerateTimer += Time.deltaTime;
        if(enemyGenerateTimer >= EnemyGenerateTime)
        {
            GenerateEnemy();
            enemyGenerateTimer = 0f;
        }
    }
}
