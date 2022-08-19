using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickMovement : MonoBehaviour
{
    public static JoyStickMovement Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<JoyStickMovement>();
                if (Instance == null)
                {
                    var instanceContainer = new GameObject("JoyStickMovement");
                    instance = instanceContainer.AddComponent<JoyStickMovement>();
                }
            }
            return instance;
        }
    }
    private static JoyStickMovement instance;

    public GameObject smallStick;
    public GameObject bGStick;
    Vector3 stickFirstPosition;
    public Vector3 joyVec;
    Vector3 joyStickFirstPosition;
    float stickRadius;
    public bool isDragonMoving = false;

    void Start()
    {
        stickRadius = bGStick.gameObject.GetComponent<RectTransform>().sizeDelta.y / 2;
        joyStickFirstPosition = bGStick.transform.position;
    }
    public void PointDown()
    {
        bGStick.transform.position = Input.mousePosition;
        smallStick.transform.position = Input.mousePosition;
        stickFirstPosition = Input.mousePosition;


        if (!DragonMovement.Instance.Anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            Debug.Log("Walk");
            //DragonMovement.Instance.Anim.SetBool("Attack", false);
            DragonMovement.Instance.Anim.SetBool("Idle", false);
            DragonMovement.Instance.Anim.SetBool("Jump", false);
            DragonMovement.Instance.Anim.SetBool("Walk", true);
        }
        isDragonMoving = true;
        //PlayerTargeting.Instance.getATarget = false;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector3 DragPosition = pointerEventData.position;
        joyVec = (DragPosition - stickFirstPosition).normalized;
        float stickDistance = Vector3.Distance(DragPosition, stickFirstPosition);

        if (stickDistance < stickRadius)
        {
            smallStick.transform.position = stickFirstPosition + joyVec * stickDistance;
        }
        else
        {
            smallStick.transform.position = stickFirstPosition + joyVec * stickRadius;
        }
    }

    public void Drop()
    {
        joyVec = Vector3.zero;
        bGStick.transform.position = joyStickFirstPosition;
        smallStick.transform.position = joyStickFirstPosition;

        if (!DragonMovement.Instance.Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            Debug.Log("Idle");
            DragonMovement.Instance.Anim.SetBool("Jump", false);
            DragonMovement.Instance.Anim.SetBool("Walk", false);
            DragonMovement.Instance.Anim.SetBool("Idle", true);
        }
        isDragonMoving = false;
    }


}
