using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ComponentMovement : MonoBehaviour {
    GameObject targetObj;
    Vector2 nowPos, prePos;
    Vector3 movePos;
    Vector3 currentPos, lastPos;
    bool isdrag;
    bool touch;
    int frame_cur;
    int frame_before;
    bool first_check;
    public Vector3 rotate_vector;

    // Use this for initialization
    void Start () {
        isdrag = false;
        targetObj = gameObject;
        frame_cur = 0;
        first_check = true;
        touch = false;
    }

	// Update is called once per frame
	void Update () {
        frame_cur++;
        if (Input.GetMouseButtonDown(0))
        {
            if (UIPointer.IsPointerOverUIObject())
            {
                Debug.Log("UI Collid");
                return;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.Equals(targetObj))
                {
                    isdrag = true;
                    frame_before = frame_cur;
                    
                }
            }
            if (isdrag) { 
                prePos = Input.mousePosition;
                lastPos = prePos;
            }
        }
        if (isdrag)
        {
            movePos = Input.mousePosition;
            movePos.z = Camera.main.transform.position.y - targetObj.transform.position.y;
            movePos = Camera.main.ScreenToWorldPoint(movePos);
            targetObj.transform.position = movePos;
            touch = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            /*if (!first_check && Mathf.Abs(frame_cur - frame_before) < 15 && Mathf.Abs(frame_cur - frame_before) > 10)
            {
                touch = true;
                targetObj.transform.Rotate(rotate_vector.x, rotate_vector.y, rotate_vector.z);
                
            }*/
            /* network */
            if (touch)
            {
                    Dictionary<string, string> senddata = new Dictionary<string, string>();
                    senddata.Add("pos", targetObj.transform.position.ToString());
                    senddata.Add("dir", targetObj.transform.rotation.ToString());
                    foreach (object obj in GameObjectStructure.ObjList)
                    {
                        if (((GameObjectStructure)obj).obj.Equals(targetObj))
                        {
                            senddata.Add("obj_id", ((GameObjectStructure)obj).objid.ToString());
                            break;
                        }
                    }

                    JSONObject jdata = new JSONObject(senddata);
                    Debug.Log(jdata);
                    if (SocketManage.id != null)
                        SocketManage.socket.Emit("MSGrequest_ModifyObj", jdata);
                
            }
            isdrag = false;
            first_check = false;
            touch = false;
        }
        

    }
}
