using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        float scale_y = gameObject.transform.localScale.y;
        Vector3 pos = new Vector3(0, scale_y / 2, 0);
        gameObject.transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
