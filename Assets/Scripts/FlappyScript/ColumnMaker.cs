using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColumnMaker : MonoBehaviour
{
    public GameObject   Column;

    private float   nowTime;
    private float   makeTime = 2f;

    public Text     ScoreUI;
    public int     score = 0;
    private float   scoreTime;

    // Start is called before the first frame update
    void Start()
    {
        nowTime = Time.time;
        scoreTime = Time.time + 2;
    }

    // Update is called once per frame
    public void Update()
    {
        if(Time.time - nowTime > makeTime)
        {
            nowTime = Time.time;
            GameObject temp = Instantiate(Column); // 생성한 오브젝트는 임시 변수 temp안에 참조시키고 부모 오브젝트 설정, 위치값과 크기값을 설정해준다.
            temp.transform.parent = gameObject.transform;

            float randomY = Random.Range(-6.15f, -1.5f);

            temp.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + 5, randomY, 0);
            temp.transform.localScale = new Vector3(1, 1, 1);
        }
        if (Time.time - scoreTime > 2)
        {
            scoreTime = Time.time;
            score++;
            ScoreUI.text = score.ToString();
        }
    }
}
