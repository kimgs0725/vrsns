using UnityEngine;
using System.Collections;
using SocketIO;

public class SocketManage : MonoBehaviour
{

    // Use this for initialization
    public static SocketIOComponent socket;
    public static string id, roomId;
    public static bool backbtn;
    public static string friendid;

    void Start()
    {
        id = null;
        backbtn = false;
        friendid = null;
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
        SocketManage.socket.On("MSGresponse_ObjList", GameObjectStructure.addGameObjectList);
        SocketManage.socket.On("MSGresponse_FriendObjList", GameObjectStructure.addFriendGameObjectList);

    }

}