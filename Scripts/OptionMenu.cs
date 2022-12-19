using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject flashlight;
    public GameObject power;
    bool enable = false;
    bool disable = true;

    public void EnableDisable()
    {
        enable = !enable;
        Menu.SetActive(enable);

        disable = !disable;
        flashlight.SetActive(disable);
        power.SetActive(disable);
    }
}
