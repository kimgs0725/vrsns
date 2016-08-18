using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SocketIO;
using UnityEngine.UI;

public class JoinScript : MonoBehaviour {
	//private SocketIOComponent socket;
	JSONObject jdata;

	void Start(){
		// go = GameObject.Find ("SocketIO");
		//socket = go.GetComponent<SocketIOComponent> ();

		SocketManage.socket.On ("MSGresponse_Join", serverMSG);
		//StartCoroutine ("SendTest");
	}
		
	public void serverMSG(SocketIOEvent e){
		Dictionary<string, string> data = e.data.ToDictionary ();
		string ret;
		data.TryGetValue ("ret", out ret);

		Debug.Log ("Client received MSG : " + ret);
	}

	/*private IEnumerator SendTest(){
		while (true) {
			yield return new WaitForSeconds (2);
			data.Add ("id", "admin");
			data.Add ("pwd", "1234");

			jdata = new JSONObject (data);
			socket.Emit ("MSGrequest_Join", jdata);
		}
	}*/

	public void joinBtn(){

        //Application.LoadLevel ("Login_Scene");
        //data.Add ("id", "admin");
        //data.Add ("pwd", "1234");

        //jdata = new JSONObject (data);
        //socket.Emit ("MSGrequest_Join", jdata);

        string idfield = GameObject.Find("ID_InputField_Join").GetComponent<InputField>().text;
        string pwdfield = GameObject.Find("Password_InputField_Join").GetComponent<InputField>().text;

        Debug.Log(idfield + ", " + pwdfield);

        Dictionary<string, string> senddata = new Dictionary<string, string>();
        senddata.Add("id", idfield);
        senddata.Add("pwd", pwdfield);

        jdata = new JSONObject(senddata);
        Debug.Log(jdata);
        SocketManage.socket.Emit("MSGrequest_Join", jdata);

        Application.LoadLevel("Login_Scene");
        //Application.UnloadLevel(1);
	}
}
