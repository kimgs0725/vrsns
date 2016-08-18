using UnityEngine;
using System.Collections;

public class Button_Friend : MonoBehaviour {

    bool toggle;
    public GameObject friend_panel;
    void Start()
    {
        toggle = false;
    }
    public void Button_Friend_OnOff()
    {
        if (toggle) {
            friend_panel.SetActive(false);
            toggle = false;
        }
        else {
            friend_panel.SetActive(true);
            toggle = true;
        }

    }

}
