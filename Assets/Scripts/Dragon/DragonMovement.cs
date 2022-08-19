using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    public static bool VillToBuy = false;
    public static DragonMovement Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DragonMovement>();
                if (instance == null)
                {
                    var instanceContainer = new GameObject("DragonMovement");
                    instance = instanceContainer.AddComponent<DragonMovement>();
                }
            }
            return instance;
        }
    }
    private static DragonMovement instance;

    Rigidbody rb;
    public float moveSpeed = 5f;
    public Animator Anim;
    private bool isDragonJumping = false;

    void Start()
    {
        Screen.SetResolution(480, 800, false);

        Vector3 DragonPos;
        rb = GetComponent<Rigidbody>();
        Anim = GetComponent<Animator>();
        string name = GameObject.Find("ScoreScript").GetComponent<JsonTest>().GetDragonName();
        GameObject.Find(name).transform.position = GameObject.Find("ScoreScript").GetComponent<JsonTest>().GetDragonPos();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(moveHorizontal * moveSpeed, rb.velocity.y, moveVertical * moveSpeed);
        if (JoyStickMovement.Instance.joyVec.x != 0 || JoyStickMovement.Instance.joyVec.y != 0)
        {
            rb.velocity = new Vector3(JoyStickMovement.Instance.joyVec.x, 0, JoyStickMovement.Instance.joyVec.y) * moveSpeed;
            rb.rotation = Quaternion.LookRotation(new Vector3(JoyStickMovement.Instance.joyVec.x, 0, JoyStickMovement.Instance.joyVec.y));
        }
    }

    private void Update()
    {
        //Debug.Log(GameObject.FindWithTag("Dragon").transform.position);

        if (Input.GetKeyDown(KeyCode.Space) && isDragonJumping == false)
        {
            Debug.Log("Jump");
            DragonMovement.Instance.Anim.SetBool("Idle", false);
            DragonMovement.Instance.Anim.SetBool("Jump", true);
            DragonMovement.Instance.Anim.SetBool("Walk", false);
            isDragonJumping = true;
        }
        else if (isDragonJumping == true)
        {
            isDragonJumping = false;
            DragonMovement.Instance.Anim.SetBool("Jump", false);
            DragonMovement.Instance.Anim.SetBool("Idle", true);
            DragonMovement.Instance.Anim.SetBool("Walk", false);
        }

    }
    private void OnTriggerEnter(Collider space)
    {
        if(space.tag == "Dogam")
        {
            Debug.Log("Dogam 충돌");
            saveDragonPosition(space.tag);
            Application.LoadLevel("start");
        }
        if (space.tag == "Playgame")
        {
            Debug.Log("Playgame 충돌");
            saveDragonPosition(space.tag);
            Application.LoadLevel("GameMenu");
            
        }
        if (space.tag == "Hospital")
        {
            Debug.Log("Hospital 충돌");
            saveDragonPosition(space.tag);
            Application.LoadLevel("HospitalMenu");
        }
        if (space.tag == "Restaurant")
        {
            Debug.Log("Restaurant 충돌");
            saveDragonPosition(space.tag);
            Application.LoadLevel("restaurant2");
        }
        if (space.tag == "Random")
        {
            Debug.Log("Random 충돌");
            VillToBuy = true;
            saveDragonPosition(space.tag);
            Application.LoadLevel("RandomMachine");
        }
    }
    public void saveDragonPosition(string tag){
        Vector3 pos;
        GameObject.Find("ScoreScript").GetComponent<JsonTest>().buildingPos();
        GameObject.Find("ScoreScript").GetComponent<JsonTest>().SaveDragonPos(tag);
        Debug.Log("saveDragonPosition Successful");
    }
}
