using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DragonAnimator : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isFlyFire", true);
        }
        else
        {
            anim.SetBool("isFlyFire", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetBool("isFlyUp", true);
        }
        else
        {
            anim.SetBool("isFlyUp", false);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetBool("isFlyDown", true);
        }
        else
        {
            anim.SetBool("isFlyDown", false);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("isFlyR", true);
        }
        else
        {
            anim.SetBool("isFlyR", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetBool("isFlyL", true);
        }
        else
        {
            anim.SetBool("isFlyL", false);
        }

    }

    public static DragonAnimator Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DragonAnimator>();
                if (instance == null)
                {
                    var instanceContainer = new GameObject("DragonAnimator");
                    instance = instanceContainer.AddComponent<DragonAnimator>();
                }
            }
            return instance;
        }
    }
    private static DragonAnimator instance;

    Rigidbody rb;
    public float moveSpeed = 5f;
    //public Animator Anim;
    //private bool isDragonJumping = false;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(moveHorizontal * moveSpeed, moveVertical * moveSpeed, rb.velocity.z);
        if (ShootingJoyStick.Instance.joyVec.x != 0 || ShootingJoyStick.Instance.joyVec.y != 0)
        {
            rb.velocity = new Vector3(ShootingJoyStick.Instance.joyVec.x, ShootingJoyStick.Instance.joyVec.y, 0) * moveSpeed;
            //rb.rotation = Quaternion.LookRotation(new Vector3(ShootingJoyStick.Instance.joyVec.x, ShootingJoyStick.Instance.joyVec.y, 0));
        }
    }
}