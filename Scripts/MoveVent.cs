using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVent : MonoBehaviour
{
    public GameObject vent2;
    public GameObject trigger2;
    public GameObject vent;
    public GameObject trigger;
    public GameObject doll;
    public Light eyeL;
    public Light eyeR;
    public EnemyController enemy;

    private void OnTriggerEnter(Collider other)
    {
        vent.transform.position = new Vector3(vent2.transform.position.x, vent2.transform.position.y, vent2.transform.position.z + 19.454078f);
        trigger.transform.position = new Vector3(trigger2.transform.position.x, trigger2.transform.position.y, trigger2.transform.position.z + 19.454078f);
    }
}
