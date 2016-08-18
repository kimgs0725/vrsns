using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OBJDestroy : MonoBehaviour {

    public GameObject targetobj;
    bool one_click = false;
    int frame_cur;
    int frame_before;
    // Use this for initialization
    void Start () {
        //targetobj = gameObject;
        frame_cur = 0;
	}

    public void targetObjDestroy() {
        targetobj = ObjClickControl.targetobj;
        if (targetobj == null) return;
        Debug.Log("Destroy");
        Dictionary<string, string> senddata = new Dictionary<string, string>();
        Debug.Log(GameObjectStructure.ObjList.Count);
        for (int i = 0; i < GameObjectStructure.ObjList.Count; i++)
        {
            GameObjectStructure gbs = (GameObjectStructure)GameObjectStructure.ObjList[i];
            if (gbs.obj.Equals(targetobj))
            {
                senddata.Add("obj_id", gbs.objid.ToString());
                GameObjectStructure.ObjList.RemoveAt(i);
                break;
            }
        }

        JSONObject jdata = new JSONObject(senddata);
        Debug.Log(jdata);
        if(SocketManage.id != null)
            SocketManage.socket.Emit("MSGrequest_RemoveObj", jdata);
        Destroy(targetobj);
    }

    // Update is called once per frame
    /*void Update() {
        frame_cur++;
        if (Input.touchCount == 2) {
            Destroy(targetobj);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.Equals(targetobj))
                {
                    if (!one_click) // first click no previous clicks
                    {
                        one_click = true;
                        frame_before = frame_cur;
                    }
                    else
                    {
                        if (Mathf.Abs(frame_cur - frame_before) < 10)
                        {
                            Debug.Log("Destroy");
                            Dictionary<string, string> senddata = new Dictionary<string, string>();
                            Debug.Log(GameObjectStructure.ObjList.Count);
                            for (int i = 0 ; i < GameObjectStructure.ObjList.Count; i++)
                            {
                                GameObjectStructure gbs = (GameObjectStructure)GameObjectStructure.ObjList[i];
                                if (gbs.obj.Equals(targetobj))
                                {
                                        senddata.Add("obj_id", gbs.objid.ToString());
                                        GameObjectStructure.ObjList.RemoveAt(i);
                                        break;
                                }
                            }

                            JSONObject jdata = new JSONObject(senddata);
                            Debug.Log(jdata);
                            SocketManage.socket.Emit("MSGrequest_RemoveObj", jdata);
                            Destroy(targetobj);
                        }
                        else one_click = false;

                    }
                }
                else one_click = false;
            }
            else one_click = false;
        }
        if (Mathf.Abs(frame_cur - frame_before) >= 20)
        {
            one_click = false;
        }

    }*/
}
