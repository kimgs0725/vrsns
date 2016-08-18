using UnityEngine;
using System.Collections;

public class ObjClickControl : MonoBehaviour {

    public static GameObject targetobj;

	// Use this for initialization
	void Start () {
        targetobj = null;
    }
	
	// Update is called once per frame
	void Update () {
        bool check = false;
        if (Input.GetMouseButtonDown(0))
        {
            if (UIPointer.IsPointerOverUIObject())
            {
                Debug.Log("UI Collid");
                return;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //Debug.Log("Hit! : " + hit.transform.gameObject);
                foreach (GameObjectStructure obj in GameObjectStructure.ObjList)
                {

                    if (obj.obj.Equals(hit.transform.gameObject))
                    {
                        check = true;
                        targetobj = hit.transform.gameObject;
                        Debug.Log("Hit! : " + hit.transform.gameObject);
                        break;
                    }
                }
                if(!check)
                {
                    targetobj = null;
                }
                
            }
        }
        

    }
}
