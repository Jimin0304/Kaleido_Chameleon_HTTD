/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragandDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public GameObject Image;
    Animator Anim;
    Animator DragonAnim;

    void Start(){
        Anim = GetComponent<Animator>();
        var Dragon = GameObject.FindGameObjectWithTag("Dragon");
        DragonAnim = Dragon.GetComponent<Animator>();
        //Vector3 spotPos =Image.transform.position;
    }
    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public static Vector3 defaultPosition;

    public void OnBeginDrag(PointerEventData eventData) {
        defaultPosition = Image.transform.position;
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        Image.transform.position = defaultPosition;//드래그 한 거 원래 위치로
        // Image.transform.localPosition = defaultPosition;
        // Vector3 position = Image.transform.localPosition; 
        // //Debug.Log(position);
        // position.x = 0; 
        // position.y = -572; 
        //Image.transform.localPosition = spotPos; 

        //Destroy(Image);
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
    }

}
