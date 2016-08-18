using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using SocketIO;

public class LoginScript : MonoBehaviour {
    private int unregister_btn = 0;
    private int login_btn = 0;
    private int join_btn = 0;
    private string id;
  
    // Use this for initialization
    void Start() {         
		SocketManage.socket.On ("MSGresponse_Login", loginMSG);
    }

    public void loginMSG(SocketIOEvent e)
    {
        Dictionary<string, string> data = e.data.ToDictionary();
        string ret;
        data.TryGetValue("ret", out ret);

        Debug.Log("Client received MSG : " + ret);
        if (ret.Equals("1"))
        {
            /* sence change */
            GameObject[] Objects = GameObject.FindGameObjectsWithTag("Socket");
            SocketManage.id = id;
            foreach (GameObject obj in Objects)
            {
                Object.DontDestroyOnLoad(obj);
            }
            Application.LoadLevel("EditorMode");
        }
    }

    public void unregisterBtn(){
		Debug.Log ("unregister Mode : " + unregister_btn);
		unregister_btn++;
        Application.LoadLevel("EditorMode");
    }

	public void loginBtn(){
		Debug.Log ("login Mode : " + login_btn);
		login_btn++;
        string idfield = GameObject.Find("ID_InputField_Join").GetComponent<InputField>().text;
        string pwdfield = GameObject.Find("Password_InputField_Join").GetComponent<InputField>().text;

        Debug.Log(idfield + ", " + pwdfield);

        Dictionary<string, string> senddata = new Dictionary<string, string>();
        senddata.Add("id", idfield);
        senddata.Add("pwd", pwdfield);
        id = idfield;

        JSONObject jdata = new JSONObject(senddata);
        Debug.Log(jdata);
        SocketManage.socket.Emit("MSGrequest_Login", jdata);

    }

	public void joinBtn(){
        GameObject[] Objects = GameObject.FindGameObjectsWithTag("Socket");
        foreach (GameObject obj in Objects)
        {
            Object.DontDestroyOnLoad(obj);
        }
        Application.LoadLevel ("Join_Scene");
        //Application.LoadLevelAdditive("Join_Scene");
	}
}
