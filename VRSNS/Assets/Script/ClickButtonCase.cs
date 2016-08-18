using UnityEngine;
using System.Collections;

public class ClickButtonCase : MonoBehaviour {

    public static GameObject buttonkey;
    public static int type;

	// Use this for initialization
	void Start () {
        buttonkey = null;
	}

    public void OnButtonKeySet(GameObject preb, int type)
    {
        if (buttonkey != null) buttonkey = null;
        buttonkey = preb;
        ClickButtonCase.type = type;
        //Debug.Log(buttonkey);
    }
	
}
