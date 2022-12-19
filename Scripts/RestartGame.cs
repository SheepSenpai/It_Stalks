using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public Animator transition;

    [System.Obsolete]
    public void RestartGameMethod()
    {
        Time.timeScale = 1f;
        StartCoroutine(RestartLevel());
    }

    [System.Obsolete]
    IEnumerator RestartLevel()
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(1);

        Application.LoadLevel(Application.loadedLevel);
    }
}
