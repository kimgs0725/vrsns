using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SocketIO;

public class ManageScript : MonoBehaviour {
	//public static SocketIOComponent socket;
	Dictionary<string, GameObject> id_list;
	Dictionary<string, Vector3> id_move;
	public GameObject otherPlayer;
    void Start () {
		//GameObject go = GameObject.Find ("SocketIO");
		//socket = go.GetComponent<SocketIOComponent> ();

		SocketManage.socket.On ("MSGresponse_NewUser", onNewUser);
		SocketManage.socket.On ("MSGresponse_Vector", onVector);
		SocketManage.socket.On ("MSGresponse_Disconnect", onDisconnect);

		id_list = new Dictionary<string, GameObject> ();
        //id_move = new Dictionary<string, Vector3>();
        //transform.position = new Vector3(transform.position.x, 13.05f, transform.position.z);
        Debug.Log("Manage ");
	}

	private void onNewUser(SocketIOEvent e){
		Dictionary<string, string> data = e.data.ToDictionary ();
		string id;
		data.TryGetValue ("id", out id);
        id_list.Add(id, null);
		id_list[id] = Instantiate (otherPlayer) as GameObject;
        id_list[id].transform.position = new Vector3(0f, 0.5f, 0f);
        //id_list.Add (id, otherPlayer.transform);
        //id_move.Add(id, new Vector3(0, 0, 0));
        Debug.Log("onNewUser");
	}

	private void onVector(SocketIOEvent e){
        //Dictionary<string,  string> data = e.data.ToDictionary ();
        //string id, pos, vec;
        //data.TryGetValue ("id", out id);
        //data.TryGetValue ("pos", out pos);
        //data.TryGetValue ("vec", out vec);
        //Vector3 pos_v = Vector3FromString (pos);
        //Vector3 vec_v = Vector3FromString (vec);
        //id_move [id] = vec_v;
        Dictionary<string, string> data = e.data.ToDictionary();
        string id, pos, vec;
        data.TryGetValue("id", out id);
        data.TryGetValue("pos", out pos);
        data.TryGetValue("vec", out vec);
        Vector3 pos_v = Vector3FromString(pos);
        Quaternion vec_v = QuaternionFromString(vec);
        id_list[id].transform.position = pos_v;
        id_list[id].transform.rotation = vec_v;
        Debug.Log("vec : " + vec_v);
    }

	private void onDisconnect(SocketIOEvent e){
		Dictionary<string, string> data = e.data.ToDictionary ();
		string id;
		data.TryGetValue ("id", out id);
		Destroy (id_list[id]);
		id_list.Remove (id);
        //id_move.Remove (id);
	}

    // Update is called once per frame
    void Update()
    {
        if(((Application.platform == RuntimePlatform.Android)&& Input.GetKey(KeyCode.Escape))||Input.GetKey(KeyCode.UpArrow))
        {
            //if (Input.GetKey(KeyCode.Escape))
            //{
                SocketManage.backbtn = true;
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("id", SocketManage.roomId);
                SocketManage.socket.Emit("MSGrequest_ExitRoom", new JSONObject(data));
            /*GameObject[] etcObjects = GameObject.FindGameObjectsWithTag("ETC");
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
            }*/

            /////////////////////////////////////////////////////////////////////////////////
            //if (SocketManage.id != null)
            //    GameObjectStructure.release();
            //else {
            //    GameObject[] etcObjects = GameObject.FindGameObjectsWithTag("ETC");
            //    GameObject[] floorObjects = GameObject.FindGameObjectsWithTag("Floor");
            //    GameObject[] funObjects = GameObject.FindGameObjectsWithTag("Funiture");
            //    foreach (GameObject obj in etcObjects)
            //    {
            //        Object.DontDestroyOnLoad(obj);
            //    }
            //    foreach (GameObject obj in floorObjects)
            //    {
            //        Object.DontDestroyOnLoad(obj);
            //    }
            //    foreach (GameObject obj in funObjects)
            //    {
            //        Object.DontDestroyOnLoad(obj);
            //    }
            //}
            //    GameObject[] Objects = GameObject.FindGameObjectsWithTag("Socket");
            //    foreach (GameObject obj in Objects)
            //    {
            //        Object.DontDestroyOnLoad(obj);
            //    }
            //    Application.LoadLevel("EditorMode");
            //////////////////////////////////////////////////////////////////////////////

            //}
            CameraSwitch.ActiveMainCam();
        }
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    Application.UnloadLevel(3);
        //}
    }

    public static Vector3 Vector3FromString(string s){
		s = s.Substring (1, s.Length - 2);
		string[] parts = s.Split (new string[] { "," }, System.StringSplitOptions.None);
		return new Vector3 (
			float.Parse (parts [0]),
			float.Parse (parts [1]),
			float.Parse (parts [2]));
	}

    public static Quaternion QuaternionFromString(string s)
    {
        s = s.Substring(1, s.Length - 2);
        string[] parts = s.Split(new string[] { "," }, System.StringSplitOptions.None);
        return new Quaternion(
            float.Parse(parts[0]),
            float.Parse(parts[1]),
            float.Parse(parts[2]),
            float.Parse(parts[3])
        );
    }

	public static void sendMsg(string packetName, JSONObject jdata){
		//socket.Emit (packetName, jdata);
	}
}
