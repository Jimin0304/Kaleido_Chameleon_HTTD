using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CoinDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private bool Drop = false;
    private bool Triggered = false;
    Rigidbody2D rb;
    public static int random;
    public static int PreRandom=-1;
    public static GameObject[] DragonList;
    public static int RandomCount = 0;//몇번째 뽑기인지 카운트
    float rotSpeed = 100f;

    public int score; // input 코인
    private int minus;
    public Text countText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        for (int i = 0; i < 8; i++)
        {
            DragonList = GameObject.FindGameObjectsWithTag("Dragon");
        }
        System.Array.Sort<GameObject>(DragonList, (x, y) => string.Compare(x.name, y.name));//드래곤 옵젝 이름에있는 번호 크기순대로 정렬!
        for(int i = 0; i < DragonList.Length; i++)
        {
            DragonList[i].gameObject.SetActive(false);
        }
        Debug.Log("Set false");
        countText.text = "" + GameObject.Find("ScoreScript").GetComponent<JsonTest>().LoadScoreDataFromJson();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered");
        Triggered = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trigger False");
        Triggered = false;
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public static Vector2 defaultPosition;
    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultPosition = this.transform.position;
        Debug.Log("Drag Start");
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Dropped");
        Drop = true; 
        this.transform.position = defaultPosition;//드래그 한 거 원래 위치로
    }
    private void Update()
    {
        if (Drop == true && Triggered == true)//drop,triggered 되어 있으면
        {
            //돈 차감되는 스크립트 작성
            //랜덤함수 호출, 총 8개의 드래곤 옵젝
            while (true) { 
             random = Random.Range(0, 8);
                if (random != PreRandom)
                    break;
            }
            Debug.Log("random Num: " + random);
            //다시 해당 씬으로 돌아왔을 때, 드래곤이 카운트 0일 때 애로 돌아가야함! 초기화 되어야함
            if (DragonMovement.VillToBuy==true||RandomCount==0)
                GameObject.Find("RandomDra").SetActive(false);//처음이면 걔 없애고
            else
                DragonList[PreRandom].gameObject.SetActive(false);//아니면 바로 직전 꺼 없애기
            if (RandomCount == 0)
            {
                GameObject.Find("Center?").SetActive(false);
                GameObject.Find("Right?").SetActive(false);
                GameObject.Find("L?").SetActive(false);
            }
            DragonList[random].gameObject.SetActive(true);//위의 랜덤함수 결과로 setActive 호출
            //DragonList[random].gameObject.transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
            //DragonList[random].gameObject.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
            PreRandom = random;//직전 랜덤번호 저장
            RandomCount++;//뽑기횟수 올리기
            Debug.Log("Dragon set active: " + DragonList[random]);

            Drop = false;//drop 이랑 triggered 변수 false로
            Triggered = false;
            DragonMovement.VillToBuy = false;
            minus = 200; //가차 뽑기 가격
            var coin = GameObject.Find("ScoreScript").GetComponent<JsonTest>().LoadMinusDataFromJson(minus);
            countText.text = "" + coin;
        }
        else if (Triggered == false)
        {
            Drop = false;
        }
    }


}
