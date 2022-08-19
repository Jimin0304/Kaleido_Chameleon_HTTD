using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake()

    {

        animator = GetComponent<Animator>();

    }
void Update()

{


    if (Input.GetKeyDown(KeyCode.B))

    {

        animator.SetBool("Eat", true);

    }



    if (Input.GetKeyUp(KeyCode.B))

    {

        animator.SetBool("Eat", false);

    }

}
}
