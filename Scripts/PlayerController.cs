using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Light flashlight;
    public Camera maincam;
    public bool moving = false;

    public Animator transition;
    public GameObject death;
    public GameObject player;
    public GameObject doll;
    public AudioSource jump;
    public AudioSource heart;
    bool jumpscare = true;
    public bool gamepaused = false;

    float timeSurvived;
    public TextMeshProUGUI timeText;
    int distance = 0;

    public GameObject batterybuttonObject;
    public GameObject batterysoundObject;
    public GameObject batterybarObject;
    public GameObject flashbuttonObject;
    public GameObject pausebuttonObject;
    public EnemyController enemy;

    public float walkingBobbingSpeed = 14f;
    public float bobbingAmount = 0.05f;

    float defaultPosY = 0;
    float timer = 0;

    public float deathtimer = 0;
    readonly float delayAmount = 2;

    public AudioSource deathsound;
    public AudioSource crawl;

    public float battery = 1;
    public Image bar;
    float battimer;
    readonly float batdelay = 0.05f;

    public Flashlight flash;

    public bool canMove = true;

    public void Pausegame()
    {
        gamepaused = !gamepaused;
        deathtimer = 0;
        crawl.Stop();
        deathsound.Stop();
        moving = true;
    }


    void Start()
    {
        defaultPosY = maincam.transform.localPosition.y;
    }

    void Update()
    {
        bar.rectTransform.sizeDelta = new Vector2(59.21f, 1024 * battery);
        deathtimer += Time.deltaTime;
        timeSurvived += Time.deltaTime;
        battimer += Time.deltaTime;
        timeText.text = distance.ToString();


        if (gamepaused == false)
        {
            if (flash.charge == false)
            {
                if (battery > 0f)
                {
                    if (flash.flashlightOn == true)
                    {
                        if (battimer >= batdelay)
                        {
                            battimer = 0;
                            battery -= 0.007f;
                        }
                    }

                }
            }
            else
            {
                if (flash.flashlightOn == true)
                {
                    if (battery < 1)
                    {
                        if (battimer >= batdelay)
                        {
                            battimer = 0;
                            battery += 0.006f;
                        }
                    }
                }
            }

            if (Input.touchCount == 1)
            {

            Touch touch = Input.GetTouch(0);
                if (canMove == true)
                {
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        if (timeSurvived >= delayAmount)
                        {
                            timeSurvived = 0f;
                            distance++;
                        }
                        if (crawl.isPlaying == false)
                        {
                            crawl.Play();
                        }
                        deathsound.Stop();
                        deathtimer = 0;
                        moving = true;
                        if (moving == true)
                        {
                            transition.SetBool("IsMoving", moving);
                            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.0325f);
                            flashlight.transform.rotation = new Quaternion(0.2f, 0f, 0f, 1f);

                            timer += Time.deltaTime * walkingBobbingSpeed;
                            maincam.transform.localPosition = new Vector3(maincam.transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobbingAmount, maincam.transform.localPosition.z);
                        }
                    }
                    else
                    {
                        if (deathsound.isPlaying == false)
                        {
                            deathsound.Play();
                        }
                        moving = false;
                        if (moving == false)
                        {
                            crawl.Stop();
                            transition.SetBool("IsMoving", moving);
                            flashlight.transform.rotation = new Quaternion(0f, 0f, 0f, 1f);
                        }

                        timer = Mathf.PI / 2; //reinitialize

                        timer = 0;
                        maincam.transform.localPosition = new Vector3(maincam.transform.localPosition.x, Mathf.Lerp(maincam.transform.localPosition.y, defaultPosY, Time.deltaTime * walkingBobbingSpeed), maincam.transform.localPosition.z);
                    }
                }
            }
            else
            {
                if (deathsound.isPlaying == false)
                {
                    deathsound.Play();
                }
                moving = false;
                crawl.Stop();
                transition.SetBool("IsMoving", moving);
                flashlight.transform.rotation = new Quaternion(0f, 0f, 0f, 1f);
            }
            if (deathtimer >= 5.745)
            {
                enemy.timertga = 0;
                deathsound.Stop();
                battery = 0.5f;
                flashlight.color = Color.red;
                if (jumpscare == true)
                {
                    if (jump.isPlaying == false)
                    {
                        jump.Play();
                    }
                    player.transform.localPosition = new Vector3(6.83f, 0.91f, -10f);
                    batterybarObject.SetActive(false);
                    batterybuttonObject.SetActive(false);
                    batterysoundObject.SetActive(false);
                    pausebuttonObject.SetActive(false);
                    flashbuttonObject.SetActive(false);
                    canMove = false;
                    crawl.Stop();
                    StartCoroutine(Wait());
                    jumpscare = false;
                }
            }

            if (timer > Mathf.PI * 2) //completed a full cycle on the unit circle. Reset to 0 to avoid bloated values.
                timer = 0;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        death.SetActive(true);
    }
}
