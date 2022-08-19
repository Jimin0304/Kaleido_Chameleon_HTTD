﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    float _distance = 7.67f;
    int _count = 2;
    int _index = 2;

    public GameObject[] grounds;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;

        gameObject.transform.localPosition += new Vector3(-0.05f, 0, 0); // 바닥 오브젝트가 뒤로 이동하는 코드

        _count = 2 + (int)(-gameObject.transform.localPosition.x / 7.67f);
        //index와 count값이 다르면 바닥 오브젝트가 반복되는 코드
        if (_index != _count)
        {
            grounds[(_index - 2) % 3].transform.localPosition = new Vector3(_distance * _count, -5, 0);
            _index = _count;
        }
    }
}
