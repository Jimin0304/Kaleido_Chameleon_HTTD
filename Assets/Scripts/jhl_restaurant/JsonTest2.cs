using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JsonTest2 : MonoBehaviour
{
    public int score;
    public int hi;
    public int minus;
    //public Text countText;

    void Awake(){

    }
    void Start()
    {   
        score = 0;
        minus = 0;
        //var hi = GameObject.Find("ScoreScript").GetComponent<JsonTest>().LoadPlusDataFromJson(score);
        //var mi = GameObject.Find("ScoreScript").GetComponent<JsonTest>().LoadPlusDataFromJson(minus);

    }
    // Update is called once per frame
    void Update()
    {
        
        //GameObject.Find("ScoreScript").GetComponent<JsonTest>().LoadPlayerDataFromJson();
    }
}
