using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Button_VR : MonoBehaviour {

    // Use this for initialization
    
    // Update is called once per frame
    public void Button_VR_Switch() {

        //GameObject[] etcObjects = GameObject.FindGameObjectsWithTag("ETC");
        //GameObject[] floorObjects = GameObject.FindGameObjectsWithTag("Floor");
        //GameObject[] funObjects = GameObject.FindGameObjectsWithTag("Funiture");
        //foreach (GameObject obj in etcObjects)
        //{
        //    Object.DontDestroyOnLoad(obj);
        //}
        //foreach (GameObject obj in floorObjects)
        //{
        //    Object.DontDestroyOnLoad(obj);
        //}
        //foreach (GameObject obj in funObjects)
        //{
        //    Object.DontDestroyOnLoad(obj);
        //}
        //GameObject[] Objects = GameObject.FindGameObjectsWithTag("Socket");
        //foreach (GameObject obj in Objects)
        //{
        //    Object.DontDestroyOnLoad(obj);
        //}
        //Dictionary<string, string> data = new Dictionary<string, string>();
        //data.Add("id", SocketManage.id);
        //SocketManage.roomId = SocketManage.id;
        //SocketManage.socket.Emit("MSGrequest_EnterRoom", new JSONObject(data));
        //Application.LoadLevel("VRMode");

        //Application.LoadLevelAdditive(3);
        CameraSwitch.ActiveVrCam();
    }
}
