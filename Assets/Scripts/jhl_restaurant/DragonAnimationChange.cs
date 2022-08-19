using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO; //파일 입출력

public class DragonAnimationChange : MonoBehaviour, IDropHandler
{
    Animator Anim;
    Animator DragonAnim;
    public int minus;
    public Text countText;

    void Awake(){
        countText.text = ""+ GameObject.Find("ScoreScript").GetComponent<JsonTest>().LoadScoreDataFromJson();

    }
    void Start(){
        Anim = GetComponent<Animator>();
        var Dragon = GameObject.FindGameObjectWithTag("Dragon");
        DragonAnim = Dragon.GetComponent<Animator>();
    }
    public void OnDrop(PointerEventData eventData){
        Debug.Log("OnDropJoongHeon");
        DragonAnim.SetTrigger("YesT");
        minus = 10;
        var coin = GameObject.Find("ScoreScript").GetComponent<JsonTest>().LoadMinusDataFromJson(minus);
        countText.text = "" + coin;
    }
}
