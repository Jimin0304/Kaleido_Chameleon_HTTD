using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ScoreText;

    private void Start()
    {
        EventDispatcher.Listen(message: "ScoreUpdated", ScoreUpdated);
        //EventDispatcher.Remove(message: "OnDestroy", OnDestroy);
    }
    private void ScoreUpdated(object[] args)
    {
        int score = (int)args[0];
        ScoreText.text = $"Score : {score}";
        GameObject.Find("ScoreScript").GetComponent<JsonTest>().LoadGamePlusDataFromJson(score);
    }

    //ResetVariable.Static <EventDispatcher>();

    private void OnDestroy()
    {
        EventDispatcher.Remove(message: "ScoreUpdated", ScoreUpdated);
    }
}
