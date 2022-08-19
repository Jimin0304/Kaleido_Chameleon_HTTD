using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO; //파일 입출력

public class D2ragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private bool Drop = false;
    private bool Triggered = false;
    //public static bool HospitalCoin=false;

    public int score;  //input 스코어 정의하기 코인
    public Text coinText;   //text 수정

    Rigidbody2D rb;
    Animator Anim;
    Animator DragonAnim;
    public GameObject Image;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        var Dragon = GameObject.FindGameObjectWithTag("Dragon");//dragon 태그 가지는 게임옵젝 찾아서
        DragonAnim=Dragon.GetComponent<Animator>(); //옵젝 애니메이터
        coinText.text = "" + GameObject.Find("ScoreScript").GetComponent<JsonTest>().LoadScoreDataFromJson(); // 초기값 불러오기
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tarea"))//드랍해야할 위치 지정해두고 Tarea라고 태그달아둠
        {
            //Debug.Log("Triggered");
            Triggered = true;//triggered 변수를 true로
            Debug.Log("Triggered? :" + Triggered);
        }


    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        //coinText.text = "" + GameObject.Find("ScoreScript").GetComponent<JsonTest>().LoadScoreDataFromJson(); // 초기값 불러오기
    }
    public static Vector3 defaultPosition;
    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultPosition = Image.transform.position;
        Debug.Log("Drag Start");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Dropped");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        Drop = true; //drop 되면 drop 변수를 true로
        Debug.Log("Drop true: "+ Drop);
        Image.transform.position = defaultPosition;//드래그 한 거 원래 위치로
    }
    private void Update()
    {
        if (Drop == true&&Triggered==true)//drop,triggered 되어 있으면
        {
            Debug.Log("Animation Yes!!!");
            DragonAnim.SetTrigger("YesT");//YesT (Yes 애니메이션 실행)
            Drop = false;//drop 이랑 triggered 변수 false로
            Triggered = false;
            Debug.Log("After animation, Drop, Triggered: " + Drop + Triggered);
            score = 10;
            coinText.text = "" + GameObject.Find("ScoreScript").GetComponent<JsonTest>().LoadMinusDataFromJson(score); // 버튼 데이터 갱신
  
        }
        else if (Drop == false||Triggered==false)//drop이 false이거나 triggered가 false이면 idle 애니메이션
        {

            DragonAnim.SetTrigger("IdleT");
        }
    }


}
