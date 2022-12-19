using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMonster : MonoBehaviour
{
    public GameObject trigger;
    public GameObject doll;
    public Light eyeL;
    public Light eyeR;
    public EnemyController enemy;

    private void OnTriggerEnter(Collider other)
    {
        trigger.transform.position = new Vector3(trigger.transform.position.x, trigger.transform.position.y, trigger.transform.position.z + 13f);
        doll.transform.position = new Vector3(doll.transform.position.x, doll.transform.position.y, doll.transform.position.z + 13f);
        doll.SetActive(true);
        enemy.SetAggresivity();
        enemy.Spawn();
    }
}
