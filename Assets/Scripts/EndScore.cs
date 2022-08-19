using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{
    public Text countText;
    // Start is called before the first frame update
    void Start()
    {
        var i = GameObject.Find("ScoreScript").GetComponent<JsonTest>().LoadGameDataFromJson();
        Debug.Log(i);
        countText.text = "" + GameObject.Find("ScoreScript").GetComponent<JsonTest>().LoadGameDataFromJson();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
