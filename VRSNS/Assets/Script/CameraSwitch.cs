using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {
    public GameObject vr_obj;
    public static GameObject vr_cam, vr_object;
    public GameObject main_obj;
    public static GameObject main_cam, main_object;
    public static bool is_already_button;
    void Start()
    {
        main_cam = GameObject.Find("Main Camera");
        vr_object = vr_obj;
        main_object = main_obj;
        is_already_button = true;
    }

    public static void ActiveMainCam()
    {
        main_cam = Instantiate(main_object) as GameObject;
        main_cam.transform.position = new Vector3(0.0f, 80.0f, 0.0f);
        Destroy(vr_cam);
        GameObject obj = GameObject.Find("EventSystem");
        Component.Destroy(obj.GetComponent<GazeInputModule>());
    }

    public static void ActiveVrCam()
    {
        GameObject obj = GameObject.Find("EventSystem");
        obj.AddComponent<GazeInputModule>();
        UnityEditorInternal.ComponentUtility.MoveComponentUp(obj.GetComponent<GazeInputModule>());
        vr_cam = Instantiate(vr_object) as GameObject;
        vr_cam.transform.position = new Vector3(0.0f, 12.0f, -1.72f);
        Destroy(main_cam);
    }
}
