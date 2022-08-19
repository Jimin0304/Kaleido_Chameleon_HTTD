using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootingJoyStick : MonoBehaviour
{
    public static ShootingJoyStick Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ShootingJoyStick>();
                if (Instance == null)
                {
                    var instanceContainer = new GameObject("ShootingJoyStick");
                    instance = instanceContainer.AddComponent<ShootingJoyStick>();
                }
            }
            return instance;
        }
    }
    private static ShootingJoyStick instance;

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

        /*
        if (!DragonMovement.Instance.Anim.GetCurrentAnimatorStateInfo(0).IsName("isFlyFire"))
        {
            Debug.Log("Fly");
            //DragonMovement.Instance.Anim.SetBool("Attack", false);
            DragonMovement.Instance.Anim.SetBool("isFlyFire", false);

        }
        isDragonMoving = true;
        //PlayerTargeting.Instance.getATarget = false;
        */

        //isDragonMoving = true;
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

        /*
        if (!DragonMovement.Instance.Anim.GetCurrentAnimatorStateInfo(0).IsName("isFlyFire"))
        {
            Debug.Log("isFlyFire");
            DragonMovement.Instance.Anim.SetBool("isFlyFire", true);
        }
        */

        //isDragonMoving = false;
    }


}