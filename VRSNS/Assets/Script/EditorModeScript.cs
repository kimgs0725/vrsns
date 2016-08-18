using UnityEngine;
using System.Collections;

public class EditorModeScript : MonoBehaviour {
    // Use this for initialization
	void Start () {
        /*foreach (GameObjectStructure ge in GameObjectStructure.friendObjList)
        {
            Debug.Log("ge : " + ge.obj);
            Destroy(ge.obj);
        }
        GameObjectStructure.friendObjList.Clear(); */
        Camera.main.transform.position = new Vector3(0, 80, 0);
        if (SocketManage.id != null)
        {
            GameObjectStructure.release();
            GameObjectStructure.setGameObjectList(SocketManage.id);
        }
    }
    void Update()
    {
        if ((Application.platform == RuntimePlatform.Android && Input.GetKey(KeyCode.Escape)) || Input.GetKey(KeyCode.UpArrow))
        {
            Application.Quit();
        }
    }
}
