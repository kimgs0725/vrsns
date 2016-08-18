using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OBJRotate : MonoBehaviour {
    public GameObject targetobj;
    // Use this for initialization
    void Start () {
	
	}

    public void targetObjRotate() {
        targetobj = ObjClickControl.targetobj;
        if (targetobj == null) return;
        Debug.Log("Rotate");
        Vector3 rotate_vector = targetobj.GetComponent<ComponentMovement>().rotate_vector;
        targetobj.transform.Rotate(rotate_vector.x, rotate_vector.y, rotate_vector.z);
        Dictionary<string, string> senddata = new Dictionary<string, string>();
        senddata.Add("pos", targetobj.transform.position.ToString());
        senddata.Add("dir", targetobj.transform.rotation.ToString());
        foreach (object obj in GameObjectStructure.ObjList)
        {
            if (((GameObjectStructure)obj).obj.Equals(targetobj))
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

}
