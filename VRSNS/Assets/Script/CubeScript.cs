using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeScript : MonoBehaviour{
	private bool move;
    private Vector3 V3;
	//void Start () {
	//	move = false;
	//	StartCoroutine (testRoutine ());
 //       StartCoroutine (sendRoutine ());
	//}

  //  public void SetMove(){
		//move = !move;
		//Dictionary<string, string> data = new Dictionary<string, string> ();
		//data.Add ("pos", transform.position.ToString ());
		//if (move == false) 
		//	data.Add ("vec", new Vector3(0,0,0).ToString());
		//else 
		//	data.Add ("vec", transform.forward.ToString ());
		//ManageScript.sendMsg("MSGrequest_MoveUser", new JSONObject(data));
	//}

	//IEnumerator testRoutine(){
	//	Vector3 vec = transform.forward;
	//	while (true) {
 //           if (move)
 //           {
 //               transform.position += vec * 0.1f;
 //           }
 //           else
 //           {
 //               vec = transform.forward;
 //               vec.y = 0;
 //           }
 //           yield return null;
 //           if (move)
 //           {
 //               Debug.Log("testRoutine");
 //               vec = transform.forward;
 //               vec.y = 0;
 //               transform.position += (vec * 0.5f);
                
 //               yield return null;
 //           }
 //           yield return null;
 //       }
	//}

    //IEnumerator sendRoutine()
    //{
    //    while (true)
    //    {
    //        Dictionary<string, string> data = new Dictionary<string, string>();
    //        data.Add("pos", transform.position.ToString());
    //        //ManageScript.sendMsg("MSGrequest_MoveUser", new JSONObject(data));
    //        SocketManage.socket.Emit("MSGrequest_MoveUser", new JSONObject(data));
    //        Debug.Log("SendRoutine");
    //        yield return new WaitForSeconds(0.01f);
    //    }
    //    //StartCoroutine(sendRoutine());
    //}
}
