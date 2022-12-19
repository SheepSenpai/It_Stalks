using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVent2 : MonoBehaviour
{
    public GameObject vent2;
    public GameObject trigger2;
    public GameObject vent;
    public GameObject doll;
    public Light eyeL;
    public Light eyeR;
    public GameObject trigger;
    public EnemyController enemy;

    private void OnTriggerEnter(Collider other)
    {
        vent2.transform.position = new Vector3(vent.transform.position.x, vent.transform.position.y, vent.transform.position.z + 19.454078f);
        trigger2.transform.position = new Vector3(trigger.transform.position.x, trigger.transform.position.y, trigger.transform.position.z + 19.454078f);
    }
}
