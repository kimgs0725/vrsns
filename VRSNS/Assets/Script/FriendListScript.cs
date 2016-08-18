using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FriendListScript : MonoBehaviour {

    // Use this for initialization
    public GameObject prefab_button;
    public GameObject OBJparent;
    void Start() {
        GameObject pre;
        //get list from network
        gameObject.SetActive(false);
        if (SocketManage.id == null) return;
        pre = Instantiate(prefab_button);
        pre.transform.parent = OBJparent.transform;
        pre.GetComponentInChildren<Text>().text = "abc";
        pre.transform.localPosition = new Vector3(pre.transform.position.x, pre.transform.position.y, 0f);
        pre.transform.localScale = new Vector3(1, 1, 1);
        pre.transform.localRotation = Quaternion.Euler(0, 0, 0);
        Button btn = pre.GetComponent<Button>();
        btn.onClick.AddListener(() => visit_friend(pre.GetComponentInChildren<Text>().text));
    }

    public void print(string str) {
        Debug.Log(str);
    }

    public void visit_friend(string id)
    {

        GameObjectStructure.release();
        GameObjectStructure.setFriendGameObjectList(id);
        // 배치 & friendlist setting ?? 약간 텀을 줘야하지 않나? 친구 id로부터 받아오는 시간이 있는데....
        GameObject[] etcObjects = GameObject.FindGameObjectsWithTag("ETC");
        GameObject[] floorObjects = GameObject.FindGameObjectsWithTag("Floor");
        GameObject[] funObjects = GameObject.FindGameObjectsWithTag("Funiture");
        foreach (GameObject obj in etcObjects)
        {
            Object.DontDestroyOnLoad(obj);
        }
        foreach (GameObject obj in floorObjects)
        {
            Object.DontDestroyOnLoad(obj);
        }
        foreach (GameObject obj in funObjects)
        {
            Object.DontDestroyOnLoad(obj);
        }
        GameObject[] Objects = GameObject.FindGameObjectsWithTag("Socket");
        foreach (GameObject obj in Objects)
        {
            Object.DontDestroyOnLoad(obj);
        }
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("id", id);
        SocketManage.roomId = id;
        SocketManage.socket.Emit("MSGrequest_EnterRoom", new JSONObject(data));
        //Application.LoadLevel("VRMode");
        CameraSwitch.ActiveVrCam();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
