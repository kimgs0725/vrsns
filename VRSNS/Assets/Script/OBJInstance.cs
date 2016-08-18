using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SocketIO;
using System;

public class OBJInstance : MonoBehaviour {
    // Use this for initialization
    GameObject obj_c;
    GameObject obj;
    int type;
    void Start () {
       // GameObject go = GameObject.Find("SocketIO");
       // socket = go.GetComponent<SocketIOComponent>();
        SocketManage.socket.On("MSGresponse_AddObj", addobjMSG);
        //StartCoroutine ("SendTest");
    }

    public void addobjMSG(SocketIOEvent e)
    {
        Dictionary<string, string> data = e.data.ToDictionary();
        string id;
        data.TryGetValue("obj_id", out id);

        Debug.Log("Client received MSG : " + id);

        GameObjectStructure.ObjList.Add(new GameObjectStructure(int.Parse(id), type, obj));
        Debug.Log(GameObjectStructure.ObjList.Count);

    }

// Update is called once per frame
void Update () {
        if (UIPointer.IsPointerOverUIObject())
        {
            Debug.Log("UI Collid");
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Input.touchCount);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.tag == "Plane")
                {

                    Debug.Log(ClickButtonCase.buttonkey);
                    if (ClickButtonCase.buttonkey != null) {
                        type = ClickButtonCase.type;
                        obj_c = ClickButtonCase.buttonkey;
                        Debug.Log("INSTANCE");

                        //obj_c.transform.position = new Vector3(0, obj_c.transform.localScale.y / 2, 0);
                        obj_c.transform.position = new Vector3(0, obj_c.transform.position.y, 0);
                        Vector3 pos = Input.mousePosition;
                        pos.z = Camera.main.transform.position.y - obj_c.transform.position.y;
                        pos = Camera.main.ScreenToWorldPoint(pos);
                        obj_c.transform.position = pos;
                        obj = Instantiate(obj_c);

                        /* network */
                        Dictionary<string, string> senddata = new Dictionary<string, string>();
                        senddata.Add("obj_type", type.ToString());
                        senddata.Add("pos", obj.transform.position.ToString());
                        senddata.Add("dir", obj.transform.rotation.ToString());
                        senddata.Add("scale", obj.transform.localScale.ToString());

                        JSONObject jdata = new JSONObject(senddata);
                        Debug.Log(jdata);
                        if (SocketManage.id != null)
                            SocketManage.socket.Emit("MSGrequest_AddObj", jdata);
                        else {
                            GameObjectStructure.ObjList.Add(new GameObjectStructure(0, type, obj));
                        }
                        ObjClickControl.targetobj = obj;
                        ClickButtonCase.buttonkey = null;
                    }
                }
                ClickButtonCase.buttonkey = null;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            ClickButtonCase.buttonkey = null;
        }
    }
}
