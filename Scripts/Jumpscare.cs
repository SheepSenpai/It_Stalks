using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public GameObject death;
    public GameObject player;
    public GameObject doll;
    public AudioSource jump;
    public PlayerController playerc;
    public EnemyController enemy;
    bool jumpscare = true;

    private void OnTriggerEnter(Collider other)
    {
        if (jumpscare == true)
        {
            playerc.deathsound.Stop();
            playerc.battery = 0.5f;
            playerc.flashlight.color = Color.red;
            enemy.timertga = 0;
            player.transform.localPosition = new Vector3(6.83f, 0.91f, -10f);
            if (jump.isPlaying == false)
            {
                jump.Play();
            }
            playerc.crawl.Stop();
            playerc.canMove = false;
            playerc.batterybarObject.SetActive(false);
            playerc.batterybuttonObject.SetActive(false);
            playerc.batterysoundObject.SetActive(false);
            playerc.pausebuttonObject.SetActive(false);
            playerc.flashbuttonObject.SetActive(false);
            StartCoroutine(Wait());
            jumpscare = false;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        death.SetActive(true);
    }
}
