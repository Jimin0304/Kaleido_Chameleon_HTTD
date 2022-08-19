using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCamera : MonoBehaviour
{
    public Transform[] target;
    public float dist = 7f;
    public float height = 5f;
    private Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.position = target[CoinDrag.random].position - (1 * Vector3.forward * dist) + (Vector3.up * height);
        tr.LookAt(target[CoinDrag.random]);
    }
}
