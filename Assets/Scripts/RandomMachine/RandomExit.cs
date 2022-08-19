using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomExit : MonoBehaviour
{
    public void ChaneToVillage()
    {
        SceneManager.LoadScene("VillageScene");
    }
}
