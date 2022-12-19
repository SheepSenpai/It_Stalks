using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Flashlight : MonoBehaviour
{
    public bool flashlightOn = true;
    public PlayerController player;
    public GameObject flickerPlayer;
    public AudioSource sound;
    public AudioSource charging;
    public AudioSource flicker;
    public bool charge = false;


    [SerializeField] GameObject flash;

    private void Update()
    {

        if (player.battery <= 0)
        {
            if (flicker.isPlaying == false)
            {
                StartCoroutine(Sound());
            }
            flashlightOn = false;
            flash.SetActive(false);
        }
        else
        {
            flickerPlayer.SetActive(true);
        }
    }

    public void OnToggleButtonClick()
    {
        if (player.battery > 0)
        {
            flashlightOn = !flashlightOn;
            if (flashlightOn == false)
            {
                sound.Play();
                flash.SetActive(false);
            }
            else
            {
                sound.Play();
                flash.SetActive(true);
            }
        }
    }

    IEnumerator Sound()
    {
        flicker.Play();
        yield return new WaitForSeconds(2);
        flickerPlayer.SetActive(false);
    }


    public void Buttondown()
    {
        charging.Play();
        sound.Play();
        flashlightOn = true;
        flash.SetActive(false);
        player.canMove = false;
        player.moving = false;
        charge = true;
    }

    public void Buttonup()
    {
        sound.Play();
        charging.Stop();
        flashlightOn = true;
        flash.SetActive(true);
        player.canMove = true;
        charge = false;
    }
}
