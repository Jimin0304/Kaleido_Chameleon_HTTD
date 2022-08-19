using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float dist = 7f;
    public float height = 5f;

    private Transform tr;

    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    private void Update()
    {
        tr.position = target.position - (1 * Vector3.forward * dist) + (Vector3.up * height);
        tr.LookAt(target);
    }

}