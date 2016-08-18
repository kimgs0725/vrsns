using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class CameraMovement : MonoBehaviour {
    public Camera mainCamera;
    public float Speed;
    Vector2 nowPos, prePos;
    Vector3 movePos;
    Vector3 currentPos, lastPos, deltaPos;
    bool isdrag;

    // Use this for initialization
    void Start()
    {
        isdrag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (UIPointer.IsPointerOverUIObject())
        {
            Debug.Log("UI Collid");
            return;
        }
        if (ClickButtonCase.buttonkey != null) {

            return;
        }
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                /*
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    // do
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    // do
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    // do
                }
                */
                if (hit.transform.gameObject.tag == "Plane") {
                    isdrag = true;
                }
            }
            if (isdrag)
            {
                prePos = Input.mousePosition;
                lastPos = prePos;
            }
        }
        else if (isdrag && Input.GetMouseButton(0)) {
            currentPos = Input.mousePosition;
            deltaPos = currentPos - lastPos;
            nowPos = Input.mousePosition - deltaPos;
            movePos = (Vector3)(prePos - nowPos) * Speed;
            mainCamera.transform.Translate(movePos);
            prePos = Input.mousePosition - deltaPos;
            lastPos = currentPos;
        }
        if (Input.GetMouseButtonUp(0)) {
            isdrag = false;
        }
        /*
        if (Input.touchCount  == 1)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log("pos : " + touch.position);
            if (touch.phase == TouchPhase.Began)
            {
                prePos = touch.position - touch.deltaPosition;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                nowPos = touch.position - touch.deltaPosition;
                movePos = (Vector3)(prePos - nowPos) * Speed;
                mainCamera.transform.Translate(movePos);
                prePos = touch.position - touch.deltaPosition;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                //do
            }
        }
            
        */
          
        
    }

  
}
