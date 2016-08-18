using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraScript : MonoBehaviour {
	//public GameObject cube;
	public GameObject sp;
    public GameObject camera;
	private float sp_y;
	private float dis;
    private bool move;
    private Vector3 V3;
    //private Vector3 offset;
    //private Vector3 previous;
    void Start(){
		sp_y = sp.transform.position.y;
		dis = Vector3.Distance(transform.position ,sp.transform.position);
        //offset = transform.position - cube.transform.position;
        move = false;
        StartCoroutine(testRoutine());
        StartCoroutine(sendRoutine());
    }

    public void SetMove()
    {
        move = !move;
        //Dictionary<string, string> data = new Dictionary<string, string> ();
        //data.Add ("pos", transform.position.ToString ());
        //if (move == false) 
        //	data.Add ("vec", new Vector3(0,0,0).ToString());
        //else 
        //	data.Add ("vec", transform.forward.ToString ());
        //ManageScript.sendMsg("MSGrequest_MoveUser", new JSONObject(data));
    }

    void Update(){
        //Vector3 vec = transform.forward.normalized * dis + transform.position;
        Vector3 vec = camera.transform.forward.normalized * dis + transform.position;
		sp.transform.position = new Vector3(vec.x, sp_y, vec.z);
        //Vector3 cube_direction = new Vector3(sp.transform.position.x, cube.transform.position.y, sp.transform.position.z);
        //cube.transform.LookAt(cube_direction);

        //Vector3 forward = transform.forward;
        //cube.transform.TransformDirection(forward);
        //Debug.Log(forward);

        //Debug.Log("V3 vertical : " + V3);
        //Debug.Log("rotation : " + camera.transform.rotation);
        //Debug.Log("qu.x=" + camera.transform.rotation.x +
        //          "qu.y=" + camera.transform.rotation.y +
        //          "qu.z=" + camera.transform.rotation.z +
        //          "qu.w=" + camera.transform.rotation.w);

    }

    //void LateUpdate(){
    //	transform.position = cube.transform.position + offset;
    //}

    IEnumerator testRoutine()
    {
        Vector3 vec = transform.forward;
        while (true)
        {
            //if (move) {
            //	transform.position += vec * 0.1f;
            //} else {
            //	vec = transform.forward;
            //	vec.y = 0;
            //}
            //yield return null;
            if (move)
            {
                //Debug.Log("testRoutine");
                vec = camera.transform.forward;
                
                vec.y = 0;
                transform.position += (vec * 2.0f);
                //Debug.Log("transform.position.y : " + transform.position.y);
                yield return null;
            }
            yield return null;
        }
    }

    IEnumerator sendRoutine()
    {
        while (true)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("pos", transform.position.ToString());
            //Vector3 angle = transform.eulerAngles;
            //angle.x = angle.z = 0;
            //data.Add("vec", angle.ToString());
            Quaternion angle = camera.transform.rotation;
            angle.x = angle.z = 0;
            data.Add("vec", angle.ToString());
            SocketManage.socket.Emit("MSGrequest_MoveUser", new JSONObject(data));
            yield return new WaitForSeconds(0.01f);
        }
    }
}
