using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button_List : MonoBehaviour {

    public GameObject prefab_button;
    // Use this for initialization
    void Start () {
        if (!CameraSwitch.is_already_button)
            ButtonObjectStructure.init();
        foreach (object obj in ButtonObjectStructure.ButtenList)
        {
            GameObject pre;
            ButtonObjectStructure gbs = (ButtonObjectStructure)obj;
            pre = Instantiate(prefab_button);
            pre.transform.parent = transform.Find("Tab_Table_" + gbs.tab + "/content/Virtical_Scroll_Button/Layout_Image").gameObject.transform;
            pre.transform.localPosition = new Vector3(pre.transform.position.x, pre.transform.position.y, 0f);
            pre.transform.localScale = new Vector3(1, 1, 1);
            pre.transform.localRotation = Quaternion.Euler(0, 0, 0);
            pre.GetComponentInChildren<Text>().text = gbs.name;
            Button btn = pre.GetComponent<Button>();
            Debug.Log(gbs.prefab);
            btn.onClick.AddListener(() => GameObject.Find("Obj_Button_Control").GetComponent<ClickButtonCase>().OnButtonKeySet(gbs.prefab, gbs.objID));
        }
	}
	
}
