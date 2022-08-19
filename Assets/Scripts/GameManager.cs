using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;

    private void Start()
    {
        GameObject.Find("ScoreScript").GetComponent<JsonTest>().LoadGamePlusDataFromJson(score);
        EventDispatcher.Listen(message: "EnemyDied", EnemyDied);//EnemyDied라는 이벤트를 EnemyController에서 받아오면 EnemyDied를 실행한다. 그러면 아래 EnemyDied가 실행된다.
        EventDispatcher.Listen(message: "PlayerDied", PlayerDied);
    }

    private void EnemyDied(object[] args)
    {
        score++;
        EventDispatcher.Dispatch(message: "ScoreUpdated", score);
        //Debug.Log(message: $"Score : {score}");
    }

    private void PlayerDied(object[] args)
    {
        //score++;
        EventDispatcher.Dispatch(message: "OnDestroy");
    }

}
