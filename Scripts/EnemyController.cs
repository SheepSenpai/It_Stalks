using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Light eyeL;
    public Light eyeR;
    public Flashlight flashlight;
    public PlayerController player;
    public GameObject playermodel;
    public GameObject doll;
    public float timertga;
    public bool Aggresiv;
    public float timerd;
    float difficulty = 3;
    public GameObject death;
    public GameObject stat;
    public AudioSource statsound;
    public AudioSource jump;
    int aggresivity;
    int spawn;
    public bool check = false;
    bool jumpscare = true;

    // Start is called before the first frame update
    void Start()
    {
        SetAggresivity();
        Spawn();
    }

    public void SetAggresivity()
    {
        spawn = Random.Range(1, 3);
        if (spawn == 1)
        {
            doll.SetActive(true);
        }
        else
        {
            doll.SetActive(false);
        }
    }

    public void Spawn()
    {
        aggresivity = Random.Range(1, 3);
        if (aggresivity == 1)
        {
            Aggresiv = true;
            eyeL.color = Color.red;
            eyeR.color = Color.red;
        }
        else
        {
            Aggresiv = false;
            eyeR.color = Color.blue;
            eyeL.color = Color.blue;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (player.gamepaused == false)
        {

            if (check == true)
            {
                timertga += Time.deltaTime;
                timerd += Time.deltaTime;

                if (player.moving == false)
                {
                    if (Aggresiv == true)
                    {
                        if (flashlight.flashlightOn == false)
                        {
                            if (timertga >= 1)
                            {
                                if (check == true)
                                {
                                    if (difficulty != 1.5)
                                    {
                                        difficulty -= 0.1f;
                                    }
                                    StartCoroutine(StatEnable());
                                }
                                check = false;
                            }
                        }
                        else
                        {
                            timertga = 0;
                        }
                    }
                    if (Aggresiv == false)
                    {
                        if (flashlight.flashlightOn == true)
                        {
                            if (timertga >= 1)
                            {
                                if (check == true)
                                {
                                    if (difficulty != 1.5)
                                    {
                                        difficulty -= 0.1f;
                                    }
                                    StartCoroutine(StatEnable());
                                }
                                check = false;
                            }
                        }
                        else
                        {
                            timertga = 0;
                        }
                    }
                }
                else
                {
                    timertga = 0;
                }
                if (timerd >= difficulty)
                {
                    timertga = 0;
                    player.battery = 0.5f;
                    player.flashlight.color = Color.red;
                    player.deathsound.Stop();
                    if (jumpscare == true)
                    {
                        if (jump.isPlaying == false)
                        {
                            jump.Play();
                        }
                        player.transform.localPosition = new Vector3(6.83f, 0.91f, -10f);
                        player.canMove = false;
                        player.crawl.Stop();
                        player.batterybarObject.SetActive(false);
                        player.batterybuttonObject.SetActive(false);
                        player.batterysoundObject.SetActive(false);
                        player.pausebuttonObject.SetActive(false);
                        player.flashbuttonObject.SetActive(false);
                        StartCoroutine(Wait());
                        jumpscare = false;
                    }
                }
            }
            else
            {
                timerd = 0;
                timertga = 0;
            }
        }else
        {
            timerd = 0;
            timertga = 0;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        check = true;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        death.SetActive(true);
        
    }

    IEnumerator StatEnable()
    {
        stat.SetActive(true);
        statsound.Play();
        yield return new WaitForSeconds(0.5f);
        stat.SetActive(false);
        doll.SetActive(false);
    }
}
