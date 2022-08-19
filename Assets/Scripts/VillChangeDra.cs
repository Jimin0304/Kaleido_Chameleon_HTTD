using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillChangeDra : MonoBehaviour
{
    public static GameObject[] VDragonList;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 8; i++)
            VDragonList = GameObject.FindGameObjectsWithTag("Dragon");
        System.Array.Sort<GameObject>(VDragonList, (x, y) => string.Compare(x.name, y.name));//드래곤 옵젝 이름에있는 번호 크기순대로 정렬!
        for (int i = 0; i < VDragonList.Length; i++)
        {
            VDragonList[i].gameObject.SetActive(false);
        }
        if (CoinDrag.RandomCount == 0)
        {
            VDragonList[0].gameObject.SetActive(true);
            GameObject.Find("ScoreScript").GetComponent<JsonTest>().SaveDragonName(VDragonList[0].gameObject.name);
            Debug.Log("Village Dragon Set false, 00 left");
        }
        VillageDragonActive();
    }
    public static void VillageDragonActive()
    {
        if (CoinDrag.RandomCount == 0)
            return;
        if (CoinDrag.RandomCount == 1)
        {
            VDragonList[0].gameObject.SetActive(false);
        }
        else
            VDragonList[CoinDrag.PreRandom].gameObject.SetActive(false);

        VDragonList[CoinDrag.random].gameObject.SetActive(true);
        Debug.Log("Village Dragon Set Active: " + VDragonList[CoinDrag.random]);
        GameObject.Find("ScoreScript").GetComponent<JsonTest>().SaveDragonName(VDragonList[CoinDrag.random].gameObject.name);
    }
}
