using UnityEngine;
using System.Collections;
using SocketIO;
using System.Collections.Generic;

public class GameObjectStructure : MonoBehaviour
{

    public int objid;
    public int objtype;
    public GameObject obj;

    public static ArrayList ObjList = new ArrayList();
    public static ArrayList friendObjList = new ArrayList();

    public GameObjectStructure(int objid, int objtype, GameObject obj)
    {
        this.objid = objid;
        this.objtype = objtype;
        this.obj = obj;
    }

    public static void release()
    {
        foreach(GameObjectStructure gbs in ObjList)
        {
            Destroy(gbs.obj.gameObject);
        }
        ObjList.Clear();
        foreach (GameObjectStructure gbs in friendObjList)
        {
            Destroy(gbs.obj.gameObject);
        }
        friendObjList.Clear();
    }

    public static void setGameObjectList(string id)
    {
        foreach (GameObjectStructure ge in ObjList)
        {
            Debug.Log("ge : " + ge.obj);
            Destroy(ge.obj);
        }
        ObjList.Clear();
        
        /* ask */
        Dictionary<string, string> senddata = new Dictionary<string, string>();
        senddata.Add("userId", id);
        JSONObject jdata = new JSONObject(senddata);
        Debug.Log(jdata);
        SocketManage.socket.Emit("MSGrequest_ObjList", jdata);
    }

    public static void addGameObjectList(SocketIOEvent e)
    {
        Debug.Log("addGameObjectList");
        string tmp;
        GameObject obj_c = null;
        int obj_id;
        int obj_type;
        Vector3 pos;
        Quaternion dir;
        Vector3 scale;
        Dictionary<string, string> data = e.data.ToDictionary();
        data.TryGetValue("obj_id", out tmp);
        obj_id = int.Parse(tmp);
        data.TryGetValue("obj_type", out tmp);
        obj_type = int.Parse(tmp);
        data.TryGetValue("pos", out tmp);
        pos = ManageScript.Vector3FromString(tmp);
        data.TryGetValue("dir", out tmp);
        dir = ManageScript.QuaternionFromString(tmp);
        data.TryGetValue("scale", out tmp);
        scale = ManageScript.Vector3FromString(tmp);

        foreach (ButtonObjectStructure obj in ButtonObjectStructure.ButtenList)
        {
            if (obj.objID == obj_type)
            {
                Debug.Log("OBJ Search");
                //obj_c = Instantiate(obj.prefab,pos, obj.transform.rotation)as GameObject;
                obj_c = Instantiate(obj.prefab, pos, obj.prefab.transform.rotation) as GameObject;
                //Debug.Log("Prefab rotate : " + obj.prefab.transform.rotation);
                break;
            }
        }
        obj_c.transform.position = pos;
        obj_c.transform.rotation = dir;
        //Debug.Log("OBJINT rotate : " + obj_c.transform.rotation);
        obj_c.transform.localScale = scale;
        ObjList.Add(new GameObjectStructure(obj_id, obj_type, obj_c));

        Debug.Log("Client received MSG : " + obj_id + ", " + obj_type + ", " + pos + ", " + dir + ", " + scale);

    }


    public static void setFriendGameObjectList(string id)
    {
        
        friendObjList.Clear();
        
        /* ask */
        Dictionary<string, string> senddata = new Dictionary<string, string>();
        senddata.Add("userId", id);
        JSONObject jdata = new JSONObject(senddata);
        Debug.Log(jdata);
        SocketManage.socket.Emit("MSGrequest_FriendObjList", jdata);
    }

    public static void addFriendGameObjectList(SocketIOEvent e)
    {
        Debug.Log("addGameObjectList");
        string tmp;
        GameObject obj_c = null;
        int obj_id;
        int obj_type;
        Vector3 pos;
        Quaternion dir;
        Vector3 scale;
        Dictionary<string, string> data = e.data.ToDictionary();
        data.TryGetValue("obj_id", out tmp);
        obj_id = int.Parse(tmp);
        data.TryGetValue("obj_type", out tmp);
        obj_type = int.Parse(tmp);
        data.TryGetValue("pos", out tmp);
        pos = ManageScript.Vector3FromString(tmp);
        data.TryGetValue("dir", out tmp);
        dir = ManageScript.QuaternionFromString(tmp);
        data.TryGetValue("scale", out tmp);
        scale = ManageScript.Vector3FromString(tmp);

        foreach (ButtonObjectStructure obj in ButtonObjectStructure.ButtenList)
        {
            if (obj.objID == obj_type)
            {
                Debug.Log("OBJ Search");
                //obj_c = Instantiate(obj.prefab,pos, obj.transform.rotation)as GameObject;
                obj_c = Instantiate(obj.prefab, pos, obj.prefab.transform.rotation) as GameObject;
                //Debug.Log("Prefab rotate : " + obj.prefab.transform.rotation);
                break;
            }
        }
        obj_c.transform.position = pos;
        obj_c.transform.rotation = dir;
        //Debug.Log("OBJINT rotate : " + obj_c.transform.rotation);
        obj_c.transform.localScale = scale;
        friendObjList.Add(new GameObjectStructure(obj_id, obj_type, obj_c));

        Debug.Log("Client received MSG : " + obj_id + ", " + obj_type + ", " + pos + ", " + dir + ", " + scale);

    }
}

